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
```cs
//Instantiate the Presentation class that represents the presentation file
using (Presentation pres = new Presentation("Slides Test Presentation.pptx"))
{
    //Access the first slide
    ISlide sld = pres.Slides[0];

    //Create a full scale image
    using (IImage image = sld.GetImage(1f, 1f))
    {
        //Save the image to disk in JPEG format
        image.Save("Test Thumbnail.jpg", ImageFormat.Jpeg);
    }
}
``` 
## **Download Running Example**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Aspose.Slides%20Features%20missing%20in%20VSTO/Slide%20Thumbnail%20to%20JPEG)
## **Download Sample Code**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/Aspose.SlidesFeaturesmissingInVSTOv1.1)

{{% alert color="primary" %}} 

For more details, visit [Convert PPT and PPTX to JPG in .NET](/slides/net/convert-powerpoint-to-jpg/).

{{% /alert %}}
