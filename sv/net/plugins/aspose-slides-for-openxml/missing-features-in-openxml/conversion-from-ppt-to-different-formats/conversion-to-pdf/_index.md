---
title: Konvertering till PDF
type: docs
weight: 30
url: /sv/net/conversion-to-pdf/
---
PDF-dokument används i stor utsträckning som ett standardformat för att utbyta dokument mellan organisationer, offentliga sektorer och individer. Det är ett populärt format, så utvecklare blir ofta ombedda att konvertera Microsoft PowerPoint-presentationer till PDF-dokument. Med tanke på detta möjliga behov stödjer Aspose.Slides för .NET att konvertera presentationer till PDF-dokument utan att använda någon annan komponent.

**Aspose.Slides for .NET** erbjuder Presentation-klassen som representerar en presentationsfil. **Presentation**-klassen exponerar Save-metoden som kan anropas för att konvertera hela presentationen till ett **PDF**-dokument. **PdfOptions**-klassen tillhandahåller alternativ för att skapa **PDF**-dokument, såsom JpegQuality, TextCompression, Compliance och andra. Dessa alternativ kan användas för att uppnå önskad PDF-standard.

``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string srcFileName = FilePath + "Conversion.pptx";

string destFileName = FilePath + "Converting to PDF.pdf";

//Skapa ett Presentation-objekt som representerar en presentationsfil

Presentation pres = new Presentation(srcFileName);

//Save the presentation to PDF with default options

pres.Save(destFileName, Aspose.Slides.Export.SaveFormat.Pdf);

``` 
## **Ladda ner exempelprogram**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Converting%20to%20PDF%20%28Aspose.Slides%29.zip)