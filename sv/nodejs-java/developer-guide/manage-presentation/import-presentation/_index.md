---
title: Importera presentationer från PDF eller HTML i JavaScript
linktitle: Importera presentation
type: docs
weight: 60
url: /sv/nodejs-java/import-presentation/
keywords:
- importera presentation
- importera bild
- importera PDF
- importera HTML
- PDF till presentation
- PDF till PPT
- PDF till PPTX
- PDF till ODP
- HTML till presentation
- HTML till PPT
- HTML till PPTX
- HTML till ODP
- PowerPoint
- OpenDocument
- Node.js
- JavaScript
- Aspose.Slides
description: "Importera PDF- och HTML-dokument till PowerPoint- och OpenDocument-presentationer med Aspose.Slides för Node.js för sömlös, högpresterande bildbehandling."
---
## **Introduktion**

Genom att använda [**Aspose.Slides for Node.js via Java**](https://products.aspose.com/slides/sv/nodejs-java/) kan du importera presentationer från filer i andra format. Aspose.Slides tillhandahåller klassen [SlideCollection](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/slidecollection/) för att låta dig importera presentationer från PDF-filer, HTML‑dokument osv.

## **Importera PowerPoint från PDF**

I det här fallet konverterar du en PDF till en PowerPoint‑presentation.

<img src="pdf-to-powerpoint.png" alt="pdf-to-powerpoint" style="zoom:50%;" />

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/).
2. Anropa metoden [addFromPdf()](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/SlideCollection#addFromPdf-java.lang.String-) och skicka PDF‑filen.
3. Använd metoden [save()](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/Presentation#save-java.lang.String-int-) för att spara filen i PowerPoint‑format.

Denna JavaScript‑kod demonstrerar PDF‑till‑PowerPoint‑operationen:

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

Du kanske vill prova **Aspose free** [PDF till PowerPoint](https://products.aspose.app/slides/sv/import/pdf-to-powerpoint) webbapp eftersom den är en live‑implementation av processen som beskrivs här. 

{{% /alert %}} 

## **Importera PowerPoint från HTML**

I det här fallet konverterar du ett HTML‑dokument till en PowerPoint‑presentation.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/).
2. Anropa metoden [addFromHtml()](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/slidecollection/#addFromHtml-java.io.InputStream-) och skicka HTML‑filen.
3. Använd metoden [save()](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/Presentation#save-java.lang.String-int-) för att spara filen i PowerPoint‑format.

Denna JavaScript‑kod demonstrerar HTML‑till‑PowerPoint‑operationen:

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

## **Vanliga frågor**

**Behålls tabeller när man importerar en PDF, och kan deras igenkänning förbättras?**

Tabeller kan detekteras vid import; [PdfImportOptions](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/pdfimportoptions/) innehåller en [setDetectTables](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/pdfimportoptions/#setDetectTables) metod som möjliggör tabelligenkänning. Effektiviteten beror på PDF:ens struktur.