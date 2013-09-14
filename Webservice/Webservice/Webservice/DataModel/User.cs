using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace Webservice.DataModel
{
    [DataContract]
    public class User
    {
        [DataMember]
        public string PhoneNumber { get; set; }

        [DataMember]
        public string UserName { get; set; }

        [DataMember]
        public short CountryCode { get; set; }

        [DataMember]
        public bool IsProUser { get; set; }

        [DataMember]
        public short SecurityQuestionID { get; set; }

        [DataMember]
        public string SecurityQuestionAnswer { get; set; }
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
}