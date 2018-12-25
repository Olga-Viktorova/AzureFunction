using System;
using System.Data.SqlClient;
using System.IO;
using Dapper;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Blob;

namespace QueueTriger
{
    public static class Function1
    {
        //private readonly AWDBContext _context;

        [FunctionName("Function1")]
        public static void Run([QueueTrigger("awapiqueue", Connection = "connectionString")]string myQueueItem, TraceWriter log)
        {
            int indexOf = myQueueItem.IndexOf("BlobId") + 7;
            string fileName = myQueueItem.Substring(indexOf);
            var blobFile = GetBlobFile(fileName);
            SaveDocumentInDatabase(fileName, blobFile);


            log.Info($"File name: {fileName}");
            log.Info($"C# Queue trigger function processed: {myQueueItem}");
        }

        public static byte[] GetBlobFile(string fileName)
        {
            var credentials = new StorageCredentials("storageaccountaw", "43VFe0AQezMlebphIDJ98f6YMe0uC0CpRjELvIy/424GAYCQMJ2KJEfKFU6c1nZVAjRpWyfyBr8tY5RqA94klg==");
            string baseUriBlob = "https://storageaccountaw.blob.core.windows.net/";
            var blobClient = new CloudBlobClient(new Uri(baseUriBlob), credentials);
            var container = blobClient.GetContainerReference("files");
            var blob = container.GetBlockBlobReference(fileName);
            blob.FetchAttributes();
            string result = string.Empty;

            long fileByteLength = blob.Properties.Length;
            byte[] fileContent = new byte[fileByteLength];
            blob.DownloadToByteArray(target: fileContent, index: 0);

            return fileContent;
        }

        public static void SaveDocumentInDatabase(string fileName, byte[] fileContent)
        {
            var connectionString = "Server=tcp:adventure-worksserver.database.windows.net,1433;Initial Catalog=AdventureWorks;Persist Security Info=False;User ID=volha-viktarava;Password=123456qwerty!@;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            using (var connection = new SqlConnection(connectionString))
            {
                //Opens Azure SQL DB connection.
                connection.Open();

                connection.Execute("INSERT INTO [dbo].[Document] (" +
                    "[FileName], " +
                    "[FileContent]) VALUES (@fileName, @fileContent)", new { fileName = fileName, fileContent = fileContent });
                
                
                //var logMessage = $"Fonksiyon {data.userName} tarafından {DateTime.UtcNow} tarihinde çağırılmıştır.";

                // Insert Log to database.
                //var date = DateTime.Now;
                //var rowguid = new Guid();
                //connection.Execute("INSERT INTO Production.Document (" +
                //    "[DocumentNode], " +
                //    "[ChangeNumber]," +
                //    "[DocumentLevel]," +
                //    "[FileExtension]," +
                //    "[FileName]," +
                //    "[FolderFlag]," +
                //    "[ModifiedDate]," +
                //    "[Document]," +
                //    "[Owner]," +
                //    "[Revision]," +
                //    "[rowguid]," +
                //    "[Status]," +
                //    "[Title]) VALUES (0x58, 1, 1, 'docx', @fileName, 0, @date, @fileContent, 1, '1', @rowguid, 1, 'test')", new { fileName = fileName, date = date, fileContent = fileContent, rowguid = rowguid });

                

                //log.Info("Log kaydı başarılı şekilde veritabanına eklenmiştir!");
            }


            //var _context = new AWDBContext(); 
            //var document = new DocumentModel
            //{
            //    DocumentNode = 1,
            //    ChangeNumber = 1,
            //    DocumentLevel = 1,
            //    FileExtension = "docx",no
            //    FileName = fileName,
            //    FolderFlag = false,
            //    ModifiedDate = DateTime.Now,
            //    Document = fileContent,
            //    Owner = 1,
            //    Revision = "1",
            //    rowguid = new Guid(),
            //    Status = 1,
            //    Title = "Test"
            //};

            //_context.DocumentModel.Add(document);
            //_context.SaveChanges();
        }
    }
}
