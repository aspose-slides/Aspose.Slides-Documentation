---
title: Als Tiff Gerendert
type: docs
weight: 30
url: /de/net/rendered-as-tiff/
---

Das TIFF-Format ist bekannt für seine Flexibilität, mehrere Seitenbilder und Daten zu accommodate. Angesichts der Bedeutung und Beliebtheit des TIFF-Formats bietet Aspose.Slides für .NET die Unterstützung, Präsentationen in TIFF-Dokumente zu konvertieren. Dieser Artikel erklärt die verschiedenen TIFF-Exportoptionen:

- Konvertieren der Präsentation in TIFF mit der Standardgröße.
- Konvertieren der Präsentation in TIFF mit benutzerdefinierter Größe.

Die **Save**-Methode der **Presentation**-Klasse kann von Entwicklern aufgerufen werden, um die gesamte Präsentation in ein **TIFF**-Dokument zu konvertieren. Darüber hinaus bietet die TiffOptions-Klasse die ImageSize-Eigenschaft, die es dem Entwickler ermöglicht, die Größe des Bildes bei Bedarf zu definieren.

``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string srcFileName = FilePath + "Conversion.pptx";

string destFileName = FilePath + "Konvertierung zu Tiff.tiff";

//Instanziiere ein Präsentationsobjekt, das eine Präsentationsdatei darstellt

using (Presentation pres = new Presentation(srcFileName))

{

    //Speichern der Präsentation als TIFF-Dokument

    pres.Save(destFileName, Aspose.Slides.Export.SaveFormat.Tiff);

}

``` 
## **Beispielcode Herunterladen**
- [Codeplex](https://asposeslidesopenxml.codeplex.com/releases/view/619597)
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Code.MSDN](https://code.msdn.microsoft.com/AsposeSlides-Features-9866600c)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Conversion%20to%20Tiff%20%28Aspose.Slides%29.zip)