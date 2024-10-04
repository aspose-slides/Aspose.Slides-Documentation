---
title: Importar Presentación
type: docs
weight: 60
url: /php-java/import-presentation/
keywords: "Importar PowerPoint, PDF a Presentación, PDF a PPTX, PDF a PPT, Java, Aspose.Slides para PHP vía Java"
description: "Importar presentación de PowerPoint desde PDF. Convertir PDF a PowerPoint"
---

Usando [**Aspose.Slides para PHP vía Java**](https://products.aspose.com/slides/php-java/), puedes importar presentaciones desde archivos en otros formatos. Aspose.Slides proporciona la clase [SlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/slidecollection/) para permitirte importar presentaciones desde PDFs, documentos HTML, etc.

## **Importar PowerPoint desde PDF**

En este caso, puedes convertir un PDF a una presentación de PowerPoint.

<img src="pdf-to-powerpoint.png" alt="pdf-to-powerpoint" style="zoom:50%;" />

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/).
2. Llama al método [addFromPdf()](https://reference.aspose.com/slides/php-java/aspose.slides/SlideCollection#addFromPdf-java.lang.String-) y pasa el archivo PDF.
3. Usa el método [save()](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#save-java.lang.String-int-) para guardar el archivo en el formato de PowerPoint.

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

{{% alert title="Consejo" color="primary" %}} 

Tal vez quieras probar la aplicación web gratuita de **Aspose** [PDF a PowerPoint](https://products.aspose.app/slides/import/pdf-to-powerpoint) porque es una implementación en vivo del proceso descrito aquí. 

{{% /alert %}} 

## **Importar PowerPoint desde HTML**

En este caso, puedes convertir un documento HTML en una presentación de PowerPoint.

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/).
2. Llama al método [addFromHtml()](https://reference.aspose.com/slides/php-java/aspose.slides/slidecollection/#addFromHtml-java.io.InputStream-) y pasa el archivo HTML.
3. Usa el método [save()](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#save-java.lang.String-int-) para guardar el archivo en el formato de PowerPoint.

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

{{% alert title="Nota" color="warning" %}} 

También puedes usar Aspose.Slides para convertir HTML a otros formatos de archivo populares: 

* [HTML a imagen](https://products.aspose.com/slides/php-java/conversion/html-to-image/)
* [HTML a JPG](https://products.aspose.com/slides/php-java/conversion/html-to-jpg/)
* [HTML a XML](https://products.aspose.com/slides/php-java/conversion/html-to-xml/)
* [HTML a TIFF](https://products.aspose.com/slides/php-java/conversion/html-to-tiff/)

{{% /alert %}}