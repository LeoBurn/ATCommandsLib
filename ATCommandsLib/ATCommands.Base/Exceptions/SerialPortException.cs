using System;
using System.Runtime.Serialization;

namespace ATCommands.Base.Exceptions
{
  /// <summary>
  /// This Exception occurs when serial port give an error
  /// </summary>
  public class SerialPortException : Exception
  {

    #region Methods

    public SerialPortException(string message) : base(message)
    {
    }

    public SerialPortException(string message, Exception innerException) : base(message, innerException)
    {
    }

    protected SerialPortException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    } 
    
    #endregion
  }
}
