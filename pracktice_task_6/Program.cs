using System;
using System.Collections.Generic;

namespace pracktice_task_6
{
    class Program
    {
        static List<Spel> globalSpelsList = new List<Spel>()
        {
            new Spel("magic bolt", 10),
            new Spel("magic rocket", 30),
            new Spel("magic spining bolt", 20),
        };

        static void Main(string[] args)
        {
            Player player = new Player();
            Boss boss = new Boss();
            Boolean game = true;
            Boolean turn = true;

            player.GetStartPlayerSpels(globalSpelsList);
            boss.GetStartBossSpels(globalSpelsList);

            while (game)
            {
                if (player.Hp <= 0)
                {
                    Console.WriteLine("\n------------------------------------");
                    Console.WriteLine("Вы погибли!!");
                    break;
                }

                if (boss.Hp <= 0)
                {
                    Console.WriteLine("\n------------------------------------");
                    Console.WriteLine("Вы Выйграли!!!");
                    break;
                }

                if (turn)
                {
                    player.DoTurn(boss);
                    turn = false;
                }   //TODO ZA GAME
                else
                {
                    boss.DoTurn(player);
                    turn = true;
                }
            }
        }
    }

    public class Spel
    {
        private string name;
        private Random DamageRandom = new Random();
        private int maxDamage;
        Boolean needOtherSpelToCast;                // TODO: include
        private string requaredSpelForCastThisSpel; // TODO: include
        public string description;                  // TODO: include

        public string Name { get { return name; } }

        Spel()
        {
            name = "puf";
            maxDamage = 6;
        }

        public Spel(string spelName, int spelDamage)
        {
            name = spelName;
            maxDamage = spelDamage;
        }

        public int CastSpell()
        {
            int damage = DamageRandom.Next(1, maxDamage);
            Console.WriteLine(name + " наносит " + damage + " урона.");
            return damage;
        }
    }

    class Boss
    {
        private int bossHP;
        public readonly List<Spel> bossSpels;

        public int Hp { get { return bossHP; } set { bossHP = value; } }

        public Boss()
        {
            Random randomHP = new Random();
            bossHP = randomHP.Next(100, 200);
            bossSpels = new List<Spel>();
        }

        public void GetStartBossSpels(List<Spel> glSpelList)
        {
            Random randomSpel = new Random();
            List<Spel> startBossSpels = new List<Spel>();

            startBossSpels.Add(glSpelList[randomSpel.Next(glSpelList.Count)]);
            startBossSpels.Add(glSpelList[randomSpel.Next(glSpelList.Count)]);

            bossSpels.AddRange(startBossSpels);
        }

        public void DoTurn(Player player)
        {
            Random randSpel = new Random();
            player.Hp -= bossSpels[randSpel.Next(bossSpels.Count)].CastSpell();
            Console.WriteLine("Здоровье игрока: " + player.Hp);
        }
    }

    class Player
    {
        private int playerHp;
        public List<Spel> playerSpels;
        private string lastCastedSpel;

        public int Hp { get { return playerHp; } set { playerHp = value; } }

        public Player()
        {
            playerHp = 50;
            playerSpels = new List<Spel>();
            lastCastedSpel = "puf";
        }

        public void GetStartPlayerSpels(List<Spel> glSpelList)
        {
            Random randomSpel = new Random();
            List<Spel> playerStartSpels = new List<Spel>();

            playerStartSpels.Add(glSpelList[randomSpel.Next(glSpelList.Count)]);
            playerStartSpels.Add(glSpelList[randomSpel.Next(glSpelList.Count)]);

            playerSpels.AddRange(playerStartSpels);
        }

        private void PrintPlayerSpels()
        {
            for(int i=0; i < playerSpels.Count; i++)
            {
                Console.WriteLine(playerSpels[i].Name);
            }
        }

        public void DoTurn(Boss boss)
        {
            Console.WriteLine("Ваш ход.\nВыберите заклитнание для каста:");
            PrintPlayerSpels();
            string spelToCast = Console.ReadLine().ToLower();

            for(int i=0; i < playerSpels.Count; i++)
            {
                if (playerSpels[i].Name == spelToCast)
                {
                    boss.Hp -= playerSpels[i].CastSpell();
                    Console.WriteLine("Здоровье босса: " + boss.Hp);
                    break;
                }
            }
        }
    }
}
