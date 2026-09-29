---
title: 在 Android 簡報中管理圖表資料系列
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
- 系列間距
- 負值
- PowerPoint
- 簡報
- Android
- Java
- Aspose.Slides
description: "了解如何在 Android 簡報中管理圖表系列、資料點、工作簿儲存格、格式設定、重疊、間距寬度及負值。"
---
## **概觀**

圖表將其繪製的資料儲存在圖表資料工作簿中。 [IChartSeries](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ichartseries/) 代表一組相關的數值，系列中的每個 [IChartDataPoint](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ichartdatapoint/) 參考一個或多個工作簿儲存格。[IChartCategory](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ichartcategory/) 物件提供系列共用的標籤或分組值。因此，系列名稱、類別和資料點值會連結到 [IChartDataCell](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ichartdatacell/) 物件，而不是僅以顯示文字儲存。

對於典型的類別圖表，預設工作簿會使用第 0 列儲存系列名稱，第 0 行儲存類別名稱，剩餘的儲存格則存放系列數值。傳遞給 [IChartDataWorkbook.getCell](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ichartdataworkbook/#getCell-int-int-int-) 的工作表、列與欄索引為零基礎。此佈局在建立具有預設資料的圖表時很有用，但不要假設每個現有圖表都使用此佈局。對於已載入的簡報，請在變更工作簿值之前檢查系列、類別與資料點所參考的儲存格。

圖表設定有三種不同的範圍：

- 系列層級設定，如 [IChartSeries.getFormat](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ichartseries/#getFormat--)，提供單一系列中所有資料點的預設外觀。
- 資料點層級設定，如 [IChartDataPoint.getFormat](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ichartdatapoint/#getFormat--)，會覆寫該點的系列外觀。
- 群組設定套用於屬於相同 [IChartSeriesGroup](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ichartseriesgroup/)，的相容系列。當需要設定重疊或間隙寬度等選項時，請透過 [IChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ichartseries/#getParentSeriesGroup--) 取得該群組。

當未設定明確的資料點或系列填色時，圖表樣式與主題會決定自動外觀。若同時存在系列與資料點格式，則以資料點的格式為優先。

![圖表系列-PowerPoint](chart-series-powerpoint.png)

## **設定圖表系列重疊**

[IChartSeries.getOverlap](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ichartseries/#getOverlap--) 報告 2D 圖表中條形或柱形的重疊程度，範圍從 -100% 到 100%。它是父系列群組設定的唯讀投影。使用 [IChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ichartseriesgroup/#setOverlap-byte-) 可更新該群組中所有相容系列。此選項適用於顯示分組條形或柱形的圖表類型；對於組合圖中不相關的系列群組則不會產生影響。

以下範例為包含第一個系列的群組設定重疊：

```java
import com.aspose.slides.*;

final int firstSlideIndex = 0;
final int firstSeriesIndex = 0;
final byte overlapPercent = 30;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    // 新圖表包含範例系列、類別和數值。
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

使用 [IChartSeries.getFormat](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ichartseries/#getFormat--) 設定整個系列的預設填色。如果資料點已設定明確的填色，則其 [IChartDataPoint.getFormat](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ichartdatapoint/#getFormat--) 設定會覆寫該系列的填色。

以下範例將實心藍色填充套用到第一個系列：

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

![系列顏色](series_color.png)

## **變更系列名稱**

系列名稱儲存在圖表資料工作簿中，通常顯示於圖例中。在為叢集柱形圖所建立的預設工作簿中，儲存格 B1 位於第 0 列第 1 欄，內含第一個系列的名稱。以下範例中的具名常數明確說明了此結構：

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

您也可以更新已由 [IChartSeries.getName](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ichartseries/#getName--) 參考的儲存格。此做法避免假設現有圖表中的特定列與欄：

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

## **取得自動系列填色**

[IChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ichartseries/#getAutomaticSeriesColor--) 會傳回依系列索引與圖表樣式計算出的 Android ARGB 整數顏色。這是系列填色未被明確定義時使用的顏色。呼叫此方法會讀取計算出的顏色；不會指定新的填色。

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

實際的整數值取決於圖表樣式與主題。

## **設定系列反轉填色**

對於條形、柱形與泡泡系列， [IChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ichartseries/#setInvertIfNegative-boolean-) 可使用不同的填色顯示負值。將常規系列填色設定為實心，啟用反轉，並透過 [IChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ichartseries/#getInvertedSolidFillColor--) 指定負值顏色。工作簿中的負數值保持不變；僅顯示顏色會改變。

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

![反轉實心填色](inverted_solid_fill_color.png)

您可以透過 [IChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ichartdatapoint/#setInvertIfNegative-boolean-) 為單一資料點啟用反轉。以下範例將系列的反轉關閉，僅為選取的資料點啟用，且為該點指派負值以便顯示效果：

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

## **清除特定資料點值**

若要使單一資料點變為空白而不移除其他點，將其對應的工作簿儲存格設為 `null`。對於柱形圖，繪製的值可透過 [IChartDataPoint.getValue](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ichartdatapoint/#getValue--) 取得。資料點仍保留在相同的類別位置，但圖表會根據空白值設定將其視為空白。

以下範例僅清除第一系列的第二個點：

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

散佈圖使用分別的 X 與 Y 儲存格，泡泡圖亦使用大小儲存格。僅清除代表欲移除之數值的儲存格。若想保留其他點，請勿呼叫 [IChartDataPointCollection.clear](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ichartdatapointcollection/#clear--)，因為該方法會移除該系列的所有資料點。

## **控制空儲存格的顯示**

隱藏的、含有值的儲存格與空白儲存格是不同的情況。若要包含或排除來自隱藏工作表列與欄的資料，請參閱 [Include Data from Hidden Rows and Columns](/slides/zh-hant/androidjava/chart-workbook/#include-data-from-hidden-rows-and-columns)。

空的工作簿儲存格代表缺失資料；儲存格內的 `0` 代表已知的數值。呼叫 [IChartDataCell.setValue](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ichartdatacell/#setValue-java.lang.Object-) 並傳入 `null` 可使儲存格變為空白。數值零即使在空白儲存格設定下仍保持為零。

使用 [IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ichart/#setDisplayBlanksAs-int-) 可選擇圖表如何顯示空白儲存格。此設定套用於整個圖表，會改變空白的繪製方式，而不會將空儲存格填入零或插值。

以下獨立範例建立一個含單一系列的折線圖，清除第 3 天的值，並以每種模式分別儲存相同的圖表。無需輸入檔案。[IChartDataWorkbook](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ichartdataworkbook/) 使用工作表 0，欄 0 作為類別標籤，欄 1 為數值；第 0 列為系列名稱。最終資料為 `10, 20, empty, 30, 40`。

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

    // 保持第 3 天真正為空，同時保留其類別和資料點。
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

每個輸出檔案會在儲存前記錄所指派的模式：`empty_cells_Gap.pptx`、`empty_cells_Zero.pptx`、`empty_cells_Span.pptx`。若只需一個版本，可在儲存簡報前指定所需模式，而不必遍歷所有模式。

下方比較顯示三個檔案中相同的資料。第 3 天在工作簿中皆為空白：

![折線圖顯示相同資料：Gap 在第 3 天斷線，Zero 下降至零，Span 連接第 2 天至第 4 天。](display_blanks_as.png)

可見效果取決於圖表類型。折線圖能讓三種模式容易比較。條形與柱形圖沒有線條跨越缺失類別，故 `Span` 無法產生如上所示的連接段落；缺失的柱形與零高的柱形也可能看起來相似。同樣地，僅有標記的散佈圖沒有連接線。不要期望每種圖表類型皆產生三個明顯不同的結果；請檢查您使用類型的輸出。

## **設定系列間隙寬度**

間隙寬度是相鄰條形或柱形叢集之間的空間，以條形或柱形寬度的百分比表示。與重疊類似，它屬於父系列群組而非單一系列。對該群組呼叫 [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-) 一次即可。較大的值會在叢集之間創造更多空間，較小的值則使其更密集。

以下範例變更間隙寬度，並僅儲存最終的簡報：

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

**哪些圖表類型支援資料系列？**

所有由 [ChartType](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/charttype/) 列舉表示的圖表類型皆使用圖表資料，但其系列的數值結構或設定並不完全相同。例如，類別圖使用類別與值，散佈圖使用 X 與 Y 值，泡泡圖則額外使用泡泡大小。請使用與系列類型相符的資料點建立方法。重疊與間隙寬度等選項僅適用於相容的條形或柱形群組。

**什麼是圖表系列群組？**

[IChartSeriesGroup](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ichartseriesgroup/) 包含相容的系列，共用群組層級的繪圖設定。組合圖可包含多個群組，因此透過某一系列取得的群組設定不一定會影響圖表中的每個系列。

**新建立的圖表是否包含預設資料？**

是。預設情況下， [IShapeCollection.addChart](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ishapecollection/#addChart-int-float-float-float-float-) 會建立示範系列、類別與值。您可以編輯這些儲存格，或在加入完全自訂的資料集之前先清除系列與類別集合。亦可使用其他重載，建立不含預設資料的圖表。

**圖表物件如何連結到工作簿儲存格？**

系列名稱、類別標籤與資料點值皆參考 [IChartDataWorkbook](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ichartdataworkbook/) 中的儲存格。變更被參考的儲存格會更新相對應的圖表元素。建立自訂資料時，請保持類別列與系列值列對齊，以確保每個點都繪製在正確的類別下。

**如何僅清除單一資料點而非整個系列？**

將相關的值儲存格設為 `null`，即可保留資料點的類別位置並使其為空白。僅在確實想移除該系列所有點時才使用 [IChartDataPointCollection.clear](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ichartdatapointcollection/#clear--)。若同時移除類別，請更新每個系列，使其值仍與類別集合對齊。

**空白資料點如何顯示？**

結果取決於圖表類型以及透過 [IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ichart/#setDisplayBlanksAs-int-) 設定的值。支援的圖表可以將空白顯示為間隙、零值，或透過連接相鄰點來顯示。請選擇符合您簡報中缺失資料意義的設定。完整範例與視覺比較請參閱 [控制空儲存格的顯示](#control-the-display-of-empty-cells)。

**負值如何格式化？**

對於支援的條形、柱形與泡泡系列，呼叫 [IChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ichartseries/#setInvertIfNegative-boolean-) 並設定由 [IChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ichartseries/#getInvertedSolidFillColor--) 回傳的顏色。您也可以使用 [IChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ichartdatapoint/#setInvertIfNegative-boolean-) 為個別資料點覆寫此行為。這些方法僅影響格式，並不改變儲存的數值。

**當系列與資料點同時設定格式時，哪個會生效？**

明確的資料點格式會覆寫該點的系列格式。其他資料點仍使用明確的系列格式，或在未定義系列格式時使用自動圖表樣式與主題。群組設定如重疊與間隙寬度屬於版面配置，並非資料點層級的格式覆寫。

**圖表能包含的系列數量是否有限制？**

Aspose.Slides 不對系列數量設置單獨的固定上限。實際上，簡報檔案的限制、可用記憶體、渲染時間與圖表可讀性會決定實用的上限。

**當柱形過於靠近或過於分散時，我該如何調整？**

對適當的父系列群組呼叫 [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-)。提高數值可擴大叢集之間的空間，降低數值則可使叢集更靠近。