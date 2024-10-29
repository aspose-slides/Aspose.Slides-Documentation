---
title: Generierung eines Thumbnails aus einer Folie mit benutzerdefinierten Abmessungen
type: docs
weight: 100
url: /de/net/generating-a-thumbnail-from-a-slide-with-user-defined-dimensions/
---

Um das Thumbnail einer gewünschten Folie mit Aspose.Slides für .NET zu generieren:

- Erstellen Sie eine Instanz der Klasse Presentation.
- Erhalten Sie die Referenz einer gewünschten Folie anhand ihrer ID oder ihres Index.
- Ermitteln Sie die X- und Y-Skalierungsfaktoren basierend auf den benutzerdefinierten X- und Y-Abmessungen.
- Holen Sie sich das Thumbnail-Bild der referenzierten Folie in einem angegebenen Maßstab.
- Speichern Sie das Thumbnail-Bild in einem gewünschten Bildformat.
## **Beispiel**
```cs
//Instanziieren Sie die Presentation-Klasse, die die Präsentationsdatei darstellt
using (Presentation pres = new Presentation("TestPresentation.pptx"))
{
    //Zugriff auf die erste Folie
    ISlide sld = pres.Slides[0];

    //Benutzerdefinierte Abmessung
    int desiredX = 1200;
    int desiredY = 800;

    //Ermitteln des skalierten Wertes von X und Y
    float scaleX = (float)(1.0 / pres.SlideSize.Size.Width) * desiredX;
    float scaleY = (float)(1.0 / pres.SlideSize.Size.Height) * desiredY;

    //Erstellen Sie ein Full-Scale-Bild
    using (IImage image = sld.GetImage(scaleX, scaleY))
    {
        //Speichern Sie das Bild auf der Festplatte im JPEG-Format
        image.Save("Thumbnail2.jpg", ImageFormat.Jpeg);
    }
}
``` 
## **Beispiel herunterladen**
- [CodePlex](https://asposeslidesvsto.codeplex.com/SourceControl/latest#Aspose.Slides Features missing in VSTO/User Defined Thumbnail/)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Aspose.Slides%20Features%20missing%20in%20VSTO/User%20Defined%20Thumbnail)
- [Code.MSDN](https://code.msdn.microsoft.com/AsposeSlides-Features-78d1d03d/view/SourceCode)
## **Beispielcode herunterladen**
- [CodePlex](https://asposeslidesvsto.codeplex.com/releases/view/620001)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/Aspose.SlidesFeaturesmissingInVSTOv1.1)
- [Code.MSDN](https://code.msdn.microsoft.com/AsposeSlides-Features-78d1d03d#content)

{{% alert color="primary" %}} 

Für weitere Details besuchen Sie [Erstellen von Folien-Thumbnail-Bildern](/slides/de/net/presentation-viewer/#creating-slides-thumbnail-image).

{{% /alert %}}