using cs_WCF.Common;
using cs_WCF.Config;
using IBatisNet.DataMapper;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;

namespace cs_WCF.Services.Common {
    public class CommonDAO {
        private static ISqlMapper mapper = Properties.EntityMapper;

        /// <summary>
        /// SelectDeptList
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static IList<Hashtable> SelectDeptList(Dictionary<string, object> parameters)
        {
            Console.WriteLine("Service" + parameters["EQP_ID"]);
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