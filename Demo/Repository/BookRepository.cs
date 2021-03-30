using Demo.Data;
using Demo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.Repository
{
    public class BookRepository
    {
        private readonly BookStoreContext _context = null;
        public BookRepository(BookStoreContext context)
        {
            _context = context;
        }
        public int AddNewBook(BookModel model)
        {
            var newBook = new Books()
            {
                Author = model.Author,
                CreatedOn = DateTime.UtcNow,
                Description = model.Description,
                Title = model.Title,
                TotalPages = model.TotalPages,
                UpdatedOn = DateTime.UtcNow
            };
            _context.Books.Add(newBook);
            _context.SaveChanges();
            return newBook.Id;
        }
        public List<BookModel> GetAllBooks()
        {
            return DataSource();

        }
        public BookModel GetBookById(int id)
        {
            return DataSource().Where(x => x.Id == id).FirstOrDefault();
        }
        public List<BookModel> SearchBook(string title , string authorName)
        {
            return DataSource().Where(x => x.Title.Contains(title) && x.Author.Contains(authorName)).ToList();

        }

        private List<BookModel> DataSource()
        {
            return new List<BookModel>() { 
            new BookModel() {Id = 1, Title="Physics", Author="Gaurav Kukreti",Description="This is the new book, you should try it!",Category="Physics",Language="English",TotalPages=1034},
            new BookModel() {Id = 2, Title="Chemistry", Author="Gaurav Kukreti",Description="This is the new book, you should try it!",Category="Chemistry",Language="English",TotalPages=1034},
            new BookModel() {Id = 3, Title="Biology", Author="Gaurav Kukreti",Description="This is the new book, you should try it!",Category="Biology",Language="English",TotalPages=103423},
            new BookModel() {Id = 4, Title="Mathematics", Author="Gaurav Kukreti",Description="This is the new book, you should try it!",Category="Mathematics",Language="English",TotalPages=132034},
            new BookModel() {Id = 5, Title="English Core", Author="Gaurav Kukreti",Description="This is the new book, you should try it!",Category="English",Language="English",TotalPages=103434},
            new BookModel() {Id = 6, Title="Psychology", Author="Gaurav Kukreti",Description="This is the new book, you should try it!",Category="Psychology",Language="English",TotalPages=103324},

            };
        }
    }
}
