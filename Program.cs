using System;
using System.Net.Sockets;

namespace MyCityVersion2
{
    internal class Program
    {        
        static int height = 25;
        static int width = 100;
        static int policeman = 10;
        static int thiefman = 5;
        static int citizenman = 15;
        static char[,] map = new char[height, width];
        static void Main(string[] args)
        {
            List<Person> Society = City.CityMap(policeman, thiefman, citizenman, map);
            while (true) 
            {
                foreach (Person person in Society)
                {
                    person.PersonMove(width, height);
                }
                DisplayCity(Society);               
              
            }
        }
        
        
        
        static void DisplayCity(List<Person> Society)
        {
            foreach (Person person in Society)
            {
                if (person is Police) map[person.Personx, person.Persony] = 'P';
                else if (person is Thief) map[person.Personx, person.Persony] = 'T';
                else if (person is Citizen) map[person.Personx, person.Persony] = 'M';
            }
            Console.Clear();
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {

                    //Console.Write(map[i, j] == '\0' ? '.' : map[i, j]); 
                    
                    Console.Write(map[i, j]);
                    //char[,]map = City.EmptyMap(map);
                }
                Console.WriteLine();
               
            }
            //Console.Clear();
        }
    }    
}
