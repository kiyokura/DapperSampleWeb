using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Dapper; // Dapperの機能は拡張メソッドで提供されるため、必須

namespace DapperSampleWeb.Models
{
    public class TransUsers
    {
        internal List<UserEntity> GetList()
        {
            using (var cn = DbConnectionUtil.GetConnection())
            {
                cn.Open();
                return cn.Query<UserEntity>("SELECT * FROM Users ORDER BY ID").ToList();
            }
        }

        internal UserEntity GetDetail(int Id)
        {
            using (var cn = DbConnectionUtil.GetConnection())
            {
                cn.Open();
                return cn.Query<UserEntity>("SELECT * FROM Users WHERE Id = @ID ", new { ID = Id }).FirstOrDefault();
            }
        }

        // transactionを開始して、commitして正常に終わるパターンの例
        internal void UpdateCommitOK(UserEntity data)
        {
            using (var cn = DbConnectionUtil.GetConnection())
            {

                cn.Open();

                // 通常のADO.NETと同様、トランザクションを開始する
                var tr = cn.BeginTransaction();

                try
                {
                    // Execute拡張メソッドの第三引数：transactionに開始したトランザクションをセット
                    cn.Execute(" UPDATE Users " +
                               " SET " +
                               "     FirstName = @FirstName , " +
                               "     LastName = @LastName , " +
                               "     Email = @Email , " +
                               "     Age = @Age " +
                               " WHERE " +
                               "     Id = @ID ",
                               data,
                               tr);

                    // 通常通り、コミットすればOK
                    tr.Commit();
                }
                catch (Exception)
                {
                    // 例外の場合等は、ロールバックする。
                    tr.Rollback();
                }
            }
        }

        // transactionを開始して、（敢て）rollbackするパターンの例
        internal void UpdateCommitNG(UserEntity data)
        {
            using (var cn = DbConnectionUtil.GetConnection())
            {

                cn.Open();

                // 通常のADO.NETと同様、トランザクションを開始する
                var tr = cn.BeginTransaction();

                try
                {
                    // Execute拡張メソッドの第三引数：transactionに開始したトランザクションをセット
                    cn.Execute(" UPDATE Users " +
                               " SET " +
                               "     FirstName = @FirstName , " +
                               "     LastName = @LastName , " +
                               "     Email = @Email , " +
                               "     Age = @Age " +
                               " WHERE " +
                               "     Id = @ID ",
                               data,
                               tr);

                    // 通常通り、コミットすればOK...だが、ここはサンプルの為、あえて例外を出す。

                    throw new Exception("敢て例外を発生させる");

                    tr.Commit();
                }
                catch (Exception)
                {
                    // 例外の場合等は、ロールバックする。
                    tr.Rollback();
                }
            }
        }


    }
}