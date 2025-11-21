---
title: Präsentation importieren
type: docs
weight: 60
url: /de/nodejs-java/import-presentation/
keywords: "PowerPoint importieren, PDF zu Präsentation, PDF zu PPTX, PDF zu PPT, Java, Aspose.Slides für Node.js via Java"
description: "PowerPoint‑Präsentation aus PDF importieren. PDF in PowerPoint konvertieren"
---

Mit [**Aspose.Slides for Node.js via Java**](https://products.aspose.com/slides/nodejs-java/) können Sie Präsentationen aus Dateien in anderen Formaten importieren. Aspose.Slides stellt die Klasse [SlideCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slidecollection/) zur Verfügung, um Präsentationen aus PDFs, HTML‑Dokumenten usw. zu importieren.

## **PowerPoint aus PDF importieren**

In diesem Fall können Sie ein PDF in eine PowerPoint‑Präsentation konvertieren.

<img src="pdf-to-powerpoint.png" alt="pdf-zu-powerpoint" style="zoom:50%;" />

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/).
2. Rufen Sie die Methode [addFromPdf()](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideCollection#addFromPdf-java.lang.String-) auf und übergeben Sie die PDF‑Datei.
3. Verwenden Sie die Methode [save()](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#save-java.lang.String-int-) , um die Datei im PowerPoint‑Format zu speichern.

Dieser JavaScript‑Code demonstriert die PDF‑zu‑PowerPoint‑Operation:
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
Vielleicht möchten Sie die **Aspose free**‑Web‑App [PDF to PowerPoint](https://products.aspose.app/slides/import/pdf-to-powerpoint) ausprobieren, da sie eine Live‑Implementierung des hier beschriebenen Prozesses bietet. 
{{% /alert %}} 

## **PowerPoint aus HTML importieren**

In diesem Fall können Sie ein HTML‑Dokument in eine PowerPoint‑Präsentation konvertieren.

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/).
2. Rufen Sie die Methode [addFromHtml()](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slidecollection/#addFromHtml-java.io.InputStream-) auf und übergeben Sie die HTML‑Datei.
3. Verwenden Sie die Methode [save()](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#save-java.lang.String-int-) , um die Datei im PowerPoint‑Format zu speichern.

Dieser JavaScript‑Code demonstriert die HTML‑zu‑PowerPoint‑Operation:
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

**Werden Tabellen beim Importieren eines PDFs beibehalten und kann ihre Erkennung verbessert werden?**

Tabellen können beim Import erkannt werden; [PdfImportOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfimportoptions/) enthält die Methode [setDetectTables](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfimportoptions/#setDetectTables), die die Tabellenerkennung aktiviert. Die Wirksamkeit hängt von der Struktur des PDFs ab.

{{% alert title="Note" color="warning" %}} 
Sie können Aspose.Slides auch verwenden, um HTML in andere gängige Dateiformate zu konvertieren: 

* [HTML zu Bild](https://products.aspose.com/slides/nodejs-java/conversion/html-to-image/)
* [HTML zu JPG](https://products.aspose.com/slides/nodejs-java/conversion/html-to-jpg/)
* [HTML zu XML](https://products.aspose.com/slides/nodejs-java/conversion/html-to-xml/)
* [HTML zu TIFF](https://products.aspose.com/slides/nodejs-java/conversion/html-to-tiff/)

{{% /alert %}}