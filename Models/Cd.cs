using System.Collections.Generic;

namespace CdOrganizer.Models
{
  public class Cd
  {
    public string Description { get; set; }
    public int Id { get; set; }
    private static List <Cd> _cdList = new List<Cd> {};

    public Cd (string description)
    {
      Description = description;
    }
    public static List<Cd> GetAll()
    {
      return _cdList;
    }

    public static void ClearAll()
    {
      _cdList.Clear();
    }
  }

}
