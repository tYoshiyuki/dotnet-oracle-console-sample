using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Data;
using System.Linq;

namespace DotNetOracleConsoleSample.DotNet;

/// <summary>
/// バルクインサート処理ヘルパークラス
/// </summary>
public static class OracleBulkInsertHelper
{
    /// <summary>
    /// バルクインサート処理を実施します。
    /// ArrayBindCountを用いて、配列情報を一括でテーブルへインサートします。
    /// <see cref="OracleBulkCopy"/> ではダイレクトパスロードを利用していますが、本処理は通常のインサート処理を実施します。
    /// </summary>
    /// <param name="dt"><see cref="DataTable"/></param>
    /// <param name="context"><see cref="DbContext"/></param>
    public static void OracleBulkInsert(DataTable dt, DbContext context)
    {
        var connection = (OracleConnection)context.Database.GetDbConnection();
        if (connection.State != ConnectionState.Open)
        {
            connection.Open();
        }

        var paramList = dt.Columns.Cast<DataColumn>()
            .Select(x => new OracleParameter
            {
                ParameterName = $":{x.ColumnName}",
                OracleDbType = GetOracleDbType(x.DataType),
                Value = dt.AsEnumerable().Select(r => r[x.ColumnName]).ToArray()
            }).ToArray();

        // INSERT INTO TARGET_TABLE (COLUMN1, COLUMN2...) VALUES (:COLUMN1, :COLUMN2...) の形式でSQLを構築する
        var cmd = connection.CreateCommand();
        cmd.CommandText = $"INSERT INTO {dt.TableName}" +
                          $" ({string.Join(',', paramList.Select(x => x.ParameterName.Substring(1)))})" +
                          $" VALUES ({string.Join(',', paramList.Select(x => x.ParameterName))})";
        cmd.ArrayBindCount = dt.Rows.Count;
        cmd.Parameters.AddRange(paramList);
        cmd.ExecuteNonQuery();
    }

    /// <summary>
    /// <see cref="Type"/> を <see cref="OracleDbType"/> へ変換します。
    /// </summary>
    /// <param name="type"><see cref="Type"/></param>
    /// <returns><see cref="OracleDbType"/></returns>
    private static OracleDbType GetOracleDbType(Type type)
    {
        if (type == typeof(string))
        {
            return OracleDbType.Varchar2;
        }

        if (type == typeof(DateTime))
        {
            return OracleDbType.Date;
        }

        if (type == typeof(long))
        {
            return OracleDbType.Int64;
        }

        if (type == typeof(int))
        {
            return OracleDbType.Int32;
        }

        if (type == typeof(short))
        {
            return OracleDbType.Int16;
        }

        if (type == typeof(sbyte))
        {
            return OracleDbType.Byte;
        }

        if (type == typeof(byte))
        {
            return OracleDbType.Int16;
        }

        if (type == typeof(decimal))
        {
            return OracleDbType.Decimal;
        }

        if (type == typeof(float))
        {
            return OracleDbType.Single;
        }

        if (type == typeof(double))
        {
            return OracleDbType.Double;
        }

        if (type == typeof(byte[]))
        {
            return OracleDbType.Blob;
        }

        return OracleDbType.Varchar2;
    }
}