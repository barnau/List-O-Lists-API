using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MultiList.Models
{
    public class List
    {

        public List()
        {
            ListItems = new List<ListItem>();
        }
        public int ListId { get; set; }
        public string ListDescription { get; set; }
        public virtual ICollection<ListItem> ListItems { get; set; }
    }
}