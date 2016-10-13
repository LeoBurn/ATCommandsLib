using System;
using ATCommands.Base;
using ATCommands.Base.DataModel;
using ATCommands.Base.Request;
using ATCommands.Implementation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// ReSharper disable InconsistentNaming

namespace ATCommands.Tests
{
  [TestClass]
  public class ATCommandsLibsOperationsTest
  {
    [TestMethod]
    public void ShouldOpenComPort()
    {
      //Arrange
      string comPortName = "COM10";
      OpenPortRequest request = new OpenPortRequest
      {
        Device = new Device { DeviceInfo = new DeviceInfo { ComPortName = comPortName } }
      };
      IATCommandService service = new ATCommandService();

      //Act
      try
      {
        service.OpenPort(request);
      
        //Assert
        Assert.IsTrue(true);
      }
      catch (Exception)
      {
        //Assert  
        Assert.Fail();
      }
      
    }
  }
}
