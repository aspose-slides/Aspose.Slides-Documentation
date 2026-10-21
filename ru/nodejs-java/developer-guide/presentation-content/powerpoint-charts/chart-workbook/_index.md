---
title: Управление рабочими книгами диаграмм в презентациях с использованием JavaScript
linktitle: Рабочая книга диаграммы
type: docs
weight: 70
url: /ru/nodejs-java/chart-workbook/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Ознакомьтесь с Aspose.Slides для Node.js через Java: легко управляйте рабочими книгами диаграмм в форматах PowerPoint и OpenDocument, упрощая работу с данными презентаций."
---
## **Обзор**

В этой статье объясняется, как работать с рабочими книгами диаграмм в Aspose.Slides. Она показывает, как читать и записывать данные диаграмм через потоки рабочей книги, использовать ячейки рабочей книги в качестве меток данных диаграммы, получать доступ к коллекциям листов и указывать тип источника данных для значений диаграммы.

Статья также охватывает работу с внешними рабочими книгами в качестве источников данных для диаграмм. Примеры демонстрируют, как создать и назначить внешнюю рабочую книгу, получить путь к внешней рабочей книге, связанной с диаграммой, и редактировать данные диаграммы, когда рабочая книга доступна.

Для ячеек рабочей книги, представляющих отсутствующие данные, см. [Control the Display of Empty Cells](/slides/ru/nodejs-java/chart-series/) для различий между пустой ячейкой и нулём, а также сравнение режимов отображения на линейной диаграмме.

## **Включить данные из скрытых строк и столбцов**

Используйте [Chart.setPlotVisibleCellsOnly](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/setplotvisiblecellsonly/) для управления тем, будет ли диаграмма использовать данные из скрытых строк и столбцов листа. Установите значение `true`, чтобы использовать только видимые ячейки, или `false`, чтобы включить как видимые, так и скрытые ячейки. Эта настройка управляет построением диаграммы; она не скрывает и не отображает строки или столбцы листа.

[Пример презентации](hidden-source-data.pptx) содержит столбчатую диаграмму как первую фигуру на первом слайде. Встроенный лист `Sheet1` имеет исходный диапазон `A1:C4`. Строка 3 и столбец C скрыты, но их ячейки всё равно содержат значения.

| Строка листа | A: Месяц | B: Розница | C: Оптовая (скрытый столбец) |
| --- | --- | --- | --- |
| 2 | Январь | 10 | 30 |
| 3 (скрытая строка) | Февраль | 40 | 60 |
| 4 | Март | 20 | 50 |

Получайте доступ к исходным ячейкам через [ChartData.getChartDataWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/getchartdataworkbook/) и проверяйте их скрытый статус с помощью [ChartDataCell.isHidden](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatacell/ishidden/). Этот метод сообщает о скрытом статусе без его изменения. В этом примере B2 видима, B3 принадлежит скрытой строке, а C2 — скрытому столбцу; вывод будет `false`, `true` и `true` соответственно.

