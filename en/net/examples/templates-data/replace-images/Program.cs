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
        foreach(var fixture in new[] { (Name: "portrait", Bytes: portrait), (Name: "landscape", Bytes: landscape) })
        {
            using var p=new Presentation("output/template.pptx");
            foreach(string name in new[]{"Contain","Crop"})
            {var frame=Example.Named<IPictureFrame>(p.Slides[0],name);var position=(frame.X,frame.Y,frame.Width,frame.Height);
             frame.PictureFormat.Picture.Image=p.Images.AddImage(PortableImage.Fit(fixture.Bytes, 500, 400, crop: name == "Crop"));
             preserved&=position==(frame.X,frame.Y,frame.Width,frame.Height);}
            p.Save("output/"+fixture.Name+".pptx",SaveFormat.Pptx);Example.Render(p,"output/"+fixture.Name+"-preview.png");
            using var reopened=new Presentation("output/"+fixture.Name+".pptx");
            Example.Require(Example.Named<IPictureFrame>(reopened.Slides[0],"Contain").Width==250,"Frame size changed.");
        }
        Example.Require(preserved,"Frame geometry changed.");Example.Result(new{frame_geometry_preserved=true,portrait_and_landscape_checked=true});
    }
}
