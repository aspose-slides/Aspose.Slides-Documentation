---
title: Renderuj slajd jako miniaturkę JPEG przy użyciu wartości określonych przez użytkownika
type: docs
weight: 70
url: /pl/net/render-slide-as-thumbnail-to-jpeg-by-user-defined-values/
---
Aby wygenerować miniaturkę dowolnego wybranego slajdu przy użyciu Aspose.Slides for .NET:

1. Utwórz instancję klasy **Presentation**.
1. Uzyskaj odwołanie do dowolnego wybranego slajdu, używając jego ID lub indeksu.
1. Pobierz współczynniki skalowania X i Y na podstawie wymiarów X i Y określonych przez użytkownika.
1. Pobierz obraz miniaturki odwołanego slajdu w określonej skali.
1. Zapisz obraz miniaturki w dowolnym wybranym formacie obrazu.

``` csharp
string filePath = @"..\..\..\Sample Files\";
string srcFileName = filePath + "User Defined Thumbnail.pptx";
string destFileName = filePath + "User Defined Thumbnail.jpg";

    //Utwórz instancję klasy Presentation, która reprezentuje plik prezentacji
using (Presentation pres = new Presentation(srcFileName))
{
        //Uzyskaj dostęp do pierwszego slajdu
    ISlide sld = pres.Slides[0];

        //Wymiary określone przez użytkownika
    int desiredX = 1200;
    int desiredY = 800;

        //Obliczanie przeskalowanych wartości X i Y
    float scaleX = (float)(1.0 / pres.SlideSize.Size.Width) * desiredX;
    float scaleY = (float)(1.0 / pres.SlideSize.Size.Height) * desiredY;

        //Utwórz obraz w pełnej skali
    using (IImage image = sld.GetImage(scaleX, scaleY))
    {
            //Zapisz obraz na dysku w formacie JPEG
        image.Save(destFileName, ImageFormat.Jpeg);
    }
}
``` 
## **Pobierz przykładowy kod**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/User%20Defined%20Thumbnail%20%28Aspose.Slides%29.zip)