using EngineKnowledgeBase.DataAccess.Repositories;
using EngineKnowledgeBase.PresentationLogic.Commands;
using EngineKnowledgeBase.PresentationLogic.Repositories;
using System.Collections.ObjectModel;

namespace EngineKnowledgeBase.PresentationLogic.Models
{
    public class ProductViewModel
    {
        public ProductViewModel()
        {
            Components = new ObservableCollection<ComponentViewModel>();
        }

        public int ComponentId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ObservableCollection<ComponentViewModel>? Components { get; set; }


        private RelayCommand _deleteCommand;
        public RelayCommand DeleteCommand
        {
            get
            {
                return _deleteCommand ?? new RelayCommand(obj =>
                {
                  var result= RepositoriesEngineDB.DeleteElement((obj as ProductViewModel).ComponentId, (obj as ComponentViewModel).ParentId);
                });
            }
        }

        private RelayCommand _editCommand;
        public RelayCommand EditCommand
        {
            get
            {
                return _editCommand ?? new RelayCommand(obj =>
                {                  

                });
            }
        }

        private RelayCommand _reportCommand;
        public RelayCommand ReportCommand
        {
            get
            {
                return _reportCommand ?? new RelayCommand(obj =>
                {
                    ReportDocumet reportDocumet = new ReportDocumet(obj);                   
                });
            }
        }
    }
}
