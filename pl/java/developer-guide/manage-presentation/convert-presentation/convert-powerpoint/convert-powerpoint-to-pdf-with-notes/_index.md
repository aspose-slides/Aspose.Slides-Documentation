---
title: Konwertuj prezentacje PowerPoint na PDF z notatkami w Javie
linktitle: PowerPoint na PDF z notatkami
type: docs
weight: 50
url: /pl/java/convert-powerpoint-to-pdf-with-notes/
keywords:
- konwertuj PowerPoint
- konwertuj prezentację
- konwertuj slajd
- konwertuj PPT
- konwertuj PPTX
- PowerPoint na PDF
- prezentacja na PDF
- slajd na PDF
- PPT na PDF
- PPTX na PDF
- zapisz prezentację jako PDF
- zapisz PPT jako PDF
- zapisz PPTX jako PDF
- eksportuj PPT do PDF
- eksportuj PPTX do PDF
- notatki prelegenta
- PDF z notatkami
- Java
- Aspose.Slides
description: "Konwertuj formaty PPT i PPTX na PDF z notatkami przy użyciu Aspose.Slides dla Javy. Zachowaj układy i notatki prelegenta w profesjonalnych prezentacjach."
---
## **Przegląd**

W tym artykule dowiesz się, jak konwertować prezentacje PowerPoint do formatu PDF z notatkami prelegenta przy użyciu Aspose.Slides. Poradnik opisze niezbędne kroki i dostarczy przykłady kodu, które pomogą efektywnie wykonać to zadanie. Po przeczytaniu tego artykułu będziesz w stanie:

- Zaimplementować proces konwersji, aby przekształcić slajdy PowerPoint w dokumenty PDF, zachowując notatki prelegenta.
- Dostosować wyjściowy PDF, aby notatki prelegenta były uwzględnione i sformatowane zgodnie z Twoimi wymaganiami.

## **Konwertowanie PowerPoint do PDF z notatkami**

Metoda `save` w klasie [Presentation](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentation/) może być użyta do konwersji prezentacji PPT lub PPTX do PDF z notatkami prelegenta. Korzystając z Aspose.Slides, po prostu ładujesz prezentację, konfigurujesz opcje układu za pomocą klasy [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/pl/java/com.aspose.slides/notescommentslayoutingoptions/) aby uwzględnić notatki prelegenta, a następnie zapisujesz plik jako PDF. Poniższy fragment kodu demonstruje, jak skonwertować przykładową prezentację do PDF w widoku Notatki slajdu.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");

// Skonfiguruj opcje PDF do renderowania notatek prelegenta.
NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
notesOptions.setNotesPosition(NotesPositions.BottomFull); // Renderuj notatki prelegenta pod slajdem.

PdfOptions pdfOptions = new PdfOptions();
pdfOptions.setSlidesLayoutOptions(notesOptions);

// Zapisz prezentację jako PDF z notatkami prelegenta.
presentation.save("output.pdf", SaveFormat.Pdf, pdfOptions);
presentation.dispose();
```

{{% alert color="info" %}} 

Możesz chcieć sprawdzić Aspose [Online PowerPoint to PDF Converter](https://products.aspose.app/slides/pl/conversion). 

{{% /alert %}}