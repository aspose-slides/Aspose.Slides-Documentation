---
title: Animar gráficos de PowerPoint en Java
linktitle: Gráficos animados
type: docs
weight: 80
url: /es/java/animated-charts/
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
- Java
- Aspose.Slides
description: "Crea gráficos animados impresionantes en Java con Aspose.Slides. Potencia las presentaciones con visuales dinámicos en archivos PPT y PPTX—comienza ahora."
---

{{% alert color="primary" %}}

Aspose.Slides for Java admite animar los elementos del gráfico. **Series**, **Categorías**, **Elementos de series**, **Elementos de categorías** pueden animarse con el método [**ISequence**.**addEffect**](https://reference.aspose.com/slides/java/com.aspose.slides/ISequence#addEffect-com.aspose.slides.IChart-int-int-int-int-int-) y dos enumeraciones [**EffectChartMajorGroupingType**](https://reference.aspose.com/slides/java/com.aspose.slides/EffectChartMajorGroupingType) y [**EffectChartMinorGroupingType**](https://reference.aspose.com/slides/java/com.aspose.slides/EffectChartMinorGroupingType).

{{% /alert %}}

## **Animación de series de gráfico**
Si deseas animar una serie de gráfico, escribe el código según los pasos que se enumeran a continuación:

1. Carga una presentación.
1. Obtén la referencia del objeto del gráfico.
1. Anima la serie.
1. Escribe el archivo de la presentación en disco.

En el ejemplo que se muestra a continuación, animamos series de gráfico.
```java
// Instanciar la clase Presentation que representa un archivo de presentación
Presentation pres = new Presentation("ExistingChart.pptx");
try {
    // Obtener la referencia del objeto gráfico
    ISlide slide = pres.getSlides().get_Item(0);
    IShapeCollection shapes = slide.getShapes();
    IChart chart = (IChart) shapes.get_Item(0);

    // Animar la serie
    slide.getTimeline().getMainSequence().addEffect(chart, EffectType.Fade, EffectSubtype.None,
            EffectTriggerType.AfterPrevious);

    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart,
            EffectChartMajorGroupingType.BySeries, 0,
            EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart,
            EffectChartMajorGroupingType.BySeries, 1,
            EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart,
            EffectChartMajorGroupingType.BySeries, 2,
            EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart,
            EffectChartMajorGroupingType.BySeries, 3,
            EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    // Guardar la presentación modificada en disco
    pres.save("AnimatingSeries_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Animación de categoría de gráfico**
Si deseas animar una categoría de gráfico, escribe el código según los pasos que se enumeran a continuación:

1. Carga una presentación.
1. Obtén la referencia del objeto del gráfico.
1. Anima la categoría.
1. Escribe el archivo de la presentación en disco.

En el ejemplo que se muestra a continuación, animamos la categoría del gráfico.
```java
// Instanciar la clase Presentation que representa un archivo de presentación
Presentation pres = new Presentation("ExistingChart.pptx");
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IShapeCollection shapes = slide.getShapes();
    IChart chart = (IChart) shapes.get_Item(0);

    slide.getTimeline().getMainSequence().addEffect(chart, EffectType.Fade, EffectSubtype.None,
            EffectTriggerType.AfterPrevious);

    ((Sequence) slide.getTimeline().getMainSequence()).addEffect(chart,
            EffectChartMajorGroupingType.ByCategory, 0, 
            EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    
    ((Sequence) slide.getTimeline().getMainSequence()).addEffect(chart, 
            EffectChartMajorGroupingType.ByCategory, 1, 
            EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    
    ((Sequence) slide.getTimeline().getMainSequence()).addEffect(chart, 
            EffectChartMajorGroupingType.ByCategory, 2, 
            EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    
    ((Sequence) slide.getTimeline().getMainSequence()).addEffect(chart, 
            EffectChartMajorGroupingType.ByCategory, 3, 
            EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    pres.save("Sample_Animation_C.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Animación en un elemento de serie**
Si deseas animar los elementos de serie, escribe el código según los pasos que se enumeran a continuación:

1. Carga una presentación.
1. Obtén la referencia del objeto del gráfico.
1. Anima los elementos de serie.
1. Escribe el archivo de la presentación en disco.

En el ejemplo que se muestra a continuación, hemos animado los elementos de la serie.
```java
// Instanciar la clase Presentation que representa un archivo de presentación
Presentation pres = new Presentation("ExistingChart.pptx");
try {
    // Obtener la referencia del objeto del gráfico
    ISlide slide = pres.getSlides().get_Item(0);
    IShapeCollection shapes = slide.getShapes();
    IChart chart = (IChart) shapes.get_Item(0);

    // Animar elementos de series
    slide.getTimeline().getMainSequence().addEffect(chart, EffectType.Fade, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 
            0, 0, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 
            0, 1, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 
            0, 2, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 
            0, 3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 
            1, 0, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 
            1, 1, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 
            1, 2, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 
            1, 3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 
            2, 0, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 
            2, 1, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 
            2, 2, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 
            2, 3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    // Guardar el archivo de presentación en disco 
    pres.save("AnimatingSeriesElements_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Animación en un elemento de categoría**
Si deseas animar los elementos de categoría, escribe el código según los pasos que se enumeran a continuación:

1. Carga una presentación.
1. Obtén la referencia del objeto del gráfico.
1. Anima los elementos de categoría.
1. Escribe el archivo de la presentación en disco.

En el ejemplo que se muestra a continuación, hemos animado los elementos de categoría.
```java
// Instanciar la clase Presentation que representa un archivo de presentación
Presentation pres = new Presentation("ExistingChart.pptx");
try {
    // Obtener la referencia del objeto del gráfico
    ISlide slide = pres.getSlides().get_Item(0);
    IShapeCollection shapes = slide.getShapes();
    IChart chart = (IChart) shapes.get_Item(0);

    // Animar elementos de categorías
    slide.getTimeline().getMainSequence().addEffect(chart, EffectType.Fade, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 
            0, 0, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 
            0, 1, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 
            0, 2, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 
            0, 3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 
            1, 0, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 
            1, 1, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 
            1, 2, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 
            1, 3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 
            2, 0, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 
            2, 1, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 
            2, 2, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 
            2, 3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    // Guardar el archivo de presentación en disco
    pres.save("AnimatingCategoriesElements_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **FAQ**

**¿Se admiten diferentes tipos de efectos (p. ej., entrada, énfasis, salida) para los gráficos como para las formas regulares?**

Sí. Un gráfico se trata como una forma, por lo que admite los tipos de efectos de animación estándar, incluidos entrada, énfasis y salida, con control total a través de la línea de tiempo de la diapositiva y las secuencias de animación.

**¿Puedo combinar la animación de gráficos con transiciones de diapositivas?**

Sí. [Transitions](/slides/es/java/slide-transition/) se aplican a la diapositiva, mientras que los efectos de animación se aplican a los objetos de la diapositiva. Puedes usar ambos juntos en la misma presentación y controlarlos de forma independiente.

**¿Se conservan las animaciones de los gráficos al guardar en PPTX?**

Sí. Cuando [save to PPTX](/slides/es/java/save-presentation/), todos los efectos de animación y su orden se conservan porque forman parte del modelo nativo de animación de la presentación.

**¿Puedo leer animaciones de gráficos existentes de una presentación y modificarlas?**

Sí. La API brinda acceso a la línea de tiempo de la diapositiva, secuencias y efectos, lo que permite inspeccionar las animaciones de gráficos existentes y ajustarlas sin recrear todo desde cero.

**¿Puedo producir un vídeo que incluya animaciones de gráficos usando Aspose.Slides?**

Sí. Puedes [export a presentation to video](/slides/es/java/convert-powerpoint-to-video/) manteniendo las animaciones, configurando los tiempos y otras opciones de exportación para que el clip resultante refleje la reproducción animada.