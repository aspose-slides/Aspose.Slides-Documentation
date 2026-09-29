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
description: "探索 Aspose.Slides for Node.js via Java：輕鬆管理 PowerPoint 與 OpenDocument 格式的圖表工作簿，以簡化您的簡報資料。"
---
## **概覽**

本文章說明如何在 Aspose.Slides 中使用圖表工作簿。它展示了如何透過工作簿串流讀寫圖表資料、使用工作簿儲存格作為圖表資料標籤、存取工作表集合，以及為圖表值指定資料來源類型。

此外也涵蓋了使用外部工作簿作為圖表資料來源的情況。範例示範如何建立並指派外部工作簿、取得連結至圖表的外部工作簿路徑，以及在工作簿可用時編輯圖表資料。

若工作簿儲存格代表缺失資料，請參閱[控制空儲存格的顯示](/slides/zh-hant/nodejs-java/chart-series/)，了解空儲存格與零的差異，以及可用顯示模式的折線圖比較。

## **包含隱藏列與行的資料**

使用[Chart.setPlotVisibleCellsOnly](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/chart/#setPlotVisibleCellsOnly) 來控制圖表是否僅繪製隱藏工作表列與行的資料。設定為 `true` 時僅繪製可見儲存格，設定為 `false` 時同時包含可見與隱藏的儲存格。此設定僅影響圖表的繪製，並不會隱藏或取消隱藏工作表列與欄。

下載 [hidden-source-data.pptx](hidden-source-data.pptx) 並將其放置於工作目錄。其第一張投影片的第一個圖形是一個柱狀圖。內嵌工作表 `Sheet1` 包含以下來源範圍 `A1:C4`。第 3 列與 C 欄被隱藏，但其儲存格仍有值。

| 工作表列 | A: 月份 | B: 零售 | C: 批發（隱藏欄） |
| --- | --- | --- | --- |
| 2 | January | 10 | 30 |
| 3 (hidden row) | February | 40 | 60 |
| 4 | March | 20 | 50 |

透過[ChartData.getChartDataWorkbook](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/chartdata/#getChartDataWorkbook) 取得來源儲存格，並讀取[ChartDataCell.isHidden](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/chartdatacell/#isHidden) 以檢查其隱藏狀態。此方法僅回報隱藏狀態而不會改變它。在此範例中，B2 為可見，B3 屬於隱藏列，C2 屬於隱藏欄；範例分別印出 `false`、`true`、`true`。

此範例在變更繪圖設定後，請重新整理圖表資料：保留使用[readWorkbookStream](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/chartdata/#readWorkbookStream) 讀取的內嵌工作簿，並使用[writeWorkbookStream](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/chartdata/#writeWorkbookStream) 重新載入。若要包含所有儲存格，還需使用[setRange](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/chartdata/#setRange) 以恢復完整範圍（包含隱藏的 February 類別）。僅變更旗標不足以重新整理此範例的快取圖表資料與類別標籤。範例在傳遞給寫入方法前，先將 Node.js 緩衝區轉換為 Java 位元組陣列。

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
                // 還原完整來源範圍，包含隱藏的類別。
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

此範例將 `hidden_cells_true.pptx` 儲存為僅包含可見的 Retail 值 (10 與 20)，將 `hidden_cells_false.pptx` 儲存為全部六個值。下圖說明兩種繪圖模式。第 3 列與 C 欄在兩個內嵌工作簿中均保持隱藏。

| 只顯示可見儲存格 (`true`) | 顯示全部儲存格 (`false`) |
| --- | --- |
| ![Only visible cells: Retail values 10 and 20 for January and March.](hidden_cells_True.png) | ![All cells: Retail and Wholesale values for January, February, and March.](hidden_cells_False.png) |

包含值的隱藏儲存格不同於空儲存格。[Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/chart/#setDisplayBlanksAs) 控制缺失值的顯示方式，並不會包含或排除隱藏的來源資料。請參閱[控制空儲存格的顯示](/slides/zh-hant/nodejs-java/chart-series/#control-the-display-of-empty-cells) 了解範例。

## **從工作簿讀寫圖表資料**

Aspose.Slides for Node.js via Java 提供[readWorkbookStream](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/chartdata/#readWorkbookStream) 與[writeWorkbookStream](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/chartdata/#writeWorkbookStream) 方法，讓您讀寫圖表工作簿（包含使用 Aspose.Cells 編輯的圖表資料）。**注意** 圖表資料必須以相同方式組織，或須具備與來源相似的結構。

此範例開啟 `chart.pptx`（必須在第一張投影片的第一個圖形為圖表），將內嵌工作簿讀取為位元組陣列，清除現有的系列與類別，然後將相同的工作簿寫回。變更保留於記憶體中；範例不會儲存簡報。

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

當您以修改過的工作簿取代內嵌工作簿時，圖表仍保留原始的系列與類別集合。此不匹配可能導致[Chart.validateChartLayout](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/chart/#validateChartLayout) 失敗並拋出索引超出範圍的錯誤。寫回更新後的工作簿前，請先清除現有的系列與類別。此範例需要 `chart.pptx`（第一張投影片的第一個圖形為圖表）。註解標示了工作簿編輯的地方；可執行的範例將原始工作簿寫回，並在記憶體中驗證版面配置。

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

清除集合會在寫回工作簿前移除過時的資料參考。在使用圖表前，請為更新的工作簿重新建構任何必要的系列與類別對映。

## **將工作簿儲存格設定為圖表資料標籤**

您可以將工作簿儲存格的文字作為圖表資料標籤。以下步驟說明如何在氣泡圖中將標籤連結至資料工作簿的儲存格。

1. 建立[Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation/) 類別的實例。  
1. 以零基索引存取第一張投影片。  
1. 加入預設資料的氣泡圖。  
1. 取得圖表系列。  
1. 設定工作簿儲存格為資料標籤。  
1. 儲存簡報。

此範例開啟 `chart2.pptx`（必須至少有一張投影片），並加入預設資料的氣泡圖。它使用工作表 0 的儲存格 A10:A12 作為第一系列前三個標籤，啟用來自儲存格的標籤，最後將結果儲存為 `resultchart.pptx`。

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

[ChartDataWorkbook.getWorksheets](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/chartdataworkbook/#getWorksheets) 方法提供存取圖表工作簿中的工作表。本範例建立預設資料的圓餅圖，並將每個工作表名稱印出至主控台。

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

此範例建立預設資料的 3D 柱狀圖，並使用不同的資料來源設定兩個系列名稱。第一個名稱使用字串常量；第二個名稱使用工作表 0 的儲存格 C1。[DataSourceType](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/datasourcetype/) 列舉決定每個名稱的來源。結果儲存為 `pres.pptx`。

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

## **偵測不受支援的內嵌工作簿格式**

Aspose.Slides 不支援可嵌入於某些圖表的 Excel 二進制工作簿（.xlsb）格式。您可以在[ChartData](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/chartdata/) 上使用[getEmbeddedWorkbookType](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/chartdata/#getEmbeddedWorkbookType) 方法，搭配[WorkbookType](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/workbooktype/) 列舉，偵測不受支援的格式並跳過這些圖表。此範例檢查 `sample.pptx` 第一張投影片的所有形狀，跳過非圖表形狀，並對每個內嵌 .xlsb 工作簿的圖表列印診斷訊息。

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

        // 在此讀取或修改受支援的圖表工作簿資料。
    }
} finally {
    presentation.dispose();
}
```

## **外部工作簿**

Aspose.Slides 支援使用外部工作簿作為圖表的資料來源。

### **建立外部工作簿**

使用[readWorkbookStream](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/chartdata/#readWorkbookStream) 與[setExternalWorkbook](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/chartdata/#setExternalWorkbook) 將內嵌圖表工作簿匯出為檔案，並將圖表連結至該外部工作簿。

此範例建立預設資料的圓餅圖，將其工作簿寫入 `externalWorkbook1.xlsx`，完成檔案寫入後指派該檔案為圖表資料來源，最後將連結的簡報儲存為 `externalWorkbook.pptx`。

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

使用[setExternalWorkbook](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/chartdata/#setExternalWorkbook) 方法，您可以將外部工作簿指派給圖表作為資料來源。此方法亦可用於更新外部工作簿的路徑（若檔案已搬移）。

雖然無法直接編輯儲存在遠端位置或資源中的工作簿資料，但仍可將此類工作簿作為外部資料來源。若提供相對路徑，系統會自動轉換為完整路徑。

此範例需要工作目錄中存在 `externalWorkbook.xlsx`。其工作表 `Sheet1` 必須在 B1 包含系列名稱、A2:A4 包含類別名稱、B2:B4 包含數值。範例建立圓餅圖、連結工作簿，並使用[setRange](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/chartdata/#setRange) 將 A1:B4 映射為一個系列與三個類別。結果儲存為 `Presentation_with_externalWorkbook.pptx`.

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

[setExternalWorkbook](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/chartdata/#setExternalWorkbook) 的 `updateChartData` 參數決定是否載入工作簿。

* 當 `updateChartData` 為 `false` 時，僅更新工作簿路徑。圖表資料不會從目標工作簿載入或更新，因此工作簿可能不存在。  
* 當 `updateChartData` 為 `true` 時，圖表資料會從目標工作簿更新。

以下範例以 `updateChartData` 設為 `false`，指派一個佔位 URL。它保留圓餅圖的預設資料，且在未載入不可用的工作簿情況下儲存簡報。

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

要辨識連結至圖表的工作簿，首先檢查圖表是否使用外部資料來源。如果是，您可以依照下列步驟取得工作簿路徑。

1. 建立[Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation/) 類別的實例。  
1. 以零基索引存取第一張投影片。  
1. 確認第一個圖形是圖表。  
1. 讀取圖表資料來源類型。  
1. 若來源為外部工作簿，讀取其路徑。

此範例開啟先前建立的 `externalWorkbook.pptx`，檢查第一張投影片的第一個圖形。如果它是連結至外部工作簿的圖表，範例會將[getExternalWorkbookPath](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/chartdata/#getExternalWorkbookPath) 印出至主控台，然後將簡報複本儲存為 `Result.pptx`。

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

您可以像編輯內部工作簿內容一樣編輯外部工作簿的資料。若外部工作簿無法載入，系統會拋出例外。

此範例需要 `presentation.pptx`（第一張投影片的第一個圖形為圖表）以及可存取的外部工作簿。它將第一系列第一個資料點的儲存格值設為 100，並將簡報儲存為 `presentation_out.pptx`。編輯儲存格值會更新連結的外部 XLSX 檔案，若需保留原始工作簿，請使用備份檔案。

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

### **從圖表快取還原工作簿**

如果圖表使用的外部工作簿遺失或無法取得，Aspose.Slides 可以從簡報中的快取資料重建圖表工作簿。建立 [LoadOptions](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/loadoptions/)，呼叫 [LoadOptions.setSpreadsheetOptions](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/loadoptions/#setSpreadsheetOptions)，並在開啟簡報前將 [SpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/spreadsheetoptions/#setRecoverWorkbookFromChartCache) 設為 `true`。

以下 JavaScript 範例開啟 `presentation.pptx`（第一張投影片的第一個圖形必須是參考不可用外部工作簿的圖表），並透過 [Chart.getChartData](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/chart/#getChartData) 與 [ChartData.getChartDataWorkbook](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/chartdata/#getChartDataWorkbook) 取得復原的資料：

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

        // 在此讀取或修改已復原的工作簿資料。
    } else {
        console.log("The first shape is not a chart.");
    }
} finally {
    presentation.dispose();
}
```

若外部工作簿不可用且未啟用復原，Aspose.Slides 會拋出例外。僅在接受使用快取圖表資料作為後備時才啟用復原，因為快取資料可能不包含外部工作簿在最後一次更新簡報後所做的變更。

## **常見問與答**

**我能判斷特定圖表是連結至外部工作簿還是內嵌工作簿嗎？**  
可以。圖表具有[資料來源類型](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/chartdata/#getDataSourceType) 與[外部工作簿路徑](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/chartdata/#getExternalWorkbookPath)；若來源為外部工作簿，您可以讀取完整路徑以確認使用了外部檔案。

**是否支援相對路徑的外部工作簿，且它們如何儲存？**  
支援。若提供相對路徑，系統會自動轉換為絕對路徑。簡報會在 PPTX 檔案中儲存絕對路徑，因此搬移工作簿可能需要更新連結。

**我可以使用位於網路資源/共享的工作簿嗎？**  
可以，這類工作簿可作為外部資料來源。但 Aspose.Slides 不支援直接編輯遠端工作簿——只能作為來源使用。

**儲存簡報時，Aspose.Slides 會覆寫外部 XLSX 嗎？**  
簡報會儲存一個[指向外部檔案的連結](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/chartdata/#getExternalWorkbookPath)。編輯以儲存格為基礎的圖表資料也可能會更新本機的外部 XLSX 檔案。若原始檔案必須保持不變，請使用該工作簿的副本。

**若外部檔案受密碼保護該怎麼辦？**  
Aspose.Slides 在建立連結時不接受密碼。常見做法是事先移除保護或先準備一個已解密的副本（例如使用 [Aspose.Cells](https://reference.aspose.com/cells/java/)），再連結至該副本。

**多個圖表可以參考同一個外部工作簿嗎？**  
可以。每個圖表都會儲存自己的連結。如果它們指向相同檔案，更新該檔案後，下次載入資料時所有圖表皆會反映變更。