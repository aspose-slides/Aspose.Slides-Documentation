---
title: Importowanie prezentacji z PDF lub HTML w JavaScript
linktitle: Importowanie prezentacji
type: docs
weight: 60
url: /pl/nodejs-java/import-presentation/
keywords:
- import prezentacji
- import slajdu
- import PDF
- import HTML
- PDF do prezentacji
- PDF do PPT
- PDF do PPTX
- PDF do ODP
- HTML do prezentacji
- HTML do PPT
- HTML do PPTX
- HTML do ODP
- PowerPoint
- OpenDocument
- Node.js
- JavaScript
- Aspose.Slides
description: "Importuj dokumenty PDF i HTML do prezentacji PowerPoint oraz OpenDocument przy użyciu Aspose.Slides dla Node.js, zapewniając płynne i wydajne przetwarzanie slajdów."
---
## **Wprowadzenie**

Korzystając z [**Aspose.Slides for Node.js via Java**](https://products.aspose.com/slides/pl/nodejs-java/), możesz importować prezentacje z plików w innych formatach. Aspose.Slides udostępnia klasę [SlideCollection](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/slidecollection/), która pozwala importować prezentacje z plików PDF, dokumentów HTML itp.

## **Import PowerPoint z PDF**

W tym przypadku konwertujesz plik PDF na prezentację PowerPoint.

<img src="pdf-to-powerpoint.png" alt="pdf-to-powerpoint" style="zoom:50%;" />

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/).
2. Wywołaj metodę [addFromPdf()](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/SlideCollection#addFromPdf-java.lang.String-) i przekaż plik PDF.
3. Użyj metody [save()](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Presentation#save-java.lang.String-int-) , aby zapisać plik w formacie PowerPoint.

Ten kod JavaScript demonstruje operację konwersji PDF do PowerPoint:

```javascript
var pres = new aspose.slides.Presentation();
try {
    pres.getSlides().addFromPdf("InputPDF.pdf");
    pres.save("OutputPresentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

{{% alert  title="Tip" color="primary" %}} 
Możesz chcieć wypróbować darmową aplikację internetową **Aspose free** [PDF to PowerPoint](https://products.aspose.app/slides/pl/import/pdf-to-powerpoint), ponieważ jest to działająca implementacja opisanej tutaj procedury. 
{{% /alert %}} 

## **Import PowerPoint z HTML**

W tym przypadku konwertujesz dokument HTML na prezentację PowerPoint.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/).
2. Wywołaj metodę [addFromHtml()](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/slidecollection/#addFromHtml-java.io.InputStream-) i przekaż plik PDF.
3. Użyj metody [save()](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Presentation#save-java.lang.String-int-) , aby zapisać plik w formacie PowerPoint.

Ten kod JavaScript demonstruje operację konwersji HTML do PowerPoint:

```javascript
var presentation = new aspose.slides.Presentation();
try {
    var htmlStream = java.newInstanceSync("java.io.FileInputStream", "page.html");
    try {
        presentation.getSlides().addFromHtml(htmlStream);
    } finally {
        if (htmlStream != null) {
            htmlStream.close();
        }
    }
    presentation.save("MyPresentation.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {
    console.log(e);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **FAQ**

**Czy tabele są zachowywane podczas importu pliku PDF i czy ich wykrywanie można ulepszyć?**

Tabele mogą być wykrywane podczas importu; [PdfImportOptions](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/pdfimportoptions/) zawiera metodę [setDetectTables](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/pdfimportoptions/#setDetectTables), która umożliwia rozpoznawanie tabel. Skuteczność zależy od struktury pliku PDF.