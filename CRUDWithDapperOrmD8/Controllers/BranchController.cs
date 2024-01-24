using CRUDWithDapperOrmD8.Models;
using CRUDWithDapperOrmD8.Repository;
using Microsoft.AspNetCore.Mvc;

namespace CRUDWithDapperOrmD8.Controllers
{
    public class BranchController : Controller
    {
        private readonly IGenericRepository<Branch> _iGenericRepository;
        public BranchController(IGenericRepository<Branch> iGenericRepository)
        {
            _iGenericRepository = iGenericRepository;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _iGenericRepository.GetAll("Branch");
            return View(result);
        }
        public async Task<IActionResult> Details(Int64 id)
        {
            var result = await _iGenericRepository.GetById("Branch", id);
            return View(result);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Branch branch)
        {
            if (ModelState.IsValid)
            {
                branch.CreatedDate = DateTime.Now;
                branch.UpdatedDate = DateTime.Now;
                await _iGenericRepository.Add("Branch", branch);

                return RedirectToAction(nameof(Index));
            }
            return View(branch);
        }
        public async Task<IActionResult> Edit(Int64 id)
        {
            var _Branch = await _iGenericRepository.GetById("Branch", id);
            return View(_Branch);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, Branch branch)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    branch.Id = id;
                    branch.UpdatedDate = DateTime.Now;
                    await _iGenericRepository.Update("Branch", branch);
                }
                catch (Exception)
                {
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(branch);
        }
        public async Task<IActionResult> Delete(Int64 id)
        {
            var _Branch = await _iGenericRepository.GetById("Branch", id);
            return View(_Branch);
        }

        [HttpDelete, ActionName("DeleteConfirmed")]
        public async Task<IActionResult> DeleteConfirmed(Int64 id)
        {
            await _iGenericRepository.Delete("Branch", id);
            return RedirectToAction(nameof(Index));
        }
    }
}