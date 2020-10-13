using NikeStore.Entities;
using NikeStore.Models;
using NikeStore.ViewModels.Home;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NikeStore.Controllers
{
    public class HomeController : Controller
    {  
        public ActionResult Index(IndexVM model)
        {
            NikeContext context = new NikeContext();
            
            model.Page = model.Page > 0 ? model.Page : 1;
            model.ItemsPerPage = model.ItemsPerPage > 0 ? model.ItemsPerPage : 9;

            model.Shoes = context.Shoes.OrderByDescending(i => i.Id).Skip((model.Page - 1) * (model.ItemsPerPage)).Take(model.ItemsPerPage).ToList();
            model.PageCount=(int)Math.Ceiling(context.Shoes.Count() / (double)model.ItemsPerPage);

            model.Tags = context.Tags.ToList();
            model.Shoetags = context.ShoeTags.ToList();
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
            NikeContext context = new NikeContext();
            User LogedUser = context.Users.Where(u => u.Username == model.Username && u.Password == model.Password).FirstOrDefault();
            if (LogedUser != null)
            {
                Session["LoggedUser"] = LogedUser;
                Session["username"] = LogedUser.Username;
                if (LogedUser.IsAdmin)
                {
                    Session["Admin"] = LogedUser;
                }
                
            }
            else
            {
                return View(model);
            }

            return RedirectToAction("Index","Home");
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
            NikeContext context = new NikeContext();
            User RegisteredUser = new User();
            RegisteredUser.Username = model.Username;
            RegisteredUser.Password = model.Password;
            RegisteredUser.FirstName = model.FirstName;
            RegisteredUser.LastName = model.LastName;
            RegisteredUser.Address = model.Address;
            RegisteredUser.PhoneNumber = model.PhoneNumber;
            RegisteredUser.Email = model.Email;
            RegisteredUser.IsAdmin = model.IsAdmin;

            context.Users.Add(RegisteredUser);
            context.SaveChanges();

            return RedirectToAction("Login","Home");
        }
        public ActionResult Logout()
        {
            Session["LoggedUser"] = null;
            Session["Admin"] = null;
            Session["Cart"] = null;
            Session["Count"] = null;
            Session["Username"] = null;
            return RedirectToAction("Login","Home");
        }
        public ActionResult AddToCart(Shoe shoe)
        {
            if (Session["Cart"]==null)
            {
                List<Shoe> buy = new List<Shoe>();
                buy.Add(shoe);
                Session["Cart"] = buy;
                Session["Count"] = buy.Count;
            }
            else
            {
                List<Shoe> buy = (List<Shoe>)Session["Cart"];
                buy.Add(shoe);
                Session["Cart"] = buy;
                Session["Count"] = buy.Count;
            }
            return RedirectToAction("Index", "Home");
        }
        public ActionResult Cart()
        {
            CartVM model = new CartVM();
            model.Items = (List<Shoe>)Session["Cart"];
            return View(model);
        }
        public ActionResult CashOut()
        {
            NikeContext context = new NikeContext();
            User LoggedUser = (User)Session["LoggedUser"];
            if (Session["LoggedUser"]!=null)
            {
                Order order = new Order();
                order.Addres = LoggedUser.Address;
                order.Client = LoggedUser.Username;
                order.Date = DateTime.Now;
                float price = 0;
                List<Shoe> shoes= (List<Shoe>)Session["Cart"];
                foreach (Shoe shoe in shoes)
                {
                    price += shoe.Price;
                }
                order.Price = price;
                context.Orders.Add(order);
                context.SaveChanges();          
                foreach (Shoe shoe in shoes)
                {
                    OrderItems items = new OrderItems();
                    items.Order_Id = order.OrderID;
                    items.Shoe_Id = shoe.Id;
                    context.OrderItems.Add(items);
                    context.SaveChanges();
                }
                Session["Cart"] = null;
                Session["Count"] = null;
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("Cart", "Home");
        }
    }
}