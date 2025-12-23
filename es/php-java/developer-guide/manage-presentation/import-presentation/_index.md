---
title: Importar presentaciones desde PDF o HTML en PHP
linktitle: Importar presentación
type: docs
weight: 60
url: /es/php-java/import-presentation/
keywords:
- importar presentación
- importar diapositiva
- importar PDF
- importar HTML
- PDF a presentación
- PDF a PPT
- PDF a PPTX
- PDF a ODP
- HTML a presentación
- HTML a PPT
- HTML a PPTX
- HTML a ODP
- PowerPoint
- OpenDocument
- PHP
- Aspose.Slides
description: "Importa documentos PDF y HTML en presentaciones PowerPoint y OpenDocument en PHP con Aspose.Slides para un procesamiento de diapositivas sin interrupciones y de alto rendimiento."
---

Usando [**Aspose.Slides for PHP via Java**](https://products.aspose.com/slides/php-java/), puedes importar presentaciones desde archivos en otros formatos. Aspose.Slides proporciona la clase [SlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/slidecollection/) para permitir la importación de presentaciones desde PDFs, documentos HTML, etc.

## **Importar PowerPoint desde PDF**

En este caso, conviertes un PDF a una presentación PowerPoint.

<img src="pdf-to-powerpoint.png" alt="pdf-to-powerpoint" style="zoom:50%;" />

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/).
2. Llama al método [addFromPdf()](https://reference.aspose.com/slides/php-java/aspose.slides/SlideCollection#addFromPdf-java.lang.String-) y pasa el archivo PDF.
3. Utiliza el método [save()](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#save-java.lang.String-int-) para guardar el archivo en formato PowerPoint.

Este código PHP demuestra la operación de PDF a PowerPoint:
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
Quizás desees probar la aplicación web **Aspose free** [PDF to PowerPoint](https://products.aspose.app/slides/import/pdf-to-powerpoint) porque es una implementación en vivo del proceso descrito aquí. 
{{% /alert %}} 

## **Importar PowerPoint desde HTML**

En este caso, conviertes un documento HTML a una presentación PowerPoint.

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/).
2. Llama al método [addFromHtml()](https://reference.aspose.com/slides/php-java/aspose.slides/slidecollection/#addFromHtml-java.io.InputStream-) y pasa el archivo PDF.
3. Utiliza el método [save()](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#save-java.lang.String-int-) para guardar el archivo en formato PowerPoint.

Este código PHP demuestra la operación de HTML a PowerPoint:
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

**¿Se conservan las tablas al importar un PDF y puede mejorarse su detección?**

Las tablas pueden detectarse durante la importación; [PdfImportOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfimportoptions/) incluye un método [setDetectTables](https://reference.aspose.com/slides/php-java/aspose.slides/pdfimportoptions/#setDetectTables) que habilita el reconocimiento de tablas. La efectividad depende de la estructura del PDF.

{{% alert title="Note" color="warning" %}} 
También puedes usar Aspose.Slides para convertir HTML a otros formatos de archivo populares: 

* [HTML a imagen](https://products.aspose.com/slides/php-java/conversion/html-to-image/)
* [HTML a JPG](https://products.aspose.com/slides/php-java/conversion/html-to-jpg/)
* [HTML a XML](https://products.aspose.com/slides/php-java/conversion/html-to-xml/)
* [HTML a TIFF](https://products.aspose.com/slides/php-java/conversion/html-to-tiff/)

{{% /alert %}}