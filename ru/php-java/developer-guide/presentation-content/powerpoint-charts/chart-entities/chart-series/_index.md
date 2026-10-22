---
title: Управление данными серии диаграммы в презентациях на PHP
linktitle: Серии данных
type: docs
url: /ru/php-java/chart-series/
keywords:
- серия диаграммы
- перекрытие серии
- цвет серии
- имя серии
- точка данных
- ячейка рабочей книги
- промежуток серии
- отрицательное значение
- PowerPoint
- презентация
- PHP
- Aspose.Slides
description: "Узнайте, как управлять сериями диаграмм, точками данных, ячейками рабочей книги, форматированием, перекрытием, шириной промежутка и отрицательными значениями в презентациях с PHP."
---
## **Обзор**

Диаграмма может хранить построенные значения в ячейках рабочей книги или напрямую как числовые литералы. [ChartSeries](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/) представляет один набор связанных значений, а каждый [ChartDataPoint](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/) представляет точку в этом наборе. Объекты [ChartCategory](https://reference.aspose.com/slides/php-java/aspose.slides/chartcategory/) предоставляют подписи или группы значений, общие для всех наборов. В диаграммах, созданных с данными по умолчанию, имена наборов, категории и значения точек используют объекты [ChartDataCell](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatacell/) из рабочей книги диаграммы.

Для типичной диаграммы категорий рабочая книга по умолчанию использует строку 0 для имён наборов, столбец 0 для имён категорий и остальные ячейки для значений наборов. Индексы листа, строки и столбца, передаваемые в [ChartDataWorkbook::getCell](https://reference.aspose.com/slides/php-java/aspose.slides/chartdataworkbook/getcell/), нумеруются с нуля. Такое расположение удобно, когда вы создаёте диаграмму с данными по умолчанию, но не следует полагаться, что каждая существующая диаграмма использует его. Для загруженной презентации проверьте ячейки, на которые ссылаются наборы, категории и точки данных, прежде чем изменять значения в рабочей книге.

Настройки диаграммы имеют три уровня:

- Настройки уровня набора, такие как [ChartSeries::getFormat](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/getformat/), задают внешний вид по умолчанию для всех точек в наборе.
- Настройки точки данных, такие как [ChartDataPoint::getFormat](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/getformat/), переопределяют внешний вид набора для одной точки.
- Настройки группы применяются к совместимым наборам, принадлежащим одному [ChartSeriesGroup](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/). Доступ к группе можно получить через [ChartSeries::getParentSeriesGroup](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/getparentseriesgroup/), когда нужно задать параметры, такие как перекрытие или ширина промежутка.

Если явным образом не задана заливка точки или набора, стиль и тема диаграммы определяют автоматический внешний вид. Когда одновременно заданы параметры набора и точки, приоритет имеет форматирование точки.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **Установка значений серии с использованием числовых литералов**

Используйте числовые литералы, когда значения серии берутся из данных приложения или вычислений и не требуют ссылок на ячейки листа. Вызовите [setDataSourceTypeForValues](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapointcollection/setdatasourcetypeforvalues/) с [DataSourceType::DoubleLiterals](https://reference.aspose.com/slides/php-java/aspose.slides/datasourcetype/) перед присвоением каждой точке результата [getValue](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/getvalue/) через [setAsLiteralDouble](https://reference.aspose.com/slides/php-java/aspose.slides/doublechartvalue/setasliteraldouble/).

Настройка коллекции управляет типом источника всех значений точек в данном наборе. Метод [getDataSourceType](https://reference.aspose.com/slides/php-java/aspose.slides/basechartvalue/) каждой точки возвращает выбранный тип; изменить его можно через настройку коллекции. С `Worksheet` используйте [getAsCell](https://reference.aspose.com/slides/php-java/aspose.slides/doublechartvalue/getascell/) для доступа к ссылочной ячейке. С `DoubleLiterals` используйте [getAsLiteralDouble](https://reference.aspose.com/slides/php-java/aspose.slides/doublechartvalue/getasliteraldouble/) или `setAsLiteralDouble` для чтения или записи числа напрямую.

В следующем примере создаётся столбчатая диаграмма с наборами и категориями по умолчанию, затем вычисленные значения 10, 20 и т.д. назначаются существующим точкам первого набора. Пример сохраняет презентацию, открывает её вновь и выводит сохранённые значения.

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

Тип источника значения точки отличается от [ChartData::getDataSourceType](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getdatasourcetype/), который определяет конфигурацию внутренней или внешней рабочей книги диаграммы. Использование числовых литералов само по себе не удаляет встроенную рабочую книгу. В этом примере рабочая книга остаётся доступной для меток категорий, имён наборов и остальных наборов. См. [Рабочая книга диаграммы](/slides/ru/php-java/chart-workbook/) для управления рабочей книгой.

Для точечных и пузырчатых диаграмм используйте [setDataSourceTypeForXValues](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapointcollection/setdatasourcetypeforxvalues/) и [setDataSourceTypeForYValues](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapointcollection/setdatasourcetypeforyvalues/) для выбора источников [getXValue](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/getxvalue/) и [getYValue](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/getyvalue/). Пузырчатые диаграммы также используют [setDataSourceTypeForBubbleSizes](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapointcollection/setdatasourcetypeforbubblesizes/) для [getBubbleSize](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/getbubblesize/). Установите каждый применимый источник в `DoubleLiterals` перед присвоением чисел через метод `setAsLiteralDouble`.

## **Установка перекрытия наборов диаграммы**

[ChartSeries::getOverlap](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/getoverlap/) сообщает, насколько столбцы или бары перекрываются в 2D‑диаграмме, от -100 до 100 процентов. Это только чтение проекции настройки группы родительских наборов. Для изменения используйте [ChartSeriesGroup::setOverlap](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/setoverlap/), что обновит каждый совместимый набор в этой группе. Параметр применяется к типам диаграмм, где отображаются группированные бары или столбцы; на несвязанные группы наборов в комбинированной диаграмме он не влияет.

В следующем примере задаётся перекрытие для группы, содержащей первый набор:

```php
$firstSlideIndex = 0;
$firstSeriesIndex = 0;
$overlapPercent = 30;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item($firstSlideIndex);

    // Новая диаграмма содержит образцы серий, категорий и значений.
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

Результат:

![Перекрытие наборов](series_overlap.png)

## **Изменение цвета заливки набора**

Используйте [ChartSeries::getFormat](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/getformat/) для установки заливки по умолчанию для всего набора. Если у точки уже задана явная заливка, её настройка [ChartDataPoint::getFormat](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/getformat/) переопределяет заливку набора для этой точки.

В следующем примере применяется сплошная синяя заливка к первому набору:

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

Результат:

![Цвет набора](series_color.png)

## **Изменение имени набора**

Имя набора хранится в рабочей книге данных диаграммы и обычно отображается в легенде. В рабочей книге по умолчанию для сгруппированной столбчатой диаграммы ячейка B1 находится в строке 0, столбце 1 и содержит имя первого набора. Именованные переменные в следующем примере делают эту структуру явной:

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

Вы также можете обновить ячейку, уже используемую в [ChartSeries::getName](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/getname/). Такой подход позволяет избежать предположений о конкретных строках и столбцах в существующей диаграмме:

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

Результат:

![Имя набора](series_name.png)

### **Создание набора с именем из нескольких ячеек**

Составное имя набора удобно, когда название продукта и отчётный период хранятся в разных ячейках рабочей книги. Например, можно объединить `Product A` из B1 и `2026` из C1 в одно имя набора, при этом оба компонента остаются привязанными к своим исходным ячейкам.

Используйте [ChartDataWorkbook::getCellCollection](https://reference.aspose.com/slides/php-java/aspose.slides/chartdataworkbook/getcellcollection/) для получения диапазона имён, затем передайте эту коллекцию в [ChartSeriesCollection::add](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriescollection/add/). Параметр `skipHiddenCells` определяет, включать ли скрытые ячейки: `true` — исключает, `false` — включает. В примере используется `false`, чтобы включить каждую ячейку диапазона имён.

Следующий пример создаёт презентацию с одним набором и двумя точками данных. Ячейки B1:C1 содержат только имя набора; A2:A3 — подписи категорий, а B2:B3 — числовые значения.

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

    // Эти две ячейки задают имя серии.
    $workbook->getCell(0, 0, 1, "Product A");
    $workbook->getCell(0, 0, 2, "2026");
    $nameCells = $workbook->getCellCollection('Sheet1!$B$1:$C$1', false);
    $series = $chart->getChartData()->getSeries()->add($nameCells, ChartType::ClusteredColumn);

    // Отдельные ячейки задают категории и числовые точки данных.
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

Получаемое имя набора — `Product A 2026`, между двумя значениями вставлен пробел. Легенда отображает его как одну запись для обоих столбцов. Ниже изображён результат:

![Столбчатая диаграмма с названиями Север и Юг и составным именем набора Product A 2026 в легенде](composite_series_name.png)

## **Получение автоматического цвета заливки набора**

[ChartSeries::getAutomaticSeriesColor](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/getautomaticseriescolor/) возвращает цвет, вычисленный из индекса набора и стиля диаграммы. Это цвет, используемый, когда заливка набора не задана явно. Вызов метода лишь читает вычисленный цвет; он не назначает новую заливку.

В следующем примере выводится автоматический цвет каждого набора по умолчанию:

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

Пример вывода для стиля диаграммы по умолчанию:

```text
Series 0: java.awt.Color[r=79,g=129,b=189]
Series 1: java.awt.Color[r=192,g=80,b=77]
Series 2: java.awt.Color[r=155,g=187,b=89]
```

Точные цвета зависят от стиля и темы диаграммы.

## **Установка инвертированного цвета заливки для набора**

Для наборов баров, столбцов и пузырей [ChartSeries::setInvertIfNegative](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/setinvertifnegative/) позволяет отображать отрицательные значения другим цветом. Задайте обычную заливку набора как сплошную, включите инверсию и задайте цвет отрицательных значений через [ChartSeries::getInvertedSolidFillColor](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/getinvertedsolidfillcolor/). Отрицательные числа в рабочей книге остаются без изменений; меняется только их цвет отображения.

Следующий пример заменяет данные диаграммы на один набор. Строка листа 0 содержит имя набора, столбец 0 — названия категорий, столбец 1 — значения:

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

Результат:

![Инвертированный сплошной цвет заливки](inverted_solid_fill_color.png)

Инверсию можно включить для одной точки через [ChartDataPoint::setInvertIfNegative](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/setinvertifnegative/). В следующем примере инверсия отключена для набора и включена только для выбранной точки, которой также присвоено отрицательное значение, чтобы эффект был виден:

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

## **Очистка значения конкретной точки данных**

Чтобы сделать одну точку пустой, не удаляя остальные, установите её ячейку в рабочей книге в `null`. Для столбчатой диаграммы значение доступно через [ChartDataPoint::getValue](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/getvalue/). Точка остаётся на той же позиции категории, но диаграмма считает её пустой в соответствии с настройками отображения пустых значений.

Следующий пример очищает только вторую точку первого набора:

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

Точечные диаграммы используют отдельные ячейки X и Y, а пузырьковые также используют ячейку размера. Очищайте только ту ячейку, которая представляет значение, которое нужно удалить. Не вызывайте [ChartDataPointCollection::clear](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapointcollection/clear/) если хотите сохранить остальные точки, так как этот метод удаляет все точки из коллекции.

## **Управление отображением пустых ячеек**

Скрытые ячейки, содержащие значения, рассматриваются отдельно от пустых ячеек. Чтобы включать или исключать данные из скрытых строк и столбцов листа, см. [Включить данные из скрытых строк и столбцов](/slides/ru/php-java/chart-workbook/#include-data-from-hidden-rows-and-columns).

Пустая ячейка рабочей книги представляет отсутствие данных; ячейка, содержащая `0`, представляет известное числовое значение. Вызовите [ChartDataCell::setValue](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatacell/setvalue/) с `null`, чтобы сделать ячейку пустой. Числовой ноль остаётся нулём независимо от настройки пустой ячейки.

Используйте [Chart::setDisplayBlanksAs](https://reference.aspose.com/slides/php-java/aspose.slides/chart/setdisplayblanksas/) для выбора способа отображения пустых ячеек. Эта настройка применяется ко всей диаграмме. Она меняет способ построения пустых точек без заполнения пустой ячейки нулём или интерполированным значением.

Следующий самостоятельный пример создаёт линейную диаграмму с одним набором, очищает значение для Дня 3 и сохраняет одну и ту же диаграмму в трёх режимах. Входной файл не требуется. [ChartDataWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdataworkbook/) использует лист 0, столбец 0 для меток категорий и столбец 1 для значений; строка 0 хранит имя набора. Итоговые данные: `10, 20, empty, 30, 40`.

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

    // Оставить день 3 действительно пустым, сохранив при этом его категорию и точку данных.
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

Каждый выходной файл сохраняет режим, выбранный перед сохранением: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx` и `empty_cells_Span.pptx`. Чтобы сохранить только одну версию, задайте нужный режим и сохраните презентацию один раз вместо перебора режимов.

Сравнение ниже показывает одинаковые данные во всех трёх файлах. День 3 пуст в рабочей книге во всех случаях:

![Линейные диаграммы с одинаковыми данными: Gap разрывает линию в Дне 3, Zero опускает линию к нулю, Span соединяет День 2 с Днём 4.](display_blanks_as.png)

Видимый эффект зависит от типа диаграммы. На линейных диаграммах все три режима легко сравнить. У баров и столбцов нет линии для соединения пропущенной категории, поэтому `Span` не может создать соединительный сегмент, показанный выше; пустой столбец и столбец нулевой высоты могут выглядеть одинаково. Аналогично, точечная диаграмма только с маркерами не имеет соединительной линии. Не ожидайте трёх разных результатов для каждого типа диаграммы; проверьте вывод для используемого типа.

## **Установка ширины промежутка между наборами**

Ширина промежутка — это пространство между соседними кластерами баров или столбцов, выраженное в процентах от их ширины. Как и перекрытие, она относится к родительской группе наборов, а не к отдельному набору. Вызовите [ChartSeriesGroup::setGapWidth](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/setgapwidth/) один раз для группы. Большое значение создаёт больший промежуток между кластерами; меньшее — делает их плотнее.

В следующем примере изменяется ширина промежутка и сохраняется только итоговая презентация:

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

Результат:

![Ширина промежутка](gap_width.png)

## **FAQ**

**Какие типы диаграмм поддерживают наборы данных?**

Все типы диаграмм, представленные перечислением [ChartType](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/), используют данные диаграммы, но их наборы не всегда имеют одинаковую структуру значений или настройки. Например, диаграммы категорий используют категории и значения, точечные — X и Y, а пузырьковые добавляют размеры пузырей. Используйте метод создания точек, соответствующий типу набора. Параметры, такие как перекрытие и ширина промежутка, применимы только к совместимым группам баров или столбцов.

**Что такое группа наборов диаграммы?**

[ChartSeriesGroup](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/) содержит совместимые наборы, которые разделяют настройки построения на уровне группы. Комбинированная диаграмма может содержать более одной группы, поэтому изменение группы через один набор не обязательно меняет все наборы в диаграмме.

**Создаётся ли новая диаграмма с данными по умолчанию?**

Да. По умолчанию [ShapeCollection.addChart](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addchart/) создаёт примерные наборы, категории и значения. Вы можете редактировать эти ячейки или очистить как наборы, так и коллекции категорий перед добавлением полностью пользовательского набора данных. Есть перегрузка, позволяющая создать диаграмму без данных по умолчанию.

**Как объекты диаграммы связываются с ячейками рабочей книги?**

Имена наборов, подписи категорий и значения точек данных ссылаются на ячейки в [ChartDataWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdataworkbook/). Изменение ссылочной ячейки обновляет соответствующий элемент диаграммы. При построении собственных данных сохраняйте согласованность строк категорий и строк значений наборов, чтобы каждая точка отображалась под нужной категорией.

**Как очистить одну точку, а не весь набор?**

Установите соответствующую ячейку значения в `null`, чтобы точка сохранила позицию категории как пустую. Используйте [ChartDataPointCollection::clear](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapointcollection/clear/) только когда хотите удалить все точки из набора. Если удаляете также категории, обновите каждый набор, чтобы их значения оставались согласованными с коллекцией категорий.

**Как отображаются пустые точки?**

Результат зависит от типа диаграммы и настройки, выбранной через [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/php-java/aspose.slides/chart/setdisplayblanksas/). Поддерживаемые диаграммы могут отображать пустые места как разрывы, как нулевые значения или соединяя соседние точки. Выберите настройку, соответствующую смыслу отсутствующих данных в вашей презентации. См. раздел [Управление отображением пустых ячеек](#control-the-display-of-empty-cells) для полного примера и визуального сравнения.

**Как форматируются отрицательные значения?**

Для поддерживаемых наборов баров, столбцов и пузырей вызовите [ChartSeries::setInvertIfNegative](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/setinvertifnegative/) и задайте цвет, возвращаемый [ChartSeries::getInvertedSolidFillColor](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/getinvertedsolidfillcolor/). Для отдельной точки можно переопределить поведение через [ChartDataPoint::setInvertIfNegative](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/setinvertifnegative/). Эти методы влияют только на форматирование, а не на сохранённые числовые значения.

**Какой формат выигрывает, если заданы и набор, и точка?**

Явное форматирование точки имеет приоритет для этой точки. Другие точки продолжают использовать явный формат набора или, если формат набора не определён, автоматический стиль и тему диаграммы. Настройки группы, такие как перекрытие и ширина промежутка, управляют расположением и не переопределяют форматирование точек.

**Есть ли ограничение на количество наборов в диаграмме?**

Aspose.Slides не накладывает отдельного фиксированного ограничения на количество наборов. На практике ограничения задают размеры файла презентации, доступная память, время рендеринга и читаемость диаграммы.

**Что изменить, если столбцы слишком близко или слишком далеко друг от друга?**

Вызовите [ChartSeriesGroup::setGapWidth](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/setgapwidth/) для соответствующей родительской группы наборов. Увеличьте значение, чтобы расширить промежуток между кластерами, или уменьшите, чтобы собрать кластеры ближе.