---
title: Als Tiff gerendert
type: docs
weight: 30
url: /de/net/rendered-as-tiff/
---
TIFF-Format ist für seine Flexibilität bekannt, mehrseitige Bilder und Daten zu unterstützen. Angesichts der Bedeutung und Beliebtheit des TIFF-Formats bietet Aspose.Slides for .NET Unterstützung beim Konvertieren von Präsentationen in TIFF-Dokumente.
Dieser Artikel erklärt die verschiedenen TIFF-Exportoptionen:

- Konvertieren einer Präsentation in TIFF mit Standardgröße.
- Konvertieren einer Präsentation in TIFF mit benutzerdefinierter Größe.

Die von der **Presentation**-Klasse bereitgestellte **Save**-Methode kann von Entwicklern aufgerufen werden, um die gesamte Präsentation in ein **TIFF**-Dokument zu konvertieren. Weiterhin stellt die Klasse TiffOptions die Eigenschaft ImageSize zur Verfügung, die es dem Entwickler ermöglicht, die Bildgröße bei Bedarf festzulegen.

``` csharp
using Aspose.Slides;


 string FilePath = @"..\..\..\Sample Files\";

string srcFileName = FilePath + "Conversion.pptx";

string destFileName = FilePath + "Conversion to Tiff.tiff";

//Instanziieren Sie ein Presentation-Objekt, das eine Präsentationsdatei darstellt

using (Presentation pres = new Presentation(srcFileName))

{

    //Die Präsentation in ein TIFF-Dokument speichern

}
``` 
## **Beispielcode herunterladen**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Conversion%20to%20Tiff%20%28Aspose.Slides%29.zip)