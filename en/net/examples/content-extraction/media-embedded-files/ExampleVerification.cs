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
        ctx.BeginAction("content-extraction/media-embedded-files/block-001");
        ExtractMedia();
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

    private static void VerifyExtraction(byte[] audio, byte[] video, byte[] ole, List<Payload> rows, List<object> links)
    {
        Example.Require(rows.Count==3&&links.Count==2,"Unexpected embedded/external resource counts.");
        Example.Require(rows.Select(x=>x.Sha256).ToHashSet().SetEquals(new[]{Example.Hash(audio),Example.Hash(video),Example.Hash(ole)}),"Payload bytes changed.");
        bool escaped=Example.Throws(()=>Example.SafeOutput("output/extracted","../escape.txt"));Example.Require(escaped,"Unsafe path accepted.");
        foreach(var row in rows)Example.Require(Example.HashFile("output/"+row.File)==row.Sha256,"Extracted bytes differ.");
        Example.Result(new{embedded_payloads=3,external_links=2,payload_hashes_checked=true,path_escape_rejected=escaped,no_external_fetch=true,no_payload_execution=true});
    }
}
