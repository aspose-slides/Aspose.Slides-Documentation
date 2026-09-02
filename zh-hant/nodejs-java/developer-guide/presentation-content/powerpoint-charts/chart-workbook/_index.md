---
title: 使用 JavaScript 管理簡報中的圖表工作簿
linktitle: 圖表工作簿
type: docs
weight: 70
url: /zh-hant/nodejs-java/chart-workbook/
keywords:
- 圖表工作簿
- 圖表資料
- 工作簿儲存格
- 資料標籤
- 工作表
- 資料來源
- 外部工作簿
- 外部資料
- 圖表快取
- 工作簿復原
- PowerPoint
- 簡報
- Node.js
- JavaScript
- Aspose.Slides
description: "透過 Java 探索 Aspose.Slides for Node.js：輕鬆管理 PowerPoint 與 OpenDocument 格式的圖表工作簿，簡化您的簡報資料。"
---
## **概述**

本文說明如何在 Aspose.Slides 中使用圖表工作簿。它展示了如何透過工作簿串流讀寫圖表資料、使用工作簿儲存格作為圖表資料標籤、存取工作表集合，以及為圖表值指定資料來源類型。

它還涵蓋了將外部工作簿作為圖表資料來源的使用方式。範例示範了如何建立與指派外部工作簿、取得連結至圖表的外部工作簿路徑，以及在工作簿可用時編輯圖表資料。

## **從工作簿讀寫圖表資料**

