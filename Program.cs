using System;
using System.Net.Sockets;
using System.Runtime.InteropServices;

namespace MyCityVersion2
{
    internal class Program
    {
        static int height = 25;
        static int width = 100;
        static int policeman = 20;
        static int thiefman = 25;
        static int citizenman = 30;
        static int totalHijacked = 0;
        static int totalArrested = 0;               
        static List<Person> peopleList = new List<Person>();
        static void Main(string[] args)
        {
            List<Person> Society = City.AddPerson(policeman, thiefman, citizenman, peopleList);  // method to add different classes of pople and add them in the matrix as a list.
            while (totalArrested != thiefman)   //as soon as the number of thieves and the number of arrested thieves are equal, the loop breaks
            {
                foreach (Person person in Society)
                {
                    person.PersonMove(width, height);   //uses the class method to move every instance of person in list
                }
                Meeting(Society);       // Method to control the interactions
                City.DisplayCity(height, width, Society, totalHijacked, thiefman, totalArrested);   //revokes class method
                Thread.Sleep(200);
            }
            Console.WriteLine();
        }
        static void Meeting(List<Person> Society)       //method body of controling interactions
        {
            for (int i = 0; i < Society.Count; i++)
            {
                for (int j = 0; j < Society.Count; j++)
                {
                    if (Society[i].Personx == Society[j].Personx && Society[i].Persony == Society[j].Persony)
                    {
                        if (Society[i] is Thief && Society[j] is Citizen)
                        {
                            ((Thief)Society[i]).Rob((Citizen)Society[j]);                            
                            totalHijacked++;
                        }                        
                        else if (Society[i] is Thief && Society[j] is Police)
                        {
                            int arrested =((Police)Society[j]).Arrest((Thief)Society[i], Society, totalArrested);
                            totalArrested = arrested;
                        }
                        else if (Society[i] is Police && Society[j] is Thief)
                        {
                            int arrested = ((Police)Society[i]).Arrest((Thief)Society[j], Society, totalArrested);
                            totalArrested = arrested;
                        }
                    }
                }
            }
        }    
    }
}
