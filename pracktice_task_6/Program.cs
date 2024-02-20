using System;
using System.Collections.Generic;

namespace pracktice_task_6
{
    class Program
    {
        List<Spel> globalSpelsList = new List<Spel>()
        {
            new Spel("magic Bolt", 10),
            new Spel("magic Rocket", 30),
            new Spel("magic spining Bolt", 20),
        };

        static void Main(string[] args)
        {
            Player player = new Player();
            Boss boss = new Boss();


            //TODO ZA GAME
        }
    }

    public class Spel
    {
        private string name;
        private Random DamageRandom;
        private int maxDamage;
        private string requaredSpelForCastThisSpel; //TODO: include

        Spel()
        {
            name = "puf";
            maxDamage = 6;
            requaredSpelForCastThisSpel = "";
        }

        public Spel(string spelName, int spelDamage)
        {
            name = spelName;
            maxDamage = spelDamage;
        }

        public int CastSpell()
        {
            return DamageRandom.Next(1, maxDamage);
        }
    }

    class Boss
    {
        private int bossHP;
        private List<Spel> bossSpels;

        public Boss()
        {
            Random randomHP = new Random();
            bossHP = randomHP.Next(100, 200);
            bossSpels = GetStartBossSpels();
        }

        private List<Spel> GetStartBossSpels()
        {
            List<Spel> startBossSpels = new List<Spel>();

            //TODO

            return startBossSpels;
        }

        public void BossCastSpel()
        {
            //TODO
        }
    }

    class Player
    {
        private int playerHp;
        private List<Spel> playerSpels;

        public Player()
        {
            playerHp = 50;
            playerSpels = GetStartPlayerSpels();
        }

        private List<Spel> GetStartPlayerSpels()
        {
            List<Spel> playerStartSpels = new List<Spel>;

            //TODO

            return playerStartSpels;
        }
    }
}
