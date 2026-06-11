---
title: Importera presentationer från PDF eller HTML i Java
linktitle: Importera presentation
type: docs
weight: 60
url: /sv/java/import-presentation/
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
- Java
- Aspose.Slides
description: "Importera PDF- och HTML-dokument till PowerPoint- och OpenDocument-presentationer i Java med Aspose.Slides på ett enkelt och högpresterande sätt för sömlös bildbearbetning."
---
## **Introduktion**

Med Aspose.Slides kan du importera presentationer från filer i andra format. Aspose.Slides tillhandahåller klassen [SlideCollection](https://reference.aspose.com/slides/sv/java/com.aspose.slides/slidecollection/) som möjliggör import av presentationer från PDF‑ och HTML‑dokument.

## **Importera PowerPoint från PDF**

I det här fallet konverterar du en PDF till en PowerPoint‑presentation.

<img src="pdf-to-powerpoint.png" alt="pdf-to-powerpoint" style="zoom:50%;" />

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/) .
2. Anropa metoden [addFromPdf()](https://reference.aspose.com/slides/sv/java/com.aspose.slides/SlideCollection#addFromPdf-java.lang.String-) och skicka PDF‑filen.
3. Använd metoden [save()](https://reference.aspose.com/slides/sv/java/com.aspose.slides/Presentation#save-java.lang.String-int-) för att spara filen i PowerPoint‑format.

Den här Java‑koden demonstrerar PDF‑till‑PowerPoint‑operationen:

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
Du kanske vill kolla in **Aspose free** [PDF to PowerPoint](https://products.aspose.app/slides/sv/import/pdf-to-powerpoint) webbapp eftersom den är en levande implementation av processen som beskrivs här. 
{{% /alert %}} 

## **Importera PowerPoint från HTML**

I det här fallet konverterar du ett HTML‑dokument till en PowerPoint‑presentation.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/) .
2. Anropa metoden [addFromHtml()](https://reference.aspose.com/slides/sv/java/com.aspose.slides/slidecollection/#addFromHtml-java.io.InputStream-) och skicka PDF‑filen.
3. Använd metoden [save()](https://reference.aspose.com/slides/sv/java/com.aspose.slides/Presentation#save-java.lang.String-int-) för att spara filen i PowerPoint‑format.

Den här Java‑koden demonstrerar HTML‑till‑PowerPoint‑operationen: 

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

**Bevaras tabeller vid import av en PDF, och kan deras upptäckt förbättras?**

Tabeller kan upptäckas under import; [PdfImportOptions](https://reference.aspose.com/slides/sv/java/com.aspose.slides/pdfimportoptions/) innehåller en [setDetectTables](https://reference.aspose.com/slides/sv/java/com.aspose.slides/pdfimportoptions/#setDetectTables-boolean-)‑metod som möjliggör tabelligenkänning. Effektiviteten beror på PDF‑filens struktur.

{{% alert title="Note" color="warning" %}} 
Du kan också använda Aspose.Slides för att konvertera HTML till andra populära filformat: 

* [HTML to image](https://products.aspose.com/slides/sv/java/conversion/html-to-image/)
* [HTML to JPG](https://products.aspose.com/slides/sv/java/conversion/html-to-jpg/)
* [HTML to XML](https://products.aspose.com/slides/sv/java/conversion/html-to-xml/)
* [HTML to TIFF](https://products.aspose.com/slides/sv/java/conversion/html-to-tiff/)

{{% /alert %}}