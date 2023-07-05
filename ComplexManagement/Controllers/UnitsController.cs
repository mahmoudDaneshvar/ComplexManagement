using ComplexManagement.Context;
using ComplexManagement.Dto.Units;
using ComplexManagement.Entities;
using ComplexManagement.Exceptions.Block;
using ComplexManagement.Exceptions.Units;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace ComplexManagement.Controllers
{
    [ApiController]
    [Route("units")]
    public class UnitsController : Controller
    {
        private readonly ComplexDBContext _context;

        public UnitsController(ComplexDBContext context)
        {
            _context = context;
        }

        [HttpPost]
        public void Add([FromBody]AddUnitDto dto)
        {
            if (!_context.Blocks
                .Any(_ => _.Id == dto.BlockId))
            {
                throw new BlockNotFoundException();
            }

            if (_context.Units
                .Any(u => u.BlockId == dto.BlockId
                && u.Name == dto.Name))
            {
                throw new DuplicateUnitNameInSameBlockException();
            }

            var unit = new Unit
            {
                Name = dto.Name,
                BlockId = dto.BlockId,
                ResidenceType = dto.ResidenceType,

            };

            _context.Units.Add(unit);
            _context.SaveChanges();

        }
    }
}
