using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EngineKnowledgeBase.DataAccess;
using EngineKnowledgeBase.DataAccess.Models;
using EngineKnowledgeBase.DataAccess.Repositories;

namespace EngineKnowledgeBase.PresentationLogic.ViewModels
{
    public class MainViewModel
    {
        public MainViewModel() 
        {
         RepositoriesEngineDB repositoriesEngineDB = new RepositoriesEngineDB();
            Components = new ObservableCollection<DataAccess.Models.Component>(repositoriesEngineDB.Get());

            
        
        }
        public string Name { get; set; }
        public ObservableCollection<DataAccess.Models.Component> Components { get; set; }
    }
}
