using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace socketClient
{
    
    public class Perso
    {
       
        public string nom { get; set; }

        public int age { get; set; }

        public string sex { get; set; }

        public Perso(string nom, int age, string sex)
        {
            this.nom = nom;
            this.age = age;
            this.sex = sex;
        }
    }
}
