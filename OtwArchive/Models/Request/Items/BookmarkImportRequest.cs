using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OtwArchive.Models.Request.Items;

namespace OtwArchive.Models.Request
{
  public class BookmarkImportRequest : IRequestItem
  {
    public String PseudId { get; set; }
    public String Url { get; set; }
    public String Author { get; set; }
    public String Title { get; set; }
    public String Summary { get; set; }
    public String FandomString { get; set; }
    public String RatingString { get; set; }
    public String CategoryString { get; set; }
    public String RelationshipString { get; set; }
    public String CharacterString { get; set; }
    public String CollectionNames { get; set; }
    public String Notes { get; set; }
    public String TagString { get; set; }
    public Boolean Private { get; set; }
    public Boolean Rec { get; set; }
  }
}
