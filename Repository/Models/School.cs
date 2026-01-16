using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Models
{
    internal class School:IEntity
    {
        public int Id {  get; set; }
        public string Name { get; set; }
        public string Adress {  get; set; }
    }
}
