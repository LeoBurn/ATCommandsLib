using ATCommands.Base.Request;
using ATCommands.Base.Response;

namespace ATCommands.Base
{
  // ReSharper disable once InconsistentNaming
  /// <summary>
  ///   This Interface Implement All Operations you can have in dispositive that receives ATCommands
  /// </summary>
  public interface IATCommandService
  {
    OpenPortResponse OpenPort(OpenPortRequest request);

    ClosePortResponse ClosePort(ClosePortRequest request);

    GetImeiResponse GetImei(GetImeiRequest request);
  }
}