---
title: Render Dia als Miniatuur naar JPEG met Door de Gebruiker Gedefinieerde Waarden
type: docs
weight: 70
url: /nl/net/render-slide-as-thumbnail-to-jpeg-by-user-defined-values/
---
Om een miniatuurweergave te genereren van een willekeurige gewenste dia met Aspose.Slides voor .NET:

1. Maak een instantie van de **Presentation**-klasse aan.
1. Verkrijg de referentie van de gewenste dia door het ID of de index te gebruiken.
1. Haal de X- en Y-schaalfactoren op op basis van door de gebruiker gedefinieerde X- en Y-afmetingen.
1. Haal de miniatuurafbeelding van de referentiële dia op in een opgegeven schaal.
1. Sla de miniatuurafbeelding op in een gewenst beeldformaat.

``` csharp
using Aspose.Slides;

string filePath = @"..\..\..\Sample Files\";
string srcFileName = filePath + "User Defined Thumbnail.pptx";
string destFileName = filePath + "User Defined Thumbnail.jpg";

//Instantieer de Presentation-klasse die het presentatiebestand vertegenwoordigt
using (Presentation pres = new Presentation(srcFileName))
{
    //Toegang tot de eerste dia
    ISlide sld = pres.Slides[0];

    //Door de gebruiker gedefinieerde afmeting
    int desiredX = 1200;
    int desiredY = 800;

    //Opvragen van geschaalde waarden van X en Y
    float scaleX = (float)(1.0 / pres.SlideSize.Size.Width) * desiredX;
    float scaleY = (float)(1.0 / pres.SlideSize.Size.Height) * desiredY;

    //Maak een afbeelding op volledige schaal
    using (IImage image = sld.GetImage(scaleX, scaleY))
    {
        //Sla de afbeelding op schijf in JPEG-formaat
        image.Save(destFileName, ImageFormat.Jpeg);
    }
}
``` 
## **Voorbeeldcode downloaden**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/User%20Defined%20Thumbnail%20%28Aspose.Slides%29.zip)