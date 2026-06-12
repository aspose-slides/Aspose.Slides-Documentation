---
title: Import prezentací z PDF nebo HTML na Androidu
linktitle: Import prezentace
type: docs
weight: 60
url: /cs/androidjava/import-presentation/
keywords:
- import prezentace
- import snímku
- import PDF
- import HTML
- PDF do prezentace
- PDF do PPT
- PDF do PPTX
- PDF do ODP
- HTML do prezentace
- HTML do PPT
- HTML do PPTX
- HTML do ODP
- PowerPoint
- OpenDocument
- Android
- Java
- Aspose.Slides
description: "Importujte PDF a HTML dokumenty do prezentací PowerPoint a OpenDocument v Javě s Aspose.Slides pro Android pro plynulé a vysoce výkonné zpracování snímků."
---
## **Úvod**

Pomocí [**Aspose.Slides for Android via Java**](https://products.aspose.com/slides/cs/androidjava/) můžete importovat prezentace ze souborů v jiných formátech. Aspose.Slides poskytuje třídu [SlideCollection](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/slidecollection/), která vám umožní importovat prezentace z PDF, HTML dokumentů atd.

## **Import PowerPointu z PDF**

V tomto případě můžete převést PDF do prezentace PowerPoint.

<img src="pdf-to-powerpoint.png" alt="pdf-to-powerpoint" style="zoom:50%;" />

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/).
2. Zavolejte metodu [addFromPdf()](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/SlideCollection#addFromPdf-java.lang.String-) a předáte soubor PDF.
3. Použijte metodu [save()](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/Presentation#save-java.lang.String-int-) k uložení souboru ve formátu PowerPoint.

Tento Java kód ukazuje operaci převodu PDF do PowerPointu:

```java
Presentation pres = new Presentation();
try {
    pres.getSlides().addFromPdf("InputPDF.pdf");
    pres.save("OutputPresentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert  title="Tip" color="primary" %}} 
Možná budete chtít vyzkoušet **Aspose free** [PDF to PowerPoint](https://products.aspose.app/slides/cs/import/pdf-to-powerpoint) webovou aplikaci, protože je živou implementací procesu popsaného zde. 
{{% /alert %}} 

## **Import PowerPointu z HTML**

V tomto případě můžete převést HTML dokument do prezentace PowerPoint.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/).
2. Zavolejte metodu [addFromHtml()](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/slidecollection/#addFromHtml-java.io.InputStream-) a předáte soubor HTML.
3. Použijte metodu [save()](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/Presentation#save-java.lang.String-int-) k uložení souboru ve formátu PowerPoint.

Tento Java kód ukazuje operaci převodu HTML do PowerPointu: 

```java
Presentation presentation = new Presentation();
try {
    FileInputStream htmlStream = new FileInputStream("page.html");
    try {
        presentation.getSlides().addFromHtml(htmlStream);
    } finally {
        if (htmlStream != null) htmlStream.close();
    }

    presentation.save("MyPresentation.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Často kladené otázky**

**Zůstávají tabulky zachovány při importu PDF a lze jejich detekci zlepšit?**

Tabulky lze během importu detekovat; [PdfImportOptions](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/pdfimportoptions/) obsahuje metodu [setDetectTables](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/pdfimportoptions/#setDetectTables-boolean-), která umožňuje rozpoznávání tabulek. Účinnost závisí na struktuře PDF.