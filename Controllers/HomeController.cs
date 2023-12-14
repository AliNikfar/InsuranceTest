using InsuranceTest.Models;
using InsuranceTest.Models.Contract;
using InsuranceTest.Models.Entities;
using InsuranceTest.Models.Entities.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace InsuranceTest.Controllers
{
    public class HomeController : Controller
    {
        CompensationRequestDTO defaults = new CompensationRequestDTO();
        IEnumerable<InsuranceCover> covers;
        private readonly ILogger<HomeController> _logger;
        private readonly ICompensationRequestRepository _compensationCTX;
        private readonly IInsuranceCoverRepository _insuranceCoverCTX;



        public HomeController(ILogger<HomeController> logger, ICompensationRequestRepository compensationCTX,
           IInsuranceCoverRepository insuranceCoverCTX)
        {
            _logger = logger;
            this._compensationCTX = compensationCTX;
            this._insuranceCoverCTX = insuranceCoverCTX;

            if (covers is null)
            {
                covers = _insuranceCoverCTX.GetAllAsync().Result.ToList();

                defaults.insuranceCovers = new List<InsuranceCoverDTO>();

                defaults.SurgeryMaxFund = covers.Where(p => p.Id == 1).Select(p => p.MaxFund).FirstOrDefault();
                defaults.SurgeryMinFund = covers.Where(p => p.Id == 1).Select(p => p.MinFund).FirstOrDefault();
                defaults.SurgeryPresentage = covers.Where(p => p.Id == 1).Select(p => p.RatePrecentage).FirstOrDefault();
                defaults.SurgeryCk = false;

                defaults.DentalMaxFund = covers.Where(p => p.Id == 2).Select(p => p.MaxFund).FirstOrDefault();
                defaults.DentalMinFund = covers.Where(p => p.Id == 2).Select(p => p.MinFund).FirstOrDefault();
                defaults.DentalPresentage = covers.Where(p => p.Id == 2).Select(p => p.RatePrecentage).FirstOrDefault();
                defaults.DentalCk = false;

                defaults.HospitalizationMaxFund = covers.Where(p => p.Id == 3).Select(p => p.MaxFund).FirstOrDefault();
                defaults.HospitalizationMinFund = covers.Where(p => p.Id == 3).Select(p => p.MinFund).FirstOrDefault();
                defaults.HospitalizationPresentage = covers.Where(p => p.Id == 3).Select(p => p.RatePrecentage).FirstOrDefault();
                defaults.HospitalizationCk = false;
            }

        }

        public IActionResult Index()
        {

            if (covers is not null)
            {
                return View(defaults);
            }
            else
            {
                return View("پوششی یافت نشد");
            }
        }
        [HttpPost]
        public IActionResult Index(CompensationRequestDTO request)
        {

            if (request.SurgeryFund is null && request.HospitalizationFund is null && request.DentalFund is null)
            {
                ModelState.AddModelError("1", "حداقل یکی از مقادیر سرمایه باید وارد شود");
                defaults.Title = request.Title;
                return View(defaults);
            }
            else if (!ModelState.IsValid)
            {
                ModelState.AddModelError("2", "لطفا پس از بررسی مقادیر ورودی مجددا تلاش نمایید.");
                defaults.Title = request.Title;
                return View(defaults);
            }
            else
            {
                var sumFund = 0f;

                sumFund += request.DentalFund.HasValue ? (request.DentalFund.Value * defaults.DentalPresentage) : 0f;
                sumFund += request.SurgeryFund.HasValue ? (request.SurgeryFund.Value * defaults.SurgeryPresentage) : 0f;
                sumFund += request.HospitalizationFund.HasValue ? (request.HospitalizationFund.Value * defaults.HospitalizationPresentage) : 0f;

                CompensationRequest compForInsert = new CompensationRequest
                {

                    Fund = sumFund,
                    HospitalizationFund = request.HospitalizationFund,
                    SurgeryFund = request.SurgeryFund,
                    DentalFund = request.DentalFund,
                    LastChangeDate = DateTime.Now,
                    LastChangeUser = 1,
                    RegisterDate = DateTime.Now,
                    RegisterUser = 1,
                    Title = request.Title,
                    Visable = true,
                    Author = 1,
                };
                var result = _compensationCTX.InsertAsync(compForInsert);

                CompensationRequestDTO resultDTO = new CompensationRequestDTO
                {
                    Fund = result.Result.Fund,
                    HospitalizationFund = result.Result.HospitalizationFund,
                    SurgeryFund = result.Result.SurgeryFund,
                    DentalFund = result.Result.DentalFund,
                    LastChangeDate = result.Result.LastChangeDate,
                    LastChangeUser = result.Result.LastChangeUser,
                    RegisterDate = result.Result.RegisterDate,
                    RegisterUser = result.Result.RegisterUser,
                    Title = result.Result.Title,
                    Visable = result.Result.Visable,
                    Author = result.Result.Author,
                };
                defaults.Title = String.Empty;
                return RedirectToAction("ResultPage", resultDTO);
            }

        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        [HttpGet]
        public IActionResult ResultPage(CompensationRequestDTO result)
        {

            return View(result);
        }
        [HttpPost]
        public IActionResult ResultPage()
        {

            return RedirectToAction("index");
        }
    }
}