---
title: Konwertuj prezentacje PowerPoint do PDF z notatkami na Androidzie
linktitle: PowerPoint do PDF z notatkami
type: docs
weight: 50
url: /pl/androidjava/convert-powerpoint-to-pdf-with-notes/
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
- Android
- Java
- Aspose.Slides
description: "Konwertuj formaty PPT i PPTX do PDF z notatkami przy użyciu Aspose.Slides dla Androida w języku Java. Zachowaj układy i notatki prelegenta dla profesjonalnych prezentacji."
---
## **Przegląd**

W tym artykule dowiesz się, jak konwertować prezentacje PowerPoint do formatu PDF z notatkami prelegenta przy użyciu Aspose.Slides. Ten przewodnik omówi niezbędne kroki i dostarczy przykłady kodu, które pomogą Ci skutecznie wykonać to zadanie. Po zakończeniu tego artykułu będziesz w stanie:

- Zaimplementować proces konwersji, aby przekształcić slajdy PowerPoint w dokumenty PDF, zachowując notatki prelegenta.
- Dostosować wyjściowy plik PDF, aby zapewnić włączenie notatek prelegenta i ich formatowanie zgodnie z wymaganiami.

## **Konwertuj PowerPoint do PDF z notatkami**

Metoda `save` w klasie [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentation/) może być użyta do konwersji prezentacji PPT lub PPTX do PDF z notatkami prelegenta. Korzystając z Aspose.Slides, po prostu wczytujesz prezentację, konfigurujesz opcje układu przy użyciu klasy [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/notescommentslayoutingoptions/) aby uwzględnić notatki prelegenta, a następnie zapisujesz plik jako PDF. Poniższy fragment kodu pokazuje, jak przekonwertować przykładową prezentację do PDF w widoku Notatki slajdu.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
	// Skonfiguruj opcje PDF dla renderowania notatek prelegenta.
	NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
	notesOptions.setNotesPosition(NotesPositions.BottomFull); // Renderuj notatki prelegenta pod slajdem.

	PdfOptions pdfOptions = new PdfOptions();
	pdfOptions.setSlidesLayoutOptions(notesOptions);

	// Zapisz prezentację jako PDF z notatkami prelegenta.
	presentation.save("output.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
	if (presentation != null) presentation.dispose();
}
```

{{% alert color="primary" %}} 
Możesz chcieć sprawdzić internetowy konwerter PowerPoint na PDF od Aspose [Online PowerPoint to PDF Converter](https://products.aspose.app/slides/pl/conversion). 
{{% /alert %}}