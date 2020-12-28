using System;
using IBatisNet.DataMapper;
using IBatisNet.DataMapper.SessionStore;
using IBatisNet.DataMapper.Configuration;
using IBatisNet.Common.Utilities;
using System.Xml;
using System.Text.RegularExpressions;

namespace cs_WCF.Config {
    class Properties {
        public static ISqlMapper EntityMapper {
            get {
                try
                {
                    ISqlMapper mapper = Mapper.Instance();
                    //mapper.DataSource.ConnectionString = "User Id=emt;Password=emt;Data Source=(DESCRIPTION=(ADDRESS_LIST= (ADDRESS=(PROTOCOL=TCP) (HOST=127.0.0.1) (PORT=1521))) (CONNECT_DATA = (SERVICE_NAME = xe)))";
                    //mapper.SessionStore = new HybridWebThreadSessionStore(mapper.Id);
                    return mapper;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
    }
}