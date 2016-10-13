using System.IO.Ports;

namespace ATCommands.Base.DataModel
{
  /// <summary>
  /// This DataModel Represents Device to comunicate
  /// </summary>
  public class DeviceInfo
  {
    #region Properties

    /// <summary>
    /// Imei of device
    /// </summary>
    public string Imei { get; set; }


    /// <summary>
    /// COM port of device example:COM10
    /// </summary>
    public string ComPortName { get; set; }

    public SerialPort SerialPort { get; set; }

    #endregion
  }
}
