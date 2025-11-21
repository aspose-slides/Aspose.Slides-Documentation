---
title: Series de gráfico
type: docs
url: /es/nodejs-java/chart-series/
keywords: "Series de gráfico, color de series, presentación PowerPoint, Java, Aspose.Slides for Node.js via Java"
description: "Series de gráfico en presentaciones PowerPoint en JavaScript"
---

Una serie es una fila o columna de números trazados en un gráfico.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **Establecer superposición de series de gráfico**

Con el método [ChartSeries.getOverlap](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/properties/overlap) puede especificar cuánto deben superponerse las barras y columnas en un gráfico 2D (rango: -100 a 100). Esta propiedad se aplica a todas las series del grupo de series principal: es una proyección de la propiedad de grupo correspondiente. Por lo tanto, esta propiedad es de solo lectura.

Utilice la propiedad de lectura/escritura `ParentSeriesGroup.getOverlap` para establecer el valor preferido de `Overlap`.

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
1. Añada un gráfico de columnas agrupadas en una diapositiva.
1. Acceda a la primera serie del gráfico.
1. Acceda al `ParentSeriesGroup` de la serie del gráfico y establezca el valor de superposición que desee para la serie. 
1. Guarde la presentación modificada en un archivo PPTX.

Este código JavaScript le muestra cómo establecer la superposición para una serie de gráfico:
```javascript
var pres = new aspose.slides.Presentation();
try {
    // Añade el gráfico
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400, true);
    var series = chart.getChartData().getSeries();
    if (series.get_Item(0).getOverlap() == 0) {
        // Establece la superposición de la serie
        series.get_Item(0).getParentSeriesGroup().setOverlap(-30);
    }
    // Escribe el archivo de presentación en disco
    pres.save("SetChartSeriesOverlap_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Cambiar el color de la serie**

Aspose.Slides para Node.js a través de Java le permite cambiar el color de una serie de la siguiente manera:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
1. Añada un gráfico en la diapositiva.
1. Acceda a la serie cuyo color desea cambiar. 
1. Establezca el tipo de relleno y el color de relleno que prefiera.
1. Guarde la presentación modificada.

Este código JavaScript le muestra cómo cambiar el color de una serie:
```javascript
var pres = new aspose.slides.Presentation("test.pptx");
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Pie, 50, 50, 600, 400);
    var point = chart.getChartData().getSeries().get_Item(0).getDataPoints().get_Item(1);
    point.setExplosion(30);
    point.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    point.getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Cambiar el color de la categoría de la serie**

Aspose.Slides para Node.js a través de Java le permite cambiar el color de la categoría de una serie de la siguiente manera:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
1. Añada un gráfico en la diapositiva.
1. Acceda a la categoría de la serie cuyo color desea cambiar.
1. Establezca el tipo de relleno y el color de relleno que prefiera.
1. Guarde la presentación modificada.

Este código JavaScript le muestra cómo cambiar el color de la categoría de una serie:
```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400);
    var point = chart.getChartData().getSeries().get_Item(0).getDataPoints().get_Item(0);
    point.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    point.getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Cambiar el nombre de la serie** 

Por defecto, los nombres de la leyenda de un gráfico son el contenido de las celdas situadas encima de cada columna o fila de datos. 

En nuestro ejemplo (imagen de muestra):

* las columnas son *Series 1, Series 2,* y *Series 3*;
* las filas son *Category 1, Category 2, Category 3,* y *Category 4.* 

Aspose.Slides para Node.js a través de Java le permite actualizar o cambiar el nombre de una serie en sus datos de gráfico y en la leyenda.

Este código JavaScript le muestra cómo cambiar el nombre de una serie en sus datos de gráfico `ChartDataWorkbook`:
```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Column3D, 50, 50, 600, 400, true);
    var seriesCell = chart.getChartData().getChartDataWorkbook().getCell(0, 0, 1);
    seriesCell.setValue("New name");
    pres.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


