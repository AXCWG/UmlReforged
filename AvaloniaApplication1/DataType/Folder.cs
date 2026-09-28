using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using AXExpansion;
using CommunityToolkit.Mvvm.ComponentModel;

namespace AvaloniaApplication1.DataType;

public class Folder
{
    public List<VersionProfile> VersionProfiles { get; set; } = []; 
}

public class ApplicationDataDataObject
{
    /*
     * Implementation details in case I forgot.
     *
     * Why they are not required and nullable?
     * In case I have an update and added more properties to this type,
     *  JsonSerializer, located in App.xaml.cs, used for opening config file,
     *  won't throw any exception and flush all configs. 
     */
    public  IEnumerable<Folder>? Folders { get; set; }
    public  IEnumerable<string>? StoredNames { get; set; }
    public  int? SelectedIndex { get; set; }
    public  bool? IsOnline { get; set; }
    public static implicit operator ApplicationDataDataObject(ApplicationData applicationData) =>
        new()
        {
            Folders = applicationData.Folders,
            StoredNames = applicationData.StoredNames,
            SelectedIndex = applicationData.SelectedIndex,
            IsOnline = applicationData.IsOnline
        };
}
public partial class ApplicationData : ObservableObject
{
    [ObservableProperty]
    public partial bool IsOnline { get; set; }
    
    public ObservableCollection<Folder> Folders { get; } 
    public ObservableCollection<string> StoredNames { get; } 
    [ObservableProperty]
    public partial int SelectedIndex { get; set; }

    public ApplicationData(IEnumerable<Folder>  folders, IEnumerable<string> storedNames , int selectedIndex, bool isOnline)
    {
        Folders = new ObservableCollection<Folder>(folders ?? []);
            Folders.CollectionChanged += (_, _) =>
        {
            OnPropertyChanged(nameof(Folders));
            
        };
        StoredNames = new(storedNames?? []); 
        StoredNames.CollectionChanged += (_, _) =>
        {
            OnPropertyChanged(nameof(StoredNames));
        };
        SelectedIndex = selectedIndex;
        IsOnline = isOnline;
        
    }
    protected override void OnPropertyChanged(PropertyChangedEventArgs e)
    {
        File.WriteAllText("config.json", JsonSerializer.Serialize<ApplicationDataDataObject>(this, AppJsonSerializer.Default.ApplicationDataDataObject));
        base.OnPropertyChanged(e);
    }
}

[JsonSerializable(typeof(ApplicationDataDataObject))]
public partial class AppJsonSerializer : JsonSerializerContext;