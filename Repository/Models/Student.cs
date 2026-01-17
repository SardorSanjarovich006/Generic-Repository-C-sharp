using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Models
{
    public class Student:IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string School {  get; set; }
        public int Grade {  get; set; }
    }
}
