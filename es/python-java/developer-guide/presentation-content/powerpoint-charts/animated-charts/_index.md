---
title: Animar gráficos de PowerPoint en Python mediante Java
linktitle: Gráficos animados
type: docs
weight: 80
url: /es/python-java/animated-charts/
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
- Python
- Java
- Aspose.Slides
description: "Crea gráficos animados impresionantes en Python mediante Java con Aspose.Slides. Mejora las presentaciones con visuales dinámicos en archivos PPT y PPTX—empieza ahora."
---
## **Introducción**

Aspose.Slides for Python via Java admite la animación de elementos de gráficos. **Series**, **Categorías**, **Elementos de Serie** y **Elementos de Categoría** pueden animarse mediante el método [Sequence.addEffect](https://reference.aspose.com/slides/es/python-java/aspose.slides/sequence/#addEffect) y dos enumeraciones: [EffectChartMajorGroupingType](https://reference.aspose.com/slides/es/python-java/aspose.slides/effectchartmajorgroupingtype/) y [EffectChartMinorGroupingType](https://reference.aspose.com/slides/es/python-java/aspose.slides/effectchartminorgroupingtype/).

## **Animación de series de gráfico**

Si desea animar una serie de gráfico, escriba el código según los pasos que se indican a continuación:

1. Cargue una presentación.
1. Obtenga una referencia al objeto del gráfico.
1. Anime la serie.
1. Guarde el archivo de presentación en disco.

El siguiente ejemplo anima series de gráfico. El gráfico del archivo de ejemplo tiene tres series, por lo que se añade un efecto para cada índice de 0 a 2. Aspose.Slides no verifica el índice contra los datos del gráfico, y un efecto añadido para una serie que no existe se escribe en el archivo pero no anima nada—mantenga el índice por debajo del número de series en su propio gráfico.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EffectChartMajorGroupingType, EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat

# Cargar la presentación.
presentation = Presentation("ExistingChart.pptx")
try:
    # Obtener una referencia al objeto del gráfico.
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().get_Item(0)
    sequence = slide.getTimeline().getMainSequence()

    # Animar los elementos del gráfico.
    sequence.addEffect(chart, EffectType.Fade, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMajorGroupingType.BySeries, 0, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMajorGroupingType.BySeries, 1, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMajorGroupingType.BySeries, 2, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)

    # Guardar la presentación modificada en disco.
    presentation.save("AnimatingSeries_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Animación de categorías de gráfico**

Si desea animar una categoría de gráfico, escriba el código según los pasos que se indican a continuación:

1. Cargue una presentación.
1. Obtenga una referencia al objeto del gráfico.
1. Anime la categoría.
1. Guarde el archivo de presentación en disco.

El siguiente ejemplo anima categorías de gráfico.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EffectChartMajorGroupingType, EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat

# Cargar la presentación.
presentation = Presentation("ExistingChart.pptx")
try:
    # Obtener una referencia al objeto del gráfico.
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().get_Item(0)
    sequence = slide.getTimeline().getMainSequence()

    # Animar los elementos del gráfico.
    sequence.addEffect(chart, EffectType.Fade, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMajorGroupingType.ByCategory, 0, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMajorGroupingType.ByCategory, 1, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMajorGroupingType.ByCategory, 2, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMajorGroupingType.ByCategory, 3, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)

    # Guardar la presentación modificada en disco.
    presentation.save("Sample_Animation_C.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Animación en un elemento de serie**

Si desea animar elementos de serie, escriba el código según los pasos que se indican a continuación:

1. Cargue una presentación.
1. Obtenga una referencia al objeto del gráfico.
1. Anime los elementos de serie.
1. Guarde el archivo de presentación en disco.

El siguiente ejemplo anima elementos de serie.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EffectChartMinorGroupingType, EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat

# Cargar la presentación.
presentation = Presentation("ExistingChart.pptx")
try:
    # Obtener una referencia al objeto del gráfico.
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().get_Item(0)
    sequence = slide.getTimeline().getMainSequence()

    # Animar los elementos del gráfico.
    sequence.addEffect(chart, EffectType.Fade, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 0, 0, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 0, 1, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 0, 2, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 0, 3, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 1, 0, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 1, 1, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 1, 2, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 1, 3, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 2, 0, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 2, 1, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 2, 2, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 2, 3, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)

    # Guardar la presentación modificada en disco.
    presentation.save("AnimatingSeriesElements_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Animación en un elemento de categoría**

Si desea animar elementos de categoría, escriba el código según los pasos que se indican a continuación:

1. Cargue una presentación.
1. Obtenga una referencia al objeto del gráfico.
1. Anime los elementos de categoría.
1. Guarde el archivo de presentación en disco.

El siguiente ejemplo anima elementos de categoría.

```python
import jpype
import asposeslides

if not jpource.isJVMStarted():
    jpource.startJVM()

from asposeslides.api import EffectChartMinorGroupingType, EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat

# Cargar la presentación.
presentation = Presentation("ExistingChart.pptx")
try:
    # Obtener una referencia al objeto del gráfico.
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().get_Item(0)
    sequence = slide.getTimeline().getMainSequence()

    # Animar los elementos del gráfico.
    sequence.addEffect(chart, EffectType.Fade, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 0, 0, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 0, 1, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 0, 2, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 0, 3, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 1, 0, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 1, 1, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 1, 2, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 1, 3, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 2, 0, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 2, 1, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 2, 2, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 2, 3, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)

    # Guardar la presentación modificada en disco.
    presentation.save("AnimatingCategoriesElements_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**¿Se admiten diferentes tipos de efectos (por ejemplo, entrada, énfasis, salida) para los gráficos como para las formas normales?**

Sí. Un gráfico se trata como una forma, por lo que admite los tipos estándar de efectos de animación, incluidos entrada, énfasis y salida, con control total mediante la línea de tiempo de la diapositiva y las secuencias de animación.

**¿Puedo combinar la animación del gráfico con las transiciones de diapositiva?**

Sí. [Transiciones](/slides/es/python-java/slide-transition/) se aplican a la diapositiva, mientras que los efectos de animación se aplican a los objetos de la misma. Puede usar ambos juntos en una presentación y controlarlos de forma independiente.

**¿Se conservan las animaciones de los gráficos al guardar en PPTX?**

Sí. Cuando [guarda en PPTX](/slides/es/python-java/save-presentation/), todos los efectos de animación y su orden se conservan porque forman parte del modelo nativo de animación de la presentación.

**¿Puedo leer animaciones de gráficos existentes en una presentación y modificarlas?**

Sí. La API brinda acceso a la línea de tiempo de la diapositiva, secuencias y efectos, lo que permite inspeccionar las animaciones de gráficos actuales y ajustarlas sin recrear todo desde cero.

**¿Puedo crear un vídeo que incluya animaciones de gráficos usando Aspose.Slides?**

Sí. Puede [exportar una presentación a vídeo](/slides/es/python-java/convert-powerpoint-to-video/) manteniendo las animaciones, configurando los tiempos y otras opciones de exportación para que el clip resultante refleje la reproducción animada.