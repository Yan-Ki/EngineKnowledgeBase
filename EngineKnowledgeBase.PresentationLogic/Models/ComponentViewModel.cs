using AutoMapper;
using EngineKnowledgeBase.DataAccess.Repositories;
using EngineKnowledgeBase.PresentationLogic.Commands;
using System.Collections.ObjectModel;
using System.Windows;

namespace EngineKnowledgeBase.PresentationLogic.Models
{
    public class ComponentViewModel
    {
        public ComponentViewModel()
        {
            Components = new ObservableCollection<ComponentViewModel>();
        }

        public int ComponentId { get; set; }
        public string Name { get; set; }
        public string? Simple { get; set; }
        public string? Product { get; set; }
        public int? Count { get; set; }
        public int ParentId { get; set; }
        // public int ? ChildId { get; set; }
        public string? Description { get; set; }
        public ObservableCollection<ComponentViewModel>? Components { get; set; }

        private RelayCommand _deleteCommand;
        public RelayCommand DeleteCommand
        {
            get
            {
                return _deleteCommand ?? new RelayCommand(obj =>
                {
                    MessageBox.Show(RepositoriesEngineDB.DeleteElement((obj as ComponentViewModel).ComponentId, (obj as ComponentViewModel).ParentId));
                });
            }
        }
        private RelayCommand _addCommand;
        public RelayCommand AddCommand
        {
            get
            {
                return _addCommand ?? new RelayCommand(obj =>
                {                    

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
                    //ReportDocumet reportDocumet = new ReportDocumet();
                });
            }
        }
    }
}
