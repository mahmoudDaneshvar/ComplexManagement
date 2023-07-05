namespace ComplexManagement.Entities
{
    public class Unit
    {
        public ResidenceType ResidenceType { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public int BlockId { get; set; }
    }

    public enum ResidenceType
    {
        Owner = 1,
        Tenant = 2,
        Empty = 3
    }
}
