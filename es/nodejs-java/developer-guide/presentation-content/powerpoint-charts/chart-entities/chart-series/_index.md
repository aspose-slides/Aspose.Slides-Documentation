---
title: Gestionar series de datos de gráficos en presentaciones usando JavaScript
linktitle: Series de datos
type: docs
url: /es/nodejs-java/chart-series/
keywords:
- series de gráfico
- solapamiento de series
- color de series
- nombre de la serie
- punto de datos
- celda del libro de trabajo
- intervalo de series
- valor negativo
- PowerPoint
- presentación
- Node.js
- JavaScript
- Aspose.Slides
description: "Aprenda a gestionar series de gráficos, puntos de datos, celdas del libro de trabajo, formato, solapamiento, ancho de intervalo y valores negativos en presentaciones con JavaScript."
---
## **Visión general**

Un gráfico puede almacenar sus valores trazados en celdas del libro de trabajo o directamente como literales numéricos. Un [ChartSeries](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/) representa un conjunto de valores relacionados, y cada [ChartDataPoint](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapoint/) representa un punto en esa serie. Los objetos [ChartCategory](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartcategory/) proporcionan las etiquetas o valores de agrupación compartidos por las series. En los gráficos creados con datos predeterminados, los nombres de series, las categorías y los valores de los puntos utilizan objetos [ChartDataCell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatacell/) del libro de trabajo del gráfico.

Para un gráfico de categorías típico, el libro de trabajo predeterminado usa la fila 0 para los nombres de serie, la columna 0 para los nombres de categoría y el resto de celdas para los valores de la serie. Los índices de hoja, fila y columna que se pasan a [ChartDataWorkbook.getCell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdataworkbook/getcell/) son base 0. Este diseño es útil cuando se crea un gráfico con datos predeterminados, pero no asuma que todos los gráficos existentes lo utilizan. Para una presentación cargada, inspeccione las celdas referenciadas por las series, categorías y puntos de datos antes de modificar los valores del libro de trabajo.

Los ajustes del gráfico tienen tres ámbitos diferentes:

- Ajustes a nivel de serie, como [ChartSeries.getFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getformat/), que proporcionan la apariencia predeterminada para todos los puntos de una serie.
- Ajustes de punto de datos, como [ChartDataPoint.getFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapoint/getformat/), que sobrescriben la apariencia de la serie para un punto concreto.
- Ajustes de grupo que se aplican a series compatibles que pertenecen al mismo [ChartSeriesGroup](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/). Acceda al grupo mediante [ChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getparentseriesgroup/) cuando necesite establecer opciones como solapamiento o ancho del intervalo.

Cuando no se define un relleno explícito para un punto o una serie, el estilo y el tema del gráfico determinan la apariencia automática. Cuando existen tanto el formato de serie como el de punto, el formato del punto tiene prioridad para ese punto.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **Establecer valores de la serie usando literales numéricos**

