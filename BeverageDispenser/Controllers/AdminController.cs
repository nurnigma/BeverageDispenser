using BeverageDispenser.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;

namespace BeverageDispenser.Controllers
{
    /// <summary>
    /// Контроллер для администрирования
    /// </summary>
    public class AdminController : Controller
    {
        /// <summary>
        /// Ключ для доступа в админ
        /// </summary>
        private readonly string _adminSecretKey;

        private readonly ApplicationContext _db;

        public AdminController(ApplicationContext db, IConfiguration configuration)
        {
            _db = db;
            _adminSecretKey = configuration["AdminSecretKey"];

        }
        /// <summary>
        /// Отображение всех данных и функций
        /// </summary>
        /// <param name="secretKey">Ключ для доступа в админ</param>
        /// <returns></returns>
        public IActionResult ManageDrinks(string secretKey)
        {
            if (secretKey != _adminSecretKey)
                return Unauthorized(); // Возращает 401 ошибку, не авторизован

            var drinks = _db.Beverages
            .Select(c => new BeveragesInfo { DrinkId = c.Id, Name = c.Name, Price = c.Cost.Price, Count = c.Cost.Count })
            .ToList();
            var coins = _db.Coins.ToList();

            return View((drinks, coins));

        }
        /// <summary>
        /// Изменение монеты, приходит из AJAx
        /// </summary>
        /// <param name="id">Идентификатор монеты</param>
        /// <param name="isDis">Активна ли</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult EditCoin(int id, bool isDis)
        {
            var coin = _db.Coins.Find(id);
            coin.IsDispenser = isDis;
            _db.SaveChanges();
            return Ok();
        }

        [HttpGet]
        public IActionResult Create(string secretKey)
        {
            if (secretKey != _adminSecretKey)
                return Unauthorized();
            return View();
        }

        // Добавление нового напитка
        [HttpPost]
        public IActionResult Create(Beverage drink)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            _db.Beverages.Add(drink);
            _db.Costs.Add(drink.Cost);

            _db.SaveChanges();

            string secretKey = _adminSecretKey;

            return RedirectToAction("ManageDrinks", new { secretKey });

        }

        // Удаление напитка по идентификатору
        [HttpGet]
        public IActionResult Delete(int id, string secretKey)
        {
            if (secretKey != _adminSecretKey)
                return Unauthorized();

            var drink = _db.Beverages.Include(x => x.Cost).FirstOrDefault(d => d.Id == id);
            if (drink == null)
                return NotFound();
            var cost = drink.Cost;
            _db.Beverages.Remove(drink);

            // Удалить ассоциацию вместе с ним
            if (cost != null)
            {
                _db.Costs.Remove(cost);
            }
            _db.Beverages.Remove(drink);
            _db.SaveChanges();

            return RedirectToAction("ManageDrinks", new { secretKey });
        }

        [HttpGet]
        public IActionResult EditCost(int id, string secretKey)
        {
            if (secretKey != _adminSecretKey)
                return Unauthorized();

            if (id == null)
            {
                return NotFound();
            }
            var cost = _db.Costs.Find(id);

            if (cost == null)
            {
                return NotFound();
            }

            return View(cost);
        }

        [HttpPost]
        public IActionResult EditCost(Cost cost)
        {
            if (!ModelState.IsValid)
            {
                return NotFound();
            }

            _db.Costs.Update(cost);
            _db.SaveChanges();

            string secretKey = _adminSecretKey;

            return RedirectToAction("ManageDrinks", new { secretKey });

        }
        // Обновление названия напитка
        [HttpGet]
        public IActionResult EditDrink(int id, string secretKey)
        {
            if (secretKey != _adminSecretKey)
                return Unauthorized();
            if (id == null)
            {
                return NotFound();
            }
            var beverage = _db.Beverages.Find(id);

            if (beverage == null)
            {
                return NotFound();
            }

            return View(beverage);
        }
        // Обновление количества и стоимости напитка
        [HttpPost]
        public IActionResult EditDrink(Beverage beverage)
        {
            if (!ModelState.IsValid)
            {
                return NotFound();
            }

            _db.Beverages.Update(beverage);
            _db.SaveChanges();

            string secretKey = _adminSecretKey;

            return RedirectToAction("ManageDrinks", new { secretKey });


        }

    }




}