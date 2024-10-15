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
        //
        static void Main(string[] args)
        {
            List<Person> Society = new List<Person> ();
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
