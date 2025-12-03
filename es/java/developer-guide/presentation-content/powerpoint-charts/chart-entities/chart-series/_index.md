---
title: Administrar series de datos de gráfico en presentaciones usando Java
linktitle: Series de datos
type: docs
url: /es/java/chart-series/
keywords:
- series de gráfico
- superposición de series
- color de series
- color de categoría
- nombre de serie
- punto de datos
- espacio entre series
- PowerPoint
- presentación
- Java
- Aspose.Slides
description: "Aprenda a gestionar series de gráfico en Java para PowerPoint (PPT/PPTX) con ejemplos de código prácticos y buenas prácticas para mejorar sus presentaciones de datos."
---

Una serie es una fila o columna de números trazados en un gráfico.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **Establecer superposición de series de gráfico**

Con la propiedad [IChartSeriesOverlap](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/properties/overlap) puede especificar cuánto deben superponerse las barras y columnas en un gráfico 2D (rango: -100 a 100). Esta propiedad se aplica a todas las series del grupo de series principal: es una proyección de la propiedad correspondiente del grupo. Por lo tanto, esta propiedad es de solo lectura.

Utilice la propiedad de lectura/escritura `ParentSeriesGroup.Overlap` para establecer el valor preferido de `Overlap`.

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
1. Añada un gráfico de columnas agrupadas en una diapositiva.
1. Acceda a la primera serie del gráfico.
1. Acceda al `ParentSeriesGroup` de la serie y establezca el valor de superposición que prefiera.
1. Guarde la presentación modificada en un archivo PPTX.

Este código Java le muestra cómo establecer la superposición para una serie de gráfico:
```java
Presentation pres = new Presentation();
try {
    // Añade gráfico
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400, true);
    IChartSeriesCollection series = chart.getChartData().getSeries();
    if (series.get_Item(0).getOverlap() == 0)
    {
        // Establece superposición de series
        series.get_Item(0).getParentSeriesGroup().setOverlap((byte)-30);
    }

    // Escribe el archivo de presentación en disco
    pres.save("SetChartSeriesOverlap_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Cambiar color de la serie**

Aspose.Slides for Java le permite cambiar el color de una serie de esta manera:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
1. Añada un gráfico en la diapositiva.
1. Acceda a la serie cuyo color desea cambiar. 
1. Establezca el tipo de relleno y el color de relleno que prefiera.
1. Guarde la presentación modificada.

Este código Java le muestra cómo cambiar el color de una serie:
```java
Presentation pres = new Presentation("test.pptx");
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 50, 50, 600, 400);
    IChartDataPoint point = chart.getChartData().getSeries().get_Item(0).getDataPoints().get_Item(1);

    point.setExplosion(30);
    point.getFormat().getFill().setFillType(FillType.Solid);
    point.getFormat().getFill().getSolidFillColor().setColor(Color.BLUE);

    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Cambiar color de la categoría de la serie**

Aspose.Slides for Java le permite cambiar el color de la categoría de una serie de esta manera:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
1. Añada un gráfico en la diapositiva.
1. Acceda a la categoría de la serie cuyo color desea cambiar.
1. Establezca el tipo de relleno y el color de relleno que prefiera.
1. Guarde la presentación modificada.

