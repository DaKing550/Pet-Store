using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetStore
{
    public class Pet
    { 
        public string Name { get; set; }

        public string Species { get; set; }

        public DateTime BirthDate { get; set; }

        public int Age { get; set; }
        // based on Birthdate

        public int Weight { get; set; }

        public string Size { get; set; }
        // Based on weight

        public bool IsAdopted { get; set; }

        public Pet(string name, string species, DateTime birthDate, int weight)
        {
            
            this.Name = name;
            this.Species = species;
            this.BirthDate = birthDate;
            this.Age = DateTime.Now.Year - birthDate.Year;
            this.Weight = weight;
           
            if (weight <= 5)
            {
                Size = "small";
            }
            else if (weight <= 10 || weight >= 6)
            {
                Size = "medium";
            }
            else
            {
                Size = "large";
            }
            this.IsAdopted = false;
        }
        public override string ToString()
        {
            return $"{Name}\n" +
                $"{Age} years\n" +
                $"Born on {BirthDate}\n" +
                $"Species: {Species}\n" +
                $"Weight: {Weight}\n" +
                $"{Size}\n" +
                $"Is it Adopted? {IsAdopted}\n";
        }
    }
}
