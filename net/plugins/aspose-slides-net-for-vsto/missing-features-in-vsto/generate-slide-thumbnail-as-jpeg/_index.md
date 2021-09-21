---
title: Generate Slide Thumbnail as JPEG
type: docs
weight: 90
url: /net/generate-slide-thumbnail-as-jpeg/
---

To generate the thumbnail of any desired slide using Aspose.Slides for .NET:

- Create an instance of the Presentation class.
- Obtain the reference of any desired slide by using its ID or index.
- Get the thumbnail image of the referenced slide on a specified scale.
- Save the thumbnail image in any desired image format.
## **Example**
``` 

 //Instantiate a Presentation class that represents the presentation file

using (Presentation pres = new Presentation("Slides Test Presentation.pptx"))

{

  //Access the first slide

  ISlide sld = pres.Slides[0];

  //Create a full scale image

  Bitmap bmp = sld.GetThumbnail(1f, 1f);

  //Save the image to disk in JPEG format

  bmp.Save("Test Thumbnail.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);

``` 
## **Download Running Example**
- [CodePlex](https://asposeslidesvsto.codeplex.com/SourceControl/latest#Aspose.Slides Features missing in VSTO/Slide Thumbnail to JPEG/)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Aspose.Slides%20Features%20missing%20in%20VSTO/Slide%20Thumbnail%20to%20JPEG)
- [Code.MSDN](https://code.msdn.microsoft.com/AsposeSlides-Features-78d1d03d/view/SourceCode)
## **Download Sample Code**
- [CodePlex](https://asposeslidesvsto.codeplex.com/releases/view/620001)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/Aspose.SlidesFeaturesmissingInVSTOv1.1)
- [Code.MSDN](https://code.msdn.microsoft.com/AsposeSlides-Features-78d1d03d#content)

{{% alert color="primary" %}} 

For more details, visit [Creating Slides Thumbnail Image](/slides/net/presentation-viewer/#presentationviewer-creatingslidesthumbnailimage).

{{% /alert %}}
