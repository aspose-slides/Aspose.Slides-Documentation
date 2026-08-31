---
title: Rendera bild som miniatyr till JPEG med användardefinierade värden
type: docs
weight: 70
url: /sv/net/render-slide-as-thumbnail-to-jpeg-by-user-defined-values/
---
För att generera miniatyren för vilken önskad bild som helst med Aspose.Slides för .NET:

1. Skapa en instans av **Presentation**-klassen.  
1. Hämta referensen till önskad bild genom att använda dess ID eller index.  
1. Hämta X- och Y-skalningsfaktorerna baserat på användardefinierade X- och Y-dimensioner.  
1. Hämta miniatyrbilden för den refererade bilden i en angiven skala.  
1. Spara miniatyrbilden i valfritt bildformat.

``` csharp
using Aspose.Slides;

string filePath = @"..\..\..\Sample Files\";
string srcFileName = filePath + "User Defined Thumbnail.pptx";
string destFileName = filePath + "User Defined Thumbnail.jpg";

//Instansiera Presentation-klassen som representerar presentationsfilen
using (Presentation pres = new Presentation(srcFileName))
{
    //Hämta den första bilden
    ISlide sld = pres.Slides[0];

    //Användardefinierad dimension
    int desiredX = 1200;
    int desiredY = 800;

    //Hämtar skalade värden för X och Y
    float scaleX = (float)(1.0 / pres.SlideSize.Size.Width) * desiredX;
    float scaleY = (float)(1.0 / pres.SlideSize.Size.Height) * desiredY;

    //Skapa en bild i full skala
    using (IImage image = sld.GetImage(scaleX, scaleY))
    {
        //Spara bilden till disk i JPEG-format
        image.Save(destFileName, ImageFormat.Jpeg);
    }
}
``` 
## **Ladda ner exempel kod**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/User%20Defined%20Thumbnail%20%28Aspose.Slides%29.zip)