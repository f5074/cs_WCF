using IBatisNet.DataMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace cs_WCF.Common {
    public class DefaultConnection {
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