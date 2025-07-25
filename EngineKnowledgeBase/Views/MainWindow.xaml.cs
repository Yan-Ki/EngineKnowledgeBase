using EngineKnowledgeBase.PresentationLogic.Models;
using EngineKnowledgeBase.PresentationLogic.ViewModels;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace EngineKnowledgeBase.Views
{
    public partial class MainWindow : Window
    {
        MainViewModel viewModel;
        public MainWindow()
        {
            InitializeComponent();
            viewModel = new MainViewModel();
            DataContext = viewModel;           
        }
      
        private void TreeView_PreviewMouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            var originalSource = e.OriginalSource as DependencyObject;

            while (originalSource != null && !(originalSource is TreeViewItem))
                originalSource = VisualTreeHelper.GetParent(originalSource);

            if (originalSource is TreeViewItem item)
            {
                item.IsSelected = true;
                item.Focus();
                e.Handled = false;
            }
        }

        private void AddProductClick(object sender, RoutedEventArgs e)
        {
            AddProduct addProduct = new AddProduct(viewModel);
            addProduct.ShowDialog();
        }

        private void AddComponentClick(object sender, RoutedEventArgs e)
        {
            MenuItem menuItem = sender as MenuItem;         
            object context = menuItem.CommandParameter;
            int ComponentId=0;

            if (context is ProductViewModel product)
            {
                ComponentId = (product as ProductViewModel).ComponentId;    
            }
            else if (context is ComponentViewModel component)
            {
                ComponentId = (component as ComponentViewModel).ComponentId;
            }
            AddComponent addComponent = new AddComponent(viewModel, ComponentId);
            addComponent.ShowDialog();
        }
    }
}