using EngineKnowledgeBase.PresentationLogic.ViewModels;
using System.Windows;

namespace EngineKnowledgeBase.Views
{
    public partial class AddComponent : Window
    {
        public AddComponent(MainViewModel viewModel, int ComponentId)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}
