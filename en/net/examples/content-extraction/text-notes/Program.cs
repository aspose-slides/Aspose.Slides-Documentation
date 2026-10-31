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
        ctx.BeginAction("content-extraction/text-notes/block-001");
        RunExample();
        string path=File.Exists("output/result.json")?"output/result.json":"result.json";
        using var result=JsonDocument.Parse(File.ReadAllText(path));
        var checks=new System.Collections.Generic.Dictionary<string,bool>();
        if(ctx.IsLicensed)
        {
            using var expected=JsonDocument.Parse("{\"checks.slides_including_hidden\":2,\"checks.visible_slides\":1,\"checks.unicode_groups_empty_and_notes_checked\":true,\"checks.one_based_numbering\":true}");
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
        ctx.Pass("content-extraction/text-notes/block-001",checks);
        await Task.CompletedTask;
    });


    private sealed record TextItem(string Shape,string Text);
    private sealed record SlideText(int Number,bool Hidden,TextItem[] Text,string Notes);
    private static SlideText[] Extract(Presentation p,bool includeHidden)
    {return p.Slides.Cast<ISlide>().Select((s,i)=>(s,i)).Where(x=>includeHidden||!x.s.Hidden).Select(x=>new SlideText(x.i+1,x.s.Hidden,Example.Walk(x.s.Shapes).OfType<IAutoShape>().Select(s=>new TextItem(s.Name,s.TextFrame.Text)).ToArray(),x.s.NotesSlideManager.NotesSlide?.NotesTextFrame.Text??"")).ToArray();}
    private static void RunExample()
    {
        Example.Setup();using(var p=new Presentation())
        {var slide=p.Slides[0];Example.Text(slide.Shapes,"Title",Example.Choice("Résumé – 東京","東京 β"));var group=slide.Shapes.AddGroupShape();Example.Text(group.Shapes,"Group text",Example.Choice("Grouped α","α"));var nested=group.Shapes.AddGroupShape();Example.Text(nested.Shapes,"Nested text",Example.Choice("Nested β","β"));Example.Text(slide.Shapes,"Empty","");slide.NotesSlideManager.AddNotesSlide().NotesTextFrame.Text=Example.Choice("Speaker notes ✓","✓");
         var hidden=p.Slides.AddEmptySlide(p.LayoutSlides[0]);hidden.Hidden=true;Example.Text(hidden.Shapes,"Hidden text",Example.Choice("Hidden slide","Hide"));p.Save("output/input.pptx",SaveFormat.Pptx);}
        using var input=new Presentation("output/input.pptx");var all=Extract(input,true);var visible=Extract(input,false);
        Example.Json("output/text.json",new{presentation=Example.HashFile("output/input.pptx"),include_hidden=true,slides=all});
        Example.Require(all.Length==2 && visible.Length==1 && all[1].Number==2,"Slide number/hidden policy differs.");
        Example.Require(all[0].Text.Any(x=>x.Text==Example.Choice("Résumé – 東京","東京 β"))&&all[0].Text.Any(x=>x.Text==Example.Choice("Nested β","β"))&&all[0].Text.Any(x=>x.Text==""),"Unicode/group/empty text lost.");
        Example.Require(all[0].Notes.Contains(Example.Choice("Speaker notes ✓","✓")),"Notes lost.");Example.Result(new{slides_including_hidden=2,visible_slides=1,unicode_groups_empty_and_notes_checked=true,one_based_numbering=true});
    }

}
