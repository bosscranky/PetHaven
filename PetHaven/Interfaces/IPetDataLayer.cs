using PetHaven.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetHaven.Interfaces
{
    public interface IPetDataLayer
    {

        List<BasePet> FindAllPets();

        List<BasePet> FindPetsByName(string name);

        BasePet SavePet(BasePet pet);
    }
}