Для данного примера обновите данные диаграммы после изменения настройки построения: сохраните встроенную рабочую книгу с помощью [readWorkbookStream](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/readworkbookstream/) и загрузите её снова через [writeWorkbookStream](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/writeworkbookstream/). При включении всех ячеек также используйте [setRange](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/setrange/) для восстановления полного диапазона, включая скрытую категорию «Февраль». Простая смена флага недостаточна для обновления кэшированных данных и подписей категорий в этом примере. Пример преобразует полученный буфер Node.js в массив байт Java перед передачей его в метод записи.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("hidden-source-data.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const shapeCount = slide.getShapes().size();
    if (shapeCount > 0 && java.instanceOf(slide.getShapes().get_Item(0), "com.aspose.slides.IChart")) {
        const chart = slide.getShapes().get_Item(0);
        const workbook = chart.getChartData().getChartDataWorkbook();
        console.log("B2 hidden: " + workbook.getCell(0, "B2").isHidden());
        console.log("B3 hidden: " + workbook.getCell(0, "B3").isHidden());
        console.log("C2 hidden: " + workbook.getCell(0, "C2").isHidden());

        const workbookBuffer = chart.getChartData().readWorkbookStream();
        const workbookBytes = Array.from(workbookBuffer);
        const workbookData = java.newArray("byte", workbookBytes);
        for (const visibleOnly of [true, false]) {
            chart.setPlotVisibleCellsOnly(visibleOnly);

            // Обновить данные диаграммы из встроенной рабочей книги.
            chart.getChartData().writeWorkbookStream(workbookData);
            if (!visibleOnly) {
                // Восстановить полный исходный диапазон, включая скрытые категории.
                chart.getChartData().setRange("Sheet1!$A$1:$C$4");
            }

            presentation.save("hidden_cells_" + visibleOnly + ".pptx", aspose.slides.SaveFormat.Pptx);
        }
    } else {
        console.log("The first shape is not a chart.");
    }
} finally {
    presentation.dispose();
}
```

Пример сохраняет две версии презентации: одну только с видимыми значениями розницы (10 и 20) и другую со всеми шестью значениями. Ниже показаны два режима построения. Строка 3 и столбец C остаются скрытыми в обеих встроенных рабочих книгах.

| Только видимые ячейки (`true`) | Все ячейки (`false`) |
| --- | --- |
| ![Only visible cells: Retail values 10 and 20 for January and March.](hidden_cells_True.png) | ![All cells: Retail and Wholesale values for January, February, and March.](hidden_cells_False.png) |

Скрытая ячейка, содержащая значение, отличается от пустой ячейки. [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/setdisplayblanksas/) управляет тем, как отображаются отсутствующие значения; он не включает и не исключает скрытые исходные данные. См. [Control the Display of Empty Cells](/slides/ru/nodejs-java/chart-series/#control-the-display-of-empty-cells) для примера.

## **Получить диапазон данных диаграммы**

Перед обновлением данных рабочей книги в существующей презентации проверьте исходные диапазоны, чтобы определить, какие ячейки листа использует каждая диаграмма. Метод [ChartData.getRange](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/getrange/) возвращает текущий диапазон данных в виде формулы, квалифицированной листом, например `Sheet1!$A$1:$D$5`. Здесь `Sheet1` — имя листа, `!` — разделитель, а `$A$1:$D$5` — диапазон ячеек от A1 до D5 включительно. Знаки доллара указывают на абсолютные ссылки на строки и столбцы.

Метод читает текущий диапазон без изменения диаграммы или её рабочей книги. Если диаграмма не использует рабочую книгу в качестве источника данных, генерируется `InvalidOperationException`. Подробнее см. в [ChartData API Reference](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/).

В этом примере открывается презентация и проверяются фигуры на каждом слайде на предмет диаграмм. Для каждой диаграммы выводится её имя и диапазон источника. Если диаграмма не использует рабочую книгу, выводится сообщение, после чего обработка продолжается со следующей диаграммой.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    for (let slideIndex = 0; slideIndex < presentation.getSlides().size(); slideIndex++) {
        const slide = presentation.getSlides().get_Item(slideIndex);
        for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
            const shape = slide.getShapes().get_Item(shapeIndex);
            if (java.instanceOf(shape, "com.aspose.slides.IChart")) {
                const chart = shape;
                try {
                    const range = chart.getChartData().getRange();
                    console.log(chart.getName() + ": " + range);
                } catch (exception) {
                    if (exception.cause && java.instanceOf(exception.cause, "com.aspose.slides.exceptions.InvalidOperationException")) {
                        console.log(chart.getName() + ": The chart does not use a workbook as its data source.");
                    } else {
                        console.log(chart.getName() + ": Could not retrieve the data range: " + exception.message);
                    }
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

## **Чтение и запись данных диаграммы из рабочей книги**

Aspose.Slides for Node.js via Java предоставляет методы [readWorkbookStream](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/readworkbookstream/) и [writeWorkbookStream](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/writeworkbookstream/), позволяющие считывать и записывать рабочие книги данных диаграмм (содержащие данные, отредактированные в Aspose.Cells). **Note** что данные диаграммы должны быть организованы тем же способом или иметь структуру, похожую на исходную.

В этом примере используется презентация с диаграммой в качестве первой фигуры на первом слайде. Встроенная рабочая книга считывается в массив байт, очищаются существующие серии и категории, после чего та же рабочая книга записывается обратно. Изменения остаются в памяти; презентация не сохраняется.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("chart.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const shapeCount = slide.getShapes().size();
    if (shapeCount > 0 && java.instanceOf(slide.getShapes().get_Item(0), "com.aspose.slides.IChart")) {
        const chart = slide.getShapes().get_Item(0);
        const chartData = chart.getChartData();
        const workbookBuffer = chartData.readWorkbookStream();
        const workbookBytes = Array.from(workbookBuffer);
        const workbookData = java.newArray("byte", workbookBytes);

        chartData.getSeries().clear();
        chartData.getCategories().clear();

        chartData.writeWorkbookStream(workbookData);
    } else {
        console.log("The first shape is not a chart.");
    }
} finally {
    presentation.dispose();
}
```

