using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace cs_WCF.Common {
    [DataContract]
    public class ApiResponse<T> {

        [DataMember]
        public bool Result = false;
        [DataMember]
        public T Data;
        [DataMember]
        public string Message = string.Empty;
    }
}