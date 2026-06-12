---
title: Importovat prezentace z PDF nebo HTML v Javě
linktitle: Importovat prezentaci
type: docs
weight: 60
url: /cs/java/import-presentation/
keywords:
- importovat prezentaci
- importovat snímek
- importovat PDF
- importovat HTML
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
- Java
- Aspose.Slides
description: "Jednoduše importujte PDF a HTML dokumenty do prezentací PowerPoint a OpenDocument v Javě pomocí Aspose.Slides pro plynulé a vysoce výkonné zpracování snímků."
---
## **Úvod**

Pomocí Aspose.Slides můžete importovat prezentace ze souborů v jiných formátech. Aspose.Slides poskytuje třídu [SlideCollection](https://reference.aspose.com/slides/cs/java/com.aspose.slides/slidecollection/), která umožňuje importovat prezentace z dokumentů PDF a HTML.

## **Import PowerPoint z PDF**

V tomto případě můžete převést PDF do prezentace PowerPoint.

<img src="pdf-to-powerpoint.png" alt="pdf-to-powerpoint" style="zoom:50%;" />

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/). 
2. Zavolejte metodu [addFromPdf()](https://reference.aspose.com/slides/cs/java/com.aspose.slides/SlideCollection#addFromPdf-java.lang.String-) a předáte PDF soubor. 
3. Použijte metodu [save()](https://reference.aspose.com/slides/cs/java/com.aspose.slides/Presentation#save-java.lang.String-int-) k uložení souboru ve formátu PowerPoint.

Tento kód v jazyce Java demonstruje operaci převodu PDF do PowerPoint:

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
Možná budete chtít vyzkoušet **Aspose free** [PDF to PowerPoint](https://products.aspose.app/slides/cs/import/pdf-to-powerpoint) webovou aplikaci, protože jde o živou implementaci popsaného procesu. 
{{% /alert %}} 

## **Import PowerPoint z HTML**

V tomto případě můžete převést dokument HTML do prezentace PowerPoint.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/). 
2. Zavolejte metodu [addFromHtml()](https://reference.aspose.com/slides/cs/java/com.aspose.slides/slidecollection/#addFromHtml-java.io.InputStream-) a předáte soubor HTML. 
3. Použijte metodu [save()](https://reference.aspose.com/slides/cs/java/com.aspose.slides/Presentation#save-java.lang.String-int-) k uložení souboru ve formátu PowerPoint.

Tento kód v jazyce Java demonstruje operaci převodu HTML do PowerPoint: 

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

## **FAQ**

**Jsou tabulky zachovány při importu PDF a lze jejich detekci vylepšit?**

Tabulky mohou být při importu detekovány; [PdfImportOptions](https://reference.aspose.com/slides/cs/java/com.aspose.slides/pdfimportoptions/) obsahuje metodu [setDetectTables](https://reference.aspose.com/slides/cs/java/com.aspose.slides/pdfimportoptions/#setDetectTables-boolean-), která umožňuje rozpoznávání tabulek. Účinnost závisí na struktuře PDF.

{{% alert title="Note" color="warning" %}} 
Můžete také použít Aspose.Slides k převodu HTML do dalších populárních formátů souborů: 

* [HTML na obrázek](https://products.aspose.com/slides/cs/java/conversion/html-to-image/)
* [HTML na JPG](https://products.aspose.com/slides/cs/java/conversion/html-to-jpg/)
* [HTML na XML](https://products.aspose.com/slides/cs/java/conversion/html-to-xml/)
* [HTML na TIFF](https://products.aspose.com/slides/cs/java/conversion/html-to-tiff/)

{{% /alert %}}