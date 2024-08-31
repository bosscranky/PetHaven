using PetHaven.Domain;
using PetHaven.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetHaven.BusinessLayer
{
    public class PetBusinessLayer
    {
        protected IPetDataLayer Data { get; } 

        protected IPetValidator Validator { get; }

        public PetBusinessLayer(IPetDataLayer aData) 
        { 
            Data = aData;
            Validator = new PetValidator();
        }

        public PetBusinessLayer(IPetDataLayer aData, IPetValidator valid) : this(aData) 
        {
            Validator = valid;
        }

        public List<BasePet> FindPets()
        {
            List<BasePet> pets = Data.FindAllPets();
                        

            return pets != null ? pets : new List<BasePet>();
        }

        public List<BasePet> FindPetsByName(string name)
        {
            List<BasePet> pets = new List<BasePet>();

            if (Validator.IsValidForNameSearch(name))
            {
                pets.AddRange(Data.FindPetsByName(name));
            }

            return pets != null ? pets : new List<BasePet>();
        }

        public BasePet SaveDog(Dog aDog)
        {
            if (Validator.IsValidForSave(aDog))
            {
                return Data.SavePet(aDog);
            }
            else
            {
                return null;
            }
        }

    }
}
