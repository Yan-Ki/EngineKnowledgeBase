using EngineKnowledgeBase.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EngineKnowledgeBase.DataAccess.Repositories
{
   public class RepositoriesEngineDB
    {
        public  MainDbContext mainDbContext {  get; set; }
        public RepositoriesEngineDB() 
        {
            mainDbContext = new MainDbContext();

        }
        //public async Task<List<Models.Component>> Get()
        //{
        //    return await mainDbContext.Components.AsNoTracking()
        //        .OrderBy(x => x.ComponentId)
        //        .ToListAsync();

        //}

        public  List<Component> Get()
        {
           
                var result = mainDbContext.Components.ToList();
                return result;
            

        }
    }
}
