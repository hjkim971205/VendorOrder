using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Mvc;
using VendorOrder.Models;

namespace VendorOrder.Controllers
{
    public class VendorsController : Controller
    {

        [HttpGet("/vendors")]
        public ActionResult Index()
        {
            List<Vendor> allCategories = Vendor.GetAll();
            return View(allCategories);
        }

        [HttpGet("/vendors/new")]
        public ActionResult New()
        {
            return View();
        }

        [HttpPost("/vendors")]
        public ActionResult Create(string vendorName)
        {
            Vendor newVendor = new Vendor(vendorName);
            return RedirectToAction("Index");
        }

        [HttpGet("/vendors/{id}")]
        public ActionResult Show(int id)
        {
            Dictionary<string, object> model = new Dictionary<string, object>();
            Vendor selectedVendor = Vendor.Find(id);
            List<Item> vendorItems = selectedVendor.Items;
            model.Add("vendor", selectedVendor);
            model.Add("items", vendorItems);
            return View(model);
        }

        // This one creates new Items within a given Vendor, not new vendors:
        [HttpPost("/vendors/{vendorId}/items")]
        public ActionResult Create(int vendorId, string itemAlbum, string itemArtist, string itemRelease, string itemTitle)
        {
            Dictionary<string, object> model = new Dictionary<string, object>();
            Vendor foundVendor = Vendor.Find(vendorId);
            Item newItem = new Item(itemAlbum, itemArtist, itemRelease, itemTitle);
            foundVendor.AddItem(newItem);
            List<Item> vendorItems = foundVendor.Items;
            model.Add("items", vendorItems);
            model.Add("vendor", foundVendor);
            return View("Show", model);
        }
    }
}