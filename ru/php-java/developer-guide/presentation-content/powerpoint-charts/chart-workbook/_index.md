---
title: У管理图表工作簿如何在演示文稿中使用PHP
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
- кеш диаграммы
- восстановление рабочей книги
- PowerPoint
- презентация
- PHP
- Aspose.Slides
description: "Откройте для себя Aspose.Slides для PHP через Java: легко управляйте рабочими книгами диаграмм в форматах PowerPoint и OpenDocument, упрощая работу с данными вашей презентации."
---
## **Обзор**

В этой статье объясняется, как работать с рабочими книгами диаграмм в Aspose.Slides. Показано, как читать и записывать данные диаграммы через потоки рабочей книги, использовать ячейки рабочей книги в качестве меток данных диаграммы, получать доступ к коллекциям листов и указывать тип источника данных для значений диаграммы.  

Также рассматривается работа с внешними рабочими книгами в качестве источников данных диаграммы. В примерах демонстрируется, как создать и привязать внешнюю рабочую книгу, получить путь к внешней рабочей книге, связанной с диаграммой, и редактировать данные диаграммы, когда рабочая книга доступна.  

Для ячеек рабочей книги, представляющих отсутствующие данные, см. [Управление отображением пустых ячеек](/slides/ru/php-java/chart-series/) для различий между пустой ячейкой и нулём, а также сравнение режимов отображения на линейной диаграмме.

## **Включать данные из скрытых строк и столбцов**

