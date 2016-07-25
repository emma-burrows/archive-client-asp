using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OtwArchive.Models.Response
{
  public class BookmarkImportResponse
  {
    public string OriginalRef { get; set; }
    public string Status { get; set; }
    public string ArchiveUrl { get; set; } 
    public string OriginalUrl { get; set; }
    public List<string> Messages { get; set; }
  }
}
