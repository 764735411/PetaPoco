using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using PetaPoco;

namespace PetspPetaPocoWebApi.Model
{
    [TableName("Student")]
    [PrimaryKey("ID", AutoIncrement = true)]
    public class Student
    {
        [Column("id")]
        public int ID { get; set; }

        [Column("name")]
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Column("age")]
        [Range(1, 100000000, ErrorMessage = "Age must be between 1 and 100000000")]
        public int Age { get; set; }

        [Column("sex")]
        [StringLength(2)]
        public string Sex { get; set; }
    }
}
