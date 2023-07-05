using ComplexManagement.Context;
using ComplexManagement.Dto.Complexes;
using ComplexManagement.Entities;
using ComplexManagement.Exceptions.Complex;
using Microsoft.AspNetCore.Mvc;

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

    }
}
