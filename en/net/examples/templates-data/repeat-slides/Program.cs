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
        ctx.BeginAction("templates-data/repeat-slides/block-001");
        RunExample();
        string path=File.Exists("output/result.json")?"output/result.json":"result.json";
        using var result=JsonDocument.Parse(File.ReadAllText(path));
        var checks=new System.Collections.Generic.Dictionary<string,bool>();
        if(ctx.IsLicensed)
        {
            using var expected=JsonDocument.Parse("{\"checks.slide_count\":2,\"checks.order_preserved\":true,\"checks.no_template_slide\":true,\"checks.no_state_leak\":true,\"checks.semantic_repeatability\":true,\"checks.duplicate_name_rejected\":true}");
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
        ctx.Pass("templates-data/repeat-slides/block-001",checks);
        await Task.CompletedTask;
    });


    private sealed record Customer(string Name,double Amount,string Color);
    private static string[] Generate(Customer[] customers,string path)
    {
        using var p=new Presentation();var template=p.Slides[0];
        Example.Text(template.Shapes,"Customer","{{Customer}}",35,20,600,70);Example.Chart(template,"Sales");
        template.Shapes.AddPictureFrame(ShapeType.Rectangle,600,15,60,60,p.Images.AddImage(Example.Png(60,60,Color.Gray))).Name="Logo";
        foreach(var customer in customers)
        {var slide=p.Slides.AddClone(template);Example.Named<IAutoShape>(slide,"Customer").TextFrame.ReplaceText("{{Customer}}",customer.Name,new TextSearchOptions(),null);
         Example.ChartData(Example.Named<IChart>(slide,"Sales"),new[]{"Sales"},new[]{customer.Name},new[]{new[]{customer.Amount}});
         Example.Named<IPictureFrame>(slide,"Logo").PictureFormat.Picture.Image=p.Images.AddImage(Example.Png(60,60,Color.FromName(customer.Color)));}
        p.Slides.Remove(template);Example.Require(p.Slides.Count==customers.Length,"Default/template slide leaked.");
        if(customers.Length==0)return Array.Empty<string>();
        p.Save(path,SaveFormat.Pptx);Example.Render(p,path+".png");using var reopened=new Presentation(path);
        var values=reopened.Slides.Cast<ISlide>().Select(s=>Example.Named<IAutoShape>(s,"Customer").TextFrame.Text).ToArray();
        for(int i=0;i<customers.Length;i++)Example.Require(Convert.ToDouble(Example.Named<IChart>(reopened.Slides[i],"Sales").ChartData.Series[0].DataPoints[0].Value.Data)==customers[i].Amount,"Record state leaked.");return values;
    }
    private static void RunExample()
    {
        Example.Setup();var data=JsonSerializer.Deserialize<Customer[]>(File.ReadAllText("customers.json"))!;
        if(!Context.IsLicensed)data=data.Select((c,i)=>c with{Name=i==0?"Acme":"東京"}).ToArray();
        var first=Generate(data,"output/report.pptx");var second=Generate(data,"output/repeated.pptx");
        Example.Require(first.SequenceEqual(data.Select(c=>c.Name))&&first.SequenceEqual(second),"Order or repeatability differs.");
        Example.Require(Generate(Array.Empty<Customer>(),"output/empty.pptx").Length==0,"Empty data not handled.");
        using var duplicate=new Presentation();Example.Text(duplicate.Slides[0].Shapes,"Duplicate","A");Example.Text(duplicate.Slides[0].Shapes,"Duplicate","B");
        bool rejected=Example.Throws(()=>Example.Named<IAutoShape>(duplicate.Slides[0],"Duplicate"));Example.Require(rejected,"Duplicate name accepted.");
        Example.Result(new{slide_count=data.Length,order_preserved=true,no_template_slide=true,no_state_leak=true,semantic_repeatability=true,duplicate_name_rejected=rejected});
    }

}
