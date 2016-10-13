using ATCommands.Base.Request.Base;
using ATCommands.Base.Response.Base;

namespace ATCommands.Base.Response
{
  /// <summary>
  /// Response of ClosePort service operation
  /// </summary>
  public class ClosePortResponse : ATCommandsBaseResponse
  {
    public override void CompleteRunAfter(ATCommandsBaseRequest request)
    {
    }
  }
}
