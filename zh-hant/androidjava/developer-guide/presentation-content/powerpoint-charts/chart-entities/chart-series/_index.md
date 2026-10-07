---
title: 在 Android 上管理簡報中的圖表資料系列
linktitle: 資料系列
type: docs
url: /zh-hant/androidjava/chart-series/
keywords:
- 圖表系列
- 系列重疊
- 系列顏色
- 系列名稱
- 資料點
- 工作簿儲存格
- 系列間隙
- 負值
- PowerPoint
- 簡報
- Android
- Java
- Aspose.Slides
description: "了解如何在 Android 簡報中管理圖表系列、資料點、工作簿儲存格、格式設定、重疊、間隙寬度以及負值。"
---
## **概覽**

圖表將其繪製的資料儲存在圖表資料工作簿中。一個 [IChartSeries](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/) 代表一組相關的數值，而系列中的每個 [IChartDataPoint](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapoint/) 參照一個或多個工作簿儲存格。[IChartCategory](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartcategory/) 物件提供由系列共用的標籤或分組值。因此，系列名稱、類別以及點值皆連結至 [IChartDataCell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatacell/) 物件，而非僅以顯示文字儲存。

對於一般的類別圖表，預設工作簿使用第 0 列儲存系列名稱，第 0 欄儲存類別名稱，其餘儲存格則存放系列數值。傳遞給 [IChartDataWorkbook.getCell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdataworkbook/#getCell-int-int-int-) 的工作表、列與欄索引皆為零基。此佈局在建立具有預設資料的圖表時很有用，但請勿假設每個既有圖表皆使用此方式。載入簡報時，請先檢查系列、類別與資料點所參照的儲存格，再變更工作簿值。

圖表設定有三種不同的範圍：

- 系列層級設定，例如 [IChartSeries.getFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getFormat--)，提供整個系列所有點的預設外觀。
- 資料點層級設定，例如 [IChartDataPoint.getFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapoint/#getFormat--)，會覆寫該點的系列外觀。
- 群組設定套用於屬於同一個 [IChartSeriesGroup](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/) 的相容系列。需要設定重疊或間隙寬度等選項時，請透過 [IChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getParentSeriesGroup--) 取得群組。

當未明確設定點或系列填色時，圖表樣式與佈景主題會決定自動外觀。當同時存在系列與點的格式設定時，點的格式會優先套用於該點。

![chart-series-powerpoint](chart-series-powerpoint.png)

## **設定圖表系列的重疊度**

[IChartSeries.getOverlap](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getOverlap--) 回報 2D 圖表中長條或柱狀的重疊程度，範圍為 -100% 到 100%。它是父系列群組上設定的唯讀投影。使用 [IChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/#setOverlap-byte-) 來更新該群組中所有相容系列。此選項適用於顯示分組長條或柱狀的圖表類型；不會影響組合圖中不相關的系列群組。

以下範例為包含第一個系列的群組設定重疊度：

```java
import com.aspose.slides.*;

final int firstSlideIndex = 0;
final int firstSeriesIndex = 0;
final byte overlapPercent = 30;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    // 新的圖表包含範例系列、類別和數值。
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    IChartSeries series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    series.getParentSeriesGroup().setOverlap(overlapPercent);

    presentation.save("series_overlap.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果：

![The series overlap](series_overlap.png)

## **變更系列填色**

使用 [IChartSeries.getFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getFormat--) 來設定整個系列的預設填色。如果某個點已經有明確的填色，其 [IChartDataPoint.getFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapoint/#getFormat--) 設定會覆寫該系列的填色。

以下範例將第一個系列套用實心藍色填色：

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

![The color of the series](series_color.png)

## **變更系列名稱**

系列名稱儲存在圖表資料工作簿中，通常會在圖例中顯示。對於預設建立的叢集柱狀圖，儲存格 B1 位於第 0 列第 1 欄，儲存第一個系列的名稱。下列範例中的具名常數將此結構具體化：

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

您也可以更新由 [IChartSeries.getName](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getName--) 已參照的儲存格。此方法避免在既有圖表中假設特定的列與欄：

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

![The series name](series_name.png)

### **從多個儲存格建立具名稱的系列**

當產品名稱與報告期間分別儲存在不同儲存格時，合成系列名稱會很有用。例如，您可以將 B1 中的 `Product A` 與 C1 中的 `2026` 組合成單一系列名稱，同時保留兩個部分與來源儲存格的連結。

使用 [IChartDataWorkbook.getCellCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdataworkbook/#getCellCollection-java.lang.String-boolean-) 取得名稱範圍，然後將該集合傳遞給 [IChartSeriesCollection.add](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriescollection/#add-com.aspose.slides.IChartCellCollection-int-)。`skipHiddenCells` 參數決定是否包含隱藏儲存格：`true` 會排除，`false` 會包含。本範例使用 `false` 以包含名稱範圍中的所有儲存格。

以下範例建立一個包含一個系列與兩個資料點的簡報。儲存格 B1:C1 僅提供系列名稱；A2:A3 提供類別標籤；B2:B3 提供數值。

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

    // 分別的儲存格提供類別和數值資料點。
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

產生的系列名稱為 `Product A 2026`，兩個儲存格值之間有一個空格。圖例會將其顯示為兩個欄位的單一項目。下圖說明結果：

![Column chart with North and South values and the composite series name Product A 2026 in the legend](composite_series_name.png)

## **取得自動系列填色**

[IChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getAutomaticSeriesColor--) 會回傳依系列索引與圖表樣式計算出的 Android ARGB 顏色整數。此顏色會在系列填色未明確定義時使用。呼叫此方法僅會讀取計算出的顏色，不會指派新的填色。

以下範例列印每個預設系列的自動顏色整數：

```java
import com.aspose.slides.*;

final int firstSlideIndex = 0;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    int seriesCount = chart.getChartData().getSeries().size();
    for (int seriesIndex = 0; seriesIndex < seriesCount; seriesIndex++) {
        IChartSeries series = chart.getChartData().getSeries().get_Item(seriesIndex);
        int automaticColor = series.getAutomaticSeriesColor();
        System.out.println("Series " + seriesIndex + ": " + automaticColor);
    }
} finally {
    presentation.dispose();
}
```

具體的整數值取決於圖表樣式與佈景主題。

## **為圖表系列設定負值反轉填色**

對於長條、柱狀與氣泡系列，您可以使用 [IChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#setInvertIfNegative-boolean-) 於負值時顯示不同的填色。先將系列的常規填色設定為實心，啟用反轉，並透過 [IChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getInvertedSolidFillColor--) 指定負值的顏色。負數在工作簿中保持不變，僅改變其顯示顏色。

以下範例以單一系列取代預設圖表資料。工作表第 0 列包含系列名稱，第 0 欄包含類別名稱，第 1 欄包含數值：

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

    int automaticSeriesColor = series.getAutomaticSeriesColor();
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

![The inverted solid fill color](inverted_solid_fill_color.png)

您亦可使用 [IChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapoint/#setInvertIfNegative-boolean-) 為單一點啟用反轉。以下範例在系列層面停用反轉，僅於選取的點啟用，且為該點指定負值以顯示效果：

```java
import com.aspose.slides.*;
import android.graphics.Color;

final int firstSlideIndex = 0;
final int firstSeriesIndex = 0;
final int targetDataPointIndex = 2;
final int negativeValue = -30;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    IChartSeries series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    int automaticSeriesColor = series.getAutomaticSeriesColor();
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

若要使某一點變為空白而不移除其他點，請將其對應的工作簿儲存格設為 `null`。對於柱狀圖，繪製的數值可透過 [IChartDataPoint.getValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapoint/#getValue--) 取得。資料點仍保留在相同的類別位置，只是圖表會依照空白值設定將其視為空白。

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

散佈圖使用分別的 X 與 Y 儲存格，氣泡圖亦使用大小儲存格。僅清除您欲移除之數值所對應的儲存格。若只想保留其他點，請勿呼叫 [IChartDataPointCollection.clear](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapointcollection/#clear--)，因為該方法會移除集合中的所有資料點。

## **控制空白儲存格的顯示方式**

隱藏的儲存格即使包含值，也屬於與空白儲存格不同的情況。若要包含或排除隱藏工作表列與欄的資料，請參閱 [Include Data from Hidden Rows and Columns](/slides/zh-hant/androidjava/chart-workbook/#include-data-from-hidden-rows-and-columns)。

空白工作簿儲存格代表缺失資料；儲存格內含 `0` 則代表已知的數值。呼叫 [IChartDataCell.setValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatacell/#setValue-java.lang.Object-) 並傳入 `null` 即可使儲存格變為空白。數值 0 無論空白儲存格的設定如何，仍會保持為 0。

使用 [IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#setDisplayBlanksAs-int-) 來選擇圖表如何顯示空白儲存格。此設定套用於整個圖表，會改變空白的繪製方式，而不會將空白工作簿儲存格填入 0 或插值。

以下自包含範例建立一個單系列折線圖，清除第 3 天的值，並以每種模式分別儲存同一張圖表。此範例不需要輸入檔案。[IChartDataWorkbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdataworkbook/) 使用工作表 0，欄 0 為類別標籤，欄 1 為數值；第 0 列為系列名稱。最終資料為 `10, 20, empty, 30, 40`。

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

    // 讓第 3 天真正保持空白，同時保留其類別和資料點。
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

每個輸出檔案會在存檔前設定相應的模式：`empty_cells_Gap.pptx`、`empty_cells_Zero.pptx` 與 `empty_cells_Span.pptx`。若只需其中一個版本，只需在儲存簡報前設定所需的模式即可，無需遍歷所有模式。

下圖比較了三個檔案中相同的資料。第 3 天在工作簿中皆為空白：

![Line charts with identical data: Gap breaks the line at Day 3, Zero drops the line to zero, and Span connects Day 2 to Day 4.](display_blanks_as.png)

可見效果取決於圖表類型。折線圖可清楚比較三種模式。長條與柱狀圖因缺少連接線而無法呈現 `Span` 模式的連接段落；缺少的柱與零高度的柱也可能看起來相似。同樣地，僅有標記的散佈圖也沒有連線。不要期望每種圖表類型皆有三種明顯不同的結果；請檢查您使用的圖表類型的輸出。

## **設定系列間隙寬度**

間隙寬度是相鄰長條或柱狀叢集之間的空間，以長條或柱狀寬度的百分比表示。與重疊度類似，它屬於父系列群組而非單一系列。對群組呼叫一次 [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-) 即可。較大的值會在叢集之間產生更多空間，較小的值則使其更密集。

以下範例變更間隙寬度，並僅儲存最終簡報：

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

![The gap width](gap_width.png)

## **常見問題**

**哪些圖表類型支援資料系列？**

所有由 [ChartType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/) 列舉表示的圖表類型皆使用圖表資料，但其系列的值結構與設定並不完全相同。例如，類別圖表使用類別與數值，散佈圖使用 X 與 Y 值，氣泡圖則額外加入氣泡大小。請使用符合系列類型的資料點建立方法。重疊與間隙寬度等選項僅適用於相容的長條或柱狀群組。

**什麼是圖表系列群組？**

[IChartSeriesGroup](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/) 包含共享群組層級繪製設定的相容系列。組合圖可包含多個群組，因此透過單一系列取得的群組設定未必會影響圖表中的所有系列。

**新建立的圖表會包含預設資料嗎？**

會。預設情況下，[IShapeCollection.addChart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addChart-int-float-float-float-float-) 會建立範例系列、類別與數值。您可以編輯這些儲存格，或在加入完全自訂的資料集之前先清除系列與類別集合。也有重載方法可建立不含預設資料的圖表。

**圖表物件如何連結至工作簿儲存格？**

系列名稱、類別標籤與資料點數值皆參照 [IChartDataWorkbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdataworkbook/) 中的儲存格。變更被參照的儲存格會即時更新相應的圖表元素。建構自訂資料時，請確保類別列與系列值列對齊，以便每個點正確繪製於預期的類別之下。

**如何只清除單一點而不是整個系列？**

將相關的值儲存格設為 `null`，即可保留該點的類別位置作為空白點。僅在您確實要移除該系列所有點時，才使用 [IChartDataPointCollection.clear](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapointcollection/#clear--)；此方法會刪除該系列的全部資料點。如果同時移除類別，請同步更新所有系列，使其值仍與類別集合保持對齊。

**空白點會如何顯示？**

顯示結果取決於圖表類型以及透過 [IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#setDisplayBlanksAs-int-) 設定的方式。支援的圖表可將空白顯示為間隙、零值，或連接相鄰點。請選擇最符合您簡報中缺失資料意義的設定。完整範例與視覺比較請參閱 [Control the Display of Empty Cells](#control-the-display-of-empty-cells)。

**負值的格式如何設定？**

對於支援的長條、柱狀與氣泡系列，呼叫 [IChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#setInvertIfNegative-boolean-)，並設定 [IChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getInvertedSolidFillColor--) 所回傳的顏色。您亦可使用 [IChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapoint/#setInvertIfNegative-boolean-) 為單一資料點覆寫此行為。這些方法僅影響格式，不會變更儲存的數值。

**當系列與點同時被格式化時，哪個會優先？**

明確的資料點格式會優先套用於該點。其他點仍會使用明確的系列格式，或在系列格式未定義時使用自動的圖表樣式與佈景主題。群組設定（如重疊與間隙寬度）屬於版面配置，並不會覆寫點層級的格式。

**圖表可以包含多少系列？有上限嗎？**

Aspose.Slides 本身沒有設定固定的系列數上限。實務上，簡報檔案的限制、可用記憶體、渲染時間與圖表的可讀性會決定實際可用的上限。

**當欄位過於接近或過於遙遠時該怎麼調整？**

對適當的父系列群組呼叫 [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-)。增大數值會擴大叢集之間的空間，減小則會使叢集更靠近。