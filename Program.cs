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
            List<Person> Society = new List<Person> ();
            City.AddPerson(Society, policeman, thiefman, citizenman, map);
            
            while (true) 
            {
                foreach (Person person in Society)
                {
                    person.PersonMove(width, height);
                }
                City.DisplayCity(Society, map);               
                
            }
        }
        
        
        
        
    }    
}
