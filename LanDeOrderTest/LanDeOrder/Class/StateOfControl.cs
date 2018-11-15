using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LanDeOrder.Class
{
    public class StateOfControl
    {
        public static void SpliEnableFalse ( SplitContainer split )
        {
            foreach ( Control conSpli in split.Controls )
            {
                if ( conSpli.GetType( ) == typeof( SplitterPanel ) )
                {
                    SplitterPanel spli = conSpli as SplitterPanel;
                    foreach ( Control sp in spli.Controls )
                    {
                        if ( sp.GetType( ) == typeof( TextBox ) )
                        {
                            TextBox box = sp as TextBox;
                            box.Enabled = false;
                            continue;
                        }
                        if ( sp.GetType( ) == typeof( ComboBox ) )
                        {
                            ComboBox box = sp as ComboBox;
                            box.Enabled = false;
                            continue;
                        }
                        if ( sp.GetType( ) == typeof( DateTimePicker ) )
                        {
                            DateTimePicker date = sp as DateTimePicker;
                            date.Enabled = false;
                            continue;
                        }
                        if ( sp.GetType( ) == typeof( Button ) )
                        {
                            Button btn = sp as Button;
                            btn.Enabled = false;
                            continue;
                        }
                        if ( sp.GetType( ) == typeof( DevExpress.XtraEditors.LookUpEdit ) )
                        {
                            DevExpress.XtraEditors.LookUpEdit btn = sp as DevExpress.XtraEditors.LookUpEdit;
                            btn.Enabled = false;
                            continue;
                        }
                        if ( sp.GetType( ) == typeof( GroupBox ) )
                        {
                            GroupBox box = sp as GroupBox;
                            foreach ( Control boxCon in box.Controls )
                            {
                                if ( boxCon.GetType( ) == typeof( TextBox ) )
                                {
                                    TextBox text = boxCon as TextBox;
                                    text.Enabled = false;
                                    continue;
                                }
                                if ( boxCon.GetType( ) == typeof( ComboBox ) )
                                {
                                    ComboBox text = boxCon as ComboBox;
                                    text.Enabled = false;
                                    continue;
                                }
                            }
                        }
                    }
                }
            }
        }
        public static void SpliEnableTrue ( SplitContainer split )
        {
            foreach ( Control conSpli in split.Controls )
            {
                if ( conSpli.GetType( ) == typeof( SplitterPanel ) )
                {
                    SplitterPanel spli = conSpli as SplitterPanel;
                    foreach ( Control sp in spli.Controls )
                    {
                        if ( sp.GetType( ) == typeof( TextBox ) )
                        {
                            TextBox box = sp as TextBox;
                            box.Enabled = true;
                            continue;
                        }
                        if ( sp.GetType( ) == typeof( ComboBox ) )
                        {
                            ComboBox box = sp as ComboBox;
                            box.Enabled = true;
                            continue;
                        }
                        if ( sp.GetType( ) == typeof( DateTimePicker ) )
                        {
                            DateTimePicker date = sp as DateTimePicker;
                            date.Enabled = true;
                            continue;
                        }
                        if ( sp.GetType( ) == typeof( Button ) )
                        {
                            Button btn = sp as Button;
                            btn.Enabled = true;
                            continue;
                        }
                        if ( sp.GetType( ) == typeof( DevExpress.XtraEditors.LookUpEdit ) )
                        {
                            DevExpress.XtraEditors.LookUpEdit btn = sp as DevExpress.XtraEditors.LookUpEdit;
                            btn.Enabled = true;
                            continue;
                        }
                        if ( sp.GetType( ) == typeof( GroupBox ) )
                        {
                            GroupBox box = sp as GroupBox;
                            foreach ( Control boxCon in box.Controls )
                            {
                                if ( boxCon.GetType( ) == typeof( TextBox ) )
                                {
                                    TextBox text = boxCon as TextBox;
                                    text.Enabled = true;
                                    continue;
                                }
                                if ( boxCon.GetType( ) == typeof( ComboBox ) )
                                {
                                    ComboBox text = boxCon as ComboBox;
                                    text.Enabled = true;
                                    continue;
                                }
                            }
                        }
                    }
                }
            }
        }
        public static void SpliClear ( SplitContainer split )
        {
            foreach ( Control conSpli in split.Controls )
            {
                if ( conSpli.GetType( ) == typeof( SplitterPanel ) )
                {
                    SplitterPanel spli = conSpli as SplitterPanel;
                    foreach ( Control sp in spli.Controls )
                    {
                        if ( sp.GetType( ) == typeof( TextBox ) )
                        {
                            TextBox box = sp as TextBox;
                            box.Text = "";
                            continue;
                        }
                        if ( sp.GetType( ) == typeof( ComboBox ) )
                        {
                            ComboBox box = sp as ComboBox;
                            box.Text = "";
                            continue;
                        }
                        if ( sp.GetType( ) == typeof( DevExpress.XtraEditors.LookUpEdit ) )
                        {
                            DevExpress.XtraEditors.LookUpEdit btn = sp as DevExpress.XtraEditors.LookUpEdit;
                            btn.EditValue = null;
                            btn.ItemIndex = -1;
                            continue;
                        }
                        if ( sp.GetType( ) == typeof( GroupBox ) )
                        {
                            GroupBox box = sp as GroupBox;
                            foreach ( Control boxCon in box.Controls )
                            {
                                if ( boxCon.GetType( ) == typeof( TextBox ) )
                                {
                                    TextBox text = boxCon as TextBox;
                                    text.Text = "";
                                    continue;
                                }
                                if ( boxCon.GetType( ) == typeof( ComboBox ) )
                                {
                                    ComboBox text = boxCon as ComboBox;
                                    text.Text = "";
                                    continue;
                                }
                                if ( boxCon.GetType( ) == typeof( DevExpress.XtraEditors.LookUpEdit ) )
                                {
                                    DevExpress.XtraEditors.LookUpEdit btn = boxCon as DevExpress.XtraEditors.LookUpEdit;
                                    btn.EditValue = null;
                                    btn.ItemIndex = -1;
                                    continue;
                                }
                            }
                        }
                        if ( sp.GetType( ) == typeof( TableLayoutPanel ) )
                        {
                            TableLayoutPanel tab = sp as TableLayoutPanel;
                            foreach ( Control tabCon in tab.Controls )
                            {
                                if ( tabCon.GetType( ) == typeof( TextBox ) )
                                {
                                    TextBox box = tabCon as TextBox;
                                    box.Text = "";
                                    continue;
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
