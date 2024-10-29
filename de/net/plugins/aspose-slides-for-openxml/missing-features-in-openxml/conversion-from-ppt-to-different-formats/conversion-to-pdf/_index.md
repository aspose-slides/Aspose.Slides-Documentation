---
title: Konvertierung nach PDF
type: docs
weight: 30
url: /de/net/conversion-to-pdf/
---

PDF-Dokumente werden häufig als Standardformat für den Austausch von Dokumenten zwischen Organisationen, staatlichen Einrichtungen und Einzelpersonen verwendet. Es ist ein beliebtes Format, sodass Entwickler oft gebeten werden, Microsoft PowerPoint-Präsentationsdateien in PDF-Dokumente zu konvertieren. In Anbetracht dieses möglichen Bedarfs unterstützt Aspose.Slides für .NET die Konvertierung von Präsentationen in PDF-Dokumente, ohne dass ein anderes Element verwendet werden muss.

**Aspose.Slides für .NET** bietet die Klasse Presentation, die eine Präsentationsdatei darstellt. Die **Presentation**-Klasse stellt die Save-Methode bereit, die aufgerufen werden kann, um die gesamte Präsentation in ein **PDF**-Dokument zu konvertieren. Die **PdfOptions**-Klasse bietet Optionen zum Erstellen des **PDF**, wie z.B. JpegQuality, TextCompression, Compliance und andere. Diese Optionen können verwendet werden, um den gewünschten Standard für das PDF zu erreichen.

``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string srcFileName = FilePath + "Conversion.pptx";

string destFileName = FilePath + "Converting to PDF.pdf";

//Instanziere ein Presentation-Objekt, das eine Präsentationsdatei darstellt

Presentation pres = new Presentation(srcFileName);

//Speichere die Präsentation im PDF-Format mit den Standardoptionen

pres.Save(destFileName, Aspose.Slides.Export.SaveFormat.Pdf);

``` 
## **Beispielcode herunterladen**
- [Codeplex](https://asposeslidesopenxml.codeplex.com/releases/view/619597)
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Code.MSDN](https://code.msdn.microsoft.com/AsposeSlides-Features-9866600c)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Converting%20to%20PDF%20%28Aspose.Slides%29.zip)