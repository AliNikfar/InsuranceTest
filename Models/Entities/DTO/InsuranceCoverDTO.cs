namespace InsuranceTest.Models.Entities.DTO
{
    public class InsuranceCoverDTO :BaseEntity
    {

        public string Title { get; set; }

        public int MaxFund { get; set; }

        public int MinFund { get; set; }

        public float RatePrecentage { get; set; }
        public float ComputedFund { get; set; }

        public bool Selected { get; set; }
    }
}
