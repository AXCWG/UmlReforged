using System;
using System.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel;
using fNbt;

namespace AvaloniaApplication1.ViewModels;

public partial class NBTUserControlStaticState : ViewModelBase
{
    private static NBTUserControlStaticState? _instance;
    public static NBTUserControlStaticState Instance  => _instance ??= new NBTUserControlStaticState();
    [ObservableProperty] public partial NbtFile? File { get; set; }
    
    partial void OnFileChanged(NbtFile? value)
    {
        Console.WriteLine(File?.ToString());
    }

    public void FileChanged()
    {
        var f = File;
        File = null;
        File = f;
    }

    public NBTUserControlStaticState()
    {
        Console.WriteLine("Created. ");
    }

    public void LoadFileCommand(string filename)
    {
        var nbt = new NbtFile();
        nbt.LoadFromFile(filename, compression: NbtCompression.AutoDetect, null);
        File = nbt;
        
    }
}