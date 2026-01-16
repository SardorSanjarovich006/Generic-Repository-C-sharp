using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Models
{
    public class Teacher:IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Subject { get; set; }
    }
}
