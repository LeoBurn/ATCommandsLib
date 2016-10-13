using ATCommands.Base.DataModel;

// ReSharper disable InconsistentNaming

namespace ATCommands.Base.Request.Base
{
  /// <summary>
  /// This class correspond of a request of ATCommandService
  /// All methods have a request object with context
  /// </summary>
  public class ATCommandsBaseRequest
  {

    #region Members

    /// <summary>
    /// KeepConnection identify if comPortComunication close the connection
    /// Default value is false
    /// </summary>
    public bool KeepConnection { get; set; }

    #endregion

    #region Constructor
    public ATCommandsBaseRequest()
    {
      KeepConnection = false;
    }

    #endregion

    #region Properties
    /// <summary>
    /// DeviceInfo has all information of device ( ComPort, Imei, Network)
    /// </summary>
    public Device Device { get; set; }

    #endregion
  }
}
