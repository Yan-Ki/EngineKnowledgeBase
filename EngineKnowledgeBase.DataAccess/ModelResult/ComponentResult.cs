
namespace EngineKnowledgeBase.PresentationLogic.Models
{
    public class ComponentResult
    {
        public ComponentResult(){ }
        
        public int ComponentId { get; set; }
        public string Name { get; set; }
        public string? Simple { get; set; }
        public string? Product { get; set; }
        public int? Count { get; set; }
        public int ParentId { get; set; }
        //public int ? ChildId { get; set; }
        public string? Description { get; set; }
    }
}
