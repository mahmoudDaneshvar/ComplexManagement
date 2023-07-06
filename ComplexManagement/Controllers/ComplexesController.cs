using ComplexManagement.Context;
using ComplexManagement.Dto.Complexes;
using ComplexManagement.Entities;
using ComplexManagement.Exceptions.Complex;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ComplexManagement.Controllers
{
    [Route("complexes")]
    [ApiController]
    public class ComplexesController : Controller
    {
        private readonly ComplexDBContext _context;
        public ComplexesController(ComplexDBContext context)
        {
            _context = context;
        }

        [HttpPost]

        public void Add([FromBody] AddComplexDto dto)
        {
            if (_context.Complexes
                .Any(_ => _.Name == dto.Name))
            {
                throw new DuplicateComplexNameException();
            }

            var complex = new Complex
            {
                Name = dto.Name,
                UnitCount = dto.UnitCount,
            };

            _context.Complexes.Add(complex);
            _context.SaveChanges();
        }

        [HttpGet]
        public List<GetAllComplexesDto> GetAll()
        {


            //var a = (from b in _context.Blocks
            //         join u in _context.Units
            //         on b.Id equals u.BlockId
            //         into u
            //         select new GetAllComplexesDto
            //         {
            //             Id = b.ComplexId,
            //             Name = b.Complex.Name,
            //             UnitCount = b.Complex.UnitCount,
            //             SubmittedUnitCount = u.Where(u => u.BlockId == b.Id).Count(),
            //             RemainedUnitCount = b.Complex.UnitCount - u.Where(u => u.BlockId == b.Id).Count()

            //         });


            return _context.Complexes
                .Select(_ => new GetAllComplexesDto
                {
                    Id = _.Id,
                    Name = _.Name,
                    UnitCount = _.UnitCount,
                }).ToList();
        }


        [HttpPatch]
        [Route("{id}")]
        public void EditUnitCount([FromRoute] int id,
            [FromBody] EditComplexUnitCountDto dto)

        {
            if (!_context.Complexes
                .Any(_ => _.Id == id))
            {
                throw new ComplexNotFoundException();
            }

            var isExistUnit = (from block in _context.Blocks
                               where block.ComplexId == id
                               join unit in _context.Units
                               on block.Id equals unit.BlockId
                               select unit).Any();

            if (isExistUnit)
            {
                throw new ComplexHasUnitException();
            }

            _context.Complexes
                .First(_ => _.Id == id).UnitCount = dto.UnitCount;
            _context.SaveChanges();
        }

        [HttpGet]
        [Route("{id}")]
        public GetComplexByIdDto GetById([FromRoute] int id)
        {
           

            if (!_context.Complexes
                .Any(_ => _.Id == id))
            {
                throw new ComplexNotFoundException();
            }

            var submmitedUnitCount = (from block in _context.Blocks
                             where block.ComplexId == id
                             join unit in _context.Units
                             on block.Id equals unit.BlockId
                             select unit).Count();
            return _context.Complexes
                .Where(_ => _.Id == id).Select(_ => new GetComplexByIdDto
                {
                    Id = _.Id,
                    Name = _.Name,
                    SubmittedBlocksCount = _.Blocks.Count(),
                    SubmittedUnitCount = submmitedUnitCount,
                    RemainedUnitCount = _.UnitCount - submmitedUnitCount
                }).First();



            
        }



    }
}
