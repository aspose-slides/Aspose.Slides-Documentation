---
title: Animar gráficos de PowerPoint en .NET
linktitle: Gráficos animados
type: docs
weight: 80
url: /es/net/animated-charts/
keywords:
- gráfico
- gráfico animado
- animación de gráfico
- series de gráfico
- categoría de gráfico
- elemento de serie
- elemento de categoría
- agregar efecto
- tipo de efecto
- PowerPoint
- presentación
- .NET
- C#
- Aspose.Slides
description: "Cree impresionantes gráficos animados en .NET con Aspose.Slides. Mejore las presentaciones con visuales dinámicos en archivos PPT y PPTX—comience ahora."
---

Aspose.Slides for .NET admite la animación de los elementos del gráfico. **Series**, **Categorías**, **Elementos de Serie**, **Elementos de Categoría** pueden animarse con el método [**ISequence**.**AddEffect**](https://reference.aspose.com/slides/net/aspose.slides.animation/isequence/methods/addeffect) y con dos enumeraciones [**EffectChartMajorGroupingType**](https://reference.aspose.com/slides/net/aspose.slides.animation/effectchartmajorgroupingtype) y [**EffectChartMinorGroupingType**](https://reference.aspose.com/slides/net/aspose.slides.animation/effectchartminorgroupingtype).

## **Animación de Series de Gráfica**
Si desea animar una serie de gráfico, escriba el código siguiendo los pasos enumerados a continuación:

1. Cargue una presentación.  
1. Obtenga una referencia del objeto de gráfico.  
1. Anime la serie.  
1. Guarde el archivo de presentación en disco.

En el ejemplo a continuación, animamos la serie del gráfico.  
```c#
 // Instanciar la clase Presentation que representa un archivo de presentación 
 using (Presentation presentation = new Presentation("ExistingChart.pptx"))
 {
     // Obtener la referencia del objeto de gráfico
     var slide = presentation.Slides[0] as Slide;
     var shapes = slide.Shapes as ShapeCollection;
     var chart = shapes[0] as IChart;

     // Animar la serie
     slide.Timeline.MainSequence.AddEffect(chart, EffectType.Fade, EffectSubtype.None,
     EffectTriggerType.AfterPrevious);

     ((Sequence)slide.Timeline.MainSequence).AddEffect(chart,
     EffectChartMajorGroupingType.BySeries, 0,
     EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

     ((Sequence)slide.Timeline.MainSequence).AddEffect(chart,
     EffectChartMajorGroupingType.BySeries, 1,
     EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

     ((Sequence)slide.Timeline.MainSequence).AddEffect(chart,
     EffectChartMajorGroupingType.BySeries, 2,
     EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

     ((Sequence)slide.Timeline.MainSequence).AddEffect(chart,
     EffectChartMajorGroupingType.BySeries, 3,
     EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

     // Guardar la presentación modificada en disco 
     presentation.Save("AnimatingSeries_out.pptx", SaveFormat.Pptx);
 }
```


## **Animación de Categoría de Gráfica**
Si desea animar una serie de gráfico, escriba el código siguiendo los pasos enumerados a continuación:

1. Cargue una presentación.  
1. Obtenga una referencia del objeto de gráfico.  
1. Anime la categoría.  
1. Guarde el archivo de presentación en disco.

En el ejemplo a continuación, animamos la categoría del gráfico.  
```c#
using (Presentation presentation = new Presentation("ExistingChart.pptx"))
{
    // Obtener la referencia del objeto de gráfico
    var slide = presentation.Slides[0] as Slide;
    var shapes = slide.Shapes as ShapeCollection;
    var chart = shapes[0] as IChart;

    // Animar los elementos de las categorías
    slide.Timeline.MainSequence.AddEffect(chart, EffectType.Fade, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 0, 0, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 0, 1, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 0, 2, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 0, 3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 1, 0, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 1, 1, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 1, 2, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 1, 3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 2, 0, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 2, 1, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 2, 2, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 2, 3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    // Guardar el archivo de presentación en disco
    presentation.Save("AnimatingCategoriesElements_out.pptx", SaveFormat.Pptx);
}
```


## **Animación en Elemento de Serie**
Si desea animar elementos de serie, escriba el código siguiendo los pasos enumerados a continuación:

1. Cargue una presentación.  
1. Obtenga una referencia del objeto de gráfico.  
1. Anime los elementos de la serie.  
1. Guarde el archivo de presentación en disco.

En el ejemplo a continuación, hemos animado los elementos de la serie.  
```c#
// Cargar una presentación
using (Presentation presentation = new Presentation("ExistingChart.pptx"))
{
    // Obtener la referencia del objeto de gráfico
    var slide = presentation.Slides[0] as Slide;
    var shapes = slide.Shapes as ShapeCollection;
    var chart = shapes[0] as IChart;

    // Animar elementos de serie
    slide.Timeline.MainSequence.AddEffect(chart, EffectType.Fade, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 0, 0, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 0, 1, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 0, 2, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 0, 3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 1, 0, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 1, 1, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 1, 2, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 1, 3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 2, 0, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 2, 1, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 2, 2, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 2, 3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    // Guardar el archivo de presentación en disco 
    presentation.Save("AnimatingSeriesElements_out.pptx", SaveFormat.Pptx);
}
```


## **Animación en Elemento de Categoría**
Si desea animar elementos de las categorías, escriba el código siguiendo los pasos enumerados a continuación:

1. Cargue una presentación.  
1. Obtenga una referencia del objeto de gráfico.  
1. Anime los elementos de las categorías.  
1. Guarde el archivo de presentación en disco.

En el ejemplo a continuación, hemos animado los elementos de las categorías.  
```c#
using (Presentation presentation = new Presentation("ExistingChart.pptx"))
{
    // Obtener la referencia del objeto de gráfico
    var slide = presentation.Slides[0] as Slide;
    var shapes = slide.Shapes as ShapeCollection;
    var chart = shapes[0] as IChart;

    // Animar los elementos de las categorías
    slide.Timeline.MainSequence.AddEffect(chart, EffectType.Fade, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 0, 0, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 0, 1, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 0, 2, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 0, 3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 1, 0, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 1, 1, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 1, 2, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 1, 3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 2, 0, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 2, 1, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 2, 2, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 2, 3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    // Guardar el archivo de presentación en disco
    presentation.Save("AnimatingCategoriesElements_out.pptx", SaveFormat.Pptx);
}
```


## **FAQ**

**¿Se admiten diferentes tipos de efecto (p. ej., entrada, énfasis, salida) para los gráficos como para las formas normales?**  
Sí. Un gráfico se trata como una forma, por lo que admite los tipos de efecto de animación estándar, incluidos entrada, énfasis y salida, con control total a través de la línea de tiempo de la diapositiva y las secuencias de animación.

**¿Puedo combinar la animación de gráficos con las transiciones de diapositivas?**  
Sí. [Transitions](/slides/es/net/slide-transition/) se aplican a la diapositiva, mientras que los efectos de animación se aplican a los objetos de la diapositiva. Puede usar ambos juntos en la misma presentación y controlarlos de forma independiente.

**¿Se conservan las animaciones de los gráficos al guardar en PPTX?**  
Sí. Cuando [guarda en PPTX](/slides/es/net/save-presentation/), todos los efectos de animación y su orden se conservan porque forman parte del modelo de animación nativo de la presentación.

**¿Puedo leer animaciones de gráficos existentes de una presentación y modificarlas?**  
Sí. La [API](https://reference.aspose.com/slides/net/aspose.slides.animation/) brinda acceso a la línea de tiempo de la diapositiva, las secuencias y los efectos, lo que le permite inspeccionar animaciones de gráficos existentes y ajustarlas sin recrear todo desde cero.

**¿Puedo generar un video que incluya animaciones de gráficos usando Aspose.Slides?**  
Sí. Puede [exportar una presentación a video](/slides/es/net/convert-powerpoint-to-video/) mientras preserva las animaciones, configurando los tiempos y otras opciones de exportación para que el clip resultante refleje la reproducción animada.