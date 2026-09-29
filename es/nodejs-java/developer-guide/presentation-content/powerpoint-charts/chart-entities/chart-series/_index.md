---
title: Gestionar series de datos de gráficos en presentaciones usando JavaScript
linktitle: Series de datos
type: docs
url: /es/nodejs-java/chart-series/
keywords:
- series de gráfico
- superposición de series
- color de series
- nombre de la serie
- punto de datos
- celda del libro de trabajo
- espacio entre series
- valor negativo
- PowerPoint
- presentación
- Node.js
- JavaScript
- Aspose.Slides
description: "Aprenda cómo gestionar series de gráficos, puntos de datos, celdas del libro de trabajo, formato, superposición, anchura del espacio y valores negativos en presentaciones con JavaScript."
---
## **Visión general**

Un gráfico almacena sus datos trazados en un libro de datos del gráfico. Un [ChartSeries](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/chartseries/) representa un conjunto de valores relacionados, y cada [ChartDataPoint](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/chartdatapoint/) en la serie se refiere a una o más celdas del libro de trabajo. Los objetos [ChartCategory](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/chartcategory/) proporcionan las etiquetas o valores de agrupación compartidos por las series. Por lo tanto, el nombre de la serie, las categorías y los valores de los puntos están conectados a objetos [ChartDataCell](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/chartdatacell/) en lugar de almacenarse solo como texto de visualización.

