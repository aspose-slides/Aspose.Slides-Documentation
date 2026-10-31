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
        ctx.BeginAction("templates-data/replace-images/block-001");
        RunExample();
        string path=File.Exists("output/result.json")?"output/result.json":"result.json";
        using var result=JsonDocument.Parse(File.ReadAllText(path));
        var checks=new System.Collections.Generic.Dictionary<string,bool>();
        if(ctx.IsLicensed)
        {
            using var expected=JsonDocument.Parse("{\"checks.frame_geometry_preserved\":true,\"checks.portrait_and_landscape_checked\":true}");
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
        ctx.Pass("templates-data/replace-images/block-001",checks);
        await Task.CompletedTask;
    });


    private static byte[] Fit(byte[] bytes,int width,int height,bool crop) => PortableImage.Fit(bytes,width,height,crop);
    private static void RunExample()
    {
        Example.Setup();byte[] portrait=Example.Png(100,240,Color.DarkOrange),landscape=Example.Png(260,100,Color.Teal);
        File.WriteAllBytes("output/portrait.png",portrait);File.WriteAllBytes("output/landscape.png",landscape);
        using(var p=new Presentation())
        {
            var image=p.Images.AddImage(Example.Png(100,100,Color.SlateGray));
            p.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle,40,80,250,200,image).Name="Contain";
            p.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle,350,80,250,200,image).Name="Crop";
            p.Save("output/template.pptx",SaveFormat.Pptx);
        }
        bool preserved=true;
        foreach(var fixture in new[]{("portrait",portrait),("landscape",landscape)})
        {
            using var p=new Presentation("output/template.pptx");
            foreach(string name in new[]{"Contain","Crop"})
            {var frame=Example.Named<IPictureFrame>(p.Slides[0],name);var position=(frame.X,frame.Y,frame.Width,frame.Height);
             frame.PictureFormat.Picture.Image=p.Images.AddImage(Fit(fixture.Item2,500,400,name=="Crop"));
             preserved&=position==(frame.X,frame.Y,frame.Width,frame.Height);}
            p.Save("output/"+fixture.Item1+".pptx",SaveFormat.Pptx);Example.Render(p,"output/"+fixture.Item1+"-preview.png");
            using var reopened=new Presentation("output/"+fixture.Item1+".pptx");
            Example.Require(Example.Named<IPictureFrame>(reopened.Slides[0],"Contain").Width==250,"Frame size changed.");
        }
        Example.Require(preserved,"Frame geometry changed.");Example.Result(new{frame_geometry_preserved=true,portrait_and_landscape_checked=true});
    }

}
