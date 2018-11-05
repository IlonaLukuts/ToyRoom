using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToysRoom.Toys
{
    [Serializable]
    class Car:Toy
    {
        private bool inercicOrMechanic;
        private string type;

        public Car() : base()
        {
            
        }

        public void SetParameters(string age, string size, string material, bool inercicOrMechanic, string type)
        {
            this.inercicOrMechanic = inercicOrMechanic;
            this.type = type;
            base.SetParameters(age, size, material);
            GetPrice();
        }

        public override string GetDescription()
        {
            string line = "CAR ";
            line += base.GetDescription();
            line += " " + this.type + " ";
            if (this.inercicOrMechanic)
                line += "inercic";
            else line += "mechanic";
            return line;
        }

        public void GetPrice()
        {
            this.price += Car.PriceInercic(this.inercicOrMechanic);
            this.price += Car.PriceType(this.type);
            base.GetPrice("Car");
        }

        public static int PriceInercic(bool currentInercicOrMechanic)
        {
            if (currentInercicOrMechanic)
                return 200;
            else return 100;
        }

        public static int PriceType(string currentType)
        {
            switch(currentType)
            {
                case "Ambulance": return 25;
                case "Police": return 30;
                case "Fire": return 35;
                case "Racing": return 40;
                case "Cars": return 45;
            }
            return 0;
        }
    }
}
