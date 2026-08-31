---
title: Renderowanie slajdu jako miniatury w formacie JPEG przy użyciu wartości zdefiniowanych przez użytkownika
type: docs
weight: 70
url: /pl/net/render-slide-as-thumbnail-to-jpeg-by-user-defined-values/
---
Aby wygenerować miniaturę dowolnego wybranego slajdu przy użyciu Aspose.Slides for .NET:

1. Utwórz instancję klasy **Presentation**.
1. Uzyskaj referencję do wybranego slajdu, używając jego identyfikatora lub indeksu.
1. Pobierz współczynniki skalowania X i Y na podstawie wymiarów X i Y określonych przez użytkownika.
1. Pobierz obraz miniatury referowanego slajdu w określonej skali.
1. Zapisz obraz miniatury w wybranym formacie obrazu.

``` csharp
using Aspose.Slides;

string filePath = @"..\..\..\Sample Files\";
string srcFileName = filePath + "User Defined Thumbnail.pptx";
string destFileName = filePath + "User Defined Thumbnail.jpg";

//Utwórz instancję klasy Presentation, która reprezentuje plik prezentacji
using (Presentation pres = new Presentation(srcFileName))
{
    //Uzyskaj dostęp do pierwszego slajdu
    ISlide sld = pres.Slides[0];

    //Wymiary zdefiniowane przez użytkownika
    int desiredX = 1200;
    int desiredY = 800;

    //Obliczanie skalowanych wartości X i Y
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