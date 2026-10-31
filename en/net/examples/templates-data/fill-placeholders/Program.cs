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
        ctx.BeginAction("templates-data/fill-placeholders/block-001");
        RunExample();
        string path=File.Exists("output/result.json")?"output/result.json":"result.json";
        using var result=JsonDocument.Parse(File.ReadAllText(path));
        var checks=new System.Collections.Generic.Dictionary<string,bool>();
        if(ctx.IsLicensed)
        {
            using var expected=JsonDocument.Parse("{\"checks.marker_replaced\":true,\"checks.format_retained\":true,\"checks.missing_required_rejected\":true,\"checks.long_text_checked\":true,\"checks.input_unchanged\":true}");
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
        ctx.Pass("templates-data/fill-placeholders/block-001",checks);
        await Task.CompletedTask;
    });


    private static void Bind(ISlide slide,Dictionary<string,string> data)
    {
        if(!data.TryGetValue("Customer",out string? customer)||string.IsNullOrWhiteSpace(customer))throw new InvalidDataException("Customer is required.");
        foreach(var frame in Example.Frames(slide))
        {frame.ReplaceText("{{Customer}}",customer,new TextSearchOptions{CaseSensitive=true},null);
         frame.ReplaceText("{{Optional}}",data.GetValueOrDefault("Optional",""),new TextSearchOptions{CaseSensitive=true},null);
         frame.TextFrameFormat.AutofitType=TextAutofitType.Normal;}
        if(Example.Frames(slide).Any(f=>f.Text.Contains("{{")))throw new InvalidDataException("Unbound template marker.");
    }
    private static void RunExample()
    {
        Example.Setup();
        var values=JsonSerializer.Deserialize<Dictionary<string,string>>(File.ReadAllText("customer.json"))!;
        using(var template=new Presentation())
        {
            var title=Example.Text(template.Slides[0].Shapes,"Customer","",35,35,600,100);
            var p=title.TextFrame.Paragraphs[0];p.Portions.Clear();
            var prefix=new Portion("Customer: ");prefix.PortionFormat.FontBold=NullableBool.True;p.Portions.Add(prefix);
            p.Portions.Add(new Portion("{{Cus"));p.Portions.Add(new Portion("tomer}}"));
            foreach(var portion in p.Portions){portion.PortionFormat.LatinFont=new FontData("Noto Sans");portion.PortionFormat.FontHeight=24;portion.PortionFormat.FillFormat.FillType=FillType.Solid;portion.PortionFormat.FillFormat.SolidFillColor.Color=Color.FromArgb(35,65,100);}
            Example.Text(template.Slides[0].Shapes,"Optional","{{Optional}}",35,180,600,60);
            template.Save("output/template.pptx",SaveFormat.Pptx);
        }
        string before=Example.HashFile("output/template.pptx");
        using(var p=new Presentation("output/template.pptx"))
        {
            Bind(p.Slides[0],values);p.Save("output/filled.pptx",SaveFormat.Pptx);Example.Render(p,"output/preview.png");
        }
        using var check=new Presentation("output/filled.pptx");
        var shape=Example.Named<IAutoShape>(check.Slides[0],"Customer");
        Example.Require(shape.TextFrame.Text==Example.ExpectedText("Customer: "+values["Customer"]),"Run-spanning marker was not replaced.");
        Example.VerifySavedText("output/filled.pptx","Customer","Customer: "+values["Customer"]);
        Example.Require(shape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FontBold==NullableBool.True,"Prefix style changed.");
        bool missing=Example.Throws(()=>Bind(check.Slides[0],new Dictionary<string,string>()));
        using var longDeck=new Presentation("output/template.pptx");Bind(longDeck.Slides[0],new(){{"Customer",string.Join(" ",Enumerable.Repeat("Long customer name",8))}});
        var longShape=Example.Named<IAutoShape>(longDeck.Slides[0],"Customer");
        // Bounded application-side fitting keeps the text measurable before saving.
        longShape.TextFrame.TextFrameFormat.AutofitType=TextAutofitType.None;
        for(float size=24;size>=10;size--)
        {foreach(var paragraph in longShape.TextFrame.Paragraphs)foreach(var portion in paragraph.Portions)portion.PortionFormat.FontHeight=size;
         if(longShape.TextFrame.Paragraphs.Sum(p=>p.GetRect().Height)<=longShape.Height-12)break;}
        bool overflow=longShape.TextFrame.Paragraphs.Sum(p=>p.GetRect().Height)>longShape.Height-12;
        Example.Render(longDeck,"output/long-preview.png");Example.Require(!overflow,"Long text overflows the checked frame height.");
        Example.Require(Example.HashFile("output/template.pptx")==before,"Input changed.");
        Example.Result(new{marker_replaced=true,format_retained=true,missing_required_rejected=missing,long_text_checked=!overflow,input_unchanged=true});
    }

}
