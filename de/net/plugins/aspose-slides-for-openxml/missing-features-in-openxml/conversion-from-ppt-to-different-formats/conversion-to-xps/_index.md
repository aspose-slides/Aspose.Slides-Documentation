---
title: Konvertierung zu XPS
type: docs
weight: 40
url: /de/net/conversion-to-xps/
---

**XPS**-Format wird ebenfalls häufig für den Austausch von Daten verwendet. Aspose.Slides für .NET erkennt dessen Bedeutung und bietet die integrierte Unterstützung für die Konvertierung einer Präsentation in ein XPS-Dokument.

Die **Save**-Methode, die von der Präsentationsklasse bereitgestellt wird, kann verwendet werden, um die gesamte Präsentation in ein **XPS**-Dokument zu konvertieren. Darüber hinaus bietet die **XpsOptions**-Klasse die **SaveMetafileAsPng**-Eigenschaft, die je nach Anforderung auf true oder false gesetzt werden kann.

``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string srcFileName = FilePath + "Conversion.pptx";

string destFileName = FilePath + "Converting to XPS.xps";

//Erstellen Sie ein Präsentationsobjekt, das eine Präsentationsdatei repräsentiert

Presentation pres = new Presentation(srcFileName);

//Speichern der Präsentation als TIFF-Dokument

pres.Save(destFileName, Aspose.Slides.Export.SaveFormat.Xps);

``` 
## **Beispielcode herunterladen**
- [Codeplex](https://asposeslidesopenxml.codeplex.com/releases/view/619597)
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Code.MSDN](https://code.msdn.microsoft.com/AsposeSlides-Features-9866600c)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Converting%20to%20XPS%20%28Aspose.Slides%29.zip)