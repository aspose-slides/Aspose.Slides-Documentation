---
title: Konwertuj prezentacje PowerPoint na PDF z notatkami na Androidzie
linktitle: PowerPoint na PDF z notatkami
type: docs
weight: 50
url: /pl/androidjava/convert-powerpoint-to-pdf-with-notes/
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
- Android
- Java
- Aspose.Slides
description: "Konwertuj formaty PPT i PPTX na PDF z notatkami przy użyciu Aspose.Slides dla Androida w Javie. Zachowaj układy i notatki prelegenta dla profesjonalnych prezentacji."
---
## **Przegląd**

W tym artykule dowiesz się, jak konwertować prezentacje PowerPoint na format PDF z notatkami prelegenta przy użyciu Aspose.Slides. Ten przewodnik omówi niezbędne kroki i dostarczy przykłady kodu, które pomogą Ci efektywnie wykonać to zadanie. Po przeczytaniu tego artykułu będziesz w stanie:

- Zaimplementować proces konwersji, aby przekształcić slajdy PowerPoint w dokumenty PDF, zachowując notatki prelegenta.
- Dostosować wyjściowy plik PDF, aby zapewnić uwzględnienie notatek prelegenta i ich formatowanie zgodnie z Twoimi wymaganiami.

Aby ustawić wymiary i orientację strony z notatkami przed eksportem, zobacz [Rozmiar strony notatek](/slides/pl/androidjava/notes-size/).

## **Konwertuj PowerPoint na PDF z notatkami**

Metoda `save` w klasie [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentation/) może być użyta do konwersji prezentacji PPT lub PPTX na PDF z notatkami prelegenta. Korzystając z Aspose.Slides, po prostu wczytujesz prezentację, konfigurujesz opcje układu za pomocą klasy [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/notescommentslayoutingoptions/), aby uwzględnić notatki prelegenta, a następnie zapisujesz plik jako PDF. Poniższy fragment kodu pokazuje, jak skonwertować przykładową prezentację na PDF w widoku slajdu z notatkami.

```java
import com.aspose.slides.*;

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

{{% alert color="info" title="Note" %}}
Możesz chcieć wypróbować Aspose [Online PowerPoint to PDF Converter](https://products.aspose.app/slides/pl/conversion).
{{% /alert %}}