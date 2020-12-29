using cs_WCF.Common;
using IBatisNet.DataMapper;
using System;
using System.Collections;
using System.Collections.Generic;

namespace cs_WCF.Services.Common {
    public class CommonDAO {
        private static ISqlMapper mapper = DBConnection.EntityMapper;

        /// <summary>
        /// SelectDeptList
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static IList<Hashtable> SelectDeptList(Dictionary<string, object> parameters)
        {
            return mapper.QueryForList<Hashtable>("SelectDeptList", parameters);
        }

        /// <summary>
        /// SelectDeptList2
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static IList<Hashtable> SelectDeptList2(Dictionary<string, object> parameters)
        {
            return mapper.QueryForList<Hashtable>("SelectDeptList2", parameters);
        }

    }
}