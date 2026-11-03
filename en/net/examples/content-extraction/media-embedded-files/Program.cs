using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Text.Json;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.DOM.Ole;
using Aspose.Slides.Export;

internal static partial class Program
{
    private static Task<int> Main(string[] args) => RunChecked(args);

    private sealed record Payload(int Slide,string Shape,string Kind,string File,string Sha256);

    private static string Extension(string contentType)=>contentType.ToLowerInvariant() switch
    {"audio/wav" or "audio/x-wav"=>"wav","audio/mpeg"=>"mp3","video/avi" or "video/x-msvideo" or "video/msvideo"=>"avi","video/mp4"=>"mp4",_=>"bin"};

    private static string SafeExtension(string extension)
    {string clean=extension.TrimStart('.');return clean.Length>0&&clean.Length<=12&&clean.All(char.IsLetterOrDigit)?clean.ToLowerInvariant():"bin";}

    private static void ExtractMedia()
    {
        var (audio, video, ole) = CreateInput();
        using var input=new Presentation("output/input.pptx");Directory.CreateDirectory("output/extracted");var rows=new List<Payload>();var links=new List<object>();
        void Save(int slide,IShape shape,string kind,string extension,byte[] data)
        {
            string hash = Example.Hash(data);
            string name = $"{kind}-{hash}.{extension}";
            File.WriteAllBytes(Example.SafeOutput("output/extracted", name), data);
            rows.Add(new(slide, shape.Name, kind, "extracted/" + name, hash));
        }
        for(int i=0;i<input.Slides.Count;i++)foreach(var shape in Example.Walk(input.Slides[i].Shapes))
        {if(shape is IAudioFrame a){if(a.EmbeddedAudio!=null)Save(i+1,shape,"audio",Extension(a.EmbeddedAudio.ContentType),a.EmbeddedAudio.BinaryData);else links.Add(new{slide=i+1,shape=shape.Name,url=a.LinkPathLong});}
         else if(shape is IVideoFrame v){if(v.EmbeddedVideo!=null)Save(i+1,shape,"video",Extension(v.EmbeddedVideo.ContentType),v.EmbeddedVideo.BinaryData);else links.Add(new{slide=i+1,shape=shape.Name,url=v.LinkPathLong});}
         else if(shape is IOleObjectFrame o){if(o.IsObjectLink)links.Add(new{slide=i+1,shape=shape.Name,url=o.LinkPathLong});else Save(i+1,shape,"ole",SafeExtension(o.EmbeddedData.EmbeddedFileExtension),o.EmbeddedData.EmbeddedFileData);}}
        Example.Json("output/manifest.json",new{payloads=rows,external_links=links});
        VerifyExtraction(audio, video, ole, rows, links);
    }
}
