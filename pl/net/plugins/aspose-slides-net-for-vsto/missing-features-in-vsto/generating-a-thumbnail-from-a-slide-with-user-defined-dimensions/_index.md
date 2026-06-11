---
title: Generowanie miniatury ze slajdu o wymiarach określonych przez użytkownika
type: docs
weight: 100
url: /pl/net/generating-a-thumbnail-from-a-slide-with-user-defined-dimensions/
---
Aby wygenerować miniaturę dowolnego wybranego slajdu przy użyciu Aspose.Slides for .NET:

- Utwórz instancję klasy Presentation.
- Uzyskaj odniesienie do wybranego slajdu, używając jego identyfikatora lub indeksu.
- Pobierz współczynniki skalowania X i Y na podstawie wymiarów X i Y zdefiniowanych przez użytkownika.
- Pobierz miniaturę obrazu referowanego slajdu w określonej skali.
- Zapisz obraz miniatury w dowolnym żądanym formacie obrazu.
## **Przykład**
```cs
//Utwórz instancję klasy Presentation reprezentującej plik prezentacji
using (Presentation pres = new Presentation("TestPresentation.pptx"))
{
    //Uzyskaj dostęp do pierwszego slajdu
    ISlide sld = pres.Slides[0];

    //Wymiary określone przez użytkownika
    int desiredX = 1200;
    int desiredY = 800;

    //Obliczanie skalowanej wartości  X i Y
    float scaleX = (float)(1.0 / pres.SlideSize.Size.Width) * desiredX;
    float scaleY = (float)(1.0 / pres.SlideSize.Size.Height) * desiredY;

    //Utwórz obraz w pełnej skali
    using (IImage image = sld.GetImage(scaleX, scaleY))
    {
        //Zapisz obraz na dysku w formacie JPEG
        image.Save("Thumbnail2.jpg", ImageFormat.Jpeg);
    }
}
``` 
## **Pobierz działający przykład**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Aspose.Slides%20Features%20missing%20in%20VSTO/User%20Defined%20Thumbnail)
## **Pobierz przykładowy kod**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/Aspose.SlidesFeaturesmissingInVSTOv1.1)

{{% alert color="primary" %}} 

Aby uzyskać więcej szczegółów, odwiedź [Konwertuj slajd](/slides/pl/net/convert-slide/).

{{% /alert %}}