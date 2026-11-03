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
    private static ExampleContext Context = null!;

    private static Task<int> RunChecked(string[] args) => ExampleBootstrap.RunAsync(args, async ctx =>
    {
        Context = ctx;
        Example.Context = ctx;
        ctx.BeginAction("content-extraction/images/block-001");
        ExtractImages();
        string path=File.Exists("output/result.json")?"output/result.json":"result.json";
        using var result=JsonDocument.Parse(File.ReadAllText(path));
        var checks=new System.Collections.Generic.Dictionary<string,bool>();
        if(ctx.IsLicensed)
        {
            using var expected=JsonDocument.Parse("{\"checks.image_references\":3,\"checks.unique_images\":2,\"checks.external_links_reported\":1,\"checks.original_bytes_checked\":true,\"checks.no_network_fetch\":true}");
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
        ctx.Pass("content-extraction/images/block-001",checks);
        await Task.CompletedTask;
    });

    private static void VerifyExtraction(byte[] blue, byte[] orange, HashSet<string> seen, List<ImageRef> refs, List<object> links)
    {
        Example.Require(seen.SetEquals(new[]{Example.Hash(blue),Example.Hash(orange)}),"Original image bytes differ.");
        Example.Require(refs.Count==3&&seen.Count==2&&links.Count==1,"Deduplication or linked-resource policy differs.");
        foreach(var image in refs)Example.Require(Example.HashFile("output/"+image.File)==image.Sha256,"Saved image hash differs.");
        Example.Result(new{image_references=3,unique_images=2,external_links_reported=1,original_bytes_checked=true,no_network_fetch=true});
    }
}
