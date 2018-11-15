﻿using System;
using System . Collections . Generic;
using System . Linq;
using System . Text;
using System . Configuration;
using System . Data . SqlClient;
using System . Data;
using System . Collections;
using Utility;

namespace StudentMgr
{
    public static class SqlHelper
    {
        public static readonly string connstr =
            ConfigurationManager.ConnectionStrings["connstr"].ConnectionString;
        
        /// <summary>
        /// 连接并打开数据库
        /// </summary>
        /// <returns></returns>
        public static SqlConnection OpenConnection( )
        {
            SqlConnection conn = new SqlConnection( connstr );
            conn.Open( );
            return conn;
        }
        /// <summary>
        /// 返回受影响的行数
        /// </summary>
        /// <param name="cmdText"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static int ExecuteNonQuery( string cmdText,
            params SqlParameter[] parameters )
        {
            using (SqlConnection conn = new SqlConnection( connstr ))
            {
                conn.Open( );
                return ExecuteNonQuery( conn, cmdText, parameters );
            }
        }

        /// <summary>
        /// 执行没有参数的SQL语句  返回受影响的行数
        /// </summary>
        /// <param name="cmdText"></param>
        /// <returns></returns>
        public static int ExecuteNonQuery ( string cmdText )
        {
            using ( SqlConnection conn = new SqlConnection( connstr ) )
            {
                conn.Open( );
                return ExecuteNonQuery( conn ,cmdText );
            }
        }

