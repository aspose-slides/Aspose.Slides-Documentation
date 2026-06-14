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
- PowerPoint
- 簡報
- Node.js
- JavaScript
- Aspose.Slides
description: "探索適用於 Node.js 的 Aspose.Slides（透過 Java）：輕鬆在 PowerPoint 與 OpenDocument 格式中管理圖表工作簿，簡化簡報資料。"
---
## **概觀**

本文說明如何在 Aspose.Slides 中使用圖表工作簿。它展示了如何透過工作簿串流讀寫圖表資料、使用工作簿儲存格作為圖表資料標籤、存取工作表集合，以及為圖表值指定資料來源類型。

此外，本文還涵蓋了使用外部工作簿作為圖表資料來源的情況。示例示範了如何建立並指派外部工作簿、取得連結至圖表的外部工作簿路徑，以及在工作簿可用時編輯圖表資料。

## **從工作簿讀寫圖表資料**

Aspose.Slides 提供 [readWorkbookStream](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/ChartData#readWorkbookStream--) 與 [writeWorkbookStream](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/ChartData#writeWorkbookStream-byte:A-) 方法，允許您讀寫包含以 Aspose.Cells 編輯之圖表資料的工作簿。**Note** 圖表資料必須以相同方式組織，或具備與來源相似的結構。

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

## **將工作簿儲存格設為圖表資料標籤**

1. 建立 [Presentation](https://apireference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation) 類別的執行個體。  
2. 取得投影片之索引對應的參考。  
3. 新增一個含有資料的 Bubble 圖表。  
4. 存取圖表系列。  
5. 將工作簿儲存格設為資料標籤。  
6. 儲存簡報。

以下 JavaScript 程式碼示範如何將工作簿儲存格設定為圖表資料標籤：

```javascript
var lbl0 = "Label 0 cell value";
var lbl1 = "Label 1 cell value";
var lbl2 = "Label 2 cell value";
// 實例化代表簡報檔案的簡報類別
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

Aspose.Slides 不支援某些圖表內嵌的 Excel 二進位工作簿（.xlsb）格式。您可以在 [ChartData](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/chartdata/) 上使用 `getEmbeddedWorkbookType` 方法，配合 [WorkbookType](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/workbooktype/) 列舉，來偵測不支援的格式並跳過這些圖表。

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
            // 嵌入式工作簿是 .xlsb 格式，不受支援。
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

以下 JavaScript 程式碼示範外部工作簿的建立流程：

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

使用 **`setExternalWorkbook`** 方法，您可以將外部工作簿指派給圖表作為其資料來源。此方法亦可用於更新外部工作簿的路徑（若該工作簿已被移動）。

雖然無法編輯儲存在遠端位置或資源中的工作簿資料，但仍可將這類工作簿作為外部資料來源使用。若提供相對路徑，系統會自動轉換為完整路徑。

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

* 當 `ChartData` 值設定為 `false` 時，僅會更新工作簿路徑——圖表資料不會從目標工作簿載入或更新。若目標工作簿不存在或無法取得時，可使用此設定。  
* 當 `ChartData` 值設定為 `true` 時，圖表資料將從目標工作簿更新。

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

1. 建立 [Presentation](https://apireference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation) 類別的執行個體。  
2. 取得投影片之索引對應的參考。  
3. 建立圖表形狀的物件。  
4. 建立代表圖表資料來源之來源類型（`ChartDataSourceType`）的物件。  
5. 依據來源類型與外部工作簿資料來源類型相同，指定相關條件。

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

您可以像編輯內部工作簿內容一樣編輯外部工作簿的資料。若無法載入外部工作簿，將拋出例外。

以下 JavaScript 程式碼為上述流程的實作範例：

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

## **常見問題**

**我能判斷特定圖表是連結至外部工作簿還是內嵌工作簿嗎？**

是的。圖表具有[data source type](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/chartdata/getdatasourcetype/)和[path to an external workbook](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/chartdata/getexternalworkbookpath/)；若來源為外部工作簿，您可以讀取完整路徑以確保使用的是外部檔案。

**是否支援外部工作簿的相對路徑，且它們如何被儲存？**

是。若指定相對路徑，系統會自動轉換為絕對路徑。此方式有助於專案可移植性；但請注意，簡報會將絕對路徑寫入 PPTX 檔案中。

**我可以使用位於網路資源/共享上的工作簿嗎？**

可以，這類工作簿可作為外部資料來源使用。但不支援直接在 Aspose.Slides 中編輯遠端工作簿——只能作為來源使用。

**Aspose.Slides 在儲存簡報時會覆寫外部 XLSX 嗎？**

不會。簡報會儲存[外部檔案的連結](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/chartdata/getexternalworkbookpath/)，僅用於讀取資料；儲存簡報時不會修改外部檔案本身。

**如果外部檔案受密碼保護，我該怎麼做？**

Aspose.Slides 在連結時不接受密碼。常見的做法是事先解除保護，或事先準備一個已解密的副本（例如使用 [Aspose.Cells](/cells/nodejs-java/)），再連結至該副本。

**多個圖表可以參考同一個外部工作簿嗎？**

可以。每個圖表都會儲存自己的連結。若它們都指向相同檔案，更新該檔案後，下一次載入資料時各圖表皆會反映變更。