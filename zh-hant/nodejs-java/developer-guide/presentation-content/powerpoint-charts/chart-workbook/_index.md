---
title: 使用 JavaScript 管理簡報中的圖表活頁簿
linktitle: 圖表活頁簿
type: docs
weight: 70
url: /zh-hant/nodejs-java/chart-workbook/
keywords:
- 圖表活頁簿
- 圖表資料
- 活頁簿儲存格
- 資料標籤
- 工作表
- 資料來源
- 外部活頁簿
- 外部資料
- 圖表快取
- 活頁簿復原
- PowerPoint
- 簡報
- Node.js
- JavaScript
- Aspose.Slides
description: "探索適用於 Node.js 的 Aspose.Slides（透過 Java）：輕鬆在 PowerPoint 與 OpenDocument 格式中管理圖表活頁簿，簡化您的簡報資料。"
---
## **概述**

本文說明如何在 Aspose.Slides 中使用圖表活頁簿，示範如何透過活頁簿串流讀寫圖表資料、使用活頁簿儲存格作為圖表資料標籤、存取工作表集合，並為圖表值指定資料來源類型。

亦涵蓋將外部活頁簿用作圖表資料來源的相關操作。範例展示如何建立與指派外部活頁簿、取得連結至圖表的外部活頁簿路徑，以及在活頁簿可用時編輯圖表資料。

## **從活頁簿讀寫圖表資料**

