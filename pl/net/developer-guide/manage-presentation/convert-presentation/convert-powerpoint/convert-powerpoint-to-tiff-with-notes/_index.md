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

Aspose.Slides for .NET zapewnia proste rozwiązanie do konwertowania prezentacji PowerPoint i OpenDocument (PPT, PPTX i ODP) z notatkami do formatu TIFF. Ten format jest powszechnie używany do przechowywania wysokiej jakości obrazów, drukowania i archiwizacji dokumentów. Dzięki Aspose.Slides możesz nie tylko eksportować całe prezentacje z notatkami prelegenta, ale także generować miniatury slajdów w widoku Notes Slide. Proces konwersji jest prosty i wydajny, wykorzystując metodę `Save` klasy [Presentation](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/) do przekształcenia całej prezentacji w serię obrazów TIFF, zachowując notatki i układ.

## **Konwertuj prezentację do TIFF z notatkami**

Zapisanie prezentacji PowerPoint lub OpenDocument w formacie TIFF z notatkami przy użyciu Aspose.Slides for .NET obejmuje następujące kroki:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/): załaduj plik PowerPoint lub OpenDocument.  
2. Skonfiguruj opcje układu wyjściowego: użyj klasy [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/pl/net/aspose.slides.export/notescommentslayoutingoptions/) aby określić, jak mają być wyświetlane notatki i komentarze.  
3. Zapisz prezentację w formacie TIFF: przekaż skonfigurowane opcje do metody [Save](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/methods/save/index).

Załóżmy, że mamy plik „speaker_notes.pptx” z następującym slajdem:

![Slajd prezentacji z notatkami prelegenta](slide_with_notes.png)

```c#
 // Utwórz instancję klasy Presentation, która reprezentuje plik prezentacji.
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

     // Zapisz prezentację w formacie TIFF z notatkami prelegenta.
     presentation.Save("TIFF_with_notes.tiff", SaveFormat.Tiff, tiffOptions);
 }
```

Wynik:

![Obraz TIFF z notatkami prelegenta](TIFF_with_notes.png)

{{% alert title="Tip" color="primary" %}}
Sprawdź bezpłatny konwerter Aspose [Free PowerPoint to Poster Converter](https://products.aspose.app/slides/pl/conversion/convert-ppt-to-poster-online).
{{% /alert %}}

## **FAQ**

**Czy mogę kontrolować położenie obszaru notatek w wygenerowanym pliku TIFF?**

Tak. Użyj [ustawień układu notatek](https://reference.aspose.com/slides/pl/net/aspose.slides.export/tiffoptions/slideslayoutoptions/), aby wybrać spośród opcji takich jak `None`, `BottomTruncated` lub `BottomFull`, które odpowiednio ukrywają notatki, dopasowują je do jednej strony lub pozwalają im rozciągać się na dodatkowe strony.

**Jak mogę zmniejszyć rozmiar pliku TIFF z notatkami bez widocznej utraty jakości?**

Wybierz [wydajną kompresję](https://reference.aspose.com/slides/pl/net/aspose.slides.export/tiffoptions/compressiontype/) (np. `LZW` lub `RLE`), ustaw rozsądne DPI i, jeśli dopuszczalne, użyj niższego [formatu pikseli](https://reference.aspose.com/slides/pl/net/aspose.slides.export/tiffoptions/pixelformat/) (np. 8 bpp lub 1 bpp dla monokromu). Nieznaczne zmniejszenie [rozmiarów obrazu](https://reference.aspose.com/slides/pl/net/aspose.slides.export/tiffoptions/imagesize/) również może pomóc, nie wpływając zauważalnie na czytelność.

**Czy czcionka w notatkach wpływa na wynik, jeśli oryginalne czcionki nie są zainstalowane w systemie?**

Tak. Brakujące czcionki wywołują [zastąpienie](/slides/pl/net/font-selection-sequence/), co może zmienić metryki i wygląd tekstu. Aby tego uniknąć, [dostarcz wymagane czcionki](/slides/pl/net/custom-font/) lub ustaw domyślną [czcionkę zapasową](/slides/pl/net/fallback-font/), aby użyte zostały zamierzone fonty.