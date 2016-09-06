using System.ComponentModel.DataAnnotations.Schema;

namespace MultiList.Models
{
    public class ListItem
    {
        public int ListItemId { get; set; }

        public string Description { get; set; }
        public string PriorityClass { get; set; }
        public int PriorityNumber { get; set; }
        public int ListId { get; set; }
        [ForeignKey("ListId")]
        public virtual List list { get; set; }

    }
}