Используйте [Chart::setPlotVisibleCellsOnly](https://reference.aspose.com/slides/ru/php-java/aspose.slides/chart/setplotvisiblecellsonly/) для управления тем, будет ли диаграмма отображать данные из скрытых строк и столбцов листа. Установите `true`, чтобы отображать только видимые ячейки, или `false`, чтобы включать как видимые, так и скрытые ячейки. Этот параметр управляет построением диаграммы; он не скрывает и не отображает строки или столбцы листа.  

Скачайте [hidden-source-data.pptx](hidden-source-data.pptx) и поместите его в рабочий каталог. Его первый слайд содержит столбчатую диаграмму как первую фигуру. Встроенный лист, `Sheet1`, содержит следующий исходный диапазон, `A1:C4`. Строка 3 и столбец C скрыты, но их ячейки всё равно содержат значения.

| Строка листа | A: Месяц | B: Розничные | C: Оптовые (скрытый столбец) |
| --- | --- | --- | --- |
| 2 | Январь | 10 | 30 |
| 3 (скрытая строка) | Февраль | 40 | 60 |
| 4 | Март | 20 | 50 |

Получайте исходные ячейки через [ChartData::getChartDataWorkbook](https://reference.aspose.com/slides/ru/php-java/aspose.slides/chartdata/getchartdataworkbook/) и читайте [ChartDataCell::isHidden](https://reference.aspose.com/slides/ru/php-java/aspose.slides/chartdatacell/ishidden/) для проверки их скрытого статуса. Этот метод сообщает о скрытом статусе без его изменения. В этом файле B2 видимая, B3 относится к скрытой строке, а C2 — к скрытому столбцу; пример выводит `false`, `true` и `true` соответственно.  

Для этого примера обновите данные диаграммы после изменения параметра построения: сохраните встроенную рабочую книгу с помощью [readWorkbookStream](https://reference.aspose.com/slides/ru/php-java/aspose.slides/chartdata/readworkbookstream/) и загрузите её заново с помощью [writeWorkbookStream](https://reference.aspose.com/slides/ru/php-java/aspose.slides/chartdata/writeworkbookstream/). При включении всех ячеек также используйте [setRange](https://reference.aspose.com/slides/ru/php-java/aspose.slides/chartdata/setrange/) для восстановления полного диапазона, включая скрытую категорию февраля. Просто изменение флага недостаточно для обновления кэшированных данных диаграммы и меток категорий в этом образце.

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

Пример сохраняет `hidden_cells_true.pptx` только с видимыми значениями Retail (10 и 20), и `hidden_cells_false.pptx` со всеми шестью значениями. Ниже приведённые изображения иллюстрируют два режима построения. Строка 3 и столбец C остаются скрытыми в обеих встроенных рабочих книгах.

| Только видимые ячейки (`true`) | Все ячейки (`false`) |
| --- | --- |
| ![Только видимые ячейки: значения Retail 10 и 20 для Января и Марта.](hidden_cells_True.png) | ![Все ячейки: значения Retail и Wholesale для Января, Февраля и Марта.](hidden_cells_False.png) |

Скрытая ячейка, содержащая значение, отличается от пустой ячейки. [Chart::setDisplayBlanksAs](https://reference.aspose.com/slides/ru/php-java/aspose.slides/chart/setdisplayblanksas/) управляет тем, как отображаются отсутствующие значения; он не включает и не исключает скрытые исходные данные. См. [Управление отображением пустых ячеек](/slides/ru/php-java/chart-series/#control-the-display-of-empty-cells) для примера.

## **Чтение и запись данных диаграммы из рабочей книги**

Aspose.Slides for PHP via Java предоставляет методы [readWorkbookStream](https://reference.aspose.com/slides/ru/php-java/aspose.slides/chartdata/readworkbookstream/) и [writeWorkbookStream](https://reference.aspose.com/slides/ru/php-java/aspose.slides/chartdata/writeworkbookstream/), позволяющие читать и записывать рабочие книги данных диаграммы (содержащие данные диаграммы, отредактированные с помощью Aspose.Cells). **Примечание** данные диаграммы должны быть организованы одинаково или иметь структуру, аналогичную источнику.  

В этом примере открывается `chart.pptx`, который должен содержать диаграмму как первую фигуру на первом слайде. Он читает встроенную рабочую книгу в массив байтов, очищает существующие серии и категории и записывает ту же рабочую книгу обратно. Изменения остаются в памяти; пример не сохраняет презентацию.

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

Когда вы заменяете встроенную рабочую книгу модифицированной, диаграмма сохраняет свои исходные коллекции серий и категорий. Это несоответствие может привести к ошибке [Chart::validateChartLayout](https://reference.aspose.com/slides/ru/php-java/aspose.slides/chart/validatechartlayout/) с ошибкой выхода индекса за пределы. Очистите существующие серии и категории перед записью обновленной рабочей книги обратно в диаграмму. Этот пример требует `chart.pptx` с диаграммой как первой фигурой на первом слайде. Комментарий указывает место, где должно происходить редактирование рабочей книги; исполняемый пример записывает оригинальную рабочую книгу обратно и проверяет расположение в памяти.

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

Очистка коллекций удаляет устаревшие ссылки на данные перед записью рабочей книги обратно. Восстановите необходимые сопоставления серий и категорий для обновлённой рабочей книги перед использованием диаграммы.

## **Установка ячейки рабочей книги в качестве метки данных диаграммы**

Вы можете использовать текст из ячеек рабочей книги в качестве меток данных диаграммы. Ниже приведены шаги, показывающие, как связать метки в пузырьковой диаграмме с ячейками её рабочей книги данных.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentation/).  
2. Получите доступ к первому слайду по его нулевому индексу.  
3. Добавьте пузырьковую диаграмму с данными по умолчанию.  
4. Получите доступ к сериям диаграммы.  
5. Установите ячейку рабочей книги в качестве метки данных.  
6. Сохраните презентацию.  

В этом примере открывается `chart2.pptx`, который должен содержать как минимум один слайд, и добавляется пузырьковая диаграмма с данными по умолчанию. Он использует ячейки A10:A12 на листе 0 для первых трёх меток в первой серии, включает метки из ячеек и сохраняет результат в `resultchart.pptx`.

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

Метод [ChartDataWorkbook::getWorksheets](https://reference.aspose.com/slides/ru/php-java/aspose.slides/chartdataworkbook/getworksheets/) предоставляет доступ к листам в рабочей книге диаграммы. Этот пример создаёт круговую диаграмму с данными по умолчанию и выводит имя каждого листа в консоль.

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

В этом примере создаётся 3D столбчатая диаграмма с данными по умолчанию и задаются два имени серии, используя разные источники данных. Первое имя задаётся строковым литералом; второе — ячейкой C1 на листе 0. Перечисление [DataSourceType](https://reference.aspose.com/slides/ru/php-java/aspose.slides/datasourcetype/) выбирает источник для каждого имени. Результат сохраняется в `pres.pptx`.

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

Aspose.Slides не поддерживает формат двоичной рабочей книги Excel (.xlsb), который может быть встроен в некоторые диаграммы. Вы можете использовать метод `getEmbeddedWorkbookType` на [ChartData](https://reference.aspose.com/slides/ru/php-java/aspose.slides/chartdata/) совместно с перечислением [WorkbookType](https://reference.aspose.com/slides/ru/php-java/aspose.slides/workbooktype/) для обнаружения неподдерживаемых форматов и пропуска таких диаграмм. Этот пример просматривает фигуры на первом слайде `sample.pptx`, пропускает не‑диаграммные фигуры и выводит диагностическое сообщение для каждой диаграммы со встроенной рабочей книгой .xlsb.

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

Используйте [readWorkbookStream](https://reference.aspose.com/slides/ru/php-java/aspose.slides/chartdata/readworkbookstream/) и [setExternalWorkbook](https://reference.aspose.com/slides/ru/php-java/aspose.slides/chartdata/setexternalworkbook/) для экспорта встроенной рабочей книги диаграммы в файл и связывания диаграммы с этой внешней рабочей книгой.  

В этом примере создаётся круговая диаграмма с данными по умолчанию, её рабочая книга записывается в `externalWorkbook1.xlsx`, и запись файла завершается перед назначением файла в качестве источника данных диаграммы. Презентация со ссылкой сохраняется в `externalWorkbook.pptx`.

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

С помощью метода [setExternalWorkbook](https://reference.aspose.com/slides/ru/php-java/aspose.slides/chartdata/setexternalworkbook/) вы можете назначить внешнюю рабочую книгу диаграмме в качестве источника данных. Этот метод также можно использовать для обновления пути к внешней рабочей книге (если она была перемещена).  

Хотя вы не можете редактировать данные в рабочих книгах, хранящихся в удалённых местах или ресурсах, их всё равно можно использовать в качестве внешнего источника данных. Если указать относительный путь к внешней рабочей книге, он автоматически преобразуется в полный путь.  

Для этого примера требуется `externalWorkbook.xlsx` в рабочем каталоге. Его лист с именем `Sheet1` должен содержать имя серии в B1, имена категорий в A2:A4 и числовые значения в B2:B4. Пример создаёт круговую диаграмму, связывает рабочую книгу и использует [setRange](https://reference.aspose.com/slides/ru/php-java/aspose.slides/chartdata/setrange/) для сопоставления A1:B4 с одной серией и тремя категориями. Результат сохраняется в `Presentation_with_externalWorkbook.pptx`.

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

Параметр `updateChartData` метода [setExternalWorkbook](https://reference.aspose.com/slides/ru/php-java/aspose.slides/chartdata/setexternalworkbook/) управляет тем, будет ли рабочая книга загружена.

* Когда `updateChartData` равно `false`, обновляется только путь к рабочей книге. Данные диаграммы не загружаются и не обновляются из целевой рабочей книги, поэтому рабочая книга может быть недоступна.  
* Когда `updateChartData` равно `true`, данные диаграммы обновляются из целевой рабочей книги.  

В следующем примере назначается placeholder URL с `updateChartData`, установленным в `false`. Он сохраняет значения по умолчанию круговой диаграммы и сохраняет презентацию без загрузки недоступной рабочей книги.

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

### **Получение пути к внешней рабочей книге источника данных диаграммы**

Чтобы определить рабочую книгу, связанную с диаграммой, сначала проверьте, использует ли диаграмма внешний источник данных. Если да, вы можете получить путь к рабочей книге, выполнив следующие шаги.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentation/).  
2. Получите доступ к первому слайду по его нулевому индексу.  
3. Убедитесь, что первая фигура является диаграммой.  
4. Прочитайте тип источника данных диаграммы.  
5. Если источник — внешняя рабочая книга, прочитайте её путь.  

В этом примере открывается `externalWorkbook.pptx`, созданный в предыдущем примере, и проверяется первая фигура на первом слайде. Если это диаграмма, связанная с внешней рабочей книгой, пример выводит [getExternalWorkbookPath](https://reference.aspose.com/slides/ru/php-java/aspose.slides/chartdata/getexternalworkbookpath/) в консоль. Затем сохраняется копия презентации в `Result.pptx`.

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

Вы можете редактировать данные во внешних рабочих книгах так же, как вносите изменения в содержимое внутренних рабочих книг. Когда внешняя рабочая книга не может быть загружена, генерируется исключение.  

Для этого примера требуется `presentation.pptx` с диаграммой как первой фигурой на первом слайде и доступной внешней рабочей книгой. Он задаёт значение ячейки первого элемента данных первой серии равным 100 и сохраняет презентацию в `presentation_out.pptx`. Редактирование значений ячеек может обновлять связанную внешнюю XLSX‑файл, поэтому используйте копию, если необходимо сохранить оригинальную рабочую книгу.

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

Если диаграмма использует внешнюю рабочую книгу, которой нет или она недоступна, Aspose.Slides может восстановить рабочую книгу диаграммы из данных, кэшированных в презентации. Создайте [LoadOptions](https://reference.aspose.com/slides/ru/php-java/aspose.slides/loadoptions/), вызовите [LoadOptions::setSpreadsheetOptions](https://reference.aspose.com/slides/ru/php-java/aspose.slides/loadoptions/setspreadsheetoptions/), и установите [SpreadsheetOptions::setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/ru/php-java/aspose.slides/spreadsheetoptions/setrecoverworkbookfromchartcache/) в `true` перед открытием презентации.  

Следующий пример PHP открывает `presentation.pptx`, первая фигура которого на первом слайде должна быть диаграммой, ссылающейся на недоступную внешнюю рабочую книгу, и получает восстановленные данные через [Chart::getChartData](https://reference.aspose.com/slides/ru/php-java/aspose.slides/chart/getchartdata/) и [ChartData::getChartDataWorkbook](https://reference.aspose.com/slides/ru/php-java/aspose.slides/chartdata/getchartdataworkbook/):

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

        // Читать или изменять восстановленные данные рабочей книги здесь.
    } else {
        echo "The first shape is not a chart.", PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

Если внешняя рабочая книга недоступна и восстановление отключено, Aspose.Slides генерирует исключение. Включайте восстановление только тогда, когда использование кэшированных данных диаграммы допустимо в качестве резерва, так как кэш может не содержать изменений, внесённых во внешнюю рабочую книгу после последнего обновления презентации.

## **FAQ**

**Могу ли я определить, связана ли конкретная диаграмма с внешней или встроенной рабочей книгой?**  
Да. У диаграммы есть [data source type](https://reference.aspose.com/slides/ru/php-java/aspose.slides/chartdata/getdatasourcetype/) и [path to an external workbook](https://reference.aspose.com/slides/ru/php-java/aspose.slides/chartdata/getexternalworkbookpath/). Если источник — внешняя рабочая книга, вы можете прочитать полный путь, чтобы убедиться, что используется внешний файл.

**Поддерживаются ли относительные пути к внешним рабочим книгам и как они хранятся?**  
Да. Если указать относительный путь, он автоматически преобразуется в абсолютный путь. Презентация сохраняет абсолютный путь в файле PPTX, поэтому при перемещении рабочей книги может потребоваться обновить ссылку.

**Могу ли я использовать рабочие книги, расположенные на сетевых ресурсах/общих папках?**  
Да, такие рабочие книги могут использоваться в качестве внешнего источника данных. Однако редактирование удалённых рабочих книг напрямую из Aspose.Slides не поддерживается — они могут использоваться только как источник.

**Перезаписывает ли Aspose.Slides внешний XLSX при сохранении презентации?**  
Презентация сохраняет [link to the external file](https://reference.aspose.com/slides/ru/php-java/aspose.slides/chartdata/getexternalworkbookpath/). Редактирование данных, основанных на ячейках, может также обновлять связанный локальный XLSX‑файл. Используйте копию рабочей книги, если оригинал должен оставаться неизменным.

**Что делать, если внешний файл защищён паролем?**  
Aspose.Slides не принимает пароль при связывании. Обычный подход — удалить защиту заранее или подготовить расшифрованную копию (например, с помощью [Aspose.Cells](https://reference.aspose.com/cells/java/)) и связать её.

**Могут ли несколько диаграмм ссылаться на одну и ту же внешнюю рабочую книгу?**  
Да. Каждая диаграмма хранит свою собственную ссылку. Если они все указывают на один файл, обновление этого файла будет отражено в каждой диаграмме при следующей загрузке данных.