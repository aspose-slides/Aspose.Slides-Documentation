---
title: Personalizar áreas de trazado de gráficos de presentación en Java
linktitle: Área de trazado
type: docs
url: /es/java/chart-plot-area/
keywords:
- gráfico
- área de trazado
- ancho del área de trazado
- altura del área de trazado
- tamaño del área de trazado
- modo de diseño
- PowerPoint
- presentación
- Java
- Aspose.Slides
description: "Descubra cómo personalizar áreas de trazado de gráficos en presentaciones de PowerPoint con Aspose.Slides para Java. Mejore visualmente sus diapositivas sin esfuerzo."
---

## **Obtener ancho y altura del área de trazado del gráfico**
Aspose.Slides for Java proporciona una API simple para .  

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
1. Acceder a la primera diapositiva.
1. Añadir un gráfico con datos predeterminados.
1. Llamar al método [IChart.validateChartLayout()](https://reference.aspose.com/slides/java/com.aspose.slides/IChart#validateChartLayout--) antes de obtener los valores reales.
1. Obtiene la ubicación X real (izquierda) del elemento del gráfico relativa a la esquina superior izquierda del gráfico.
1. Obtiene la parte superior real del elemento del gráfico relativa a la esquina superior izquierda del gráfico.
1. Obtiene el ancho real del elemento del gráfico.
1. Obtiene la altura real del elemento del gráfico.
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


## **Establecer modo de diseño del área de trazado del gráfico**
Aspose.Slides for Java proporciona una API simple para establecer el modo de diseño del área de trazado del gráfico. Se han añadido los métodos [**setLayoutTargetType**](https://reference.aspose.com/slides/java/com.aspose.slides/ChartPlotArea#setLayoutTargetType-int-) y [**getLayoutTargetType**](https://reference.aspose.com/slides/java/com.aspose.slides/ChartPlotArea#getLayoutTargetType--) a la clase [**ChartPlotArea**](https://reference.aspose.com/slides/java/com.aspose.slides/ChartPlotArea) y a la interfaz [**IChartPlotArea**](https://reference.aspose.com/slides/java/com.aspose.slides/IChartPlotArea). Si el diseño del área de trazado se define manualmente, esta propiedad especifica si el diseño del área de trazado se hace por su interior (sin incluir ejes y etiquetas de eje) o por su exterior (incluyendo ejes y etiquetas de eje). Existen dos valores posibles que se definen en el enumerado [**LayoutTargetType**](https://reference.aspose.com/slides/java/com.aspose.slides/LayoutTargetType).

- [**LayoutTargetType.Inner**](https://reference.aspose.com/slides/java/com.aspose.slides/LayoutTargetType#Inner) - especifica que el tamaño del área de trazado determinará el tamaño del área de trazado, sin incluir las marcas de graduación y las etiquetas de eje.
- [**LayoutTargetType.Outer**](https://reference.aspose.com/slides/java/com.aspose.slides/LayoutTargetType#Outer) - especifica que el tamaño del área de trazado determinará el tamaño del área de trazado, las marcas de graduación y las etiquetas de eje.

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


## **FAQ**

**¿En qué unidades se devuelven x real, y real, ancho real y altura real?**

En puntos; 1 pulgada = 72 puntos. Estas son unidades de coordenadas de Aspose.Slides.

**¿En qué se diferencia el Área de trazado del Área del gráfico en cuanto al contenido?**

El Área de trazado es la región donde se dibujan los datos (series, líneas de cuadrícula, líneas de tendencia, etc.); el Área del gráfico incluye los elementos circundantes (título, leyenda, etc.). En los gráficos 3D, el Área de trazado también incluye las paredes/piso y los ejes.

**¿Cómo se interpretan x, y, ancho y altura del Área de trazado cuando el diseño es manual?**

Son fracciones (0–1) del tamaño total del gráfico; en este modo, la ubicación automática está desactivada y se utilizan las fracciones que usted establezca.

**¿Por qué cambió la posición del Área de trazado después de agregar/mover la leyenda?**

La leyenda se encuentra en el área del gráfico fuera del Área de trazado, pero afecta el diseño y el espacio disponible, por lo que el Área de trazado puede desplazarse cuando la ubicación automática está habilitada. (Este es el comportamiento estándar de los gráficos de PowerPoint.)