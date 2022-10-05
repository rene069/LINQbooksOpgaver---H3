// A. Vha. LINQbooks projektet laves en query, der henter alle de bøger som er på over 100 sider og som koster under 30$, 
//    sorteret stigende efter titel og efter faldende pris. Udlæs Title, PageCount og Price.
// B. Lav en query, der finder de to dyreste bøger.
// C. Lav en query, der henter alle de bøger som har et Review. Udskriften skal vise bogens Title 
//    og nedenunder skal der være en indrykket liste med User og vedkommendes Comments.


using LINQbooks;
using System;
using System.Linq;


namespace LINQbooksOpgaver
{
    class Opgave4
    {
        static void Main(string[] args)
        {
            //#region A
            //A
            //var queryA =
            //    from Books in SampleData.Books
            //    where Books.PageCount > 100 && Books.Price < 30
            //    orderby Books.Title ascending, Books.Price descending
            //    select Books;

            //foreach (var item in queryA)
            //{
            //    Console.WriteLine($"{item.Title} : {item.PageCount} : {item.Price}");
            //}
            //#endregion

            //#region B
            ////B
            //var queryB =
            //    from book in SampleData.Books
            //    orderby book.Price descending
            //    select book;

            //foreach (var item in queryB.Take(2))
            //{
            //    Console.WriteLine($"{item.Title} : {item.Price}");
            //}
            //#endregion


            ////C

            //var queryC =
            //    from Books in SampleData.Books
            //    where Books.Reviews.Count() > 0
            //    select Books;

            //foreach (var item in queryC)
            //{
            //    Console.WriteLine($"{item.Title}");
            //    foreach (var review in item.Reviews)
            //    {
            //        Console.WriteLine($"User: {review.User.Name} - Comment: {review.Comments}");
            //    }
            //}


            //d




                var query2 =
                     from sub in SampleData.Subjects
                     join book in SampleData.Books on sub.Name equals book.Subject.Name
                         into bookgroup
                     select new
                     {
                         sub = sub,
                         Title = bookgroup
                     } into result
                     group result by result.sub.Name;

            var cry = SampleData.Subjects.GroupJoin(SampleData.Books, m => m.Name, c => c.Subject.Name,
                (m, g) =>
                new
                {
                    Subject = m,
                    Title = g
                }).GroupBy(m => m.Subject.Name);

            foreach (var item in query2)
            {
                Console.WriteLine($"{item.Key}");
                foreach (var item2 in item.SelectMany(g => g.Title))
                {
                    Console.WriteLine($"{item2.Title}");
                }
            }


            foreach (var item in cry)
            {
                Console.WriteLine($"{item.Key}");
                foreach (var item2 in item.SelectMany(g => g.Title))
                {
                    Console.WriteLine($"{item2.Title}");
                }
            }

        }
    }
}
