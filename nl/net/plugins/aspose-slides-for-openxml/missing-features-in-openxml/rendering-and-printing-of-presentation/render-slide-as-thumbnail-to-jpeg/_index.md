---
title: Dia renderen als miniatuur naar JPEG
type: docs
weight: 60
url: /nl/net/render-slide-as-thumbnail-to-jpeg/
---
**Aspose.Slides for .NET** wordt gebruikt om presentatiebestanden met dia's te maken. Deze dia's kunnen bekeken worden door de presentatiebestanden te openen met Microsoft PowerPoint. Maar soms moeten ontwikkelaars de dia's als afbeeldingen bekijken met hun favoriete afbeeldingsviewer. In dat geval helpt Aspose.Slides for .NET je om miniatuurafbeeldingen van de dia's te genereren.

Om een miniatuur van een gewenste dia te genereren met Aspose.Slides for .NET:

1. Maak een instantie van de **Presentation**-klasse.
1. Verkrijg de referentie van een gewenste dia door zijn ID of index te gebruiken.
1. Haal de miniatuurafbeelding van de refererende dia op met een opgegeven schaal.
1. Sla de miniatuurafbeelding op in een gewenst beeldformaat.

``` csharp
string filePath = @"..\..\..\Sample Files\";
string srcFileName = filePath + "Slide Thumbnail to JPEG.pptx";
string destFileName = filePath + "Slide Thumbnail to JPEG.jpg";

//Instantieer de Presentation-klasse die het presentatiebestand vertegenwoordigt
using (Presentation pres = new Presentation(srcFileName))
{
    //Toegang tot de eerste dia
    ISlide sld = pres.Slides[0];

    //Maak een afbeelding op volledige schaal
    using (IImage image = sld.GetImage(1f, 1f))
    {
        //Sla de afbeelding op schijf in JPEG-formaat
        image.Save(destFileName, ImageFormat.Jpeg);
    }
}
```

## **Voorbeeldcode downloaden**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Slide%20Thumbnail%20to%20JPEG%20%28Aspose.Slides%29.zip)