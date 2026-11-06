---
title: Управление метками данных диаграмм в презентациях с использованием PHP
linktitle: Метка данных
type: docs
url: /ru/php-java/chart-data-label/
keywords:
- диаграмма
- метка данных
- точность данных
- процент
- расстояние метки
- положение метки
- PowerPoint
- презентация
- PHP
- Aspose.Slides
description: "Узнайте, как добавлять и форматировать метки данных диаграмм в презентациях PowerPoint с помощью Aspose.Slides для PHP через Java, чтобы сделать слайды более привлекательными."
---
## **Введение**

Метки данных отображают информацию о сериалах диаграммы и отдельных точках данных, помогая читателям определять значения и понимать диаграмму. В этой статье объясняется, как форматировать значения, отображать проценты, считывать текст метки, управлять метками за пределами максимума оси, регулировать расстояние между метками оси категорий и размещать метки круговой диаграммы.

## **Подсчёт видимых меток данных**

Используйте [getCountOfVisibleDataLabels](https://reference.aspose.com/slides/php-java/aspose.slides/datalabelcollection/getcountofvisibledatalabels/) для проверки количества меток данных, включённых для отображения, перед публикацией презентации. В отличие от [getCount](https://reference.aspose.com/slides/php-java/aspose.slides/datalabelcollection/getcount/), который возвращает общее количество меток в коллекции, он учитывает значения по умолчанию серии и индивидуальные настройки меток.

Этот пример создаёт столбчатую диаграмму с одной серией и тремя точками данных. Он получает коллекцию меток серии через [getLabels](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/getlabels/) и выводит количество видимых меток по мере изменения настроек: **0, 3, 2, 3**. Общее количество остаётся **3**.

```php
use aspose\slides\Presentation;
use aspose\slides\ChartType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 500, 300);

    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();

    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $seriesCell = $workbook->getCell(0, 0, 1, "Values");
    $series = $chart->getChartData()->getSeries()->add($seriesCell, $chart->getType());

    for ($i = 0; $i < 3; $i++) {
        $categoryCell = $workbook->getCell(0, $i + 1, 0, "Category " . ($i + 1));
        $chart->getChartData()->getCategories()->add($categoryCell);
        $valueCell = $workbook->getCell(0, $i + 1, 1, ($i + 1) * 10);
        $series->getDataPoints()->addDataPointForBarSeries($valueCell);
    }

    $labels = $series->getLabels();
    echo "Total: " . java_values($labels->getCount()) . "; visible: " . java_values($labels->getCountOfVisibleDataLabels()) . PHP_EOL; // Всего: 3; видимых: 0

    $labels->getDefaultDataLabelFormat()->setShowValue(true);
    echo "Visible: " . java_values($labels->getCountOfVisibleDataLabels()) . PHP_EOL; // Видимых: 3

    $labels->get_Item(1)->getDataLabelFormat()->setShowValue(false);
    echo "Visible: " . java_values($labels->getCountOfVisibleDataLabels()) . PHP_EOL; // Видимых: 2

    $labels->get_Item(1)->getDataLabelFormat()->setShowLegendKey(true);
    echo "Visible: " . java_values($labels->getCountOfVisibleDataLabels()) . PHP_EOL; // Видимых: 3
} finally {
    $presentation->dispose();
}
```

Метод [getDefaultDataLabelFormat](https://reference.aspose.com/slides/php-java/aspose.slides/datalabelcollection/getdefaultdatalabelformat/) серии предоставляет настройки по умолчанию. Передача `true` в [setShowValue](https://reference.aspose.com/slides/php-java/aspose.slides/datalabelformat/setshowvalue/) отображает значения для всех трёх меток. Передача `false` через [getDataLabelFormat](https://reference.aspose.com/slides/php-java/aspose.slides/datalabel/getdatalabelformat/) отдельной метки переопределяет эту настройку для выбранной метки. Передача `true` в [setShowLegendKey](https://reference.aspose.com/slides/php-java/aspose.slides/datalabelformat/setshowlegendkey/) снова делает эту метку видимой, хотя её значение остаётся скрытым.

Количество видимых меток отражает настройки видимости. Оно не измеряет, перекрываются ли метки, обрезаются ли они или читаемы ли в отрендеренной диаграмме.

## **Установить точность данных в метках диаграммы**

Используйте [setNumberFormatOfValues](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/setnumberformatofvalues/) , чтобы форматировать значения серии. Этот пример создаёт линейную диаграмму с данными по умолчанию, отображает её таблицу данных и включает метки значений для первой серии. Формат `#,##0.00` выводит разделитель тысяч и два десятичных знака, не изменяя исходные значения.

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

Чтобы отформатировать числовые ячейки во встроенной в диаграмму книге, см. [Установить пользовательские числовые форматы для ячеек рабочей книги](/slides/ru/php-java/chart-workbook/#set-custom-number-formats-for-workbook-cells). Этот пример также показывает, как метки значений используют форматы исходных ячеек, сохраняя при этом хранимые числовые значения.

## **Отображать процент в виде меток**

Для накопительной столбчатой диаграммы вычислите каждое значение как процент от общей суммы категории и присвойте текст текстовому фрейму, возвращаемому [getTextFrameForOverriding](https://reference.aspose.com/slides/php-java/aspose.slides/datalabel/gettextframeforoverriding/). Этот пример использует данные диаграммы по умолчанию и отображает проценты с двумя десятичными знаками шрифтом 8 пунктов. Категории с нулевой суммой пропускаются, чтобы избежать деления на ноль. Пересчитайте пользовательский текст метки, если данные диаграммы изменятся.

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

## **Установить знак процента в метках диаграммы**

Когда значения хранятся в виде дробей, используйте [setNumberFormat](https://reference.aspose.com/slides/php-java/aspose.slides/datalabelformat/setnumberformat/) , чтобы отображать проценты. Передайте `false` в [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/php-java/aspose.slides/datalabelformat/setnumberformatlinkedtosource/) , чтобы применить формат метки независимо от исходных ячеек.

Этот пример создаёт 100% накопительную столбчатую диаграмму с красными и синими сериями по четырём категориям. Каждая пара значений в сумме даёт 1. Формат метки `0.0%` выводит 0.30 как 30.0%, в то время как вертикальная ось использует два десятичных знака. Обе серии используют белый текст метки размером 10 пунктов.

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

## **Получить фактический текст меток данных**

Используйте [getActualLabelText](https://reference.aspose.com/slides/php-java/aspose.slides/datalabel/getactuallabeltext/) , чтобы получить текст, сформированный настройками метки данных. Это полезно при извлечении меток для отчётов, поиске содержимого презентаций или проверке сгенерированных диаграмм. В примере ниже формат метки данных по умолчанию ([data label format](https://reference.aspose.com/slides/php-java/aspose.slides/datalabelformat/)) объединяет название категории, название серии и значение. Одна точка форматирует своё значение как процент, а другая использует пользовательский текст из [getTextFrameForOverriding](https://reference.aspose.com/slides/php-java/aspose.slides/datalabel/gettextframeforoverriding/).

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

Число, хранящееся в точке данных, остаётся `0.75`, даже если её метка показывает `75%` вместе с названиями категории и серии. Пользовательский текст заменяет сгенерированный текст метки. [getActualLabelText](https://reference.aspose.com/slides/php-java/aspose.slides/datalabel/getactuallabeltext/) возвращает полученную строку метки в любом случае. Проверяйте [isVisible](https://reference.aspose.com/slides/php-java/aspose.slides/datalabel/isvisible/) отдельно, как показано выше, когда необходимо извлекать только видимые метки.

## **Управление метками данных за пределами максимума оси**

Если вы вручную ограничиваете диапазон оси, некоторые точки данных могут превышать её максимум. Используйте [setShowDataLabelsOverMaximum](https://reference.aspose.com/slides/php-java/aspose.slides/chart/setshowdatalabelsovermaximum/) , чтобы управлять отображением их меток данных. Эта настройка изменяет видимость меток; она не меняет диапазон оси или исходные значения данных.

Пример ниже создаёт 2‑мерную сгруппированную столбчатую диаграмму со значениями 60 и 120. Он передаёт `false` в [setAutomaticMaxValue](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setautomaticmaxvalue/) и задаёт максимум 100 с помощью [setMaxValue](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setmaxvalue/) на вертикальной оси. На первом слайде разрешены метки за пределами максимума; копия этого слайда отключает их. Оба слайда сохраняются в `DataLabelsOverMaximum.pptx`.

Включите метки значений с помощью [setShowValue](https://reference.aspose.com/slides/php-java/aspose.slides/datalabelformat/setshowvalue/). Настройка уровня диаграммы сама по себе не включает отображение значений и не переопределяет отключённое отображение значения отдельной метки. Этот пример включает значения для всей серии и использует [setPosition](https://reference.aspose.com/slides/php-java/aspose.slides/datalabelformat/setposition/) , чтобы разместить метки с внешней стороны каждого столбца.

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

Ниже показаны изображения сохранённых слайдов, отрисованных Microsoft PowerPoint. При `true` метка **120** видна у верхней границы; при `false` она скрыта. Метка **60** остаётся видимой, максимум оси остаётся **100**, и в обоих случаях вторая точка данных остаётся **120**.

| setShowDataLabelsOverMaximum(true) | setShowDataLabelsOverMaximum(false) |
| --- | --- |
| ![Диаграмма PowerPoint, показывающая метку значения 120 при максимуме оси 100](data-labels-over-maximum-true.png) | ![Диаграмма PowerPoint, скрывающая метку значения 120 при максимуме оси 100](data-labels-over-maximum-false.png) |

{{% alert color="info" title="Chart Type" %}}
В этом примере используется 2‑мерная столбчатая диаграмма со значительной осью. Диаграммы без значительной оси, такие как круговые и кольцевые диаграммы, не имеют максимума оси, который можно ограничить таким образом.
{{% /alert %}}

## **Установить расстояние метки от оси**

Используйте [setLabelOffset](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setlabeloffset/) , чтобы управлять расстоянием между метками оси категорий и осью. Значение представляет собой процент от максимального размера шрифта меток оси. Этот пример создаёт сгруппированную столбчатую диаграмму и устанавливает смещение меток горизонтальной оси в 500. Эта настройка влияет на метки оси категорий, а не на метки, прикреплённые к отдельным точкам данных.

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

## **Регулировка расположения меток**

На круговой диаграмме отрегулируйте расположение меток данных, чтобы улучшить интервалы и освободить место для линий‑соединителей.

Этот пример отображает значение первой точки данных, размещает её метку за пределами сегмента и регулирует её горизонтальное и вертикальное смещение с помощью [setX](https://reference.aspose.com/slides/php-java/aspose.slides/datalabel/setx/) и [setY](https://reference.aspose.com/slides/php-java/aspose.slides/datalabel/sety/). Эти смещения относительно ширины и высоты диаграммы соответственно.

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

![Круговая диаграмма с отрегулированным положением метки данных](pie-chart-adjusted-label.png)

## **Форматировать линии‑соединители**

Когда метки круговой диаграммы находятся за пределами сегментов, линии‑соединители помогают читателям сопоставить каждое значение с соответствующим сегментом. Контрастный цвет и слегка утолщённая линия делают такие соединения более удобными, а прозрачность и пунктирный стиль сохраняют линии визуально незаметными.

Используйте [getLeaderLinesFormat](https://reference.aspose.com/slides/php-java/aspose.slides/datalabelcollection/getleaderlinesformat/) , чтобы форматировать линии‑соединители на уровне коллекции меток данных серии. Настройки в `$series->getLabels()->getLeaderLinesFormat()->getLine()` применяются к коллекции, а не к отдельной метке.

Этот пример создаёт круговую диаграмму с данными по умолчанию, отображает значения за пределами сегментов и включает [setShowLeaderLines](https://reference.aspose.com/slides/php-java/aspose.slides/datalabelformat/setshowleaderlines/). Он перемещает две метки дальше от их сегментов, используя смещения [setX](https://reference.aspose.com/slides/php-java/aspose.slides/datalabel/setx/) и [setY](https://reference.aspose.com/slides/php-java/aspose.slides/datalabel/sety/) , выраженные в долях ширины и высоты диаграммы. Входная презентация не требуется.

[getFillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/getfillformat/) линии задаёт сплошной синий цвет с альфа‑значением 191 из 255, обеспечивая приблизительно 25 % прозрачности. [setWidth](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/setwidth/) устанавливает толщину в 2 пункта, а [setDashStyle](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/setdashstyle/) делает линию пунктирной.

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

    // Переместить две метки дальше от их секторов.
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

Включение линий‑соединителей не гарантирует появление линии для каждой метки. Видимость зависит от размещения меток и поведения компоновки диаграммы. В этом примере две сдвинутые метки имеют видимые линии‑соединители; метки, оставшиеся близко к своим сегментам, их не требуют.

Следующее изображение показывает сохранённый `FormattedLeaderLines.pptx`, отрисованный с помощью Aspose.Slides:

![Круговая диаграмма с синими, полупрозрачными пунктирными линиями‑соединителями, соединяющими две внешние метки с их сегментами](formatted-leader-lines.png)

## **Добавить несколько строк меток данных над столбчатой диаграммой**

Этот пример создаёт столбчатую диаграмму с двумя строками меток данных над областью графика. Серия A отображает видимые столбцы, а серии B и C предоставляют дополнительные метки. Их столбцы скрыты удалением заливки и контура. Метод [ChartSeriesGroup::setOverlap](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/setoverlap/) выравнивает все три серии по общим центрам категорий.

Настройки [ChartPlotArea](https://reference.aspose.com/slides/php-java/aspose.slides/chartplotarea/) резервируют пространство для строк меток. После того как [Chart::validateChartLayout](https://reference.aspose.com/slides/php-java/aspose.slides/chart/validatechartlayout/) вычислит позиции по умолчанию, [DataLabel::setX](https://reference.aspose.com/slides/php-java/aspose.slides/datalabel/setx/) и [DataLabel::setY](https://reference.aspose.com/slides/php-java/aspose.slides/datalabel/sety/) сохраняют горизонтальное выравнивание и применяют вертикальные смещения, чтобы разместить метки в две строки. Числа остаются метками данных, связанными со значениями серий; только заголовки строк представляют отдельные текстовые формы.

```php
use aspose\slides\Presentation;
use aspose\slides\ChartType;
use aspose\slides\FillType;
use aspose\slides\LegendDataLabelPosition;
use aspose\slides\LayoutTargetType;
use aspose\slides\ShapeType;
use aspose\slides\SaveFormat;

$colors = java("java.awt.Color');

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
            // Скрыть столбцы B и C, но оставить их метки данных.
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

    // Выровнять все три серии по одинаковым центрам категорий.
    $chart->getChartData()->getSeries()->get_Item(0)->getParentSeriesGroup()->setOverlap(100);

    // Использовать меньше сеточных линий для этого компактного примера.
    $chart->getAxes()->getVerticalAxis()->setAutomaticMajorUnit(false);
    $chart->getAxes()->getVerticalAxis()->setMajorUnit(10);

    // Зарезервировать пространство над областью графика для двух рядов меток данных.
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
            // Сохранить положение по умолчанию по горизонтали. Y — смещение от
            // позиции метки по умолчанию, выраженное в долях высоты диаграммы.
            $actualY = java_values($dataLabel->getActualY());
            $dataLabel->setX(0);
            $dataLabel->setY($rowTop - $actualY / $chartHeight);
        }

        // Только заголовок строки является отдельной текстовой фигурой.
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

![Столбчатая диаграмма с двумя строками меток данных над областью графика](multiple-rows-of-labels.png)

## **FAQ**

**Как предотвратить перекрытие меток данных на плотных диаграммах?**

Сочетайте автоматическое размещение меток, линии‑соединители и уменьшенный размер шрифта; при необходимости скрывайте некоторые поля (например, категорию) или отображайте метки только для экстремальных значений или ключевых точек.

**Как отключить метки только для нулевых, отрицательных или пустых значений?**

Отфильтруйте точки данных перед включением меток и отключите отображение для значений 0, отрицательных значений или отсутствующих значений согласно заданному правилу.

**Как обеспечить единый стиль меток при экспорте в PDF/изображения?**

Явно задайте семейство шрифтов и размер, а также убедитесь, что шрифт доступен в среде рендеринга, чтобы избежать подстановки.