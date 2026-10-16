---
title: Añadir líneas de tendencia a los gráficos de presentación en PHP
linktitle: Línea de tendencia
type: docs
url: /es/php-java/trend-line/
keywords:
- gráfico
- línea de tendencia
- línea de tendencia exponencial
- línea de tendencia lineal
- línea de tendencia logarítmica
- línea de tendencia de media móvil
- línea de tendencia polinómica
- línea de tendencia de potencia
- línea de tendencia personalizada
- PowerPoint
- presentación
- PHP
- Aspose.Slides
description: "Añade y personaliza rápidamente líneas de tendencia en los gráficos de PowerPoint con Aspose.Slides para PHP mediante Java — una guía práctica para cautivar a tu audiencia."
---
## **Visión general**

Este artículo explica cómo añadir líneas de tendencia a los gráficos de presentación mediante Aspose.Slides. Muestra cómo crear un gráfico, añadir líneas de tendencia a las series del gráfico y trabajar con varios tipos de líneas de tendencia, incluyendo exponencial, lineal, logarítmica, media móvil, polinómica y de potencia.

También describe cómo añadir una línea personalizada a un gráfico insertando una forma de línea, e incluye una breve FAQ sobre los valores de proyección de la línea de tendencia hacia adelante y hacia atrás y si las líneas de tendencia se conservan durante la exportación a PDF o SVG y al renderizar los gráficos como imágenes.

## **Añadir una línea de tendencia**

