using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Dapper;

namespace DapperSampleWeb.Models
{
    public class StoredProcUsers
    {
        internal int GetCountByReturn()
        {
            using (var cn = DbConnectionUtil.GetConnection())
            {
                cn.Open();

                // パラメータにIN/OUT等細かな設定が必要な場合は、
                // DynamicParametersのインスタンスを作ってそこに設定してやればよい模様。

                // 細かな設定が要らないパラメータ（入力専用等）は、コンストラクタに纏めて渡してやればよさそう
                var param = new DynamicParameters( new { baseAge = 24 });
                
                // 値の受け取りなど個別の設定が必要な場合は、一つ一つ設定。
                // 設定内容は、System.Data.Common.DbParameterに設定する内容に準じる。
                // ストアドの戻り値を受け取る場合は、引数directionにSystem.Data.ParameterDirection.ReturnValueを設定。
                param.Add("result", 0 , direction: System.Data.ParameterDirection.ReturnValue);

                // Execute拡張メソッドで実行。引数commandTypeにSystem.Data.CommandType.StoredProcedureを設定してやる。
                cn.Execute("GetCountOlderByRerutnProc", param, commandType: System.Data.CommandType.StoredProcedure);

                return param.Get<int>("result");
            }
        }

        internal int GetCountByOutParam()
        {
            using (var cn = DbConnectionUtil.GetConnection())
            {
                cn.Open();

                // 基本的にはGetCountByReturn()のケースと同様。
                // outputパラメータで値を受け取る場合は引数directionにSystem.Data.ParameterDirection.Outputを設定。
                var param = new DynamicParameters(new { baseAge = 24 });
                param.Add("count", 0, direction: System.Data.ParameterDirection.Output);
                cn.Execute("GetCountOlderByOutputParamProc", param, commandType: System.Data.CommandType.StoredProcedure);
                return param.Get<int>("count");
            }
        }

        internal List<UserEntity> GetListByRecord()
        {

            using (var cn = DbConnectionUtil.GetConnection())
            {
                cn.Open();

                // SQL Serverのストアドでレコードが帰ってくる場合、普通にQuery拡張メソッドを実行すれば良い。
                // （commandTypeは一応書いているが、省略しても多分通る。）
                return cn.Query<UserEntity>("GetOlderUserByRecordProc", new { baseAge = 24 }, commandType: System.Data.CommandType.StoredProcedure).ToList();
            }
            

        }
    }
}