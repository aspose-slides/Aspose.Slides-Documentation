---
title: Importovat prezentace z PDF nebo HTML v Java
linktitle: Importovat prezentaci
type: docs
weight: 60
url: /cs/java/import-presentation/
keywords:
- importovat prezentaci
- importovat snímek
- importovat PDF
- importovat HTML
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
- Java
- Aspose.Slides
description: "Jednoduše importujte PDF a HTML dokumenty do prezentací PowerPoint a OpenDocument v Javě pomocí Aspose.Slides pro plynulé a výkonné zpracování snímků."
---
## **Úvod**

Pomocí Aspose.Slides můžete importovat prezentace ze souborů v jiných formátech. Aspose.Slides poskytuje třídu [SlideCollection](https://reference.aspose.com/slides/cs/java/com.aspose.slides/slidecollection/), která umožňuje importovat prezentace z PDF a HTML dokumentů.

## **Importovat PowerPoint z PDF**

V tomto případě převádíte PDF na prezentaci PowerPoint.

<img src="pdf-to-powerpoint.png" alt="pdf-to-powerpoint" style="zoom:50%;" />

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/) .  
2. Zavolejte metodu [addFromPdf()](https://reference.aspose.com/slides/cs/java/com.aspose.slides/SlideCollection#addFromPdf-java.lang.String-) a předáte soubor PDF.  
3. Použijte metodu [save()](https://reference.aspose.com/slides/cs/java/com.aspose.slides/Presentation#save-java.lang.String-int-) k uložení souboru ve formátu PowerPoint.

Tento Java kód demonstruje operaci převodu PDF na PowerPoint:

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

Možná budete chtít vyzkoušet **Aspose free** [PDF to PowerPoint](https://products.aspose.app/slides/cs/import/pdf-to-powerpoint) webovou aplikaci, protože se jedná o živou implementaci procesu popsaného zde. 

{{% /alert %}} 

## **Importovat PowerPoint z HTML**

V tomto případě převádíte HTML dokument na prezentaci PowerPoint.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/) .  
2. Zavolejte metodu [addFromHtml()](https://reference.aspose.com/slides/cs/java/com.aspose.slides/slidecollection/#addFromHtml-java.io.InputStream-) a předáte proud s HTML dokumentem.  
3. Použijte metodu [save()](https://reference.aspose.com/slides/cs/java/com.aspose.slides/Presentation#save-java.lang.String-int-) k uložení souboru ve formátu PowerPoint.

Tento Java kód demonstruje operaci HTML na PowerPoint: 

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

### Zachovají se tabulky při importu PDF a lze jejich detekci vylepšit?

Tabulky lze během importu detekovat; [PdfImportOptions](https://reference.aspose.com/slides/cs/java/com.aspose.slides/pdfimportoptions/) obsahuje metodu [setDetectTables](https://reference.aspose.com/slides/cs/java/com.aspose.slides/pdfimportoptions/#setDetectTables-boolean-) umožňující rozpoznání tabulek. Účinnost závisí na struktuře PDF.

{{% alert title="Poznámka" color="warning" %}} 

Můžete také použít Aspose.Slides k převodu HTML do dalších populárních formátů souborů: 

* [HTML na obrázek](https://products.aspose.com/slides/cs/java/conversion/html-to-image/)
* [HTML na JPG](https://products.aspose.com/slides/cs/java/conversion/html-to-jpg/)
* [HTML na XML](https://products.aspose.com/slides/cs/java/conversion/html-to-xml/)
* [HTML na TIFF](https://products.aspose.com/slides/cs/java/conversion/html-to-tiff/)

{{% /alert %}}