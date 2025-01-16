using Microsoft.Extensions.Hosting;

namespace IKM6.Models
{
    public class item
    {
        
        public int id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public float price { get; set; }
        public List<values> Values { get; } = [];
    }
}
