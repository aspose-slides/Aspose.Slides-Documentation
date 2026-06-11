---
title: Importera presentationer från PDF eller HTML på Android
linktitle: Importera presentation
type: docs
weight: 60
url: /sv/androidjava/import-presentation/
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
- Android
- Java
- Aspose.Slides
description: "Importera PDF- och HTML-dokument till PowerPoint- och OpenDocument-presentationer i Java med Aspose.Slides för Android för sömlös, högpresterande bildbearbetning."
---
## **Introduktion**

Genom att använda [**Aspose.Slides for Android via Java**](https://products.aspose.com/slides/sv/androidjava/) kan du importera presentationer från filer i andra format. Aspose.Slides tillhandahåller klassen [SlideCollection](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/slidecollection/) för att du ska kunna importera presentationer från PDF‑filer, HTML‑dokument osv.

## **Importera PowerPoint från PDF**

I det här fallet konverterar du en PDF till en PowerPoint‑presentation.

<img src="pdf-to-powerpoint.png" alt="pdf-to-powerpoint" style="zoom:50%;" />

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/).
2. Anropa metoden [addFromPdf()](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/SlideCollection#addFromPdf-java.lang.String-) och skicka PDF‑filen.
3. Använd metoden [save()](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/Presentation#save-java.lang.String-int-) för att spara filen i PowerPoint‑formatet.

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

{{% alert  title="Tips" color="primary" %}} 

Du kanske vill prova **Aspose free** [PDF till PowerPoint](https://products.aspose.app/slides/sv/import/pdf-to-powerpoint) webbapp eftersom den är en levande implementering av processen som beskrivs här. 

{{% /alert %}} 

## **Importera PowerPoint från HTML**

I det här fallet konverterar du ett HTML‑dokument till en PowerPoint‑presentation.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/).
2. Anropa metoden [addFromHtml()](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/slidecollection/#addFromHtml-java.io.InputStream-) och skicka HTML‑filen.
3. Använd metoden [save()](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/Presentation#save-java.lang.String-int-) för att spara filen i PowerPoint‑formatet.

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

**Behålls tabeller när man importerar en PDF, och kan deras detektering förbättras?**

Tabeller kan upptäckas vid import; [PdfImportOptions](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/pdfimportoptions/) inkluderar en [setDetectTables](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/pdfimportoptions/#setDetectTables-boolean-)‑metod som möjliggör tabelldetektion. Effektiviteten beror på PDF:ens struktur.