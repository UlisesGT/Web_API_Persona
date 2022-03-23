using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace api_personas_web.Models.ResponsesCollection
{
    [DataContract]
    public class CollectionModel
    {
        [DataMember]
        public int Code { get; set; }
        [DataMember]
        public string Message { get; set; }
        [DataMember]
        public object Object { get; set; }
    }
}
