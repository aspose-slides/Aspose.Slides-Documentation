---
title: Настройка осей диаграмм в презентациях с использованием PHP
linktitle: Ось диаграммы
type: docs
url: /ru/php-java/chart-axis/
keywords:
- ось диаграммы
- вертикальная ось
- горизонтальная ось
- настройка оси
- манипулирование осью
- управление осью
- свойства оси
- максимальное значение
- минимальное значение
- линия оси
- формат даты
- заголовок оси
- положение оси
- PowerPoint
- презентация
- PHP
- Aspose.Slides
description: "Узнайте, как использовать Aspose.Slides for PHP via Java для настройки осей диаграмм в презентациях PowerPoint для отчетов и визуализаций."
---
## **Обзор**

Эта статья объясняет, как настраивать оси диаграмм с помощью Aspose.Slides for PHP via Java. Она охватывает вычисленные значения осей, переключение строк и столбцов диаграммы, видимость осей, интервалы подписей категорий и делений, датированные категории и их форматирование, вращение заголовка, позиционирование осей, единицы отображения и логарифмическое масштабирование.

## **Получить максимальные значения на вертикальной оси диаграмм**

Создайте [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) и добавьте областьную диаграмму с данными по умолчанию. Вызовите [validateChartLayout](https://reference.aspose.com/slides/php-java/aspose.slides/chart/validatechartlayout/) перед чтением вычисленных значений осей, чтобы макет диаграммы был актуален.

Читайте [getActualMaxValue](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualmaxvalue/) и [getActualMinValue](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualminvalue/) для пределов оси, а также [getActualMajorUnit](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualmajorunit/) и [getActualMinorUnit](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualminorunit/) для интервалов делений. [getActualMajorUnitScale](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualmajorunitscale/) и [getActualMinorUnitScale](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualminorunitscale/) предоставляют масштабы временных единиц, которые актуальны для датированных осей. В примере эти значения сохраняются в локальные переменные и сохраняется диаграмма.

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

## **Поменять данные между осями**

Используйте [switchRowColumn](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/switchrowcolumn/) для обмена ролями рядов и категорий в данных диаграммы. Каждая прежняя категория становится рядом, а каждый прежний ряд — категорией. Это изменяет способ группировки данных; это не меняет местами горизонтальную и вертикальную оси. В примере используется [setRange](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/setrange/) для привязки данных по умолчанию к `Sheet1!A1:D5`, включая строку заголовков и столбец категорий, перед переключением рядов и столбцов. Сохраняется диаграмма с четырьмя рядами и тремя категориями.

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

## **Отключить вертикальную ось для линейных диаграмм**

Вызовите [setVisible](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setvisible/) с `false` у вертикальной оси, чтобы скрыть её. В примере создаётся линейная диаграмма с данными по умолчанию и сохраняется с скрытой вертикальной осью.

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

## **Отключить горизонтальную ось для линейных диаграмм**

Вызовите [setVisible](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setvisible/) с `false` у горизонтальной оси, чтобы скрыть её. В примере создаётся линейная диаграмма с данными по умолчанию и сохраняется с скрытой горизонтальной осью.

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

## **Изменить категориальную ось**

Используйте [setCategoryAxisType](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setcategoryaxistype/) для выбора датированной или текстовой категориальной оси. Этот пример требует `ExistingChart.pptx`, где диаграмма является первой фигурой на первом слайде, а ячейки категорий содержат численные значения дат Excel. Ось X меняется на датированную. Вызов [setAutomaticMajorUnit](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setautomaticmajorunit/) с `false`, [setMajorUnit](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setmajorunit/) с `1` и [setMajorUnitScale](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setmajorunitscale/) с `TimeUnitType::Months` размещают основные деления с интервалом в один месяц.

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

## **Управление интервалами меток категориальной оси**

Когда диаграмма содержит множество категорий, уменьшите количество видимых меток оси, не удаляя категории и точки данных. Вызовите [setAutomaticTickLabelSpacing](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setautomaticticklabelspacing/) с `false`, а затем передайте желаемый интервал категории в [setTickLabelSpacing](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setticklabelspacing/). Для текстовых категорий в обычном порядке отсчёт начинается с первой категории:

| Интервал | Метки, отображаемые в примере |
| --- | --- |
| `1` | Category 1, Category 2, Category 3, ... Category 24 |
| `2` | Category 1, Category 3, Category 5, ... Category 23 |
| `3` | Category 1, Category 4, Category 7, ... Category 22 |

Интервал `3` отображает каждую третью метку, оставляя между отображаемыми две скрытые. Это не удаляет соответствующие столбцы. Автоматический интервал выбирается исходя из доступного пространства; он не обязательно отображает каждую метку.

Отметки делений имеют отдельные настройки. Вызовите [setAutomaticTickMarksSpacing](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setautomatictickmarksspacing/) с `false` и используйте [setTickMarksSpacing](https://reference.aspose.com/slides/php-java/aspose.slides/axis/settickmarksspacing/) для задания их интервала. Например, `1` оставляет деление у каждой категории, тогда как метки отображаются только каждые три категории. Примените [setMajorTickMark](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setmajortickmark/) со стилем, видимым на диаграмме. Повторный вызов любого из автоматических методов с `true` возвращает автоматический выбор интервала.

Следующий автономный пример создаёт 24 категории и один ряд, затем сохраняет три слайда в `CategoryAxisIntervals.pptx`: автоматический интервал, ручной интервал меток с независимыми делениями и восстановленный автоматический интервал. Обе копии сохраняют исходные данные диаграммы. Входная презентация не требуется. Горизонтальный текст меток делает различие в плотности легко заметным.

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

    // Слайд 2: показывать каждую третью метку, но оставлять деление для каждой категории.
    $manualSlide = $presentation->getSlides()->addClone($slide);
    $manualChart = $manualSlide->getShapes()->get_Item(0);
    $manualAxis = $manualChart->getAxes()->getHorizontalAxis();
    $manualAxis->setAutomaticTickLabelSpacing(false);
    $manualAxis->setTickLabelSpacing(3);
    $manualAxis->setAutomaticTickMarksSpacing(false);
    $manualAxis->setTickMarksSpacing(1);

    // Слайд 3: позволить диаграмме снова выбрать оба интервала.
    $restoredSlide = $presentation->getSlides()->addClone($manualSlide);
    $restoredChart = $restoredSlide->getShapes()->get_Item(0);
    $restoredChart->getAxes()->getHorizontalAxis()->setAutomaticTickLabelSpacing(true);
    $restoredChart->getAxes()->getHorizontalAxis()->setAutomaticTickMarksSpacing(true);

    $presentation->save("CategoryAxisIntervals.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

**Automatic spacing (slide 1):** В этом варианте каждая вторая метка категории отображается и переносится на две строки. Автоматический результат может различаться в зависимости от размеров диаграммы, шрифтов и рендерера.

![Автоматический интервал меток категорий при видимых всех 24 столбцах](category-axis-automatic.png)

**Manual spacing (slide 2):** Каждая третья метка отображается в одну строку, тогда как деления остаются у каждой категории. Все 24 столбца, включая те, у которых нет меток, остаются видимыми с теми же значениями. Слайд 3 восстанавливает автоматический вид, показанный выше.

![Ручной интервал меток категории в три при видимых всех 24 столбцах](category-axis-manual.png)

### **Выберите правильную ось и интервал**

Используйте этот интервал количества категорий для текстовой категориальной оси, например для оси категорий столбчатой, линейной, областной или гистограммы. В столбчатой диаграмме это горизонтальная ось. В горизонтальной гистограмме категориальная ось вертикальна, поэтому применяйте эти настройки к оси, возвращаемой [getVerticalAxis](https://reference.aspose.com/slides/php-java/aspose.slides/axesmanager/getverticalaxis/). Интервал делений также относится к оси рядов в диаграммах, где она присутствует.

Не используйте интервалы меток категорий для задания числовой шкалы оси значений. На оси значений [setMajorUnit](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setmajorunit/) задаёт разницу в значениях: например, основной шаг `10` создаёт деления 0, 10, 20 и т.д., когда ось начинается с нуля. Интервал метки категории `3` же считает позиции категорий независимо от их значений. Диаграммы рассеяния и пузырьковые используют оси значений, а не текстовую категориальную ось. Для датированной оси используйте временные основные единицы и масштабы, как описано в [Изменить категориальную ось](#изменить-категориальную-ось).

## **Установить формат даты для значений категориальной оси**

Пример заменяет данные диаграммы четырьмя годовыми значениями. Даты хранятся как серийные номера OLE Automation в первом листе (индекс `0`), вычисляемые как количество дней, прошедших с 30 декабря 1899. Используйте [setCategoryAxisType](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setcategoryaxistype/) с `CategoryAxisType::Date`, вызовите [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setnumberformatlinkedtosource/) с `false` и передайте `yyyy` в [setNumberFormat](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setnumberformat/), чтобы метки категорий отображали четырёхзначные годы независимо от формата ячейки.

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

## **Установить угол вращения заголовка оси диаграммы**

Вызовите [setTitle](https://reference.aspose.com/slides/php-java/aspose.slides/axis/settitle/) с `true` у вертикальной оси, укажите текст заголовка и используйте [setRotationAngle](https://reference.aspose.com/slides/java/com.aspose.slides/icharttextblockformat/#setRotationAngle-float-) для его поворота. Угол измеряется в градусах; в примере сохраняется столбчатая диаграмма, у которой заголовок оси значений повернут на 90 градусов.

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

## **Установить позицию оси на категориальной или оси значений**

Используйте [setAxisBetweenCategories](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setaxisbetweencategories/) для управления тем, пересекает ли ось значений ось категорий между категориями или на метках категорий. Эта настройка применяется к категориальным осям. В примере параметр устанавливается в `true` для горизонтальной категориальной оси столбчатой диаграммы и сохраняется результат.

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

## **Установить единицу отображения на оси значений диаграммы**

Используйте [setDisplayUnit](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setdisplayunit/) для масштабирования меток оси значений без изменения исходных данных. При значении [DisplayUnitType](https://reference.aspose.com/slides/php-java/aspose.slides/displayunittype/) `Millions` значение 60 000 000 будет отображаться как 60. В примере создаётся столбчатая диаграмма и к её вертикальной оси применяется единица отображения «миллионы».

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

## **Настроить логарифмическую ось значений**

Логарифмическая ось значений полезна, когда положительные значения охватывают несколько порядков величины. Например, сервис может получать 10, 100, 1 000, 10 000 и 100 000 запросов за пять периодов. При линейной шкале меньшие значения сосредоточены рядом с нулём. Логарифмическая шкала облегчает сравнение относительного роста: одинаковые расстояния соответствуют одинаковым коэффициентам, а не одинаковым разницам.

Вызовите [setLogarithmic](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setlogarithmic/) с `true` у оси значений и используйте [setLogBase](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setlogbase/) для выбора основания. Это меняет только способ отображения существующих значений; данные и добавление логарифмической линии тренда не меняются. Линия тренда представляет собой построенную по данным зависимость и является отдельной функцией.

### **Выберите ось значений и основание**

Для линейной или столбчатой диаграммы ось значений возвращается методом [getVerticalAxis](https://reference.aspose.com/slides/php-java/aspose.slides/axesmanager/getverticalaxis/). Для горизонтальной гистограммы — методом [getHorizontalAxis](https://reference.aspose.com/slides/php-java/aspose.slides/axesmanager/gethorizontalaxis/). Диаграммы рассеяния и пузырьковые имеют две оси значений, поэтому выбирайте горизонтальную ось для значений X, вертикальную — для Y, или обе. Не применяйте логарифмическое масштабирование к категориальной оси.

Основание логарифма по умолчанию `10`. Для диаграмм PPTX допускаются основания от `2` до `1000` включительно; поддерживаются также дробные основания, такие как `2.5`. При основании `10` последовательные степени (10, 100, 1 000, 10 000) располагаются равномерно.

### **Сравнение линейного и логарифмического масштабирования**

Следующий автономный пример создаёт линейную диаграмму с пятью подсчётами запросов на первом слайде, затем клонирует этот слайд и включает логарифмическую ось значений с основанием 10 на втором. Оба слайда сохраняют одинаковые данные.

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

    // Оставляем первый слайд линейным и изменяем только масштаб оси значений копии.
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

**Linear scale (slide 1):** Равные вертикальные расстояния представляют равные различия в количестве запросов. Наибольшее значение доминирует, делая малые значения трудно различимыми.

![Линейная диаграмма в PowerPoint, показывающая пять подсчётов запросов на линейной оси значений](value-axis-linear.png)

**Logarithmic scale (slide 2):** Равные вертикальные расстояния представляют равные коэффициенты. Каждый период содержит в десять раз больше запросов, чем предыдущий, поэтому точки образуют прямую восходящую линию на шкале с основанием 10. Метки оси по‑прежнему отображают оригинальные подсчёты запросов.

![Те же пять подсчётов запросов в PowerPoint на логарифмической оси значений с основанием 10](value-axis-logarithmic.png)

### **Обрабатывать нулевые и отрицательные значения**

Логарифмическая шкала может отображать только строго положительные значения. Проверьте данные перед включением её. Если нулевые или отрицательные значения имеют смысл, оставьте линейную шкалу или отобразите их отдельно. Если исключение этих значений уместно для анализа, объясните причину их исключения. Не заменяйте их «тихо» на небольшие положительные числа, так как это меняет смысл данных. Любой вручную заданный минимум или максимум для логарифмической оси также должен быть положительным.

## **FAQ**

**Как задать значение, в котором одна ось пересекает другую (пересечение осей)?**

Используйте [setCrossType](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setcrosstype/) для выбора поведения пересечения. Чтобы указать числовое значение пересечения, примените [setCrossAt](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setcrossat/). Эти настройки позволяют переместить точку пересечения осей к подходящей базовой линии.

**Как позиционировать подписи делений относительно оси?**

Вызовите [setTickLabelPosition](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setticklabelposition/) с использованием [TickLabelPositionType](https://reference.aspose.com/slides/php-java/aspose.slides/ticklabelpositiontype/): `Low`, `High`, `NextTo` или `None`. Чтобы управлять самими делениями, используйте [setMajorTickMark](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setmajortickmark/) или [setMinorTickMark](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setminortickmark/); они независимы от позиционирования меток.