---
title: Administrar series de datos de gráficos en presentaciones en Android
linktitle: Series de datos
type: docs
url: /es/androidjava/chart-series/
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
- Android
- Java
- Aspose.Slides
description: "Aprenda a administrar series de gráficos en Android para PowerPoint (PPT/PPTX) con ejemplos prácticos de código Java y buenas prácticas para mejorar sus presentaciones de datos."
---

Una serie es una fila o columna de números representados en un gráfico.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **Establecer la superposición de series del gráfico**

Con el método [IChartSeries.getOverlap](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getOverlap--) puedes determinar cuánto deben superponerse las barras y columnas en un gráfico 2D (rango: -100 a 100). Esta propiedad se aplica a todas las series del grupo de series padre: es una proyección de la propiedad de grupo correspondiente. Por lo tanto, esta propiedad es de solo lectura.

Utiliza el método de escritura `getParentSeriesGroup().setOverlap()` para establecer el valor de superposición que prefieras.

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
1. Agregar un gráfico de columnas agrupadas en una diapositiva.
1. Acceder a la primera serie del gráfico.
1. Acceder al `ParentSeriesGroup` de la serie del gráfico y establecer el valor de superposición que prefieras para la serie.
1. Escribir la presentación modificada en un archivo PPTX.

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

    // Escribe el archivo de presentación en el disco
    pres.save("SetChartSeriesOverlap_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Cambiar el color de la serie**

Aspose.Slides for Android a través de Java le permite cambiar el color de una serie de la siguiente manera:

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
1. Agregar un gráfico en la diapositiva.
1. Acceder a la serie cuyo color deseas cambiar.
1. Establecer el tipo de relleno y el color de relleno que prefieras.
1. Guardar la presentación modificada.

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

Aspose.Slides for Android a través de Java le permite cambiar el color de la categoría de una serie de la siguiente manera:

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
1. Agregar un gráfico en la diapositiva.
1. Acceder a la categoría de la serie cuyo color deseas cambiar.
1. Establecer el tipo de relleno y el color de relleno que prefieras.
1. Guardar la presentación modificada.

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

Por defecto, los nombres de la leyenda de un gráfico son el contenido de las celdas sobre cada columna o fila de datos.

En nuestro ejemplo (imagen de muestra),

* las columnas son *Series 1, Series 2,* y *Series 3*;
* las filas son *Category 1, Category 2, Category 3,* y *Category 4.*

Aspose.Slides for Android a través de Java le permite actualizar o cambiar el nombre de una serie en los datos del gráfico y la leyenda.

Este código Java le muestra cómo cambiar el nombre de una serie en sus datos de gráfico `ChartDataWorkbook`:
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


Este código Java le muestra cómo cambiar el nombre de una serie en su leyenda a través de `Series`:
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


## **Establecer el color de relleno de la serie del gráfico**

Aspose.Slides for Android a través de Java le permite establecer el color de relleno automático para las series del gráfico dentro del área de trazado de la siguiente manera:

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
1. Obtener la referencia de una diapositiva por su índice.
1. Agregar un gráfico con datos predeterminados según el tipo que prefieras (en el ejemplo siguiente usamos `ChartType.ClusteredColumn`).
1. Acceder a la serie del gráfico y establecer el color de relleno a Automático.
1. Guardar la presentación en un archivo PPTX.

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

    // Escribe el archivo de presentación en el disco
    pres.save("AutoFillSeries_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Establecer color de relleno invertido para una serie del gráfico**

Aspose.Slides le permite establecer el color de relleno invertido para las series del gráfico dentro del área de trazado de la siguiente manera:

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
1. Obtener la referencia de una diapositiva por su índice.
1. Agregar un gráfico con datos predeterminados según el tipo que prefieras (en el ejemplo siguiente usamos `ChartType.ClusteredColumn`).
1. Acceder a la serie del gráfico y establecer el color de relleno a invertido.
1. Guardar la presentación en un archivo PPTX.

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

    // Toma la primera serie del gráfico y llena sus datos de serie.
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


## **Configurar una serie para invertir cuando el valor es negativo**

Aspose.Slides le permite establecer inversiones mediante las propiedades `IChartDataPoint.InvertIfNegative` y `ChartDataPoint.InvertIfNegative`. Cuando se establece una inversión usando estas propiedades, el punto de datos invierte sus colores al recibir un valor negativo.

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


## **Borrar datos de punto específico**

Aspose.Slides for Android a través de Java le permite borrar los datos `DataPoints` de una serie de gráfico específica de la siguiente manera:

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
2. Obtener la referencia de una diapositiva a través de su índice.
3. Obtener la referencia de un gráfico a través de su índice.
4. Recorrer todos los `DataPoints` del gráfico y establecer `XValue` y `YValue` a null.
5. Borrar todos`DataPoints` para la serie de gráfico específica.
6. Escribir la presentación modificada en un archivo PPTX.

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


## **Establecer el ancho del intervalo de la serie**

Aspose.Slides for Android a través de Java le permite establecer el Ancho del intervalo de una serie mediante la propiedad **`GapWidth`** de la siguiente manera:

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
1. Acceder a la primera diapositiva.
1. Agregar un gráfico con datos predeterminados.
1. Acceder a cualquier serie del gráfico.
1. Establecer la propiedad `GapWidth`.
1. Escribir la presentación modificada en un archivo PPTX.

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


## **Preguntas frecuentes**

**¿Existe un límite en la cantidad de series que puede contener un solo gráfico?**

Aspose.Slides no impone un límite fijo en la cantidad de series que puedes agregar. El techo práctico está determinado por la legibilidad del gráfico y por la memoria disponible para tu aplicación.

**¿Qué pasa si las columnas dentro de un grupo están demasiado juntas o demasiado separadas?**

Ajusta la configuración `GapWidth` para esa serie (o su grupo de series padre). Incrementar el valor ensancha el espacio entre columnas, mientras que disminuirlo las acerca más.