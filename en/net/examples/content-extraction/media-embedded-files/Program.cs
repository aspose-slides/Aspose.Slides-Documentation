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

internal static class Program
{
    private static ExampleContext Context = null!;
    private static Task<int> Main(string[] args) => ExampleBootstrap.RunAsync(args, async ctx =>
    {
        Context = ctx;
        Example.Context = ctx;
        ctx.BeginAction("content-extraction/media-embedded-files/block-001");
        RunExample();
        string path=File.Exists("output/result.json")?"output/result.json":"result.json";
        using var result=JsonDocument.Parse(File.ReadAllText(path));
        var checks=new System.Collections.Generic.Dictionary<string,bool>();
        if(ctx.IsLicensed)
        {
            using var expected=JsonDocument.Parse("{\"checks.embedded_payloads\":3,\"checks.external_links\":2,\"checks.payload_hashes_checked\":true,\"checks.path_escape_rejected\":true,\"checks.no_external_fetch\":true,\"checks.no_payload_execution\":true}");
            foreach(var field in expected.RootElement.EnumerateObject())
            {
                var actual=result.RootElement;foreach(string part in field.Name.Split('.'))actual=actual.GetProperty(part);
                ctx.Require(actual.ToString()==field.Value.ToString(),"Licensed assertion differs: "+field.Name);
                checks["licensed-"+field.Name.Replace('.','-')]=true;
            }
        }
        else
        {
            var values=result.RootElement.TryGetProperty("checks",out var nested)?nested:result.RootElement;
            foreach(var field in values.EnumerateObject())if(field.Value.ValueKind==JsonValueKind.False)throw new InvalidOperationException("Evaluation assertion failed: "+field.Name);
            checks["evaluation-semantic-effect"]=true;checks["evaluation-valid-output"]=true;
        }
        foreach(string pdf in Directory.GetFiles(".","*.pdf",SearchOption.AllDirectories))ctx.Require(File.ReadAllBytes(pdf).AsSpan(0,5).SequenceEqual(System.Text.Encoding.ASCII.GetBytes("%PDF-")),"Invalid PDF output.");
        foreach(string png in Directory.GetFiles(".","*.png",SearchOption.AllDirectories)){var image=PortableImage.Decode(File.ReadAllBytes(png));ctx.Require(image.Width>0&&image.Height>0,"Empty PNG output.");}
        ctx.Pass("content-extraction/media-embedded-files/block-001",checks);
        await Task.CompletedTask;
    });


