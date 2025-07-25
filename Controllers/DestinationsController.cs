using DahiraAgency.Data;
using DahiraAgency.Data.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DahiraAgency.Controllers
{
    public class DestinationsController : Controller
    {
        private readonly IDestinationService _destinationService;

        public DestinationsController(IDestinationService destinationService)
        {
            _destinationService = destinationService;
        }

        public async Task<IActionResult> Index(string searchTerm, int page = 1)
        {
            int pageSize = 10;
            var destinations = await _destinationService.GetAllDestinationsAsync(searchTerm, page, pageSize);
            int totalCount = await _destinationService.GetTotalCountAsync(searchTerm);

            ViewBag.CurrentPage = page;
            ViewBag.TotalPages = (int)Math.Ceiling((double)totalCount / pageSize);
            ViewBag.SearchTerm = searchTerm;

            return View(destinations);
        }

        public async Task<IActionResult> Details(int id)
        {
            var destination = await _destinationService.GetDestinationByIdAsync(id);
            if (destination == null)
                return NotFound();

            return View(destination);
        }
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Destination destination)
        {
            if (ModelState.IsValid)
            {
                await _destinationService.AddDestinationAsync(destination);
                return RedirectToAction(nameof(Index));
            }
            return View(destination);
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int id)
        {
            var destination = await _destinationService.GetDestinationByIdAsync(id);
            if (destination == null)
                return NotFound();

            return View(destination);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Destination destination)
        {
            if (id != destination.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                await _destinationService.UpdateDestinationAsync(destination);
                return RedirectToAction(nameof(Index));
            }
            return View(destination);
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            var destination = await _destinationService.GetDestinationByIdAsync(id);
            if (destination == null)
                return NotFound();

            return View(destination);
        }

        [HttpPost, ActionName("Delete")]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _destinationService.DeleteDestinationAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
