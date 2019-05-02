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
      List<Item> artistItems = selectedArtist.GetItems();
      model.Add("artist", selectedArtist);
      model.Add("cds", artistItems);
      return View(model);
    }

    // This one creates new Items within a given Artist, not new Artists:
    [HttpPost("/artists/{artistId}/items")]
    public ActionResult Create(int artistId, string itemDescription)
    {
      Dictionary<string, object> model = new Dictionary<string, object>();
      Artist foundArtist = Artist.Find(artistId);
      Item newItem = new Item(itemDescription);
      foundArtist.AddItem(newItem);
      List<Item> artistItems = foundArtist.GetItems();
      model.Add("cds", artistItems);
      model.Add("artist", foundArtist);
      return View("Show", model);
    }

  }
}
