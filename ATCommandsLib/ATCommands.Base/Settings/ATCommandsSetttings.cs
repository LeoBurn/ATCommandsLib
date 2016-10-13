using System.Configuration;

// ReSharper disable InconsistentNaming

namespace ATCommands.Base.Settings
{
  /// <summary>
  /// This Settings correspond to SerialPort configurations
  /// </summary>
  
  public class ATCommandsSetttings : ConfigurationSection
  {
    #region Members

    //Properties names of config file
    private const string sectionName = "atcommandslibs-settings";
    private const string baudRateString = "baudRate";
    private const string dataBitsString = "dataBits";
    private const string readTimeoutString = "readTimeout";
    private const string writeTimeoutString = "writeTimeout";

    //Singleton Objects
    private static ATCommandsSetttings instance;
    private static readonly object syncObject;


    //Configuration Properties
    private static readonly ConfigurationProperty baudRateProperty;
    private static readonly ConfigurationProperty dataBitsProperty;
    private static readonly ConfigurationProperty readTimeoutProperty;
    private static readonly ConfigurationProperty writeTimeoutProperty;

    #endregion

    #region static constructor
    /// <summary>
    /// Constructor
    /// </summary>
    static ATCommandsSetttings()
    {
      syncObject = new object();

      baudRateProperty = new ConfigurationProperty(baudRateString, typeof(int), null, ConfigurationPropertyOptions.IsRequired);
      dataBitsProperty = new ConfigurationProperty(dataBitsString, typeof(int), null, ConfigurationPropertyOptions.IsRequired);
      readTimeoutProperty = new ConfigurationProperty(readTimeoutString, typeof(int), null, ConfigurationPropertyOptions.IsRequired);
      writeTimeoutProperty = new ConfigurationProperty(writeTimeoutString, typeof(int), null, ConfigurationPropertyOptions.IsRequired);
    }

    #endregion

    #region Properties

    [ConfigurationProperty(baudRateString, IsRequired = false, IsKey = false)]
    public int BaudRate => (int)base[baudRateProperty];

    [ConfigurationProperty(dataBitsString, IsRequired = false, IsKey = false)]
    public int DataBits => (int)base[dataBitsProperty];

    [ConfigurationProperty(readTimeoutString, IsRequired = false, IsKey = false)]
    public int ReadTimeout => (int)base[readTimeoutProperty];

    [ConfigurationProperty(writeTimeoutString, IsRequired = false, IsKey = false)]
    public int WriteTimeout => (int)base[writeTimeoutProperty];

    #endregion

    #region Methods

    /// <summary>
    /// Singleton GetInstance
    /// </summary>
    /// <returns></returns>
    public static ATCommandsSetttings GetInstance()
    {
      lock (syncObject)
      {
        return instance ?? (instance = (ATCommandsSetttings)ConfigurationManager.GetSection(sectionName));
      }
    }

    #endregion

  }
}
