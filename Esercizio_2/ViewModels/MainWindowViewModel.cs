using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Esercizio_2.ViewModels
{
    internal class MainWindowViewModel : BaseViewModel
    {
        private string nome;
        private string cognome;
        
        public DelegateCommand<object> AggiungiPersonaCommand { get; private set; }
        public DelegateCommand<object> RimuoviPersonaCommand { get; private set; }
        public DelegateCommand<object> ModificaPersonaCommand { get; private set; }
        private ObservableCollection<Models.Persona> people;
        private Models.Persona persona_selezionata;
        
        public MainWindowViewModel()
        {
            AggiungiPersonaCommand = new DelegateCommand<object>(AggiungiPersona, CanAggiungiPersona);
            RimuoviPersonaCommand = new DelegateCommand<object>(RimuoviPersona, CanRimuoviPersona);
            ModificaPersonaCommand = new DelegateCommand<object>(ModificaPersona, CanModificaPersona);
            People = new ObservableCollection<Models.Persona>()
            {
                new Models.Persona("Mario","Rossi") ,
                new Models.Persona("Maria", "Bianchi"),
                new Models.Persona("Giacomo", "Pucci")
            };
            NotifyPropertyChanged(nameof(People));
        }

        public 

        void AggiungiPersona(object param)
        {
            Models.Persona pers = new Models.Persona(Nome, Cognome);
            People.Add(pers);
            NotifyPropertyChanged();
        }

        bool CanAggiungiPersona(object param)
        {
            if(Nome != string.Empty && cognome != string.Empty)
            {
                return true;
            }
            return false;
        }

        public ObservableCollection<Models.Persona> People
        {
            get
            {
                return people;
            }
            set
            {
                people = value;
                NotifyPropertyChanged(nameof(people));
            }
        }

        public string Nome
        {
            get { return nome; }
            set { 
                nome = value;
                NotifyPropertyChanged(); 
                AggiungiPersonaCommand.RaiseCanExecuteChanged(); 
            }
        }

        public string Cognome
        {
            get { return cognome; }
            set {
                cognome = value;
                NotifyPropertyChanged(); 
                AggiungiPersonaCommand.RaiseCanExecuteChanged(); 
            }
        }

        public Models.Persona Persona_selezionata
        {
            get
            {
                return persona_selezionata;
            }
            set
            {
                persona_selezionata = value;
                SetFields();
                NotifyPropertyChanged(); 
                RimuoviPersonaCommand.RaiseCanExecuteChanged();
                ModificaPersonaCommand.RaiseCanExecuteChanged();
            }
        }

        void RimuoviPersona(object param)
        {
            People.Remove(Persona_selezionata);
            NotifyPropertyChanged(nameof(People));
        }

        bool CanRimuoviPersona(object param)
        {
            if(People.Contains(Persona_selezionata))
            {
                return true;
            }
            return false;
        }

        void ModificaPersona(object param)
        {
            int index = People.IndexOf(Persona_selezionata);
            //People.RemoveAt(index);
            Models.Persona pers = new Models.Persona(Nome, Cognome);
            People[index] = pers;
            //People.Insert(index, Persona_selezionata);
            NotifyPropertyChanged();
        }

        bool CanModificaPersona(object param)
        {
            if(Persona_selezionata != null)
            {
                return true;
            }
            return false;
        }

        void SetFields()
        {
            if(Persona_selezionata != null)
            {
                Nome = Persona_selezionata.Nome;
                Cognome = Persona_selezionata.Cognome;
            }
        }
    }
}
