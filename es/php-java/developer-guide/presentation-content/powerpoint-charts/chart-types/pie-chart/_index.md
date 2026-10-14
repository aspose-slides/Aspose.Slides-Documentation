---
title: Personalizar gráficos circulares en presentaciones usando PHP
linktitle: Gráfico circular
type: docs
url: /es/php-java/pie-chart/
keywords:
- gráfico circular
- gestionar gráfico
- personalizar gráfico
- opciones de gráfico
- configuración de gráfico
- opciones de trazado
- color de porción
- PowerPoint
- presentación
- PHP
- Aspose.Slides
description: "Cree y personalice gráficos circulares en PHP con Aspose.Slides. Configure trazados secundarios, muestre etiquetas de datos y aplique colores automáticos a las porciones en PowerPoint."
---
## **Visión general**

Este artículo explica cómo trabajar con gráficos circulares en Aspose.Slides. Muestra cómo configurar las opciones de trazado secundario para los gráficos Pie of Pie y Bar of Pie, y cómo habilitar el coloreado automático de las porciones en un gráfico circular estándar.

Los ejemplos se centran en tareas de personalización de gráficos, como añadir un gráfico a una diapositiva, ajustar la configuración de series y etiquetas, reemplazar los datos predeterminados del gráfico con categorías y valores personalizados, y guardar la presentación actualizada.

## **Opciones de trazado secundario para gráficos Pie of Pie y Bar of Pie**

Aspose.Slides for PHP via Java admite opciones de trazado secundario para los gráficos Pie of Pie y Bar of Pie. Estas opciones controlan el tamaño del trazado secundario y cómo se dividen los puntos de datos entre los dos trazados.

