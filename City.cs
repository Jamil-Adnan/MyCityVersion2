﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCityVersion2
{
    internal class City
    {
        public static List<Person> AddPerson(int policeman, int thiefman, int citizenman, List<Person> peopleList)
        {
            for (int i = 0; i < policeman; i++) //creating police and adding in city
            {
                int persX = Random.Shared.Next(1, 25);
                int persY = Random.Shared.Next(1, 100);
                int Xdir = Random.Shared.Next(-1, 2);
                int Ydir = Random.Shared.Next(-1, 2);
                List<string> recoveredGoods = new List<string>();
                peopleList.Add(new Police(persX, persY, Xdir, Ydir, recoveredGoods));
            }

            for (int i = 0; i < thiefman; i++)  //creating Thief and adding in city
            {
                int persX = Random.Shared.Next(1, 25);
                int persY = Random.Shared.Next(1, 100);
                int Xdir = Random.Shared.Next(-1, 2);
                int Ydir = Random.Shared.Next(-1, 2);
                List<string> hijackedgoods = new List<string>();
                peopleList.Add(new Thief(persX, persY, Xdir, Ydir, hijackedgoods));
            }

            for (int i = 0; i < citizenman; i++)    //creating citizen and adding in city
            {
                int persX = Random.Shared.Next(1, 25);
                int persY = Random.Shared.Next(1, 100);
                int Xdir = Random.Shared.Next(-1, 2);
                int Ydir = Random.Shared.Next(-1, 2);
                List<string> inventory = new List<string>();
                peopleList.Add(new Citizen(persX, persY, Xdir, Ydir, inventory));
            }
            return peopleList;  //returns the list to main class
        }

        public static void DisplayCity(int height, int width, List<Person> Society, int totalHijacked, int thiefman, int totalArrested)
        {
            char[,] map = new char[height, width];
            foreach (Person person in Society)  //loops through the whole matrix and sets characters to different Person subclasses
            {
                if (person is Police) map[person.Personx, person.Persony] = 'P';
                else if (person is Thief) map[person.Personx, person.Persony] = 'T';
                else if (person is Citizen) map[person.Personx, person.Persony] = 'M';
            }
            Console.Clear();

            for (int i = 0; i < height; i++)    //prints the city
            {
                for (int j = 0; j < width; j++)
                {
                    Console.Write(map[i, j] == '\0' ? ' ' : map[i, j]);
                }                
                Console.WriteLine();                
            }
            Console.WriteLine("Number of hijacked citizens: " + totalHijacked);
            Console.WriteLine("Number of arrested thieves is: " + totalArrested);            
            Thread.Sleep(150);
        }
    }
}
