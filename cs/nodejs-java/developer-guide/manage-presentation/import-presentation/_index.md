---
title: Import prezentací z PDF nebo HTML v JavaScriptu
linktitle: Import prezentace
type: docs
weight: 60
url: /cs/nodejs-java/import-presentation/
keywords:
- import prezentace
- import snímku
- import PDF
- import HTML
- PDF na prezentaci
- PDF na PPT
- PDF na PPTX
- PDF na ODP
- HTML na prezentaci
- HTML na PPT
- HTML na PPTX
- HTML na ODP
- PowerPoint
- OpenDocument
- Node.js
- JavaScript
- Aspose.Slides
description: "Importujte PDF a HTML dokumenty do prezentací PowerPoint a OpenDocument pomocí Aspose.Slides pro Node.js pro plynulé a výkonné zpracování snímků."
---
## **Úvod**

Pomocí [**Aspose.Slides for Node.js via Java**](https://products.aspose.com/slides/cs/nodejs-java/) můžete importovat prezentace ze souborů v jiných formátech. Aspose.Slides poskytuje třídu [SlideCollection](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/slidecollection/), která vám umožní importovat prezentace z PDF, HTML dokumentů atd.

## **Import PowerPointu z PDF**

V tomto případě můžete převést PDF na prezentaci PowerPoint.

<img src="pdf-to-powerpoint.png" alt="pdf-to-powerpoint" style="zoom:50%;" />

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/).
2. Zavolejte metodu [addFromPdf()](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/SlideCollection#addFromPdf-java.lang.String-) a předáte soubor PDF.
3. Použijte metodu [save()](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/Presentation#save-java.lang.String-int-) k uložení souboru ve formátu PowerPoint.

Tento kód JavaScript ukazuje operaci převodu PDF do PowerPoint:

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
Možná budete chtít vyzkoušet bezplatnou webovou aplikaci **Aspose free** [PDF to PowerPoint](https://products.aspose.app/slides/cs/import/pdf-to-powerpoint), protože je to živá implementace zde popsaného postupu. 
{{% /alert %}} 

## **Import PowerPointu z HTML**

V tomto případě můžete převést dokument HTML na prezentaci PowerPoint.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/).
2. Zavolejte metodu [addFromHtml()](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/slidecollection/#addFromHtml-java.io.InputStream-) a předáte soubor PDF.
3. Použijte metodu [save()](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/Presentation#save-java.lang.String-int-) k uložení souboru ve formátu PowerPoint.

Tento kód JavaScript ukazuje operaci převodu HTML do PowerPoint:

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

**Jsou tabulky zachovány při importu PDF a lze jejich detekci zlepšit?**

Tabulky lze během importu detekovat; [PdfImportOptions](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/pdfimportoptions/) obsahuje metodu [setDetectTables](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/pdfimportoptions/#setDetectTables), která umožňuje rozpoznávání tabulek. Účinnost závisí na struktuře PDF.