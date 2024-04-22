---
title: Slide Thumbnails in Aspose.Slides
type: docs
weight: 40
url: /java/slide-thumbnails-in-aspose-slides/
---

## **Aspose.Slides - Slide Thumbnails**
To generate the thumbnail of any desired slide using Aspose.Slides for Java:

1. Create an instance of the Presentation class.
1. Obtain the reference of any desired slide by using its ID or index.
1. Get the thumbnail image of the referenced slide on a specified scale.
1. Save the thumbnail image in any desired image format.

**Java**

``` java

 //Instantiate a Presentation class that represents the PPTX file

Presentation pres = new Presentation(dataDir + "presentation.pptx");

//Access the first slide

ISlide sld = pres.getSlides().get_Item(0);

//Create a full scale image

IImage slideImage = sld.getImage(1f, 1f);

//Save the image to disk in JPEG format
try {
     // save the image on the disk.
      slideImage.save("AsposeThumbnail.jpg", ImageFormat.Jpeg);
} finally {
     if (slideImage != null) slideImage.dispose();
}

```
## **Download Running Code**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-Java/releases)
- [CodePlex](https://asposeslidesjavapptx4j.codeplex.com/releases)
## **Download Sample Code**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-Java)
- [CodePlex](https://asposeslidesjavapptx4j.codeplex.com/)

{{% alert color="primary" %}} 

For more details, visit [Creating Slides Thumbnail Image](http://docs.aspose.com:8082/docs/display/slidesjava/Creating+Slides+Thumbnail+Image).

{{% /alert %}}
