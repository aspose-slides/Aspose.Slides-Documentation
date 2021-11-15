---
title: Converting Presentation to PDF using Aspose.Slides
type: docs
weight: 10
url: /java/converting-presentation-to-pdf-using-aspose-slides/
---

## **Aspose.Slides - Conversion of Presentation to PDF**
{{% alert color="primary" %}} 

Aspose.Slides for Java offers the [Presentation](/pages/createpage.action?spaceKey=slidesjava&title=com.aspose.slides.Presentation+Class&linkCreation=true&fromPageId=9503610) class that represents a presentation file. The Presentation class exposes the Save method that can be called to convert the whole presentation into a PDF document. The [PdfOptions](/pages/createpage.action?spaceKey=slidesjava&title=com.aspose.slides.PdfOptions+Class&linkCreation=true&fromPageId=9503610) class provides options for creating the PDF such as JpegQuality, TextCompression, Compliance and others. These options can be used to get the desired standard of PDF.

{{% /alert %}} 

Converting presentation to PDF

**Java**

{{< highlight java >}}

 //Instantiate a Presentation object that represents a presentation file

Presentation pres = new Presentation("presentation.pptx");

//Saving the presentation to PDF document with default options

pres.save("AsposeConvert.pdf", SaveFormat.Pdf);

{{< /highlight >}}
## **Download Running Code**
- [CodePlex](https://asposeslidesjavaapachepoi.codeplex.com/releases/view/618722)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-Java/releases/tag/Aspose.Slides_Java_for_Apache_POI-v1.0.0)
## **Download Sample Code**
- [CodePlex](https://asposeslidesjavaapachepoi.codeplex.com/SourceControl/latest#src/main/java/com/aspose/slides/examples/asposefeatures/presentation/converttoPDF/AsposeConverter.java)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-Java/blob/master/Plugins/Aspose_Slides_for_Apache_POI/src/main/java/com/aspose/slides/examples/asposefeatures/presentation/converttoPDF/AsposeConverter.java)

{{% alert color="primary" %}} 

For more details, visit [Converting Presentation to PDF](/slides/java/convert-powerpoint-ppt-and-pptx-to-pdf/).

{{% /alert %}}
