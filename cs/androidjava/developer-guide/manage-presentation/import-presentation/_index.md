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
- Android
- Java
- Aspose.Slides
description: "Importujte PDF a HTML dokumenty do prezentací PowerPoint a OpenDocument v jazyce Java pomocí Aspose.Slides pro Android pro plynulé a výkonné zpracování snímků."
---
## **Úvod**

Pomocí [**Aspose.Slides for Android via Java**](https://products.aspose.com/slides/cs/androidjava/) můžete importovat prezentace ze souborů v jiných formátech. Aspose.Slides poskytuje třídu [SlideCollection](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/slidecollection/), která umožňuje importovat prezentace z PDF, HTML dokumentů atd.

## **Importovat PowerPoint z PDF**

V tomto případě můžete převést PDF na prezentaci PowerPoint.

<img src="pdf-to-powerpoint.png" alt="pdf-to-powerpoint" style="zoom:50%;" />

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/).
2. Zavolejte metodu [addFromPdf()](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/SlideCollection#addFromPdf-java.lang.String-) a předáte PDF soubor.
3. Použijte metodu [save()](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/Presentation#save-java.lang.String-int-) k uložení souboru ve formátu PowerPoint.

Tento kód v jazyce Java demonstruje operaci převodu PDF do PowerPoint:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    pres.getSlides().addFromPdf("InputPDF.pdf");
    pres.save("OutputPresentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert  title="Tip" color="info" %}} 
Možná budete chtít vyzkoušet webovou aplikaci **Aspose free** [PDF to PowerPoint](https://products.aspose.app/slides/cs/import/pdf-to-powerpoint), protože se jedná o živou implementaci zde popsaného procesu. 
{{% /alert %}} 

## **Importovat PowerPoint z HTML**

V tomto případě můžete převést HTML dokument na prezentaci PowerPoint.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/).
2. Zavolejte metodu [addFromHtml()](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/slidecollection/#addFromHtml-java.io.InputStream-) a předáte proud s HTML dokumentem.
3. Použijte metodu [save()](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/Presentation#save-java.lang.String-int-) k uložení souboru ve formátu PowerPoint.

Tento kód v jazyce Java demonstruje operaci převodu HTML do PowerPoint: 

```java
import com.aspose.slides.*;
import java.io.FileInputStream;
import java.io.IOException;

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

### Jsou tabulky zachovány při importu PDF a lze jejich detekci zlepšit?

Tabulky lze během importu detekovat; [PdfImportOptions](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/pdfimportoptions/) obsahuje metodu [setDetectTables](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/pdfimportoptions/#setDetectTables-boolean-), která umožňuje rozpoznání tabulek. Účinnost závisí na struktuře PDF.