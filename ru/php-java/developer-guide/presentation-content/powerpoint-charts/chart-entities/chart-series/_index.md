---
title: Управление сериями данных диаграммы в презентациях в PHP
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

Диаграмма хранит свои построенные данные в рабочей книге данных диаграммы. [ChartSeries](https://reference.aspose.com/slides/ru/php-java/aspose.slides/chartseries/) представляет один набор связанных значений, и каждый [ChartDataPoint](https://reference.aspose.com/slides/ru/php-java/aspose.slides/chartdatapoint/) в серии ссылается на одну или несколько ячеек рабочей книги. Объекты [ChartCategory](https://reference.aspose.com/slides/ru/php-java/aspose.slides/chartcategory/) предоставляют метки или группирующие значения, общие для серии. Поэтому имя серии, категории и значения точек связаны с объектами [ChartDataCell](https://reference.aspose.com/slides/ru/php-java/aspose.slides/chartdatacell/), а не хранятся только как отображаемый текст.

Для типичной диаграммы с категориями рабочая книга по умолчанию использует строку 0 для имён серий, столбец 0 для имён категорий и остальные ячейки для значений серий. Индексы листа, строки и столбца, передаваемые в [ChartDataWorkbook.getCell](https://reference.aspose.com/slides/ru/php-java/aspose.slides/chartdataworkbook/#getCell), нумеруются с нуля. Такой макет полезен, когда вы создаёте диаграмму с данными по умолчанию, но не следует полагать, что каждая существующая диаграмма использует его. Для загруженной презентации перед изменением значений в рабочей книге проверьте ячейки, на которые ссылаются серии, категории и точки данных.

Настройки диаграммы имеют три разных уровня:

- Настройки уровня серии, такие как [ChartSeries.getFormat](https://reference.aspose.com/slides/ru/php-java/aspose.slides/chartseries/#getFormat), задают внешний вид по умолчанию для всех точек в одной серии.
- Настройки отдельной точки, такие как [ChartDataPoint.getFormat](https://reference.aspose.com/slides/ru/php-java/aspose.slides/chartdatapoint/#getFormat), переопределяют внешний вид серии для одной точки.
- Групповые настройки применяются к совместимым сериям, принадлежащим одному [ChartSeriesGroup](https://reference.aspose.com/slides/ru/php-java/aspose.slides/chartseriesgroup/). Доступ к группе выполняется через [ChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/ru/php-java/aspose.slides/chartseries/#getParentSeriesGroup), когда необходимо установить параметры, такие как перекрытие или ширина промежутка.

Когда для точки или серии не задано явное заполнение, стиль и тема диаграммы определяют автоматический внешний вид. Если присутствует как форматирование серии, так и точки, форматирование точки имеет приоритет для этой точки.

![серия диаграммы PowerPoint](chart-series-powerpoint.png)

## **Установка перекрытия серии диаграммы**

[ChartSeries.getOverlap](https://reference.aspose.com/slides/ru/php-java/aspose.slides/chartseries/#getOverlap) сообщает, насколько столбцы или бары перекрываются в 2D‑диаграмме, от ‑100 до 100 процентов. Это только чтение проекции настройки группы родительских серий. Используйте [ChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/ru/php-java/aspose.slides/chartseriesgroup/#setOverlap), чтобы обновить каждую совместимую серию в этой группе. Эта опция применяется к типам диаграмм, отображающим сгруппированные столбцы или бары; она не влияет на несвязанные группы серий в комбинированной диаграмме.

Следующий пример задаёт перекрытие для группы, содержащей первую серию:

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

![Перекрытие серии](series_overlap.png)

## **Изменение цвета заполнения серии**

Используйте [ChartSeries.getFormat](https://reference.aspose.com/slides/ru/php-java/aspose.slides/chartseries/#getFormat), чтобы задать заполнение по умолчанию для всей серии. Если точка уже имеет явно заданное заполнение, её настройка [ChartDataPoint.getFormat](https://reference.aspose.com/slides/ru/php-java/aspose.slides/chartdatapoint/#getFormat) переопределяет заполнение серии для этой точки.

Следующий пример применяет сплошное синее заполнение к первой серии:

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

## **Изменение имени серии**

Имя серии хранится в рабочей книге данных диаграммы и обычно отображается в легенде. В рабочей книге по умолчанию для сгруппированной столбчатой диаграммы ячейка B1 находится в строке 0, столбце 1 и содержит имя первой серии. Именованные переменные в следующем примере делают эту структуру явной:

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

Вы также можете обновить ячейку, уже referenced by [ChartSeries.getName](https://reference.aspose.com/slides/ru/php-java/aspose.slides/chartseries/#getName). Такой подход избавляет от предположения о конкретных строке и столбце в существующей диаграмме:

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

## **Получение автоматического цвета заполнения серии**

[ChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/ru/php-java/aspose.slides/chartseries/#getAutomaticSeriesColor) возвращает цвет, вычисленный из индекса серии и стиля диаграммы. Это цвет, используемый, когда заполнение серии явно не определено. Вызов метода лишь читает вычисленный цвет; он не задаёт новое заполнение.

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

## **Установка инверсного цвета заполнения для серии диаграммы**

Для серий типа бар, столбец и пузырёк [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/ru/php-java/aspose.slides/chartseries/#setInvertIfNegative) может отображать отрицательные значения другим заполнением. Задайте обычное заполнение серии как сплошное, включите инверсию и задайте цвет для отрицательных значений через [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/ru/php-java/aspose.slides/chartseries/#getInvertedSolidFillColor). Отрицательные числа в рабочей книге остаются без изменений; меняется только их цвет отображения.

Следующий пример заменяет данные диаграммы по умолчанию одной серией. Строка 0 листа содержит имя серии, столбец 0 — имена категорий, столбец 1 — значения:

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

![Инвертированный сплошной цвет заполнения](inverted_solid_fill_color.png)

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

## **Очистка конкретного значения точки данных**

Чтобы сделать одну точку пустой, не удаляя другие точки, задайте её ячейке в рабочей книге значение `null`. Для столбчатой диаграммы отображаемое значение доступно через [ChartDataPoint.getValue](https://reference.aspose.com/slides/ru/php-java/aspose.slides/chartdatapoint/#getValue). Точка данных остаётся в той же позиции категории, но диаграмма воспринимает её значение как пустое в соответствии с настройками отображения пустых значений диаграммы.

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

Диаграммы рассеяния используют отдельные ячейки X и Y, а пузырьковые — также ячейку размера. Очищайте только ту ячейку, которая представляет значение, которое вы хотите удалить. Не вызывайте [ChartDataPointCollection.clear](https://reference.aspose.com/slides/ru/php-java/aspose.slides/chartdatapointcollection/#clear), если хотите оставить остальные точки, поскольку этот метод удаляет все точки из коллекции.

## **Управление отображением пустых ячеек**

Скрытые ячейки, содержащие значения, отличаются от пустых ячеек. Чтобы включать или исключать данные из скрытых строк и столбцов листа, см. [Include Data from Hidden Rows and Columns](/slides/ru/php-java/chart-workbook/#include-data-from-hidden-rows-and-columns).

Пустая ячейка рабочей книги представляет отсутствие данных; ячейка, содержащая `0`, представляет известное числовое значение. Вызовите [ChartDataCell::setValue](https://reference.aspose.com/slides/ru/php-java/aspose.slides/chartdatacell/#setValue) с `null`, чтобы сделать ячейку пустой. Числовой ноль остаётся нулём независимо от настройки отображения пустых ячеек.

Используйте [Chart::setDisplayBlanksAs](https://reference.aspose.com/slides/ru/php-java/aspose.slides/chart/#setDisplayBlanksAs), чтобы выбрать способ отображения пустых ячеек. Эта настройка применяется ко всей диаграмме. Она меняет способ построения пустых точек без заполнения пустой ячейки нулём или интерполированным значением.

Следующий автономный пример создаёт линейную диаграмму с одной серией, очищает значение для 3‑го дня и сохраняет одну и ту же диаграмму в каждом режиме. Входной файл не требуется. [ChartDataWorkbook](https://reference.aspose.com/slides/ru/php-java/aspose.slides/chartdataworkbook/) использует лист 0, столбец 0 для подписи категорий и столбец 1 для значений; строка 0 хранит имя серии. Итоговые данные: `10, 20, empty, 30, 40`.

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

    // Оставить 3‑й день действительно пустым, сохранив его категорию и точку данных.
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

Каждый выходной файл сохраняет режим, установленный перед сохранением: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx` и `empty_cells_Span.pptx`. Чтобы сохранить только одну версию, задайте нужный режим и сохраните презентацию один раз вместо перебора режимов.

Сравнение ниже показывает одинаковые данные во всех трёх файлах. День 3 пуст в рабочей книге во всех случаях:

![Линейные диаграммы с одинаковыми данными: Gap разрывает линию в день 3, Zero опускает линию к нулю, а Span соединяет день 2 с днём 4.](display_blanks_as.png)

Видимый эффект зависит от типа диаграммы. Линейная диаграмма позволяет легко сравнить все три режима. У столбчатых и бар‑диаграмм нет линии, соединяющей пропущенную категорию, поэтому `Span` не может создать соединительный сегмент, показанный выше; пустой столбец и столбец нулевой высоты также могут выглядеть одинаково. Аналогично, в диаграмме рассеяния только с маркерами нет соединительной линии. Не ожидайте три отдельных результата для каждого типа диаграммы; проверьте вывод для используемого типа.

## **Установка ширины промежутка между сериями**

Ширина промежутка — это расстояние между соседними кластерами баров или столбцов, выраженное в процентах от ширины бара или столбца. Как и перекрытие, она относится к группе родительских серий, а не к отдельной серии. Вызовите [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/ru/php-java/aspose.slides/chartseriesgroup/#setGapWidth) один раз для группы. Большее значение создаёт больше пространства между кластерами; меньшее — делает их плотнее.

Следующий пример меняет ширину промежутка и сохраняет только окончательную презентацию:

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

**Какие типы диаграмм поддерживают серии данных?**

Все типы диаграмм, представленные перечислением [ChartType](https://reference.aspose.com/slides/ru/php-java/aspose.slides/charttype/), используют данные диаграммы, но их серии не всегда имеют одинаковую структуру значений или настройки. Например, диаграммы с категориями используют категории и значения, диаграммы рассеяния — X и Y, а пузырьковые — добавляют размеры пузырей. Используйте метод создания точек данных, соответствующий типу серии. Параметры, такие как перекрытие и ширина промежутка, применимы только к совместимым группам баров или столбцов.

**Что такое группа серий диаграммы?**

[ChartSeriesGroup](https://reference.aspose.com/slides/ru/php-java/aspose.slides/chartseriesgroup/) содержит совместимые серии, которые используют общие настройки построения на уровне группы. Комбинированная диаграмма может содержать более одной группы, поэтому изменение группы через одну серию не обязано менять каждую серию в диаграмме.

**Содержит ли только что созданная диаграмма данные по умолчанию?**

Да. По умолчанию [ShapeCollection.addChart](https://reference.aspose.com/slides/ru/php-java/aspose.slides/shapecollection/#addChart) создаёт образцы серий, категорий и значений. Вы можете отредактировать эти ячейки или очистить как коллекцию серий, так и коллекцию категорий перед добавлением полностью пользовательского набора данных. Существует перегрузка, позволяющая создать диаграмму без данных по умолчанию.

**Как объекты диаграммы связаны с ячейками рабочей книги?**

Имена серий, подписи категорий и значения точек данных ссылаются на ячейки в [ChartDataWorkbook](https://reference.aspose.com/slides/ru/php-java/aspose.slides/chartdataworkbook/). Изменение ссылки ячейки обновляет соответствующий элемент диаграммы. При построении пользовательских данных поддерживайте согласованность строк категорий и строк значений серий, чтобы каждая точка отрисовывалась под нужной категорией.

**Как очистить одну точку, а не всю серию?**

Установите соответствующую ячейку значения в `null`, чтобы сохранить позицию категории точки как пустой. Используйте [ChartDataPointCollection.clear](https://reference.aspose.com/slides/ru/php-java/aspose.slides/chartdatapointcollection/#clear) только тогда, когда действительно нужно удалить все точки из серии. Если вы также удаляете категории, обновите каждую серию, чтобы их значения оставались согласованными с коллекцией категорий.

**Как отображаются пустые точки?**

Результат зависит от типа диаграммы и значения, заданного через [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/ru/php-java/aspose.slides/chart/#setDisplayBlanksAs). Поддерживаемые диаграммы могут отображать пустоты как разрывы, как нулевые значения или соединяя соседние точки. Выберите настройку, соответствующую смыслу отсутствующих данных в вашей презентации. См. раздел [Управление отображением пустых ячеек](#control-the-display-of-empty-cells) для полного примера и визуального сравнения.

**Как форматируются отрицательные значения?**

Для поддерживаемых серий баров, столбцов и пузырьков вызовите [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/ru/php-java/aspose.slides/chartseries/#setInvertIfNegative) и задайте цвет, полученный через [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/ru/php-java/aspose.slides/chartseries/#getInvertedSolidFillColor). Поведение для отдельной точки можно переопределить с помощью [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/ru/php-java/aspose.slides/chartdatapoint/#setInvertIfNegative). Эти методы влияют на форматирование, а не на хранимые числовые значения.

**Какой формат имеет приоритет, если задано и для серии, и для точки?**

Явное форматирование точки имеет приоритет для этой точки. Остальные точки продолжают использовать явный формат серии или, если формат серии не определён, автоматический стиль и тему диаграммы. Групповые настройки, такие как перекрытие и ширина промежутка, управляют расположением и не являются переопределяющим форматированием точек.

**Есть ли предел количеству серий в диаграмме?**

Aspose.Slides не накладывает отдельного фиксированного ограничения на количество серий. На практике ограничения определяются размером файла презентации, доступной памятью, временем рендеринга и читаемостью диаграммы.

**Что менять, если столбцы слишком близко или слишком далеко друг от друга?**

Вызовите [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/ru/php-java/aspose.slides/chartseriesgroup/#setGapWidth) для соответствующей группы родительских серий. Увеличьте значение, чтобы расширить пространство между кластерами, или уменьшите его, чтобы сделать кластеры ближе друг к другу.