---
title: Управление рабочими книгами диаграмм в презентациях с использованием PHP
linktitle: Рабочая книга диаграммы
type: docs
weight: 70
url: /ru/php-java/chart-workbook/
keywords:
- рабочая книга диаграммы
- данные диаграммы
- ячейка рабочей книги
- метка данных
- лист
- источник данных
- внешняя рабочая книга
- внешние данные
- кэш диаграммы
- восстановление рабочей книги
- PowerPoint
- презентация
- PHP
- Aspose.Slides
description: "Откройте Aspose.Slides for PHP via Java: без труда управляйте рабочими книгами диаграмм в форматах PowerPoint и OpenDocument, упрощая данные вашей презентации."
---
## **Обзор**

Эта статья объясняет, как работать с рабочими книгами диаграмм в Aspose.Slides. Она показывает, как читать и записывать данные диаграммы через потоки рабочей книги, использовать ячейки рабочей книги в качестве меток данных диаграммы, получать доступ к коллекциям листов и задавать тип источника данных для значений диаграммы.

Также рассматривается работа с внешними рабочими книгами в качестве источников данных диаграммы. Примеры демонстрируют, как создать и назначить внешнюю рабочую книгу, получить путь к внешней рабочей книге, привязанной к диаграмме, и редактировать данные диаграммы, когда рабочая книга доступна.

Для ячеек рабочей книги, представляющих отсутствующие данные, смотрите [Управление отображением пустых ячеек](/slides/ru/php-java/chart-series/) для различий между пустой ячейкой и нулём, а также сравнения режимов отображения на линейной диаграмме.

## **Включать данные из скрытых строк и столбцов**

