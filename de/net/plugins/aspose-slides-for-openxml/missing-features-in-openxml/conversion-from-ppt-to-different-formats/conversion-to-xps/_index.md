---
title: Konvertierung zu XPS
type: docs
weight: 40
url: /de/net/conversion-to-xps/
---

**XPS**-Format wird ebenfalls häufig zum Austausch von Daten verwendet. Aspose.Slides für .NET berücksichtigt seine Bedeutung und bietet die integrierte Unterstützung zum Konvertieren einer Präsentation in ein XPS-Dokument.

Die von der Presentation‑Klasse bereitgestellte **Save**‑Methode kann verwendet werden, um die gesamte Präsentation in ein **XPS**‑Dokument zu konvertieren. Außerdem stellt die **XpsOptions**‑Klasse die Eigenschaft **SaveMetafileAsPng** bereit, die je nach Bedarf auf true oder false gesetzt werden kann.

``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string srcFileName = FilePath + "Conversion.pptx";

string destFileName = FilePath + "Converting to XPS.xps";

//Instantiate a Presentation object that represents a presentation file

Presentation pres = new Presentation(srcFileName);

//Saving the presentation to TIFF document

pres.Save(destFileName, Aspose.Slides.Export.SaveFormat.Xps);

``` 
## **Beispielcode herunterladen**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Converting%20to%20XPS%20%28Aspose.Slides%29.zip)