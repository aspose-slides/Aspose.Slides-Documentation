---
title: Gestionar series de datos de gráfico en presentaciones en Java
linktitle: Series de datos
type: docs
url: /es/java/chart-series/
keywords:
- series de gráfico
- superposición de series
- color de series
- nombre de series
- punto de datos
- celda del libro de trabajo
- espacio entre series
- valor negativo
- PowerPoint
- presentación
- Java
- Aspose.Slides
description: "Aprenda cómo gestionar series de gráficos, puntos de datos, celdas del libro de trabajo, formato, superposición, ancho del espacio y valores negativos en presentaciones con Java."
---
## **Visión general**

Un gráfico almacena sus datos trazados en un libro de datos del gráfico. Un [IChartSeries](https://reference.aspose.com/slides/es/java/com.aspose.slides/ichartseries/) representa un conjunto de valores relacionados, y cada [IChartDataPoint](https://reference.aspose.com/slides/es/java/com.aspose.slides/ichartdatapoint/) de la serie hace referencia a una o más celdas del libro. Los objetos [IChartCategory](https://reference.aspose.com/slides/es/java/com.aspose.slides/ichartcategory/) proporcionan las etiquetas o valores de agrupación compartidos por las series. Por lo tanto, el nombre de la serie, las categorías y los valores de los puntos están conectados a objetos [IChartDataCell](https://reference.aspose.com/slides/es/java/com.aspose.slides/ichartdatacell/) en lugar de almacenarse solo como texto visible.

Para un gráfico de categoría típico, el libro predeterminado usa la fila 0 para los nombres de las series, la columna 0 para los nombres de las categorías y el resto de celdas para los valores de las series. Los índices de hoja, fila y columna que se pasan a [IChartDataWorkbook.getCell](https://reference.aspose.com/slides/es/java/com.aspose.slides/ichartdataworkbook/#getCell-int-int-int-) son basados en cero. Esta disposición es útil cuando crea un gráfico con datos predeterminados, pero no asuma que todos los gráficos existentes la utilizan. En una presentación cargada, inspeccione las celdas referenciadas por las series, categorías y puntos de datos antes de cambiar los valores del libro.

La configuración del gráfico tiene tres ámbitos diferentes:

- Configuraciones a nivel de serie, como [IChartSeries.getFormat](https://reference.aspose.com/slides/es/java/com.aspose.slides/ichartseries/#getFormat--), proporcionan la apariencia predeterminada para todos los puntos de una serie.
- Configuraciones de punto de datos, como [IChartDataPoint.getFormat](https://reference.aspose.com/slides/es/java/com.aspose.slides/ichartdatapoint/#getFormat--), sobrescriben la apariencia de la serie para un punto concreto.
- Las configuraciones de grupo se aplican a series compatibles que pertenecen al mismo [IChartSeriesGroup](https://reference.aspose.com/slides/es/java/com.aspose.slides/ichartseriesgroup/). Acceda al grupo mediante [IChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/es/java/com.aspose.slides/ichartseries/#getParentSeriesGroup--) cuando necesite establecer opciones como superposición o ancho del espacio.

Cuando no se establece un relleno explícito de punto o de serie, el estilo y el tema del gráfico determinan la apariencia automática. Cuando existen tanto formato de serie como de punto, el formato del punto tiene prioridad para ese punto.

![serie de gráfico PowerPoint](chart-series-powerpoint.png)

## **Establecer la superposición de la serie del gráfico**

[IChartSeries.getOverlap](https://reference.aspose.com/slides/es/java/com.aspose.slides/ichartseries/#getOverlap--) indica cuánto se superponen barras o columnas en un gráfico 2D, de -100 a 100 por ciento. Es una proyección de solo lectura de la configuración del grupo de series principal. Utilice [IChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/es/java/com.aspose.slides/ichartseriesgroup/#setOverlap-byte-) para actualizar todas las series compatibles en ese grupo. Esta opción se aplica a tipos de gráfico que muestran barras o columnas agrupadas; no afecta a grupos de series no relacionados en un gráfico combinado.

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

Utilice [IChartSeries.getFormat](https://reference.aspose.com/slides/es/java/com.aspose.slides/ichartseries/#getFormat--) para establecer el relleno predeterminado de una serie completa. Si un punto ya tiene un relleno explícito, su configuración [IChartDataPoint.getFormat](https://reference.aspose.com/slides/es/java/com.aspose.slides/ichartdatapoint/#getFormat--) sobrescribe el relleno de la serie para ese punto.

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

También puede actualizar la celda ya referenciada por [IChartSeries.getName](https://reference.aspose.com/slides/es/java/com.aspose.slides/ichartseries/#getName--). Este enfoque evita suponer una fila y columna particulares en un gráfico existente:

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

## **Obtener el color de relleno automático de la serie**

[IChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/es/java/com.aspose.slides/ichartseries/#getAutomaticSeriesColor--) devuelve el color calculado a partir del índice de la serie y del estilo del gráfico. Este es el color usado cuando el relleno de la serie no ha sido definido explícitamente. Llamar al método solo lee el color calculado; no asigna un nuevo relleno.

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

Los colores exactos dependen del estilo y del tema del gráfico.

## **Establecer color de relleno invertido para una serie de gráfico**

Para series de barras, columnas y burbujas, [IChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/es/java/com.aspose.slides/ichartseries/#setInvertIfNegative-boolean-) puede mostrar valores negativos con un relleno diferente. Defina el relleno regular de la serie como sólido, habilite la inversión y asigne el color para valores negativos mediante [IChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/es/java/com.aspose.slides/ichartseries/#getInvertedSolidFillColor--). Los números negativos permanecen sin cambios en el libro; solo cambia su color de visualización.

El siguiente ejemplo sustituye los datos predeterminados del gráfico por una sola serie. La fila 0 de la hoja contiene el nombre de la serie, la columna 0 contiene los nombres de las categorías y la columna 1 contiene los valores:

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

Puede habilitar la inversión para un punto mediante [IChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/es/java/com.aspose.slides/ichartdatapoint/#setInvertIfNegative-boolean-). En el siguiente ejemplo, la inversión está desactivada para la serie y habilitada solo para el punto seleccionado. Además, al punto se le asigna un valor negativo para que el efecto sea visible:

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

## **Eliminar el valor de un punto de datos específico**

Para dejar un punto vacío sin eliminar los demás, establezca su celda subyacente en `null`. En un gráfico de columnas, el valor trazado está disponible mediante [IChartDataPoint.getValue](https://reference.aspose.com/slides/es/java/com.aspose.slides/ichartdatapoint/#getValue--). El punto de datos permanece en la misma posición de categoría, pero el gráfico trata su valor como vacío según la configuración de valores en blanco del gráfico.

El siguiente ejemplo elimina solo el segundo punto de la primera serie:

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

Los gráficos de dispersión usan celdas X y Y separadas, y los de burbujas también usan una celda de tamaño. Elimine solo la celda que representa el valor que desea suprimir. No llame a [IChartDataPointCollection.clear](https://reference.aspose.com/slides/es/java/com.aspose.slides/ichartdatapointcollection/#clear--) cuando quiera conservar los demás puntos, ya que ese método elimina todos los puntos de la colección.

## **Establecer el ancho del espacio de la serie**

El ancho del espacio es el espacio entre clusters de barras o columnas adyacentes, expresado como porcentaje del ancho de la barra o columna. Al igual que la superposición, pertenece al grupo de series principal y no a una única serie. Llame a [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/es/java/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-) una sola vez para el grupo. Un valor mayor crea más espacio entre clusters; un valor menor los hace más densos.

El siguiente ejemplo modifica el ancho del espacio y guarda solo la presentación final:

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

![El ancho del espacio](gap_width.png)

## **FAQ**

**¿Qué tipos de gráfico admiten series de datos?**

Todos los tipos de gráfico representados por la enumeración [ChartType](https://reference.aspose.com/slides/es/java/com.aspose.slides/charttype/) utilizan datos de gráfico, pero sus series no comparten siempre la misma estructura de valores o configuraciones. Por ejemplo, los gráficos de categorías usan categorías y valores, los de dispersión usan valores X e Y, y los de burbujas añaden tamaños de burbuja. Utilice el método de creación de puntos de datos que corresponda al tipo de serie. Opciones como superposición y ancho del espacio solo se aplican a grupos de barras o columnas compatibles.

**¿Qué es un grupo de series de gráfico?**

Un [IChartSeriesGroup](https://reference.aspose.com/slides/es/java/com.aspose.slides/ichartseriesgroup/) contiene series compatibles que comparten configuraciones de trazado a nivel de grupo. Un gráfico combinado puede contener más de un grupo, de modo que cambiar el grupo alcanzado a través de una serie no necesariamente modifica todas las series del gráfico.

**¿Un gráfico recién creado contiene datos predeterminados?**

Sí. Por defecto, [IShapeCollection.addChart](https://reference.aspose.com/slides/es/java/com.aspose.slides/ishapecollection/#addChart-int-float-float-float-float-) crea series, categorías y valores de ejemplo. Puede editar esas celdas o vaciar tanto las colecciones de series como de categorías antes de añadir un conjunto de datos totalmente personalizado. También existe una sobrecarga que crea un gráfico sin datos predeterminados.

**¿Cómo se conectan los objetos del gráfico a las celdas del libro de trabajo?**

Los nombres de serie, las etiquetas de categoría y los valores de los puntos de datos hacen referencia a celdas en un [IChartDataWorkbook](https://reference.aspose.com/slides/es/java/com.aspose.slides/ichartdataworkbook/). Cambiar una celda referenciada actualiza el elemento del gráfico correspondiente. Cuando construye datos personalizados, mantenga las filas de categorías y las filas de valores de serie alineadas de modo que cada punto se trace bajo la categoría prevista.

**¿Cómo elimino un punto en lugar de toda la serie?**

Establezca la celda de valor pertinente en `null` para conservar la posición de categoría del punto como un punto vacío. Utilice [IChartDataPointCollection.clear](https://reference.aspose.com/slides/es/java/com.aspose.slides/ichartdatapointcollection/#clear--) solo cuando pretenda eliminar todos los puntos de esa serie. Si también elimina categorías, actualice todas las series para que sus valores sigan alineados con la colección de categorías.

**¿Cómo se muestran los puntos vacíos?**

El resultado depende del tipo de gráfico y del valor configurado mediante [IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/es/java/com.aspose.slides/ichart/#setDisplayBlanksAs-int-). Los gráficos compatibles pueden mostrar los vacíos como espacios, como valores cero o conectando los puntos vecinos. Elija la configuración que mejor refleje el significado de los datos ausentes en su presentación.

**¿Cómo se formatean los valores negativos?**

Para series de barras, columnas y burbujas compatibles, llame a [IChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/es/java/com.aspose.slides/ichartseries/#setInvertIfNegative-boolean-) y establezca el color devuelto por [IChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/es/java/com.aspose.slides/ichartseries/#getInvertedSolidFillColor--). Puede sobrescribir el comportamiento para un punto individual mediante [IChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/es/java/com.aspose.slides/ichartdatapoint/#setInvertIfNegative-boolean-). Estos métodos afectan al formato, no a los valores numéricos almacenados.

**¿Qué formato prevalece cuando tanto una serie como un punto están formateados?**

El formato explícito del punto de datos tiene precedencia para ese punto. Los demás puntos continúan usando el formato explícito de la serie o, cuando no está definido, el estilo y tema automático del gráfico. Las configuraciones de grupo, como superposición y ancho del espacio, controlan el diseño y no sustituyen el formato a nivel de punto.

**¿Existe un límite de cuántas series puede contener un gráfico?**

Aspose.Slides no impone un límite fijo separado de series. En la práctica, las restricciones del archivo de presentación, la memoria disponible, el tiempo de renderizado y la legibilidad del gráfico determinan un límite útil.

**¿Qué debo cambiar cuando las columnas están demasiado juntas o demasiado separadas?**

Llame a [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/es/java/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-) sobre el grupo de series principal correspondiente. Aumente el valor para ensanchar el espacio entre clusters o disminúyalo para acercarlos.