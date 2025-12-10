---
title: Optimizar cálculos de gráficos para presentaciones en Java
linktitle: Cálculos de gráficos
type: docs
weight: 50
url: /es/java/chart-calculations/
keywords:
- cálculos de gráficos
- elementos de gráfico
- posición del elemento
- posición real
- elemento hijo
- elemento padre
- valores del gráfico
- valor real
- PowerPoint
- presentación
- Java
- Aspose.Slides
description: "Comprenda los cálculos de gráficos, la actualización de datos y el control de precisión en Aspose.Slides for Java para PPT y PPTX, con ejemplos prácticos de código Java."
---

## **Calcular valores reales de los elementos del gráfico**
Aspose.Slides for Java ofrece una API sencilla para obtener estas propiedades. Las propiedades de la interfaz [IAxis](https://reference.aspose.com/slides/java/com.aspose.slides/IAxis) proporcionan información sobre la posición real del elemento del eje del gráfico ([IAxis.getActualMaxValue](https://reference.aspose.com/slides/java/com.aspose.slides/IAxis#getActualMaxValue--), [IAxis.getActualMinValue](https://reference.aspose.com/slides/java/com.aspose.slides/IAxis#getActualMinValue--), [IAxis.getActualMajorUnit](https://reference.aspose.com/slides/java/com.aspose.slides/IAxis#getActualMajorUnit--), [IAxis.getActualMinorUnit](https://reference.aspose.com/slides/java/com.aspose.slides/IAxis#getActualMinorUnit--), [IAxis.getActualMajorUnitScale](https://reference.aspose.com/slides/java/com.aspose.slides/IAxis#getActualMajorUnitScale--), [IAxis.getActualMinorUnitScale](https://reference.aspose.com/slides/java/com.aspose.slides/IAxis#getActualMinorUnitScale--)). Es necesario llamar al método [IChart.validateChartLayout()](https://reference.aspose.com/slides/java/com.aspose.slides/IChart#validateChartLayout--) previamente para rellenar las propiedades con los valores reales.
```java
Presentation pres = new Presentation();
try {
    Chart chart = (Chart)pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Area, 100, 100, 500, 350);
    chart.validateChartLayout();
    
    double maxValue = chart.getAxes().getVerticalAxis().getActualMaxValue();
    double minValue = chart.getAxes().getVerticalAxis().getActualMinValue();
    
    double majorUnit = chart.getAxes().getHorizontalAxis().getActualMajorUnit();
    double minorUnit = chart.getAxes().getHorizontalAxis().getActualMinorUnit();
} finally {
    if (pres != null) pres.dispose();
}
```


## **Calcular la posición real de los elementos padre del gráfico**
Aspose.Slides for Java ofrece una API sencilla para obtener estas propiedades. Las propiedades de la interfaz [IActualLayout](https://reference.aspose.com/slides/java/com.aspose.slides/IActualLayout) proporcionan información sobre la posición real del elemento padre del gráfico ([IActualLayout.getActualX](https://reference.aspose.com/slides/java/com.aspose.slides/IActualLayout#getActualX--), [IActualLayout.getActualY](https://reference.aspose.com/slides/java/com.aspose.slides/IActualLayout#getActualY--), [IActualLayout.getActualWidth](https://reference.aspose.com/slides/java/com.aspose.slides/IActualLayout#getActualWidth--), [IActualLayout.getActualHeight](https://reference.aspose.com/slides/java/com.aspose.slides/IActualLayout#getActualHeight--)). Es necesario llamar al método [IChart.validateChartLayout()](https://reference.aspose.com/slides/java/com.aspose.slides/IChart#validateChartLayout--) previamente para rellenar las propiedades con los valores reales.
```java
Presentation pres = new Presentation();
try {
    Chart chart = (Chart) pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 500, 350);
    chart.validateChartLayout();

    double x = chart.getPlotArea().getActualX();
    double y = chart.getPlotArea().getActualY();
    double w = chart.getPlotArea().getActualWidth();
    double h = chart.getPlotArea().getActualHeight();
} finally {
    if (pres != null) pres.dispose();
}
```


## **Ocultar elementos del gráfico**
Este tema le ayuda a comprender cómo ocultar información de un gráfico. Con Aspose.Slides for Java puede ocultar **Título, Eje vertical, Eje horizontal** y **Líneas de cuadrícula** del gráfico. El siguiente ejemplo de código muestra cómo usar estas propiedades.
```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IChart chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 140, 118, 320, 370);

    //Ocultando el título del gráfico
    chart.setTitle(false);

    ///Ocultando el eje de valores
    chart.getAxes().getVerticalAxis().setVisible(false);

    //Visibilidad del eje de categorías
    chart.getAxes().getHorizontalAxis().setVisible(false);

    //Ocultando la leyenda
    chart.setLegend(false);

    //Ocultando líneas de cuadrícula principales
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.NoFill);

    for (int i = 0; i < chart.getChartData().getSeries().size(); i++)
    {
        chart.getChartData().getSeries().removeAt(i);
    }

    IChartSeries series = chart.getChartData().getSeries().get_Item(0);

    series.getMarker().setSymbol(MarkerStyleType.Circle);
    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);
    series.getLabels().getDefaultDataLabelFormat().setPosition(LegendDataLabelPosition.Top);
    series.getMarker().setSize(15);

    //Estableciendo el color de línea de la serie
    series.getFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    series.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.MAGENTA);
    series.getFormat().getLine().setDashStyle(LineDashStyle.Solid);

    pres.save("HideInformationFromChart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Preguntas frecuentes**

**¿Los libros de Excel externos funcionan como fuente de datos y cómo afecta eso al recálculo?**

Sí. Un gráfico puede hacer referencia a un libro externo: cuando se conecta o actualiza la fuente externa, las fórmulas y valores se toman de ese libro, y el gráfico refleja las actualizaciones durante las operaciones de apertura/edición. La API le permite [especificar el libro de trabajo externo](https://reference.aspose.com/slides/java/com.aspose.slides/chartdata/#setExternalWorkbook-java.lang.String-boolean-) la ruta y gestionar los datos vinculados.

**¿Puedo calcular y mostrar líneas de tendencia sin implementar la regresión yo mismo?**

Sí. Las [líneas de tendencia](/slides/es/java/trend-line/) (lineales, exponenciales y otras) son añadidas y actualizadas por Aspose.Slides; sus parámetros se recalculan automáticamente a partir de los datos de la serie, por lo que no necesita implementar sus propios cálculos.

**Si una presentación tiene varios gráficos con enlaces externos, ¿puedo controlar qué libro de trabajo usa cada gráfico para los valores calculados?**

Sí. Cada gráfico puede apuntar a su propio [libro de trabajo externo](https://reference.aspose.com/slides/java/com.aspose.slides/chartdata/#setExternalWorkbook-java.lang.String-boolean-), o puede crear/reemplazar un libro de trabajo externo por gráfico de forma independiente de los demás.