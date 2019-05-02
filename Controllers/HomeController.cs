using Microsoft.AspNetCore.Mvc;
using CdOrganizer.Models;
using System.Collections.Generic;

namespace CdOrganizer.Controllers
{
  public class HomeController : Controller
  {

    [HttpGet("/")]
    public ActionResult Index()
    {
      return View();
    }
  }
}
