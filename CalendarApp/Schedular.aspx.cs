using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CalendarApp
{
    public partial class Schedular : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Calendar1_DayRender(object sender, DayRenderEventArgs e)
        {
            // restrict dates
            if (e.Day.IsWeekend)
            {
                e.Day.IsSelectable = false;
            }
            
            if(e.Day.Date.Day == 26 && e.Day.Date.Month == 8)
            {
                e.Day.IsSelectable = false;
                e.Cell.BackColor = System.Drawing.Color.Blue;
                e.Cell.ForeColor = System.Drawing.Color.White;

                // add static text to cell
                Label lbl = new Label();
                lbl.Text = "<br />My Birthday!";
                e.Cell.Controls.Add(lbl);
            }
        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            DropDownList1.Items.Clear();

            switch (Calendar1.SelectedDate.DayOfWeek)
            {
                case DayOfWeek.Monday:
                    //Apply special monday schedule
                    DropDownList1.Items.Add("10:00");
                    DropDownList1.Items.Add("10:30");
                    DropDownList1.Items.Add("11:00");
                    break;
                default:
                    DropDownList1.Items.Add("10:00");
                    DropDownList1.Items.Add("10:30");
                    DropDownList1.Items.Add("11:00");
                    DropDownList1.Items.Add("11:30");
                    DropDownList1.Items.Add("12:00");
                    DropDownList1.Items.Add("12:30");
                    break;
            }
        }

        protected void BtnSubmit_Click(object sender, EventArgs e)
        {
            LblResult.Text = $"Your selected Date: <br />{Calendar1.SelectedDate.ToLongDateString()}<br />Time: {DropDownList1.Text}";

            // make selected time and date unavailable for further scheduling
            // these entries are only temporarily removed as they are set to be
            // re added when you click on a date on the calendar for now.  This
            // is just more for practice
            DropDownList1.Items.Remove(DropDownList1.SelectedItem);
        }
    }
}