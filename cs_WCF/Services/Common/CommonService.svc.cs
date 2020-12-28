using cs_WCF.Common;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;

namespace cs_WCF.Services.Common {
    // 참고: "리팩터링" 메뉴에서 "이름 바꾸기" 명령을 사용하여 코드, svc 및 config 파일에서 클래스 이름 "PDAService"을 변경할 수 있습니다.
    // 참고: 이 서비스를 테스트하기 위해 WCF 테스트 클라이언트를 시작하려면 솔루션 탐색기에서 PDAService.svc나 PDAService.svc.cs를 선택하고 디버깅을 시작하십시오.
    public class CommonService : ICommonService {
        /// <summary>
        /// SelectDeptList
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public IList<Hashtable> SelectDeptList(Dictionary<string, object> parameters)
        {
            return CommonDAO.SelectDeptList(parameters);
        }

        /// <summary>
        /// SelectDeptList2
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public ApiResponse<IList<Hashtable>> SelectDeptList2(Dictionary<string, object> parameters)
        {
            ApiResponse<IList<Hashtable>> response = new ApiResponse<IList<Hashtable>>();

            try
            {
                response.Data = CommonDAO.SelectDeptList2(parameters);
                response.Result = true;
            }
            catch (Exception ex)
            {
                response.Result = false;
                response.Message = ex.Message;
            }
            return response;
        }
    }
}
