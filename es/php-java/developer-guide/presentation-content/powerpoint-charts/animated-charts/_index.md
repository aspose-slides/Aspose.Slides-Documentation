---
title: Animar gráficos de PowerPoint en PHP
linktitle: Gráficos animados
type: docs
weight: 80
url: /es/php-java/animated-charts/
keywords:
  - gráfico
  - gráfico animado
  - animación de gráfico
  - serie de gráfico
  - categoría de gráfico
  - elemento de serie
  - elemento de categoría
  - añadir efecto
  - tipo de efecto
  - PowerPoint
  - presentación
  - PHP
  - Aspose.Slides
description: "Crea gráficos animados impresionantes con Aspose.Slides for PHP via Java. Potencia las presentaciones con visuales dinámicos en archivos PPT y PPTX — comienza ahora."
---

{{% alert color="primary" %}} 

Aspose.Slides for PHP via Java admite la animación de los elementos del gráfico. **Series**, **Categories**, **Series Elements**, **Categories Elements** pueden animarse con [**Sequence::addEffect**](https://reference.aspose.com/slides/php-java/aspose.slides/sequence/#addEffect) y dos enumeraciones [**EffectChartMajorGroupingType**](https://reference.aspose.com/slides/php-java/aspose.slides/EffectChartMajorGroupingType) y [**EffectChartMinorGroupingType**](https://reference.aspose.com/slides/php-java/aspose.slides/EffectChartMinorGroupingType).

{{% /alert %}} 

## **Animación de series de gráfico**
Si desea animar una serie de gráfico, escriba el código según los pasos enumerados a continuación:

1. Cargar una presentación.
1. Obtener la referencia del objeto gráfico.
1. Animar la serie.
1. Guardar el archivo de presentación en el disco.

En el ejemplo que se muestra a continuación, animamos series de gráfico.
```php
  # Instanciar la clase Presentation que representa un archivo de presentación
  $pres = new Presentation("ExistingChart.pptx");
  try {
    # Obtener la referencia del objeto del gráfico
    $slide = $pres->getSlides()->get_Item(0);
    $shapes = $slide->getShapes();
    $chart = $shapes->get_Item(0);
    # Animar la serie
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectType::Fade, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMajorGroupingType::BySeries, 0, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMajorGroupingType::BySeries, 1, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMajorGroupingType::BySeries, 2, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMajorGroupingType::BySeries, 3, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    # Guardar la presentación modificada en disco
    $pres->save("AnimatingSeries_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Animación de categoría de gráfico**
Si desea animar una categoría de gráfico, escriba el código según los pasos enumerados a continuación:

1. Cargar una presentación.
1. Obtener la referencia del objeto gráfico.
1. Animar la categoría.
1. Guardar el archivo de presentación en el disco.

En el ejemplo que se muestra a continuación, animamos la categoría del gráfico.
```php
  # Instanciar la clase Presentation que representa un archivo de presentación
  $pres = new Presentation("ExistingChart.pptx");
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $shapes = $slide->getShapes();
    $chart = $shapes->get_Item(0);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectType::Fade, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMajorGroupingType::ByCategory, 0, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMajorGroupingType::ByCategory, 1, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMajorGroupingType::ByCategory, 2, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMajorGroupingType::ByCategory, 3, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $pres->save("Sample_Animation_C.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Animación en un elemento de serie**
Si desea animar elementos de serie, escriba el código según los pasos enumerados a continuación:

1. Cargar una presentación.
1. Obtener la referencia del objeto gráfico.
1. Animar los elementos de la serie.
1. Guardar el archivo de presentación en el disco.

En el ejemplo que se muestra a continuación, hemos animado los elementos de la serie.
```php
  # Instanciar la clase Presentation que representa un archivo de presentación
  $pres = new Presentation("ExistingChart.pptx");
  try {
    # Obtener la referencia del objeto del gráfico
    $slide = $pres->getSlides()->get_Item(0);
    $shapes = $slide->getShapes();
    $chart = $shapes->get_Item(0);
    # Animar los elementos de la serie
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectType::Fade, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInSeries, 0, 0, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInSeries, 0, 1, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInSeries, 0, 2, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInSeries, 0, 3, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInSeries, 1, 0, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInSeries, 1, 1, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInSeries, 1, 2, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInSeries, 1, 3, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInSeries, 2, 0, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInSeries, 2, 1, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInSeries, 2, 2, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInSeries, 2, 3, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    # Escribir el archivo de presentación en disco
    $pres->save("AnimatingSeriesElements_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Animación en un elemento de categoría**
Si desea animar elementos de categoría, escriba el código según los pasos enumerados a continuación:

1. Cargar una presentación.
1. Obtener la referencia del objeto gráfico.
1. Animar los elementos de las categorías.
1. Guardar el archivo de presentación en el disco.

En el ejemplo que se muestra a continuación, hemos animado los elementos de las categorías.
```php
  # Instanciar la clase Presentation que representa un archivo de presentación
  $pres = new Presentation("ExistingChart.pptx");
  try {
    # Obtener la referencia del objeto del gráfico
    $slide = $pres->getSlides()->get_Item(0);
    $shapes = $slide->getShapes();
    $chart = $shapes->get_Item(0);
    # Animar los elementos de las categorías
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectType::Fade, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInCategory, 0, 0, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInCategory, 0, 1, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInCategory, 0, 2, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInCategory, 0, 3, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInCategory, 1, 0, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInCategory, 1, 1, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInCategory, 1, 2, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInCategory, 1, 3, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInCategory, 2, 0, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInCategory, 2, 1, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInCategory, 2, 2, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInCategory, 2, 3, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    # Escribir el archivo de presentación en disco
    $pres->save("AnimatingCategoriesElements_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **FAQ**

**¿Se admiten diferentes tipos de efecto (por ejemplo, aparición, énfasis, salida) para los gráficos como para las formas normales?**

Sí. Un gráfico se trata como una forma, por lo que admite los tipos de efecto de animación estándar, incluidos aparición, énfasis y salida, con control total a través de la línea de tiempo de la diapositiva y las secuencias de animación.

**¿Puedo combinar la animación del gráfico con las transiciones de diapositiva?**

Sí. [Transiciones](/slides/es/php-java/slide-transition/) se aplican a la diapositiva, mientras que los efectos de animación se aplican a los objetos de la diapositiva. Puede usar ambos juntos en la misma presentación y controlarlos de forma independiente.

**¿Se conservan las animaciones del gráfico al guardar en PPTX?**

Sí. Cuando usted [guardar en PPTX](/slides/es/php-java/save-presentation/), todos los efectos de animación y su orden se conservan porque forman parte del modelo de animación nativo de la presentación.

**¿Puedo leer animaciones de gráficos existentes de una presentación y modificarlas?**

Sí. La API proporciona acceso a la línea de tiempo de la diapositiva, secuencias y efectos, lo que permite inspeccionar las animaciones de gráficos existentes y ajustarlas sin recrear todo desde cero.

**¿Puedo generar un vídeo que incluya animaciones de gráficos usando Aspose.Slides?**

Sí. Puede [exportar una presentación a vídeo](/slides/es/php-java/convert-powerpoint-to-video/) manteniendo las animaciones, configurando los tiempos y otros ajustes de exportación para que el clip resultante refleje la reproducción animada.