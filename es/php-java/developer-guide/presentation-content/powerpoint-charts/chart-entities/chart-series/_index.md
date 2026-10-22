---
title: Gestionar series de datos de gráficos en presentaciones en PHP
linktitle: Series de datos
type: docs
url: /es/php-java/chart-series/
keywords:
- series de gráfico
- superposición de series
- color de series
- nombre de serie
- punto de datos
- celda de libro de trabajo
- espacio entre series
- valor negativo
- PowerPoint
- presentación
- PHP
- Aspose.Slides
description: "Aprenda a gestionar series de gráficos, puntos de datos, celdas de libro de trabajo, formato, superposición, ancho de separación y valores negativos en presentaciones con PHP."
---
## **Visión general**

Un gráfico puede almacenar sus valores trazados en celdas del libro de trabajo o directamente como literales numéricos. Un [ChartSeries](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/) representa un conjunto de valores relacionados, y cada [ChartDataPoint](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/) representa un punto de esa serie. Los objetos [ChartCategory](https://reference.aspose.com/slides/php-java/aspose.slides/chartcategory/) proporcionan las etiquetas o valores de agrupamiento compartidos por las series. En los gráficos creados con datos predeterminados, los nombres de las series, las categorías y los valores de los puntos utilizan objetos [ChartDataCell](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatacell/) del libro de trabajo del gráfico.

Para un gráfico de categorías típico, el libro de trabajo predeterminado usa la fila 0 para los nombres de series, la columna 0 para los nombres de categorías y las celdas restantes para los valores de las series. Los índices de hoja, fila y columna que se pasan a [ChartDataWorkbook::getCell](https://reference.aspose.com/slides/php-java/aspose.slides/chartdataworkbook/getcell/) son base 0. Este diseño es útil cuando se crea un gráfico con datos predeterminados, pero no asuma que todo gráfico existente lo emplea. Para una presentación cargada, examine las celdas a las que hacen referencia las series, categorías y puntos de datos antes de modificar los valores del libro de trabajo.

Los ajustes del gráfico tienen tres ámbitos diferentes:

- Ajustes a nivel de serie, como [ChartSeries::getFormat](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/getformat/), que proporcionan la apariencia predeterminada para todos los puntos de una serie.
- Ajustes de punto de datos, como [ChartDataPoint::getFormat](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/getformat/), que sobrescriben la apariencia de la serie para un punto concreto.
- Ajustes de grupo que se aplican a series compatibles que pertenecen al mismo [ChartSeriesGroup](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/). Acceda al grupo mediante [ChartSeries::getParentSeriesGroup](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/getparentseriesgroup/) cuando necesite definir opciones como superposición o ancho de separación.

Cuando no se establece un relleno explícito para un punto o una serie, el estilo y el tema del gráfico determinan la apariencia automática. Cuando existen formatos tanto de serie como de punto, el formato del punto tiene prioridad para ese punto.

![serie‑de‑gráfico‑PowerPoint](chart-series-powerpoint.png)

## **Establecer valores de la serie mediante literales numéricos**

Utilice literales numéricos cuando los valores de la serie provengan de datos o cálculos de la aplicación y no necesiten referencias a celdas de la hoja. Llame a [setDataSourceTypeForValues](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapointcollection/setdatasourcetypeforvalues/) con [DataSourceType::DoubleLiterals](https://reference.aspose.com/slides/php-java/aspose.slides/datasourcetype/) antes de asignar a cada punto el resultado de [getValue](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/getvalue/) mediante [setAsLiteralDouble](https://reference.aspose.com/slides/php-java/aspose.slides/doublechartvalue/setasliteraldouble/).

El ajuste de la colección controla el tipo de origen de todos los valores de punto de esa serie. El método [getDataSourceType](https://reference.aspose.com/slides/php-java/aspose.slides/basechartvalue/) de cada valor de punto informa del tipo seleccionado; cámbielo a través del ajuste de la colección. Con `Worksheet`, use [getAsCell](https://reference.aspose.com/slides/php-java/aspose.slides/doublechartvalue/getascell/) para acceder a la celda referenciada. Con `DoubleLiterals`, use [getAsLiteralDouble](https://reference.aspose.com/slides/php-java/aspose.slides/doublechartvalue/getasliteraldouble/) o `setAsLiteralDouble` para leer o escribir el número directamente.

El siguiente ejemplo crea un gráfico de columnas con series y categorías predeterminadas, y asigna valores calculados de 10, 20, etc. a los puntos existentes de su primera serie. Guarda la presentación, la vuelve a abrir y muestra los valores almacenados.

```php
use aspose\slides\ChartType;
use aspose\slides\DataSourceType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 20, 20, 500, 300);
    $series = $chart->getChartData()->getSeries()->get_Item(0);

    $series->getDataPoints()->setDataSourceTypeForValues(DataSourceType::DoubleLiterals);
    $pointCount = java_values($series->getDataPoints()->size());
    for ($i = 0; $i < $pointCount; $i++) {
        $series->getDataPoints()->get_Item($i)->getValue()->setAsLiteralDouble(($i + 1) * 10);
    }

    $presentation->save("numeric_literals.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}

$reopenedPresentation = new Presentation("numeric_literals.pptx");
try {
    $reopenedSlide = $reopenedPresentation->getSlides()->get_Item(0);
    $reopenedChart = $reopenedSlide->getShapes()->get_Item(0);
    $reopenedSeries = $reopenedChart->getChartData()->getSeries()->get_Item(0);
    $pointCount = java_values($reopenedSeries->getDataPoints()->size());
    for ($i = 0; $i < $pointCount; $i++) {
        $point = $reopenedSeries->getDataPoints()->get_Item($i);
        echo java_values($point->getValue()->getAsLiteralDouble()), PHP_EOL;
    }
} finally {
    $reopenedPresentation->dispose();
}
```

El tipo de origen del valor del punto es independiente de [ChartData::getDataSourceType](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getdatasourcetype/), que identifica la configuración interna o externa del libro de trabajo del gráfico. Utilizar literales numéricos no elimina, por sí mismo, el libro de trabajo incrustado. En este ejemplo, el libro sigue disponible para las etiquetas de categoría, los nombres de serie y las demás series. Consulte [Chart Workbook](/slides/es/php-java/chart-workbook/) para la gestión del libro de trabajo.

Para gráficos de dispersión y de burbujas, use [setDataSourceTypeForXValues](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapointcollection/setdatasourcetypeforxvalues/) y [setDataSourceTypeForYValues](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapointcollection/setdatasourcetypeforyvalues/) para elegir los orígenes de [getXValue](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/getxvalue/) y [getYValue](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/getyvalue/). Los gráficos de burbujas también usan [setDataSourceTypeForBubbleSizes](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapointcollection/setdatasourcetypeforbubblesizes/) para [getBubbleSize](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/getbubblesize/). Establezca cada origen aplicable a `DoubleLiterals` antes de asignar números mediante el método `setAsLiteralDouble` de ese valor.

## **Establecer la superposición de la serie del gráfico**

[ChartSeries::getOverlap](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/getoverlap/) indica cuánto se solapan las barras o columnas en un gráfico 2D, desde -100 hasta 100 por ciento. Es una proyección de solo lectura del ajuste en el grupo de series padre. Utilice [ChartSeriesGroup::setOverlap](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/setoverlap/) para actualizar todas las series compatibles en ese grupo. Esta opción se aplica a tipos de gráfico que muestran barras o columnas agrupadas; no afecta a grupos de series no relacionados en un gráfico combinado.

El siguiente ejemplo establece la superposición para el grupo que contiene la primera serie:

```php
$firstSlideIndex = 0;
$firstSeriesIndex = 0;
$overlapPercent = 30;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item($firstSlideIndex);

    // El nuevo gráfico contiene series de muestra, categorías y valores.
    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 20, 20, 500, 200);

    $series = $chart->getChartData()->getSeries()->get_Item($firstSeriesIndex);
    $series->getParentSeriesGroup()->setOverlap($overlapPercent);

    $presentation->save("series_overlap.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

El resultado:

![superposición‑de‑series](series_overlap.png)

## **Cambiar el color de relleno de la serie**

Utilice [ChartSeries::getFormat](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/getformat/) para establecer el relleno predeterminado de una serie completa. Si un punto ya tiene un relleno explícito, su ajuste [ChartDataPoint::getFormat](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/getformat/) sobrescribe el relleno de la serie para ese punto.

El siguiente ejemplo aplica un relleno sólido azul a la primera serie:

```php
$firstSlideIndex = 0;
$firstSeriesIndex = 0;
$blueColor = java("java.awt.Color")->BLUE;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item($firstSlideIndex);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 20, 20, 500, 200);

    $series = $chart->getChartData()->getSeries()->get_Item($firstSeriesIndex);
    $series->getFormat()->getFill()->setFillType(FillType::Solid);
    $series->getFormat()->getFill()->getSolidFillColor()->setColor($blueColor);

    $presentation->save("series_color.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

El resultado:

![color‑de‑la‑serie](series_color.png)

## **Cambiar el nombre de la serie**

El nombre de una serie se almacena en el libro de datos del gráfico y normalmente se muestra en la leyenda. En el libro predeterminado creado para un gráfico de columnas agrupadas, la celda B1 está en la fila 0, columna 1 y contiene el nombre de la primera serie. Las variables nombradas en el siguiente ejemplo hacen explícita esa estructura:

```php
$firstSlideIndex = 0;
$worksheetIndex = 0;
$seriesNameRowIndex = 0;
$firstSeriesColumnIndex = 1;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item($firstSlideIndex);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 20, 20, 500, 200);

    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $seriesNameCell = $workbook->getCell($worksheetIndex, $seriesNameRowIndex, $firstSeriesColumnIndex);
    $seriesNameCell->setValue("Revenue");

    $presentation->save("series_name.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

También puede actualizar la celda ya referenciada por [ChartSeries::getName](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/getname/). Este enfoque evita suponer una fila y columna determinadas en un gráfico existente:

```php
$firstSlideIndex = 0;
$firstSeriesIndex = 0;
$firstNameCellIndex = 0;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item($firstSlideIndex);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 20, 20, 500, 200);

    $series = $chart->getChartData()->getSeries()->get_Item($firstSeriesIndex);
    $seriesNameCell = $series->getName()->getAsCells()->get_Item($firstNameCellIndex);
    $seriesNameCell->setValue("Revenue");

    $presentation->save("series_name.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

El resultado:

![nombre‑de‑la‑serie](series_name.png)

### **Crear una serie con un nombre a partir de varias celdas**

Un nombre de serie compuesto es útil cuando el nombre del producto y el período del informe se guardan en celdas distintas del libro. Por ejemplo, puede combinar `Product A` en B1 y `2026` en C1 en un único nombre de serie manteniendo ambas partes enlazadas a sus celdas de origen.

Utilice [ChartDataWorkbook::getCellCollection](https://reference.aspose.com/slides/php-java/aspose.slides/chartdataworkbook/getcellcollection/) para obtener el rango de nombres y páselo a [ChartSeriesCollection::add](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriescollection/add/). El argumento `skipHiddenCells` controla si se incluyen las celdas ocultas: `true` las excluye, `false` las incluye. Este ejemplo usa `false` para incluir todas las celdas del rango de nombres.

El siguiente ejemplo crea una presentación con una serie y dos puntos de datos. Las celdas B1:C1 suministran solo el nombre de la serie; A2:A3 suministran las etiquetas de categoría, y B2:B3 los valores numéricos.

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 620, 180);

    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();
    $chart->setLegend(true);

    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $workbook->clear(0);

    // Estas dos celdas proporcionan el nombre de la serie.
    $workbook->getCell(0, 0, 1, "Product A");
    $workbook->getCell(0, 0, 2, "2026");
    $nameCells = $workbook->getCellCollection('Sheet1!$B$1:$C$1', false);
    $series = $chart->getChartData()->getSeries()->add($nameCells, ChartType::ClusteredColumn);

    // Celdas separadas proporcionan las categorías y los puntos de datos numéricos.
    $northCategory = $workbook->getCell(0, 1, 0, "North");
    $southCategory = $workbook->getCell(0, 2, 0, "South");
    $chart->getChartData()->getCategories()->add($northCategory);
    $chart->getChartData()->getCategories()->add($southCategory);
    $northValue = $workbook->getCell(0, 1, 1, 120);
    $southValue = $workbook->getCell(0, 2, 1, 150);
    $series->getDataPoints()->addDataPointForBarSeries($northValue);
    $series->getDataPoints()->addDataPointForBarSeries($southValue);

    $presentation->save("composite_series_name.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

El nombre resultante de la serie es `Product A 2026`, con un espacio entre los dos valores de celda. La leyenda lo muestra como una única entrada para ambas columnas. La imagen a continuación ilustra el resultado:

![gráfico‑de‑columnas‑con‑valores‑Norte‑y‑Sur‑y‑el‑nombre‑compuesto Product A 2026 en la leyenda](composite_series_name.png)

## **Obtener el color de relleno automático de la serie**

[ChartSeries::getAutomaticSeriesColor](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/getautomaticseriescolor/) devuelve el color calculado a partir del índice de la serie y del estilo del gráfico. Este es el color que se usa cuando el relleno de la serie no se ha definido explícitamente. Llamar al método lee el color calculado; no asigna un nuevo relleno.

El siguiente ejemplo muestra el color automático de cada serie predeterminada:

```php
$firstSlideIndex = 0;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item($firstSlideIndex);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 20, 20, 500, 200);

    $seriesCount = java_values($chart->getChartData()->getSeries()->size());
    for ($seriesIndex = 0; $seriesIndex < $seriesCount; $seriesIndex++) {
        $series = $chart->getChartData()->getSeries()->get_Item($seriesIndex);
        $automaticColor = $series->getAutomaticSeriesColor();
        $red = java_values($automaticColor->getRed());
        $green = java_values($automaticColor->getGreen());
        $blue = java_values($automaticColor->getBlue());
        echo "Series " . $seriesIndex . ": java.awt.Color[r=" . $red . ",g=" . $green . ",b=" . $blue . "]" . PHP_EOL;
    }
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
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

Para series de barras, columnas y burbujas, [ChartSeries::setInvertIfNegative](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/setinvertifnegative/) puede mostrar valores negativos con un relleno diferente. Establezca el relleno regular de la serie a sólido, habilite la inversión y asigne el color para valores negativos mediante [ChartSeries::getInvertedSolidFillColor](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/getinvertedsolidfillcolor/). Los números negativos permanecen sin cambios en el libro; solo varía su color de visualización.

El siguiente ejemplo reemplaza los datos del gráfico predeterminados por una serie. La fila 0 de la hoja contiene el nombre de la serie, la columna 0 contiene los nombres de categoría y la columna 1 los valores:

```php
$firstSlideIndex = 0;
$worksheetIndex = 0;
$headerRowIndex = 0;
$categoryColumnIndex = 0;
$firstSeriesColumnIndex = 1;
$firstDataRowIndex = 1;

$categoryNames = ["Category 1", "Category 2", "Category 3"];
$seriesValues = [-20, 50, -30];
$redColor = java("java.awt.Color")->RED;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item($firstSlideIndex);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 20, 20, 500, 200);
    $chartData = $chart->getChartData();
    $workbook = $chartData->getChartDataWorkbook();

    $chartData->getSeries()->clear();
    $chartData->getCategories()->clear();

    $seriesNameCell = $workbook->getCell($worksheetIndex, $headerRowIndex, $firstSeriesColumnIndex, "Series 1");
    $chartType = $chart->getType();
    $series = $chartData->getSeries()->add($seriesNameCell, $chartType);

    $categoryCount = count($categoryNames);
    for ($categoryIndex = 0; $categoryIndex < $categoryCount; $categoryIndex++) {
        $dataRowIndex = $firstDataRowIndex + $categoryIndex;
        $categoryName = $categoryNames[$categoryIndex];
        $seriesValue = $seriesValues[$categoryIndex];

        $categoryCell = $workbook->getCell($worksheetIndex, $dataRowIndex, $categoryColumnIndex, $categoryName);
        $chartData->getCategories()->add($categoryCell);

        $valueCell = $workbook->getCell($worksheetIndex, $dataRowIndex, $firstSeriesColumnIndex, $seriesValue);
        $series->getDataPoints()->addDataPointForBarSeries($valueCell);
    }

    $automaticSeriesColor = $series->getAutomaticSeriesColor();
    $series->getFormat()->getFill()->setFillType(FillType::Solid);
    $series->getFormat()->getFill()->getSolidFillColor()->setColor($automaticSeriesColor);
    $series->setInvertIfNegative(true);
    $series->getInvertedSolidFillColor()->setColor($redColor);

    $presentation->save("inverted_solid_fill_color.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

El resultado:

![relleno‑sólido‑invertido](inverted_solid_fill_color.png)

Puede habilitar la inversión para un solo punto mediante [ChartDataPoint::setInvertIfNegative](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/setinvertifnegative/). En el siguiente ejemplo, la inversión está desactivada para la serie y activada solo para el punto seleccionado. Al punto también se le asigna un valor negativo para que el efecto sea visible:

```php
$firstSlideIndex = 0;
$firstSeriesIndex = 0;
$targetDataPointIndex = 2;
$negativeValue = -30;
$redColor = java("java.awt.Color")->RED;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item($firstSlideIndex);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 20, 20, 500, 200);

    $series = $chart->getChartData()->getSeries()->get_Item($firstSeriesIndex);
    $automaticSeriesColor = $series->getAutomaticSeriesColor();
    $series->getFormat()->getFill()->setFillType(FillType::Solid);
    $series->getFormat()->getFill()->getSolidFillColor()->setColor($automaticSeriesColor);
    $series->getInvertedSolidFillColor()->setColor($redColor);
    $series->setInvertIfNegative(false);

    $dataPoint = $series->getDataPoints()->get_Item($targetDataPointIndex);
    $dataPoint->getValue()->getAsCell()->setValue($negativeValue);
    $dataPoint->setInvertIfNegative(true);

    $presentation->save("data_point_invert_color_if_negative.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

## **Borrar el valor de un punto de datos específico**

Para dejar un punto vacío sin eliminar los demás, establezca su celda del libro subyacente a `null`. En un gráfico de columnas, el valor trazado está disponible mediante [ChartDataPoint::getValue](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/getvalue/). El punto permanece en la misma posición de categoría, pero el gráfico lo trata como vacío según la configuración de valores en blanco del gráfico.

El siguiente ejemplo borra solo el segundo punto de la primera serie:

```php
$firstSlideIndex = 0;
$firstSeriesIndex = 0;
$targetDataPointIndex = 1;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item($firstSlideIndex);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 20, 20, 500, 200);

    $series = $chart->getChartData()->getSeries()->get_Item($firstSeriesIndex);
    $dataPoint = $series->getDataPoints()->get_Item($targetDataPointIndex);
    $dataPoint->getValue()->getAsCell()->setValue(null);

    $presentation->save("clear_data_point_value.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

Los gráficos de dispersión usan celdas X y Y separadas, y los de burbujas también utilizan una celda de tamaño. Borre solo la celda que representa el valor que desea eliminar. No llame a [ChartDataPointCollection::clear](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapointcollection/clear/) cuando desee conservar los demás puntos, pues ese método elimina todos los puntos de la colección.

## **Controlar la visualización de celdas vacías**

Las celdas ocultas que contienen valores son un caso distinto de las celdas vacías. Para incluir o excluir datos de filas y columnas ocultas, consulte [Include Data from Hidden Rows and Columns](/slides/es/php-java/chart-workbook/#include-data-from-hidden-rows-and-columns).

Una celda de libro vacía representa datos ausentes; una celda que contiene `0` representa un valor numérico conocido. Llame a [ChartDataCell::setValue](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatacell/setvalue/) con `null` para dejar una celda vacía. Un cero numérico sigue siendo cero independientemente de la configuración de celdas en blanco.

Utilice [Chart::setDisplayBlanksAs](https://reference.aspose.com/slides/php-java/aspose.slides/chart/setdisplayblanksas/) para elegir cómo el gráfico muestra las celdas vacías. Este ajuste se aplica a todo el gráfico. Cambia la forma en que se trazan los vacíos, sin rellenar la celda del libro con cero o con un valor interpolado.

El siguiente ejemplo autocontenido crea un gráfico de líneas con una serie, borra el valor del Día 3 y guarda el mismo gráfico con cada modo. No se necesita archivo de entrada. El [ChartDataWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdataworkbook/) usa la hoja 0, la columna 0 para las etiquetas de categoría y la columna 1 para los valores; la fila 0 contiene el nombre de la serie. Los datos finales son `10, 20, empty, 30, 40`.

```php
use aspose\slides\ChartType;
use aspose\slides\DisplayBlanksAsType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::LineWithMarkers, 40, 40, 640, 400);
    $chartData = $chart->getChartData();
    $workbook = $chartData->getChartDataWorkbook();

    $chartData->getSeries()->clear();
    $chartData->getCategories()->clear();

    $seriesNameCell = $workbook->getCell(0, 0, 1, "Measurements");
    $series = $chartData->getSeries()->add($seriesNameCell, $chart->getType());
    $values = [10, 20, 25, 30, 40];

    for ($i = 0; $i < count($values); $i++) {
        $categoryCell = $workbook->getCell(0, $i + 1, 0, "Day " . ($i + 1));
        $chartData->getCategories()->add($categoryCell);
        $valueCell = $workbook->getCell(0, $i + 1, 1, $values[$i]);
        $series->getDataPoints()->addDataPointForLineSeries($valueCell);
    }

    // Dejar el día 3 realmente vacío, manteniendo su categoría y punto de datos.
    $workbook->getCell(0, 3, 1)->setValue(null);

    $modes = [DisplayBlanksAsType::Gap, DisplayBlanksAsType::Zero, DisplayBlanksAsType::Span];
    $modeNames = ["Gap", "Zero", "Span"];
    for ($i = 0; $i < count($modes); $i++) {
        $chart->setDisplayBlanksAs($modes[$i]);
        $presentation->save("empty_cells_" . $modeNames[$i] . ".pptx", SaveFormat::Pptx);
    }
} finally {
    $presentation->dispose();
}
```

Cada archivo de salida almacena el modo asignado antes de guardar: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx` y `empty_cells_Span.pptx`. Para guardar solo una versión, asigne el modo deseado y guarde la presentación una única vez en lugar de iterar sobre los modos.

La comparación a continuación muestra los mismos datos en los tres archivos. El Día 3 está vacío en el libro en todos los casos:

![Gráficos de líneas con datos idénticos: Gap interrumpe la línea en el Día 3, Zero lleva la línea a cero y Span conecta el Día 2 con el Día 4.](display_blanks_as.png)

El efecto visible depende del tipo de gráfico. Un gráfico de líneas permite comparar fácilmente los tres modos. Los gráficos de barras y columnas no tienen línea que conectar una categoría ausente, por lo que `Span` no puede producir el segmento de conexión mostrado arriba; una columna ausente y una columna de altura cero también pueden parecer iguales. De forma similar, un gráfico de dispersión solo con marcadores no tiene línea de conexión. No espere tres resultados distintos para todos los tipos de gráfico; compruebe la salida para el tipo que utilice.

## **Establecer el ancho de separación de la serie**

El ancho de separación es el espacio entre grupos adyacentes de barras o columnas, expresado como porcentaje del ancho de la barra o columna. Al igual que la superposición, pertenece al grupo de series padre y no a una serie individual. Llame a [ChartSeriesGroup::setGapWidth](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/setgapwidth/) una sola vez para el grupo. Un valor mayor crea más espacio entre grupos; un valor menor los hace más densos.

El siguiente ejemplo cambia el ancho de separación y guarda solo la presentación final:

```php
$firstSlideIndex = 0;
$firstSeriesIndex = 0;
$gapWidthPercent = 30;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item($firstSlideIndex);

    $chart = $slide->getShapes()->addChart(ChartType::StackedColumn, 20, 20, 500, 200);

    $series = $chart->getChartData()->getSeries()->get_Item($firstSeriesIndex);
    $series->getParentSeriesGroup()->setGapWidth($gapWidthPercent);

    $presentation->save("gap_width_30.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

El resultado:

![ancho‑de‑separación](gap_width.png)

## **FAQ**

**¿Qué tipos de gráfico admiten series de datos?**

Todos los tipos de gráfico representados por la enumeración [ChartType](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/) utilizan datos de gráfico, pero sus series no comparten la misma estructura de valores ni los mismos ajustes. Por ejemplo, los gráficos de categorías usan categorías y valores, los de dispersión usan valores X e Y, y los de burbujas añaden tamaños de burbuja. Utilice el método de creación de puntos de datos que corresponda al tipo de serie. Los ajustes como superposición y ancho de separación solo se aplican a grupos de barras o columnas compatibles.

**¿Qué es un grupo de series de gráfico?**

Un [ChartSeriesGroup](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/) contiene series compatibles que comparten ajustes de trazado a nivel de grupo. Un gráfico combinado puede contener más de un grupo, de modo que cambiar el grupo al que se accede a través de una serie no necesariamente modifica todas las series del gráfico.

**¿Un gráfico recién creado contiene datos predeterminados?**

Sí. Por defecto, [ShapeCollection.addChart](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addchart/) crea series, categorías y valores de muestra. Puede editar esas celdas o vaciar tanto las colecciones de series como de categorías antes de añadir un conjunto de datos totalmente personalizado. También existe una sobrecarga que crea un gráfico sin datos predeterminados.

**¿Cómo se conectan los objetos del gráfico a las celdas del libro?**

Los nombres de serie, las etiquetas de categoría y los valores de los puntos de datos hacen referencia a celdas en un [ChartDataWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdataworkbook/). Cambiar una celda referenciada actualiza el elemento del gráfico correspondiente. Cuando construye datos personalizados, mantenga alineadas las filas de categorías y las filas de valores de serie para que cada punto se trace bajo la categoría prevista.

**¿Cómo borro un punto en lugar de toda la serie?**

Establezca la celda de valor correspondiente a `null` para conservar la posición de categoría del punto como vacío. Use [ChartDataPointCollection::clear](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapointcollection/clear/) solo cuando pretenda eliminar todos los puntos de esa serie. Si también elimina categorías, actualice cada serie para que sus valores sigan alineados con la colección de categorías.

**¿Cómo se visualizan los puntos vacíos?**

El resultado depende del tipo de gráfico y del valor configurado mediante [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/php-java/aspose.slides/chart/setdisplayblanksas/). Los gráficos compatibles pueden mostrar los vacíos como huecos, como valores cero o conectando los puntos vecinos. Elija la configuración que coincida con el significado de datos ausentes en su presentación. Consulte [Controlar la visualización de celdas vacías](#controlar-la-visualización-de-celdas-vacías) para un ejemplo completo y una comparación visual.

**¿Cómo se formatean los valores negativos?**

Para series de barras, columnas y burbujas compatibles, llame a [ChartSeries::setInvertIfNegative](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/setinvertifnegative/) y establezca el color devuelto por [ChartSeries::getInvertedSolidFillColor](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/getinvertedsolidfillcolor/). Puede sobrescribir el comportamiento para un punto individual con [ChartDataPoint::setInvertIfNegative](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/setinvertifnegative/). Estos métodos afectan al formateo, no a los valores numéricos almacenados.

**¿Qué formateo prevalece cuando tanto una serie como un punto están formateados?**

El formateo explícito del punto de datos tiene prioridad para ese punto. Los demás puntos continúan usando el formato explícito de la serie o, cuando no hay formato de serie definido, el estilo y tema automáticos del gráfico. Los ajustes de grupo, como superposición y ancho de separación, controlan la disposición y no sobrescriben el formateo a nivel de punto.

**¿Existe un límite al número de series que puede contener un gráfico?**

Aspose.Slides no impone un límite fijo independiente de series. En la práctica, las restricciones del archivo de presentación, la memoria disponible, el tiempo de renderizado y la legibilidad del gráfico determinan un límite razonable.

**¿Qué debo modificar cuando las columnas están demasiado juntas o demasiado separadas?**

Llame a [ChartSeriesGroup::setGapWidth](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/setgapwidth/) en el grupo de series padre correspondiente. Aumente el valor para ensanchar el espacio entre grupos, o disminúyalo para acercar los grupos.