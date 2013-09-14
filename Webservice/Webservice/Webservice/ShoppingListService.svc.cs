using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using MySql.Data.MySqlClient;
using System.Data;

namespace Webservice
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    public class ShoppingListService : IShoppingListService
    {

        static MySqlConnection m_Connnection;
        public RequestResult CreateUser(UserProfile userDetails)
        {
            // Write sql query to check whether the user already exists
            // and update the user details in DB.

            if (m_Connnection == null)
                CreateConnection();
            try
            {
                m_Connnection.Open();
            }
            catch (Exception ex)
            {
                m_Connnection.Clone();
                return new RequestResult() { Result = Result.Failed, Message = "Sorry {0}!!! " + Environment.NewLine + "Unable to create your account as the server is down at this moment. Please try after sometime." }; 
            }
            MySqlCommand cmd = m_Connnection.CreateCommand();
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
               return new RequestResult() {Result= Result.Failed, Message = "Sorry {0}!!! "+ Environment.NewLine +"Unable to create your account."}; 
           }
           return new RequestResult() { Result = Result.Failed, Message = String.Format("Congratulations {0}!!!" + Environment.NewLine + "Successfully created your account.", userDetails.Name) }; 
        }


        public UserVerification IsUserExists(string userPhoneNumber)
        {
            if (m_Connnection == null)
                CreateConnection();

            MySqlCommand cmd = m_Connnection.CreateCommand();
            cmd.CommandText = "SELECT * FROM user where Phonenumber= ?userPhoneNumber";
            cmd.Parameters.AddWithValue("?userPhoneNumber", userPhoneNumber);            
            using (MySqlDataAdapter adap = new MySqlDataAdapter(cmd))
            {
                DataSet ds = new DataSet();
                adap.Fill(ds);
                if (ds.Tables[0].Rows.Count == 1)
                {
                    //User already exists
                }
                else
                { //new user}
                }
            }

         

            return null;
        }

        private void CreateConnection()
        {           
            string connectionString = "Server=192.168.1.102; Database=shoppinglistappdb; Uid=root; Pwd=password";
            m_Connnection = new MySqlConnection(connectionString);
            m_Connnection.Open();
        }
    }
}
