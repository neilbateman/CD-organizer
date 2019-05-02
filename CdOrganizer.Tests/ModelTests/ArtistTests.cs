using Microsoft.VisualStudio.TestTools.UnitTesting;
using CdOrganizer.Models;
using System.Collections.Generic;
using System;

namespace CdOrganizer.Tests
{
  [TestClass]
  public class ArtistTest : IDisposable
  {

    public void Dispose()
    {
      Artist.ClearAll();
    }

    [TestMethod]
    public void ArtistConstructor_CreatesInstanceOfArtist_Artist()
    {
      Artist newArtist = new Artist("test category");
      Assert.AreEqual(typeof(Artist), newArtist.GetType());
    }

    [TestMethod]
    public void GetArtistName_ReturnsArtistName_String()
    {
      //Arrange
      string name = "Test Artist";
      Artist newArtist = new Artist(name);

      //Act
      string result = newArtist.GetArtistName();

      //Assert
      Assert.AreEqual(name, result);
    }


    [TestMethod]
    public void GetId_ReturnsArtistId_Int()
    {
      //Arrange
      string name = "Test Artist";
      Artist newArtist = new Artist(name);

      //Act
      int result = newArtist.GetId();

      //Assert
      Assert.AreEqual(1, result);
    }

    [TestMethod]
  public void GetAll_ReturnsAllArtistObjects_ArtistList()
  {
    //Arrange
    string name01 = "Work";
    string name02 = "School";
    Artist newArtist1 = new Artist(name01);
    Artist newArtist2 = new Artist(name02);
    List<Artist> newList = new List<Artist> { newArtist1, newArtist2 };

    //Act
    List<Artist> result = Artist.GetAll();

    //Assert
    CollectionAssert.AreEqual(newList, result);
  }
    [TestMethod]
    public void Find_REturnCorrectArtist_Artist()
    {
      string name01 = "Work";
      string name02 = "School";
      Artist newArtist1 = new Artist(name01);
      Artist newArtist2 = new Artist(name02);

      Artist result = Artist.Find(2);

      Assert.AreEqual(newArtist2, result);


    }
  }
}
