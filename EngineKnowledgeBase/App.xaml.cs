using System.Configuration;
using System.Data;
using System.Windows;
using EngineKnowledgeBase.PresentationLogic;
using EngineKnowledgeBase.PresentationLogic.ViewModels;

namespace EngineKnowledgeBase
{
    public partial class App : Application
    {
        protected override async void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            //MainViewModel viewModel = new MainViewModel();
        }
    }
}
