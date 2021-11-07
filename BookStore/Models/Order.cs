using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public string UserId { get; set; } // имя фамилия покупателя
        public string Address { get; set; } // адрес покупателя
        public string ContactPhone { get; set; } // контактный телефон покупателя
        public int Quantity { get; set; }
        public int BookId { get; set; } // ссылка на связанную книгу
    }
}
