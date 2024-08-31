using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetHaven.Domain
{
    public abstract class Reptile : BasePet
    {
        public override string Speak()
        {
            return "HISSS!";
        }
       
    }
}
