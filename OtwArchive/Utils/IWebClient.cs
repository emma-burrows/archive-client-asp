using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace OtwArchive.Utils
{
  /// <summary>
  /// Interface wrapper for WebClient to facilitate unit testing.
  /// </summary>
  public interface IWebClient : IDisposable
  {
    // Required properties
    Encoding Encoding { get; set; }
    WebHeaderCollection Headers { get; set; }

    // Required methods (subset of `System.Net.WebClient` methods).
    string UploadString(string address, string postData);
  }
}
