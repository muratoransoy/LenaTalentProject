using LenaTalent.DAL.Abstract;
using LenaTalent.Entities.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace LenaTalent.UI.Controllers
{
    public class FormController : Controller
    {
        private readonly IFormDAL formDAL;
        private readonly IFormDataDAL formDataDAL;

        public FormController(IFormDAL formDAL, IFormDataDAL formDataDAL)
        {
            this.formDAL = formDAL;
            this.formDataDAL = formDataDAL;
        }

        public IActionResult Index() => View(formDAL.GetAll());

       
        public IActionResult Edit(int id)
        {
            var formdata = formDataDAL.Get(id);
            if (id == null || formdata == null)
                return NotFound();

            return View(formdata);
        }

        [HttpPost]
        public IActionResult Edit(FormData formData)
        {
            if (ModelState.IsValid)
            {
                formDataDAL.Update(formData);
                return RedirectToAction("Index");
            }
            return View(formData);
        }
        public IActionResult Delete(int id)
        {
            var form = formDAL.Get(id);
            if (id == null || form == null)
                return NotFound();

      
            formDAL.Delete(form);
            return RedirectToAction("Index");
        }

        public IActionResult Search(string name)
        {
            var forms = formDAL.GetAll().Where(f => f.Name.Contains(name)).ToList();

            return View("Index", forms);
        }


    }
}
