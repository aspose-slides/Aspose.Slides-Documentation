---
title: Cálculos de Gráficos
type: docs
weight: 50
url: /es/nodejs-java/chart-calculations/
---

## **Calcular valores reales de los elementos del gráfico**

Aspose.Slides for Node.js via Java proporciona una API sencilla para obtener estas propiedades. Las propiedades de la clase [Axis](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Axis) proporcionan información sobre la posición real del elemento del gráfico ([Axis.getActualMaxValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Axis#getActualMaxValue--), [Axis.getActualMinValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Axis#getActualMinValue--), [Axis.getActualMajorUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Axis#getActualMajorUnit--), [Axis.getActualMinorUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Axis#getActualMinorUnit--), [Axis.getActualMajorUnitScale](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Axis#getActualMajorUnitScale--), [Axis.getActualMinorUnitScale](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Axis#getActualMinorUnitScale--)). Es necesario llamar al método [Chart.validateChartLayout()](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Chart#validateChartLayout--) antes para rellenar las propiedades con valores reales.
```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Area, 100, 100, 500, 350);
    chart.validateChartLayout();
    var maxValue = chart.getAxes().getVerticalAxis().getActualMaxValue();
    var minValue = chart.getAxes().getVerticalAxis().getActualMinValue();
    var majorUnit = chart.getAxes().getHorizontalAxis().getActualMajorUnit();
    var minorUnit = chart.getAxes().getHorizontalAxis().getActualMinorUnit();
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Calcular posición real de los elementos principales del gráfico**

Aspose.Slides for Node.js via Java proporciona una API sencilla para obtener estas propiedades. Las propiedades de la clase [ActualLayout](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ActualLayout) proporcionan información sobre la posición real del elemento principal del gráfico ([ActualLayout.getActualX](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ActualLayout#getActualX--), [ActualLayout.getActualY](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ActualLayout#getActualY--), [ActualLayout.getActualWidth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ActualLayout#getActualWidth--), [ActualLayout.getActualHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ActualLayout#getActualHeight--)). Es necesario llamar al método [Chart.validateChartLayout()](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Chart#validateChartLayout--) antes para rellenar las propiedades con valores reales.
```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 100, 100, 500, 350);
    chart.validateChartLayout();
    var x = chart.getPlotArea().getActualX();
    var y = chart.getPlotArea().getActualY();
    var w = chart.getPlotArea().getActualWidth();
    var h = chart.getPlotArea().getActualHeight();
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Ocultar información del gráfico**

Este tema le ayuda a comprender cómo ocultar información del gráfico. Usando Aspose.Slides for Node.js via Java puede ocultar **Título, Eje vertical, Eje horizontal** y **Líneas de cuadrícula** del gráfico. El siguiente ejemplo de código muestra cómo usar estas propiedades.
```javascript
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.LineWithMarkers, 140, 118, 320, 370);
    // Ocultando el título del gráfico
    chart.setTitle(false);
    // /Ocultando eje de valores
    chart.getAxes().getVerticalAxis().setVisible(false);
    // Visibilidad del eje de categorías
    chart.getAxes().getHorizontalAxis().setVisible(false);
    // Ocultando la leyenda
    chart.setLegend(false);
    // Ocultando líneas de cuadrícula principales
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    for (var i = 0; i < chart.getChartData().getSeries().size(); i++) {
        chart.getChartData().getSeries().removeAt(i);
    }
    var series = chart.getChartData().getSeries().get_Item(0);
    series.getMarker().setSymbol(aspose.slides.MarkerStyleType.Circle);
    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);
    series.getLabels().getDefaultDataLabelFormat().setPosition(aspose.slides.LegendDataLabelPosition.Top);
    series.getMarker().setSize(15);
    // Estableciendo el color de la línea de la serie
    series.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    series.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "MAGENTA"));
    series.getFormat().getLine().setDashStyle(aspose.slides.LineDashStyle.Solid);
    pres.save("HideInformationFromChart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **FAQ**

**¿Los libros de Excel externos funcionan como fuente de datos y cómo afecta eso a la recalculación?**

Sí. Un gráfico puede hacer referencia a un libro externo: cuando se conecta o se actualiza la fuente externa, las fórmulas y valores se toman de ese libro, y el gráfico refleja las actualizaciones durante las operaciones de apertura/edición. La API le permite [especificar la ruta del libro externo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/setexternalworkbook/) y gestionar los datos vinculados.

**¿Puedo calcular y mostrar líneas de tendencia sin implementar yo mismo la regresión?**

Sí. Las [Trendlines](/slides/es/nodejs-java/trend-line/) (lineales, exponenciales y otras) son añadidas y actualizadas por Aspose.Slides; sus parámetros se recalculan automáticamente a partir de los datos de la serie, por lo que no necesita implementar sus propios cálculos.

**Si una presentación tiene varios gráficos con enlaces externos, ¿puedo controlar qué libro usa cada gráfico para los valores calculados?**

Sí. Cada gráfico puede apuntar a su propio [libro externo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/setexternalworkbook/), o puede crear/reemplazar un libro externo por gráfico de forma independiente de los demás.