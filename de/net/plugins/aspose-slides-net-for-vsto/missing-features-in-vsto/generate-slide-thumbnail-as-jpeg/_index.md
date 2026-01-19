---
title: Slide-Thumbnail als JPEG erstellen
type: docs
weight: 90
url: /de/net/generate-slide-thumbnail-as-jpeg/
---

Um das Miniaturbild einer beliebigen Folie mit Aspose.Slides für .NET zu erstellen:

- Erstellen Sie eine Instanz der Klasse Presentation.
- Holen Sie die Referenz der gewünschten Folie über deren ID oder Index.
- Ermitteln Sie das Miniaturbild der referenzierten Folie in einem angegebenen Maßstab.
- Speichern Sie das Miniaturbild in einem gewünschten Bildformat.

## **Beispiel**
```cs
//Instanziieren Sie die Presentation-Klasse, die die Präsentationsdatei repräsentiert
using (Presentation pres = new Presentation("Slides Test Presentation.pptx"))
{
    //Zugriff auf die erste Folie
    ISlide sld = pres.Slides[0];

    //Erstellen Sie ein Bild im Vollmaßstab
    using (IImage image = sld.GetImage(1f, 1f))
    {
        //Speichern Sie das Bild auf die Festplatte im JPEG-Format
        image.Save("Test Thumbnail.jpg", ImageFormat.Jpeg);
    }
}
``` 

## **Laufendes Beispiel herunterladen**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Aspose.Slides%20Features%20missing%20in%20VSTO/Slide%20Thumbnail%20to%20JPEG)

## **Beispielcode herunterladen**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/Aspose.SlidesFeaturesmissingInVSTOv1.1)

{{% alert color="primary" %}} 
Weitere Details finden Sie unter [PPT und PPTX nach JPG konvertieren in .NET](/slides/de/net/convert-powerpoint-to-jpg/).
{{% /alert %}}