Aspose.Slides 提供了 [readWorkbookStream](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/ChartData#readWorkbookStream--) 與 [writeWorkbookStream](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/ChartData#writeWorkbookStream-byte:A-) 方法，允許您讀寫圖表資料工作簿（包含使用 Aspose.Cells 編輯的圖表資料）。**注意** 圖表資料必須以相同的方式組織，或具備與來源相似的結構。

以下 JavaScript 程式碼示範一個範例操作：

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

## **將工作簿儲存格設定為圖表資料標籤**

1. 建立 [Presentation](https://apireference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation) 類別的實例。
2. 透過索引取得投影片的參考。
3. 加入一個含有資料的 Bubble 圖表。
4. 存取圖表系列。
5. 將工作簿儲存格設定為資料標籤。
6. 儲存簡報。

以下 JavaScript 程式碼示範如何將工作簿儲存格設定為圖表資料標籤：

```javascript
var lbl0 = "Label 0 cell value";
var lbl1 = "Label 1 cell value";
var lbl2 = "Label 2 cell value";
// 實例化一個代表簡報檔案的簡報類別
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

## **管理工作表**

以下 JavaScript 程式碼示範一個使用 [ChartDataWorkbook.getWorksheets](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/ChartDataWorkbook#getWorksheets--) 方法存取工作表集合的操作：

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

## **指定資料來源類型**

以下 JavaScript 程式碼示範如何為資料來源指定類型：

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

## **偵測不支援的內嵌工作簿格式**

Aspose.Slides 不支援某些圖表中可能內嵌的 Excel 二進位工作簿 (.xlsb) 格式。您可以在 [ChartData](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/chartdata/) 上使用 `getEmbeddedWorkbookType` 方法，結合 [WorkbookType](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/workbooktype/) 列舉，以偵測不支援的格式並跳過這些圖表。

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
            // 內嵌工作簿為 .xlsb 格式，未受支援。
            continue;
        }

        // 在此讀取或修改圖表工作簿資料。
    }
} finally {
    presentation.dispose();
}
```

## **外部工作簿**

Aspose.Slides 支援將外部工作簿作為圖表的資料來源。

### **建立外部工作簿**

使用 **`readWorkbookStream`** 與 **`setExternalWorkbook`** 方法，您可以從頭建立外部工作簿，或將內部工作簿轉為外部工作簿。

以下 JavaScript 程式碼示範外部工作簿的建立過程：

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

### **設定外部工作簿**

使用 **`setExternalWorkbook`** 方法，您可以將外部工作簿指定為圖表的資料來源。此方法也可用於更新外部工作簿的路徑（如果該檔案已被移動）。

雖然您無法編輯儲存在遠端位置或資源中的工作簿資料，但仍可將此類工作簿用作外部資料來源。如果提供外部工作簿的相對路徑，系統會自動將其轉換為完整路徑。

以下 JavaScript 程式碼示範如何設定外部工作簿：

```javascript
// 建立 Presentation 類別的實例
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

`ChartData` 參數（位於 `setExternalWorkbook` 方法下）用於指定是否載入 Excel 工作簿。

* 當 `ChartData` 值設為 `false` 時，僅會更新工作簿路徑——圖表資料不會從目標工作簿載入或更新。當目標工作簿不存在或不可用時，您可能會使用此設定。
* 當 `ChartData` 值設為 `true` 時，圖表資料會從目標工作簿更新。

```javascript
// 建立 Presentation 類別的實例
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

### **取得圖表外部資料來源工作簿路徑**

1. 建立 [Presentation](https://apireference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation) 類別的實例。
2. 透過索引取得投影片的參考。
3. 建立圖表形狀的物件。
4. 建立代表圖表資料來源之來源類型 (`ChartDataSourceType`) 物件。
5. 根據來源類型與外部工作簿資料來源類型相同，指定相關條件。

以下 JavaScript 程式碼示範此操作：

```javascript
// 建立 Presentation 類別的實例
var pres = new aspose.slides.Presentation("chart.pptx");
try {
    var slide = pres.getSlides().get_Item(1);
    var chart = slide.getShapes().get_Item(0);
    var sourceType = chart.getChartData().getDataSourceType();
    if (sourceType == aspose.slides.ChartDataSourceType.ExternalWorkbook) {
        var path = chart.getChartData().getExternalWorkbookPath();
    }
    // 儲存簡報
    pres.save("result.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **編輯圖表資料**

您可以以與編輯內部工作簿內容相同的方式編輯外部工作簿的資料。當無法載入外部工作簿時，會拋出例外。

以下 JavaScript 程式碼實作上述流程：

```javascript
// 建立 Presentation 類別的實例
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

### **從圖表快取復原工作簿**

若圖表使用的外部工作簿遺失或無法使用，Aspose.Slides 可以從簡報中快取的資料重建圖表工作簿。於開啟簡報前，建立 [LoadOptions](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/loadoptions/)，使用 [SpreadsheetOptions](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/spreadsheetoptions/) 進行配置，並以 `true` 呼叫 [SpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/spreadsheetoptions/#setRecoverWorkbookFromChartCache)。

以下 JavaScript 範例開啟一個圖表參照不可用外部工作簿的簡報，並透過 [ChartData.getChartDataWorkbook](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/chartdata/#getChartDataWorkbook) 存取復原的資料：

```javascript
const spreadsheetOptions = new aspose.slides.SpreadsheetOptions();
spreadsheetOptions.setRecoverWorkbookFromChartCache(true);

const loadOptions = new aspose.slides.LoadOptions();
loadOptions.setSpreadsheetOptions(spreadsheetOptions);

const presentation = new aspose.slides.Presentation("presentation.pptx", loadOptions);
try {
    const chart = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const recoveredWorkbook = chart.getChartData().getChartDataWorkbook();

    // 在此讀取或修改復原的工作簿資料。
} finally {
    presentation.dispose();
}
```

若外部工作簿不可用且未啟用復原，Aspose.Slides 會拋出例外。僅當使用快取的圖表資料作為可接受的備援時才啟用復原，因為快取可能不包含簡報最後更新後對外部工作簿所做的變更。

## **常見問題**

**我可以判斷特定圖表是連結到外部工作簿還是內嵌工作簿嗎？**

是。圖表具有 [資料來源類型](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/chartdata/getdatasourcetype/) 和 [外部工作簿路徑](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/chartdata/getexternalworkbookpath/)；如果來源是外部工作簿，您可以讀取完整路徑以確保使用的是外部檔案。

**是否支援外部工作簿的相對路徑，且它們如何儲存？**

是。若指定相對路徑，系統會自動轉換為絕對路徑。這對專案可移植性很方便；但請注意，簡報會在 PPTX 檔案中儲存絕對路徑。

**我可以使用位於網路資源/共享上的工作簿嗎？**

是，這類工作簿可作為外部資料來源使用。但不支援直接從 Aspose.Slides 編輯遠端工作簿——只能作為來源使用。

**Aspose.Slides 在儲存簡報時會覆寫外部 XLSX 嗎？**

不會。簡報會儲存對外部檔案的 [外部檔案的連結](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/chartdata/getexternalworkbookpath/) 並用於讀取資料。儲存簡報時不會修改外部檔案本身。

**如果外部檔案有密碼保護，我該怎麼辦？**

Aspose.Slides 在連結時不接受密碼。常見做法是事先移除保護或準備一個已解密的副本（例如使用 [Aspose.Cells](/cells/nodejs-java/)），再連結至該副本。

**多個圖表可以參照同一個外部工作簿嗎？**

是。每個圖表都儲存自己的連結。若它們皆指向同一檔案，更新該檔案後，在下一次載入資料時，所有圖表皆會反映變更。