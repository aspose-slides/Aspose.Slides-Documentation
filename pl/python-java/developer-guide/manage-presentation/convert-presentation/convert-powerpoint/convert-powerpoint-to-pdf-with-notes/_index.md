---
title: Konwertuj prezentacje PowerPoint na PDF z notatkami w Pythonie
linktitle: PowerPoint do PDF z notatkami
type: docs
weight: 50
url: /pl/python-java/convert-powerpoint-to-pdf-with-notes/
keywords:
- konwertuj PowerPoint
- konwertuj prezentację
- konwertuj PPT
- konwertuj PPTX
- PowerPoint do PDF
- prezentacja do PDF
- PPT do PDF
- PPTX do PDF
- zapisz prezentację jako PDF
- eksportuj PPT do PDF
- eksportuj PPTX do PDF
- notatki prelegenta
- PDF z notatkami
- Python
- Java
- Aspose.Slides
description: "Konwertuj prezentacje PPT i PPTX na PDF z notatkami prelegenta przy użyciu Aspose.Slides for Python via Java. Skonfiguruj położenie notatek i zachowaj długie notatki."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak przekonwertować prezentacje PowerPoint do formatu PDF z notatkami prelegenta przy użyciu Aspose.Slides for Python via Java. Możesz dołączyć notatki pod każdym slajdem i umożliwić długim notatkom kontynuację na dodatkowych stronach. Inne ustawienia eksportu PDF znajdziesz w [Konwertuj PowerPoint do PDF](/slides/pl/python-java/convert-powerpoint-to-pdf/).

Aby ustawić wymiary i orientację strony notatek przed eksportem, zobacz [Rozmiar strony notatek](/slides/pl/python-java/notes-size/).

## **Konwertuj PowerPoint do PDF z notatkami**

Użyj metody [save](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/#save) klasy [Presentation](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/), aby wyeksportować prezentację PPT lub PPTX do PDF. Aby uwzględnić notatki prelegenta, utwórz obiekt [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/pl/python-java/aspose.slides/notescommentslayoutingoptions/) i skonfiguruj położenie notatek za pomocą jego metody [setNotesPosition](https://reference.aspose.com/slides/pl/python-java/aspose.slides/notescommentslayoutingoptions/#setNotesPosition). Przypisz ten układ do [PdfOptions](https://reference.aspose.com/slides/pl/python-java/aspose.slides/pdfoptions/) używając [setSlidesLayoutOptions](https://reference.aspose.com/slides/pl/python-java/aspose.slides/pdfoptions/#setSlidesLayoutOptions).

Poniższy przykład ładuje `sample.pptx` i eksportuje go do `output.pdf` z notatkami prelegenta pod slajdami:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NotesCommentsLayoutingOptions, NotesPositions, PdfOptions, Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    # Skonfiguruj opcje PDF dla renderowania notatek prelegenta.
    notes_options = NotesCommentsLayoutingOptions()
    notes_options.setNotesPosition(NotesPositions.BottomFull)

    pdf_options = PdfOptions()
    pdf_options.setSlidesLayoutOptions(notes_options)

    # Zapisz prezentację jako PDF z notatkami prelegenta.
    presentation.save("output.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Uwaga" %}}
Możesz również wypróbować [Internetowy konwerter PowerPoint do PDF](https://products.aspose.app/slides/pl/conversion).
{{% /alert %}}

## **FAQ**

**Jak mogę zapobiec obcięciu długich notatek prelegenta?**

Użyj [NotesPositions.BottomFull](https://reference.aspose.com/slides/pl/python-java/aspose.slides/notespositions/#BottomFull), tak jak w powyższym przykładzie. To ustawienie wyświetla pełne notatki, używając dodatkowych stron w razie potrzeby.

**Czy mogę zachować każdy slajd i jego notatki na jednej stronie?**

Użyj [NotesPositions.BottomTruncated](https://reference.aspose.com/slides/pl/python-java/aspose.slides/notespositions/#BottomTruncated). To ustawienie ogranicza notatki do jednej strony, więc notatki, które nie mieszczą się, mogą zostać przycięte.

**Jak wyeksportować slajdy bez notatek prelegenta?**

Pomiń konfigurację układu notatek i użyj standardowego eksportu PDF opisanego w [Konwertuj PowerPoint do PDF](/slides/pl/python-java/convert-powerpoint-to-pdf/).