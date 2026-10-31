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
        ctx.BeginAction("optimization-batch/compression/block-001");
        RunExample();
        string path=File.Exists("output/result.json")?"output/result.json":"result.json";
        using var result=JsonDocument.Parse(File.ReadAllText(path));
        var checks=new System.Collections.Generic.Dictionary<string,bool>();
        if(ctx.IsLicensed)
        {
            using var expected=JsonDocument.Parse("{\"checks.fixture_shrank\":true,\"checks.geometry_preserved\":true,\"checks.render_difference_within_limit\":true,\"checks.reopened\":true}");
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
        ctx.Pass("optimization-batch/compression/block-001",checks);
        await Task.CompletedTask;
    });


    private static double MeanDifference(string first,string second) => PortableImage.Difference(first,second);
    private static void RunExample()
    {
        Example.Setup();using(var p=new Presentation())
        {Example.Text(p.Slides[0].Shapes,"Title","Reduce an oversized raster image",30,20,620,60);
         p.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle,80,110,500,300,p.Images.AddImage(Example.Png(4000,2400,Color.Teal))).Name="Oversized image";
         p.Save("output/input.pptx",SaveFormat.Pptx);Example.Render(p,"output/before.png");}
        long before=new FileInfo("output/input.pptx").Length;
        bool compressed;
        using(var p=new Presentation("output/input.pptx"))
        {var frame=Example.Named<IPictureFrame>(p.Slides[0],"Oversized image");compressed=frame.PictureFormat.CompressImage(true,PicturesCompression.Dpi96);p.Save("output/compressed.pptx",SaveFormat.Pptx);Example.Render(p,"output/after.png");}
        long after=new FileInfo("output/compressed.pptx").Length;
        using var reopened=new Presentation("output/compressed.pptx");var picture=Example.Named<IPictureFrame>(reopened.Slides[0],"Oversized image");
        double difference=MeanDifference("output/before.png","output/after.png");
        Example.Require(compressed&&after<before,"The deliberately oversized fixture did not shrink.");
        Example.Require(picture.Width==500&&picture.Height==300&&reopened.Slides.Count==1,"Frame or slides changed.");
        Example.Require(difference<3,"Representative render changed too much.");
        Example.Json("output/measurements.json",new{before_bytes=before,after_bytes=after,mean_rgb_difference=difference,resolution="96 DPI"});
        Example.Result(new{fixture_shrank=true,geometry_preserved=true,render_difference_within_limit=true,reopened=true});
    }

}
