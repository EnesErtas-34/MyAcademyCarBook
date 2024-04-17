using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyAcademyCarBook.BusinessLayer.Abstract;
using MyAcademyCarBook.EntityLayer.Concrete;

namespace MyAcademyCarBook.PresentationLayer.Controllers
{
    public class BrandController : Controller
    {
        private readonly IBrandService _brandService;
        private readonly UserManager<AppUser> _userManager;
        public BrandController(IBrandService brandService, UserManager<AppUser> userManager = null)
        {
            _brandService = brandService;
            _userManager = userManager;
        }
        public async Task<IActionResult> Deneme()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.name = user.Name+""+user.Surname;
            return View();
        }

        public IActionResult Index()
        {
            var values = _brandService.TGetListAll();
            return View(values);
        }
        [HttpGet]
        public IActionResult AddBrand()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddBrand(Brand brand)
        {
            _brandService.TInsert(brand);
            return RedirectToAction("Index");
        }
        public IActionResult DeleteBrand(int id)
        {
            var value=_brandService.TGetById(id);
            _brandService.TDelete(value);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult UpdateBrand(int id)
        {
            var value = _brandService.TGetById(id);
            return View(value);
        }
        [HttpPost]
        public IActionResult UpdateBrand(Brand brand)
        {
            _brandService.TUpdate(brand);
            return RedirectToAction("Index");
        }
    }
}
