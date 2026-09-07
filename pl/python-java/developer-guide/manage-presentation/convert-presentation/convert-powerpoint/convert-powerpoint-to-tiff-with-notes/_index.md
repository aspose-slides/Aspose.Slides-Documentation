---
title: Konwertuj prezentacje PowerPoint do formatu TIFF z notatkami w Pythonie
linktitle: PowerPoint do TIFF z notatkami
type: docs
weight: 100
url: /pl/python-java/convert-powerpoint-to-tiff-with-notes/
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
- Python
- Java
- Aspose.Slides
description: "Konwertuj prezentacje PowerPoint do formatu TIFF z notatkami przy użyciu Aspose.Slides dla Pythona przez Java. Dowiedz się, jak efektywnie eksportować slajdy z notatkami prelegenta."
---
## **Wprowadzenie**

Aspose.Slides for Python via Java zapewnia proste rozwiązanie umożliwiające konwersję prezentacji PowerPoint i OpenDocument (PPT, PPTX i ODP) wraz z notatkami do formatu TIFF. Format ten jest szeroko stosowany do przechowywania wysokiej jakości obrazów, drukowania i archiwizacji dokumentów. Użyj metody [save](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/#save) klasy [Presentation](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/) aby wyeksportować slajdy i ich notatki prelegenta do jednego wielostronicowego pliku TIFF.

## **Konwersja prezentacji do TIFF z notatkami**

Zapisywanie prezentacji PowerPoint lub OpenDocument do formatu TIFF z notatkami przy użyciu Aspose.Slides for Python via Java obejmuje następujące kroki:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/): wczytaj plik PowerPoint lub OpenDocument.  
2. Skonfiguruj opcje układu wyjściowego: użyj klasy [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/pl/python-java/aspose.slides/notescommentslayoutingoptions/) aby określić, jak mają być wyświetlane notatki i komentarze.  
3. Zapisz prezentację w formacie TIFF: przekaż skonfigurowane opcje do metody [save](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/#save).

Załóżmy, że mamy plik „speaker_notes.pptx” z następującym slajdem:

![Slajd prezentacji z notatkami prelegenta](slide_with_notes.png)

Poniższy fragment kodu demonstruje, jak przekształcić prezentację w obraz TIFF w widoku Notatki slajdu przy użyciu metody [setSlidesLayoutOptions](https://reference.aspose.com/slides/pl/python-java/aspose.slides/tiffoptions/#setSlidesLayoutOptions).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NotesCommentsLayoutingOptions, NotesPositions, Presentation, SaveFormat, TiffOptions

presentation = Presentation("speaker_notes.pptx")
try:
    # Wyświetl pełne notatki prelegenta pod każdym slajdem.
    notes_options = NotesCommentsLayoutingOptions()
    notes_options.setNotesPosition(NotesPositions.BottomFull)

    # Skonfiguruj rozdzielczość TIFF i układ notatek.
    tiff_options = TiffOptions()
    tiff_options.setDpiX(300)
    tiff_options.setDpiY(300)
    tiff_options.setSlidesLayoutOptions(notes_options)

    # Zapisz prezentację jako TIFF z notatkami prelegenta.
    presentation.save("TIFF_with_notes.tiff", SaveFormat.Tiff, tiff_options)
finally:
    presentation.dispose()
```

Wynik:

![Obraz TIFF z notatkami prelegenta](TIFF_with_notes.png)

{{% alert title="Tip" color="success" %}}
Sprawdź darmowy narzędzie Aspose [Free PowerPoint to Poster Converter](https://products.aspose.app/slides/pl/conversion/convert-ppt-to-poster-online).
{{% /alert %}}

## **FAQ**

**Czy mogę kontrolować położenie obszaru notatek w wygenerowanym pliku TIFF?**

Tak. Skonfiguruj metodę [setNotesPosition](https://reference.aspose.com/slides/pl/python-java/aspose.slides/notescommentslayoutingoptions/#setNotesPosition) z wartością [NotesPositions.BottomTruncated](https://reference.aspose.com/slides/pl/python-java/aspose.slides/notespositions/#BottomTruncated), aby zmieścić notatki na jednej stronie, ewentualnie je przycinając, lub [NotesPositions.BottomFull](https://reference.aspose.com/slides/pl/python-java/aspose.slides/notespositions/#BottomFull), aby wyświetlić wszystkie notatki, używając dodatkowych stron w razie potrzeby. Aby wyeksportować slajdy bez notatek, pomiń konfigurację układu notatek, jak pokazano w [Convert PowerPoint to TIFF](/slides/pl/python-java/convert-powerpoint-to-tiff/).

**Jak mogę zmniejszyć rozmiar pliku TIFF z notatkami bez utraty jakości obrazu?**

Użyj bezstratnej kompresji [LZW compression](https://reference.aspose.com/slides/pl/python-java/aspose.slides/tiffcompressiontypes/#LZW) poprzez metodę [setCompressionType](https://reference.aspose.com/slides/pl/python-java/aspose.slides/tiffoptions/#setCompressionType). Zmniejszenie rozdzielczości lub głębi kolorów może dodatkowo obniżyć rozmiar pliku, ale może wpływać na jakość obrazu i czytelność notatek. Zobacz [TIFF export settings](/slides/pl/python-java/convert-powerpoint-to-tiff/) po więcej opcji.

**Czy czcionka w notatkach wpływa na wynik, jeśli oryginalne czcionki nie są zainstalowane w systemie?**

Tak. Brakujące czcionki wywołują [font substitution](/slides/pl/python-java/font-selection-sequence/), co może zmienić wymiary i wygląd tekstu. [Supply the required fonts](/slides/pl/python-java/custom-font/) aby zachować zamierzone kroje pisma.