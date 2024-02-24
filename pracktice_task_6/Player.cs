using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pracktice_task_6
{
    internal class Player
    {
        private int playerHp;
        private int playerDef;
        public List<Spel> playerSpels;
        private List<string> playerSupportSpels = new List<string> {"heal", "blade ward", "resistance"};
        private string lastCastedSpel;

        private Random playerDice;

        public int Hp { get { return playerHp; } set { playerHp = value; } }
        public int Def { get { return playerDef; } }

        public Player()
        {
            playerHp = 75;
            playerDef = 13;
            playerDice = new Random();
            playerSpels = new List<Spel>();
            lastCastedSpel = "puf";
        }

        public void GetStartPlayerSpels(List<Spel> glSpelList)
        {
            Random randomSpel = new Random();
            List<Spel> playerStartSpels = new List<Spel>();

            int SpelsCounter = 0;
            while (SpelsCounter < 6) 
            {
                Spel SpeltoAdd = glSpelList[randomSpel.Next(glSpelList.Count)];
                if (playerStartSpels.Contains(SpeltoAdd)) { continue; }
                else
                {
                    playerStartSpels.Add(SpeltoAdd);
                    SpelsCounter++;
                }
            }
            playerSpels.AddRange(playerStartSpels);
        }

        private void PrintPlayerSpels()
        {
            for (int i = 0; i < playerSpels.Count; i++)
            {
                Console.WriteLine(playerSpels[i].Name);
            }
            for (int i = 0;i < playerSupportSpels.Count; i++)
            {
                Console.WriteLine(playerSupportSpels[i]);
            }
        }

        public void DoTurn(Boss boss)
        {
            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine("Ваш ход.\nВыберите заклитнание для каста:");
            PrintPlayerSpels();
            Console.WriteLine("-------------------------------------------------");
            Console.Write("Ваш Выбор: ");
            string spelToCast = Console.ReadLine().ToLower();

            if (playerSupportSpels.Contains(spelToCast)) 
            {
                switch (spelToCast)
                {
                    case "heal": playerHp = 75; break;
                    case "blade ward":
                        {
                            playerDef++; boss.Def -= 2; 
                            playerSupportSpels.Remove(spelToCast); 
                            break;
                        }
                    case "resistance":
                        {
                            playerDef += 3; 
                            playerSupportSpels.Remove(spelToCast); 
                            break;
                        }
                }
            }
            
            for (int i = 0; i < playerSpels.Count; i++)
            {
                if (playerSpels[i].Name == spelToCast)
                {
                    int attackRoll = playerDice.Next(1, 21);
                    if (attackRoll == 20)
                    {
                        boss.Hp -= playerSpels[i].CastSpell(lastCastedSpel) * 3;
                        Console.WriteLine("Критическое попадание!! Урон увеличен втрое!!");
                        break;
                    }
                    else if (attackRoll >= boss.Def)
                    {
                        boss.Hp -= playerSpels[i].CastSpell(lastCastedSpel);
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Вы промазали заклинанием!!");
                        break;
                    }
                }
            }
            Console.WriteLine("Здоровье босса: " + boss.Hp);
            lastCastedSpel = spelToCast;
        }
    }
}
