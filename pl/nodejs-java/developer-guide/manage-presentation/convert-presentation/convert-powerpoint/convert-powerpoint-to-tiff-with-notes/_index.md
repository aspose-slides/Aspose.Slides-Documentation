---
title: Konwertuj prezentacje PowerPoint do formatu TIFF z notatkami w JavaScript
linktitle: PowerPoint do TIFF z notatkami
type: docs
weight: 100
url: /pl/nodejs-java/convert-powerpoint-to-tiff-with-notes/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Konwertuj prezentacje PowerPoint do formatu TIFF z notatkami w JavaScript przy użyciu Aspose.Slides dla Node.js. Dowiedz się, jak efektywnie eksportować slajdy z notatkami prelegenta."
---
## **Wprowadzenie**

Aspose.Slides for Node.js via Java zapewnia proste rozwiązanie do konwertowania prezentacji PowerPoint i OpenDocument (PPT, PPTX i ODP) z notatkami do formatu TIFF. Ten format jest szeroko stosowany do przechowywania wysokiej jakości obrazów, druku oraz archiwizacji dokumentów. Dzięki Aspose.Slides możesz nie tylko eksportować całe prezentacje z notatkami prelegenta, ale także generować miniatury slajdów w widoku Notatki slajdu. Proces konwersji jest prosty i wydajny, wykorzystując metodę `save` klasy [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation/) w celu przekształcenia całej prezentacji w serię obrazów TIFF, zachowując notatki i układ.

## **Konwertowanie prezentacji do TIFF z notatkami**

Zapisywanie prezentacji PowerPoint lub OpenDocument jako TIFF z notatkami przy użyciu Aspose.Slides for Node.js via Java obejmuje następujące kroki:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation/): załaduj plik PowerPoint lub OpenDocument.  
1. Skonfiguruj opcje układu wyjściowego: użyj klasy [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/notescommentslayoutingoptions/), aby określić, jak mają być wyświetlane notatki i komentarze.  
1. Zapisz prezentację jako TIFF: przekaż skonfigurowane opcje do metody [save](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation/#save).

Załóżmy, że mamy plik „speaker_notes.pptx” z następującym slajdem:

![Slajd prezentacji z notatkami prelegenta](slide_with_notes.png)

Poniższy fragment kodu pokazuje, jak przekonwertować prezentację na obraz TIFF w widoku Notatki slajdu przy użyciu metody [setSlidesLayoutOptions](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/tiffoptions/#setSlidesLayoutOptions).

```js
// Utwórz instancję klasy Presentation, która reprezentuje plik prezentacji.
let presentation = new aspose.slides.Presentation("speaker_notes.pptx");
try {
    let notesOptions = new aspose.slides.NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(aspose.slides.NotesPositions.BottomFull); // Wyświetl notatki pod slajdem.

    // Skonfiguruj opcje TIFF z układem notatek.
    let tiffOptions = new aspose.slides.TiffOptions();
    tiffOptions.setDpiX(300);
    tiffOptions.setDpiY(300);
    tiffOptions.setSlidesLayoutOptions(notesOptions);

    // Zapisz prezentację jako TIFF z notatkami prelegenta.
    presentation.save("TIFF_with_notes.tiff", aspose.slides.SaveFormat.Tiff, tiffOptions);
} finally {
    presentation.dispose();
}
```

Wynik:

![Obraz TIFF z notatkami prelegenta](TIFF_with_notes.png)

{{% alert title="Tip" color="primary" %}}
Sprawdź darmowy konwerter PowerPoint na plakat Aspose [Free PowerPoint to Poster Converter](https://products.aspose.app/slides/pl/conversion/convert-ppt-to-poster-online).
{{% /alert %}}

## **FAQ**

**Czy mogę kontrolować pozycję obszaru notatek w wygenerowanym pliku TIFF?**

Tak. Użyj [ustawień układu notatek](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/tiffoptions/#setSlidesLayoutOptions), aby wybrać spośród opcji takich jak `None`, `BottomTruncated` lub `BottomFull`, które odpowiednio ukrywają notatki, dopasowują je do jednej strony lub pozwalają im rozciągnąć się na kolejne strony.

**Jak mogę zmniejszyć rozmiar pliku TIFF z notatkami bez widocznej utraty jakości?**

Wybierz [efektywną kompresję](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/tiffoptions/setcompressiontype/) (np. `LZW` lub `RLE`), ustaw rozsądne DPI i, jeśli to dopuszczalne, użyj niższego [formatu pikseli](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/tiffoptions/setpixelformat/) (np. 8 bpp lub 1 bpp dla monochromu). Nieznaczne zmniejszenie [rozmiarów obrazu](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/tiffoptions/setimagesize/) może również pomóc, nie wpływając zauważalnie na czytelność.

**Czy czcionka w notatkach wpływa na wynik, jeśli oryginalne czcionki nie są dostępne w systemie?**

Tak. Brakujące czcionki wywołują [zastąpienie](/slides/pl/nodejs-java/font-selection-sequence/), co może zmienić metryki i wygląd tekstu. Aby tego uniknąć, [dostarcz wymagane czcionki](/slides/pl/nodejs-java/custom-font/) lub ustaw domyślną [czcionkę zapasową](/slides/pl/nodejs-java/fallback-font/), aby używane były zamierzone kroje pisma.