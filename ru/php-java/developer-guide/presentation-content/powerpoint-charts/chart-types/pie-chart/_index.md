---
title: Настройка круговых диаграмм в презентациях с использованием PHP
linktitle: Круговая диаграмма
type: docs
url: /ru/php-java/pie-chart/
keywords:
- круговая диаграмма
- управление диаграммой
- настройка диаграммы
- параметры диаграммы
- настройки диаграммы
- параметры построения
- цвет сектора
- PowerPoint
- презентация
- PHP
- Aspose.Slides
description: "Создавайте и настраивайте круговые диаграммы в PHP с помощью Aspose.Slides. Настраивайте вторичные графики, отображайте метки данных и применяйте автоматическое раскрашивание секторов в PowerPoint."
---
## **Обзор**

Эта статья объясняет, как работать с круговыми диаграммами в Aspose.Slides. В ней показывается, как настроить параметры вторичного графика для диаграмм "Pie of Pie" и "Bar of Pie", а также как включить автоматическое раскрашивание секторов для обычной круговой диаграммы.

Примеры сосредоточены на задачах настройки диаграмм, таких как добавление диаграммы на слайд, настройка параметров серий и меток, замена данных диаграммы по умолчанию пользовательскими категориями и значениями, а также сохранение обновлённой презентации.

## **Параметры вторичного графика для диаграмм Pie of Pie и Bar of Pie**

Aspose.Slides for PHP via Java поддерживает параметры вторичного графика для диаграмм Pie of Pie и Bar of Pie. Эти параметры управляют размером вторичного графика и тем, как точки данных распределяются между двумя графиками.

В следующем примере создаётся диаграмма Pie of Pie в новой презентации и отображаются значения точек данных в виде меток. Метод [setSecondPieSize](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/#setSecondPieSize) задаёт размер вторичного графика как 149% от основного графика. [setPieSplitBy](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/#setPieSplitBy) выбирает разбиение по процентам, а [setPieSplitPosition](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/#setPieSplitPosition) устанавливает порог в 53%.

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

    // Отображать значения и настраивать вторичный график.
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

### **Выбор категорий для вторичного графика**

Используйте пользовательское разделение, когда необходимо сгруппировать определённые категории во вторичном графике независимо от их процентных значений. Например, в отчёте о продажах можно отобразить категории Online и Events вместе, чтобы читатели могли сравнить эти два канала, хотя они составляют 35% и 10% от общего объёма продаж.

Вызовите [setPieSplitBy](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/#setPieSplitBy) с параметром [PieSplitType::Custom](https://reference.aspose.com/slides/php-java/aspose.slides/piesplittype/) и выберите точки через [getPieSplitCustomPoints](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/#getPieSplitCustomPoints). Метод [add](https://reference.aspose.com/slides/php-java/aspose.slides/piesplitcustompointcollection/#add) коллекции принимает нулевой индекс в серии; используйте [addItem](https://reference.aspose.com/slides/php-java/aspose.slides/piesplitcustompointcollection/#addItem) для добавления объекта точки данных. В этом примере индекс 1 выбирает Online, а точка с индексом 3 выбирает Events. Partners также временно добавляется, а затем исключается с помощью [removeItem](https://reference.aspose.com/slides/php-java/aspose.slides/piesplitcustompointcollection/#removeItem).

```php
use aspose\slides\ChartType;
use aspose\slides\PieSplitType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::PieOfPie, 50, 50, 600, 200);

    // Заменить данные по умолчанию продажами по каналам.
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

    // Выбрать Online по его нулевому индексу и Events по объекту точки данных.
    $seriesGroup->getPieSplitCustomPoints()->add(1);
    $seriesGroup->getPieSplitCustomPoints()->addItem($series->getDataPoints()->get_Item(3));

    // Исключить Partners из выбора без удаления его исходных данных.
    $seriesGroup->getPieSplitCustomPoints()->add(2);
    $seriesGroup->getPieSplitCustomPoints()->removeItem($series->getDataPoints()->get_Item(2));

    $presentation->save("pie_of_pie_custom.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Online (35) и Events (10) отображаются как отдельные сектора во вторичном графике. В первичном графике они представлены одним объединённым сектором со значением 45, рядом с Retail (40) и Partners (15). Удаление Partners из пользовательского выбора оставляет его в первичном графике; категория и её значение не удаляются из исходных данных диаграммы.

Следующее изображение показывает сохранённую презентацию в PowerPoint:

![Диаграмма Pie of Pie с Online и Events во вторичном графике и их объединённым значением 45 в первичном графике](pie_of_pie_custom.png)

## **Установка автоматических цветов секторов круговой диаграммы**

Aspose.Slides for PHP via Java может автоматически назначать разные цвета секторам круговой диаграммы. В следующем примере создаётся круговая диаграмма с заголовком по центру и заменяются данные по умолчанию на три квартальные категории и их значения. Метод [setShowValue](https://reference.aspose.com/slides/php-java/aspose.slides/datalabelformat/#setShowValue) отображает значения 20, 50 и 30 в виде меток, а [setColorVaried](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/#setColorVaried) включает отдельный цвет для каждого сектора.

```php
use aspose\slides\ChartType;
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Pie, 100, 100, 400, 400);

    // Добавить центрированный заголовок диаграммы.
    $chart->getChartTitle()->addTextFrameForOverriding("Sample Title");
    $chart->getChartTitle()->getTextFrameForOverriding()->getTextFrameFormat()->setCenterText(NullableBool::True);
    $chart->getChartTitle()->setHeight(20);
    $chart->setTitle(true);

    // Заменить данные по умолчанию, используя первый лист.
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

    // Показать значения и назначить разные цвета секторам.
    $series->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);
    $series->getParentSeriesGroup()->setColorVaried(true);

    $presentation->save("pie.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Часто задаваемые вопросы**

**Поддерживаются ли варианты Pie of Pie и Bar of Pie?**

Да, библиотека [поддерживает](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/) вторичный график для круговых диаграмм, включая типы Pie of Pie и Bar of Pie.

**Можно ли экспортировать только диаграмму как изображение (например, PNG)?**

Да, вы можете [экспортировать саму диаграмму как изображение](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getImage) (например, PNG) без экспорта всей презентации.