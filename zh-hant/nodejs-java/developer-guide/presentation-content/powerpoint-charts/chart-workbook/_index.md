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
description: "探索適用於 Node.js via Java 的 Aspose.Slides：輕鬆在 PowerPoint 與 OpenDocument 格式中管理圖表工作簿，簡化簡報資料。"
---
## **概觀**

本文說明如何在 Aspose.Slides 中使用圖表工作簿。它展示了如何透過工作簿串流讀寫圖表資料、將工作簿儲存格作為圖表資料標籤、存取工作表集合，以及為圖表值指定資料來源類型。

它也涵蓋了將外部工作簿作為圖表資料來源的使用方式。範例示範了如何建立並指派外部工作簿、取得連結到圖表的外部工作簿路徑，以及在工作簿可用時編輯圖表資料。

若工作簿儲存格代表缺少的資料，請參閱[控制空儲存格的顯示](/slides/zh-hant/nodejs-java/chart-series/)瞭解空儲存格與零的差異，以及可用顯示模式的折線圖比較。

## **包含隱藏列與欄的資料**

使用[Chart.setPlotVisibleCellsOnly](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/#setPlotVisibleCellsOnly)控制圖表是否僅繪製隱藏工作表列與欄的資料。設定為 `true` 只繪製可見儲存格，設定為 `false` 則同時包含可見與隱藏儲存格。此設定僅影響圖表繪製，不會隱藏或取消隱藏工作表列或欄。

[範例簡報](hidden-source-data.pptx)的第一張投影片第一個圖形是一個柱狀圖。內嵌工作表 `Sheet1` 包含以下來源範圍 `A1:C4`。第 3 列與 C 欄被隱藏，但其儲存格仍有值。

| 工作表列 | A：月份 | B：零售 | C：批發（隱藏欄） |
| --- | --- | --- | --- |
| 2 | January | 10 | 30 |
| 3 (隱藏列) | February | 40 | 60 |
| 4 | March | 20 | 50 |

透過[ChartData.getChartDataWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/#getChartDataWorkbook)存取來源儲存格，並讀取[ChartDataCell.isHidden](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatacell/#isHidden)以檢查其隱藏狀態。此方法僅回報隱藏狀態，不會變更它。範例中，B2 為可見，B3 屬於隱藏列，C2 屬於隱藏欄；程式分別印出 `false`、`true`、`true`。

對於此範例，變更繪圖設定後需要重新整理圖表資料：使用[readWorkbookStream](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/#readWorkbookStream)保留內嵌工作簿，並以[writeWorkbookStream](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/#writeWorkbookStream)重新載入。若要包含所有儲存格，亦需使用[setRange](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/#setRange)還原完整範圍，包含隱藏的 February 分類。僅變更旗標不足以重新整理此樣本的快取圖表資料與分類標籤。範例在傳遞給寫入方法前，先將 Node.js 緩衝區轉換為 Java 位元組陣列。

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

            // 從內嵌工作簿重新整理圖表資料。
            chart.getChartData().writeWorkbookStream(workbookData);
            if (!visibleOnly) {
                // 復原完整的來源範圍，包含隱藏的分類。
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

此範例儲存兩個版本的簡報：一個僅含可見的 Retail 值 (10 與 20)，另一個則包含全部六個值。下方圖片說明兩種繪圖模式。第 3 列與 C 欄在兩個內嵌工作簿中皆保持隱藏。

| 僅顯示可見儲存格 (`true`) | 全部儲存格 (`false`) |
| --- | --- |
| ![僅顯示可見儲存格：January 與 March 的 Retail 值 10 與 20。](hidden_cells_True.png) | ![全部儲存格：January、February、March 的 Retail 與 Wholesale 值。](hidden_cells_False.png) |

隱藏的儲存格含值與空儲存格不同。[Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/#setDisplayBlanksAs)控制缺少值的顯示方式；它不會包含或排除隱藏的來源資料。請參閱[控制空儲存格的顯示](/slides/zh-hant/nodejs-java/chart-series/#control-the-display-of-empty-cells)取得示例。

## **取得圖表的資料範圍**

在更新現有簡報中的工作簿資料之前，先檢查來源範圍，以辨識每個圖表使用的工作表儲存格。[ChartData.getRange](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/#getRange)方法會回傳目前資料範圍的工作表限定公式，例如 `Sheet1!$A$1:$D$5`。此處 `Sheet1` 為工作表名稱，`!` 分隔工作表與儲存格範圍，`$A$1:$D$5` 表示包含 A1 至 D5 的儲存格。美元符號表示絕對列與欄參照。

此方法在不變更圖表或其工作簿的情況下讀取目前範圍。若圖表未使用工作簿作為資料來源，會拋出 `InvalidOperationException`。更多資訊請參閱[ChartData API 參考](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/)。

此範例開啟簡報，直接檢查每張投影片上的圖形是否為圖表。它會印出每個圖表的名稱與來源範圍。若圖表未使用工作簿，則印出訊息並繼續處理下一個圖表。

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

## **從工作簿讀寫圖表資料**

Aspose.Slides for Node.js via Java 提供[readWorkbookStream](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/#readWorkbookStream)與[writeWorkbookStream](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/#writeWorkbookStream)方法，讓您讀寫圖表工作簿（包含使用 Aspose.Cells 編輯的圖表資料）。**注意**：圖表資料必須以相同方式組織，或具備類似於來源的結構。

此範例使用第一張投影片第一個圖形為圖表的簡報。它將內嵌工作簿讀取為位元組陣列，清除現有系列與分類，然後將相同的工作簿寫回。變更保留在記憶體中；範例不會儲存簡報。

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

### **在工作簿修改後驗證圖表版面配置**

當您以修改過的工作簿取代內嵌工作簿時，圖表仍保留原始的系列與分類集合。此不匹配可能導致[Chart.validateChartLayout](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/#validateChartLayout)因索引超出範圍而失敗。寫回更新的工作簿之前，請先清除現有系列與分類。本範例使用第一張投影片第一個圖形為圖表。註解標示了工作簿編輯可能發生的位置；可執行範例將原始工作簿寫回並在記憶體中驗證版面配置。

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

        // 在此修改工作簿位元組，例如使用 Aspose.Cells.

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

清除集合可在寫回工作簿前移除過時的資料參考。於使用圖表前，請為更新後的工作簿重新建構任何必要的系列與分類對映。

## **將工作簿儲存格設為圖表資料標籤**

您可以使用工作簿儲存格中的文字作為圖表資料標籤。

此範例在現有簡報的第一張投影片加入預設資料的氣泡圖，使用工作表 0 的 A10:A12 作為第一系列前三個標籤，啟用來自儲存格的標籤，並儲存更新後的簡報。

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

## **管理工作表**

[ChartDataWorkbook.getWorksheets](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdataworkbook/#getWorksheets)方法提供對圖表工作簿中工作表的存取。此範例建立預設資料的圓餅圖，並將每個工作表名稱印至主控台。

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

## **指定資料來源類型**

此範例建立預設資料的 3D 柱狀圖，並使用不同的資料來源設定兩個系列名稱。第一個名稱使用字串常值；第二個名稱使用工作表 0 的 C1 儲存格。[DataSourceType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datasourcetype/)列舉決定每個名稱的來源。範例儲存簡報，包含更新後的系列名稱。

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

## **偵測不支援的內嵌工作簿格式**

Aspose.Slides 不支援可內嵌於某些圖表的 Excel 二進位工作簿（.xlsb）格式。您可以使用[ChartData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/)的[getEmbeddedWorkbookType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/#getEmbeddedWorkbookType)方法，搭配[WorkbookType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/workbooktype/)列舉，偵測不支援的格式並跳過那些圖表。此範例檢查現有簡報第一張投影片上的圖形，跳過非圖表圖形，並為每個含有內嵌 .xlsb 工作簿的圖表印出診斷訊息。

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

        // 在此讀取或修改支援的圖表工作簿資料。
    }
} finally {
    presentation.dispose();
}
```

## **外部工作簿**

Aspose.Slides 支援將外部工作簿作為圖表的資料來源。

### **建立外部工作簿**

使用[readWorkbookStream](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/#readWorkbookStream)與[setExternalWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/#setExternalWorkbook)將內嵌圖表工作簿匯出為檔案，並將圖表連結至該外部工作簿。

此範例建立預設資料的圓餅圖，並匯出其工作簿。完成檔案寫入後指派外部工作簿為圖表資料來源，最後儲存已連結的簡報。

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

### **設定外部工作簿**

使用[setExternalWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/#setExternalWorkbook)方法，您可以將外部工作簿指派給圖表作為資料來源。此方法亦可用於更新外部工作簿的路徑（如已搬移）。

雖然無法直接編輯儲存在遠端位置或資源中的工作簿資料，但仍可將此類工作簿用作外部資料來源。若提供相對路徑，系統會自動轉換為完整路徑。

此範例使用的外部工作簿，其工作表 `Sheet1` 包含 B1 的系列名稱、A2:A4 的分類名稱，以及 B2:B4 的數值。範例建立圓餅圖，連結工作簿，並使用[setRange](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/#setRange)將 A1:B4 對映為一個系列與三個分類。最後儲存包含已連結圖表的簡報。

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

[setExternalWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/#setExternalWorkbook) 的 `updateChartData` 參數控制是否載入工作簿。

* 當 `updateChartData` 為 `false` 時，僅更新工作簿路徑。圖表資料不會從目標工作簿載入或更新，因而工作簿可以不存在。
* 當 `updateChartData` 為 `true` 時，圖表資料會從目標工作簿更新。

以下範例將 `updateChartData` 設為 `false`，指派一個佔位 URL。它保留圓餅圖的預設資料，且在未載入不可用的工作簿時仍能儲存簡報。

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

### **取得圖表的外部資料來源工作簿路徑**

若要辨識連結到圖表的工作簿，請檢查圖表是否使用外部資料來源，並取得其工作簿路徑。

此範例檢查簡報第一張投影片的第一個圖形是否為連結外部工作簿的圖表，若是則將[getExternalWorkbookPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/#getExternalWorkbookPath)印至主控台，然後儲存簡報的副本。

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

### **編輯圖表資料**

您可以以與編輯內部工作簿相同的方式編輯外部工作簿的資料。若無法載入外部工作簿，會拋出例外。

此範例使用第一張投影片第一個圖形的圖表，且該圖表連結至可存取的外部工作簿。它將第一系列第一個資料點的儲存格值設為 100，並儲存更新後的簡報。編輯儲存格值可能會更新連結的外部 XLSX 檔案，若需保留原始工作簿，請使用副本。

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

### **從圖表快取中復原工作簿**

若圖表使用的外部工作簿缺少或無法使用，Aspose.Slides 可以從簡報中的快取資料重建圖表工作簿。建立[LoadOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/loadoptions/)，呼叫[LoadOptions.setSpreadsheetOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/loadoptions/#setSpreadsheetOptions)，並在開啟簡報前將[SpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/nodejs-java/aspose.slides/spreadsheetoptions/#setRecoverWorkbookFromChartCache) 設為 `true`。

以下 JavaScript 範例復原第一張投影片第一個圖形的圖表工作簿資料，該圖表參考了不可用的外部工作簿。它透過[Chart.getChartData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/#getChartData)與[ChartData.getChartDataWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/#getChartDataWorkbook)存取復原的資料：

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

        // 在此讀取或修改復原的工作簿資料。
    } else {
        console.log("The first shape is not a chart.");
    }
} finally {
    presentation.dispose();
}
```

若外部工作簿不可用且未啟用復原，Aspose.Slides 會拋出例外。僅在使用快取圖表資料為可接受的備援時才啟用復原，因為快取可能不包含外部工作簿最後一次更新後的變更。

## **常見問答**

**我可以判斷特定圖表是連結到外部工作簿還是內嵌工作簿嗎？**

可以。圖表具有[資料來源類型](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/#getDataSourceType)與[外部工作簿路徑](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/#getExternalWorkbookPath)；若來源是外部工作簿，您可以讀取完整路徑以確定使用的是外部檔案。

**是否支援相對路徑的外部工作簿，且它們如何儲存？**

支援。若您指定相對路徑，系統會自動轉換為絕對路徑。簡報會在 PPTX 檔案中儲存絕對路徑，因此搬移工作簿可能需要更新連結。

**可以使用位於網路資源/共用的工作簿嗎？**

可以，這類工作簿可作為外部資料來源。不過，直接從 Aspose.Slides 編輯遠端工作簿並不受支援——僅能作為來源使用。

**在儲存簡報時，Aspose.Slides 會覆寫外部 XLSX 嗎？**

簡報會儲存[指向外部檔案的連結](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/#getExternalWorkbookPath)。編輯以儲存格為基礎的圖表資料亦可能更新連結的本機 XLSX 檔案。如需保留原始工作簿，請使用其副本。

**如果外部檔案受密碼保護該怎麼辦？**

Aspose.Slides 連結時不接受密碼。常見做法是事前移除保護或先準備一個已解密的副本（例如使用[Aspose.Cells](https://reference.aspose.com/cells/java/)），再連結該副本。

**多個圖表可以參考同一個外部工作簿嗎？**

可以。每個圖表都會儲存各自的連結。若皆指向同一檔案，更新該檔案時下次載入資料時所有圖表都會反映變更。