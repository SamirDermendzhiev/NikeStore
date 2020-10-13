using NikeStore.Entities;
using NikeStore.Models;
using NikeStore.ViewModels.Admin;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NikeStore.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult AddModel()
        {
            if (Session["Admin"] != null)
            {
                AddModelVM model = new AddModelVM();
                NikeContext context = new NikeContext();

                model.Tags = context.Tags.ToList();
                return View(model);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
        [HttpPost]
        public ActionResult AddModel(AddModelVM model)
        {
            var file = model.Image[0];
            if (file == null || file.ContentLength <= 0)
            {
                ModelState.AddModelError("", "Please upload file!");
            }
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            NikeContext context = new NikeContext();
            Shoe item = new Shoe();


            try
            {
                string path = Path.Combine(Server.MapPath("~/Images/" + Path.GetFileName(file.FileName)));
                file.SaveAs(path);
                item.Picture = Path.GetFileName(file.FileName);
            }
            catch (Exception)
            {

                throw;
            }
            item.Name = model.Name;
            item.Price = model.Price;
            item.Size = model.Size;
            context.Shoes.Add(item);
            int id = item.Id;
            context.SaveChanges();

            foreach (Tag tag in model.Tags)
            {
                if (tag.SetTag == true)
                {
                    ShoeTag tagShoe = new ShoeTag();
                    tagShoe.Tag_Id = tag.Id;
                    tagShoe.Shoe_Id = item.Id;
                    context.ShoeTags.Add(tagShoe);
                    context.SaveChanges();
                }
            }
            return RedirectToAction("AddModel", "Admin");
        }
        public ActionResult AddTag(AddModelVM model)
        {
            NikeContext context = new NikeContext();
            Tag item = new Tag();
            item.Name = model.AddTag;
            context.Tags.Add(item);
            context.SaveChanges();

            return RedirectToAction("AddModel", "Admin", model);
        }
        [HttpGet]
        public ActionResult Edit(int? id)
        {

            if (Session["Admin"] != null)
            {
                
            
                NikeContext context = new NikeContext();
                Shoe shoe = id == null ? new Shoe() :
                                   context.Shoes.Where(i => i.Id == id.Value).FirstOrDefault();

                if (shoe == null)
                    return RedirectToAction("Index", "Home");
                EditVM model = new EditVM();
                model.Name = shoe.Name;
                model.Price = shoe.Price;
                model.Size = shoe.Size;
                model.Tags = context.Tags.ToList();
                model.ImageName = shoe.Picture;
                foreach (Tag tag in model.Tags)
                {
                    if (context.ShoeTags.Where(t => t.Shoe_Id == id.Value && t.Tag_Id == tag.Id).FirstOrDefault() != null)
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
        public ActionResult Edit(EditVM model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            NikeContext context = new NikeContext();
            Shoe item = new Shoe();
            item.Id = model.Id;
            item.Name = model.Name;
            item.Price = model.Price;
            item.Size = model.Size;           
            var file = model.Image[0];
            if (file != null )
            {
                if (file.ContentLength > 0)
                {
                    try
                    {
                        string path = Path.Combine(Server.MapPath("~/Images/" + Path.GetFileName(file.FileName)));
                        file.SaveAs(path);
                        item.Picture = Path.GetFileName(file.FileName);
                    }
                    catch (Exception)
                    {

                        throw;
                    }
                }             
            }
            else
            {
                item.Picture = model.ImageName;
            }
           
            context.Entry(item).State = EntityState.Modified;
            context.SaveChanges();

            foreach (Tag tag in model.Tags)
            {
                if (context.ShoeTags.Where(i => i.Tag_Id == tag.Id && i.Shoe_Id == model.Id).FirstOrDefault() != null)
                {
                    ShoeTag shoetag = context.ShoeTags.Where(i => i.Tag_Id == tag.Id && i.Shoe_Id == model.Id).FirstOrDefault();
                    context.ShoeTags.Remove(shoetag);
                    context.SaveChanges();
                }
               
                if (tag.SetTag == true)
                {
                    ShoeTag tagShoe = new ShoeTag();
                    tagShoe.Tag_Id = tag.Id;
                    tagShoe.Shoe_Id = item.Id;
                    context.ShoeTags.Add(tagShoe);
                    context.SaveChanges();
                }
            }
            return RedirectToAction("Index", "Home");
        }
        public ActionResult Delete(int Id)
        {
            if (Session["Admin"] != null)
            {

            
                NikeContext context = new NikeContext();

                Shoe item = context.Shoes.Where(u => u.Id == Id)
                                         .FirstOrDefault();

                context.Shoes.Remove(item);
                context.SaveChanges();

                return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
        public ActionResult Purchases()
        {
            if (Session["Admin"] != null)
            {
                NikeContext context = new NikeContext();
                PurchasesVM model = new PurchasesVM();
                model.orders = context.Orders.ToList();
                return View(model);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }    
        }
    }
}