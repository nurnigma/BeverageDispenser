using BeverageDispenser.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace BeverageDispenser.Controllers
{
    /// <summary>
    /// Контроллер для покупки
    /// </summary>
    public class PurchasesController : Controller
    {
        private readonly ApplicationContext _db;

        public PurchasesController(ApplicationContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            var drinks = _db.Beverages
            .Select(c => new BeveragesInfo { DrinkId = c.Id, Name = c.Name, Price = c.Cost.Price, Count = c.Cost.Count })
            .ToList();
            var coins = _db.Coins
                .ToList();
            return View((drinks, coins));
        }

        [HttpPost]
        public IActionResult ResetChange()
        {
            TempData["Change"] = null;
            return Ok();
        }

        /// <summary>
        /// Выбрать напиток
        /// </summary>
        /// <param name="drinkId">Индентификатор напитка</param>
        /// <param name="totalAmount">Внесенная сумма</param>
        [HttpPost]
        public async Task<IActionResult> Select(int drinkId, decimal totalAmount)
        {
            if (drinkId == 0)
            {
                TempData["ErrorMessage"] = "Напиток закончился";
            }
            if (totalAmount == 0)
            {
                TempData["ErrorMessage"] = "Вы не внесли деньги";
            }
            else
            {
                var selectedDrink = _db.Beverages.Include(x => x.Cost).FirstOrDefault(x => x.Id == drinkId && x.Cost.Price <= totalAmount);
                if (selectedDrink != null)
                {
                    decimal totalPrice = selectedDrink.Cost.Price;

                    if (totalPrice <= totalAmount)
                    {
                        selectedDrink.Cost.Count--;

                        decimal change = totalAmount - totalPrice;

                        _db.SaveChanges();

                        TempData["Change"] = change.ToString();


                        TempData["IsPurchased"] = true;
                        TempData["DrinkName"] = selectedDrink.Name;

                    }

                }
                else
                {
                    TempData["ErrorMessage"] = "Ошибка, недостаточно средств для напитка, выберите другой либо внестите корректную сумму";
                }
            }
            return RedirectToAction("Index");
        }
    }
}
