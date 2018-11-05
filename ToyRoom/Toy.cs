using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToysRoom
{
    [Serializable]
    public class Toy:IComparable<Toy>, IEquatable<Toy>
    {
        public string Age { get; private set; }
        private string size;
        public string Size { get { return size; } }
        private string material;
        public string Material { get { return material; } }
        protected int price;
        public int Price { get { return price; } }

        public Toy()
        {
            this.price = 0;
        }

        public void SetParameters(string age, string size, string material)
        {
            this.Age = age;
            this.size = size;
            this.material = material;
        }

        public int CompareTo(Toy other)
        {
            if (this.Price > other.Price)
                return 1;
            if (this.Price < other.Price)
                return -1;
            return 0;
        }

        public virtual string GetDescription()
        {
            string line = this.Age + " " + this.size + " " + this.material + " " + this.Price + " ";
            return line;
        }

        public void GetPrice(string toy)
        {
            this.price += Toy.PriceToy(toy);
            this.price += Toy.PriceAge(this.Age);
            this.price += Toy.PriceSize(this.size);
            this.price += Toy.PriceMaterial(this.material);
        }

        public static int PriceAge(string currentAge)
        {
            switch (currentAge)
            {
                case "0-3": return 20;
                case "3-6": return 35;
                case "6-14": return 50;
            }
            return 0;
        }

        public static int PriceSize(string currentSize)
        {
            switch(currentSize)
            {
                case "Small": return 50;
                case "Middle": return 100;
                case "Big": return 150;
            }
            return 0;
        }

        public static int PriceMaterial(string currentMaterial)
        {
            switch(currentMaterial)
            {
                case "Wood": return 30;
                case "Metal": return 42;
                case "Rubber": return 54;
                case "Plastic": return 66;
            }
            return 0;
        }
        public static int PriceToy(string currentToy)
        {
            switch (currentToy)
            {
                case "Ball": return 100;
                case "Car": return 300;
                case "Doll": return 250;
            }
            return 0;
        }

        public bool Equals(Toy other)
        {
            if (this.Age != other.Age) return false;
            if (this.Material != other.Material) return false;
            if (this.Price != other.Price) return false;
            if (this.Size != other.Size) return false;
            return true;
        }
    }
}
