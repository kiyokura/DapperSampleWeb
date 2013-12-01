using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Dapper;

namespace DapperSampleWeb.Models
{
    public class InStatementUsers
    {
        internal List<UserEntity> GetList()
        {
            using (var cn = DbConnectionUtil.GetConnection())
            {
                cn.Open();


                var param = new
                {
                    // IN句に並べたい値をリストとして積んでやる
                    AgeList = new List<int>() { 20, 38 }
                };

                // 上ではジェネリックリストにしているが、配列でもOK
                //var param = new
                //{
                //    AgeList = new int[] { 20, 38 }
                //};


                return cn.Query<UserEntity>("SELECT * FROM Users WHERE Age IN @AgeList ORDER BY ID", param).ToList();
            }
        }
    }
}