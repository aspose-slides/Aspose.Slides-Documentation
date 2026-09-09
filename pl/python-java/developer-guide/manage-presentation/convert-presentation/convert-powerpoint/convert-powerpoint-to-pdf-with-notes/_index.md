---
title: Konwertuj prezentacje PowerPoint na PDF z notatkami w języku Python
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
description: "Konwertuj prezentacje PPT i PPTX na PDF z notatkami prelegenta przy użyciu Aspose.Slides dla Pythona przez Javę. Skonfiguruj położenie notatek i zachowaj długie notatki."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak konwertować prezentacje PowerPoint na PDF z notatkami prelegenta przy użyciu Aspose.Slides dla Pythona za pośrednictwem Javy. Możesz umieścić notatki pod każdym slajdem i pozwolić długim notatkom kontynuować na dodatkowych stronach. Inne ustawienia eksportu PDF znajdziesz w [Convert PowerPoint to PDF](/slides/pl/python-java/convert-powerpoint-to-pdf/).

## **Konwertowanie PowerPoint na PDF z notatkami**

Użyj metody [save](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/#save) klasy [Presentation](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/), aby wyeksportować prezentację PPT lub PPTX do formatu PDF. Aby dołączyć notatki prelegenta, utwórz obiekt [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/pl/python-java/aspose.slides/notescommentslayoutingoptions/) i skonfiguruj położenie notatek za pomocą jego metody [setNotesPosition](https://reference.aspose.com/slides/pl/python-java/aspose.slides/notescommentslayoutingoptions/#setNotesPosition). Przypisz ten układ do [PdfOptions](https://reference.aspose.com/slides/pl/python-java/aspose.slides/pdfoptions/) za pomocą [setSlidesLayoutOptions](https://reference.aspose.com/slides/pl/python-java/aspose.slides/pdfoptions/#setSlidesLayoutOptions).

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

    # Zapisz prezentację do PDF z notatkami prelegenta.
    presentation.save("output.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}}
Możesz także wypróbować [Online PowerPoint to PDF Converter](https://products.aspose.app/slides/pl/conversion).
{{% /alert %}}

## **FAQ**

**Jak mogę zapobiec obcięciu długich notatek prelegenta?**

Użyj [NotesPositions.BottomFull](https://reference.aspose.com/slides/pl/python-java/aspose.slides/notespositions/#BottomFull), jak w powyższym przykładzie. To ustawienie wyświetla pełne notatki, wykorzystując dodatkowe strony w razie potrzeby.

**Czy mogę utrzymać każdy slajd i jego notatki na jednej stronie?**

Użyj [NotesPositions.BottomTruncated](https://reference.aspose.com/slides/pl/python-java/aspose.slides/notespositions/#BottomTruncated). To ustawienie ogranicza notatki do jednej strony, więc notatki, które nie mieszczą się, mogą zostać obcięte.

**Jak wyeksportować slajdy bez notatek prelegenta?**

Pomiń konfigurację układu notatek i użyj standardowego eksportu PDF opisanego w [Convert PowerPoint to PDF](/slides/pl/python-java/convert-powerpoint-to-pdf/).