### **Проверка макета диаграммы после изменения рабочей книги**

При замене встроенной рабочей книги её модифицированной версией диаграмма сохраняет исходные коллекции серий и категорий. Такое несоответствие может привести к ошибке [Chart.validateChartLayout](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/validatechartlayout/) с сообщением о выходе индекса за пределы. Очистите существующие серии и категории перед записью обновлённой рабочей книги обратно в диаграмму. В примере используется диаграмма, которая является первой фигурой на первом слайде. Комментарий указывает место, где может происходить редактирование рабочей книги; runnable‑пример записывает исходную рабочую книгу обратно и проверяет макет в памяти.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("chart.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const shapeCount = slide.getShapes().size();
    if (shapeCount > 0 && java.instanceOf(slide.getShapes().get_Item(0), "com.aspose.slides.IChart")) {
        const chart = slide.getShapes().get_Item(0);
        const chartData = chart.getChartData();
        const workbookBuffer = chartData.readWorkbookStream();
        const workbookBytes = Array.from(workbookBuffer);
        const workbookData = java.newArray("byte", workbookBytes);

        // Измените байты рабочей книги здесь, например, используя Aspose.Cells.

        chartData.getSeries().clear();
        chartData.getCategories().clear();

        chartData.writeWorkbookStream(workbookData);
        chart.validateChartLayout();
    } else {
        console.log("The first shape is not a chart.");
    }
} finally {
    presentation.dispose();
}
```

Очистка коллекций удаляет устаревшие ссылки перед записью рабочей книги. Восстановите необходимые сопоставления серий и категорий для обновлённой рабочей книги перед использованием диаграммы.

## **Установка пользовательских числовых форматов для ячеек рабочей книги**

Используйте [ChartDataCell.setCustomNumberFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatacell/setcustomnumberformat/) для управления отображением числовых значений в встроенной рабочей книге диаграммы. Например, отчёт может требовать вывод коэффициента конверсии в виде процента с четырьмя знаками после запятой и коэффициента с пятью знаками после запятой. Оставьте оба значения числовыми, чтобы они оставались доступными для вычислений и построения диаграмм.

Числовой формат изменяет только отображение, а не сохранённое значение. Формат `0.0000%` отображает `0.125` как `12.5000%`; он не заменяет сохранённое число на `12.5`. Аналогично, `0.00000` отображает `0.1234567` как `0.12346`, не округляя сохранённое значение. Если пользовательский формат пустой строкой (`""`), используется формат, возвращённый [getPresetNumberFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatacell/getpresetnumberformat/).

В следующем примере создаётся столбчатая диаграмма и получаются её ячейки через [getChartDataWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/getchartdataworkbook/). На листе 0 ячейка B2 содержит коэффициент конверсии, а C2 — коэффициент. Обе ячейки поставляют значения диаграммы. Пример также включает подписи значений, связанные с исходными форматами.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    presentation.getSlideSize().setSize(720, 270, aspose.slides.SlideSizeScaleType.DoNotScale);
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 20, 620, 210);
    chart.setTitle(false);

    chart.getAxes().getVerticalAxis().setNumberFormatLinkedToSource(false);
    chart.getAxes().getVerticalAxis().setNumberFormat("0.00");
    chart.getAxes().getVerticalAxis().setAutomaticMinValue(false);
    chart.getAxes().getVerticalAxis().setMinValue(0);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    const workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    const categoryCell = workbook.getCell(0, "A2", "Sample");
    chart.getChartData().getCategories().add(categoryCell);

    const percentageCell = workbook.getCell(0, "B2", 0.125);
    percentageCell.setCustomNumberFormat("0.0000%");
    const percentageName = workbook.getCell(0, "B1", "Conversion rate");
    const percentageSeries = chart.getChartData().getSeries().add(percentageName, chart.getType());
    percentageSeries.getDataPoints().addDataPointForBarSeries(percentageCell);

    const precisionCell = workbook.getCell(0, "C2", 0.1234567);
    precisionCell.setCustomNumberFormat("0.00000");
    const precisionName = workbook.getCell(0, "C1", "Coefficient");
    const precisionSeries = chart.getChartData().getSeries().add(precisionName, chart.getType());
    precisionSeries.getDataPoints().addDataPointForBarSeries(precisionCell);

    for (let seriesIndex = 0; seriesIndex < chart.getChartData().getSeries().size(); seriesIndex++) {
        const series = chart.getChartData().getSeries().get_Item(seriesIndex);
        const labelFormat = series.getDataPoints().get_Item(0).getLabel().getDataLabelFormat();
        labelFormat.setShowValue(true);
        labelFormat.setNumberFormatLinkedToSource(true);
    }

    presentation.save("CustomCellFormats.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Форматы ячеек рабочей книги независимы от форматов, задаваемых непосредственно на осях диаграммы или подпицах данных. В этом примере каждая подпись отображает значение своей исходной ячейки, потому что [setShowValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabelformat/setshowvalue/) установлено в `true`, а [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabelformat/setnumberformatlinkedtosource/) — в `true`. После сохранения и повторного открытия презентации подписи показывают `12.5000%` и `0.12346`, как показано ниже. Вертикальная ось использует собственный числовой формат, заданный через [setNumberFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setnumberformat/) как `0.00`, а [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setnumberformatlinkedtosource/) установлено в `false`.

Чтобы оформить подпись независимо, снимите флаг ссылки на источник, установив его в `false`, и задайте формат через [setNumberFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabelformat/setnumberformat/). Это не меняет формат ячейки рабочей книги. Например, независимый формат подписи `0.00` отображает первое значение как `0.13`, в то время как B2 по‑прежнему показывает `12.5000%`. См. [Chart Data Labels](/slides/ru/nodejs-java/chart-data-label/#set-percentage-sign-with-chart-data-labels) для прямого форматирования подписи.

Изображение ниже было получено из сохранённой презентации после её повторного открытия:

![Column chart with source-linked labels showing 12.5000% and 0.12346 and an independently formatted numeric axis.](custom-cell-formats.png)

## **Установить ячейку рабочей книги в качестве метки данных диаграммы**

Текст из ячеек рабочей книги можно использовать в качестве меток данных диаграммы.

В данном примере добавляется пузырёчная диаграмма с данными по умолчанию на первый слайд существующей презентации. Используются ячейки A10:A12 листа 0 для первых трёх меток первой серии, включаются подписи из ячеек, и презентация сохраняется.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("chart2.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.Bubble, 50, 50, 600, 400, true);
    const series = chart.getChartData().getSeries().get_Item(0);
    const workbook = chart.getChartData().getChartDataWorkbook();

    series.getLabels().getDefaultDataLabelFormat().setShowLabelValueFromCell(true);
    series.getLabels().get_Item(0).setValueFromCell(workbook.getCell(0, "A10", "Label 0 cell value"));
    series.getLabels().get_Item(1).setValueFromCell(workbook.getCell(0, "A11", "Label 1 cell value"));
    series.getLabels().get_Item(2).setValueFromCell(workbook.getCell(0, "A12", "Label 2 cell value"));

    presentation.save("resultchart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Управление листами**

Метод [ChartDataWorkbook.getWorksheets](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdataworkbook/getworksheets/) предоставляет доступ к листам в рабочей книге диаграммы. В примере создаётся круговая диаграмма с данными по умолчанию и выводятся имена всех листов в консоль.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.Pie, 50, 50, 400, 500);
    const workbook = chart.getChartData().getChartDataWorkbook();

    for (let i = 0; i < workbook.getWorksheets().size(); i++) {
        console.log(workbook.getWorksheets().get_Item(i).getName());
    }
} finally {
    presentation.dispose();
}
```

