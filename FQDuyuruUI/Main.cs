using Rocket.Core.Plugins;
using Rocket.Unturned.Player;
using SDG.Unturned;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace FQDuyuruUI
{
    public class Main : RocketPlugin<Config>
    {
        protected override void Load()
        {
            StartCoroutine(duyuruRutin());
        }

        protected override void Unload()
        {
            StopAllCoroutines();
        }

        public IEnumerator<WaitForSeconds> duyuruRutin()
        {
            while (true)
            {
                duyuru();
                yield return new WaitForSeconds(Configuration.Instance.beklemeAraligi);
            }
        }

        public void duyuru()
        {
            if(duyuruCount >= Configuration.Instance.Mesajlar.Count)
            {
                duyuruCount = 0;
            }

            String msg = Configuration.Instance.Mesajlar[duyuruCount];

            foreach(var steamPlayer in Provider.clients)
            {
                var player = UnturnedPlayer.FromSteamPlayer(steamPlayer);
                EffectManager.sendUIEffect(Configuration.Instance.effectID, 78, player.SteamPlayer().transportConnection, true, $"{msg}");
            }
            duyuruCount++;
            

        }

        private int duyuruCount = 0;

    }
}
