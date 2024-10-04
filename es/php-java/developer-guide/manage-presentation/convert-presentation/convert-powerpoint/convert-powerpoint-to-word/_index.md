---
title: Convertir PowerPoint a Word
type: docs
weight: 110
url: /php-java/convert-powerpoint-to-word/
keywords: "Convertir PowerPoint, PPT, PPTX, Presentación, Word, DOCX, DOC, PPTX a DOCX, PPT a DOC, PPTX a DOC, PPT a DOCX, Java, java, Aspose.Slides"
description: "Convertir presentación de PowerPoint a Word "
---

Si planeas utilizar contenido textual o información de una presentación (PPT o PPTX) de nuevas maneras, puedes beneficiarte de convertir la presentación a Word (DOC o DOCX). 

* En comparación con Microsoft PowerPoint, la aplicación Microsoft Word está más equipada con herramientas o funcionalidades para el contenido. 
* Además de las funciones de edición en Word, también puedes beneficiarte de características mejoradas de colaboración, impresión y compartición. 

{{% alert color="primary" %}} 

Puedes querer probar nuestro [**Convertidor en Línea de Presentación a Word**](https://products.aspose.app/slides/conversion/ppt-to-word) para ver qué podrías ganar al trabajar con contenido textual de las diapositivas. 

{{% /alert %}} 

## **Aspose.Slides y Aspose.Words**

Para convertir un archivo de PowerPoint (PPTX o PPT) a Word (DOCX o DOCX), necesitas tanto [Aspose.Slides para PHP a través de Java](https://products.aspose.com/slides/php-java/) como [Aspose.Words para Java](https://products.aspose.com/words/php-java/).

Como una API independiente, [Aspose.Slides](https://products.aspose.app/slides) para Java proporciona funciones que te permiten extraer textos de presentaciones. 

[Aspose.Words](https://docs.aspose.com/words/php-java/) es una API avanzada de procesamiento de documentos que permite a las aplicaciones generar, modificar, convertir, renderizar, imprimir archivos y realizar otras tareas con documentos sin utilizar Microsoft Word.

## **Convertir PowerPoint a Word**

1. Descarga las bibliotecas [Aspose.Slides para PHP a través de Java](https://downloads.aspose.com/slides/java) y [Aspose.Words para Java](https://downloads.aspose.com/words/java).
2. Agrega *aspose-slides-x.x-jdk16.jar* y *aspose-words-x.x-jdk16.jar* a tu CLASSPATH.
3. Usa este fragmento de código para convertir PowerPoint a Word:

```php
  $pres = new Presentation($inputPres);
  try {
    $doc = new Document();
    $builder = new DocumentBuilder($doc);
    foreach($pres->getSlides() as $slide) {
      # genera e inserta la imagen de la diapositiva
      $bitmap = $slide->getThumbnail(1, 1);
      $builder->insertImage($bitmap);
      # inserta los textos de la diapositiva
      foreach($slide->getShapes() as $shape) {
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.AutoShape"))) {
          $builder->writeln($shape->getTextFrame()->getText());
        }
      }
      $builder->insertBreak(BreakType::PAGE_BREAK);
    }
    $doc->save($outputDoc);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```