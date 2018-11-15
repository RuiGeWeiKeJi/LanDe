using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanDeBll.Bll
{
    public class LanDeOrderBll
    {
        Dao.LanDeOrderDao _dao = new Dao.LanDeOrderDao( );
        /// <summary>
        /// 是否存在一条记录
        /// </summary>
        /// <param name="idx"></param>
        /// <returns></returns>
        public bool Exists ( LanDeLibrary.LanDeOrderEntity _model )
        {
            return _dao.Exists( _model );
        }
        /// <summary>
        /// 是否存在记录
        /// </summary>
        /// <param name="_model"></param>
        /// <returns></returns>
        public bool Esits ( LanDeLibrary.LanDeOrderEntity _model )
        {
            return _dao.Esits( _model );
        }

        /// <summary>
        /// 是否存在上一工序
        /// </summary>
        /// <param name="odd"></param>
        /// <param name="workProcude"></param>
        /// <returns></returns>
        public bool ExistsPrevious ( string odd ,string workProcude )
        {
            return _dao.ExistsPrevious( odd ,workProcude );
        }

        /// <summary>
        /// 同工单单号  同工序
        /// </summary>
        /// <param name="oddNum"></param>
        /// <param name="gx"></param>
        /// <returns></returns>
        public bool Exists ( string oddNum ,string gx )
        {
            return _dao.Exists( oddNum ,gx );
        }

        /// <summary>
        /// 编辑一条记录
        /// </summary>
        /// <param name="_model"></param>
        /// <returns></returns>
        public bool UpdateTrans ( LanDeLibrary.LanDeOrderEntity _model )
        {
            return _dao.UpdateTrans( _model );
        }

        /// <summary>
        /// 录入一条记录
        /// </summary>
        /// <param name="_model"></param>
        /// <returns></returns>
        public bool InsertTran ( LanDeLibrary.LanDeOrderEntity _model )
        {
            return _dao.InsertTran( _model );
        }

        /// <summary>
        /// 是否存在上一道工序
        /// </summary>
        /// <param name="odd"></param>
        /// <param name="workProduce"></param>
        /// <returns></returns>
        public bool DeleteExists ( string odd ,string workProduce )
        {
            return _dao.DeleteExists( odd ,workProduce );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable GetDataTable ( string strWhere )
        {
            return _dao.GetDataTable( strWhere );
        }
        public DataTable GetDataTables ( string strWhere )
        {
            return _dao.GetDataTables( strWhere );
        }
        public DataTable GetDataTableBuild ( string strWhere )
        {
            return _dao.GetDataTableBuild( strWhere );
        }


        /// <summary>
        /// 获取人员信息
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTablePeople ( )
        {
            return _dao.GetDataTablePeople( );
        }

        /// <summary>
        /// 获取工序信息
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableTeah (string strWhere )
        {
            return _dao.GetDataTableTeah( strWhere );
        }

        /// <summary>
        /// 获取工单单号
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableWorkOrder ( )
        {
            return _dao.GetDataTableWorkOrder( );
        }
        public DataTable GetDataTableWorkOrderOne ( )
        {
            return _dao.GetDataTableWorkOrderOne( );
        }

        /// <summary>
        /// 生成报工单号
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableOddNum ( )
        {
            return _dao.GetDataTableOddNum( );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="idx"></param>
        /// <returns></returns>
        public LanDeLibrary.LanDeOrderEntity GetModel ( int idx )
        {
            return _dao.GetModel( idx );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableBatch ( )
        {
            return _dao.GetDataTableBatch( );
        }

        /// <summary>
        /// 获取上工序产出数量
        /// </summary>
        /// <param name="workProduce"></param>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public DataTable GetDataTableOfPrevious ( string workProduce ,string oddNum )
        {
            return _dao.GetDataTableOfPrevious( workProduce ,oddNum );
        }

        /// <summary>
        /// 获取上工序的操作工
        /// </summary>
        public DataTable GetDataTableOfPrevious ( string oddNum )
        {
            return _dao.GetDataTableOfPrevious( oddNum );
        }

        /// <summary>
        /// 是否是最后一道工序
        /// </summary>
        /// <param name="odd"></param>
        /// <param name="gx"></param>
        /// <returns></returns>
        public bool ExistsOfMax ( string odd ,string gx )
        {
            return _dao.ExistsOfMax( odd ,gx );
        }

        /// <summary>
        /// 获取服务器时间
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableGetDate ( )
        {
            return _dao.GetDataTableGetDate( );
        }

        /// <summary>
        /// 获取工序信息
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableTeahs ( string rac001 )
        {
            return _dao.GetDataTableTeahs( rac001 );
        }

        /// <summary>
        /// 查看工单单号是否有多余T，有则改
        /// </summary>
        /// <param name="bgd006"></param>
        public void findAndEidt ( string bgd006 )
        {
            _dao . findAndEidt ( bgd006 );
        }

    }
}
