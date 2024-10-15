using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCityVersion2
{
    internal class City
    {
        public static List <Person> CityMap(int policeman, int thiefman, int citizenman, char[,] map)
        {            
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    map[i, j] = '.';
                }
            }
            List<Person> Society = new List<Person>();
            for (int i = 0; i < policeman; i++)
            {
                int persX = Random.Shared.Next(1, 25);
                int persY = Random.Shared.Next(1, 100);
                int Xdir = Random.Shared.Next(-1, 2);
                int Ydir = Random.Shared.Next(-1, 2);
                
                Society.Add(new Police(persX, persY, Xdir, Ydir));
            }

            for (int i = 0; i < thiefman; i++)
            {
                int persX = Random.Shared.Next(1, 25);
                int persY = Random.Shared.Next(1, 100);
                int Xdir = Random.Shared.Next(-1, 2);
                int Ydir = Random.Shared.Next(-1, 2);
                Society.Add(new Thief(persX, persY, Xdir, Ydir));
            }

            for (int i = 0; i < citizenman; i++)
            {
                int persX = Random.Shared.Next(1, 25);
                int persY = Random.Shared.Next(1, 100);
                int Xdir = Random.Shared.Next(-1, 2);
                int Ydir = Random.Shared.Next(-1, 2);
                Society.Add(new Citizen(persX, persY, Xdir, Ydir));               
            }
            return Society;
            
        }
        public static char [,] EmptyMap(char[,] map)
        {
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    map[i, j] = ' ';
                }
            }
            return map;
        }
    }
    
}
