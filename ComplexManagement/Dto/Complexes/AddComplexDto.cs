using System.ComponentModel.DataAnnotations;

namespace ComplexManagement.Dto.Complexes
{
    public class AddComplexDto
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        [Range(4, 1000)]
        public int UnitCount { get; set; }
    }
}