Para un gráfico de categorías típico, el libro de datos predeterminado usa la fila 0 para los nombres de las series, la columna 0 para los nombres de las categorías y el resto de las celdas para los valores de las series. Los índices de hoja, fila y columna que se pasan a [ChartDataWorkbook.getCell](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/chartdataworkbook/#getCell) son base cero. Este esquema es útil cuando se crea un gráfico con datos predeterminados, pero no se debe asumir que todo gráfico existente lo utilice. Para una presentación cargada, inspeccione las celdas referenciadas por las series, categorías y puntos de datos antes de modificar los valores del libro de trabajo.

Los ajustes del gráfico tienen tres ámbitos diferentes:

- Ajustes a nivel de serie, como [ChartSeries.getFormat](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/chartseries/#getFormat), proporcionan la apariencia predeterminada para todos los puntos de una serie.
- Ajustes de punto de datos, como [ChartDataPoint.getFormat](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/chartdatapoint/#getFormat), sustituyen la apariencia de la serie para un punto concreto.
- Los ajustes de grupo se aplican a series compatibles que pertenecen al mismo [ChartSeriesGroup](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/chartseriesgroup/). Acceda al grupo mediante [ChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/chartseries/#getParentSeriesGroup) cuando necesite establecer opciones como superposición o anchura del espacio.

Cuando no se define un relleno explícito de punto o serie, el estilo y el tema del gráfico determinan la apariencia automática. Cuando están presentes tanto el formato de serie como el de punto, el formato de punto tiene prioridad para ese punto.

![serie-de-gráfico-powerpoint](chart-series-powerpoint.png)

## **Establecer la superposición de la serie del gráfico**

[ChartSeries.getOverlap](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/chartseries/#getOverlap) indica cuánto se solapan las barras o columnas en un gráfico 2D, desde -100 hasta 100 por ciento. Es una proyección de solo lectura del ajuste en el grupo de series padre. Utilice [ChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/chartseriesgroup/#setOverlap) para actualizar todas las series compatibles en ese grupo. Esta opción se aplica a los tipos de gráfico que muestran barras o columnas agrupadas; no afecta a los grupos de series no relacionados en un gráfico combinado.

El siguiente ejemplo establece la superposición para el grupo que contiene la primera serie:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const firstSlideIndex = 0;
const firstSeriesIndex = 0;
const overlapPercent = java.newByte(30);

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(firstSlideIndex);

    // El nuevo gráfico contiene series de ejemplo, categorías y valores.
    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 200);

    const series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    series.getParentSeriesGroup().setOverlap(overlapPercent);

    presentation.save("series_overlap.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

El resultado:

![Superposición de la serie](series_overlap.png)

## **Cambiar el color de relleno de la serie**

Utilice [ChartSeries.getFormat](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/chartseries/#getFormat) para establecer el relleno predeterminado de una serie completa. Si un punto ya tiene un relleno explícito, su ajuste [ChartDataPoint.getFormat](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/chartdatapoint/#getFormat) sustituye el relleno de la serie para ese punto.

El siguiente ejemplo aplica un relleno sólido azul a la primera serie:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const firstSlideIndex = 0;
const firstSeriesIndex = 0;
const solidFillType = java.newByte(aspose.slides.FillType.Solid);
const blueColor = java.getStaticFieldValue("java.awt.Color", "BLUE");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(firstSlideIndex);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 200);

    const series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    series.getFormat().getFill().setFillType(solidFillType);
    series.getFormat().getFill().getSolidFillColor().setColor(blueColor);

    presentation.save("series_color.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

El resultado:

![Color de la serie](series_color.png)

## **Cambiar el nombre de la serie**

El nombre de una serie se almacena en el libro de datos del gráfico y normalmente se muestra en la leyenda. En el libro de datos predeterminado creado para un gráfico de columnas agrupadas, la celda B1 está en la fila 0, columna 1 y contiene el nombre de la primera serie. Las constantes nombradas en el siguiente ejemplo hacen explícita esa estructura:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const firstSlideIndex = 0;
const worksheetIndex = 0;
const seriesNameRowIndex = 0;
const firstSeriesColumnIndex = 1;

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(firstSlideIndex);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 200);

    const workbook = chart.getChartData().getChartDataWorkbook();
    const seriesNameCell = workbook.getCell(worksheetIndex, seriesNameRowIndex, firstSeriesColumnIndex);
    seriesNameCell.setValue("Revenue");

    presentation.save("series_name.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

También puede actualizar la celda ya referenciada por [ChartSeries.getName](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/chartseries/#getName). Este enfoque evita suponer una fila y columna concretas en un gráfico existente:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const firstSlideIndex = 0;
const firstSeriesIndex = 0;
const firstNameCellIndex = 0;

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(firstSlideIndex);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 200);

    const series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    const seriesNameCell = series.getName().getAsCells().get_Item(firstNameCellIndex);
    seriesNameCell.setValue("Revenue");

    presentation.save("series_name.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

El resultado:

![Nombre de la serie](series_name.png)

## **Obtener el color de relleno automático de la serie**

[ChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/chartseries/#getAutomaticSeriesColor) devuelve el color calculado a partir del índice de la serie y del estilo del gráfico. Este es el color que se usa cuando el relleno de la serie no se ha definido explícitamente. Llamar al método lee el color calculado; no asigna un nuevo relleno.

El siguiente ejemplo muestra el color automático de cada serie predeterminada:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const firstSlideIndex = 0;

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(firstSlideIndex);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 200);

    const seriesCount = chart.getChartData().getSeries().size();
    for (let seriesIndex = 0; seriesIndex < seriesCount; seriesIndex++) {
        const series = chart.getChartData().getSeries().get_Item(seriesIndex);
        const automaticColor = series.getAutomaticSeriesColor();
        const automaticColorText = automaticColor.toString();
        console.log("Series " + seriesIndex + ": " + automaticColorText);
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

## **Establecer color de relleno invertido para una serie del gráfico**

Para series de barras, columnas y burbujas, [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/chartseries/#setInvertIfNegative) puede mostrar valores negativos con un relleno diferente. Establezca el relleno regular de la serie a sólido, habilite la inversión y asigne el color para valores negativos mediante [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/chartseries/#getInvertedSolidFillColor). Los números negativos permanecen sin cambios en el libro de trabajo; solo cambia su color de visualización.

El siguiente ejemplo sustituye los datos predeterminados del gráfico por una serie. La fila 0 de la hoja contiene el nombre de la serie, la columna 0 los nombres de las categorías y la columna 1 los valores:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const firstSlideIndex = 0;
const worksheetIndex = 0;
const headerRowIndex = 0;
const categoryColumnIndex = 0;
const firstSeriesColumnIndex = 1;
const firstDataRowIndex = 1;
const solidFillType = java.newByte(aspose.slides.FillType.Solid);
const redColor = java.getStaticFieldValue("java.awt.Color", "RED");

const categoryNames = ["Category 1", "Category 2", "Category 3"];
const seriesValues = [-20, 50, -30];

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(firstSlideIndex);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 200);
    const chartData = chart.getChartData();
    const workbook = chartData.getChartDataWorkbook();

    chartData.getSeries().clear();
    chartData.getCategories().clear();

    const seriesNameCell = workbook.getCell(worksheetIndex, headerRowIndex, firstSeriesColumnIndex, "Series 1");
    const chartType = chart.getType();
    const series = chartData.getSeries().add(seriesNameCell, chartType);

    for (let categoryIndex = 0; categoryIndex < categoryNames.length; categoryIndex++) {
        const dataRowIndex = firstDataRowIndex + categoryIndex;
        const categoryName = categoryNames[categoryIndex];
        const seriesValue = seriesValues[categoryIndex];

        const categoryCell = workbook.getCell(worksheetIndex, dataRowIndex, categoryColumnIndex, categoryName);
        chartData.getCategories().add(categoryCell);

        const valueCell = workbook.getCell(worksheetIndex, dataRowIndex, firstSeriesColumnIndex, seriesValue);
        series.getDataPoints().addDataPointForBarSeries(valueCell);
    }

    const automaticSeriesColor = series.getAutomaticSeriesColor();
    series.getFormat().getFill().setFillType(solidFillType);
    series.getFormat().getFill().getSolidFillColor().setColor(automaticSeriesColor);
    series.setInvertIfNegative(true);
    series.getInvertedSolidFillColor().setColor(redColor);

    presentation.save("inverted_solid_fill_color.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

El resultado:

![Color de relleno sólido invertido](inverted_solid_fill_color.png)

Puede habilitar la inversión para un solo punto mediante [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/chartdatapoint/#setInvertIfNegative). En el siguiente ejemplo la inversión está desactivada para la serie y activada solo para el punto seleccionado. Además, se asigna un valor negativo al punto para que el efecto sea visible:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const firstSlideIndex = 0;
const firstSeriesIndex = 0;
const targetDataPointIndex = 2;
const negativeValue = -30;
const solidFillType = java.newByte(aspose.slides.FillType.Solid);
const redColor = java.getStaticFieldValue("java.awt.Color", "RED");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(firstSlideIndex);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 200);

    const series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    const automaticSeriesColor = series.getAutomaticSeriesColor();
    series.getFormat().getFill().setFillType(solidFillType);
    series.getFormat().getFill().getSolidFillColor().setColor(automaticSeriesColor);
    series.getInvertedSolidFillColor().setColor(redColor);
    series.setInvertIfNegative(false);

    const dataPoint = series.getDataPoints().get_Item(targetDataPointIndex);
    dataPoint.getValue().getAsCell().setValue(negativeValue);
    dataPoint.setInvertIfNegative(true);

    presentation.save("data_point_invert_color_if_negative.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Borrar el valor de un punto de datos específico**

Para dejar vacío un punto sin eliminar los demás, establezca su celda de respaldo en el libro de trabajo a `null`. En un gráfico de columnas, el valor trazado está disponible mediante [ChartDataPoint.getValue](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/chartdatapoint/#getValue). El punto de datos permanece en la misma posición de categoría, pero el gráfico trata su valor como vacío según la configuración de valores vacíos del gráfico.

El siguiente ejemplo borra únicamente el segundo punto de la primera serie:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const firstSlideIndex = 0;
const firstSeriesIndex = 0;
const targetDataPointIndex = 1;

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(firstSlideIndex);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 200);

    const series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    const dataPoint = series.getDataPoints().get_Item(targetDataPointIndex);
    dataPoint.getValue().getAsCell().setValue(null);

    presentation.save("clear_data_point_value.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Los gráficos de dispersión usan celdas X e Y separadas, y los de burbujas también usan una celda de tamaño. Borra solo la celda que representa el valor que desea eliminar. No llame a [ChartDataPointCollection.clear](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/chartdatapointcollection/#clear) cuando quiera conservar los demás puntos, ya que ese método elimina todos los puntos de datos de la colección.

## **Controlar la visualización de celdas vacías**

Las celdas ocultas que contienen valores son un caso diferente de las celdas vacías. Para incluir o excluir datos de filas y columnas ocultas de la hoja, consulte [Include Data from Hidden Rows and Columns](/slides/es/nodejs-java/chart-workbook/#include-data-from-hidden-rows-and-columns).

Una celda de libro de trabajo vacía representa datos faltantes; una celda que contiene `0` representa un valor numérico conocido. Llame a [ChartDataCell.setValue](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/chartdatacell/#setValue) con `null` para dejar una celda vacía. Un cero numérico sigue siendo cero independientemente de la configuración de celdas vacías.

Utilice [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/chart/#setDisplayBlanksAs) para elegir cómo el gráfico muestra las celdas vacías. Esta configuración se aplica a todo el gráfico. Cambia la forma en que se trazan los vacíos, sin rellenar la celda del libro de trabajo con cero o con un valor interpolado.

El siguiente ejemplo autónomo crea un gráfico de líneas con una serie, borra el valor del Día 3 y guarda el mismo gráfico con cada modo. No se requiere archivo de entrada. El [ChartDataWorkbook](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/chartdataworkbook/) usa la hoja 0, la columna 0 para las etiquetas de categoría y la columna 1 para los valores; la fila 0 contiene el nombre de la serie. Los datos finales son `10, 20, empty, 30, 40`.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.LineWithMarkers, 40, 40, 640, 400);
    const chartData = chart.getChartData();
    const workbook = chartData.getChartDataWorkbook();

    chartData.getSeries().clear();
    chartData.getCategories().clear();

    const seriesNameCell = workbook.getCell(0, 0, 1, "Measurements");
    const series = chartData.getSeries().add(seriesNameCell, chart.getType());
    const values = [10, 20, 25, 30, 40];

    for (let i = 0; i < values.length; i++) {
        const categoryCell = workbook.getCell(0, i + 1, 0, "Day " + (i + 1));
        chartData.getCategories().add(categoryCell);
        const valueCell = workbook.getCell(0, i + 1, 1, values[i]);
        series.getDataPoints().addDataPointForLineSeries(valueCell);
    }

    // Deje el Día 3 realmente vacío, mientras conserva su categoría y punto de datos.
    workbook.getCell(0, 3, 1).setValue(null);

    const modes = [aspose.slides.DisplayBlanksAsType.Gap, aspose.slides.DisplayBlanksAsType.Zero, aspose.slides.DisplayBlanksAsType.Span];
    const modeNames = ["Gap", "Zero", "Span"];
    for (let i = 0; i < modes.length; i++) {
        chart.setDisplayBlanksAs(modes[i]);
        presentation.save("empty_cells_" + modeNames[i] + ".pptx", aspose.slides.SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

Cada archivo de salida almacena el modo asignado antes de guardarse: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx` y `empty_cells_Span.pptx`. Para guardar solo una versión, asigne el modo deseado y guarde la presentación una única vez en lugar de iterar sobre los modos.

La comparación a continuación muestra los mismos datos en los tres archivos. El Día 3 está vacío en el libro de trabajo en todos los casos:

![Gráficos de líneas con datos idénticos: Gap corta la línea en el Día 3, Zero lleva la línea a cero, y Span conecta el Día 2 con el Día 4.](display_blanks_as.png)

El efecto visible depende del tipo de gráfico. Un gráfico de líneas facilita la comparación de los tres modos. Los gráficos de barras y columnas no tienen línea que conecte a través de una categoría faltante, por lo que `Span` no puede producir el segmento de conexión mostrado arriba; una columna faltante y una columna de altura cero pueden parecer similares. Del mismo modo, un gráfico de dispersión con solo marcadores no tiene línea de conexión. No espere tres resultados distintos para cada tipo de gráfico; compruebe la salida del tipo que utilice.

## **Establecer la anchura del espacio entre series**

La anchura del espacio entre series es el espacio entre grupos adyacentes de barras o columnas, expresado como porcentaje del ancho de la barra o columna. Al igual que la superposición, pertenece al grupo de series padre y no a una única serie. Llamar a [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/chartseriesgroup/#setGapWidth) una sola vez para el grupo. Un valor mayor crea más espacio entre los grupos; un valor menor los hace más densos.

El siguiente ejemplo modifica la anchura del espacio y guarda solo la presentación final:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const firstSlideIndex = 0;
const firstSeriesIndex = 0;
const gapWidthPercent = 30;

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(firstSlideIndex);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.StackedColumn, 20, 20, 500, 200);

    const series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    series.getParentSeriesGroup().setGapWidth(gapWidthPercent);

    presentation.save("gap_width_30.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

El resultado:

![Anchura del espacio](gap_width.png)

## **FAQ**

**¿Qué tipos de gráfico admiten series de datos?**

Todos los tipos de gráfico representados por la enumeración [ChartType](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/charttype/) utilizan datos de gráfico, pero sus series no comparten la misma estructura de valores ni los mismos ajustes. Por ejemplo, los gráficos de categorías usan categorías y valores, los de dispersión usan valores X e Y, y los de burbujas añaden tamaños de burbuja. Utilice el método de creación de punto de datos que coincida con el tipo de serie. Opciones como superposición y anchura del espacio se aplican solo a grupos de barras o columnas compatibles.

**¿Qué es un grupo de series de gráfico?**

Un [ChartSeriesGroup](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/chartseriesgroup/) contiene series compatibles que comparten ajustes de trazado a nivel de grupo. Un gráfico combinado puede contener más de un grupo, por lo que cambiar el grupo al que se llega a través de una serie no necesariamente modifica todas las series del gráfico.

**¿Un gráfico creado recientemente contiene datos predeterminados?**

Sí. De forma predeterminada, [ShapeCollection.addChart](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/shapecollection/#addChart) crea series, categorías y valores de ejemplo. Puede editar esas celdas o borrar tanto las colecciones de series como de categorías antes de añadir un conjunto de datos totalmente personalizado. También existe una sobrecarga que crea un gráfico sin datos predeterminados.

**¿Cómo están conectados los objetos del gráfico a las celdas del libro de trabajo?**

Los nombres de las series, las etiquetas de categoría y los valores de los puntos de datos hacen referencia a celdas en un [ChartDataWorkbook](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/chartdataworkbook/). Cambiar una celda referenciada actualiza el elemento del gráfico correspondiente. Cuando construye datos personalizados, mantenga alineadas las filas de categorías y las filas de valores de series para que cada punto se trace bajo la categoría prevista.

**¿Cómo borrar un punto sin eliminar toda la serie?**

Establezca la celda de valor correspondiente a `null` para conservar la posición de categoría del punto como un punto vacío. Utilice [ChartDataPointCollection.clear](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/chartdatapointcollection/#clear) solo cuando pretenda eliminar todos los puntos de esa serie. Si también elimina categorías, actualice todas las series para que sus valores permanezcan alineados con la colección de categorías.

**¿Cómo se visualizan los puntos vacíos?**

El resultado depende del tipo de gráfico y del valor configurado mediante [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/chart/#setDisplayBlanksAs). Los gráficos compatibles pueden mostrar los vacíos como huecos, como valores cero o conectando los puntos vecinos. Elija la configuración que coincida con el significado de los datos faltantes en su presentación. Consulte [Controlar la visualización de celdas vacías](#controlar-la-visualización-de-celdas-vacías) para un ejemplo completo y una comparación visual.

**¿Cómo se formatean los valores negativos?**

Para series de barras, columnas y burbujas compatibles, llame a [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/chartseries/#setInvertIfNegative) y establezca el color devuelto por [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/chartseries/#getInvertedSolidFillColor). Puede sobrescribir el comportamiento para un punto individual con [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/chartdatapoint/#setInvertIfNegative). Estos métodos afectan al formato, no a los valores numéricos almacenados.

**¿Qué formato tiene prioridad cuando se formatean tanto la serie como el punto?**

El formato explícito del punto de datos tiene precedencia para ese punto. Los demás puntos continúan usando el formato explícito de la serie o, cuando no se define, el estilo y el tema automáticos del gráfico. Los ajustes de grupo, como superposición y anchura del espacio, controlan la disposición y no sobrescriben el formato a nivel de punto.

**¿Existe un límite en la cantidad de series que puede contener un gráfico?**

Aspose.Slides no impone un límite fijo separado de series. En la práctica, las restricciones del archivo de presentación, la memoria disponible, el tiempo de renderizado y la legibilidad del gráfico determinan un límite útil.

**¿Qué debo modificar cuando las columnas están demasiado juntas o demasiado separadas?**

Llame a [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/chartseriesgroup/#setGapWidth) en el grupo de series padre correspondiente. Aumente el valor para ensanchar el espacio entre los grupos, o disminúyalo para acercarlos.