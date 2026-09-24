---
title: Управление сериями данных диаграммы в презентациях на PHP
linktitle: Серии данных
type: docs
url: /ru/php-java/chart-series/
keywords:
- серии диаграммы
- перекрытие серий
- цвет серии
- имя серии
- точка данных
- ячейка рабочей книги
- промежуток между сериями
- отрицательное значение
- PowerPoint
- презентация
- PHP
- Aspose.Slides
description: "Узнайте, как управлять сериями диаграмм, точками данных, ячейками рабочей книги, форматированием, перекрытием, шириной промежутка и отрицательными значениями в презентациях с помощью PHP."
---
## **Обзор**

Диаграмма хранит отображаемые данные в рабочей книге данных диаграммы. A [ChartSeries](https://reference.aspose.com/slides/ru/php-java/aspose.slides/chartseries/) представляет один набор связанных значений, и каждый [ChartDataPoint](https://reference.aspose.com/slides/ru/php-java/aspose.slides/chartdatapoint/) в серии ссылается на одну или несколько ячеек рабочей книги. Объекты [ChartCategory](https://reference.aspose.com/slides/ru/php-java/aspose.slides/chartcategory/) предоставляют метки или значения группировки, общие для серии. Поэтому имя серии, категории и значения точек соединены с объектами [ChartDataCell](https://reference.aspose.com/slides/ru/php-java/aspose.slides/chartdatacell/), а не хранятся только как текст отображения.

Для типичной диаграммы категорий стандартная рабочая книга использует строку 0 для имён серий, столбец 0 для имён категорий и остальные ячейки для значений серий. Индексы листа, строки и столбца, передаваемые в [ChartDataWorkbook.getCell](https://reference.aspose.com/slides/ru/php-java/aspose.slides/chartdataworkbook/#getCell), нулевые. Такая раскладка полезна при создании диаграммы с данными по умолчанию, но не следует предполагать, что каждый существующий график использует её. Для загруженной презентации проверьте ячейки, на которые ссылаются серии, категории и точки данных, прежде чем менять значения в рабочей книге.

Настройки диаграммы имеют три разных уровня:

- Настройки уровня серии, такие как [ChartSeries.getFormat](https://reference.aspose.com/slides/ru/php-java/aspose.slides/chartseries/#getFormat), определяют внешний вид всех точек в одной серии по умолчанию.
- Настройки отдельной точки данных, такие как [ChartDataPoint.getFormat](https://reference.aspose.com/slides/ru/php-java/aspose.slides/chartdatapoint/#getFormat), переопределяют внешний вид серии для одной точки.
- Настройки группы применяются к совместимым сериям, принадлежащим к одной [ChartSeriesGroup](https://reference.aspose.com/slides/ru/php-java/aspose.slides/chartseriesgroup/). Доступ к группе осуществляется через [ChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/ru/php-java/aspose.slides/chartseries/#getParentSeriesGroup), когда необходимо задать параметры, такие как перекрытие или ширина промежутка.

Когда явная заливка точки или серии не задана, стиль и тема диаграммы определяют автоматический внешний вид. Если задаются как форматирование серии, так и точки, форматирование точки имеет приоритет для этой точки.

![график серии PowerPoint](chart-series-powerpoint.png)

## **Установить перекрытие серии диаграммы**

[ChartSeries.getOverlap](https://reference.aspose.com/slides/ru/php-java/aspose.slides/chartseries/#getOverlap) сообщает, насколько столбцы или столбики перекрываются в 2‑D диаграмме, в диапазоне от ‑100 до 100 процентов. Это только чтение проекции настройки в родительской группе серий. Используйте [ChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/ru/php-java/aspose.slides/chartseriesgroup/#setOverlap) для обновления всех совместимых серий в этой группе. Этот параметр применяется к типам диаграмм, отображающим группированные столбцы или столбики; он не влияет на несвязанные группы серий в комбинированной диаграмме.

Следующий пример задаёт перекрытие для группы, содержащей первую серию:

```php
$firstSlideIndex = 0;
$firstSeriesIndex = 0;
$overlapPercent = 30;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item($firstSlideIndex);

    // Новая диаграмма содержит примерные серии, категории и значения.
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

![Перекрытие серии](series_overlap.png)

## **Изменить цвет заливки серии**

Используйте [ChartSeries.getFormat](https://reference.aspose.com/slides/ru/php-java/aspose.slides/chartseries/#getFormat) для установки заливки по умолчанию для всей серии. Если у точки уже задана явная заливка, её настройка [ChartDataPoint.getFormat](https://reference.aspose.com/slides/ru/php-java/aspose.slides/chartdatapoint/#getFormat) переопределяет заливку серии для этой точки.

Следующий пример применяет сплошную синюю заливку к первой серии:

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

![Цвет серии](series_color.png)

## **Изменить имя серии**

Имя серии хранится в рабочей книге данных диаграммы и обычно отображается в легенде. В стандартной рабочей книге, созданной для кластерной столбчатой диаграммы, ячейка B1 находится в строке 0, столбце 1 и содержит имя первой серии. Именованные переменные в следующем примере делают эту структуру явной:

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

Вы также можете обновить ячейку, уже возвращаемую методом [ChartSeries.getName](https://reference.aspose.com/slides/ru/php-java/aspose.slides/chartseries/#getName). Такой подход исключает предположение о конкретных строках и столбцах в уже существующей диаграмме:

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

![Имя серии](series_name.png)

## **Получить автоматический цвет заливки серии**

[ChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/ru/php-java/aspose.slides/chartseries/#getAutomaticSeriesColor) возвращает цвет, вычисляемый на основе индекса серии и стиля диаграммы. Это цвет, используемый, когда заливка серии не задана явно. Вызов метода только читает вычисленный цвет; он не присваивает новую заливку.

Следующий пример выводит автоматический цвет каждой серии по умолчанию:

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

## **Установить инвертированный цвет заливки для серии диаграммы**

Для столбцов, столбиков и пузырьковых серий метод [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/ru/php-java/aspose.slides/chartseries/#setInvertIfNegative) может отображать отрицательные значения другой заливкой. Установите обычную заливку серии как сплошную, включите инверсию и задайте цвет отрицательного значения через [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/ru/php-java/aspose.slides/chartseries/#getInvertedSolidFillColor). Отрицательные числа остаются неизменными в рабочей книге; меняется только их цвет отображения.

Следующий пример заменяет стандартные данные диаграммы одной серией. В листе строка 0 содержит имя серии, столбец 0 — имена категорий, столбец 1 — значения:

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

Вы можете включить инверсию для одной точки через [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/ru/php-java/aspose.slides/chartdatapoint/#setInvertIfNegative). В следующем примере инверсия отключена для серии и включена только для выбранной точки. Точке также присвоено отрицательное значение, чтобы эффект был виден:

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

## **Очистить конкретное значение точки данных**

Чтобы сделать одну точку пустой, не удаляя остальные, установите её ячейку в рабочей книге в `null`. Для столбчатой диаграммы отображаемое значение доступно через [ChartDataPoint.getValue](https://reference.aspose.com/slides/ru/php-java/aspose.slides/chartdatapoint/#getValue). Точка остаётся в той же позиции категории, но диаграмма рассматривает её значение как пустое в соответствии с настройками обработки пустых значений.

Следующий пример очищает только вторую точку в первой серии:

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

Диаграммы разброса используют отдельные ячейки X и Y, а пузырьковые диаграммы также используют ячейку размера. Очищайте только ячейку, представляющую значение, которое хотите удалить. Не вызывайте [ChartDataPointCollection.clear](https://reference.aspose.com/slides/ru/php-java/aspose.slides/chartdatapointcollection/#clear), если хотите сохранить другие точки, поскольку этот метод удалит все точки из коллекции.

## **Управление отображением пустых ячеек**

Пустая ячейка рабочей книги представляет отсутствие данных; ячейка, содержащая `0`, представляет известное числовое значение. Вызовите [ChartDataCell::setValue](https://reference.aspose.com/slides/ru/php-java/aspose.slides/chartdatacell/#setValue) с `null`, чтобы сделать ячейку пустой. Числовой ноль остаётся нулём независимо от настройки пустых ячеек.

Используйте [Chart::setDisplayBlanksAs](https://reference.aspose.com/slides/ru/php-java/aspose.slides/chart/#setDisplayBlanksAs), чтобы выбрать, как диаграмма отображает пустые ячейки. Эта настройка применяется ко всей диаграмме. Она меняет способ построения пустых точек, не заполняя пустую ячейку нулём или интерполированным значением.

Следующий автономный пример создаёт линейную диаграмму с одной серией, очищает значение для Дня 3 и сохраняет одну и ту же диаграмму в каждом режиме. Входной файл не требуется. [ChartDataWorkbook](https://reference.aspose.com/slides/ru/php-java/aspose.slides/chartdataworkbook/) использует лист 0, столбец 0 для меток категорий и столбец 1 для значений; строка 0 хранит имя серии. Итоговые данные: `10, 20, empty, 30, 40`.

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

    // Оставить третий день действительно пустым, сохранив его категорию и точку данных.
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

![Графики линии с одинаковыми данными: Gap разрывает линию в День 3, Zero опускает линию к нулю, а Span соединяет День 2 с Днем 4.](display_blanks_as.png)

Видимый эффект зависит от типа диаграммы. Линейная диаграмма позволяет легко сравнивать все три режима. Для столбчатых и колонных диаграмм нет линии, соединяющей пропущенную категорию, поэтому `Span` не может создать соединительный сегмент, как показано выше; отсутствие столбца и столбец нулевой высоты могут выглядеть одинаково. Аналогично, диаграмма разброса только с маркерами не имеет соединительной линии. Не рассчитывайте получить три различных результата для каждого типа диаграммы; проверьте вывод для используемого типа.

## **Установить ширину промежутка серии**

Ширина промежутка — это пространство между соседними кластерами столбцов или полос, выраженное в процентах от ширины столбца или полосы. Как и перекрытие, она относится к родительской группе серий, а не к отдельной серии. Вызовите [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/ru/php-java/aspose.slides/chartseriesgroup/#setGapWidth) один раз для группы. Большое значение создаёт больше пространства между кластерами; меньшее — делает их плотнее.

Следующий пример меняет ширину промежутка и сохраняет только конечную презентацию:

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

## **Часто задаваемые вопросы**

**Какие типы диаграмм поддерживают серии данных?**

Все типы диаграмм, представленные перечислением [ChartType](https://reference.aspose.com/slides/ru/php-java/aspose.slides/charttype/), используют данные диаграммы, но их серии не имеют одинаковой структуры значений или настроек. Например, диаграммы категорий используют категории и значения, диаграммы разброса используют X и Y, а пузырьковые диаграммы добавляют размеры пузырей. Используйте метод создания точек данных, соответствующий типу серии. Параметры, такие как перекрытие и ширина промежутка, применимы только к совместимым группам столбцов или полос.

**Что такое группа серий диаграммы?**

[ChartSeriesGroup](https://reference.aspose.com/slides/ru/php-java/aspose.slides/chartseriesgroup/) содержит совместимые серии, которые разделяют настройки уровня группы. В комбинированной диаграмме может быть более одной группы, поэтому изменение группы, полученной через одну серию, не обязательно изменит все серии в диаграмме.

**Содержит ли только что созданная диаграмма данные по умолчанию?**

Да. По умолчанию [ShapeCollection.addChart](https://reference.aspose.com/slides/ru/php-java/aspose.slides/shapecollection/#addChart) создаёт образцы серий, категорий и значений. Вы можете изменить эти ячейки или очистить коллекции серий и категорий перед добавлением полностью пользовательского набора данных. Перегрузка может также создать диаграмму без данных по умолчанию.

**Как объекты диаграмм связаны с ячейками рабочей книги?**

Имена серий, метки категорий и значения точек данных ссылаются на ячейки в [ChartDataWorkbook](https://reference.aspose.com/slides/ru/php-java/aspose.slides/chartdataworkbook/). Изменение ссылки ячейки обновляет соответствующий элемент диаграммы. При построении пользовательских данных сохраняйте выравнивание строк категорий и строк значений серий, чтобы каждая точка отображалась под нужной категорией.

**Как очистить одну точку вместо всей серии?**

Установите соответствующую ячейку значения в `null`, чтобы оставить позицию категории точки, но сделать её пустой. Используйте [ChartDataPointCollection.clear](https://reference.aspose.com/slides/ru/php-java/aspose.slides/chartdatapointcollection/#clear) только тогда, когда хотите удалить все точки из серии. Если вы также удаляете категории, обновите все серии, чтобы их значения оставались согласованными с коллекцией категорий.

**Как отображаются пустые точки?**

Результат зависит от типа диаграммы и значения, установленного через [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/ru/php-java/aspose.slides/chart/#setDisplayBlanksAs). Поддерживаемые диаграммы могут отображать пустоты как разрывы, как нулевые значения или соединяя соседние точки. Выберите настройку, соответствующую смыслу отсутствующих данных в вашей презентации. См. раздел **Управление отображением пустых ячеек** для полного примера и визуального сравнения.

**Как форматируются отрицательные значения?**

Для поддерживаемых столбцовых, колонных и пузырьковых серий вызовите [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/ru/php-java/aspose.slides/chartseries/#setInvertIfNegative) и задайте цвет, возвращаемый [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/ru/php-java/aspose.slides/chartseries/#getInvertedSolidFillColor). Для отдельной точки можно переопределить поведение с помощью [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/ru/php-java/aspose.slides/chartdatapoint/#setInvertIfNegative). Эти методы влияют только на форматирование, а не на хранящиеся числовые значения.

**Какое форматирование имеет приоритет, когда форматируются и серия, и точка?**

Явное форматирование отдельной точки данных имеет приоритет для этой точки. Другие точки продолжают использовать явный формат серии или, если формат серии не определён, автоматический стиль и тему диаграммы. Настройки группы, такие как перекрытие и ширина промежутка, управляют компоновкой и не переопределяют форматирование на уровне точек.

**Есть ли ограничение на количество серий в диаграмме?**

Aspose.Slides не накладывает отдельное фиксированное ограничение на количество серий. На практике ограничения задают размеры файла презентации, доступная память, время рендеринга и читаемость диаграммы.

**Что следует изменить, если столбцы слишком близко друг к другу или слишком далеко?**

Вызовите [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/ru/php-java/aspose.slides/chartseriesgroup/#setGapWidth) у соответствующей родительской группы серий. Увеличьте значение, чтобы расширить пространство между кластерами, или уменьшите его, чтобы собрать кластеры ближе.