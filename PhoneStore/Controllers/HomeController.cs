using Microsoft.AspNetCore.Mvc;
using PhoneStore.BLL.Interfaces;

namespace PhoneStore.Controllers;

public class HomeController : Controller
{
    private readonly IPhoneService _phoneService;

    public HomeController(IPhoneService phoneService)
    {
        _phoneService = phoneService;
    }

    public async Task<IActionResult> Index()
    {
        var phones = await _phoneService.GetAllAsync();
        return View(phones);
    }
}
