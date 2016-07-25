using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OtwArchive.Models.Response
{
  public class ImportResponse
  {
    public string Status { get; set; }
    public List<String> Messages { get; set; }
    public List<WorkImportResponse> Works { get; set; }
    public List<BookmarkImportResponse> Bookmarks { get; set; }
  }
}
