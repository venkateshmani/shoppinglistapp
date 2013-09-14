using System.Runtime.Serialization;
using System.ServiceModel;

namespace Webservice
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IShoppingListService
    {
        [OperationContract]
        RequestResult CreateUser(UserProfile userDetails);
        [OperationContract]
        UserVerification IsUserExists(string userPhoneNumber);
    }
    
    [DataContract]
    public class UserProfile
    {  
        [DataMember]
        public string PhoneNumber
        {
            get;
            set;
        } 
        [DataMember]
        public string Name
        {
            get; 
            set;
        }               
        [DataMember]
        public short SecurityQuestionID
        {
            get;
            set;
        }
        [DataMember]
        public string SecurityAnswer
        {
            get;
            set;
        }
        [DataMember]
        public bool IsPro
        {
            get;
            set;
        }
        [DataMember]
        public short CountryCode
        {
            get;
            set;
        }
    }

    [DataContract]
    public class UserVerification
    {
        [DataMember]
        public bool AlreadyExists
        {
            get;
            set;
        }        
        [DataMember]
        public string SecurityQuestion
        {
            get;
            set;        
        }
        [DataMember]
        public string PhoneNumber
        {
            get;
            set;
        }
        [DataMember]
        public RequestResult RequestResult
        {
            get;
            set;
        }
    }    

    [DataContract]
    public class RequestResult
    {
        [DataMember]
        public string Message
        { get;  set; }
        [DataMember]
        public Result Result
        { get; set; }
    }
    [DataContract]
    public enum Result
    {
        [EnumMember]
        Success,
        [EnumMember]
        Failed,
        [EnumMember]
        UserAlreadyExists,
        [EnumMember]
        AuthenticationFailed,
        [EnumMember]
        NotProUser,
        [EnumMember]
        DataNotFound
    }
}
