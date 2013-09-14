using System.Runtime.Serialization;
using System.ServiceModel;

namespace Webservice.DataModel
{
    [DataContract]
    public class RequestResult
    {
        [DataMember]
        public string Message
        { get; set; }
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