using MultiList.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MultiList.Infrastructure
{
    public class MultiListDataContext : DbContext
    {
        public MultiListDataContext() :base("MyMultiListDatabase")
        {
            

        }

        public IDbSet<ListItem> ListItems { get; set; }
        public IDbSet<List> Lists{ get; set; }

        
    }
}