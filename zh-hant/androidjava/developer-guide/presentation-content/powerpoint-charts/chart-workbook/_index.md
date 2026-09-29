---
title: 管理 Android 上簡報中的圖表活頁簿
linktitle: 圖表活頁簿
type: docs
weight: 70
url: /zh-hant/androidjava/chart-workbook/
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
- Android
- Java
- Aspose.Slides
description: "探索適用於 Android via Java 的 Aspose.Slides：輕鬆管理 PowerPoint 與 OpenDocument 格式中的圖表活頁簿，以簡化您的簡報資料。"
---
## **概覽**

本文說明如何在 Aspose.Slides 中使用圖表活頁簿。它展示了如何透過活頁簿串流讀寫圖表資料、使用活頁簿儲存格作為圖表資料標籤、存取工作表集合，以及為圖表值指定資料來源類型。

它還涵蓋了將外部活頁簿作為圖表資料來源的操作。範例示範如何建立與指派外部活頁簿、取得連結至圖表的外部活頁簿路徑，以及在活頁簿可用時編輯圖表資料。

對於代表缺少資料的活頁簿儲存格，請參閱[控制空白儲存格的顯示](/slides/zh-hant/androidjava/chart-series/)以了解空儲存格與零值之間的差異，以及可用顯示模式的折線圖比較。

## **包含隱藏列與欄的資料**

