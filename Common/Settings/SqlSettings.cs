using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ADFSTK.ExternalMFA.Common.Settings
{
    [DataContract]
    public class SqlSettings
    {
        [DataMember]
        public List<SqlSetting> Settings { get; set; }

    }
}
