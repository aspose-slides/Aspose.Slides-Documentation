---
title: "Рабочая книга диаграммы"
type: docs
weight: 70
url: /ru/nodejs-java/chart-workbook/
keywords: "рабочая книга диаграммы, данные диаграммы, презентация PowerPoint, Java, Aspose.Slides для Node.js через Java"
description: "Рабочая книга диаграммы в презентации PowerPoint на JavaScript"
---

## **Установить данные диаграммы из рабочей книги**
Aspose.Slides предоставляет методы [readWorkbookStream](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartData#readWorkbookStream--) и [writeWorkbookStream](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartData#writeWorkbookStream-byte:A-) , которые позволяют считывать и записывать рабочие книги данных диаграмм (содержащие данные диаграмм, отредактированные с помощью Aspose.Cells). **Примечание**: данные диаграммы должны быть организованы одинаково или иметь структуру, схожую с исходной.

This JavaScript code demonstrates a sample operation:
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


## **Установить ячейку рабочей книги в качестве метки данных диаграммы**

1. Создайте экземпляр класса [Presentation](https://apireference.aspose.com/slides/nodejs-java/aspose.slides/presentation) .
2. Получите ссылку на слайд по его индексу.
3. Добавьте пузырчатую диаграмму с некоторыми данными.
4. Получите доступ к сериям диаграммы.
5. Установите ячейку рабочей книги в качестве метки данных.
6. Сохраните презентацию.

This JavaScript code shows you to set a workbook cell as a chart data label:
```javascript
var lbl0 = "Label 0 cell value";
var lbl1 = "Label 1 cell value";
var lbl2 = "Label 2 cell value";
// Создаёт экземпляр класса презентации, представляющего файл презентации
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

This JavaScript code demonstrates an operation where the [ChartDataWorkbook.getWorksheets](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartDataWorkbook#getWorksheets--) method is used to access a worksheet collection:
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

This JavaScript code shows you how to specify a type for a data source:
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


## **External Workbook**

{{% alert color="primary" %}} 
В [Aspose.Slides 19.4](https://docs.aspose.com/slides/nodejs-java/aspose-slides-for-java-19-4-release-notes/), мы реализовали поддержку внешних рабочих книг в качестве источника данных для диаграмм.
{{% /alert %}} 

### **Создать внешнюю рабочую книгу**

Using the **`readWorkbookStream`** and **`setExternalWorkbook`** methods, you can either create an external workbook from scratch or make an internal workbook external.

This JavaScript code demonstrates the external workbook creation process:
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


### **Установить внешнюю рабочую книгу**

Using the **`setExternalWorkbook`** method, you can assign an external workbook to a chart as its data source. This method can also be used to update a path to the external workbook (if the latter has been moved).

While you cannot edit the data in workbooks stored in remote locations or resources, you can still use such workbooks as an external data source. If the relative path for an external workbook is provided, it gets converted to a full path automatically.

This JavaScript code shows you how to set an external workbook:
```javascript
// Создаёт экземпляр класса Presentation
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


The `ChartData` parameter (under the `setExternalWorkbook` method) is used to specify whether an excel workbook will be loaded or not. 

* When `ChartData` value is set to `false`, only the workbook path gets updated—the chart data will not be loaded or updated from the target workbook. You may want to use this setting when in a situation where the target workbook is nonexistent or unavailable. 
* When `ChartData` value is set to `true` , the chart data gets updated from the target workbook.
```javascript
// Создаёт экземпляр класса Presentation
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


### **Получить путь к внешней рабочей книге источника данных диаграммы**

1. Создайте экземпляр класса [Presentation](https://apireference.aspose.com/slides/nodejs-java/aspose.slides/presentation) .
2. Получите ссылку на слайд по его индексу.
3. Создайте объект для формы диаграммы.
4. Создайте объект для типа источника (`ChartDataSourceType`), представляющего источник данных диаграммы.
5. Укажите соответствующее условие, исходя из того, что тип источника совпадает с типом внешней рабочей книги.

This JavaScript code demonstrates the operation:
```javascript
// Создаёт экземпляр класса Presentation
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

You can edit the data in external workbooks the same way you make changes to the contents of internal workbooks. When an external workbook cannot be loaded, an exception is thrown.

This JavaScript code is an implementation of the described process:
```javascript
// Создаёт экземпляр класса Presentation
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

**Могу ли я определить, связана ли конкретная диаграмма с внешней или встроенной рабочей книгой?**

Yes. A chart has a [data source type](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/getdatasourcetype/) and a [path to an external workbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/getexternalworkbookpath/); if the source is an external workbook, you can read the full path to make sure an external file is being used.

**Поддерживаются ли относительные пути к внешним рабочим книгам, и как они хранятся?**

Yes. If you specify a relative path, it is automatically converted to an absolute path. This is convenient for project portability; however, be aware that the presentation will store the absolute path in the PPTX file.

**Можно ли использовать рабочие книги, расположенные на сетевых ресурсах/общих папках?**

Yes, such workbooks can be used as an external data source. However, editing remote workbooks directly from Aspose.Slides is not supported—they can only be used as a source.

**Перезаписывает ли Aspose.Slides внешний XLSX при сохранении презентации?**

No. The presentation stores a [link to the external file](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/getexternalworkbookpath/) and uses it for reading data. The external file itself is not modified when the presentation is saved.

**Что делать, если внешний файл защищён паролем?**

Aspose.Slides does not accept a password when linking. A common approach is to remove protection in advance or prepare a decrypted copy (for example, using [Aspose.Cells](/cells/nodejs-java/)) and link to that copy.

**Могут ли несколько диаграмм ссылаться на одну и ту же внешнюю рабочую книгу?**

Yes. Each chart stores its own link. If they all point to the same file, updating that file will be reflected in each chart the next time the data is loaded.