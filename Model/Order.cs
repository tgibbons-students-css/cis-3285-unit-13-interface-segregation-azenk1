using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Order
    {
        //TEG added
        public Guid id { get; set; }
        public string product { get; set; }
        public int amount { get; set; }

        public string toString()
        {
            string retString;

            retString = "Order of " + amount + " " + product;

            return retString;
    
        }

}       
    }

