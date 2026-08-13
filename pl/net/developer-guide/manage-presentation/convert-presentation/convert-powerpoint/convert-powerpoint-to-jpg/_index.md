---
title: Konwertuj PPT i PPTX do JPG w .NET
linktitle: PowerPoint do JPG
type: docs
weight: 60
url: /pl/net/convert-powerpoint-to-jpg/
keywords:
- konwertuj PowerPoint
- konwertuj prezentację
- konwertuj slajd
- konwertuj PPT
- konwertuj PPTX
- PowerPoint do JPG
- prezentacja do JPG
- slajd do JPG
- PPT do JPG
- PPTX do JPG
- zapisz PowerPoint jako JPG
- zapisz prezentację jako JPG
- zapisz slajd jako JPG
- zapisz PPT jako JPG
- zapisz PPTX jako JPG
- eksportuj PPT do JPG
- eksportuj PPTX do JPG
- .NET
- C#
- Aspose.Slides
description: "Konwertuj slajdy PowerPoint (PPT, PPTX) na wysokiej jakości obrazy JPG w C# przy użyciu Aspose.Slides dla .NET, korzystając z szybkich i niezawodnych przykładów kodu."
---
## **Wprowadzenie**

Konwertowanie prezentacji PowerPoint i OpenDocument do obrazów JPG pomaga w udostępnianiu slajdów, optymalizacji wydajności oraz osadzaniu treści w witrynach internetowych lub aplikacjach. Aspose.Slides for .NET umożliwia przekształcenie plików PPTX, PPT i ODP w wysokiej jakości obrazy JPEG. Ten przewodnik wyjaśnia różne metody konwersji.

Dzięki tym funkcjom łatwo jest zaimplementować własną przeglądarkę prezentacji i stworzyć miniaturę każdego slajdu. Może to być przydatne, jeśli chcesz chronić slajdy przed kopiowaniem lub pokazać prezentację w trybie tylko do odczytu. Aspose.Slides pozwala konwertować całą prezentację lub konkretny slajd do formatów obrazów.

