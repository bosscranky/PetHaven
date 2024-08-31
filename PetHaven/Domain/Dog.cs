using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetHaven.Domain
{
    public class Dog : Mammal
    {
        public override string Speak()
        {
            return "Arf Arf!";
        }
    }
}
