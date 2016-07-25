using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OtwArchive.Models.Request.Items
{
  public class WorkImportRequest : IRequestItem
  {
    public String Title { get; set; }
    public String ExternalAuthorName { get; set; }
    public String ExternalAuthorEmail { get; set; }
    public String ExternalCoauthorName { get; set; }
    public String ExternalCoauthorEmail { get; set; }
    
    public String CollectionNames { get; set; }
    // Tags
    public String Fandoms { get; set; }
    public String Warnings { get; set; }
    public String Characters { get; set; }
    public String Rating { get; set; }
    public String Relationships { get; set; }
    public String Categories { get; set; }
    public String AdditionalTags { get; set; }
    public String Notes { get; set; }
    // Other meta
    public String Summary { get; set; }

    public List<Uri> ChapterUrls { get; set; }
  }
}
