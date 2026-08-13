---
title: Konwertuj prezentacje PowerPoint do formatu TIFF z notatkami w .NET
linktitle: PowerPoint do TIFF z notatkami
type: docs
weight: 100
url: /pl/net/convert-powerpoint-to-tiff-with-notes/
keywords:
- konwertuj PowerPoint
- konwertuj prezentację
- konwertuj slajd
- konwertuj PPT
- konwertuj PPTX
- PowerPoint do TIFF
- prezentacja do TIFF
- slajd do TIFF
- PPT do TIFF
- PPTX do TIFF
- zapisz PPT jako TIFF
- zapisz PPTX jako TIFF
- eksportuj PPT do TIFF
- eksportuj PPTX do TIFF
- PowerPoint z notatkami
- prezentacja z notatkami
- slajd z notatkami
- PPT z notatkami
- PPTX z notatkami
- TIFF z notatkami
- .NET
- C#
- Aspose.Slides
description: "Konwertuj prezentacje PowerPoint do formatu TIFF z notatkami przy użyciu Aspose.Slides dla .NET. Dowiedz się, jak efektywnie eksportować slajdy z notatkami prelegenta."
---
## **Wprowadzenie**

Aspose.Slides for .NET zapewnia proste rozwiązanie do konwertowania prezentacji PowerPoint i OpenDocument (PPT, PPTX i ODP) wraz z notatkami do formatu TIFF. Format ten jest szeroko używany do przechowywania wysokiej jakości obrazów, drukowania i archiwizacji dokumentów. Dzięki Aspose.Slides możesz nie tylko eksportować całe prezentacje z notatkami prelegenta, ale także generować miniatury slajdów w widoku Notatki slajdu. Proces konwersji jest prosty i wydajny, wykorzystując metodę `Save` klasy [Presentation](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/) do przekształcenia całej prezentacji w serię obrazów TIFF przy zachowaniu notatek i układu.

## **Konwertowanie prezentacji do formatu TIFF z notatkami**

Zapisywanie prezentacji PowerPoint lub OpenDocument do formatu TIFF z notatkami przy użyciu Aspose.Slides for .NET obejmuje następujące kroki:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/): załaduj plik PowerPoint lub OpenDocument.  
2. Skonfiguruj opcje układu wyjściowego: użyj klasy [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/pl/net/aspose.slides.export/notescommentslayoutingoptions/), aby określić, jak mają być wyświetlane notatki i komentarze.  
3. Zapisz prezentację jako TIFF: przekaż skonfigurowane opcje do metody [Save](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/methods/save/index).

Załóżmy, że mamy plik „speaker_notes.pptx” z następującym slajdem:

![Slajd prezentacji z notatkami prelegenta](slide_with_notes.png)

Poniższy fragment kodu pokazuje, jak przekonwertować prezentację na obraz TIFF w widoku Notatki slajdu przy użyciu właściwości [SlidesLayoutOptions](https://reference.aspose.com/slides/pl/net/aspose.slides.export/tiffoptions/slideslayoutoptions/).

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Utwórz obiekt klasy Presentation, który reprezentuje plik prezentacji.
using (Presentation presentation = new Presentation("speaker_notes.pptx"))
{
    // Skonfiguruj opcje TIFF z układem notatek.
    TiffOptions tiffOptions = new TiffOptions
    {
        DpiX = 300,
        DpiY = 300,

        SlidesLayoutOptions = new NotesCommentsLayoutingOptions
        {
            NotesPosition = NotesPositions.BottomFull // Wyświetl notatki pod slajdem.
        }
    };

    // Zapisz prezentację do formatu TIFF wraz z notatkami prelegenta.
    presentation.Save("TIFF_with_notes.tiff", SaveFormat.Tiff, tiffOptions);
}
```

Wynik:

![Obraz TIFF z notatkami prelegenta](TIFF_with_notes.png)

{{% alert title="Wskazówka" color="info" %}}
Sprawdź darmowy konwerter Aspose [Free PowerPoint to Poster Converter](https://products.aspose.app/slides/pl/conversion/convert-ppt-to-poster-online).
{{% /alert %}}

## **FAQ**

### Czy mogę kontrolować położenie obszaru notatek w wygenerowanym pliku TIFF?

Tak. Użyj [ustawień układu notatek](https://reference.aspose.com/slides/pl/net/aspose.slides.export/tiffoptions/slideslayoutoptions/), aby wybrać jedną z opcji: `None`, `BottomTruncated` lub `BottomFull`, które odpowiednio ukrywają notatki, mieszczą je na jednej stronie lub pozwalają im rozciągać się na kolejne strony.

### Jak mogę zmniejszyć rozmiar pliku TIFF z notatkami bez widocznej utraty jakości?

Wybierz [wydajną kompresję](https://reference.aspose.com/slides/pl/net/aspose.slides.export/tiffoptions/compressiontype/) (np. `LZW` lub `RLE`), ustaw rozsądne DPI i, jeśli to dopuszczalne, użyj niższego [formatu pikseli](https://reference.aspose.com/slides/pl/net/aspose.slides.export/tiffoptions/pixelformat/) (takiego jak 8 bpp lub 1 bpp dla monochromatu). Delikatne zmniejszenie [wymiarów obrazu](https://reference.aspose.com/slides/pl/net/aspose.slides.export/tiffoptions/imagesize/) również może pomóc, nie wpływając zauważalnie na czytelność.

### Czy czcionka w notatkach wpływa na wynik, gdy oryginalne czcionki są nieobecne w systemie?

Tak. Brakujące czcionki wywołują [zastępowanie](/slides/pl/net/font-selection-sequence/), co może zmienić metryki i wygląd tekstu. Aby tego uniknąć, [dostarcz wymagane czcionki](/slides/pl/net/custom-font/) lub ustaw domyślną [czcionkę awaryjną](/slides/pl/net/fallback-font/), aby użyte zostały zamierzone style czcionek.