## **Указание типа источника данных**

В этом примере создаётся 3‑мерная столбчатая диаграмма с данными по умолчанию и задаются две подписи серий, использующие разные источники данных. Первая подпись задаётся строковым литералом; вторая — ячейкой C1 листа 0. Перечисление [DataSourceType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datasourcetype/) выбирает источник для каждой подписи. Пример сохраняет презентацию с обновлёнными названиями серий.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.Column3D, 50, 50, 600, 400, true);
    const literalName = chart.getChartData().getSeries().get_Item(0).getName();

    literalName.setDataSourceType(aspose.slides.DataSourceType.StringLiterals);
    literalName.setData("LiteralString");

    const cellName = chart.getChartData().getSeries().get_Item(1).getName();
    const nameCell = chart.getChartData().getChartDataWorkbook().getCell(0, "C1", "NewCell");
    cellName.setDataSourceType(aspose.slides.DataSourceType.Worksheet);
    cellName.setData(nameCell);

    presentation.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Обнаружение неподдерживаемых форматов встроенных рабочих книг**

Aspose.Slides не поддерживает формат бинарных книг Excel (.xlsb), которые могут быть встроены в некоторые диаграммы. С помощью метода `getEmbeddedWorkbookType` класса [ChartData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/) и перечисления [WorkbookType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/workbooktype/) можно определить неподдерживаемые форматы и пропустить такие диаграммы. Пример проверяет фигуры на первом слайде существующей презентации, пропускает не‑диаграммы и выводит диагностическое сообщение для каждой диаграммы со встроенной книгой .xlsb.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
        const shape = slide.getShapes().get_Item(shapeIndex);
        if (!(java.instanceOf(shape, "com.aspose.slides.IChart"))) {
            continue;
        }

        const chart = shape;
        const chartData = chart.getChartData();
        const isInternalWorkbook = chartData.getDataSourceType() == aspose.slides.ChartDataSourceType.InternalWorkbook;
        const isBinaryMacro = chartData.getEmbeddedWorkbookType() == aspose.slides.WorkbookType.WorkbookBinaryMacro;

        if (isInternalWorkbook && isBinaryMacro) {
            console.log("Skipping a chart with an unsupported .xlsb workbook.");
            continue;
        }

        // Читать или изменять поддерживаемые данные рабочей книги диаграммы здесь.
    }
} finally {
    presentation.dispose();
}
```

## **Внешняя рабочая книга**

Aspose.Slides поддерживает использование внешних рабочих книг в качестве источника данных для диаграмм.

### **Создание внешней рабочей книги**

Используйте [readWorkbookStream](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/readworkbookstream/) и [setExternalWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/setexternalworkbook/) для экспорта встроенной рабочей книги диаграммы в файл и привязки диаграммы к этой внешней книге.

В примере создаётся круговая диаграмма с данными по умолчанию и экспортируется её рабочая книга. Сначала завершается запись файла, затем диаграмма связывается с внешней книгой в качестве источника данных, после чего сохраняется связанная презентация.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const path = require("path");
const fileSystem = require("fs");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.Pie, 50, 50, 400, 600);
    const workbookPath = path.resolve("externalWorkbook1.xlsx");
    const workbookData = chart.getChartData().readWorkbookStream();
    try {
        fileSystem.writeFileSync(workbookPath, Buffer.from(workbookData));
        chart.getChartData().setExternalWorkbook(workbookPath);
        
        presentation.save("externalWorkbook.pptx", aspose.slides.SaveFormat.Pptx);
    } catch (exception) {
        console.log("Could not write the external workbook: " + exception.message);
    }
} finally {
    presentation.dispose();
}
```

