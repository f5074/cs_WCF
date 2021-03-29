using cs_WCF.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace cs_WCF.Services.FileTansfer
{
    // 참고: "리팩터링" 메뉴에서 "이름 바꾸기" 명령을 사용하여 코드, svc 및 config 파일에서 클래스 이름 "FileTransferService"을 변경할 수 있습니다.
    // 참고: 이 서비스를 테스트하기 위해 WCF 테스트 클라이언트를 시작하려면 솔루션 탐색기에서 FileTransferService.svc나 FileTransferService.svc.cs를 선택하고 디버깅을 시작하십시오.
    public class FileTransferService : IFileTransferService
    {
        public RemoteFileInfo DownloadFile(String fileName)
        {
            RemoteFileInfo result = new RemoteFileInfo();
            try
            {
                string filePath = System.IO.Path.Combine(@"c:\DEV", fileName);
                System.IO.FileInfo fileInfo = new System.IO.FileInfo(filePath);

                // check if exists
                if (!fileInfo.Exists)
                    throw new System.IO.FileNotFoundException("File not found", fileName);

                // open stream
                System.IO.FileStream stream = new System.IO.FileStream(filePath,
                          System.IO.FileMode.Open, System.IO.FileAccess.Read);

                // return result 
                result.FileName = fileName;
                result.Length = fileInfo.Length;
                result.FileByteStream = stream;
            }
            catch (Exception ex)
            {

            }
            return result;
        }
        public void UploadFile(RemoteFileInfo request)
        {
            FileStream targetStream = null;
            Stream sourceStream = request.FileByteStream;

            string uploadFolder = @"C:\DEV\downloads";

            string filePath = Path.Combine(uploadFolder, request.FileName);

            using (targetStream = new FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                //read from the input stream in 65000 byte chunks

                const int bufferLen = 65000;
                byte[] buffer = new byte[bufferLen];
                int count = 0;
                while ((count = sourceStream.Read(buffer, 0, bufferLen)) > 0)
                {
                    // save to output stream
                    targetStream.Write(buffer, 0, count);
                }
                targetStream.Close();
                sourceStream.Close();
            }
        }



        public Stream DownloadFile(string fileName, string fileExtension)
        {
            string path = Path.GetFullPath(".\\Deploy");
            string downloadFilePath = Path.Combine(path, fileName + "." + fileExtension);

            //Write logic to create the file
            //File.Create(downloadFilePath);

            String headerInfo = "attachment; filename=" + fileName + "." + fileExtension;
            WebOperationContext.Current.OutgoingResponse.Headers["Content-Disposition"] = headerInfo;
            WebOperationContext.Current.OutgoingResponse.ContentType = "application/octet-stream";
            return File.OpenRead(downloadFilePath);
        }

        public void UploadFile(string fileName, Stream stream)
        {
            string path = Path.GetFullPath(".\\Deploy");
            string filePath = Path.Combine(path, fileName );
            int length = 0;
            using (FileStream writer = new FileStream(filePath, FileMode.Create))
            {
                int readCount;
                var buffer = new byte[8192];
                while ((readCount = stream.Read(buffer, 0, buffer.Length)) != 0)
                {
                    writer.Write(buffer, 0, readCount);
                    length += readCount;
                }
            }
        }
    }
}
