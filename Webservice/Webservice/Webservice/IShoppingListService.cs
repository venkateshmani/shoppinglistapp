using System.Runtime.Serialization;
using System.ServiceModel;

namespace Webservice
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IShoppingListService
    {
        [OperationContract]
        bool CreateUser(UserProfile userDetails);        
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


}
