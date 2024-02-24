using System;
using System.Collections.Generic;

namespace pracktice_task_6
{
    class Main_Game
    {
        // камень, Огненный снаряд, Магическая стрела, Погребальный звон 
        // Защита от оружия, Сопротивление, Лечение ран
        // Электошок -> Лассо молний -> Громовой клинок
        // Мистический заряд -> Потусторонний ВЗРЫВ
        // Луч холода -> Разрывной Лёд
        static List<Spel> globalSpelsList = new List<Spel>()
        {
            new Spel(),
            new Spel("magic rock", 10, 1),
            new Spel("magic missle", 15, 3),
            new Spel("toll of the dead", 12, 4),
            new Spel("fire bolt", 10, 2),
            new Spel("shocking grasp", 8, 2),
            new Spel("lightning lure", 16, 8, "shocking grasp"),
            new Spel("lightning blade", 32, 16, "lightning lure"),
            new Spel("mystic bolt", 12, 2),
            new Spel("eldritch blast", 50, 30, "mystic bolt"),
            new Spel("ray of frost", 10, 2),
            new Spel("rupture of ice", 30, 15, "ray of frost"),
        };

        static void Main(string[] args)
        {
            Player player = new Player();
            Boss boss = new Boss();
            Boolean game = true;
            Boolean turn = true;

            player.GetStartPlayerSpels(globalSpelsList);
            boss.GetStartBossSpels(globalSpelsList);

            Console.WriteLine("Вы - начинающий маг. Вас отправили на ваше первое задание по уничтожению демона.");
            Console.WriteLine("Демон не должен быть особо силён, но и вы не особо опытны. . .");
            Console.WriteLine("Вам нужно правильно мпроизнести известное вамм заклинаание и попасть в него, если вы атакуете.");
            Console.WriteLine("Также вам стоит помнить, что некоторые ваши заклинания можно связать в цепочки");
            Console.WriteLine("Например: ray of frost -> ruprure of ice");
            Console.WriteLine("Нооо, вы не помните их все. . . Во всяком случае, Удаччи!");

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
}
