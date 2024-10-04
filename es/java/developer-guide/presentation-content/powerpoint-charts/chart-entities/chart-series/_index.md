---
title: Series de Gráficos
type: docs
url: /java/chart-series/
keywords: "Series de gráficos, color de serie, presentación de PowerPoint, Java, Aspose.Slides para Java"
description: "Series de gráficos en presentaciones de PowerPoint en Java"
---

Una serie es una fila o columna de números trazados en un gráfico.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **Establecer superposición de series de gráficos**

Con la propiedad [IChartSeriesOverlap](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/properties/overlap), puedes especificar cuánto deben superponerse las barras y columnas en un gráfico 2D (rango: -100 a 100). Esta propiedad se aplica a todas las series del grupo de series principal: esto es una proyección de la propiedad del grupo correspondiente. Por lo tanto, esta propiedad es de solo lectura.

Utiliza la propiedad de lectura/escritura `ParentSeriesGroup.Overlap` para establecer tu valor preferido para `Overlap`.

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
1. Agrega un gráfico de columnas agrupadas en una diapositiva.
1. Accede a la primera serie de gráficos.
1. Accede al `ParentSeriesGroup` de la serie de gráficos y establece tu valor de superposición preferido para la serie.
1. Escribe la presentación modificada en un archivo PPTX.

Este código Java te muestra cómo establecer la superposición para una serie de gráficos:

```java
Presentation pres = new Presentation();
try {
    // Agrega el gráfico
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400, true);
    IChartSeriesCollection series = chart.getChartData().getSeries();
    if (series.get_Item(0).getOverlap() == 0)
    {
        // Establece la superposición de la serie
        series.get_Item(0).getParentSeriesGroup().setOverlap((byte)-30);
    }

    // Escribe el archivo de presentación en disco
    pres.save("SetChartSeriesOverlap_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Cambiar el color de la serie**
Aspose.Slides para Java te permite cambiar el color de una serie de la siguiente manera:

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
1. Agrega un gráfico en la diapositiva.
1. Accede a la serie cuyo color deseas cambiar.
1. Establece tu tipo de relleno y color de relleno preferidos.
1. Guarda la presentación modificada.

Este código Java te muestra cómo cambiar el color de una serie:

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

## **Cambiar el color de la categoría de la serie**
Aspose.Slides para Java te permite cambiar el color de la categoría de la serie de la siguiente manera:

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
1. Agrega un gráfico en la diapositiva.
1. Accede a la categoría de la serie cuyo color deseas cambiar.
1. Establece tu tipo de relleno y color de relleno preferidos.
1. Guarda la presentación modificada.

Este código en Java te muestra cómo cambiar el color de la categoría de una serie:

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

## **Cambiar el nombre de la serie** 

Por defecto, los nombres de la leyenda para un gráfico son los contenidos de las celdas sobre cada columna o fila de datos.

En nuestro ejemplo (imagen de muestra),

* las columnas son *Serie 1, Serie 2,* y *Serie 3*;
* las filas son *Categoría 1, Categoría 2, Categoría 3,* y *Categoría 4.* 

Aspose.Slides para Java te permite actualizar o cambiar el nombre de una serie en sus datos de gráfico y leyenda. 

Este código Java te muestra cómo cambiar el nombre de una serie en los datos de su gráfico `ChartDataWorkbook`:

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Column3D, 50, 50, 600, 400, true);

    IChartDataCell seriesCell = chart.getChartData().getChartDataWorkbook().getCell(0, 0, 1);
    seriesCell.setValue("Nuevo nombre");

    pres.save("pres.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

Este código Java te muestra cómo cambiar el nombre de una serie en su leyenda a través de `Series`:

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Column3D, 50, 50, 600, 400, true);
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);

    IStringChartValue name = series.getName();
    name.getAsCells().get_Item(0).setValue("Nuevo nombre");
} finally {
    if (pres != null) pres.dispose();
}
```

## **Establecer el color de relleno de la serie**

