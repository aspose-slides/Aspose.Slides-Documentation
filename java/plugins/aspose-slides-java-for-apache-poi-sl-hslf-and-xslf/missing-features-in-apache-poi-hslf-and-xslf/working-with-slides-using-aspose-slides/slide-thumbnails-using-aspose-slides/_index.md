---
title: Slide Thumbnails using Aspose.Slides
type: docs
weight: 40
url: /java/slide-thumbnails-using-aspose-slides/
---

## **Aspose.Slides - Slide Thumbnails**
To generate the thumbnail of any desired slide using Aspose.Slides for Java:

1. Create an instance of the Presentation class.
1. Obtain the reference of any desired slide by using its ID or index.
1. Get the thumbnail image of the referenced slide on a specified scale.
1. Save the thumbnail image in any desired image format.

**Java**

{{< highlight java >}}

 //Instantiate a Presentation class that represents the PPTX file

Presentation pres = new Presentation(dataDir + "presentation.pptx");

//Access the first slide

ISlide sld = pres.getSlides().get_Item(0);

//Create a full scale image

BufferedImage image = sld.getThumbnail(1f, 1f);

//Save the image to disk in JPEG format

ImageIO.write(image,"jpeg",new File(dataDir + "AsposeThumbnail.jpg"));

{{< /highlight >}}
## **Download Running Code**
- [CodePlex](https://asposeslidesjavaapachepoi.codeplex.com/releases/view/618722)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-Java/releases/tag/Aspose.Slides_Java_for_Apache_POI-v1.0.0)
## **Download Sample Code**
- [CodePlex](https://asposeslidesjavaapachepoi.codeplex.com/SourceControl/latest#src/main/java/com/aspose/slides/examples/asposefeatures/slides/slidethumbnails/AsposeThumbnail.java)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-Java/blob/master/Plugins/Aspose_Slides_for_Apache_POI/src/main/java/com/aspose/slides/examples/asposefeatures/slides/slidethumbnails/AsposeThumbnail.java)

{{% alert color="primary" %}} 

For more details, visit [Creating Slides Thumbnail Image](http://docs.aspose.com:8082/docs/display/slidesjava/Creating+Slides+Thumbnail+Image).

{{% /alert %}}
