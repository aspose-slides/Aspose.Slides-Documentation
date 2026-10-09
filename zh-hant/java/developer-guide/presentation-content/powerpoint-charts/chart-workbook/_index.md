---
title: 使用 Java 在簡報中管理圖表工作簿
linktitle: 圖表工作簿
type: docs
weight: 70
url: /zh-hant/java/chart-workbook/
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
- Java
- Aspose.Slides
description: "探索 Aspose.Slides for Java：輕鬆在 PowerPoint 與 OpenDocument 格式中管理圖表工作簿，以簡化您的簡報資料。"
---
## **概觀**

本文說明如何在 Aspose.Slides 中使用圖表工作簿。它展示了如何透過工作簿串流讀取和寫入圖表資料、使用工作簿儲存格作為圖表資料標籤、存取工作表集合，以及為圖表值指定資料來源類型。

它還涵蓋了使用外部工作簿作為圖表資料來源的操作。範例說明了如何建立與指派外部工作簿、取得連結至圖表的外部工作簿路徑，以及在工作簿可用時編輯圖表資料。

如需了解代表缺失資料的工作簿儲存格，請參閱[控制空儲存格的顯示](/slides/zh-hant/java/chart-series/)，了解空儲存格與零的差異，以及可用顯示模式的折線圖比較。

## **包含隱藏列與欄位的資料**

