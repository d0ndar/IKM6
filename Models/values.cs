using Microsoft.Extensions.Hosting;

namespace IKM6.Models
{
    public class values
    {
        public int id { get; set; }
        public int property_id { get; set; }
        public string name { get; set; }
        public property? property { get; }


        public List<item> Items { get; } = [];
    }
}
