using System;
using System.ComponentModel.DataAnnotations;
namespace MvcMovie.Models
{
    public class Animails
    {
        [Key]
        public int Id { get; set; }
        public int Age { get; set; }
        public string Name { get; set; }
        public string animalType { get; set; }
        public string Gender { get; set; }
        public Animails()
        {
          
        }
    }
}
