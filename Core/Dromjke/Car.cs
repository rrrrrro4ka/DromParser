using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DromParser.Core.Dromjke
{
    class Car
    {
        public Car(string name)
        {
            Name = name;
        }
        public Car(string name, string text, string price)
        {
            Name = name;
            Text = text;
            Price = price;
        }
        public string Name { get; set; }
        public string Text { get; set; }
        public string Price { get; set; }
    }
}
