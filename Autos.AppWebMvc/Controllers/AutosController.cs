using Autos.DTOs.Autos.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Autos.AppWebMvc.Controllers
{
    public class AutosController : Controller
    {
        private readonly HttpClient _httpClientAutoAPI;
        public AutosController(IHttpClientFactory httpClientFactory)
        {
            _httpClientAutoAPI = httpClientFactory.CreateClient("AutoAPI");
        }

        // GET: AutosController
        public async Task<IActionResult> Index(SearchQueryAutoDTO searchQueryAutoDTO, int CountRow = 0)
        {
            if (searchQueryAutoDTO.SendRowCount == 0)
                searchQueryAutoDTO.SendRowCount = 2;
            if (searchQueryAutoDTO.Take == 0)
                searchQueryAutoDTO.Take = 10;

            var result = new SearchResultAutoDTO();
            var response = await _httpClientAutoAPI.PostAsJsonAsync("/auto/search", searchQueryAutoDTO);

            if (response.IsSuccessStatusCode)
                result = await response.Content.ReadFromJsonAsync<SearchResultAutoDTO>();

            result = result != null ? result : new SearchResultAutoDTO();

            if (result.CountRow == 0 && searchQueryAutoDTO.SendRowCount == 1)
                result.CountRow = CountRow;

            ViewBag.CountRow = result.CountRow;
            searchQueryAutoDTO.SendRowCount = 0;
            ViewBag.SearchQuery = searchQueryAutoDTO;

            return View(result);
        }

        // GET: AutosController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var result = new GetIdResultAuto();
            var response = await _httpClientAutoAPI.GetAsync("/auto/" + id);

            if (response.IsSuccessStatusCode)
                result = await response.Content.ReadFromJsonAsync<GetIdResultAuto>();

            return View(result ?? new GetIdResultAuto());
        }

        // GET: AutosController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AutosController/Create
        [HttpPost]
        public async Task<IActionResult> Create(CreateAutoDTO createAutoDTO)
        {
            try
            {
                var response = await _httpClientAutoAPI.PostAsJsonAsync("/auto", createAutoDTO);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }

                ViewBag.Error = "Error al ingresar los datos";
                return View();
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View();
            }
        }

        // GET: AutosController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var result = new GetIdResultAuto();
            var response = await _httpClientAutoAPI.GetAsync("/auto/" + id);

            if (response.IsSuccessStatusCode)
                result = await response.Content.ReadFromJsonAsync<GetIdResultAuto>();

            return View(new EditAutoDTO(result ?? new GetIdResultAuto()));
        }

        // POST: AutosController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, EditAutoDTO editAutoDTO)
        {
            try
            {
                var response = await _httpClientAutoAPI.PostAsJsonAsync("/auto", editAutoDTO);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
                ViewBag.Error = "Error al editar los datos";
                return View();
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View();
            }
        }

        // GET: AutosController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var result = new GetIdResultAuto();
            var response = await _httpClientAutoAPI.GetAsync("/auto/" + id);

            if (response.IsSuccessStatusCode)
                result = await response.Content.ReadFromJsonAsync<GetIdResultAuto>();

            return View(result ?? new GetIdResultAuto());
        }

        // POST: AutosController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, GetIdResultAuto get)
        {
            try
            {
                var response = await _httpClientAutoAPI.DeleteAsync("/auto/" + id);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
                ViewBag.Error = "Error al eliminar los datos";
                return View(get);
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(get);
            }
        }
    }
}
