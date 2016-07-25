using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtwArchive.Models.Response
{
  public class WorksResponse
  {
    public string Status { get; set; }
    public string OriginalUrl { get; set; }
    public string WorkUrl { get; set; }
    public DateTime Created { get; set; }
  }
}
