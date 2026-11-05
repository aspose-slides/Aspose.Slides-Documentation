---
title: Konwertuj prezentacje PowerPoint na PDF z notatkami w JavaScript
linktitle: PowerPoint na PDF z notatkami
type: docs
weight: 50
url: /pl/nodejs-java/convert-powerpoint-to-pdf-with-notes/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Konwertuj formaty PPT i PPTX na PDF z notatkami w JavaScript przy użyciu Aspose.Slides dla Node.js. Zachowaj układy i notatki prelegenta w profesjonalnych prezentacjach."
---
## **Przegląd**

W tym artykule dowiesz się, jak przekonwertować prezentacje PowerPoint na format PDF z notatkami prelegenta przy użyciu Aspose.Slides. Poradnik obejmuje niezbędne kroki i zawiera przykłady kodu, które pomogą Ci efektywnie wykonać to zadanie. Po przeczytaniu tego artykułu będziesz w stanie:

- Zaimplementować proces konwersji, aby przekształcić slajdy PowerPoint w dokumenty PDF, zachowując notatki prelegenta.  
- Dostosować wyjściowy PDF, aby notatki prelegenta zostały uwzględnione i sformatowane zgodnie z wymaganiami.

Aby ustawić wymiary i orientację strony notatek przed eksportem, zobacz [Rozmiar strony notatek](/slides/pl/nodejs-java/notes-size/).

## **Konwersja PowerPoint do PDF z notatkami**

Metoda `save` w klasie [Prezentacja](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation/) może być użyta do konwersji prezentacji PPT lub PPTX na PDF z notatkami prelegenta. Korzystając z Aspose.Slides, po prostu wczytujesz prezentację, konfigurowałeś opcje układu przy użyciu klasy [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/notescommentslayoutingoptions/) aby uwzględnić notatki prelegenta, a następnie zapisujesz plik jako PDF. Poniższy fragment kodu pokazuje, jak przekonwertować przykładową prezentację na PDF w widoku Notatki Slajdu.

```js
const asposeSlides = require("aspose.slides.via.java");

let presentation = new asposeSlides.Presentation("sample.pptx");

// Skonfiguruj opcje PDF do renderowania notatek prelegenta.
let notesOptions = new asposeSlides.NotesCommentsLayoutingOptions();
notesOptions.setNotesPosition(asposeSlides.NotesPositions.BottomFull); // Renderuj notatki prelegenta pod slajdem.

let pdfOptions = new asposeSlides.PdfOptions();
pdfOptions.setSlidesLayoutOptions(notesOptions);

// Zapisz prezentację jako PDF z notatkami prelegenta.
presentation.save("output.pdf", asposeSlides.SaveFormat.Pdf, pdfOptions);
presentation.dispose();
```

{{% alert color="info" title="Uwaga" %}}
Możesz chcieć wypróbować konwerter Aspose [Internetowy konwerter PowerPoint do PDF](https://products.aspose.app/slides/pl/conversion).
{{% /alert %}}