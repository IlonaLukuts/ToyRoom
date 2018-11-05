using Microsoft.VisualStudio.TestTools.UnitTesting;
using ToysRoom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToysRoom.Tests
{
    [TestClass()]
    public class ToyTests
    {
        [TestMethod()]
        public void ToyTest()
        {
            Toy toy = new Toy();
            int expected = 0;
            int actual = toy.Price;
            Assert.AreEqual(expected,actual);
        }

        [TestMethod()]
        public void SetParametersTest()
        {
            Toy toy = new Toy();
            toy.SetParameters("0-3", "Small", "Wood");
            string[] expected = new string[3] { "0-3", "Small", "Wood" };
            string[] actual = new string[3] { toy.Age, toy.Size, toy.Material };
            CollectionAssert.AreEqual(expected,actual);
        }

        [TestMethod()]
        public void CompareToTest()
        {
            Toy toy1 = new Toy();
            Toy toy2 = new Toy();
            toy1.SetParameters("0-3", "Small", "Wood");
            toy1.GetPrice("Ball");
            toy2.SetParameters("0-3", "Small", "Wood");
            toy2.GetPrice("Car");
            int expected = -1;
            int actual = toy1.CompareTo(toy2);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void GetDescriptionTest()
        {
            Toy toy1 = new Toy();
            toy1.SetParameters("0-3", "Small", "Wood");
            toy1.GetPrice("Ball");
            string expected = "0-3 Small Wood 200 ";
            string actual = toy1.GetDescription();
            Assert.AreEqual(expected,actual);
        }

        [TestMethod()]
        public void GetPriceTest()
        {
            Toy toy1 = new Toy();
            toy1.SetParameters("0-3", "Small", "Wood");
            int expected = 200;
            toy1.GetPrice("Ball");
            int actual = toy1.Price;
            Assert.AreEqual(expected,actual);
        }

        [TestMethod()]
        public void PriceAgeTest()
        {
            int expected = 35;
            int actual = Toy.PriceAge("3-6");
            Assert.AreEqual(expected,actual);
        }

        [TestMethod()]
        public void PriceSizeTest()
        {
            int expected = 150;
            int actual = Toy.PriceSize("Big");
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void PriceMaterialTest()
        {
            int expected = 66;
            int actual = Toy.PriceMaterial("Plastic");
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void PriceToyTest()
        {
            int expected = 300;
            int actual = Toy.PriceToy("Car");
            Assert.AreEqual(expected, actual);
        }
    }
}