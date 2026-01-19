---
title: Erzeugen eines Miniaturbilds aus einer Folie mit benutzerdefinierten Abmessungen
type: docs
weight: 100
url: /de/net/generating-a-thumbnail-from-a-slide-with-user-defined-dimensions/
---

Um das Miniaturbild einer beliebigen gewünschten Folie mit Aspose.Slides für .NET zu erzeugen:

- Erstellen Sie eine Instanz der Klasse Presentation.
- Holen Sie die Referenz einer gewünschten Folie, indem Sie deren ID oder Index verwenden.
- Ermitteln Sie die X- und Y-Skalierungsfaktoren basierend auf benutzerdefinierten X- und Y-Dimensionen.
- Erhalten Sie das Miniaturbild der referenzierten Folie in einem angegebenen Maßstab.
- Speichern Sie das Miniaturbild in einem gewünschten Bildformat.
## **Beispiel**
```cs
//Instantiate the Presentation class that represents the presentation file
using (Presentation pres = new Presentation("TestPresentation.pptx"))
{
    //Access the first slide
    ISlide sld = pres.Slides[0];

    //User defined dimension
    int desiredX = 1200;
    int desiredY = 800;

    //Getting scaled value  of X and Y
    float scaleX = (float)(1.0 / pres.SlideSize.Size.Width) * desiredX;
    float scaleY = (float)(1.0 / pres.SlideSize.Size.Height) * desiredY;

    //Create a full scale image
    using (IImage image = sld.GetImage(scaleX, scaleY))
    {
        //Save the image to disk in JPEG format
        image.Save("Thumbnail2.jpg", ImageFormat.Jpeg);
    }
}
``` 
## **Beispiel herunterladen**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Aspose.Slides%20Features%20missing%20in%20VSTO/User%20Defined%20Thumbnail)
## **Beispielcode herunterladen**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/Aspose.SlidesFeaturesmissingInVSTOv1.1)

{{% alert color="primary" %}} 

Weitere Details finden Sie unter [Folie konvertieren](/slides/de/net/convert-slide/).

{{% /alert %}}