---
title: Управление рабочими книгами диаграмм в презентациях с помощью JavaScript
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
description: "Откройте для себя Aspose.Slides для Node.js через Java: без усилий управляйте рабочими книгами диаграмм в форматах PowerPoint и OpenDocument, упрощая работу с данными вашей презентации."
---
## **Обзор**

В этой статье объясняется, как работать с книгами диаграмм в Aspose.Slides. Описывается, как считывать и записывать данные диаграмм через потоки книги, использовать ячейки книги в качестве меток данных диаграммы, получать доступ к коллекциям листов и указывать тип источника данных для значений диаграммы.

Также рассматривается работа с внешними книгами в качестве источников данных для диаграмм. Примеры демонстрируют, как создать и назначить внешнюю книгу, получить путь к внешней книге, связанной с диаграммой, и редактировать данные диаграммы, когда книга доступна.

## **Чтение и запись данных диаграммы из книги**

Aspose.Slides предоставляет методы [readWorkbookStream](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/ChartData#readWorkbookStream--) и [writeWorkbookStream](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/ChartData#writeWorkbookStream-byte:A-) , которые позволяют считывать и записывать книги данных диаграмм (содержащие данные диаграмм, отредактированные с помощью Aspose.Cells). **Примечание**: данные диаграммы должны быть организованы одинаково или иметь структуру, похожую на исходную.

```javascript
var pres = new aspose.slides.Presentation("chart.pptx");
try {
    var chart = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    var data = chart.getChartData();
    var stream = data.readWorkbookStream();
    data.getSeries().clear();
    data.getCategories().clear();
    data.writeWorkbookStream(stream);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Установка ячейки книги в качестве метки данных диаграммы**

1. Создайте экземпляр класса [Presentation](https://apireference.aspose.com/slides/ru/nodejs-java/aspose.slides/presentation).
2. Получите ссылку на слайд по его индексу.
3. Добавьте пузырьковую диаграмму с некоторыми данными.
4. Получите доступ к сериям диаграммы.
5. Установите ячейку книги в качестве метки данных.
6. Сохраните презентацию.

```javascript
var lbl0 = "Label 0 cell value";
var lbl1 = "Label 1 cell value";
var lbl2 = "Label 2 cell value";
// Создает экземпляр класса презентации, представляющего файл презентации
var pres = new aspose.slides.Presentation("chart2.pptx");
try {
    var slide = pres.getSlides().get_Item(0);
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.Bubble, 50, 50, 600, 400, true);
    var series = chart.getChartData().getSeries();
    var dataLabelCollection = series.get_Item(0).getLabels();
    dataLabelCollection.getDefaultDataLabelFormat().setShowLabelValueFromCell(true);
    var wb = chart.getChartData().getChartDataWorkbook();
    dataLabelCollection.get_Item(0).setValueFromCell(wb.getCell(0, "A10", lbl0));
    dataLabelCollection.get_Item(1).setValueFromCell(wb.getCell(0, "A11", lbl1));
    dataLabelCollection.get_Item(2).setValueFromCell(wb.getCell(0, "A12", lbl2));
    pres.save("resultchart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Управление листами**

Этот JavaScript‑код демонстрирует операцию, в которой используется метод [ChartDataWorkbook.getWorksheets](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/ChartDataWorkbook#getWorksheets--) для доступа к коллекции листов:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Pie, 50, 50, 400, 500);
    var wb = chart.getChartData().getChartDataWorkbook();
    for (var i = 0; i < wb.getWorksheets().size(); i++) {
        console.log(wb.getWorksheets().get_Item(i).getName());
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Указание типа источника данных**

Этот JavaScript‑код показывает, как указать тип для источника данных:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Column3D, 50, 50, 600, 400, true);
    var val = chart.getChartData().getSeries().get_Item(0).getName();
    val.setDataSourceType(aspose.slides.DataSourceType.StringLiterals);
    val.setData("LiteralString");
    val = chart.getChartData().getSeries().get_Item(1).getName();
    val.setData(chart.getChartData().getChartDataWorkbook().getCell(0, "B1", "NewCell"));
    pres.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Обнаружение неподдерживаемых форматов встроенных книг**

Aspose.Slides не поддерживает формат бинарной книги Excel (.xlsb), который может быть встроен в некоторые диаграммы. Вы можете использовать метод `getEmbeddedWorkbookType` на объекте [ChartData](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/chartdata/) совместно с перечислением [WorkbookType](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/workbooktype/) для обнаружения неподдерживаемых форматов и пропуска таких диаграмм.

```js
let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let shapes = slide.getShapes();

    for (let shapeIndex = 0; shapeIndex < shapes.size(); shapeIndex++) {
        let shape = shapes.get_Item(shapeIndex);

        if (!java.instanceOf(shape, "com.aspose.slides.IChart")) continue;

        let chart = shape;
        let chartData = chart.getChartData();

        if (chartData.getDataSourceType() == aspose.slides.ChartDataSourceType.InternalWorkbook &&
                chartData.getEmbeddedWorkbookType() == aspose.slides.WorkbookType.WorkbookBinaryMacro) {
            // Встроенная рабочая книга в формате .xlsb, который не поддерживается.
            continue;
        }

        // Здесь можно читать или изменять данные рабочей книги диаграммы.
    }
} finally {
    presentation.dispose();
}
```

## **Внешняя книга**

Aspose.Slides поддерживает внешние книги в качестве источника данных для диаграмм.

### **Создание внешней книги**

С помощью методов **`readWorkbookStream`** и **`setExternalWorkbook`** вы можете либо создать внешнюю книгу с нуля, либо сделать внутреннюю книгу внешней.

```javascript
var pres = new aspose.slides.Presentation();
try {
    final var workbookPath = "externalWorkbook1.xlsx";
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Pie, 50, 50, 400, 600);
    var fileStream = java.newInstanceSync("java.io.FileOutputStream", workbookPath);
    try {
        var workbookData = chart.getChartData().readWorkbookStream();
        fileStream.write(workbookData, 0, workbookData.length);
    } finally {
        if (fileStream != null) {
            fileStream.close();
        }
    }
    chart.getChartData().setExternalWorkbook(workbookPath);
    pres.save("externalWorkbook.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Установка внешней книги**

С помощью метода **`setExternalWorkbook`** вы можете назначить внешнюю книгу диаграмме в качестве её источника данных. Этот метод также может использоваться для обновления пути к внешней книге (если она была перемещена).

Хотя вы не можете редактировать данные в книгах, хранящихся в удалённых расположениях или ресурсах, такие книги всё равно могут использоваться в качестве внешнего источника данных. Если указать относительный путь к внешней книге, он автоматически преобразуется в абсолютный путь.

```javascript
// Создает экземпляр класса Presentation
var pres = new aspose.slides.Presentation("chart.pptx");
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Pie, 50, 50, 400, 600, false);
    var chartData = chart.getChartData();
    chartData.setExternalWorkbook("externalWorkbook.xlsx");
    chartData.getSeries().add(chartData.getChartDataWorkbook().getCell(0, "B1"), aspose.slides.ChartType.Pie);
    chartData.getSeries().get_Item(0).getDataPoints().addDataPointForPieSeries(chartData.getChartDataWorkbook().getCell(0, "B2"));
    chartData.getSeries().get_Item(0).getDataPoints().addDataPointForPieSeries(chartData.getChartDataWorkbook().getCell(0, "B3"));
    chartData.getSeries().get_Item(0).getDataPoints().addDataPointForPieSeries(chartData.getChartDataWorkbook().getCell(0, "B4"));
    chartData.getCategories().add(chartData.getChartDataWorkbook().getCell(0, "A2"));
    chartData.getCategories().add(chartData.getChartDataWorkbook().getCell(0, "A3"));
    chartData.getCategories().add(chartData.getChartDataWorkbook().getCell(0, "A4"));
    pres.save("Presentation_with_externalWorkbook.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

Параметр `ChartData` (в методе `setExternalWorkbook`) используется для указания, будет ли загружена Excel‑книга.

* Когда значение `ChartData` установлено в `false`, обновляется только путь к книге — данные диаграммы не будут загружаться и обновляться из целевой книги. Это может быть полезно, когда целевая книга не существует или недоступна. 
* Когда значение `ChartData` установлено в `true`, данные диаграммы обновляются из целевой книги.

```javascript
// Создает экземпляр класса Presentation
var pres = new aspose.slides.Presentation("chart.pptx");
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Pie, 50, 50, 400, 600, true);
    var chartData = chart.getChartData();
    chartData.setExternalWorkbook("http://path/doesnt/exists", false);
    pres.save("Presentation_with_externalWorkbookWithUpdateChartData.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Получение пути к внешней книге источника данных диаграммы**

1. Создайте экземпляр класса [Presentation](https://apireference.aspose.com/slides/ru/nodejs-java/aspose.slides/presentation).
2. Получите ссылку на слайд по его индексу.
3. Создайте объект для формы диаграммы.
4. Создайте объект типа источника (`ChartDataSourceType`), представляющего источник данных диаграммы.
5. Укажите соответствующее условие, исходя из того, что тип источника совпадает с типом внешней книги.

```javascript
// Создает экземпляр класса Presentation
var pres = new aspose.slides.Presentation("chart.pptx");
try {
    var slide = pres.getSlides().get_Item(1);
    var chart = slide.getShapes().get_Item(0);
    var sourceType = chart.getChartData().getDataSourceType();
    if (sourceType == aspose.slides.ChartDataSourceType.ExternalWorkbook) {
        var path = chart.getChartData().getExternalWorkbookPath();
    }
    // Сохраняет презентацию
    pres.save("result.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Редактирование данных диаграммы**

Вы можете редактировать данные во внешних книгах так же, как меняете содержимое внутренних книг. Если внешняя книга не может быть загружена, возникает исключение.

```javascript
// Создает экземпляр класса Presentation
var pres = new aspose.slides.Presentation("chart.pptx");
try {
    var chart = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    var chartData = chart.getChartData();
    chartData.getSeries().get_Item(0).getDataPoints().get_Item(0).getValue().getAsCell().setValue(100);
    pres.save("presentation_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Восстановление книги из кеша диаграммы**

Если диаграмма использует внешнюю книгу, которой нет или она недоступна, Aspose.Slides может восстановить книгу диаграммы из данных, закешированных в презентации. Создайте [LoadOptions](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/loadoptions/), настройте его с помощью [SpreadsheetOptions](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/spreadsheetoptions/), и вызовите [SpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/spreadsheetoptions/#setRecoverWorkbookFromChartCache) со значением `true` перед открытием презентации.

Следующий JavaScript‑пример открывает презентацию, в которой диаграмма ссылается на недоступную внешнюю книгу, и получает восстановленные данные через [ChartData.getChartDataWorkbook](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/chartdata/#getChartDataWorkbook):

```javascript
const spreadsheetOptions = new aspose.slides.SpreadsheetOptions();
spreadsheetOptions.setRecoverWorkbookFromChartCache(true);

const loadOptions = new aspose.slides.LoadOptions();
loadOptions.setSpreadsheetOptions(spreadsheetOptions);

const presentation = new aspose.slides.Presentation("presentation.pptx", loadOptions);
try {
    const chart = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const recoveredWorkbook = chart.getChartData().getChartDataWorkbook();

    // Читать или изменять восстановленные данные рабочей книги здесь.
} finally {
    presentation.dispose();
}
```

Если внешняя книга недоступна и восстановление отключено, Aspose.Slides бросает исключение. Включайте восстановление только в тех случаях, когда использование закешированных данных диаграммы является приемлемым резервом, поскольку кеш может не содержать изменений, сделанных во внешней книге после последнего обновления презентации.

## **FAQ**

**Могу ли я определить, связана ли конкретная диаграмма с внешней или встроенной книгой?**

Да. У диаграммы есть [тип источника данных](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/chartdata/getdatasourcetype/) и [путь к внешней книге](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/chartdata/getexternalworkbookpath/); если источник — внешняя книга, вы можете прочитать полный путь, чтобы убедиться, что используется внешний файл.

**Поддерживаются ли относительные пути к внешним книгам и как они хранятся?**

Да. При указании относительного пути он автоматически преобразуется в абсолютный. Это удобно для переносимости проекта; однако презентация сохраняет абсолютный путь в файле PPTX.

**Можно ли использовать книги, расположенные на сетевых ресурсах/общих папках?**

Да, такие книги могут использоваться в качестве внешнего источника данных. Однако прямое редактирование удалённых книг из Aspose.Slides не поддерживается — они могут использоваться только как источник.

**Перезаписывает ли Aspose.Slides внешний XLSX при сохранении презентации?**

Нет. Презентация хранит [ссылку на внешний файл](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/chartdata/getexternalworkbookpath/) и использует её только для чтения данных. Сам внешний файл не изменяется при сохранении презентации.

**Что делать, если внешний файл защищён паролем?**

Aspose.Slides не принимает пароль при связывании. Обычно сначала снимают защиту или готовят расшифрованную копию (например, с помощью [Aspose.Cells](/cells/nodejs-java/)) и связываются с этой копией.

**Могут ли несколько диаграмм ссылаться на одну и ту же внешнюю книгу?**

Да. Каждая диаграмма хранит свою собственную ссылку. Если они указывают на один и тот же файл, обновление этого файла отразится во всех диаграммах при следующей загрузке данных.