namespace ComplexManagement.Dto.Complexes
{
    public class GetComplexByIdDto
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public int SubmittedUnitCount { get; set; }
        public int RemainedUnitCount { get; set; }
        public int SubmittedBlocksCount { get; set; }
    }
}