## **Konwertuj slajdy prezentacji na obrazy JPG**

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation).
1. Pobierz obiekt slajdu typu [ISlide](https://reference.aspose.com/slides/pl/net/aspose.slides/islide) z kolekcji [Presentation.Slides](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/properties/slides).
1. Utwórz obraz slajdu przy użyciu metody [ISlide.GetImage(float,float)](https://reference.aspose.com/slides/pl/net/aspose.slides/islide/getimage/#getimage_5).
1. Wywołaj metodę [IImage.Save(string,ImageFormat)](https://reference.aspose.com/slides/pl/net/aspose.slides/iimage/save/#save_3) na obiekcie obrazu. Przekaż nazwę pliku wyjściowego oraz format obrazu jako argumenty.

{{% alert color="info" %}} 
**Uwaga:** Konwersja PPT, PPTX lub ODP do JPG różni się od konwersji do innych formatów w API Aspose.Slides .NET. Dla innych formatów zazwyczaj używasz metody [IPresentation.Save(String,SaveFormat,ISaveOptions)](https://reference.aspose.com/slides/pl/net/aspose.slides/ipresentation/save/#save_5). Jednak przy konwersji do JPG musisz użyć metody [IImage.Save(string,ImageFormat)](https://reference.aspose.com/slides/pl/net/aspose.slides/iimage/save/#save_3).
{{% /alert %}} 

```c#
using Aspose.Slides;

int scaleX = 1;
int scaleY = scaleX;

using (Presentation presentation = new Presentation("PowerPoint_Presentation.ppt"))
{
    foreach (ISlide slide in presentation.Slides)
    {
        // Utwórz obraz slajdu w określonej skali.
        using (IImage thumbnail = slide.GetImage(scaleX, scaleY))
        {
            // Zapisz obraz na dysku w formacie JPEG.
            string imageFileName = $"Slide_{slide.SlideNumber}.jpg";
            thumbnail.Save(imageFileName, ImageFormat.Jpeg);
        }
    }
}
```

## **Konwertuj slajdy do JPG z niestandardowymi wymiarami**

Aby zmienić wymiary generowanych obrazów JPG, możesz ustawić rozmiar obrazu, przekazując go do metody [ISlide.GetImage(Size)](https://reference.aspose.com/slides/pl/net/aspose.slides/islide/getimage/#getimage_6). Dzięki temu możesz tworzyć obrazy o określonych wartościach szerokości i wysokości, zapewniając, że wynik spełnia wymagania dotyczące rozdzielczości i proporcji. Ta elastyczność jest szczególnie przydatna przy generowaniu obrazów dla aplikacji internetowych, raportów lub dokumentacji, gdzie wymagane są precyzyjne wymiary obrazu.

```c#
using System.Drawing;
using Aspose.Slides;

Size imageSize = new Size(1200, 800);

using (Presentation presentation = new Presentation("PowerPoint_Presentation.pptx"))
{
    foreach (ISlide slide in presentation.Slides)
    {
        // Utwórz obraz slajdu o określonym rozmiarze.
        using (IImage thumbnail = slide.GetImage(imageSize))
        {
            // Zapisz obraz na dysku w formacie JPEG.
            string imageFileName = $"Slide_{slide.SlideNumber}.jpg";
            thumbnail.Save(imageFileName, ImageFormat.Jpeg);
        }
    }
}
```

## **Renderuj komentarze przy zapisie slajdów jako obrazy**

Aspose.Slides for .NET udostępnia funkcję, która umożliwia renderowanie komentarzy na slajdach prezentacji podczas konwersji ich do obrazów JPG. Ta funkcjonalność jest szczególnie przydatna do zachowania adnotacji, uwag lub dyskusji dodanych przez współpracowników w prezentacjach PowerPoint. Włączając tę opcję, zapewniasz, że komentarze będą widoczne w wygenerowanych obrazach, co ułatwia przeglądanie i udostępnianie uwag bez konieczności otwierania oryginalnego pliku prezentacji.

Załóżmy, że mamy plik prezentacji „sample.pptx”, zawierający slajd z komentarzami:

![Slajd z komentarzami](slide_with_comments.png)

Poniższy kod C# konwertuje slajd na obraz JPG, zachowując komentarze:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

int scaleX = 2;
int scaleY = scaleX;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    IRenderingOptions options = new RenderingOptions
    {
        // Ustaw opcje dla komentarzy slajdu.
        SlidesLayoutOptions = new NotesCommentsLayoutingOptions
        {
            CommentsPosition = CommentsPositions.Right,
            CommentsAreaWidth = 200,
            CommentsAreaColor = Color.DarkOrange                  
        }
    };

    // Konwertuj pierwszy slajd na obraz.
    using (IImage image = presentation.Slides[0].GetImage(options, scaleX, scaleY))
    {
        image.Save("Slide_1.jpg", ImageFormat.Jpeg);
    }
}
```

Wynik:

![Obraz JPG z komentarzami](image_with_comments.png)

## **Zobacz także**

Zobacz inne opcje konwersji PPT, PPTX lub ODP na obrazy, takie jak:

- [Konwertuj PowerPoint do GIF](/slides/pl/net/convert-powerpoint-to-animated-gif/)
- [Konwertuj PowerPoint do PNG](/slides/pl/net/convert-powerpoint-to-png/)
- [Konwertuj PowerPoint do TIFF](/slides/pl/net/convert-powerpoint-to-tiff/)
- [Konwertuj PowerPoint do SVG](/slides/pl/net/render-a-slide-as-an-svg-image/)

{{% alert color="info" %}} 

Aby zobaczyć, jak Aspose.Slides konwertuje PowerPoint do obrazów JPG, wypróbuj te darmowe konwertery online: PowerPoint [PPTX to JPG](https://products.aspose.app/slides/pl/conversion/pptx-to-jpg) i [PPT to JPG](https://products.aspose.app/slides/pl/conversion/ppt-to-jpg). 

{{% /alert %}} 

![Darmowy konwerter online PPTX do JPG](ppt-to-jpg.png)

{{% alert title="Wskazówka" color="info" %}}

Aspose udostępnia [DARMOWĄ aplikację internetową Collage](https://products.aspose.app/slides/pl/collage). Korzystając z tej usługi online, możesz łączyć obrazy [JPG do JPG](https://products.aspose.app/slides/pl/collage/jpg) lub PNG do PNG, tworzyć [siatki zdjęć](https://products.aspose.app/slides/pl/collage/photo-grid) i tak dalej. 

Stosując te same zasady opisane w tym artykule, możesz konwertować obrazy z jednego formatu na inny. Po więcej informacji zobacz te strony: konwertuj [obraz do JPG](https://products.aspose.com/slides/pl/net/conversion/image-to-jpg/); konwertuj [JPG do obrazu](https://products.aspose.com/slides/pl/net/conversion/jpg-to-image/); konwertuj [JPG do PNG](https://products.aspose.com/slides/pl/net/conversion/jpg-to-png/), konwertuj [PNG do JPG](https://products.aspose.com/slides/pl/net/conversion/png-to-jpg/); konwertuj [PNG do SVG](https://products.aspose.com/slides/pl/net/conversion/png-to-svg/), konwertuj [SVG do PNG](https://products.aspose.com/slides/pl/net/conversion/svg-to-png/).

{{% /alert %}}

## **FAQ**

### Czy ta metoda obsługuje konwersję wsadową?

Tak, Aspose.Slides umożliwia konwersję wsadową wielu slajdów do JPG w jednej operacji.

### Czy konwersja obsługuje SmartArt, wykresy i inne złożone obiekty?

Tak, Aspose.Slides renderuje całą zawartość, w tym SmartArt, wykresy, tabele, kształty i inne. Jednak dokładność renderowania może nieco różnić się od PowerPoint, szczególnie przy użyciu niestandardowych lub brakujących czcionek.

### Czy istnieją ograniczenia dotyczące liczby slajdów, które można przetworzyć?

Aspose.Slides nie narzuca ścisłych limitów na liczbę slajdów, które można przetworzyć. Jednak przy pracy z dużymi prezentacjami lub obrazami wysokiej rozdzielczości możesz napotkać błąd braku pamięci.