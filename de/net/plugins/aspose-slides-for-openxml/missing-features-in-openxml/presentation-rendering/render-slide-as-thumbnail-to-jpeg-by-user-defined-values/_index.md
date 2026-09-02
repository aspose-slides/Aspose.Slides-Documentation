---
title: Folie als Thumbnail im JPEG-Format mit benutzerdefinierten Werten rendern
type: docs
weight: 70
url: /de/net/render-slide-as-thumbnail-to-jpeg-by-user-defined-values/
---
Um das Thumbnail einer gewünschten Folie mit Aspose.Slides für .NET zu erzeugen:

1. Erstellen Sie eine Instanz der **Presentation**-Klasse.
1. Holen Sie die Referenz einer gewünschten Folie, indem Sie deren ID oder Index verwenden.
1. Ermitteln Sie die X- und Y-Skalierungsfaktoren basierend auf benutzerdefinierten X- und Y-Dimensionen.
1. Holen Sie das Thumbnail-Bild der referenzierten Folie in einem angegebenen Maßstab.
1. Speichern Sie das Thumbnail-Bild in einem gewünschten Bildformat.

``` csharp
using Aspose.Slides;

string filePath = @"..\..\..\Sample Files\";
string srcFileName = filePath + "User Defined Thumbnail.pptx";
string destFileName = filePath + "User Defined Thumbnail.jpg";

//Instanziieren Sie die Presentation-Klasse, die die Präsentationsdatei darstellt
using (Presentation pres = new Presentation(srcFileName))
{
    //Greifen Sie auf die erste Folie zu
    ISlide sld = pres.Slides[0];

    //Benutzerdefinierte Dimension
    int desiredX = 1200;
    int desiredY = 800;

    //Skalierten Wert von X und Y ermitteln
    float scaleX = (float)(1.0 / pres.SlideSize.Size.Width) * desiredX;
    float scaleY = (float)(1.0 / pres.SlideSize.Size.Height) * desiredY;

    //Ein Bild im Vollmaßstab erstellen
    using (IImage image = sld.GetImage(scaleX, scaleY))
    {
        //Bild im JPEG-Format auf dem Datenträger speichern
        image.Save(destFileName, ImageFormat.Jpeg);
    }
}
``` 
## **Beispielcode herunterladen**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/User%20Defined%20Thumbnail%20%28Aspose.Slides%29.zip)