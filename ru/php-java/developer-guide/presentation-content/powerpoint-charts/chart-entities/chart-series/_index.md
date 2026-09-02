---
title: Управление данными серии диаграмм в презентациях на PHP
linktitle: Серии данных
type: docs
url: /ru/php-java/chart-series/
keywords:
- серия диаграммы
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

Диаграмма хранит свои построенные данные в рабочей книге данных диаграммы. Объект [ChartSeries](https://reference.aspose.com/slides/ru/php-java/aspose.slides/chartseries/) представляет один набор связанных значений, и каждый [ChartDataPoint](https://reference.aspose.com/slides/ru/php-java/aspose.slides/chartdatapoint/) в серии ссылается на одну или несколько ячеек рабочей книги. Объекты [ChartCategory](https://reference.aspose.com/slides/ru/php-java/aspose.slides/chartcategory/) предоставляют метки или значения группировки, общие для серии. Поэтому имя серии, категории и значения точек связаны с объектами [ChartDataCell](https://reference.aspose.com/slides/ru/php-java/aspose.slides/chartdatacell/), а не хранятся только как отображаемый текст.

Для типичной диаграммы категорий рабочая книга по умолчанию использует строку 0 для имён серий, столбец 0 для имён категорий и остальные ячейки для значений серий. Индексы листа, строки и столбца, передаваемые в [ChartDataWorkbook.getCell](https://reference.aspose.com/slides/ru/php-java/aspose.slides/chartdataworkbook/#getCell), начинаются с нуля. Такой макет удобен, когда вы создаёте диаграмму с данными по умолчанию, но не следует предполагать, что каждая существующая диаграмма использует его. Для загруженной презентации проверьте ячейки, на которые ссылаются серии, категории и точки данных, прежде чем изменять значения в рабочей книге.

Настройки диаграммы имеют три разных уровня:

- Настройки уровня серии, такие как [ChartSeries.getFormat](https://reference.aspose.com/slides/ru/php-java/aspose.slides/chartseries/#getFormat), определяют внешний вид по умолчанию для всех точек одной серии.
- Настройки уровня точки, такие как [ChartDataPoint.getFormat](https://reference.aspose.com/slides/ru/php-java/aspose.slides/chartdatapoint/#getFormat), переопределяют внешний вид серии для одной точки.
- Настройки группы применяются к совместимым сериям, принадлежащим к одному [ChartSeriesGroup](https://reference.aspose.com/slides/ru/php-java/aspose.slides/chartseriesgroup/). Получите доступ к группе через [ChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/ru/php-java/aspose.slides/chartseries/#getParentSeriesGroup), когда необходимо задать параметры, такие как перекрытие или ширина промежутка.

Когда явная заливка точки или серии не задана, стиль и тема диаграммы определяют автоматический внешний вид. Когда одновременно присутствуют форматирование серии и точки, форматирование точки имеет приоритет для этой точки.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **Установить перекрытие серии диаграммы**

[ChartSeries.getOverlap](https://reference.aspose.com/slides/ru/php-java/aspose.slides/chartseries/#getOverlap) сообщает, насколько столбцы или полосы перекрываются в 2D‑диаграмме, от -100 до 100 процентов. Это только чтение текущего значения, унаследованного от родительской группы серий. Используйте [ChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/ru/php-java/aspose.slides/chartseriesgroup/#setOverlap), чтобы обновить каждую совместимую серию в этой группе. Эта опция применяется к типам диаграмм, отображающим сгруппированные столбцы или полосы; она не влияет на несвязанные группы серий в комбинированной диаграмме.

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

## **Изменить цвет заливки серии**

Используйте [ChartSeries.getFormat](https://reference.aspose.com/slides/ru/php-java/aspose.slides/chartseries/#getFormat), чтобы задать заливку по умолчанию для всей серии. Если у точки уже задана явная заливка, её настройка [ChartDataPoint.getFormat](https://reference.aspose.com/slides/ru/php-java/aspose.slides/chartdatapoint/#getFormat) переопределяет заливку серии для этой точки.

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

Вы также можете обновить ячейку, уже используемую в [ChartSeries.getName](https://reference.aspose.com/slides/ru/php-java/aspose.slides/chartseries/#getName). Такой подход избегает предположения о конкретных строке и столбце в существующей диаграмме:

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

[ChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/ru/php-java/aspose.slides/chartseries/#getAutomaticSeriesColor) возвращает цвет, вычисленный на основе индекса серии и стиля диаграммы. Это цвет, используемый, когда заливка серии не была явно определена. Вызов метода только считывает вычисленный цвет; он не задаёт новую заливку.

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

Точные цвета зависят от стиля диаграммы и темы.

## **Установить инвертированный цвет заливки для серии диаграммы**

Для серий столбцов, полос и пузырей [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/ru/php-java/aspose.slides/chartseries/#setInvertIfNegative) может отображать отрицательные значения другим цветом. Задайте обычную заливку серии как сплошную, включите инверсию и укажите цвет отрицательных значений через [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/ru/php-java/aspose.slides/chartseries/#getInvertedSolidFillColor). Отрицательные числа в рабочей книге остаются неизменными; меняется только их цвет отображения.

Следующий пример заменяет данные диаграммы по умолчанию одной серией. Строка листа 0 содержит имя серии, столбец 0 — имена категорий, столбец 1 — значения:

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

Вы можете включить инверсию для одной точки через [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/ru/php-java/aspose.slides/chartdatapoint/#setInvertIfNegative). В следующем примере инверсия отключена для серии и включена только для выбранной точки. Точке также присваивается отрицательное значение, чтобы эффект был видим:

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

Чтобы сделать одну точку пустой, не удаляя остальные, задайте её ячейке в рабочей книге значение `null`. Для столбчатой диаграммы построенное значение доступно через [ChartDataPoint.getValue](https://reference.aspose.com/slides/ru/php-java/aspose.slides/chartdatapoint/#getValue). Точка остаётся в той же позиции категории, но диаграмма рассматривает её значение как пустое в соответствии с настройками отображения пустых значений.

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

Диаграммы рассеяния используют отдельные ячейки X и Y, а диаграммы пузырей — также ячейку размера. Очищайте только ту ячейку, которая представляет значение, которое нужно удалить. Не вызывайте [ChartDataPointCollection.clear](https://reference.aspose.com/slides/ru/php-java/aspose.slides/chartdatapointcollection/#clear), если хотите сохранить остальные точки, потому что этот метод удаляет все точки из коллекции.

## **Установить ширину промежутка между сериями**

Ширина промежутка — это пространство между соседними кластерами столбцов или полос, выраженное в процентах от их ширины. Как и перекрытие, она относится к родительской группе серий, а не к отдельной серии. Вызовите [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/ru/php-java/aspose.slides/chartseriesgroup/#setGapWidth) один раз для группы. Большое значение создаёт больше пространства между кластерами; маленькое — делает их плотнее.

Следующий пример изменяет ширину промежутка и сохраняет только финальную презентацию:

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

Все типы диаграмм, представленные перечислением [ChartType](https://reference.aspose.com/slides/ru/php-java/aspose.slides/charttype/), используют данные диаграммы, но их серии не всегда имеют одинаковую структуру значений или настройки. Например, диаграммы категорий используют категории и значения, диаграммы рассеяния — X и Y, а диаграммы пузырей добавляют размеры пузырей. Используйте метод создания точек данных, соответствующий типу серии. Параметры, такие как перекрытие и ширина промежутка, применимы только к совместимым группам столбцов или полос.

**Что такое группа серии диаграммы?**

[ChartSeriesGroup](https://reference.aspose.com/slides/ru/php-java/aspose.slides/chartseriesgroup/) содержит совместимые серии, которые используют общие настройки построения уровня группы. Комбинированная диаграмма может содержать более одной группы, поэтому изменение группы, полученной через одну серию, не обязательно меняет все серии в диаграмме.

**Создаётся ли в новой диаграмме набор данных по умолчанию?**

Да. По умолчанию [ShapeCollection.addChart](https://reference.aspose.com/slides/ru/php-java/aspose.slides/shapecollection/#addChart) создаёт образцы серий, категорий и значений. Вы можете отредактировать эти ячейки или очистить коллекции серий и категорий перед добавлением полностью пользовательского набора данных. Существует перегрузка, позволяющая создать диаграмму без данных по умолчанию.

**Как объекты диаграммы связаны с ячейками рабочей книги?**

Имена серий, метки категорий и значения точек данных ссылаются на ячейки в [ChartDataWorkbook](https://reference.aspose.com/slides/ru/php-java/aspose.slides/chartdataworkbook/). Изменение ссылочной ячейки обновляет соответствующий элемент диаграммы. При построении пользовательских данных держите строки категорий и строки значений серий выровненными, чтобы каждая точка отображалась под нужной категорией.

**Как очистить одну точку, а не всю серию?**

Задайте соответствующей ячейке значение `null`, чтобы сохранить позицию категории точки как пустой. Используйте [ChartDataPointCollection.clear](https://reference.aspose.com/slides/ru/php-java/aspose.slides/chartdatapointcollection/#clear) только тогда, когда необходимо удалить все точки из серии. Если вы также удаляете категории, обновите каждую серию, чтобы их значения оставались согласованными с коллекцией категорий.

**Как отображаются пустые точки?**

Результат зависит от типа диаграммы и настройки, задаваемой через [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/ru/php-java/aspose.slides/chart/#setDisplayBlanksAs). Поддерживаемые диаграммы могут показывать пустоты как пробелы, как нулевые значения или соединяя соседние точки. Выберите настройку, соответствующую смыслу отсутствующих данных в вашей презентации.

**Как форматируются отрицательные значения?**

Для поддерживаемых столбчатых, столбцовых и пузырчатых серий вызовите [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/ru/php-java/aspose.slides/chartseries/#setInvertIfNegative) и задайте цвет, возвращаемый [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/ru/php-java/aspose.slides/chartseries/#getInvertedSolidFillColor). Поведение отдельной точки можно переопределить с помощью [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/ru/php-java/aspose.slides/chartdatapoint/#setInvertIfNegative). Эти методы влияют только на форматирование, а не на хранимые числовые значения.

**Какой формат имеет приоритет, если серия и точка отформатированы?**

Явное форматирование точки имеет приоритет для этой точки. Остальные точки продолжают использовать явный формат серии или, если формат серии не задан, автоматический стиль и тему диаграммы. Настройки группы, такие как перекрытие и ширина промежутка, управляют расположением и не являются переопределениями форматирования точек.

**Есть ли ограничение на количество серий в диаграмме?**

Aspose.Slides не накладывает отдельного фиксированного ограничения на количество серий. На практике ограничения определяются размером файла презентации, доступной памятью, временем рендеринга и читаемостью диаграммы.

**Что менять, если столбцы слишком близко или слишком далеко друг от друга?**

Вызовите [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/ru/php-java/aspose.slides/chartseriesgroup/#setGapWidth) у соответствующей родительской группы серий. Увеличьте значение, чтобы расширить пространство между кластерами, или уменьшите его, чтобы сблизить кластеры.