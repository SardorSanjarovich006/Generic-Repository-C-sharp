using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Models
{
    public class Subject:IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int GradeLevel { get; set; } 
    }
}
