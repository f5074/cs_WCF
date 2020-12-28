using cs_WCF.Common;
using System.Collections;
using System.Collections.Generic;
using System.ServiceModel;

namespace cs_WCF.Services.Common {
    // 참고: "리팩터링" 메뉴에서 "이름 바꾸기" 명령을 사용하여 코드 및 config 파일에서 인터페이스 이름 "ICommonService"을 변경할 수 있습니다.
    [ServiceContract]
    public interface ICommonService {
        [OperationContract]
        IList<Hashtable> SelectDeptList(Dictionary<string, object> parameters);

        [OperationContract]
        ApiResponse<IList<Hashtable>> SelectDeptList2(Dictionary<string, object> parameters);
    }
}
