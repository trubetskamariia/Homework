using System.Collections.Generic;

// single responsibility principle 
namespace OrderExample
{
    class Item
    {

    }
    class Order
    {
        private List<Item> itemList;

        internal List<Item> ItemList
        {
            get
            {
                return itemList;
            }
            set
            {
                itemList = value;
            }
        }
        public void CalculateTotalSum() {/*...*/}
        public void GetItems() {/*...*/}
        public void GetItemCount() {/*...*/}
        public void AddItem(Item item) {/*...*/}
        public void DeleteItem(Item item) {/*...*/}
    }
    class OrderPrinter
    {
        public void PrintOrder() {/*...*/}
        public void ShowOrder() {/*...*/}
    }
    class OrderRepository
    {
        public void Load() {/*...*/}
        public void Save() {/*...*/}
        public void Update() {/*...*/}
        public void Delete() {/*...*/}
    }
}

//single responsibility principle 

class Email
{
    public String Theme { get; set; }
    public String From { get; set; }
    public String To { get; set; }
}

class EmailSender
{
    public void Send(Email email)
    {
        // ... sending...
        Console.WriteLine("Email from '" + email.From + "' to '" + email.To + "' was send");
    }
}

class BulkEmailSender
{
    private EmailSender sender = new EmailSender();

    public void SendAll(List<Email> emails)
    {
        foreach (var email in emails)
        {
            sender.Send(email);
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        List<Email> emails = new List<Email>()
        {
            new Email() { From = "Me", To = "Vasya", Theme = "Who are you?" },
            new Email() { From = "Vasya", To = "Me", Theme = "vacuum cleaners!" },
            new Email() { From = "Kolya", To = "Vasya", Theme = "No! Thanks!" },
            new Email() { From = "Vasya", To = "Me", Theme = "washing machines!" },
            new Email() { From = "Me", To = "Vasya", Theme = "Yes" },
            new Email() { From = "Vasya", To = "Petya", Theme = "+2" }
        };

        BulkEmailSender bulkSender = new BulkEmailSender();
        bulkSender.SendAll(emails);

        Console.ReadKey();
    }
}

// Liskov substitution principle 

namespace ShapeExample
{
    interface IShape
    {
        int GetArea();
    }

    class Rectangle : IShape
    {
        public int Width { get; set; }
        public int Height { get; set; }

        public int GetArea()
        {
            return Width * Height;
        }
    }

    class Square : IShape
    {
        public int Side { get; set; }

        public int GetArea()
        {
            return Side * Side;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Rectangle rect = new Rectangle();
            rect.Width = 5;
            rect.Height = 10;
            Console.WriteLine(rect.GetArea()); 

            Square sq = new Square();
            sq.Side = 10;
            Console.WriteLine(sq.GetArea()); 

            Console.ReadKey();
        }
    }
}

// interface segregation principle

namespace ISPExample
{
    interface IPricable
    {
        void SetPrice(double price);
    }

    interface IDiscountable
    {
        void ApplyDiscount(String discount);
        void ApplyPromocode(String promocode);
    }

    interface IColorable
    {
        void SetColor(byte color);
    }

    interface ISizable
    {
        void SetSize(byte size);
    }
    class Book : IPricable, IDiscountable
    {
        public void SetPrice(double price) { }
        public void ApplyDiscount(String discount) { }
        public void ApplyPromocode(String promocode) { }
    }
    class Outerwear : IPricable, IDiscountable, IColorable, ISizable
    {
        public void SetPrice(double price) { }
        public void ApplyDiscount(String discount) { }
        public void ApplyPromocode(String promocode) { }
        public void SetColor(byte color) { }
        public void SetSize(byte size) { }
    }
}
