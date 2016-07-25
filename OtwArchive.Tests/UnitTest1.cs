using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OtwArchive;
using OtwArchive.Models.Request;
using OtwArchive.Models.Response;
using OtwArchive.Utils;
using System.Text;
using System.Net;
using Moq;
using System.Collections.Generic;
using OtwArchive.Models.Request.Items;

namespace OtwArchive.Tests
{
  [TestClass]
  public class ArchiveClientTest
  {
    ImportSettings settings = new ImportSettings();
    ImportRequest request = new ImportRequest();
    ArchiveClient client;
    Mock<IWebClient> mockWebClient;

    [TestInitialize]
    public void SetupTests()
    {
      settings.ArchiveHost = "http://dummy";
      Mock<WebHeaderCollection> mockWebHeaders = new Mock<WebHeaderCollection>(MockBehavior.Strict);
      mockWebHeaders.Setup(m => m.Add(It.IsAny<string>(), It.IsAny<string>())); 
      
      mockWebClient = new Mock<IWebClient>(MockBehavior.Strict);
      mockWebClient.Setup(m => m.Dispose());
      mockWebClient.SetupSet(m => m.Encoding = It.IsAny<Encoding>());
      mockWebClient.SetupGet(m => m.Headers).Returns(mockWebHeaders.Object);
      mockWebClient.Setup(m => m.UploadString(It.IsAny<string>(), It.IsAny<string>()))
        .Returns(@"
          {
    ""messages"": [
        ""All works were successfully imported.""
    ],
    ""works"": [
        {
            ""status"": ""created"",
            ""url"": ""http://localhost:3000/works/425979"",
            ""original_url"": ""http://astele.co.uk/henneth/Chapter/Details/3178"",
            ""messages"": [
                ""Successfully created work 'Title'.""
            ]
        },
        {
            ""status"": ""created"",
            ""url"": ""http://localhost:3000/works/425980"",
            ""original_url"": ""http://astele.co.uk/henneth/Chapter/Details/3179"",
            ""messages"": [
                ""Successfully created work 'Title'.""
            ]
        }
    ]
}

      ");

      client = new ArchiveClient(settings, mockWebClient.Object);
    }

    [TestMethod]
    public void ImportTest()
    {
      Assert.IsInstanceOfType(client.import(new ImportRequest()), 
        typeof(ImportResponse), 
        "OtwArchive.ArchiveClient.import should return an ImportResponse", 
        new { });
    }

    [TestMethod]
    public void MockWebRequestTest()
    {
      ImportResponse response = client.import(new ImportRequest());
      Assert.IsInstanceOfType(response,
        typeof(ImportResponse),
        "OtwArchive.ArchiveClient.import should return an ImportResponse");

      Assert.AreEqual("All works were successfully imported.", response.Messages[0]);

    }

    [TestMethod]
    public void ImportUrlTest()
    {
      client = new ArchiveClient(settings, mockWebClient.Object);
      // Assert.AreEqual("http://dummy/api/v1/import", client.importUrl());
    }

    [TestMethod]
    public void BookmarkTest()
    {
      client = new ArchiveClient(settings, mockWebClient.Object);
      ImportRequest req = new ImportRequest();
      BookmarkImportRequest bookmark = new BookmarkImportRequest();
      ExternalWork work = new ExternalWork();
      bookmark.CollectionNames = "collection";
      bookmark.Notes = "my notes";
      work.Author = "External Author";
      work.Title = "Work Title";
      work.Summary = "Work summary.";
      bookmark.External = work;
      req.Type = ImportSettings.ImportType.Bookmark;
      req.Archivist = "testy";
      req.Works = new List<IRequestItem>();
      req.Works.Add(bookmark);
      
      ImportResponse resp = client.import(req);
      Console.Out.Write(resp);
      Assert.IsInstanceOfType(resp, typeof(ImportResponse));
    }
  }
}
