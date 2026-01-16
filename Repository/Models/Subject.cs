using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Models
{
    internal class Subject:IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Grade {  get; set; }
    }
}
