---
title: Render Slide as Thumbnail to JPEG
type: docs
weight: 60
url: /net/render-slide-as-thumbnail-to-jpeg/
---

**Aspose.Slides for .NET** is used to create presentation files containing slides. These slides can be viewed by opening presentation files using Microsoft PowerPoint. But sometimes, developers may need to view slides as images using their favorite image viewer. In such cases, Aspose.Slides for .NET help you generate thumbnail images of the slides.

To generate the thumbnail of any desired slide using Aspose.Slides for .NET:

1. Create an instance of the **Presentation** class.
1. Obtain the reference of any desired slide by using its ID or index.
1. Get the thumbnail image of the referenced slide on a specified scale.
1. Save the thumbnail image in any desired image format.

``` csharp
string filePath = @"..\..\..\Sample Files\";
string srcFileName = filePath + "Slide Thumbnail to JPEG.pptx";
string destFileName = filePath + "Slide Thumbnail to JPEG.jpg";

//Instantiate the Presentation class that represents the presentation file
using (Presentation pres = new Presentation(srcFileName))
{
    //Access the first slide
    ISlide sld = pres.Slides[0];

    //Create a full scale image
    using (IImage image = sld.GetImage(1f, 1f))
    {
        //Save the image to disk in JPEG format
        image.Save(destFileName, ImageFormat.Jpeg);
    }
}
``` 

## **Download Sample Code**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Slide%20Thumbnail%20to%20JPEG%20%28Aspose.Slides%29.zip)
