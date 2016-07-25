using Newtonsoft.Json;
using OtwArchive.Models.Request;
using OtwArchive.Models.Response;
using OtwArchive.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;


namespace OtwArchive
{
  public class ArchiveClient : IDisposable
  {
    private ImportSettings settings = new ImportSettings();
    private IWebClient webClient;

    private String API_URL = "/api/v1";
    private String IMPORT_URL = "import";
    private String WORKS_URL = "works/urls";
    private String BOOKMARK_IMPORT_URL = "bookmarks/import";

    public ArchiveClient(String hostUrl, String token, String archivist, bool sendEmails, 
                         bool postWorks, String encoding = "UTF-8")
    {
      webClient = new ArchiveWebClient();

      settings.ArchiveHost = hostUrl;
      settings.Token = token;
      settings.Archivist = archivist;
      settings.SendClaimEmails = sendEmails;
      settings.PostWithoutPreview = postWorks;
      settings.Encoding = encoding;
    }

    public ArchiveClient(ImportSettings settings)
    {
      webClient = new ArchiveWebClient();
      this.settings = settings;
    }

    public ArchiveClient(ImportSettings settings, IWebClient webClient)
    {
      this.webClient = webClient;
      this.settings = settings;
    }

    public ImportResponse import(ImportRequest request, 
                                 ImportSettings.ImportType type = ImportSettings.ImportType.Work)
    {
      request.populateFromSettings(settings);
      
      ImportResponse result = new ImportResponse();
      try
      {
        using (IWebClient webClient = configureRequest())
        {
          string postString = JsonConvert.SerializeObject(request, jsonSettings());
          // string webResponse = webClient.UploadString(importUrl(request.Type), postString);
          string webResponse = webClient.UploadString(importUrl(type), postString);
          result = JsonConvert.DeserializeObject<ImportResponse>(webResponse, jsonSettings());
        }
      }
      catch (WebException we)
      {
        if (we.Response == null || !(we.Response.ContentType.StartsWith("application/json")))
        {
          // No response from the Archive or some generated error like a 500
          result.Status = we.Status.ToString();
          result.Messages = new List<string> { we.Message };
        }
        else
        {
          // The Archive received the request but didn't like it (incorrect archivist, bad requests)
          var response = new StreamReader(we.Response.GetResponseStream()).ReadToEnd();
          result = JsonConvert.DeserializeObject<ImportResponse>(response);
        }
      }
      return result;
    }

    public CheckResponse checkUrls(CheckRequest request) {
      CheckResponse result = new CheckResponse();
      List<WorksResponse> responses = null;
      try
      {
        using (IWebClient webClient = configureRequest())
        {
          string postString = JsonConvert.SerializeObject(request, jsonSettings());
          string webResponse = webClient.UploadString(checkUrl(), postString);
          responses = JsonConvert.DeserializeObject<List<WorksResponse>>(webResponse, jsonSettings());
          result.worksResponses = responses;
        }
      }
      catch (WebException we)
      {
        System.Diagnostics.Debug.WriteLine(we.Message);

        if (we.Response == null || !(we.Response.ContentType.StartsWith("application/json")))
        {
          // No response from the Archive or some generated error like a 500
          result.Status = we.Status.ToString();
          result.Messages = new List<string> { we.Message };
        }
        else
        {
          // Boo-boo in API code - it should return 200 if the only problem is a business logic
          var response = new StreamReader(we.Response.GetResponseStream()).ReadToEnd();
          responses = JsonConvert.DeserializeObject<List<WorksResponse>>(response, new JsonSerializerSettings { ContractResolver = new SnakeCaseContractResolver() });
          result.worksResponses = responses;
        }
      }
      return result;
    }

    // Common WebClient configuration
    private IWebClient configureRequest()
    {
      webClient.Encoding = System.Text.Encoding.UTF8;
      // Initialise Headers for testing mock
      webClient.Headers.Add("Authorization", "Token token=\"" + settings.Token + "\"");
      webClient.Headers.Add("Content-Type", "application/json");
      return webClient;
    }

    // Convert camelCase to and from snake_case
    private JsonSerializerSettings jsonSettings()
    {
      return new JsonSerializerSettings { 
        ContractResolver = new Utils.SnakeCaseContractResolver() };
    }

    // Import URL
    private String importUrl(ImportSettings.ImportType type = ImportSettings.ImportType.Work)
    {
      if (type == ImportSettings.ImportType.Bookmark)
      {
        return String.Join("/", new List<String> { settings.ArchiveHost, API_URL, BOOKMARK_IMPORT_URL });
      }
      else
      {
        return String.Join("/", new List<String> { settings.ArchiveHost, API_URL, IMPORT_URL });
      }
      
    }

    private String checkUrl()
    {
      return String.Join("/", new List<String> { settings.ArchiveHost, API_URL, WORKS_URL });
    }

    public void Dispose()
    {
      throw new NotImplementedException();
    }


  }
}
