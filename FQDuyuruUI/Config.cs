using Rocket.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FQDuyuruUI
{
    public class Config : IRocketPluginConfiguration
    {
        public void LoadDefaults()
        {
            effectID = 45896;
            beklemeAraligi = 30f;
            Mesajlar = new List<string>() { 
                "deneme1",
                "deneme2"
            };
        }

        public float beklemeAraligi;
        public ushort effectID;
        public List<String> Mesajlar;
    }
}
