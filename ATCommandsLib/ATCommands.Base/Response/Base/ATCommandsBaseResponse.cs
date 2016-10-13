using System.Collections.Generic;
using ATCommands.Base.DataModel;
using ATCommands.Base.Request.Base;

// ReSharper disable InconsistentNaming

namespace ATCommands.Base.Response.Base
{
  /// <summary>
  /// This class correspond of a Response of ATCommandService
  /// All methods have a response object with context
  /// 
  /// This response use a template method : https://sourcemaking.com/design_patterns/template_method
  /// </summary>
  public abstract class ATCommandsBaseResponse
  {
    #region Constructor

    protected ATCommandsBaseResponse()
    {
      Queries = new Dictionary<string, string>();
    }

    #endregion

    #region Properties

    public bool Sucess { get; set; }

    public string ErrorDescription { get; set; }

    public Device Device { get; set; }

    public Dictionary<string, string> Queries { get; set; }

    #endregion

    #region Methods

    public void AddQueryObjectInTheList(string request, string response)
    {
      Queries.Add(request, response);
    }

    public void CompleteRun(ATCommandsBaseRequest request)
    {
      Device = request.Device;
      CompleteRunAfter(request);
    }

    public abstract void CompleteRunAfter(ATCommandsBaseRequest request);

    #endregion
  }
}
