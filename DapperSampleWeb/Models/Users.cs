using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Dapper; // Dapperの機能は拡張メソッドで提供されるため、必須

namespace DapperSampleWeb.Models
{
    class Users
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

        internal UserEntity GetDetail(int Id)
        {
            using (var cn = DbConnectionUtil.GetConnection())
            {
                cn.Open();

                // パラメタライズドクエリでパラメータを設定する場合、
                // 第二引数（param）に『バインド変数名と同じ名前のメンバ』を持ったオブジェクトを渡す。
                // この例のように、匿名オブジェクトでもOK。
                return cn.Query<UserEntity>("SELECT * FROM Users WHERE Id = @ID ",new { ID = Id }).FirstOrDefault();
            }
        }

        internal int GetCount()
        {
            using (var cn = DbConnectionUtil.GetConnection())
            {
                cn.Open();

                // スカラ値を取得する例
                return cn.Query<int>("SELECT Count(*) FROM Users").Single();
            }
        }

        internal void Update(UserEntity data)
        {
            using (var cn = DbConnectionUtil.GetConnection())
            {
                cn.Open();

                // パラメタライズドクエリでパラメータを設定する場合、その２．
                // 当然、匿名型ではなく名前を持った型も設定可能.
                //
                // なお、UPDATE/INSERT/DELETE等、結果列を返さないクエリの実行はExecute拡張メソッドを利用する。
                cn.Execute(" UPDATE Users " +
                           " SET " +
                           "     FirstName = @FirstName , " +
                           "     LastName = @LastName , " +
                           "     Email = @Email , " +
                           "     Age = @Age " +
                           " WHERE " +
                           "     Id = @ID ",
                           data);
            }
        }


        internal void Create(UserEntity data)
        {
            using (var cn = DbConnectionUtil.GetConnection())
            {
                cn.Open();

                // パラメタライズドクエリでパラメータを設定する場合、その３．
                // バインドに使用しないメンバが存在しても問題ない
                // （今回の場合、data.IDは使用しない為不要だが、あってもエラーにならない
                cn.Execute(" INSERT INTO Users " +
                           "  (FirstName , LastName , Email , Age) " +
                           " VALUES " +
                           "  (@FirstName , @LastName , @Email, @Age )",
                           data);
            }
        }


        internal void Delete(int id)
        {
            using (var cn = DbConnectionUtil.GetConnection())
            {
                cn.Open();
                cn.Execute(" DELETE Users " +
                           " WHERE " +
                           "     Id = @ID ",
                           new { ID = id });
            }
        }
    }
}
