---
title: Konwertuj prezentacje do PDF z notatkami w Pythonie
linktitle: Prezentacja do PDF z notatkami
type: docs
weight: 50
url: /pl/python-net/convert-powerpoint-to-pdf-with-notes/
keywords:
- konwertuj PowerPoint
- konwertuj OpenDocument
- konwertuj prezentację
- konwertuj PPT
- konwertuj PPTX
- konwertuj ODP
- PowerPoint do PDF
- OpenDocument do PDF
- prezentacja do PDF
- PPT do PDF
- PPTX do PDF
- ODP do PDF
- notatki prelegenta
- PDF z notatkami
- Python
- Aspose.Slides
description: "Konwertuj formaty PPT, PPTX i ODP do PDF z notatkami przy użyciu Aspose.Slides dla Pythona. Zachowaj układy i notatki prelegenta dla profesjonalnych prezentacji."
---
## **Przegląd**

W tym artykule dowiesz się, jak konwertować prezentacje PowerPoint do formatu PDF z notatkami prelegenta przy użyciu Aspose.Slides. Ten przewodnik omówi niezbędne kroki i dostarczy przykłady kodu, które pomogą Ci efektywnie wykonać to zadanie. Po przeczytaniu tego artykułu będziesz w stanie:

- Zaimplementować proces konwersji, aby przekształcić slajdy PowerPoint w dokumenty PDF, zachowując notatki prelegenta.
- Dostosować wyjściowy PDF, aby zapewnić uwzględnienie i sformatowanie notatek prelegenta zgodnie z Twoimi wymaganiami.

Aby ustawić wymiary i orientację strony notatek przed eksportem, zobacz [Rozmiar strony notatek](/slides/pl/python-net/notes-size/).

## **Konwersja PowerPoint do PDF z notatkami**

Metoda `save` w klasie [Presentation](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/) może być użyta do konwersji prezentacji PPT lub PPTX do PDF z notatkami prelegenta. Korzystając z Aspose.Slides, po prostu ładujesz prezentację, konfigurować opcje układu przy użyciu klasy [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/pl/python-net/aspose.slides.export/notescommentslayoutingoptions/) aby uwzględnić notatki prelegenta, a następnie zapisujesz plik jako PDF. Poniższy fragment kodu demonstruje, jak przekonwertować przykładową prezentację na PDF w widoku notatek slajdu.

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:

    # Skonfiguruj opcje PDF do renderowania notatek prelegenta.
    notes_options = slides.export.NotesCommentsLayoutingOptions()
    notes_options.notes_position = slides.export.NotesPositions.BOTTOM_FULL

    pdf_options = slides.export.PdfOptions()
    pdf_options.slides_layout_options = notes_options

    # Zapisz prezentację jako PDF z notatkami prelegenta.
    presentation.save("output.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

{{% alert color="info" title="Note" %}}
Możesz chcieć sprawdzić Aspose [Internetowy konwerter PowerPoint do PDF](https://products.aspose.app/slides/pl/conversion).
{{% /alert %}}