Este código JavaScript le muestra cómo cambiar el nombre de una serie en su leyenda mediante `Series`:
```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Column3D, 50, 50, 600, 400, true);
    var series = chart.getChartData().getSeries().get_Item(0);
    var name = series.getName();
    name.getAsCells().get_Item(0).setValue("New name");
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Establecer color de relleno de la serie de gráfico**

Aspose.Slides para Node.js a través de Java le permite establecer el color de relleno automático para series de gráfico dentro del área de trazado de la siguiente manera:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
1. Obtenga una referencia a una diapositiva por su índice.
1. Añada un gráfico con datos predeterminados según el tipo que prefiera (en el ejemplo siguiente, usamos `ChartType.ClusteredColumn`).
1. Acceda a la serie del gráfico y establezca el color de relleno en Automático.
1. Guarde la presentación en un archivo PPTX.

Este código JavaScript le muestra cómo establecer el color de relleno automático para una serie de gráfico:
```javascript
var pres = new aspose.slides.Presentation();
try {
    // Crea un gráfico de columnas agrupadas
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 100, 50, 600, 400);
    // Establece el formato de relleno de la serie a automático
    for (var i = 0; i < chart.getChartData().getSeries().size(); i++) {
        chart.getChartData().getSeries().get_Item(i).getAutomaticSeriesColor();
    }
    // Escribe el archivo de presentación en disco
    pres.save("AutoFillSeries_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Establecer colores de relleno invertidos para la serie de gráfico**

Aspose.Slides le permite establecer el color de relleno invertido para series de gráfico dentro del área de trazado de la siguiente manera:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
1. Obtenga una referencia a una diapositiva por su índice.
1. Añada un gráfico con datos predeterminados según el tipo que prefiera (en el ejemplo siguiente, usamos `ChartType.ClusteredColumn`).
1. Acceda a la serie del gráfico y establezca el color de relleno en invertido.
1. Guarde la presentación en un archivo PPTX.

Este código JavaScript demuestra la operación:
```javascript
var inverColor = java.getStaticFieldValue("java.awt.Color", "RED");
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 100, 100, 400, 300);
    var workBook = chart.getChartData().getChartDataWorkbook();
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    // Agrega nuevas series y categorías
    chart.getChartData().getSeries().add(workBook.getCell(0, 0, 1, "Series 1"), chart.getType());
    chart.getChartData().getCategories().add(workBook.getCell(0, 1, 0, "Category 1"));
    chart.getChartData().getCategories().add(workBook.getCell(0, 2, 0, "Category 2"));
    chart.getChartData().getCategories().add(workBook.getCell(0, 3, 0, "Category 3"));
    // Toma la primera serie del gráfico y rellena sus datos de serie.
    var series = chart.getChartData().getSeries().get_Item(0);
    series.getDataPoints().addDataPointForBarSeries(workBook.getCell(0, 1, 1, -20));
    series.getDataPoints().addDataPointForBarSeries(workBook.getCell(0, 2, 1, 50));
    series.getDataPoints().addDataPointForBarSeries(workBook.getCell(0, 3, 1, -30));
    var seriesColor = series.getAutomaticSeriesColor();
    series.setInvertIfNegative(true);
    series.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    series.getFormat().getFill().getSolidFillColor().setColor(seriesColor);
    series.getInvertedSolidFillColor().setColor(inverColor);
    pres.save("SetInvertFillColorChart_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Invertir la serie cuando el valor es negativo**

Aspose.Slides le permite establecer la inversión mediante el método `ChartDataPoint.setInvertIfNegative`. Cuando se establece una inversión mediante las propiedades, el punto de datos invierte sus colores al obtener un valor negativo. 

Este código JavaScript demuestra la operación:
```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400, true);
    var series = chart.getChartData().getSeries();
    chart.getChartData().getSeries().clear();
    var chartSeries = series.add(chart.getChartData().getChartDataWorkbook().getCell(0, "B1"), chart.getType());
    chartSeries.getDataPoints().addDataPointForBarSeries(chart.getChartData().getChartDataWorkbook().getCell(0, "B2", -5));
    chartSeries.getDataPoints().addDataPointForBarSeries(chart.getChartData().getChartDataWorkbook().getCell(0, "B3", 3));
    chartSeries.getDataPoints().addDataPointForBarSeries(chart.getChartData().getChartDataWorkbook().getCell(0, "B4", -2));
    chartSeries.getDataPoints().addDataPointForBarSeries(chart.getChartData().getChartDataWorkbook().getCell(0, "B5", 1));
    chartSeries.setInvertIfNegative(false);
    chartSeries.getDataPoints().get_Item(2).setInvertIfNegative(true);
    pres.save("out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Borrar los datos de los puntos de datos específicos**

Aspose.Slides para Node.js a través de Java le permite borrar los datos de `DataPoints` para una serie de gráfico específica de la siguiente manera:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
2. Obtenga la referencia de una diapositiva mediante su índice.
3. Obtenga la referencia de un gráfico mediante su índice.
4. Recorra todos los `DataPoints` del gráfico y establezca `XValue` y `YValue` en null.
5. Borre todos los `DataPoints` de la serie de gráfico específica.
6. Guarde la presentación modificada en un archivo PPTX.

Este código JavaScript demuestra la operación:
```javascript
var pres = new aspose.slides.Presentation("TestChart.pptx");
try {
    var sl = pres.getSlides().get_Item(0);
    var chart = sl.getShapes().get_Item(0);
    for (let i = 0; i < chart.getChartData().getSeries().get_Item(0).getDataPoints().size(); i++) {
        let dataPoint = chart.getChartData().getSeries().get_Item(0).getDataPoints().get_Item(i);
        dataPoint.getXValue().getAsCell().setValue(null);
        dataPoint.getYValue().getAsCell().setValue(null);
    }
    chart.getChartData().getSeries().get_Item(0).getDataPoints().clear();
    pres.save("ClearSpecificChartSeriesDataPointsData.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Establecer ancho de separación de la serie**

Aspose.Slides para Node.js a través de Java le permite establecer el ancho de separación de una serie mediante la propiedad **`GapWidth`** de la siguiente manera:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
1. Acceda a la primera diapositiva.
1. Añada un gráfico con datos predeterminados.
1. Acceda a cualquier serie del gráfico.
1. Establezca la propiedad `GapWidth`.
1. Guarde la presentación modificada en un archivo PPTX.

Este código JavaScript le muestra cómo establecer el ancho de separación de una serie:
```javascript
// Crea una presentación vacía
var pres = new aspose.slides.Presentation();
try {
    // Accede a la primera diapositiva de la presentación
    var slide = pres.getSlides().get_Item(0);
    // Añade un gráfico con datos predeterminados
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.StackedColumn, 0, 0, 500, 500);
    // Establece el índice de la hoja de datos del gráfico
    var defaultWorksheetIndex = 0;
    // Obtiene la hoja de cálculo de datos del gráfico
    var fact = chart.getChartData().getChartDataWorkbook();
    // Añade series
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.getType());
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 2, "Series 2"), chart.getType());
    // Añade categorías
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 3, 0, "Caetegoty 3"));
    // Obtiene la segunda serie del gráfico
    var series = chart.getChartData().getSeries().get_Item(1);
    // Rellena los datos de la serie
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 2, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 2, 10));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 2, 60));
    // Establece el valor de GapWidth
    series.getParentSeriesGroup().setGapWidth(50);
    // Guarda la presentación en disco
    pres.save("GapWidth_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Preguntas frecuentes**

**¿Existe un límite en la cantidad de series que puede contener un solo gráfico?**

Aspose.Slides no impone un límite fijo al número de series que añada. El techo práctico está determinado por la legibilidad del gráfico y por la memoria disponible para su aplicación.

**¿Qué pasa si las columnas dentro de un grupo están demasiado juntas o demasiado separadas?**

Ajuste la configuración de **Gap Width** para esa serie (o su grupo de series principal). Incrementar el valor amplía el espacio entre columnas, mientras que reducirlo las acerca más.