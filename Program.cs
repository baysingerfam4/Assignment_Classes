using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Reflection.Metadata;

namespace Assignment_Classes
{
    internal class Program
    {
        // Carla Baysinger
        // May 29th 2024
        // Assignment - Basic Console Application Using Classes

        static Book[] books = new Book[10];
        static void Main(string[] args)
        {
            PreLoad();
            Menu();



        }// Main

        public static void Menu()
        {
            
                Console.WriteLine("Choose a menu option: ");
                Console.WriteLine("1 - Add a new book");
                Console.WriteLine("2 - Display all books");
                Console.WriteLine("3 - Update a book's information");
                Console.WriteLine("4 - Exit the program");
                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        AddANewBook1();
                        break;
                    case "2":
                        DisplayAllBooks();
                        break;
                    case "3":
                        UpdateInformation();
                        break;
                    case "4":
                        Console.WriteLine("Exit");
                        break;
                    default:
                        Console.WriteLine("Invalid");
                        break;
                }
                 


        }// Menu
        public static void PreLoad()
        {
            books[0] = new Book("Happy Place", "Emily Henry", 2023);
            books[1] = new Book("The Nightingale", "Kristin Hannah", 2015);
            books[2] = new Book("Remarkably Bright Creatures", "Shelby Van Pelt", 2022);
            books[3] = new Book("The BodyGuard", "Katherine Center", 2022);
            books[4] = new Book("The Women", "Kristin Hannah", 2024);
        }// PreLoad()

           
        public static Book AddANewBook1()
        {
            //Prompt the user to enter the title, author, and year of publication.
            //Otherwise, add the new book after the last book in the array.

            Console.WriteLine("Enter the title: ");
            string title = Console.ReadLine();

            Console.WriteLine("Enter the author: ");
            string author = Console.ReadLine();

            Console.WriteLine("Enter the year of publication: ");
            int year = Convert.ToInt32(Console.ReadLine());
            
            
            Book name = new Book(title, author, year);
            return name;

        }
        public static void AddANewBook2()
        {
            
            
            for (int i = 0; i < books.Length; i++)
            {
                
                //Check if there is space in the array.
                if (books[i] == null)
                {
                    // If an empty spot is found, add to space
                    books[i] = AddANewBook1();
                    // You can use the return keyword in a method that is void. To leave the method
                    Console.WriteLine("Book successfully added");
                    return;

                }
            }

            // Throw a new exception
            //If the array is full, display a message indicating that no more books can be added.
            throw new Exception("No more books can be added");
        }

        public static void DisplayAllBooks()
        {
            int count = 0;
            
            for (int i = 0; i < books.Length; i++)
            {
                if (books[i] != null)
                {
                    // Displays information for the books in the following format
                    count++;
                    Console.WriteLine(value: $"Title: {books[i].Title} | Author: {books[i].Author} | Year: {books[i].Year}");
                }
                else
                {
                    Console.WriteLine("Item not found");
                }
            }
             
        }

        public static void UpdateInformation()
        {
            //Prompt the user to enter the title of the book they want to update.
            Console.WriteLine("Enter the title of the book to update: ");
            string title = Console.ReadLine();

            int index = FindBookIndex(title);

            if(index == -1)
            {
                Console.WriteLine("Invalid");
                return;
            }
            //If the book is found, prompt the user to enter the new title, author, and year.
            Console.WriteLine("Enter the new title: ");
            string newtitle = Console.ReadLine();
            Console.WriteLine("Enter the new author: ");
            string newauthor = Console.ReadLine();
            Console.WriteLine("Enter the new year of publication: ");
            int newyear = Convert.ToInt32(Console.ReadLine());

            //Update the book's information with the new values.
            books[index].Title = newtitle;
            books[index].Author = newauthor;
            books[index].Year = newyear;

            Console.WriteLine("Book updated successfully!");
        }

        public static int FindBookIndex(string title)
        {
            for (int i = 0; i < books.Length; i++)
            {
                if (books[i] != null && books[i].Title.Equals(title))
                {
                    return i;
                }
            }
            return -1;
        }

    }//Class

    
    public class Book
    {
        // Fields Title, Author, Year
        public string Title { get; set; }
        public string Author { get; set; }
        public int Year { get; set; }

        public Book(string title, string author,int year)
        { //Constructor Initializes the fields
            Title = title;
            Author = author;
            Year = year;
        }
       
        

    } // Book class



}// Namespace
