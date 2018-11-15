namespace LanDeQuery
{
    partial class TechnologyAll
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose ( bool disposing )
        {
            if ( disposing && ( components != null ) )
            {
                components.Dispose( );
            }
            base.Dispose( disposing );
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent ( )
        {
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.RAC002 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.RAC003 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.QBA002 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.QBA960 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.QBA961 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(659, 388);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.ColumnPanelRowHeight = 25;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.RAC002,
            this.RAC003,
            this.QBA002,
            this.QBA960,
            this.QBA961});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.RowHeight = 20;
            this.gridView1.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.RAC002, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.gridView1.DoubleClick += new System.EventHandler(this.gridView1_DoubleClick);
            // 
            // RAC002
            // 
            this.RAC002.AppearanceCell.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.RAC002.AppearanceCell.Options.UseFont = true;
            this.RAC002.AppearanceHeader.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.RAC002.AppearanceHeader.Options.UseFont = true;
            this.RAC002.AppearanceHeader.Options.UseTextOptions = true;
            this.RAC002.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.RAC002.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.RAC002.Caption = "工序";
            this.RAC002.FieldName = "RAC002";
            this.RAC002.Name = "RAC002";
            this.RAC002.Visible = true;
            this.RAC002.VisibleIndex = 0;
            // 
            // RAC003
            // 
            this.RAC003.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.RAC003.AppearanceCell.Options.UseFont = true;
            this.RAC003.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.RAC003.AppearanceHeader.Options.UseFont = true;
            this.RAC003.AppearanceHeader.Options.UseTextOptions = true;
            this.RAC003.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.RAC003.Caption = "工艺";
            this.RAC003.FieldName = "RAC003";
            this.RAC003.Name = "RAC003";
            this.RAC003.Visible = true;
            this.RAC003.VisibleIndex = 1;
            // 
            // QBA002
            // 
            this.QBA002.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.QBA002.AppearanceCell.Options.UseFont = true;
            this.QBA002.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.QBA002.AppearanceHeader.Options.UseFont = true;
            this.QBA002.AppearanceHeader.Options.UseTextOptions = true;
            this.QBA002.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.QBA002.Caption = "工艺名称";
            this.QBA002.FieldName = "QBA002";
            this.QBA002.Name = "QBA002";
            this.QBA002.Visible = true;
            this.QBA002.VisibleIndex = 2;
            // 
            // QBA960
            // 
            this.QBA960.AppearanceCell.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.QBA960.AppearanceCell.Options.UseFont = true;
            this.QBA960.AppearanceHeader.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.QBA960.AppearanceHeader.Options.UseFont = true;
            this.QBA960.AppearanceHeader.Options.UseTextOptions = true;
            this.QBA960.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.QBA960.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.QBA960.Caption = "投入单位";
            this.QBA960.FieldName = "QBA960";
            this.QBA960.Name = "QBA960";
            this.QBA960.Visible = true;
            this.QBA960.VisibleIndex = 3;
            // 
            // QBA961
            // 
            this.QBA961.AppearanceCell.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.QBA961.AppearanceCell.Options.UseFont = true;
            this.QBA961.AppearanceHeader.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.QBA961.AppearanceHeader.Options.UseFont = true;
            this.QBA961.AppearanceHeader.Options.UseTextOptions = true;
            this.QBA961.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.QBA961.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.QBA961.Caption = "产出单位";
            this.QBA961.FieldName = "QBA961";
            this.QBA961.Name = "QBA961";
            this.QBA961.Visible = true;
            this.QBA961.VisibleIndex = 4;
            // 
            // TechnologyAll
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(659, 388);
            this.Controls.Add(this.gridControl1);
            this.Name = "TechnologyAll";
            this.Text = "工艺查询";
            this.Load += new System.EventHandler(this.TechnologyAll_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn RAC003;
        private DevExpress.XtraGrid.Columns.GridColumn QBA002;
        private DevExpress.XtraGrid.Columns.GridColumn QBA960;
        private DevExpress.XtraGrid.Columns.GridColumn QBA961;
        private DevExpress.XtraGrid.Columns.GridColumn RAC002;
    }
}