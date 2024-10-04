---
title: Área de Trazado de Gráficos
type: docs
url: /java/chart-plot-area/
---

## **Obtener Ancho, Alto del Área de Trazado de Gráficos**
Aspose.Slides para Java proporciona una API simple para. 

1. Crear una instancia de la [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) clase.
1. Acceder a la primera diapositiva.
1. Agregar un gráfico con datos predeterminados.
1. Llamar al método [IChart.validateChartLayout()](https://reference.aspose.com/slides/java/com.aspose.slides/IChart#validateChartLayout--) antes de obtener los valores reales.
1. Obtener la ubicación X real (izquierda) del elemento gráfico en relación con la esquina superior izquierda del gráfico.
1. Obtener la parte superior real del elemento gráfico en relación con la esquina superior izquierda del gráfico.
1. Obtener el ancho real del elemento gráfico.
1. Obtener la altura real del elemento gráfico.

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

## **Establecer Modo de Diseño del Área de Trazado de Gráficos**
Aspose.Slides para Java proporciona una API simple para establecer el modo de diseño del área de trazado del gráfico. Se han añadido los métodos [**setLayoutTargetType**](https://reference.aspose.com/slides/java/com.aspose.slides/ChartPlotArea#setLayoutTargetType-int-) y [**getLayoutTargetType**](https://reference.aspose.com/slides/java/com.aspose.slides/ChartPlotArea#getLayoutTargetType--) a la clase [**ChartPlotArea**](https://reference.aspose.com/slides/java/com.aspose.slides/ChartPlotArea) y a la interfaz [**IChartPlotArea**](https://reference.aspose.com/slides/java/com.aspose.slides/IChartPlotArea). Si se define manualmente el diseño del área de trazado, esta propiedad especifica si se debe diseñar el área de trazado por su interior (sin incluir los ejes y las etiquetas de los ejes) o por su exterior (incluyendo los ejes y las etiquetas de los ejes). Hay dos valores posibles que se definen en el enum [**LayoutTargetType**](https://reference.aspose.com/slides/java/com.aspose.slides/LayoutTargetType).

- [**LayoutTargetType.Inner**](https://reference.aspose.com/slides/java/com.aspose.slides/LayoutTargetType#Inner) - especifica que el tamaño del área de trazado debe determinar el tamaño del área de trazado, sin incluir las marcas de graduación y las etiquetas de los ejes.
- [**LayoutTargetType.Outer**](https://reference.aspose.com/slides/java/com.aspose.slides/LayoutTargetType#Outer) - especifica que el tamaño del área de trazado debe determinar el tamaño del área de trazado, las marcas de graduación y las etiquetas de los ejes.

El código de muestra se muestra a continuación.

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