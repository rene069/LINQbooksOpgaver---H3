using LINQbooks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQbooksOpgaver
{
    class Opgave12
    {
        static void Main(string[] args)
        {
            #region a
            //a
            var query =
                from Book in SampleData.Books
                where Book.Publisher.Name == "FunBooks"
                orderby Book.Price ascending
                select Book.Title;


            foreach (var item in query)
            {
                Console.WriteLine(item);
            }
            #endregion

            //#region b
            ////b

            //var queryb =
            //     from Book in SampleData.Books
            //     where Book.PageCount > 100
            //     orderby Book.Title ascending
            //     select Book;

            //foreach (var item in queryb)
            //{
            //    Console.WriteLine(item.Title + " " + item.PageCount);
            //}

            //#endregion

            //#region c 

            ////c

            //var queryc =
            //         from Book in SampleData.Books
            //         where Book.PageCount > 100
            //         orderby Book.Title ascending
            //         select new
            //         {
            //             Title = Book.Title,
            //             Sideantal = Book.PageCount
            //         };

            //foreach (var item in queryc)
            //{
            //    Console.WriteLine(item.Title + " " + item.Sideantal);
            //}


            //#endregion


        }

    }

    //b extention


}

