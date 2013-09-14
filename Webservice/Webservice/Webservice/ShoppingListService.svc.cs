using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using MySql.Data.MySqlClient;

namespace Webservice
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    public class ShoppingListService : IShoppingListService
    {  
        public bool CreateUser(UserProfile userDetails)
        {
            // Write sql query to check whether the user already exists
            // and update the user details in DB.
            string connectionString = "Server=192.168.1.102; Database=shoppinglistappdb; Uid=root; Pwd=password";
            MySqlConnection con = new MySqlConnection(connectionString);
            try
            {
                con.Open();
            }
            catch (Exception ex)
            { 

            }
            MySqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "INSERT INTO user(Phonenumber,UserName,CountryCode,IsProUser,SecurityQuestionID,SecurityQuestionAnswer)" +
                              "VALUES(@phoneNumber,@name,@conCode,@isPro,@secQuesID,@secQuesAns)";
            cmd.Parameters.AddWithValue("@phoneNumber", userDetails.PhoneNumber);
            cmd.Parameters.AddWithValue("@name", userDetails.Name);
            cmd.Parameters.AddWithValue("@conCode",userDetails.CountryCode);
            cmd.Parameters.AddWithValue("@isPro", userDetails.IsPro);
            cmd.Parameters.AddWithValue("@secQuesID",userDetails.SecurityQuestionID);
            cmd.Parameters.AddWithValue("@secQuesAns", userDetails.SecurityAnswer);
           try
           {
            cmd.ExecuteNonQuery();
           }
           catch (Exception ex)
           {

           }
            return true;
        }
    }
}
