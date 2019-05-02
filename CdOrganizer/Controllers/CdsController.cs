using Microsoft.AspNetCore.Mvc;
using CdOrganizer.Models;
using System.Collections.Generic;

namespace CdOrganizer.Controllers
{
  public class CdsController : Controller
  {

    [HttpGet("/artists/{artistId}/cds/new")]
    public ActionResult New(int artistId)
    {
       Artist artist = Artist.Find(artistId);
       return View(artist);
    }

    [HttpGet("/artists/{artistId}/cds/{cdId}")]
    public ActionResult Show(int artistId, int cdId)
    {
      Cd cd = Cd.Find(cdId);
      Dictionary<string, object> model = new Dictionary<string, object>();
      Artist artist = Artist.Find(artistId);
      model.Add("cd", cd);
      model.Add("artist", artist);
      return View(model);
    }

    [HttpPost("/cds/delete")]
    public ActionResult DeleteAll()
    {
      Cd.ClearAll();
      return View();
    }

  }
}
