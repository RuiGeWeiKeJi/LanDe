using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentMgr;
using System.Data.SqlClient;

namespace ReportBll.Dao
{
    public class FormOne
    {
        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable GetDataTable (DateTime dtOne,DateTime dtTwo )
        {
            StringBuilder strSql = new StringBuilder( );
            //strSql.Append( "WITH CFT AS (" );
            strSql.Append( "SELECT BGD032,A.BGD006,A.BGD008,ISNULL(A.BGD010,0) BZ,ISNULL(B.BGD018,0) GK,ISNULL(C.BGD010,0) NP,CONVERT(DECIMAL(11,2),CASE WHEN B.BGD018=0 OR B.BGD018 IS NULL THEN 0 ELSE A.BGD010*1.0/B.BGD018 END) CP,CONVERT(DECIMAL(11,2),CASE WHEN C.BGD010=0 OR C.BGD010 IS NULL THEN 0 ELSE A.BGD010*1.0/C.BGD010 END) CL FROM" );
            strSql.Append( " (SELECT BGD032,BGD006,BGD005,BGD008,BGD004,BGD010 FROM SGMBGD WHERE BGD005='包装' AND BGD008 IS NOT NULL " );
            strSql.Append( " AND BGD034 BETWEEN @BG AND @GD" );
            strSql.Append( ") A " );
            strSql.Append( "  LEFT JOIN (" );
            strSql.Append( " SELECT BGD006,BGD005,BGD018 FROM SGMBGD WHERE BGD006 IN (SELECT BGD006 FROM SGMBGD WHERE BGD005='包装' AND BGD008 IS NOT NULL) AND BGD005='光刻'" );
            strSql.Append( "  ) B ON A.BGD006=B.BGD006 LEFT JOIN (" );
            strSql.Append( " SELECT BGD006,BGD005,BGD010 FROM SGMBGD WHERE BGD006 IN (SELECT BGD006 FROM SGMBGD WHERE BGD005='包装' AND BGD008 IS NOT NULL) AND BGD005='粘片'" );
            strSql.Append( "  ) C ON A.BGD006=C.BGD006" );
            strSql.Append( "  LEFT JOIN SGMRAC D ON A.BGD004=D.RAC003 AND A.BGD006=D.RAC001 RIGHT JOIN SGMRAA E ON D.RAC001=E.RAA001 WHERE RAA020='Y'" );
            strSql.Append( " AND RAC003 IN ( '02','05','16') AND A.BGD006 IS NOT NULL" );
            //strSql.Append( " ),CET AS(" );
            //strSql.Append( "SELECT A.BGD008,CONVERT(DECIMAL(11,2),SUM(A.BGD010*1.0)/SUM(B.BGD010)) CP,CONVERT(DECIMAL(11,2),SUM(A.BGD010*1.0)/SUM(C.BGD010)) CL  FROM" );
            //strSql.Append( " (SELECT BGD032,BGD006,BGD005,BGD008,BGD004,BGD010 FROM SGMBGD WHERE BGD005='包装' AND BGD008 IS NOT NULL " );
            //strSql.Append( " AND BGD034 BETWEEN @BG AND @GD" );
            //strSql.Append( ") A " );
            //strSql.Append( "  LEFT JOIN (" );
            //strSql.Append( " SELECT BGD006,BGD005,BGD010 FROM SGMBGD WHERE BGD006 IN (SELECT BGD006 FROM SGMBGD WHERE BGD005='包装' AND BGD008 IS NOT NULL) AND BGD005='光刻'" );
            //strSql.Append( "  ) B ON A.BGD006=B.BGD006 LEFT JOIN (" );
            //strSql.Append( " SELECT BGD006,BGD005,BGD010 FROM SGMBGD WHERE BGD006 IN (SELECT BGD006 FROM SGMBGD WHERE BGD005='包装' AND BGD008 IS NOT NULL) AND BGD005='粘片'" );
            //strSql.Append( "  ) C ON A.BGD006=C.BGD006" );
            //strSql.Append( "  LEFT JOIN SGMRAC D ON A.BGD004=D.RAC003 AND A.BGD006=D.RAC001 RIGHT JOIN SGMRAA E ON D.RAC001=E.RAA001 WHERE RAA020='Y'" );
            //strSql.Append( " AND RAC003 IN ( '02','05','16') AND A.BGD006 IS NOT NULL GROUP BY A.BGD008)" );
            //strSql.Append( " SELECT A.*,B.CP,B.CL FROM CFT A LEFT JOIN CET B ON A.BGD008=B.BGD008 ORDER BY A.BGD008" );
            SqlParameter[] parameter = {
                new SqlParameter("@BG",SqlDbType.Date),
                new SqlParameter("@GD",SqlDbType.Date)
            };
            parameter[0].Value = dtOne;
            parameter[1].Value = dtTwo;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }

        /// <summary>
        /// 获取合计信息
        /// </summary>
        /// <param name="dtOne"></param>
        /// <param name="dtTwo"></param>
        /// <returns></returns>
        public DataTable GetDataTableOf ( DateTime dtOne ,DateTime dtTwo )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT CONVERT(DECIMAL(11,2),SUM(A.BGD010*1.0)/SUM(B.BGD010)) CP,CONVERT(DECIMAL(11,2),SUM(A.BGD010*1.0)/SUM(C.BGD010)) CL FROM" );
            strSql.Append( " (SELECT BGD032,BGD006,BGD005,BGD008,BGD004,BGD010 FROM SGMBGD WHERE BGD005='包装' AND BGD008 IS NOT NULL " );
            strSql.Append( " AND BGD034 BETWEEN @BG AND @GD" );
            strSql.Append( ") A " );
            strSql.Append( "  LEFT JOIN (" );
            strSql.Append( " SELECT BGD006,BGD005,BGD010 FROM SGMBGD WHERE BGD006 IN (SELECT BGD006 FROM SGMBGD WHERE BGD005='包装' AND BGD008 IS NOT NULL) AND BGD005='光刻'" );
            strSql.Append( "  ) B ON A.BGD006=B.BGD006 LEFT JOIN (" );
            strSql.Append( " SELECT BGD006,BGD005,BGD010 FROM SGMBGD WHERE BGD006 IN (SELECT BGD006 FROM SGMBGD WHERE BGD005='包装' AND BGD008 IS NOT NULL) AND BGD005='粘片'" );
            strSql.Append( "  ) C ON A.BGD006=C.BGD006" );
            strSql.Append( "  LEFT JOIN SGMRAC D ON A.BGD004=D.RAC003 AND A.BGD006=D.RAC001 RIGHT JOIN SGMRAA E ON D.RAC001=E.RAA001 WHERE RAA020='Y'" );
            strSql.Append( " AND RAC003 IN ( '02','05','16') AND A.BGD006 IS NOT NULL" );
            SqlParameter[] parameter = {
                new SqlParameter("@BG",SqlDbType.Date),
                new SqlParameter("@GD",SqlDbType.Date)
            };
            parameter[0].Value = dtOne;
            parameter[1].Value = dtTwo;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }
    }
}
