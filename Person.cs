using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCityVersion2
{
    internal class Person
    {
        public int Personx { get; set; }
        public int Persony { get; set; }
        public int Xdirection { get; set; }
        public int Ydirection { get; set; }
        //public List<string> Goods { get; set; }
        public Person(int xdirection, int ydirection, int personx, int persony)
        {
            Personx = personx;
            Persony = persony;
            Xdirection = xdirection;
            Ydirection = ydirection;
            //Goods = new List<string>();
            SetDirection();
        }
        public void SetDirection() 
        {
            var direction = Random.Shared.Next(0,6);
            switch (direction) 
            {
                case 0:
                    Xdirection = -1;  Ydirection = 0;   //left
                    break;
                case 1:
                    Xdirection = 1; Ydirection = 0; //right
                    break;
                case 2:
                    Xdirection = 0; Ydirection = 1; //up
                    break;
                case 3:
                    Xdirection = 0; Ydirection = -1;    //down
                    break;
                case 4:
                    Xdirection = -1; Ydirection= 1;    //diagonal left
                    break;
                case 5:
                    Xdirection = 1; Ydirection= -1;    //diagonal right
                    break;
            }
        }
        public void PersonMove(int height, int width)
        {
            Personx += Xdirection;
            Persony += Ydirection;
            if (Personx >= width) 
            {
                Personx = 0;
            }
            if (Personx < 0) 
            {
                Personx = width - 1;
            }
            if (Persony >= height)
            {
                Persony = 0;
            }
            if (Persony < 0) 
            {
                Persony = height - 1;
            }
        }
        public virtual void ArrestThief(Thief thief) 
        {
        }
        public virtual void Hijack(Citizen citizen) 
        {
        }
    }
    

    class Police : Person
    {
        public List<string> RecoveredGoods { get; set; }

        public Police(int personx, int persony, int xdirection, int ydirection, List<string> recoveredgoods) : base(xdirection, ydirection, personx, persony)
        {
            RecoveredGoods = recoveredgoods;            
        }

        public override void ArrestThief(Thief thief) 
        {
            if (thief.HijackedGoods.Count > 0) 
            {
                RecoveredGoods.AddRange(thief.HijackedGoods);
                thief.HijackedGoods.Clear();
                Console.WriteLine($"Headline!!   Gotham City Police just arrested a thief and recovered many expensive items");
                Thread.Sleep(2000);
            }
        }
    }


    class Thief : Person
    {
        public List<string> HijackedGoods { get; set; }

        public Thief(int personx, int persony, int xdirection, int ydirection, List <string> hijackedgoods) : base(xdirection, ydirection, personx, persony)
        {
            HijackedGoods = hijackedgoods;
        }
        public override void Hijack(Citizen citizen) 
        {
            if (citizen.Inventory.Count > 0) 
            {
                Random rnd = new Random();
                int thing = rnd.Next(citizen.Inventory.Count);
                string loots = citizen.Inventory[thing];
                citizen.Inventory.RemoveAt(thing);
                HijackedGoods.Add(loots);
                Console.WriteLine($"Oh No!!!   A thief just stole a {loots} from a citizen!");
                Thread.Sleep(2000);

            }
        }
    }

    class Citizen : Person
    {
        public List<string> Inventory { get; set; }
        public Citizen(int personx, int persony, int xdirection, int ydirection, List <string> inventory) : base(xdirection, ydirection, personx, persony)
        {
            Inventory = inventory;
            string[] inventory2 = { "Keys", "Mobile", "Money", "Watch" };
            Inventory.AddRange(inventory2.ToList());
        }
        
    }
}
