---
title: Personalizar áreas de trazado de gráficos de presentación en Android
linktitle: Área de trazado
type: docs
url: /es/androidjava/chart-plot-area/
keywords:
- gráfico
- área de trazado
- anchura del área de trazado
- altura del área de trazado
- tamaño del área de trazado
- modo de diseño
- PowerPoint
- presentación
- Android
- Java
- Aspose.Slides
description: "Descubra cómo personalizar las áreas de trazado de los gráficos en presentaciones de PowerPoint con Aspose.Slides para Android a través de Java. Mejore los visuales de sus diapositivas sin esfuerzo."
---

## **Obtener ancho y altura del área de trazado de un gráfico**
Aspose.Slides para Android a través de Java proporciona una API simple para .  

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
2. Acceder a la primera diapositiva.
3. Agregar un gráfico con datos predeterminados.
4. Llamar al método [IChart.validateChartLayout()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChart#validateChartLayout--) antes de obtener los valores reales.
5. Obtiene la ubicación X real (izquierda) del elemento del gráfico relativo a la esquina superior izquierda del gráfico.
6. Obtiene la parte superior real del elemento del gráfico relativa a la esquina superior izquierda del gráfico.
7. Obtiene el ancho real del elemento del gráfico.
8. Obtiene la altura real del elemento del gráfico.
```java
// Crear una instancia de la clase Presentation
Presentation pres = new Presentation();
try {
    Chart chart = (Chart)pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 500, 350);
    chart.validateChartLayout();

    double x = chart.getPlotArea().getActualX();
    double y = chart.getPlotArea().getActualY();
    double w = chart.getPlotArea().getActualWidth();
    double h = chart.getPlotArea().getActualHeight();
} finally {
    if (pres != null) pres.dispose();
}
```


## **Establecer el modo de diseño del área de trazado de un gráfico**
Aspose.Slides para Android a través de Java proporciona una API simple para establecer el modo de diseño del área de trazado del gráfico.  

Se han añadido los métodos [**setLayoutTargetType**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ChartPlotArea#setLayoutTargetType-int-) y [**getLayoutTargetType**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ChartPlotArea#getLayoutTargetType--) a la clase [**ChartPlotArea**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ChartPlotArea) y a la interfaz [**IChartPlotArea**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartPlotArea). Si el diseño del área de trazado se define manualmente, esta propiedad especifica si se debe diseñar el área de trazado por su interior (sin incluir los ejes y sus etiquetas) o por su exterior (incluyendo los ejes y sus etiquetas). Hay dos valores posibles que se definen en el enumerado [**LayoutTargetType**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/LayoutTargetType).

- [**LayoutTargetType.Inner**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/LayoutTargetType#Inner) - especifica que el tamaño del área de trazado determinará el tamaño del área de trazado, sin incluir las marcas de graduación y las etiquetas de los ejes.
- [**LayoutTargetType.Outer**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/LayoutTargetType#Outer) - especifica que el tamaño del área de trazado determinará el tamaño del área de trazado, las marcas de graduación y las etiquetas de los ejes.

A continuación se muestra el código de ejemplo.
```java
// Crear una instancia de la clase Presentation
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 100, 600, 400);
    chart.getPlotArea().setX(0.2f);
    chart.getPlotArea().setY(0.2f);
    chart.getPlotArea().setWidth(0.7f);
    chart.getPlotArea().setHeight(0.7f);
    chart.getPlotArea().setLayoutTargetType(LayoutTargetType.Inner);

    pres.save("SetLayoutMode_outer.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Preguntas frecuentes**

**¿En qué unidades se devuelven x real, y real, ancho real y altura real?**

En puntos; 1 pulgada = 72 puntos. Estas son unidades de coordenadas de Aspose.Slides.

**¿En qué se diferencia el área de trazado del área del gráfico en cuanto al contenido?**

El área de trazado es la región donde se dibujan los datos (series, líneas de cuadrícula, líneas de tendencia, etc.); el área del gráfico incluye los elementos circundantes (título, leyenda, etc.). En los gráficos 3D, el área de trazado también incluye los muros/suelo y los ejes.

**¿Cómo se interpretan x, y, ancho y altura del área de trazado cuando el diseño es manual?**

Son fracciones (0–1) del tamaño total del gráfico; en este modo, el posicionamiento automático está deshabilitado y se utilizan las fracciones que establezca.

**¿Por qué cambió la posición del área de trazado después de agregar/mover la leyenda?**

La leyenda se ubica en el área del gráfico fuera del área de trazado, pero afecta el diseño y el espacio disponible, por lo que el área de trazado puede desplazarse cuando el posicionamiento automático está activo. (Este es el comportamiento estándar de los gráficos de PowerPoint.)