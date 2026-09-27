using System;

namespace AvaloniaApplication1.DataType;

public class VersionProfile
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string Version { get; set; }
    public DateTime LastPlayed { get; set; }

    #region Settings

    public bool IsSeparated { get; set; }
    public string WindowTitle { get; set; }
    public object Java { get; set; }
    public long Memory { get; set; }
    public string JvmArgs { get; set; }
    
    #endregion
}