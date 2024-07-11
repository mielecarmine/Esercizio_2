using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esercizio_2.Models
{
    internal class Persona
    {
        private string nome;
        private string cognome;
        //public Persona()
        //{
        //}

        public Persona(string nome, string cognome)
        {
            Nome = nome;
            Cognome = cognome;
        }

        public string Nome { get { return nome; } 
            set {
                nome = value;
            } 
        }

        public string Cognome
        {
            get { return cognome; }
            set
            {
                cognome = value;
            }
        }
        public override string ToString()
        {
            return $"{Nome} {Cognome}";
        }

    }
}
