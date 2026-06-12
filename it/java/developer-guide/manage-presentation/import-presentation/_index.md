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
- PDF a presentazione
- PDF a PPT
- PDF a PPTX
- PDF a ODP
- HTML a presentazione
- HTML a PPT
- HTML a PPTX
- HTML a ODP
- PowerPoint
- OpenDocument
- Java
- Aspose.Slides
description: "Importa facilmente documenti PDF e HTML in presentazioni PowerPoint e OpenDocument in Java con Aspose.Slides per una elaborazione diapositive fluida e ad alte prestazioni."
---
## **Introduzione**

Utilizzando Aspose.Slides, è possibile importare presentazioni da file in altri formati. Aspose.Slides fornisce la classe [SlideCollection](https://reference.aspose.com/slides/it/java/com.aspose.slides/slidecollection/) che consente di importare presentazioni da documenti PDF e HTML.

## **Importa PowerPoint da PDF**

In questo caso, si ottiene la conversione di un PDF in una presentazione PowerPoint.

<img src="pdf-to-powerpoint.png" alt="pdf-to-powerpoint" style="zoom:50%;" />

1. Creare un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/java/com.aspose.slides/) .
2. Chiamare il metodo [addFromPdf()](https://reference.aspose.com/slides/it/java/com.aspose.slides/SlideCollection#addFromPdf-java.lang.String-) e passare il file PDF.
3. Utilizzare il metodo [save()](https://reference.aspose.com/slides/it/java/com.aspose.slides/Presentation#save-java.lang.String-int-) per salvare il file nel formato PowerPoint.

Questo codice Java dimostra l'operazione di conversione da PDF a PowerPoint:

```java
Presentation pres = new Presentation();
try {
    pres.getSlides().addFromPdf("InputPDF.pdf");
    pres.save("OutputPresentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert  title="Suggerimento" color="primary" %}} 

Potresti voler provare l'app web **Aspose free** [PDF to PowerPoint](https://products.aspose.app/slides/it/import/pdf-to-powerpoint) perché è un'implementazione live del processo descritto qui. 

{{% /alert %}} 

## **Importa PowerPoint da HTML**

In questo caso, si ottiene la conversione di un documento HTML in una presentazione PowerPoint.

1. Creare un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/java/com.aspose.slides/) .
2. Chiamare il metodo [addFromHtml()](https://reference.aspose.com/slides/it/java/com.aspose.slides/slidecollection/#addFromHtml-java.io.InputStream-) e passare il file PDF.
3. Utilizzare il metodo [save()](https://reference.aspose.com/slides/it/java/com.aspose.slides/Presentation#save-java.lang.String-int-) per salvare il file nel formato PowerPoint.

Questo codice Java dimostra l'operazione di conversione da HTML a PowerPoint: 

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

**Le tabelle vengono preservate durante l'importazione di un PDF e la loro rilevazione può essere migliorata?**

Le tabelle possono essere rilevate durante l'importazione; [PdfImportOptions](https://reference.aspose.com/slides/it/java/com.aspose.slides/pdfimportoptions/) include un metodo [setDetectTables](https://reference.aspose.com/slides/it/java/com.aspose.slides/pdfimportoptions/#setDetectTables-boolean-) che abilita il riconoscimento delle tabelle. L'efficacia dipende dalla struttura del PDF.

{{% alert title="Nota" color="warning" %}} 

È inoltre possibile utilizzare Aspose.Slides per convertire HTML in altri formati di file popolari: 

* [HTML a immagine](https://products.aspose.com/slides/it/java/conversion/html-to-image/)
* [HTML a JPG](https://products.aspose.com/slides/it/java/conversion/html-to-jpg/)
* [HTML a XML](https://products.aspose.com/slides/it/java/conversion/html-to-xml/)
* [HTML a TIFF](https://products.aspose.com/slides/it/java/conversion/html-to-tiff/)

{{% /alert %}}