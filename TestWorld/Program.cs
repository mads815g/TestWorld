using System;
using System.Collections.Generic;
using System.Linq;
using MandatoryWorld;
using MandatoryWorld.Factory;
using Microsoft.VisualBasic;
using static MandatoryWorld.GameChecks;

namespace TestWorld
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Game newGame = new Game(10, 10, 3, 3, 5,  "Mads", 100, 10);
            //newGame.Run();

            World.MaxX = 10;
            World.MaxY = 10;
            Monster mads = new Monster("Mads");
            mads.PositionX = 2;
            mads.PositionY = 2;
            Hero hero = new Hero("heroman", 100, 10);
            MonsterFactory fac = new MonsterFactory();
            ChestFactory chest = new ChestFactory();
            List<Chest> chestList = new List<Chest>();
            List<Creature> list = new List<Creature>();
            Spawn(chestList, chest.CreateChest());
            Spawn(list, mads);
            Spawn(list, fac.CreateCreature());
            int i = list.Count();
            Console.WriteLine(i);
            var gameWon = false;
            while (hero.IsDead == false && gameWon == false)
            {
                Console.WriteLine($"{hero.PositionX}, {hero.PositionY}");
                hero.move();
                MonsterCheck(hero, list);
                ChestCheck(hero, chestList);
                gameWon = GameWon(list);
            }
        }
    }
}
