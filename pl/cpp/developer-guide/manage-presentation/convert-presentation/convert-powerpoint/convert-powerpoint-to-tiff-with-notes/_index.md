---
title: Konwertuj prezentacje PowerPoint do TIFF z notatkami w C++
linktitle: PowerPoint do TIFF z notatkami
type: docs
weight: 100
url: /pl/cpp/convert-powerpoint-to-tiff-with-notes/
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
- C++
- Aspose.Slides
description: "Konwertuj prezentacje PowerPoint do formatu TIFF z notatkami przy użyciu Aspose.Slides dla C++. Dowiedz się, jak efektywnie eksportować slajdy z notatkami prelegenta."
---
## **Wprowadzenie**

Aspose.Slides for C++ zapewnia proste rozwiązanie do konwertowania prezentacji PowerPoint i OpenDocument (PPT, PPTX i ODP) wraz z notatkami do formatu TIFF. Format ten jest szeroko stosowany do przechowywania wysokiej jakości obrazów, drukowania i archiwizacji dokumentów. Z Aspose.Slides możesz nie tylko eksportować całe prezentacje z notatkami prelegenta, ale także generować miniatury slajdów w widoku notatek slajdu. Proces konwersji jest prosty i wydajny, wykorzystując metodę `Save` klasy [Presentation](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/) do przekształcenia całej prezentacji w serię obrazów TIFF, zachowując notatki i układ.

## **Konwertowanie prezentacji do TIFF z notatkami**

Zapisywanie prezentacji PowerPoint lub OpenDocument do formatu TIFF z notatkami przy użyciu Aspose.Slides for C++ obejmuje następujące kroki:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/): wczytaj plik PowerPoint lub OpenDocument.
1. Skonfiguruj opcje układu wyjściowego: użyj klasy [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/pl/cpp/aspose.slides.export/notescommentslayoutingoptions/), aby określić, jak notatki i komentarze mają być wyświetlane.
1. Zapisz prezentację do formatu TIFF: przekaż skonfigurowane opcje do metody [Save](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/save/).

Załóżmy, że mamy plik "speaker_notes.pptx" z następującym slajdem:

![Slajd prezentacji z notatkami prelegenta](slide_with_notes.png)

```cpp
// Utwórz instancję klasy Presentation, która reprezentuje plik prezentacji.
auto presentation = MakeObject<Presentation>(u"speaker_notes.pptx");

auto notesOptions = MakeObject<NotesCommentsLayoutingOptions>();
notesOptions->set_NotesPosition(NotesPositions::BottomFull); // Wyświetl notatki pod slajdem.

// Skonfiguruj opcje TIFF z układem notatek.
auto tiffOptions = MakeObject<TiffOptions>();
tiffOptions->set_DpiX(300);
tiffOptions->set_DpiY(300);
tiffOptions->set_SlidesLayoutOptions(notesOptions);

// Zapisz prezentację do TIFF z notatkami prelegenta.
presentation->Save(u"TIFF_with_notes.tiff", SaveFormat::Tiff, tiffOptions);

presentation->Dispose();
```

Wynik:

![Obraz TIFF z notatkami prelegenta](TIFF_with_notes.png)

{{% alert title="Tip" color="primary" %}}
Sprawdź Aspose [Darmowy konwerter PowerPoint do plakatu](https://products.aspose.app/slides/pl/conversion/convert-ppt-to-poster-online).
{{% /alert %}}

## **FAQ**

**Czy mogę kontrolować pozycję obszaru notatek w wynikowym pliku TIFF?**

Tak. Użyj [ustawień układu notatek](https://reference.aspose.com/slides/pl/cpp/aspose.slides.export/tiffoptions/set_slideslayoutoptions/), aby wybrać spośród opcji takich jak `None`, `BottomTruncated` lub `BottomFull`, które odpowiednio ukrywają notatki, dopasowują je do jednej strony lub pozwalają na ich kontynuację na kolejnych stronach.

**Jak mogę zmniejszyć rozmiar pliku TIFF z notatkami bez widocznej utraty jakości?**

Wybierz [wydajne kompresowanie](https://reference.aspose.com/slides/pl/cpp/aspose.slides.export/tiffoptions/set_compressiontype/) (np. `LZW` lub `RLE`), ustaw rozsądne DPI i, jeśli to dopuszczalne, użyj niższego [formatu pikseli](https://reference.aspose.com/slides/pl/cpp/aspose.slides.export/tiffoptions/set_pixelformat/) (np. 8 bpp lub 1 bpp dla monochromatu). Delikatne zmniejszenie [wymiarów obrazu](https://reference.aspose.com/slides/pl/cpp/aspose.slides.export/tiffoptions/set_imagesize/) również może pomóc, nie wpływając zauważalnie na czytelność.

**Czy czcionka w notatkach wpływa na wynik, jeśli oryginalne czcionki nie są zainstalowane w systemie?**

Tak. Brakujące czcionki wywołują [zastąpienie](/slides/pl/cpp/font-selection-sequence/), co może zmienić metryki i wygląd tekstu. Aby tego uniknąć, [dostarcz wymagane czcionki](/slides/pl/cpp/custom-font/) lub ustaw domyślną [czcionkę zapasową](/slides/pl/cpp/fallback-font/), aby użyte zostały zamierzone rodzaje czcionek.