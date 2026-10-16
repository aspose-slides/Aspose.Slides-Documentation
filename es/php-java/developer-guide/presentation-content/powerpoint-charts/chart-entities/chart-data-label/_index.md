---
title: Gestionar etiquetas de datos de gráficos en presentaciones usando PHP
linktitle: Etiqueta de datos
type: docs
url: /es/php-java/chart-data-label/
keywords:
- gráfico
- etiqueta de datos
- precisión de datos
- porcentaje
- distancia de la etiqueta
- ubicación de la etiqueta
- PowerPoint
- presentación
- PHP
- Aspose.Slides
description: "Aprenda a añadir y formatear etiquetas de datos de gráficos en presentaciones de PowerPoint usando Aspose.Slides para PHP a través de Java para diapositivas más atractivas."
---
## **Introducción**

Las etiquetas de datos muestran información sobre las series del gráfico y los puntos de datos individuales, ayudando a los lectores a identificar valores y comprender el gráfico. Este artículo explica cómo formatear valores, mostrar porcentajes, leer el texto de la etiqueta, controlar las etiquetas más allá del máximo del eje, ajustar el espaciado de las etiquetas del eje de categorías y posicionar las etiquetas de los gráficos circulares.

## **Establecer precisión de los datos en las etiquetas de datos del gráfico**

Utilice [setNumberFormatOfValues](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/setnumberformatofvalues/) para formatear los valores de la serie. Este ejemplo crea un gráfico de líneas con datos predeterminados, muestra su tabla de datos y habilita las etiquetas de valores para la primera serie. El formato `#,##0.00` muestra un separador de miles y dos decimales sin cambiar los valores subyacentes.

