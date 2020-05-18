using RegistrationSQLServer.BusinessLayer;
using RegistrationSQLServer.DBLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RegistrationSQLServer
{
    public partial class EditUserInformationById : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack)
                return;
            int userId = default;
            if (!string.IsNullOrEmpty(Request.QueryString["id"]))
            {
                userId = int.Parse(Request.QueryString["id"]);
            }

            UserInformation userInformation = new UserInformation();
            userInformation = DBUtilities.SelectUserInformationById(userId);
            firstNameTextBox.Text = userInformation.FirstName;
            lastNameTextBox.Text = userInformation.LastName;
            addressTextBox.Text = userInformation.Address;
            cityTextBox.Text = userInformation.City;
            stateOrProvinceTextBox.Text = userInformation.Province;
            zipCodeTextBox.Text = userInformation.PostalCode;
            countryTextBox.Text = userInformation.Country;
        }

        protected void UpdateInfoButton_OnClick(object sender, EventArgs e)
        {
            UserInformation userInfo = new BusinessLayer.UserInformation();

            userInfo.FirstName = Server.HtmlEncode(firstNameTextBox.Text);
            userInfo.LastName = Server.HtmlEncode(lastNameTextBox.Text);
            userInfo.Address = Server.HtmlEncode(addressTextBox.Text);
            userInfo.City = Server.HtmlEncode(cityTextBox.Text);
            userInfo.Province = Server.HtmlEncode(stateOrProvinceTextBox.Text);
            userInfo.PostalCode = Server.HtmlEncode(zipCodeTextBox.Text);
            userInfo.Country = Server.HtmlEncode(countryTextBox.Text);

            if (DBLayer.DBUtilities.UpdateUserInformationById(1, userInfo) == 1)
                this.lblResultMessage.Text = "The User Information was successfully updated into db table";
            else
                this.lblResultMessage.Text = "There was an error on updating the user information!!!!!!";
        }

        protected void registrationButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Registration.aspx");
        }
    }
}