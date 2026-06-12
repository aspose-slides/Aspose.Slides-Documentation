---
title: Een miniatuur genereren van een dia met door de gebruiker gedefinieerde afmetingen
type: docs
weight: 100
url: /nl/net/generating-a-thumbnail-from-a-slide-with-user-defined-dimensions/
---
Om de miniatuur van een willekeurige gewenste dia te genereren met Aspose.Slides for .NET:

- Maak een instantie van de Presentation-klasse.
- Haal de referentie op van de gewenste dia door gebruik te maken van diens ID of index.
- Verkrijg de X- en Y-schalingsfactoren op basis van door de gebruiker gedefinieerde X- en Y-afmetingen.
- Haal de miniatuurafbeelding van de refererende dia op een opgegeven schaal op.
- Sla de miniatuurafbeelding op in een gewenst beeldformaat.
## **Voorbeeld**
```cs
//Instantie van de Presentation-klasse maken die het presentatiebestand voorstelt
using (Presentation pres = new Presentation("TestPresentation.pptx"))
{
    //Toegang tot de eerste dia
    ISlide sld = pres.Slides[0];

    //Door de gebruiker gedefinieerde afmeting
    int desiredX = 1200;
    int desiredY = 800;

    //Geschaalde waarde van X en Y verkrijgen
    float scaleX = (float)(1.0 / pres.SlideSize.Size.Width) * desiredX;
    float scaleY = (float)(1.0 / pres.SlideSize.Size.Height) * desiredY;

    //Een afbeelding op volledige schaal maken
    using (IImage image = sld.GetImage(scaleX, scaleY))
    {
        //De afbeelding opslaan op schijf in JPEG-formaat
        image.Save("Thumbnail2.jpg", ImageFormat.Jpeg);
    }
}
``` 
## **Download werkend voorbeeld**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Aspose.Slides%20Features%20missing%20in%20VSTO/User%20Defined%20Thumbnail)
## **Download voorbeeldcode**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/Aspose.SlidesFeaturesmissingInVSTOv1.1)

{{% alert color="primary" %}} 
Voor meer details, bezoek [Convert Slide](/slides/nl/net/convert-slide/).
{{% /alert %}}