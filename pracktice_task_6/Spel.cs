using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pracktice_task_6
{
    internal class Spel
    {
        private string name;
        private Random DamageRandom = new Random();
        private int maxDamage;
        private int minDamage;
        Boolean needOtherSpelToCast;                // TODO: include
        private string requaredSpelForCastThisSpel; // TODO: include
        public string description;                  // TODO: include

        public string Name { get { return name; } }

        public string RequredSpel { get { return requaredSpelForCastThisSpel; } }

        public Spel()
        {
            name = "puf";
            maxDamage = 6;
        }

        public Spel(string spelName, int spelMaxDamage, int spelMinDamage)
        {
            name = spelName;
            maxDamage = spelMaxDamage;
            minDamage = spelMinDamage;
        }

        public Spel(string spelName, int spelMaxDamage, int spelMinDamage, string otherSplesName)
        {
            name = spelName;
            maxDamage = spelMaxDamage;
            minDamage = spelMinDamage;
            needOtherSpelToCast = true;
            requaredSpelForCastThisSpel = otherSplesName;
        }

        public int CastSpell(string lastCastedSpel)
        {
            int damage = DamageRandom.Next(minDamage, maxDamage+1);
            if (needOtherSpelToCast)
            {
                if (lastCastedSpel == requaredSpelForCastThisSpel)
                {

                    Console.WriteLine(name + " наносит " + damage + " урона.");
                    return damage;
                }
                else
                {
                    Console.WriteLine("заклинание не удалось создать!!");
                }
            }
            else
            {
                Console.WriteLine(name + " наносит " + damage + " урона.");
                return damage;
            }
            return 4;
        }
    }
}
