using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DapperSampleWeb.Models
{
    public class UserFavoriteBookEntity
    {
        public int ID { get; set; }
        public UserEntity User { get; set; }
        public BooksEntity InterstBook { get; set; }
    }
}