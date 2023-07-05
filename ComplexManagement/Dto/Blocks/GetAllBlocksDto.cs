namespace ComplexManagement.Dto.Blocks
{
    public class GetAllBlocksDto
    {
        public int Id { get; set; }
        public string BlockName { get; set; }
        public int ComplexId { get; set; }
        public string ComplexName { get; set; }
        public int UnitCount { get; set; }
    }
}
