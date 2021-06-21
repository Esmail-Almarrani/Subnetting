using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SubnettingTool
{
    public partial class MainForm : Form
    {
        List<Label> ReqirdList = new List<Label>();
        public MainForm()
        {
            InitializeComponent();
        }

        private void ClosePanel_Paint(object sender, PaintEventArgs e)
        {
        }

        private void ClosePanel_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            var lebel = new Label() { Text = HostNeededFild.Text, };
            ReqirdList.Add(lebel);
            RequairmentStack.Controls.Add(lebel);
            HostNeededFild.ResetText();
    }

        private void ResetBtn_Click(object sender, EventArgs e)
        {
            foreach(Label Item in ReqirdList )
            {
                RequairmentStack.Controls.Remove(Item);
                //ReqirdList.Remove(Item);
            }
            ReqirdList.Clear();
        }

        private void ApplyBtn_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("");
            if(AddressField.Text!=""&&PerfixLengthField.Text!="")
            {
                //MessageBox.Show("Q");
                if (ReqirdList.Count>0)
                {
                    //MessageBox.Show("Q2");
                    List<int> list = new List<int>();
                    foreach(Label Item in ReqirdList)
                    {
                        list.Add(int.Parse(Item.Text));
                    }
                    List<NetworksReport> NList = new List<NetworksReport>();
                    foreach(Address Item in Subnetting.NetworkBasedOnHostNeeded(AddressField.Text,int.Parse(PerfixLengthField.Text), list))
                    {
                        NList.Add(new NetworksReport(Item));
                    }
                    //MessageBox.Show(NList.Count.ToString());
                    dataGridView.DataSource = NList;
                    
                }
            }
        }
    }
}
