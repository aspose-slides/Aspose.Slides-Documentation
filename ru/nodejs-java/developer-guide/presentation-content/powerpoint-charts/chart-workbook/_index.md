---
title: Управление книгами-таблицей диаграмм в презентациях с помощью JavaScript
linktitle: Книга-таблица диаграммы
type: docs
weight: 70
url: /ru/nodejs-java/chart-workbook/
keywords:
- книга-таблица диаграммы
- данные диаграммы
- ячейка книги-таблицы
- метка данных
- лист
- источник данных
- внешняя книга-таблица
- внешние данные
- кеш диаграммы
- восстановление книги-таблицы
- PowerPoint
- презентация
- Node.js
- JavaScript
- Aspose.Slides
description: "Откройте для себя Aspose.Slides для Node.js через Java: легко управляйте книгами-таблицами диаграмм в форматах PowerPoint и OpenDocument, упрощая работу с данными вашей презентации."
---
## **Обзор**

В этой статье объясняется, как работать с книгу‑таблицами диаграмм в Aspose.Slides. Описывается, как читать и записывать данные диаграммы через потоки книги‑таблиц, использовать ячейки книги‑таблиц в качестве меток данных диаграммы, получать доступ к коллекциям листов и указывать тип источника данных для значений диаграммы.

Также рассматривается работа с внешними книгами‑таблицами в качестве источников данных диаграмм. Примеры демонстрируют, как создать и назначить внешнюю книгу‑таблицу, получить путь к внешней книге‑таблице, связанной с диаграммой, и редактировать данные диаграммы, когда книга‑таблица доступна.

Для ячеек книги‑таблицы, представляющих отсутствующие данные, см. [Управление отображением пустых ячеек](/slides/ru/nodejs-java/chart-series/) — различия между пустой ячейкой и нулём, а также сравнение режимов отображения на линейной диаграмме.

## **Включать данные из скрытых строк и столбцов**

Используйте [Chart.setPlotVisibleCellsOnly](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/setplotvisiblecellsonly/) для контроля того, будет ли диаграмма отображать данные из скрытых строк и столбцов листа. Установите `true`, чтобы отображать только видимые ячейки, или `false`, чтобы включать и видимые, и скрытые ячейки. Эта настройка управляет построением диаграммы; она не скрывает и не делает видимыми строки или столбцы листа.

[Пример презентации](hidden-source-data.pptx) содержит столбчатую диаграмму в виде первой фигуры на первом слайде. Встроенный лист `Sheet1` имеет диапазон источника `A1:C4`. Строка 3 и столбец C скрыты, но их ячейки всё‑таки содержат значения.

| Строка листа | A: Месяц | B: Розница | C: Оптовая (скрытый столбец) |
| --- | --- | --- | --- |
| 2 | Январь | 10 | 30 |
| 3 (скрытая строка) | Февраль | 40 | 60 |
| 4 | Март | 20 | 50 |

Получайте доступ к ячейкам‑источникам через [ChartData.getChartDataWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/getchartdataworkbook/) и проверяйте их статус с помощью [ChartDataCell.isHidden](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatacell/ishidden/). Этот метод сообщает о скрытом статусе без его изменения. В данном файле B2 видима, B3 принадлежит скрытой строке, а C2 — скрытому столбцу; пример выводит `false`, `true` и `true` соответственно.

Для этого примера обновите данные диаграммы после изменения настройки построения: сохраните встроенную книгу‑таблицу с помощью [readWorkbookStream](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/readworkbookstream/) и загрузите её снова через [writeWorkbookStream](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/writeworkbookstream/). При включении всех ячеек также используйте [setRange](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/setrange/) для восстановления полного диапазона, включая скрытую категорию «Февраль». Простое изменение флага недостаточно для обновления кэшированных данных и меток категорий в этом примере. Пример конвертирует полученный буфер Node.js в массив байтов Java перед передачей в метод записи.

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

            // Обновить данные диаграммы из встроенной книги‑таблицы.
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

Пример сохраняет две версии презентации: одну только с видимыми значениями розницы (10 и 20), а другую со всеми шестью значениями. Ниже изображены два режима построения. Строка 3 и столбец C остаются скрытыми в обеих встроенных книгах‑таблицах.

