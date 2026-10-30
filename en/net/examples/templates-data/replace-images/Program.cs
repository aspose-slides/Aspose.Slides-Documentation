using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Runtime.Versioning;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.DOM.Ole;
using Aspose.Slides.Export;

[SupportedOSPlatform("windows")]
internal static class Program
{

    private static byte[] Fit(byte[] bytes,int width,int height,bool crop)
    {
        using var sourceStream=new MemoryStream(bytes);using var source=System.Drawing.Image.FromStream(sourceStream);
        using var canvas=new Bitmap(width,height);using var g=Graphics.FromImage(canvas);g.Clear(Color.White);
        float scale=crop?Math.Max((float)width/source.Width,(float)height/source.Height):Math.Min((float)width/source.Width,(float)height/source.Height);
        float w=source.Width*scale,h=source.Height*scale;g.DrawImage(source,(width-w)/2,(height-h)/2,w,h);
        using var output=new MemoryStream();canvas.Save(output,System.Drawing.Imaging.ImageFormat.Png);return output.ToArray();
    }
    private static void Main()
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
