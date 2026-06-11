---
title: Konwertuj prezentacje PowerPoint do formatu TIFF z notatkami w Pythonie
linktitle: PowerPoint do TIFF z notatkami
type: docs
weight: 100
url: /pl/python-net/convert-powerpoint-to-tiff-with-notes/
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
- PowerPoint z notatkami
- prezentacja z notatkami
- slajd z notatkami
- PPT z notatkami
- PPTX z notatkami
- TIFF z notatkami
- Python
- Aspose.Slides
description: "Konwertuj prezentacje PowerPoint do formatu TIFF z notatkami przy użyciu Aspose.Slides dla Pythona poprzez .NET. Dowiedz się, jak efektywnie eksportować slajdy z notatkami prelegenta."
---
## **Wprowadzenie**

Aspose.Slides for Python via .NET zapewnia proste rozwiązanie umożliwiające konwertowanie prezentacji PowerPoint i OpenDocument (PPT, PPTX oraz ODP) z notatkami do formatu TIFF. Ten format jest szeroko stosowany do przechowywania wysokiej jakości obrazów, drukowania oraz archiwizacji dokumentów. Dzięki Aspose.Slides możesz nie tylko eksportować całe prezentacje z notatkami prelegenta, ale także generować miniatury slajdów w widoku Notatki slajdu. Proces konwersji jest prosty i wydajny, wykorzystując metodę `save` klasy [Presentation](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/) do przekształcenia całej prezentacji w serię obrazów TIFF, zachowując notatki i układ.

## **Konwertowanie prezentacji do TIFF z notatkami**

Zapisywanie prezentacji PowerPoint lub OpenDocument do TIFF z notatkami przy użyciu Aspose.Slides for Python via .NET obejmuje następujące kroki:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/): wczytaj plik PowerPoint lub OpenDocument.  
2. Skonfiguruj opcje układu wyjściowego: użyj klasy [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/pl/python-net/aspose.slides.export/notescommentslayoutingoptions/) aby określić, jak mają być wyświetlane notatki i komentarze.  
3. Zapisz prezentację jako TIFF: przekaż skonfigurowane opcje do metody [save](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/save/#str-asposeslidesexportsaveformat-asposeslidesexportisaveoptions).

Załóżmy, że mamy plik „speaker_notes.pptx” z następującym slajdem:

![Slajd prezentacji z notatkami prelegenta](slide_with_notes.png)

```py
# Utwórz instancję klasy Presentation, która reprezentuje plik prezentacji.
with slides.Presentation("speaker_notes.pptx") as presentation:
    
    notes_options = slides.export.NotesCommentsLayoutingOptions()
    notes_options.notes_position = slides.export.NotesPositions.BOTTOM_FULL  # Wyświetlaj notatki pod slajdem.
    
    # Skonfiguruj opcje TIFF z układem notatek.
    tiff_options = slides.export.TiffOptions()
    tiff_options.dpi_x = 300
    tiff_options.dpi_y = 300
    tiff_options.slides_layout_options = notes_options
    
    # Zapisz prezentację jako TIFF z notatkami prelegenta.
    presentation.save("TIFF_with_notes.tiff", slides.export.SaveFormat.TIFF, tiff_options)
```

Wynik:

![Obraz TIFF z notatkami prelegenta](TIFF_with_notes.png)

{{% alert title="Tip" color="primary" %}}
Sprawdź Aspose [Free PowerPoint to Poster Converter](https://products.aspose.app/slides/pl/conversion/convert-ppt-to-poster-online).
{{% /alert %}}

## **FAQ**

**Czy mogę kontrolować położenie obszaru notatek w wygenerowanym pliku TIFF?**

Tak. Użyj [notes layout settings](https://reference.aspose.com/slides/pl/python-net/aspose.slides.export/tiffoptions/slides_layout_options/), aby wybrać spośród opcji takich jak `NONE`, `BOTTOM_TRUNCATED` lub `BOTTOM_FULL`, które odpowiednio ukrywają notatki, dopasowują je do jednej strony lub pozwalają im rozciągać się na kolejne strony.

**Jak mogę zmniejszyć rozmiar pliku TIFF z notatkami bez widocznej utraty jakości?**

Wybierz [efficient compression](https://reference.aspose.com/slides/pl/python-net/aspose.slides.export/tiffoptions/compression_type/) (np. `LZW` lub `RLE`), ustaw rozsądne DPI oraz, jeśli dopuszczalne, użyj niższego [pixel format](https://reference.aspose.com/slides/pl/python-net/aspose.slides.export/tiffoptions/pixel_format/) (np. 8 bpp lub 1 bpp dla monochromu). Nieco zmniejszenie [image dimensions](https://reference.aspose.com/slides/pl/python-net/aspose.slides.export/tiffoptions/image_size/) również może pomóc, nie wpływając zauważalnie na czytelność.

**Czy czcionka w notatkach wpływa na wynik, jeśli oryginalne czcionki nie są dostępne w systemie?**

Tak. Brakujące czcionki wywołują [substitution](/slides/pl/python-net/font-selection-sequence/), co może zmienić metryki i wygląd tekstu. Aby tego uniknąć, [dostarcz wymagane czcionki](/slides/pl/python-net/custom-font/) lub ustaw domyślną [fallback font](/slides/pl/python-net/fallback-font/), aby używane były zamierzone kroje.