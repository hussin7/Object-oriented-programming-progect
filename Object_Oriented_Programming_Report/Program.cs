using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Object_Oriented_Programming_Report
{
    class Book
    {
        private string titlebook, author, year;
        public Book(string titlebook, string author, string year)
        {
            this.titlebook = titlebook;
            this.author = author;
            this.year = year;
        }
        public string Titlebook
        {
            get { return titlebook; }
        }
        public string Author
        {
            get { return author; }
        }
        public string Year
        {
            get { return year; }
        }
    }
    class Library
    {
        public void AddBook(List<Book> books, string title, string author, string year)
        {
            bool unavailable = false;
            foreach (Book book in books)
            {
                if(book.Titlebook==title && book.Author==author && book.Year==year)
                {
                    Console.WriteLine("The book already exists!!");
                    unavailable = true;
                }
            }
            if(!unavailable)
            {
                books.Add(new Book(title, author, year));
                Console.WriteLine("Book added successfully!");
            }
        }
        public void SearchBook(List<Book> books, string searchbook)
        {
            bool found = false;
            foreach (Book book in books)
            {
                if (book.Titlebook.Contains(searchbook) || book.Author.Contains(searchbook))
                {
                    DisPlay(book);
                    found = true;
                }
            }
            if (!found)                          
                Console.WriteLine("No Book Found");            
        }
        public void DisPlay(Book book)
        {
            Console.WriteLine("________________________");
            Console.WriteLine("Title:" + book.Titlebook);
            Console.WriteLine("Author:" + book.Author);
            Console.WriteLine("Year:" + book.Year);
            Console.WriteLine("_________________________");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Book> books = new List<Book>()
            {
                new Book("staying strong: 365 days a year", "demi lovato", "2013"),
                new Book("the forty rules of love","khaled al-jubaili", "2009"),
                new Book("the art of indifference","mark manson", "2016"),
                new Book("the power of your subconscious mind", "joseph murphyv", "1963"),                
            };
            Library library = new Library();
            while (true)
            {
                Console.WriteLine("___________________________________________________");
                Console.WriteLine("If you want to Add a new book, enter the word (Add).");
                Console.WriteLine("If you want to Search for a book, enter a (Search) term.");
                Console.WriteLine("If you want to go out, enter, (Exit).");
                Console.Write("Enter the word that suits you:");                
                string operation = Console.ReadLine().ToLower();
                Console.Clear();                
                if (operation == "add")
                {                    
                    Console.Write("Enter the book title:");
                    string title = Console.ReadLine().ToLower();
                    Console.Write("Enter the author's name:");
                    string author = Console.ReadLine().ToLower(); 
                   
                    string year;
                    while (true)
                    {
                        Console.Write("Enter the year the book was published:");
                        year = Console.ReadLine().ToLower();
                        if (int.TryParse(year, out int years) && years > 0 && years>=1900 &&years<DateTime.Now.Year)                    
                            break;                        
                        else
                            Console.WriteLine("Please enter a valid year (numeric value).");                          
                    }
                    library.AddBook(books, title, author, year);
                }
                else if (operation == "search")
                {                    
                    Console.Write("To search, enter the title book or author name:");
                    string searchbook = Console.ReadLine().ToLower();
                    library.SearchBook(books, searchbook);
                }
                else if (operation == "exit")
                {
                    Console.WriteLine("The program has been exited");
                    Console.WriteLine();
                    break;
                }
                else
                {
                    Console.WriteLine(" ");
                    Console.WriteLine("Invalid input! Please enter 'Add', 'Search', or 'Exit'.");
                    Console.WriteLine();
                }
            }
        }
    }
}