using ComplexManagement.Entities;
using System.ComponentModel.DataAnnotations;

namespace ComplexManagement.Dto.Units
{
    public class AddUnitDto
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        public ResidenceType ResidenceType { get; set; }
        [Required]
        public int BlockId { get; set; }
    }
}
