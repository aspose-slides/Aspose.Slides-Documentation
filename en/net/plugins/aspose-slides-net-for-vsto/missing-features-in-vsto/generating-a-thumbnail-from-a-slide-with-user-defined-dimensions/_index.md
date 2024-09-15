---
title: Generating a Thumbnail from a Slide with User Defined Dimensions
type: docs
weight: 100
url: /net/generating-a-thumbnail-from-a-slide-with-user-defined-dimensions/
---

To generate the thumbnail of any desired slide using Aspose.Slides for .NET:

- Create an instance of the Presentation class.
- Obtain the reference of any desired slide by using its ID or index.
- Get the X and Y scaling factors based on user defined X and Y dimensions.
- Get the thumbnail image of the referenced slide on a specified scale.
- Save the thumbnail image in any desired image format.
## **Example**
``` 

 //Instantiate a Presentation class that represents the presentation file

using (Presentation pres = new Presentation("TestPresentation.pptx"))

{

  //Access the first slide

  ISlide sld = pres.Slides[0];

  //User defined dimension

  int desiredX = 1200;

  int desiredY = 800;

  //Getting scaled value  of X and Y

  float ScaleX = (float)(1.0 / pres.SlideSize.Size.Width) * desiredX;

  float ScaleY = (float)(1.0 / pres.SlideSize.Size.Height) * desiredY;

  //Create a full scale image

  Bitmap bmp = sld.GetThumbnail(ScaleX, ScaleY);

  //Save the image to disk in JPEG format

  bmp.Save("Thumbnail2.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);

``` 
## **Download Running Example**
- [CodePlex](https://asposeslidesvsto.codeplex.com/SourceControl/latest#Aspose.Slides Features missing in VSTO/User Defined Thumbnail/)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Aspose.Slides%20Features%20missing%20in%20VSTO/User%20Defined%20Thumbnail)
- [Code.MSDN](https://code.msdn.microsoft.com/AsposeSlides-Features-78d1d03d/view/SourceCode)
## **Download Sample Code**
- [CodePlex](https://asposeslidesvsto.codeplex.com/releases/view/620001)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/Aspose.SlidesFeaturesmissingInVSTOv1.1)
- [Code.MSDN](https://code.msdn.microsoft.com/AsposeSlides-Features-78d1d03d#content)

{{% alert color="primary" %}} 

For more details, visit [Creating Slides Thumbnail Image](/slides/net/presentation-viewer/#creating-slides-thumbnail-image).

{{% /alert %}}
