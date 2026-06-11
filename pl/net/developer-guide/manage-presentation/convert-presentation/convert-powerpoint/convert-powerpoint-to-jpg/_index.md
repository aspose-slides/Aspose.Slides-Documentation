---
title: Konwertuj PPT i PPTX na JPG w .NET
linktitle: PowerPoint na JPG
type: docs
weight: 60
url: /pl/net/convert-powerpoint-to-jpg/
keywords:
- konwertuj PowerPoint
- konwertuj prezentację
- konwertuj slajd
- konwertuj PPT
- konwertuj PPTX
- PowerPoint na JPG
- prezentacja na JPG
- slajd na JPG
- PPT na JPG
- PPTX na JPG
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
description: "Konwertuj slajdy PowerPoint (PPT, PPTX) na wysokiej jakości obrazy JPG w języku C# przy użyciu Aspose.Slides dla .NET, korzystając z szybkich i niezawodnych przykładów kodu."
---
## **Wprowadzenie**

Konwertowanie prezentacji PowerPoint i OpenDocument do obrazów JPG pomaga w udostępnianiu slajdów, optymalizacji wydajności oraz osadzaniu treści w witrynach internetowych lub aplikacjach. Aspose.Slides dla .NET umożliwia przekształcenie plików PPTX, PPT i ODP w obrazy JPEG wysokiej jakości. Ten przewodnik wyjaśnia różne metody konwersji.

Dzięki tym funkcjom łatwo jest zaimplementować własną przeglądarkę prezentacji i utworzyć miniaturę każdego slajdu. Może to być przydatne, jeśli chcesz chronić slajdy przed kopiowaniem lub przedstawić prezentację w trybie tylko do odczytu. Aspose.Slides pozwala konwertować całą prezentację lub wybrany slajd do formatów obrazu.

## **Konwertuj slajdy prezentacji do obrazów JPG**

