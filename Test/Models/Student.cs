using System;
using System.Collections.Generic;

namespace Test.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Group { get; set; }
        public string RollNumber { get; set; }
        public string Fullname { get; set; }
        public bool Absent { get; set; }
        public bool Present { get; set; }
        public string Comment { get; set; }
        public string Image { get; set; }
    }

}

