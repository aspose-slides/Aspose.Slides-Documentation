---
title: Rendera bild som miniatyr till JPEG
type: docs
weight: 60
url: /sv/net/render-slide-as-thumbnail-to-jpeg/
---
**Aspose.Slides for .NET** används för att skapa presentationsfiler som innehåller bilder. Dessa bilder kan visas genom att öppna presentationsfiler i Microsoft PowerPoint. Men ibland kan utvecklare behöva visa bilder som bilder med sin favoritsbildvisare. I sådana fall hjälper Aspose.Slides for .NET dig att generera miniatyrbilder av bilderna.

För att generera miniatyrbilden av en valfri bild med Aspose.Slides for .NET:

1. Skapa en instans av **Presentation**-klassen.
1. Hämta referensen till den önskade bilden genom att använda dess ID eller index.
1. Hämta miniatyrbilden av den refererade bilden i en angiven skala.
1. Spara miniatyrbilden i önskat bildformat.

``` csharp
using Aspose.Slides;

string filePath = @"..\..\..\Sample Files\";
string srcFileName = filePath + "Slide Thumbnail to JPEG.pptx";
string destFileName = filePath + "Slide Thumbnail to JPEG.jpg";

//Instansiera Presentation-klassen som representerar presentationsfilen
using (Presentation pres = new Presentation(srcFileName))
{
    //Åtkomst till den första bilden
    ISlide sld = pres.Slides[0];

    //Skapa en fullskalig bild
    using (IImage image = sld.GetImage(1f, 1f))
    {
        //Spara bilden till disk i JPEG-format
        image.Save(destFileName, ImageFormat.Jpeg);
    }
}
``` 

## **Hämta exempel kod**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Slide%20Thumbnail%20to%20JPEG%20%28Aspose.Slides%29.zip)