```php
use aspose\slides\Presentation;
use aspose\slides\ChartType;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Line, 50, 50, 450, 300);
    $chart->setDataTable(true);

    $series = $chart->getChartData()->getSeries()->get_Item(0);
    $series->setNumberFormatOfValues("#,##0.00");
    $series->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);

    $presentation->save("PrecisionOfDatalabels_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Mostrar porcentaje como etiquetas**

Para un gráfico de columnas apiladas, calcule cada valor como porcentaje del total de su categoría y asigne el texto al marco de texto devuelto por [getTextFrameForOverriding](https://reference.aspose.com/slides/php-java/aspose.slides/datalabel/gettextframeforoverriding/). Este ejemplo usa los datos predeterminados del gráfico y muestra porcentajes con dos decimales en una fuente de 8 pt. Las categorías con un total de cero se omiten para evitar una división por cero. Recalcule el texto de la etiqueta personalizada si los datos del gráfico cambian.

```php
use aspose\slides\Presentation;
use aspose\slides\ChartType;
use aspose\slides\Portion;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::StackedColumn, 20, 20, 400, 400);

    $categoryCount = java_values($chart->getChartData()->getCategories()->size());
    $categoryTotals = array_fill(0, $categoryCount, 0.0);
    for ($k = 0; $k < $categoryCount; $k++) {
        for ($i = 0; $i < java_values($chart->getChartData()->getSeries()->size()); $i++) {
            $series = $chart->getChartData()->getSeries()->get_Item($i);
            $pointValue = java_values($series->getDataPoints()->get_Item($k)->getValue()->getData());
            $categoryTotals[$k] += $pointValue;
        }
    }

    for ($x = 0; $x < java_values($chart->getChartData()->getSeries()->size()); $x++) {
        $series = $chart->getChartData()->getSeries()->get_Item($x);
        $series->getLabels()->getDefaultDataLabelFormat()->setShowLegendKey(false);

        for ($j = 0; $j < java_values($series->getDataPoints()->size()); $j++) {
            $label = $series->getDataPoints()->get_Item($j)->getLabel();
            if ($categoryTotals[$j] == 0) {
                continue;
            }

            $pointValue = java_values($series->getDataPoints()->get_Item($j)->getValue()->getData());
            $dataPointPercent = ($pointValue / $categoryTotals[$j]) * 100;

            $portion = new Portion();
            $portion->setText(sprintf("%.2F %%", $dataPointPercent));
            $portion->getPortionFormat()->setFontHeight(8);

            $label->getTextFrameForOverriding()->setText("");
            $paragraph = $label->getTextFrameForOverriding()->getParagraphs()->get_Item(0);
            $paragraph->getPortions()->add($portion);

            $label->getDataLabelFormat()->setShowValue(true);
            $label->getDataLabelFormat()->setShowSeriesName(false);
            $label->getDataLabelFormat()->setShowPercentage(false);
            $label->getDataLabelFormat()->setShowLegendKey(false);
            $label->getDataLabelFormat()->setShowCategoryName(false);
            $label->getDataLabelFormat()->setShowBubbleSize(false);
        }
    }

    $presentation->save("DisplayPercentageAsLabels_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Establecer el signo de porcentaje con las etiquetas de datos del gráfico**

Cuando los valores se almacenan como fracciones, utilice [setNumberFormat](https://reference.aspose.com/slides/php-java/aspose.slides/datalabelformat/setnumberformat/) para mostrar porcentajes. Pase `false` a [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/php-java/aspose.slides/datalabelformat/setnumberformatlinkedtosource/) para aplicar el formato de la etiqueta de forma independiente de las celdas de origen.

Este ejemplo crea un gráfico de columnas apiladas al 100 % con series roja y azul en cuatro categorías. Cada pareja de valores suma 1. El formato de etiqueta `0.0%` muestra 0.30 como 30.0 %, mientras que el eje vertical usa dos decimales. Ambas series utilizan texto de etiqueta blanco de 10 pt.

```php
use aspose\slides\Presentation;
use aspose\slides\ChartType;
use aspose\slides\FillType;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::PercentsStackedColumn, 20, 20, 500, 400);

    $chart->getAxes()->getVerticalAxis()->setNumberFormatLinkedToSource(false);
    $chart->getAxes()->getVerticalAxis()->setNumberFormat("0.00%");

    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();

    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $worksheetIndex = 0;
    for ($i = 0; $i < 4; $i++) {
        $categoryCell = $workbook->getCell($worksheetIndex, $i + 1, 0, "Category " . ($i + 1));
        $chart->getChartData()->getCategories()->add($categoryCell);
    }

    $colors = java("java.awt.Color");
    $seriesNames = [ "Reds", "Blues" ];
    $seriesColors = [ $colors->RED, $colors->BLUE ];
    $values = [ [ 0.30, 0.50, 0.80, 0.65 ], [ 0.70, 0.50, 0.20, 0.35 ] ];

    for ($i = 0; $i < count($seriesNames); $i++) {
        $seriesCell = $workbook->getCell($worksheetIndex, 0, $i + 1, $seriesNames[$i]);
        $series = $chart->getChartData()->getSeries()->add($seriesCell, $chart->getType());
        for ($j = 0; $j < 4; $j++) {
            $valueCell = $workbook->getCell($worksheetIndex, $j + 1, $i + 1, $values[$i][$j]);
            $series->getDataPoints()->addDataPointForBarSeries($valueCell);
        }

        $series->getFormat()->getFill()->setFillType(FillType::Solid);
        $series->getFormat()->getFill()->getSolidFillColor()->setColor($seriesColors[$i]);

        $labelFormat = $series->getLabels()->getDefaultDataLabelFormat();
        $labelFormat->setShowValue(true);
        $labelFormat->setNumberFormatLinkedToSource(false);
        $labelFormat->setNumberFormat("0.0%");
        $labelFormat->getTextFormat()->getPortionFormat()->setFontHeight(10);
        $labelFormat->getTextFormat()->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
        $labelFormat->getTextFormat()->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor($colors->WHITE);
    }

    $presentation->save("SetDataLabelsPercentageSign_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Leer el texto real de las etiquetas de datos**

Utilice [getActualLabelText](https://reference.aspose.com/slides/php-java/aspose.slides/datalabel/getactuallabeltext/) para obtener el texto producido por la configuración de una etiqueta de datos. Esto es útil al extraer etiquetas para informes, buscar contenido en presentaciones o validar gráficos generados. En el ejemplo siguiente, el formato de etiqueta de datos predeterminado ([data label format](https://reference.aspose.com/slides/php-java/aspose.slides/datalabelformat/)) combina el nombre de cada categoría, el nombre de la serie y el valor. Un punto formatea su valor como porcentaje y otro usa texto personalizado de [getTextFrameForOverriding](https://reference.aspose.com/slides/php-java/aspose.slides/datalabel/gettextframeforoverriding/).

```php
use aspose\slides\Presentation;
use aspose\slides\ChartType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 20, 20, 500, 300);

    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();

    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $firstCategoryCell = $workbook->getCell(0, 1, 0, "Q1");
    $chart->getChartData()->getCategories()->add($firstCategoryCell);
    $secondCategoryCell = $workbook->getCell(0, 2, 0, "Q2");
    $chart->getChartData()->getCategories()->add($secondCategoryCell);

    $northSeriesCell = $workbook->getCell(0, 0, 1, "North");
    $north = $chart->getChartData()->getSeries()->add($northSeriesCell, $chart->getType());
    $northFirstValueCell = $workbook->getCell(0, 1, 1, 0.25);
    $north->getDataPoints()->addDataPointForBarSeries($northFirstValueCell);
    $northSecondValueCell = $workbook->getCell(0, 2, 1, 0.75);
    $north->getDataPoints()->addDataPointForBarSeries($northSecondValueCell);

    $southSeriesCell = $workbook->getCell(0, 0, 2, "South");
    $south = $chart->getChartData()->getSeries()->add($southSeriesCell, $chart->getType());
    $southFirstValueCell = $workbook->getCell(0, 1, 2, 0.40);
    $south->getDataPoints()->addDataPointForBarSeries($southFirstValueCell);
    $southSecondValueCell = $workbook->getCell(0, 2, 2, 0.60);
    $south->getDataPoints()->addDataPointForBarSeries($southSecondValueCell);

    for ($i = 0; $i < java_values($chart->getChartData()->getSeries()->size()); $i++) {
        $series = $chart->getChartData()->getSeries()->get_Item($i);
        $format = $series->getLabels()->getDefaultDataLabelFormat();
        $format->setShowCategoryName(true);
        $format->setShowSeriesName(true);
        $format->setShowValue(true);
    }

    $north->getLabels()->get_Item(1)->getDataLabelFormat()->setNumberFormatLinkedToSource(false);
    $north->getLabels()->get_Item(1)->getDataLabelFormat()->setNumberFormat("0%");
    $south->getLabels()->get_Item(0)->getTextFrameForOverriding()->setText("Reviewed");

    for ($i = 0; $i < java_values($chart->getChartData()->getSeries()->size()); $i++) {
        $series = $chart->getChartData()->getSeries()->get_Item($i);
        for ($j = 0; $j < java_values($series->getDataPoints()->size()); $j++) {
            $point = $series->getDataPoints()->get_Item($j);
            $label = $point->getLabel();
            if (!java_values($label->isVisible())) {
                continue;
            }

            echo "Value: " . java_values($point->getValue()->getData()) . "; label: " . java_values($label->getActualLabelText()) . PHP_EOL;
        }
    }
} finally {
    $presentation->dispose();
}
```

El número almacenado en un punto de datos sigue siendo `0.75`, incluso cuando su etiqueta muestra `75%` junto con los nombres de categoría y serie. El texto personalizado sustituye al texto generado por la etiqueta. [getActualLabelText](https://reference.aspose.com/slides/php-java/aspose.slides/datalabel/getactuallabeltext/) devuelve la cadena de etiqueta resultante en ambos casos. Compruebe [isVisible](https://reference.aspose.com/slides/php-java/aspose.slides/datalabel/isvisible/) por separado, como se muestra arriba, cuando solo desee extraer etiquetas visibles.

## **Controlar las etiquetas de datos más allá del máximo del eje**

Cuando limita manualmente el rango de un eje, algunos puntos pueden superar su máximo. Utilice [setShowDataLabelsOverMaximum](https://reference.aspose.com/slides/php-java/aspose.slides/chart/setshowdatalabelsovermaximum/) para controlar si se muestran sus etiquetas de datos. Esta configuración cambia la visibilidad de la etiqueta; no modifica el rango del eje ni los valores subyacentes.

El ejemplo siguiente crea un gráfico de columnas agrupadas 2D con valores de 60 y 120. Pasa `false` a [setAutomaticMaxValue](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setautomaticmaxvalue/) y establece el máximo en 100 con [setMaxValue](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setmaxvalue/) en el eje vertical. La primera diapositiva permite etiquetas más allá del máximo; una copia de esa diapositiva las desactiva. Ambas diapositivas se guardan en `DataLabelsOverMaximum.pptx`.

Active las etiquetas de valores con [setShowValue](https://reference.aspose.com/slides/php-java/aspose.slides/datalabelformat/setshowvalue/). La configuración a nivel de gráfico no habilita la visualización de valores por sí sola ni sobrescribe la visualización desactivada de una etiqueta individual. Este ejemplo habilita los valores para toda la serie y usa [setPosition](https://reference.aspose.com/slides/php-java/aspose.slides/datalabelformat/setposition/) para colocar las etiquetas en el extremo externo de cada columna.

```php
use aspose\slides\Presentation;
use aspose\slides\ChartType;
use aspose\slides\LegendDataLabelPosition;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400);
    $chart->setLegend(false);

    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();

    $workbook = $chart->getChartData()->getChartDataWorkbook();

    $firstCategory = $workbook->getCell(0, 1, 0, "Within range");
    $secondCategory = $workbook->getCell(0, 2, 0, "Above maximum");

    $chart->getChartData()->getCategories()->add($firstCategory);
    $chart->getChartData()->getCategories()->add($secondCategory);

    $seriesName = $workbook->getCell(0, 0, 1, "Values");
    $series = $chart->getChartData()->getSeries()->add($seriesName, $chart->getType());

    $firstValue = $workbook->getCell(0, 1, 1, 60);
    $secondValue = $workbook->getCell(0, 2, 1, 120);

    $series->getDataPoints()->addDataPointForBarSeries($firstValue);
    $series->getDataPoints()->addDataPointForBarSeries($secondValue);

    $series->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);
    $series->getLabels()->getDefaultDataLabelFormat()->setPosition(LegendDataLabelPosition::OutsideEnd);

    $chart->getAxes()->getVerticalAxis()->setAutomaticMaxValue(false);
    $chart->getAxes()->getVerticalAxis()->setMaxValue(100);
    $chart->setShowDataLabelsOverMaximum(true);

    $secondSlide = $presentation->getSlides()->addClone($slide);
    $secondChart = $secondSlide->getShapes()->get_Item(0);
    $secondChart->setShowDataLabelsOverMaximum(false);

    $presentation->save("DataLabelsOverMaximum.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Las imágenes siguientes muestran las diapositivas guardadas renderizadas por Microsoft PowerPoint. Con `true`, la etiqueta **120** es visible en el límite superior; con `false`, está oculta. La etiqueta **60** sigue visible, el máximo del eje permanece en **100** y el segundo punto de datos sigue siendo **120** en ambos casos.

| setShowDataLabelsOverMaximum(true) | setShowDataLabelsOverMaximum(false) |
| --- | --- |
| ![Gráfico de PowerPoint que muestra la etiqueta de valor 120 con un máximo de eje de 100](data-labels-over-maximum-true.png) | ![Gráfico de PowerPoint que oculta la etiqueta de valor 120 con un máximo de eje de 100](data-labels-over-maximum-false.png) |

{{% alert color="info" title="Chart Type" %}}
This example uses a 2D column chart with a value axis. Charts without a value axis, such as pie and doughnut charts, do not have an axis maximum to limit in this way.
{{% /alert %}}

## **Establecer distancia de la etiqueta desde un eje**

Utilice [setLabelOffset](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setlabeloffset/) para controlar la distancia entre las etiquetas del eje de categorías y el eje. El valor es un porcentaje del tamaño máximo de fuente de las etiquetas del eje. Este ejemplo crea un gráfico de columnas agrupadas y establece el desplazamiento de etiquetas del eje horizontal en 500. Esta configuración afecta a las etiquetas del eje de categorías más que a las etiquetas asociadas a puntos de datos individuales.

```php
use aspose\slides\Presentation;
use aspose\slides\ChartType;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 20, 20, 500, 300);
    $chart->getAxes()->getHorizontalAxis()->setLabelOffset(500);

    $presentation->save("SetCategoryAxisLabelDistance_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Ajustar la ubicación de la etiqueta**

En un gráfico circular, ajuste la posición de las etiquetas de datos para mejorar el espaciado y dejar espacio a las líneas guía.

Este ejemplo muestra el valor del primer punto de datos, coloca su etiqueta fuera de la porción y ajusta sus desplazamientos horizontal y vertical mediante [setX](https://reference.aspose.com/slides/php-java/aspose.slides/datalabel/setx/) y [setY](https://reference.aspose.com/slides/php-java/aspose.slides/datalabel/sety/). Estos desplazamientos son relativos al ancho y al alto del gráfico, respectivamente.

```php
use aspose\slides\Presentation;
use aspose\slides\ChartType;
use aspose\slides\LegendDataLabelPosition;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    
    $chart = $slide->getShapes()->addChart(ChartType::Pie, 50, 50, 200, 200);
    $series = $chart->getChartData()->getSeries();

    $label = $series->get_Item(0)->getLabels()->get_Item(0);
    $label->getDataLabelFormat()->setShowValue(true);
    $label->getDataLabelFormat()->setPosition(LegendDataLabelPosition::OutsideEnd);
    $label->setX(0.71);
    $label->setY(0.04);

    $presentation->save("presentation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

![Gráfico circular con una posición de etiqueta de datos ajustada](pie-chart-adjusted-label.png)

## **Formatear líneas guía**

Cuando las etiquetas de los gráficos circulares se sitúan fuera de sus porciones, las líneas guía ayudan a los lectores a asociar cada valor con la porción correcta. Un color contrastante y una línea ligeramente más gruesa pueden facilitar estas conexiones, mientras que la transparencia y un estilo dash mantienen las líneas visualmente discretas.

Utilice [getLeaderLinesFormat](https://reference.aspose.com/slides/php-java/aspose.slides/datalabelcollection/getleaderlinesformat/) para dar formato a las líneas guía a nivel de la colección de etiquetas de datos de la serie. La configuración en `$series->getLabels()->getLeaderLinesFormat()->getLine()` se aplica a la colección, no a una etiqueta individual.

Este ejemplo crea un gráfico circular con datos predeterminados, muestra los valores fuera de las porciones y habilita [setShowLeaderLines](https://reference.aspose.com/slides/php-java/aspose.slides/datalabelformat/setshowleaderlines/). Mueve dos etiquetas más lejos de sus porciones mediante los desplazamientos [setX](https://reference.aspose.com/slides/php-java/aspose.slides/datalabel/setx/) y [setY](https://reference.aspose.com/slides/php-java/aspose.slides/datalabel/sety/), expresados como fracciones del ancho y alto del gráfico. No se requiere una presentación de entrada.

El [getFillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/getfillformat/) de la línea establece un color azul sólido con un valor alfa de 191 sobre 255, lo que equivale a aproximadamente un 25 % de transparencia. [setWidth](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/setwidth/) establece el grosor en 2 pt, y [setDashStyle](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/setdashstyle/) convierte la línea en dash.

```php
use aspose\slides\Presentation;
use aspose\slides\ChartType;
use aspose\slides\LegendDataLabelPosition;
use aspose\slides\FillType;
use aspose\slides\LineDashStyle;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Pie, 80, 50, 560, 400);
    $chart->setLegend(false);

    $series = $chart->getChartData()->getSeries()->get_Item(0);

    $labelFormat = $series->getLabels()->getDefaultDataLabelFormat();
    $labelFormat->setShowValue(true);
    $labelFormat->setPosition(LegendDataLabelPosition::OutsideEnd);
    $labelFormat->setShowLeaderLines(true);

    // Mover dos etiquetas más lejos de sus porciones.
    $series->getLabels()->get_Item(0)->setX(0.10);
    $series->getLabels()->get_Item(0)->setY(-0.05);
    $series->getLabels()->get_Item(1)->setX(-0.10);
    $series->getLabels()->get_Item(1)->setY(0.05);

    $line = $series->getLabels()->getLeaderLinesFormat()->getLine();
    $line->getFillFormat()->setFillType(FillType::Solid);
    $lineColor = new Java("java.awt.Color", 30, 90, 160, 191);
    $line->getFillFormat()->getSolidFillColor()->setColor($lineColor);
    $line->setWidth(2);
    $line->setDashStyle(LineDashStyle::Dash);

    $presentation->save("FormattedLeaderLines.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Activar las líneas guía no garantiza que aparezca una línea para cada etiqueta. La visibilidad depende de la ubicación de la etiqueta y del comportamiento de diseño del gráfico. En este ejemplo, las dos etiquetas desplazadas tienen líneas guía visibles; las etiquetas que permanecen cerca de sus porciones no las necesitan.

La imagen siguiente muestra el archivo `FormattedLeaderLines.pptx` guardado y renderizado con Aspose.Slides:

![Gráfico circular con líneas guía azules, semitransparentes y con estilo dash que conectan dos etiquetas externas con sus porciones](formatted-leader-lines.png)

## **Agregar varias filas de etiquetas de datos encima de un gráfico de columnas**

Este ejemplo crea un gráfico de columnas con dos filas de etiquetas de datos encima del área de trazado. La Serie A muestra las columnas visibles, mientras que las Series B y C proporcionan las etiquetas adicionales. Sus columnas se ocultan eliminando el relleno y el contorno. El método [ChartSeriesGroup::setOverlap](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/setoverlap/) alinea las tres series con los mismos centros de categoría.

Los ajustes de [ChartPlotArea](https://reference.aspose.com/slides/php-java/aspose.slides/chartplotarea/) reservan espacio para las filas de etiquetas. Después de que [Chart::validateChartLayout](https://reference.aspose.com/slides/php-java/aspose.slides/chart/validatechartlayout/) calcula las posiciones predeterminadas, [DataLabel::setX](https://reference.aspose.com/slides/php-java/aspose.slides/datalabel/setx/) y [DataLabel::setY](https://reference.aspose.com/slides/php-java/aspose.slides/datalabel/sety/) conservan la alineación horizontal y aplican desplazamientos verticales para organizar las etiquetas en dos filas. Los números siguen siendo etiquetas de datos vinculadas a los valores de la serie; solo los encabezados de fila son formas de texto independientes.

```php
use aspose\slides\Presentation;
use aspose\slides\ChartType;
use aspose\slides\FillType;
use aspose\slides\LegendDataLabelPosition;
use aspose\slides\LayoutTargetType;
use aspose\slides\ShapeType;
use aspose\slides\SaveFormat;

$colors = java("java.awt.Color");

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 40, 40, 640, 200);
    $chart->setTitle(false);
    $chart->setLegend(false);
    $chart->getTextFormat()->getPortionFormat()->setFontHeight(12);

    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();

    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $workbook->clear(0);

    $categories = [ "North", "South", "East", "West" ];
    $seriesNames = [ "Series A", "Series B", "Series C" ];
    $seriesValues = [
        [ 35, 42, 28, 47 ],
        [ 22, 31, 19, 26 ],
        [ 12, 16, 14, 18 ]
    ];
    
    for ($categoryIndex = 0; $categoryIndex < count($categories); $categoryIndex++) {
        $categoryCell = $workbook->getCell(0, $categoryIndex + 1, 0, $categories[$categoryIndex]);
        $chart->getChartData()->getCategories()->add($categoryCell);
    }

    for ($seriesIndex = 0; $seriesIndex < count($seriesNames); $seriesIndex++) {
        $seriesCell = $workbook->getCell(0, 0, $seriesIndex + 1, $seriesNames[$seriesIndex]);
        $series = $chart->getChartData()->getSeries()->add($seriesCell, ChartType::ClusteredColumn);

        for ($categoryIndex = 0; $categoryIndex < count($categories); $categoryIndex++) {
            $valueCell = $workbook->getCell(0, $categoryIndex + 1, $seriesIndex + 1, $seriesValues[$seriesIndex][$categoryIndex]);
            $series->getDataPoints()->addDataPointForBarSeries($valueCell);
        }

        if ($seriesIndex > 0) {
            // Ocultar las columnas de B y C, pero mantener sus etiquetas de datos.
            $series->getFormat()->getFill()->setFillType(FillType::NoFill);
            $series->getFormat()->getLine()->getFillFormat()->setFillType(FillType::NoFill);
            $labelFormat = $series->getLabels()->getDefaultDataLabelFormat();
            $labelFormat->setShowValue(true);
            $labelFormat->getTextFormat()->getPortionFormat()->setFontHeight(12);
            $labelFill = $labelFormat->getTextFormat()->getPortionFormat()->getFillFormat();
            $labelFill->setFillType(FillType::Solid);
            $labelFill->getSolidFillColor()->setColor($colors->BLACK);
            $labelFormat->setPosition(LegendDataLabelPosition::InsideBase);
        }
    }

    // Alinear las tres series con los mismos centros de categoría.
    $chart->getChartData()->getSeries()->get_Item(0)->getParentSeriesGroup()->setOverlap(100);

    // Usar menos líneas de cuadrícula para este ejemplo compacto.
    $chart->getAxes()->getVerticalAxis()->setAutomaticMajorUnit(false);
    $chart->getAxes()->getVerticalAxis()->setMajorUnit(10);

    // Reservar espacio encima del área de trazado para dos filas de etiquetas de datos.
    $chart->getPlotArea()->setLayoutTargetType(LayoutTargetType::Inner);
    $chart->getPlotArea()->setX(0.15);
    $chart->getPlotArea()->setY(0.32);
    $chart->getPlotArea()->setWidth(0.80);
    $chart->getPlotArea()->setHeight(0.48);
    $chart->validateChartLayout();

    $chartX = java_values($chart->getX());
    $chartY = java_values($chart->getY());
    $chartHeight = java_values($chart->getHeight());
    for ($seriesIndex = 1; $seriesIndex < count($seriesNames); $seriesIndex++) {
        $series = $chart->getChartData()->getSeries()->get_Item($seriesIndex);
        $rowTop = $seriesIndex == 1 ? 0.15 : 0.03;

        for ($categoryIndex = 0; $categoryIndex < count($categories); $categoryIndex++) {
            $dataLabel = $series->getDataPoints()->get_Item($categoryIndex)->getLabel();
            // Mantener la posición horizontal predeterminada. Y es un desplazamiento desde
            // la posición predeterminada de la etiqueta, expresado como una fracción de la altura del gráfico.
            $actualY = java_values($dataLabel->getActualY());
            $dataLabel->setX(0);
            $dataLabel->setY($rowTop - $actualY / $chartHeight);
        }

        // Solo el encabezado de fila es una forma de texto separada.
        $rowHeading = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, $chartX, $chartY + $rowTop * $chartHeight, 85, 18);
        $rowHeading->getFillFormat()->setFillType(FillType::NoFill);
        $rowHeading->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);
        $rowHeading->addTextFrame($seriesNames[$seriesIndex]);
        $rowHeading->getTextFrame()->getTextFrameFormat()->setMarginTop(0);
        $rowHeading->getTextFrame()->getTextFrameFormat()->setMarginBottom(0);
        $headingFormat = $rowHeading->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat();
        $headingFormat->setFontHeight(12);
        $headingFormat->getFillFormat()->setFillType(FillType::Solid);
        $headingFormat->getFillFormat()->getSolidFillColor()->setColor($colors->BLACK);
    }

    $presentation->save("multiple-rows-of-labels.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

![Gráfico de columnas con dos filas de etiquetas de datos encima del área de trazado](multiple-rows-of-labels.png)


## **Preguntas frecuentes**

**¿Cómo puedo evitar que las etiquetas de datos se superpongan en gráficos densos?**

Combine la colocación automática de etiquetas, líneas guía y una reducción del tamaño de fuente; si es necesario, oculte algunos campos (por ejemplo, la categoría) o muestre etiquetas solo para valores extremos o puntos clave.

**¿Cómo puedo desactivar etiquetas solo para valores cero, negativos o vacíos?**

Filtre los puntos de datos antes de activar las etiquetas y desactive la visualización para valores de 0, valores negativos o valores ausentes según una regla definida.

**¿Cómo puedo garantizar un estilo de etiqueta coherente al exportar a PDF/imagenes?**

Establezca explícitamente la familia y el tamaño de fuente y verifique que la fuente esté disponible en el entorno de renderizado para evitar sustituciones.