Este código Java le muestra cómo cambiar el color de la categoría de una serie:
```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400);
    IChartDataPoint point = chart.getChartData().getSeries().get_Item(0).getDataPoints().get_Item(0);

    point.getFormat().getFill().setFillType(FillType.Solid);
    point.getFormat().getFill().getSolidFillColor().setColor(Color.BLUE);

    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Cambiar nombre de la serie** 

De forma predeterminada, los nombres de la leyenda de un gráfico son el contenido de las celdas situadas encima de cada columna o fila de datos. 

En nuestro ejemplo (imagen de muestra),

* las columnas son *Series 1, Series 2,* y *Series 3*;
* las filas son *Category 1, Category 2, Category 3,* y *Category 4.* 

Aspose.Slides for Java le permite actualizar o cambiar el nombre de una serie en sus datos de gráfico y en la leyenda.

Este código Java le muestra cómo cambiar el nombre de una serie en los datos del gráfico `ChartDataWorkbook`:
```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Column3D, 50, 50, 600, 400, true);

    IChartDataCell seriesCell = chart.getChartData().getChartDataWorkbook().getCell(0, 0, 1);
    seriesCell.setValue("New name");

    pres.save("pres.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


Este código Java le muestra cómo cambiar el nombre de una serie en la leyenda mediante `Series`:
```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Column3D, 50, 50, 600, 400, true);
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);

    IStringChartValue name = series.getName();
    name.getAsCells().get_Item(0).setValue("New name");
} finally {
    if (pres != null) pres.dispose();
}
```


## **Establecer color de relleno automático de series de gráfico**

Aspose.Slides for Java le permite establecer el color de relleno automático para series de gráfico dentro de un área de trazado de esta manera:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
1. Obtenga una referencia a la diapositiva por su índice.
1. Añada un gráfico con datos predeterminados según el tipo que prefiera (en el ejemplo siguiente usamos `ChartType.ClusteredColumn`).
1. Acceda a la serie del gráfico y establezca el color de relleno en Automatic.
1. Guarde la presentación en un archivo PPTX.

Este código Java le muestra cómo establecer el color de relleno automático para una serie de gráfico:
```java
Presentation pres = new Presentation();
try {
    // Crea un gráfico de columnas agrupadas
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 50, 600, 400);

    // Establece el formato de relleno de la serie a automático
    for (int i = 0; i < chart.getChartData().getSeries().size(); i++)
    {
        chart.getChartData().getSeries().get_Item(i).getAutomaticSeriesColor();
    }

    // Escribe el archivo de presentación en disco
    pres.save("AutoFillSeries_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Establecer colores de relleno invertidos de series de gráfico**

Aspose.Slides le permite establecer el color de relleno invertido para series de gráfico dentro de un área de trazado de esta manera:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
1. Obtenga una referencia a la diapositiva por su índice.
1. Añada un gráfico con datos predeterminados según el tipo que prefiera (en el ejemplo siguiente usamos `ChartType.ClusteredColumn`).
1. Acceda a la serie del gráfico y establezca el color de relleno en invert.
1. Guarde la presentación en un archivo PPTX.

Este código Java demuestra la operación:
```java
Color inverColor = Color.RED;
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 400, 300);
    IChartDataWorkbook workBook = chart.getChartData().getChartDataWorkbook();

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    // Agrega nuevas series y categorías
    chart.getChartData().getSeries().add(workBook.getCell(0, 0, 1, "Series 1"), chart.getType());
    chart.getChartData().getCategories().add(workBook.getCell(0, 1, 0, "Category 1"));
    chart.getChartData().getCategories().add(workBook.getCell(0, 2, 0, "Category 2"));
    chart.getChartData().getCategories().add(workBook.getCell(0, 3, 0, "Category 3"));

    // Obtiene la primera serie del gráfico y llena sus datos de serie.
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);
    series.getDataPoints().addDataPointForBarSeries(workBook.getCell(0, 1, 1, -20));
    series.getDataPoints().addDataPointForBarSeries(workBook.getCell(0, 2, 1, 50));
    series.getDataPoints().addDataPointForBarSeries(workBook.getCell(0, 3, 1, -30));
    Color seriesColor = series.getAutomaticSeriesColor();
    series.setInvertIfNegative(true);
    series.getFormat().getFill().setFillType(FillType.Solid);
    series.getFormat().getFill().getSolidFillColor().setColor(seriesColor);
    series.getInvertedSolidFillColor().setColor(inverColor);
    
    pres.save("SetInvertFillColorChart_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Establecer serie para invertir cuando el valor es negativo**

Aspose.Slides le permite establecer la inversión mediante las propiedades `IChartDataPoint.InvertIfNegative` y `ChartDataPoint.InvertIfNegative`. Cuando se establece la inversión mediante estas propiedades, el punto de datos invierte sus colores al recibir un valor negativo. 

Este código Java demuestra la operación:
```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400, true);
    IChartSeriesCollection series = chart.getChartData().getSeries();
    chart.getChartData().getSeries().clear();

    IChartSeries chartSeries = series.add(chart.getChartData().getChartDataWorkbook().getCell(0, "B1"), chart.getType());
    chartSeries.getDataPoints().addDataPointForBarSeries(chart.getChartData().getChartDataWorkbook().getCell(0, "B2", -5));
    chartSeries.getDataPoints().addDataPointForBarSeries(chart.getChartData().getChartDataWorkbook().getCell(0, "B3", 3));
    chartSeries.getDataPoints().addDataPointForBarSeries(chart.getChartData().getChartDataWorkbook().getCell(0, "B4", -2));
    chartSeries.getDataPoints().addDataPointForBarSeries(chart.getChartData().getChartDataWorkbook().getCell(0, "B5", 1));

    chartSeries.setInvertIfNegative(false);

    chartSeries.getDataPoints().get_Item(2).setInvertIfNegative(true);

    pres.save("out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Borrar datos de puntos de datos específicos**

Aspose.Slides for Java le permite borrar los datos de `DataPoints` para una serie de gráfico específica de esta manera:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. Obtenga la referencia de una diapositiva a través de su índice.
3. Obtenga la referencia de un gráfico a través de su índice.
4. Recorra todos los `DataPoints` del gráfico y establezca `XValue` y `YValue` en null.
5. Borre todos los `DataPoints` de la serie de gráfico específica.
6. Guarde la presentación modificada en un archivo PPTX.

Este código Java demuestra la operación:
```java
Presentation pres = new Presentation("TestChart.pptx");
try {
    ISlide sl = pres.getSlides().get_Item(0);

    IChart chart = (IChart)sl.getShapes().get_Item(0);

    for (IChartDataPoint dataPoint : chart.getChartData().getSeries().get_Item(0).getDataPoints())
    {
        dataPoint.getXValue().getAsCell().setValue(null);
        dataPoint.getYValue().getAsCell().setValue(null);
    }

    chart.getChartData().getSeries().get_Item(0).getDataPoints().clear();

    pres.save("ClearSpecificChartSeriesDataPointsData.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Establecer ancho de la brecha de la serie**

Aspose.Slides for Java le permite establecer el ancho de la brecha de una serie mediante la propiedad **`GapWidth`** de esta manera:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
1. Acceda a la primera diapositiva.
1. Añada un gráfico con datos predeterminados.
1. Acceda a cualquier serie del gráfico.
1. Establezca la propiedad `GapWidth`.
1. Guarde la presentación modificada en un archivo PPTX.

Este código Java le muestra cómo establecer el ancho de la brecha de una serie:
```java
// Crea una presentación vacía 
Presentation pres = new Presentation();
try {
    // Accede a la primera diapositiva de la presentación
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Añade un gráfico con datos predeterminados
    IChart chart = slide.getShapes().addChart(ChartType.StackedColumn, 0, 0, 500, 500);
    
    // Establece el índice de la hoja de datos del gráfico
    int defaultWorksheetIndex = 0;
    
    // Obtiene la hoja de datos del gráfico
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();
    
    // Añade series
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.getType());
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 2, "Series 2"), chart.getType());
    
    // Añade categorías
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 3, 0, "Caetegoty 3"));
    
    // Obtiene la segunda serie del gráfico
    IChartSeries series = chart.getChartData().getSeries().get_Item(1);
    
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
    pres.save("GapWidth_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **FAQ**

**¿Existe un límite de cuántas series puede contener un único gráfico?**

Aspose.Slides no impone un límite fijo al número de series que añada. El techo práctico está determinado por la legibilidad del gráfico y por la memoria disponible para su aplicación.

**¿Qué pasa si las columnas dentro de un grupo están demasiado juntas o demasiado separadas?**

Ajuste la configuración `GapWidth` para esa serie (o su grupo de series principal). Incrementar el valor amplía el espacio entre columnas, mientras que disminuirlo las acerca más.