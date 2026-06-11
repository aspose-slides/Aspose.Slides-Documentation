---
title: Renderuj slajd jako miniaturę do JPEG
type: docs
weight: 60
url: /pl/net/render-slide-as-thumbnail-to-jpeg/
---
**Aspose.Slides for .NET** jest używany do tworzenia plików prezentacji zawierających slajdy. Te slajdy można wyświetlać, otwierając pliki prezentacji w programie Microsoft PowerPoint. Jednak czasami programiści mogą potrzebować wyświetlać slajdy jako obrazy w swoim ulubionym przeglądarce obrazów. W takich przypadkach Aspose.Slides for .NET pomaga generować miniatury obrazów slajdów.

Aby wygenerować miniaturę dowolnego wybranego slajdu przy użyciu Aspose.Slides for .NET:

1. Utwórz instancję klasy **Presentation**.
1. Uzyskaj odniesienie do wybranego slajdu, używając jego identyfikatora lub indeksu.
1. Pobierz obraz miniatury odniesionego slajdu w określonej skali.
1. Zapisz obraz miniatury w wybranym formacie obrazu.

``` csharp
string filePath = @"..\..\..\Sample Files\";
string srcFileName = filePath + "Slide Thumbnail to JPEG.pptx";
string destFileName = filePath + "Slide Thumbnail to JPEG.jpg";

//Utwórz instancję klasy Presentation, która reprezentuje plik prezentacji
using (Presentation pres = new Presentation(srcFileName))
{
    //Uzyskaj dostęp do pierwszego slajdu
    ISlide sld = pres.Slides[0];

    //Utwórz obraz w pełnej skali
    using (IImage image = sld.GetImage(1f, 1f))
    {
        //Zapisz obraz na dysku w formacie JPEG
        image.Save(destFileName, ImageFormat.Jpeg);
    }
}
``` 

## **Pobierz przykładowy kod**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Slide%20Thumbnail%20to%20JPEG%20%28Aspose.Slides%29.zip)