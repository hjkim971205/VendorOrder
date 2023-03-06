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
            List<Order> vendorOrders = selectedVendor.Orders;
            model.Add("vendor", selectedVendor);
            model.Add("orders", vendorOrders);
            return View(model);
        }

        // This one creates new Orders within a given Vendor, not new vendors:
        [HttpPost("/vendors/{vendorId}/orders")]
        public ActionResult Create(int vendorId, string orderName, string orderLocation, string orderDue, int orderQuantity)
        {
            Dictionary<string, object> model = new Dictionary<string, object>();
            Vendor foundVendor = Vendor.Find(vendorId);
            Order newOrder = new Order(orderName, orderLocation, orderDue, orderQuantity);
            foundVendor.AddOrder(newOrder);
            List<Order> vendorOrders = foundVendor.Orders;
            model.Add("orders", vendorOrders);
            model.Add("vendor", foundVendor);
            return View("Show", model);
        }
    }
}