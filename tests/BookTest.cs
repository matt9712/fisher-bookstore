using System;
using Xunit;
using Fisher.Bookstore.Models;

namespace tests
{
    public class BookTest
    {
        [Fact]
        public void ChangePublicationDate()
        {
            var book = new Book()
            {
                Id = 1,
                Title = "Domain Driven Design",
                Author = new Author()
                {
                    Id = 65,
                    Name = "Eric Evans"
                },
                PublishDate = DateTime.Now.AddMonths(-6),
                Publisher = "McGraw-Hill"
            };

            var newPublicationDate = DateTime.Now.AddMonths(2);
            book.ChangePublicationDate(newPublicationDate);

            var expectedPublicationDate = newPublicationDate.ToShortDateString();
            var actualPublicationDate = book.PublishDate.ToShortDateString();

            Assert.Equal(expectedPublicationDate, actualPublicationDate);

        }

        public void ChangePublisherName()
        {
            var book = new Book()
            {
                Id = 2,
                Title = "School's Going to Kill Me",
                Author = new Author()
                {
                    Id = 138,
                    Name = "Matt Herold"
                },
                PublishDate = DateTime.Now,
                Publisher = "Herold's Yitty Books"
            };

            var newPublisherName = "Herold's Really Yitty Books";
            book.ChangePublisherName(newPublisherName);

            Assert.Equal(newPublisherName, book.Publisher);
        }

        public void AddAuthorName()
        {
            var book = new Book()
            {
                Id = 101,
                Title = "Dalmations",
                Author = new Author()
                {
                    Id = 101,
                    Name = "I. D. K. Who"
                },
                PublishDate = DateTime.Now,
                Publisher = "DogBooks Inc.,"
            };

            var originalAuthor = book.Author.Name;
            var newAuthor = "The Acutal Author";
            book.AddAuthorName(newAuthor);

            Assert.Equal(originalAuthor + " and " + newAuthor, book.Author.Name);
        }
    }
}
