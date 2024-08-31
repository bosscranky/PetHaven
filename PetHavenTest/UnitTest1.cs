using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using PetHaven.BusinessLayer;
using PetHaven.Domain;
using PetHaven.Interfaces;
using System.Text.Json;

namespace PetHavenTest
{
    [TestClass]
    public class UnitTest1
    {
        private PetBusinessLayer BL { get; } = new PetBusinessLayer(new TestDataLayer());

        private class TestDataLayer : IPetDataLayer
        {
            private List<BasePet> Pets { get; set; } = new List<BasePet>();

            public TestDataLayer()
            {
                Pets.Add(new Dog() { Id = 1, Name = "Fido", Neutered = true });
                Pets.Add(new Cat() { Id = 2, Name = "Fluffy", Neutered = true });
                Pets.Add(new Cat() { Id = 3, Name = "Fritz", Neutered = true });
                Pets.Add(new Dog() { Id = 4, Name = "Lassie", Neutered = true });
                Pets.Add(new Lizard() { Id = 5, Name = "Gojira", Neutered = true });
                Pets.Add(new Snake() { Id = 6, Name = "Huggy McHugginton, Esquire", Neutered = true });
                Pets.Add(new Lizard() { Id = 7, Name = "Karma Chameleon", Neutered = true });

            }

            public List<BasePet> FindAllPets()
            {
                return Pets;
            }

            public List<BasePet> FindPetsByName(string name)
            {
                return Pets.FindAll(x => x.Name.StartsWith(name));
            }

            public BasePet SavePet(BasePet pet)
            {
                pet.Id = Pets.Count + 1;

                Pets.Add(pet);

                return pet;
            }

        }


        [TestMethod]
        public void TestInvalidNameSearch()
        {
            var response = BL.FindPetsByName(string.Empty);

            Assert.IsNotNull(response);
            Assert.IsTrue(response.Count == 0);

        }

        [TestMethod]
        public void TestMultipleNameMatchSearch()
        {
            var response = BL.FindPetsByName("F");

            Assert.IsNotNull(response);
            Assert.IsTrue(response.Count == 3);

        }

        [TestMethod]
        public void TestSavePet()
        {
            Dog goodDoggie = new Dog() { Name = "Spot", Neutered = true };

            var newDoggie = BL.SavePet(goodDoggie);

            Assert.IsNotNull(newDoggie);
            Assert.IsTrue(newDoggie.Id > 0);
        }

        [TestMethod]
        public void TestInvalidSave()
        {
            Lizard liz = new Lizard() { Name = "", Neutered = true};

            var newLizard = BL.SavePet(liz);

            Assert.IsNull(newLizard);
        }
    }
}