使用[IChart.setPlotVisibleCellsOnly](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#setPlotVisibleCellsOnly-boolean-) 來控制圖表是否繪製隱藏工作表列與欄位的資料。將其設為 `true` 只繪製可見儲存格，或 `false` 同時包含可見與隱藏儲存格。此設定僅控制圖表繪製；不會隱藏或取消隱藏工作表列或欄位。

此[範例簡報](hidden-source-data.pptx)的第一張投影片的第一個圖形是一個直條圖。內嵌工作表 `Sheet1` 包含以下來源範圍 `A1:C4`。第 3 列與 C 欄被隱藏，但其儲存格仍含有數值。

| 工作表列 | A: 月份 | B: 零售 | C: 批發（隱藏欄） |
| --- | --- | --- | --- |
| 2 | January | 10 | 30 |
| 3 (隱藏列) | February | 40 | 60 |
| 4 | March | 20 | 50 |

透過[IChartData.getChartDataWorkbook](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#getChartDataWorkbook--) 取得來源儲存格，並讀取[IChartDataCell.isHidden](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatacell/#isHidden--) 以檢查其隱藏狀態。此方法回報隱藏狀態而不會更改。於此檔案中，B2 為可見，B3 屬於隱藏列，C2 屬於隱藏欄；範例分別印出 `false`、`true`、`true`。

對於此範例，在變更繪圖設定後請重新整理圖表資料：使用[readWorkbookStream](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#readWorkbookStream--) 保留內嵌工作簿，並使用[writeWorkbookStream](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#writeWorkbookStream-byte---) 重新載入。若要包含所有儲存格，亦使用[setRange](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#setRange-java.lang.String-) 復原完整範圍，包含隱藏的二月類別。僅變更旗標不足以重新整理此範例的快取圖表資料與類別標籤。

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

            // 從內嵌工作簿重新整理圖表資料。
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

此範例會儲存兩個版本的簡報：一個僅包含可見的零售值 (10 與 20)，另一個包含全部六個值。下方圖片說明了兩種繪圖模式。第 3 列與 C 欄在兩個內嵌工作簿中皆保持隱藏。

| 僅可見儲存格 (`true`) | 所有儲存格 (`false`) |
| --- | --- |
| ![僅可見儲存格：一月與三月的零售值 10 與 20](hidden_cells_True.png) | ![所有儲存格：一月、二月、三月的零售與批發值](hidden_cells_False.png) |

包含值的隱藏儲存格不同於空儲存格。[IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#setDisplayBlanksAs-int-) 控制缺失值的顯示方式；不會包含或排除隱藏的來源資料。請參閱[控制空儲存格的顯示](/slides/zh-hant/java/chart-series/#control-the-display-of-empty-cells) 取得範例。

## **取得圖表的資料範圍**

在更新現有簡報的工作簿資料之前，請先檢查來源範圍以確認每個圖表使用的工作表儲存格。[IChartData.getRange](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#getRange--) 方法傳回目前的資料範圍，格式為工作表限定的公式，例如 `Sheet1!$A$1:$D$5`。此處，`Sheet1` 為工作表名稱，`!` 用於分隔工作表與儲存格範圍，而 `$A$1:$D$5` 表示從 A1 到 D5（含）的儲存格。美元符號表示絕對的列與欄參照。

此方法在不變更圖表或其工作簿的情況下讀取目前範圍。若圖表未使用工作簿作為資料來源，則會拋出 `InvalidOperationException`。欲取得更多資訊，請參閱[ChartData API 參考文件](https://reference.aspose.com/slides/java/com.aspose.slides/chartdata/)。

此範例開啟簡報，並直接於每張投影片檢查形狀是否為圖表。它會輸出每個圖表的名稱與來源範圍。若圖表未使用工作簿，則會輸出訊息並繼續處理下一個圖表。

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

Aspose.Slides for Java 提供 [readWorkbookStream](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#readWorkbookStream--) 以及 [writeWorkbookStream](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#writeWorkbookStream-byte---) 方法，讓您能讀寫圖表資料工作簿（包含使用 Aspose.Cells 編輯的圖表資料）。**注意** 圖表資料必須以相同方式組織或結構與來源相似。

此範例使用一個簡報，其第一張投影片的第一個圖形是一個圖表。它將內嵌工作簿讀取為位元組陣列，清除現有的系列與類別，然後將相同的工作簿寫回。變更僅保留於記憶體中；此範例不會儲存簡報。

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

### **修改工作簿後驗證圖表版面配置**

當您以已修改的工作簿取代內嵌工作簿時，圖表仍保留原始的系列與類別集合。此不匹配可能導致[IChart.validateChartLayout](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#validateChartLayout--) 因索引超出範圍而失敗。請在將更新的工作簿寫回圖表之前，先清除現有的系列與類別。此範例使用第一張投影片的第一個圖表。註解標示了工作簿編輯的地方；可執行範例會將原始工作簿寫回，並在記憶體中驗證版面配置。

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

        // 在此處修改工作簿位元組，例如使用 Aspose.Cells.

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

清除集合會在工作簿寫回之前移除過時的資料參考。於使用圖表前，請重新建立更新後工作簿所需的系列與類別對應。

## **將工作簿儲存格設為圖表資料標籤**

您可以使用工作簿儲存格中的文字作為圖表資料標籤。

此範例在現有簡報的第一張投影片加入一個具有預設資料的氣泡圖。它使用工作表 0 上的儲存格 A10:A12 作為第一系列的前三個標籤，啟用來自儲存格的標籤，並儲存更新後的簡報。

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

[IChartDataWorkbook.getWorksheets](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdataworkbook/#getWorksheets--) 方法提供對圖表工作簿中工作表的存取。此範例建立一個具有預設資料的圓餅圖，並將每個工作表名稱輸出至主控台。

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

此範例建立一個具有預設資料的 3D 直條圖，並使用不同的資料來源設定兩個系列名稱。第一個名稱使用字串常值；第二個名稱使用工作表 0 上的儲存格 C1。[DataSourceType](https://reference.aspose.com/slides/java/com.aspose.slides/datasourcetype/) 列舉用於為每個名稱選擇來源。範例會儲存更新系列名稱的簡報。

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

## **偵測不支援的內嵌工作簿格式**

Aspose.Slides 不支援某些圖表中可內嵌的 Excel 二進位工作簿 (.xlsb) 格式。您可以在 [IChartData](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/) 上使用 [getEmbeddedWorkbookType](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#getEmbeddedWorkbookType--) 方法，結合 [WorkbookType](https://reference.aspose.com/slides/java/com.aspose.slides/workbooktype/) 列舉，以偵測不支援的格式並跳過這些圖表。此範例檢查現有簡報第一張投影片的形狀，跳過非圖表形狀，並為每個內嵌 .xlsb 工作簿的圖表輸出診斷訊息。

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

Aspose.Slides 支援將外部工作簿作為圖表的資料來源。

### **建立外部工作簿**

使用[readWorkbookStream](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#readWorkbookStream--) 與[setExternalWorkbook](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#setExternalWorkbook-java.lang.String-) 將內嵌圖表工作簿匯出為檔案，並將圖表連結至該外部工作簿。

此範例建立一個具有預設資料的圓餅圖，並匯出其工作簿。它在將外部工作簿指派為圖表資料來源之前完成檔案寫入，然後儲存已連結的簡報。

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Pie, 50, 50, 400, 600);
    Path workbookPath = Paths.get("externalWorkbook1.xlsx").toAbsolutePath();
    byte[] workbookData = chart.getChartData().readWorkbookStream();
    try {
        Files.write(workbookPath, workbookData);
        chart.getChartData().setExternalWorkbook(workbookPath.toString());
        presentation.save("externalWorkbook.pptx", SaveFormat.Pptx);
    } catch (IOException exception) {
        System.out.println("Could not write the external workbook: " + exception.getMessage());
    }
} finally {
    presentation.dispose();
}
```

### **設定外部工作簿**

使用[setExternalWorkbook](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#setExternalWorkbook-java.lang.String-) 方法，您可以將外部工作簿指定給圖表作為其資料來源。此方法亦可用於更新外部工作簿的路徑（若該檔案已搬移）。

雖然無法編輯儲存在遠端位置或資源中的工作簿資料，但仍可將此類工作簿作為外部資料來源。若提供外部工作簿的相對路徑，系統會自動將其轉換為完整路徑。

此範例使用一個外部工作簿，其工作表 `Sheet1` 在 B1 包含系列名稱、在 A2:A4 包含類別名稱，且在 B2:B4 包含數值。範例建立一個圓餅圖，連結該工作簿，並使用[setRange](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#setRange-java.lang.String-) 將 A1:B4 對應為一個系列與三個類別。它會儲存包含已連結圖表的簡報。

```java
import com.aspose.slides.*;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Pie, 50, 50, 400, 600, true);
    IChartData chartData = chart.getChartData();
    String workbookPath = Paths.get("externalWorkbook.xlsx").toAbsolutePath().toString();

    chartData.setExternalWorkbook(workbookPath);
    chartData.setRange("Sheet1!$A$1:$B$4");

    presentation.save("Presentation_with_externalWorkbook.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

[setExternalWorkbook](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#setExternalWorkbook-java.lang.String-boolean-) 的 `updateChartData` 參數控制是否載入工作簿。

* 當 `updateChartData` 為 `false` 時，僅更新工作簿路徑。圖表資料不會從目標工作簿載入或更新，因此工作簿可以不存在。
* 當 `updateChartData` 為 `true` 時，圖表資料會從目標工作簿更新。

以下範例以 `updateChartData` 設為 `false` 指派一個佔位 URL。它保留圓餅圖的預設資料，並在未載入不可用工作簿的情況下儲存簡報。

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

若要辨識連結至圖表的工作簿，請檢查圖表是否使用外部資料來源，並取得其工作簿路徑。

此範例檢查具備已連結外部工作簿的簡報第一張投影片的第一個形狀。若該形狀為連結至外部工作簿的圖表，範例會將[getExternalWorkbookPath](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#getExternalWorkbookPath--) 輸出至主控台。之後儲存簡報的副本。

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

您可以像編輯內部工作簿內容一樣編輯外部工作簿的資料。若無法載入外部工作簿，會拋出例外。

此範例使用第一張投影片的第一個圖表，且已連結至可存取的外部工作簿。它將第一系列第一資料點的儲存格值設定為 100，並儲存更新後的簡報。編輯儲存格值可更新連結的外部 XLSX 檔案，若需保留原始工作簿，請使用副本。

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

如果圖表使用的外部工作簿遺失或不可用，Aspose.Slides 可以從簡報中快取的資料重新建構圖表工作簿。於開啟簡報前，建立[LoadOptions](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/)，呼叫[LoadOptions.setSpreadsheetOptions](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/#setSpreadsheetOptions-com.aspose.slides.ISpreadsheetOptions-)，並將[ISpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/java/com.aspose.slides/ispreadsheetoptions/#setRecoverWorkbookFromChartCache-boolean-) 設為 `true`。

以下 Java 範例復原第一張投影片第一個圖表的工作簿資料，該圖表參考了不可用的外部工作簿。它透過[IChart.getChartData](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#getChartData--) 與[IChartData.getChartDataWorkbook](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#getChartDataWorkbook--) 取得復原的資料：

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

        // 在此讀取或修改復原的工作簿資料。
    } else {
        System.out.println("The first shape is not a chart.");
    }
} finally {
    presentation.dispose();
}
```

若外部工作簿不可用且未啟用復原，Aspose.Slides 會拋出例外。僅在接受使用快取圖表資料作為備援時才啟用復原，因為快取可能不包含簡報最後更新後對外部工作簿所做的變更。

## **常見問題**

**我能判斷特定圖表是連結到外部工作簿還是內嵌工作簿嗎？**

可以。圖表具有[資料來源類型](https://reference.aspose.com/slides/java/com.aspose.slides/chartdata/#getDataSourceType--) 與[外部工作簿路徑](https://reference.aspose.com/slides/java/com.aspose.slides/chartdata/#getExternalWorkbookPath--)；若來源為外部工作簿，您可以讀取完整路徑以確認使用的是外部檔案。

**是否支援外部工作簿的相對路徑，且如何儲存？**

支援。若指定相對路徑，系統會自動轉換為絕對路徑。簡報會將絕對路徑存於 PPTX 檔案中，若移動工作簿可能需要更新連結。

**我可以使用位於網路資源/共享上的工作簿嗎？**

可以，此類工作簿可作為外部資料來源使用。但不支援直接從 Aspose.Slides 編輯遠端工作簿—只能作為來源使用。

**Aspose.Slides 在儲存簡報時會覆寫外部 XLSX 嗎？**

簡報會儲存[外部檔案的連結](https://reference.aspose.com/slides/java/com.aspose.slides/chartdata/#getExternalWorkbookPath--)。編輯儲存格支持的圖表資料亦可能更新已連結的本機 XLSX 檔案。若必須保持原始工作簿不變，請使用其副本。

**如果外部檔案受密碼保護，我該怎麼做？**

Aspose.Slides 在連結時不接受密碼。常見的做法是事先移除保護或先準備一個已解密的副本（例如使用[Aspose.Cells](https://reference.aspose.com/cells/java/)），再連結該副本。

**多個圖表可以參照同一個外部工作簿嗎？**

可以。每個圖表都存有自己的連結。若皆指向同一檔案，更新該檔案後，在下次載入資料時，所有圖表皆會反映此變更。