using Microsoft.AspNetCore.Mvc;
using VendorOrder.Models;
using System.Collections.Generic;

namespace VendorOrder.Controllers
{
  public class ItemsController : Controller
  {

    [HttpGet("/vendors/{vendorId}/items/new")]
    public ActionResult New(int vendorId)
    {
      Vendor vendor = Vendor.Find(vendorId);
      return View(vendor);
    }

    [HttpGet("/vendors/{vendorId}/items/{itemId}")]
    public ActionResult Show(int vendorId, int itemId)
    {
      Item item = Item.Find(itemId);
      Vendor vendor = Vendor.Find(vendorId);
      Dictionary<string, object> model = new Dictionary<string, object>();
      model.Add("item", item);
      model.Add("vendor", vendor);
      return View(model);
    }
  }
}