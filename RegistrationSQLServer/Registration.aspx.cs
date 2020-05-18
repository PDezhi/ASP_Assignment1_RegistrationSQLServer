using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RegistrationSQLServer
{
    public partial class Registration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void EnterInfoButton_OnClick(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                //send the user info to the database
                BusinessLayer.UserInformation userInfo = new BusinessLayer.UserInformation();

                userInfo.FirstName = Server.HtmlEncode(firstNameTextBox.Text);
                userInfo.LastName = Server.HtmlEncode(lastNameTextBox.Text);
                userInfo.Address = Server.HtmlEncode(addressTextBox.Text);
                userInfo.City = Server.HtmlEncode(cityTextBox.Text);
                userInfo.Province = Server.HtmlEncode(stateOrProvinceTextBox.Text);
                userInfo.PostalCode = Server.HtmlEncode(zipCodeTextBox.Text);
                userInfo.Country = Server.HtmlEncode(countryTextBox.Text);
                int id = default;
                if (int.TryParse(DBLayer.DBUtilities.InsertUserInformation(userInfo).ToString(), out id))
                {
                    idTextBox.Text = id.ToString();
                    this.lblResultMessage.Text = "The User Information was successfully inserted into db table";
                }
                else
                    this.lblResultMessage.Text = "There was an error on inserting the user information!!!!!!";
            }
        }

        protected void EditUserButton_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(idTextBox.Text.Trim()))
            {
                Response.Redirect("~/EditUserInformationById.aspx?id=" + idTextBox.Text.Trim());
            }

        }
    }
}