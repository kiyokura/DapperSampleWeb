using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DapperSampleWeb.Models
{
    public class BooksEntity
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int PublisherID { get; set; }
    }
}