Aspose.Slides 提供 [readWorkbookStream](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/ChartData#readWorkbookStream--) 與 [writeWorkbookStream](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/ChartData#writeWorkbookStream-byte:A-) 方法，可讓您讀寫包含以 Aspose.Cells 編輯之圖表資料的活頁簿。**Note** 圖表資料必須以相同方式組織，或具備與來源相似的結構。

以下 JavaScript 程式碼示範一個範例操作：

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

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

### **驗證活頁簿變更後的圖表佈局**

當您以已修改的活頁簿取代內嵌活頁簿時，圖表會保留原本的系列與類別集合。此不匹配可能導致 [Chart.validateChartLayout](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/Chart#validateChartLayout--) 因索引超出範圍而失敗。寫入更新後的活頁簿之前，請先清除現有的系列與類別。

```javascript
// 修改工作簿串流後（例如使用 Aspose.Cells）
var updatedWorkbook = chartData.readWorkbookStream();

// 清除現有的資料參考。
chartData.getSeries().clear();
chartData.getCategories().clear();

chartData.writeWorkbookStream(updatedWorkbook);

chart.validateChartLayout();
```

清除集合可確保圖表資料結構與新活頁簿保持一致，使 `validateChartLayout` 能順利完成而不產生錯誤。

## **將活頁簿儲存格設為圖表資料標籤**

1. 建立一個 [Presentation](https://apireference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation) 類別的實例。  
1. 依索引取得投影片的參照。  
1. 新增一個含有資料的氣泡圖表。  
1. 取得圖表系列。  
1. 將活頁簿儲存格設為資料標籤。  
1. 儲存簡報。

以下 JavaScript 程式碼示範如何將活頁簿儲存格設為圖表資料標籤：

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var lbl0 = "Label 0 cell value";
var lbl1 = "Label 1 cell value";
var lbl2 = "Label 2 cell value";
// 實例化表示簡報檔案的簡報類別
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

以下 JavaScript 程式碼示範使用 [ChartDataWorkbook.getWorksheets](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/ChartDataWorkbook#getWorksheets--) 方法存取工作表集合的操作：

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

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
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

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

## **偵測不支援的內嵌活頁簿格式**

Aspose.Slides 不支援某些圖表中可能內嵌的 Excel 二進位活頁簿（.xlsb）格式。您可以對 [ChartData](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/chartdata/) 使用 `getEmbeddedWorkbookType` 方法，搭配 [WorkbookType](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/workbooktype/) 列舉，以偵測不支援的格式並略過該圖表。

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

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
            // 內嵌活頁簿為 .xlsb 格式，尚不支援。
            continue;
        }

        // 在此讀取或修改圖表活頁簿資料。
    }
} finally {
    presentation.dispose();
}
```

## **外部活頁簿**

Aspose.Slides 支援將外部活頁簿作為圖表的資料來源。

### **建立外部活頁簿**

使用 **`readWorkbookStream`** 與 **`setExternalWorkbook`** 方法，您可以從頭建立外部活頁簿，或將內部活頁簿轉為外部活頁簿。

以下 JavaScript 程式碼示範外部活頁簿的建立程序：

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const fileSystem = require("fs");

var pres = new aspose.slides.Presentation();
try {
    var workbookPath = "externalWorkbook1.xlsx";
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Pie, 50, 50, 400, 600);
    // readWorkbookStream 會以 Node Buffer 形式返回活頁簿位元組。
    var workbookData = chart.getChartData().readWorkbookStream();
    fileSystem.writeFileSync(workbookPath, Buffer.from(workbookData));
    chart.getChartData().setExternalWorkbook(workbookPath);
    pres.save("externalWorkbook.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **設定外部活頁簿**

使用 **`setExternalWorkbook`** 方法，您可以將外部活頁簿指派給圖表作為資料來源。此方法亦可用於更新外部活頁簿的路徑（若該檔案已搬移）。

雖然無法編輯儲存在遠端位置或資源中的活頁簿資料，但仍可將此類活頁簿用作外部資料來源。若提供相對路徑，系統會自動轉換為完整路徑。

以下 JavaScript 程式碼示範如何設定外部活頁簿：

```javascript
// 建立 Presentation 類別的實例
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

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

`setExternalWorkbook` 方法的第二個參數 `updateChartData` 會指示是否載入 Excel 活頁簿。

* 當 `updateChartData` 設為 `false` 時，僅會更新活頁簿路徑——圖表資料不會從目標活頁簿載入或更新。若目標活頁簿不存在或無法取得，建議使用此設定。  
* 當 `updateChartData` 設為 `true` 時，圖表資料會從目標活頁簿更新。

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

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

### **取得圖表外部資料來源活頁簿路徑**

1. 建立一個 [Presentation](https://apireference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation) 類別的實例。  
1. 依索引取得投影片的參照。  
1. 為圖表形狀建立物件。  
1. 為來源（`ChartDataSourceType`）類型建立物件，該類型代表圖表的資料來源。  
1. 依來源類型與外部活頁簿資料來源類型相同的條件，指定相關條件。

以下 JavaScript 程式碼示範此操作：

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

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

您可以以與編輯內部活頁簿相同的方式，修改外部活頁簿中的資料。若無法載入外部活頁簿，會拋出例外。

以下 JavaScript 程式碼為上述流程的實作範例：

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

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

### **從圖表快取中復原活頁簿**

如果圖表使用的外部活頁簿遺失或無法取得，Aspose.Slides 可以根據簡報中快取的資料重建圖表活頁簿。建立 [LoadOptions](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/loadoptions/)，以 [SpreadsheetOptions](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/spreadsheetoptions/) 進行設定，並在開啟簡報前呼叫 `SpreadsheetOptions.setRecoverWorkbookFromChartCache(true)`。

以下 JavaScript 範例開啟一個圖表參考不可用外部活頁簿的簡報，並透過 [ChartData.getChartDataWorkbook](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/chartdata/#getChartDataWorkbook) 存取復原的資料：

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

const spreadsheetOptions = new aspose.slides.SpreadsheetOptions();
spreadsheetOptions.setRecoverWorkbookFromChartCache(true);

const loadOptions = new aspose.slides.LoadOptions();
loadOptions.setSpreadsheetOptions(spreadsheetOptions);

const presentation = new aspose.slides.Presentation("presentation.pptx", loadOptions);
try {
    const chart = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const recoveredWorkbook = chart.getChartData().getChartDataWorkbook();

    // 在此讀取或修改已復原的活頁簿資料。
} finally {
    presentation.dispose();
}
```

若外部活頁簿不可用且未啟用復原，Aspose.Slides 會拋出例外。僅在接受以快取圖表資料作為可接受的備援時才啟用復原，因為快取可能不包含外部活頁簿在簡報最後一次更新之後的變更。

## **常見問題**

**我可以判斷特定圖表是連結到外部活頁簿還是內嵌活頁簿嗎？**

可以。圖表具有 [data source type](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/chartdata/getdatasourcetype/) 與 [path to an external workbook](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/chartdata/getexternalworkbookpath/)；若來源為外部活頁簿，您可以讀取完整路徑以確認正在使用外部檔案。

**是否支援外部活頁簿的相對路徑，且它們如何被儲存？**

支援。若指定相對路徑，系統會自動轉換為絕對路徑。這對專案可移植性很有幫助；但請留意簡報會在 PPTX 檔案中儲存絕對路徑。

**可以使用位於網路資源/共享的活頁簿嗎？**

可以，此類活頁簿可作為外部資料來源。然而，直接從 Aspose.Slides 編輯遠端活頁簿並不受支援——只能將其作為來源使用。

**Aspose.Slides 會在儲存簡報時覆寫外部 XLSX 嗎？**

不會。簡報只會儲存一個指向外部檔案的 [link to the external file](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/chartdata/getexternalworkbookpath/)，並在讀取資料時使用該連結。儲存簡報時不會修改外部檔案本身。

**如果外部檔案受密碼保護該怎麼辦？**

Aspose.Slides 連結時不接受密碼。常見做法是事先移除保護或先產生一個已解密的副本（例如使用 [Aspose.Cells](/cells/nodejs-java/)），再連結至該副本。

**多個圖表可以參考同一個外部活頁簿嗎？**

可以。每個圖表都會儲存自己的連結。若它們指向同一檔案，更新該檔案後，下次載入資料時所有圖表都會反映變更。