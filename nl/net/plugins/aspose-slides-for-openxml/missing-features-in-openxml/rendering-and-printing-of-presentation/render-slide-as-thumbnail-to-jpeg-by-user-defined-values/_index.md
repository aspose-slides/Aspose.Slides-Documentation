---
title: Dia renderen als miniatuur naar JPEG met door gebruiker gedefinieerde waarden
type: docs
weight: 70
url: /nl/net/render-slide-as-thumbnail-to-jpeg-by-user-defined-values/
---
Om een miniatuur van een gewenste dia te genereren met Aspose.Slides voor .NET:

1. Maak een instantie van de **Presentation**-klasse.
1. Verkrijg de referentie van een gewenste dia door zijn ID of index te gebruiken.
1. Haal de X- en Y-schaalfactoren op op basis van door de gebruiker gedefinieerde X- en Y-afmetingen.
1. Haal de miniatuurfoto van de refererende dia op een opgegeven schaal.
1. Sla de miniatuurfoto op in een gewenst afbeeldingformaat.

``` csharp
string filePath = @"..\..\..\Sample Files\";
string srcFileName = filePath + "User Defined Thumbnail.pptx";
string destFileName = filePath + "User Defined Thumbnail.jpg";

//Instantieer de Presentation-klasse die het presentatiebestand vertegenwoordigt
using (Presentation pres = new Presentation(srcFileName))
{
    //Toegang tot de eerste dia
    ISlide sld = pres.Slides[0];

    //Door gebruiker gedefinieerde dimensie
    int desiredX = 1200;
    int desiredY = 800;

    //Opvragen geschaalde waarde van X en Y
    float scaleX = (float)(1.0 / pres.SlideSize.Size.Width) * desiredX;
    float scaleY = (float)(1.0 / pres.SlideSize.Size.Height) * desiredY;

    //Maak een afbeelding op volledige schaal
    using (IImage image = sld.GetImage(scaleX, scaleY))
    {
        //Sla de afbeelding op schijf op in JPEG-formaat
        image.Save(destFileName, ImageFormat.Jpeg);
    }
}
``` 
## **Voorbeeldcode downloaden**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/User%20Defined%20Thumbnail%20%28Aspose.Slides%29.zip)