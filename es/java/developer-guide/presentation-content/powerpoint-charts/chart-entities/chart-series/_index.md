---
title: Administrar series de datos de gráficos en presentaciones usando Java
linktitle: Series de datos
type: docs
url: /es/java/chart-series/
keywords:
- series de gráfico
- superposición de series
- color de serie
- color de categoría
- nombre de serie
- punto de datos
- separación de series
- PowerPoint
- presentación
- Java
- Aspose.Slides
description: "Aprenda a gestionar series de gráficos en Java para PowerPoint (PPT/PPTX) con ejemplos de código prácticos y buenas prácticas para mejorar sus presentaciones de datos."
---

Una serie es una fila o columna de números graficados en un chart.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **Establecer la superposición de la serie del chart**

Con la propiedad [IChartSeriesOverlap](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/properties/overlap) puedes especificar cuánto deben superponerse las barras y columnas en un chart 2D (rango: -100 a 100). Esta propiedad se aplica a todas las series del grupo de series principal: es una proyección de la propiedad de grupo correspondiente. Por lo tanto, esta propiedad es de solo lectura. 

Usa la propiedad de lectura/escritura `ParentSeriesGroup.Overlap` para establecer el valor que prefieras para `Overlap`. 

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
1. Añade un chart de columnas agrupadas en una diapositiva.
1. Accede a la primera serie del chart.
1. Accede al `ParentSeriesGroup` de la serie del chart y establece el valor de superposición que prefieras para la serie. 
1. Escribe la presentación modificada a un archivo PPTX.

Este código Java muestra cómo establecer la superposición para una serie del chart:
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
Aspose.Slides for Java te permite cambiar el color de una serie de la siguiente manera:

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
1. Añade un chart en la diapositiva.
1. Accede a la serie cuyo color deseas cambiar. 
1. Establece el tipo de relleno y el color de relleno que prefieras.
1. Guarda la presentación modificada.

Este código Java muestra cómo cambiar el color de una serie:
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
Aspose.Slides for Java te permite cambiar el color de una categoría de serie de la siguiente manera:

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
1. Añade un chart en la diapositiva.
1. Accede a la categoría de la serie cuyo color deseas cambiar.
1. Establece el tipo de relleno y el color de relleno que prefieras.
1. Guarda la presentación modificada.

Este código Java muestra cómo cambiar el color de una categoría de serie:
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

Por defecto, los nombres de la leyenda de un chart son el contenido de las celdas sobre cada columna o fila de datos. 

En nuestro ejemplo (imagen de muestra), 

* las columnas son *Series 1, Series 2,* y *Series 3*;
* las filas son *Category 1, Category 2, Category 3,* y *Category 4.* 

Aspose.Slides for Java te permite actualizar o cambiar el nombre de una serie en sus datos de chart y en la leyenda. 

Este código Java muestra cómo cambiar el nombre de una serie en su `ChartDataWorkbook` de datos del chart:
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


Este código Java muestra cómo cambiar el nombre de una serie en su leyenda a través de `Series`:
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


## **Establecer el color de relleno de la serie del chart**

Aspose.Slides for Java te permite establecer el color de relleno automático para series de chart dentro del área de trazado de la siguiente manera:

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
1. Obtén una referencia a una diapositiva por su índice.
1. Añade un chart con datos predeterminados según el tipo que prefieras (en el ejemplo siguiente, usamos `ChartType.ClusteredColumn`).
1. Accede a la serie del chart y establece el color de relleno en Automatic.
1. Guarda la presentación en un archivo PPTX.

Este código Java muestra cómo establecer el color de relleno automático para una serie de chart:
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


## **Establecer el color de relleno invertido para una serie de chart**
Aspose.Slides te permite establecer el color de relleno invertido para series de chart dentro del área de trazado de la siguiente manera:

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
1. Obtén una referencia a una diapositiva por su índice.
1. Añade un chart con datos predeterminados según el tipo que prefieras (en el ejemplo siguiente, usamos `ChartType.ClusteredColumn`).
1. Accede a la serie del chart y establece el color de relleno en invert.
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
    chart.getChartData().getSeries().add(workBook.getCell(0, 0, 1, "Series 1"), chart.getType());
    chart.getChartData().getCategories().add(workBook.getCell(0, 1, 0, "Category 1"));
    chart.getChartData().getCategories().add(workBook.getCell(0, 2, 0, "Category 2"));
    chart.getChartData().getCategories().add(workBook.getCell(0, 3, 0, "Category 3"));

    // Toma la primera serie del gráfico y rellena sus datos de serie.
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



## **Establecer una serie para invertir cuando el valor es negativo**
Aspose.Slides permite establecer inversiones mediante las propiedades IChartDataPoint.InvertIfNegative y ChartDataPoint.InvertIfNegative. Cuando se establece una inversión mediante estas propiedades, el punto de datos invierte sus colores al recibir un valor negativo. 

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
Aspose.Slides for Java te permite borrar los datos de `DataPoints` para una serie de chart específica de la siguiente manera:

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. Obtén la referencia de una diapositiva mediante su índice.
3. Obtén la referencia de un chart mediante su índice.
4. Recorre todos los `DataPoints` del chart y establece `XValue` y `YValue` a null.
5. Borra todos los `DataPoints` de la serie de chart específica.
6. Escribe la presentación modificada a un archivo PPTX.

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
Aspose.Slides for Java te permite establecer el ancho de separación (`GapWidth`) de una serie de la siguiente manera:

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
1. Accede a la primera diapositiva.
1. Añade un chart con datos predeterminados.
1. Accede a cualquier serie del chart.
1. Establece la propiedad `GapWidth`.
1. Escribe la presentación modificada a un archivo PPTX.

Este código Java muestra cómo establecer el ancho de separación de una serie:
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
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.getType());
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 2, "Series 2"), chart.getType());
    
    // Agrega categorías
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
    
    // Establece el valor GapWidth
    series.getParentSeriesGroup().setGapWidth(50);
    
    // Guarda la presentación en disco
    pres.save("GapWidth_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Preguntas frecuentes**

**¿Existe un límite en la cantidad de series que puede contener un solo chart?**

Aspose.Slides no impone un límite fijo al número de series que agregas. El techo práctico está determinado por la legibilidad del chart y por la memoria disponible para tu aplicación.

**¿Qué ocurre si las columnas dentro de un grupo están demasiado juntas o demasiado separadas?**

Ajusta la configuración `GapWidth` para esa serie (o su grupo de series principal). Incrementar el valor amplía el espacio entre columnas, mientras que disminuirlo las acerca más.