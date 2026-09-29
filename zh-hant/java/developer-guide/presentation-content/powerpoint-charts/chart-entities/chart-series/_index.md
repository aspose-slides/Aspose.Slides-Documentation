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
- 工作簿儲存格
- 系列間隙
- 負值
- PowerPoint
- 簡報
- Java
- Aspose.Slides
description: "了解如何在 Java 簡報中管理圖表系列、資料點、工作簿儲存格、格式設定、重疊、間隙寬度以及負值。"
---
## **概述**

圖表將繪製的資料儲存在圖表資料工作簿中。 [IChartSeries](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ichartseries/) 代表一組相關值，而系列中的每個 [IChartDataPoint](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ichartdatapoint/) 皆參照一個或多個工作表儲存格。 [IChartCategory](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ichartcategory/) 物件提供系列共用的標籤或分組值。系列名稱、類別與點值因此連結到 [IChartDataCell](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ichartdatacell/) 物件，而不只是儲存為顯示文字。

對於一般的類別圖表，預設工作簿使用第 0 列放系列名稱，第 0 行放類別名稱，其餘儲存格放系列值。傳遞給 [IChartDataWorkbook.getCell](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ichartdataworkbook/#getCell-int-int-int-) 的工作表、列與欄索引均為零基礎。此佈局在建立預設資料圖表時很有用，但請勿假設每個現有圖表皆使用此方式。對於已載入的簡報，請在變更工作簿值之前檢查系列、類別與資料點所參照的儲存格。

圖表設定有三種不同的範圍：

- 系列層級設定，例如 [IChartSeries.getFormat](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ichartseries/#getFormat--)，提供單一系列中所有點的預設外觀。
- 資料點層級設定，例如 [IChartDataPoint.getFormat](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ichartdatapoint/#getFormat--)，會覆寫該點的系列外觀。
- 群組設定套用於屬於相同 [IChartSeriesGroup](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ichartseriesgroup/) 的相容系列。需要設定重疊或間隙寬度等選項時，請透過 [IChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ichartseries/#getParentSeriesGroup--) 取得群組。

當未明確設定點或系列填色時，圖表樣式與主題會決定自動外觀。當同時存在系列與點的格式設定時，點的格式設定會優先套用於該點。

![chart-series-powerpoint](chart-series-powerpoint.png)

## **設定圖表系列重疊**

[IChartSeries.getOverlap](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ichartseries/#getOverlap--) 會回報 2D 圖表中長條或柱狀的重疊程度，範圍為 -100 至 100%。它是父系列群組設定的唯讀投影。使用 [IChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ichartseriesgroup/#setOverlap-byte-) 可更新該群組中所有相容系列。此選項適用於顯示分組長條或柱狀的圖表類型；對組合圖表中不相關的系列群組不產生影響。

以下範例為包含第一個系列的群組設定重疊：

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

使用 [IChartSeries.getFormat](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ichartseries/#getFormat--) 來設定整個系列的預設填色。如果某個點已有明確的填色，其 [IChartDataPoint.getFormat](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ichartdatapoint/#getFormat--) 設定會覆寫該點的系列填色。

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

![The color of the series](series_color.png)

## **變更系列名稱**

系列名稱儲存在圖表資料工作簿中，通常顯示在圖例裡。對於預設建立的叢集柱狀圖，儲存格 B1 位於第 0 列、第 1 欄，包含第一個系列的名稱。以下範例中的具名常數明確說明了此結構：

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

您也可以更新已由 [IChartSeries.getName](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ichartseries/#getName--) 參照的儲存格。此做法避免假設現有圖表的特定列與欄：

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

## **取得自動系列填色**

[IChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ichartseries/#getAutomaticSeriesColor--) 會回傳根據系列索引與圖表樣式計算出的顏色。這是在系列填色未被明確定義時所使用的顏色。呼叫此方法只會讀取計算出的顏色，不會指派新的填色。

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

## **為圖表系列設定反轉填色**

對於長條、柱狀與氣泡系列， [IChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ichartseries/#setInvertIfNegative-boolean-) 可在負值時顯示不同的填色。將常規系列填色設為實心、啟用反轉，並透過 [IChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ichartseries/#getInvertedSolidFillColor--) 指定負值顏色。負數在工作簿中保持不變，僅改變其顯示顏色。

以下範例以單一系列替換預設圖表資料。工作表第 0 列包含系列名稱，第 0 欄包含類別名稱，第 1 欄包含數值：

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

![The inverted solid fill color](inverted_solid_fill_color.png)

您也可以透過 [IChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ichartdatapoint/#setInvertIfNegative-boolean-) 為單一點啟用反轉。以下範例在系列上停用反轉，僅為選取的點啟用，且為該點指定負值以便觀察效果：

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

若要使某個點變為空白而不移除其他點，將其對應的工作簿儲存格設為 `null`。對於柱狀圖，繪製的值可透過 [IChartDataPoint.getValue](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ichartdatapoint/#getValue--) 取得。資料點仍保留在相同的類別位置，但圖表會依照空白值設定將其視為空白。

以下範例只清除第一個系列的第二個點：

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

散佈圖使用分別的 X 與 Y 儲存格，氣泡圖亦使用大小儲存格。僅清除您想移除之值所對應的儲存格。若只想保留其他點，請勿呼叫 [IChartDataPointCollection.clear](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ichartdatapointcollection/#clear--)；該方法會移除系列中所有資料點。

## **控制空儲存格的顯示方式**

隱藏且包含值的儲存格屬於另一種情況，與空白儲存格不同。若要包含或排除來自隱藏工作表列與欄的資料，請參閱 [Include Data from Hidden Rows and Columns](/slides/zh-hant/java/chart-workbook/#include-data-from-hidden-rows-and-columns)。

空的工作簿儲存格代表缺失資料；包含 `0` 的儲存格則代表已知的數值。呼叫 [IChartDataCell.setValue](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ichartdatacell/#setValue-java.lang.Object-) 並傳入 `null` 即可將儲存格設為空白。數值零即使在空白儲存格設定下仍保持為零。

使用 [IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ichart/#setDisplayBlanksAs-int-) 來選擇圖表如何顯示空儲存格。此設定套用於整個圖表，會改變空白的繪製方式，而不會將空儲存格填入零或插值。

以下自包含範例建立一個單系列折線圖，清除第 3 天的值，並以每種模式另存同一圖表。此範例不需要輸入檔案。[IChartDataWorkbook](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ichartdataworkbook/) 使用工作表 0，欄 0 作為類別標籤，欄 1 作為值；第 0 列保存系列名稱。最終資料為 `10, 20, empty, 30, 40`。

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

    // 將第 3 天真正留空，同時保留其類別和資料點。
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

每個輸出檔案會在儲存前設定對應的模式：`empty_cells_Gap.pptx`、`empty_cells_Zero.pptx` 與 `empty_cells_Span.pptx`。若只想保留單一版本，請先設定所需模式，然後只儲存一次簡報，而非遍歷所有模式。

以下比較顯示三個檔案中相同的資料。第 3 天在工作簿中皆為空白：

![Line charts with identical data: Gap breaks the line at Day 3, Zero drops the line to zero, and Span connects Day 2 to Day 4.](display_blanks_as.png)

可見效果取決於圖表類型。折線圖最能比較全部三種模式。長條與柱狀圖因缺少連接線，`Span` 無法產生上述的連接段落；缺少的柱狀與零高度柱狀也可能看起來相似。散佈圖若僅有標記亦無連接線。不要期望每種圖表類型都有三種明顯不同的結果；請檢查您使用的圖表類型的輸出。

## **設定系列間隙寬度**

間隙寬度是相鄰長條或柱狀叢集之間的空間，表示為長條或柱狀寬度的百分比。與重疊相同，它屬於父系列群組而非單一系列。對群組呼叫一次 [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-) 即可。較大的值會在叢集之間產生更多空間，較小的值則使叢集更緊密。

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

## **常見問題集**

**哪種圖表類型支援資料系列？**

所有由 [ChartType](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/charttype/) 列舉表示的圖表類型皆使用圖表資料，但其系列不一定具有相同的值結構或設定。例如，類別圖使用類別與值，散佈圖使用 X 與 Y 值，氣泡圖則再加入氣泡大小。請使用與系列類型相符的資料點建立方法。重疊與間隙寬度等選項僅適用於相容的長條或柱狀群組。

**什麼是圖表系列群組？**

[IChartSeriesGroup](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ichartseriesgroup/) 包含共享群組層級繪圖設定的相容系列。組合圖表可以包含多個群組，因此透過單一系列取得的群組設定不一定會影響圖表中的所有系列。

**新建的圖表是否包含預設資料？**

是的。預設情況下， [IShapeCollection.addChart](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ishapecollection/#addChart-int-float-float-float-float-) 會建立範例系列、類別與值。您可以編輯這些儲存格或在加入完全自訂的資料集之前先清除系列與類別集合。亦可使用其他重載建立不含預設資料的圖表。

**圖表物件如何連結到工作簿儲存格？**

系列名稱、類別標籤與資料點值皆參照 [IChartDataWorkbook](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ichartdataworkbook/) 中的儲存格。變更參照的儲存格會更新對應的圖表元素。自行建立資料時，請保持類別列與系列值列對齊，以確保每個點繪製於正確的類別下。

**如何只清除單一點而不是整個系列？**

將相關的值儲存格設為 `null`，即可保留該點的類別位置作為空點。僅在您想移除該系列所有點時才使用 [IChartDataPointCollection.clear](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ichartdatapointcollection/#clear--)。若同時移除類別，請更新所有系列，使其值仍與類別集合保持對齊。

**空點如何顯示？**

結果取決於圖表類型以及透過 [IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ichart/#setDisplayBlanksAs-int-) 設定的顯示方式。支援的圖表可將空白顯示為間隙、零值或連接相鄰點。選擇與簡報中缺失資料意義相符的設定。完整範例與視覺比較請參閱 [Control the Display of Empty Cells](#control-the-display-of-empty-cells)。

**負值如何格式化？**

對於支援的長條、柱狀與氣泡系列，呼叫 [IChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ichartseries/#setInvertIfNegative-boolean-) 並設定由 [IChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ichartseries/#getInvertedSolidFillColor--) 取得的顏色。您也可以使用 [IChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ichartdatapoint/#setInvertIfNegative-boolean-) 為單一點覆寫此行為。這些方法僅影響格式，並不改變儲存的數值。

**當系列與點同時設定格式時，哪個會生效？**

明確的資料點格式會優先套用於該點。其他點仍使用明確的系列格式，或在未定義系列格式時使用自動圖表樣式與主題。群組設定如重疊與間隙寬度屬於版面配置，不屬於點層級的格式覆寫。

**圖表可以包含多少系列？有沒有上限？**

Aspose.Slides 並未設定固定的系列數上限。實務上，簡報檔案的限制、可用記憶體、渲染時間以及圖表的可讀性會決定實用的上限。

**當柱狀過於接近或過於分散時該怎麼調整？**

對適當的父系列群組呼叫 [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-)。增大數值可擴寬叢集間的空間，減少數值則使叢集更靠近。