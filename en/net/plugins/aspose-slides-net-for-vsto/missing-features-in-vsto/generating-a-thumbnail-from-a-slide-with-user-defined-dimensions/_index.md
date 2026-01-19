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
```cs
//Instantiate the Presentation class that represents the presentation file
using (Presentation pres = new Presentation("TestPresentation.pptx"))
{
    //Access the first slide
    ISlide sld = pres.Slides[0];

    //User defined dimension
    int desiredX = 1200;
    int desiredY = 800;

    //Getting scaled value  of X and Y
    float scaleX = (float)(1.0 / pres.SlideSize.Size.Width) * desiredX;
    float scaleY = (float)(1.0 / pres.SlideSize.Size.Height) * desiredY;

    //Create a full scale image
    using (IImage image = sld.GetImage(scaleX, scaleY))
    {
        //Save the image to disk in JPEG format
        image.Save("Thumbnail2.jpg", ImageFormat.Jpeg);
    }
}
``` 
## **Download Running Example**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Aspose.Slides%20Features%20missing%20in%20VSTO/User%20Defined%20Thumbnail)
## **Download Sample Code**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/Aspose.SlidesFeaturesmissingInVSTOv1.1)

{{% alert color="primary" %}} 

For more details, visit [Convert Slide](/slides/net/convert-slide/).

{{% /alert %}}
