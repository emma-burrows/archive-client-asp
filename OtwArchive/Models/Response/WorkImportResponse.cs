using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OtwArchive.Models.Response
{
  public class WorkImportResponse
  {
    public string Status { get; set; }
    public string Url { get; set; } // TODO: rename to WorkUrl or ArchiveUrl?
    public string OriginalUrl { get; set; }
    public List<string> Messages { get; set; }
  }
}