Oto kroki, aby przekonwertować plik PPT, PPTX lub ODP na JPG:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation).
1. Pobierz obiekt slajdu typu [ISlide](https://reference.aspose.com/slides/pl/net/aspose.slides/islide) z kolekcji [Presentation.Slides](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/properties/slides).
1. Utwórz obraz slajdu przy użyciu metody [ISlide.GetImage(float,float)](https://reference.aspose.com/slides/pl/net/aspose.slides/islide/getimage/#getimage_5).
1. Wywołaj metodę [IImage.Save(string,ImageFormat)](https://reference.aspose.com/slides/pl/net/aspose.slides/iimage/save/#save_3) na obiekcie obrazu. Przekaż nazwę pliku wyjściowego oraz format obrazu jako argumenty.

{{% alert color="primary" %}} 
**Uwaga:** Konwersja PPT, PPTX lub ODP do JPG różni się od konwersji do innych formatów w API Aspose.Slides .NET. Dla innych formatów zazwyczaj używa się metody [IPresentation.Save(String,SaveFormat,ISaveOptions)](https://reference.aspose.com/slides/pl/net/aspose.slides/ipresentation/save/#save_5). Jednak przy konwersji do JPG należy użyć metody [IImage.Save(string,ImageFormat)](https://reference.aspose.com/slides/pl/net/aspose.slides/iimage/save/#save_3).
{{% /alert %}} 

```c#
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

Aby zmienić wymiary generowanych obrazów JPG, możesz ustawić rozmiar obrazu, przekazując go do metody [ISlide.GetImage(Size)](https://reference.aspose.com/slides/pl/net/aspose.slides/islide/getimage/#getimage_6). Pozwala to generować obrazy o określonej szerokości i wysokości, zapewniając, że wynik spełnia Twoje wymagania dotyczące rozdzielczości i proporcji. Ta elastyczność jest szczególnie przydatna przy tworzeniu obrazów dla aplikacji internetowych, raportów lub dokumentacji, gdzie wymagane są precyzyjne wymiary obrazu.

```c#
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

## **Renderuj komentarze przy zapisywaniu slajdów jako obrazy**

Aspose.Slides dla .NET udostępnia funkcję, która pozwala renderować komentarze na slajdach prezentacji podczas ich konwersji do obrazów JPG. Funkcjonalność ta jest szczególnie przydatna do zachowania adnotacji, uwag lub dyskusji dodanych przez współpracowników w prezentacjach PowerPoint. Włączając tę opcję, zapewniasz, że komentarze będą widoczne w wygenerowanych obrazach, co ułatwia przeglądanie i udostępnianie informacji zwrotnej bez konieczności otwierania oryginalnego pliku prezentacji.

Załóżmy, że mamy plik prezentacji „sample.pptx” z slajdem zawierającym komentarze:

![Slajd z komentarzami](slide_with_comments.png)

Poniższy kod C# konwertuje slajd na obraz JPG, zachowując komentarze:

```c#
int scaleX = 2;
int scaleY = scaleX;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    IRenderingOptions options = new RenderingOptions
    {
        // Ustaw opcje dla komentarzy na slajdach.
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

Zobacz inne opcje konwersji PPT, PPTX lub ODP do obrazów, takie jak:

- [Konwertuj PowerPoint na GIF](/slides/pl/net/convert-powerpoint-to-animated-gif/)
- [Konwertuj PowerPoint na PNG](/slides/pl/net/convert-powerpoint-to-png/)
- [Konwertuj PowerPoint na TIFF](/slides/pl/net/convert-powerpoint-to-tiff/)
- [Konwertuj PowerPoint na SVG](/slides/pl/net/render-a-slide-as-an-svg-image/)

{{% alert color="primary" %}} 
Aby zobaczyć, jak Aspose.Slides konwertuje PowerPoint na obrazy JPG, wypróbuj te darmowe konwertery online: PowerPoint [PPTX to JPG](https://products.aspose.app/slides/pl/conversion/pptx-to-jpg) i [PPT to JPG](https://products.aspose.app/slides/pl/conversion/ppt-to-jpg). 
{{% /alert %}} 

![Darmowy internetowy konwerter PPTX do JPG](ppt-to-jpg.png)

{{% alert title="Wskazówka" color="primary" %}}

Aspose udostępnia [DARMOWĄ aplikację internetową Collage](https://products.aspose.app/slides/pl/collage). Korzystając z tej usługi online, możesz łączyć obrazy [JPG to JPG](https://products.aspose.app/slides/pl/collage/jpg) lub PNG to PNG, tworzyć [siatki zdjęć](https://products.aspose.app/slides/pl/collage/photo-grid) i wiele więcej. 

Stosując te same zasady opisane w tym artykule, możesz konwertować obrazy z jednego formatu na inny. Po więcej informacji zobacz: konwertuj [obraz na JPG](https://products.aspose.com/slides/pl/net/conversion/image-to-jpg/); konwertuj [JPG na obraz](https://products.aspose.com/slides/pl/net/conversion/jpg-to-image/); konwertuj [JPG na PNG](https://products.aspose.com/slides/pl/net/conversion/jpg-to-png/), konwertuj [PNG na JPG](https://products.aspose.com/slides/pl/net/conversion/png-to-jpg/); konwertuj [PNG na SVG](https://products.aspose.com/slides/pl/net/conversion/png-to-svg/), konwertuj [SVG na PNG](https://products.aspose.com/slides/pl/net/conversion/svg-to-png/).
{{% /alert %}}

## **FAQ**

**Czy ta metoda obsługuje konwersję wsadową?**

Tak, Aspose.Slides umożliwia wsadową konwersję wielu slajdów do JPG w jednej operacji.

**Czy konwersja obsługuje SmartArt, wykresy i inne złożone obiekty?**

Tak, Aspose.Slides renderuje całą zawartość, w tym SmartArt, wykresy, tabele, kształty i inne elementy. Dokładność renderowania może nieco się różnić w porównaniu z PowerPoint, szczególnie przy użyciu niestandardowych lub brakujących czcionek.

**Czy istnieją ograniczenia dotyczące liczby slajdów, które można przetworzyć?**

Aspose.Slides nie narzuca ścisłych limitów liczby slajdów, które możesz przetworzyć. Jednak przy dużych prezentacjach lub obrazach o wysokiej rozdzielczości możesz napotkać błąd braku pamięci.