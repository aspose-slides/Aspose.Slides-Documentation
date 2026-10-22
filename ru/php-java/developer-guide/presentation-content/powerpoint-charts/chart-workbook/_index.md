---
title: Управление рабочими книгами диаграмм в презентациях с помощью PHP
linktitle: Рабочая книга диаграммы
type: docs
weight: 70
url: /ru/php-java/chart-workbook/
keywords:
- рабочая книга диаграммы
- данные диаграммы
- ячейка рабочей книги
- подпись данных
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
description: "Откройте для себя Aspose.Slides для PHP via Java: легко управляйте рабочими книгами диаграмм в форматах PowerPoint и OpenDocument, оптимизируя данные ваших презентаций."
---
## **Обзор**

В этой статье объясняется, как работать с рабочими книгами диаграмм в Aspose.Slides. Описывается чтение и запись данных диаграммы через потоки рабочей книги, использование ячеек рабочей книги в качестве подпунктов данных диаграммы, доступ к коллекциям листов, а также указание типа источника данных для значений диаграммы.

Также рассматривается работа с внешними рабочими книгами в качестве источников данных диаграмм. Примеры демонстрируют, как создать и назначить внешнюю рабочую книгу, получить путь к внешней рабочей книге, связанной с диаграммой, и редактировать данные диаграммы, когда рабочая книга доступна.

Для ячеек рабочей книги, представляющих отсутствующие данные, см. [Управление отображением пустых ячеек](/slides/ru/php-java/chart-series/) — различия между пустой ячейкой и нулём, а также сравнение линейных диаграмм доступных режимов отображения.

## **Включение данных из скрытых строк и столбцов**

