---
title: Als Tiff gerendert
type: docs
weight: 30
url: /de/net/rendered-as-tiff/
---

Das TIFF-Format ist für seine Flexibilität bekannt, mehrseitige Bilder und Daten zu unterstützen. In Anbetracht der Bedeutung und Popularität des TIFF-Formats bietet Aspose.Slides für .NET die Unterstützung zum Konvertieren von Präsentationen in ein TIFF‑Dokument.  
Dieser Artikel erklärt die verschiedenen TIFF‑Exportoptionen:

- Konvertieren einer Präsentation in TIFF mit Standardgröße.  
- Konvertieren einer Präsentation in TIFF mit benutzerdefinierter Größe.

Die von der **Presentation**‑Klasse bereitgestellte **Save**‑Methode kann von Entwicklern aufgerufen werden, um die gesamte Präsentation in ein **TIFF**‑Dokument zu konvertieren. Darüber hinaus stellt die Klasse TiffOptions die Eigenschaft ImageSize zur Verfügung, mit der der Entwickler bei Bedarf die Bildgröße festlegen kann.

``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string srcFileName = FilePath + "Conversion.pptx";

string destFileName = FilePath + "Conversion to Tiff.tiff";

//Instantiate a Presentation object that represents a presentation file

using (Presentation pres = new Presentation(srcFileName))

{

    //Saving the presentation to TIFF document

    pres.Save(destFileName, Aspose.Slides.Export.SaveFormat.Tiff);

}

``` 
## **Beispielcode herunterladen**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Conversion%20to%20Tiff%20%28Aspose.Slides%29.zip)