using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EngineKnowledgeBase.PresentationLogic.ViewModels
{
    public class Component
    {
        public Component(string Name, int Count)
        {
            this.Count = Count;
            this.Name = Name;
        }
        public string Name { get; set; }
        public int? Count { get; set; }
    }
}
