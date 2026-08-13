---
title: Importeer presentaties vanuit PDF of HTML op Android
linktitle: Importeer presentatie
type: docs
weight: 60
url: /nl/androidjava/import-presentation/
keywords:
- importeer presentatie
- importeer dia
- importeer PDF
- importeer HTML
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
description: "Importeer PDF- en HTML-documenten in PowerPoint- en OpenDocument-presentaties in Java met Aspose.Slides voor Android voor naadloze, snelle dia-verwerking."
---
## **Introductie**

Met [**Aspose.Slides for Android via Java**](https://products.aspose.com/slides/nl/androidjava/), kun je presentaties importeren vanuit bestanden in andere formaten. Aspose.Slides biedt de klasse [SlideCollection](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/slidecollection/) om presentaties te importeren vanuit PDF's, HTML‑documenten, enz.

## **PowerPoint importeren vanuit PDF**

In dit geval kun je een PDF converteren naar een PowerPoint‑presentatie.

<img src="pdf-to-powerpoint.png" alt="pdf-to-powerpoint" style="zoom:50%;" />

1. Maak een instantie van de klasse [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/) aan.  
2. Roep de methode [addFromPdf()](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/SlideCollection#addFromPdf-java.lang.String-) aan en geef het PDF‑bestand door.  
3. Gebruik de methode [save()](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/Presentation#save-java.lang.String-int-) om het bestand op te slaan in het PowerPoint‑formaat.

Deze Java‑code demonstreert de PDF‑naar‑PowerPoint‑operatie:

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
Je wilt misschien de **Aspose free** [PDF to PowerPoint](https://products.aspose.app/slides/nl/import/pdf-to-powerpoint) webapp bekijken, omdat deze een live‑implementatie van het hier beschreven proces is. 
{{% /alert %}} 

## **PowerPoint importeren vanuit HTML**

In dit geval kun je een HTML‑document converteren naar een PowerPoint‑presentatie.

1. Maak een instantie van de klasse [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/) aan.  
2. Roep de methode [addFromHtml()](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/slidecollection/#addFromHtml-java.io.InputStream-) aan en geef een stream met het HTML‑document door.  
3. Gebruik de methode [save()](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/Presentation#save-java.lang.String-int-) om het bestand op te slaan in het PowerPoint‑formaat.

Deze Java‑code demonstreert de HTML‑naar‑PowerPoint‑operatie: 

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

### Worden tabellen behouden bij het importeren van een PDF, en kan hun detectie worden verbeterd?

Tabellen kunnen tijdens het importeren worden gedetecteerd; [PdfImportOptions](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/pdfimportoptions/) bevat een [setDetectTables](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/pdfimportoptions/#setDetectTables-boolean-)‑methode die tabelherkenning inschakelt. De effectiviteit hangt af van de structuur van de PDF.