Aspose.Slides para Java te permite establecer el color de relleno automático para las series de gráficos dentro de un área de trazado de la siguiente manera:

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
1. Obtén una referencia de la diapositiva a través de su índice.
1. Agrega un gráfico con datos predeterminados basado en tu tipo preferido (en el ejemplo a continuación, usamos `ChartType.ClusteredColumn`).
1. Accede a la serie de gráficos y establece el color de relleno en automático.
1. Guarda la presentación en un archivo PPTX.

Este código Java te muestra cómo establecer el color de relleno automático para una serie de gráficos:

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

## **Establecer el color de relleno invertido de la serie**
Aspose.Slides te permite establecer el color de relleno invertido para las series de gráficos dentro de un área de trazado de la siguiente manera:

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
1. Obtén una referencia de la diapositiva a través de su índice.
1. Agrega un gráfico con datos predeterminados basado en tu tipo preferido (en el ejemplo a continuación, usamos `ChartType.ClusteredColumn`).
1. Accede a la serie de gráficos y establece el color de relleno en invertido.
1. Guarda la presentación en un archivo PPTX.

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
    chart.getChartData().getSeries().add(workBook.getCell(0, 0, 1, "Serie 1"), chart.getType());
    chart.getChartData().getCategories().add(workBook.getCell(0, 1, 0, "Categoría 1"));
    chart.getChartData().getCategories().add(workBook.getCell(0, 2, 0, "Categoría 2"));
    chart.getChartData().getCategories().add(workBook.getCell(0, 3, 0, "Categoría 3"));

    // Toma la primera serie de gráficos y populada sus datos de serie.
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

## **Establecer la serie para invertir cuando el valor es negativo**
Aspose.Slides te permite establecer inversiones a través de las propiedades `IChartDataPoint.InvertIfNegative` y `ChartDataPoint.InvertIfNegative`. Cuando se establece una inversión usando las propiedades, el punto de datos invierte sus colores cuando obtiene un valor negativo. 

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

## **Limpiar los datos de puntos específicos**
Aspose.Slides para Java te permite limpiar los datos de `DataPoints` para una serie de gráficos específica de la siguiente manera:

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. Obtén la referencia de una diapositiva a través de su índice.
3. Obtén la referencia de un gráfico a través de su índice.
4. Itera a través de todos los `DataPoints` del gráfico y establece `XValue` y `YValue` en nulo.
5. Limpia todos los `DataPoints` para una serie de gráficos específica.
6. Escribe la presentación modificada en un archivo PPTX.

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

## **Establecer el ancho de separación de la serie**
Aspose.Slides para Java te permite establecer el ancho de separación de una serie a través de la propiedad **`GapWidth`** de la siguiente manera:

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. Accede a la primera diapositiva.
3. Agrega un gráfico con datos predeterminados.
4. Accede a cualquier serie de gráficos.
5. Establece la propiedad `GapWidth`.
6. Escribe la presentación modificada en un archivo PPTX.

Este código en Java te muestra cómo establecer el ancho de separación de una serie:

```java
// Crea una presentación vacía 
Presentation pres = new Presentation();
try {
    // Accede a la primera diapositiva de la presentación
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Agrega un gráfico con datos predeterminados
    IChart chart = slide.getShapes().addChart(ChartType.StackedColumn, 0, 0, 500, 500);
    
    // Establece el índice de la hoja de datos del gráfico
    int defaultWorksheetIndex = 0;
    
    // Obtiene la hoja de datos del gráfico
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();
    
    // Agrega series
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 1, "Serie 1"), chart.getType());
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 2, "Serie 2"), chart.getType());
    
    // Agrega categorías
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 1, 0, "Categoría 1"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 2, 0, "Categoría 2"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 3, 0, "Categoría 3"));
    
    // Toma la segunda serie de gráficos
    IChartSeries series = chart.getChartData().getSeries().get_Item(1);
    
    // Pobla los datos de la serie
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