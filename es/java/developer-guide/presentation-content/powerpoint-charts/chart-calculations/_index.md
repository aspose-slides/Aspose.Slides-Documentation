---
title: Cálculos de Gráficos
type: docs
weight: 50
url: /java/chart-calculations/
---

## **Calcular Valores Reales de los Elementos del Gráfico**
Aspose.Slides para Java proporciona una API simple para obtener estas propiedades. Las propiedades de la interfaz [IAxis](https://reference.aspose.com/slides/java/com.aspose.slides/IAxis) proporcionan información sobre la posición real del elemento del gráfico del eje ([IAxis.getActualMaxValue](https://reference.aspose.com/slides/java/com.aspose.slides/IAxis#getActualMaxValue--), [IAxis.getActualMinValue](https://reference.aspose.com/slides/java/com.aspose.slides/IAxis#getActualMinValue--), [IAxis.getActualMajorUnit](https://reference.aspose.com/slides/java/com.aspose.slides/IAxis#getActualMajorUnit--), [IAxis.getActualMinorUnit](https://reference.aspose.com/slides/java/com.aspose.slides/IAxis#getActualMinorUnit--), [IAxis.getActualMajorUnitScale](https://reference.aspose.com/slides/java/com.aspose.slides/IAxis#getActualMajorUnitScale--), [IAxis.getActualMinorUnitScale](https://reference.aspose.com/slides/java/com.aspose.slides/IAxis#getActualMinorUnitScale--)). Es necesario llamar al método [IChart.validateChartLayout()](https://reference.aspose.com/slides/java/com.aspose.slides/IChart#validateChartLayout--) previamente para llenar las propiedades con valores reales.

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

## **Calcular la Posición Real de los Elementos del Gráfico Padre**
Aspose.Slides para Java proporciona una API simple para obtener estas propiedades. Las propiedades de la interfaz [IActualLayout](https://reference.aspose.com/slides/java/com.aspose.slides/IActualLayout) proporcionan información sobre la posición real del elemento del gráfico padre ([IActualLayout.getActualX](https://reference.aspose.com/slides/java/com.aspose.slides/IActualLayout#getActualX--), [IActualLayout.getActualY](https://reference.aspose.com/slides/java/com.aspose.slides/IActualLayout#getActualY--), [IActualLayout.getActualWidth](https://reference.aspose.com/slides/java/com.aspose.slides/IActualLayout#getActualWidth--), [IActualLayout.getActualHeight](https://reference.aspose.com/slides/java/com.aspose.slides/IActualLayout#getActualHeight--)). Es necesario llamar al método [IChart.validateChartLayout()](https://reference.aspose.com/slides/java/com.aspose.slides/IChart#validateChartLayout--) previamente para llenar las propiedades con valores reales.

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

## **Ocultar Información del Gráfico**
Este tema te ayuda a entender cómo ocultar información del gráfico. Utilizando Aspose.Slides para Java puedes ocultar **Título, Eje Vertical, Eje Horizontal** y **Líneas de Cuadrícula** del gráfico. El siguiente ejemplo de código muestra cómo usar estas propiedades.

```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IChart chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 140, 118, 320, 370);

    //Ocultar el Título del gráfico
    chart.setTitle(false);

    //Ocultar el eje de Valores
    chart.getAxes().getVerticalAxis().setVisible(false);

    //Visibilidad del Eje de Categoría
    chart.getAxes().getHorizontalAxis().setVisible(false);

    //Ocultar la Leyenda
    chart.setLegend(false);

    //Ocultar MajorGridLines
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

    //Configurando el color de la línea de la serie
    series.getFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    series.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.MAGENTA);
    series.getFormat().getLine().setDashStyle(LineDashStyle.Solid);

    pres.save("HideInformationFromChart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```