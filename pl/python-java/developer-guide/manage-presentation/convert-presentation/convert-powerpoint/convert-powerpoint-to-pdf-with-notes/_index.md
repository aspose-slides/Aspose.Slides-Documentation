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
description: "Konwertuj prezentacje PPT i PPTX na PDF z notatkami prelegenta przy użyciu Aspose.Slides dla Pythona via Java. Skonfiguruj położenie notatek i zachowaj długie notatki."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak konwertować prezentacje PowerPoint na PDF z notatkami prelegenta przy użyciu Aspose.Slides for Python via Java. Możesz umieścić notatki pod każdym slajdem i pozwolić, aby długie notatki kontynuowały się na dodatkowych stronach. Inne ustawienia eksportu PDF znajdziesz w [Konwertuj PowerPoint na PDF](/slides/pl/python-java/convert-powerpoint-to-pdf/).

## **Konwertuj PowerPoint na PDF z notatkami**

Użyj metody [save](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/#save) klasy [Presentation](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/) do eksportu prezentacji PPT lub PPTX do PDF. Aby uwzględnić notatki prelegenta, utwórz obiekt [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/pl/python-java/aspose.slides/notescommentslayoutingoptions/) i skonfiguruj jego metodę [setNotesPosition](https://reference.aspose.com/slides/pl/python-java/aspose.slides/notescommentslayoutingoptions/#setNotesPosition). Przypisz ten układ do [PdfOptions](https://reference.aspose.com/slides/pl/python-java/aspose.slides/pdfoptions/) za pomocą [setSlidesLayoutOptions](https://reference.aspose.com/slides/pl/python-java/aspose.slides/pdfoptions/#setSlidesLayoutOptions).

Poniższy przykład wczytuje `sample.pptx` i eksportuje go do `output.pdf` z notatkami prelegenta pod slajdami:

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

    # Zapisz prezentację do PDF z notatkami prelegenta.
    presentation.save("output.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}}
Możesz również wypróbować [Internetowy konwerter PowerPoint na PDF](https://products.aspose.app/slides/pl/conversion).
{{% /alert %}}

## **FAQ**

**Jak mogę zapobiec obcinaniu długich notatek prelegenta?**

Użyj [NotesPositions.BottomFull](https://reference.aspose.com/slides/pl/python-java/aspose.slides/notespositions/#BottomFull), jak w powyższym przykładzie. To ustawienie wyświetla pełne notatki, używając dodatkowych stron w razie potrzeby.

**Czy mogę zachować każdy slajd i jego notatki na jednej stronie?**

Użyj [NotesPositions.BottomTruncated](https://reference.aspose.com/slides/pl/python-java/aspose.slides/notespositions/#BottomTruncated). To ustawienie ogranicza notatki do jednej strony, więc notatki, które nie mieszczą się, mogą być obcięte.

**Jak wyeksportować slajdy bez notatek prelegenta?**

Pomiń konfigurację układu notatek i użyj standardowego eksportu PDF opisanego w [Konwertuj PowerPoint na PDF](/slides/pl/python-java/convert-powerpoint-to-pdf/).