Используйте [Chart::setPlotVisibleCellsOnly](https://reference.aspose.com/slides/php-java/aspose.slides/chart/setplotvisiblecellsonly/) для управления тем, использует ли диаграмма данные из скрытых строк и столбцов листа. Установите `true`, чтобы строить только видимые ячейки, или `false`, чтобы включать как видимые, так и скрытые ячейки. Эта настройка управляет построением диаграммы; она не скрывает и не делает видимыми строки или столбцы листа.

Пример презентации ([пример презентации](hidden-source-data.pptx)) содержит столбчатую диаграмму в качестве первой фигуры на первом слайде. Встроенный лист `Sheet1` содержит следующий исходный диапазон `A1:C4`. Строка 3 и столбец C скрыты, но их ячейки всё ещё содержат значения.

| Строка листа | A: Месяц | B: Розница | C: Оптовая (скрытый столбец) |
| --- | --- | --- | --- |
| 2 | Январь | 10 | 30 |
| 3 (скрытая строка) | Февраль | 40 | 60 |
| 4 | Март | 20 | 50 |

Получите доступ к исходным ячейкам через [ChartData::getChartDataWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getchartdataworkbook/) и считайте [ChartDataCell::isHidden](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatacell/ishidden/) чтобы проверить их скрытый статус. Этот метод сообщает статус скрытия без его изменения. В этом файле B2 видима, B3 относится к скрытой строке, а C2 — к скрытому столбцу; пример выводит `false`, `true` и `true` соответственно.

Для этого примера обновите данные диаграммы после изменения настройки построения: сохраните встроенную рабочую книгу с помощью [readWorkbookStream](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/readworkbookstream/) и загрузите её снова с помощью [writeWorkbookStream](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/writeworkbookstream/). При включении всех ячеек также используйте [setRange](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/setrange/) для восстановления полного диапазона, включая скрытую категорию февраля. Простое изменение флага недостаточно для обновления кэшированных данных диаграммы и меток категорий в этом примере.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("hidden-source-data.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shapeCount = java_values($slide->getShapes()->size());
    if ($shapeCount > 0 && java_instanceof($slide->getShapes()->get_Item(0), new JavaClass("com.aspose.slides.IChart"))) {
        $chart = $slide->getShapes()->get_Item(0);
        $workbook = $chart->getChartData()->getChartDataWorkbook();
        echo "B2 hidden: " . (java_values($workbook->getCell(0, "B2")->isHidden()) ? "true" : "false"), PHP_EOL;
        echo "B3 hidden: " . (java_values($workbook->getCell(0, "B3")->isHidden()) ? "true" : "false"), PHP_EOL;
        echo "C2 hidden: " . (java_values($workbook->getCell(0, "C2")->isHidden()) ? "true" : "false"), PHP_EOL;

        $workbookData = $chart->getChartData()->readWorkbookStream();
        foreach ([true, false] as $visibleOnly) {
            $chart->setPlotVisibleCellsOnly($visibleOnly);

            // Обновить данные диаграммы из встроенной рабочей книги.
            $chart->getChartData()->writeWorkbookStream($workbookData);
            if (!$visibleOnly) {
                // Восстановить полный исходный диапазон, включая скрытые категории.
                $chart->getChartData()->setRange('Sheet1!$A$1:$C$4');
            }

            $presentation->save("hidden_cells_" . ($visibleOnly ? "true" : "false") . ".pptx", SaveFormat::Pptx);
        }
    } else {
        echo "The first shape is not a chart.", PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

Пример сохраняет две версии презентации: одну только с видимыми значениями розницы (10 и 20) и другую со всеми шестью значениями. Ниже изображены два режима построения. Строка 3 и столбец C остаются скрытыми в обеих встроенных рабочих книгах.

| Только видимые ячейки (`true`) | Все ячейки (`false`) |
| --- | --- |
| ![Только видимые ячейки: значения розницы 10 и 20 для января и марта.](hidden_cells_True.png) | ![Все ячейки: значения розницы и оптовые значения для января, февраля и марта.](hidden_cells_False.png) |

Скрытая ячейка, содержащая значение, отличается от пустой ячейки. [Chart::setDisplayBlanksAs](https://reference.aspose.com/slides/php-java/aspose.slides/chart/setdisplayblanksas/) управляет тем, как отображаются отсутствующие значения; она не включает и не исключает скрытые исходные данные. Смотрите [Управление отображением пустых ячеек](/slides/ru/php-java/chart-series/#control-the-display-of-empty-cells) для примера.

## **Получить диапазон данных диаграммы**

Перед обновлением данных рабочей книги в существующей презентации проверьте исходные диапазоны, чтобы определить, какие ячейки листа использует каждая диаграмма. Метод [ChartData::getRange](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getrange/) возвращает текущий диапазон данных в виде формулы, квалифицированной листом, например `Sheet1!$A$1:$D$5`. Здесь `Sheet1` — название листа, `!` отделяет его от диапазона ячеек, а `$A$1:$D$5` определяет ячейки от A1 до D5 включительно. Знак доллара указывает на абсолютные ссылки на строки и столбцы.

Метод считывает текущий диапазон без изменения диаграммы или её рабочей книги. Если диаграмма не использует рабочую книгу в качестве источника данных, метод генерирует исключение. Для получения дополнительной информации смотрите [ChartData API Reference](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/).

В этом примере открывается презентация и проверяются фигуры на каждом слайде на наличие диаграмм. Выводятся имя каждой диаграммы и её исходный диапазон. Если диаграмма не использует рабочую книгу, выводится сообщение и переход к следующей диаграмме.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("presentation.pptx");
try {
    $slideCount = java_values($presentation->getSlides()->size());
    for ($slideIndex = 0; $slideIndex < $slideCount; $slideIndex++) {
        $slide = $presentation->getSlides()->get_Item($slideIndex);
        $shapeCount = java_values($slide->getShapes()->size());
        for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
            $shape = $slide->getShapes()->get_Item($shapeIndex);
            if (java_instanceof($shape, new JavaClass("com.aspose.slides.IChart"))) {
                $chart = $shape;
                try {
                    $range = $chart->getChartData()->getRange();
                    echo $chart->getName() . ": " . $range, PHP_EOL;
                } catch (JavaException $exception) {
                    if (java_instanceof($exception, new JavaClass("com.aspose.slides.exceptions.InvalidOperationException"))) {
                        echo $chart->getName() . ": The chart does not use a workbook as its data source.", PHP_EOL;
                    } else {
                        echo $chart->getName() . ": " . $exception->getMessage(), PHP_EOL;
                    }
                }
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

## **Чтение и запись данных диаграммы из рабочей книги**

Aspose.Slides for PHP via Java предоставляет методы [readWorkbookStream](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/readworkbookstream/) и [writeWorkbookStream](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/writeworkbookstream/), позволяющие читать и записывать рабочие книги данных диаграмм (содержащие данные диаграмм, отредактированные с помощью Aspose.Cells). **Примечание** что данные диаграммы должны быть организованы аналогично или иметь структуру, сходную с исходной.

В этом примере используется презентация с диаграммой в качестве первой фигуры на первом слайде. Она читает встроенную рабочую книгу в массив байтов, очищает существующие серии и категории и записывает ту же рабочую книгу обратно. Изменения остаются в памяти; пример не сохраняет презентацию.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("chart.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shapeCount = java_values($slide->getShapes()->size());
    if ($shapeCount > 0 && java_instanceof($slide->getShapes()->get_Item(0), new JavaClass("com.aspose.slides.IChart"))) {
        $chart = $slide->getShapes()->get_Item(0);
        $chartData = $chart->getChartData();
        $workbookData = $chartData->readWorkbookStream();

        $chartData->getSeries()->clear();
        $chartData->getCategories()->clear();

        $chartData->writeWorkbookStream($workbookData);
    } else {
        echo "The first shape is not a chart.", PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

### **Проверка раскладки диаграммы после изменения рабочей книги**

Когда вы заменяете встроенную рабочую книгу изменённой, диаграмма сохраняет свои исходные коллекции серий и категорий. Это несоответствие может привести к ошибке [Chart::validateChartLayout](https://reference.aspose.com/slides/php-java/aspose.slides/chart/validatechartlayout/) с сообщением о выходе индекса за пределы. Очистите существующие серии и категории перед записью обновлённой рабочей книги обратно в диаграмму. В этом примере используется диаграмма, являющаяся первой фигурой на первом слайде. Комментарий указывает, где происходит редактирование рабочей книги; исполняемый пример записывает оригинальную рабочую книгу обратно и проверяет раскладку в памяти.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("chart.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shapeCount = java_values($slide->getShapes()->size());
    if ($shapeCount > 0 && java_instanceof($slide->getShapes()->get_Item(0), new JavaClass("com.aspose.slides.IChart"))) {
        $chart = $slide->getShapes()->get_Item(0);
        $chartData = $chart->getChartData();
        $workbookData = $chartData->readWorkbookStream();

        // Измените байты рабочей книги здесь, например, используя Aspose.Cells.

        $chartData->getSeries()->clear();
        $chartData->getCategories()->clear();

        $chartData->writeWorkbookStream($workbookData);
        $chart->validateChartLayout();
    } else {
        echo "The first shape is not a chart.", PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

Очистка коллекций удаляет устаревшие ссылки на данные перед записью рабочей книги. Восстановите необходимые сопоставления серий и категорий для обновлённой рабочей книги перед использованием диаграммы.

## **Установить пользовательские числовые форматы для ячеек рабочей книги**

Используйте [ChartDataCell::setCustomNumberFormat](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatacell/setcustomnumberformat/) для управления отображением числовых значений во встроенной рабочей книге диаграммы. Например, в отчёте может потребоваться коэффициент преобразования, отображаемый в виде процента с четырьмя знаками после запятой, и коэффициент, отображаемый с пятью знаками после запятой. Оставляйте оба значения числовыми, чтобы они оставались доступными для вычислений и построения диаграммы.

Числовой формат меняет только отображение, а не сохраняемое значение. Формат `0.0000%` отображает `0.125` как `12.5000%`; он не заменяет хранимое число на `12.5`. Аналогично, `0.00000` отображает `0.1234567` как `0.12346` без округления сохраняемого значения. Если пользовательский формат — пустая строка (`""`), используется формат, возвращённый [getPresetNumberFormat](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatacell/getpresetnumberformat/).

Следующий пример создаёт столбчатую диаграмму и получает доступ к её ячейкам через [getChartDataWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getchartdataworkbook/). На листе 0 ячейка B2 содержит коэффициент преобразования, а C2 — коэффициент. Обе ячейки поставляют значения диаграммы. Пример также включает метки значений, привязанные к исходным форматам.

```php
use aspose\slides\Presentation;
use aspose\slides\ChartType;
use aspose\slides\SlideSizeScaleType;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $presentation->getSlideSize()->setSize(720, 270, SlideSizeScaleType::DoNotScale);
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 20, 620, 210);
    $chart->setTitle(false);

    $chart->getAxes()->getVerticalAxis()->setNumberFormatLinkedToSource(false);
    $chart->getAxes()->getVerticalAxis()->setNumberFormat("0.00");
    $chart->getAxes()->getVerticalAxis()->setAutomaticMinValue(false);
    $chart->getAxes()->getVerticalAxis()->setMinValue(0);

    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();

    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $workbook->clear(0);

    $categoryCell = $workbook->getCell(0, "A2", "Sample");
    $chart->getChartData()->getCategories()->add($categoryCell);

    $percentageCell = $workbook->getCell(0, "B2", 0.125);
    $percentageCell->setCustomNumberFormat("0.0000%");
    $percentageName = $workbook->getCell(0, "B1", "Conversion rate");
    $percentageSeries = $chart->getChartData()->getSeries()->add($percentageName, $chart->getType());
    $percentageSeries->getDataPoints()->addDataPointForBarSeries($percentageCell);

    $precisionCell = $workbook->getCell(0, "C2", 0.1234567);
    $precisionCell->setCustomNumberFormat("0.00000");
    $precisionName = $workbook->getCell(0, "C1", "Coefficient");
    $precisionSeries = $chart->getChartData()->getSeries()->add($precisionName, $chart->getType());
    $precisionSeries->getDataPoints()->addDataPointForBarSeries($precisionCell);

    for ($seriesIndex = 0; $seriesIndex < java_values($chart->getChartData()->getSeries()->size()); $seriesIndex++) {
        $series = $chart->getChartData()->getSeries()->get_Item($seriesIndex);
        $labelFormat = $series->getDataPoints()->get_Item(0)->getLabel()->getDataLabelFormat();
        $labelFormat->setShowValue(true);
        $labelFormat->setNumberFormatLinkedToSource(true);
    }

    $presentation->save("CustomCellFormats.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Форматы ячеек рабочей книги отличаются от форматов, устанавливаемых напрямую на осях диаграммы или метках данных. В этом примере каждая метка отображает значение исходной ячейки, потому что [setShowValue](https://reference.aspose.com/slides/php-java/aspose.slides/datalabelformat/setshowvalue/) установлен в `true`, и следует исходному числовому формату, поскольку [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/php-java/aspose.slides/datalabelformat/setnumberformatlinkedtosource/) установлен в `true`. После сохранения и повторного открытия презентации метки показывают `12.5000%` и `0.12346`, как показано ниже. Вертикальная ось использует собственный числовой формат, назначенный через [setNumberFormat](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setnumberformat/) как `0.00`, при этом [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setnumberformatlinkedtosource/) установлен в `false`.

Чтобы отформатировать метку данных независимо, установите её флаг привязки к источнику в `false` и задайте формат с помощью [setNumberFormat](https://reference.aspose.com/slides/php-java/aspose.slides/datalabelformat/setnumberformat/). Это не меняет формат ячейки рабочей книги. Например, независимый формат метки `0.00` отображает первое значение как `0.13`, в то время как B2 всё ещё показывает `12.5000%`. См. [Chart Data Labels](/slides/ru/php-java/chart-data-label/#set-percentage-sign-with-chart-data-labels) для прямого форматирования меток.

Изображение ниже было получено из сохранённой презентации после её повторного открытия:

![Столбчатая диаграмма с метками, связанными с источником, показывающими 12.5000% и 0.12346, и независимым числовым форматом оси.](custom-cell-formats.png)

## **Установить ячейку рабочей книги как метку данных диаграммы**

Можно использовать текст из ячеек рабочей книги в качестве меток данных диаграммы.

В этом примере добавляется пузырьковая диаграмма с данными по умолчанию на первый слайд существующей презентации. Она использует ячейки A10:A12 на листе 0 для первых трёх меток в первой серии, включает метки из ячеек и сохраняет обновлённую презентацию.

```php
use aspose\slides\Presentation;
use aspose\slides\ChartType;
use aspose\slides\SaveFormat;

$presentation = new Presentation("chart2.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Bubble, 50, 50, 600, 400, true);
    $series = $chart->getChartData()->getSeries()->get_Item(0);
    $workbook = $chart->getChartData()->getChartDataWorkbook();

    $series->getLabels()->getDefaultDataLabelFormat()->setShowLabelValueFromCell(true);
    $series->getLabels()->get_Item(0)->setValueFromCell($workbook->getCell(0, "A10", "Label 0 cell value"));
    $series->getLabels()->get_Item(1)->setValueFromCell($workbook->getCell(0, "A11", "Label 1 cell value"));
    $series->getLabels()->get_Item(2)->setValueFromCell($workbook->getCell(0, "A12", "Label 2 cell value"));

    $presentation->save("resultchart.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Управление листами**

Метод [ChartDataWorkbook::getWorksheets](https://reference.aspose.com/slides/php-java/aspose.slides/chartdataworkbook/getworksheets/) предоставляет доступ к листам в рабочей книге диаграммы. Этот пример создаёт круговую диаграмму с данными по умолчанию и выводит имена всех листов в консоль.

```php
use aspose\slides\Presentation;
use aspose\slides\ChartType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Pie, 50, 50, 400, 500);
    $workbook = $chart->getChartData()->getChartDataWorkbook();

    for ($i = 0; $i < java_values($workbook->getWorksheets()->size()); $i++) {
        echo $workbook->getWorksheets()->get_Item($i)->getName(), PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

## **Указать тип источника данных**

В этом примере создаётся 3‑мерная столбчатая диаграмма с данными по умолчанию и задаются два имени серий, используя разные источники данных. Первое имя задаётся строковым литералом; второе — ячейкой C1 на листе 0. Перечисление [DataSourceType](https://reference.aspose.com/slides/php-java/aspose.slides/datasourcetype/) выбирает источник для каждого имени. Пример сохраняет презентацию с обновлёнными именами серий.

```php
use aspose\slides\Presentation;
use aspose\slides\ChartType;
use aspose\slides\SaveFormat;
use aspose\slides\DataSourceType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Column3D, 50, 50, 600, 400, true);
    $literalName = $chart->getChartData()->getSeries()->get_Item(0)->getName();

    $literalName->setDataSourceType(DataSourceType::StringLiterals);
    $literalName->setData("LiteralString");

    $cellName = $chart->getChartData()->getSeries()->get_Item(1)->getName();
    $nameCell = $chart->getChartData()->getChartDataWorkbook()->getCell(0, "C1", "NewCell");
    $cellName->setDataSourceType(DataSourceType::Worksheet);
    $cellName->setData($nameCell);

    $presentation->save("pres.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Обнаружение неподдерживаемых форматов встроенных рабочих книг**

Aspose.Slides не поддерживает бинарный формат Excel (.xlsb), который может быть встроен в некоторые диаграммы. Вы можете использовать метод `getEmbeddedWorkbookType` в [ChartData](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/) вместе с перечислением [WorkbookType](https://reference.aspose.com/slides/php-java/aspose.slides/workbooktype/) для обнаружения неподдерживаемых форматов и пропуска таких диаграмм. Этот пример проверяет фигуры на первом слайде существующей презентации, пропускает не‑диаграммные фигуры и выводит диагностическое сообщение для каждой диаграммы со встроенной рабочей книгой .xlsb.

```php
use aspose\slides\Presentation;
use aspose\slides\ChartDataSourceType;
use aspose\slides\WorkbookType;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shapeCount = java_values($slide->getShapes()->size());
    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $slide->getShapes()->get_Item($shapeIndex);
        if (!java_instanceof($shape, new JavaClass("com.aspose.slides.IChart"))) {
            continue;
        }

        $chart = $shape;
        $chartData = $chart->getChartData();
        $isInternalWorkbook = java_values($chartData->getDataSourceType()) == ChartDataSourceType::InternalWorkbook;
        $isBinaryMacro = java_values($chartData->getEmbeddedWorkbookType()) == WorkbookType::WorkbookBinaryMacro;

        if ($isInternalWorkbook && $isBinaryMacro) {
            echo "Skipping a chart with an unsupported .xlsb workbook.", PHP_EOL;
            continue;
        }

        // Прочитать или изменить поддерживаемые данные рабочей книги диаграммы здесь.
    }
} finally {
    $presentation->dispose();
}
```

## **Внешняя рабочая книга**

Aspose.Slides поддерживает использование внешних рабочих книг в качестве источника данных для диаграмм.

### **Создать внешнюю рабочую книгу**

Используйте [readWorkbookStream](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/readworkbookstream/) и [setExternalWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/setexternalworkbook/) для экспорта встроенной рабочей книги диаграммы в файл и привязки диаграммы к этой внешней рабочей книге.

В этом примере создаётся круговая диаграмма с данными по умолчанию и экспортируется её рабочая книга. Запись файла завершается до назначения внешней рабочей книги в качестве источника данных диаграммы, затем сохраняется связанная презентация.

```php
use aspose\slides\Presentation;
use aspose\slides\ChartType;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Pie, 50, 50, 400, 600);
    $workbookPath = new Java("java.io.File", "externalWorkbook1.xlsx");
    $workbookData = $chart->getChartData()->readWorkbookStream();
    try {
        $fileStream = new Java("java.io.FileOutputStream", $workbookPath);
        try {
            $fileStream->write($workbookData);
        } finally {
            $fileStream->close();
        }
        $chart->getChartData()->setExternalWorkbook($workbookPath->getAbsolutePath());
        
        $presentation->save("externalWorkbook.pptx", SaveFormat::Pptx);
    } catch (JavaException $exception) {
        echo "Could not write the external workbook: " . $exception->getMessage(), PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

### **Назначить внешнюю рабочую книгу**

С помощью метода [setExternalWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/setexternalworkbook/) можно назначить внешнюю рабочую книгу диаграмме в качестве её источника данных. Этот метод также можно использовать для обновления пути к внешней рабочей книге (если она была перемещена).

Хотя вы не можете редактировать данные в рабочих книгах, хранящихся в удалённых местах или ресурсах, такие книги всё равно можно использовать в качестве внешнего источника данных. Если указан относительный путь к внешней рабочей книге, он автоматически преобразуется в полный путь.

В этом примере используется внешняя рабочая книга, лист которой с именем `Sheet1` содержит имя серии в B1, названия категорий в A2:A4 и числовые значения в B2:B4. Пример создаёт круговую диаграмму, связывает рабочую книгу и использует [setRange](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/setrange/) для сопоставления A1:B4 с одной серией и тремя категориями. Пример сохраняет презентацию со связанным графиком.

```php
use aspose\slides\Presentation;
use aspose\slides\ChartType;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Pie, 50, 50, 400, 600, true);
    $chartData = $chart->getChartData();
    $workbookFile = new Java("java.io.File", "externalWorkbook.xlsx");
    $workbookPath = $workbookFile->getAbsolutePath();

    $chartData->setExternalWorkbook($workbookPath);
    $chartData->setRange('Sheet1!$A$1:$B$4');

    $presentation->save("Presentation_with_externalWorkbook.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Параметр `updateChartData` метода [setExternalWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/setexternalworkbook/) управляет тем, загружается ли рабочая книга.

* Когда `updateChartData` равно `false`, обновляется только путь к рабочей книге. Данные диаграммы не загружаются и не обновляются из целевой рабочей книги, поэтому рабочая книга может быть недоступна.
* Когда `updateChartData` равно `true`, данные диаграммы обновляются из целевой рабочей книги.

Следующий пример назначает псевдоссылку с `updateChartData`, установленным в `false`. Он сохраняет значения по умолчанию круговой диаграммы и сохраняет презентацию без загрузки недоступной рабочей книги.

```php
use aspose\slides\Presentation;
use aspose\slides\ChartType;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Pie, 50, 50, 400, 600, true);
    $chart->getChartData()->setExternalWorkbook("https://example.com/unavailable-workbook.xlsx", false);

    $presentation->save("SetExternalWorkbookWithUpdateChartData.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **Получить путь к внешней рабочей книге источника данных диаграммы**

Чтобы определить рабочую книгу, привязанную к диаграмме, проверьте, использует ли диаграмма внешний источник данных, и получите её путь.

В этом примере проверяется первая фигура на первом слайде презентации со связанным внешним рабочим файлом. Если это диаграмма, связанная с внешней рабочей книгой, пример выводит [getExternalWorkbookPath](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getexternalworkbookpath/) в консоль. Затем сохраняется копия презентации.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ChartDataSourceType;

$presentation = new Presentation("externalWorkbook.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shapeCount = java_values($slide->getShapes()->size());
    if ($shapeCount > 0 && java_instanceof($slide->getShapes()->get_Item(0), new JavaClass("com.aspose.slides.IChart"))) {
        $chart = $slide->getShapes()->get_Item(0);
        $chartData = $chart->getChartData();
        if (java_values($chartData->getDataSourceType()) == ChartDataSourceType::ExternalWorkbook) {
            echo $chartData->getExternalWorkbookPath(), PHP_EOL;
        } else {
            echo "The chart does not use an external workbook.", PHP_EOL;
        }
    } else {
        echo "The first shape is not a chart.", PHP_EOL;
    }

    $presentation->save("Result.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **Редактировать данные диаграммы**

Вы можете редактировать данные во внешних рабочих книгах так же, как вносите изменения в содержимое внутренних книг. Если внешнюю рабочую книгу не удаётся загрузить, генерируется исключение.

В этом примере используется диаграмма, являющаяся первой фигурой на первом слайде и связанная с доступной внешней рабочей книгой. Она задаёт значение первой точки данных первой серии, привязанное к ячейке, равным 100 и сохраняет обновлённую презентацию. Редактирование значений ячеек может обновлять связанный внешний файл XLSX, поэтому используйте копию, если необходимо сохранить оригинальную рабочую книгу.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("presentation.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shapeCount = java_values($slide->getShapes()->size());
    if ($shapeCount > 0 && java_instanceof($slide->getShapes()->get_Item(0), new JavaClass("com.aspose.slides.IChart"))) {
        $chart = $slide->getShapes()->get_Item(0);
        $series = $chart->getChartData()->getSeries();
        if (java_values($series->size()) > 0 && java_values($series->get_Item(0)->getDataPoints()->size()) > 0) {
            $valueCell = $series->get_Item(0)->getDataPoints()->get_Item(0)->getValue()->getAsCell();
            if (!java_is_null($valueCell)) {
                $valueCell->setValue(100);
                $presentation->save("presentation_out.pptx", SaveFormat::Pptx);
            } else {
                echo "The first data point is not linked to a workbook cell.", PHP_EOL;
            }
        } else {
            echo "The chart has no data points to edit.", PHP_EOL;
        }
    } else {
        echo "The first shape is not a chart.", PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

### **Восстановить рабочую книгу из кэша диаграммы**

Если диаграмма использует внешнюю рабочую книгу, которой нет или она недоступна, Aspose.Slides может восстановить рабочую книгу диаграммы из данных, кэшированных в презентации. Создайте [LoadOptions](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/), вызовите [LoadOptions::setSpreadsheetOptions](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/setspreadsheetoptions/) и установите [SpreadsheetOptions::setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/php-java/aspose.slides/spreadsheetoptions/setrecoverworkbookfromchartcache/) в `true` перед открытием презентации.

Следующий пример на PHP восстанавливает данные рабочей книги для диаграммы, являющейся первой фигурой на первом слайде и ссылающейся на недоступную внешнюю рабочую книгу. Он получает доступ к восстановленным данным через [Chart::getChartData](https://reference.aspose.com/slides/php-java/aspose.slides/chart/getchartdata/) и [ChartData::getChartDataWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getchartdataworkbook/):

```php
use aspose\slides\Presentation;
use aspose\slides\SpreadsheetOptions;
use aspose\slides\LoadOptions;

$spreadsheetOptions = new SpreadsheetOptions();
$spreadsheetOptions->setRecoverWorkbookFromChartCache(true);

$loadOptions = new LoadOptions();
$loadOptions->setSpreadsheetOptions($spreadsheetOptions);

$presentation = new Presentation("presentation.pptx", $loadOptions);
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shapeCount = java_values($slide->getShapes()->size());
    if ($shapeCount > 0 && java_instanceof($slide->getShapes()->get_Item(0), new JavaClass("com.aspose.slides.IChart"))) {
        $chart = $slide->getShapes()->get_Item(0);
        $recoveredWorkbook = $chart->getChartData()->getChartDataWorkbook();

        // Прочитать или изменить восстановленные данные рабочей книги здесь.
    } else {
        echo "The first shape is not a chart.", PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

Если внешняя рабочая книга недоступна и восстановление отключено, Aspose.Slides генерирует исключение. Включайте восстановление только тогда, когда использование кэшированных данных диаграммы является приемлемой альтернативой, поскольку кэш может не содержать изменений, внесённых во внешнюю рабочую книгу после последнего обновления презентации.

## **FAQ**

**Можно ли определить, связана ли конкретная диаграмма с внешней или встроенной рабочей книгой?**  
Да. Диаграмма имеет [тип источника данных](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getdatasourcetype/) и [путь к внешней рабочей книге](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getexternalworkbookpath/); если источник — внешняя рабочая книга, можно прочитать полный путь, чтобы убедиться, что используется внешний файл.

**Поддерживаются ли относительные пути к внешним рабочим книгам и как они хранятся?**  
Да. Если указать относительный путь, он автоматически преобразуется в абсолютный. Презентация хранит абсолютный путь в файле PPTX, поэтому при перемещении рабочей книги может потребоваться обновить ссылку.

**Можно ли использовать рабочие книги, расположенные на сетевых ресурсах/общих папках?**  
Да, такие рабочие книги могут использоваться как внешний источник данных. Однако редактирование удалённых рабочих книг напрямую из Aspose.Slides не поддерживается — их можно использовать только в качестве источника.

**Перезаписывает ли Aspose.Slides внешний XLSX при сохранении презентации?**  
Презентация сохраняет [ссылку на внешний файл](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getexternalworkbookpath/). Редактирование данных диаграммы, привязанных к ячейкам, также может обновлять связанный локальный файл XLSX. Используйте копию рабочей книги, если оригинал должен оставаться неизменным.

**Что делать, если внешний файл защищён паролем?**  
Aspose.Slides не принимает пароль при создании ссылки. Обычный подход — удалить защиту заранее или подготовить расшифрованную копию (например, с помощью [Aspose.Cells](https://reference.aspose.com/cells/java/)) и привязать к этой копии.

**Могут ли несколько диаграмм ссылаться на одну и ту же внешнюю рабочую книгу?**  
Да. Каждая диаграмма хранит свою собственную ссылку. Если они все указывают на один и тот же файл, обновление этого файла отразится в каждой диаграмме при следующей загрузке данных.