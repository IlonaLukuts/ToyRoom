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
    public class ToyRoomTests
    {
        [TestMethod()]
        public void ToyRoomTest()
        {
            ToyRoom toyRoom = new ToyRoom();
            int expected = 1000;
            int actual = toyRoom.maxPrice;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void SortByPriceTest()
        {
            ToyRoom toyRoom = new ToyRoom();
            toyRoom.maxPrice = 15000;
            Toy toy = new Toy();
            Toy toy1 = new Toy();
            Toy toy2 = new Toy();
            Toy toy3 = new Toy();
            toy.SetParameters("3-6", "Middle", "Metal");
            toy.GetPrice("Doll"); 
            toy1.SetParameters("6-14", "Big", "Rubber");
            toy1.GetPrice("Car");
            toy2.SetParameters("0-3", "Small", "Plastic");
            toy2.GetPrice("Car");
            toy3.SetParameters("0-3", "Small", "Wood");
            toy3.GetPrice("Ball");
            toyRoom.AddNewToy(toy);
            toyRoom.AddNewToy(toy1);
            toyRoom.AddNewToy(toy2);
            toyRoom.AddNewToy(toy3);
            //toy.Price = 427  || toy1.Price = 554  || toy2.Price = 436  || toy3.Price = 200
            List<Toy> expected = new List<Toy>();
            expected.Add(toy3);
            expected.Add(toy);
            expected.Add(toy2);
            expected.Add(toy1);
            List<Toy> actual = toyRoom.SortByPrice();
            CollectionAssert.AreEqual(expected, actual);
        }
        

        [TestMethod()]
        public void SortByAgeTest()
        {
            ToyRoom toyRoom = new ToyRoom();
            toyRoom.maxPrice = 15000;
            Toy toy = new Toy();
            Toy toy1 = new Toy();
            Toy toy2 = new Toy();
            Toy toy3 = new Toy();
            toy.SetParameters("3-6", "Middle", "Metal");
            toy.GetPrice("Doll");
            toy1.SetParameters("6-14", "Big", "Rubber");
            toy1.GetPrice("Car");
            toy2.SetParameters("0-3", "Small", "Plastic");
            toy2.GetPrice("Car");
            toy3.SetParameters("0-3", "Small", "Wood");
            toy3.GetPrice("Ball");
            toyRoom.AddNewToy(toy);
            toyRoom.AddNewToy(toy1);
            toyRoom.AddNewToy(toy2);
            toyRoom.AddNewToy(toy3);
            //toy.Price = 427  || toy1.Price = 554  || toy2.Price = 436  || toy3.Price = 200
            Dictionary<string, List<Toy>> expected = new Dictionary<string, List<Toy>>();
            List<Toy> list1 = new List<Toy>();
            list1.Add(toy2);
            list1.Add(toy3);
            expected.Add("0-3", list1);
            var list2 = new List<Toy>();
            list2.Add(toy);
            expected.Add("3-6", list2);
            var list3 = new List<Toy>();
            list3.Add(toy1);
            expected.Add("6-14", list3);
            Dictionary<string, List<Toy>> actual = toyRoom.SortByAge();
            Assert.AreEqual(ToAssertableString(expected), ToAssertableString(actual));
        }

        public string ToAssertableString(Dictionary<string, List<Toy>> dictionary)
        {
            var str = new StringBuilder("");
            foreach(var item in dictionary)
            {
                str.Append(item.Key);
                foreach(var i in item.Value)
                {
                    str.Append($"{i.GetDescription()};");
                }
            }
            return str.ToString();
        }

        [TestMethod()]
        public void SortBySizeTest()
        {
            ToyRoom toyRoom = new ToyRoom();
            toyRoom.maxPrice = 15000;
            Toy toy = new Toy();
            Toy toy1 = new Toy();
            Toy toy2 = new Toy();
            Toy toy3 = new Toy();
            toy.SetParameters("3-6", "Middle", "Metal");
            toy.GetPrice("Doll");
            toy1.SetParameters("6-14", "Big", "Rubber");
            toy1.GetPrice("Car");
            toy2.SetParameters("0-3", "Small", "Plastic");
            toy2.GetPrice("Car");
            toy3.SetParameters("0-3", "Small", "Wood");
            toy3.GetPrice("Ball");
            toyRoom.AddNewToy(toy);
            toyRoom.AddNewToy(toy1);
            toyRoom.AddNewToy(toy2);
            toyRoom.AddNewToy(toy3);
            //toy.Price = 427  || toy1.Price = 554  || toy2.Price = 436  || toy3.Price = 200
            Dictionary<string, List<Toy>> expected = new Dictionary<string, List<Toy>>();
            List<Toy> list = new List<Toy>();
            list.Add(toy2);
            list.Add(toy3);
            expected.Add("Small", list);
            list = new List<Toy>();
            list.Add(toy);
            expected.Add("Middle", list);
            list = new List<Toy>();
            list.Add(toy1);
            expected.Add("Big", list);
            Dictionary<string, List<Toy>> actual = toyRoom.SortBySize();
            Assert.AreEqual(ToAssertableString(expected), ToAssertableString(actual));
        }

        [TestMethod()]
        public void SortByMaterialTest()
        {
            ToyRoom toyRoom = new ToyRoom();
            toyRoom.maxPrice = 15000;
            Toy toy = new Toy();
            Toy toy1 = new Toy();
            Toy toy2 = new Toy();
            Toy toy3 = new Toy();
            toy.SetParameters("3-6", "Middle", "Metal");
            toy.GetPrice("Doll");
            toy1.SetParameters("6-14", "Big", "Rubber");
            toy1.GetPrice("Car");
            toy2.SetParameters("0-3", "Small", "Plastic");
            toy2.GetPrice("Car");
            toy3.SetParameters("0-3", "Small", "Wood");
            toy3.GetPrice("Ball");
            toyRoom.AddNewToy(toy);
            toyRoom.AddNewToy(toy1);
            toyRoom.AddNewToy(toy2);
            toyRoom.AddNewToy(toy3);
            //toy.Price = 427  || toy1.Price = 554  || toy2.Price = 436  || toy3.Price = 200
            Dictionary<string, List<Toy>> expected = new Dictionary<string, List<Toy>>();
            List<Toy> list = new List<Toy>();
            list.Add(toy3);
            expected.Add("Wood", list);
            list = new List<Toy>();
            list.Add(toy);
            expected.Add("Metal", list);
            list = new List<Toy>();
            list.Add(toy1);
            expected.Add("Rubber", list);
            list = new List<Toy>();
            list.Add(toy2);
            expected.Add("Plastic", list);
            Dictionary<string, List<Toy>> actual = toyRoom.SortByMaterial();
            Assert.AreEqual(ToAssertableString(expected), ToAssertableString(actual));
        }
    }
}