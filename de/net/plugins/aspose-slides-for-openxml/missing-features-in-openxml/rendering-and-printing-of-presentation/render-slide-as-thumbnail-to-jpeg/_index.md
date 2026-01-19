---
title: Folie als Miniaturbild in JPEG rendern
type: docs
weight: 60
url: /de/net/render-slide-as-thumbnail-to-jpeg/
---

**Aspose.Slides for .NET** wird verwendet, um Präsentationsdateien mit Folien zu erstellen. Diese Folien können angezeigt werden, indem die Präsentationsdateien mit Microsoft PowerPoint geöffnet werden. Manchmal müssen Entwickler jedoch die Folien als Bilder in ihrem bevorzugten Bildbetrachter ansehen. In solchen Fällen hilft Aspose.Slides for .NET beim Erzeugen von Miniaturbildern der Folien.

Um die Miniaturansicht einer beliebigen Folie mit Aspose.Slides for .NET zu erzeugen:

1. Erstellen Sie eine Instanz der **Presentation**‑Klasse.  
2. Holen Sie die Referenz der gewünschten Folie über deren ID oder Index.  
3. Erzeugen Sie das Miniaturbild der referenzierten Folie in einem angegebenen Maßstab.  
4. Speichern Sie das Miniaturbild in einem gewünschten Bildformat.

``` csharp
string filePath = @"..\..\..\Sample Files\";
string srcFileName = filePath + "Slide Thumbnail to JPEG.pptx";
string destFileName = filePath + "Slide Thumbnail to JPEG.jpg";

//Instanziieren Sie die Presentation‑Klasse, die die Präsentationsdatei repräsentiert
using (Presentation pres = new Presentation(srcFileName))
{
    //Zugriff auf die erste Folie
    ISlide sld = pres.Slides[0];

    //Erstellen Sie ein Bild in voller Größe
    using (IImage image = sld.GetImage(1f, 1f))
    {
        //Speichern Sie das Bild auf dem Datenträger im JPEG‑Format
        image.Save(destFileName, ImageFormat.Jpeg);
    }
}
``` 

## **Beispielcode herunterladen**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Slide%20Thumbnail%20to%20JPEG%20%28Aspose.Slides%29.zip)