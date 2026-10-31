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
        ctx.BeginAction("content-extraction/images/block-001");
        RunExample();
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


    private sealed record ImageRef(int Slide,string Shape,string File,string Sha256);
    private static void RunExample()
    {
        Example.Setup();byte[] blue=Example.Png(120,80,Color.Blue),orange=Example.Png(80,120,Color.Orange);
        using(var p=new Presentation())
        {var shared=p.Images.AddImage(blue);p.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle,20,20,120,80,shared).Name="First";p.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle,160,20,120,80,shared).Name="Duplicate";var other=p.Slides.AddEmptySlide(p.LayoutSlides[0]);other.Shapes.AddPictureFrame(ShapeType.Rectangle,20,20,80,120,p.Images.AddImage(orange)).Name="Second image";
         var linked=other.Shapes.AddPictureFrame(ShapeType.Rectangle,150,20,80,80,shared);linked.Name="External";linked.PictureFormat.Picture.LinkPathLong="https://example.invalid/unfetched.png";p.Save("output/input.pptx",SaveFormat.Pptx);}
        using var input=new Presentation("output/input.pptx");Directory.CreateDirectory("output/images");var seen=new HashSet<string>();var refs=new List<ImageRef>();var links=new List<object>();
        for(int i=0;i<input.Slides.Count;i++)foreach(var shape in Example.Walk(input.Slides[i].Shapes).OfType<IPictureFrame>())
        {
            var picture=shape.PictureFormat.Picture;if(!string.IsNullOrWhiteSpace(picture.LinkPathLong)){links.Add(new{slide=i+1,shape=shape.Name,url=picture.LinkPathLong});continue;}
            byte[] data=picture.Image.BinaryData;string hash=Example.Hash(data),name=hash+".png";if(seen.Add(hash))File.WriteAllBytes(Example.SafeOutput("output/images",name),data);refs.Add(new ImageRef(i+1,shape.Name,"images/"+name,hash));
        }
        Example.Json("output/images.json",new{images=refs,external_links=links});
        Example.Require(seen.SetEquals(new[]{Example.Hash(blue),Example.Hash(orange)}),"Original image bytes differ.");
        Example.Require(refs.Count==3&&seen.Count==2&&links.Count==1,"Deduplication or linked-resource policy differs.");
        foreach(var image in refs)Example.Require(Example.HashFile("output/"+image.File)==image.Sha256,"Saved image hash differs.");
        Example.Result(new{image_references=3,unique_images=2,external_links_reported=1,original_bytes_checked=true,no_network_fetch=true});
    }

}
