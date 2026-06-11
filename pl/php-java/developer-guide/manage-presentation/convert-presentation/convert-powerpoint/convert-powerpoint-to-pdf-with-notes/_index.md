---
title: Konwertuj prezentacje PowerPoint na PDF z notatkami w PHP
linktitle: PowerPoint na PDF z notatkami
type: docs
weight: 50
url: /pl/php-java/convert-powerpoint-to-pdf-with-notes/
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
- PHP
- Aspose.Slides
description: "Konwertuj formaty PPT i PPTX na PDF z notatkami przy użyciu Aspose.Slides dla PHP poprzez Java. Zachowaj układy i notatki prelegenta w profesjonalnych prezentacjach."
---
## **Przegląd**

W tym artykule dowiesz się, jak konwertować prezentacje PowerPoint na format PDF z notatkami prelegenta przy użyciu Aspose.Slides. Ten przewodnik przedstawi niezbędne kroki i dostarczy przykłady kodu, aby pomóc Ci skutecznie wykonać to zadanie. Po przeczytaniu tego artykułu będziesz w stanie:

- Zaimplementować proces konwersji, aby przekształcić slajdy PowerPoint w dokumenty PDF, zachowując notatki prelegenta.
- Dostosować wygenerowany PDF, aby zapewnić włączenie notatek prelegenta i ich formatowanie zgodnie z wymaganiami.

## **Konwertuj PowerPoint na PDF z notatkami**

Metoda `save` w klasie [Presentation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation/) może być użyta do konwersji prezentacji PPT lub PPTX na PDF z notatkami prelegenta. Korzystając z Aspose.Slides, po prostu ładować prezentację, konfigurować opcje układu przy użyciu klasy [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/pl/php-java/aspose.slides/notescommentslayoutingoptions/), aby uwzględnić notatki prelegenta, a następnie zapisać plik jako PDF. Poniższy fragment kodu demonstruje, jak skonwertować przykładową prezentację na PDF w widoku Notatek Slajdu.

```php
$presentation = new Presentation("sample.pptx");

// Skonfiguruj opcje PDF dla renderowania notatek prelegenta.
$notesOptions = new NotesCommentsLayoutingOptions();
$notesOptions->setNotesPosition(NotesPositions::BottomFull); // Renderuj notatki prelegenta pod slajdem.

$pdfOptions = new PdfOptions();
$pdfOptions->setSlidesLayoutOptions($notesOptions);

// Zapisz prezentację do PDF z notatkami prelegenta.
$presentation->save("output.pdf", SaveFormat::Pdf, $pdfOptions);
$presentation->dispose();
```

{{% alert color="primary" %}}  
Możesz chcieć sprawdzić Aspose [Online PowerPoint to PDF Converter](https://products.aspose.app/slides/pl/conversion).  
{{% /alert %}}