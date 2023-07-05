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

        public void Add(AddComplexDto dto)
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
    }
}
