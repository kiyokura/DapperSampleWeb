using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Dapper;

namespace DapperSampleWeb.Models
{
    public class MultiRowUpdateUsers
    {

        internal List<UserEntity> GetList()
        {
            using (var cn = DbConnectionUtil.GetConnection())
            {
                cn.Open();

                // Query拡張メソッドに型引数を渡すと、その型にマッピングする。
                // 戻り値はIEnumerable<UserEntity>となる
                return cn.Query<UserEntity>("SELECT * FROM Users ORDER BY ID").ToList();
            }
        }


        internal void InsertMultiRow()
        {
            using (var cn = DbConnectionUtil.GetConnection())
            {
                cn.Open();

                // リストを作って渡してやる
                var param = new List<UserEntity>()
                {
                    new UserEntity()
                        {
                            FirstName = "氏１",
                            LastName = "名１",
                            Email = "add1@example.com",
                            Age = 11
                        },
                    new UserEntity()
                        {
                            FirstName = "氏2",
                            LastName = "名2",
                            Email = "add2@example.com",
                            Age = 22
                        },
                    new UserEntity()
                        {
                            FirstName = "氏3",
                            LastName = "名3",
                            Email = "add3@example.com",
                            Age = 33
                        },
                };

                // 配列でもOK
                //var param = new[]
                //{
                //  new
                //  {
                //      FirstName = "氏１",
                //      LastName = "名１",
                //      Email = "add1@example.com",
                //      Age = 11
                //  },
                //  new
                //  {
                //      FirstName = "氏2",
                //      LastName = "名2",
                //      Email = "add2@example.com",
                //      Age = 22
                //  },
                //  new
                //  {
                //      FirstName = "氏3",
                //      LastName = "名3",
                //      Email = "add3@example.com",
                //      Age = 33
                //  },
                //};

                cn.Execute("INSERT INTO Users (FirstName,LastName,Email,Age ) VALUES (@FirstName,@LastName,@Email,@Age)  ", param);
            }
        }

        internal void UpdateMultiRow()
        {
            using (var cn = DbConnectionUtil.GetConnection())
            {
                cn.Open();

                // リストを作って渡してやる
                var param = new List<UserEntity>()
                {
                    new UserEntity()
                        {
                            FirstName = "氏1111",
                            LastName = "名1111",
                            Age = 11
                        },
                    new UserEntity()
                        {
                            FirstName = "氏22222",
                            LastName = "名22222",
                            Age = 22
                        },
                    new UserEntity()
                        {
                            FirstName = "氏33333",
                            LastName = "名33333",
                            Age = 33
                        },
                };

                // 配列でもOK
                //var param = new[]
                //{
                //  new
                //  {
                //      FirstName = "氏1111",
                //      LastName = "名1111",
                //      Age = 11
                //  },
                //  new
                //  {
                //      FirstName = "氏22222",
                //      LastName = "名22222",
                //      Age = 22
                //  },
                //  new
                //  {
                //      FirstName = "氏33333",
                //      LastName = "名33333",
                //      Age = 33
                //  },
                //};

                cn.Execute("UPDATE Users SET FirstName = @FirstName , LastName = @LastName WHERE Age = @Age ", param);
            }
        }
    }
}