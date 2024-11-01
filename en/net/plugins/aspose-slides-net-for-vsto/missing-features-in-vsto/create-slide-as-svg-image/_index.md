---
title: Create Slide as SVG Image
type: docs
weight: 70
url: /net/create-slide-as-svg-image/
---

To generate an SVG image from any desired slide with Aspose.Slides.Pptx for .NET, please follow the steps below:

- Create an instance of the Presentation class.
- Obtain the desired slide's reference by using its ID or index.
- Get the SVG image in a memory stream.
- Save the memory stream to file.
## **Example**

```

 //Instantiate a Presentation class that represents the presentation file

using (Presentation pres = new Presentation("Slides Test Presentation.pptx"))

{

   //Access the second slide

   ISlide sld = pres.Slides[1];

   //Create a memory stream object

   MemoryStream SvgStream = new MemoryStream();

   //Generate SVG image of slide and save in memory stream

   sld.WriteAsSvg(SvgStream);

   SvgStream.Position = 0;

   //Save memory stream to file

   using (Stream fileStream = System.IO.File.OpenWrite("PresentatoinTemplate.svg"))

   {

     byte[] buffer = new byte[8 * 1024];

     int len;

     while ((len = SvgStream.Read(buffer, 0, buffer.Length)) > 0)

     {

       fileStream.Write(buffer, 0, len);

     }

}

SvgStream.Close();

``` 
## **Download Running Example**
- [CodePlex](https://asposeslidesvsto.codeplex.com/SourceControl/latest#Aspose.Slides Features missing in VSTO/Creating Slide SVG Image/)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Aspose.Slides%20Features%20missing%20in%20VSTO/Creating%20Slide%20SVG%20Image)
- [Code.MSDN](https://code.msdn.microsoft.com/AsposeSlides-Features-78d1d03d/view/SourceCode)
## **Download Sample Code**
- [CodePlex](https://asposeslidesvsto.codeplex.com/releases/view/620001)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/Aspose.SlidesFeaturesmissingInVSTOv1.1)
- [Code.MSDN](https://code.msdn.microsoft.com/AsposeSlides-Features-78d1d03d#content)

{{% alert color="primary" %}} 

For more details, visit [Creating Slide SVG Image](/slides/net/presentation-viewer/).

{{% /alert %}}
