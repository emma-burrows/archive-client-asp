using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace OtwArchive.Utils
{
  /// <summary>
  /// Archive-specific implementation of IWebClient.
  /// </summary>
  public class ArchiveWebClient : WebClient, IWebClient
  {
    /// <summary>
    /// Extend default time out for long batch requests.
    /// </summary>
    /// <param name="uri">The requested URI</param>
    /// <returns>A WebRequest for the URI with the specified timeout</returns>
    protected override WebRequest GetWebRequest(Uri uri)
    {
      WebRequest w = base.GetWebRequest(uri);
      w.Timeout = 20 * 60 * 1000;
      return w;
    }

  }
}
