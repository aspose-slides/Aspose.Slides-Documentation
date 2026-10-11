---
title: Konwertuj prezentacje PowerPoint do PDF z notatkami w Javie
linktitle: PowerPoint do PDF z notatkami
type: docs
weight: 50
url: /pl/java/convert-powerpoint-to-pdf-with-notes/
keywords:
- konwertuj PowerPoint
- konwertuj prezentację
- konwertuj slajd
- konwertuj PPT
- konwertuj PPTX
- PowerPoint do PDF
- prezentacja do PDF
- slajd do PDF
- PPT do PDF
- PPTX do PDF
- zapisz prezentację jako PDF
- zapisz PPT jako PDF
- zapisz PPTX jako PDF
- eksportuj PPT do PDF
- eksportuj PPTX do PDF
- notatki prelegenta
- PDF z notatkami
- Java
- Aspose.Slides
description: "Konwertuj formaty PPT i PPTX do PDF z notatkami przy użyciu Aspose.Slides dla Javy. Zachowaj układy i notatki prelegenta dla profesjonalnych prezentacji."
---
## **Przegląd**

W tym artykule dowiesz się, jak konwertować prezentacje PowerPoint do formatu PDF z notatkami prelegenta przy użyciu Aspose.Slides. Ten przewodnik omówi niezbędne kroki i dostarczy przykłady kodu, aby pomóc Ci skutecznie wykonać to zadanie. Po zakończeniu tego artykułu będziesz w stanie:

- Zaimplementować proces konwersji, aby przekształcić slajdy PowerPoint w dokumenty PDF, zachowując notatki prelegenta.
- Dostosować wyjściowy plik PDF, aby notatki prelegenta były uwzględnione i sformatowane zgodnie z Twoimi wymaganiami.

Aby ustawić rozmiar i orientację strony notatek przed eksportem, zobacz [Rozmiar strony notatek](/slides/pl/java/notes-size/).

## **Konwertuj PowerPoint do PDF z notatkami**

Metoda `save` w klasie [Presentation](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentation/) może być użyta do konwersji prezentacji PPT lub PPTX do PDF z notatkami prelegenta. Korzystając z Aspose.Slides, po prostu wczytujesz prezentację, konfigurować opcje układu za pomocą klasy [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/pl/java/com.aspose.slides/notescommentslayoutingoptions/) aby uwzględnić notatki prelegenta, a następnie zapisujesz plik jako PDF. Poniższy fragment kodu demonstruje, jak przekonwertować przykładową prezentację do PDF w trybie slajdu z notatkami.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");

// Skonfiguruj opcje PDF dla renderowania notatek prelegenta.
NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
notesOptions.setNotesPosition(NotesPositions.BottomFull); // Renderuj notatki prelegenta pod slajdem.

PdfOptions pdfOptions = new PdfOptions();
pdfOptions.setSlidesLayoutOptions(notesOptions);

// Save the presentation to PDF with speaker notes.
presentation.save("output.pdf", SaveFormat.Pdf, pdfOptions);
presentation.dispose();
```

{{% alert color="info" title="Note" %}}
Możesz chcieć wypróbować Aspose [Internetowy konwerter PowerPoint do PDF](https://products.aspose.app/slides/pl/conversion).
{{% /alert %}}