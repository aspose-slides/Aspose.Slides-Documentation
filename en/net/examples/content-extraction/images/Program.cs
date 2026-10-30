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

    private sealed record ImageRef(int Slide,string Shape,string File,string Sha256);
    private static void Main()
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
