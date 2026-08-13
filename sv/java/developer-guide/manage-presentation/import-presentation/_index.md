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
description: "Importera enkelt PDF- och HTML-dokument till PowerPoint- och OpenDocument-presentationer i Java med Aspose.Slides för sömlös, högpresterande bildbehandling."
---
## **Introduktion**

Med Aspose.Slides kan du importera presentationer från filer i andra format. Aspose.Slides tillhandahåller klassen [SlideCollection](https://reference.aspose.com/slides/sv/java/com.aspose.slides/slidecollection/) som gör att du kan importera presentationer från PDF- och HTML‑dokument.

## **Importera PowerPoint från PDF**

I det här fallet konverterar du en PDF till en PowerPoint‑presentation.

<img src="pdf-to-powerpoint.png" alt="pdf-to-powerpoint" style="zoom:50%;" />

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/). 
2. Anropa metoden [addFromPdf()](https://reference.aspose.com/slides/sv/java/com.aspose.slides/SlideCollection#addFromPdf-java.lang.String-) och skicka PDF‑filen. 
3. Använd metoden [save()](https://reference.aspose.com/slides/sv/java/com.aspose.slides/Presentation#save-java.lang.String-int-) för att spara filen i PowerPoint‑format.

Denna Java‑kod visar PDF‑till‑PowerPoint‑operationen:

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
Du kanske vill prova den **gratis Aspose**‑webbappen [PDF till PowerPoint](https://products.aspose.app/slides/sv/import/pdf-to-powerpoint) eftersom den är en live‑implementation av processen som beskrivs här. 
{{% /alert %}} 

## **Importera PowerPoint från HTML**

I det här fallet konverterar du ett HTML‑dokument till en PowerPoint‑presentation.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/). 
2. Anropa metoden [addFromHtml()](https://reference.aspose.com/slides/sv/java/com.aspose.slides/slidecollection/#addFromHtml-java.io.InputStream-) och skicka en ström med HTML‑dokumentet. 
3. Använd metoden [save()](https://reference.aspose.com/slides/sv/java/com.aspose.slides/Presentation#save-java.lang.String-int-) för att spara filen i PowerPoint‑format.

Denna Java‑kod visar HTML‑till‑PowerPoint‑operationen: 

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

## **FAQ**

### Bevaras tabeller när en PDF importeras, och kan deras identifiering förbättras?

Tabeller kan upptäckas under import; [PdfImportOptions](https://reference.aspose.com/slides/sv/java/com.aspose.slides/pdfimportoptions/) innehåller en [setDetectTables](https://reference.aspose.com/slides/sv/java/com.aspose.slides/pdfimportoptions/#setDetectTables-boolean-)‑metod som möjliggör tabelligenkänning. Effektiviteten beror på PDF:ens struktur.

{{% alert title="Note" color="warning" %}} 
Du kan också använda Aspose.Slides för att konvertera HTML till andra populära filformat: 

* [HTML till bild](https://products.aspose.com/slides/sv/java/conversion/html-to-image/)
* [HTML till JPG](https://products.aspose.com/slides/sv/java/conversion/html-to-jpg/)
* [HTML till XML](https://products.aspose.com/slides/sv/java/conversion/html-to-xml/)
* [HTML till TIFF](https://products.aspose.com/slides/sv/java/conversion/html-to-tiff/)

{{% /alert %}}