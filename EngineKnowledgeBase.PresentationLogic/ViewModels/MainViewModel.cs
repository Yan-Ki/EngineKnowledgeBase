using AutoMapper;
using EngineKnowledgeBase.DataAccess.Repositories;
using EngineKnowledgeBase.PresentationLogic.Commands;
using EngineKnowledgeBase.PresentationLogic.Models;
using System.Collections.ObjectModel;
using System.Windows;


namespace EngineKnowledgeBase.PresentationLogic.ViewModels
{
    public class MainViewModel
    {
        //private object _selectedItem;
        //public object SelectedItem
        //{
        //    get => _selectedItem;
        //    set { _selectedItem = value; OnPropertyChanged(nameof(SelectedItem)); }
        //}
        public ObservableCollection<ProductViewModel>? ProductViewModels { get; set; }
        public MainViewModel()
        {     
            ProductViewModels = new ObservableCollection<ProductViewModel>();
            AddProduct();
            AddComponent();           
        }

        private void AddProduct() //Добавили Изделия с параметром product=="true"
        {
            var temp = RepositoriesEngineDB.GetProduct();
            foreach (var i in temp)
            {
                ProductViewModels.Add(new ProductViewModel() { ComponentId = i.ComponentId, Name = i.Name });
            }
        }

        private void AddComponent() //Добавляем компоненты в коллекцию компонентов
        {
            foreach (var i in ProductViewModels) //Идём по коллекции  продуктов
            {
                var result = RepositoriesEngineDB.GetComponent(i.ComponentId); // запрос на поиск всех компонентов

                if (result != null)
                {
                    foreach (var j in result) //Идём по коллекции компонентов полученных в результате запроса мапим и добавляем в коллекцию вьюмодели
                    {
                        var temp = new ComponentViewModel()
                        {
                            ComponentId = j.ComponentId,
                            Name = j.Name,
                            Count = j.Count,
                            ParentId = j.ParentId,
                            Simple = j.Simple,
                            Description = j.Description
                        };
                        i.Components.Add(temp);
                    }

                    foreach (var q in i.Components)
                    {
                        AddAllComponents(q);
                    }
                }
            }
        }

        private void AddAllComponents(ComponentViewModel componentViewModel)
        {
            var result2 = RepositoriesEngineDB.GetComponent(componentViewModel.ComponentId); // запрос на поиск всех компонентов

            if (result2 != null)
            {
                foreach (var g in result2) //Идём по коллекции компонентов полученных в результате запроса мапим и добавляем в коллекцию вьюмодели
                {
                    var temp = new ComponentViewModel
                    {
                        ComponentId = g.ComponentId,
                        Name = g.Name,
                        Count = g.Count,
                        ParentId = g.ParentId,
                        Description = g.Description
                    };
                    componentViewModel.Components.Add(temp);
                    AddAllComponents(temp);
                }
            }
        }
        

        private RelayCommand _addProductCommand;
        public RelayCommand AddProductCommand
        {
            get
            {
                return _addProductCommand ?? new RelayCommand(obj =>
                {
                   var component =RepositoriesEngineDB.AddProduct((obj as string));
                    if (component != null)
                    {
                        ProductViewModels.Add(new ProductViewModel()
                        {
                            ComponentId = component.ComponentId,
                            Name = component.Name,
                            Description = component.Description
                        });
                        MessageBox.Show("Изделие добавлено");
                    }
                    else
                    {
                        MessageBox.Show("Наименование изделия не должно совпадать");
                    }   
                });
            }
        }
    }
}
