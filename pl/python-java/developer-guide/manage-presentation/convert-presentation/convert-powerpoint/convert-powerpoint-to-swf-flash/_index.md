---
title: Konwertuj prezentacje PowerPoint do formatu SWF Flash w Pythonie za pomocą Java
linktitle: PowerPoint do SWF
type: docs
weight: 80
url: /pl/python-java/convert-powerpoint-to-swf-flash/
keywords:
- konwertuj PowerPoint
- konwertuj prezentację
- konwertuj slajd
- konwertuj PPT
- konwertuj PPTX
- PowerPoint do SWF
- prezentacja do SWF
- slajd do SWF
- PPT do SWF
- PPTX do SWF
- PowerPoint do Flash
- prezentacja do Flash
- slajd do Flash
- PPT do Flash
- PPTX do Flash
- zapisz PPT jako SWF
- zapisz PPTX jako SWF
- eksportuj PPT do SWF
- eksportuj PPTX do SWF
- Python
- Java
- Aspose.Slides
description: "Konwertuj prezentacje PowerPoint do formatu SWF Flash w Pythonie za pomocą Java z Aspose.Slides. Skonfiguruj przeglądarkę, notatki, ukryte slajdy, kompresję i czcionki."
---
## **Przegląd**

Aspose.Slides for Python via Java umożliwia konwertowanie prezentacji PowerPoint do formatu SWF bez Microsoft PowerPoint. Użyj [Presentation.save](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/#save), aby wyeksportować prezentację, oraz [SwfOptions](https://reference.aspose.com/slides/pl/python-java/aspose.slides/swfoptions/), aby skonfigurować ustawienia przeglądarki, jakość obrazów oraz układ notatek lub komentarzy.

## **Konwertowanie prezentacji do Flash**

Załaduj plik źródłowy przy użyciu [Presentation](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/), skonfiguruj [SwfOptions](https://reference.aspose.com/slides/pl/python-java/aspose.slides/swfoptions/) i zapisz go używając [SaveFormat.Swf](https://reference.aspose.com/slides/pl/python-java/aspose.slides/saveformat/#Swf).

Poniższy przykład eksportuje `presentation.pptx` do `presentation.swf`. Wyłącza wbudowaną przeglądarkę za pomocą [setViewerIncluded](https://reference.aspose.com/slides/pl/python-java/aspose.slides/swfoptions/#setViewerIncluded) i dołącza notatki prelegenta pod slajdami przy użyciu [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/pl/python-java/aspose.slides/notescommentslayoutingoptions/).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NotesCommentsLayoutingOptions, NotesPositions, Presentation, SaveFormat, SwfOptions

presentation = Presentation("presentation.pptx")
try:
    layout_options = NotesCommentsLayoutingOptions()
    layout_options.setNotesPosition(NotesPositions.BottomFull)

    swf_options = SwfOptions()
    swf_options.setViewerIncluded(False)
    swf_options.setSlidesLayoutOptions(layout_options)

    presentation.save("presentation.swf", SaveFormat.Swf, swf_options)
finally:
    presentation.dispose()
```

Przed uruchomieniem przykładu, [zainstaluj Aspose.Slides for Python via Java](/slides/pl/python-java/installation/) i umieść `presentation.pptx` w bieżącym katalogu roboczym. JVM jest uruchamiany raz na proces Pythona.

Przykład stosuje [NotesPositions.BottomFull](https://reference.aspose.com/slides/pl/python-java/aspose.slides/notespositions/#BottomFull) poprzez [setNotesPosition](https://reference.aspose.com/slides/pl/python-java/aspose.slides/notescommentslayoutingoptions/#setNotesPosition) i przekazuje układ do [SwfOptions.setSlidesLayoutOptions](https://reference.aspose.com/slides/pl/python-java/aspose.slides/swfoptions/#setSlidesLayoutOptions). Aby dołączyć również komentarze, skonfiguruj [NotesCommentsLayoutingOptions.setCommentsPosition](https://reference.aspose.com/slides/pl/python-java/aspose.slides/notescommentslayoutingoptions/#setCommentsPosition) przed eksportem.

## **FAQ**

**Czy mogę dołączyć ukryte slajdy do pliku SWF?**

Tak. Wywołaj [SwfOptions.setShowHiddenSlides](https://reference.aspose.com/slides/pl/python-java/aspose.slides/swfoptions/#setShowHiddenSlides) z wartością `True`. Domyślnie ukryte slajdy nie są eksportowane.

**Jak mogę kontrolować kompresję i ostateczny rozmiar pliku SWF?**

Użyj [SwfOptions.setCompressed](https://reference.aspose.com/slides/pl/python-java/aspose.slides/swfoptions/#setCompressed), aby włączyć lub wyłączyć kompresję oraz [SwfOptions.setJpegQuality](https://reference.aspose.com/slides/pl/python-java/aspose.slides/swfoptions/#setJpegQuality), aby dostosować jakość obrazu JPEG. Niższa jakość JPEG może zmniejszyć rozmiar pliku kosztem dokładności obrazu.

**Do czego służy wbudowana przeglądarka i kiedy należy ją wyłączyć?**

[SwfOptions.setViewerIncluded](https://reference.aspose.com/slides/pl/python-java/aspose.slides/swfoptions/#setViewerIncluded) kontroluje, czy generowany plik SWF zawiera przeglądarkę. Przekaż `False`, gdy potrzebujesz wyeksportowanych slajdów bez wbudowanej przeglądarki, tak jak w powyższym przykładzie.

**Co się stanie, jeśli brakują czcionka źródłowa na maszynie eksportującej?**

Możesz określić domyślną czcionkę regularną za pomocą [setDefaultRegularFont](https://reference.aspose.com/slides/pl/python-java/aspose.slides/saveoptions/#setDefaultRegularFont), dziedziczoną przez [SwfOptions](https://reference.aspose.com/slides/pl/python-java/aspose.slides/swfoptions/). Wybierz czcionkę dostępną w procesie eksportu; podstawienie czcionki może zmienić wygląd tekstu i układ.