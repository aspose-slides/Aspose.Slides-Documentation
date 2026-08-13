---
title: Importa presentazioni da PDF o HTML in Java
linktitle: Importa presentazione
type: docs
weight: 60
url: /it/java/import-presentation/
keywords:
- importa presentazione
- importa diapositiva
- importa PDF
- importa HTML
- PDF in presentazione
- PDF in PPT
- PDF in PPTX
- PDF in ODP
- HTML in presentazione
- HTML in PPT
- HTML in PPTX
- HTML in ODP
- PowerPoint
- OpenDocument
- Java
- Aspose.Slides
description: "Importa senza sforzo documenti PDF e HTML in presentazioni PowerPoint e OpenDocument in Java con Aspose.Slides per una gestione delle diapositive senza intoppi e ad alte prestazioni."
---
## **Introduzione**

Usando Aspose.Slides, puoi importare presentazioni da file in altri formati. Aspose.Slides fornisce la classe [SlideCollection](https://reference.aspose.com/slides/it/java/com.aspose.slides/slidecollection/) che consente di importare presentazioni da documenti PDF e HTML.

## **Importa PowerPoint da PDF**

In questo caso, puoi convertire un PDF in una presentazione PowerPoint.

<img src="pdf-to-powerpoint.png" alt="pdf-to-powerpoint" style="zoom:50%;" />

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/java/com.aspose.slides/) . 
2. Chiama il metodo [addFromPdf()](https://reference.aspose.com/slides/it/java/com.aspose.slides/SlideCollection#addFromPdf-java.lang.String-) e passa il file PDF. 
3. Usa il metodo [save()](https://reference.aspose.com/slides/it/java/com.aspose.slides/Presentation#save-java.lang.String-int-) per salvare il file nel formato PowerPoint.

Questo codice Java dimostra l'operazione di conversione da PDF a PowerPoint:

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

Potresti voler provare l'app web **Aspose free** [PDF to PowerPoint](https://products.aspose.app/slides/it/import/pdf-to-powerpoint) perché è un'implementazione reale del processo descritto qui. 

{{% /alert %}} 

## **Importa PowerPoint da HTML**

In questo caso, puoi convertire un documento HTML in una presentazione PowerPoint.

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/java/com.aspose.slides/) . 
2. Chiama il metodo [addFromHtml()](https://reference.aspose.com/slides/it/java/com.aspose.slides/slidecollection/#addFromHtml-java.io.InputStream-) e passa un flusso con il documento HTML. 
3. Usa il metodo [save()](https://reference.aspose.com/slides/it/java/com.aspose.slides/Presentation#save-java.lang.String-int-) per salvare il file nel formato PowerPoint.

Questo codice Java dimostra l'operazione di conversione da HTML a PowerPoint: 

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

### Le tabelle vengono preservate durante l'importazione di un PDF e la loro rilevazione può essere migliorata?

Le tabelle possono essere rilevate durante l'importazione; [PdfImportOptions](https://reference.aspose.com/slides/it/java/com.aspose.slides/pdfimportoptions/) include un metodo [setDetectTables](https://reference.aspose.com/slides/it/java/com.aspose.slides/pdfimportoptions/#setDetectTables-boolean-) che abilita il riconoscimento delle tabelle. L'efficacia dipende dalla struttura del PDF.

{{% alert title="Note" color="warning" %}} 

Puoi anche usare Aspose.Slides per convertire HTML in altri formati di file popolari: 

* [HTML in immagine](https://products.aspose.com/slides/it/java/conversion/html-to-image/)
* [HTML in JPG](https://products.aspose.com/slides/it/java/conversion/html-to-jpg/)
* [HTML in XML](https://products.aspose.com/slides/it/java/conversion/html-to-xml/)
* [HTML in TIFF](https://products.aspose.com/slides/it/java/conversion/html-to-tiff/)

{{% /alert %}}