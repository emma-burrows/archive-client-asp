using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OtwArchive.Models.Request;
using OtwArchive.Utils;
using OtwArchive.Models.Response;
using System.Collections.Generic;

namespace OtwArchive.Tests
{
  [TestClass]
  public class IntegrationTests
  {
    ImportSettings settings = new ImportSettings();

    [TestMethod]
    public void LocalIntegrationTest()
    {
      // Set all the possible settings (token is local to my dev machine only)
      settings.ArchiveHost = "http://localhost:3000";
      settings.Archivist = "testy";
      settings.Token = "e1b6298a6209dd65e5df95b83b10c0f1";

      //settings. = "Collection";
      ArchiveClient client = new ArchiveClient(settings, new ArchiveWebClient());
      ImportRequest request = new ImportRequest();
      //request. =
      //  new WorkImportRequest()
      //  {
      //    Title = "Integration Test",
      //    ChapterUrls = new List<Uri>() { new Uri("http://integration-test/chapter/" + new Guid()) },
      //    Summary = "This is my summary",
      //    CollectionNames = "Collection name"
      //  };
      ImportResponse response = client.import(request);
    }

  }
}
