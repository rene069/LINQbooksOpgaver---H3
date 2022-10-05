// A. Ved hjælp af LINQbooks projektet laves en query, der henter alle de bøger som er udgivet af forlaget ”FunBooks”, sorteret stigende efter pris. 
//    Benyt Select til at beskære resulatet, således at det kun er Title, der udlæses i foreach løkken
// B. Lav en query, der henter alle de bøger som er på over 100 sider, sorteret stigende efter titel. 
//    Her skal ikke benyttes en Select, men udlæsningen af Title og PageCount tilpasses i en foreach
// C. Lav den samme query igen, men benyt denne gang en anonymous type til at beskære resultatet, så det bliver nemt at udlæse Title og PageCount. 
//    Kald de nye properties: Titel og Sideantal.

using LINQbooks;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace LINQbooksOpgaver
{
    class Opgave1
    {
        static void Main(string[] args)
        {
            #region a
            //a
            var query = SampleData.Books.Where(t => t.Publisher.Name == "FunBooks").Select(t => t.Title);

            foreach (var item in query)
            {
                Console.WriteLine(item);
            }
            #endregion

            #region b
            //b
            var queuryb = SampleData.Books.Where(x => x.PageCount > 100).ToBookB().OrderBy(t => t.Title);

            foreach (var item in queuryb)
            {
                Console.WriteLine(item.PageCount + " " + item.Title);
            }
            #endregion

            #region c 

            //c
            var queryc = SampleData.Books.Where(x => x.PageCount > 100).ToBookC().OrderBy(t => t.Title);

            foreach (var item in queryc)
            {
                Console.WriteLine(item.SideAntal + " " + item.Title);
            }

            #endregion


        }

    }

    //b extention
    public static class BookExtentions
    {
        public static IEnumerable<Book> ToBookB(this IEnumerable<Book> books)
        {
            foreach (var book in books)
            {
                yield return new Book
                {
                    PageCount = book.PageCount,
                    Title = book.Title,
                };
            }
        }
        //c extentionmethod
        public static IEnumerable<dynamic> ToBookC(this IEnumerable<dynamic> books)
        {
            foreach (var book in books)
            {
                yield return new 
                {
                    SideAntal = book.PageCount,
                    Title = book.Title,
                };
            }
        }
    }
}
