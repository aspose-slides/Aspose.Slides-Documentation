---
title: 在簡報中使用 JavaScript 管理圖表資料系列
linktitle: 資料系列
type: docs
url: /zh-hant/nodejs-java/chart-series/
keywords:
- 圖表系列
- 系列重疊
- 系列顏色
- 系列名稱
- 資料點
- 活頁本儲存格
- 系列間距
- 負值
- PowerPoint
- 簡報
- Node.js
- JavaScript
- Aspose.Slides
description: "了解如何在簡報中使用 JavaScript 管理圖表系列、資料點、活頁本儲存格、格式設定、重疊、間距寬度和負值。"
---
## **概觀**

圖表將其繪製的資料儲存在圖表資料活頁本中。 [ChartSeries](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/) 代表一組相關值，而系列中的每個 [ChartDataPoint](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapoint/) 均參照一個或多個活頁本儲存格。[ChartCategory](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartcategory/) 物件提供系列共用的標籤或分組值。因此，系列名稱、類別和點值會連結至 [ChartDataCell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatacell/) 物件，而非僅以顯示文字儲存。

對於一般的類別圖，預設活頁本使用第 0 列儲存系列名稱，第 0 行儲存類別名稱，其餘儲存格用於系列值。傳遞給 [ChartDataWorkbook.getCell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdataworkbook/#getCell) 的工作表、列與欄索引為零基礎。此佈局在建立預設資料的圖表時相當有用，但不要假設每個現有圖表皆採用此佈局。對於已載入的簡報，請於變更活頁本資料前先檢查系列、類別與資料點所參照的儲存格。

圖表設定有三種不同的範圍：

- 系列層級設定，例如 [ChartSeries.getFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/#getFormat)，提供整個系列內所有點的預設外觀。
- データ點層級設定，例如 [ChartDataPoint.getFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapoint/#getFormat)，會覆寫該系列的外觀僅針對單一點。
- 群組設定套用於屬於同一個 [ChartSeriesGroup](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/) 的相容系列。當需要設定重疊或間距寬度等選項時，請透過 [ChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/#getParentSeriesGroup) 取得群組。

當未明確設定點或系列的填色時，圖表樣式與主題會決定自動外觀。若同時存在系列與點的格式設定，點的格式會優先套用於該點。

![chart-series-powerpoint](chart-series-powerpoint.png)

## **設定圖表系列重疊**

[ChartSeries.getOverlap](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/#getOverlap) 回報 2D 圖表中長條或柱狀的重疊程度，範圍從 -100% 到 100%。它是父系列群組設定的唯讀投射。使用 [ChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/#setOverlap) 可更新該群組中所有相容系列。此選項套用於顯示分組長條或柱狀的圖表類型；不會影響組合圖中不相關的系列群組。

下列範例設定包含第一個系列的群組重疊：

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

    // 新圖表包含示範系列、類別和數值。
    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 200);

    const series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    series.getParentSeriesGroup().setOverlap(overlapPercent);

    presentation.save("series_overlap.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果：

![The series overlap](series_overlap.png)

## **變更系列填色**

使用 [ChartSeries.getFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/#getFormat) 設定整個系列的預設填色。如果某個點已有明確的填色，則其 [ChartDataPoint.getFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapoint/#getFormat) 設定會覆寫該系列的填色。

下列範例將第一個系列設定為實心藍色填充：

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

![The color of the series](series_color.png)

## **變更系列名稱**

系列名稱儲存在圖表資料活頁本中，通常顯示於圖例。對於預設用於群組柱狀圖的活頁本，儲存格 B1 位於第 0 列第 1 欄，內含第一個系列的名稱。以下範例中的具名常數明確說明了此結構：

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

您也可以直接更新 [ChartSeries.getName](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/#getName) 已參照的儲存格。此作法避免假設現有圖表中的特定列與欄：

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

![The series name](series_name.png)

### **從多個儲存格建立具有名稱的系列**

當產品名稱與報告期間分別儲存在不同活頁本儲存格時，複合系列名稱會很有用。例如，您可以將 B1 中的 `Product A` 與 C1 中的 `2026` 合併為單一系列名稱，同時保留兩個部份與其來源儲存格的連結。

使用 [ChartDataWorkbook.getCellCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdataworkbook/#getCellCollection) 取得名稱範圍，然後將該集合傳遞給 [ChartSeriesCollection.add](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriescollection/#add)。`skipHiddenCells` 參數控制是否包含隱藏儲存格：`true` 會排除，`false` 會包含。本範例使用 `false` 以包含名稱範圍中的每個儲存格。

下列範例建立一個包含一個系列與兩個資料點的簡報。B1:C1 僅提供系列名稱；A2:A3 提供類別標籤；B2:B3 提供數值。

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 620, 180);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    chart.setLegend(true);

    const workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    // 這兩個儲存格提供系列名稱。
    workbook.getCell(0, 0, 1, "Product A");
    workbook.getCell(0, 0, 2, "2026");
    const nameCells = workbook.getCellCollection("Sheet1!$B$1:$C$1", false);
    const series = chart.getChartData().getSeries().add(nameCells, aspose.slides.ChartType.ClusteredColumn);

    // 分別的儲存格提供類別和數值資料點。
    const northCategory = workbook.getCell(0, 1, 0, "North");
    const southCategory = workbook.getCell(0, 2, 0, "South");
    chart.getChartData().getCategories().add(northCategory);
    chart.getChartData().getCategories().add(southCategory);
    const northValue = workbook.getCell(0, 1, 1, 120);
    const southValue = workbook.getCell(0, 2, 1, 150);
    series.getDataPoints().addDataPointForBarSeries(northValue);
    series.getDataPoints().addDataPointForBarSeries(southValue);

    presentation.save("composite_series_name.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

產生的系列名稱為 `Product A 2026`，兩個儲存格值之間保有空格。圖例會將此顯示為單一條目。下圖說明結果：

![Column chart with North and South values and the composite series name Product A 2026 in the legend](composite_series_name.png)

## **取得自動系列填色**

[ChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/#getAutomaticSeriesColor) 會回傳依系列索引與圖表樣式計算出的顏色。此顏色在系列填色未明確定義時使用。呼叫此方法僅讀取計算出的顏色，不會指派新填色。

下列範例列印每個預設系列的自動顏色：

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

實際顏色取決於圖表樣式與主題。

## **為圖表系列設定負值反向填色**

對於長條、柱狀與氣泡系列，[ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/#setInvertIfNegative) 可讓負值以不同的填色顯示。先將系列填色設定為實心，啟用反向，並透過 [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/#getInvertedSolidFillColor) 指定負值顏色。負數在活頁本中仍保留原值，僅改變顯示顏色。

下列範例以一個系列取代預設圖表資料。第 0 列儲存系列名稱，第 0 欄儲存類別名稱，第 1 欄儲存數值：

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

![The inverted solid fill color](inverted_solid_fill_color.png)

您也可以透過 [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapoint/#setInvertIfNegative) 為單一點啟用反向。以下範例在系列停用反向的同時，僅為所選點啟用，且該點同時被賦予負值，以便顯示效果：

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

## **清除特定資料點值**

若要讓單一點變為空白而不移除其他點，請將其背後的活頁本儲存格設為 `null`。對於柱狀圖，可透過 [ChartDataPoint.getValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapoint/#getValue) 取得繪製值。資料點仍保留在相同類別位置，但圖表會依據空白值設定將其視為空白。

下列範例僅清除第一個系列的第二個點：

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

散佈圖使用分別的 X 與 Y 儲存格，氣泡圖亦使用大小儲存格。僅清除欲移除之值的儲存格。若只想保留其他點，請勿呼叫 [ChartDataPointCollection.clear](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapointcollection/#clear)，因為該方法會移除該系列的全部資料點。

## **控制空儲存格的顯示方式**

包含值的隱藏儲存格與空儲存格屬不同情況。若要包含或排除隱藏工作表列與欄的資料，請參閱 [Include Data from Hidden Rows and Columns](/slides/zh-hant/nodejs-java/chart-workbook/#include-data-from-hidden-rows-and-columns)。

空的活頁本儲存格代表缺少資料；包含 `0` 的儲存格則代表已知的數值。呼叫 [ChartDataCell.setValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatacell/#setValue) 並傳入 `null` 即可將儲存格設為空白。數值零即使在空白儲存格設定下仍保持為零。

使用 [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/#setDisplayBlanksAs) 來選擇圖表如何顯示空儲存格。此設定套用於整個圖表，會改變空白的繪製方式，而不會將空儲存格填入零或插值值。

以下自行包含的範例建立一個含一個系列的折線圖，清除第 3 天的值，並以每種模式儲存同一圖表。無需輸入檔案。[ChartDataWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdataworkbook/) 使用第 0 工作表，第 0 欄作為類別標籤，第 1 欄作為數值；第 0 列儲存系列名稱。最終資料為 `10, 20, empty, 30, 40`。

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

    // 讓第 3 天實際保持空白，同時保留其類別和資料點。
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

每個輸出檔案會以儲存前設定的模式命名：`empty_cells_Gap.pptx`、`empty_cells_Zero.pptx`、`empty_cells_Span.pptx`。若只需保存一個版本，請先設定所需模式，然後只儲存一次簡報。

下圖比較三個檔案的相同資料。第 3 天在活頁本中皆為空白：

![Line charts with identical data: Gap breaks the line at Day 3, Zero drops the line to zero, and Span connects Day 2 to Day 4.](display_blanks_as.png)

可見效果取決於圖表類型。折線圖最能清楚比較三種模式。長條與柱狀圖因缺少可跨越缺失類別的連接線，`Span` 無法產生上述連接段；缺失的柱狀與高度為零的柱狀也可能看起來相似。散佈圖僅有標記時亦無連接線。請勿期望每種圖表類型都有三種明顯結果；請依您使用的圖表類型檢查輸出。

## **設定系列間距寬度**

間距寬度是相鄰長條或柱狀叢集之間的空間，表示為長條或柱狀寬度的百分比。與重疊相同，它屬於父系列群組而非單一系列。對群組呼叫一次 [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/#setGapWidth) 即可。較大的數值會在叢集之間產生更大空間，較小的數值則使叢集更緊密。

下列範例變更間距寬度，並僅儲存最終簡報：

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

![The gap width](gap_width.png)

## **常見問題集**

**哪些圖表類型支援資料系列？**

所有由 [ChartType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/) 列舉表示的圖表類型皆使用圖表資料，但其系列的值結構或設定並不完全相同。例如，類別圖使用類別與值，散佈圖使用 X 與 Y 值，氣泡圖則額外加入氣泡大小。請使用與系列類型相符的資料點建立方法。重疊與間距寬度等選項僅適用於相容的長條或柱狀群組。

**什麼是圖表系列群組？**

[ChartSeriesGroup](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/) 包含共享群組層級繪製設定的相容系列。組合圖可以包含多個群組，因此透過某個系列取得的群組設定不一定會影響圖表中的所有系列。

**新建立的圖表會包含預設資料嗎？**

會。預設情況下，[ShapeCollection.addChart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addChart) 會產生範例系列、類別與值。您可以編輯這些儲存格，或在加入完全自訂的資料集之前先清除系列與類別集合。亦可使用其他重載建立不含預設資料的圖表。

**圖表物件如何與活頁本儲存格連結？**

系列名稱、類別標籤與資料點值皆參照 [ChartDataWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdataworkbook/) 中的儲存格。變更被參照的儲存格會即時更新相應的圖表元素。建立自訂資料時，請確保類別列與系列值列保持對齊，使每個點都繪製在正確的類別下。

**如何只清除單一點而不是整個系列？**

將相關的值儲存格設為 `null`，即可保留該點的類別位置作為空白點。僅在希望移除該系列所有點時才使用 [ChartDataPointCollection.clear](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapointcollection/#clear)。

**空白點會如何顯示？**

結果取決於圖表類型以及透過 [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/#setDisplayBlanksAs) 設定的值。支援的圖表可將空白顯示為間隙、零值或連接相鄰點。選擇最符合簡報中缺失資料意涵的設定。請參閱 [Control the Display of Empty Cells](#control-the-display-of-empty-cells) 取得完整範例與視覺比較。

**負值的格式如何設定？**

對於支援的長條、柱狀與氣泡系列，呼叫 [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/#setInvertIfNegative) 並設定 [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/#getInvertedSolidFillColor) 回傳的顏色。您也可以使用 [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapoint/#setInvertIfNegative) 為單一點覆寫此行為。這些方法僅影響格式，不會改變儲存的數值。

**當系列與資料點同時設定格式時，哪個會贏？**

明確的資料點格式會優先套用於該點。其他點仍會使用明確的系列格式，或在系列未設定時使用自動圖表樣式與主題。群組設定（例如重疊與間距寬度）屬於版面配置，並非點層級的格式覆寫。

**圖表能容納多少個系列？是否有上限？**

Aspose.Slides 本身未設定固定的系列數量上限。實務上，簡報檔案的限制、可用記憶體、渲染時間與圖表可讀性會決定實際可用的上限。

**當欄位過於靠近或過於分散時，應如何調整？**

對相應的父系列群組呼叫 [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/#setGapWidth)。提高數值可擴大叢集之間的間距，降低數值則使叢集更靠近。