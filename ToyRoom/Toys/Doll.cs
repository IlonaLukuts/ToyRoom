using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToysRoom.Toys
{
    [Serializable]
    class Doll:Toy
    {
        private bool speaking;

        public Doll() : base()
        {
            
        }

        public void SetParameters(string age, string size, string material, bool speaking)
        {
            this.speaking = speaking;
            base.SetParameters(age, size, material);
            GetPrice();
        }

        public override string GetDescription()
        {
            string line = "DOLL ";
            line += base.GetDescription();
            if (this.speaking)
                line += "speaking";
            else line += "not speaking";
            return line;
        }

        public void GetPrice()
        {
            this.price += Doll.PriceSpeaking(this.speaking);
            base.GetPrice("Doll");
        }

        public static int PriceSpeaking(bool currentSpeaking)
        {
            if (currentSpeaking)
                return 350;
            else return 150;
        }
    }
}
