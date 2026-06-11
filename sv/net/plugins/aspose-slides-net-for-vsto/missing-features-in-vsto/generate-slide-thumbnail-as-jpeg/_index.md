---
title: Generera bildrutes miniatyr som JPEG
type: docs
weight: 90
url: /sv/net/generate-slide-thumbnail-as-jpeg/
---
För att skapa miniatyrbild av en vald bildruta med Aspose.Slides för .NET:

- Skapa en instans av klassen Presentation.
- Hämta referensen till en vald bildruta genom att använda dess ID eller index.
- Hämta miniatyrbilden för den refererade bildrutan i en specificerad skala.
- Spara miniatyrbilden i ett önskat bildformat.
## **Exempel**
```cs
//Instansiera Presentation-klassen som representerar presentationsfilen
using (Presentation pres = new Presentation("Slides Test Presentation.pptx"))
{
    //Åtkomst till den första bilden
    ISlide sld = pres.Slides[0];

    //Skapa en bild i full skala
    using (IImage image = sld.GetImage(1f, 1f))
    {
        //Spara bilden till disk i JPEG-format
        image.Save("Test Thumbnail.jpg", ImageFormat.Jpeg);
    }
}
``` 
## **Ladda ner körande exempel**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Aspose.Slides%20Features%20missing%20in%20VSTO/Slide%20Thumbnail%20to%20JPEG)
## **Ladda ner exempel kod**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/Aspose.SlidesFeaturesmissingInVSTOv1.1)

{{% alert color="primary" %}} 

För mer information, besök [Convert PPT and PPTX to JPG in .NET](/slides/sv/net/convert-powerpoint-to-jpg/).

{{% /alert %}}