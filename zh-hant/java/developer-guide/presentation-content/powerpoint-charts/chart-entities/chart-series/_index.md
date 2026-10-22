---
title: 在 Java 簡報中管理圖表資料系列
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
description: "了解如何使用 Java 在簡報中管理圖表系列、資料點、工作簿儲存格、格式設定、重疊、間隙寬度及負值。"
---
## **概覽**

圖表可以將其繪製的值儲存在工作簿儲存格中，或直接作為數值文字。[IChartSeries](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/) 代表相關值的一組，而每個[IChartDataPoint](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapoint/) 代表該系列中的一個點。[IChartCategory](https://reference.aspose.com/slides/java/com.aspose.slides/ichartcategory/) 物件提供系列共用的標籤或分組值。在使用預設資料建立的圖表中，系列名稱、類別和點值會使用來自圖表工作簿的[IChartDataCell](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatacell/) 物件。

對於一般的類別圖表，預設工作簿使用第 0 列儲存系列名稱，第 0 行儲存類別名稱，其餘儲存格用於系列值。傳遞給[IChartDataWorkbook.getCell](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdataworkbook/#getCell-int-int-int-) 的工作表、列與欄索引皆為零基礎。此配置在建立使用預設資料的圖表時很有用，但不要假設每個現有圖表都遵循此規則。對於已載入的簡報，請在變更工作簿值之前檢查系列、類別和資料點所參照的儲存格。

圖表設定有三種不同的範圍：

- 系列層級設定，例如[IChartSeries.getFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getFormat--)，提供單一系列中所有點的預設外觀。
- 資料點層級設定，例如[IChartDataPoint.getFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapoint/#getFormat--)，會覆寫該點的系列外觀。
- 群組設定套用於屬於同一[IChartSeriesGroup](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/) 的相容系列。當需要設定重疊或間隙寬度等選項時，請透過[IChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getParentSeriesGroup--) 取得群組。

當未設定明確的點或系列填色時，圖表樣式與佈景主題會決定自動外觀。當同時存在系列與點的格式設定時，點的格式會優先套用於該點。

![chart-series-powerpoint](chart-series-powerpoint.png)

## **使用數值文字設定系列值**

當系列值來自應用程式資料或計算且不需要工作表儲存格參照時，請使用數值文字。先以[DataSourceType.DoubleLiterals](https://reference.aspose.com/slides/java/com.aspose.slides/datasourcetype/#DoubleLiterals) 呼叫[setDataSourceTypeForValues](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapointcollection/#setDataSourceTypeForValues-int-)，再透過[setAsLiteralDouble](https://reference.aspose.com/slides/java/com.aspose.slides/idoublechartvalue/#setAsLiteralDouble-double-) 為每個點的[getValue](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapoint/#getValue--) 結果指定數值。

集合設定會控制該系列中所有點值的來源類型。每個點值的[getDataSourceType](https://reference.aspose.com/slides/java/com.aspose.slides/ibasechartvalue/#getDataSourceType--) 方法會回報所選類型；可透過集合設定變更。若使用 `Worksheet`，請以[getAsCell](https://reference.aspose.com/slides/java/com.aspose.slides/isinglecellchartvalue/#getAsCell--) 取得參照的儲存格。若使用 `DoubleLiterals`，則以[getAsLiteralDouble](https://reference.aspose.com/slides/java/com.aspose.slides/idoublechartvalue/#getAsLiteralDouble--) 或 `setAsLiteralDouble` 直接讀寫數字。

以下範例建立一個具有預設系列與類別的柱狀圖，然後為第一系列的現有點指派計算後的 10、20 等值，接著儲存簡報、重新開啟並輸出儲存的值。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 300);
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);

    series.getDataPoints().setDataSourceTypeForValues(DataSourceType.DoubleLiterals);
    for (int i = 0; i < series.getDataPoints().size(); i++) {
        series.getDataPoints().get_Item(i).getValue().setAsLiteralDouble((i + 1) * 10);
    }

    presentation.save("numeric_literals.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

Presentation reopenedPresentation = new Presentation("numeric_literals.pptx");
try {
    ISlide reopenedSlide = reopenedPresentation.getSlides().get_Item(0);
    IChart reopenedChart = (IChart) reopenedSlide.getShapes().get_Item(0);
    IChartSeries reopenedSeries = reopenedChart.getChartData().getSeries().get_Item(0);
    for (IChartDataPoint point : reopenedSeries.getDataPoints()) {
        System.out.println(point.getValue().getAsLiteralDouble());
    }
} finally {
    reopenedPresentation.dispose();
}
```

點值的來源類型與[IChartData.getDataSourceType](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#getDataSourceType--) 分開，後者指出圖表的內部或外部工作簿設定。使用數值文字本身不會移除內嵌工作簿。在此範例中，工作簿仍保留供類別標籤、系列名稱及其他系列使用。請參閱[Chart Workbook](/slides/zh-hant/java/chart-workbook/) 了解工作簿管理。

對於散點圖與氣泡圖，請使用[setDataSourceTypeForXValues](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapointcollection/#setDataSourceTypeForXValues-int-) 與[setDataSourceTypeForYValues](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapointcollection/#setDataSourceTypeForYValues-int-) 針對[getXValue](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapoint/#getXValue--) 與[getYValue](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapoint/#getYValue--) 選擇來源。氣泡圖亦使用[setDataSourceTypeForBubbleSizes](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapointcollection/#setDataSourceTypeForBubbleSizes-int-) 為[getBubbleSize](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapoint/#getBubbleSize--) 設定來源。於指派數字前，先將每個適用的來源設為 `DoubleLiterals`，然後透過該值的 `setAsLiteralDouble` 方法寫入。

## **設定圖表系列重疊**

[IChartSeries.getOverlap](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getOverlap--) 會回報 2D 圖表中條形或柱形的重疊程度，範圍從 -100% 到 100%。此值為父系列群組設定的唯讀投影。使用[IChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/#setOverlap-byte-) 可更新同一群組中所有相容系列。此選項僅適用於顯示分組條形或柱形的圖表類型；不會影響組合圖中不相關的系列群組。

以下範例為包含第一系列的群組設定重疊：

```java
import com.aspose.slides.*;

final int firstSlideIndex = 0;
final int firstSeriesIndex = 0;
final byte overlapPercent = 30;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    // 新圖表包含示範系列、類別和數值。
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

使用[IChartSeries.getFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getFormat--) 可為整個系列設定預設填色。如果某個點已設定明確的填色，其[IChartDataPoint.getFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapoint/#getFormat--) 會覆寫該系列的填色。

以下範例為第一系列套用實心藍色填色：

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

系列名稱儲存於圖表資料工作簿中，通常會顯示於圖例。於預設為叢集柱狀圖建立的工作簿中，儲存格 B1（第 0 列第 1 欄）即為第一系列的名稱。下列範例以具名常數明確說明此結構：

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

您也可以直接更新[IChartSeries.getName](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getName--) 已參照的儲存格。此做法可避免假設現有圖表的特定列與欄：

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

### **從多個儲存格建立具有名稱的系列**

當產品名稱與報告期間分別儲存在不同工作簿儲存格時，合成系列名稱相當有用。例如，您可以將 B1 中的 `Product A` 與 C1 中的 `2026` 結合為單一系列名稱，同時保持兩個部分皆連結至來源儲存格。

使用[IChartDataWorkbook.getCellCollection](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdataworkbook/#getCellCollection-java.lang.String-boolean-) 取得名稱範圍，然後將該集合傳遞給[IChartSeriesCollection.add](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriescollection/#add-com.aspose.slides.IChartCellCollection-int-)。`skipHiddenCells` 參數決定是否排除隱藏儲存格：`true` 表示排除，`false` 表示包含。本範例使用 `false` 以包含名稱範圍內的每個儲存格。

以下範例建立一個只有一個系列與兩個資料點的簡報。儲存格 B1:C1 只提供系列名稱；A2:A3 提供類別標籤；B2:B3 提供數值。

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

    // 獨立的儲存格提供類別和數值資料點。
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

得到的系列名稱為 `Product A 2026`，兩個儲存格值之間有空格。圖例會將此顯示為兩欄皆屬於同一條目。下圖示意結果：

![Column chart with North and South values and the composite series name Product A 2026 in the legend](composite_series_name.png)

## **取得自動系列填色**

[IChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getAutomaticSeriesColor--) 會回傳依系列索引與圖表樣式計算出的顏色。這是未明確定義系列填色時所使用的顏色。呼叫此方法僅讀取計算出的顏色，並不會設定新的填色。

以下範例印出每個預設系列的自動顏色：

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

實際顏色取決於圖表樣式與佈景主題。

## **設定圖表系列的反轉填色**

對於條形、柱形與氣泡系列，可使用[IChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#setInvertIfNegative-boolean-) 在負值時顯示不同的填色。先將系列的常規填色設定為實心，啟用反轉，並透過[IChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getInvertedSolidFillColor--) 指定負值的顏色。負數在工作簿中仍保持不變，僅變更顯示顏色。

以下範例以單一系列取代預設圖表資料。工作表第 0 列為系列名稱，第 0 欄為類別名稱，第 1 欄為值：

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

您也可以透過[IChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapoint/#setInvertIfNegative-boolean-) 為單一點啟用反轉。下例中，系列的反轉功能被停用，僅對選取的點啟用，且該點亦被指派負值以呈現效果：

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

若要讓某個點變為空白而不移除其他點，請將其對應的工作簿儲存格設為 `null`。對於柱狀圖，可透過[IChartDataPoint.getValue](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapoint/#getValue--) 取得繪製值。資料點仍保留在相同的類別位置，但圖表會依照空白值設定將其視為空白。

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

散點圖使用分別的 X 與 Y 儲存格，氣泡圖亦使用尺寸儲存格。僅清除您想移除之值所對應的儲存格。若只想保留其他點，請勿呼叫[IChartDataPointCollection.clear](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapointcollection/#clear--)，因為該方法會移除整個集合的所有資料點。

## **控制空白儲存格的顯示方式**

隱藏且含有值的儲存格與空白儲存格屬於不同情況。若要包含或排除來自隱藏工作表列與欄的資料，請參閱[Include Data from Hidden Rows and Columns](/slides/zh-hant/java/chart-workbook/#include-data-from-hidden-rows-and-columns)。

空白工作簿儲存格代表缺失資料；儲存格內含 `0` 則代表已知的數值。使用[IChartDataCell.setValue](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatacell/#setValue-java.lang.Object-) 並傳入 `null` 即可將儲存格設為空白。數值零即使在空白儲存格設定下仍保持為零。

使用[IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#setDisplayBlanksAs-int-) 可選擇圖表如何顯示空白儲存格。此設定套用於整個圖表，會改變空白點的繪製方式，且不會將空白工作簿儲存格填入零或插值。

以下獨立範例建立一個具有單一系列的折線圖，清除第 3 天的值，並以三種模式分別儲存同一圖表。此範例不需要輸入檔案。[IChartDataWorkbook](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdataworkbook/) 使用第 0 工作表，第 0 欄作為類別標籤，第 1 欄作為值；第 0 列為系列名稱。最終資料為 `10, 20, empty, 30, 40`。

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

每個輸出檔案會在儲存前套用相應模式：`empty_cells_Gap.pptx`、`empty_cells_Zero.pptx` 與 `empty_cells_Span.pptx`。若只想產生單一版本，請設定所需模式後僅儲存一次簡報，而非遍歷所有模式。

下圖比較三個檔案的相同資料。第 3 天在工作簿中皆為空白：

![Line charts with identical data: Gap breaks the line at Day 3, Zero drops the line to zero, and Span connects Day 2 to Day 4.](display_blanks_as.png)

可見效果依圖表類型而異。折線圖最能說明三種模式的差異；條形與柱形圖沒有連線可跨過缺失的類別，因此 `Span` 無法產生如上所示的連接段；缺失的柱形與零高柱形在外觀上也可能相似。散點圖若僅使用標記也不會有連線。請勿期望每種圖表類型皆產生三種截然不同的結果，需自行檢查目標圖表的輸出。

## **設定系列間隙寬度**

間隙寬度是相鄰條形或柱形叢集之間的空間，以條形或柱形寬度的百分比表示。與重疊類似，它屬於父系列群組而非單一系列。請對群組呼叫[IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-)，一次即可。較大的數值會在叢集之間產生更多空間，較小的數值則使叢集更為緊密。

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

![The gap width](gap_width.png)

## **常見問題集**

**哪些圖表類型支援資料系列？**

所有由[ChartType](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/) 列舉的圖表類型皆使用圖表資料，但其系列的值結構或設定並不完全相同。例如，類別圖使用類別與值，散點圖使用 X 與 Y 值，氣泡圖則額外使用氣泡大小。請使用與系列類型相符的資料點建立方法。重疊與間隙寬度等選項僅適用於相容的條形或柱形群組。

**什麼是圖表系列群組？**

[IChartSeriesGroup](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/) 包含共享群組層級繪製設定的相容系列。組合圖可能包含多個群組，因此透過單一系列取得的群組設定不一定會影響圖表中的所有系列。

**新建立的圖表是否包含預設資料？**

是。預設情況下，[IShapeCollection.addChart](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addChart-int-float-float-float-float-) 會建立範例系列、類別與值。您可以編輯這些儲存格，或在加入完全自訂的資料集之前先清除系列與類別集合。亦可使用其他覆載方法建立不含預設資料的圖表。

**圖表物件如何與工作簿儲存格連結？**

系列名稱、類別標籤與資料點值會參照[IChartDataWorkbook](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdataworkbook/) 中的儲存格。變更已參照的儲存格會即時更新對應的圖表元素。建立自訂資料時，請確保類別列與系列值列保持對齊，使每個點皆繪製在正確的類別下。

**如何只清除單一點而不是整個系列？**

將相關的值儲存格設為 `null`，即可保留該點的類別位置作為空白點。僅在想要移除整個系列時，才使用[IChartDataPointCollection.clear](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapointcollection/#clear--)，因為它會刪除該系列的所有資料點。若同時移除類別，請同步更新所有系列，使其值仍與類別集合保持對齊。

**空白點如何顯示？**

顯示結果取決於圖表類型以及透過[IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#setDisplayBlanksAs-int-) 設定的方式。支援的圖表可將空白顯示為間隙、零值或連接相鄰點。選擇與簡報中缺失資料意義相符的設定。參閱[Control the Display of Empty Cells](#control-the-display-of-empty-cells) 取得完整範例與視覺比較。

**負值的格式如何設定？**

對於支援的條形、柱形與氣泡系列，呼叫[IChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#setInvertIfNegative-boolean-) 並設定[IChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getInvertedSolidFillColor--) 回傳的顏色。您也可透過[IChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapoint/#setInvertIfNegative-boolean-) 為單一點覆寫此行為。這些方法僅影響格式，並不改變儲存的數值。

**當系列與點同時設定格式時，哪個會生效？**

明確的資料點格式會覆寫該點的系列格式。其他點仍會使用明確的系列格式，或在系列格式未定義時使用自動的圖表樣式與佈景主題。群組設定（如重疊與間隙寬度）屬於版面配置，並非點層級的格式覆寫。

**圖表可容納的系列數量有限制嗎？**

Aspose.Slides 本身沒有單獨的系列數量上限。實務上，簡報檔案的限制、可用記憶體、渲染時間以及圖表可讀性會決定實際可使用的上限。

**當柱形或條形過於靠近或過於分離時，該怎麼調整？**

對相應的父系列群組呼叫[IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-)。增大數值會擴大叢集之間的間距，減小則會使叢集更為緊密。