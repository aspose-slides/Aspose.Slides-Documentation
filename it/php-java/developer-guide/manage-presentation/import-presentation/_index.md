---
title: Importa presentazioni da PDF o HTML in PHP
linktitle: Importa presentazione
type: docs
weight: 60
url: /it/php-java/import-presentation/
keywords:
- importazione presentazione
- importazione diapositiva
- importazione PDF
- importazione HTML
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
- PHP
- Aspose.Slides
description: "Importa documenti PDF e HTML in presentazioni PowerPoint e OpenDocument in PHP con Aspose.Slides per una elaborazione delle diapositive senza soluzione di continuità e ad alte prestazioni."
---
## **Introduzione**

Utilizzando [**Aspose.Slides for PHP via Java**](https://products.aspose.com/slides/it/php-java/), è possibile importare presentazioni da file in altri formati. Aspose.Slides fornisce la classe [SlideCollection](https://reference.aspose.com/slides/it/php-java/aspose.slides/slidecollection/) per consentire l'importazione di presentazioni da PDF, documenti HTML, ecc.

## **Importa PowerPoint da PDF**

In questo caso, si converte un PDF in una presentazione PowerPoint.

<img src="pdf-to-powerpoint.png" alt="pdf-to-powerpoint" style="zoom:50%;" />

1. Creare un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/php-java/aspose.slides/).
2. Chiamare il metodo [addFromPdf()](https://reference.aspose.com/slides/it/php-java/aspose.slides/SlideCollection#addFromPdf-java.lang.String-) e passare il file PDF.
3. Utilizzare il metodo [save()](https://reference.aspose.com/slides/it/php-java/aspose.slides/Presentation#save-java.lang.String-int-) per salvare il file nel formato PowerPoint.

Questo codice PHP dimostra l'operazione di conversione da PDF a PowerPoint:

```php
  $pres = new Presentation();
  try {
    $pres->getSlides()->addFromPdf("InputPDF.pdf");
    $pres->save("OutputPresentation.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert  title="Tip" color="primary" %}} 
Potresti voler provare l'app web **Aspose free** [PDF to PowerPoint](https://products.aspose.app/slides/it/import/pdf-to-powerpoint) perché è un'implementazione live del processo descritto qui. 
{{% /alert %}} 

## **Importa PowerPoint da HTML**

In questo caso, si converte un documento HTML in una presentazione PowerPoint.

1. Creare un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/php-java/aspose.slides/).
2. Chiamare il metodo [addFromHtml()](https://reference.aspose.com/slides/it/php-java/aspose.slides/slidecollection/#addFromHtml-java.io.InputStream-) e passare il file PDF.
3. Utilizzare il metodo [save()](https://reference.aspose.com/slides/it/php-java/aspose.slides/Presentation#save-java.lang.String-int-) per salvare il file nel formato PowerPoint.

Questo codice PHP dimostra l'operazione di conversione da HTML a PowerPoint:

```php
  $presentation = new Presentation();
  try {
    $htmlStream = new Java("java.io.FileInputStream", "page.html");
    try {
      $presentation->getSlides()->addFromHtml($htmlStream);
    } finally {
      if (!java_is_null($htmlStream)) {
        $htmlStream->close();
      }
    }
    $presentation->save("MyPresentation.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **FAQ**

**Le tabelle vengono conservate durante l'importazione di un PDF e la loro rilevazione può essere migliorata?**

Le tabelle possono essere rilevate durante l'importazione; [PdfImportOptions](https://reference.aspose.com/slides/it/php-java/aspose.slides/pdfimportoptions/) include un metodo [setDetectTables](https://reference.aspose.com/slides/it/php-java/aspose.slides/pdfimportoptions/#setDetectTables) che abilita il riconoscimento delle tabelle. L'efficacia dipende dalla struttura del PDF.

{{% alert title="Note" color="warning" %}} 
Puoi anche utilizzare Aspose.Slides per convertire HTML in altri formati di file popolari: 

* [HTML to image](https://products.aspose.com/slides/it/php-java/conversion/html-to-image/)
* [HTML to JPG](https://products.aspose.com/slides/it/php-java/conversion/html-to-jpg/)
* [HTML to XML](https://products.aspose.com/slides/it/php-java/conversion/html-to-xml/)
* [HTML to TIFF](https://products.aspose.com/slides/it/php-java/conversion/html-to-tiff/)

{{% /alert %}}