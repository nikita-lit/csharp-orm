using orm.Models;

namespace orm.Data;

public static class SeedData
{
    public static void Initialize(ApplicationDbContext context)
    {
        if (context.Articles.Any())
        {
            return;
        }

        var contact = new ContactData
        {
            Address = "Akadeemia tee 15",
            Phone = "55512345"
        };
        context.ContactDatas.Add(contact);
        context.SaveChanges();

        var author = new Author
        {
            FirstName = "Mari",
            LastName = "Maasikas",
            PersonalCode = "49001010001",
            ContactDataId = contact.Id,
            Contact = contact
        };
        context.Authors.Add(author);
        context.SaveChanges();

        var article = new Article
        {
            Header = "Esimene artikkel",
            Content = "See on näidisartikkel.",
            AuthorId = author.Id
        };
        context.Articles.Add(article);
        context.SaveChanges();

        context.Comments.Add(new Comment
        {
            Date = DateTime.Now,
            Content = "Esimene kommentaar",
            ArticleId = article.Id,
            AuthorId = author.Id
        });

        var category = new Category { Name = "Raamatud" };
        context.Categories.Add(category);
        context.SaveChanges();

        var product = new Product
        {
            Name = "C# õpik",
            Price = 29.99,
            Image = "csharp-book.jpg",
            Active = true,
            Stock = 10,
            CategoryId = category.Id
        };
        context.Products.Add(product);
        context.SaveChanges();

        var person = new Person
        {
            PersonCode = "50001010002",
            FirstName = "Jaan",
            LastName = "Jänes",
            Phone = "55567890",
            Address = "Ehitajate tee 5",
            Password = "test",
            Admin = false
        };

        context.Orders.Add(new Order
        {
            created = DateTime.Now,
            TotalSum = product.Price,
            Paid = false,
            Person = person,
            CartProduct =
            [
                new CartProduct
                {
                    ProductId = product.Id,
                    Quantity = 1
                }
            ]
        });

        context.Subjects.Add(new Subject
        {
            Code = "ITI0202",
            Name = "Programmeerimine II",
            Credits = 6,
            Classroom = new Classroom
            {
                Building = "ICT",
                BuildingSection = "A",
                RoomNumber = "A-101",
                Floor = 1,
                Capacity = 30
            },
            Students =
            [
                new Student
                {
                    StudentCode = "ST001",
                    FirstName = "Kati",
                    LastName = "Kask",
                    Email = "kati.kask@example.com"
                }
            ],
            Lecturers =
            [
                new Lecturer
                {
                    FirstName = "Peeter",
                    LastName = "Pärn",
                    Email = "peeter.parn@example.com"
                }
            ]
        });

        context.SaveChanges();
    }
}
