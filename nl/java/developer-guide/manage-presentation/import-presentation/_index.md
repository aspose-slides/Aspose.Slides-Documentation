---
title: Presentaties importeren vanuit PDF of HTML in Java
linktitle: Presentatie importeren
type: docs
weight: 60
url: /nl/java/import-presentation/
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
- Java
- Aspose.Slides
description: "Importeer moeiteloos PDF- en HTML-documenten naar PowerPoint- en OpenDocument-presentaties in Java met Aspose.Slides voor een naadloze, hoogwaardige dia-verwerking."
---
## **Introductie**

Met Aspose.Slides kunt u presentaties importeren uit bestanden van andere formaten. Aspose.Slides biedt de [SlideCollection](https://reference.aspose.com/slides/nl/java/com.aspose.slides/slidecollection/)‑klasse, waarmee u presentaties kunt importeren uit PDF‑ en HTML‑documenten.

## **PowerPoint importeren vanuit PDF**

In dit geval converteert u een PDF‑bestand naar een PowerPoint‑presentatie.

<img src="pdf-to-powerpoint.png" alt="pdf-to-powerpoint" style="zoom:50%;" />

1. Maak een instance van de [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/)‑klasse.  
2. Roep de [addFromPdf()](https://reference.aspose.com/slides/nl/java/com.aspose.slides/SlideCollection#addFromPdf-java.lang.String-)‑methode aan en geef het PDF‑bestand door.  
3. Gebruik de [save()](https://reference.aspose.com/slides/nl/java/com.aspose.slides/Presentation#save-java.lang.String-int-)‑methode om het bestand op te slaan in PowerPoint‑formaat.

Deze Java‑code toont de PDF‑naar‑PowerPoint‑bewerking:

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

U kunt de gratis **Aspose**‑webapp [PDF naar PowerPoint](https://products.aspose.app/slides/nl/import/pdf-to-powerpoint) uitproberen, omdat dit een live‑implementatie van het hier beschreven proces is. 

{{% /alert %}} 

## **PowerPoint importeren vanuit HTML**

In dit geval converteert u een HTML‑document naar een PowerPoint‑presentatie.

1. Maak een instance van de [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/)‑klasse.  
2. Roep de [addFromHtml()](https://reference.aspose.com/slides/nl/java/com.aspose.slides/slidecollection/#addFromHtml-java.io.InputStream-)‑methode aan en geef een stream met het HTML‑document door.  
3. Gebruik de [save()](https://reference.aspose.com/slides/nl/java/com.aspose.slides/Presentation#save-java.lang.String-int-)‑methode om het bestand op te slaan in PowerPoint‑formaat.

Deze Java‑code toont de HTML‑naar‑PowerPoint‑bewerking:

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

Tabellen kunnen tijdens het importeren worden gedetecteerd; [PdfImportOptions](https://reference.aspose.com/slides/nl/java/com.aspose.slides/pdfimportoptions/) bevat een [setDetectTables](https://reference.aspose.com/slides/nl/java/com.aspose.slides/pdfimportoptions/#setDetectTables-boolean-)‑methode die tabelherkenning inschakelt. De effectiviteit hangt af van de structuur van de PDF.

{{% alert title="Note" color="warning" %}} 

U kunt Aspose.Slides ook gebruiken om HTML naar andere populaire bestandsformaten te converteren: 

* [HTML naar afbeelding](https://products.aspose.com/slides/nl/java/conversion/html-to-image/)
* [HTML naar JPG](https://products.aspose.com/slides/nl/java/conversion/html-to-jpg/)
* [HTML naar XML](https://products.aspose.com/slides/nl/java/conversion/html-to-xml/)
* [HTML naar TIFF](https://products.aspose.com/slides/nl/java/conversion/html-to-tiff/)

{{% /alert %}}