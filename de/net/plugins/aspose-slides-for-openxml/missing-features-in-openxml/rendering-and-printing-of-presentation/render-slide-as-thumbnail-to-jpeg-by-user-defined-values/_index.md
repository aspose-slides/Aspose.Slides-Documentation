---
title: Folie als Miniaturbild zu JPEG rendern mit benutzerdefinierten Werten
type: docs
weight: 70
url: /de/net/render-slide-as-thumbnail-to-jpeg-by-user-defined-values/
---

Um das Miniaturbild einer beliebigen gewünschten Folie mit Aspose.Slides für .NET zu erzeugen:

1. Erstellen Sie eine Instanz der **Presentation**-Klasse.
1. Holen Sie die Referenz einer gewünschten Folie, indem Sie deren ID oder Index verwenden.
1. Ermitteln Sie die X- und Y-Skalierungsfaktoren basierend auf benutzerdefinierten X- und Y-Dimensionen.
1. Rufen Sie das Miniaturbild der referenzierten Folie in einem angegebenen Maßstab ab.
1. Speichern Sie das Miniaturbild in einem gewünschten Bildformat.

``` csharp
string filePath = @"..\..\..\Sample Files\";
string srcFileName = filePath + "User Defined Thumbnail.pptx";
string destFileName = filePath + "User Defined Thumbnail.jpg";

//Instantiate the Presentation class that represents the presentation file
using (Presentation pres = new Presentation(srcFileName))
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
        image.Save(destFileName, ImageFormat.Jpeg);
    }
}
``` 
## **Beispielcode herunterladen**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/User%20Defined%20Thumbnail%20%28Aspose.Slides%29.zip)