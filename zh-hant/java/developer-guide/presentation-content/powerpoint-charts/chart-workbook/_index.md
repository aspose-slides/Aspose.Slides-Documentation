---
title: 使用 Java 在投影片中管理圖表活頁簿
linktitle: 圖表活頁簿
type: docs
weight: 70
url: /zh-hant/java/chart-workbook/
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
- Java
- Aspose.Slides
description: "探索 Aspose.Slides for Java：輕鬆在 PowerPoint 與 OpenDocument 格式中管理圖表活頁簿，以簡化您的投影片資料。"
---
## **概觀**

本文說明如何在 Aspose.Slides 中使用圖表活頁簿。它展示了如何透過活頁簿串流讀寫圖表資料、將活頁簿儲存格作為圖表資料標籤、存取工作表集合，以及為圖表值指定資料來源類型。

此外，亦說明如何使用外部活頁簿作為圖表資料來源。範例示範了如何建立並指派外部活頁簿、取得連結至圖表的外部活頁簿之路徑，以及在活頁簿可用時編輯圖表資料。

若活頁簿儲存格代表遺失資料，請參閱[控制空白儲存格的顯示](/slides/zh-hant/java/chart-series/)，了解空白儲存格與 0 之差異，以及可用顯示模式的折線圖比較。

## **包含隱藏列與欄的資料**

