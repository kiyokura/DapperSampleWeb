using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Dapper;

namespace DapperSampleWeb.Models
{
    public class NestedObjectModels
    {
        internal List<UserFavoriteBookEntity> GetRecords1()
        {
            using (var cn = DbConnectionUtil.GetConnection())
            {
                cn.Open();

                // 型引数を複数与える。
                // 型引数には、SELECT句の前から順に、カラムをマップする方を指定。
                // （splitOn引数で指定した名前のカラムで分割し、それぞれの型にマップする。）
                // 最後の型引数は、最終的に返却する型を指定する。
                // 
                // map引数には、マッピングするアルゴリズムをラムダで記述する。
                // 引数の型と数と順番は、Query拡張メソッドの型引数で指定した順（最後の一つは除く）
                // ラムダ式の戻り値は、Query拡張メソッドの型引数の最後に指定したものになるようにする。
                //
                // splitOnには結果列の区切りなるカラム名を指定する。
                // 複数ある場合は、カンマで区切る。
                // 同名であっても数が合っていればよしなにやってくれる。
                var ret = cn.Query<UserFavoriteBookEntity, UserEntity, BooksEntity, UserFavoriteBookEntity>(
                        " SELECT " +
                        "     f.Id, " +
                        "     u.Id, " +
                        "     u.FirstName, " +
                        "     u.LastName, " +
                        "     u.Email, " +
                        "     u.Age, " +
                        "     b.Id, " +
                        "     b.Name " +
                        " FROM " +
                        "     UserFavoriteBook f left join " +
                        "         Users u on f.UserID = u.Id Left Join  " +
                        "             Books b on f.BookID = b.id",
                        map: (uf, user, book) =>
                                    {
                                        uf.User = user;
                                        uf.InterstBook = book;
                                        return uf;
                                    },
                        splitOn: "Id,Id"
                        ).ToList();

                return ret;
            }
        }

    }
}