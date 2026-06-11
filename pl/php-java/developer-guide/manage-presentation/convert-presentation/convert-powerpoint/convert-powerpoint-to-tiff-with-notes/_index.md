---
title: Konwertuj prezentacje PowerPoint do TIFF z notatkami w PHP
linktitle: PowerPoint do TIFF z notatkami
type: docs
weight: 100
url: /pl/php-java/convert-powerpoint-to-tiff-with-notes/
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
- PHP
- Aspose.Slides
description: "Konwertuj prezentacje PowerPoint do formatu TIFF z notatkami, używając Aspose.Slides dla PHP via Java. Dowiedz się, jak efektywnie eksportować slajdy z notatkami prelegenta."
---
## **Wprowadzenie**

Aspose.Slides dla PHP via Java zapewnia proste rozwiązanie do konwertowania prezentacji PowerPoint i OpenDocument (PPT, PPTX i ODP) z notatkami do formatu TIFF. Ten format jest szeroko stosowany do przechowywania wysokiej jakości obrazów, druku i archiwizacji dokumentów. Dzięki Aspose.Slides możesz nie tylko eksportować całe prezentacje z notatkami prelegenta, ale także generować miniatury slajdów w widoku Notatki slajdu. Proces konwersji jest prosty i wydajny, wykorzystując metodę `save` klasy [Presentation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation/) do przekształcenia całej prezentacji w serię obrazów TIFF, zachowując notatki i układ.

## **Konwertuj prezentację do formatu TIFF z notatkami**

Zapisywanie prezentacji PowerPoint lub OpenDocument do formatu TIFF z notatkami przy użyciu Aspose.Slides dla PHP via Java obejmuje następujące kroki:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation/): załaduj plik PowerPoint lub OpenDocument.  
1. Skonfiguruj opcje układu wyjściowego: użyj klasy [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/pl/php-java/aspose.slides/notescommentslayoutingoptions/) do określenia, jak notatki i komentarze mają być wyświetlane.  
1. Zapisz prezentację do TIFF: przekaż skonfigurowane opcje do metody [save](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation/#save).

Załóżmy, że mamy plik "speaker_notes.pptx" z następującym slajdem:

![The presentation slide with speaker notes](slide_with_notes.png)

Kod poniżej pokazuje, jak skonwertować prezentację do obrazu TIFF w widoku Notatki slajdu przy użyciu metody [setSlidesLayoutOptions](https://reference.aspose.com/slides/pl/php-java/aspose.slides/tiffoptions/#setSlidesLayoutOptions).

```php
// Utwórz instancję klasy Presentation, która reprezentuje plik prezentacji.
$presentation = new Presentation("speaker_notes.pptx");
try {
    $notesOptions = new NotesCommentsLayoutingOptions();
    $notesOptions->setNotesPosition(NotesPositions::BottomFull); // Wyświetl notatki pod slajdem.

    // Skonfiguruj opcje TIFF z układem notatek.
    $tiffOptions = new TiffOptions();
    $tiffOptions->setDpiX(300);
    $tiffOptions->setDpiY(300);
    $tiffOptions->setSlidesLayoutOptions($notesOptions);

    // Zapisz prezentację do TIFF z notatkami prelegenta.
    $presentation->save("TIFF_with_notes.tiff", SaveFormat::Tiff, $tiffOptions);
} finally {
    $presentation->dispose();
}
```

Wynik:

![The TIFF image with speaker notes](TIFF_with_notes.png)

{{% alert title="Tip" color="primary" %}}
Sprawdź Aspose [Bezpłatny konwerter PowerPoint do plakatu](https://products.aspose.app/slides/pl/conversion/convert-ppt-to-poster-online).
{{% /alert %}}

## **FAQ**

**Czy mogę kontrolować pozycję obszaru notatek w wynikowym pliku TIFF?**

Tak. Użyj [ustawień układu notatek](https://reference.aspose.com/slides/pl/php-java/aspose.slides/tiffoptions/#setSlidesLayoutOptions), aby wybrać spośród opcji takich jak `None`, `BottomTruncated` lub `BottomFull`, które odpowiednio ukrywają notatki, dopasowują je do jednej strony lub pozwalają im rozciągać się na dodatkowe strony.

**Jak mogę zmniejszyć rozmiar pliku TIFF z notatkami bez widocznej utraty jakości?**

Wybierz [wydajną kompresję](https://reference.aspose.com/slides/pl/php-java/aspose.slides/tiffoptions/setcompressiontype/) (np. `LZW` lub `RLE`), ustaw rozsądne DPI i, jeśli dopuszczalne, użyj niższego [formatu pikseli](https://reference.aspose.com/slides/pl/php-java/aspose.slides/tiffoptions/setpixelformat/) (takiego jak 8 bpp lub 1 bpp dla monochromu). Nieco zmniejszenie [wymiarów obrazu](https://reference.aspose.com/slides/pl/php-java/aspose.slides/tiffoptions/setimagesize/) również może pomóc, nie wpływając zauważalnie na czytelność.

**Czy czcionka w notatkach wpływa na wynik, jeśli oryginalne czcionki brakuje w systemie?**

Tak. Brakujące czcionki wywołują [substytucję](/slides/pl/php-java/font-selection-sequence/), co może zmienić metryki tekstu i wygląd. Aby tego uniknąć, [dostarcz wymagane czcionki](/slides/pl/php-java/custom-font/) lub ustaw domyślną [czcionkę zapasową](/slides/pl/php-java/fallback-font/), aby użyte zostały zamierzone kroje.