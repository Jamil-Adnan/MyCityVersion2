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
        public List<Goods> Inventory { get; set; }
        public Person(int xdirection, int ydirection, int personx, int persony)
        {
            Personx = personx;
            Persony = persony;
            Xdirection = xdirection;
            Ydirection = ydirection;
            //Inventory = Goods.GoodsList();
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
    }

    class Police : Person
    {
        public List<Goods> PoliceInventory { get; set; }

        public Police(int personx, int persony, int xdirection, int ydirection) : base(xdirection, ydirection, personx, persony)
        {
            PoliceInventory = new List<Goods>();
            
        }      
    }


    class Thief : Person
    {
        public List<Goods> Thiefinventory { get; set; }

        public Thief(int personx, int persony, int xdirection, int ydirection) : base(xdirection, ydirection, personx, persony)
        {
            Thiefinventory = new List<Goods>();
        }        
    }

    class Citizen : Person
    {
        public List<Goods> CitizenInventory { get; set; }

        public Citizen(int personx, int persony, int xdirection, int ydirection) : base(xdirection, ydirection, personx, persony)
        {
            CitizenInventory = new List<Goods>();  
            
        }
        
    }
}
