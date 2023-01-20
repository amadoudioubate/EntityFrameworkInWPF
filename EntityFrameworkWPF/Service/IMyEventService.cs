using EntityFrameworkWPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkWPF.Service
{
    public interface IMyEventService
    {
        //Recuperer la liste des évenements 
        List<MyEvent> GetAll();

        //Recuperer un evenement
        MyEvent GetById(int id);

        //Sauvegarder ou mettre à jour un evenement
        void Create(MyEvent myEvent);
        void Update(MyEvent myEvent);

        //recuperer le nombre d'événement (int)
        int Count(MyEvent myEvent);

        //Effacer  un evenement 
        void Delete(int id);

        //Rechecher un evenement par  son titre ou sa description ou sa datedebut ou sa datefin
        MyEvent GetByTitle(string title);

        List<MyEvent> Search(string keyword);
    }
}
