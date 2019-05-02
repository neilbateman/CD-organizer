using System.Collections.Generic;

namespace CdOrganizer.Models
{
  public class Cd
  {
    private string _description;
    private int _id;
    private static List <Cd> _cdList = new List<Cd> {};

    public Cd (string description)
    {
      _description = description;
    }

    public static List<Cd> GetAll()
    {
      return _cdList;
    }

    public string GetDescription()
    {
      return _description;
    }

    public int GetId()
    {
      return _id;
    }

    public void SetDescription(string description)
    {
      _description = description;
    }

    public void SetId(int id)
    {
      _id = id;
    }

    public static void ClearAll()
    {
      _cdList.Clear();
    }
    public static Cd Find(int searchId)
    {
      return _cdList[searchId-1];
    }
  }

}
