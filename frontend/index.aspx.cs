using System;
using System.Data;
using System.Drawing;
using System.Web.UI;
using System.Web.UI.WebControls;
using winedrops_coding_challenge.backend;

namespace winedrops_coding_challenge.frontend
{
    public partial class index : System.Web.UI.Page
    {
        private static DataSet _wineList;
        private static Label[] lblWine;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                _wineList = new model().getList('r');
                displayList();
            }
        }

        void displayList()
        {
            listViewer.Controls.Clear();
            lblWine = new Label[_wineList.Tables[0].Rows.Count];

            double top10percent = lblWine.Length * 0.1;
            double bottom10percent = lblWine.Length - top10percent;

            for (int i=0; i < lblWine.Length; i++)
            {
                lblWine[i] = new Label();
                lblWine[i].Text = _wineList.Tables[0].Rows[i]["position"].ToString() + ". " +
                                  _wineList.Tables[0].Rows[i]["name"].ToString() + " - " +
                                  _wineList.Tables[0].Rows[i]["amount"].ToString();
                lblWine[i].CssClass = "wine-label";

                if(i <= top10percent)
                {
                    lblWine[i].ForeColor = Color.LimeGreen;
                }
                else if(i > bottom10percent)
                {
                    lblWine[i].ForeColor = Color.Red;
                }

            }

            search();
        }

        void search()
        {
            listViewer.Controls.Clear();

            for(int i=0; i< lblWine.Length; i++)
            {
                string name = _wineList.Tables[0].Rows[i]["name"].ToString();
                string search = txtSearch.Text;

                if(txtSearch.Text == String.Empty)
                {
                    listViewer.Controls.Add(lblWine[i]);
                    
                }
                else if(name.IndexOf(search) > -1)
                {
                    listViewer.Controls.Add(lblWine[i]);
                }
            }
        }

        protected void btnRevenue_Click(object sender, EventArgs e)
        {
            setActiveTab(sender);
            _wineList = new model().getList('r');
            displayList();
        }

        protected void btnBottles_Click(object sender, EventArgs e)
        {
            setActiveTab(sender);
            _wineList = new model().getList('b');
            displayList();
        }

        protected void btnOrders_Click(object sender, EventArgs e)
        {
            setActiveTab(sender);
            _wineList = new model().getList('o');
            displayList();
        }

        void setActiveTab(object sender)
        {
            btnBottles.BackColor = Color.White;
            btnOrders.BackColor = Color.White;
            btnRevenue.BackColor = Color.White;

            ((Button)sender).BackColor = ColorTranslator.FromHtml("#ebebeb");
        }

        protected void txtSearch_TextChanged(object sender, EventArgs e)
        {
            search();
        }
    }
}