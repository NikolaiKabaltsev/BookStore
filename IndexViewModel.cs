using BookStore.Models;
using System.Collections.Generic;

public class IndexViewModel
{
    public IEnumerable<Book> Bks { get; set; }
    public IEnumerable<OrderModel> Ordrs { get; set; }
}
