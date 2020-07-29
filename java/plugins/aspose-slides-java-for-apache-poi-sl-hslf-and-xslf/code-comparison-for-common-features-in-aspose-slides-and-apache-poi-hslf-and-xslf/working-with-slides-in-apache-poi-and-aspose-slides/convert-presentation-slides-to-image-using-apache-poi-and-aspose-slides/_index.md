---
title: Convert Presentation Slides to Image using Apache POI and Aspose.Slides
type: docs
weight: 30
url: /java/convert-presentation-slides-to-image-using-apache-poi-and-aspose-slides/
---

## **Microsoft PowerPoint - Convert Presentation Slides to Image**
Following are the steps involved for saving presentation slides as images.

1. Open the presentation you want its slides to be saved as images.
1. In the **File** menu, click **Save As Pictures...**.
1. Select the file format and provide desired name. 
1. Folder with the provided name will be created having separate image file(s) for each slide.
## **Aspose.Slides - Convert Presentation Slides to Image**
{{% alert color="primary" %}} 

The **save** method exposed by **Presentation** class can be called by developers to convert the whole presentation into TIFF document. Further, **TiffOptions** class exposes **imageSize** property enabling the developer to define the size of the image if required.

{{% /alert %}} 

Convert Presentation Slides to Image using Aspose.Slides

**Java**

{{< highlight java >}}

 //Instantiate a PresentationEx object that represents a PPTX file

Presentation pres = new Presentation("presentation.pptx");

//Instantiate the TiffOptions class

TiffOptions opts = new TiffOptions();

//Set Image Size

opts.setImageSize(new Dimension(500, 400));

//Save the presentation to TIFF with specified image size

pres.save("Aspose_PPT-TIFF.tiff", SaveFormat.Tiff, opts);

{{< /highlight >}}
## **Apache POI SL - Convert Presentation Slides to Image**
{{% alert color="primary" %}} 

Apache POI SL provides PPTX2PNG, an application that converts each slide of a .pptx slideshow into a PNG image.

{{% /alert %}} 

PPTX2PNG converting slides to images

**Java**

{{< highlight java >}}

 // Convert the slides to PNG files

PPTX2PNG.main(new String[]{"presentation.pptx"});

{{< /highlight >}}
## **Download Running Code**
- [CodePlex](https://asposeslidesjavaapachepoi.codeplex.com/releases/view/618722)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-Java/releases/tag/Aspose.Slides_Java_for_Apache_POI-v1.0.0)
## **Download Sample Code**
- [CodePlex](https://asposeslidesjavaapachepoi.codeplex.com/SourceControl/latest#src/main/java/com/aspose/slides/examples/featurescomparison/slides/convertslidetoimage/)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-Java/tree/master/Plugins/Aspose_Slides_for_Apache_POI/src/main/java/com/aspose/slides/examples/featurescomparison/slides/convertslidetoimage)

{{% alert color="primary" %}} 

For more details, visit [Converting Presentation to TIFF](http://www.aspose.com/docs/display/slidesjava/Converting+Presentation+to+TIFF).

{{% /alert %}}
