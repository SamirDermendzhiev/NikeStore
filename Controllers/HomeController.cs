using Microsoft.AspNetCore.Mvc;
using NikeStore.Entities;
using NikeStore.Models;
using NikeStore.ViewModels.Home;
using System.Text.Json;

namespace NikeStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly NikeContext _context;

        public HomeController(NikeContext context)
        {
            _context = context;
        }

        public ActionResult Index(IndexVM model)
        {
            model.Page = model.Page > 0 ? model.Page : 1;
            model.ItemsPerPage = model.ItemsPerPage > 0 ? model.ItemsPerPage : 9;

            model.Shoes = _context.Shoes.OrderByDescending(i => i.Id).Skip((model.Page - 1) * (model.ItemsPerPage)).Take(model.ItemsPerPage).ToList();
            model.PageCount = (int)Math.Ceiling(_context.Shoes.Count() / (double)model.ItemsPerPage);

            model.Tags = _context.Tags.ToList();
            model.Shoetags = _context.ShoeTags.ToList();
            return View(model);
        }
        [HttpGet]
        public ActionResult Login()
        {
            LoginVM model = new LoginVM();
            return View(model);
        }
        [HttpPost]
        public ActionResult Login(LoginVM model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            User LogedUser = _context.Users.Where(u => u.Username == model.Username && u.Password == model.Password).FirstOrDefault();
            if (LogedUser != null)
            {
                HttpContext.Session.SetString("LoggedUser", JsonSerializer.Serialize(LogedUser));
                HttpContext.Session.SetString("username", LogedUser.Username);
                if (LogedUser.IsAdmin)
                {
                    HttpContext.Session.SetString("Admin", JsonSerializer.Serialize(LogedUser));
                }

            }
            else
            {
                return View(model);
            }

            return RedirectToAction("Index", "Home");
        }
        [HttpGet]
        public ActionResult Register()
        {
            RegisterVM model = new RegisterVM();
            return View(model);
        }
        [HttpPost]
        public ActionResult Register(RegisterVM model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            User RegisteredUser = new User();
            RegisteredUser.Username = model.Username;
            RegisteredUser.Password = model.Password;
            RegisteredUser.FirstName = model.FirstName;
            RegisteredUser.LastName = model.LastName;
            RegisteredUser.Address = model.Address;
            RegisteredUser.PhoneNumber = model.PhoneNumber;
            RegisteredUser.Email = model.Email;
            RegisteredUser.IsAdmin = model.IsAdmin;

            _context.Users.Add(RegisteredUser);
            _context.SaveChanges();

            return RedirectToAction("Login", "Home");
        }
        public ActionResult Logout()
        {
            HttpContext.Session.Remove("LoggedUser");
            HttpContext.Session.Remove("Admin");
            HttpContext.Session.Remove("Cart");
            HttpContext.Session.Remove("Count");
            HttpContext.Session.Remove("Username");
            return RedirectToAction("Login", "Home");
        }
        public ActionResult AddToCart(Shoe shoe)
        {
            HttpContext.Session.Remove("LoggedUser");

            if (HttpContext.Session.GetString("Cart") == null)
            {
                List<Shoe> buy = new List<Shoe>();
                buy.Add(shoe);
                HttpContext.Session.SetString("Cart", JsonSerializer.Serialize(buy));
                HttpContext.Session.SetInt32("Count", buy.Count);
            }
            else
            {
                List<Shoe> buy = JsonSerializer.Deserialize<List<Shoe>>(HttpContext.Session.GetString("Cart"));
                buy.Add(shoe);
                HttpContext.Session.SetString("Cart", JsonSerializer.Serialize(buy));
                HttpContext.Session.SetInt32("Count", buy.Count);
            }
            return RedirectToAction("Index", "Home");
        }
        public ActionResult Cart()
        {
            CartVM model = new CartVM();
            model.Items = JsonSerializer.Deserialize<List<Shoe>>(HttpContext.Session.GetString("Cart"));
            return View(model);
        }
        public ActionResult CashOut()
        {
            var LoggedUser = JsonSerializer.Deserialize<User>(HttpContext.Session.GetString("LoggedUser"));
            if (LoggedUser != null)
            {
                Order order = new Order();
                order.Addres = LoggedUser.Address;
                order.Client = LoggedUser.Username;
                order.Date = DateTime.Now;
                float price = 0;
                List<Shoe> shoes = JsonSerializer.Deserialize<List<Shoe>>(HttpContext.Session.GetString("Cart"));
                foreach (Shoe shoe in shoes)
                {
                    price += shoe.Price;
                }
                order.Price = price;
                _context.Orders.Add(order);
                _context.SaveChanges();
                foreach (Shoe shoe in shoes)
                {
                    OrderItems items = new OrderItems();
                    items.Order_Id = order.OrderID;
                    items.Shoe_Id = shoe.Id;
                    _context.OrderItems.Add(items);
                    _context.SaveChanges();
                }
                HttpContext.Session.Remove("Cart");
                HttpContext.Session.Remove("Count");
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("Cart", "Home");
        }
    }
}