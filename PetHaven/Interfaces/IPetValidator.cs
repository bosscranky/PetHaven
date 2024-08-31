using PetHaven.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetHaven.Interfaces
{
    public interface IPetValidator
    {
        bool IsValidForSave(BasePet pet);

        bool IsValidForNameSearch(string name);
    }
}
