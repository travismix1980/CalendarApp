using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CalendarApp
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            LblResult1.Text = Calendar1.SelectedDate.ToShortDateString();
        }

        protected void BtnGet_Click(object sender, EventArgs e)
        {
            LblResult1.Text = Calendar1.SelectedDate.ToLongDateString();
        }

        protected void BtnSet_Click(object sender, EventArgs e)
        {
            Calendar1.SelectedDate = DateTime.Parse("6/4/2023");
            Calendar1.VisibleDate = Calendar1.SelectedDate;
        }

        protected void BtnDifference_Click(object sender, EventArgs e)
        {
            if(Calendar1.SelectedDate > Calendar2.SelectedDate)
            {
                LblResult2.Text = Calendar1.SelectedDate.Subtract(Calendar2.SelectedDate).TotalDays.ToString();
            } 
            else
            {
                LblResult2.Text = Calendar2.SelectedDate.Subtract(Calendar1.SelectedDate).TotalDays.ToString();
            }
        }
    }
}