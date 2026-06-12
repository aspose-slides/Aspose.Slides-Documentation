---
title: Presentaties importeren vanuit PDF of HTML in JavaScript
linktitle: Presentatie importeren
type: docs
weight: 60
url: /nl/nodejs-java/import-presentation/
keywords:
- presentatie importeren
- dia importeren
- PDF importeren
- HTML importeren
- PDF naar presentatie
- PDF naar PPT
- PDF naar PPTX
- PDF naar ODP
- HTML naar presentatie
- HTML naar PPT
- HTML naar PPTX
- HTML naar ODP
- PowerPoint
- OpenDocument
- Node.js
- JavaScript
- Aspose.Slides
description: "Importeer PDF- en HTML-documenten in PowerPoint- en OpenDocument-presentaties met Aspose.Slides voor Node.js voor een naadloze, hoogwaardige dia-verwerking."
---
## **Introductie**

Met [**Aspose.Slides for Node.js via Java**](https://products.aspose.com/slides/nl/nodejs-java/) kun je presentaties importeren vanuit bestanden in andere formaten. Aspose.Slides biedt de [SlideCollection](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/slidecollection/) klasse om presentaties te importeren vanuit PDF‑bestanden, HTML‑documenten, enz.

## **PowerPoint importeren vanuit PDF**

In dit geval kun je een PDF converteren naar een PowerPoint‑presentatie.

<img src="pdf-to-powerpoint.png" alt="pdf-to-powerpoint" style="zoom:50%;" />

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/) klasse.  
2. Roep de [addFromPdf()](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/SlideCollection#addFromPdf-java.lang.String-) methode aan en geef het PDF‑bestand door.  
3. Gebruik de [save()](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Presentation#save-java.lang.String-int-) methode om het bestand op te slaan in het PowerPoint‑formaat.

Deze JavaScript‑code toont de PDF‑naar‑PowerPoint‑bewerking:

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

Je wilt misschien de **Aspose free** [PDF naar PowerPoint](https://products.aspose.app/slides/nl/import/pdf-to-powerpoint) web‑app bekijken omdat dit een live‑implementatie is van het hier beschreven proces. 

{{% /alert %}} 

## **PowerPoint importeren vanuit HTML**

In dit geval kun je een HTML‑document converteren naar een PowerPoint‑presentatie.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/) klasse.  
2. Roep de [addFromHtml()](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/slidecollection/#addFromHtml-java.io.InputStream-) methode aan en geef het HTML‑bestand door.  
3. Gebruik de [save()](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Presentation#save-java.lang.String-int-) methode om het bestand op te slaan in het PowerPoint‑formaat.

Deze JavaScript‑code toont de HTML‑naar‑PowerPoint‑bewerking:

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

**Worden tabellen behouden bij het importeren van een PDF, en kan hun detectie worden verbeterd?**

Tabellen kunnen tijdens het importeren worden gedetecteerd; [PdfImportOptions](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/pdfimportoptions/) bevat een [setDetectTables](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/pdfimportoptions/#setDetectTables)‑methode die tabelherkenning inschakelt. De effectiviteit hangt af van de structuur van de PDF.