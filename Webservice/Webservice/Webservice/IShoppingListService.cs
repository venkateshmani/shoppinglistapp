using System.Runtime.Serialization;
using System.ServiceModel;
using Webservice.DataModel;

namespace Webservice
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IShoppingListService
    {
        [OperationContract]
        RequestResult CreateUser(User userDetails);
        [OperationContract]
        UserVerification IsUserExists(string userPhoneNumber);
    }   
   

   

    
}
