---
title: Generieren Sie ein Folienminiaturbild im JPEG-Format
type: docs
weight: 90
url: /net/generate-slide-thumbnail-as-jpeg/
---

Um die Miniaturansicht einer gewünschten Folie mit Aspose.Slides für .NET zu generieren:

- Erstellen Sie eine Instanz der Klasse Presentation.
- Erhalten Sie die Referenz der gewünschten Folie, indem Sie deren ID oder Index verwenden.
- Holen Sie sich das Miniaturbild der referenzierten Folie in einem bestimmten Maßstab.
- Speichern Sie das Miniaturbild in einem gewünschten Bildformat.
## **Beispiel**
```cs
//Instanziieren Sie die Präsentationsklasse, die die Präsentationsdatei darstellt
using (Presentation pres = new Presentation("Slides Test Presentation.pptx"))
{
    //Zugriff auf die erste Folie
    ISlide sld = pres.Slides[0];

    //Erstellen Sie ein Bild im Vollformat
    using (IImage image = sld.GetImage(1f, 1f))
    {
        //Speichern Sie das Bild auf der Festplatte im JPEG-Format
        image.Save("Test Thumbnail.jpg", ImageFormat.Jpeg);
    }
}
``` 
## **Beispiel herunterladen**
- [CodePlex](https://asposeslidesvsto.codeplex.com/SourceControl/latest#Aspose.Slides Features missing in VSTO/Slide Thumbnail to JPEG/)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Aspose.Slides%20Features%20missing%20in%20VSTO/Slide%20Thumbnail%20to%20JPEG)
- [Code.MSDN](https://code.msdn.microsoft.com/AsposeSlides-Features-78d1d03d/view/SourceCode)
## **Beispielcode herunterladen**
- [CodePlex](https://asposeslidesvsto.codeplex.com/releases/view/620001)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/Aspose.SlidesFeaturesmissingInVSTOv1.1)
- [Code.MSDN](https://code.msdn.microsoft.com/AsposeSlides-Features-78d1d03d#content)

{{% alert color="primary" %}} 

Für weitere Details besuchen Sie [Erstellen von Folienminiaturbildern](/slides/net/presentation-viewer/#presentationviewer-creatingslidesthumbnailimage).

{{% /alert %}}