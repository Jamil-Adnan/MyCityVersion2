using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCityVersion2
{
    internal class City
    {
        public static void AddPerson(List<Person> Society, List <Police>policeList, List <Thief>thiefList, List <Citizen>citizenList, int policeman, int thiefman, int citizenman)
        {
            for (int i = 0; i < policeman; i++)
            {
                int persX = Random.Shared.Next(1, 25);
                int persY = Random.Shared.Next(1, 100);
                int Xdir = Random.Shared.Next(-1, 2);
                int Ydir = Random.Shared.Next(-1, 2);
                List<string> recoveredGoods = new List<string>();
                Society.Add(new Police(persX, persY, Xdir, Ydir, recoveredGoods));
                policeList.Add(new Police(persX, persY,Xdir,Ydir, recoveredGoods));
            }

            for (int i = 0; i < thiefman; i++)
            {
                int persX = Random.Shared.Next(1, 25);
                int persY = Random.Shared.Next(1, 100);
                int Xdir = Random.Shared.Next(-1, 2);
                int Ydir = Random.Shared.Next(-1, 2);
                List <string>hijackedgoods = new List<string>();
                Society.Add(new Thief(persX, persY, Xdir, Ydir, hijackedgoods));
                thiefList.Add(new Thief(persX, persY, Xdir, Ydir, hijackedgoods));
            }

            for (int i = 0; i < citizenman; i++)
            {
                int persX = Random.Shared.Next(1, 25);
                int persY = Random.Shared.Next(1, 100);
                int Xdir = Random.Shared.Next(-1, 2);
                int Ydir = Random.Shared.Next(-1, 2);
                List<string> inventory = new List<string>();
                Society.Add(new Citizen(persX, persY, Xdir, Ydir, inventory));
                citizenList.Add(new Citizen(persX, persY, Xdir, Ydir, inventory));
            } 
        }

        public static void DisplayCity(List<Person> Society, int row, int col, int totalHijacked, int totalArrested)
        {
            char[,] map = new char[row, col];

            /*for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    map[i, j] = ' ';
                }
            }*/
            
            foreach (Person person in Society)
            {
                if (person is Police) map[person.Personx, person.Persony] = 'P';
                else if (person is Thief) map[person.Personx, person.Persony] = 'T';
                else if (person is Citizen) map[person.Personx, person.Persony] = 'M';
            }
            Console.Clear();
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {                    
                    Console.Write(map[i, j] == '\0' ? '.' : map[i, j]);

                }
                Console.WriteLine();
            }
            
            Console.WriteLine($"Number of total hijacked citizens : {totalHijacked}");
            Console.WriteLine($"Number of total arrested thieves : {totalArrested}");
            Thread.Sleep(2000);
        }

        

    }
    
}
