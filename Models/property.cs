using Microsoft.Extensions.Hosting;

namespace IKM6.Models
{
    public class property
    {
        public int id { get; set; }
        public string title { get; set; }

        public ICollection<values> values { get; } = new List<values>();
    }
}
