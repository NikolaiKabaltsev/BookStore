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
                        ProductImageName = @"https://i.stack.imgur.com/ILTQq.png",
                        Title = "Дюна",
                        Author = "Фрэнк Герберт",
                        Price = 500
                    },
                    new Book
                    {
                        Title = "Поезд убийц",
                        Author = "Котаро Исака",
                        Price = 400
                    },
                    new Book
                    {
                        Title = "ПОСТ",
                        Author = "Дмитрий Глуховский",
                        Price = 500
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
