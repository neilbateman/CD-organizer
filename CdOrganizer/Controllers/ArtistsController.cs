using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Mvc;
using CdOrganizer.Models;

namespace CdOrganizer.Controllers
{
  public class ArtistsController : Controller
  {

    [HttpGet("/artists")]
    public ActionResult Index()
    {
      List<Artist> allArtists = Artist.GetAll();
      return View(allArtists);
    }

    [HttpGet("/artists/new")]
    public ActionResult New()
    {
      return View();
    }

    [HttpPost("/artists")]
    public ActionResult Create(string artistName)
    {
      Artist newArtist = new Artist(artistName);
      List<Artist> allArtists = Artist.GetAll();
      return View("Index", allArtists);
    }

    [HttpGet("/artists/{id}")]
    public ActionResult Show(int id)
    {
      Dictionary<string, object> model = new Dictionary<string, object>();
      Artist selectedArtist = Artist.Find(id);
      List<Cd> artistCds = selectedArtist.GetCd();
      model.Add("artist", selectedArtist);
      model.Add("cds", artistCds);
      return View(model);
    }

    // This one creates new Cds within a given Artist, not new Artists:
    [HttpPost("/artists/{artistId}/cds")]
    public ActionResult Create(int artistId, string cdDescription)
    {
      Dictionary<string, object> model = new Dictionary<string, object>();
      Artist foundArtist = Artist.Find(artistId);
      Cd newCd = new Cd(cdDescription);
      foundArtist.AddCd(newCd);
      List<Cd> artistCds = foundArtist.GetCd();
      model.Add("cds", artistCds);
      model.Add("artist", foundArtist);
      return View("Show", model);
    }

  }
}
