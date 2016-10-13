using System;
using System.IO.Ports;
using System.Text;
using System.Threading;
using ATCommands.Base;
using ATCommands.Base.Exceptions;
using ATCommands.Base.Request;
using ATCommands.Base.Request.Base;
using ATCommands.Base.Response;
using ATCommands.Base.Response.Base;
using ATCommands.Base.Settings;

namespace ATCommands.Implementation
{
  // ReSharper disable once InconsistentNaming
  /// <summary>
  /// </summary>
  public class ATCommandService : IATCommandService
  {
    #region Members

    #endregion

    #region Constructor

    /// <summary>
    /// Constructor of ATCommandService
    /// </summary>
    public ATCommandService()
    {
     if(Settings == null)
        Settings = ATCommandsSetttings.GetInstance();
    }

    #endregion

    #region Properties

    //This propertie has setting to fill SerialPort Object
    public ATCommandsSetttings Settings { get; set; }

    #endregion

    #region Methods

    /// <summary>
    /// Open Serial port configurations
    /// </summary>
    public OpenPortResponse OpenPort(OpenPortRequest request)
    {
      try
      {
        request.Device.SerialPort.PortName = request.Device.DeviceInfo.ComPortName; //COM1
        request.Device.SerialPort.BaudRate = Settings.BaudRate; //9600 || 115200 -> default
        request.Device.SerialPort.DataBits = 8; //8 -> default
        request.Device.SerialPort.StopBits = StopBits.One; //1 -> default
        request.Device.SerialPort.Parity = Parity.None; //None -> default
        request.Device.SerialPort.ReadTimeout = Settings.ReadTimeout; //300 -> default
        request.Device.SerialPort.WriteTimeout = Settings.WriteTimeout; //300 -> default
        request.Device.SerialPort.Encoding = Encoding.GetEncoding("iso-8859-1");
        request.Device.SerialPort.DataReceived += PortDataReceived;
        request.Device.SerialPort.Open();
        request.Device.SerialPort.DtrEnable = true;
        request.Device.SerialPort.RtsEnable = true;
      }
      catch (Exception ex)
      {
        throw new SerialPortException("SerialPort Open Error", ex);
      }

      OpenPortResponse response = new OpenPortResponse();
      response.CompleteRunAfter(request);
      return response;
    }

    public void PortDataReceived(object sender, SerialDataReceivedEventArgs e)
    {
      throw new NotImplementedException();
    }

    /// <summary>
    /// Close serial port
    /// </summary>
    public ClosePortResponse ClosePort(ClosePortRequest request)
    {
      try
      {
        request.Device.SerialPort.Close();
        request.Device.SerialPort.DataReceived -= PortDataReceived;
        request.Device.SerialPort = null;
      }
      catch (Exception ex)
      {
        throw new SerialPortException("Failed to close port", ex);
      }

      ClosePortResponse response = new ClosePortResponse();
      response.CompleteRunAfter(request);
      return response;
    }

    public GetImeiResponse GetImei(GetImeiRequest request)
    {
      var response = new GetImeiResponse();
      ExecuteAtCommand(Base.ATCommands.ImeiCommand, Settings.ReadTimeout, request, response);
      response.CompleteRun(request);

      if(!request.KeepConnection)
        request.Device.SerialPort.Close();

      return response;
    }

    #region Internal Methods

    /// <summary>
    /// Generic method to execute ATCommand
    /// </summary>
    /// <param name="request">execute</param>
    /// <param name="responseTimeout">Timeout</param>
    /// <param name="requestObj">Response object to aggregate responses</param>
    /// <param name="response">Request object to aggregate responses</param>
    /// <returns></returns>
    private string ExecuteAtCommand(string request, int responseTimeout,ATCommandsBaseRequest requestObj, ATCommandsBaseResponse response = null)
    {
      try
      {
        requestObj.Device.SerialPort.DiscardOutBuffer();
        requestObj.Device.SerialPort.DiscardInBuffer();
        requestObj.Device.SerialPort.Write(request + "\r");
        Thread.Sleep(responseTimeout);
        var responseAt = ReadResponse(requestObj);
        response?.AddQueryObjectInTheList(request, responseAt);
        return responseAt;
      }
      catch (Exception ex)
      {
        throw new ComunicationException("ExcutedAtCommand", ex);
      }
    }


    /// <summary>
    /// Read Response from Serial Port
    /// </summary>
    /// <returns></returns>
    private string ReadResponse(ATCommandsBaseRequest request)
    {
      var buffer = string.Empty;
      try
      {
        var response = request.Device.SerialPort.ReadExisting();
        buffer += response;
      }
      catch (Exception ex)
      {
        throw new ComunicationException("Read Response", ex);
      }
      return buffer;
    }


    #endregion

    #endregion
  }
}