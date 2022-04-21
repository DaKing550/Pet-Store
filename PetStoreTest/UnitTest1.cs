using Microsoft.VisualStudio.TestTools.UnitTesting;
using PetStore;
using System;

namespace PetStoreTest
{
    [TestClass]
    public class UnitTest1
    {
        private static Pet BasicPet()
        {
            return new Pet("sara", "dog", DateTime.Parse("03/08/1993"), 5);
        }

        [TestMethod]
        public void AddPet_WhenAddingAPet_ShouldAddAPet()
        {
            //arrange
            PetRepository petRepository = new PetRepository();
            Pet pet = BasicPet();

            //act
            petRepository.AddPet(pet);

            //assert
            StringAssert.Contains(petRepository.ListPets(), pet.ToString());
        }

        [TestMethod]
        public void EditPet_WhenEditingAPetsWeight_ShouldEditAPetsweight()
        {
            //arrange
            PetRepository petRepository = new PetRepository();
            Pet pet = BasicPet();
            petRepository.AddPet(pet);
            //act
            petRepository.EditPet(pet, 6);
            //assert
            Assert.AreEqual(6, pet.Weight);
        }

        [TestMethod]
        public void EditPet_WhenEditingAPetsAdopted_ShouldEditAPetsAdopted()
        {
            //arrange
            PetRepository petRepository = new PetRepository();
            Pet pet = BasicPet();
            petRepository.AddPet(pet);
            //act
            petRepository.EditPet(pet, true);
            //assert
            Assert.IsTrue(pet.IsAdopted);
        }

        [TestMethod]
        public void FindPetByName_WhenFindingAPet_ShouldFindThePet()
        {
            //arrange
            PetRepository petRepository = new PetRepository();
            Pet pet = BasicPet();
            petRepository.AddPet(pet);
            //act
            var result = petRepository.FindPetByName(pet.Name);
            //assert
            Assert.AreEqual(pet.Name, result.Name);
        }

        [TestMethod]
        public void RemovePet_WhenRemovingAPet_ShouldRemoveAPet()
        {
            //arrange
            PetRepository petRepository = new PetRepository();
            Pet pet = BasicPet();
            petRepository.AddPet(pet);
            //act
            petRepository.RemovePet(pet);
            //assert
            Assert.AreEqual(petRepository.ListPets(), string.Empty);
        }

        [TestMethod]
        public void RemovePetByName_WhenRemovingAPetByName_ShouldRemoveAPetByName()
        {
            //arrange
            PetRepository petRepository = new PetRepository();
            Pet pet = BasicPet();
            petRepository.AddPet(pet);
            //act
            petRepository.RemovePetByName(pet.Name);
            //assert
            Assert.AreEqual(petRepository.ListPets(), string.Empty);
        }
        [TestMethod]

        public void ListPets_WhenListPets_ShouldListAllPets()
        {
            //arrange
            PetRepository petRepository = new PetRepository();
            Pet pet = BasicPet();
            petRepository.AddPet(pet);
            //act
            var result = petRepository.ListPets();
            //assert
            StringAssert.Contains(result, pet.ToString());
        }
    }
}