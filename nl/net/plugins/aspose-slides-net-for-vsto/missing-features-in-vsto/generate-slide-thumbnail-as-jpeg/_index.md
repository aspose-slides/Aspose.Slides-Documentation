---
title: Genereer dia-miniatuur als JPEG
type: docs
weight: 90
url: /nl/net/generate-slide-thumbnail-as-jpeg/
---
Om de miniatuur van een gewenste dia te genereren met Aspose.Slides voor .NET:

- Maak een instantie van de Presentation‑klasse.
- Haal de referentie op van een gewenste dia via het ID of de index.
- Verkrijg de miniatuurafbeelding van de refererende dia op een opgegeven schaal.
- Sla de miniatuurafbeelding op in een gewenst beeldformaat.

## **Voorbeeld**
```cs
//Instantieer de Presentation‑klasse die het presentiebestand vertegenwoordigt
using (Presentation pres = new Presentation("Slides Test Presentation.pptx"))
{
    //Toegang tot de eerste dia
    ISlide sld = pres.Slides[0];

    //Maak een afbeelding op volledige schaal
    using (IImage image = sld.GetImage(1f, 1f))
    {
        //Sla de afbeelding op schijf in JPEG‑indeling
        image.Save("Test Thumbnail.jpg", ImageFormat.Jpeg);
    }
}
``` 
## **Download werkend voorbeeld**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Aspose.Slides%20Features%20missing%20in%20VSTO/Slide%20Thumbnail%20to%20JPEG)
## **Download voorbeeldcode**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/Aspose.SlidesFeaturesmissingInVSTOv1.1)

{{% alert color="primary" %}} 

Voor meer details, zie [Converteer PPT en PPTX naar JPG in .NET](/slides/nl/net/convert-powerpoint-to-jpg/).

{{% /alert %}}