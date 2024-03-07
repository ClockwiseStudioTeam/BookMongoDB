using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Linq;

namespace BookMongoDB
{

    public class Book
    {
        public ObjectId _id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int YearPublished { get; set; } 


        public override string ToString()
        {
            return $"Livro: {Title} ||| Author= {Author}  || Publish Year: {YearPublished}";
        }

    }



    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "mongodb+srv://treasurehunterstickets:Mongo92@cluster0.bo0cxpe.mongodb.net/?retryWrites=true&w=majority&appName=Cluster0";
            string dataBaseName = "myDataBase";
            string collectionName = "books";

            //connect to MongoDb
            var client = new MongoClient(connectionString);
            var database = client.GetDatabase(dataBaseName);
            var collection = database.GetCollection<Book>(collectionName);

            var book = new Book
            {
                Title = " Os fundamentos de Quimica",
                Author = "Albert Einstein",
                YearPublished = 1997
            };

            //Insere um livro na base de dados
            collection.InsertOne(book);

            //Vai buscar todos os livros que estão na minha base de dados
            var filter = Builders<Book>.Filter.Empty;
            var allBooks = collection.Find(filter).ToList();

            if (allBooks.Any())
            {
                foreach (Book book1 in allBooks)
                {

                    Console.WriteLine(book1);
                }

            }
            else
            {
                Console.WriteLine("No books found");
            }





        }
    }
}
