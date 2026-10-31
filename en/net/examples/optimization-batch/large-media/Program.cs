using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
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
using Aspose.Slides.LowCode;
using Aspose.Slides.Warnings;

internal static class Program
{
    private static ExampleContext Context = null!;
    private static Task<int> Main(string[] args) => ExampleBootstrap.RunAsync(args, async ctx =>
    {
        Context = ctx;
        Example.Context = ctx;
        ctx.BeginAction("optimization-batch/large-media/block-001");
        RunExample();
        string path=File.Exists("output/result.json")?"output/result.json":"result.json";
        using var result=JsonDocument.Parse(File.ReadAllText(path));
        var checks=new System.Collections.Generic.Dictionary<string,bool>();
        if(ctx.IsLicensed)
        {
            using var expected=JsonDocument.Parse("{\"checks.media_bytes_preserved\":true,\"checks.input_unlocked_after_disposal\":true,\"checks.temp_files_cleaned\":true,\"checks.memory_measurement_recorded\":true}");
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
        ctx.Pass("optimization-batch/large-media/block-001",checks);
        await Task.CompletedTask;
    });


    private static void WriteWav(string path,int samples)
    {
        using var stream=File.Create(path);using var writer=new BinaryWriter(stream);
        writer.Write(Encoding.ASCII.GetBytes("RIFF"));writer.Write(36+samples*2);writer.Write(Encoding.ASCII.GetBytes("WAVEfmt "));writer.Write(16);writer.Write((short)1);writer.Write((short)1);writer.Write(8000);writer.Write(16000);writer.Write((short)2);writer.Write((short)16);writer.Write(Encoding.ASCII.GetBytes("data"));writer.Write(samples*2);
        var random=new Random(17);var buffer=new byte[65536];int remaining=samples*2;while(remaining>0){random.NextBytes(buffer);int count=Math.Min(buffer.Length,remaining);writer.Write(buffer,0,count);remaining-=count;}
    }
    private static void RunExample()
    {
        Example.Setup();WriteWav("output/original.wav",4*1024*1024);
        using(var audio=File.OpenRead("output/original.wav"))using(var p=new Presentation())
        {p.Slides[0].Shapes.AddAudioFrameEmbedded(40,40,80,80,audio);p.Save("output/input.pptx",SaveFormat.Pptx);}
        string temp=Path.GetFullPath("output/blob-temp");Directory.CreateDirectory(temp);
        long baseline=Process.GetCurrentProcess().WorkingSet64;var watch=Stopwatch.StartNew();
        var options=new LoadOptions{BlobManagementOptions=new BlobManagementOptions{PresentationLockingBehavior=PresentationLockingBehavior.KeepLocked,IsTemporaryFilesAllowed=true,TempFilesRootPath=temp,MaxBlobsBytesInMemory=1024}};
        using(var p=new Presentation("output/input.pptx",options)){p.Save("output/processed.pptx",SaveFormat.Pptx);}
        watch.Stop();using(var exclusive=File.Open("output/input.pptx",FileMode.Open,FileAccess.ReadWrite,FileShare.None)){}
        int remainingFiles=Directory.GetFiles(temp,"*",SearchOption.AllDirectories).Length;
        using var result=new Presentation("output/processed.pptx");byte[] actual=result.Slides[0].Shapes.OfType<IAudioFrame>().Single().EmbeddedAudio.BinaryData;
        Example.Require(Example.Hash(actual)==Example.HashFile("output/original.wav"),"Audio changed.");Example.Require(remainingFiles==0,"BLOB temporary files remain after disposal.");
        Example.Json("output/measurements.json",new{audio_bytes=actual.Length,baseline_working_set=baseline,process_peak_working_set=Process.GetCurrentProcess().PeakWorkingSet64,processing_elapsed_ms=watch.ElapsedMilliseconds,temp_files_after_disposal=remainingFiles,operating_system=System.Runtime.InteropServices.RuntimeInformation.OSDescription,runtime=System.Runtime.InteropServices.RuntimeInformation.FrameworkDescription});
        Example.Result(new{media_bytes_preserved=true,input_unlocked_after_disposal=true,temp_files_cleaned=true,memory_measurement_recorded=true});
    }

}
