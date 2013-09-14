using System;
using System.Data;
using MySql.Data.MySqlClient;
using Webservice.DataModel;

namespace Webservice
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    public class ShoppingListService : IShoppingListService
    {

        static MySqlConnection m_Connnection;
        public RequestResult CreateUser(User userDetails)
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
            cmd.Parameters.AddWithValue("@name", userDetails.UserName);
            cmd.Parameters.AddWithValue("@conCode",userDetails.CountryCode);
            cmd.Parameters.AddWithValue("@isPro", userDetails.IsProUser);
            cmd.Parameters.AddWithValue("@secQuesID",userDetails.SecurityQuestionID);
            cmd.Parameters.AddWithValue("@secQuesAns", userDetails.SecurityQuestionAnswer);
           try
           {
            cmd.ExecuteNonQuery();
           }
           catch (Exception ex)
           {
               return new RequestResult() {Result= Result.Failed, Message = "Sorry {0}!!! "+ Environment.NewLine +"Unable to create your account."}; 
           }
           return new RequestResult() { Result = Result.Failed, Message = String.Format("Congratulations {0}!!!" + Environment.NewLine + "Successfully created your account.", userDetails.UserName) }; 
        }


        public UserVerification IsUserExists(string userPhoneNumber)
        {
            if (m_Connnection == null)
                CreateConnection();

            MySqlCommand cmd = m_Connnection.CreateCommand();
            cmd.CommandText = "SELECT a.Phonenumber, a.UserName, b.Question FROM user a, securityquestion b " +
               "WHERE (a.Phonenumber = ?userPhoneNumber and a.SecurityQuestionID  = b.SecurityQuestionID)";                
            cmd.Parameters.AddWithValue("?userPhoneNumber", userPhoneNumber);            
            using (MySqlDataAdapter adap = new MySqlDataAdapter(cmd))
            {
                DataSet ds = new DataSet();
                adap.Fill(ds);
                if (ds.Tables[0].Rows.Count == 1)
                {
                    return new UserVerification() { AlreadyExists = true, PhoneNumber = userPhoneNumber, SecurityQuestion = ds.Tables[0].Rows[0]["Question"].ToString() };
                    //User already exists
                }
                else
                { //new user}
                    return new UserVerification() { AlreadyExists = false, PhoneNumber = userPhoneNumber, SecurityQuestion = ""};
                }
            }             
        }

        private void CreateConnection()
        {           
            string connectionString = "Server=192.168.1.102; Database=shoppinglistappdb; Uid=root; Pwd=password";
            m_Connnection = new MySqlConnection(connectionString);
            m_Connnection.Open();
        }
    }
}
