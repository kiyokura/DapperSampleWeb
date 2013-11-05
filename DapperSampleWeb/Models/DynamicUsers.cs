using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Dapper; // Dapperの機能は拡張メソッドで提供されるため、必須

namespace DapperSampleWeb.Models
{
    /// <summary>
    /// Query拡張メソッドの型引数を指定せず動的型にマッピングするサンプル
    /// </summary>
    public class DynamicUsers
    {
        internal List<dynamic> GetList()
        {
            using (var cn = DbConnectionUtil.GetConnection())
            {
                cn.Open();

                // Query拡張メソッドで型引数を指定しない。
                // 戻り値はIEnumerable<dynamic>となる
                // dynamicの中身（？）は、クエリ結果のカラムと同名/同型のメンバを持ったオブジェクトとなる。
                return cn.Query("SELECT Id, FirstName , LastName ,Email , Age FROM Users ORDER BY Id").ToList();
            }
        }

    }
}