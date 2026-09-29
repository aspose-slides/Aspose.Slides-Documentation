---
title: Administrar series de datos de gráficos en presentaciones en Android
linktitle: Series de datos
type: docs
url: /es/androidjava/chart-series/
keywords:
- series de gráficos
- superposición de series
- color de series
- nombre de serie
- punto de datos
- celda del libro
- espacio de series
- valor negativo
- PowerPoint
- presentación
- Android
- Java
- Aspose.Slides
description: "Aprenda a administrar series de gráficos, puntos de datos, celdas de libro, formato, superposición, ancho de separación y valores negativos en presentaciones en Android."
---
## **Visión general**

Un gráfico almacena sus datos trazados en un libro de datos del gráfico. Un [IChartSeries](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ichartseries/) representa un conjunto de valores relacionados, y cada [IChartDataPoint](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ichartdatapoint/) en la serie se refiere a una o más celdas del libro. Los objetos [IChartCategory](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ichartcategory/) proporcionan las etiquetas o valores de agrupación compartidos por las series. Por lo tanto, el nombre de la serie, las categorías y los valores de los puntos están conectados a objetos [IChartDataCell](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ichartdatacell/) en lugar de almacenarse solo como texto de visualización.

Para un gráfico de categorías típico, el libro predeterminado utiliza la fila 0 para los nombres de series, la columna 0 para los nombres de categorías y las celdas restantes para los valores de las series. Los índices de hoja de cálculo, fila y columna que se pasan a [IChartDataWorkbook.getCell](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ichartdataworkbook/#getCell-int-int-int-) son base cero. Este diseño es útil cuando se crea un gráfico con datos predeterminados, pero no se debe asumir que todos los gráficos existentes lo utilizan. Para una presentación cargada, inspeccione las celdas referenciadas por las series, categorías y puntos de datos antes de cambiar los valores del libro.

Los ajustes del gráfico tienen tres ámbitos diferentes:

- Ajustes a nivel de serie, como [IChartSeries.getFormat](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ichartseries/#getFormat--), proporcionan la apariencia predeterminada para todos los puntos de una serie.
- Ajustes de punto de datos, como [IChartDataPoint.getFormat](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ichartdatapoint/#getFormat--), sobrescriben la apariencia de la serie para un punto.
- Los ajustes de grupo se aplican a series compatibles que pertenecen al mismo [IChartSeriesGroup](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ichartseriesgroup/). Acceda al grupo a través de [IChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ichartseries/#getParentSeriesGroup--) cuando necesite establecer opciones como superposición o ancho de separación.

Cuando no se define un relleno explícito para el punto o la serie, el estilo y el tema del gráfico determinan la apariencia automática. Cuando existen formatos tanto de serie como de punto, el formato del punto tiene precedencia para ese punto.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **Establecer la superposición de la serie del gráfico**

[IChartSeries.getOverlap](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ichartseries/#getOverlap--) informa cuánto se superponen las barras o columnas en un gráfico 2D, de -100 a 100 por ciento. Es una proyección de solo lectura del ajuste en el grupo de series padre. Utilice [IChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ichartseriesgroup/#setOverlap-byte-) para actualizar todas las series compatibles en ese grupo. Esta opción se aplica a los tipos de gráfico que muestran barras o columnas agrupadas; no afecta a los grupos de series no relacionados en un gráfico combinado.

El siguiente ejemplo establece la superposición para el grupo que contiene la primera serie:

```java
import com.aspose.slides.*;

final int firstSlideIndex = 0;
final int firstSeriesIndex = 0;
final byte overlapPercent = 30;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    // El nuevo gráfico contiene series, categorías y valores de muestra.
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    IChartSeries series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    series.getParentSeriesGroup().setOverlap(overlapPercent);

    presentation.save("series_overlap.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

El resultado:

![The series overlap](series_overlap.png)

## **Cambiar el color de relleno de la serie**

Utilice [IChartSeries.getFormat](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ichartseries/#getFormat--) para establecer el relleno predeterminado de una serie completa. Si un punto ya tiene un relleno explícito, su ajuste [IChartDataPoint.getFormat](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ichartdatapoint/#getFormat--) sobrescribe el relleno de la serie para ese punto.

El siguiente ejemplo aplica un relleno sólido azul a la primera serie:

```java
import com.aspose.slides.*;
import android.graphics.Color;

final int firstSlideIndex = 0;
final int firstSeriesIndex = 0;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    IChartSeries series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    series.getFormat().getFill().setFillType(FillType.Solid);
    series.getFormat().getFill().getSolidFillColor().setColor(Color.BLUE);

    presentation.save("series_color.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

El resultado:

![The color of the series](series_color.png)

## **Cambiar el nombre de la serie**

El nombre de una serie se almacena en el libro de datos del gráfico y normalmente se muestra en la leyenda. En el libro predeterminado creado para un gráfico de columnas agrupadas, la celda B1 está en la fila 0, columna 1 y contiene el nombre de la primera serie. Las constantes nombradas en el siguiente ejemplo hacen explícita esa estructura:

```java
import com.aspose.slides.*;

final int firstSlideIndex = 0;
final int worksheetIndex = 0;
final int seriesNameRowIndex = 0;
final int firstSeriesColumnIndex = 1;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    IChartDataCell seriesNameCell = workbook.getCell(worksheetIndex, seriesNameRowIndex, firstSeriesColumnIndex);
    seriesNameCell.setValue("Revenue");

    presentation.save("series_name.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

También puede actualizar la celda ya referenciada por [IChartSeries.getName](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ichartseries/#getName--). Este enfoque evita suponer una fila y columna particulares en un gráfico existente:

```java
import com.aspose.slides.*;

final int firstSlideIndex = 0;
final int firstSeriesIndex = 0;
final int firstNameCellIndex = 0;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    IChartSeries series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    IChartDataCell seriesNameCell = series.getName().getAsCells().get_Item(firstNameCellIndex);
    seriesNameCell.setValue("Revenue");

    presentation.save("series_name.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

El resultado:

![The series name](series_name.png)

## **Obtener el color automático de relleno de la serie**

[IChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ichartseries/#getAutomaticSeriesColor--) devuelve el color calculado a partir del índice de la serie y el estilo del gráfico como un entero ARGB de Android. Este es el color que se usa cuando el relleno de la serie no ha sido definido explícitamente. Llamar al método lee el color calculado; no asigna un nuevo relleno.

El siguiente ejemplo imprime el entero de color automático de cada serie predeterminada:

```java
import com.aspose.slides.*;

final int firstSlideIndex = 0;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    int seriesCount = chart.getChartData().getSeries().size();
    for (int seriesIndex = 0; seriesIndex < seriesCount; seriesIndex++) {
        IChartSeries series = chart.getChartData().getSeries().get_Item(seriesIndex);
        int automaticColor = series.getAutomaticSeriesColor();
        System.out.println("Series " + seriesIndex + ": " + automaticColor);
    }
} finally {
    presentation.dispose();
}
```

Los valores exactos dependen del estilo y el tema del gráfico.

## **Establecer color de relleno invertido para una serie del gráfico**

Para series de barras, columnas y burbujas, [IChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ichartseries/#setInvertIfNegative-boolean-) puede mostrar los valores negativos con un relleno diferente. Establezca el relleno regular de la serie a sólido, habilite la inversión y asigne el color de valor negativo mediante [IChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ichartseries/#getInvertedSolidFillColor--). Los números negativos permanecen sin cambios en el libro; solo su color de visualización cambia.

El siguiente ejemplo sustituye los datos predeterminados del gráfico por una serie. La fila 0 de la hoja contiene el nombre de la serie, la columna 0 contiene los nombres de categorías y la columna 1 contiene los valores:

```java
import com.aspose.slides.*;
import android.graphics.Color;

final int firstSlideIndex = 0;
final int worksheetIndex = 0;
final int headerRowIndex = 0;
final int categoryColumnIndex = 0;
final int firstSeriesColumnIndex = 1;
final int firstDataRowIndex = 1;

String[] categoryNames = { "Category 1", "Category 2", "Category 3" };
int[] seriesValues = { -20, 50, -30 };

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200);
    IChartData chartData = chart.getChartData();
    IChartDataWorkbook workbook = chartData.getChartDataWorkbook();

    chartData.getSeries().clear();
    chartData.getCategories().clear();

    IChartDataCell seriesNameCell = workbook.getCell(worksheetIndex, headerRowIndex, firstSeriesColumnIndex, "Series 1");
    int chartType = chart.getType();
    IChartSeries series = chartData.getSeries().add(seriesNameCell, chartType);

    for (int categoryIndex = 0; categoryIndex < categoryNames.length; categoryIndex++) {
        int dataRowIndex = firstDataRowIndex + categoryIndex;
        String categoryName = categoryNames[categoryIndex];
        int seriesValue = seriesValues[categoryIndex];

        IChartDataCell categoryCell = workbook.getCell(worksheetIndex, dataRowIndex, categoryColumnIndex, categoryName);
        chartData.getCategories().add(categoryCell);

        IChartDataCell valueCell = workbook.getCell(worksheetIndex, dataRowIndex, firstSeriesColumnIndex, seriesValue);
        series.getDataPoints().addDataPointForBarSeries(valueCell);
    }

    int automaticSeriesColor = series.getAutomaticSeriesColor();
    series.getFormat().getFill().setFillType(FillType.Solid);
    series.getFormat().getFill().getSolidFillColor().setColor(automaticSeriesColor);
    series.setInvertIfNegative(true);
    series.getInvertedSolidFillColor().setColor(Color.RED);

    presentation.save("inverted_solid_fill_color.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

El resultado:

![The inverted solid fill color](inverted_solid_fill_color.png)

Puede habilitar la inversión para un punto mediante [IChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ichartdatapoint/#setInvertIfNegative-boolean-). En el siguiente ejemplo, la inversión está desactivada para la serie y activada solo para el punto seleccionado. Al punto también se le asigna un valor negativo para que el efecto sea visible:

```java
import com.aspose.slides.*;
import android.graphics.Color;

final int firstSlideIndex = 0;
final int firstSeriesIndex = 0;
final int targetDataPointIndex = 2;
final int negativeValue = -30;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    IChartSeries series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    int automaticSeriesColor = series.getAutomaticSeriesColor();
    series.getFormat().getFill().setFillType(FillType.Solid);
    series.getFormat().getFill().getSolidFillColor().setColor(automaticSeriesColor);
    series.getInvertedSolidFillColor().setColor(Color.RED);
    series.setInvertIfNegative(false);

    IChartDataPoint dataPoint = series.getDataPoints().get_Item(targetDataPointIndex);
    dataPoint.getValue().getAsCell().setValue(negativeValue);
    dataPoint.setInvertIfNegative(true);

    presentation.save("data_point_invert_color_if_negative.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Borrar el valor de un punto de datos específico**

Para dejar un punto vacío sin eliminar los demás, establezca su celda subyacente en `null`. En un gráfico de columnas, el valor trazado está disponible mediante [IChartDataPoint.getValue](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ichartdatapoint/#getValue--). El punto de datos permanece en la misma posición de categoría, pero el gráfico trata su valor como vacío según la configuración de valores en blanco del gráfico.

El siguiente ejemplo borra solo el segundo punto de la primera serie:

```java
import com.aspose.slides.*;

final int firstSlideIndex = 0;
final int firstSeriesIndex = 0;
final int targetDataPointIndex = 1;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    IChartSeries series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    IChartDataPoint dataPoint = series.getDataPoints().get_Item(targetDataPointIndex);
    dataPoint.getValue().getAsCell().setValue(null);

    presentation.save("clear_data_point_value.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Los gráficos de dispersión utilizan celdas X e Y separadas, y los gráficos de burbujas también usan una celda de tamaño. Borre solo la celda que representa el valor que desea eliminar. No llame a [IChartDataPointCollection.clear](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ichartdatapointcollection/#clear--) cuando quiera conservar los demás puntos, porque ese método elimina todos los puntos de datos de la colección.

## **Controlar la visualización de celdas vacías**

Las celdas ocultas que contienen valores son un caso distinto de las celdas vacías. Para incluir o excluir datos de filas y columnas ocultas de la hoja, consulte [Include Data from Hidden Rows and Columns](/slides/es/androidjava/chart-workbook/#include-data-from-hidden-rows-and-columns).

Una celda de libro vacía representa datos ausentes; una celda que contiene `0` representa un valor numérico conocido. Llame a [IChartDataCell.setValue](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ichartdatacell/#setValue-java.lang.Object-) con `null` para dejarla vacía. Un cero numérico sigue siendo cero independientemente de la configuración de celdas en blanco.

Utilice [IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ichart/#setDisplayBlanksAs-int-) para elegir cómo el gráfico muestra las celdas vacías. Esta configuración se aplica a todo el gráfico. Cambia la forma en que se trazan los vacíos, sin rellenar la celda vacía del libro con cero o con un valor interpolado.

El siguiente ejemplo autónomo crea un gráfico de líneas con una serie, borra el valor del Día 3 y guarda el mismo gráfico con cada modo. No se requiere archivo de entrada. El [IChartDataWorkbook](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ichartdataworkbook/) usa la hoja 0, columna 0 para etiquetas de categoría y columna 1 para valores; la fila 0 contiene el nombre de la serie. Los datos finales son `10, 20, empty, 30, 40`.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 40, 40, 640, 400);
    IChartData chartData = chart.getChartData();
    IChartDataWorkbook workbook = chartData.getChartDataWorkbook();

    chartData.getSeries().clear();
    chartData.getCategories().clear();

    IChartDataCell seriesNameCell = workbook.getCell(0, 0, 1, "Measurements");
    IChartSeries series = chartData.getSeries().add(seriesNameCell, chart.getType());
    int[] values = { 10, 20, 25, 30, 40 };

    for (int i = 0; i < values.length; i++) {
        IChartDataCell categoryCell = workbook.getCell(0, i + 1, 0, "Day " + (i + 1));
        chartData.getCategories().add(categoryCell);
        IChartDataCell valueCell = workbook.getCell(0, i + 1, 1, values[i]);
        series.getDataPoints().addDataPointForLineSeries(valueCell);
    }

    // Dejar el Día 3 realmente vacío, manteniendo su categoría y punto de datos.
    workbook.getCell(0, 3, 1).setValue(null);

    int[] modes = { DisplayBlanksAsType.Gap, DisplayBlanksAsType.Zero, DisplayBlanksAsType.Span };
    String[] modeNames = { "Gap", "Zero", "Span" };
    for (int i = 0; i < modes.length; i++) {
        chart.setDisplayBlanksAs(modes[i]);
        presentation.save("empty_cells_" + modeNames[i] + ".pptx", SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

Cada archivo de salida almacena el modo asignado antes de guardar: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx` y `empty_cells_Span.pptx`. Para guardar solo una versión, asigne el modo deseado y guarde la presentación una sola vez en lugar de iterar sobre los modos.

La comparación a continuación muestra los mismos datos en los tres archivos. El Día 3 está vacío en el libro en todos los casos:

![Line charts with identical data: Gap breaks the line at Day 3, Zero drops the line to zero, and Span connects Day 2 to Day 4.](display_blanks_as.png)

El efecto visible depende del tipo de gráfico. Un gráfico de líneas permite comparar fácilmente los tres modos. Los gráficos de barras y columnas no tienen línea para conectar a través de una categoría ausente, por lo que `Span` no puede producir el segmento de conexión que se muestra arriba; una columna ausente y una columna de altura cero también pueden parecer iguales. De forma similar, un gráfico de dispersión solo con marcadores no tiene línea de conexión. No espere tres resultados distintos para cada tipo de gráfico; compruebe la salida para el tipo que use.

## **Establecer el ancho de separación de la serie**

El ancho de separación es el espacio entre grupos adyacentes de barras o columnas, expresado como un porcentaje del ancho de la barra o columna. Al igual que la superposición, pertenece al grupo de series padre y no a una sola serie. Llame a [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-) una vez para el grupo. Un valor mayor crea más espacio entre los grupos; un valor menor los hace más densos.

El siguiente ejemplo modifica el ancho de separación y guarda solo la presentación final:

```java
import com.aspose.slides.*;

final int firstSlideIndex = 0;
final int firstSeriesIndex = 0;
final int gapWidthPercent = 30;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    IChart chart = slide.getShapes().addChart(ChartType.StackedColumn, 20, 20, 500, 200);

    IChartSeries series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    series.getParentSeriesGroup().setGapWidth(gapWidthPercent);

    presentation.save("gap_width_30.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

El resultado:

![The gap width](gap_width.png)

## **FAQ**

**¿Qué tipos de gráfico admiten series de datos?**

Todos los tipos de gráfico representados por la enumeración [ChartType](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/charttype/) usan datos de gráfico, pero sus series no comparten la misma estructura de valores ni los mismos ajustes. Por ejemplo, los gráficos de categorías usan categorías y valores, los de dispersión usan valores X y Y, y los de burbujas añaden tamaños de burbuja. Utilice el método de creación de puntos de datos que coincida con el tipo de serie. Opciones como superposición y ancho de separación solo se aplican a grupos de barras o columnas compatibles.

**¿Qué es un grupo de series de gráfico?**

Un [IChartSeriesGroup](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ichartseriesgroup/) contiene series compatibles que comparten ajustes de trazado a nivel de grupo. Un gráfico combinado puede contener más de un grupo, por lo que cambiar el grupo alcanzado a través de una serie no necesariamente modifica todas las series del gráfico.

**¿Un gráfico recién creado contiene datos predeterminados?**

Sí. De forma predeterminada, [IShapeCollection.addChart](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ishapecollection/#addChart-int-float-float-float-float-) crea series, categorías y valores de muestra. Puede editar esas celdas o borrar tanto las colecciones de series como de categorías antes de agregar un conjunto de datos totalmente personalizado. También existe una sobrecarga que crea un gráfico sin datos predeterminados.

**¿Cómo se conectan los objetos del gráfico a las celdas del libro?**

Los nombres de series, etiquetas de categoría y valores de puntos de datos hacen referencia a celdas en un [IChartDataWorkbook](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ichartdataworkbook/). Cambiar una celda referenciada actualiza el elemento del gráfico correspondiente. Cuando construya datos personalizados, mantenga las filas de categorías y las filas de valores de serie alineadas para que cada punto se trace bajo la categoría prevista.

**¿Cómo borro un punto sin eliminar toda la serie?**

Establezca la celda de valor correspondiente a `null` para conservar la posición de categoría del punto como un punto vacío. Use [IChartDataPointCollection.clear](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ichartdatapointcollection/#clear--) solo cuando quiera eliminar todos los puntos de esa serie. Si también elimina categorías, actualice cada serie para que sus valores sigan alineados con la colección de categorías.

**¿Cómo se muestran los puntos vacíos?**

El resultado depende del tipo de gráfico y del valor configurado mediante [IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ichart/#setDisplayBlanksAs-int-). Los gráficos compatibles pueden mostrar los vacíos como huecos, como valores cero o conectando los puntos vecinos. Elija la configuración que mejor refleje el significado de los datos ausentes en su presentación. Consulte **Controlar la visualización de celdas vacías** para un ejemplo completo y una comparación visual.

**¿Cómo se formatean los valores negativos?**

Para series de barras, columnas y burbujas compatibles, llame a [IChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ichartseries/#setInvertIfNegative-boolean-) y establezca el color devuelto por [IChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ichartseries/#getInvertedSolidFillColor--). Puede anular el comportamiento para un punto individual con [IChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ichartdatapoint/#setInvertIfNegative-boolean-). Estos métodos afectan al formato, no a los valores numéricos almacenados.

**¿Qué formato prevalece cuando se formatea una serie y un punto?**

El formato explícito del punto de datos tiene prioridad para ese punto. Los demás puntos continúan usando el formato explícito de la serie o, cuando el formato de la serie no está definido, el estilo y tema automáticos del gráfico. Los ajustes de grupo, como superposición y ancho de separación, controlan el diseño y no sobrescriben el formato a nivel de punto.

**¿Existe un límite de series que puede contener un gráfico?**

Aspose.Slides no impone un límite fijo separado para el número de series. En la práctica, las limitaciones del archivo de presentación, la memoria disponible, el tiempo de renderizado y la legibilidad del gráfico determinan un límite útil.

**¿Qué debo ajustar cuando las columnas están demasiado juntas o demasiado separadas?**

Llame a [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-) en el grupo de series padre correspondiente. Aumente el valor para ampliar el espacio entre los grupos, o disminúyalo para acercarlos.