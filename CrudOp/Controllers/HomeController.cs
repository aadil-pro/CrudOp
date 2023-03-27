using CrudOp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using ClassLibrary.Entities;
using Microsoft.Identity.Client;

namespace CrudOp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult DetailsList()
        {
            var DbContext = new CrudDbContext();

            var Details = DbContext.SendMoneys.ToList();

            return View(Details);
        }

        public IActionResult Editor(int? Id = null)
        {
            Model model = new Model();

            if (Id.HasValue)
            {
                var DbContext = new CrudDbContext();
                SendMoney money = DbContext.SendMoneys.FirstOrDefault(p => p.Id == Id);


                model.AmountToSend = money.AmountToSend;
                model.AmountReceived = money.AmountReceived;
                model.SenderName = money.SenderName;
                model.ReceiverName = money.ReceiverName;
                model.Purpose = money.Purpose;
            }

            return View(model);
        }

        [HttpPost]
        public IActionResult Editor(Model model)
        {
            if (ModelState.IsValid)
            {
                var dbContext = new CrudDbContext();

                var MoneyObj = new SendMoney();

                if (model.Id.HasValue)
                {
                    

                    MoneyObj = dbContext.SendMoneys.FirstOrDefault(p => p.Id == model.Id);

                    MoneyObj.AmountToSend = model.AmountToSend;
                    MoneyObj.AmountReceived = model.AmountToSend;
                    MoneyObj.SenderName = model.SenderName;
                    MoneyObj.ReceiverName = model.ReceiverName;
                    MoneyObj.Purpose = model.Purpose;

                    dbContext.SendMoneys.Update(MoneyObj);
                }
                else
                {

                    MoneyObj.AmountToSend = model.AmountToSend;
                    MoneyObj.AmountReceived = model.AmountReceived;
                    MoneyObj.SenderName = model.SenderName;
                    MoneyObj.ReceiverName = model.ReceiverName;
                    MoneyObj.Purpose = model.Purpose;

                    dbContext.SendMoneys.Add(MoneyObj);
                }

                dbContext.SaveChanges();

                return RedirectToAction("DetailsList", "Home");
            }
            else
            {
                ModelState.AddModelError("", "Money Details are not saved, please fix errors and save again!");

                return View(model);
            }
        }

        // Deleting a record from the list
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var dbContext = new CrudDbContext();

            var moneyDetails = dbContext.SendMoneys.Find(id);

            if (moneyDetails != null)
            {
                dbContext.SendMoneys.Remove(moneyDetails);
                dbContext.SaveChanges();
            }

            return RedirectToAction("DetailsList");
        }

    }
}