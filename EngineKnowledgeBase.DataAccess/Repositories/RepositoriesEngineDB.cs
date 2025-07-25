using EngineKnowledgeBase.PresentationLogic.Models;

using Component = EngineKnowledgeBase.DataAccess.Models.Component;

namespace EngineKnowledgeBase.DataAccess.Repositories
{
    public static class RepositoriesEngineDB
    {
        static RepositoriesEngineDB(){}

        public static List<Component> GetProduct() //Для наполнения вьюмодели
        {
            using (MainDbContext mainDbContext = new MainDbContext())
            {
                var result = (from product in mainDbContext.Components
                              where product.Product == "true"
                              select product).ToList();
                return result;
            }
        }

        public static List<ComponentResult> GetComponent(int ComponentId)//Для наполнения вьюмодели
        {
            using (MainDbContext mainDbContext = new MainDbContext())
            {
                var result = mainDbContext.Includeds
              .Where(i => i.ParentId == ComponentId)
              .Join(
        mainDbContext.Components,
        i => i.ChildId,
        c => c.ComponentId,
        (i, c) => new
        {
            c.ComponentId,
            c.Name,
            c.Description,
            c.Simple,
            c.Product,
            i.Count,

            i.ParentId
        }
    )
    .ToList();
                List<ComponentResult> commonentsResult = new List<ComponentResult>();
                foreach (var i in result)
                {
                    commonentsResult.Add(new ComponentResult()
                    {
                        ComponentId = i.ComponentId,
                        Name = i.Name,
                        Description = i.Description,
                        Product = i.Product,
                        Simple = i.Simple,
                        ParentId = i.ParentId,
                        Count = i.Count
                    });
                }
                return commonentsResult;
            }
        }

        public static List<Component> EditElement()
        {
            using (MainDbContext mainDbContext = new MainDbContext())
            {
                var result = mainDbContext.Components.ToList();
                return result;
            }
        }

        public static string DeleteElement(int ComponentId, int ParentId)
        {
            using (MainDbContext mainDbContext = new MainDbContext())
            {
                string answer = "";
                var component = mainDbContext.Components.SingleOrDefault(p => p.ComponentId == ComponentId);
                if (component == null)
                {
                    answer = "Элемент не найден";
                    return answer;
                }

                var childComponent = mainDbContext.Includeds.SingleOrDefault(c => c.ChildId == ComponentId);
                var includeRemove = mainDbContext.Includeds.Where(i => i.ParentId == ParentId && i.ChildId == ComponentId);
                mainDbContext.Includeds.RemoveRange(includeRemove);
                if (childComponent == null)
                {
                    mainDbContext.Components.RemoveRange(component);
                }
                else
                {
                    var includesToRemove = mainDbContext.Includeds.Where(i => i.ParentId == ComponentId).ToList();
                }
                mainDbContext.SaveChanges();

                //if (component.Simple == "true")
                //{
                //    var includesToRemove = mainDbContext.Includeds.Where(i => i.ParentId == ComponentId).ToList();
                //    var childIds = includesToRemove.Select(i => i.ChildId).Distinct().ToList();
                //    mainDbContext.Includeds.RemoveRange(includesToRemove);
                //    mainDbContext.SaveChanges();

                //    foreach (var childId in childIds)
                //    {
                //        var childComponent = mainDbContext.Components.SingleOrDefault(c => c.ComponentId == childId);
                //        if (childComponent != null)
                //        {
                //            mainDbContext.Components.Remove(childComponent);
                //        }
                //    }
                //    mainDbContext.SaveChanges();
                //    answer = "Удалено";
                //}
                //else
                //{
                //    var includesToRemove = mainDbContext.Includeds.Where(i => i.ChildId == ComponentId).ToList();
                //    var childIds = includesToRemove.Select(i => i.ChildId).Distinct().ToList();
                //    foreach (var childId in childIds)
                //    {
                //        var childComponent = mainDbContext.Components.SingleOrDefault(c => c.ComponentId == childId);
                //        if (childComponent != null)
                //        {
                //            mainDbContext.Components.Remove(childComponent);
                //        }
                //    }
                //    mainDbContext.SaveChanges();
                //    answer = "Удалено";
                //    mainDbContext.Components.Remove(component);
                //    mainDbContext.SaveChanges();
                //    answer = "Удалено";
                //}             
                return answer;
            }
        }

        public static ComponentResult AddProduct(string Name)
        {
            using (MainDbContext mainDbContext = new MainDbContext())
            {
                if (!mainDbContext.Components.Any(c => c.Name == Name))
                {
                    Component component = new Component { Name = Name, Product = "true" };
                    mainDbContext.Components.Add(component);
                    mainDbContext.SaveChanges();

                    ComponentResult componentResult = new ComponentResult
                    {
                        ComponentId = component.ComponentId,
                        Name = component.Name,
                        Description = component.Description
                    };
                    return componentResult;
                }
                else
                {
                    return null;
                }
            }
        }

        public static ComponentResult AddComponent(string Name)
        {
            using (MainDbContext mainDbContext = new MainDbContext())
            {
                if (!mainDbContext.Components.Any(c => c.Name == Name))
                {
                    Component component = new Component { Name = Name, Product = "true" };
                    mainDbContext.Components.Add(component);
                    mainDbContext.SaveChanges();

                    ComponentResult componentResult = new ComponentResult
                    {
                        ComponentId = component.ComponentId,
                        Name = component.Name,
                        Description = component.Description
                    };
                    return componentResult;
                }
                else
                {
                    return null;
                }
            }
        }

        public static void Report()
        {
            using (MainDbContext mainDbContext = new MainDbContext())
            {
            }
        }
    }
}
