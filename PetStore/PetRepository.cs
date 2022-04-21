using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetStore
{
    public class PetRepository
    {
        List<Pet> pets = new List<Pet>();

        public void AddPet(Pet newPet)
        {
            pets.Add(newPet);
        }
        public void EditPet(Pet editPet, int weight)
        {
            var result = FindPetByName(editPet.Name);
            result.Weight = weight;
        }
        public void EditPet(Pet editPet, bool adopted)
        {
            var result = FindPetByName(editPet.Name);
            result.IsAdopted = adopted;
        }

        public Pet FindPetByName(string petName)
        {
            var result = pets.First(p => p.Name == petName);
            return result;
        }
        
        public void RemovePet(Pet pet)
        {
            pets.Remove(pet);
        }
        
        public void RemovePetByName(string petName)
        {
            var result = pets.First(p=> p.Name == petName);
            RemovePet(result);
        }

        public string ListPets()
        {
            var petItems = new StringBuilder();
            foreach (Pet newPet in pets)
            {
                petItems.AppendLine(newPet.ToString());
            }
            return petItems.ToString();
        }
    }
}
