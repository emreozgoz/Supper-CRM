using Castle.Core.Internal;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SupperCRM.Entities;
using SupperCRM.Models;
using SupperCRM.Services;

namespace SupperCRM.WebApp.Controllers
{
    public class CustomersController : Controller
    {
        private readonly IClientService _clientService;

        public CustomersController(IClientService clientService)
        {
            _clientService = clientService;
        }

        // GET: CustomersController
        public ActionResult Index(string keyword = "")
        {
            List<Client> clients = null;
            if (string.IsNullOrEmpty(keyword) || string.IsNullOrWhiteSpace(keyword))
            {
                clients = _clientService.GetAll();
            }
            else
            {
                clients = _clientService.ListBySearch(keyword);
                ViewData["keyword"] = keyword;
            }
            return View(clients);
        }

        // GET: CustomersController/Details/5
        public ActionResult Details(int id)
        {
            var client = _clientService.GetById(id);
            return Json(new AjaxResponseModel<Client> { Object = client });
        }

        // GET: CustomersController/Create
        public ActionResult Create()
        {
            return View();
        }
        // POST: CustomersController/Create
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Create(CreateCustomerModel model)
        {
            AjaxResponseModel<string> response = new AjaxResponseModel<string>();
            if (ModelState.IsValid)
            {
                _clientService.Create(model);
                response.Success = "Müşteri Başarıyla Eklendi";
                return Json(response);
            }

            AddModelStateToAjaxResponse(response);

            return Json(response);

        }

        private void AddModelStateToAjaxResponse(AjaxResponseModel<string> response)
        {
            foreach (var keys in ModelState.Keys)
            {
                var item = ModelState.GetValueOrDefault(keys);
                if (item.Errors.Count > 0)
                    item.Errors.ToList().ForEach(x => response.Add(keys, x.ErrorMessage));
            }
        }

        // GET: CustomersController/Edit/5
        public ActionResult Edit(int id)
        {
            var client = _clientService.GetById(id);
            return Json(new AjaxResponseModel<Client> { Object = client });
        }

        // POST: CustomersController/Edit/5
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Edit(int id, EditCustomerModel model)
        {
            AjaxResponseModel<string> response = new AjaxResponseModel<string>();
            if (ModelState.IsValid)
            {
                _clientService.Update(id, model);
                response.Success = "Müşteri Başarıyla Güncellendi";
                return Json(response);
            }

            AddModelStateToAjaxResponse(response);

            return Json(response);
        }

        // POST: CustomersController/Delete/5
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            AjaxResponseModel<string> response = new AjaxResponseModel<string>();
            try
            {
                _clientService.Delete(id);
                response.Success = "Başarıyla Silindi";
            }
            catch (Exception e)
            {
                response.Add("", e.Message);
            }
            return Json(response);
        }
    }
}
