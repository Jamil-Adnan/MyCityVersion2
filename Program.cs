using System;
using System.Net.Sockets;

namespace MyCityVersion2
{
    internal class Program
    {
        static int height = 25;
        static int width = 100;
        static int policeman = 20;
        static int thiefman = 35;
        static int citizenman = 50;
        static int totalHijacked = 0;
        static int totalArrested = 0;
        static char[,] map = new char[height, width];
        static List<Person> peopleList = new List<Person>();
        static void Main(string[] args)
        {
            List<Person> Society = City.AddPerson(policeman, thiefman, citizenman, peopleList);
            while (true)
            {
                foreach (Person person in Society)
                {
                    person.PersonMove(width, height);
                }
                Meeting(Society);
                City.DisplayCity(height, width, Society);
                Console.WriteLine("Number of hijacked citizens: " + totalHijacked);
                Console.WriteLine("Number of arrested thieves is: " + totalArrested);
                Thread.Sleep(500);
            }
        }
        static void Meeting(List<Person> Society)
        {
            for (int i = 0; i < Society.Count; i++)
            {
                for (int j = 0; j < Society.Count; j++)
                {
                    if (Society[i].Personx == Society[j].Personx && Society[i].Persony == Society[j].Persony)
                    {
                        if (Society[i] is Thief && Society[j] is Citizen)
                        {
                            ((Thief)Society[i]).Hijack((Citizen)Society[j]);
                            totalHijacked++;
                        }
                        else if (Society[i] is Citizen && Society[j] is Thief)
                        {
                            ((Thief)Society[j]).Hijack((Citizen)Society[i]);
                            totalHijacked++;
                        }
                        else if (Society[i] is Police && Society[j] is Thief)
                        {
                            ((Police)Society[i]).Arrest((Thief)Society[j]);
                            totalArrested++;
                        }
                        else if (Society[i] is Thief && Society[j] is Police)
                        {
                            ((Police)Society[j]).Arrest((Thief)Society[i]);
                            totalArrested++;
                        }
                    }
                }
            }
        }
    }
}
