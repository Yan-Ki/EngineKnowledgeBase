
namespace EngineKnowledgeBase.DataAccess.Models
{
    public class Component
    {
        public Component() { }

        public int ComponentId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Simple { get; set; }
        public string? Product { get; set; }
        public ICollection<Included> Children { get; set; }
        public ICollection<Included> Parents { get; } 
    }
}
