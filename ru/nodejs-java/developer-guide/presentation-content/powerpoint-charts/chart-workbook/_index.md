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
description: "Откройте для себя Aspose.Slides для Node.js via Java: без труда управлять рабочими книгами диаграмм в форматах PowerPoint и OpenDocument, упрощая работу с данными вашей презентации."
---
## **Обзор**

В этой статье объясняется, как работать с рабочими книгами диаграмм в Aspose.Slides. Показано, как считывать и записывать данные диаграммы через потоки рабочей книги, использовать ячейки рабочей книги в качестве меток данных диаграммы, получать доступ к коллекциям листов и указывать тип источника данных для значений диаграммы.

Также рассматривается работа с внешними рабочими книгами в качестве источников данных диаграмм. Примеры демонстрируют, как создать и связать внешнюю рабочую книгу, получить путь внешней рабочей книги, связанной с диаграммой, и редактировать данные диаграммы, когда рабочая книга доступна.

Для ячеек рабочей книги, представляющих отсутствующие данные, см. [Управление отображением пустых ячеек](/slides/ru/nodejs-java/chart-series/) для различий между пустой ячейкой и нулём, а также сравнение режимов отображения на линейной диаграмме.

## **Включение данных из скрытых строк и столбцов**

Используйте [Chart.setPlotVisibleCellsOnly](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/chart/#setPlotVisibleCellsOnly), чтобы контролировать, будет ли диаграмма отображать данные из скрытых строк и столбцов листа. Установите `true`, чтобы отображать только видимые ячейки, или `false`, чтобы включать как видимые, так и скрытые ячейки. Эта настройка управляет построением диаграммы; она не скрывает и не отображает строки или столбцы листа.

Скачайте [hidden-source-data.pptx](hidden-source-data.pptx) и поместите её в рабочий каталог. На первом слайде находится столбчатая диаграмма как первая фигура. Встроенный лист `Sheet1` содержит диапазон источника `A1:C4`. Строка 3 и столбец C скрыты, но их ячейки всё‑таки содержат значения.

| Строка листа | A: Месяц | B: Розница | C: Оптовая (скрытый столбец) |
| --- | --- | --- | --- |
| 2 | Январь | 10 | 30 |
| 3 (скрытая строка) | Февраль | 40 | 60 |
| 4 | Март | 20 | 50 |

Получайте доступ к исходным ячейкам через [ChartData.getChartDataWorkbook](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/chartdata/#getChartDataWorkbook) и проверяйте их статус скрытия с помощью [ChartDataCell.isHidden](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/chartdatacell/#isHidden). Этот метод сообщает о статусе скрытия без его изменения. В этом примере B2 видима, B3 относится к скрытой строке, а C2 — к скрытому столбцу; пример выводит соответственно `false`, `true` и `true`.

Для данного примера после изменения настройки построения обновите данные диаграммы: сохраните встроенную рабочую книгу с помощью [readWorkbookStream](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/chartdata/#readWorkbookStream) и загрузите её заново с помощью [writeWorkbookStream](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/chartdata/#writeWorkbookStream). При включении всех ячеек также используйте [setRange](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/chartdata/#setRange), чтобы восстановить полный диапазон, включая скрытую категорию февраль. Простая смена флага недостаточна для обновления кэшированных данных и меток категорий в этом образце. Пример преобразует полученный буфер Node.js в массив байтов Java перед передачей его в метод записи.

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

Пример сохраняет `hidden_cells_true.pptx` только с видимыми значениями розницы (10 и 20) и `hidden_cells_false.pptx` со всеми шестью значениями. Ниже показаны изображения двух режимов построения. Строка 3 и столбец C остаются скрытыми в обеих встроенных рабочих книгах.

| Только видимые ячейки (`true`) | Все ячейки (`false`) |
| --- | --- |
| ![Только видимые ячейки: значения розницы 10 и 20 для января и марта.](hidden_cells_True.png) | ![Все ячейки: значения розницы и оптовой цены для января, февраля и марта.](hidden_cells_False.png) |

Скрытая ячейка, содержащая значение, отличается от пустой ячейки. [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/chart/#setDisplayBlanksAs) управляет тем, как отображаются отсутствующие значения; он не включает и не исключает скрытые исходные данные. См. [Управление отображением пустых ячеек](/slides/ru/nodejs-java/chart-series/#control-the-display-of-empty-cells) для примера.

## **Чтение и запись данных диаграммы из рабочей книги**

Aspose.Slides for Node.js via Java предоставляет методы [readWorkbookStream](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/chartdata/#readWorkbookStream) и [writeWorkbookStream](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/chartdata/#writeWorkbookStream), позволяющие читать и записывать рабочие книги данных диаграмм (содержащие данные, отредактированные с помощью Aspose.Cells). **Важно**: данные диаграммы должны быть организованы одинаково или иметь структуру, схожую с исходной.

В этом примере открывается `chart.pptx`, который должен содержать диаграмму как первую фигуру на первом слайде. Встроенная рабочая книга считывается в массив байтов, существующие серии и категории очищаются, затем та же рабочая книга записывается обратно. Изменения остаются в памяти; пример не сохраняет презентацию.

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

Когда вы заменяете встроенную рабочую книгу модифицированной, диаграмма сохраняет свои исходные коллекции серий и категорий. Такое несоответствие может привести к сбою [Chart.validateChartLayout](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/chart/#validateChartLayout) с ошибкой “index out of range”. Очистите существующие серии и категории перед записью обновлённой рабочей книги обратно в диаграмму. Пример требует `chart.pptx` с диаграммой как первой фигурой на первом слайде. Комментарий указывает, где должна происходить правка рабочей книги; исполняемый пример записывает оригинальную рабочую книгу обратно и проверяет макет в памяти.

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

Очистка коллекций удаляет устаревшие ссылки перед записью рабочей книги. Перед использованием диаграммы перестройте необходимые отображения серий и категорий для обновлённой рабочей книги.

## **Установка ячейки рабочей книги в качестве метки данных диаграммы**

Можно использовать текст из ячеек рабочей книги в качестве меток данных диаграммы. Ниже перечислены шаги, показывающие, как привязать метки в пузырьковой диаграмме к ячейкам её рабочей книги.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/presentation/).
2. Получите первый слайд по нулевому индексу.
3. Добавьте пузырьковую диаграмму с данными по умолчанию.
4. Получите серию диаграммы.
5. Установите ячейку рабочей книги в качестве метки данных.
6. Сохраните презентацию.

В примере открывается `chart2.pptx`, который должен содержать хотя бы один слайд, и добавляется пузырьковая диаграмма с данными по умолчанию. Используются ячейки A10:A12 листа 0 для первых трёх меток первой серии, включаются метки из ячеек, и результат сохраняется в `resultchart.pptx`.

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

Метод [ChartDataWorkbook.getWorksheets](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/chartdataworkbook/#getWorksheets) предоставляет доступ к листам в рабочей книге диаграммы. В этом примере создаётся круговая диаграмма с данными по умолчанию и выводятся имена каждого листа в консоль.

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

В этом примере создаётся 3D‑столбчатая диаграмма с данными по умолчанию и задаются два имени серий, использующих разные источники данных. Первое имя задаётся строковым литералом; второе — ячейкой C1 листа 0. Перечисление [DataSourceType](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/datasourcetype/) выбирает источник для каждого имени. Результат сохраняется в `pres.pptx`.

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

Aspose.Slides не поддерживает формат двоичной рабочей книги Excel (.xlsb), который может быть встроен в некоторые диаграммы. Вы можете использовать метод [getEmbeddedWorkbookType](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/chartdata/#getEmbeddedWorkbookType) класса [ChartData](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/chartdata/) совместно с перечислением [WorkbookType](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/workbooktype/) для обнаружения неподдерживаемых форматов и пропуска таких диаграмм. Пример проверяет фигуры на первом слайде `sample.pptx`, пропускает не‑диаграммные фигуры и выводит диагностическое сообщение для каждой диаграммы с встроенной рабочей книгой .xlsb.

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

Используйте [readWorkbookStream](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/chartdata/#readWorkbookStream) и [setExternalWorkbook](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/chartdata/#setExternalWorkbook) для экспорта встроенной рабочей книги диаграммы в файл и связывания диаграммы с этой внешней рабочей книгой.

В примере создаётся круговая диаграмма с данными по умолчанию, её рабочая книга записывается в `externalWorkbook1.xlsx`, и запись в файл завершается до назначения файла в качестве источника данных диаграммы. Связанная презентация сохраняется в `externalWorkbook.pptx`.

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

### **Назначение внешней рабочей книги**

С помощью метода [setExternalWorkbook](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/chartdata/#setExternalWorkbook) вы можете назначить внешнюю рабочую книгу диаграмме в качестве её источника данных. Этот метод также позволяет обновить путь к внешней рабочей книге (если её переместили).

Хотя редактировать данные в рабочих книгах, хранящихся в удалённых местах или ресурсах, нельзя, такие книги всё равно могут использоваться как внешний источник данных. Если указан относительный путь к внешней рабочей книге, он автоматически преобразуется в полный путь.

Пример требует `externalWorkbook.xlsx` в рабочем каталоге. На листе `Sheet1` должны быть имя серии в B1, имена категорий в A2:A4 и числовые значения в B2:B4. Пример создаёт круговую диаграмму, связывает рабочую книгу и использует [setRange](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/chartdata/#setRange) для сопоставления A1:B4 с одной серией и тремя категориями. Результат сохраняется в `Presentation_with_externalWorkbook.pptx`.

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

Параметр `updateChartData` метода [setExternalWorkbook](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/chartdata/#setExternalWorkbook) управляет тем, будет ли загружена рабочая книга.

* Когда `updateChartData` равен `false`, обновляется только путь к рабочей книге. Данные диаграммы не загружаются и не обновляются из целевой рабочей книги, поэтому рабочая книга может быть недоступна.
* Когда `updateChartData` равен `true`, данные диаграммы обновляются из целевой рабочей книги.

В следующем примере задаётся фиктивный URL с `updateChartData`, установленным в `false`. Диаграмма сохраняет данные по умолчанию и сохраняет презентацию без загрузки недоступной рабочей книги.

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

### **Получение пути внешнего источника данных рабочей книги диаграммы**

Чтобы определить, какая рабочая книга связана с диаграммой, сначала проверьте, использует ли диаграмма внешний источник данных. Если да, вы можете получить путь к рабочей книге, выполнив следующие шаги.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/presentation/).
2. Получите первый слайд по нулевому индексу.
3. Убедитесь, что первая фигура — это диаграмма.
4. Считайте тип источника данных диаграммы.
5. Если источник — внешняя рабочая книга, считайте её путь.

Пример открывает `externalWorkbook.pptx`, созданный в предыдущем примере, и проверяет первую фигуру на первом слайде. Если это диаграмма, связанная с внешней рабочей книгой, пример выводит [getExternalWorkbookPath](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/chartdata/#getExternalWorkbookPath) в консоль. Затем сохраняется копия презентации в `Result.pptx`.

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

Вы можете редактировать данные во внешних рабочих книгах так же, как и во встроенных. Если внешняя рабочая книга не может быть загружена, выбрасывается исключение.

Пример требует `presentation.pptx` с диаграммой как первой фигурой на первом слайде и доступной внешней рабочей книгой. Значению первой точки первой серии, поддерживаемой ячейкой, присваивается 100, после чего презентация сохраняется в `presentation_out.pptx`. Редактирование значений ячеек может обновлять связанный внешний файл XLSX, поэтому используйте копию, если необходимо сохранить оригинальную книгу.

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

### **Восстановление рабочей книги из кеша диаграммы**

Если диаграмма использует внешнюю рабочую книгу, которая отсутствует или недоступна, Aspose.Slides может восстановить рабочую книгу диаграммы из кешированных данных презентации. Создайте [LoadOptions](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/loadoptions/), вызовите [LoadOptions.setSpreadsheetOptions](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/loadoptions/#setSpreadsheetOptions) и установите [SpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/spreadsheetoptions/#setRecoverWorkbookFromChartCache) в `true` перед открытием презентации.

Следующий пример JavaScript открывает `presentation.pptx`, у которого первая фигура на первом слайде должна быть диаграммой, ссылающейся на недоступную внешнюю рабочую книгу, и получает восстановленные данные через [Chart.getChartData](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/chart/#getChartData) и [ChartData.getChartDataWorkbook](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/chartdata/#getChartDataWorkbook):

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

Если внешняя рабочая книга недоступна и восстановление отключено, Aspose.Slides выбрасывает исключение. Включайте восстановление только тогда, когда использование кешированных данных диаграммы является приемлемым запасным вариантом, так как кеш может не содержать изменений, внесённых во внешнюю рабочую книгу после последнего обновления презентации.

## **FAQ**

**Могу ли я определить, привязана ли конкретная диаграмма к внешней или встроенной рабочей книге?**

Да. У диаграммы есть [тип источника данных](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/chartdata/#getDataSourceType) и [путь к внешней рабочей книге](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/chartdata/#getExternalWorkbookPath); если источник — внешняя рабочая книга, вы можете прочитать полный путь, чтобы убедиться, что используется внешний файл.

**Поддерживаются ли относительные пути к внешним рабочим книгам и как они хранятся?**

Да. При указании относительного пути он автоматически преобразуется в абсолютный. Презентация сохраняет абсолютный путь в файле PPTX, поэтому при перемещении книги может потребоваться обновить ссылку.

**Можно ли использовать рабочие книги, расположенные на сетевых ресурсах/общих папках?**

Да, такие рабочие книги могут использоваться как внешний источник данных. Однако редактирование удалённых рабочих книг напрямую из Aspose.Slides не поддерживается — они могут только служить источником.

**Перезаписывает ли Aspose.Slides внешний XLSX при сохранении презентации?**

Презентация сохраняет [ссылку на внешний файл](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/chartdata/#getExternalWorkbookPath). Редактирование данных диаграммы, основанных на ячейках, также может обновлять связанный локальный файл XLSX. Используйте копию рабочей книги, если оригинал должен оставаться неизменным.

**Что делать, если внешний файл защищён паролем?**

Aspose.Slides не принимает пароль при связывании. Обычно снимают защиту заранее или подготавливают расшифрованную копию (например, с помощью [Aspose.Cells](https://reference.aspose.com/cells/java/)) и связывают её.

**Могут ли несколько диаграмм ссылаться на одну и ту же внешнюю рабочую книгу?**

Да. Каждая диаграмма хранит свою собственную ссылку. Если они указывают на один и тот же файл, изменение этого файла отразится во всех диаграммах при следующей загрузке данных.