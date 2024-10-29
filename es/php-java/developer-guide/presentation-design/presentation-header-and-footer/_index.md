---
title: Encabezado y Pie de Página de Presentación
type: docs
weight: 140
url: /es/php-java/presentation-header-and-footer/
keywords: "Encabezado y pie de página de PowerPoint"
description: "Encabezado y pie de página de PowerPoint"
---

{{% alert color="primary" %}} 

[Aspose.Slides](/slides/es/php-java/) proporciona soporte para trabajar con el texto de los encabezados y pies de página de las diapositivas que se mantienen a nivel de la diapositiva maestra.

{{% /alert %}} 

[Aspose.Slides para PHP a través de Java](/slides/es/php-java/) ofrece la función para gestionar encabezados y pies de página dentro de las diapositivas de presentación. Estos se gestionan en realidad a nivel de la presentación maestra.

## **Gestionar Encabezado y Pie de Página en la Presentación**
Las notas de una diapositiva específica pueden eliminarse como se muestra en el ejemplo a continuación:

```php
  # Cargar Presentación
  $pres = new Presentation("headerTest.pptx");
  try {
    # Establecer Pie de Página
    $pres->getHeaderFooterManager()->setAllFootersText("Mi texto de pie de página");
    $pres->getHeaderFooterManager()->setAllFootersVisibility(true);
    # Acceder y Actualizar Encabezado
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

## **Gestionar Encabezado y Pie de Página en Diapositivas de Entrega y Notas**
Aspose.Slides para PHP a través de Java admite Encabezado y Pie de Página en las diapositivas de entrega y notas. Siga los pasos a continuación:

- Cargue una [Presentación](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) que contenga un video.
- Cambie la configuración de Encabezado y Pie de Página para la diapositiva maestra de notas y todas las diapositivas de notas.
- Establezca visibles los marcadores de posición del pie de página de la diapositiva maestra de notas y todos los hijos.
- Establezca visibles los marcadores de posición de fecha y hora de la diapositiva maestra de notas y todos los hijos.
- Cambie la configuración de Encabezado y Pie de Página solo para la primera diapositiva de notas.
- Haga visible el marcador de posición del Encabezado de la diapositiva de notas.
- Establezca texto en el marcador de posición del Encabezado de la diapositiva de notas.
- Establezca texto en el marcador de posición de fecha y hora de la diapositiva de notas.
- Escriba el archivo de presentación modificado.

Se proporciona un fragmento de código en el siguiente ejemplo.

```php
  $pres = new Presentation("presentation.pptx");
  try {
    # Cambiar la configuración de Encabezado y Pie de Página para la diapositiva maestra de notas y todas las diapositivas de notas
    $masterNotesSlide = $pres->getMasterNotesSlideManager()->getMasterNotesSlide();
    if (!java_is_null($masterNotesSlide)) {
      $headerFooterManager = $masterNotesSlide->getHeaderFooterManager();
      $headerFooterManager->setHeaderAndChildHeadersVisibility(true);// hacer visibles la diapositiva maestra de notas y todos los hijos del Pie de Página

      $headerFooterManager->setFooterAndChildFootersVisibility(true);// hacer visibles la diapositiva maestra de notas y todos los hijos del Encabezado

      $headerFooterManager->setSlideNumberAndChildSlideNumbersVisibility(true);// hacer visibles la diapositiva maestra de notas y todos los hijos de los marcadores de posición de Número de Diapositiva

      $headerFooterManager->setDateTimeAndChildDateTimesVisibility(true);// hacer visibles la diapositiva maestra de notas y todos los hijos de los marcadores de posición de Fecha y Hora

      $headerFooterManager->setHeaderAndChildHeadersText("Texto del encabezado");// establecer texto para la diapositiva maestra de notas y todos los hijos del marcador de posición del Encabezado

      $headerFooterManager->setFooterAndChildFootersText("Texto del pie de página");// establecer texto para la diapositiva maestra de notas y todos los hijos del marcador de posición del Pie de Página

      $headerFooterManager->setDateTimeAndChildDateTimesText("Texto de fecha y hora");// establecer texto para la diapositiva maestra de notas y todos los hijos de los marcadores de posición de Fecha y Hora

    }
    # Cambiar la configuración de Encabezado y Pie de Página solo para la primera diapositiva de notas
    $notesSlide = $pres->getSlides()->get_Item(0)->getNotesSlideManager()->getNotesSlide();
    if (!java_is_null($notesSlide)) {
      $headerFooterManager = $notesSlide->getHeaderFooterManager();
      if (!$headerFooterManager->isHeaderVisible()) {
        $headerFooterManager->setHeaderVisibility(true);
      }// hacer visible el marcador de posición del Encabezado de esta diapositiva de notas

      if (!$headerFooterManager->isFooterVisible()) {
        $headerFooterManager->setFooterVisibility(true);
      }// hacer visible el marcador de posición del Pie de Página de esta diapositiva de notas

      if (!$headerFooterManager->isSlideNumberVisible()) {
        $headerFooterManager->setSlideNumberVisibility(true);
      }// hacer visible el marcador de posición del Número de Diapositiva de esta diapositiva de notas

      if (!$headerFooterManager->isDateTimeVisible()) {
        $headerFooterManager->setDateTimeVisibility(true);
      }// hacer visible el marcador de posición de Fecha y Hora de esta diapositiva de notas

      $headerFooterManager->setHeaderText("Nuevo texto del encabezado");// establecer texto en el marcador de posición del Encabezado de la diapositiva de notas

      $headerFooterManager->setFooterText("Nuevo texto del pie de página");// establecer texto en el marcador de posición del Pie de Página de la diapositiva de notas

      $headerFooterManager->setDateTimeText("Nuevo texto de fecha y hora");// establecer texto en el marcador de posición de Fecha y Hora de la diapositiva de notas

    }
    $pres->save("testresult.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```