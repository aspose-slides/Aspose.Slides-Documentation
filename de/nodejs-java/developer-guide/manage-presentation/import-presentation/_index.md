---
title: Präsentationen aus PDF oder HTML in JavaScript importieren
linktitle: Präsentation importieren
type: docs
weight: 60
url: /de/nodejs-java/import-presentation/
keywords:
- Präsentation importieren
- Folie importieren
- PDF importieren
- HTML importieren
- PDF zu Präsentation
- PDF zu PPT
- PDF zu PPTX
- PDF zu ODP
- HTML zu Präsentation
- HTML zu PPT
- HTML zu PPTX
- HTML zu ODP
- PowerPoint
- OpenDocument
- Node.js
- JavaScript
- Aspose.Slides
description: "Importieren Sie PDF- und HTML-Dokumente in PowerPoint- und OpenDocument-Präsentationen mit Aspose.Slides für Node.js für nahtlose, leistungsstarke Folienverarbeitung."
---

Mit [**Aspose.Slides for Node.js via Java**](https://products.aspose.com/slides/nodejs-java/), können Sie Präsentationen aus Dateien anderer Formate importieren. Aspose.Slides stellt die Klasse [SlideCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slidecollection/) bereit, um Ihnen das Importieren von Präsentationen aus PDFs, HTML‑Dokumenten usw. zu ermöglichen.

## **PowerPoint aus PDF importieren**

In diesem Fall können Sie ein PDF in eine PowerPoint‑Präsentation konvertieren.

<img src="pdf-to-powerpoint.png" alt="pdf-to-powerpoint" style="zoom:50%;" />

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/) .
2. Rufen Sie die Methode [addFromPdf()](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideCollection#addFromPdf-java.lang.String-) auf und übergeben Sie die PDF‑Datei.
3. Verwenden Sie die Methode [save()](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#save-java.lang.String-int-) , um die Datei im PowerPoint‑Format zu speichern.

Dieser JavaScript‑Code zeigt die PDF‑zu‑PowerPoint‑Operation:
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
Vielleicht möchten Sie die kostenlose **Aspose free** [PDF to PowerPoint](https://products.aspose.app/slides/import/pdf-to-powerpoint) Web‑App testen, da sie eine Live‑Implementierung des hier beschriebenen Vorgangs ist. 
{{% /alert %}} 

## **PowerPoint aus HTML importieren**

In diesem Fall können Sie ein HTML‑Dokument in eine PowerPoint‑Präsentation konvertieren.

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/) .
2. Rufen Sie die Methode [addFromHtml()](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slidecollection/#addFromHtml-java.io.InputStream-) auf und übergeben Sie die HTML‑Datei.
3. Verwenden Sie die Methode [save()](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#save-java.lang.String-int-) , um die Datei im PowerPoint‑Format zu speichern.

Dieser JavaScript‑Code zeigt die HTML‑zu‑PowerPoint‑Operation:
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

**Werden Tabellen beim Importieren eines PDFs beibehalten, und kann ihre Erkennung verbessert werden?**

Tabellen können beim Import erkannt werden; [PdfImportOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfimportoptions/) enthält die Methode [setDetectTables](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfimportoptions/#setDetectTables), die die Tabellenerkennung aktiviert. Die Wirksamkeit hängt von der Struktur des PDFs ab.