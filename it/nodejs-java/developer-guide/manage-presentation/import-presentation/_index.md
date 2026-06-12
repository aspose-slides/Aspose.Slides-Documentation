---
title: Importa presentazioni da PDF o HTML in JavaScript
linktitle: Importa presentazione
type: docs
weight: 60
url: /it/nodejs-java/import-presentation/
keywords:
- importa presentazione
- importa diapositiva
- importa PDF
- importa HTML
- PDF a presentazione
- PDF a PPT
- PDF a PPTX
- PDF a ODP
- HTML a presentazione
- HTML a PPT
- HTML a PPTX
- HTML a ODP
- PowerPoint
- OpenDocument
- Node.js
- JavaScript
- Aspose.Slides
description: "Importa documenti PDF e HTML in presentazioni PowerPoint e OpenDocument con Aspose.Slides per Node.js per una gestione delle diapositive fluida e ad alte prestazioni."
---
## **Introduzione**

Utilizzando [**Aspose.Slides per Node.js via Java**](https://products.aspose.com/slides/it/nodejs-java/), è possibile importare presentazioni da file in altri formati. Aspose.Slides fornisce la classe [SlideCollection](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/slidecollection/) per consentire l'importazione di presentazioni da PDF, documenti HTML, ecc.

## **Importa PowerPoint da PDF**

In questo caso, si converte un PDF in una presentazione PowerPoint.

<img src="pdf-to-powerpoint.png" alt="pdf-to-powerpoint" style="zoom:50%;" />

1. Creare un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/).
2. Richiamare il metodo [addFromPdf()](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/SlideCollection#addFromPdf-java.lang.String-) e passare il file PDF.
3. Utilizzare il metodo [save()](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/Presentation#save-java.lang.String-int-) per salvare il file nel formato PowerPoint.

Questo codice JavaScript dimostra l'operazione di conversione da PDF a PowerPoint:

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

{{% alert  title="Suggerimento" color="primary" %}} 
Potresti voler provare l'app web **Aspose free** [PDF to PowerPoint](https://products.aspose.app/slides/it/import/pdf-to-powerpoint) perché è un'implementazione live del processo descritto qui. 
{{% /alert %}} 

## **Importa PowerPoint da HTML**

In questo caso, si converte un documento HTML in una presentazione PowerPoint.

1. Creare un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/).
2. Richiamare il metodo [addFromHtml()](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/slidecollection/#addFromHtml-java.io.InputStream-) e passare il file HTML.
3. Utilizzare il metodo [save()](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/Presentation#save-java.lang.String-int-) per salvare il file nel formato PowerPoint.

Questo codice JavaScript dimostra l'operazione di conversione da HTML a PowerPoint:

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

**Le tabelle vengono conservate durante l'importazione di un PDF e la loro rilevazione può essere migliorata?**

Le tabelle possono essere rilevate durante l'importazione; [PdfImportOptions](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/pdfimportoptions/) include un metodo [setDetectTables](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/pdfimportoptions/#setDetectTables) che abilita il riconoscimento delle tabelle. L'efficacia dipende dalla struttura del PDF.