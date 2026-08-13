---
title: Konwertuj prezentacje PowerPoint do TIFF z notatkami na Androidzie
linktitle: PowerPoint do TIFF z notatkami
type: docs
weight: 100
url: /pl/androidjava/convert-powerpoint-to-tiff-with-notes/
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
- Android
- Java
- Aspose.Slides
description: "Konwertuj prezentacje PowerPoint do formatu TIFF z notatkami przy użyciu Aspose.Slides dla Androida w Javie. Dowiedz się, jak efektywnie eksportować slajdy z notatkami prelegenta."
---
## **Wprowadzenie**

Aspose.Slides for Android via Java zapewnia proste rozwiązanie do konwertowania prezentacji PowerPoint i OpenDocument (PPT, PPTX oraz ODP) wraz z notatkami do formatu TIFF. Format ten jest szeroko stosowany do przechowywania wysokiej jakości obrazów, drukowania oraz archiwizacji dokumentów. Dzięki Aspose.Slides możesz nie tylko wyeksportować całe prezentacje z notatkami prelegenta, ale także generować miniatury slajdów w widoku Notes Slide. Proces konwersji jest prosty i wydajny – wykorzystuje metodę `save` klasy [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentation/), aby przekształcić całą prezentację w serię obrazów TIFF, zachowując notatki i układ.

## **Konwersja prezentacji do TIFF z notatkami**

Zapisywanie prezentacji PowerPoint lub OpenDocument do formatu TIFF z notatkami przy użyciu Aspose.Slides for Android via Java obejmuje następujące kroki:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentation/): załaduj plik PowerPoint lub OpenDocument.  
2. Skonfiguruj opcje układu wyjściowego: użyj klasy [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/notescommentslayoutingoptions/), aby określić, jak mają być wyświetlane notatki i komentarze.  
3. Zapisz prezentację do TIFF: przekaż skonfigurowane opcje do metody [save](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-com.aspose.slides.ISaveOptions-).

Załóżmy, że mamy plik „speaker_notes.pptx” z następującym slajdem:

![Slajd prezentacji z notatkami prelegenta](slide_with_notes.png)

Poniższy fragment kodu pokazuje, jak przekonwertować prezentację na obraz TIFF w widoku Notes Slide przy użyciu metody [setSlidesLayoutOptions](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/tiffoptions/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-).

```java
import com.aspose.slides.*;

// Utwórz instancję klasy Presentation, która reprezentuje plik prezentacji.
Presentation presentation = new Presentation("speaker_notes.pptx");
try {
    NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(NotesPositions.BottomFull); // Wyświetl notatki pod slajdem.

    // Skonfiguruj opcje TIFF z układem notatek.
    TiffOptions tiffOptions = new TiffOptions();
    tiffOptions.setDpiX(300);
    tiffOptions.setDpiY(300);
    tiffOptions.setSlidesLayoutOptions(notesOptions);

    // Zapisz prezentację do TIFF z notatkami prelegenta.
    presentation.save("TIFF_with_notes.tiff", SaveFormat.Tiff, tiffOptions);
} finally {
    presentation.dispose();
}
```

Wynik:

![Obraz TIFF z notatkami prelegenta](TIFF_with_notes.png)

{{% alert title="Tip" color="info" %}}
Sprawdź Aspose [Free PowerPoint to Poster Converter](https://products.aspose.app/slides/pl/conversion/convert-ppt-to-poster-online).
{{% /alert %}}

## **FAQ**

### Czy mogę kontrolować położenie obszaru notatek w wynikowym pliku TIFF?

Tak. Użyj [ustawień układu notatek](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/tiffoptions/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-), aby wybrać jedną z opcji: `None`, `BottomTruncated` lub `BottomFull`, które odpowiednio ukrywają notatki, mieszczą je na jednej stronie lub pozwalają im przechodzić na kolejne strony.

### Jak mogę zmniejszyć rozmiar pliku TIFF z notatkami bez widocznej utraty jakości?

Wybierz [wydajną kompresję](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/tiffoptions/#setCompressionType-int-) (np. `LZW` lub `RLE`), ustaw rozsądne DPI oraz, jeśli to dopuszczalne, użyj niższego [formatu pikseli](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/tiffoptions/#setPixelFormat-int-) (np. 8 bpp lub 1 bpp dla obrazu monochromatycznego). Nieznaczne zmniejszenie [wymiarów obrazu](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/tiffoptions/#setImageSize-java.awt.Dimension-) również może pomóc, nie wpływając zauważalnie na czytelność.

### Czy czcionka w notatkach wpływa na rezultat, jeśli oryginalne czcionki nie są zainstalowane w systemie?

Tak. Brakujące czcionki wywołują [zastępowanie](/slides/pl/androidjava/font-selection-sequence/), co może zmienić wymiary i wygląd tekstu. Aby tego uniknąć, [dostarcz wymagane czcionki](/slides/pl/androidjava/custom-font/) lub ustaw domyślną [czcionkę zapasową](/slides/pl/androidjava/fallback-font/), aby używane były zamierzone kroje pisma.