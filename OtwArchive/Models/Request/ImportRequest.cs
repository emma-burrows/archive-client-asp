using OtwArchive.Models.Request.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OtwArchive.Models.Request
{
  /// <summary>
  /// Provide all the required information for an Import request to the Archive of Our Own API.
  /// </summary>
  public class ImportRequest
  {
    // public ImportSettings.ImportType Type { get; set; }
    public string Archivist { get; set; }
    public bool SendClaimEmails { get; set; }
    public bool PostWithoutPreview { get; set; }
    public String Encoding { get; set; }

    public string CollectionNames { get; set; }
    public List<IRequestItem> Works { get; set; }
    public List<IRequestItem> Bookmarks { get; set; }

    public void populateFromSettings(ImportSettings settings)
    {
      this.Archivist = settings.Archivist;
      this.CollectionNames = settings.CollectionNames;
      this.SendClaimEmails = settings.SendClaimEmails;
      this.PostWithoutPreview = settings.PostWithoutPreview;
      this.Encoding = settings.Encoding;
    }
  }
}