Используйте [Chart::setPlotVisibleCellsOnly](https://reference.aspose.com/slides/php-java/aspose.slides/chart/setplotvisiblecellsonly/) для управления тем, будет ли диаграмма отображать данные из скрытых строк и столбцов листа. Установите `true`, чтобы отображать только видимые ячейки, или `false`, чтобы включить как видимые, так и скрытые ячейки. Эта настройка управляет построением диаграммы; она не скрывает и не отображает строки или столбцы листа.

[пример презентации](hidden-source-data.pptx) содержит столбчатую диаграмму как первую форму на первом слайде. Встроенный лист `Sheet1` имеет диапазон источника `A1:C4`. Строка 3 и столбец C скрыты, но их ячейки всё равно содержат значения.

| Строка листа | A: Месяц | B: Розница | C: Опт (скрытый столбец) |
| --- | --- | --- | --- |
| 2 | Январь | 10 | 30 |
| 3 (скрытая строка) | Февраль | 40 | 60 |
| 4 | Март | 20 | 50 |

Получайте доступ к исходным ячейкам через [ChartData::getChartDataWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getchartdataworkbook/) и проверяйте их статус с помощью [ChartDataCell::isHidden](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatacell/ishidden/). Этот метод сообщает о скрытом статусе без его изменения. В данном файле B2 видима, B3 относится к скрытой строке, а C2 — к скрытому столбцу; пример выводит `false`, `true` и `true` соответственно.

Для этого примера обновите данные диаграммы после изменения настройки построения: сохраните встроенную рабочую книгу через [readWorkbookStream](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/readworkbookstream/) и загрузите её снова с помощью [writeWorkbookStream](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/writeworkbookstream/). При включении всех ячеек также используйте [setRange](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/setrange/) для восстановления полного диапазона, включая скрытую категорию «Февраль». Простое изменение флага недостаточно для обновления кэшированных данных диаграммы и подписей категорий в этом примере.

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

Пример сохраняет две версии презентации: одну только с видимыми значениями розницы (10 и 20), и другую со всеми шестью значениями. Изображения ниже иллюстрируют два режима построения. Строка 3 и столбец C остаются скрытыми в обеих встроенных рабочих книгах.

| Только видимые ячейки (`true`) | Все ячейки (`false`) |
| --- | --- |
| ![Только видимые ячейки: значения розницы 10 и 20 для Января и Марта.](hidden_cells_True.png) | ![Все ячейки: значения розницы и опта для Января, Февраля и Марта.](hidden_cells_False.png) |

Скрытая ячейка, содержащая значение, отличается от пустой ячейки. [Chart::setDisplayBlanksAs](https://reference.aspose.com/slides/php-java/aspose.slides/chart/setdisplayblanksas/) управляет тем, как отображаются отсутствующие значения; он не включает и не исключает скрытые исходные данные. См. [Управление отображением пустых ячеек](/slides/ru/php-java/chart-series/#control-the-display-of-empty-cells) для примера.

## **Получение диапазона данных диаграммы**

Перед обновлением данных рабочей книги в существующей презентации проверьте исходные диапазоны, чтобы определить, какие ячейки листа использует каждая диаграмма. Метод [ChartData::getRange](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getrange/) возвращает текущий диапазон данных в виде формулы, квалифицированной листом, например `Sheet1!$A$1:$D$5`. Здесь `Sheet1` — имя листа, `!` разделяет его от диапазона ячеек, а `$A$1:$D$5` указывает на ячейки от A1 до D5 включительно. Знаки `$` обозначают абсолютные ссылки на строку и столбец.

Метод читает текущий диапазон без изменения диаграммы или её рабочей книги. Если диаграмма не использует рабочую книгу как источник данных, бросается исключение. Дополнительную информацию см. в [ChartData API Reference](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/).

Этот пример открывает презентацию и проверяет формы непосредственно на каждом слайде в поиске диаграмм. Он выводит имя каждой диаграммы и её исходный диапазон. Если диаграмма не использует рабочую книгу, выводится сообщение и проверка продолжается со следующей диаграммой.

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

Aspose.Slides for PHP via Java предоставляет методы [readWorkbookStream](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/readworkbookstream/) и [writeWorkbookStream](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/writeworkbookstream/), позволяющие читать и записывать рабочие книги данных диаграмм (содержащие данные, отредактированные в Aspose.Cells). **Примечание** — данные диаграммы должны быть организованы одинаково или иметь структуру, схожую с исходной.

В этом примере используется презентация с диаграммой как первой формой на первом слайде. Встроенная рабочая книга читается в массив байтов, удаляются существующие серии и категории, после чего та же рабочая книга записывается обратно. Изменения остаются в памяти; пример не сохраняет презентацию.

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

### **Проверка расположения диаграммы после изменения рабочей книги**

При замене встроенной рабочей книги её изменённой версией диаграмма сохраняет исходные коллекции серий и категорий. Такое несоответствие может привести к ошибке [Chart::validateChartLayout](https://reference.aspose.com/slides/php-java/aspose.slides/chart/validatechartlayout/) с «индекс вне диапазона». Очистите существующие серии и категории перед записью обновлённой рабочей книги обратно в диаграмму. Пример использует диаграмму, являющуюся первой формой на первом слайде. Комментарий отмечает место, где будет редактирование рабочей книги; исполняемый пример записывает оригинальную рабочую книгу обратно и проверяет расположение в памяти.

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

        // Измените байты рабочей книги здесь, например, с помощью Aspose.Cells.

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

Очистка коллекций удаляет устаревшие ссылки перед записью рабочей книги. Восстановите необходимые серии и отображения категорий для обновлённой рабочей книги перед использованием диаграммы.

## **Установка пользовательских числовых форматов для ячеек рабочей книги**

Используйте [ChartDataCell::setCustomNumberFormat](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatacell/setcustomnumberformat/) для управления тем, как числовые значения отображаются в встроенной рабочей книге диаграммы. Например, отчёт может требовать отображения коэффициента конверсии в виде процента с четырьмя знаками после запятой и коэффициента с пятью знаками после запятой. Оставьте оба значения числовыми, чтобы они сохранялись доступными для вычислений и построения диаграммы.

Числовой формат изменяет только отображение, а не сохранённое значение. Формат `0.0000%` отображает `0.125` как `12.5000%`; он не заменяет сохранённое число на `12.5`. Аналогично, `0.00000` отображает `0.1234567` как `0.12346` без округления сохранённого значения. Если пользовательский формат — пустая строка (`""`), используется формат, возвращаемый [getPresetNumberFormat](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatacell/getpresetnumberformat/).

В следующем примере создаётся столбчатая диаграмма и получаются её ячейки через [getChartDataWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getchartdataworkbook/). На листе 0 ячейка B2 содержит коэффициент конверсии, а C2 — коэффициент. Обе ячейки поставляют значения диаграммы. Пример также включает подписи значений, привязанные к исходным форматам.

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

Форматы ячеек рабочей книги отделены от форматов, задаваемых напрямую на осях диаграммы или подписи данных. В этом примере каждая подпись отображает значение своей исходной ячейки, потому что [setShowValue](https://reference.aspose.com/slides/php-java/aspose.slides/datalabelformat/setshowvalue/) установлено в `true`, а [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/php-java/aspose.slides/datalabelformat/setnumberformatlinkedtosource/) — в `true`. После сохранения и повторного открытия презентации подписи отображаются как `12.5000%` и `0.12346`, как показано ниже. Вертикальная ось использует собственный числовой формат, назначенный через [setNumberFormat](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setnumberformat/) как `0.00`, а [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setnumberformatlinkedtosource/) установлено в `false`.

Чтобы задать независимый формат подписи, отключите привязку к источнику (`false`) и задайте формат через [setNumberFormat](https://reference.aspose.com/slides/php-java/aspose.slides/datalabelformat/setnumberformat/). Это не изменит формат ячейки рабочей книги. Например, независимый формат `0.00` отобразит первое значение как `0.13`, тогда как B2 всё равно будет показывать `12.5000%`. См. [Подписи данных диаграммы](/slides/ru/php-java/chart-data-label/#set-percentage-sign-with-chart-data-labels) для прямого форматирования подписей.

Изображение ниже получено из сохранённой презентации после её повторного открытия:

![Столбчатая диаграмма с подписями, привязанными к источнику, показывающая 12.5000% и 0.12346, и с независимым числовым форматом оси.](custom-cell-formats.png)

## **Установка ячейки рабочей книги в качестве подписи данных диаграммы**

Текст из ячеек рабочей книги можно использовать в качестве подписей данных диаграммы.

В этом примере добавляется пузырьковая диаграмма с данными по умолчанию на первый слайд существующей презентации. В качестве подписи для первых трёх точек первого ряда используются ячейки A10:A12 листа 0, подписи из ячеек включаются, и обновлённая презентация сохраняется.

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

Метод [ChartDataWorkbook::getWorksheets](https://reference.aspose.com/slides/php-java/aspose.slides/chartdataworkbook/getworksheets/) предоставляет доступ к листам в рабочей книге диаграммы. В этом примере создаётся круговая диаграмма с данными по умолчанию и выводятся имена всех листов в консоль.

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

## **Указание типа источника данных**

Значения точек серии могут также храниться непосредственно как числовые литералы. См. [Установка значений серии с использованием числовых литералов](/slides/ru/php-java/chart-series/#set-series-values-using-numeric-literals) для полного примера, сохраняющего и читающего их. Тип источника значений точек отделён от внутренней или внешней конфигурации рабочей книги диаграммы; использование числовых литералов само по себе не устраняет встроенную рабочую книгу.

В этом примере создаётся 3‑D столбчатая диаграмма с данными по умолчанию и задаются два имени серии, использующие разные источники данных. Первое имя задаётся строковым литералом; второе — ячейкой C1 листа 0. Перечисление [DataSourceType](https://reference.aspose.com/slides/php-java/aspose.slides/datasourcetype/) выбирает источник для каждого имени. Пример сохраняет презентацию с обновлёнными именами серий.

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

Aspose.Slides не поддерживает формат двоичной рабочей книги Excel (.xlsb), который может быть встроен в некоторые диаграммы. Вы можете использовать метод `getEmbeddedWorkbookType` класса [ChartData](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/) совместно с перечислением [WorkbookType](https://reference.aspose.com/slides/php-java/aspose.slides/workbooktype/) для обнаружения неподдерживаемых форматов и пропуска соответствующих диаграмм. Пример проверяет формы на первом слайде существующей презентации, пропускает формы, не являющиеся диаграммами, и выводит диагностическое сообщение для каждой диаграммы с встроенной рабочей книгой .xlsb.

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

        // Читать или изменять поддерживаемые данные рабочей книги диаграммы здесь.
    }
} finally {
    $presentation->dispose();
}
```

## **Внешняя рабочая книга**

Aspose.Slides поддерживает использование внешних рабочих книг в качестве источника данных для диаграмм.

### **Создание внешней рабочей книги**

Используйте [readWorkbookStream](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/readworkbookstream/) и [setExternalWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/setexternalworkbook/) для экспорта встроенной рабочей книги диаграммы в файл и привязки диаграммы к этой внешней книге.

В этом примере создаётся круговая диаграмма с данными по умолчанию и экспортируется её рабочая книга. Запись в файл завершается перед назначением внешней рабочей книги в качестве источника данных диаграммы, после чего сохраняется связанная презентация.

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

### **Назначение внешней рабочей книги**

С помощью метода [setExternalWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/setexternalworkbook/) можно привязать внешнюю рабочую книгу к диаграмме как её источник данных. Этот же метод позволяет обновить путь к внешней рабочей книге (если файл был перемещён).

Хотя редактировать данные в рабочих книгах, хранящихся в удалённых местах или ресурсах, нельзя, их можно использовать в качестве внешнего источника данных. Если указан относительный путь к внешней рабочей книге, он автоматически преобразуется в полный путь.

В примере используется внешняя рабочая книга, лист `Sheet1` которой содержит имя серии в B1, имена категорий в A2:A4 и числовые значения в B2:B4. Пример создаёт круговую диаграмму, привязывает рабочую книгу и с помощью [setRange](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/setrange/) сопоставляет диапазон A1:B4 с одной серией и тремя категориями. Затем презентация сохраняется с привязанной диаграммой.

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

Параметр `updateChartData` метода [setExternalWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/setexternalworkbook/) определяет, будет ли загружена рабочая книга.

* При `updateChartData` = `false` обновляется только путь к рабочей книге. Данные диаграммы не загружаются и не обновляются из целевой книги, поэтому книга может быть недоступна.
* При `updateChartData` = `true` данные диаграммы обновляются из целевой книги.

В следующем примере задаётся URL‑заполнитель с `updateChartData` = `false`. Круговая диаграмма сохраняет данные по умолчанию, и презентация сохраняется без попытки загрузки недоступной рабочей книги.

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

### **Получение пути к внешней рабочей книге, используемой диаграммой**

Чтобы узнать, к какой рабочей книге привязана диаграмма, проверьте, использует ли она внешний источник данных, и получите путь к этой книге.

В примере проверяется первая форма на первом слайде презентации с привязанной внешней книгой. Если это диаграмма, связанная с внешней книгой, выводится путь, полученный через [getExternalWorkbookPath](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getexternalworkbookpath/), затем сохраняется копия презентации.

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

### **Редактирование данных диаграммы**

Данные во внешних рабочих книгах редактируются так же, как и во внутренних. Если внешнюю книгу невозможно загрузить, генерируется исключение.

В примере используется диаграмма, являющаяся первой формой на первом слайде и привязанная к доступной внешней рабочей книге. Значение первой точки первой серии задаётся равным 100, после чего презентация сохраняется. Редактирование значений ячеек может обновлять внешний файл XLSX, поэтому используйте копию, если нужно сохранить оригинальную книгу.

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

### **Восстановление рабочей книги из кэша диаграммы**

Если диаграмма использует внешнюю рабочую книгу, которой нет или она недоступна, Aspose.Slides может восстановить рабочую книгу из кэшированных данных в презентации. Создайте [LoadOptions](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/), вызовите [LoadOptions::setSpreadsheetOptions](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/setspreadsheetoptions/) и установите [SpreadsheetOptions::setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/php-java/aspose.slides/spreadsheetoptions/setrecoverworkbookfromchartcache/) в `true` перед открытием презентации.

Следующий пример PHP восстанавливает данные рабочей книги для диаграммы, являющейся первой формой на первом слайде и ссылающейся на недоступную внешнюю книгу. Доступ к восстановленным данным осуществляется через [Chart::getChartData](https://reference.aspose.com/slides/php-java/aspose.slides/chart/getchartdata/) и [ChartData::getChartDataWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getchartdataworkbook/):

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

Если внешняя рабочая книга недоступна и восстановление отключено, Aspose.Slides генерирует исключение. Включайте восстановление только тогда, когда использование кэша диаграммы допустимо, так как кэш может не содержать изменений, внесённых во внешнюю книгу после последнего обновления презентации.

## **FAQ**

**Можно ли определить, связана ли конкретная диаграмма с внешней или встроенной рабочей книгой?**

Да. Диаграмма имеет [data source type](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getdatasourcetype/) и [path to an external workbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getexternalworkbookpath/); если источник — внешняя рабочая книга, можно прочитать полный путь, чтобы убедиться, что используется внешний файл.

**Поддерживаются ли относительные пути к внешним рабочим книгам и как они хранятся?**

Да. При указании относительного пути он автоматически преобразуется в абсолютный. Презентация сохраняет абсолютный путь в файле PPTX, поэтому при перемещении книги может потребоваться обновить связь.

**Можно ли использовать рабочие книги, расположенные на сетевых ресурсах/общих папках?**

Да, такие книги могут использоваться как внешний источник данных. Однако прямое редактирование удалённых книг из Aspose.Slides не поддерживается — их можно лишь использовать в качестве источника.

**Перезаписывает ли Aspose.Slides внешний XLSX при сохранении презентации?**

Презентация сохраняет [link to the external file](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getexternalworkbookpath/). Редактирование данных диаграммы, привязанных к ячейкам, также может обновлять привязанный локальный файл XLSX. Используйте копию рабочей книги, если оригинал должен оставаться неизменным.

**Что делать, если внешний файл защищён паролем?**

Aspose.Slides не принимает пароль при привязке. Обычно пароль снимают заранее или готовят расшифрованную копию (например, с помощью [Aspose.Cells](https://reference.aspose.com/cells/java/)) и привязывают её.

**Могут ли несколько диаграмм ссылаться на одну и ту же внешнюю рабочую книгу?**

Да. Каждая диаграмма хранит свою собственную ссылку. Если все они указывают на один и тот же файл, обновление этого файла будет отражаться в каждой диаграмме при следующей загрузке данных.