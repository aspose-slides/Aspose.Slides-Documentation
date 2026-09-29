---
title: 使用 JavaScript 管理簡報中的圖表資料系列
linktitle: 資料系列
type: docs
url: /zh-hant/nodejs-java/chart-series/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "了解如何使用 JavaScript 在簡報中管理圖表系列、資料點、活頁簿儲存格、格式設定、重疊、間隙寬度以及負值。"
---
## **概觀**

圖表將其繪製的資料儲存在圖表資料活頁簿中。[ChartSeries](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/chartseries/) 代表一組相關的值，系列中的每個 [ChartDataPoint](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/chartdatapoint/) 參照一個或多個活頁簿儲存格。[ChartCategory](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/chartcategory/) 物件提供系列共用的標籤或分組值。因此，系列名稱、類別與資料點值是透過 [ChartDataCell](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/chartdatacell/) 物件連結，而不是僅以顯示文字儲存。

對於一般的類別圖表，預設活頁簿使用第 0 列儲存系列名稱，第 0 欄儲存類別名稱，其餘儲存格用於系列值。傳遞給 [ChartDataWorkbook.getCell](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/chartdataworkbook/#getCell) 的工作表、列與欄索引皆為零基礎。此布局在建立使用預設資料的圖表時很有用，但不要假設所有現有圖表都採用此布局。對於已載入的簡報，請先檢查系列、類別與資料點所參照的儲存格，再變更活頁簿的值。

圖表設定有三種不同的範圍：

- 系列層級設定，例如 [ChartSeries.getFormat](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/chartseries/#getFormat)，提供整個系列中所有資料點的預設外觀。
- 資料點層級設定，例如 [ChartDataPoint.getFormat](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/chartdatapoint/#getFormat)，會覆寫單一資料點的系列外觀。
- 群組設定套用於屬於同一個 [ChartSeriesGroup](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/chartseriesgroup/) 的相容系列。需要設定重疊或間隙寬度等選項時，請透過 [ChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/chartseries/#getParentSeriesGroup) 取得該群組。

當未明確設定資料點或系列的填充時，圖表樣式與佈景主題會決定自動外觀。當同時存在系列與資料點的格式設定時，以資料點的格式為優先。

![圖表系列 PowerPoint](chart-series-powerpoint.png)

## **設定圖表系列重疊度**

[ChartSeries.getOverlap](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/chartseries/#getOverlap) 會回報 2D 圖表中長條或柱狀的重疊程度，範圍為 -100% 到 100%。它是父系列群組設定的唯讀投影。使用 [ChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/chartseriesgroup/#setOverlap) 可更新該群組內所有相容系列。此選項僅適用於顯示分組長條或柱狀的圖表類型，不會影響組合圖表中無關的系列群組。

以下範例設定第一個系列所屬群組的重疊度：

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const firstSlideIndex = 0;
const firstSeriesIndex = 0;
const overlapPercent = java.newByte(30);

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(firstSlideIndex);

    // 新增的圖表包含示範系列、類別和數值。
    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 200);

    const series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    series.getParentSeriesGroup().setOverlap(overlapPercent);

    presentation.save("series_overlap.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果：

![系列重疊](series_overlap.png)

## **變更系列填充顏色**

使用 [ChartSeries.getFormat](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/chartseries/#getFormat) 可設定整個系列的預設填充。如果資料點已設定明確的填充，則其 [ChartDataPoint.getFormat](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/chartdatapoint/#getFormat) 會覆寫該資料點的系列填充。

以下範例將第一個系列套用實心藍色填充：

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const firstSlideIndex = 0;
const firstSeriesIndex = 0;
const solidFillType = java.newByte(aspose.slides.FillType.Solid);
const blueColor = java.getStaticFieldValue("java.awt.Color", "BLUE");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(firstSlideIndex);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 200);

    const series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    series.getFormat().getFill().setFillType(solidFillType);
    series.getFormat().getFill().getSolidFillColor().setColor(blueColor);

    presentation.save("series_color.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果：

![系列顏色](series_color.png)

## **變更系列名稱**

系列名稱儲存在圖表資料活頁簿中，通常會顯示於圖例。對於預設建立的叢集柱狀圖，儲存格 B1 位於第 0 列第 1 欄，包含第一個系列的名稱。以下範例中的具名常數明確指出了此結構：

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const firstSlideIndex = 0;
const worksheetIndex = 0;
const seriesNameRowIndex = 0;
const firstSeriesColumnIndex = 1;

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(firstSlideIndex);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 200);

    const workbook = chart.getChartData().getChartDataWorkbook();
    const seriesNameCell = workbook.getCell(worksheetIndex, seriesNameRowIndex, firstSeriesColumnIndex);
    seriesNameCell.setValue("Revenue");

    presentation.save("series_name.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

您也可以直接更新由 [ChartSeries.getName](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/chartseries/#getName) 參照的儲存格。此方法避免在既有圖表中假設特定的列與欄：

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const firstSlideIndex = 0;
const firstSeriesIndex = 0;
const firstNameCellIndex = 0;

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(firstSlideIndex);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 200);

    const series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    const seriesNameCell = series.getName().getAsCells().get_Item(firstNameCellIndex);
    seriesNameCell.setValue("Revenue");

    presentation.save("series_name.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果：

![系列名稱](series_name.png)

## **取得自動系列填充顏色**

[ChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/chartseries/#getAutomaticSeriesColor) 會回傳根據系列索引與圖表樣式計算出的顏色。這是當系列填充未明確定義時所使用的顏色。呼叫此方法只會讀取計算出的顏色，不會指派新的填充。

以下範例列印每個預設系列的自動顏色：

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const firstSlideIndex = 0;

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(firstSlideIndex);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 200);

    const seriesCount = chart.getChartData().getSeries().size();
    for (let seriesIndex = 0; seriesIndex < seriesCount; seriesIndex++) {
        const series = chart.getChartData().getSeries().get_Item(seriesIndex);
        const automaticColor = series.getAutomaticSeriesColor();
        const automaticColorText = automaticColor.toString();
        console.log("Series " + seriesIndex + ": " + automaticColorText);
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

確切的顏色取決於圖表樣式與佈景主題。

## **設定圖表系列的反轉填充顏色**

對於長條、柱狀與氣泡系列，[ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/chartseries/#setInvertIfNegative) 可在負值時顯示不同的填充。將系列的常規填充設定為實心，啟用反轉，並透過 [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/chartseries/#getInvertedSolidFillColor) 指定負值顏色。負數在活頁簿中保持不變，僅改變其顯示顏色。

以下範例使用單一系列取代預設圖表資料。工作表第 0 列為系列名稱，第 0 欄為類別名稱，第 1 欄為數值：

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const firstSlideIndex = 0;
const worksheetIndex = 0;
const headerRowIndex = 0;
const categoryColumnIndex = 0;
const firstSeriesColumnIndex = 1;
const firstDataRowIndex = 1;
const solidFillType = java.newByte(aspose.slides.FillType.Solid);
const redColor = java.getStaticFieldValue("java.awt.Color", "RED");

const categoryNames = ["Category 1", "Category 2", "Category 3"];
const seriesValues = [-20, 50, -30];

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(firstSlideIndex);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 200);
    const chartData = chart.getChartData();
    const workbook = chartData.getChartDataWorkbook();

    chartData.getSeries().clear();
    chartData.getCategories().clear();

    const seriesNameCell = workbook.getCell(worksheetIndex, headerRowIndex, firstSeriesColumnIndex, "Series 1");
    const chartType = chart.getType();
    const series = chartData.getSeries().add(seriesNameCell, chartType);

    for (let categoryIndex = 0; categoryIndex < categoryNames.length; categoryIndex++) {
        const dataRowIndex = firstDataRowIndex + categoryIndex;
        const categoryName = categoryNames[categoryIndex];
        const seriesValue = seriesValues[categoryIndex];

        const categoryCell = workbook.getCell(worksheetIndex, dataRowIndex, categoryColumnIndex, categoryName);
        chartData.getCategories().add(categoryCell);

        const valueCell = workbook.getCell(worksheetIndex, dataRowIndex, firstSeriesColumnIndex, seriesValue);
        series.getDataPoints().addDataPointForBarSeries(valueCell);
    }

    const automaticSeriesColor = series.getAutomaticSeriesColor();
    series.getFormat().getFill().setFillType(solidFillType);
    series.getFormat().getFill().getSolidFillColor().setColor(automaticSeriesColor);
    series.setInvertIfNegative(true);
    series.getInvertedSolidFillColor().setColor(redColor);

    presentation.save("inverted_solid_fill_color.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果：

![反轉實心填充顏色](inverted_solid_fill_color.png)

您也可以對單一資料點啟用反轉，方法是呼叫 [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/chartdatapoint/#setInvertIfNegative)。以下範例在系列層面停用反轉，僅對選取的資料點啟用，且為該點指定負值以顯示效果：

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const firstSlideIndex = 0;
const firstSeriesIndex = 0;
const targetDataPointIndex = 2;
const negativeValue = -30;
const solidFillType = java.newByte(aspose.slides.FillType.Solid);
const redColor = java.getStaticFieldValue("java.awt.Color", "RED");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(firstSlideIndex);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 200);

    const series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    const automaticSeriesColor = series.getAutomaticSeriesColor();
    series.getFormat().getFill().setFillType(solidFillType);
    series.getFormat().getFill().getSolidFillColor().setColor(automaticSeriesColor);
    series.getInvertedSolidFillColor().setColor(redColor);
    series.setInvertIfNegative(false);

    const dataPoint = series.getDataPoints().get_Item(targetDataPointIndex);
    dataPoint.getValue().getAsCell().setValue(negativeValue);
    dataPoint.setInvertIfNegative(true);

    presentation.save("data_point_invert_color_if_negative.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **清除特定資料點的值**

若要在不移除其他資料點的情況下讓某個點變為空白，可將其對應的活頁簿儲存格設為 `null`。對於柱狀圖，繪製的值可透過 [ChartDataPoint.getValue](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/chartdatapoint/#getValue) 取得。資料點仍保留在相同的類別位置，但圖表會依照空白值設定將其視為空白。

以下範例只清除第一個系列的第二個資料點：

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const firstSlideIndex = 0;
const firstSeriesIndex = 0;
const targetDataPointIndex = 1;

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(firstSlideIndex);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 200);

    const series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    const dataPoint = series.getDataPoints().get_Item(targetDataPointIndex);
    dataPoint.getValue().getAsCell().setValue(null);

    presentation.save("clear_data_point_value.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

散點圖使用分別的 X 與 Y 儲存格，氣泡圖亦使用大小儲存格。僅清除您欲移除的值所對應的儲存格。若只想保留其他資料點，請勿呼叫 [ChartDataPointCollection.clear](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/chartdatapointcollection/#clear)，因為該方法會移除系列中所有資料點。

## **控制空儲存格的顯示**

隱藏的儲存格即使包含值，也屬於與空儲存格不同的情況。若要包含或排除來自隱藏工作表列與欄的資料，請參閱 [包含隱藏列與欄的資料](/slides/zh-hant/nodejs-java/chart-workbook/#include-data-from-hidden-rows-and-columns)。

空的活頁簿儲存格代表遺失的資料；包含 `0` 的儲存格則代表已知的數值。呼叫 [ChartDataCell.setValue](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/chartdatacell/#setValue) 並傳入 `null` 即可將儲存格設為空白。數值 0 仍會保持為 0，且不受空儲存格設定影響。

使用 [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/chart/#setDisplayBlanksAs) 可選擇圖表如何顯示空儲存格。此設定套用於整個圖表，會改變空白的繪製方式，而不會將空儲存格填入 0 或插值。

以下自包含範例建立一個包含單一系列的折線圖，將第 3 天的值清除，並以每種模式分別儲存同一圖表。無需輸入檔案。[ChartDataWorkbook](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/chartdataworkbook/) 使用第 0 工作表，第 0 欄作為類別標籤，第 1 欄作為數值；第 0 列保存系列名稱。最終資料為 `10, 20, empty, 30, 40`。

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.LineWithMarkers, 40, 40, 640, 400);
    const chartData = chart.getChartData();
    const workbook = chartData.getChartDataWorkbook();

    chartData.getSeries().clear();
    chartData.getCategories().clear();

    const seriesNameCell = workbook.getCell(0, 0, 1, "Measurements");
    const series = chartData.getSeries().add(seriesNameCell, chart.getType());
    const values = [10, 20, 25, 30, 40];

    for (let i = 0; i < values.length; i++) {
        const categoryCell = workbook.getCell(0, i + 1, 0, "Day " + (i + 1));
        chartData.getCategories().add(categoryCell);
        const valueCell = workbook.getCell(0, i + 1, 1, values[i]);
        series.getDataPoints().addDataPointForLineSeries(valueCell);
    }

    // 將第 3 天真正留空，同時保留其類別與資料點。
    workbook.getCell(0, 3, 1).setValue(null);

    const modes = [aspose.slides.DisplayBlanksAsType.Gap, aspose.slides.DisplayBlanksAsType.Zero, aspose.slides.DisplayBlanksAsType.Span];
    const modeNames = ["Gap", "Zero", "Span"];
    for (let i = 0; i < modes.length; i++) {
        chart.setDisplayBlanksAs(modes[i]);
        presentation.save("empty_cells_" + modeNames[i] + ".pptx", aspose.slides.SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

每個輸出檔案在儲存前皆已指定模式：`empty_cells_Gap.pptx`、`empty_cells_Zero.pptx` 與 `empty_cells_Span.pptx`。若只需一個版本，請先指定所需模式，然後只儲存一次簡報，而非遍歷所有模式。

下圖比較了三個檔案的相同資料。第 3 天在活頁簿中皆為空白：

![折線圖的空儲存格顯示差異：Gap 在第 3 天斷線，Zero 使線條降至零，Span 則將第 2 天與第 4 天連接起來。](display_blanks_as.png)

可見效果取決於圖表類型。折線圖最能直觀比較三種模式；長條與柱狀圖因缺少連接線，`Span` 無法產生上圖的連接段落，且缺失的柱與零高的柱看起來也相似。散點圖僅有標記時亦無連線。請勿期望所有圖表類型皆產生三種不同結果，使用前請檢查實際輸出。

## **設定系列間隙寬度**

間隙寬度是相鄰長條或柱狀叢集之間的空間，表示為長條或柱狀寬度的百分比。與重疊度相同，它屬於父系列群組而非單一系列。對群組呼叫一次 [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/chartseriesgroup/#setGapWidth) 即可。較大的數值會在叢集之間留下更多空間，較小的數值則使叢集更緊密。

以下範例變更間隙寬度，並只儲存最終的簡報：

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const firstSlideIndex = 0;
const firstSeriesIndex = 0;
const gapWidthPercent = 30;

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(firstSlideIndex);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.StackedColumn, 20, 20, 500, 200);

    const series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    series.getParentSeriesGroup().setGapWidth(gapWidthPercent);

    presentation.save("gap_width_30.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果：

![間隙寬度](gap_width.png)

## **常見問題**

**哪些圖表類型支援資料系列？**

所有由 [ChartType](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/charttype/) 列舉的圖表類型皆使用圖表資料，但其系列的值結構與設定並不完全相同。例如，類別圖使用類別與數值，散點圖使用 X 與 Y 值，氣泡圖則額外加入氣泡大小。請使用與系列類型相符的資料點建立方法。重疊度與間隙寬度等選項僅套用於相容的長條或柱狀群組。

**什麼是圖表系列群組？**

[ChartSeriesGroup](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/chartseriesgroup/) 包含共享群組層級繪圖設定的相容系列。組合圖表可以包含多個群組，因此透過單一系列取得的群組設定不一定會影響圖表中所有系列。

**新建立的圖表是否包含預設資料？**

是的。預設情況下，[ShapeCollection.addChart](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/shapecollection/#addChart) 會建立範例系列、類別與數值。您可以編輯這些儲存格，或在加入自訂資料集之前先清除系列與類別集合。亦可使用其他重載建立不含預設資料的圖表。

**圖表物件如何與活頁簿儲存格連結？**

系列名稱、類別標籤與資料點數值皆參照 [ChartDataWorkbook](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/chartdataworkbook/) 中的儲存格。變更被參照的儲存格會即時更新相對應的圖表元素。自建資料時，請確保類別列與系列值列保持對齊，以便每個資料點正確映射至預期的類別。

**如何僅清除單一資料點而非整個系列？**

將相關的值儲存格設定為 `null`，即可保留資料點的類別位置，只讓它顯示為空白。僅在欲移除該系列所有資料點時才使用 [ChartDataPointCollection.clear](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/chartdatapointcollection/#clear)。如果同時刪除類別，請記得更新所有系列，使其值仍與類別集合保持對齊。

**空白點如何顯示？**

顯示結果取決於圖表類型以及透過 [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/chart/#setDisplayBlanksAs) 設定的方式。支援的圖表可以將空白顯示為斷線、零值或將相鄰點連接起來。請選擇最能表達遺失資料意義的設定，詳情請參閱 [控制空儲存格的顯示](#控制空儲存格的顯示) 之完整範例與視覺比較。

**負值如何格式化？**

對於支援的長條、柱狀與氣泡系列，呼叫 [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/chartseries/#setInvertIfNegative) 並設定由 [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/chartseries/#getInvertedSolidFillColor) 取得的顏色，即可為負值指定不同的填充色彩。您也可以透過 [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/chartdatapoint/#setInvertIfNegative) 為單一資料點覆寫此行為。這些方法僅影響顯示格式，並不改變儲存的數值。

**當系列與資料點同時格式化時，哪個格式優先？**

對於特定資料點，明確的資料點格式會覆寫系列格式。其他資料點則繼續使用明確的系列格式，若系列格式未定義則使用自動的圖表樣式與佈景主題。群組設定（如重疊度與間隙寬度）屬於版面配置，並不會覆寫資料點層級的格式。

**圖表可容納的系列數量是否有限制？**

Aspose.Slides 本身並未設定固定的系列數上限。實際上限取決於簡報檔案的限制、可用記憶體、渲染時間以及圖表的可讀性。

**當欄位過於靠近或過遠時，應該調整什麼？**

對相應的父系列群組呼叫 [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/chartseriesgroup/#setGapWidth)。增加數值會擴大叢集之間的間距，減少則會使叢集更緊密。