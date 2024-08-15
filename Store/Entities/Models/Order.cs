using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public string? Data { get; set; }
        public ICollection<CartLine> Lines { get; set; } = new List<CartLine>();

        [Required(ErrorMessage="İsim Bilgisi Hatalı.")]
        public String? Name { get; set; }


        [Required(ErrorMessage = "Adres Bilgisi Hatalı.")]
        public String? Line1 { get; set; }
        public String? Line2 { get; set; }
        public String? Line3 { get; set; }
        public String? Şehir { get; set; }

        public bool GiftWrap { get; set; }
        public bool Shipped { get; set; }
        public DateTime OrderedAt { get; set; } = DateTime.Now;




    }
}
