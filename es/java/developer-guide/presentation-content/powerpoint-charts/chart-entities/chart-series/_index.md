---
title: Gestionar series de datos de gráficos en presentaciones con Java
linktitle: Series de datos
type: docs
url: /es/java/chart-series/
keywords:
- series de gráficos
- superposición de series
- color de series
- nombre de serie
- punto de datos
- celda del libro
- separación de series
- valor negativo
- PowerPoint
- presentación
- Java
- Aspose.Slides
description: "Aprenda a gestionar series de gráficos, puntos de datos, celdas del libro, formato, superposición, ancho del espacio y valores negativos en presentaciones con Java."
---
## **Descripción general**

Un gráfico almacena sus datos trazados en un libro de datos del gráfico. Un [IChartSeries](https://reference.aspose.com/slides/es/java/com.aspose.slides/ichartseries/) representa un conjunto de valores relacionados, y cada [IChartDataPoint](https://reference.aspose.com/slides/es/java/com.aspose.slides/ichartdatapoint/) de la serie se refiere a una o más celdas del libro. Los objetos [IChartCategory](https://reference.aspose.com/slides/es/java/com.aspose.slides/ichartcategory/) proporcionan las etiquetas o valores de agrupación compartidos por las series. Por lo tanto, el nombre de la serie, las categorías y los valores de los puntos están conectados a objetos [IChartDataCell](https://reference.aspose.com/slides/es/java/com.aspose.slides/ichartdatacell/) en lugar de almacenarse solo como texto visible.

Para un gráfico de categorías típico, el libro predeterminado utiliza la fila 0 para los nombres de las series, la columna 0 para los nombres de las categorías y el resto de las celdas para los valores de las series. Los índices de hoja, fila y columna que se pasan a [IChartDataWorkbook.getCell](https://reference.aspose.com/slides/es/java/com.aspose.slides/ichartdataworkbook/#getCell-int-int-int-) son basados en cero. Esta disposición es útil cuando crea un gráfico con datos predeterminados, pero no asuma que todos los gráficos existentes la utilizan. En una presentación cargada, inspeccione las celdas a las que hacen referencia las series, categorías y puntos de datos antes de cambiar los valores del libro.

Los ajustes del gráfico tienen tres ámbitos diferentes:

- Ajustes a nivel de serie, como [IChartSeries.getFormat](https://reference.aspose.com/slides/es/java/com.aspose.slides/ichartseries/#getFormat--), proporcionan la apariencia predeterminada para todos los puntos de una serie.
- Ajustes de punto de datos, como [IChartDataPoint.getFormat](https://reference.aspose.com/slides/es/java/com.aspose.slides/ichartdatapoint/#getFormat--), sobrescriben la apariencia de la serie para un punto.
- Los ajustes de grupo se aplican a series compatibles que pertenecen al mismo [IChartSeriesGroup](https://reference.aspose.com/slides/es/java/com.aspose.slides/ichartseriesgroup/). Acceda al grupo mediante [IChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/es/java/com.aspose.slides/ichartseries/#getParentSeriesGroup--) cuando necesite establecer opciones como superposición u anchura del espacio.

Cuando no se establece un relleno explícito de punto o de serie, el estilo y el tema del gráfico determinan la apariencia automática. Cuando existen tanto el formato de la serie como el del punto, el formato del punto tiene prioridad para ese punto.

![serie del gráfico PowerPoint](chart-series-powerpoint.png)

## **Establecer la superposición de la serie del gráfico**

[IChartSeries.getOverlap](https://reference.aspose.com/slides/es/java/com.aspose.slides/ichartseries/#getOverlap--) informa cuánto se superponen las barras o columnas en un gráfico 2D, de -100 a 100 por ciento. Es una proyección de solo lectura de la configuración en el grupo de series padre. Use [IChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/es/java/com.aspose.slides/ichartseriesgroup/#setOverlap-byte-) para actualizar todas las series compatibles en ese grupo. Esta opción se aplica a los tipos de gráfico que muestran barras o columnas agrupadas; no afecta a los grupos de series no relacionados en un gráfico combinado.

El siguiente ejemplo establece la superposición para el grupo que contiene la primera serie:

```java
import com.aspose.slides.*;

final int firstSlideIndex = 0;
final int firstSeriesIndex = 0;
final byte overlapPercent = 30;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    // El nuevo gráfico contiene series de muestra, categorías y valores.
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    IChartSeries series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    series.getParentSeriesGroup().setOverlap(overlapPercent);

    presentation.save("series_overlap.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

El resultado:

![Superposición de la serie](series_overlap.png)

## **Cambiar el color de relleno de la serie**

Use [IChartSeries.getFormat](https://reference.aspose.com/slides/es/java/com.aspose.slides/ichartseries/#getFormat--) para establecer el relleno predeterminado de una serie completa. Si un punto ya tiene un relleno explícito, su ajuste [IChartDataPoint.getFormat](https://reference.aspose.com/slides/es/java/com.aspose.slides/ichartdatapoint/#getFormat--) sobrescribe el relleno de la serie para ese punto.

El siguiente ejemplo aplica un relleno sólido azul a la primera serie:

```java
import com.aspose.slides.*;
import java.awt.Color;

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

![El color de la serie](series_color.png)

## **Cambiar el nombre de la serie**

El nombre de una serie se almacena en el libro de datos del gráfico y normalmente se muestra en la leyenda. En el libro predeterminado creado para un gráfico de columnas agrupadas, la celda B1 está en la fila 0, columna 1 y contiene el nombre de la primera serie. Las constantes con nombre en el siguiente ejemplo hacen explícita esa estructura:

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

También puede actualizar la celda ya referenciada por [IChartSeries.getName](https://reference.aspose.com/slides/es/java/com.aspose.slides/ichartseries/#getName--). Este enfoque evita asumir una fila y columna particulares en un gráfico existente:

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

![El nombre de la serie](series_name.png)

## **Obtener el color automático de relleno de la serie**

[IChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/es/java/com.aspose.slides/ichartseries/#getAutomaticSeriesColor--) devuelve el color calculado a partir del índice de la serie y del estilo del gráfico. Este es el color usado cuando el relleno de la serie no ha sido definido explícitamente. Llamar al método lee el color calculado; no asigna un nuevo relleno.

El siguiente ejemplo imprime el color automático de cada serie predeterminada:

```java
import com.aspose.slides.*;
import java.awt.Color;

final int firstSlideIndex = 0;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    int seriesCount = chart.getChartData().getSeries().size();
    for (int seriesIndex = 0; seriesIndex < seriesCount; seriesIndex++) {
        IChartSeries series = chart.getChartData().getSeries().get_Item(seriesIndex);
        Color automaticColor = series.getAutomaticSeriesColor();
        System.out.println("Series " + seriesIndex + ": " + automaticColor);
    }
} finally {
    presentation.dispose();
}
```

Salida de ejemplo para el estilo de gráfico predeterminado:

```text
Series 0: java.awt.Color[r=79,g=129,b=189]
Series 1: java.awt.Color[r=192,g=80,b=77]
Series 2: java.awt.Color[r=155,g=187,b=89]
```

Los colores exactos dependen del estilo y el tema del gráfico.

## **Establecer el color de relleno invertido para una serie de gráfico**

Para series de barras, columnas y burbujas, [IChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/es/java/com.aspose.slides/ichartseries/#setInvertIfNegative-boolean-) puede mostrar valores negativos con un relleno diferente. Establezca el relleno regular de la serie como sólido, habilite la inversión y asigne el color de valor negativo mediante [IChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/es/java/com.aspose.slides/ichartseries/#getInvertedSolidFillColor--). Los números negativos permanecen sin cambios en el libro; solo cambia su color de visualización.

El siguiente ejemplo sustituye los datos predeterminados del gráfico por una serie. La fila 0 de la hoja contiene el nombre de la serie, la columna 0 contiene los nombres de las categorías y la columna 1 contiene los valores:

```java
import com.aspose.slides.*;
import java.awt.Color;

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

    Color automaticSeriesColor = series.getAutomaticSeriesColor();
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

![El color de relleno sólido invertido](inverted_solid_fill_color.png)

Puede habilitar la inversión para un punto mediante [IChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/es/java/com.aspose.slides/ichartdatapoint/#setInvertIfNegative-boolean-). En el siguiente ejemplo, la inversión está deshabilitada para la serie y habilitada solo para el punto seleccionado. Al punto también se le asigna un valor negativo para que el efecto sea visible:

```java
import com.aspose.slides.*;
import java.awt.Color;

final int firstSlideIndex = 0;
final int firstSeriesIndex = 0;
final int targetDataPointIndex = 2;
final int negativeValue = -30;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    IChartSeries series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    Color automaticSeriesColor = series.getAutomaticSeriesColor();
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

Para dejar un punto vacío sin eliminar los demás puntos, establezca su celda subyacente del libro en `null`. En un gráfico de columnas, el valor trazado está disponible mediante [IChartDataPoint.getValue](https://reference.aspose.com/slides/es/java/com.aspose.slides/ichartdatapoint/#getValue--). El punto de datos permanece en la misma posición de categoría, pero el gráfico trata su valor como vacío según la configuración de valores en blanco del gráfico.

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

Los gráficos de dispersión utilizan celdas X e Y separadas, y los gráficos de burbujas también usan una celda de tamaño. Borre solo la celda que representa el valor que desea eliminar. No llame a [IChartDataPointCollection.clear](https://reference.aspose.com/slides/es/java/com.aspose.slides/ichartdatapointcollection/#clear--) cuando quiera conservar los demás puntos, porque ese método elimina todos los puntos de datos de la colección.

## **Controlar la visualización de celdas vacías**

Una celda del libro vacía representa datos faltantes; una celda que contiene `0` representa un valor numérico conocido. Llame a [IChartDataCell.setValue](https://reference.aspose.com/slides/es/java/com.aspose.slides/ichartdatacell/#setValue-java.lang.Object-) con `null` para dejar una celda vacía. Un cero numérico sigue siendo cero independientemente de la configuración de celdas en blanco.

Utilice [IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/es/java/com.aspose.slides/ichart/#setDisplayBlanksAs-int-) para elegir cómo el gráfico muestra las celdas vacías. Esta configuración se aplica a todo el gráfico. Cambia la forma en que se trazan los vacíos, sin rellenar la celda vacía del libro con cero o con un valor interpolado.

El siguiente ejemplo autónomo crea un gráfico de líneas con una serie, borra el valor del Día 3 y guarda el mismo gráfico con cada modo. No se requiere archivo de entrada. El [IChartDataWorkbook](https://reference.aspose.com/slides/es/java/com.aspose.slides/ichartdataworkbook/) usa la hoja 0, la columna 0 para las etiquetas de categoría y la columna 1 para los valores; la fila 0 contiene el nombre de la serie. Los datos finales son `10, 20, empty, 30, 40`.

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

![Gráficos de líneas con datos idénticos: Gap interrumpe la línea en el Día 3, Zero baja la línea a cero y Span conecta el Día 2 con el Día 4.](display_blanks_as.png)

El efecto visible depende del tipo de gráfico. Un gráfico de líneas facilita la comparación de los tres modos. Los gráficos de barras y columnas no tienen línea que conectar a través de una categoría faltante, por lo que `Span` no puede producir el segmento de conexión mostrado arriba; una columna faltante y una columna de altura cero también pueden parecer iguales. De manera similar, un gráfico de dispersión solo con marcadores no tiene línea de conexión. No espere tres resultados diferentes para cada tipo de gráfico; verifique la salida para el tipo que utilice.

## **Establecer la anchura del espacio entre series**

La anchura del espacio es el espacio entre clústeres de barras o columnas adyacentes, expresado como porcentaje del ancho de la barra o columna. Al igual que la superposición, pertenece al grupo de series padre y no a una sola serie. Llame a [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/es/java/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-) una vez para el grupo. Un valor mayor crea más espacio entre clústeres; un valor menor los hace más densos.

El siguiente ejemplo cambia la anchura del espacio y guarda solo la presentación final:

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

![La anchura del espacio](gap_width.png)

## **Preguntas frecuentes**

**¿Qué tipos de gráfico admiten series de datos?**

Todos los tipos de gráfico representados por la enumeración [ChartType](https://reference.aspose.com/slides/es/java/com.aspose.slides/charttype/) utilizan datos de gráfico, pero sus series no comparten la misma estructura de valores ni los mismos ajustes. Por ejemplo, los gráficos de categorías usan categorías y valores, los gráficos de dispersión utilizan valores X y Y, y los gráficos de burbujas añaden tamaños de burbuja. Utilice el método de creación de puntos de datos que coincida con el tipo de serie. Opciones como superposición y anchura del espacio solo se aplican a grupos de barras o columnas compatibles.

**¿Qué es un grupo de series de gráfico?**

Un [IChartSeriesGroup](https://reference.aspose.com/slides/es/java/com.aspose.slides/ichartseriesgroup/) contiene series compatibles que comparten ajustes de trazado a nivel de grupo. Un gráfico combinado puede contener más de un grupo, por lo que cambiar el grupo al que se accede mediante una serie no necesariamente modifica todas las series del gráfico.

**¿Un gráfico recién creado contiene datos predeterminados?**

Sí. Por defecto, [IShapeCollection.addChart](https://reference.aspose.com/slides/es/java/com.aspose.slides/ishapecollection/#addChart-int-float-float-float-float-) crea series, categorías y valores de muestra. Puede editar esas celdas o vaciar tanto las colecciones de series como de categorías antes de añadir un conjunto de datos completamente personalizado. También existe una sobrecarga que puede crear un gráfico sin datos predeterminados.

**¿Cómo están conectados los objetos del gráfico a las celdas del libro?**

Los nombres de las series, las etiquetas de categorías y los valores de los puntos de datos hacen referencia a celdas en un [IChartDataWorkbook](https://reference.aspose.com/slides/es/java/com.aspose.slides/ichartdataworkbook/). Cambiar una celda referenciada actualiza el elemento correspondiente del gráfico. Cuando construya datos personalizados, mantenga alineadas las filas de categorías y las filas de valores de series para que cada punto se trace bajo la categoría prevista.

**¿Cómo borrar un punto en lugar de toda la serie?**

Establezca la celda de valor correspondiente en `null` para mantener la posición de categoría del punto como un punto vacío. Use [IChartDataPointCollection.clear](https://reference.aspose.com/slides/es/java/com.aspose.slides/ichartdatapointcollection/#clear--) solo cuando tenga la intención de eliminar todos los puntos de esa serie. Si también elimina categorías, actualice todas las series para que sus valores sigan alineados con la colección de categorías.

**¿Cómo se muestran los puntos vacíos?**

El resultado depende del tipo de gráfico y del valor configurado mediante [IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/es/java/com.aspose.slides/ichart/#setDisplayBlanksAs-int-). Los gráficos compatibles pueden mostrar los vacíos como huecos, como valores cero o conectando los puntos vecinos. Elija la configuración que se ajuste al significado de los datos faltantes en su presentación. Consulte [Controlar la visualización de celdas vacías](#control-the-display-of-empty-cells) para obtener un ejemplo completo y una comparación visual.

**¿Cómo se formatean los valores negativos?**

Para series de barras, columnas y burbujas compatibles, llame a [IChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/es/java/com.aspose.slides/ichartseries/#setInvertIfNegative-boolean-) y establezca el color devuelto por [IChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/es/java/com.aspose.slides/ichartseries/#getInvertedSolidFillColor--). Puede sobrescribir el comportamiento para un punto individual con [IChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/es/java/com.aspose.slides/ichartdatapoint/#setInvertIfNegative-boolean-). Estos métodos afectan al formato, no a los valores numéricos almacenados.

**¿Qué formato prevalece cuando tanto una serie como un punto están formateados?**

El formateo explícito del punto de datos tiene prioridad para ese punto. Los demás puntos continúan usando el formato explícito de la serie o, cuando el formato de la serie no está definido, el estilo y tema automático del gráfico. Los ajustes de grupo, como superposición y anchura del espacio, controlan la disposición y no son sobrescrituras de formato a nivel de punto.

**¿Existe un límite de cuántas series puede contener un gráfico?**

Aspose.Slides no impone un límite fijo separado de número de series. En la práctica, las limitaciones del archivo de presentación, la memoria disponible, el tiempo de renderizado y la legibilidad del gráfico determinan un límite razonable.

**¿Qué debo cambiar cuando las columnas están demasiado juntas o demasiado separadas?**

Llame a [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/es/java/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-) en el grupo de series padre correspondiente. Aumente el valor para ensanchar el espacio entre clústeres, o disminúyalo para acercar los clústeres.