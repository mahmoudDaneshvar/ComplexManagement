﻿namespace ComplexManagement.Dto.Complexes
{
    public class GetAllComplexesDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int UnitCount { get; set; }
        public int SubmittedUnitCount { get; set; }
        public int RemainedUnitCount { get; set; }
    }
}
