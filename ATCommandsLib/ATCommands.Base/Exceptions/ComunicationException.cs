using System;
using System.Runtime.Serialization;

namespace ATCommands.Base.Exceptions
{
  /// <summary>
  /// This Exception occurs when has problems with device comunication
  /// </summary>
  public class ComunicationException : Exception
  {

    #region Methods

    public ComunicationException(string message) : base(message)
    {
    }

    public ComunicationException(string message, Exception innerException) : base(message, innerException)
    {
    }

    protected ComunicationException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }

    #endregion
  }
}
