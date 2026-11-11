---
title: Konwersja prezentacji PowerPoint do PDF z notatkami w PHP
linktitle: PowerPoint do PDF z notatkami
type: docs
weight: 50
url: /pl/php-java/convert-powerpoint-to-pdf-with-notes/
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
- PHP
- Aspose.Slides
description: "Konwertuj formaty PPT i PPTX do PDF z notatkami przy użyciu Aspose.Slides dla PHP poprzez Javę. Zachowaj układy i notatki prelegenta w profesjonalnych prezentacjach."
---
## **Przegląd**

W tym artykule dowiesz się, jak konwertować prezentacje PowerPoint do formatu PDF z notatkami prelegenta przy użyciu Aspose.Slides. Poradnik opisuje niezbędne kroki i zawiera przykłady kodu, które pomogą Ci efektywnie wykonać to zadanie. Po przeczytaniu tego artykułu będziesz w stanie:

- Zaimplementować proces konwersji, przekształcając slajdy PowerPoint w dokumenty PDF z zachowaniem notatek prelegenta.
- Dostosować wyjściowy plik PDF, aby notatki prelegenta zostały uwzględnione i sformatowane zgodnie z Twoimi wymaganiami.

Aby ustawić wymiary i orientację strony notatek przed eksportem, zobacz [Notes Page Size](/slides/pl/php-java/notes-size/).

## **Konwersja PowerPoint do PDF z notatkami**

Metoda `save` w klasie [Presentation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation/) może być użyta do konwersji prezentacji PPT lub PPTX do PDF z notatkami prelegenta. Korzystając z Aspose.Slides, po prostu wczytujesz prezentację, konfigurujesz opcje układu przy użyciu klasy [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/pl/php-java/aspose.slides/notescommentslayoutingoptions/) w celu uwzględnienia notatek prelegenta, a następnie zapisujesz plik jako PDF. Poniższy fragment kodu pokazuje, jak przekonwertować przykładową prezentację do PDF w widoku Notatki slajdu.

```php
$presentation = new Presentation("sample.pptx");

// Skonfiguruj opcje PDF do renderowania notatek prelegenta.
$notesOptions = new NotesCommentsLayoutingOptions();
$notesOptions->setNotesPosition(NotesPositions::BottomFull); // Renderuj notatki prelegenta pod slajdem.

$pdfOptions = new PdfOptions();
$pdfOptions->setSlidesLayoutOptions($notesOptions);

// Save the presentation to PDF with speaker notes.
$presentation->save("output.pdf", SaveFormat::Pdf, $pdfOptions);
$presentation->dispose();
```

{{% alert color="info" title="Uwaga" %}}
Możesz sprawdzić Aspose [Online PowerPoint to PDF Converter](https://products.aspose.app/slides/pl/conversion).
{{% /alert %}}