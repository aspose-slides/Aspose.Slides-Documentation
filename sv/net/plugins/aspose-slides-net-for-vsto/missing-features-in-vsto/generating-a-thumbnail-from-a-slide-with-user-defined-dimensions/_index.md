---
title: Generera en miniatyrbild från en bildruta med användardefinierade dimensioner
type: docs
weight: 100
url: /sv/net/generating-a-thumbnail-from-a-slide-with-user-defined-dimensions/
---
För att skapa en miniatyrbild av en valfri bildruta med Aspose.Slides för .NET:

- Skapa en instans av Presentation-klassen.
- Hämta referensen till en valfri bildruta genom att använda dess ID eller index.
- Hämta X- och Y-skaleringsfaktorerna baserade på användardefinierade X- och Y-dimensioner.
- Hämta miniatyrbilden av den refererade bildrutan i en angiven skala.
- Spara miniatyrbilden i ett valfritt bildformat.
## **Exempel**
```cs
//Skapa en instans av Presentation-klassen som representerar presentationsfilen
using (Presentation pres = new Presentation("TestPresentation.pptx"))
{
    //Hämta den första bildrutan
    ISlide sld = pres.Slides[0];

    //Användardefinierad dimension
    int desiredX = 1200;
    int desiredY = 800;

    //Beräknar skalade värden för X och Y
    float scaleX = (float)(1.0 / pres.SlideSize.Size.Width) * desiredX;
    float scaleY = (float)(1.0 / pres.SlideSize.Size.Height) * desiredY;

    //Skapa en bild i full skala
    using (IImage image = sld.GetImage(scaleX, scaleY))
    {
        //Spara bilden till disk i JPEG-format
        image.Save("Thumbnail2.jpg", ImageFormat.Jpeg);
    }
}
``` 
## **Ladda ner körbart exempel**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Aspose.Slides%20Features%20missing%20in%20VSTO/User%20Defined%20Thumbnail)
## **Ladda ner exempelkod**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/Aspose.SlidesFeaturesmissingInVSTOv1.1)

{{% alert color="primary" %}} 
För mer information, besök [Konvertera bildruta](/slides/sv/net/convert-slide/).
{{% /alert %}}