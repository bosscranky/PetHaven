using PetHaven.Domain;
using PetHaven.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetHaven.BusinessLayer
{
    public class PetValidator : IPetValidator
    {
        public bool IsValidForNameSearch(string name)
        {
            return !string.IsNullOrWhiteSpace(name);
        }

        public bool IsValidForSave(BasePet pet)
        {
            return (pet != null && !string.IsNullOrWhiteSpace(pet.Name));
        }

    }
}
