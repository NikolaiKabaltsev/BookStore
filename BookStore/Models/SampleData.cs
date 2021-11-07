using System.Linq;
using BookStore.Models;

namespace BookStore
{
    public static class SampleData
    {
        public static void Initialize(BkContext context)
        {
            if (!context.Bookes.Any())
            {
                context.Bookes.AddRange(
                    new Book
                    {
                        ProductImageName = @"https://cdn1.ozone.ru/s3/multimedia-o/wc1200/6066541956.jpg",
                        Title = "Дюна",
                        Author = "Фрэнк Герберт",
                        Quantity = 8,
                        Price = 500
                    },
                    new Book
                    {
                        ProductImageName = @"https://cdn1.ozone.ru/s3/multimedia-k/wc1200/6121197332.jpg",
                        Title = "Поезд убийц",
                        Author = "Котаро Исака",
                        Quantity = 10,
                        Price = 400
                    },
                    new Book
                    {
                        ProductImageName = @"https://img3.labirint.ru/rc/032ed270588adf99de8b4b3e4c42dc39/220x340/books82/816939/cover.jpg?1628659754",
                        Title = "ПОСТ",
                        Author = "Дмитрий Глуховский",
                        Quantity = 5,
                        Price = 500
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
