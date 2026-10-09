---
title: 在 Android 上管理簡報中的圖表工作簿
linktitle: 圖表工作簿
type: docs
weight: 70
url: /zh-hant/androidjava/chart-workbook/
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
- Android
- Java
- Aspose.Slides
description: "探索 Aspose.Slides for Android via Java：輕鬆在 PowerPoint 和 OpenDocument 格式中管理圖表工作簿，簡化您的簡報資料。"
---
## **概觀**

本文說明如何在 Aspose.Slides 中使用圖表工作簿。它展示了如何透過工作簿串流讀寫圖表資料、使用工作簿儲存格作為圖表資料標籤、存取工作表集合，以及為圖表值指定資料來源類型。

本文亦涵蓋使用外部工作簿作為圖表資料來源的情況。範例示範了如何建立與指派外部工作簿、取得連結至圖表的外部工作簿路徑，以及在工作簿可用時編輯圖表資料。

若工作簿儲存格代表缺失資料，請參閱[控制空白儲存格的顯示](/slides/zh-hant/androidjava/chart-series/)以了解空儲存格與零的差異，以及可用顯示模式的折線圖比較。

## **包括隱藏列與欄的資料**

使用[IChart.setPlotVisibleCellsOnly](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#setPlotVisibleCellsOnly-boolean-)來控制圖表是否繪製隱藏工作表列與欄的資料。將其設為 `true` 只繪製可見儲存格，或 `false` 同時包含可見與隱藏儲存格。此設定僅影響圖表繪製；不會隱藏或取消隱藏工作表列或欄。

[示範簡報](hidden-source-data.pptx)的第一張投影片第一個圖形是一個直條圖。內嵌工作表 `Sheet1` 的來源範圍為 `A1:C4`。第 3 列與 C 欄被隱藏，但其儲存格仍包含值。

| 工作表列 | A: 月份 | B: 零售 | C: 批發（隱藏欄） |
| --- | --- | --- | --- |
| 2 | 一月 | 10 | 30 |
| 3（隱藏列） | 二月 | 40 | 60 |
| 4 | 三月 | 20 | 50 |

透過[IChartData.getChartDataWorkbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#getChartDataWorkbook--)存取來源儲存格，並使用[IChartDataCell.isHidden](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatacell/#isHidden--)檢查其隱藏狀態。此方法僅回報隱藏狀態，不會變更它。在此範例中，B2 為可見，B3 屬於隱藏列，C2 屬於隱藏欄；範例分別印出 `false`、`true`、`true`。

此範例在變更繪製設定後，請先使用[readWorkbookStream](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#readWorkbookStream--)讀取內嵌工作簿，然後以[writeWorkbookStream](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#writeWorkbookStream-byte---)重新載入。若要包含所有儲存格，亦需使用[setRange](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#setRange-java.lang.String-)復原完整範圍，包含隱藏的二月類別。僅變更旗標不足以重新整理此樣本的快取圖表資料與類別標籤。

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

            // 從嵌入式工作簿重新整理圖表資料。
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

此範例儲存兩個版本的簡報：一個僅包含可見的零售值 (10 與 20)，另一個則包含全部六個值。下方影像說明兩種繪製模式。第 3 列與 C 欄在兩個內嵌工作簿中皆保持隱藏。

| 僅可見儲存格（`true`） | 所有儲存格（`false`） |
| --- | --- |
| ![僅可見儲存格：一月與三月的零售值 10 與 20。](hidden_cells_True.png) | ![所有儲存格：一月、二月與三月的零售與批發值。](hidden_cells_False.png) |

包含值的隱藏儲存格不同於空儲存格。[IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#setDisplayBlanksAs-int-)控制缺失值的顯示方式；它不會包含或排除隱藏的來源資料。請參閱[控制空白儲存格的顯示](/slides/zh-hant/androidjava/chart-series/#control-the-display-of-empty-cells)以取得範例說明。

## **取得圖表的資料範圍**

在更新現有簡報中的工作簿資料之前，請先檢查來源範圍，以識別每個圖表使用的工作表儲存格。[IChartData.getRange](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#getRange--) 方法會以工作表限定的公式回傳目前的資料範圍，例如 `Sheet1!$A$1:$D$5`。此處 `Sheet1` 為工作表名稱，`!` 分隔名稱與儲存格範圍，`$A$1:$D$5` 表示從 A1 到 D5（含）的絕對參照。

此方法僅讀取目前範圍，不會變更圖表或其工作簿。若圖表未使用工作簿作為資料來源，會拋出 `InvalidOperationException`。更多資訊請參閱[ChartData API 參考](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chartdata/)。

此範例開啟簡報，直接檢查每張投影片上的圖形是否為圖表，並列印每個圖表的名稱與來源範圍。若圖表未使用工作簿，則印出訊息並繼續檢查下一個圖表。

```java
import com.aspose.slides.*;
import com.aspose.slides.exceptions.InvalidOperationException;

Presentation presentation = new Presentation("presentation.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        for (IShape shape : slide.getShapes()) {
            if (shape instanceof IChart) {
                IChart chart = (IChart) shape;
                try {
                    String range = chart.getChartData().getRange();
                    System.out.println(chart.getName() + ": " + range);
                } catch (InvalidOperationException exception) {
                    System.out.println(chart.getName() + ": The chart does not use a workbook as its data source.");
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

## **從工作簿讀寫圖表資料**

Aspose.Slides for Android via Java 提供[readWorkbookStream](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#readWorkbookStream--)與[writeWorkbookStream](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#writeWorkbookStream-byte---) 方法，以讀取和寫入含有 Aspose.Cells 編輯之圖表資料的工作簿。**注意** 圖表資料必須以相同方式組織，或結構類似於來源。

此範例使用第一張投影片第一個圖形為圖表的簡報。它將內嵌工作簿讀取為位元組陣列，清除現有的系列與類別，然後將相同的工作簿寫回。變更保留在記憶體中，範例不會儲存簡報。

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

### **在工作簿修改後驗證圖表佈局**

當以修改過的工作簿取代內嵌工作簿時，圖表仍保留原始的系列與類別集合。此不匹配可能導致[IChart.validateChartLayout](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#validateChartLayout--) 因索引超出範圍而失敗。請在寫回更新的工作簿之前先清除現有的系列與類別。本範例使用第一張投影片第一個圖形的圖表。註解標示了工作簿編輯會發生的地方；可執行的範例寫回原始工作簿並在記憶體中驗證佈局。

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

        // 在此修改工作簿位元組，例如使用 Aspose.Cells.

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

清除集合可在寫回工作簿前移除陳舊的資料參考。於使用圖表前，請為更新後的工作簿重新建構所需的系列與類別對應。

## **將工作簿儲存格設為圖表資料標籤**

您可以使用工作簿儲存格中的文字作為圖表資料標籤。

此範例在既有簡報的第一張投影片加入一個含預設資料的氣泡圖，使用工作表 0 上的儲存格 A10:A12 作為第一系列的前三個標籤，啟用從儲存格取得標籤，並儲存更新後的簡報。

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

[IChartDataWorkbook.getWorksheets](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdataworkbook/#getWorksheets--) 方法提供對圖表工作簿中工作表的存取。本範例建立一個含預設資料的圓餅圖，並將每個工作表名稱印至主控台。

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

此範例建立一個含預設資料的 3D 直條圖，並使用不同的資料來源設定兩個系列名稱。第一個名稱使用字串常值；第二個名稱使用工作表 0 上儲存格 C1。[DataSourceType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/datasourcetype/) 列舉選擇每個名稱的來源。範例儲存更新後的系列名稱簡報。

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

## **偵測不支援的嵌入式工作簿格式**

Aspose.Slides 不支援可嵌入於某些圖表中的 Excel 二進位工作簿 (.xlsb) 格式。您可以在[IChartData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/) 上使用[getEmbeddedWorkbookType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#getEmbeddedWorkbookType--) 方法，搭配[WorkbookType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/workbooktype/) 列舉，偵測不支援的格式並跳過這些圖表。此範例檢查既有簡報第一張投影片上的圖形，跳過非圖表的圖形，並為每個帶有嵌入 .xlsb 工作簿的圖表印出診斷訊息。

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

        // 在此讀取或修改受支援的圖表工作簿資料。
    }
} finally {
    presentation.dispose();
}
```

## **外部工作簿**

Aspose.Slides 支援使用外部工作簿作為圖表的資料來源。

### **建立外部工作簿**

使用[readWorkbookStream](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#readWorkbookStream--)與[setExternalWorkbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#setExternalWorkbook-java.lang.String-)，將內嵌圖表工作簿匯出至檔案，並將圖表連結至該外部工作簿。

此範例建立一個含預設資料的圓餅圖，並匯出其工作簿。檔案寫入完成後，再指派外部工作簿作為圖表資料來源，最後儲存已連結的簡報。

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

### **設定外部工作簿**

使用[setExternalWorkbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#setExternalWorkbook-java.lang.String-) 方法，您可以將外部工作簿指派給圖表作為資料來源。此方法亦可用於更新外部工作簿的路徑（若工作簿已搬移）。

雖然無法編輯儲存在遠端位置或資源中的工作簿資料，但仍可將此類工作簿作為外部資料來源使用。若提供相對路徑，系統會自動轉換為完整路徑。

此範例使用一個外部工作簿，其工作表 `Sheet1` 在 B1 包含系列名稱、在 A2:A4 包含類別名稱、在 B2:B4 包含數值。範例建立圓餅圖、連結工作簿，並使用[setRange](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#setRange-java.lang.String-) 將 A1:B4 映射為一個系列與三個類別。最後儲存已連結圖表的簡報。

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

[setExternalWorkbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#setExternalWorkbook-java.lang.String-boolean-) 的 `updateChartData` 參數控制是否載入工作簿。

* 當 `updateChartData` 為 `false` 時，僅更新工作簿路徑。圖表資料不會從目標工作簿載入或更新，因此工作簿可以不存在。
* 當 `updateChartData` 為 `true` 時，圖表資料會從目標工作簿更新。

以下範例將佔位網址指派給 `updateChartData` 為 `false` 的情況。它保留圓餅圖的預設資料，且在未載入不可用的工作簿情況下儲存簡報。

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

### **取得圖表的外部資料來源工作簿路徑**

若要辨識圖表所連結的工作簿，請檢查圖表是否使用外部資料來源，並取得其工作簿路徑。

此範例檢查一個已連結外部工作簿的簡報的第一張投影片第一個圖形。若該圖形為連結至外部工作簿的圖表，範例會將[getExternalWorkbookPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#getExternalWorkbookPath--) 列印至主控台，然後儲存簡報的副本。

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

您可以以與編輯內部工作簿相同的方式編輯外部工作簿的資料。若無法載入外部工作簿，會拋出例外。

此範例使用第一張投影片第一個圖形的圖表，且該圖表連結至可存取的外部工作簿。它將第一系列第一個資料點的儲存格值設定為 100，並儲存更新後的簡報。編輯儲存格值會更新連結的外部 XLSX 檔案，若需保留原始工作簿，請使用其副本。

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

### **從圖表快取復原工作簿**

若圖表使用的外部工作簿遺失或不可用，Aspose.Slides 可以從簡報中快取的資料重新建構圖表工作簿。建立[LoadOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/)，呼叫[LoadOptions.setSpreadsheetOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/#setSpreadsheetOptions-com.aspose.slides.ISpreadsheetOptions-)，並在開啟簡報前將[ISpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ispreadsheetoptions/#setRecoverWorkbookFromChartCache-boolean-) 設為 `true`。

以下 Java 範例復原第一張投影片第一個圖形的圖表資料，該圖表參考不可用的外部工作簿。它透過[IChart.getChartData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#getChartData--) 與[IChartData.getChartDataWorkbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#getChartDataWorkbook--) 取得復原的資料：

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

        // 在此讀取或修改已復原的工作簿資料。
    } else {
        System.out.println("The first shape is not a chart.");
    }
} finally {
    presentation.dispose();
}
```

若外部工作簿不可用且未啟用復原，Aspose.Slides 會拋出例外。僅在使用快取圖表資料為可接受的備援方案時才啟用復原，因為快取可能不含外部工作簿在簡報最後一次更新之後所做的變更。

## **常見問題**

**我如何判斷特定圖表是連結至外部工作簿還是內嵌工作簿？**

可以。圖表具有[資料來源類型](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chartdata/#getDataSourceType--) 以及[外部工作簿路徑](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chartdata/#getExternalWorkbookPath--)；若來源是外部工作簿，您可以讀取完整路徑以確認使用的是外部檔案。

**是否支援外部工作簿的相對路徑，且它們如何儲存？**

支援。若指定相對路徑，系統會自動轉換為絕對路徑。簡報會在 PPTX 檔案中儲存絕對路徑，因此搬移工作簿可能需要更新連結。

**我可以使用位於網路資源/共享資料夾的工作簿嗎？**

可以，此類工作簿可作為外部資料來源。不過，Aspose.Slides 不支援直接編輯遠端工作簿——只能將其作為來源使用。

**Aspose.Slides 在儲存簡報時會覆寫外部 XLSX 嗎？**

簡報會儲存對外部檔案的[連結](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chartdata/#getExternalWorkbookPath--)。編輯基於儲存格的圖表資料也可能會更新連結的本機 XLSX 檔案。若原始檔案必須保持不變，請使用其副本。

**如果外部檔案受密碼保護，我該怎麼辦？**

Aspose.Slides 在連結時不接受密碼。常見作法是事先移除保護，或先建立已解密的副本（例如使用[Aspose.Cells](https://reference.aspose.com/cells/java/)），再連結至該副本。

**多個圖表可以參考同一個外部工作簿嗎？**

可以。每個圖表都會儲存自己的連結。若它們皆指向同一個檔案，更新該檔案後，下一次載入資料時所有圖表皆會反映變更。