使用[IChart.setPlotVisibleCellsOnly](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#setPlotVisibleCellsOnly-boolean-)來控制圖表是否僅繪製可見工作表列與欄的資料。將其設為 `true` 只繪製可見儲存格，或設為 `false` 同時包含可見與隱藏儲存格。此設定僅影響圖表繪製，不會隱藏或取消隱藏工作表列或欄。

[範例投影片](hidden-source-data.pptx)的第一張投影片第一個圖形是一個直條圖。內嵌工作表 `Sheet1` 包含來源範圍 `A1:C4`。第 3 列與 C 欄被隱藏，但其儲存格仍有值。

| 工作表列 | A：月份 | B：零售 | C：批發（隱藏欄） |
| --- | --- | --- | --- |
| 2 | 一月 | 10 | 30 |
| 3（隱藏列） | 二月 | 40 | 60 |
| 4 | 三月 | 20 | 50 |

透過[IChartData.getChartDataWorkbook](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#getChartDataWorkbook--)存取來源儲存格，並讀取[IChartDataCell.isHidden](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatacell/#isHidden--)以檢查其隱藏狀態。此方法僅回報隱藏狀態不會變更它。在此範例中，B2 為可見，B3 屬於隱藏列，C2 屬於隱藏欄；範例分別輸出 `false`、`true`、`true`。

在此範例中，變更繪圖設定後請重新整理圖表資料：使用[readWorkbookStream](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#readWorkbookStream--)保留內嵌活頁簿，並以[writeWorkbookStream](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#writeWorkbookStream-byte---)重新載入。若要包含所有儲存格，亦請使用[setRange](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#setRange-java.lang.String-)恢復完整範圍（包括隱藏的二月類別）。僅變更旗標不足以重新整理此範例的快取圖表資料與類別標籤。

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
                // 恢復完整的來源範圍，包括隱藏的類別。
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

此範例會儲存兩個版本的投影片：一個僅包含可見的零售值（10 與 20），另一個包含全部六個值。下圖說明兩種繪圖模式。第 3 列與 C 欄在兩個內嵌活頁簿中皆保持隱藏。

| 僅顯示可見儲存格 (`true`) | 所有儲存格 (`false`) |
| --- | --- |
| ![僅顯示可見儲存格：一月與三月的零售值 10 與 20。](hidden_cells_True.png) | ![所有儲存格：一月、二月與三月的零售與批發值。](hidden_cells_False.png) |

包含值的隱藏儲存格不同於空白儲存格。[IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#setDisplayBlanksAs-int-)控制遺失值的顯示方式，並不會包含或排除隱藏的來源資料。請參閱[控制空白儲存格的顯示](/slides/zh-hant/java/chart-series/#control-the-display-of-empty-cells)取得範例。

## **取得圖表的資料範圍**

在更新現有投影片的活頁簿資料之前，請先檢查來源範圍，以辨識每個圖表使用的工作表儲存格。`[IChartData.getRange](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#getRange--)` 方法會以工作表限定的公式回傳目前資料範圍，例如 `Sheet1!$A$1:$D$5`。此處 `Sheet1` 為工作表名稱，`!` 為分隔符，`$A$1:$D$5` 表示從 A1 到 D5（含）之儲存格。美元符號表示絕對列與欄參照。

此方法在不變更圖表或其活頁簿的情況下讀取目前範圍。若圖表未使用活頁簿作為資料來源，會拋出 `InvalidOperationException`。更多資訊請參閱[ChartData API 參考文件](https://reference.aspose.com/slides/java/com.aspose.slides/chartdata/)。

此範例開啟投影片，直接檢查每張投影片上的圖形是否為圖表，並印出每個圖表的名稱與來源範圍。若圖表未使用活頁簿，會印出訊息並繼續處理下一個圖表。

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

Aspose.Slides for Java 提供 `[readWorkbookStream](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#readWorkbookStream--)` 與 `[writeWorkbookStream](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#writeWorkbookStream-byte---)` 方法，允許您讀寫圖表資料活頁簿（包含使用 Aspose.Cells 編輯的圖表資料）。**注意** 圖表資料必須以相同方式組織，或具備類似的結構。

此範例使用第一張投影片第一個圖形的直條圖。它將內嵌活頁簿讀取為位元組陣列，清除既有系列與類別，然後將相同的活頁簿寫回。變更保留在記憶體中；範例不會儲存投影片。

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

### **驗證活頁簿修改後的圖表布局**

當您以已修改的活頁簿取代內嵌活頁簿時，圖表仍保留原始的系列與類別集合。此不匹配可能導致 `[IChart.validateChartLayout](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#validateChartLayout--)` 失敗，拋出索引超出範圍的錯誤。請在寫回更新的活頁簿之前先清除既有系列與類別。本範例使用第一張投影片的第一個圖形。註解標示了活頁簿編輯將會發生的位置；可執行的範例寫回原始活頁簿並在記憶體中驗證布局。

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

清除集合可在活頁簿寫回前移除過時的資料參照。於使用圖表前，請為更新的活頁簿重新建構任何必要的系列與類別對應。

## **選擇類別標籤的儲存方式**

在加入標籤之前，先對空的類別集合呼叫 `[IChartCategoryCollection.setUseCells](https://reference.aspose.com/slides/java/com.aspose.slides/ichartcategorycollection/#setUseCells-boolean-)`。若標籤需要參考活頁簿資料或形成階層（例如按年度分的季），請使用工作表儲存格；若僅需單層文字標籤，請使用字串常值。此設定僅套用於類別。範例中的兩個圖表皆使用工作表儲存格作為數值系列。

範例建立兩個直條圖，並印出儲存模式，接著分別輸出 `Q1 Q2 Q3 Q4`。對於以工作表為後盾的標籤，`[IChartCategory.getAsCell](https://reference.aspose.com/slides/java/com.aspose.slides/ichartcategory/#getAsCell--)` 會回傳底層儲存格，而 `[IChartDataCell.getValue](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatacell/#getValue--)` 會取得其標籤。對於文字常值，直接使用 `[IChartCategory.getValue](https://reference.aspose.com/slides/java/com.aspose.slides/ichartcategory/#getValue--)` 讀取字串。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    IShapeCollection shapes = presentation.getSlides().get_Item(0).getShapes();

    for (boolean useCells : new boolean[] {true, false}) {
        int x = useCells ? 20 : 360;
        IChart chart = shapes.addChart(ChartType.ClusteredColumn, x, 20, 320, 250);
        IChartData data = chart.getChartData();
        data.getSeries().clear();
        IChartCategoryCollection categories = data.getCategories();
        categories.clear();
        categories.setUseCells(useCells);

        IChartDataWorkbook workbook = data.getChartDataWorkbook();
        IChartDataCell seriesName = workbook.getCell(0, 0, 1, "Sales");
        IChartSeries series = data.getSeries().add(seriesName, chart.getType());
        for (int row = 1; row <= 4; row++) {
            String label = "Q" + row;
            if (useCells) {
                IChartDataCell labelCell = workbook.getCell(0, row, 0, label);
                categories.add(labelCell);
            } else {
                categories.add(label);
            }

            IChartDataCell valueCell = workbook.getCell(0, row, 1, row * 10);
            series.getDataPoints().addDataPointForBarSeries(valueCell);
        }

        System.out.print("UseCells = " + categories.getUseCells() + ":");
        for (IChartCategory category : categories) {
            Object label = categories.getUseCells() ? category.getAsCell().getValue() : category.getValue();
            System.out.print(" " + label);
        }
        System.out.println();
    }

    presentation.save("category-labels.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **為活頁簿儲存格設定自訂數字格式**

使用 `[IChartDataCell.setCustomNumberFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatacell/#setCustomNumberFormat-java.lang.String-)` 來控制數值在圖表內嵌活頁簿中的顯示方式。例如，報表可能需要將轉換率以四位小數的百分比顯示，將係數以五位小數顯示。兩者皆保留為數字，以便仍可進行計算與圖表繪製。

數字格式僅影響顯示，不會改變儲存的值。格式 `0.0000%` 會將 `0.125` 顯示為 `12.5000%`，但不會把儲存的數字改為 `12.5`。同理，`0.00000` 會將 `0.1234567` 顯示為 `0.12346`，而不會捨入儲存值。若自訂格式為空字串 (`""`)，則使用 `[getPresetNumberFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatacell/#getPresetNumberFormat--)` 回傳的格式。

以下範例建立一個直條圖，透過 `[getChartDataWorkbook](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#getChartDataWorkbook--)` 存取其儲存格。於工作表 0，B2 含轉換率，C2 含係數。兩個儲存格皆提供圖表值，範例亦啟用與來源格式連結的數值標籤。

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

活頁簿儲存格格式與直接設定在圖表坐標軸或資料標籤上的格式彼此分離。在此範例中，每個標籤皆因 `[setShowValue](https://reference.aspose.com/slides/java/com.aspose.slides/idatalabelformat/#setShowValue-boolean-)` 設為 `true`，且因 `[setNumberFormatLinkedToSource](https://reference.aspose.com/slides/java/com.aspose.slides/idatalabelformat/#setNumberFormatLinkedToSource-boolean-)` 設為 `true` 而遵循來源數字格式。儲存並重新開啟投影片後，標籤分別顯示 `12.5000%` 與 `0.12346`，如下圖所示。垂直坐標軸使用自行設定的數字格式，透過 `[setNumberFormat](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setNumberFormat-java.lang.String-)` 設為 `0.00`，且 `[setNumberFormatLinkedToSource](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setNumberFormatLinkedToSource-boolean-)` 設為 `false`。

若要獨立格式化資料標籤，將其來源連結旗標設為 `false`，再以 `[setNumberFormat](https://reference.aspose.com/slides/java/com.aspose.slides/idatalabelformat/#setNumberFormat-java.lang.String-)` 指定格式。此操作不會改變活頁簿儲存格的格式。例如，獨立的 `0.00` 格式會將第一個值顯示為 `0.13`，而 B2 仍顯示 `12.5000%`。請參閱[圖表資料標籤](/slides/zh-hant/java/chart-data-label/#set-percentage-sign-with-chart-data-labels)取得直接標籤格式化的說明。

以下影像來自重新開啟後儲存的投影片：

![具有來源連結標籤顯示 12.5000% 與 0.12346，且坐標軸以獨立格式化的直條圖。](custom-cell-formats.png)

## **將活頁簿儲存格作為圖表資料標籤**

您可以使用活頁簿儲存格中的文字作為圖表資料標籤。

此範例在現有投影片的第一張投影片加入預設資料的氣泡圖，使用工作表 0 的儲存格 A10:A12 作為第一系列前三個標籤，啟用來自儲存格的標籤，並儲存更新後的投影片。

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

`[IChartDataWorkbook.getWorksheets](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdataworkbook/#getWorksheets--)` 方法提供存取圖表活頁簿中工作表的功能。此範例建立預設資料的圓餅圖，並將每個工作表名稱印至主控台。

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

系列點的值也可以直接以數字常值儲存。請參閱[使用數字常值設定系列值](/slides/zh-hant/java/chart-series/#set-series-values-using-numeric-literals)以取得完整範例，說明如何儲存與讀取這些值。點值的來源類型與圖表的內部或外部活頁簿設定是分開的；使用數字常值本身並不會移除內嵌活頁簿。

此範例建立預設資料的 3D 直條圖，並以不同的資料來源設定兩個系列名稱。第一個名稱使用字串常值；第二個名稱使用工作表 0 的儲存格 C1。`[DataSourceType](https://reference.aspose.com/slides/java/com.aspose.slides/datasourcetype/)` 列舉選擇每個名稱的來源。範例儲存更新後的系列名稱的投影片。

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

Aspose.Slides 不支援可嵌入於某些圖表之 Excel 二進位活頁簿（.xlsb）格式。您可以在 `[IChartData](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/)` 上使用 `[getEmbeddedWorkbookType](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#getEmbeddedWorkbookType--)` 搭配 `[WorkbookType](https://reference.aspose.com/slides/java/com.aspose.slides/workbooktype/)` 列舉，以偵測不支援的格式並跳過該圖表。此範例檢查現有投影片第一張投影片上的圖形，跳過非圖表圖形，並對每個內嵌 .xlsb 活頁簿的圖表印出診斷訊息。

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

Aspose.Slides 支援使用外部活頁簿作為圖表的資料來源。

### **建立外部活頁簿**

使用 `[readWorkbookStream](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#readWorkbookStream--)` 與 `[setExternalWorkbook](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#setExternalWorkbook-java.lang.String-)`，將內嵌圖表活頁簿匯出為檔案，並將圖表連結至該外部活頁簿。

此範例建立預設資料的圓餅圖，並匯出其活頁簿。寫入檔案完成後指派外部活頁簿作為圖表資料來源，最後儲存已連結的投影片。

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

### **設定外部活頁簿**

透過 `[setExternalWorkbook](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#setExternalWorkbook-java.lang.String-)` 方法，您可以將外部活頁簿指派給圖表作為資料來源。此方法亦可用於更新外部活頁簿的路徑（若該檔案已移動）。

雖然無法直接編輯儲存在遠端位置或資源中的活頁簿資料，但仍可將此類活頁簿作為外部資料來源。若提供相對路徑，系統會自動轉換為完整路徑。

此範例使用一個外部活頁簿，其工作表 `Sheet1` 內 B1 為系列名稱、A2:A4 為類別名稱、B2:B4 為數值。範例建立圓餅圖、連結活頁簿，並使用 `[setRange](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#setRange-java.lang.String-)` 將 A1:B4 映射為一個系列與三個類別。最後儲存已連結圖表的投影片。

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

`[setExternalWorkbook](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#setExternalWorkbook-java.lang.String-boolean-)` 的 `updateChartData` 參數決定是否載入活頁簿。

* 當 `updateChartData` 為 `false` 時，僅更新活頁簿路徑。圖表資料不會從目標活頁簿載入或更新，因而活頁簿可以不存在。
* 當 `updateChartData` 為 `true` 時，圖表資料會從目標活頁簿更新。

以下範例將 `updateChartData` 設為 `false`，指派一個佔位 URL。它保留圓餅圖的預設資料，並在未載入不可用的活頁簿時儲存投影片。

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

若要辨識圖表所連結的活頁簿，請先檢查圖表是否使用外部資料來源，然後取得其活頁簿路徑。

此範例檢查一個連結外部活頁簿的投影片的第一張投影片第一個圖形。若為連結外部活頁簿的圖表，範例會將 `[getExternalWorkbookPath](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#getExternalWorkbookPath--)` 印至主控台，然後儲存投影片的副本。

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

您可以以與編輯內部活頁簿相同的方式編輯外部活頁簿的資料。若外部活頁簿無法載入，將拋出例外。

此範例使用第一張投影片第一個圖形的圖表，且已連結至可存取的外部活頁簿。它將第一系列第一個資料點的儲存格值設為 100，並儲存更新後的投影片。編輯儲存格值會更新連結的外部 XLSX 檔案，若需保留原始活頁簿請使用副本。

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

如果圖表使用的外部活頁簿缺失或不可用，Aspose.Slides 可從投影片快取的資料重建圖表活頁簿。建立 `[LoadOptions](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/)`，呼叫 `[LoadOptions.setSpreadsheetOptions](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/#setSpreadsheetOptions-com.aspose.slides.ISpreadsheetOptions-)`，並在開啟投影片前將 `[ISpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/java/com.aspose.slides/ispreadsheetoptions/#setRecoverWorkbookFromChartCache-boolean-)` 設為 `true`。

以下 Java 範例復原第一張投影片第一個圖形的圖表資料，該圖表參考不可用的外部活頁簿。它透過 `[IChart.getChartData](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#getChartData--)` 與 `[IChartData.getChartDataWorkbook](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#getChartDataWorkbook--)` 取得復原的資料：

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

        // 在此讀取或修改復原的活頁簿資料。
    } else {
        System.out.println("The first shape is not a chart.");
    }
} finally {
    presentation.dispose();
}
```

若外部活頁簿不可用且未啟用復原，Aspose.Slides 會拋出例外。僅在使用快取圖表資料為可接受的備援方案時才啟用復原，因為快取可能不包含外部活頁簿在最後一次更新投影片後所做的變更。

## **常見問題集**

**我可以判斷特定圖表是連結至外部活頁簿還是內嵌活頁簿嗎？**

可以。圖表具備[資料來源類型](https://reference.aspose.com/slides/java/com.aspose.slides/chartdata/#getDataSourceType--)與[外部活頁簿路徑](https://reference.aspose.com/slides/java/com.aspose.slides/chartdata/#getExternalWorkbookPath--)；若來源為外部活頁簿，您可以讀取完整路徑以確定使用的是外部檔案。

**是否支援相對路徑的外部活頁簿，且它們是如何儲存的？**

支援。若您指定相對路徑，系統會自動轉換為絕對路徑。投影片會在 PPTX 檔案中儲存絕對路徑，搬移活頁簿時可能需要更新連結。

**我可以使用位於網路資源/共享上的活頁簿嗎？**

可以，這類活頁簿可作為外部資料來源使用。但 Aspose.Slides 不支援直接編輯遠端活頁簿——只能將其作為來源。

**儲存投影片時，Aspose.Slides 會覆寫外部 XLSX 嗎？**

投影片會儲存指向外部檔案的[連結](https://reference.aspose.com/slides/java/com.aspose.slides/chartdata/#getExternalWorkbookPath--)。編輯以儲存格為基礎的圖表資料也會更新連結的本機 XLSX 檔案。若原始檔案必須保持不變，請使用其副本。

**如果外部檔案受密碼保護，我該怎麼辦？**

Aspose.Slides 在建立連結時不接受密碼。常見做法是事先移除保護或使用已解密的副本（例如使用 [Aspose.Cells](https://reference.aspose.com/cells/java/)），再連結至該副本。

**多個圖表可以參考同一個外部活頁簿嗎？**

可以。每個圖表會儲存自己的連結。如果它們皆指向同一個檔案，更新該檔案後，下次載入資料時所有圖表皆會反映變更。