| Только видимые ячейки (`true`) | Все ячейки (`false`) |
| --- | --- |
| ![Только видимые ячейки: значения розницы 10 и 20 для января и марта.](hidden_cells_True.png) | ![Все ячейки: значения розницы и оптовой продажи для января, февраля и марта.](hidden_cells_False.png) |

Скрытая ячейка, содержащая значение, отличается от пустой ячейки. [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/setdisplayblanksas/) управляет тем, как отображаются отсутствующие значения; он не включает и не исключает скрытые исходные данные. См. [Управление отображением пустых ячеек](/slides/ru/nodejs-java/chart-series/#control-the-display-of-empty-cells) для примера.

## **Получение диапазона данных диаграммы**

Перед обновлением данных книги‑таблицы в существующей презентации проверьте исходные диапазоны, чтобы определить, какие ячейки листа использует каждая диаграмма. Метод [ChartData.getRange](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/getrange/) возвращает текущий диапазон данных в виде формулы, квалифицированной листом, например `Sheet1!$A$1:$D$5`. Здесь `Sheet1` — имя листа, `!` отделяет его от диапазона ячеек, а `$A$1:$D$5` указывает ячейки от A1 до D5 включительно. Знаки `$` обозначают абсолютные ссылки на строки и столбцы.

Метод читает текущий диапазон без изменения диаграммы или её книги‑таблицы. Если диаграмма не использует книгу‑таблицу в качестве источника данных, выбрасывается `InvalidOperationException`. Дополнительную информацию см. в [справочнике API ChartData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/).

В этом примере открывается презентация и проверяются фигуры на каждом слайде на предмет диаграмм. Для каждой диаграммы выводятся её имя и исходный диапазон. Если диаграмма не использует книгу‑таблицу, выводится сообщение, и обработка продолжается со следующей диаграммой.

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

## **Чтение и запись данных диаграммы из книги‑таблицы**

Aspose.Slides for Node.js via Java предоставляет методы [readWorkbookStream](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/readworkbookstream/) и [writeWorkbookStream](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/writeworkbookstream/), позволяющие читать и записывать книги‑таблицы данных диаграмм (содержащие данные, отредактированные с помощью Aspose.Cells). **Примечание**: данные диаграммы должны быть организованы тем же образом или иметь структуру, аналогичную исходной.

В примере используется презентация с диаграммой в виде первой фигуры на первом слайде. Встроенная книга‑таблица считывается в массив байтов, очищаются существующие серии и категории, после чего та же книга‑таблица записывается обратно. Изменения остаются в памяти; пример не сохраняет презентацию.

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

### **Проверка расположения диаграммы после изменения книги‑таблицы**

Когда вы заменяете встроенную книгу‑таблицу изменённой, диаграмма сохраняет свои оригинальные коллекции серий и категорий. Такое несоответствие может привести к ошибке [Chart.validateChartLayout](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/validatechartlayout/) с сообщением о выходе индекса за пределы. Очистите существующие серии и категории перед записью обновлённой книги‑таблицы обратно в диаграмму. Пример использует диаграмму, являющуюся первой фигурой на первом слайде. Комментарий отмечает место, где должно происходить редактирование книги‑таблицы; исполняемый пример записывает оригинальную книгу‑таблицу обратно и проверяет расположение в памяти.

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

        // Измените байты книги‑таблицы здесь, например, используя Aspose.Cells.

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

Очистка коллекций удаляет устаревшие ссылки перед записью книги‑таблицы. Перед использованием диаграммы восстановите необходимые сопоставления серий и категорий для обновлённой книги‑таблицы.

## **Выбор способа хранения меток категорий**

Вызовите [ChartCategoryCollection.setUseCells](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartcategorycollection/setusecells/) у пустой коллекции категорий перед добавлением меток. Используйте ячейки листа для меток, которые ссылаются на данные книги‑таблицы или образуют иерархию (например, кварталы, сгруппированные по годам). Для одноуровневых меток без ссылок на ячейки используйте строковые литералы. Эта настройка применяется только к категориям. Оба диаграмма в примере используют ячейки листа для числовых значений серий.

Пример создаёт две столбчатые диаграммы и выводит режим хранения, за которым следует `Q1 Q2 Q3 Q4` для каждой. Для меток, основанных на листе, [ChartCategory.getAsCell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartcategory/getascell/) возвращает базовую ячейку, а [ChartDataCell.getValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatacell/getvalue/) — её метку. Для литеральных меток читается строка напрямую через [ChartCategory.getValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartcategory/getvalue/). Пример сохраняет обе диаграммы в `category-labels.pptx`.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const shapes = presentation.getSlides().get_Item(0).getShapes();

    for (const useCells of [true, false]) {
        const x = useCells ? 20 : 360;
        const chart = shapes.addChart(aspose.slides.ChartType.ClusteredColumn, x, 20, 320, 250);
        const data = chart.getChartData();
        data.getSeries().clear();
        const categories = data.getCategories();
        categories.clear();
        categories.setUseCells(useCells);

        const workbook = data.getChartDataWorkbook();
        const seriesName = workbook.getCell(0, 0, 1, "Sales");
        const series = data.getSeries().add(seriesName, chart.getType());
        for (let row = 1; row <= 4; row++) {
            const label = "Q" + row;
            if (useCells) {
                const labelCell = workbook.getCell(0, row, 0, label);
                categories.add(labelCell);
            } else {
                categories.add(label);
            }

            const valueCell = workbook.getCell(0, row, 1, row * 10);
            series.getDataPoints().addDataPointForBarSeries(valueCell);
        }

        const storedInCells = categories.getUseCells();
        const labels = [];
        for (let i = 0; i < categories.size(); i++) {
            const category = categories.get_Item(i);
            labels.push(storedInCells ? category.getAsCell().getValue() : category.getValue());
        }
        console.log("UseCells = " + storedInCells + ": " + labels.join(" "));
    }

    presentation.save("category-labels.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Установка пользовательских числовых форматов для ячеек книги‑таблицы**

Используйте [ChartDataCell.setCustomNumberFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatacell/setcustomnumberformat/) для контроля того, как числовые значения отображаются в встроенной книге‑таблице диаграммы. Например, в отчёте может потребоваться показать коэффициент конверсии в процентах с четырьмя знаками после запятой и коэффициент со старой точкой с пятью знаками. Оставьте оба значения числовыми, чтобы они оставались доступными для вычислений и построения диаграмм.

Числовой формат меняет только отображение, а не сохраняемое значение. Формат `0.0000%` отображает `0.125` как `12.5000%`, но не заменяет хранимое число на `12.5`. Аналогично, `0.00000` отображает `0.1234567` как `0.12346`, не округляя сохранённое значение. Если пользовательский формат — пустая строка (`""`), используется формат, возвращаемый [getPresetNumberFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatacell/getpresetnumberformat/).

В следующем примере создаётся столбчатая диаграмма и получаются её ячейки через [getChartDataWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/getchartdataworkbook/). На листе 0 ячейка B2 содержит коэффициент конверсии, а C2 — коэффициент. Обе ячейки поставляют значения диаграммы. Пример также включает метки значений, связанные с исходными форматами.

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

Форматы ячеек книги‑таблицы отличаются от форматов, задаваемых напрямую на осях диаграммы или метках данных. В этом примере каждая метка отображает значение своей исходной ячейки, потому что [setShowValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabelformat/setshowvalue/) установлен в `true`, а также следует исходному числовому формату, потому что [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabelformat/setnumberformatlinkedtosource/) установлен в `true`. После сохранения и повторного открытия презентации метки показывают `12.5000%` и `0.12346`, как показано ниже. Вертикальная ось использует собственный числовой формат, задаваемый через [setNumberFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setnumberformat/) как `0.00`, при этом [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setnumberformatlinkedtosource/) установлен в `false`.

Чтобы отформатировать метку данных независимо, установите её флаг ссылок на источник в `false` и задайте формат через [setNumberFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabelformat/setnumberformat/). Это не изменит формат ячейки книги‑таблицы. Например, независимый формат метки `0.00` выводит первое значение как `0.13`, тогда как B2 остаётся `12.5000%`. См. [Подписи данных диаграммы](/slides/ru/nodejs-java/chart-data-label/#set-percentage-sign-with-chart-data-labels) для прямого форматирования меток.

Изображение ниже было получено из сохранённой презентации после её повторного открытия:

![Столбчатая диаграмма с метками, связанными с источником, показывающая 12.5000% и 0.12346, а также независимо отформатированной числовой осью.](custom-cell-formats.png)

## **Использование ячейки книги‑таблицы в качестве подписи данных диаграммы**

Текст из ячеек книги‑таблицы можно использовать в качестве подписей данных диаграммы.

В этом примере к первой слайде существующей презентации добавляется пузырьковая диаграмма с данными по умолчанию. Для первых трёх меток в первой серии используются ячейки A10:A12 листа 0, включаются подписи из ячеек, и презентация сохраняется.

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

Метод [ChartDataWorkbook.getWorksheets](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdataworkbook/getworksheets/) предоставляет доступ к листам книги‑таблицы диаграммы. В этом примере создаётся круговая диаграмма с данными по умолчанию и выводятся имена всех листов в консоль.

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

Значения точек серии также могут быть сохранены непосредственно как числовые литералы. См. [Задание значений серии с использованием числовых литералов](/slides/ru/nodejs-java/chart-series/#set-series-values-using-numeric-literals) для полного примера, показывающего их сохранение и чтение. Тип источника точек отделён от внутренней или внешней конфигурации книги‑таблицы диаграммы; использование числовых литералов само по себе не удаляет встроенную книгу‑таблицу.

В примере создаётся трёхмерная столбчатая диаграмма с данными по умолчанию и задаются два имени серии, использующих разные источники данных. Первое имя задаётся строковым литералом; второе — ячейкой C1 листа 0. Перечисление [DataSourceType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datasourcetype/) выбирает источник для каждого имени. Пример сохраняет презентацию с обновлёнными именами серий.

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

## **Обнаружение неподдерживаемых форматов встроенных книг‑таблиц**

Aspose.Slides не поддерживает формат бинарных книг Excel (.xlsb), которые могут быть встроены в некоторые диаграммы. Вы можете использовать метод `getEmbeddedWorkbookType` класса [ChartData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/) вместе с перечислением [WorkbookType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/workbooktype/) для выявления неподдерживаемых форматов и пропуска соответствующих диаграмм. В примере проверяются фигуры первого слайда существующей презентации, пропускаются не‑диаграммы и выводится диагностическое сообщение для каждой диаграммы с вложенной книгой‑таблицей .xlsb.

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

        // Читать или изменять поддерживаемые данные книги-таблицы диаграммы здесь.
    }
} finally {
    presentation.dispose();
}
```

## **Внешняя книга‑таблица**

Aspose.Slides поддерживает использование внешних книг‑таблиц в качестве источника данных для диаграмм.

### **Создание внешней книги‑таблицы**

Используйте [readWorkbookStream](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/readworkbookstream/) и [setExternalWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/setexternalworkbook/) для экспорта встроенной книги‑таблицы диаграммы в файл и привязки диаграммы к этой внешней книге‑таблице.

В примере создаётся круговая диаграмма с данными по умолчанию и экспортируется её книга‑таблица. Записывается файл перед назначением внешней книги‑таблицы в качестве источника данных, после чего сохраняется презентация со связью.

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

### **Назначение внешней книги‑таблицы**

С помощью метода [setExternalWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/setexternalworkbook/) вы можете назначить внешнюю книгу‑таблицу диаграмме в качестве её источника данных. Этот же метод позволяет обновить путь к внешней книге‑таблице (если файл был перемещён).

Хотя редактировать данные в удалённых или ресурсных книгах нельзя, их всё равно можно использовать как внешний источник данных. Если указать относительный путь к внешней книге‑таблице, он автоматически преобразуется в полный путь.

В примере используется внешняя книга‑таблица, лист `Sheet1` которой содержит имя серии в B1, имена категорий в A2:A4 и числовые значения в B2:B4. Пример создаёт круговую диаграмму, связывает книгу‑таблицу и с помощью [setRange](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/setrange/) сопоставляет диапазон A1:B4 к одной серии и трём категориям. Затем презентация сохраняется со связанной диаграммой.

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

Параметр `updateChartData` метода [setExternalWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/setexternalworkbook/) управляет тем, будет ли загрузка книги‑таблицы.

* При `updateChartData` = `false` обновляется только путь к книге‑таблице. Данные диаграммы не загружаются и не обновляются из целевой книги, поэтому она может быть недоступна.
* При `updateChartData` = `true` данные диаграммы обновляются из целевой книги.

В следующем примере задаётся фиктивный URL с `updateChartData` = `false`. Диаграмма сохраняет данные по умолчанию и презентация сохраняется без попытки загрузки недоступной книги‑таблицы.

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

### **Получение пути к внешней книге‑таблице диаграммы**

Чтобы определить, какая книга‑таблица привязана к диаграмме, проверьте, использует ли диаграмма внешний источник данных, и получите её путь.

В примере проверяется первая фигура первого слайда презентации со связанной внешней книгой‑таблицей. Если это диаграмма, связанная с внешней книгой‑таблицей, выводится путь, полученный с помощью [getExternalWorkbookPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/getexternalworkbookpath/), а затем сохраняется копия презентации.

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

Данные внешних книг‑таблиц можно изменять так же, как и внутренние книги‑таблицы. Если внешняя книга‑таблица не загружается, возникает исключение.

В примере используется диаграмма, первая фигура первого слайда, связанная с доступной внешней книгой‑таблицей. Значение первой точки первой серии, основанное на ячейке, устанавливается в 100, после чего презентация сохраняется. При редактировании значений ячеек можно обновлять связанный внешний файл XLSX, поэтому используйте копию, если необходимо сохранить оригинальную книгу.

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

### **Восстановление книги‑таблицы из кэша диаграммы**

Если диаграмма использует внешнюю книгу‑таблицу, которой нет или она недоступна, Aspose.Slides может восстановить книгу‑таблицу диаграммы из кэшированных данных презентации. Создайте [LoadOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/loadoptions/), вызовите [LoadOptions.setSpreadsheetOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/loadoptions/setspreadsheetoptions/) и установите [SpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/nodejs-java/aspose.slides/spreadsheetoptions/setrecoverworkbookfromchartcache/) в `true` перед открытием презентации.

Следующий пример JavaScript восстанавливает данные книги‑таблицы для диаграммы, первая фигура первого слайда, ссылающейся на недоступную внешнюю книгу‑таблицу. Доступ к восстановленным данным осуществляется через [Chart.getChartData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/getchartdata/) и [ChartData.getChartDataWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/getchartdataworkbook/):

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

        // Читать или изменять восстановленные данные книги‑таблицы здесь.
    } else {
        console.log("The first shape is not a chart.");
    }
} finally {
    presentation.dispose();
}
```

Если внешняя книга‑таблица недоступна и восстановление отключено, Aspose.Slides бросает исключение. Включайте восстановление только тогда, когда использование кэшированных данных диаграммы является приемлемым откатом, поскольку кэш может не содержать изменений, внесённых во внешнюю книгу‑таблицу после последнего обновления презентации.

## **FAQ**

**Могу ли я определить, привязана ли конкретная диаграмма к внешней или встроенной книге‑таблице?**

Да. У диаграммы есть [тип источника данных](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/getdatasourcetype/) и [путь к внешней книге‑таблице](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/getexternalworkbookpath/); если источник — внешняя книга‑таблица, вы можете прочитать полный путь, чтобы убедиться, что используется внешний файл.

**Поддерживаются ли относительные пути к внешним книгам‑таблицам и как они хранятся?**

Да. При указании относительного пути он автоматически преобразуется в абсолютный. Презентация сохраняет абсолютный путь в файле PPTX, поэтому при перемещении книги‑таблицы может потребоваться обновить ссылку.

**Можно ли использовать книги‑таблицы, расположенные на сетевых ресурсах/общих папках?**

Да, такие книги‑таблицы могут использоваться как внешний источник данных. Однако прямое редактирование удалённых книг‑таблиц из Aspose.Slides не поддерживается — их можно только использовать в качестве источника.

**Переписывает ли Aspose.Slides внешний XLSX при сохранении презентации?**

Презентация сохраняет [ссылку на внешний файл](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/getexternalworkbookpath/). При редактировании данных диаграммы, основанных на ячейках, может также обновляться связанный локальный XLSX‑файл. Используйте копию книги‑таблицы, если оригинал должен оставаться неизменным.

**Что делать, если внешний файл защищён паролем?**

Aspose.Slides не принимает пароль при связывании. Обычный подход — снять защиту заранее или подготовить расшифрованную копию (например, с помощью [Aspose.Cells](https://reference.aspose.com/cells/java/)) и привязать к ней.

**Могут ли несколько диаграмм ссылаться на одну и ту же внешнюю книгу‑таблицу?**

Да. Каждая диаграмма хранит свою собственную ссылку. Если все они указывают на один и тот же файл, обновление этого файла будет отражено во всех диаграммах при следующей загрузке данных.