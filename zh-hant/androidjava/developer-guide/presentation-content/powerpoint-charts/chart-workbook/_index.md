---
title: 在 Android 上管理投影片中的圖表活頁簿
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
- 投影片
- Android
- Java
- Aspose.Slides
description: "探索 Aspose.Slides for Android via Java：輕鬆在 PowerPoint 與 OpenDocument 格式中管理圖表活頁簿，簡化您的投影片資料。"
---
## **概觀**

本文說明如何在 Aspose.Slides 中使用圖表活頁簿。它展示如何透過活頁簿串流讀寫圖表資料、使用活頁簿儲存格作為圖表資料標籤、存取工作表集合，以及指定圖表值的資料來源類型。

它也涵蓋了將外部活頁簿作為圖表資料來源的使用。範例示範如何建立並指派外部活頁簿、取得連結至圖表的外部活頁簿路徑，以及在活頁簿可用時編輯圖表資料。

如需處理代表缺失資料的活頁簿儲存格，請參閱[控制空儲存格的顯示](/slides/zh-hant/androidjava/chart-series/)，以了解空儲存格與零的差異，以及線圖比較可用的顯示模式。

## **包含隱藏列與欄的資料**

使用[IChart.setPlotVisibleCellsOnly](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#setPlotVisibleCellsOnly-boolean-)來控制圖表是否繪製來自隱藏工作表列與欄的資料。將其設為 `true` 只繪製可見儲存格，或設為 `false` 兩者皆包括。此設定控制圖表繪製；它不會隱藏或取消隱藏工作表列或欄。

[sample presentation](hidden-source-data.pptx)的第一張投影片第一個圖形是一個柱狀圖。內嵌工作表 `Sheet1` 包含來源範圍 `A1:C4`。第 3 列與 C 欄為隱藏，但其儲存格仍有值。

| 工作表列 | A: 月份 | B: 零售 | C: 批發 (隱藏欄) |
| --- | --- | --- | --- |
| 2 | January | 10 | 30 |
| 3（隱藏列） | February | 40 | 60 |
| 4 | March | 20 | 50 |

透過[IChartData.getChartDataWorkbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#getChartDataWorkbook--)存取來源儲存格，並讀取[IChartDataCell.isHidden](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatacell/#isHidden--)以檢查其隱藏狀態。此方法僅回報隱藏狀態，不會更改它。在此範例中，B2 為可見，B3 屬於隱藏列，C2 屬於隱藏欄；範例分別印出 `false`、`true`、`true`。

此範例在變更繪製設定後，請先使用[readWorkbookStream](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#readWorkbookStream--)保留內嵌活頁簿，然後使用[writeWorkbookStream](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#writeWorkbookStream-byte---)重新載入。若要包含所有儲存格，亦須使用[setRange](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#setRange-java.lang.String-)還原完整範圍，包含隱藏的 February 類別。僅變更旗標不足以刷新此範例的快取圖表資料與類別標籤。

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

            // 從嵌入式活頁簿重新整理圖表資料。
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

此範例儲存兩個版本的投影片：一個僅包含可見的 Retail 值 (10 與 20)，另一個則包含全部六個值。下圖說明兩種繪製模式。第 3 列與 C 欄在兩個內嵌活頁簿中皆保持隱藏。

| 僅可見儲存格 (`true`) | 所有儲存格 (`false`) |
| --- | --- |
| ![僅可見儲存格：January 與 March 的零售值 10 與 20。](hidden_cells_True.png) | ![所有儲存格：January、February 與 March 的零售與批發值。](hidden_cells_False.png) |

包含值的隱藏儲存格與空儲存格不同。[IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#setDisplayBlanksAs-int-)控制缺失值的顯示方式；它不會包含或排除隱藏的來源資料。請參閱[控制空儲存格的顯示](/slides/zh-hant/androidjava/chart-series/#control-the-display-of-empty-cells)以取得範例。

## **取得圖表的資料範圍**

在既有投影片中更新活頁簿資料之前，請檢查來源範圍，以識別每個圖表使用的工作表儲存格。[IChartData.getRange](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#getRange--)方法傳回目前資料範圍的工作表限定公式，例如 `Sheet1!$A$1:$D$5`。此處 `Sheet1` 為工作表名稱，`!` 用於分隔工作表與儲存格範圍，`$A$1:$D$5` 表示包含 A1 至 D5 的儲存格。美元符號表示絕對列與欄參照。

此方法僅讀取目前範圍，不會變更圖表或其活頁簿。若圖表未使用活頁簿作為資料來源，則會拋出 `InvalidOperationException`。更多資訊請參閱[ChartData API 參考](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chartdata/)。

此範例開啟投影片，直接檢查每張投影片上的圖形是否為圖表。它會印出每個圖表的名稱與來源範圍。若圖表未使用活頁簿，則印出訊息並繼續檢查下一個圖表。

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

## **從活頁簿讀寫圖表資料**

Aspose.Slides for Android via Java 提供[readWorkbookStream](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#readWorkbookStream--)與[writeWorkbookStream](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#writeWorkbookStream-byte---)方法，可讓您讀取與寫入圖表資料活頁簿（包含使用 Aspose.Cells 編輯的圖表資料）。**注意** 圖表資料必須以相同方式組織，或具有類似於來源的結構。

此範例使用第一張投影片第一個圖形的圖表。它將內嵌活頁簿讀取為位元組陣列，清除現有系列與類別，並將相同的活頁簿寫回。變更保留於記憶體中，範例不會儲存投影片。

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

### **在修改活頁簿後驗證圖表版面配置**

當您以已修改的活頁簿取代內嵌活頁簿時，圖表仍保留原始的系列與類別集合。此不匹配可能導致[IChart.validateChartLayout](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#validateChartLayout--)因索引超出範圍錯誤而失敗。請在寫回更新後的活頁簿之前清除現有的系列與類別。本範例使用第一張投影片的第一個圖形作為圖表。註解標示了活頁簿編輯可能發生的位置；可執行的範例寫回原始活頁簿並在記憶體中驗證版面配置。

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

        // 在此修改活頁簿位元組，例如使用 Aspose.Cells.

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

清除集合可在寫回活頁簿前移除過期的資料參照。於使用圖表前，請為更新的活頁簿重新建構任何必要的系列與類別對應。

## **設定活頁簿儲存格的自訂數字格式**

使用[IChartDataCell.setCustomNumberFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatacell/#setCustomNumberFormat-java.lang.String-)可控制數值在圖表內嵌活頁簿中的顯示方式。例如，報表可能需要將轉換率以四位小數的百分比顯示，並將係數以五位小數顯示。請保持兩個值皆為數值，以便於計算與圖表繪製。

數字格式僅變更顯示，不會改變儲存值。格式 `0.0000%` 會將 `0.125` 顯示為 `12.5000%`；它不會將儲存的數字替換為 `12.5`。同樣地，`0.00000` 會將 `0.1234567` 顯示為 `0.12346`，但不會捨入儲存的值。若自訂格式為空字串 (`""`)，則使用[getPresetNumberFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatacell/#getPresetNumberFormat--) 回傳的格式。

以下範例建立柱狀圖，並透過[getChartDataWorkbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#getChartDataWorkbook--)存取其儲存格。於工作表 0，B2 包含轉換率，C2 包含係數。兩個儲存格皆供圖表使用。範例同時啟用連結至來源格式的數值標籤。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    presentation.getSlideSize().setSize(720, 270, SlideSizeScaleType.DoNotScale);
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 20, 620, 210);
    chart.setTitle(false);

    chart.getAxes().getVerticalAxis().setNumberFormatLinkedToSource(false);
    chart.getAxes().getVerticalAxis().setNumberFormat("0.00");
    chart.getAxes().getVerticalAxis().setAutomaticMinValue(false);
    chart.getAxes().getVerticalAxis().setMinValue(0);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    IChartDataCell categoryCell = workbook.getCell(0, "A2", "Sample");
    chart.getChartData().getCategories().add(categoryCell);

    IChartDataCell percentageCell = workbook.getCell(0, "B2", 0.125);
    percentageCell.setCustomNumberFormat("0.0000%");
    IChartDataCell percentageName = workbook.getCell(0, "B1", "Conversion rate");
    IChartSeries percentageSeries = chart.getChartData().getSeries().add(percentageName, chart.getType());
    percentageSeries.getDataPoints().addDataPointForBarSeries(percentageCell);

    IChartDataCell precisionCell = workbook.getCell(0, "C2", 0.1234567);
    precisionCell.setCustomNumberFormat("0.00000");
    IChartDataCell precisionName = workbook.getCell(0, "C1", "Coefficient");
    IChartSeries precisionSeries = chart.getChartData().getSeries().add(precisionName, chart.getType());
    precisionSeries.getDataPoints().addDataPointForBarSeries(precisionCell);

    for (IChartSeries series : chart.getChartData().getSeries()) {
        IDataLabelFormat labelFormat = series.getDataPoints().get_Item(0).getLabel().getDataLabelFormat();
        labelFormat.setShowValue(true);
        labelFormat.setNumberFormatLinkedToSource(true);
    }

    presentation.save("CustomCellFormats.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

活頁簿儲存格的格式與直接在圖表座標軸或資料標籤上設定的格式分開。在此範例中，每個標籤皆因[setShowValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idatalabelformat/#setShowValue-boolean-) 設為 `true`，且因[setNumberFormatLinkedToSource](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idatalabelformat/#setNumberFormatLinkedToSource-boolean-) 設為 `true` 而遵循來源的數字格式。儲存並重新開啟投影片後，標籤分別顯示 `12.5000%` 與 `0.12346`，如下所示。垂直座標軸使用其自行設定的數字格式，透過[setNumberFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setNumberFormat-java.lang.String-) 設為 `0.00`，且[setNumberFormatLinkedToSource](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setNumberFormatLinkedToSource-boolean-) 設為 `false`。

若要獨立格式化資料標籤，請將其來源連結旗標設為 `false`，並使用[setNumberFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idatalabelformat/#setNumberFormat-java.lang.String-) 指定格式。這不會變更活頁簿儲存格的格式。例如，獨立的標籤格式 `0.00` 會將第一個值顯示為 `0.13`，而 B2 仍顯示 `12.5000%`。請參閱[Chart Data Labels](/slides/zh-hant/androidjava/chart-data-label/#set-the-percentage-sign-with-chart-data-labels)以了解直接標籤格式化。

下圖為重新開啟後儲存的投影片渲染結果：

![Column chart with source-linked labels showing 12.5000% and 0.12346 and an independently formatted numeric axis.](custom-cell-formats.png)

## **將活頁簿儲存格設定為圖表資料標籤**

您可以使用活頁簿儲存格中的文字作為圖表資料標籤。

此範例於現有投影片的第一張投影片新增一個預設資料的氣泡圖，使用工作表 0 的 A10:A12 兩列作為第一系列的前三個標籤，啟用來自儲存格的標籤，並儲存更新後的投影片。

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

[IChartDataWorkbook.getWorksheets](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdataworkbook/#getWorksheets--) 方法提供存取圖表活頁簿中工作表的功能。此範例建立一個預設資料的圓餅圖，並將每個工作表名稱印至主控台。

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

此範例建立一個預設資料的 3D 柱狀圖，並使用不同的資料來源設定兩個系列名稱。第一個名稱使用字串常值；第二個名稱使用工作表 0 中的 C1 儲存格。[DataSourceType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/datasourcetype/) 列舉可為每個名稱選擇來源。範例儲存投影片以更新系列名稱。

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

## **偵測不支援的嵌入式活頁簿格式**

Aspose.Slides 不支援可嵌入於部分圖表中的 Excel 二進位活頁簿（.xlsb）格式。您可以在[IChartData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/) 上使用[getEmbeddedWorkbookType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#getEmbeddedWorkbookType--) 方法，搭配[WorkbookType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/workbooktype/) 列舉，以偵測不支援的格式並跳過那些圖表。此範例檢查現有投影片第一張投影片上的圖形，跳過非圖表圖形，並為每個含有嵌入式 .xlsb 活頁簿的圖表印出診斷訊息。

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

        // 在此讀取或修改受支援的圖表活頁簿資料。
    }
} finally {
    presentation.dispose();
}
```

## **外部活頁簿**

Aspose.Slides 支援使用外部活頁簿作為圖表的資料來源。

### **建立外部活頁簿**

使用[readWorkbookStream](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#readWorkbookStream--)與[setExternalWorkbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#setExternalWorkbook-java.lang.String-)將內嵌圖表活頁簿匯出至檔案，並將圖表連結至該外部活頁簿。

此範例建立一個預設資料的圓餅圖，並匯出其活頁簿。檔案寫入完成後指派外部活頁簿作為圖表資料來源，最後儲存已連結的投影片。

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

使用[setExternalWorkbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#setExternalWorkbook-java.lang.String-) 方法，您可以將外部活頁簿指派給圖表作為資料來源。此方法亦可用於更新外部活頁簿的路徑（若檔案已移動）。

雖然無法直接編輯儲存在遠端位置或資源中的活頁簿資料，但仍可將此類活頁簿作為外部資料來源。若提供相對路徑，系統會自動轉換為完整路徑。

此範例使用一個外部活頁簿，其工作表 `Sheet1` 包含 B1 的系列名稱、A2:A4 的類別名稱，以及 B2:B4 的數值。範例建立圓餅圖、連結活頁簿，並使用[setRange](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#setRange-java.lang.String-)將 A1:B4 映射為一個系列與三個類別。最後儲存已連結圖表的投影片。

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

[setExternalWorkbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#setExternalWorkbook-java.lang.String-boolean-) 的 `updateChartData` 參數控制是否載入活頁簿。

* 當 `updateChartData` 為 `false` 時，僅更新活頁簿路徑。圖表資料不會從目標活頁簿載入或更新，因此活頁簿可以不存在。
* 當 `updateChartData` 為 `true` 時，圖表資料會從目標活頁簿更新。

以下範例將占位符 URL 指派給 `updateChartData` 為 `false`。它保留圓餅圖的預設資料，並在未載入不可用活頁簿的情況下儲存投影片。

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

若要識別連結至圖表的活頁簿，請檢查圖表是否使用外部資料來源，並取得其活頁簿路徑。

此範例檢查一個已連結外部活頁簿的投影片第一張投影片的第一個圖形。若它是連結至外部活頁簿的圖表，範例會將[getExternalWorkbookPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#getExternalWorkbookPath--) 印至主控台，然後儲存投影片副本。

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

您可以以與編輯內嵌活頁簿相同的方式編輯外部活頁簿的資料。若外部活頁簿無法載入，將拋出例外。

此範例使用第一張投影片第一個圖形的圖表，且該圖表已連結至可存取的外部活頁簿。它將第一系列第一個資料點的儲存格支援值設定為 100，並儲存更新後的投影片。編輯儲存格值會更新連結的外部 XLSX 檔案，若需保留原始活頁簿，請使用副本。

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

### **從圖表快取復原活頁簿**

如果圖表使用的外部活頁簿缺失或不可用，Aspose.Slides 可以從投影片快取的資料重建圖表活頁簿。建立[LoadOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/)，呼叫[LoadOptions.setSpreadsheetOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/#setSpreadsheetOptions-com.aspose.slides.ISpreadsheetOptions-)，並在開啟投影片前將[ISpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ispreadsheetoptions/#setRecoverWorkbookFromChartCache-boolean-) 設為 `true`。

以下 Java 範例從缺少外部活頁簿的圖表（第一張投影片的第一個圖形）復原活頁簿資料，並透過[IChart.getChartData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#getChartData--) 與[IChartData.getChartDataWorkbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#getChartDataWorkbook--) 取得復原資料：

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

        // 在此讀取或修改已復原的活頁簿資料。
    } else {
        System.out.println("The first shape is not a chart.");
    }
} finally {
    presentation.dispose();
}
```

若外部活頁簿不可用且未啟用復原，Aspose.Slides 會拋出例外。僅在接受使用快取圖表資料作為可接受的備援時才啟用復原，因為快取可能不包含外部活頁簿在投影片最後一次更新後所做的變更。

## **常見問題**

**我可以判斷特定圖表是連結至外部活頁簿還是內嵌活頁簿嗎？**

可以。圖表具有[資料來源類型](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chartdata/#getDataSourceType--) 與[外部活頁簿路徑](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chartdata/#getExternalWorkbookPath--)；若來源為外部活頁簿，您可以讀取完整路徑以確保使用了外部檔案。

**是否支援相對路徑的外部活頁簿，且它們如何儲存？**

支援。若您指定相對路徑，系統會自動轉換為絕對路徑。投影片會在 PPTX 檔案中儲存絕對路徑，搬移活頁簿可能需要更新連結。

**我可以使用位於網路資源/共享的活頁簿嗎？**

可以，此類活頁簿可作為外部資料來源。然而，Aspose.Slides 不支援直接編輯遠端活頁簿——只能將其作為來源使用。

**Aspose.Slides 在儲存投影片時會覆寫外部 XLSX 嗎？**

投影片會儲存指向外部檔案的[連結](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chartdata/#getExternalWorkbookPath--)。編輯儲存格支援的圖表資料也可能更新連結的本機 XLSX 檔案。若原始活頁簿必須保持不變，請使用其副本。

**如果外部檔案受密碼保護，我該怎麼辦？**

Aspose.Slides 連結時不接受密碼。常見的做法是事先移除保護，或使用 [Aspose.Cells](https://reference.aspose.com/cells/java/) 之類的工具建立已解密的副本，然後連結至該副本。

**多個圖表可以參考同一個外部活頁簿嗎？**

可以。每個圖表都會存儲自己的連結。若它們指向相同檔案，更新該檔案將在下次載入資料時反映於所有圖表。