using System.ComponentModel.DataAnnotations;

namespace InsuranceTest.Models.Entities
{
    public class InsuranceCover : BaseEntity
    {
        // can use enum Instead , using class for extend future.
        [RegularExpression(@"^[A-Z]+[a-zA-Z0-9""'\s-]*$")]
        public string Title { get; set; }
        [Required]
        public int MaxFund { get; set; }
        [Required]
        public int MinFund { get; set; }
        [Required]
        public float RatePrecentage { get; set; }

    }
}
