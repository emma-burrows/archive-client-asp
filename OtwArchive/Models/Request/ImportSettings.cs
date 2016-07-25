using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace OtwArchive.Models.Request
{
  public class ImportSettings
  {
    // Import type for client use
    public enum ImportType
    {
      Bookmark,
      Work
    }
    public ImportType Type { get; set; }

    // Archive API parameters
    public string ArchiveHost { get; set; }
    public string Token { get; set; }
    public string Archivist { get; set; }

    // Import settings
    public bool SendClaimEmails { get; set; }
    public bool PostWithoutPreview { get; set; }

    // Optional import defaults
    public bool Restricted { get; set; }
    public bool OverrideTags { get; set; }

    public string CollectionNames { get; set; } // comma-separated collection names
    public string Fandoms { get; set; }
    public string Warnings { get; set; } // TODO: enum?
    public string Rating { get; set; } //TODO enum?
    public string Characters { get; set; }
    public string Relationships { get; set; }
    public string Categories { get; set; }
    public string AdditionalTags { get; set; }
    public string Summary { get; set; }
    public string Encoding { get; set; }

    public string ExternalAuthorName { get; set; }
    public string ExternalAuthorEmail { get; set; }
    public string ExternalCoauthorName { get; set; }
    public string ExternalCoauthorEmail { get; set; }
  }
}
