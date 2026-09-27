using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AvaloniaApplication1.DataType;

public class Folder
{
    public List<VersionProfile> VersionProfiles { get; set; } = []; 
}

public class ApplicationData
{
    
    public List<Folder> Folders { get; set; } = [];
    public List<string> StoredNames { get; set; } = []; 
}

[JsonSerializable(typeof(ApplicationData))]
public partial class AppJsonSerializer : JsonSerializerContext;