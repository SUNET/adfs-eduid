using System.Runtime.Serialization;

namespace ADFSTK.ExternalMFA.Common.Settings
{
    public class SqlSetting
    {
        [DataMember]
        public string ConnectionString { get; set; }
        [DataMember]
        public string Command { get; set; }
    }
}
