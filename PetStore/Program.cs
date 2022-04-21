
using System.Text;

namespace PetStore 
{
    class Program
    {
        static void Main(string[] args)
        {
            PetRepository ListOfPets = new PetRepository();
            var running = true;
            StringBuilder menuOptions = new StringBuilder();
            menuOptions.AppendLine("1. Add a Pet");
            menuOptions.AppendLine("2. Look Up a Pet");
            menuOptions.AppendLine("3. Remove a Pet");
            menuOptions.AppendLine("4. Edit a Pet");
            menuOptions.AppendLine("5. Quit");

            while (running)
            {
                var chosenAction = Prompt(menuOptions.ToString());
                Console.WriteLine();
                if (chosenAction == "1")
                {
                    var userPet = EnterPet();
                    ListOfPets.AddPet(userPet);
                }

                else if (chosenAction == "2")
                {
                    Console.WriteLine(ListOfPets.ListPets());
                    Console.ReadLine();
                }

                else if (chosenAction == "3")
                {
                    var removeName = Prompt("Which Pet Would You like to Remove?");
                    ListOfPets.RemovePetByName(removeName);
                }
                else if (chosenAction == "4")
                {
                    var editing = true;
                    StringBuilder editOptions=new StringBuilder();
                    editOptions.AppendLine("1. edit weight");
                    editOptions.AppendLine("2. edit Adoption status");
                    editOptions.AppendLine("3. Go back");
                        while (editing)
                   {
                        var editingAction = Prompt(editOptions.ToString());
                        if(editingAction == "1")
                        {
                            var editName = Prompt("Which pet to Edit?");
                            var editPet = ListOfPets.FindPetByName(editName);
                            var editWeight = int.Parse(Prompt($"{editName} weighs how much?"));
                                ListOfPets.EditPet(editPet, editWeight);

                        }
                        if (editingAction == "2")
                        {
                            var adoptedName = Prompt("Who got adopted?");
                            var editPet = ListOfPets.FindPetByName(adoptedName);
                            ListOfPets.EditPet(editPet, true);
                            Console.WriteLine("hooray!");
                            Console.ReadLine();
                        }
                        else if (editingAction == "3")
                        {
                            editing = false;
                        }
                    }

                }
                else if (chosenAction == "5")
                {
                    running = false;
                }
                else
                {
                    Console.WriteLine("Could not recognize command");
                }
            }
        }

        private static Pet EnterPet()
        {

            var petName = Prompt("Enter Pet name");
            var birthDate = DateTime.Parse(Prompt("Enter date of birth, MM/dd/yyyy"));
            var weight = int.Parse(Prompt("Enter weight of Pet"));
            var species = Prompt("Enter Pet species");
            

            var pet = new Pet(petName, species, birthDate, weight);
            return pet;


        }

        private static string Prompt(string message)
        {
            Console.WriteLine(message);
            return Console.ReadLine();

        }
    }
}