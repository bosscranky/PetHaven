using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetHaven.Domain
{
    public abstract class BasePet
    {
        public string Name { get; set; } = string.Empty;

        public bool Neutered { get; set; }  

        public int Id { get; set; }

        public abstract string Speak();
    }
}