Utilice [TrendlineCollection::add](https://reference.aspose.com/slides/php-java/aspose.slides/trendlinecollection/add/) para añadir una línea de tendencia a una serie del gráfico, seleccionando su tipo con [TrendlineType](https://reference.aspose.com/slides/php-java/aspose.slides/trendlinetype/). El ejemplo crea un gráfico de columnas agrupadas con datos predeterminados y añade dos líneas de tendencia a cada una de sus tres series.

La línea de tendencia exponencial oculta su ecuación y el valor R‑al‑cuadrado mediante [setDisplayEquation](https://reference.aspose.com/slides/php-java/aspose.slides/trendline/setdisplayequation/) y [setDisplayRSquaredValue](https://reference.aspose.com/slides/php-java/aspose.slides/trendline/setdisplayrsquaredvalue/), mientras que la línea de tendencia lineal es roja. La línea de tendencia logarítmica utiliza [addTextFrameForOverriding](https://reference.aspose.com/slides/php-java/aspose.slides/trendline/addtextframeforoverriding/) para una etiqueta personalizada. La media móvil utiliza un [setPeriod](https://reference.aspose.com/slides/php-java/aspose.slides/trendline/setperiod/) de tres puntos de datos y un [setTrendlineName](https://reference.aspose.com/slides/php-java/aspose.slides/trendline/settrendlinename/) personalizado.

La línea de tendencia polinómica tiene un orden de tres, establecido mediante [setOrder](https://reference.aspose.com/slides/php-java/aspose.slides/trendline/setorder/), y se extiende una categoría hacia adelante mediante [setForward](https://reference.aspose.com/slides/php-java/aspose.slides/trendline/setforward/). La línea de tendencia de potencia se extiende una categoría hacia atrás mediante [setBackward](https://reference.aspose.com/slides/php-java/aspose.slides/trendline/setbackward/).

```php
use aspose\slides\Presentation;
use aspose\slides\ChartType;
use aspose\slides\TrendlineType;
use aspose\slides\FillType;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 20, 20, 500, 400);

    $firstSeries = $chart->getChartData()->getSeries()->get_Item(0);

    $exponentialTrendline = $firstSeries->getTrendLines()->add(TrendlineType::Exponential);
    $exponentialTrendline->setDisplayEquation(false);
    $exponentialTrendline->setDisplayRSquaredValue(false);

    $linearTrendline = $firstSeries->getTrendLines()->add(TrendlineType::Linear);
    $linearTrendline->getFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $linearTrendline->getFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);

    $secondSeries = $chart->getChartData()->getSeries()->get_Item(1);

    $logarithmicTrendline = $secondSeries->getTrendLines()->add(TrendlineType::Logarithmic);
    $logarithmicTrendline->addTextFrameForOverriding("New log trend line");

    $movingAverageTrendline = $secondSeries->getTrendLines()->add(TrendlineType::MovingAverage);
    $movingAverageTrendline->setPeriod(3);
    $movingAverageTrendline->setTrendlineName("New TrendLine Name");

    $thirdSeries = $chart->getChartData()->getSeries()->get_Item(2);

    $polynomialTrendline = $thirdSeries->getTrendLines()->add(TrendlineType::Polynomial);
    $polynomialTrendline->setForward(1);
    $polynomialTrendline->setOrder(3);

    $powerTrendline = $thirdSeries->getTrendLines()->add(TrendlineType::Power);
    $powerTrendline->setBackward(1);

    $presentation->save("ChartTrendLines.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Establecer la intersección de una línea de tendencia**

Utilice [setIntercept](https://reference.aspose.com/slides/php-java/aspose.slides/trendline/setintercept/) para fijar el valor Y de una línea de tendencia en X = 0. Esta configuración es compatible con líneas de tendencia lineales, exponenciales y polinómicas.

Por ejemplo, un modelo de coste de producción puede necesitar comenzar con costes fijos conocidos de 100, incluso cuando las mediciones en volúmenes de producción distintos de cero sugieren una base diferente. Para una línea de tendencia lineal, fijar la intersección obliga a la ecuación `y = ax + b` a `b = 100`; la pendiente se ajusta a los datos bajo esa restricción. No simplemente desplaza una línea ya ajustada. Los ajustes de cruce de ejes controlan dónde se encuentran los ejes del gráfico, no los coeficientes de la línea de tendencia ajustada.

El siguiente ejemplo crea un gráfico de dispersión (XY) con volúmenes de producción de 1 a 4 y costes de 170, 200, 230 y 260. Guarda el gráfico con la intersección automática predeterminada, establece la intersección en 100 y guarda un segundo PPTX. Los dos archivos difieren solo en la configuración de la intersección. La línea de tendencia muestra su ecuación y se extiende hacia atrás hasta X = 0.

```php
use aspose\slides\Presentation;
use aspose\slides\ChartType;
use aspose\slides\TrendlineType;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ScatterWithMarkers, 20, 20, 480, 210);
    $chart->setLegend(false);

    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();

    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $workbook->clear(0);

    $nameCell = $workbook->getCell(0, 0, 1, "Production cost");
    $series = $chart->getChartData()->getSeries()->add($nameCell, ChartType::ScatterWithMarkers);
    $costs = [170, 200, 230, 260];

    for ($i = 0; $i < count($costs); $i++) {
        $xCell = $workbook->getCell(0, $i + 1, 0, $i + 1);
        $yCell = $workbook->getCell(0, $i + 1, 1, $costs[$i]);
        $series->getDataPoints()->addDataPointForScatterSeries($xCell, $yCell);
    }

    $trendline = $series->getTrendLines()->add(TrendlineType::Linear);
    $trendline->setDisplayEquation(true);
    $trendline->setBackward(1);

    $presentation->save("AutomaticIntercept.pptx", SaveFormat::Pptx);

    $trendline->setIntercept(100);
    $presentation->save("FixedIntercept.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Con cálculo automático, estos datos producen `y = 30x + 140`. Establecer la intersección en 100 en su lugar produce aproximadamente `y = 43.33x + 100`: el valor ajustado en cero coincide con la base conocida, mientras que la línea ya no pasa por todos los puntos de datos.

| Intersección automática | Intersección fija de 100 |
| --- | --- |
| ![Línea de tendencia lineal con una intersección calculada automáticamente de 140](intercept-automatic.png) | ![Línea de tendencia lineal con una intersección fija de 100](intercept-fixed.png) |

Ambas imágenes utilizan los mismos datos y escalas de ejes. Las líneas de tendencia se extienden hacia atrás hasta X = 0 para mostrar sus intersecciones.

Por defecto, [getIntercept](https://reference.aspose.com/slides/php-java/aspose.slides/trendline/getintercept/) devuelve `NaN`, lo que representa una intersección no especificada en lugar de cero. La intersección se calcula entonces automáticamente a partir de los datos.

## **Añadir una línea personalizada**

Una línea personalizada es una forma dibujada sobre el gráfico en lugar de una línea de tendencia calculada a partir de los datos de la serie. Este ejemplo utiliza [ShapeCollection::addAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addautoshape/) para añadir una línea horizontal a la diapositiva sobre el gráfico. La posición de la línea se especifica en coordenadas de diapositiva, medidas en puntos, por lo que comienza en el borde izquierdo del gráfico y se sitúa a mitad de altura del gráfico. Su anchura coincide con la anchura del gráfico. El [getLineFormat](https://reference.aspose.com/slides/php-java/aspose.slides/shape/getlineformat/) da a la línea un color rojo sólido.

```php
use aspose\slides\Presentation;
use aspose\slides\ChartType;
use aspose\slides\FillType;
use aspose\slides\ShapeType;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 100, 100, 500, 400);

    $lineY = java_values($chart->getY()) + java_values($chart->getHeight()) / 2;
    $line = $slide->getShapes()->addAutoShape(ShapeType::Line, $chart->getX(), $lineY, $chart->getWidth(), 0);
    $line->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $line->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);

    $presentation->save("AddCustomLines.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Preguntas frecuentes**

**¿Qué significan 'forward' y 'backward' para una línea de tendencia?**

Son las longitudes de la línea de tendencia proyectada hacia adelante/atrás: para gráficos de dispersión (XY) — en unidades del eje; para gráficos que no son de dispersión — en número de categorías. Solo se permiten valores no negativos.

**¿Se conservará la línea de tendencia al exportar la presentación a PDF o SVG, o al renderizar una diapositiva como imagen?**

Sí. Aspose.Slides convierte presentaciones a [PDF](/slides/es/php-java/convert-powerpoint-to-pdf/) o [SVG](/slides/es/php-java/render-a-slide-as-an-svg-image/) y renderiza gráficos a imágenes; las líneas de tendencia, como parte del gráfico, se conservan durante estas operaciones. También hay un método disponible para [exportar una imagen del propio gráfico](/slides/es/php-java/create-shape-thumbnails/).