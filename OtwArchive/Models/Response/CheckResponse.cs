using OtwArchive.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OtwArchive
{
  public class CheckResponse
  {
    public string Status { get; set; }
    public List<String> Messages { get; set; }
    public List<WorksResponse> worksResponses { get; set; }
  }
}
