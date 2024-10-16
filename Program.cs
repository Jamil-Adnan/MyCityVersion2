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
        static int totalHijacked = 0;
        static int totalArrested = 0;
        static List<Person> Society = new List<Person>();
        static List <Police> policeList = new List<Police>();
        static List <Thief>thiefList = new List<Thief>();
        static List <Citizen> citizenList = new List<Citizen>();
        static void Main(string[] args)
        {            
            City.AddPerson(Society, policeList, thiefList, citizenList, policeman, thiefman, citizenman);
            
            while (true) 
            {
                foreach (Person person in Society)
                {
                    person.PersonMove(col, row);
                }
                Meeting();
                City.DisplayCity(Society, row, col);
               // City.Meeting();
            }
        }
        public static void Meeting()
        {
            foreach (Police police in policeList) 
            {
                foreach (Thief thief in thiefList) 
                {
                    if (police.Personx == thief.Personx && police.Persony == thief.Persony) 
                    {
                        //police.ArrestThief(thief); //ArrestThief method needs to be done
                        //totalArrested += 1;
                        thiefman -= 1; 
                    }
                } 
            }
            /*
            foreach (Thief thief in thiefList)
            {
                foreach (Citizen citizen in citizenList)
                {
                    if (thief.Personx == citizen.Personx && thief.Persony == citizen.Persony)
                    {
                        //thief.Hijack(citizen); //hijack method needs to be done
                        //totalHijacked += 1;
                    }
                }
            }
            */

        }



    }    
}
