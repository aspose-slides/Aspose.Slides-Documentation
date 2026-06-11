---
title: Generuj miniaturę slajdu jako JPEG
type: docs
weight: 90
url: /pl/net/generate-slide-thumbnail-as-jpeg/
---
Aby wygenerować miniaturę dowolnego wybranego slajdu przy użyciu Aspose.Slides for .NET:

- Utwórz instancję klasy Presentation.
- Uzyskaj referencję do dowolnego wybranego slajdu, używając jego identyfikatora lub indeksu.
- Pobierz obraz miniatury referowanego slajdu w określonej skali.
- Zapisz obraz miniatury w dowolnym wybranym formacie obrazu.
## **Przykład**
```cs
//Utwórz instancję klasy Presentation, która reprezentuje plik prezentacji
using (Presentation pres = new Presentation("Slides Test Presentation.pptx"))
{
    //Uzyskaj dostęp do pierwszego slajdu
    ISlide sld = pres.Slides[0];

    //Utwórz obraz w pełnej skali
    using (IImage image = sld.GetImage(1f, 1f))
    {
        //Zapisz obraz na dysku w formacie JPEG
        image.Save("Test Thumbnail.jpg", ImageFormat.Jpeg);
    }
}
``` 
## **Pobierz działający przykład**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Aspose.Slides%20Features%20missing%20in%20VSTO/Slide%20Thumbnail%20to%20JPEG)
## **Pobierz przykładowy kod**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/Aspose.SlidesFeaturesmissingInVSTOv1.1)

{{% alert color="primary" %}} 

Aby uzyskać więcej informacji, odwiedź [Konwertuj PPT i PPTX do JPG w .NET](/slides/pl/net/convert-powerpoint-to-jpg/).

{{% /alert %}}