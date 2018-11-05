using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToysRoom.Toys
{
    [Serializable]
    class Ball:Toy
    {
        private string color;
        private bool gameOrSport;

        public Ball() : base()
        {

        }

        public override string GetDescription()
        {
            string line = "BALL ";
            line += base.GetDescription();
            line += this.color + " ";
            if (this.gameOrSport)
                line += "game";
            else line += "sport";
            return line;
        }

        public void SetParameters(string age, string size, string material, string color, bool gameOrSport)
        {
            this.color = color;
            this.gameOrSport = gameOrSport;
            base.SetParameters(age, size, material);
            GetPrice();
        }
        public void GetPrice()
        {
            this.price += Ball.PriceColor(this.color);
            this.price += Ball.PriceGame(this.gameOrSport);
            base.GetPrice("Ball");
        }

        public static int PriceColor(string currentColor)
        {
            switch (currentColor)
            {
                case "Red": return 1;
                case "Orange": return 2;
                case "Yellow": return 3;
                case "Green": return 4;
                case "Sky-blue": return 5;
                case "Blue": return 6;
                case "Purple": return 7;
                case "Pink": return 8;
                case "Black": return 9;
                case "White": return 10;
            }
            return 0;
        }
        public static int PriceGame(bool currentGameOrSport)
        {
            if (currentGameOrSport)
                return 20;
            else return 80;
        }
    }
}
