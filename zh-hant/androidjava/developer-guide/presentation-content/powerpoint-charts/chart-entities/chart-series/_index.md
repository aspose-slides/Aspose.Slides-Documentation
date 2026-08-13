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
- 系列間距
- 負值
- PowerPoint
- 簡報
- Android
- Java
- Aspose.Slides
description: "了解如何在 Android 上的簡報中管理圖表系列、資料點、工作簿儲存格、格式設定、重疊、間距寬度以及負值。"
---
## **概覽**

圖表將其繪製的資料儲存在圖表資料工作簿中。[IChartSeries](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ichartseries/) 代表一組相關值，系列中的每個 [IChartDataPoint](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ichartdatapoint/) 指向一個或多個工作表儲存格。[IChartCategory](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ichartcategory/) 物件提供系列共用的標籤或分組值。因此，系列名稱、類別和點值會連結至 [IChartDataCell](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ichartdatacell/) 物件，而不是僅以顯示文字儲存。

對於一般的類別圖表，預設工作簿使用第 0 列作為系列名稱，第 0 欄作為類別名稱，其餘儲存格則存放系列值。傳遞給 [IChartDataWorkbook.getCell](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ichartdataworkbook/#getCell-int-int-int-) 的工作表、列與欄索引採用零基礎。此佈局在建立使用預設資料的圖表時很有用，但不要假設每個現有圖表皆使用此方式。對於已載入的簡報，請在變更工作簿值之前檢查系列、類別與資料點所參照的儲存格。

圖表設定具有三種不同的範圍：

- 系列層級設定，例如 [IChartSeries.getFormat](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ichartseries/#getFormat--)，為整個系列的所有點提供預設外觀。
- 資料點層級設定，例如 [IChartDataPoint.getFormat](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ichartdatapoint/#getFormat--)，會覆寫單一點的系列外觀。
- 群組設定套用至屬於相同 [IChartSeriesGroup](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ichartseriesgroup/) 的相容系列。當需要設定重疊或間距寬度等選項時，透過 [IChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ichartseries/#getParentSeriesGroup--) 取得群組。

如果未設定明確的點或系列填色，圖表樣式與主題會決定自動外觀。當同時存在系列與點的格式設定時，點的格式會優先套用於該點。

![chart-series-powerpoint](chart-series-powerpoint.png)

## **設定圖表系列重疊**

[IChartSeries.getOverlap](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ichartseries/#getOverlap--) 回報 2D 圖表中條形或柱形的重疊程度，範圍從 -100% 到 100%。它是父系列群組設定的唯讀投影。使用 [IChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ichartseriesgroup/#setOverlap-byte-) 以更新該群組中所有相容的系列。此選項適用於顯示分組條形或柱形的圖表類型；對組合圖中不相關的系列群組不會產生影響。

以下範例將包含第一個系列的群組的重疊設定為：

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

使用 [IChartSeries.getFormat](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ichartseries/#getFormat--) 可設定整個系列的預設填色。如果某個點已設定明確的填色，其 [IChartDataPoint.getFormat](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ichartdatapoint/#getFormat--) 設定會覆寫該點的系列填色。

以下範例將實心藍色填色套用於第一個系列：

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

系列名稱儲存在圖表資料工作簿中，通常顯示於圖例。對於預設為聚合柱狀圖所建立的工作簿，儲存格 B1 在第 0 列第 1 欄，包含第一個系列的名稱。以下範例中的具名常數明確說明了此結構：

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

也可以直接更新 [IChartSeries.getName](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ichartseries/#getName--) 已參照的儲存格。此方式避免在既有圖表中假設特定的列與欄：

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

[IChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ichartseries/#getAutomaticSeriesColor--) 會傳回根據系列索引與圖表樣式計算出的 Android ARGB 整數顏色。這是當系列填色未明確定義時所使用的顏色。呼叫此方法會讀取計算出的顏色；不會指派新的填色。

以下範例會列印每個預設系列的自動顏色整數：

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

確切的整數值取決於圖表樣式與主題。

## **設定系列的負值反轉填色**

對於條形、柱形與氣泡系列，[IChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ichartseries/#setInvertIfNegative-boolean-) 可在負值時使用不同的填色顯示。將系列的常規填色設定為實心，啟用反轉，並透過 [IChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ichartseries/#getInvertedSolidFillColor--) 指定負值的顏色。負數在工作簿中保持不變；僅其顯示顏色會改變。

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

也可以透過 [IChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ichartdatapoint/#setInvertIfNegative-boolean-) 為單一點啟用反轉。以下範例在系列中停用反轉，僅為選取的點啟用，並為該點指定負值以顯示效果：

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

若要使單一點為空白而不移除其他點，可將其對應的工作簿儲存格設為 `null`。對於柱形圖，繪製的值可透過 [IChartDataPoint.getValue](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ichartdatapoint/#getValue--) 取得。資料點仍保留於相同的類別位置，但圖表會根據空白值設定將其視為空白。

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

散佈圖使用分別的 X 與 Y 儲存格，氣泡圖亦使用尺寸儲存格。僅清除代表欲移除之值的儲存格。若想保留其他點，請勿呼叫 [IChartDataPointCollection.clear](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ichartdatapointcollection/#clear--)，因該方法會移除集合中的所有資料點。

## **設定系列間距寬度**

間距寬度是相鄰條形或柱形叢之間的空間，表達為條形或柱形寬度的百分比。與重疊相同，它屬於父系列群組而非單一系列。對群組呼叫一次 [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-)。較大的值會在叢之間產生更多空間；較小的值則使叢更為緊密。

以下範例變更間距寬度，並僅儲存最終的簡報：

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

**哪種類型的圖表支援資料系列？**

所有由 [ChartType](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/charttype/) 列舉所代表的圖表類型皆使用圖表資料，但它們的系列並非全部具有相同的值結構或設定。例如，類別圖表使用類別與數值，散佈圖使用 X 與 Y 值，氣泡圖則額外使用氣泡大小。請使用與系列類型相符的資料點建立方法。重疊與間距寬度等選項僅適用於相容的條形或柱形群組。

**什麼是圖表系列群組？**

[IChartSeriesGroup](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ichartseriesgroup/) 包含共享群組層級繪製設定的相容系列。組合圖可能包含多個群組，因而透過單一系列取得的群組變更不一定會影響圖表中的所有系列。

**新建立的圖表是否包含預設資料？**

是。預設情況下，[IShapeCollection.addChart](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ishapecollection/#addChart-int-float-float-float-float-) 會建立範例系列、類別與數值。您可以編輯這些儲存格，或在加入完全自訂的資料集之前清除系列與類別集合。亦可使用其他重載建立不含預設資料的圖表。

**圖表物件如何與工作簿儲存格相連？**

系列名稱、類別標籤與資料點值皆參照 [IChartDataWorkbook](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ichartdataworkbook/) 中的儲存格。變更參照的儲存格即會更新相對應的圖表元素。自訂資料時，請確保類別列與系列值列保持對齊，使每個點皆在預期的類別下繪製。

**如何只清除單一資料點而非整個系列？**

將相關的值儲存格設為 `null`，即可保留該點的類別位置作為空白點。僅在想要移除該系列所有點時才使用 [IChartDataPointCollection.clear](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ichartdatapointcollection/#clear--)，因為該方法會移除整個集合。

**空白資料點如何顯示？**

顯示結果取決於圖表類型以及透過 [IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ichart/#setDisplayBlanksAs-int-) 設定的值。支援的圖表可以將空白顯示為間隙、零值，或以連接相鄰點的方式呈現。請選擇與簡報中遺失資料意涵相符的設定。

**負值如何格式化？**

對於支援的條形、柱形與氣泡系列，呼叫 [IChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ichartseries/#setInvertIfNegative-boolean-) 並設定由 [IChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ichartseries/#getInvertedSolidFillColor--) 取得的顏色。您也可以透過 [IChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ichartdatapoint/#setInvertIfNegative-boolean-) 為單一點覆寫此行為。這些方法僅影響格式，而不會改變儲存的數值。

**當系列與資料點同時設定格式時，哪一個格式優先？**

明確的資料點格式會優先套用於該點。其他點則繼續使用明確的系列格式，若系列格式未定義，則使用自動的圖表樣式與主題。群組設定（如重疊與間距寬度）僅控制版面配置，並不屬於點層級的格式覆寫。

**圖表可以包含的系列數量是否有限制？**

Aspose.Slides 本身沒有單獨設定的系列數量上限。實務上，簡報檔案的限制、可用記憶體、渲染時間以及圖表的可讀性會共同決定實際可接受的上限。

**當柱形過於接近或過於分離時應調整什麼？**

對適當的父系列群組呼叫 [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-)。將值調高可擴大叢間的間距，調低則使叢更貼近。