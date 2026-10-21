---
title: 使用 Java 管理簡報中的圖表工作簿
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
description: "探索 Aspose.Slides for Java：輕鬆在 PowerPoint 與 OpenDocument 格式中管理圖表工作簿，簡化簡報資料。"
---
## **概觀**

本文說明如何在 Aspose.Slides 中使用圖表工作簿。它展示如何透過工作簿串流讀寫圖表資料、將工作簿儲存格作為圖表資料標籤、存取工作表集合，以及為圖表值指定資料來源類型。

它也涵蓋使用外部工作簿作為圖表資料來源的操作。範例展示如何建立並指派外部工作簿、取得連結到圖表的外部工作簿路徑，以及在工作簿可用時編輯圖表資料。

對於代表缺漏資料的工作簿儲存格，請參閱[控制空儲存格的顯示](/slides/zh-hant/java/chart-series/)以了解空儲存格與零的差異，以及可用顯示模式的折線圖比較。

## **包含隱藏列與欄的資料**

使用[IChart.setPlotVisibleCellsOnly](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#setPlotVisibleCellsOnly-boolean-)來控制圖表是否繪製隱藏工作表列與欄位的資料。將其設為 `true` 只繪製可見儲存格，設為 `false` 則同時包含可見和隱藏儲存格。此設定僅影響圖表繪製，並不會隱藏或取消隱藏工作表的列或欄。

[範例簡報](hidden-source-data.pptx)的第一張投影片上有一個柱狀圖為第一個圖形。嵌入的工作表 `Sheet1` 包含以下來源範圍 `A1:C4`。第 3 列與 C 欄被隱藏，但其儲存格仍有值。

| 工作表列 | A：月份 | B：零售 | C：批發（隱藏欄） |
| --- | --- | --- | --- |
| 2 | 一月 | 10 | 30 |
| 3（隱藏列） | 二月 | 40 | 60 |
| 4 | 三月 | 20 | 50 |

透過[IChartData.getChartDataWorkbook](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#getChartDataWorkbook--)存取來源儲存格，並讀取[IChartDataCell.isHidden](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatacell/#isHidden--)以檢查其隱藏狀態。此方法僅回報隱藏狀態，並不會變更它。在此範例中，B2 為可見，B3 屬於隱藏列，C2 屬於隱藏欄；範例分別印出 `false`、`true`、`true`。

對於此範例，變更繪製設定後請重新整理圖表資料：使用[readWorkbookStream](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#readWorkbookStream--)保留嵌入工作簿，並以[writeWorkbookStream](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#writeWorkbookStream-byte---)重新載入。若要包含所有儲存格，亦可使用[setRange](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#setRange-java.lang.String-)還原完整範圍，包含隱藏的二月類別。僅變更旗標不足以刷新此樣本的快取圖表資料與類別標籤。

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

            // 從嵌入的工作簿重新整理圖表資料。
            chart.getChartData().writeWorkbookStream(workbookData);
            if (!visibleOnly) {
                // 還原完整的來源範圍，包括隱藏的類別。
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

範例會儲存兩個版本的簡報：一個僅包含可見的零售值 (10 與 20)，另一個則包含全部六個值。下方圖片說明兩種繪製模式。第 3 列與 C 欄在兩個嵌入工作簿中皆保持隱藏。

| 僅顯示可見儲存格 (`true`) | 所有儲存格 (`false`) |
| --- | --- |
| ![僅顯示可見儲存格：一月與三月的零售值 10 與 20。](hidden_cells_True.png) | ![所有儲存格：一月、二月與三月的零售與批發值。](hidden_cells_False.png) |

含有值的隱藏儲存格與空儲存格不同。[IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#setDisplayBlanksAs-int-) 控制缺漏值的顯示方式；它不會包含或排除隱藏的來源資料。請參閱[控制空儲存格的顯示](/slides/zh-hant/java/chart-series/#control-the-display-of-empty-cells)取得範例。

## **取得圖表的資料範圍**

在更新現有簡報中的工作簿資料之前，請檢查來源範圍以辨識每個圖表使用的工作表儲存格。[IChartData.getRange](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#getRange--) 方法會回傳目前的資料範圍，格式為工作表限定的公式，例如 `Sheet1!$A$1:$D$5`。其中 `Sheet1` 為工作表名稱，`!` 用於分隔工作表名稱與儲存格範圍，`$A$1:$D$5` 表示包含 A1 到 D5 的儲存格。美元符號表示絕對的列與欄參照。

此方法僅讀取目前範圍，不會變更圖表或其工作簿。若圖表未使用工作簿作為資料來源，會拋出 `InvalidOperationException`。欲取得更多資訊，請參閱[ChartData API Reference](https://reference.aspose.com/slides/java/com.aspose.slides/chartdata/)。

此範例會開啟簡報，直接在每張投影片上檢查圖形是否為圖表。它會列印每個圖表的名稱與來源範圍。若圖表未使用工作簿，則會印出訊息並繼續處理下一個圖表。

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

Aspose.Slides for Java 提供[readWorkbookStream](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#readWorkbookStream--)與[writeWorkbookStream](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#writeWorkbookStream-byte---) 方法，讓您讀寫包含由 Aspose.Cells 編輯的圖表資料之工作簿。**Note** 圖表資料必須以相同方式組織，或具備類似結構。

此範例使用第一張投影片上第一個圖形的柱狀圖。它會將嵌入的工作簿讀入位元組陣列，清除現有系列與類別，然後再寫回相同的工作簿。變更僅保留於記憶體中，範例不會儲存簡報。

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

### **在修改工作簿後驗證圖表版面配置**

當您以已修改的工作簿取代嵌入工作簿時，圖表仍保留原始的系列與類別集合。此不匹配可能導致[IChart.validateChartLayout](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#validateChartLayout--) 因索引超出範圍而失敗。請在寫回更新後的工作簿之前先清除現有的系列與類別。此範例使用第一張投影片上第一個圖形的圖表。註解標示了工作簿編輯可能發生的位置；可執行的範例會寫回原始工作簿並於記憶體中驗證版面配置。

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

        // 在此修改工作簿位元組，例如使用 Aspose.Cells。

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

清除集合可在寫回工作簿之前移除陳舊的資料參考。請在使用圖表前，為更新的工作簿重新建構任何必要的系列與類別對映。

## **為工作簿儲存格設定自訂數字格式**

使用[IChartDataCell.setCustomNumberFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatacell/#setCustomNumberFormat-java.lang.String-) 來控制數值在圖表嵌入工作簿中的顯示方式。例如，報表可能需要將轉換率顯示為四位小數的百分比，並將係數顯示為五位小數。兩個值皆保持數值型別，以便於計算與圖表繪製。

數字格式僅變更顯示，不會改變儲存的值。格式 `0.0000%` 會把 `0.125` 顯示為 `12.5000%`，但不會將儲存的數字替換成 `12.5`。同理，`0.00000` 會把 `0.1234567` 顯示為 `0.12346`，而不會捨入儲存值。若自訂格式為空字串 (`""`)，則改用 [getPresetNumberFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatacell/#getPresetNumberFormat--) 回傳的格式。

以下範例建立柱狀圖，並透過[getChartDataWorkbook](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#getChartDataWorkbook--) 取得其儲存格。於工作表 0，B2 含有轉換率，C2 含有係數。兩個儲存格皆提供圖表值。範例同時啟用連結至來源格式的值標籤。

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

工作簿儲存格格式與直接設定於圖表坐標軸或資料標籤的格式是分開的。在本例中，因為 [setShowValue](https://reference.aspose.com/slides/java/com.aspose.slides/idatalabelformat/#setShowValue-boolean-) 設為 `true`，且 [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/java/com.aspose.slides/idatalabelformat/#setNumberFormatLinkedToSource-boolean-) 也設為 `true`，所以每個標籤皆顯示其來源儲存格的值，且遵循來源的數字格式。儲存並重新開啟簡報後，標籤會顯示 `12.5000%` 與 `0.12346`，如下圖所示。垂直坐標軸使用自行設定的數字格式，透過 [setNumberFormat](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setNumberFormat-java.lang.String-) 設為 `0.00`，且 [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setNumberFormatLinkedToSource-boolean-) 設為 `false`。

若要獨立設定資料標籤，請將其來源連結旗標設為 `false`，再以 [setNumberFormat](https://reference.aspose.com/slides/java/com.aspose.slides/idatalabelformat/#setNumberFormat-java.lang.String-) 指定格式。此動作不會變更工作簿儲存格的格式。例如，獨立的標籤格式 `0.00` 會把第一個值顯示為 `0.13`，而 B2 仍顯示 `12.5000%`。請參閱[Chart Data Labels](/slides/zh-hant/java/chart-data-label/#set-percentage-sign-with-chart-data-labels) 以取得直接標籤格式化的說明。

以下圖片是重新開啟儲存的簡報後所渲染的結果：

![包含來源連結標籤顯示 12.5000% 與 0.12346，且坐標軸獨立格式化的柱狀圖。](custom-cell-formats.png)

## **將工作簿儲存格設定為圖表資料標籤**

您可以使用工作簿儲存格中的文字作為圖表資料標籤。

此範例在既有簡報的第一張投影片加入一個預設資料的泡泡圖，使用工作表 0 的 A10:A12 作為第一系列前三個標籤的來源，啟用來自儲存格的標籤，並儲存更新後的簡報。

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

[IChartDataWorkbook.getWorksheets](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdataworkbook/#getWorksheets--) 方法可取得圖表工作簿中的工作表集合。此範例建立一個預設資料的圓餅圖，並將每個工作表名稱列印至主控台。

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

此範例建立一個預設資料的 3D 柱狀圖，並使用不同資料來源設定兩個系列名稱。第一個名稱使用字串常量；第二個名稱使用工作表 0 的 C1 儲存格。[DataSourceType](https://reference.aspose.com/slides/java/com.aspose.slides/datasourcetype/) 列舉決定每個名稱的來源。範例會儲存已更新系列名稱的簡報。

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

Aspose.Slides 不支援可以嵌入於部分圖表中的 Excel 二進位工作簿 (.xlsb) 格式。您可以在[IChartData](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/) 上使用 [getEmbeddedWorkbookType](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#getEmbeddedWorkbookType--) 搭配 [WorkbookType](https://reference.aspose.com/slides/java/com.aspose.slides/workbooktype/) 列舉，來偵測不支援的格式並略過那些圖表。此範例檢查既有簡報第一張投影片上的圖形，略過非圖表的圖形，並為每個帶有嵌入 .xlsb 工作簿的圖表列印診斷訊息。

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

使用[readWorkbookStream](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#readWorkbookStream--)與[setExternalWorkbook](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#setExternalWorkbook-java.lang.String-)將嵌入的圖表工作簿匯出為檔案，並將圖表鏈結至該外部工作簿。

此範例建立一個預設資料的圓餅圖，並匯出其工作簿。檔案寫入完成後，將外部工作簿指派為圖表資料來源，最後儲存已鏈結的簡報。

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

使用[setExternalWorkbook](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#setExternalWorkbook-java.lang.String-) 方法，您可以將外部工作簿指派給圖表作為資料來源。此方法也可用於更新外部工作簿的路徑（若該檔案已搬移）。

雖然無法直接編輯儲存在遠端位置或資源中的工作簿資料，但仍可將此類工作簿作為外部資料來源。若提供相對路徑，系統會自動轉換為完整路徑。

此範例使用一個外部工作簿，該工作簿的工作表 `Sheet1` 在 B1 含有系列名稱，A2:A4 含有類別名稱，B2:B4 含有數值。範例建立圓餅圖、鏈結工作簿，並使用[setRange](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#setRange-java.lang.String-) 將 A1:B4 映射為一個系列與三個類別。最後儲存帶有鏈結圖表的簡報。

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

[setExternalWorkbook](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#setExternalWorkbook-java.lang.String-boolean-) 的 `updateChartData` 參數決定是否載入工作簿。

* 當 `updateChartData` 為 `false` 時，只會更新工作簿路徑。圖表資料不會從目標工作簿載入或更新，因而工作簿可以不存在。
* 當 `updateChartData` 為 `true` 時，圖表資料會從目標工作簿更新。

以下範例將 `updateChartData` 設為 `false`，同時指派佔位 URL。它保留圓餅圖的預設資料，且在未載入不可用的工作簿情況下儲存簡報。

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

### **取得圖表之外部資料來源工作簿路徑**

若要識別圖表所鏈結的工作簿，請先檢查圖表是否使用外部資料來源，然後取得其工作簿路徑。

此範例檢查簡報第一張投影片第一個圖形是否為鏈結外部工作簿的圖表；若是，則將[getExternalWorkbookPath](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#getExternalWorkbookPath--) 列印至主控台，最後儲存簡報的副本。

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

您可以以與編輯內部工作簿相同的方式編輯外部工作簿的資料。若無法載入外部工作簿，系統會拋出例外。

此範例使用第一張投影片上第一個圖形的圖表，且該圖表已鏈結至可存取的外部工作簿。它將第一系列第一資料點的儲存格值設定為 100，並儲存已更新的簡報。編輯儲存格值會更新鏈結的外部 XLSX 檔案，若需保留原始工作簿，請先建立副本。

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

若圖表使用的外部工作簿遺失或無法取得，Aspose.Slides 可以從簡報中快取的資料重建圖表工作簿。建立[LoadOptions](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/)，呼叫[LoadOptions.setSpreadsheetOptions](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/#setSpreadsheetOptions-com.aspose.slides.ISpreadsheetOptions-)，並在開啟簡報前將[ISpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/java/com.aspose.slides/ispreadsheetoptions/#setRecoverWorkbookFromChartCache-boolean-) 設為 `true`。

以下 Java 範例復原第一張投影片第一個圖形的圖表資料，該圖表參照了不可用的外部工作簿。它透過[IChart.getChartData](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#getChartData--) 與[IChartData.getChartDataWorkbook](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#getChartDataWorkbook--) 取得復原的資料：

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

若外部工作簿不可用且未啟用復原，Aspose.Slides 會拋出例外。僅在接受使用快取圖表資料作為可接受的備援時才啟用復原，因為快取可能不包含外部工作簿最後一次更新後的變更。

## **常見問題**

**我可以判斷特定圖表是鏈結至外部工作簿還是嵌入工作簿嗎？**

可以。圖表具有[資料來源類型](https://reference.aspose.com/slides/java/com.aspose.slides/chartdata/#getDataSourceType--) 與[外部工作簿的路徑](https://reference.aspose.com/slides/java/com.aspose.slides/chartdata/#getExternalWorkbookPath--)；若來源為外部工作簿，您可以讀取完整路徑以確認使用的是外部檔案。

**是否支援相對路徑的外部工作簿，且它們是如何儲存的？**

支援。若您指定相對路徑，系統會自動轉換為絕對路徑。簡報會在 PPTX 檔案中儲存絕對路徑，若工作簿搬移，可能需要更新連結。

**我可以使用位於網路資源/共享的工作簿嗎？**

可以，此類工作簿可作為外部資料來源使用。但 Aspose.Slides 不支援直接編輯遠端工作簿——只能將其作為來源使用。

**儲存簡報時，Aspose.Slides 會覆寫外部 XLSX 嗎？**

簡報會儲存[外部檔案的連結](https://reference.aspose.com/slides/java/com.aspose.slides/chartdata/#getExternalWorkbookPath--)。編輯以儲存格為基礎的圖表資料也可能會更新鏈結的本機 XLSX 檔案。若原始檔案必須保持不變，請使用該工作簿的副本。

**如果外部檔案受密碼保護，我該怎麼做？**

Aspose.Slides 連結時不接受密碼。常見做法是事先移除保護，或先製作已解密的副本（例如使用[Aspose.Cells](https://reference.aspose.com/cells/java/)），再鏈結至該副本。

**多個圖表可以參考同一個外部工作簿嗎？**

可以。每個圖表都會儲存自己的連結。只要它們指向同一個檔案，更新該檔案後，下次載入資料時所有圖表皆會反映變更。