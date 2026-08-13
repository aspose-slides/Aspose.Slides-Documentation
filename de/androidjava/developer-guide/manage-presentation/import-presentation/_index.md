---
title: "Import von Präsentationen aus PDF oder HTML auf Android"
linktitle: "Import Präsentation"
type: docs
weight: 60
url: /de/androidjava/import-presentation/
keywords:
- "Präsentation importieren"
- "Folie importieren"
- "PDF importieren"
- "HTML importieren"
- "PDF zu Präsentation"
- "PDF zu PPT"
- "PDF zu PPTX"
- "PDF zu ODP"
- "HTML zu Präsentation"
- "HTML zu PPT"
- "HTML zu PPTX"
- "HTML zu ODP"
- "PowerPoint"
- "OpenDocument"
- "Android"
- "Java"
- "Aspose.Slides"
description: "Importieren Sie PDF- und HTML-Dokumente in PowerPoint- und OpenDocument-Präsentationen in Java mit Aspose.Slides für Android für nahtlose, leistungsstarke Folienverarbeitung."
---
## **Einführung**

Mit [**Aspose.Slides for Android via Java**](https://products.aspose.com/slides/de/androidjava/), können Sie Präsentationen aus Dateien in anderen Formaten importieren. Aspose.Slides stellt die Klasse [SlideCollection](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/slidecollection/) bereit, mit der Sie Präsentationen aus PDFs, HTML‑Dokumenten usw. importieren können.

## **PowerPoint aus PDF importieren**

In diesem Fall können Sie ein PDF in eine PowerPoint‑Präsentation konvertieren.

<img src="pdf-to-powerpoint.png" alt="pdf-to-powerpoint" style="zoom:50%;" />

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/) .
2. Rufen Sie die Methode [addFromPdf()](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/SlideCollection#addFromPdf-java.lang.String-) auf und übergeben Sie die PDF‑Datei.
3. Verwenden Sie die Methode [save()](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/Presentation#save-java.lang.String-int-) , um die Datei im PowerPoint‑Format zu speichern.

Dieser Java‑Code demonstriert die PDF‑zu‑PowerPoint‑Operation:

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

Vielleicht möchten Sie die **Aspose free** [PDF to PowerPoint](https://products.aspose.app/slides/de/import/pdf-to-powerpoint) Web‑App ausprobieren, da sie eine Live‑Implementierung des hier beschriebenen Vorgangs bietet. 

{{% /alert %}} 

## **PowerPoint aus HTML importieren**

In diesem Fall können Sie ein HTML‑Dokument in eine PowerPoint‑Präsentation konvertieren.

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/) .
2. Rufen Sie die Methode [addFromHtml()](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/slidecollection/#addFromHtml-java.io.InputStream-) auf und übergeben Sie einen Stream mit dem HTML‑Dokument.
3. Verwenden Sie die Methode [save()](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/Presentation#save-java.lang.String-int-) , um die Datei im PowerPoint‑Format zu speichern.

Dieser Java‑Code demonstriert die HTML‑zu‑PowerPoint‑Operation: 

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

### Werden Tabellen beim Importieren eines PDFs erhalten und kann deren Erkennung verbessert werden?

Tabellen können beim Import erkannt werden; [PdfImportOptions](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/pdfimportoptions/) enthält die Methode [setDetectTables](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/pdfimportoptions/#setDetectTables-boolean-), die die Tabellenerkennung aktiviert. Die Wirksamkeit hängt von der Struktur des PDFs ab.