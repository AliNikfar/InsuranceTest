using System.ComponentModel.DataAnnotations;

namespace InsuranceTest.Models.Entities.DTO
{
    public class CompensationRequestDTO :BaseEntity
    {
        [Required(ErrorMessage = "عنوان درخواست اجباری است")]
        public string Title { get; set; }
        
        public float Fund { get; set; }

        public List<InsuranceCoverDTO>? insuranceCovers { get; set; }

        public bool SurgeryCk { get; set; }
        public float SurgeryPresentage { get; set; }
        public float? SurgeryFund { get; set; }
        public int SurgeryMaxFund { get; set; }
        public int SurgeryMinFund { get; set; }

        public bool DentalCk { get; set; }
        public float DentalPresentage { get; set; }
        public float? DentalFund { get; set; }
        public int DentalMaxFund { get; set; }
        public int DentalMinFund { get; set; }

        public bool HospitalizationCk { get; set; }
        public float HospitalizationPresentage { get; set; }
        public float? HospitalizationFund { get; set; }
        public int HospitalizationMaxFund { get; set; }
        public int HospitalizationMinFund { get; set; }



    }
}
