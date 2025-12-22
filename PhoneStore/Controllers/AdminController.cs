using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PhoneStore.BLL.Interfaces;
using PhoneStore.Domain.Entities;

[Authorize] // 🔒 Admin faqat login bo‘lsa ochiladi
public class AdminController : Controller
{
    private readonly IPhoneService _phoneService;

    public AdminController(IPhoneService phoneService)
    {
        _phoneService = phoneService;
    }

    public async Task<IActionResult> Index()
    {
        var phones = await _phoneService.GetAllAsync();
        return View(phones);
    }

    // ===== CREATE =====
    [HttpGet]
    public IActionResult PhoneCreate()
    {
        return View(new Phone());
    }

    [HttpPost]
    public async Task<IActionResult> PhoneCreate(Phone phone)
    {
        if (!ModelState.IsValid)
            return View(phone);

        await _phoneService.CreateAsync(phone);
        return RedirectToAction(nameof(Index));
    }

    // ===== EDIT =====
    [HttpGet]
    public async Task<IActionResult> PhoneEdit(long id)
    {
        var phone = await _phoneService.GetByIdAsync(id);
        if (phone == null) return NotFound();

        return View(phone);
    }

    [HttpPost]
    public async Task<IActionResult> PhoneEdit(Phone phone)
    {
        if (!ModelState.IsValid)
            return View(phone);

        await _phoneService.UpdateAsync(phone);
        return RedirectToAction(nameof(Index));
    }

    // ===== DELETE =====
    public async Task<IActionResult> PhoneDelete(long id)
    {
        await _phoneService.DeleteAsync(id);
        return RedirectToAction(nameof(Index));
    }
}
