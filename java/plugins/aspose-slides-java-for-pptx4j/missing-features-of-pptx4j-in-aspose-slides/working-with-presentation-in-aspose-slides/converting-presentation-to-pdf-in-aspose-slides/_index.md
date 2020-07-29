---
title: Converting Presentation to PDF in Aspose.Slides
type: docs
weight: 10
url: /java/converting-presentation-to-pdf-in-aspose-slides/
---

## **Aspose.Slides - Converting Presentation to PDF**
Aspose.Slides for Java offers the [Presentation](http://www.aspose.com/docs/display/slidesjava/com.aspose.slides.Presentation+class) class that represents a presentation file. The Presentation class exposes the Save method that can be called to convert the whole presentation into a PDF document. The [PdfOptions](http://www.aspose.com/docs/display/slidesjava/com.aspose.slides.PdfOptions+class) class provides options for creating the PDF such as JpegQuality, TextCompression, Compliance and others. These options can be used to get the desired standard of PDF.

**Java**

{{< highlight java >}}

 //Instantiate a Presentation object that represents a PPT file

Presentation pres = new Presentation(dataDir + "presentation.ppt");

//Saving the presentation to PDF document

pres.save(dataDir + "AsposeConvert.pdf", SaveFormat.Pdf);

{{< /highlight >}}
## **Download Running Code**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-Java/releases)
- [CodePlex](https://asposeslidesjavapptx4j.codeplex.com/releases)
## **Download Sample Code**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-Java)
- [CodePlex](https://asposeslidesjavapptx4j.codeplex.com/)

{{% alert color="primary" %}} 

For more details, visit [Converting Presentation to PDF](http://www.aspose.com/docs/display/slidesjava/Converting+Presentation+to+PDF).

{{% /alert %}}
