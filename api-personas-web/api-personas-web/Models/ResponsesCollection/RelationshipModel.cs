using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace api_personas_web.Models.ResponsesCollection
{
    [DataContract]
    public class RelationshipModel
    {
        [DataMember]
        public LinksModel Links { get; set; }
        [DataMember]
        public DataModel Data { get; set; }
    }
}
