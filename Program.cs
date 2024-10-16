using System;
using System.Net.Sockets;

namespace MyCityVersion2
{
    internal class Program
    {        
        static int row = 25;
        static int col = 100;
        static int policeman = 10;
        static int thiefman = 5;
        static int citizenman = 15;
        static List<Person> Society = new List<Person>();
        static List <Police> police = new List<Police>();
        static List <Thief>thief = new List<Thief>();
        static List <Citizen> citizen = new List<Citizen>();
        static void Main(string[] args)
        {            
            City.AddPerson(Society, policeman, thiefman, citizenman);
            
            while (true) 
            {
                foreach (Person person in Society)
                {
                    person.PersonMove(col, row);
                }
                City.DisplayCity(Society, row, col);               
                
            }
        }
        
        
        
        
    }    
}
