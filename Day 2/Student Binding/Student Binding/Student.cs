using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Binding
{
    internal class Student
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public decimal Grade { get; set; }
        public string Image { get; set; }
        
        public override string ToString()
        {
            return Name;
        }
    }
}
