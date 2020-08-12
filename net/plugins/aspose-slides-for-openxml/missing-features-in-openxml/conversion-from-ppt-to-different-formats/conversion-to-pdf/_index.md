---
title: Conversion to PDF
type: docs
weight: 30
url: /net/conversion-to-pdf/
---

PDF documents are widely used as a standard format of exchanging documents between organizations, government sectors and individuals. It's a popular format so developers are often asked to convert Microsoft PowerPoint presentation files to PDF documents. Realizing this possible requirement, Aspose.Slides for .NET supports converting presentations to PDF documents without using any other component.

**Aspose.Slides for .NET** offers the Presentation class that represents a presentation file. The **Presentation** class exposes the Save method that can be called to convert the whole presentation into a **PDF** document. The **PdfOptions** class provides options for creating the **PDF** such as JpegQuality, TextCompression, Compliance and others. These options can be used to get the desired standard of PDF.

```

 string FilePath = @"..\..\..\Sample Files\";

string srcFileName = FilePath + "Conversion.pptx";

string destFileName = FilePath + "Converting to PDF.pdf";

//Instantiate a Presentation object that represents a presentation file

Presentation pres = new Presentation(srcFileName);

//Save the presentation to PDF with default options

pres.Save(destFileName, Aspose.Slides.Export.SaveFormat.Pdf);

```
## **Download Sample Code**
- [Codeplex](https://asposeslidesopenxml.codeplex.com/releases/view/619597)
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Code.MSDN](https://code.msdn.microsoft.com/AsposeSlides-Features-9866600c)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Converting%20to%20PDF%20%28Aspose.Slides%29.zip)
