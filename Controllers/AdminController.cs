using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NikeStore.Entities;
using NikeStore.Models;
using NikeStore.ViewModels.Admin;

namespace NikeStore.Controllers
{
    public class AdminController : Controller
    {
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly NikeContext _context;

        public AdminController(IWebHostEnvironment hostingEnvironment, NikeContext context)
        {
            _hostingEnvironment = hostingEnvironment;
            _context = context;
        }

        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult AddModel()
        {
            if (HttpContext.Session.GetString("Admin") != null)
            {
                AddModelVM model = new AddModelVM();

                model.Tags = _context.Tags.ToList();
                return View(model);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
        [HttpPost]
        public async Task<ActionResult> AddModel(AddModelVM model)
        {
            var file = model.Image[0];
            if (file == null || file.Length <= 0)
            {
                ModelState.AddModelError("", "Please upload file!");
            }
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            Shoe item = new Shoe();

            string projectRootPath = _hostingEnvironment.ContentRootPath;

            string path = Path.Combine(projectRootPath, "Images", Path.GetFileName(file.FileName));
            using (Stream fileStream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }
            item.Picture = Path.GetFileName(file.FileName);

            item.Name = model.Name;
            item.Price = model.Price;
            item.Size = model.Size;
            _context.Shoes.Add(item);
            int id = item.Id;
            _context.SaveChanges();

            foreach (Tag tag in model.Tags)
            {
                if (tag.SetTag == true)
                {
                    ShoeTag tagShoe = new ShoeTag();
                    tagShoe.Tag_Id = tag.Id;
                    tagShoe.Shoe_Id = item.Id;
                    _context.ShoeTags.Add(tagShoe);
                    _context.SaveChanges();
                }
            }
            return RedirectToAction("AddModel", "Admin");
        }
        public ActionResult AddTag(AddModelVM model)
        {
            Tag item = new Tag();
            item.Name = model.AddTag;
            _context.Tags.Add(item);
            _context.SaveChanges();

            return RedirectToAction("AddModel", "Admin", model);
        }
        [HttpGet]
        public ActionResult Edit(int? id)
        {

            if (HttpContext.Session.GetString("Admin") != null)
            {
                Shoe shoe = id == null ? new Shoe() :
                                   _context.Shoes.Where(i => i.Id == id.Value).FirstOrDefault();

                if (shoe == null)
                    return RedirectToAction("Index", "Home");
                EditVM model = new EditVM();
                model.Name = shoe.Name;
                model.Price = shoe.Price;
                model.Size = shoe.Size;
                model.Tags = _context.Tags.ToList();
                model.ImageName = shoe.Picture;
                foreach (Tag tag in model.Tags)
                {
                    if (_context.ShoeTags.Where(t => t.Shoe_Id == id.Value && t.Tag_Id == tag.Id).FirstOrDefault() != null)
                    {
                        tag.SetTag = true;
                    }
                }
                return View(model);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
        [HttpPost]
        public async Task<ActionResult> Edit(EditVM model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            Shoe item = new Shoe();
            item.Id = model.Id;
            item.Name = model.Name;
            item.Price = model.Price;
            item.Size = model.Size;
            var file = model.Image[0];
            if (file != null)
            {
                if (file.Length > 0)
                {
                    string projectRootPath = _hostingEnvironment.ContentRootPath;
                    string path = Path.Combine(projectRootPath, "Images", Path.GetFileName(file.FileName));
                    using (Stream fileStream = new FileStream(path, FileMode.Create))
                    {
                        await file.CopyToAsync(fileStream);
                    }

                    item.Picture = Path.GetFileName(file.FileName);

                }
            }
            else
            {
                item.Picture = model.ImageName;
            }

            _context.Entry(item).State = EntityState.Modified;
            _context.SaveChanges();

            foreach (Tag tag in model.Tags)
            {
                if (_context.ShoeTags.Where(i => i.Tag_Id == tag.Id && i.Shoe_Id == model.Id).FirstOrDefault() != null)
                {
                    ShoeTag shoetag = _context.ShoeTags.Where(i => i.Tag_Id == tag.Id && i.Shoe_Id == model.Id).FirstOrDefault();
                    _context.ShoeTags.Remove(shoetag);
                    _context.SaveChanges();
                }

                if (tag.SetTag == true)
                {
                    ShoeTag tagShoe = new ShoeTag();
                    tagShoe.Tag_Id = tag.Id;
                    tagShoe.Shoe_Id = item.Id;
                    _context.ShoeTags.Add(tagShoe);
                    _context.SaveChanges();
                }
            }
            return RedirectToAction("Index", "Home");
        }
        public ActionResult Delete(int Id)
        {
            if (HttpContext.Session.GetString("Admin") != null)
            {
                Shoe item = _context.Shoes.Where(u => u.Id == Id)
                                         .FirstOrDefault();

                _context.Shoes.Remove(item);
                _context.SaveChanges();

                return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
        public ActionResult Purchases()
        {
            if (HttpContext.Session.GetString("Admin") != null)
            {
                PurchasesVM model = new PurchasesVM();
                model.orders = _context.Orders.ToList();
                return View(model);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
    }
}