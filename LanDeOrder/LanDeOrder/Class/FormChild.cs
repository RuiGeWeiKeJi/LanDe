using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Mulaolao.Class
{
    public partial class FormChild : Form
    {
        public FormChild( )
        {
            InitializeComponent( );
        }


        protected virtual void save( )
        {

        }
        protected virtual void select( )
        {
            
        }
        protected virtual void add( )
        {
        }
        protected virtual void delete( )
        {
        }
        protected virtual void update()
        {
        }
        protected virtual void cancel( )
        {
        }

        private void toolSave_Click( object sender, EventArgs e )
        {
            save( );               
        }
        private void toolSelect_Click( object sender, EventArgs e )
        {
            select( );

        }
        private void toolAdd_Click( object sender, EventArgs e )
        {
            add( );
            
        }
        private void toolDelete_Click( object sender, EventArgs e )
        {
            delete( );
        }
        private void toolUpdate_Click( object sender, EventArgs e )
        {
            update( );
        }      
        private void toolCancel_Click( object sender, EventArgs e )
        {
            cancel( );          
        }


        private void FormChild_Load( object sender, EventArgs e )
        {
            
        }
    }
}
