using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using AvaloniaApplication1.ViewModels;
using fNbt;

namespace AvaloniaApplication1.Views;

public partial class NbtSetValueDialogue: Window
{
    private NbtTag? NbtTag { get; set; }

    public NbtSetValueDialogue()
    {
        InitializeComponent();
    }
    public NbtSetValueDialogue( NbtTag nbtTag)
    {
        NbtTag = nbtTag; 
        InitializeComponent();
        switch (nbtTag.TagType)
        {
            case NbtTagType.Unknown:
                throw new ArgumentOutOfRangeException(nameof(nbtTag));
                break;
            case NbtTagType.End:
                throw new NotSupportedException();
                break;
            case NbtTagType.Byte:
                DataContext = new NbtSetValueDialogueViewModel<byte>
                {
                    Name = nbtTag.Name, Value = ((NbtByte)nbtTag).Value
                };
                break;
            case NbtTagType.Short:
                DataContext = new NbtSetValueDialogueViewModel<short>
                {
                    Name = nbtTag.Name, Value = ((NbtShort)nbtTag).Value
                };
                break;
            case NbtTagType.Int:
                DataContext = new NbtSetValueDialogueViewModel<int>
                {
                    Name = nbtTag.Name, Value = ((NbtInt)nbtTag).Value
                };
                break;
            case NbtTagType.Long:
                DataContext = new NbtSetValueDialogueViewModel<long>
                {
                    Name = nbtTag.Name, Value = ((NbtLong)nbtTag).Value
                };
                break;
            case NbtTagType.Float:
                DataContext = new NbtSetValueDialogueViewModel<float>
                {
                    Name = nbtTag.Name, Value = ((NbtFloat)nbtTag).Value
                };
                break;
            case NbtTagType.Double:
                DataContext = new NbtSetValueDialogueViewModel<double>
                {
                    Name = nbtTag.Name, Value = ((NbtDouble)nbtTag).Value
                };
                break;
            case NbtTagType.ByteArray:
                DataContext = new NbtSetValueDialogueViewModel<byte[]>
                {
                    Name = nbtTag.Name, Value = ((NbtByteArray)nbtTag).Value
                };
                break;
            case NbtTagType.String:
                DataContext = new NbtSetValueDialogueViewModel<string>()
                {
                    Name = nbtTag.Name, Value = ((NbtString)nbtTag).Value
                };
                break;
          
            default:
                throw new ArgumentOutOfRangeException(nbtTag.TagType.ToString());
        }
        
    }

    private void Save(object? sender, RoutedEventArgs e)
    {
        switch (NbtTag?.TagType)
        {
            case NbtTagType.Unknown:
                throw new ArgumentOutOfRangeException(nameof(NbtTag));
                break;
            case NbtTagType.End:
                throw new NotSupportedException();
                break;
            case NbtTagType.Byte:
                ((NbtByte)NbtTag).Value = ((NbtSetValueDialogueViewModel<byte>)DataContext!).Value;
                break;
            case NbtTagType.Short:
                ((NbtShort)NbtTag).Value = ((NbtSetValueDialogueViewModel<short>)DataContext!).Value;
                break;
            case NbtTagType.Int:
                ((NbtInt)NbtTag).Value = ((NbtSetValueDialogueViewModel<int>)DataContext!).Value;
                break;
            case NbtTagType.Long:
                ((NbtLong)NbtTag).Value = ((NbtSetValueDialogueViewModel<long>)DataContext!).Value;
                break;
            case NbtTagType.Float:
                ((NbtFloat)NbtTag).Value = ((NbtSetValueDialogueViewModel<float>)DataContext!).Value;
                break;
            case NbtTagType.Double:
                ((NbtDouble)NbtTag).Value = ((NbtSetValueDialogueViewModel<double>)DataContext!).Value;
                break;
            case NbtTagType.ByteArray:
                ((NbtByteArray)NbtTag).Value = ((NbtSetValueDialogueViewModel<byte[]>)DataContext!).Value;

                break;
            case NbtTagType.String:
                ((NbtString)NbtTag).Value = ((NbtSetValueDialogueViewModel<string>)DataContext!).Value;
                break; 
            default:
                throw new ArgumentOutOfRangeException();
        }
        Close();
    }

    private void Quit(object? sender, RoutedEventArgs e)
    {
        Close();
    }
}