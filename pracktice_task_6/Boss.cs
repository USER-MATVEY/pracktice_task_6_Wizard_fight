using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pracktice_task_6
{
    internal class Boss
    {
        private int bossHP;
        private int bossDef;
        public readonly List<Spel> bossSpels;

        private Random bossDice;

        public int Hp { get { return bossHP; } set { bossHP = value; } }
        public int Def { get { return bossDef; } set { bossDef = value; } }

        public Boss()
        {
            Random random = new Random();
            bossHP = random.Next(100, 200);
            bossDef = random.Next(8, 14);
            bossDice = new Random();
            bossSpels = new List<Spel>();
        }

        public void GetStartBossSpels(List<Spel> glSpelList)
        {
            Random randomSpel = new Random();
            List<Spel> startBossSpels = new List<Spel>();

            startBossSpels.Add(glSpelList[randomSpel.Next(0, 4)]);
            startBossSpels.Add(glSpelList[randomSpel.Next(glSpelList.Count) / 2]);
            startBossSpels.Add(glSpelList[randomSpel.Next(glSpelList.Count)]);

            bossSpels.AddRange(startBossSpels);
        }

        public void DoTurn(Player player)
        {
            Random randSpel = new Random();
            if (bossDice.Next(1, 20) > player.Def)
            {
                Spel spelToCast = bossSpels[randSpel.Next(bossSpels.Count)];
                player.Hp -= spelToCast.CastSpell(spelToCast.RequredSpel);
                Console.WriteLine("Здоровье игрока: " + player.Hp);
            }
            else
            {
                Console.WriteLine("Заклинание Босса пролетает мимо!!");
            }
        }
    }
}
