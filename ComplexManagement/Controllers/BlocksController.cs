using ComplexManagement.Context;
using ComplexManagement.Dto.Blocks;
using ComplexManagement.Entities;
using ComplexManagement.Exceptions.Complex;
using Microsoft.AspNetCore.Mvc;

namespace ComplexManagement.Controllers
{
    [ApiController]
    [Route("blocks")]
    public class BlocksController : Controller
    {
        private readonly ComplexDBContext _context;
        public BlocksController(ComplexDBContext context)
        {
            _context = context;
        }

        [HttpPost]
        public void Add(AddBlockDto dto)
        {
            if (!_context.Complexes
                .Any(_ => _.Id == dto.ComplexId))
            {
                throw new ComplexNotFoundException();
            }
            var block = new Block
            {
                ComplexId = dto.ComplexId,
                Name = dto.Name,
                UnitCount = dto.UnitCount,
            };

            _context.Blocks.Add(block);
            _context.SaveChanges();
        }

        [HttpGet]
        public List<GetAllBlocksDto> GetAll()
        {
            return _context.Blocks
                .Select(_ => new GetAllBlocksDto
                {
                    Id = _.Id,
                    BlockName = _.Name,
                    ComplexId = _.ComplexId,
                    UnitCount = _.UnitCount,
                    ComplexName = _.Complex.Name
                }).ToList();
        }


    }
}
