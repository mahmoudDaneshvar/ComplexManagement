using System.ComponentModel.DataAnnotations;

namespace ComplexManagement.Dto.Blocks
{
    public class AddBlockDto
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        public int ComplexId { get; set; }
        [Required]
        public int UnitCount { get; set; }
    }
}
