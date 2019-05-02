using System.Collections.Generic;

namespace CdOrganizer.Models
{
  public class Artist
  {
    private static List<Artist> _instances = new List<Artist> {};
    private string _artistName;
    private int _id;
    private List<Cd> _cds;


    public Artist(string artistName)
    {
      _artistName = artistName;
      _instances.Add(this);
      _id = _instances.Count;
      _cds = new List<Cd>{};
    }

    public static void ClearAll()
    {
      _instances.Clear();
    }

    public string GetArtistName()
    {
      return _artistName;
    }
    public int GetId()
    {
      return _id;
    }
    public static List<Artist> GetAll()
    {
      return _instances;
    }

    public void AddCd(Cd newCd)
    {
      _cds.Add(newCd);
    }

    public List<Cd> GetCd()
    {
      return _cds;
    }

    public static Artist Find(int searchId)
    {
      return _instances[searchId-1];
    }

  }
}
