using DahiraAgency.Data;
using DahiraAgency.Data.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DahiraAgency.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class DestinationsController : Controller
    {
        private readonly IAdminService _adminService;

        public DestinationsController(IAdminService adminService)
        {
            _adminService = adminService;
        }

        public async Task<IActionResult> Index()
        {
            var destinations = await _adminService.GetAllDestinationsForAdminAsync();
            return View(destinations);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Destination destination)
        {
            if (ModelState.IsValid)
            {
                await _adminService.CreateDestinationAsync(destination);
                return RedirectToAction(nameof(Index));
            }
            return View(destination);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var destination = await _adminService.GetAllDestinationsForAdminAsync();
            var editDestination = destination.FirstOrDefault(d => d.Id == id);
            if (editDestination == null)
                return NotFound();

            return View(editDestination);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Destination destination)
        {
            if (ModelState.IsValid)
            {
                await _adminService.EditDestinationAsync(destination);
                return RedirectToAction(nameof(Index));
            }
            return View(destination);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var destination = await _adminService.GetAllDestinationsForAdminAsync();
            var deleteDestination = destination.FirstOrDefault(d => d.Id == id);
            if (deleteDestination == null)
                return NotFound();

            return View(deleteDestination);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _adminService.DeleteDestinationAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
