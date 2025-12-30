---
title: Gestionar encabezados y pies de página de la presentación en PHP
linktitle: Encabezado y pie de página
type: docs
weight: 140
url: /es/php-java/presentation-header-and-footer/
keywords:
- encabezado
- texto del encabezado
- pie de página
- texto del pie de página
- establecer encabezado
- establecer pie de página
- folleto
- notas
- PowerPoint
- OpenDocument
- presentación
- PHP
- Aspose.Slides
description: "Utilice Aspose.Slides for PHP via Java para agregar y personalizar encabezados y pies de página en presentaciones de PowerPoint y OpenDocument y obtener un aspecto profesional."
---

{{% alert color="primary" %}} 
[Aspose.Slides](/slides/es/php-java/) ofrece soporte para trabajar con el texto de encabezados y pies de página de las diapositivas, que en realidad se mantiene a nivel de la diapositiva maestra.
{{% /alert %}} 
[Aspose.Slides for PHP via Java](/slides/es/php-java/) proporciona la función para gestionar encabezados y pies de página dentro de las diapositivas de la presentación. Estos se gestionan, de hecho, a nivel de la presentación maestra.

## **Gestionar encabezados y pies de página en una presentación**
Las notas de una diapositiva específica se pueden eliminar como se muestra en el ejemplo a continuación:
```php
  # Cargar presentación
  $pres = new Presentation("headerTest.pptx");
  try {
    # Estableciendo pie de página
    $pres->getHeaderFooterManager()->setAllFootersText("My Footer text");
    $pres->getHeaderFooterManager()->setAllFootersVisibility(true);
    # Acceder y actualizar encabezado
    $masterNotesSlide = $pres->getMasterNotesSlideManager()->getMasterNotesSlide();
    if (null != $masterNotesSlide) {
      updateHeaderFooterText($masterNotesSlide);
    }
    # Guardar presentación
    $pres->save("HeaderFooterJava.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

```php

```


## **Gestionar encabezados y pies de página en diapositivas de folleto y notas**
Aspose.Slides for PHP via Java admite encabezado y pie de página en diapositivas de folleto y notas. Por favor, siga los pasos a continuación:

- Cargue una [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) que contenga un video.
- Cambie la configuración de encabezado y pie de página para la diapositiva maestra de notas y todas las diapositivas de notas.
- Establezca visibles la diapositiva maestra de notas y todos los marcadores de posición de pie de página secundarios.
- Establezca visibles la diapositiva maestra de notas y todos los marcadores de posición de fecha y hora secundarios.
- Cambie la configuración de encabezado y pie de página solo para la primera diapositiva de notas.
- Establezca visible el marcador de posición de encabezado de la diapositiva de notas.
- Establezca texto en el marcador de posición de encabezado de la diapositiva de notas.
- Establezca texto en el marcador de posición de fecha y hora de la diapositiva de notas.
- Escriba el archivo de presentación modificado.

Fragmento de código proporcionado en el ejemplo a continuación.
```php
  $pres = new Presentation("presentation.pptx");
  try {
    # Cambiar la configuración de encabezado y pie de página para la diapositiva maestra de notas y todas las diapositivas de notas
    $masterNotesSlide = $pres->getMasterNotesSlideManager()->getMasterNotesSlide();
    if (!java_is_null($masterNotesSlide)) {
      $headerFooterManager = $masterNotesSlide->getHeaderFooterManager();
      $headerFooterManager->setHeaderAndChildHeadersVisibility(true);// hacer visible la diapositiva maestra de notas y todos los marcadores de posición de pie de página secundarios

      $headerFooterManager->setFooterAndChildFootersVisibility(true);// hacer visible la diapositiva maestra de notas y todos los marcadores de posición de encabezado secundarios

      $headerFooterManager->setSlideNumberAndChildSlideNumbersVisibility(true);// hacer visible la diapositiva maestra de notas y todos los marcadores de posición de número de diapositiva secundarios

      $headerFooterManager->setDateTimeAndChildDateTimesVisibility(true);// hacer visible la diapositiva maestra de notas y todos los marcadores de posición de fecha y hora secundarios

      $headerFooterManager->setHeaderAndChildHeadersText("Header text");// establecer texto en la diapositiva maestra de notas y todos los marcadores de posición de encabezado secundarios

      $headerFooterManager->setFooterAndChildFootersText("Footer text");// establecer texto en la diapositiva maestra de notas y todos los marcadores de posición de pie de página secundarios

      $headerFooterManager->setDateTimeAndChildDateTimesText("Date and time text");// establecer texto en la diapositiva maestra de notas y todos los marcadores de posición de fecha y hora secundarios

    }
    # Cambiar la configuración de encabezado y pie de página solo para la primera diapositiva de notas
    $notesSlide = $pres->getSlides()->get_Item(0)->getNotesSlideManager()->getNotesSlide();
    if (!java_is_null($notesSlide)) {
      $headerFooterManager = $notesSlide->getHeaderFooterManager();
      if (!$headerFooterManager->isHeaderVisible()) {
        $headerFooterManager->setHeaderVisibility(true);
      }// hacer visible este marcador de posición de encabezado en la diapositiva de notas

      if (!$headerFooterManager->isFooterVisible()) {
        $headerFooterManager->setFooterVisibility(true);
      }// hacer visible este marcador de posición de pie de página en la diapositiva de notas

      if (!$headerFooterManager->isSlideNumberVisible()) {
        $headerFooterManager->setSlideNumberVisibility(true);
      }// hacer visible este marcador de posición de número de diapositiva en la diapositiva de notas

      if (!$headerFooterManager->isDateTimeVisible()) {
        $headerFooterManager->setDateTimeVisibility(true);
      }// hacer visible este marcador de posición de fecha y hora en la diapositiva de notas

      $headerFooterManager->setHeaderText("New header text");// establecer texto en el marcador de posición de encabezado de la diapositiva de notas

      $headerFooterManager->setFooterText("New footer text");// establecer texto en el marcador de posición de pie de página de la diapositiva de notas

      $headerFooterManager->setDateTimeText("New date and time text");// establecer texto en el marcador de posición de fecha y hora de la diapositiva de notas

    }
    $pres->save("testresult.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Preguntas frecuentes**

**¿Puedo añadir un "encabezado" a diapositivas normales?**

En PowerPoint, el "encabezado" solo existe para notas y folletos; en diapositivas normales, los elementos compatibles son el pie de página, la fecha/hora y el número de diapositiva. En Aspose.Slides esto coincide con las mismas limitaciones: encabezado solo para Notes/Handout, y en diapositivas—Footer/DateTime/SlideNumber.

**¿Qué sucede si el diseño no contiene un área de pie de página—puedo "activar" su visibilidad?**

Sí. Verifique la visibilidad a través del gestor de encabezado/pie de página y habilítela si es necesario. Estos indicadores y métodos de la API están diseñados para casos en los que el marcador de posición falta o está oculto.

**¿Cómo hago que el número de diapositiva comience desde un valor distinto de 1?**

Establezca el [primer número de diapositiva](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/setfirstslidenumber/) de la presentación; después de eso, toda la numeración se recalcula. Por ejemplo, puede comenzar en 0 o 10, y ocultar el número en la diapositiva de título.

**¿Qué ocurre con los encabezados/pies de página al exportar a PDF/imágenes/HTML?**

Se renderizan como elementos de texto habituales de la presentación. Es decir, si los elementos son visibles en las diapositivas/páginas de notas, también aparecerán en el formato de salida junto con el resto del contenido.