    private sealed record Payload(int Slide,string Shape,string Kind,string File,string Sha256);
    private static string Extension(string contentType)=>contentType.ToLowerInvariant() switch
    {"audio/wav" or "audio/x-wav"=>"wav","audio/mpeg"=>"mp3","video/avi" or "video/x-msvideo" or "video/msvideo"=>"avi","video/mp4"=>"mp4",_=>"bin"};
    private static string SafeExtension(string extension)
    {string clean=extension.TrimStart('.');return clean.Length>0&&clean.Length<=12&&clean.All(char.IsLetterOrDigit)?clean.ToLowerInvariant():"bin";}
    private static byte[] Wav()
    {using var m=new MemoryStream();using var w=new BinaryWriter(m);w.Write(Encoding.ASCII.GetBytes("RIFF"));w.Write(36+1600);w.Write(Encoding.ASCII.GetBytes("WAVEfmt "));w.Write(16);w.Write((short)1);w.Write((short)1);w.Write(8000);w.Write(16000);w.Write((short)2);w.Write((short)16);w.Write(Encoding.ASCII.GetBytes("data"));w.Write(1600);w.Write(new byte[1600]);return m.ToArray();}
    private static byte[] Chunk(string name,byte[] data)
    {using var m=new MemoryStream();using var w=new BinaryWriter(m);w.Write(Encoding.ASCII.GetBytes(name));w.Write(data.Length);w.Write(data);if(data.Length%2!=0)w.Write((byte)0);return m.ToArray();}
    private static byte[] Bytes(Action<BinaryWriter> fill){using var m=new MemoryStream();using(var w=new BinaryWriter(m,Encoding.UTF8,true))fill(w);return m.ToArray();}
    private static byte[] Avi()
    {
        // One original 8x8 RGB frame in an uncompressed AVI container.
        byte[] frame=Enumerable.Repeat((byte)80,8*8*3).ToArray();
        byte[] avih=Bytes(w=>{w.Write(1000000);w.Write(frame.Length);w.Write(0);w.Write(0x10);w.Write(1);w.Write(0);w.Write(1);w.Write(frame.Length);w.Write(8);w.Write(8);w.Write(new byte[16]);});
        byte[] strh=Bytes(w=>{w.Write(Encoding.ASCII.GetBytes("vidsDIB "));w.Write(0);w.Write((short)0);w.Write((short)0);w.Write(0);w.Write(1);w.Write(1);w.Write(0);w.Write(1);w.Write(frame.Length);w.Write(-1);w.Write(0);w.Write((short)0);w.Write((short)0);w.Write((short)8);w.Write((short)8);});
        byte[] strf=Bytes(w=>{w.Write(40);w.Write(8);w.Write(8);w.Write((short)1);w.Write((short)24);w.Write(0);w.Write(frame.Length);w.Write(new byte[16]);});
        byte[] strl=Chunk("LIST",Encoding.ASCII.GetBytes("strl").Concat(Chunk("strh",strh)).Concat(Chunk("strf",strf)).ToArray());
        byte[] hdrl=Chunk("LIST",Encoding.ASCII.GetBytes("hdrl").Concat(Chunk("avih",avih)).Concat(strl).ToArray());
        byte[] movi=Chunk("LIST",Encoding.ASCII.GetBytes("movi").Concat(Chunk("00db",frame)).ToArray());
        return Chunk("RIFF",Encoding.ASCII.GetBytes("AVI ").Concat(hdrl).Concat(movi).ToArray());
    }
    private static void RunExample()
    {
        Example.Setup();byte[] audio=Wav(),video=Avi(),ole=Encoding.UTF8.GetBytes("Original embedded note – no executable content.\n");
        using(var p=new Presentation())
        {using var stream=new MemoryStream(audio);p.Slides[0].Shapes.AddAudioFrameEmbedded(20,20,60,60,stream).Name="../audio";
         p.Slides[0].Shapes.AddVideoFrame(100,20,100,80,p.Videos.AddVideo(video)).Name="Video";
         p.Slides[0].Shapes.AddOleObjectFrame(220,20,80,80,new OleEmbeddedDataInfo(ole,"txt")).Name="../note";
         p.Slides[0].Shapes.AddVideoFrame(320,20,100,80,"https://example.invalid/unfetched.mp4").Name="Linked video";
         p.Slides[0].Shapes.AddAudioFrameLinked(430,20,60,60,"https://example.invalid/unfetched.wav").Name="Linked audio";
         p.Save("output/input.pptx",SaveFormat.Pptx);}
        using var input=new Presentation("output/input.pptx");Directory.CreateDirectory("output/extracted");var rows=new List<Payload>();var links=new List<object>();
        void Save(int slide,IShape shape,string kind,string extension,byte[] data)
        {string name=kind+"-"+Example.Hash(data)+"."+extension;File.WriteAllBytes(Example.SafeOutput("output/extracted",name),data);rows.Add(new(slide,shape.Name,kind,"extracted/"+name,Example.Hash(data)));}
        for(int i=0;i<input.Slides.Count;i++)foreach(var shape in Example.Walk(input.Slides[i].Shapes))
        {if(shape is IAudioFrame a){if(a.EmbeddedAudio!=null)Save(i+1,shape,"audio",Extension(a.EmbeddedAudio.ContentType),a.EmbeddedAudio.BinaryData);else links.Add(new{slide=i+1,shape=shape.Name,url=a.LinkPathLong});}
         else if(shape is IVideoFrame v){if(v.EmbeddedVideo!=null)Save(i+1,shape,"video",Extension(v.EmbeddedVideo.ContentType),v.EmbeddedVideo.BinaryData);else links.Add(new{slide=i+1,shape=shape.Name,url=v.LinkPathLong});}
         else if(shape is IOleObjectFrame o){if(o.IsObjectLink)links.Add(new{slide=i+1,shape=shape.Name,url=o.LinkPathLong});else Save(i+1,shape,"ole",SafeExtension(o.EmbeddedData.EmbeddedFileExtension),o.EmbeddedData.EmbeddedFileData);}}
        Example.Json("output/manifest.json",new{payloads=rows,external_links=links});
        Example.Require(rows.Count==3&&links.Count==2,"Unexpected embedded/external resource counts.");
        Example.Require(rows.Select(x=>x.Sha256).ToHashSet().SetEquals(new[]{Example.Hash(audio),Example.Hash(video),Example.Hash(ole)}),"Payload bytes changed.");
        bool escaped=Example.Throws(()=>Example.SafeOutput("output/extracted","../escape.txt"));Example.Require(escaped,"Unsafe path accepted.");
        foreach(var row in rows)Example.Require(Example.HashFile("output/"+row.File)==row.Sha256,"Extracted bytes differ.");
        Example.Result(new{embedded_payloads=3,external_links=2,payload_hashes_checked=true,path_escape_rejected=escaped,no_external_fetch=true,no_payload_execution=true});
    }

}
