using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportBll.Bll
{
    public class FormOne
    {
        Dao.FormOne _dao = new Dao.FormOne( );

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable GetDataTable ( DateTime dtOne,DateTime dtTwo )
        {
            return _dao.GetDataTable( dtOne ,dtTwo );
        }

        /// <summary>
        /// 获取合计信息
        /// </summary>
        /// <param name="dtOne"></param>
        /// <param name="dtTwo"></param>
        /// <returns></returns>
        public DataTable GetDataTableOf ( DateTime dtOne ,DateTime dtTwo )
        {
            return _dao.GetDataTableOf( dtOne ,dtTwo );
        }
    }
}