Utilice literales numéricos cuando los valores de la serie provengan de datos de la aplicación o de cálculos y no necesiten referencias a celdas de hoja. Llame a [setDataSourceTypeForValues](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapointcollection/setdatasourcetypeforvalues/) con [DataSourceType.DoubleLiterals](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datasourcetype/) antes de asignar el resultado de [getValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapoint/getvalue/) de cada punto mediante [setAsLiteralDouble](https://reference.aspose.com/slides/nodejs-java/aspose.slides/doublechartvalue/setasliteraldouble/).

El ajuste de la colección controla el tipo de origen de todos los valores de punto en esa serie. El método [getDataSourceType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/basechartvalue/) de cada valor de punto informa del tipo seleccionado; cámbielo a través del ajuste de la colección. Con `Worksheet`, utilice [getAsCell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/doublechartvalue/getascell/) para acceder a la celda referenciada. Con `DoubleLiterals`, utilice [getAsLiteralDouble](https://reference.aspose.com/slides/nodejs-java/aspose.slides/doublechartvalue/getasliteraldouble/) o `setAsLiteralDouble` para leer o escribir el número directamente.

El siguiente ejemplo crea un gráfico de columnas con series y categorías predeterminadas, y luego asigna valores calculados de 10, 20, etc., a los puntos existentes de su primera serie. Guarda la presentación, la vuelve a abrir y muestra los valores almacenados.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 300);
    const series = chart.getChartData().getSeries().get_Item(0);

    series.getDataPoints().setDataSourceTypeForValues(aspose.slides.DataSourceType.DoubleLiterals);
    for (let i = 0; i < series.getDataPoints().size(); i++) {
        series.getDataPoints().get_Item(i).getValue().setAsLiteralDouble((i + 1) * 10);
    }

    presentation.save("numeric_literals.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

const reopenedPresentation = new aspose.slides.Presentation("numeric_literals.pptx");
try {
    const reopenedSlide = reopenedPresentation.getSlides().get_Item(0);
    const reopenedChart = reopenedSlide.getShapes().get_Item(0);
    const reopenedSeries = reopenedChart.getChartData().getSeries().get_Item(0);
    for (let i = 0; i < reopenedSeries.getDataPoints().size(); i++) {
        const point = reopenedSeries.getDataPoints().get_Item(i);
        console.log(point.getValue().getAsLiteralDouble());
    }
} finally {
    reopenedPresentation.dispose();
}
```

El tipo de origen del valor del punto es independiente de [ChartData.getDataSourceType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/getdatasourcetype/), que identifica la configuración interna o externa del libro de trabajo del gráfico. Usar literales numéricos no elimina, por sí mismo, el libro de trabajo incrustado. En este ejemplo, el libro sigue disponible para etiquetas de categoría, nombres de series y la otra serie. Consulte [Chart Workbook](/slides/es/nodejs-java/chart-workbook/) para la gestión del libro de trabajo.

Para gráficos de dispersión y de burbujas, utilice [setDataSourceTypeForXValues](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapointcollection/setdatasourcetypeforxvalues/) y [setDataSourceTypeForYValues](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapointcollection/setdatasourcetypeforyvalues/) para elegir los orígenes de [getXValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapoint/getxvalue/) y [getYValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapoint/getyvalue/). Los gráficos de burbujas también usan [setDataSourceTypeForBubbleSizes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapointcollection/setdatasourcetypeforbubblesizes/) para [getBubbleSize](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapoint/getbubblesize/). Establezca cada origen aplicable en `DoubleLiterals` antes de asignar números mediante el método `setAsLiteralDouble` de ese valor.

## **Establecer el solapamiento de la serie del gráfico**

[ChartSeries.getOverlap](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getoverlap/) indica cuánto se solapan las barras o columnas en un gráfico 2D, de -100 a 100 por ciento. Es una proyección de solo lectura del ajuste en el grupo de series padre. Utilice [ChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/setoverlap/) para actualizar todas las series compatibles en ese grupo. Esta opción se aplica a los tipos de gráficos que muestran barras o columnas agrupadas; no afecta a los grupos de series no relacionados en un gráfico combinado.

El siguiente ejemplo establece el solapamiento para el grupo que contiene la primera serie:

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

    // El nuevo gráfico contiene series de muestra, categorías y valores.
    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 200);

    const series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    series.getParentSeriesGroup().setOverlap(overlapPercent);

    presentation.save("series_overlap.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

El resultado:

![The series overlap](series_overlap.png)

## **Cambiar el color de relleno de la serie**

Utilice [ChartSeries.getFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getformat/) para establecer el relleno predeterminado de una serie completa. Si un punto ya tiene un relleno explícito, su ajuste [ChartDataPoint.getFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapoint/getformat/) sobrescribe el relleno de la serie para ese punto.

El siguiente ejemplo aplica un relleno azul sólido a la primera serie:

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

![The color of the series](series_color.png)

## **Cambiar el nombre de la serie**

El nombre de una serie se almacena en el libro de datos del gráfico y normalmente se muestra en la leyenda. En el libro predeterminado creado para un gráfico de columnas agrupadas, la celda B1 está en la fila 0, columna 1 y contiene el nombre de la primera serie. Las constantes nombradas del siguiente ejemplo hacen explícita esa estructura:

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

También puede actualizar la celda ya referenciada por [ChartSeries.getName](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getname/). Este enfoque evita suponer una fila y columna concretas en un gráfico existente:

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

![The series name](series_name.png)

### **Crear una serie con un nombre a partir de varias celdas**

Un nombre de serie compuesto es útil cuando el nombre del producto y el período del informe están almacenados en celdas diferentes del libro. Por ejemplo, puede combinar `Product A` en B1 y `2026` en C1 en un único nombre de serie manteniendo ambas partes vinculadas a sus celdas origen.

Utilice [ChartDataWorkbook.getCellCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdataworkbook/getcellcollection/) para obtener el rango de nombres y, a continuación, pase esa colección a [ChartSeriesCollection.add](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriescollection/add/). El argumento `skipHiddenCells` controla si se incluyen celdas ocultas: `true` las excluye, `false` las incluye. Este ejemplo usa `false` para incluir todas las celdas del rango de nombres.

El siguiente ejemplo crea una presentación con una serie y dos puntos de datos. Las celdas B1:C1 suministran solo el nombre de la serie; A2:A3 proporcionan las etiquetas de categoría, y B2:B3 los valores numéricos.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 620, 180);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    chart.setLegend(true);

    const workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    // Estas dos celdas proporcionan el nombre de la serie.
    workbook.getCell(0, 0, 1, "Product A");
    workbook.getCell(0, 0, 2, "2026");
    const nameCells = workbook.getCellCollection("Sheet1!$B$1:$C$1", false);
    const series = chart.getChartData().getSeries().add(nameCells, aspose.slides.ChartType.ClusteredColumn);

    // Celdas separadas proporcionan las categorías y los puntos de datos numéricos.
    const northCategory = workbook.getCell(0, 1, 0, "North");
    const southCategory = workbook.getCell(0, 2, 0, "South");
    chart.getChartData().getCategories().add(northCategory);
    chart.getChartData().getCategories().add(southCategory);
    const northValue = workbook.getCell(0, 1, 1, 120);
    const southValue = workbook.getCell(0, 2, 1, 150);
    series.getDataPoints().addDataPointForBarSeries(northValue);
    series.getDataPoints().addDataPointForBarSeries(southValue);

    presentation.save("composite_series_name.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

El nombre de serie resultante es `Product A 2026`, con un espacio entre los dos valores de celda. La leyenda lo muestra como una única entrada para ambas columnas. La imagen a continuación ilustra el resultado:

![Column chart with North and South values and the composite series name Product A 2026 in the legend](composite_series_name.png)

## **Obtener el color automático de relleno de la serie**

[ChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getautomaticseriescolor/) devuelve el color calculado a partir del índice de la serie y del estilo del gráfico. Este es el color usado cuando el relleno de la serie no se ha definido explícitamente. Llamar al método lee el color calculado; no asigna un nuevo relleno.

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

Los colores exactos dependen del estilo y el tema del gráfico.

## **Establecer relleno invertido para una serie del gráfico**

Para series de barras, columnas y burbujas, [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/setinvertifnegative/) puede mostrar valores negativos con un relleno diferente. Establezca el relleno de serie regular a sólido, habilite la inversión y asigne el color de valor negativo mediante [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getinvertedsolidfillcolor/). Los números negativos permanecen sin cambios en el libro; solo su color de visualización varía.

El siguiente ejemplo sustituye los datos del gráfico por una sola serie. La fila 0 de la hoja contiene el nombre de la serie, la columna 0 los nombres de categoría y la columna 1 los valores:

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

![The inverted solid fill color](inverted_solid_fill_color.png)

Puede habilitar la inversión para un punto mediante [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapoint/setinvertifnegative/). En el siguiente ejemplo la inversión está desactivada para la serie y activada solo para el punto seleccionado. Además, al punto se le asigna un valor negativo para que el efecto sea visible:

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

Para dejar un punto vacío sin eliminar los demás, establezca su celda de libro subyacente a `null`. En un gráfico de columnas, el valor trazado está disponible mediante [ChartDataPoint.getValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapoint/getvalue/). El punto permanece en la misma posición de categoría, pero el gráfico trata su valor como en blanco según la configuración de valores en blanco del gráfico.

El siguiente ejemplo borra solo el segundo punto de la primera serie:

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

Los gráficos de dispersión usan celdas X e Y separadas, y los de burbujas también usan una celda de tamaño. Borre solo la celda que representa el valor que desea eliminar. No llame a [ChartDataPointCollection.clear](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapointcollection/clear/) cuando quiera conservar los demás puntos, porque ese método elimina todos los puntos de datos de la colección.

## **Controlar la visualización de celdas vacías**

Las celdas ocultas que contienen valores son un caso distinto de las celdas vacías. Para incluir o excluir datos de filas y columnas ocultas, consulte [Include Data from Hidden Rows and Columns](/slides/es/nodejs-java/chart-workbook/#include-data-from-hidden-rows-and-columns).

Una celda de libro vacía representa datos ausentes; una celda que contiene `0` representa un valor numérico conocido. Llame a [ChartDataCell.setValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatacell/setvalue/) con `null` para dejar una celda vacía. Un cero numérico sigue siendo cero independientemente de la configuración de celdas en blanco.

Utilice [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/setdisplayblanksas/) para elegir cómo el gráfico muestra las celdas vacías. Este ajuste se aplica a todo el gráfico. Cambia la forma en que se trazan los vacíos, sin rellenar la celda del libro con cero ni con un valor interpolado.

El siguiente ejemplo independiente crea un gráfico de líneas con una serie, borra el valor del Día 3 y guarda el mismo gráfico con cada modo. No se necesita archivo de entrada. El [ChartDataWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdataworkbook/) usa la hoja 0, la columna 0 para etiquetas de categoría y la columna 1 para valores; la fila 0 contiene el nombre de la serie. Los datos finales son `10, 20, empty, 30, 40`.

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

    // Dejar el día 3 realmente vacío, manteniendo su categoría y punto de datos.
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

Cada archivo de salida almacena el modo asignado antes de guardar: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx` y `empty_cells_Span.pptx`. Para guardar solo una versión, asigne el modo deseado y guarde la presentación una sola vez en lugar de iterar sobre los modos.

La comparación a continuación muestra los mismos datos en los tres archivos. El Día 3 está vacío en el libro en todos los casos:

![Line charts with identical data: Gap breaks the line at Day 3, Zero drops the line to zero, and Span connects Day 2 to Day 4.](display_blanks_as.png)

El efecto visible depende del tipo de gráfico. Un gráfico de líneas permite comparar fácilmente los tres modos. Los gráficos de barras y columnas no tienen línea que conectar una categoría ausente, por lo que `Span` no puede producir el segmento de conexión mostrado arriba; una columna ausente y una columna de altura cero pueden parecer iguales. De forma similar, un gráfico de dispersión solo con marcadores no tiene línea de conexión. No espere tres resultados distintos para cada tipo de gráfico; compruebe la salida para el tipo que utilice.

## **Establecer el ancho del intervalo de la serie**

El ancho del intervalo es el espacio entre grupos adyacentes de barras o columnas, expresado como porcentaje del ancho de la barra o columna. Al igual que el solapamiento, pertenece al grupo de series padre y no a una sola serie. Llame a [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/setgapwidth/) una vez para el grupo. Un valor mayor crea más espacio entre grupos; un valor menor los hace más densos.

El siguiente ejemplo cambia el ancho del intervalo y guarda solo la presentación final:

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

![The gap width](gap_width.png)

## **Preguntas frecuentes**

**¿Qué tipos de gráfico admiten series de datos?**

Todos los tipos de gráficos representados por la enumeración [ChartType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/) usan datos de gráfico, pero sus series no comparten la misma estructura de valores ni los mismos ajustes. Por ejemplo, los gráficos de categorías usan categorías y valores, los de dispersión usan valores X y Y, y los de burbujas añaden tamaños de burbuja. Utilice el método de creación de puntos que corresponda al tipo de serie. Opciones como solapamiento y ancho del intervalo solo se aplican a grupos de barras o columnas compatibles.

**¿Qué es un grupo de series de gráfico?**

Un [ChartSeriesGroup](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/) contiene series compatibles que comparten ajustes de trazado a nivel de grupo. Un gráfico combinado puede contener más de un grupo, por lo que cambiar el grupo al que se accede a través de una serie no necesariamente modifica todas las series del gráfico.

**¿Un gráfico recién creado contiene datos predeterminados?**

Sí. Por defecto, [ShapeCollection.addChart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/addchart/) crea series, categorías y valores de muestra. Puede editar esas celdas o borrar tanto las colecciones de series como de categorías antes de añadir un conjunto de datos totalmente personalizado. Una sobrecarga también puede crear un gráfico sin datos predeterminados.

**¿Cómo están conectados los objetos del gráfico a las celdas del libro?**

Los nombres de serie, las etiquetas de categoría y los valores de los puntos de datos referencian celdas en un [ChartDataWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdataworkbook/). Cambiar una celda referenciada actualiza el elemento del gráfico correspondiente. Cuando construye datos personalizados, mantenga alineadas las filas de categorías y las filas de valores de serie para que cada punto se tracée bajo la categoría prevista.

**¿Cómo limpio un punto sin borrar toda la serie?**

Establezca la celda de valor correspondiente a `null` para conservar la posición de categoría del punto como vacío. Utilice [ChartDataPointCollection.clear](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapointcollection/clear/) solo cuando quiera eliminar todos los puntos de esa serie. Si también elimina categorías, actualice todas las series para que sus valores sigan alineados con la colección de categorías.

**¿Cómo se muestran los puntos vacíos?**

El resultado depende del tipo de gráfico y del valor configurado mediante [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/setdisplayblanksas/). Los gráficos admitidos pueden mostrar los vacíos como intervalos, como valores cero o conectando los puntos vecinos. Elija la configuración que coincida con el significado de los datos ausentes en su presentación. Consulte [Controlar la visualización de celdas vacías](#controlar-la-visualización-de-celdas-vacías) para un ejemplo completo y una comparativa visual.

**¿Cómo se formatean los valores negativos?**

Para series de barras, columnas y burbujas compatibles, llame a [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/setinvertifnegative/) y establezca el color devuelto por [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getinvertedsolidfillcolor/). Puede sobrescribir el comportamiento para un punto individual con [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapoint/setinvertifnegative/). Estos métodos afectan al formato, no a los valores numéricos almacenados.

**¿Qué formato prevalece cuando tanto una serie como un punto están formateados?**

El formato explícito del punto de datos tiene prioridad para ese punto. Los demás puntos continúan usando el formato explícito de la serie o, cuando no está definido, el estilo y tema automático del gráfico. Los ajustes de grupo como solapamiento y ancho del intervalo controlan la disposición y no sustituyen el formato a nivel de punto.

**¿Existe un límite de series que pueda contener un gráfico?**

Aspose.Slides no impone un límite fijo de series. En la práctica, las limitaciones del archivo de presentación, la memoria disponible, el tiempo de renderizado y la legibilidad del gráfico determinan un límite razonable.

**¿Qué debo modificar cuando las columnas están demasiado juntas o muy separadas?**

Llame a [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/setgapwidth/) en el grupo de series padre correspondiente. Aumente el valor para ensanchar el espacio entre grupos, o disminúyalo para acercarlos.