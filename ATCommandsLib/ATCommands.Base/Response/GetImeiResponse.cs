using System;
using System.Linq;
using ATCommands.Base.Request.Base;
using ATCommands.Base.Response.Base;

namespace ATCommands.Base.Response
{
  /// <summary>
  /// Response of GetImei service operation
  /// </summary>
  public class GetImeiResponse : ATCommandsBaseResponse
  {

    /// <summary>
    /// Store imei in response device object
    /// </summary>
    /// <param name="request"></param>
    public override void CompleteRunAfter(ATCommandsBaseRequest request)
    {
      var response = Queries.Last().Value;
      var cleanResponse = response.Replace("\r", String.Empty).Replace("\n", String.Empty).Replace("  ", " ");
      int beginIndex = cleanResponse.IndexOf(ATCommands.ImeiCommand, StringComparison.Ordinal);
      int endIndex = cleanResponse.IndexOf("OK", StringComparison.Ordinal);
      Device.DeviceInfo.Imei = cleanResponse.Substring((beginIndex == -1) ? 0 : beginIndex + ATCommands.ImeiCommand.Length, endIndex);
    }
  }
}