El siguiente ejemplo crea un gráfico Pie of Pie en una nueva presentación y muestra los valores de los puntos de datos como etiquetas. El método [setSecondPieSize](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/#setSecondPieSize) establece el tamaño del trazado secundario en un 149 % del trazado principal. [setPieSplitBy](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/#setPieSplitBy) selecciona la división basada en porcentajes, y [setPieSplitPosition](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/#setPieSplitPosition) fija el umbral en un 53 %.

```php
use aspose\slides\ChartType;
use aspose\slides\PieSplitType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::PieOfPie, 50, 50, 500, 400);
    $series = $chart->getChartData()->getSeries()->get_Item(0);

    // Mostrar valores y configurar el trazado secundario.
    $series->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);
    $seriesGroup = $series->getParentSeriesGroup();
    $seriesGroup->setSecondPieSize(149);
    $seriesGroup->setPieSplitBy(PieSplitType::ByPercentage);
    $seriesGroup->setPieSplitPosition(53);

    $presentation->save("pie_of_pie.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **Seleccionar categorías para el trazado secundario**

Utilice la división personalizada cuando desee agrupar categorías específicas en el trazado secundario sin importar sus valores porcentuales. Por ejemplo, un informe de ventas podría mostrar Online y Events juntos para que los lectores puedan comparar estos dos canales, aunque representen el 35 % y el 10 % de las ventas totales.

Llame a [setPieSplitBy](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/#setPieSplitBy) con [PieSplitType::Custom](https://reference.aspose.com/slides/php-java/aspose.slides/piesplittype/) y seleccione los puntos mediante [getPieSplitCustomPoints](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/#getPieSplitCustomPoints). El método [add](https://reference.aspose.com/slides/php-java/aspose.slides/piesplitcustompointcollection/#add) de la colección acepta un índice basado en cero en la serie; use [addItem](https://reference.aspose.com/slides/php-java/aspose.slides/piesplitcustompointcollection/#addItem) para añadir un objeto de punto de datos. En este ejemplo, el índice 1 selecciona Online, y el punto en el índice 3 selecciona Events. Partners también se añade temporalmente, y luego se excluye usando [removeItem](https://reference.aspose.com/slides/php-java/aspose.slides/piesplitcustompointcollection/#removeItem).

```php
use aspose\slides\ChartType;
use aspose\slides\PieSplitType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::PieOfPie, 50, 50, 600, 200);

    // Reemplazar los datos predeterminados con ventas por canal.
    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();
    $categoryNames = [ "Retail", "Online", "Partners", "Events" ];
    $values = [ 40, 35, 15, 10 ];
    $seriesNameCell = $workbook->getCell(0, 0, 1, "Sales");
    $series = $chart->getChartData()->getSeries()->add($seriesNameCell, $chart->getType());

    for ($i = 0; $i < count($categoryNames); $i++) {
        $categoryCell = $workbook->getCell(0, $i + 1, 0, $categoryNames[$i]);
        $chart->getChartData()->getCategories()->add($categoryCell);

        $valueCell = $workbook->getCell(0, $i + 1, 1, $values[$i]);
        $series->getDataPoints()->addDataPointForPieSeries($valueCell);
    }

    $series->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);
    $seriesGroup = $series->getParentSeriesGroup();
    $seriesGroup->setPieSplitBy(PieSplitType::Custom);
    $seriesGroup->setColorVaried(true);

    // Seleccionar Online por su índice basado en cero y Events por su objeto de punto de datos.
    $seriesGroup->getPieSplitCustomPoints()->add(1);
    $seriesGroup->getPieSplitCustomPoints()->addItem($series->getDataPoints()->get_Item(3));

    // Excluir Partners de la selección sin eliminar sus datos de origen.
    $seriesGroup->getPieSplitCustomPoints()->add(2);
    $seriesGroup->getPieSplitCustomPoints()->removeItem($series->getDataPoints()->get_Item(2));

    $presentation->save("pie_of_pie_custom.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Online (35) y Events (10) aparecen como porciones separadas en el trazado secundario. En el trazado principal, se representan con una sola porción combinada con un valor de 45, junto a Retail (40) y Partners (15). Eliminar Partners de la selección personalizada lo mantiene en el trazado principal; no elimina la categoría ni su valor de los datos de origen del gráfico.

La siguiente imagen muestra la presentación guardada en PowerPoint:

![Gráfico Pie of Pie con Online y Events en el trazado secundario y su valor combinado de 45 en el trazado principal](pie_of_pie_custom.png)

## **Establecer colores automáticos de las porciones del gráfico circular**

Aspose.Slides for PHP via Java puede asignar automáticamente diferentes colores a las porciones de un gráfico circular. El siguiente ejemplo crea un gráfico circular con un título centrado y reemplaza los datos predeterminados con tres categorías trimestrales y sus valores. El método [setShowValue](https://reference.aspose.com/slides/php-java/aspose.slides/datalabelformat/#setShowValue) muestra los valores 20, 50 y 30 como etiquetas, mientras que [setColorVaried](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/#setColorVaried) habilita un color distinto para cada porción.

```php
use aspose\slides\ChartType;
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Pie, 100, 100, 400, 400);

    // Añadir un título centrado al gráfico.
    $chart->getChartTitle()->addTextFrameForOverriding("Sample Title");
    $chart->getChartTitle()->getTextFrameForOverriding()->getTextFrameFormat()->setCenterText(NullableBool::True);
    $chart->getChartTitle()->setHeight(20);
    $chart->setTitle(true);

    // Reemplazar los datos predeterminados usando la primera hoja de cálculo.
    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $worksheetIndex = 0;
    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();
    $categoryNames = [ "First Qtr", "2nd Qtr", "3rd Qtr" ];
    $values = [ 20, 50, 30 ];
    $seriesNameCell = $workbook->getCell($worksheetIndex, 0, 1, "Series 1");
    $series = $chart->getChartData()->getSeries()->add($seriesNameCell, $chart->getType());

    for ($i = 0; $i < count($categoryNames); $i++) {
        $categoryCell = $workbook->getCell($worksheetIndex, $i + 1, 0, $categoryNames[$i]);
        $chart->getChartData()->getCategories()->add($categoryCell);

        $valueCell = $workbook->getCell($worksheetIndex, $i + 1, 1, $values[$i]);
        $series->getDataPoints()->addDataPointForPieSeries($valueCell);
    }

    // Mostrar valores y asignar colores diferentes a las porciones.
    $series->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);
    $series->getParentSeriesGroup()->setColorVaried(true);

    $presentation->save("pie.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Preguntas frecuentes**

**¿Se admiten las variaciones Pie of Pie y Bar of Pie?**

Sí, la biblioteca [admite](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/) un trazado secundario para gráficos circulares, incluidos los tipos Pie of Pie y Bar of Pie.

**¿Puedo exportar solo el gráfico como imagen (por ejemplo, PNG)?**

Sí, puede [exportar el propio gráfico como imagen](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getImage) (por ejemplo PNG) sin exportar toda la presentación.