using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using ToysRoom.Toys;

namespace ToysRoom
{
    public class ToyRoom
    {
        private List<Toy> listToys;
        public List<Toy> ListToys { set { this.listToys = value; } get { return listToys; } }
        
        public int price
        {
            get
            {
                int sum = 0;
                foreach (Toy toy in listToys)
                    sum += toy.Price;
                return sum;

            }
        }

        public int maxPrice;
        public ToyRoom()
        {
            listToys = new List<Toy>();
            maxPrice = 1000;
        }
        public List<Toy> SortByPrice()
        {
            listToys.Sort();
            return listToys;
        }

        public Dictionary<string,List<Toy>> SortByType()
        {
            List<Toy> toys = new List<Toy>();
            Dictionary<string, List<Toy>> dictionary = new Dictionary<string, List<Toy>>();

            foreach (Toy toy in listToys)
            {
                if (toy is Ball)
                    toys.Add(toy);
            }
            dictionary.Add("Ball", toys);

            toys = new List<Toy>();
            foreach (Toy toy in listToys)
            {
                if (toy is Car)
                    toys.Add(toy);
            }
            dictionary.Add("Car", toys);

            toys = new List<Toy>();
            foreach (Toy toy in listToys)
            {
                if (toy is Doll)
                    toys.Add(toy);
            }
            dictionary.Add("Doll", toys);
            return dictionary;
        }

        public Dictionary<string, List<Toy>> SortByAge()
        {
            List<Toy> toys = new List<Toy>();
            Dictionary<string, List<Toy>> dictionary = new Dictionary<string, List<Toy>>();

            foreach (Toy toy in listToys)
            {
                if (toy.Age == "0-3")
                    toys.Add(toy);
            }
            dictionary.Add("0-3", toys);

            toys = new List<Toy>();
            foreach (Toy toy in listToys)
            {
                if (toy.Age == "3-6")
                    toys.Add(toy);
            }
            dictionary.Add("3-6", toys);

            toys = new List<Toy>();
            foreach (Toy toy in listToys)
            {
                if (toy.Age == "6-14")
                    toys.Add(toy);
            }
            dictionary.Add("6-14", toys);
            return dictionary;
        }

        public Dictionary<string, List<Toy>> SortBySize()
        {
            List<Toy> toys = new List<Toy>();
            Dictionary<string, List<Toy>> dictionary = new Dictionary<string, List<Toy>>();

            foreach (Toy toy in listToys)
            {
                if (toy.Size == "Small")
                    toys.Add(toy);
            }
            dictionary.Add("Small", toys);

            toys = new List<Toy>();
            foreach (Toy toy in listToys)
            {
                if (toy.Size == "Middle")
                    toys.Add(toy);
            }
            dictionary.Add("Middle", toys);

            toys = new List<Toy>();
            foreach (Toy toy in listToys)
            {
                if (toy.Size == "Big")
                    toys.Add(toy);
            }
            dictionary.Add("Big", toys);
            return dictionary;
        }

        public Dictionary<string, List<Toy>> SortByMaterial()
        {
            List<Toy> toys = new List<Toy>();
            Dictionary<string, List<Toy>> dictionary = new Dictionary<string, List<Toy>>();

            foreach (Toy toy in listToys)
            {
                if (toy.Material == "Wood")
                    toys.Add(toy);
            }
            dictionary.Add("Wood", toys);

            toys = new List<Toy>();
            foreach (Toy toy in listToys)
            {
                if (toy.Material == "Metal")
                    toys.Add(toy);
            }
            dictionary.Add("Metal", toys);

            toys = new List<Toy>();
            foreach (Toy toy in listToys)
            {
                if (toy.Material == "Rubber")
                    toys.Add(toy);
            }
            dictionary.Add("Rubber", toys);

            toys = new List<Toy>();
            foreach (Toy toy in listToys)
            {
                if (toy.Material == "Plastic")
                    toys.Add(toy);
            }
            dictionary.Add("Plastic", toys);
            return dictionary;
        }

        public bool AddNewToy(Toy toy)
        {
            if (this.price + toy.Price < maxPrice)
            {
                this.listToys.Add(toy);
                return true;
            }
            else return false;
        }

        public void Input(string file)
        {
            using (FileStream fs = new FileStream(file, FileMode.OpenOrCreate))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                this.listToys = (List<Toy>)formatter.Deserialize(fs);
            }
        }
       

        public void Output(string file)
        {
            using (FileStream fs = new FileStream(file, FileMode.OpenOrCreate))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(fs, listToys);
            }
        }
    }
}
