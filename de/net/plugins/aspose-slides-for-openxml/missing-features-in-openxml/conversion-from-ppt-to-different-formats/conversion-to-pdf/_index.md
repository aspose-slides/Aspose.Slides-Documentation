---
title: Konvertierung zu PDF
type: docs
weight: 30
url: /de/net/conversion-to-pdf/
---

PDF‑Dokumente werden häufig als Standardformat für den Austausch von Dokumenten zwischen Organisationen, Regierungssektoren und Einzelpersonen verwendet. Es ist ein beliebtes Format, sodass Entwickler oft gebeten werden, Microsoft PowerPoint‑Präsentationsdateien in PDF‑Dokumente zu konvertieren. Da diese Anforderung möglich ist, unterstützt Aspose.Slides für .NET die Konvertierung von Präsentationen in PDF‑Dokumente, ohne ein weiteres Bauteil zu verwenden.

**Aspose.Slides für .NET** bietet die Klasse Presentation, die eine Präsentationsdatei darstellt. Die **Presentation**‑Klasse stellt die Methode Save bereit, die aufgerufen werden kann, um die gesamte Präsentation in ein **PDF**‑Dokument zu konvertieren. Die Klasse **PdfOptions** bietet Optionen für die Erstellung des **PDF**, wie JpegQuality, TextCompression, Compliance und weitere. Diese Optionen können verwendet werden, um den gewünschten PDF‑Standard zu erreichen.

``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string srcFileName = FilePath + "Conversion.pptx";

string destFileName = FilePath + "Converting to PDF.pdf";

//Instantiate a Presentation object that represents a presentation file

Presentation pres = new Presentation(srcFileName);

//Save the presentation to PDF with default options

pres.Save(destFileName, Aspose.Slides.Export.SaveFormat.Pdf);

``` 
## **Download Sample Code**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Converting%20to%20PDF%20%28Aspose.Slides%29.zip)