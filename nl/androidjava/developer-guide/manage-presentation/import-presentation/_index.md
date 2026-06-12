---
title: Presentaties importeren vanuit PDF of HTML op Android
linktitle: Presentatie importeren
type: docs
weight: 60
url: /nl/androidjava/import-presentation/
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
- Android
- Java
- Aspose.Slides
description: "Importeer PDF- en HTML-documenten in PowerPoint- en OpenDocument-presentaties in Java met Aspose.Slides voor Android voor naadloze, high-performance dia-verwerking."
---
## **Introductie**

Met [**Aspose.Slides for Android via Java**](https://products.aspose.com/slides/nl/androidjava/), kun je presentaties importeren vanuit bestanden in andere formaten. Aspose.Slides levert de [SlideCollection](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/slidecollection/) klasse om je toe te staan presentaties te importeren vanuit PDF's, HTML-documenten, enz.

## **PowerPoint importeren vanuit PDF**

In dit geval kun je een PDF converteren naar een PowerPoint‑presentatie.

<img src="pdf-to-powerpoint.png" alt="pdf-to-powerpoint" style="zoom:50%;" />

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/) klasse aan.  
2. Roep de [addFromPdf()](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/SlideCollection#addFromPdf-java.lang.String-) methode aan en geef het PDF‑bestand op.  
3. Gebruik de [save()](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/Presentation#save-java.lang.String-int-) methode om het bestand op te slaan in het PowerPoint‑formaat.

Deze Java‑code laat de PDF‑naar‑PowerPoint‑bewerking zien:

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
Je wilt misschien de **Aspose free** [PDF to PowerPoint](https://products.aspose.app/slides/nl/import/pdf-to-powerpoint) web‑app bekijken, omdat dit een live‑implementatie is van het hier beschreven proces. 
{{% /alert %}} 

## **PowerPoint importeren vanuit HTML**

In dit geval kun je een HTML‑document converteren naar een PowerPoint‑presentatie.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/) klasse aan.  
2. Roep de [addFromHtml()](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/slidecollection/#addFromHtml-java.io.InputStream-) methode aan en geef het PDF‑bestand op.  
3. Gebruik de [save()](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/Presentation#save-java.lang.String-int-) methode om het bestand op te slaan in het PowerPoint‑formaat.

Deze Java‑code toont de HTML‑naar‑PowerPoint‑bewerking: 

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

**Worden tabellen behouden bij het importeren van een PDF, en kan hun detectie verbeterd worden?**

Tabel‑detectie kan tijdens het importeren plaatsvinden; [PdfImportOptions](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/pdfimportoptions/) bevat een [setDetectTables](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/pdfimportoptions/#setDetectTables-boolean-) methode die tabelherkenning inschakelt. De effectiviteit hangt af van de structuur van de PDF.