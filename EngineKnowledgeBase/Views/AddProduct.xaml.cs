using EngineKnowledgeBase.PresentationLogic.ViewModels;
using System.Windows;

namespace EngineKnowledgeBase.Views
{  
    public partial class AddProduct : Window
    { 
        public AddProduct(MainViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}
