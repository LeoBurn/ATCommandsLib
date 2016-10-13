using System.IO.Ports;

namespace ATCommands.Base.DataModel
{
  /// <summary>
  /// Device info and object to connect with device
  /// </summary>
  public class Device
  {
    #region Contructor
    public Device()
    {
      DeviceInfo = new DeviceInfo();
      SerialPort = new SerialPort();
    }
    #endregion

    #region Properties

    public DeviceInfo DeviceInfo { get; set; }

    public SerialPort SerialPort { get; set; }

    #endregion
  }
}
