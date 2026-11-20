---
title: Personalizar ejes de gráficos en presentaciones usando PHP
linktitle: Eje de gráfico
type: docs
url: /es/php-java/chart-axis/
keywords:
- eje de gráfico
- eje vertical
- eje horizontal
- personalizar eje
- manipular eje
- gestionar eje
- propiedades del eje
- valor máximo
- valor mínimo
- línea del eje
- formato de fecha
- título del eje
- posición del eje
- PowerPoint
- presentación
- PHP
- Aspose.Slides
description: "Descubra cómo usar Aspose.Slides para PHP a través de Java para personalizar los ejes de los gráficos en presentaciones de PowerPoint para informes y visualizaciones."
---
## **Resumen**

Este artículo explica cómo personalizar los ejes de los gráficos con Aspose.Slides para PHP a través de Java. Cubre valores de eje calculados, intercambio de filas y columnas del gráfico, visibilidad del eje, intervalos de etiquetas de categoría y de marcas de graduación, categorías de fecha y formato, rotación del título, posicionamiento del eje, unidades de visualización y escalado logarítmico.

## **Obtener los valores máximos en el eje vertical de los gráficos**

Cree una [Presentación](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) y añada un gráfico de áreas con datos predeterminados. Llame a [validateChartLayout](https://reference.aspose.com/slides/php-java/aspose.slides/chart/validatechartlayout/) antes de leer los valores calculados del eje para que el diseño del gráfico esté actualizado.

Lea [getActualMaxValue](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualmaxvalue/) y [getActualMinValue](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualminvalue/) para los límites del eje, y [getActualMajorUnit](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualmajorunit/) y [getActualMinorUnit](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualminorunit/) para los intervalos de marca. [getActualMajorUnitScale](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualmajorunitscale/) y [getActualMinorUnitScale](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualminorunitscale/) proporcionan escalas de unidades de tiempo, que son relevantes para ejes de fechas. El ejemplo almacena estos valores en variables locales y guarda el gráfico.

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Area, 100, 100, 500, 350);
    $chart->validateChartLayout();

    $maxValue = $chart->getAxes()->getVerticalAxis()->getActualMaxValue();
    $minValue = $chart->getAxes()->getVerticalAxis()->getActualMinValue();

    $majorUnit = $chart->getAxes()->getVerticalAxis()->getActualMajorUnit();
    $minorUnit = $chart->getAxes()->getVerticalAxis()->getActualMinorUnit();

    $majorUnitScale = $chart->getAxes()->getVerticalAxis()->getActualMajorUnitScale();
    $minorUnitScale = $chart->getAxes()->getVerticalAxis()->getActualMinorUnitScale();

    $presentation->save("AxisValues_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Intercambiar los datos entre los ejes**

Utilice [switchRowColumn](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/switchrowcolumn/) para intercambiar los roles de series y categorías en los datos del gráfico. Cada categoría anterior se convierte en una serie, y cada serie anterior se convierte en una categoría. Esto cambia la forma en que se agrupan los datos; no intercambia los ejes horizontal y vertical. El ejemplo utiliza [setRange](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/setrange/) para vincular los datos predeterminados a `Sheet1!A1:D5`, incluyendo la fila de encabezado y la columna de categorías, antes de intercambiar filas y columnas. Guarda un gráfico con cuatro series y tres categorías.

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 100, 100, 400, 300);
    $chart->getChartData()->setRange("Sheet1!A1:D5");
    $chart->getChartData()->switchRowColumn();

    $presentation->save("SwitchChartRowColumns_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Invertir el orden de trazado de un eje**

Utilice [setPlotOrderReversed](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setplotorderreversed/) para invertir un eje de categoría o de valores. Por ejemplo, un gráfico de barras horizontal puede mostrar las fases del proyecto de arriba a abajo en el mismo orden que la hoja de cálculo: Planificación, Desarrollo, Pruebas. Invertir un eje cambia la dirección de trazado; no ordena ni reorganiza los datos de la hoja de cálculo. En comparación, [switchRowColumn](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/switchrowcolumn/) intercambia los roles de series y categorías.

El siguiente ejemplo crea un gráfico de barras horizontal con tres fases y una serie. Guarda una presentación con tres diapositivas: orden normal, categorías invertidas y valores invertidos. Cada copia utiliza el mismo conjunto de datos, y solo un eje se invierte en cada copia.

```php
use aspose\slides\ChartType;
use aspose\slides\CrossesType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredBar, 50, 40, 620, 320);
    $chart->setLegend(false);

    $chart->getChartData()->getCategories()->clear();
    $chart->getChartData()->getSeries()->clear();

    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $workbook->clear(0);

    $series = $chart->getChartData()->getSeries()->add(ChartType::ClusteredBar);
    $stages = ["Planning", "Development", "Testing"];
    $values = [10, 30, 20];
    for ($i = 0; $i < count($stages); $i++) {
        $categoryCell = $workbook->getCell(0, $i + 1, 0, $stages[$i]);
        $chart->getChartData()->getCategories()->add($categoryCell);
        $valueCell = $workbook->getCell(0, $i + 1, 1, $values[$i]);
        $series->getDataPoints()->addDataPointForBarSeries($valueCell);
    }

    // Diapositiva 2: mostrar la primera categoría en la parte superior.
    $categorySlide = $presentation->getSlides()->addClone($slide);
    $categoryChart = $categorySlide->getShapes()->get_Item(0);
    $categoryChart->getAxes()->getVerticalAxis()->setPlotOrderReversed(true);
    // Mantener el eje de valores horizontal en la parte inferior.
    $categoryChart->getAxes()->getVerticalAxis()->setCrossType(CrossesType::Maximum);

    // Diapositiva 3: invertir solo la escala numérica horizontal.
    $valueSlide = $presentation->getSlides()->addClone($slide);
    $valueChart = $valueSlide->getShapes()->get_Item(0);
    $valueChart->getAxes()->getHorizontalAxis()->setPlotOrderReversed(true);

    $presentation->save("ReversedAxes.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Invertir un eje también puede mover el eje perpendicular al lado opuesto del trazado. [setCrossType](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setcrosstype/) controla dónde el otro eje cruza el eje que se está configurando. En la diapositiva 2, llamarlo con `CrossesType::Maximum` en el eje de categoría invertido mantiene el eje de valores horizontal en la parte inferior. Para un punto de cruce específico, utilice [setCrossAt](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setcrossat/). Verifique la configuración de cruce al cambiar la dirección, especialmente si el gráfico ya tiene un punto de cruce personalizado. Llame a `setPlotOrderReversed` con `false` para restaurar la dirección de trazado normal; la configuración de cruce es independiente.

| Orden normal (diapositiva 1) | Categorías invertidas (diapositiva 2) | Valores invertidos (diapositiva 3) |
| --- | --- | --- |
| ![Gráfico de barras horizontal con orden normal de ejes de categoría y valor](axis-order-normal.png) | ![Gráfico de barras horizontal con categorías mostradas de arriba a abajo](axis-order-categories-reversed.png) | ![Gráfico de barras horizontal con eje de valores invertido y cero a la derecha](axis-order-values-reversed.png) |
| Las categorías van de abajo a arriba; los valores aumentan de izquierda a derecha. | Planificación, Desarrollo y Pruebas van de arriba a abajo. Los valores y el orden de filas de la hoja de cálculo no cambian. | Las categorías conservan su orden normal; los valores aumentan de derecha a izquierda. El eje de categorías cruza en cero a la derecha. |

## **Desactivar el eje vertical en gráficos de líneas**

Llame a [setVisible](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setvisible/) con `false` en el eje vertical para ocultarlo. El ejemplo crea un gráfico de líneas con datos predeterminados y lo guarda con el eje vertical oculto.

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Line, 100, 100, 400, 300);
    $chart->getAxes()->getVerticalAxis()->setVisible(false);

    $presentation->save("HiddenVerticalAxis.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Desactivar el eje horizontal en gráficos de líneas**

Llame a [setVisible](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setvisible/) con `false` en el eje horizontal para ocultarlo. El ejemplo crea un gráfico de líneas con datos predeterminados y lo guarda con el eje horizontal oculto.

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Line, 100, 100, 400, 300);
    $chart->getAxes()->getHorizontalAxis()->setVisible(false);

    $presentation->save("HiddenHorizontalAxis.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Mostrar u ocultar las líneas de cuadrícula del gráfico**

Llame a [getShowMajorGridLines](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getshowmajorgridlines/) y [getShowMinorGridLines](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getshowminorgridlines/) para comprobar qué líneas de cuadrícula muestra un eje. Para mostrar las líneas de cuadrícula menores, use [getMinorGridLinesFormat](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getminorgridlinesformat/) y establezca el relleno de la línea a un color sólido y visible. Para ocultarlas, establezca el relleno a [FillType::NoFill](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/). Use [getMajorGridLinesFormat](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getmajorgridlinesformat/) para cambiar el relleno de línea de las líneas de cuadrícula mayores de la misma forma. Cambiar el relleno preserva la visibilidad del eje y las marcas de graduación.

El eje vertical de este gráfico de columnas agrupadas inicialmente muestra solo líneas de cuadrícula principales. El ejemplo muestra las líneas de cuadrícula menores en naranja oscuro, luego las oculta de nuevo antes de guardar la presentación. Imprime la visibilidad de las líneas de cuadrícula en cada paso.

```php
use aspose\slides\ChartType;
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    
    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 30, 30, 660, 230);
    $axis = $chart->getAxes()->getVerticalAxis();
    printf("Initial: major=%s, minor=%s\n", java_values($axis->getShowMajorGridLines()) ? "true" : "false", java_values($axis->getShowMinorGridLines()) ? "true" : "false");

    $minorFill = $axis->getMinorGridLinesFormat()->getLine()->getFillFormat();
    $minorFill->setFillType(FillType::Solid);
    $darkOrange = new Java("java.awt.Color", 255, 140, 0);
    $minorFill->getSolidFillColor()->setColor($darkOrange);
    printf("Enabled: minor=%s\n", java_values($axis->getShowMinorGridLines()) ? "true" : "false");

    $minorFill->setFillType(FillType::NoFill);
    printf("Hidden: major=%s, minor=%s\n", java_values($axis->getShowMajorGridLines()) ? "true" : "false", java_values($axis->getShowMinorGridLines()) ? "true" : "false");

    $presentation->save("ChartGridlines.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

| Líneas de cuadrícula menores activadas | Líneas de cuadrícula menores ocultas |
| --- | --- |
| ![Líneas de cuadrícula menores naranjas entre las líneas mayores en el eje vertical](minor-gridlines-enabled.png) | ![El mismo gráfico de columnas con solo líneas mayores visibles](minor-gridlines-hidden.png) |

## **Cambiar un eje de categorías**

Utilice [setCategoryAxisType](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setcategoryaxistype/) para elegir un eje de categorías de fecha o de texto. Este ejemplo requiere `ExistingChart.pptx`, con un gráfico como la primera forma en la primera diapositiva y celdas de categoría que contienen valores de fecha numéricos de Excel. Cambia el eje horizontal a un eje de fechas. Llamar a [setAutomaticMajorUnit](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setautomaticmajorunit/) con `false`, [setMajorUnit](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setmajorunit/) con `1` y [setMajorUnitScale](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setmajorunitscale/) con `TimeUnitType::Months` coloca marcas principales a intervalos de un mes.

```php
use aspose\slides\CategoryAxisType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TimeUnitType;

$presentation = new Presentation("ExistingChart.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->get_Item(0);
    $chart->getAxes()->getHorizontalAxis()->setCategoryAxisType(CategoryAxisType::Date);
    $chart->getAxes()->getHorizontalAxis()->setAutomaticMajorUnit(false);
    $chart->getAxes()->getHorizontalAxis()->setMajorUnit(1);
    $chart->getAxes()->getHorizontalAxis()->setMajorUnitScale(TimeUnitType::Months);

    $presentation->save("ChangeChartCategoryAxis_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **Determinar el tipo de eje de categorías a partir de los datos**

Llame a [setCategoryAxisTypeAutomatically](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setcategoryaxistypeautomatically/) después de rellenar las categorías, luego lea [getCategoryAxisType](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getcategoryaxistype/) para inspeccionar la selección. Esto es útil cuando el mismo gráfico recibe etiquetas de texto o valores de fecha numéricos. El método determina el tipo al llamarse; no habilita un modo persistente que reevalúe cambios posteriores de datos. Llamelo de nuevo después de reemplazar las categorías.

El siguiente ejemplo crea un gráfico con categorías de texto e imprime `true` cuando el tipo seleccionado es `CategoryAxisType::Text`. Luego sustituye los valores de las celdas de categoría por fechas y llama al método de nuevo, imprimiendo `true` cuando el tipo seleccionado es `CategoryAxisType::Date`. Las fechas se almacenan como valores numéricos OLE Automation, calculados para estas fechas como el número de días desde el 30 de diciembre de 1899, en lugar de cadenas de fecha. [setCustomNumberFormat](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatacell/setcustomnumberformat/) controla cómo se muestran esos valores; no convierte texto en fechas numéricas. Para más información sobre celdas de categoría, vea [Libro de trabajo del gráfico](/slides/es/php-java/chart-workbook/).

Utilice la determinación automática cuando se sepa que la entrada contiene categorías de texto o fechas numéricas, como en este ejemplo. Para etiquetas numéricas normales, categorías mixtas o datos vacíos, llame explícitamente a [setCategoryAxisType](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setcategoryaxistype/) para coincidir con el significado previsto. Los valores numéricos por sí solos no establecen que las categorías representen fechas.

```php
use aspose\slides\CategoryAxisType;
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 30, 40, 660, 320);

    $chart->getChartData()->getCategories()->clear();
    $chart->getChartData()->getSeries()->clear();

    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $workbook->clear(0);

    $seriesName = $workbook->getCell(0, 0, 1, "Sales");
    $series = $chart->getChartData()->getSeries()->add($seriesName, $chart->getType());
    $labels = ["First", "Second", "Third"];

    for ($i = 0; $i < count($labels); $i++) {
        $categoryCell = $workbook->getCell(0, $i + 1, 0, $labels[$i]);
        $chart->getChartData()->getCategories()->add($categoryCell);

        $valueCell = $workbook->getCell(0, $i + 1, 1, ($i + 1) * 10);
        $series->getDataPoints()->addDataPointForBarSeries($valueCell);
    }

    $axis = $chart->getAxes()->getHorizontalAxis();
    $axis->setCategoryAxisTypeAutomatically();
    echo (java_values($axis->getCategoryAxisType()) == CategoryAxisType::Text ? "true" : "false") . PHP_EOL;

    $baseDate = gmmktime(0, 0, 0, 12, 30, 1899);
    $dates = [gmmktime(0, 0, 0, 1, 1, 2026), gmmktime(0, 0, 0, 1, 2, 2026), gmmktime(0, 0, 0, 2, 1, 2026)];

    for ($i = 0; $i < count($dates); $i++) {
        $categoryCell = $workbook->getCell(0, $i + 1, 0);
        $categoryCell->setValue((float)(($dates[$i] - $baseDate) / 86400));
        $categoryCell->setCustomNumberFormat("yyyy-mm-dd");
    }

    $axis->setCategoryAxisTypeAutomatically();
    echo (java_values($axis->getCategoryAxisType()) == CategoryAxisType::Date ? "true" : "false") . PHP_EOL;

    $presentation->save("AutomaticCategoryAxis.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Controlar los intervalos de etiquetas del eje de categorías**

Cuando un gráfico tiene muchas categorías, reduzca el número de etiquetas visibles del eje sin eliminar categorías ni puntos de datos. Llame a [setAutomaticTickLabelSpacing](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setautomaticticklabelspacing/) con `false`, luego pase el intervalo de categoría deseado a [setTickLabelSpacing](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setticklabelspacing/). Para categorías de texto en su orden normal, el recuento comienza en la primera categoría:

| Intervalo | Etiquetas mostradas en el ejemplo |
| --- | --- |
| `1` | Categoría 1, Categoría 2, Categoría 3, ... Categoría 24 |
| `2` | Categoría 1, Categoría 3, Categoría 5, ... Categoría 23 |
| `3` | Categoría 1, Categoría 4, Categoría 7, ... Categoría 22 |

Un intervalo de `3` muestra cada tercera etiqueta, dejando dos etiquetas ocultas entre las mostradas. No elimina las columnas correspondientes. El espaciado automático elige un intervalo basado en el espacio disponible; no muestra necesariamente todas las etiquetas.

Las marcas de graduación tienen controles separados. Llame a [setAutomaticTickMarksSpacing](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setautomatictickmarksspacing/) con `false` y use [setTickMarksSpacing](https://reference.aspose.com/slides/php-java/aspose.slides/axis/settickmarksspacing/) para establecer su intervalo. Por ejemplo, `1` mantiene una marca en cada intervalo de categoría mientras las etiquetas aparecen solo cada tercera categoría. Use [setMajorTickMark](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setmajortickmark/) con un estilo visible para poder ver el resultado. Llamar nuevamente a cualquiera de los setters de espaciado automático con `true` permite que el gráfico elija ese intervalo otra vez.

El siguiente ejemplo autocontenido crea 24 categorías y una serie, luego guarda tres diapositivas en `CategoryAxisIntervals.pptx`: espaciado automático, espaciado manual de etiquetas con marcas de graduación independientes y espaciado automático restaurado. Las dos copias conservan los datos originales del gráfico. No se requiere una presentación de entrada. El texto horizontal de las etiquetas facilita ver la diferencia de densidad.

```php
use aspose\slides\CategoryAxisType;
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TickMarkType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 30, 40, 660, 320);

    $chart->setLegend(false);
    $chart->getChartData()->getCategories()->clear();
    $chart->getChartData()->getSeries()->clear();

    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $workbook->clear(0);

    $series = $chart->getChartData()->getSeries()->add(ChartType::ClusteredColumn);
    for ($i = 0; $i < 24; $i++) {
        $categoryCell = $workbook->getCell(0, $i + 1, 0, "Category " . ($i + 1));
        $chart->getChartData()->getCategories()->add($categoryCell);
        $valueCell = $workbook->getCell(0, $i + 1, 1, 10 + $i % 6 * 5);
        $series->getDataPoints()->addDataPointForBarSeries($valueCell);
    }

    $axis = $chart->getAxes()->getHorizontalAxis();
    $axis->setCategoryAxisType(CategoryAxisType::Text);
    $axis->getTextFormat()->getTextBlockFormat()->setRotationAngle(0);
    $axis->getTextFormat()->getPortionFormat()->setFontHeight(12);
    $axis->setMajorTickMark(TickMarkType::Outside);
    $axis->setAutomaticTickLabelSpacing(true);
    $axis->setAutomaticTickMarksSpacing(true);

    // Diapositiva 2: mostrar cada tercera etiqueta, pero mantener una marca de graduación para cada categoría.
    $manualSlide = $presentation->getSlides()->addClone($slide);
    $manualChart = $manualSlide->getShapes()->get_Item(0);
    $manualAxis = $manualChart->getAxes()->getHorizontalAxis();
    $manualAxis->setAutomaticTickLabelSpacing(false);
    $manualAxis->setTickLabelSpacing(3);
    $manualAxis->setAutomaticTickMarksSpacing(false);
    $manualAxis->setTickMarksSpacing(1);

    // Diapositiva 3: permitir que el gráfico elija ambos intervalos nuevamente.
    $restoredSlide = $presentation->getSlides()->addClone($manualSlide);
    $restoredChart = $restoredSlide->getShapes()->get_Item(0);
    $restoredChart->getAxes()->getHorizontalAxis()->setAutomaticTickLabelSpacing(true);
    $restoredChart->getAxes()->getHorizontalAxis()->setAutomaticTickMarksSpacing(true);

    $presentation->save("CategoryAxisIntervals.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

**Espaciado automático (diapositiva 1):** En esta representación, se muestra cada segunda etiqueta de categoría y se envuelve en dos líneas. El resultado automático puede variar según el tamaño del gráfico, fuentes y el renderizador.

![Espaciado automático de etiquetas de categoría con las 24 columnas visibles](category-axis-automatic.png)

**Espaciado manual (diapositiva 2):** Cada tercera etiqueta se muestra en una línea, mientras que las marcas de graduación permanecen en cada intervalo de categoría. Las 24 columnas, incluidas las que no tienen etiquetas, siguen visibles con los mismos valores. La diapositiva 3 restaura la apariencia automática mostrada arriba.

![Intervalo manual de etiquetas de categoría de tres con las 24 columnas visibles](category-axis-manual.png)

### **Elegir el eje y el intervalo correctos**

Utilice este intervalo de recuento de categorías para un eje de categoría de texto, como el eje de categoría de un gráfico de columnas, líneas, áreas o barras. En un gráfico de columnas, es el eje horizontal. En un gráfico de barras horizontal, el eje de categoría es vertical, por lo que aplique estos ajustes al eje devuelto por [getVerticalAxis](https://reference.aspose.com/slides/php-java/aspose.slides/axesmanager/getverticalaxis/). El espaciado de marcas de graduación también se aplica a un eje de series en los gráficos que lo tengan.

No utilice el espaciado de etiquetas de categoría para establecer la escala numérica de un eje de valores. En un eje de valores, [setMajorUnit](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setmajorunit/) especifica una diferencia en los valores: por ejemplo, una unidad mayor de `10` produce marcas en 0, 10, 20, etc., cuando el eje comienza en cero. Un intervalo de etiqueta de categoría de `3` cuenta posiciones de categoría, independientemente de sus valores de datos. Los gráficos de dispersión y burbuja usan ejes de valores en lugar de un eje de categoría de texto. Para un eje de fechas, use unidades mayores y escalas basadas en tiempo como se describe en [Cambiar un eje de categorías](#change-a-category-axis).

## **Establecer el formato de fecha para los valores del eje de categorías**

El ejemplo reemplaza los datos predeterminados del gráfico con cuatro valores anuales. Las fechas se almacenan como números de serie OLE Automation en la primera hoja de cálculo (índice `0`), calculados como el número de días transcurridos desde el 30 de diciembre de 1899, para estas fechas. Use [setCategoryAxisType](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setcategoryaxistype/) con `CategoryAxisType::Date`, llame a [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setnumberformatlinkedtosource/) con `false` y pase `yyyy` a [setNumberFormat](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setnumberformat/) para que las etiquetas de categoría muestren años de cuatro dígitos independientemente del formato de la celda.

```php
use aspose\slides\CategoryAxisType;
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Line, 50, 50, 450, 300);

    $chart->getChartData()->getCategories()->clear();
    $chart->getChartData()->getSeries()->clear();

    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $workbook->clear(0);

    $baseDate = gmmktime(0, 0, 0, 12, 30, 1899);

    $series = $chart->getChartData()->getSeries()->add(ChartType::Line);
    for ($i = 0; $i < 4; $i++) {
        $date = gmmktime(0, 0, 0, 1, 1, 2015 + $i);
        $serialDate = ($date - $baseDate) / 86400;
        $categoryCell = $workbook->getCell(0, $i + 1, 0, $serialDate);
        $chart->getChartData()->getCategories()->add($categoryCell);

        $valueCell = $workbook->getCell(0, $i + 1, 1, $i + 1);
        $series->getDataPoints()->addDataPointForLineSeries($valueCell);
    }

    $chart->getAxes()->getHorizontalAxis()->setCategoryAxisType(CategoryAxisType::Date);
    $chart->getAxes()->getHorizontalAxis()->setNumberFormatLinkedToSource(false);
    $chart->getAxes()->getHorizontalAxis()->setNumberFormat("yyyy");

    $presentation->save("DateAxisFormat.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Establecer un ángulo de rotación para el título de un eje del gráfico**

Llame a [setTitle](https://reference.aspose.com/slides/php-java/aspose.slides/axis/settitle/) con `true` en el eje vertical, proporcione el texto del título y use [setRotationAngle](https://reference.aspose.com/slides/java/com.aspose.slides/icharttextblockformat/#setRotationAngle-float-) para rotar el título. El ángulo se mide en grados; este ejemplo guarda un gráfico de columnas con el título del eje de valores rotado 90 grados.

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 450, 300);
    $chart->getAxes()->getVerticalAxis()->setTitle(true);
    $chart->getAxes()->getVerticalAxis()->getTitle()->addTextFrameForOverriding("Value");
    $chart->getAxes()->getVerticalAxis()->getTitle()->getTextFormat()->getTextBlockFormat()->setRotationAngle(90);

    $presentation->save("RotatedAxisTitle.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Establecer la posición del eje en un eje de categoría o de valor**

Utilice [setAxisBetweenCategories](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setaxisbetweencategories/) para controlar si el eje de valores cruza el eje de categoría entre categorías o en las marcas de graduación de la categoría. Esta configuración se aplica a los ejes de categoría. El ejemplo lo establece en `true` en el eje de categoría horizontal de un gráfico de columnas y guarda el resultado.

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 450, 300);
    $chart->getAxes()->getHorizontalAxis()->setAxisBetweenCategories(true);

    $presentation->save("AxisBetweenCategories.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Establecer la unidad de visualización en un eje de valores del gráfico**

Utilice [setDisplayUnit](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setdisplayunit/) para escalar las etiquetas en un eje de valores sin cambiar los datos subyacentes. Con [DisplayUnitType](https://reference.aspose.com/slides/php-java/aspose.slides/displayunittype/) establecido en `Millions`, un valor de 60.000.000 se muestra como 60. El ejemplo crea un gráfico de columnas y aplica la unidad de visualización de millones a su eje vertical.

```php
use aspose\slides\ChartType;
use aspose\slides\DisplayUnitType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 450, 300);
    $chart->getAxes()->getVerticalAxis()->setDisplayUnit(DisplayUnitType::Millions);

    $presentation->save("Result.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Configurar un eje de valores logarítmico**

Un eje de valores logarítmico es útil cuando los valores positivos abarcan varios órdenes de magnitud. Por ejemplo, un servicio podría recibir 10, 100, 1.000, 10.000 y 100.000 solicitudes durante cinco periodos. En una escala lineal, los valores más pequeños aparecen muy juntos cerca de cero. Una escala logarítmica facilita comparar su crecimiento relativo: distancias iguales representan razones iguales en lugar de diferencias iguales.

Llame a [setLogarithmic](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setlogarithmic/) con `true` en el eje de valores y use [setLogBase](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setlogbase/) para elegir la base. Esto cambia cómo se muestran los valores existentes; no modifica los datos ni agrega una línea de tendencia logarítmica. Una línea de tendencia representa una relación ajustada en los datos y es una característica separada.

### **Elegir el eje de valores y la base**

Para un gráfico de líneas o de columnas, el eje de valores se obtiene con [getVerticalAxis](https://reference.aspose.com/slides/php-java/aspose.slides/axesmanager/getverticalaxis/). Para un gráfico de barras horizontal, se obtiene con [getHorizontalAxis](https://reference.aspose.com/slides/php-java/aspose.slides/axesmanager/gethorizontalaxis/). Los gráficos de dispersión y burbuja tienen dos ejes de valores, por lo que elija el eje horizontal para los valores X, el eje vertical para los valores Y, o ambos. No aplique escalado logarítmico a un eje de categorías.

La base logarítmica predeterminada es `10`. Para gráficos PPTX, use una base entre `2` y `1000`, inclusive; también se admiten bases fraccionarias como `2.5`. Con la base `10`, las potencias sucesivas como 10, 100, 1.000 y 10.000 están espaciadas uniformemente.

### **Comparar el escalado lineal y logarítmico**

El siguiente ejemplo autocontenido crea un gráfico de líneas con los cinco recuentos de solicitudes en la primera diapositiva, luego clona esa diapositiva y habilita un eje de valores logarítmico en base 10 en la segunda. Ambas diapositivas conservan los mismos datos.

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Line, 30, 40, 660, 200);

    $chart->setLegend(false);

    $chart->getChartData()->getCategories()->clear();
    $chart->getChartData()->getSeries()->clear();

    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $workbook->clear(0);

    $series = $chart->getChartData()->getSeries()->add(ChartType::Line);
    $values = [10, 100, 1000, 10000, 100000];

    for ($i = 0; $i < count($values); $i++) {
        $categoryCell = $workbook->getCell(0, $i + 1, 0, "Period " . ($i + 1));
        $chart->getChartData()->getCategories()->add($categoryCell);

        $valueCell = $workbook->getCell(0, $i + 1, 1, $values[$i]);
        $series->getDataPoints()->addDataPointForLineSeries($valueCell);
    }

    // Mantener la primera diapositiva lineal y cambiar solo la escala del eje de valores de la copia.
    $logarithmicSlide = $presentation->getSlides()->addClone($slide);
    $logarithmicChart = $logarithmicSlide->getShapes()->get_Item(0);
    $valueAxis = $logarithmicChart->getAxes()->getVerticalAxis();
    $valueAxis->setLogarithmic(true);
    $valueAxis->setLogBase(10);

    $presentation->save("LogarithmicAxis.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

**Escala lineal (diapositiva 1):** Distancias verticales iguales representan diferencias iguales en los recuentos de solicitudes. El valor más grande domina el gráfico, dificultando distinguir los valores más pequeños.

![Gráfico de líneas en PowerPoint que muestra cinco recuentos de solicitudes en un eje de valores lineal](value-axis-linear.png)

**Escala logarítmica (diapositiva 2):** Distancias verticales iguales representan razones iguales. Cada periodo tiene diez veces más solicitudes que el anterior, por lo que los puntos forman una línea recta ascendente en la escala base 10. Las etiquetas del eje siguen mostrando los recuentos originales de solicitudes.

![Los mismos cinco recuentos de solicitudes en PowerPoint en un eje de valores logarítmico base 10](value-axis-logarithmic.png)

### **Gestionar valores cero y negativos**

Una escala logarítmica solo puede mostrar valores estrictamente positivos. Verifique los datos antes de habilitarla. Si los valores cero o negativos son significativos, mantenga una escala lineal o muéstralos por separado. Si excluir esos valores es apropiado para el análisis, explique la omisión. No los reemplace silenciosamente por números positivos pequeños, ya que esto altera el significado de los datos. Cualquier mínimo o máximo configurado manualmente para un eje logarítmico también debe ser positivo.

## **Preguntas frecuentes**

**¿Cómo establezco el valor en el que un eje cruza al otro (cruce de eje)?**

Utilice [setCrossType](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setcrosstype/) para seleccionar el comportamiento de cruce. Para especificar un valor numérico de cruce, use [setCrossAt](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setcrossat/). Estas configuraciones le permiten mover el cruce de eje a una línea de base adecuada.

**¿Cómo puedo posicionar las etiquetas de las marcas respecto al eje?**

Llame a [setTickLabelPosition](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setticklabelposition/) usando [TickLabelPositionType](https://reference.aspose.com/slides/php-java/aspose.slides/ticklabelpositiontype/): `Low`, `High`, `NextTo` o `None`. Para controlar las propias marcas de graduación, use [setMajorTickMark](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setmajortickmark/) o [setMinorTickMark](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setminortickmark/); estas son independientes del posicionamiento de las etiquetas.