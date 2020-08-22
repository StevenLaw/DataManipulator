using DataManipulator.Interfaces;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;
using Google.Apis.Util.Store;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace GoogleSheetsReader
{
    public class Reader<T> : IReader<T>
    {
        static readonly string[] Scopes = { SheetsService.Scope.SpreadsheetsReadonly };
        static readonly string ApplicationName = "Google Sheets Data Reader";


        public string SpreadsheetId { get; set; }
        public string Range { get; set; }
        public TypeBuilder Build { get; set; }
        public string CredPath { get; set; }

        private string CredJson
        {
            get => Path.Combine(CredPath, "credentials.json");
        }
        private string TokenJson
        {
            get => Path.Combine(CredPath, "token.json");
        }

        public delegate T TypeBuilder(IList<object> list);

        public Reader(string spreadsheetId, string range, TypeBuilder typeBuilder, string credPath = "")
        {
            SpreadsheetId = spreadsheetId;
            Range = range;
            Build = typeBuilder;
            CredPath = credPath;
        }

        

        public IEnumerable<T> GetData()
        {
            UserCredential credential;
            
            using (var stream = new FileStream(CredJson, FileMode.Open, FileAccess.Read))
            {
                string credPath = TokenJson;
                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.Load(stream).Secrets,
                    Scopes,
                    "user",
                    CancellationToken.None,
                    new FileDataStore(credPath, true)).Result;
            }

            var service = new SheetsService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = ApplicationName
            });

            SpreadsheetsResource.ValuesResource.GetRequest request =
                service.Spreadsheets.Values.Get(SpreadsheetId, Range);

            ValueRange response = request.Execute();
            IList<IList<object>> values = response.Values;
            List<T> list = new List<T>();
            if (values != null && values.Count > 0)
            {
                foreach (var row in values)
                {
                    list.Add(Build(row));
                }
            }
            return list;
        }
    }
}
