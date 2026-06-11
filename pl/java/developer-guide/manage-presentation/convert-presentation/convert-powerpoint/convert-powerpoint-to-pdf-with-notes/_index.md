---
title: Konwertowanie prezentacji PowerPoint na PDF z notatkami w Javie
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

W tym artykule dowiesz się, jak konwertować prezentacje PowerPoint na format PDF z notatkami prelegenta przy użyciu Aspose.Slides. Ten przewodnik przedstawi niezbędne kroki i zapewni przykłady kodu, które pomogą Ci efektywnie wykonać to zadanie. Po przeczytaniu tego artykułu będziesz w stanie:

- Zaimplementować proces konwersji, aby przekształcić slajdy PowerPoint w dokumenty PDF, zachowując notatki prelegenta.
- Dostosować wyjściowy PDF, aby zapewnić, że notatki prelegenta są uwzględnione i sformatowane zgodnie z Twoimi wymaganiami.

## **Konwertuj PowerPoint do PDF z notatkami**

Metoda `save` w klasie [Presentation](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentation/) może być użyta do konwersji prezentacji PPT lub PPTX na PDF z notatkami prelegenta. Dzięki Aspose.Slides po prostu wczytujesz prezentację, konfigurować opcje układu przy użyciu klasy [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/pl/java/com.aspose.slides/notescommentslayoutingoptions/), aby uwzględnić notatki prelegenta, a następnie zapisujesz plik jako PDF. Poniższy fragment kodu pokazuje, jak przekonwertować przykładową prezentację na PDF w widoku Slajdu z notatkami.

```java
Presentation presentation = new Presentation("sample.pptx");

// Skonfiguruj opcje PDF dla renderowania notatek prelegenta.
NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
notesOptions.setNotesPosition(NotesPositions.BottomFull); // Renderuj notatki prelegenta pod slajdem.

PdfOptions pdfOptions = new PdfOptions();
pdfOptions.setSlidesLayoutOptions(notesOptions);

// Zapisz prezentację do PDF z notatkami prelegenta.
presentation.save("output.pdf", SaveFormat.Pdf, pdfOptions);
presentation.dispose();
```

{{% alert color="primary" %}} 
Możesz chcieć sprawdzić Aspose [Online PowerPoint to PDF Converter](https://products.aspose.app/slides/pl/conversion). 
{{% /alert %}}