### **Установка внешней рабочей книги**

С помощью метода [setExternalWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/setexternalworkbook/) можно назначить внешнюю рабочую книгу диаграмме в качестве источника данных. Этот метод также позволяет обновить путь к внешней книге (если она была перемещена).

Хотя редактировать данные в книгах, хранящихся в удалённых местах или ресурсах, нельзя, такие книги могут использоваться как внешний источник данных. При указании относительного пути к внешней книге он автоматически преобразуется в абсолютный.

В примере используется внешняя рабочая книга, лист которой `Sheet1` содержит название серии в B1, названия категорий в A2:A4 и числовые значения в B2:B4. Пример создаёт круговую диаграмму, привязывает книгу и с помощью [setRange](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/setrange/) сопоставляет диапазон A1:B4 одной серии и трём категориям. Презентация сохраняется с привязанной диаграммой.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const path = require("path");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.Pie, 50, 50, 400, 600, true);
    const chartData = chart.getChartData();
    const workbookPath = path.resolve("externalWorkbook.xlsx");

    chartData.setExternalWorkbook(workbookPath);
    chartData.setRange("Sheet1!$A$1:$B$4");

    presentation.save("Presentation_with_externalWorkbook.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Параметр `updateChartData` метода [setExternalWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/setexternalworkbook/) управляет загрузкой рабочей книги.

* При `updateChartData` = `false` обновляется только путь к книге. Данные диаграммы не загружаются и не обновляются из целевой книги, поэтому книга может быть недоступна.
* При `updateChartData` = `true` данные диаграммы обновляются из целевой книги.

В следующем примере задаётся заполнитель URL с `updateChartData` = `false`. Диаграмма сохраняет данные по умолчанию, а презентация сохраняется без попытки загрузки недоступной книги.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.Pie, 50, 50, 400, 600, true);
    chart.getChartData().setExternalWorkbook("https://example.com/unavailable-workbook.xlsx", false);

    presentation.save("SetExternalWorkbookWithUpdateChartData.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Получить путь к внешнему источнику данных рабочей книги диаграммы**

Чтобы определить, к какой рабочей книге привязана диаграмма, проверьте, использует ли она внешний источник данных, и получите её путь.

Пример проверяет первую фигуру на первом слайде презентации со связанной внешней книгой. Если это диаграмма, привязанная к внешней книге, пример выводит [getExternalWorkbookPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/getexternalworkbookpath/) в консоль, после чего сохраняет копию презентации.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("externalWorkbook.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    if (slide.getShapes().size() > 0 && java.instanceOf(slide.getShapes().get_Item(0), "com.aspose.slides.IChart")) {
        const chart = slide.getShapes().get_Item(0);
        const chartData = chart.getChartData();
        if (chartData.getDataSourceType() == aspose.slides.ChartDataSourceType.ExternalWorkbook) {
            console.log(chartData.getExternalWorkbookPath());
        } else {
            console.log("The chart does not use an external workbook.");
        }
    } else {
        console.log("The first shape is not a chart.");
    }

    presentation.save("Result.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Редактирование данных диаграммы**

Данные внешних рабочих книг можно изменять так же, как и внутренние. Если внешняя книга не может быть загружена, будет выброшено исключение.

В примере используется диаграмма, первая фигура на первом слайде, привязанная к доступной внешней книге. Значение первого пункта первой серии задаётся = 100, презентация сохраняется. Изменение значений ячеек может обновить связанный внешний файл XLSX, поэтому при необходимости сохранения оригинала используйте копию книги.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const shapeCount = slide.getShapes().size();
    if (shapeCount > 0 && java.instanceOf(slide.getShapes().get_Item(0), "com.aspose.slides.IChart")) {
        const chart = slide.getShapes().get_Item(0);
        const series = chart.getChartData().getSeries();
        if (series.size() > 0 && series.get_Item(0).getDataPoints().size() > 0) {
            const valueCell = series.get_Item(0).getDataPoints().get_Item(0).getValue().getAsCell();
            if (valueCell != null) {
                valueCell.setValue(100);
                presentation.save("presentation_out.pptx", aspose.slides.SaveFormat.Pptx);
            } else {
                console.log("The first data point is not linked to a workbook cell.");
            }
        } else {
            console.log("The chart has no data points to edit.");
        }
    } else {
        console.log("The first shape is not a chart.");
    }
} finally {
    presentation.dispose();
}
```

### **Восстановление рабочей книги из кэша диаграммы**

Если диаграмма использует внешнюю рабочую книгу, которая отсутствует или недоступна, Aspose.Slides может восстановить рабочую книгу диаграммы из кэшированных данных презентации. Создайте [LoadOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/loadoptions/), вызовите [LoadOptions.setSpreadsheetOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/loadoptions/setspreadsheetoptions/) и установите [SpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/nodejs-java/aspose.slides/spreadsheetoptions/setrecoverworkbookfromchartcache/) в `true` перед открытием презентации.

Следующий пример JavaScript восстанавливает данные рабочей книги для диаграммы, первая фигура на первом слайде, которая ссылается на недоступную внешнюю книгу. Доступ к восстановленным данным осуществляется через [Chart.getChartData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/getchartdata/) и [ChartData.getChartDataWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/getchartdataworkbook/):

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const spreadsheetOptions = new aspose.slides.SpreadsheetOptions();
spreadsheetOptions.setRecoverWorkbookFromChartCache(true);

const loadOptions = new aspose.slides.LoadOptions();
loadOptions.setSpreadsheetOptions(spreadsheetOptions);

const presentation = new aspose.slides.Presentation("presentation.pptx", loadOptions);
try {
    const slide = presentation.getSlides().get_Item(0);

    const shapeCount = slide.getShapes().size();
    if (shapeCount > 0 && java.instanceOf(slide.getShapes().get_Item(0), "com.aspose.slides.IChart")) {
        const chart = slide.getShapes().get_Item(0);
        const recoveredWorkbook = chart.getChartData().getChartDataWorkbook();

        // Читать или изменять восстановленные данные рабочей книги здесь.
    } else {
        console.log("The first shape is not a chart.");
    }
} finally {
    presentation.dispose();
}
```

Если внешняя рабочая книга недоступна и восстановление отключено, Aspose.Slides генерирует исключение. Включайте восстановление только тогда, когда использование кэшированных данных диаграммы является приемлемым вариантом, так как кэш может не содержать изменений, внесённых во внешнюю книгу после последнего обновления презентации.

## **FAQ**

**Можно ли определить, привязана ли конкретная диаграмма к внешней или встроенной рабочей книге?**

Да. У диаграммы есть [data source type](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/getdatasourcetype/) и [path to an external workbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/getexternalworkbookpath/); если источник — внешняя книга, можно прочитать полный путь, чтобы убедиться, что используется внешний файл.

**Поддерживаются ли относительные пути к внешним рабочим книгам и как они хранятся?**

Да. При указании относительного пути он автоматически преобразуется в абсолютный. Презентация хранит абсолютный путь в файле PPTX, поэтому при перемещении книги может потребоваться обновить ссылку.

**Можно ли использовать рабочие книги, расположенные на сетевых ресурсах/дисках?**

Да, такие книги можно использовать как внешний источник данных. Однако редактирование удалённых книг напрямую из Aspose.Slides не поддерживается — они могут использоваться только как источник.

**Перезаписывает ли Aspose.Slides внешний XLSX при сохранении презентации?**

Презентация хранит [link to the external file](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/getexternalworkbookpath/). Изменение данных, основанных на ячейках, может также обновить связанный локальный файл XLSX. Используйте копию рабочей книги, если оригинал должен оставаться неизменным.

**Что делать, если внешний файл защищён паролем?**

Aspose.Slides не принимает пароль при привязке. Обычно пароль снимают заранее или готовят расшифрованную копию (например, с помощью [Aspose.Cells](https://reference.aspose.com/cells/java/)) и привязывают к ней.

**Могут ли несколько диаграмм ссылаться на одну и ту же внешнюю рабочую книгу?**

Да. Каждая диаграмма хранит свою ссылку. Если все они указывают на один и тот же файл, обновление этого файла отразится в каждой диаграмме при следующей загрузке данных.