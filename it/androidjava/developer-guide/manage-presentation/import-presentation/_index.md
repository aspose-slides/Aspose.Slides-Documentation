---
title: Importa presentazioni da PDF o HTML su Android
linktitle: Importa presentazione
type: docs
weight: 60
url: /it/androidjava/import-presentation/
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
- Android
- Java
- Aspose.Slides
description: "Importa documenti PDF e HTML in presentazioni PowerPoint e OpenDocument in Java con Aspose.Slides per Android per una gestione delle diapositive fluida e ad alte prestazioni."
---
## **Introduzione**

Utilizzando **Aspose.Slides for Android via Java**, è possibile importare presentazioni da file in altri formati. Aspose.Slides fornisce la classe [SlideCollection](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/slidecollection/) per consentire l'importazione di presentazioni da PDF, documenti HTML, ecc.

## **Importa PowerPoint da PDF**

In questo caso, è possibile convertire un PDF in una presentazione PowerPoint.

<img src="pdf-to-powerpoint.png" alt="pdf-to-powerpoint" style="zoom:50%;" />

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/).
2. Chiama il metodo [addFromPdf()](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/SlideCollection#addFromPdf-java.lang.String-) e passa il file PDF.
3. Usa il metodo [save()](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/Presentation#save-java.lang.String-int-) per salvare il file nel formato PowerPoint.

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
Potresti voler provare l'app web gratuita **Aspose gratuito** [PDF to PowerPoint](https://products.aspose.app/slides/it/import/pdf-to-powerpoint) perché è un'implementazione live del processo descritto qui. 
{{% /alert %}} 

## **Importa PowerPoint da HTML**

In questo caso, è possibile convertire un documento HTML in una presentazione PowerPoint.

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/).
2. Chiama il metodo [addFromHtml()](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/slidecollection/#addFromHtml-java.io.InputStream-) e passa uno stream con il documento HTML.
3. Usa il metodo [save()](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/Presentation#save-java.lang.String-int-) per salvare il file nel formato PowerPoint.

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

Le tabelle possono essere rilevate durante l'importazione; [PdfImportOptions](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/pdfimportoptions/) include il metodo [setDetectTables](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/pdfimportoptions/#setDetectTables-boolean-) che consente il riconoscimento delle tabelle. L'efficacia dipende dalla struttura del PDF.