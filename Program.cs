using System;
using System.Net.Sockets;

namespace MyCityVersion2
{
    internal class Program
    {
        static int height = 25;
        static int width = 100;
        static int policeman = 85;
        static int thiefman = 5;
        static int citizenman = 50;
        static int totalHijacked = 0;
        static int totalArrested = 0;
        static char[,] map = new char[height, width];
        static List<Person> peopleList = new List<Person>();
        static void Main(string[] args)
        {
            List<Person> Society = City.AddPerson(policeman, thiefman, citizenman, peopleList);  // method to add different class of pople and add them in the matrix as a list.
            while (thiefman != 0)
            {
                foreach (Person person in Society)
                {
                    person.PersonMove(width, height);
                }
                Meeting(Society);       // Method to control the interactions
                City.DisplayCity(height, width, Society);       // method to print on screen
                Console.WriteLine("Number of hijacked citizens: " + totalHijacked);
                Console.WriteLine("Number of arrested thieves is: " + totalArrested);
                Console.WriteLine("The number of thieves left is: " + thiefman);
                Thread.Sleep(500);
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
                        /*else if (Society[i] is Citizen && Society[j] is Thief)
                        {
                            ((Thief)Society[j]).Rob((Citizen)Society[i]);
                            totalHijacked++;
                        }
                        else if (Society[i] is Police && Society[j] is Thief)
                        {
                            ((Police)Society[i]).Arrest((Thief)Society[j],Society);
                            totalArrested++;
                        }*/
                        else if (Society[i] is Thief && Society[j] is Police)
                        {
                            ((Police)Society[j]).Arrest((Thief)Society[i], Society);
                            totalArrested++;
                            thiefman -- ;
                        }
                    }
                }
            }
        }
    }
}
