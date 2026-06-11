---
title: Konwertuj prezentacje PowerPoint do formatu TIFF z notatkami w Javie
linktitle: PowerPoint do TIFF z notatkami
type: docs
weight: 100
url: /pl/java/convert-powerpoint-to-tiff-with-notes/
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
- Java
- Aspose.Slides
description: "Konwertuj prezentacje PowerPoint do formatu TIFF z notatkami za pomocą Aspose.Slides dla Javy. Dowiedz się, jak efektywnie eksportować slajdy z notatkami prelegenta."
---
## **Wstęp**

Aspose.Slides dla języka Java zapewnia proste rozwiązanie umożliwiające konwertowanie prezentacji PowerPoint i OpenDocument (PPT, PPTX i ODP) z notatkami do formatu TIFF. Format ten jest szeroko stosowany do przechowywania wysokiej jakości obrazów, drukowania i archiwizacji dokumentów. Dzięki Aspose.Slides możesz nie tylko eksportować całe prezentacje z notatkami prelegenta, ale także generować miniatury slajdów w widoku Notatki Slajdu. Proces konwersji jest prosty i wydajny, wykorzystując metodę `save` klasy [Presentation](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentation/) do przekształcenia całej prezentacji w serię obrazów TIFF przy zachowaniu notatek i układu.

## **Konwertuj prezentację do TIFF z notatkami**

Zapisanie prezentacji PowerPoint lub OpenDocument do formatu TIFF z notatkami przy użyciu Aspose.Slides dla Java obejmuje następujące kroki:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentation/): wczytaj plik PowerPoint lub OpenDocument.  
2. Skonfiguruj opcje układu wyjściowego: użyj klasy [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/pl/java/com.aspose.slides/notescommentslayoutingoptions/) aby określić, jak notatki i komentarze mają być wyświetlane.  
3. Zapisz prezentację do formatu TIFF: przekaż skonfigurowane opcje do metody [save](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentation/#save-java.lang.String-int-com.aspose.slides.ISaveOptions-).

Załóżmy, że mamy plik „speaker_notes.pptx” z następującym slajdem:

![Slajd prezentacji z notatkami prelegenta](slide_with_notes.png)

Poniższy fragment kodu pokazuje, jak przekonwertować prezentację na obraz TIFF w widoku Notatki Slajdu przy użyciu metody [setSlidesLayoutOptions](https://reference.aspose.com/slides/pl/java/com.aspose.slides/tiffoptions/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-).

```java
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

{{% alert title="Tip" color="primary" %}}
Sprawdź darmowy konwerter Aspose [Free PowerPoint to Poster Converter](https://products.aspose.app/slides/pl/conversion/convert-ppt-to-poster-online).
{{% /alert %}}

## **FAQ**

**Czy mogę kontrolować pozycję obszaru notatek w wynikowym pliku TIFF?**

Tak. Użyj [ustawień układu notatek](https://reference.aspose.com/slides/pl/java/com.aspose.slides/tiffoptions/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-) aby wybrać spośród opcji takich jak `None`, `BottomTruncated` lub `BottomFull`, które odpowiednio ukrywają notatki, dopasowują je do jednej strony lub pozwalają im przechodzić na dodatkowe strony.

**Jak mogę zmniejszyć rozmiar pliku TIFF z notatkami bez widocznej utraty jakości?**

Zastosuj [wydajną kompresję](https://reference.aspose.com/slides/pl/java/com.aspose.slides/tiffoptions/#setCompressionType-int-) (np. `LZW` lub `RLE`), ustaw rozsądne DPI i, jeśli dopuszczalne, użyj niższego [formatu pikseli](https://reference.aspose.com/slides/pl/java/com.aspose.slides/tiffoptions/#setPixelFormat-int-) (takiego jak 8 bpp lub 1 bpp dla monochromu). Nieznaczne zmniejszenie [wymiarów obrazu](https://reference.aspose.com/slides/pl/java/com.aspose.slides/tiffoptions/#setImageSize-java.awt.Dimension-) także może pomóc, nie wpływając zauważalnie na czytelność.

**Czy czcionka w notatkach wpływa na wynik, jeśli pierwotne czcionki są nieobecne w systemie?**

Tak. Brakujące czcionki wywołują [zastępowanie](/slides/pl/java/font-selection-sequence/), co może zmienić metryki i wygląd tekstu. Aby temu zapobiec, [dostarcz wymagane czcionki](/slides/pl/java/custom-font/) lub ustaw domyślną [czcionkę awaryjną](/slides/pl/java/fallback-font/), aby używane były zamierzone kroje.