---
title: Gestionar series de datos de gráficos en presentaciones en PHP
linktitle: Series de datos
type: docs
url: /es/php-java/chart-series/
keywords:
- series de gráficos
- solapamiento de series
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
description: "Aprenda a gestionar series de gráficos, puntos de datos, celdas de libro de trabajo, formato, solapamiento, ancho del espacio y valores negativos en presentaciones con PHP."
---
## **Visión general**

Un gráfico almacena sus datos trazados en un libro de datos del gráfico. Un [ChartSeries](https://reference.aspose.com/slides/es/php-java/aspose.slides/chartseries/) representa un conjunto de valores relacionados, y cada [ChartDataPoint](https://reference.aspose.com/slides/es/php-java/aspose.slides/chartdatapoint/) de la serie hace referencia a una o más celdas del libro. Los objetos [ChartCategory](https://reference.aspose.com/slides/es/php-java/aspose.slides/chartcategory/) proporcionan las etiquetas o valores de agrupación compartidos por las series. Por lo tanto, el nombre de la serie, las categorías y los valores de los puntos están conectados a objetos [ChartDataCell](https://reference.aspose.com/slides/es/php-java/aspose.slides/chartdatacell/) en lugar de almacenarse sólo como texto de presentación.

Para un gráfico de categorías típico, el libro de datos predeterminado usa la fila 0 para los nombres de series, la columna 0 para los nombres de categorías y el resto de celdas para los valores de las series. Los índices de hoja, fila y columna que se pasan a [ChartDataWorkbook.getCell](https://reference.aspose.com/slides/es/php-java/aspose.slides/chartdataworkbook/#getCell) son basados en cero. Este esquema es útil cuando crea un gráfico con datos predeterminados, pero no asuma que todos los gráficos existentes lo utilizan. Para una presentación cargada, inspeccione las celdas referenciadas por las series, categorías y puntos de datos antes de modificar los valores del libro.

Los ajustes del gráfico tienen tres ámbitos diferentes:

- Ajustes a nivel de serie, como [ChartSeries.getFormat](https://reference.aspose.com/slides/es/php-java/aspose.slides/chartseries/#getFormat), que proporcionan el aspecto predeterminado para todos los puntos de una serie.
- Ajustes a nivel de punto de datos, como [ChartDataPoint.getFormat](https://reference.aspose.com/slides/es/php-java/aspose.slides/chartdatapoint/#getFormat), que sustituyen el aspecto de la serie para un punto.
- Los ajustes de grupo se aplican a series compatibles que pertenecen al mismo [ChartSeriesGroup](https://reference.aspose.com/slides/es/php-java/aspose.slides/chartseriesgroup/). Acceda al grupo mediante [ChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/es/php-java/aspose.slides/chartseries/#getParentSeriesGroup) cuando necesite establecer opciones como solapamiento o ancho del espacio.

Cuando no se establece un relleno explícito de punto o serie, el estilo y el tema del gráfico determinan el aspecto automático. Cuando existen tanto formato de serie como de punto, el formato del punto tiene precedencia para ese punto.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **Establecer el solapamiento de la serie del gráfico**

[ChartSeries.getOverlap](https://reference.aspose.com/slides/es/php-java/aspose.slides/chartseries/#getOverlap) indica cuánto se solapan las barras o columnas en un gráfico 2D, de -100 a 100 por ciento. Es una proyección de solo lectura del ajuste en el grupo de series padre. Utilice [ChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/es/php-java/aspose.slides/chartseriesgroup/#setOverlap) para actualizar todas las series compatibles en ese grupo. Esta opción se aplica a los tipos de gráfico que muestran barras o columnas agrupadas; no afecta a los grupos de series no relacionados en un gráfico combinado.

El siguiente ejemplo establece el solapamiento para el grupo que contiene la primera serie:

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

![El solapamiento de la serie](series_overlap.png)

## **Cambiar el color de relleno de la serie**

Utilice [ChartSeries.getFormat](https://reference.aspose.com/slides/es/php-java/aspose.slides/chartseries/#getFormat) para definir el relleno predeterminado de una serie completa. Si un punto ya tiene un relleno explícito, su ajuste [ChartDataPoint.getFormat](https://reference.aspose.com/slides/es/php-java/aspose.slides/chartdatapoint/#getFormat) sustituye el relleno de la serie para ese punto.

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

![El color de la serie](series_color.png)

## **Cambiar el nombre de la serie**

El nombre de una serie se almacena en el libro de datos del gráfico y normalmente se muestra en la leyenda. En el libro predeterminado creado para un gráfico de columnas agrupadas, la celda B1 está en la fila 0, columna 1 y contiene el nombre de la primera serie. Las variables con nombre en el siguiente ejemplo hacen explícita esa estructura:

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

También puede actualizar la celda ya referenciada por [ChartSeries.getName](https://reference.aspose.com/slides/es/php-java/aspose.slides/chartseries/#getName). Este enfoque evita suponer una fila y columna particulares en un gráfico existente:

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

![El nombre de la serie](series_name.png)

## **Obtener el color de relleno automático de la serie**

[ChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/es/php-java/aspose.slides/chartseries/#getAutomaticSeriesColor) devuelve el color calculado a partir del índice de la serie y el estilo del gráfico. Este es el color que se usa cuando el relleno de la serie no se ha definido explícitamente. Llamar al método lee el color calculado; no asigna un nuevo relleno.

El siguiente ejemplo imprime el color automático de cada serie predeterminada:

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

Los colores exactos dependen del estilo y el tema del gráfico.

## **Establecer color de relleno invertido para una serie del gráfico**

Para series de barras, columnas y burbujas, [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/es/php-java/aspose.slides/chartseries/#setInvertIfNegative) puede mostrar los valores negativos con un relleno diferente. Establezca el relleno regular de la serie como sólido, habilite la inversión y asigne el color de valor negativo mediante [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/es/php-java/aspose.slides/chartseries/#getInvertedSolidFillColor). Los números negativos permanecen sin cambios en el libro; solo cambia su color de visualización.

El siguiente ejemplo sustituye los datos predeterminados del gráfico por una serie. La fila 0 de la hoja contiene el nombre de la serie, la columna 0 contiene los nombres de categoría y la columna 1 contiene los valores:

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

![El color de relleno sólido invertido](inverted_solid_fill_color.png)

Puede habilitar la inversión para un punto mediante [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/es/php-java/aspose.slides/chartdatapoint/#setInvertIfNegative). En el siguiente ejemplo, la inversión está desactivada para la serie y habilitada solo para el punto seleccionado. Al punto también se le asigna un valor negativo para que el efecto sea visible:

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

Para dejar un punto vacío sin eliminar los demás, establezca su celda de respaldo del libro en `null`. En un gráfico de columnas, el valor trazado está disponible mediante [ChartDataPoint.getValue](https://reference.aspose.com/slides/es/php-java/aspose.slides/chartdatapoint/#getValue). El punto de datos permanece en la misma posición de categoría, pero el gráfico trata su valor como vacío según la configuración de valores en blanco del gráfico.

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

Los gráficos de dispersión utilizan celdas X e Y separadas, y los gráficos de burbujas también usan una celda de tamaño. Borre solo la celda que representa el valor que desea eliminar. No llame a [ChartDataPointCollection.clear](https://reference.aspose.com/slides/es/php-java/aspose.slides/chartdatapointcollection/#clear) cuando quiera conservar los demás puntos, porque ese método elimina todos los puntos de datos de la colección.

## **Controlar la visualización de celdas vacías**

Una celda de libro vacía representa datos ausentes; una celda que contiene `0` representa un valor numérico conocido. Llame a [ChartDataCell::setValue](https://reference.aspose.com/slides/es/php-java/aspose.slides/chartdatacell/#setValue) con `null` para vaciar una celda. Un cero numérico sigue siendo cero sin importar la configuración de celdas vacías.

Utilice [Chart::setDisplayBlanksAs](https://reference.aspose.com/slides/es/php-java/aspose.slides/chart/#setDisplayBlanksAs) para elegir cómo muestra el gráfico las celdas vacías. Esta configuración se aplica a todo el gráfico. Cambia la forma en que se trazan los vacíos, sin rellenar la celda vacía del libro con cero o con un valor interpolado.

El siguiente ejemplo autónomo crea un gráfico de líneas con una serie, borra el valor del Día 3 y guarda el mismo gráfico con cada modo. No se requiere archivo de entrada. El [ChartDataWorkbook](https://reference.aspose.com/slides/es/php-java/aspose.slides/chartdataworkbook/) usa la hoja 0, columna 0 para las etiquetas de categoría y columna 1 para los valores; la fila 0 contiene el nombre de la serie. Los datos finales son `10, 20, empty, 30, 40`.

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

    // Dejar el Día 3 realmente vacío, manteniendo su categoría y punto de datos.
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

Cada archivo de salida almacena el modo asignado antes de guardar: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx` y `empty_cells_Span.pptx`. Para guardar solo una versión, asigne el modo deseado y guarde la presentación una vez en lugar de iterar sobre los modos.

La comparación siguiente muestra los mismos datos en los tres archivos. El Día 3 está vacío en el libro en todos los casos:

![Gráficos de líneas con datos idénticos: Gap interrumpe la línea en el Día 3, Zero lleva la línea a cero, y Span conecta el Día 2 con el Día 4.](display_blanks_as.png)

El efecto visible depende del tipo de gráfico. Un gráfico de líneas facilita la comparación de los tres modos. Los gráficos de barras y columnas no tienen línea que conectar a través de una categoría faltante, por lo que `Span` no puede producir el segmento de conexión mostrado arriba; una columna faltante y una columna de altura cero también pueden parecer iguales. De forma similar, un gráfico de dispersión solo con marcadores no tiene línea de conexión. No espere tres resultados distintos para cada tipo de gráfico; compruebe la salida para el tipo que utilice.

## **Establecer el ancho del espacio entre series**

El ancho del espacio es el intervalo entre conglomerados adyacentes de barras o columnas, expresado como porcentaje del ancho de la barra o columna. Al igual que el solapamiento, pertenece al grupo de series padre y no a una sola serie. Llame a [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/es/php-java/aspose.slides/chartseriesgroup/#setGapWidth) una vez para el grupo. Un valor mayor crea más espacio entre conglomerados; un valor menor los hace más densos.

El siguiente ejemplo cambia el ancho del espacio y guarda solo la presentación final:

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

![El ancho del espacio](gap_width.png)

## **Preguntas frecuentes**

**¿Qué tipos de gráficos admiten series de datos?**

Todos los tipos de gráficos representados por la enumeración [ChartType](https://reference.aspose.com/slides/es/php-java/aspose.slides/charttype/) utilizan datos de gráfico, pero sus series no comparten la misma estructura de valores ni los mismos ajustes. Por ejemplo, los gráficos de categorías usan categorías y valores, los gráficos de dispersión usan valores X y Y, y los gráficos de burbujas añaden tamaños de burbuja. Utilice el método de creación de puntos de datos que coincida con el tipo de serie. Opciones como solapamiento y ancho del espacio se aplican solo a grupos de barras o columnas compatibles.

**¿Qué es un grupo de series de gráfico?**

Un [ChartSeriesGroup](https://reference.aspose.com/slides/es/php-java/aspose.slides/chartseriesgroup/) contiene series compatibles que comparten ajustes de trazado a nivel de grupo. Un gráfico combinado puede contener más de un grupo, de modo que cambiar el grupo alcanzado a través de una serie no necesariamente modifica todas las series del gráfico.

**¿Un gráfico recién creado contiene datos predeterminados?**

Sí. Por defecto, [ShapeCollection.addChart](https://reference.aspose.com/slides/es/php-java/aspose.slides/shapecollection/#addChart) crea series, categorías y valores de ejemplo. Puede editar esas celdas o borrar tanto las colecciones de series como de categorías antes de añadir un conjunto de datos totalmente personalizado. Una sobrecarga también puede crear un gráfico sin datos predeterminados.

**¿Cómo están conectados los objetos del gráfico a las celdas del libro?**

Los nombres de series, las etiquetas de categoría y los valores de los puntos de datos hacen referencia a celdas en un [ChartDataWorkbook](https://reference.aspose.com/slides/es/php-java/aspose.slides/chartdataworkbook/). Cambiar una celda referenciada actualiza el elemento del gráfico correspondiente. Cuando construye datos personalizados, mantenga alineadas las filas de categorías y las filas de valores de series para que cada punto se trace bajo la categoría prevista.

**¿Cómo borro un punto en lugar de toda la serie?**

Establezca la celda de valor correspondiente en `null` para conservar la posición de categoría del punto como punto vacío. Utilice [ChartDataPointCollection.clear](https://reference.aspose.com/slides/es/php-java/aspose.slides/chartdatapointcollection/#clear) solo cuando pretenda eliminar todos los puntos de esa serie. Si también elimina categorías, actualice cada serie para que sus valores sigan alineados con la colección de categorías.

**¿Cómo se muestran los puntos vacíos?**

El resultado depende del tipo de gráfico y del valor configurado mediante [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/es/php-java/aspose.slides/chart/#setDisplayBlanksAs). Los gráficos compatibles pueden mostrar los vacíos como huecos, como valores cero o conectando los puntos vecinos. Elija la configuración que coincida con el significado de los datos faltantes en su presentación. Consulte **Controlar la visualización de celdas vacías** para un ejemplo completo y una comparación visual.

**¿Cómo se formatean los valores negativos?**

Para series de barras, columnas y burbujas admitidas, llame a [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/es/php-java/aspose.slides/chartseries/#setInvertIfNegative) y establezca el color devuelto por [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/es/php-java/aspose.slides/chartseries/#getInvertedSolidFillColor). Puede sobrescribir el comportamiento para un punto individual con [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/es/php-java/aspose.slides/chartdatapoint/#setInvertIfNegative). Estos métodos afectan al formato, no a los valores numéricos almacenados.

**¿Qué formato prevalece cuando tanto una serie como un punto están formateados?**

El formato explícito del punto de datos tiene precedencia para ese punto. Los demás puntos continúan usando el formato explícito de la serie o, cuando el formato de serie no está definido, el estilo y tema automáticos del gráfico. Los ajustes de grupo, como solapamiento y ancho del espacio, controlan la disposición y no son sobrescrituras de formato a nivel de punto.

**¿Existe un límite en la cantidad de series que puede contener un gráfico?**

Aspose.Slides no impone un límite fijo separado de series. En la práctica, las restricciones del archivo de presentación, la memoria disponible, el tiempo de renderizado y la legibilidad del gráfico determinan un límite útil.

**¿Qué debo modificar cuando las columnas están demasiado juntas o demasiado separadas?**

Llame a [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/es/php-java/aspose.slides/chartseriesgroup/#setGapWidth) en el grupo de series padre correspondiente. Aumente el valor para ensanchar el espacio entre conglomerados, o disminúyalo para acercarlos.