使用[IChart.setPlotVisibleCellsOnly](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ichart/#setPlotVisibleCellsOnly-boolean-)來控制圖表是否僅繪製可見工作表列與欄的資料。將其設為 `true` 只繪製可見儲存格，或設為 `false` 同時包含可見與隱藏儲存格。此設定僅影響圖表繪製；不會隱藏或取消隱藏工作表列與欄。

下載[hidden-source-data.pptx](hidden-source-data.pptx)並將其放在工作目錄中。其第一張投影片的第一個圖形是一個直條圖。內嵌工作表 `Sheet1` 包含以下來源範圍 `A1:C4`。第 3 列與 C 欄被隱藏，但其儲存格仍含有值。

| 工作表列 | A：月份 | B：零售 | C：批發（隱藏欄） |
| --- | --- | --- | --- |
| 2 | January | 10 | 30 |
| 3 (hidden row) | February | 40 | 60 |
| 4 | March | 20 | 50 |

透過[IChartData.getChartDataWorkbook](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ichartdata/#getChartDataWorkbook--)取得來源儲存格，並讀取[IChartDataCell.isHidden](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ichartdatacell/#isHidden--)以檢查其隱藏狀態。此方法僅回報隱藏狀態，不會改變它。在此檔案中，B2 為可見，B3 屬於隱藏列，C2 屬於隱藏欄；範例分別印出 `false`、`true`、`true`。

對於此範例，在變更繪製設定後請重新整理圖表資料：保留透過[readWorkbookStream](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ichartdata/#readWorkbookStream--)取得的內嵌活頁簿，並使用[writeWorkbookStream](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ichartdata/#writeWorkbookStream-byte:A-)重新載入。若要包含所有儲存格，亦請使用[setRange](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ichartdata/#setRange-java.lang.String-)還原完整範圍，包括隱藏的 February 類別。僅變更旗標不足以刷新此範例的快取圖表資料與類別標籤。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("hidden-source-data.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    int shapeCount = slide.getShapes().size();
    if (shapeCount > 0 && slide.getShapes().get_Item(0) instanceof IChart) {
        IChart chart = (IChart) slide.getShapes().get_Item(0);
        IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
        System.out.println("B2 hidden: " + workbook.getCell(0, "B2").isHidden());
        System.out.println("B3 hidden: " + workbook.getCell(0, "B3").isHidden());
        System.out.println("C2 hidden: " + workbook.getCell(0, "C2").isHidden());

        byte[] workbookData = chart.getChartData().readWorkbookStream();
        for (boolean visibleOnly : new boolean[] { true, false }) {
            chart.setPlotVisibleCellsOnly(visibleOnly);

            // 從內嵌活頁簿重新整理圖表資料。
            chart.getChartData().writeWorkbookStream(workbookData);
            if (!visibleOnly) {
                // 還原完整的來源範圍，包含隱藏的類別。
                chart.getChartData().setRange("Sheet1!$A$1:$C$4");
            }

            presentation.save("hidden_cells_" + visibleOnly + ".pptx", SaveFormat.Pptx);
        }
    } else {
        System.out.println("The first shape is not a chart.");
    }
} finally {
    presentation.dispose();
}
```

此範例將 `hidden_cells_true.pptx` 另存僅含可見的零售值 (10 與 20)，以及將 `hidden_cells_false.pptx` 另存含全部六個值。下方圖片說明兩種繪製模式。第 3 列與 C 欄在兩個內嵌活頁簿中皆保持隱藏。

| 只顯示可見儲存格 (`true`) | 顯示全部儲存格 (`false`) |
| --- | --- |
| ![只顯示可見儲存格：January 與 March 的零售值 10 與 20。](hidden_cells_True.png) | ![全部儲存格：January、February、March 的零售與批發值。](hidden_cells_False.png) |

含有值的隱藏儲存格不同於空儲存格。[IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ichart/#setDisplayBlanksAs-int-) 控制缺少值的顯示方式；不會包含或排除隱藏來源資料。請參閱[控制空白儲存格的顯示](/slides/zh-hant/androidjava/chart-series/#control-the-display-of-empty-cells)了解範例。

## **從活頁簿讀寫圖表資料**

Aspose.Slides for Android via Java 提供[readWorkbookStream](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ichartdata/#readWorkbookStream--)與[writeWorkbookStream](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ichartdata/#writeWorkbookStream-byte:A-)方法，讓您讀寫圖表資料活頁簿（可由 Aspose.Cells 編輯的圖表資料）。**注意**，圖表資料必須以相同方式組織，或結構須類似來源。

此範例開啟 `chart.pptx`（必須在第一張投影片的第一個圖形是圖表），將內嵌活頁簿讀取為位元組陣列，清除現有系列與類別，然後將相同的活頁簿寫回。變更保留在記憶體中，範例不會儲存簡報。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("chart.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    int shapeCount = slide.getShapes().size();
    if (shapeCount > 0 && slide.getShapes().get_Item(0) instanceof IChart) {
        IChart chart = (IChart) slide.getShapes().get_Item(0);
        IChartData chartData = chart.getChartData();
        byte[] workbookData = chartData.readWorkbookStream();

        chartData.getSeries().clear();
        chartData.getCategories().clear();

        chartData.writeWorkbookStream(workbookData);
    } else {
        System.out.println("The first shape is not a chart.");
    }
} finally {
    presentation.dispose();
}
```

### **在修改活頁簿後驗證圖表佈局**

當您以已修改的活頁簿取代內嵌活頁簿時，圖表仍保留原始的系列與類別集合。此不匹配可能導致[IChart.validateChartLayout](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ichart/#validateChartLayout--) 因索引超出範圍而失敗。寫回更新的活頁簿前請先清除現有系列與類別。本範例需要 `chart.pptx`（第一張投影片的第一個圖形為圖表）。註解標示活頁簿編輯之處；可執行範例將原始活頁簿寫回，並在記憶體中驗證佈局。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("chart.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    int shapeCount = slide.getShapes().size();
    if (shapeCount > 0 && slide.getShapes().get_Item(0) instanceof IChart) {
        IChart chart = (IChart) slide.getShapes().get_Item(0);
        IChartData chartData = chart.getChartData();
        byte[] workbookData = chartData.readWorkbookStream();

        // 在此處修改活頁簿位元組，例如使用 Aspose.Cells。

        chartData.getSeries().clear();
        chartData.getCategories().clear();

        chartData.writeWorkbookStream(workbookData);
        chart.validateChartLayout();
    } else {
        System.out.println("The first shape is not a chart.");
    }
} finally {
    presentation.dispose();
}
```

清除集合可在寫回活頁簿前移除過時的資料參照。於使用圖表前，請針對更新的活頁簿重新建構任何必要的系列與類別對應。

## **將活頁簿儲存格設為圖表資料標籤**

您可以使用活頁簿儲存格中的文字作為圖表資料標籤。以下步驟說明如何在氣泡圖中將標籤連結至資料活頁簿中的儲存格。

1. 建立[Presentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/presentation/)類別的實例。  
2. 以零基索引存取第一張投影片。  
3. 新增一個預設資料的氣泡圖。  
4. 取得圖表系列。  
5. 設定活頁簿儲存格為資料標籤。  
6. 儲存簡報。

此範例開啟 `chart2.pptx`（必須至少包含一張投影片），並新增一個預設資料的氣泡圖。它使用工作表 0 的 A10:A12 作為第一系列前三個標籤的儲存格，啟用從儲存格取得標籤，並將結果儲存為 `resultchart.pptx`。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("chart2.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Bubble, 50, 50, 600, 400, true);
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();

    series.getLabels().getDefaultDataLabelFormat().setShowLabelValueFromCell(true);
    series.getLabels().get_Item(0).setValueFromCell(workbook.getCell(0, "A10", "Label 0 cell value"));
    series.getLabels().get_Item(1).setValueFromCell(workbook.getCell(0, "A11", "Label 1 cell value"));
    series.getLabels().get_Item(2).setValueFromCell(workbook.getCell(0, "A12", "Label 2 cell value"));

    presentation.save("resultchart.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **管理工作表**

[IChartDataWorkbook.getWorksheets](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ichartdataworkbook/#getWorksheets--) 方法提供對圖表活頁簿中工作表的存取。本範例建立一個預設資料的圓餅圖，並將每個工作表名稱印至主控台。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Pie, 50, 50, 400, 500);
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();

    for (int i = 0; i < workbook.getWorksheets().size(); i++) {
        System.out.println(workbook.getWorksheets().get_Item(i).getName());
    }
} finally {
    presentation.dispose();
}
```

## **指定資料來源類型**

此範例建立一個預設資料的 3D 直條圖，並使用不同的資料來源設定兩個系列名稱。第一個名稱使用字串常值；第二個名稱使用工作表 0 的儲存格 C1。[DataSourceType](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/datasourcetype/) 列舉選擇每個名稱的來源。結果儲存為 `pres.pptx`。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Column3D, 50, 50, 600, 400, true);
    IStringChartValue literalName = chart.getChartData().getSeries().get_Item(0).getName();

    literalName.setDataSourceType(DataSourceType.StringLiterals);
    literalName.setData("LiteralString");

    IStringChartValue cellName = chart.getChartData().getSeries().get_Item(1).getName();
    IChartDataCell nameCell = chart.getChartData().getChartDataWorkbook().getCell(0, "C1", "NewCell");
    cellName.setDataSourceType(DataSourceType.Worksheet);
    cellName.setData(nameCell);

    presentation.save("pres.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **偵測不支援的內嵌活頁簿格式**

Aspose.Slides 不支援某些圖表可嵌入的 Excel 二進位活頁簿（.xlsb）格式。您可以在[IChartData](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ichartdata/) 上使用[getEmbeddedWorkbookType](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ichartdata/#getEmbeddedWorkbookType--) 方法，結合[WorkbookType](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/workbooktype/) 列舉，偵測不支援的格式並跳過那些圖表。此範例檢查 `sample.pptx` 第一張投影片的圖形，跳過非圖表圖形，並為每個帶有內嵌 .xlsb 活頁簿的圖表印出診斷訊息。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    for (IShape shape : slide.getShapes()) {
        if (!(shape instanceof IChart)) {
            continue;
        }

        IChart chart = (IChart) shape;
        IChartData chartData = chart.getChartData();
        boolean isInternalWorkbook = chartData.getDataSourceType() == ChartDataSourceType.InternalWorkbook;
        boolean isBinaryMacro = chartData.getEmbeddedWorkbookType() == WorkbookType.WorkbookBinaryMacro;

        if (isInternalWorkbook && isBinaryMacro) {
            System.out.println("Skipping a chart with an unsupported .xlsb workbook.");
            continue;
        }

        // 在此讀取或修改支援的圖表活頁簿資料。
    }
} finally {
    presentation.dispose();
}
```

## **外部活頁簿**

Aspose.Slides 支援將外部活頁簿作為圖表的資料來源。

### **建立外部活頁簿**

使用[readWorkbookStream](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ichartdata/#readWorkbookStream--)與[setExternalWorkbook](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ichartdata/#setExternalWorkbook-java.lang.String-)將內嵌圖表活頁簿匯出為檔案，並將圖表連結至該外部活頁簿。

此範例建立一個預設資料的圓餅圖，將其活頁簿寫入 `externalWorkbook1.xlsx`，並在指派檔案為圖表資料來源前完成檔案寫入。最後將已連結的簡報儲存為 `externalWorkbook.pptx`。

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.io.File;
import java.io.FileOutputStream;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Pie, 50, 50, 400, 600);
    File workbookFile = new File("externalWorkbook1.xlsx").getAbsoluteFile();
    byte[] workbookData = chart.getChartData().readWorkbookStream();
    try {
        try (FileOutputStream workbookStream = new FileOutputStream(workbookFile)) {
            workbookStream.write(workbookData);
        }
        chart.getChartData().setExternalWorkbook(workbookFile.getAbsolutePath());
        presentation.save("externalWorkbook.pptx", SaveFormat.Pptx);
    } catch (IOException exception) {
        System.out.println("Could not write the external workbook: " + exception.getMessage());
    }
} finally {
    presentation.dispose();
}
```

### **設定外部活頁簿**

使用[setExternalWorkbook](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ichartdata/#setExternalWorkbook-java.lang.String-) 方法，您可以將外部活頁簿指派給圖表作為其資料來源。此方法亦可用於更新外部活頁簿的路徑（若檔案已搬移）。

雖然無法直接編輯儲存在遠端位置或資源中的活頁簿資料，但仍可將此類活頁簿作為外部資料來源。若提供相對路徑，系統會自動轉換為完整路徑。

此範例需要工作目錄中有 `externalWorkbook.xlsx`。其工作表 `Sheet1` 必須在 B1 含系列名稱、A2:A4 含類別名稱，以及 B2:B4 含數值。範例建立圓餅圖、連結活頁簿，並使用[setRange](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ichartdata/#setRange-java.lang.String-) 將 A1:B4 對映為一個系列與三個類別。結果儲存為 `Presentation_with_externalWorkbook.pptx`。

```java
import com.aspose.slides.*;
import java.io.File;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Pie, 50, 50, 400, 600, true);
    IChartData chartData = chart.getChartData();
    File workbookFile = new File("externalWorkbook.xlsx");
    String workbookPath = workbookFile.getAbsolutePath();

    chartData.setExternalWorkbook(workbookPath);
    chartData.setRange("Sheet1!$A$1:$B$4");

    presentation.save("Presentation_with_externalWorkbook.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

[setExternalWorkbook](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ichartdata/#setExternalWorkbook-java.lang.String-boolean-) 的 `updateChartData` 參數控制是否載入活頁簿。

* 當 `updateChartData` 為 `false` 時，僅更新活頁簿路徑。圖表資料不會從目標活頁簿載入或更新，因而活頁簿可為無法取得的狀態。  
* 當 `updateChartData` 為 `true` 時，圖表資料會從目標活頁簿更新。

以下範例將佔位 URL 指派給 `updateChartData` 為 `false`。它保留圓餅圖的預設資料，且在未載入無法取得的活頁簿時儲存簡報。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Pie, 50, 50, 400, 600, true);
    chart.getChartData().setExternalWorkbook("https://example.com/unavailable-workbook.xlsx", false);

    presentation.save("SetExternalWorkbookWithUpdateChartData.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **取得圖表的外部資料來源活頁簿路徑**

若要識別連結至圖表的活頁簿，首先檢查圖表是否使用外部資料來源。若是，依以下步驟取得活頁簿路徑。

1. 建立[Presentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/presentation/) 類別的實例。  
2. 以零基索引存取第一張投影片。  
3. 確認第一個圖形是圖表。  
4. 讀取圖表資料來源類型。  
5. 若來源是外部活頁簿，讀取其路徑。

此範例開啟先前建立的 `externalWorkbook.pptx`，檢查第一張投影片的第一個圖形。若它是連結至外部活頁簿的圖表，範例會在主控台印出[getExternalWorkbookPath](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ichartdata/#getExternalWorkbookPath--)。然後將簡報的副本儲存為 `Result.pptx`。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("externalWorkbook.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    if (slide.getShapes().size() > 0 && slide.getShapes().get_Item(0) instanceof IChart) {
        IChart chart = (IChart) slide.getShapes().get_Item(0);
        IChartData chartData = chart.getChartData();
        if (chartData.getDataSourceType() == ChartDataSourceType.ExternalWorkbook) {
            System.out.println(chartData.getExternalWorkbookPath());
        } else {
            System.out.println("The chart does not use an external workbook.");
        }
    } else {
        System.out.println("The first shape is not a chart.");
    }

    presentation.save("Result.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **編輯圖表資料**

您可以以與編輯內部活頁簿相同的方式編輯外部活頁簿的資料。當外部活頁簿無法載入時，會拋出例外。

此範例需要 `presentation.pptx`（第一張投影片的第一個圖形為圖表）以及可存取的外部活頁簿。它將第一系列第一個資料點的儲存格值設為 100，並將簡報儲存為 `presentation_out.pptx`。編輯儲存格值會更新連結的外部 XLSX 檔案；如需保留原始活頁簿，請使用其副本。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    int shapeCount = slide.getShapes().size();
    if (shapeCount > 0 && slide.getShapes().get_Item(0) instanceof IChart) {
        IChart chart = (IChart) slide.getShapes().get_Item(0);
        IChartSeriesCollection series = chart.getChartData().getSeries();
        if (series.size() > 0 && series.get_Item(0).getDataPoints().size() > 0) {
            IChartDataCell valueCell = series.get_Item(0).getDataPoints().get_Item(0).getValue().getAsCell();
            if (valueCell != null) {
                valueCell.setValue(100);
                presentation.save("presentation_out.pptx", SaveFormat.Pptx);
            } else {
                System.out.println("The first data point is not linked to a workbook cell.");
            }
        } else {
            System.out.println("The chart has no data points to edit.");
        }
    } else {
        System.out.println("The first shape is not a chart.");
    }
} finally {
    presentation.dispose();
}
```

### **從圖表快取恢復活頁簿**

如果圖表使用的外部活頁簿遺失或無法取得，Aspose.Slides 可從簡報中的快取資料重建圖表活頁簿。建立[LoadOptions](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/loadoptions/)，呼叫[LoadOptions.setSpreadsheetOptions](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/loadoptions/#setSpreadsheetOptions-com.aspose.slides.ISpreadsheetOptions-)，並在開啟簡報前將[ISpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ispreadsheetoptions/#setRecoverWorkbookFromChartCache-boolean-) 設為 `true`。

以下 Java 範例開啟 `presentation.pptx`（其第一張投影片的第一個圖形必須是引用不可取得的外部活頁簿的圖表），並透過[IChart.getChartData](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ichart/#getChartData--) 以及[IChartData.getChartDataWorkbook](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ichartdata/#getChartDataWorkbook--) 取得恢復的資料：

```java
import com.aspose.slides.*;

SpreadsheetOptions spreadsheetOptions = new SpreadsheetOptions();
spreadsheetOptions.setRecoverWorkbookFromChartCache(true);

LoadOptions loadOptions = new LoadOptions();
loadOptions.setSpreadsheetOptions(spreadsheetOptions);

Presentation presentation = new Presentation("presentation.pptx", loadOptions);
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    int shapeCount = slide.getShapes().size();
    if (shapeCount > 0 && slide.getShapes().get_Item(0) instanceof IChart) {
        IChart chart = (IChart) slide.getShapes().get_Item(0);
        IChartDataWorkbook recoveredWorkbook = chart.getChartData().getChartDataWorkbook();

        // 在此讀取或修改已恢復的活頁簿資料。
    } else {
        System.out.println("The first shape is not a chart.");
    }
} finally {
    presentation.dispose();
}
```

如果外部活頁簿不可取得且未啟用恢復，Aspose.Slides 會拋出例外。僅在接受使用快取圖表資料作為可接受的備援時才啟用恢復，因為快取可能不包含外部活頁簿在簡報最後一次更新後所做的變更。

## **常見問答**

**我可以判斷特定圖表是連結至外部還是內嵌活頁簿嗎？**

可以。圖表具有[資料來源類型](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/chartdata/#getDataSourceType--)與[外部活頁簿路徑](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/chartdata/#getExternalWorkbookPath--)；若來源為外部活頁簿，您即可讀取完整路徑以確認使用的是外部檔案。

**是否支援相對路徑的外部活頁簿？它們如何儲存？**

支援。若指定相對路徑，系統會自動轉換為絕對路徑。簡報會在 PPTX 檔案中儲存絕對路徑，搬移活頁簿時可能需要更新連結。

**我可以使用位於網路資源/共享資料夾的活頁簿嗎？**

可以，這類活頁簿可作為外部資料來源使用。但 Aspose.Slides 不支援直接編輯遠端活頁簿——只能作為來源。

**儲存簡報時，Aspose.Slides 會覆寫外部 XLSX 嗎？**

簡報會儲存[外部檔案的連結](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/chartdata/#getExternalWorkbookPath--)。編輯由儲存格支援的圖表資料也可能會更新連結的本機 XLSX 檔案。若原始檔案必須保持不變，請使用其副本。

**如果外部檔案受密碼保護，我該怎麼辦？**

Aspose.Slides 連結時不接受密碼。常見做法是事先移除保護或先建立解密的副本（例如使用[Aspose.Cells](https://reference.aspose.com/cells/java/)），再連結至該副本。

**多個圖表可以參考同一個外部活頁簿嗎？**

可以。每個圖表都儲存自己的連結。若它們皆指向同一檔案，更新該檔案時下次載入資料會在所有圖表中反映出來。