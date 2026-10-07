---
title: 在 Java 中管理簡報的圖表資料系列
linktitle: 資料系列
type: docs
url: /zh-hant/java/chart-series/
keywords:
- 圖表系列
- 系列重疊
- 系列顏色
- 系列名稱
- 資料點
- 活頁簿儲存格
- 系列間隙
- 負值
- PowerPoint
- 簡報
- Java
- Aspose.Slides
description: "了解如何在 Java 簡報中管理圖表系列、資料點、活頁簿儲存格、格式設定、重疊、間隙寬度以及負值。"
---
## **概述**

圖表將其繪製的資料儲存在圖表資料活頁簿中。 [IChartSeries](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/) 代表一組相關的值，而系列中的每個 [IChartDataPoint](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapoint/) 指向一個或多個活頁簿儲存格。 [IChartCategory](https://reference.aspose.com/slides/java/com.aspose.slides/ichartcategory/) 物件提供系列共享的標籤或分組值。因此，系列名稱、類別和資料點值是連結到 [IChartDataCell](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatacell/) 物件，而非僅以顯示文字儲存。

對於一般的類別圖表，預設活頁簿使用第 0 列儲存系列名稱，第 0 欄儲存類別名稱，其餘儲存格用於系列值。傳遞給 [IChartDataWorkbook.getCell](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdataworkbook/#getCell-int-int-int-) 的工作表、列和欄索引從零開始。此布局在建立帶有預設資料的圖表時很有用，但不要假設所有現有圖表都使用此布局。對於已載入的簡報，請在變更活頁簿值之前檢查系列、類別和資料點所參照的儲存格。

圖表設定具有三種不同的範圍：

- 系列層級設定，例如 [IChartSeries.getFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getFormat--)，提供單一系列中所有資料點的預設外觀。
- 資料點層級設定，例如 [IChartDataPoint.getFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapoint/#getFormat--)，會覆寫單一資料點的系列外觀。
- 群組設定套用於屬於同一個 [IChartSeriesGroup](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/) 的相容系列。需要設定重疊或間隙寬度等選項時，請透過 [IChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getParentSeriesGroup--) 取得群組。

當未設定明確的資料點或系列填色時，圖表樣式與主題會決定自動外觀。當同時存在系列與資料點格式設定時，資料點的格式會優先於該點。

![chart-series-powerpoint](chart-series-powerpoint.png)

## **設定圖表系列重疊**

[IChartSeries.getOverlap](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getOverlap--) 報告 2D 圖表中條形或柱形的重疊程度，範圍為 -100 到 100%。它是父系列群組設定的唯讀投影。使用 [IChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/#setOverlap-byte-) 來更新該群組中所有相容系列。此選項適用於顯示分組條形或柱形的圖表類型；對組合圖表中不相關的系列群組無影響。

以下範例設定包含第一個系列的群組的重疊：

```java
import com.aspose.slides.*;

final int firstSlideIndex = 0;
final int firstSeriesIndex = 0;
final byte overlapPercent = 30;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    // 此新圖表包含示範系列、類別和數值。
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    IChartSeries series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    series.getParentSeriesGroup().setOverlap(overlapPercent);

    presentation.save("series_overlap.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果：

![系列重疊](series_overlap.png)

## **變更系列填色**

使用 [IChartSeries.getFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getFormat--) 為整個系列設定預設填色。如果資料點已經有明確的填色，其 [IChartDataPoint.getFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapoint/#getFormat--) 設定會覆寫該點的系列填色。

以下範例將第一個系列套用實心藍色填色：

```java
import com.aspose.slides.*;
import java.awt.Color;

final int firstSlideIndex = 0;
final int firstSeriesIndex = 0;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    IChartSeries series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    series.getFormat().getFill().setFillType(FillType.Solid);
    series.getFormat().getFill().getSolidFillColor().setColor(Color.BLUE);

    presentation.save("series_color.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果：

![系列顏色](series_color.png)

## **變更系列名稱**

系列名稱儲存在圖表資料活頁簿中，通常顯示於圖例。對於叢集柱形圖的預設活頁簿，儲存格 B1 位於第 0 列第 1 欄，包含第一個系列的名稱。下列範例中的命名常數明確說明此結構：

```java
import com.aspose.slides.*;

final int firstSlideIndex = 0;
final int worksheetIndex = 0;
final int seriesNameRowIndex = 0;
final int firstSeriesColumnIndex = 1;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    IChartDataCell seriesNameCell = workbook.getCell(worksheetIndex, seriesNameRowIndex, firstSeriesColumnIndex);
    seriesNameCell.setValue("Revenue");

    presentation.save("series_name.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

您也可以直接更新由 [IChartSeries.getName](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getName--) 參照的儲存格。此作法不必假設現有圖表中的特定列與欄：

```java
import com.aspose.slides.*;

final int firstSlideIndex = 0;
final int firstSeriesIndex = 0;
final int firstNameCellIndex = 0;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    IChartSeries series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    IChartDataCell seriesNameCell = series.getName().getAsCells().get_Item(firstNameCellIndex);
    seriesNameCell.setValue("Revenue");

    presentation.save("series_name.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果：

![系列名稱](series_name.png)

### **從多個儲存格建立具有名稱的系列**

當產品名稱與報告期間分別儲存在不同活頁簿儲存格時，複合系列名稱會很有用。例如，您可以將 B1 中的 `Product A` 與 C1 中的 `2026` 合併為單一系列名稱，同時保留兩個部份與其來源儲存格的連結。

使用 [IChartDataWorkbook.getCellCollection](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdataworkbook/#getCellCollection-java.lang.String-boolean-) 取得名稱範圍，然後將該集合傳遞給 [IChartSeriesCollection.add](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriescollection/#add-com.aspose.slides.IChartCellCollection-int-)。`skipHiddenCells` 參數控制是否包含隱藏儲存格：`true` 會排除，`false` 會包含。本範例使用 `false` 以包含名稱範圍內的所有儲存格。

以下範例建立一個包含一個系列與兩個資料點的簡報。儲存格 B1:C1 僅提供系列名稱；A2:A3 提供類別標籤，B2:B3 提供數值。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 620, 180);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    chart.setLegend(true);

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    // 這兩個儲存格提供系列名稱。
    workbook.getCell(0, 0, 1, "Product A");
    workbook.getCell(0, 0, 2, "2026");
    IChartCellCollection nameCells = workbook.getCellCollection("Sheet1!$B$1:$C$1", false);
    IChartSeries series = chart.getChartData().getSeries().add(nameCells, ChartType.ClusteredColumn);

    // 分別的儲存格提供類別與數值資料點。
    IChartDataCell northCategory = workbook.getCell(0, 1, 0, "North");
    IChartDataCell southCategory = workbook.getCell(0, 2, 0, "South");
    chart.getChartData().getCategories().add(northCategory);
    chart.getChartData().getCategories().add(southCategory);
    IChartDataCell northValue = workbook.getCell(0, 1, 1, 120);
    IChartDataCell southValue = workbook.getCell(0, 2, 1, 150);
    series.getDataPoints().addDataPointForBarSeries(northValue);
    series.getDataPoints().addDataPointForBarSeries(southValue);

    presentation.save("composite_series_name.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

最終的系列名稱為 `Product A 2026`，兩個儲存格值之間有一個空格。圖例將其顯示為同一個條目。下圖說明結果：

![Column chart with North and South values and the composite series name Product A 2026 in the legend](composite_series_name.png)

## **取得自動系列填色**

[IChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getAutomaticSeriesColor--) 會根據系列索引與圖表樣式計算顏色。當系列填色未明確定義時，使用此顏色。呼叫此方法僅是讀取計算出的顏色，並不會指派新的填色。

以下範例列印每個預設系列的自動顏色：

```java
import com.aspose.slides.*;
import java.awt.Color;

final int firstSlideIndex = 0;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    int seriesCount = chart.getChartData().getSeries().size();
    for (int seriesIndex = 0; seriesIndex < seriesCount; seriesIndex++) {
        IChartSeries series = chart.getChartData().getSeries().get_Item(seriesIndex);
        Color automaticColor = series.getAutomaticSeriesColor();
        System.out.println("Series " + seriesIndex + ": " + automaticColor);
    }
} finally {
    presentation.dispose();
}
```

預設圖表樣式的範例輸出：

```text
Series 0: java.awt.Color[r=79,g=129,b=189]
Series 1: java.awt.Color[r=192,g=80,b=77]
Series 2: java.awt.Color[r=155,g=187,b=89]
```

實際顏色取決於圖表樣式與主題。

## **設定圖表系列的反轉填色**

對於條形、柱形與氣泡系列，[IChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#setInvertIfNegative-boolean-) 可在負值時顯示不同的填色。先將常規系列填色設定為實心，啟用反轉，然後透過 [IChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getInvertedSolidFillColor--) 指定負值的顏色。負數在活頁簿中保持不變，僅改變其顯示顏色。

以下範例以單一系列取代預設圖表資料。工作表第 0 列為系列名稱，第 0 欄為類別名稱，第 1 欄為數值：

```java
import com.aspose.slides.*;
import java.awt.Color;

final int firstSlideIndex = 0;
final int worksheetIndex = 0;
final int headerRowIndex = 0;
final int categoryColumnIndex = 0;
final int firstSeriesColumnIndex = 1;
final int firstDataRowIndex = 1;

String[] categoryNames = { "Category 1", "Category 2", "Category 3" };
int[] seriesValues = { -20, 50, -30 };

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200);
    IChartData chartData = chart.getChartData();
    IChartDataWorkbook workbook = chartData.getChartDataWorkbook();

    chartData.getSeries().clear();
    chartData.getCategories().clear();

    IChartDataCell seriesNameCell = workbook.getCell(worksheetIndex, headerRowIndex, firstSeriesColumnIndex, "Series 1");
    int chartType = chart.getType();
    IChartSeries series = chartData.getSeries().add(seriesNameCell, chartType);

    for (int categoryIndex = 0; categoryIndex < categoryNames.length; categoryIndex++) {
        int dataRowIndex = firstDataRowIndex + categoryIndex;
        String categoryName = categoryNames[categoryIndex];
        int seriesValue = seriesValues[categoryIndex];

        IChartDataCell categoryCell = workbook.getCell(worksheetIndex, dataRowIndex, categoryColumnIndex, categoryName);
        chartData.getCategories().add(categoryCell);

        IChartDataCell valueCell = workbook.getCell(worksheetIndex, dataRowIndex, firstSeriesColumnIndex, seriesValue);
        series.getDataPoints().addDataPointForBarSeries(valueCell);
    }

    Color automaticSeriesColor = series.getAutomaticSeriesColor();
    series.getFormat().getFill().setFillType(FillType.Solid);
    series.getFormat().getFill().getSolidFillColor().setColor(automaticSeriesColor);
    series.setInvertIfNegative(true);
    series.getInvertedSolidFillColor().setColor(Color.RED);

    presentation.save("inverted_solid_fill_color.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果：

![反轉實心填色](inverted_solid_fill_color.png)

您也可以透過 [IChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapoint/#setInvertIfNegative-boolean-) 為單一資料點啟用反轉。以下範例中，系列的反轉被關閉，僅對所選資料點啟用，且該點亦被賦予負值以便觀察效果：

```java
import com.aspose.slides.*;
import java.awt.Color;

final int firstSlideIndex = 0;
final int firstSeriesIndex = 0;
final int targetDataPointIndex = 2;
final int negativeValue = -30;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    IChartSeries series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    Color automaticSeriesColor = series.getAutomaticSeriesColor();
    series.getFormat().getFill().setFillType(FillType.Solid);
    series.getFormat().getFill().getSolidFillColor().setColor(automaticSeriesColor);
    series.getInvertedSolidFillColor().setColor(Color.RED);
    series.setInvertIfNegative(false);

    IChartDataPoint dataPoint = series.getDataPoints().get_Item(targetDataPointIndex);
    dataPoint.getValue().getAsCell().setValue(negativeValue);
    dataPoint.setInvertIfNegative(true);

    presentation.save("data_point_invert_color_if_negative.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **清除特定資料點的值**

若想將單一資料點設為空白而不移除其他點，請將其對應的活頁簿儲存格設為 `null`。對於柱形圖，可透過 [IChartDataPoint.getValue](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapoint/#getValue--) 取得繪製值。資料點仍保留在相同的類別位置，但圖表會根據空白值設定將其視為空白。

以下範例僅清除第一個系列的第二個點：

```java
import com.aspose.slides.*;

final int firstSlideIndex = 0;
final int firstSeriesIndex = 0;
final int targetDataPointIndex = 1;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    IChartSeries series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    IChartDataPoint dataPoint = series.getDataPoints().get_Item(targetDataPointIndex);
    dataPoint.getValue().getAsCell().setValue(null);

    presentation.save("clear_data_point_value.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

散佈圖使用分開的 X 與 Y 儲存格，氣泡圖亦使用尺寸儲存格。僅清除您欲移除之值所對應的儲存格。若只想保留其他點，請勿呼叫 [IChartDataPointCollection.clear](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapointcollection/#clear--)，因為該方法會移除該系列的全部資料點。

## **控制空儲存格的顯示**

包含值的隱藏儲存格屬於與空儲存格不同的情況。若要包含或排除隱藏工作表列與欄的資料，請參閱 [Include Data from Hidden Rows and Columns](/slides/zh-hant/java/chart-workbook/#include-data-from-hidden-rows-and-columns)。

空的活頁簿儲存格代表缺失的資料；含 `0` 的儲存格則代表已知的數值。呼叫 [IChartDataCell.setValue](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatacell/#setValue-java.lang.Object-) 並傳入 `null` 可將儲存格設為空白。數值零無論空白儲存格設定為何，都會保持為零。

使用 [IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#setDisplayBlanksAs-int-) 來選擇圖表如何顯示空儲存格。此設定套用於整個圖表，會改變空白的繪製方式，但不會將空儲存格填入零或插值。

以下獨立範例建立一個包含單一系列的折線圖，清除第 3 天的值，並以每種模式分別儲存相同圖表。此範例不需要輸入檔案。[IChartDataWorkbook](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdataworkbook/) 使用工作表 0、欄 0 作為類別標籤，欄 1 作為數值；第 0 列保留系列名稱。最終資料為 `10, 20, empty, 30, 40`。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 40, 40, 640, 400);
    IChartData chartData = chart.getChartData();
    IChartDataWorkbook workbook = chartData.getChartDataWorkbook();

    chartData.getSeries().clear();
    chartData.getCategories().clear();

    IChartDataCell seriesNameCell = workbook.getCell(0, 0, 1, "Measurements");
    IChartSeries series = chartData.getSeries().add(seriesNameCell, chart.getType());
    int[] values = { 10, 20, 25, 30, 40 };

    for (int i = 0; i < values.length; i++) {
        IChartDataCell categoryCell = workbook.getCell(0, i + 1, 0, "Day " + (i + 1));
        chartData.getCategories().add(categoryCell);
        IChartDataCell valueCell = workbook.getCell(0, i + 1, 1, values[i]);
        series.getDataPoints().addDataPointForLineSeries(valueCell);
    }

    // 將第 3 天真正設為空白，同時保留其類別和資料點。
    workbook.getCell(0, 3, 1).setValue(null);

    int[] modes = { DisplayBlanksAsType.Gap, DisplayBlanksAsType.Zero, DisplayBlanksAsType.Span };
    String[] modeNames = { "Gap", "Zero", "Span" };
    for (int i = 0; i < modes.length; i++) {
        chart.setDisplayBlanksAs(modes[i]);
        presentation.save("empty_cells_" + modeNames[i] + ".pptx", SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

每個輸出檔案在儲存前皆記錄所指定的模式：`empty_cells_Gap.pptx`、`empty_cells_Zero.pptx` 與 `empty_cells_Span.pptx`。若只想產生單一版本，請設定所需模式後僅儲存一次簡報，而非對所有模式迭代。

以下比較顯示三個檔案中相同資料的呈現。第 3 天在活頁簿中皆為空白：

![Line charts with identical data: Gap breaks the line at Day 3, Zero drops the line to zero, and Span connects Day 2 to Day 4.](display_blanks_as.png)

可見效果取決於圖表類型。折線圖能清楚比較三種模式。條形與柱形圖沒有連線可跨過缺失的類別，因此 `Span` 無法產生上圖所示的連接段落；缺失的欄與零高度的欄也可能看起來相似。類似地，僅使用標記的散佈圖也沒有連線。不要期望每種圖表類型都會產生三種明顯不同的結果；請檢查您使用的圖表類型的輸出。

## **設定系列間隙寬度**

間隙寬度是相鄰條形或柱形叢集之間的空間，以條形或柱形寬度的百分比表示。與重疊類似，它屬於父系列群組而非單一系列。對該群組呼叫一次 [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-)。較大的數值會在叢集之間留下更多空間，較小的數值則使它們更緊密。

以下範例變更間隙寬度並僅儲存最終簡報：

```java
import com.aspose.slides.*;

final int firstSlideIndex = 0;
final int firstSeriesIndex = 0;
final int gapWidthPercent = 30;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    IChart chart = slide.getShapes().addChart(ChartType.StackedColumn, 20, 20, 500, 200);

    IChartSeries series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    series.getParentSeriesGroup().setGapWidth(gapWidthPercent);

    presentation.save("gap_width_30.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果：

![間隙寬度](gap_width.png)

## **常見問題**

**哪種類型的圖表支援資料系列？**

所有由 [ChartType](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/) 列舉表示的圖表類型皆使用圖表資料，但它們的系列並非都有相同的值結構或設定。例如，類別圖使用類別與數值，散佈圖使用 X 與 Y 值，氣泡圖則額外使用氣泡大小。請使用與系列類型相符的資料點建立方法。重疊與間隙寬度等選項僅套用於相容的條形或柱形群組。

**什麼是圖表系列群組？**

[IChartSeriesGroup](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/) 包含共享群組層級繪製設定的相容系列。組合圖表可包含多個群組，因此透過單一系列取得的群組設定不一定會影響圖表中的所有系列。

**新建立的圖表是否包含預設資料？**

是的。預設情況下，[IShapeCollection.addChart](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addChart-int-float-float-float-float-) 會建立示範系列、類別與數值。您可以編輯這些儲存格，或在加入完全自訂的資料集之前先清除系列與類別集合。也有可不產生預設資料的重載。

**圖表物件如何與活頁簿儲存格連結？**

系列名稱、類別標籤與資料點數值皆參照 [IChartDataWorkbook](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdataworkbook/) 中的儲存格。變更所參照的儲存格會更新對應的圖表元素。自行建立資料時，請確保類別列與系列值列對齊，使每個點都繪製在預期的類別下。

**如何只清除單一資料點而不是整個系列？**

將相關的值儲存格設為 `null`，即可保留該點的類別位置作為空白點。僅在需要移除該系列所有資料點時才使用 [IChartDataPointCollection.clear](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapointcollection/#clear--)；此方法會移除該系列的全部資料點。若同時移除類別，請確保所有系列的值仍與類別集合對齊。

**空白資料點如何顯示？**

顯示結果取決於圖表類型以及透過 [IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#setDisplayBlanksAs-int-) 設定的值。支援的圖表可以將空白顯示為間隙、零值，或是連接相鄰點。請選擇符合簡報中遺失資料意義的設定。完整範例與視覺比較請參閱 [控制空儲存格的顯示](#control-the-display-of-empty-cells)。

**負值如何格式化？**

對於支援的條形、柱形與氣泡系列，呼叫 [IChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#setInvertIfNegative-boolean-) 並設定由 [IChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getInvertedSolidFillColor--) 取得的顏色。您也可以透過 [IChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapoint/#setInvertIfNegative-boolean-) 為單一資料點覆寫此行為。這些方法僅影響格式，不會改變儲存的數值。

**當系列與資料點同時設定格式時，哪一個優先？**

明確的資料點格式會優先套用於該點。其他資料點則繼續使用明確的系列格式，或在未定義系列格式時使用自動圖表樣式與主題。群組設定（如重疊與間隙寬度）屬於版面配置，並不會覆寫資料點層級的格式。

**圖表可以包含的系列數量是否有限制？**

Aspose.Slides 本身未設置固定的系列數量上限。實務上，簡報檔案的限制、可用記憶體、渲染時間與圖表可讀性會決定實際可用的上限。

**當柱狀圖的欄位過於靠近或過於分離時，應該調整什麼？**

請對適當的父系列群組呼叫 [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-)。增大數值會擴大叢集之間的間距，減小數值則使叢集更緊密。