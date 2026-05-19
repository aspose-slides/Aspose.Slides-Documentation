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
- подпись данных
- лист
- источник данных
- внешняя рабочая книга
- внешние данные
- PowerPoint
- презентация
- Node.js
- JavaScript
- Aspose.Slides
description: "Откройте для себя Aspose.Slides для Node.js через Java: без усилий управляйте рабочими книгами диаграмм в форматах PowerPoint и OpenDocument, упрощая работу с данными вашей презентации."
---
## **Обзор**

В этой статье объясняется, как работать с рабочими книгами диаграмм в Aspose.Slides. Описывается, как считывать и записывать данные диаграмм через потоки рабочей книги, использовать ячейки рабочей книги в качестве подписей данных диаграммы, получать доступ к коллекциям листов и указывать тип источника данных для значений диаграммы.

Также рассматривается работа с внешними рабочими книгами в качестве источников данных диаграмм. Примеры демонстрируют, как создать и назначить внешнюю рабочую книгу, получить путь к внешней рабочей книге, связанной с диаграммой, и редактировать данные диаграммы, когда рабочая книга доступна.

## **Чтение и запись данных диаграммы из рабочей книги**

Aspose.Slides предоставляет методы [readWorkbookStream](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/ChartData#readWorkbookStream--) и [writeWorkbookStream](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/ChartData#writeWorkbookStream-byte:A-) , позволяющие считывать и записывать рабочие книги данных диаграммы (содержащие данные, отредактированные с помощью Aspose.Cells). **Примечание**: данные диаграммы должны быть организованы одинаково или иметь структуру, схожую с исходной.

Этот JavaScript‑код демонстрирует пример операции:

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

## **Установить ячейку рабочей книги как подпись данных диаграммы**

1. Создать экземпляр класса [Presentation](https://apireference.aspose.com/slides/ru/nodejs-java/aspose.slides/presentation).  
2. Получить ссылку на слайд по его индексу.  
3. Добавить пузырьковую диаграмму с некоторыми данными.  
4. Получить доступ к серии диаграммы.  
5. Установить ячейку рабочей книги в качестве подписи данных.  
6. Сохранить презентацию.

Этот JavaScript‑код показывает, как установить ячейку рабочей книги как подпись данных диаграммы:

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

## **Указать тип источника данных**

Этот JavaScript‑код показывает, как указать тип источника данных:

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

## **Обнаружить неподдерживаемые форматы встроенных рабочих книг**

Aspose.Slides не поддерживает бинарный формат Excel (.xlsb), который может быть встроен в некоторые диаграммы. Можно использовать метод `getEmbeddedWorkbookType` класса [ChartData](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/chartdata/) совместно с перечислением [WorkbookType](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/workbooktype/) для обнаружения неподдерживаемых форматов и пропуска соответствующих диаграмм.

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
            // Встроенная рабочая книга находится в формате .xlsb, который не поддерживается.
            continue;
        }

        // Здесь считывайте или изменяйте данные рабочей книги диаграммы.
    }
} finally {
    presentation.dispose();
}
```

## **Внешняя рабочая книга**

Aspose.Slides поддерживает внешние рабочие книги в качестве источника данных для диаграмм.

### **Создать внешнюю рабочую книгу**

С помощью методов **`readWorkbookStream`** и **`setExternalWorkbook`** можно либо создать внешнюю рабочую книгу с нуля, либо сделать внутреннюю рабочую книгу внешней.

Этот JavaScript‑код демонстрирует процесс создания внешней рабочей книги:

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

### **Назначить внешнюю рабочую книгу**

Метод **`setExternalWorkbook`** позволяет привязать внешнюю рабочую книгу к диаграмме в качестве её источника данных. Кроме того, этим методом можно обновить путь к внешней рабочей книге (если она была перемещена).

Хотя редактировать данные в рабочих книгах, хранящихся в удалённых местах или ресурсах, нельзя, такие книги могут использоваться в качестве внешнего источника данных. Если указан относительный путь к внешней рабочей книге, он автоматически преобразуется в полный путь.

Этот JavaScript‑код показывает, как назначить внешнюю рабочую книгу:

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

Параметр `ChartData` (в методе `setExternalWorkbook`) используется для указания, будет ли загружаться Excel‑рабочая книга.

* При значении `ChartData` = `false` обновляется только путь к рабочей книге — данные диаграммы не загружаются и не обновляются из целевой книги. Этот вариант полезен, когда целевая рабочая книга отсутствует или недоступна.  
* При значении `ChartData` = `true` данные диаграммы обновляются из целевой рабочей книги.

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

### **Получить путь к внешнему источнику данных диаграммы**

1. Создать экземпляр класса [Presentation](https://apireference.aspose.com/slides/ru/nodejs-java/aspose.slides/presentation).  
2. Получить ссылку на слайд по его индексу.  
3. Создать объект формы диаграммы.  
4. Создать объект типа источника (`ChartDataSourceType`), представляющего источник данных диаграммы.  
5. Указать соответствующее условие в зависимости от того, что тип источника совпадает с типом внешней рабочей книги.

Этот JavaScript‑код демонстрирует соответствующую операцию:

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

### **Редактировать данные диаграммы**

Данные во внешних рабочих книгах можно редактировать так же, как и во внутренних. Если внешняя рабочая книга не может быть загружена, генерируется исключение.

Этот JavaScript‑код реализует описанный процесс:

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

## **FAQ**

**Можно ли определить, связана ли конкретная диаграмма с внешней или встроенной рабочей книгой?**  

Да. У диаграммы есть [тип источника данных](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/chartdata/getdatasourcetype/) и [путь к внешней рабочей книге](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/chartdata/getexternalworkbookpath/); если источник — внешняя рабочая книга, можно прочитать полный путь, чтобы убедиться, что используется внешний файл.

**Поддерживаются ли относительные пути к внешним рабочим книгам и как они хранятся?**  

Да. При указании относительного пути он автоматически преобразуется в абсолютный. Это удобно для переносимости проекта, однако в файле PPTX сохраняется абсолютный путь.

**Можно ли использовать рабочие книги, расположенные на сетевых ресурсах/общих папках?**  

Да, такие книги могут служить внешним источником данных. Прямое редактирование удалённых книг из Aspose.Slides не поддерживается — они могут использоваться только как источник.

**Перезаписывает ли Aspose.Slides внешний XLSX при сохранении презентации?**  

Нет. Презентация хранит только [ссылку на внешний файл](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/chartdata/getexternalworkbookpath/) и использует её для чтения данных. При сохранении презентации внешний файл не изменяется.

**Что делать, если внешний файл защищён паролем?**  

Aspose.Slides не принимает пароль при привязке. Обычно защищённость снимают заранее или готовят расшифрованную копию (например, с помощью [Aspose.Cells](/cells/nodejs-java/)) и привязывают её.

**Могут ли несколько диаграмм ссылаться на одну и ту же внешнюю рабочую книгу?**  

Да. Каждая диаграмма хранит свою собственную ссылку. Если все они указывают на один и тот же файл, обновление этого файла отразится в каждой диаграмме при следующей загрузке данных.