---
title: Konwertuj prezentacje PowerPoint do PDF z notatkami w JavaScript
linktitle: PowerPoint do PDF z notatkami
type: docs
weight: 50
url: /pl/nodejs-java/convert-powerpoint-to-pdf-with-notes/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Konwertuj formaty PPT i PPTX do PDF z notatkami w JavaScript przy użyciu Aspose.Slides dla Node.js. Zachowaj układy i notatki prelegenta dla profesjonalnych prezentacji."
---
## **Przegląd**

W tym artykule dowiesz się, jak przekonwertować prezentacje PowerPoint do formatu PDF z notatkami prelegenta przy użyciu Aspose.Slides. Poradnik obejmuje niezbędne kroki i zawiera przykłady kodu, które pomogą Ci efektywnie wykonać to zadanie. Po przeczytaniu tego artykułu będziesz w stanie:

- Zaimplementować proces konwersji, aby przekształcić slajdy PowerPoint w dokumenty PDF, zachowując notatki prelegenta.
- Dostosować wyjściowy PDF, aby notatki prelegenta były uwzględnione i sformatowane zgodnie z Twoimi wymaganiami.

## **Konwertuj PowerPoint do PDF z notatkami**

Metodę `save` w klasie [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation/) można użyć do konwersji prezentacji PPT lub PPTX do PDF z notatkami prelegenta. Korzystając z Aspose.Slides, po prostu ładujesz prezentację, konfigurujesz opcje układu za pomocą klasy [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/notescommentslayoutingoptions/) aby uwzględnić notatki prelegenta, a następnie zapisujesz plik jako PDF. Poniższy fragment kodu demonstruje, jak przekonwertować przykładową prezentację do PDF w widoku Notatki slajdu.

```js
let presentation = new asposeSlides.Presentation("sample.pptx");

// Skonfiguruj opcje PDF dla renderowania notatek prelegenta.
let notesOptions = new asposeSlides.NotesCommentsLayoutingOptions();
notesOptions.setNotesPosition(asposeSlides.NotesPositions.BottomFull); // Renderuj notatki prelegenta pod slajdem.

let pdfOptions = new asposeSlides.PdfOptions();
pdfOptions.setSlidesLayoutOptions(notesOptions);

// Zapisz prezentację jako PDF z notatkami prelegenta.
presentation.save("output.pdf", asposeSlides.SaveFormat.Pdf, pdfOptions);
presentation.dispose();
```

{{% alert color="primary" %}} 

Możesz chcieć sprawdzić Aspose [Online PowerPoint to PDF Converter](https://products.aspose.app/slides/pl/conversion). 

{{% /alert %}}