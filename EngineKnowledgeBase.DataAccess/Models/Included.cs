
namespace EngineKnowledgeBase.DataAccess.Models
{
    public class Included
    {
        public int IncludedId { get; set; }
        public int ChildId { get; set; } 
        public int ParentId { get; set; }
        public int Count { get; set; }
        public Component Child { get; set; }   
        public Component Parent { get; set; }
    }
}
