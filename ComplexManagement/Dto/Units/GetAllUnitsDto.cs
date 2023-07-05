using ComplexManagement.Entities;

namespace ComplexManagement.Dto.Units
{
    public class GetAllUnitsDto
    {
        public int Id { get; set; }
        public ResidenceType ResidenceType { get; set; }
        public string Name { get; set; }
        public int BlockId { get; set; }
    }
}