        public static object ExecuteScalar( string cmdText,
            params SqlParameter[] parameters )
        {
            using (SqlConnection conn = new SqlConnection( connstr ))
            {
                conn.Open( );
                return ExecuteScalar( conn, cmdText, parameters );
            }
        }
        /// <summary>
        /// 返回一个DataTable实例
        /// </summary>
        /// <param name="cmdText"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static DataTable ExecuteDataTable( string cmdText,
            params SqlParameter[] parameters )
        {
            using (SqlConnection conn = new SqlConnection( connstr ))
            {
                conn.Open( );
                return ExecuteDataTable( conn, cmdText, parameters );
            }
        }
        /// <summary>
        /// 返回一个DataSet
        /// </summary>
        /// <param name="SQLString"></param>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public static DataSet Query ( string SQLString ,params object[] parameter )
        {
            using ( SqlConnection conn = new SqlConnection( connstr ) )
            {
                conn.Open( );
                return ExecuteDataSet( conn ,SQLString ,parameter );
            }
        }

        public static int ExecuteNonQuery( SqlConnection conn, string cmdText,
           params SqlParameter[] parameters )
        {
            using (SqlCommand cmd = conn.CreateCommand( ))
            {
                cmd.CommandText = cmdText;
                cmd.Parameters.AddRange( parameters );
                try
                {
                    SaveLog ( cmdText ,parameters );
                }
                catch ( Exception ex )
                {
                    LogHelper . WriteLog ( ex . Message + "\n\r" + ex . Message );
                }
                return cmd.ExecuteNonQuery( );
            }
        }

        public static int ExecuteNonQuery ( SqlConnection conn ,string cmdText )
        {
            using ( SqlCommand cmd = conn.CreateCommand() )
            {
                cmd.CommandText = cmdText;
                try
                {
                    SaveLog ( cmdText ,string . Empty );
                }
                catch ( Exception ex )
                {
                    LogHelper . WriteLog ( ex . Message + "\n\r" + ex . Message );
                }
                return cmd.ExecuteNonQuery( );
            }
        }

        public static object ExecuteScalar( SqlConnection conn, string cmdText,
            params SqlParameter[] parameters )
        {
            using (SqlCommand cmd = conn.CreateCommand( ))
            {
                cmd.CommandText = cmdText;
                cmd.Parameters.AddRange( parameters );
                try
                {
                    SaveLog ( cmdText ,string . Empty );
                }
                catch ( Exception ex )
                {
                    LogHelper . WriteLog ( ex . Message + "\n\r" + ex . Message );
                }
                return cmd.ExecuteScalar( );
            }
        }

        public static DataTable ExecuteDataTable( SqlConnection conn, string cmdText,
            params SqlParameter[] parameters )
        {
            using (SqlCommand cmd = conn.CreateCommand( ))
            {
                cmd.CommandText = cmdText;
                cmd.Parameters.AddRange( parameters );
                try
                {
                    SaveLog ( cmdText ,string . Empty );
                }
                catch ( Exception ex )
                {
                    LogHelper . WriteLog ( ex . Message + "\n\r" + ex . Message );
                }
                using (SqlDataAdapter adapter = new SqlDataAdapter( cmd ))
                {
                    DataTable dt = new DataTable( );
                    adapter.Fill( dt );
                    return dt;
                }
            }
        }

        public static DataSet ExecuteDataSet ( SqlConnection conn ,string SQLString ,params object[] parameter )
        {
            using ( SqlCommand cmd = conn.CreateCommand( ) )
            {
                PrepareCommand( cmd ,conn ,null ,SQLString ,parameter );
                try
                {
                    SaveLog ( SQLString ,parameter );
                }
                catch ( Exception ex )
                {
                    LogHelper . WriteLog ( ex . Message + "\n\r" + ex . Message );
                }
                using ( SqlDataAdapter da = new SqlDataAdapter( cmd ) )
                {
                    DataSet ds = new DataSet( );
                    try
                    {
                        da.Fill( ds ,"ds" );
                        cmd.Parameters.Clear( );
                    }
                    catch (SqlException ex) { throw new Exception( ex.Message ); }
                    finally {
                        cmd.Dispose( );
                        conn.Close( );
                    }

                    return ds;
                }
            }
        }

        #region 执行存储过程

        private static string _proceName; //存储过程名

        private static void StoreProcedure ( string sprocName )
        {
            _proceName = sprocName;
        }

        /// <summary>
        /// 执行存储过程  不返回值
        /// </summary>
        /// <param name="sprocName">存储过程名</param>
        /// <param name="parameters">参数</param>
        public static void ExecuteNoStore (  params SqlParameter[] parameters )
        {
            using (SqlConnection conn=new SqlConnection(connstr) )
            {
                SqlCommand cmd = new SqlCommand( _proceName ,conn );
                cmd.CommandType = CommandType.StoredProcedure;
                AddInParaValues( cmd ,parameters );
                conn.Open( );
                cmd.ExecuteNonQuery( );
                conn.Close( );
            }
        }

        /// <summary>
        /// 执行存储过程  返回一个表
        /// </summary>
        /// <param name="sprocName">存储过程名称</param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static DataTable ExecuteDataTableToStore ( params SqlParameter[] parameters )
        {
            SqlCommand cmd = new SqlCommand( _proceName ,new SqlConnection( connstr ) );
            cmd.CommandType = CommandType.StoredProcedure;
            AddInParaValues( cmd ,parameters );
            SqlDataAdapter ada = new SqlDataAdapter( cmd );
            DataTable dt = new DataTable( );
            ada.Fill( dt );
            return dt;
        }

        /// <summary>
        /// 执行存储过程，返回SqlDataReader对象   在SqlDataReader对象关闭的同时，数据库连接自动关闭
        /// </summary>
        /// <param name="sprocName"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static SqlDataReader ExecuteDataReaderStore ( params SqlParameter[] parameters )
        {
            SqlConnection conn = new SqlConnection( connstr );
            SqlCommand cmd = new SqlCommand( _proceName ,conn );
            cmd.CommandType = CommandType.StoredProcedure;
            AddInParaValues( cmd ,parameters );
            conn.Open( );
            return cmd.ExecuteReader( CommandBehavior.CloseConnection );
        }

        /// <summary>
        /// 获取存储过程的参数列表
        /// </summary>
        /// <param name="sprocName"></param>
        /// <returns></returns>
        private static ArrayList GetParameters ( )
        {
            SqlCommand cmd = new SqlCommand( "dbo.sp_sproc_columns_90" ,new SqlConnection( connstr ) );
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue( "@procedure_name" ,_proceName );
            SqlDataAdapter sda = new SqlDataAdapter( cmd );
            DataTable dt = new DataTable( );
            sda.Fill( dt );
            ArrayList al = new ArrayList( );
            for ( int i = 0 ; i < dt.Rows.Count ; i++ )
            {
                al.Add( dt.Rows[i][3].ToString( ) );
            }
            return al;
        }

        /// <summary>
        /// 为 SqlCommand 添加参数及赋值
        /// </summary>
        /// <param name="cmd"></param>
        /// <param name="parameters"></param>
        private static void AddInParaValues ( SqlCommand cmd ,params SqlParameter[] parameters )
        {
            cmd.Parameters.Add( new SqlParameter( "@RESURN_VALUE" ,SqlDbType.Int ) );
            cmd.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;
            if ( parameters != null )
            {
                ArrayList al = GetParameters( );
                for ( int i = 0 ; i < parameters.Length ; i++ )
                {
                    cmd.Parameters.AddWithValue( al[i + 1].ToString( ) ,parameters[i] );
                }
            }
        }

        #endregion


        public static void PrepareCommand ( SqlCommand cmd ,SqlConnection conn ,SqlTransaction trans ,string cmdText ,object[] parameter )
        {
            if ( conn.State != ConnectionState.Open )
                conn.Open( );
            cmd.Connection = conn;
            cmd.CommandText = cmdText;
            if ( trans != null )
                cmd.Transaction = trans;
            cmd.CommandType = CommandType.Text;
            if ( parameter != null )
            {
                foreach ( SqlParameter para in parameter )
                {
                    if ( ( para.Direction == ParameterDirection.InputOutput  || para.Direction == ParameterDirection.Input ) && ( para.Value == null ) )
                    {
                        para.Value = DBNull.Value;
                    }
                    cmd.Parameters.Add( para );
                }
            }
        }

        /// <summary>
        /// 执行一条计算查询结果语句，返回查询结果（object）
        /// </summary>
        /// <param name="SQLSting">计算查询结果语句</param>
        /// <param name="parameter"></param>
        /// <returns>查询结果（object）</returns>
        public static object GetSingle ( string SQLSting ,params object[] parameter )
        {
            using ( SqlConnection conn = new SqlConnection( connstr ) )
            {
                using ( SqlCommand cmd = new SqlCommand( ) )
                {
                    try
                    {
                        PrepareCommand( cmd ,conn ,null ,SQLSting ,parameter );
                        cmd.CommandText = SQLSting;
                        try
                        {
                            SaveLog ( SQLSting ,parameter );
                        }
                        catch ( Exception ex )
                        {
                            LogHelper . WriteLog ( ex . Message + "\n\r" + ex . Message );
                        }
                        object obj = cmd.ExecuteScalar( );
                        if ( ( object.Equals( obj ,null ) ) || ( object.Equals( obj ,System.DBNull.Value ) ) )
                        {
                            return null;
                        }
                        else
                        {
                            return obj;
                        }
                    }
                    catch( SqlException e )
                    {
                        throw new Exception( e.Message );
                    }
                    finally {
                        cmd.Dispose( );
                        conn.Close( );
                    }
                }    
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public static bool Exists ( string sql ,params object[] parameter )
        {
            object result = GetSingle( sql ,parameter );
            if ( result == null )
                return false;
            long count = 0;
            long.TryParse( result.ToString( ) ,out count );
            return count > 0 ? true : false;
        }

        /// <summary>
        /// 执行SQL语句，返回自增列值
        /// </summary>
        /// <param name="SQLString"></param>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public static int ExecuteSqlReturnId ( string SQLString ,params object[] parameter )
        {
            using ( SqlConnection conn = new SqlConnection( connstr ) )
            {
                using ( SqlCommand cmd = new SqlCommand())
                {
                    try
                    {
                        PrepareCommand( cmd ,conn ,null ,SQLString ,parameter );
                        object obj = cmd.ExecuteScalar( );
                        try
                        {
                            SaveLog ( SQLString ,parameter );
                        }
                        catch ( Exception ex )
                        {
                            LogHelper . WriteLog ( ex . Message + "\n\r" + ex . Message );
                        }

                        cmd .Parameters.Clear( );
                        if ( obj == null )
                            return 0;
                        else
                            return Convert.ToInt32( obj );
                    }
                    catch (Exception E)
                    {
                        throw new Exception( E.Message );
                    }
                    finally {
                        cmd.Dispose( );
                        conn.Close( );
                    }
                }
            }
        }


        /// <summary>
        /// 执行多条SQL语句，实现数据库事务。
        /// </summary>
        /// <param name="SQLStringList"></param>
        public static bool ExecuteSqlTran ( ArrayList SQLStringList )
        {
            using (SqlConnection conn=new SqlConnection(connstr))
            {
                conn.Open( );
                SqlCommand cmd = new SqlCommand( );
                cmd.Connection = conn;
                SqlTransaction tran = conn.BeginTransaction( );
                cmd.Transaction = tran;
                try
                {
                    for ( int i = 0 ; i < SQLStringList.Count ; i++ )
                    {
                        string strsql = SQLStringList[i].ToString( );
                        if ( strsql.Trim( ).Length > 1)
                        {
                            cmd.CommandText = strsql;
                            cmd.ExecuteNonQuery( );
                            try
                            {
                                SaveLog ( strsql ,string . Empty );
                            }
                            catch ( Exception ex )
                            {
                                LogHelper . WriteLog ( ex . Message + "\n\r" + ex . Message );
                            }
                        }
                    }
                    tran.Commit( );
                    return true;
                }
                catch {
                    tran.Rollback( );
                    return false;
                }
                finally
                {
                    cmd.Dispose( );
                    conn.Close( );
                }
            }
        }

        public static object ToDBValue(this object value)
        {
            return value == null ? DBNull.Value : value;
        }

        public static object FromDBValue(this object dbValue)
        {
            return dbValue == DBNull.Value ? null : dbValue;
        }


        /// <summary>
        /// 写操作日志到数据库
        /// </summary>
        /// <param name="cmdText"></param>
        /// <param name="parameters"></param>
        //public static void SaveLog ( string cmdText ,string parameters )
        //{
        //    if ( cmdText . Contains ( "MOXLOG" ) )
        //        return;
        //    StringBuilder strSql = new StringBuilder ( );
        //    strSql . Append ( "INSERT INTO MOXLOG (" );
        //    strSql . Append ( "LOG001,LOG002) " );
        //    strSql . Append ( "VALUES (" );
        //    strSql . AppendFormat ( "'{0}','{1}') ",cmdText . Replace ( "'" ,"''" ) ,parameters  );

        //    SqlHelper . ExecuteNonQuery ( strSql . ToString ( ) );
        //}

        /// <summary>
        /// 写操作日志到数据库
        /// </summary>
        /// <param name="cmdText"></param>
        /// <param name="parameters"></param>
        public static void SaveLog ( string cmdText ,params SqlParameter [ ] parameters )
        {
            if ( cmdText . Contains ( "MOXLOG" ) )
                return;
            string param = string . Empty;
            if ( parameters!=null && parameters . Length > 0 )
            {
                for ( int i = 0 ; i < parameters . Length ; i++ )
                {
                    if ( param == string . Empty )
                        param = " [ " + parameters [ i ] . ToString ( ) + ":" + parameters [ i ] . Value + " ] ";
                    else
                        param = param + " [ " + parameters [ i ] . ToString ( ) + ":" + parameters [ i ] . Value + " ] ";
                }
            }

            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "INSERT INTO MOXLOG (" );
            strSql . Append ( "LOG001,LOG002) " );
            strSql . Append ( "VALUES (" );
            strSql . AppendFormat ( "'{0}','{1}') " ,cmdText . Replace ( "'" ,"''" ) ,param );

            SqlHelper . ExecuteNonQuery ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 写操作日志到数据库
        /// </summary>
        /// <param name="cmdText"></param>
        /// <param name="parameters"></param>
        public static void SaveLog ( string cmdText ,params object [ ] parameters )
        {
            SqlParameter [ ] parame = null;
            if ( parameters !=null)
                parame = ( SqlParameter [ ] ) parameters;

            if ( cmdText . Contains ( "MOXLOG" ) )
                return;
            string param = string . Empty;
            if ( parame!=null && parame . Length > 0 )
            {
                for ( int i = 0 ; i < parame . Length ; i++ )
                {
                    if ( param == string . Empty )
                        param = " [ " + parame [ i ] . ToString ( ) + ":" + parame [ i ] . Value + " ] ";
                    else
                        param = param + " [ " + parame [ i ] . ToString ( ) + ":" + parame [ i ] . Value + " ] ";
                }
            }

            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "INSERT INTO MOXLOG (" );
            strSql . Append ( "LOG001,LOG002) " );
            strSql . Append ( "VALUES (" );
            strSql . AppendFormat ( "'{0}','{1}') " ,cmdText . Replace ( "'" ,"''" ) ,param );

            SqlHelper . ExecuteNonQuery ( strSql . ToString ( ) );
        }

    }
}
