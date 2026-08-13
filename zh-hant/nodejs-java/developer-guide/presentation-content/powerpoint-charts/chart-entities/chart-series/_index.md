---
title: 使用 JavaScript 在簡報中管理圖表資料系列
linktitle: 資料系列
type: docs
url: /zh-hant/nodejs-java/chart-series/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "了解如何在簡報中使用 JavaScript 管理圖表系列、資料點、工作簿儲存格、格式設定、重疊、間隙寬度以及負值。"
---
## **概覽**

圖表將其繪製的資料存放在圖表資料工作簿中。**[ChartSeries](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/chartseries/)** 代表一組相關的值，系列中的每個 **[ChartDataPoint](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/chartdatapoint/)** 皆對應一或多個工作簿儲存格。**[ChartCategory](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/chartcategory/)** 物件提供系列共用的標籤或分組值。系列名稱、類別以及點值因此連結至 **[ChartDataCell](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/chartdatacell/)** 物件，而非僅以顯示文字儲存。

對於一般的類別圖表，預設工作簿使用第 0 列儲存系列名稱，第 0 欄儲存類別名稱，其餘儲存格則放置系列值。傳遞給 **[ChartDataWorkbook.getCell](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/chartdataworkbook/#getCell)** 的工作表、列與欄索引皆為零基礎。此布局在建立預設資料圖表時很有用，但不要假設所有既有圖表皆採用此排列。對於已載入的簡報，在變更工作簿數值之前，請先檢查系列、類別與資料點所參照的儲存格。

圖表設定有三種不同的範圍：

- 系列層級設定，例如 **[ChartSeries.getFormat](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/chartseries/#getFormat)**，提供該系列所有點的預設外觀。
- 資料點層級設定，例如 **[ChartDataPoint.getFormat](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/chartdatapoint/#getFormat)**，會覆寫該系列的外觀於單一點上。
- 群組設定套用於屬於同一 **[ChartSeriesGroup](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/chartseriesgroup/)** 的相容系列。當需要設定如重疊或間隙寬度等選項時，請透過 **[ChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/chartseries/#getParentSeriesGroup)** 取得該群組。

如果未明確設定點或系列的填色，圖表樣式與佈景主題會決定自動外觀。當同時存在系列與點的格式設定時，點的格式會優先套用於該點。

![chart-series-powerpoint](chart-series-powerpoint.png)

## **設定圖表系列重疊**

**[ChartSeries.getOverlap](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/chartseries/#getOverlap)** 回報 2D 圖表中長條或柱狀的重疊程度，範圍為 -100% 到 100%。此屬性為父系列群組設定的唯讀投影。使用 **[ChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/chartseriesgroup/#setOverlap)** 可更新該群組中所有相容系列。此選項僅適用於顯示分組長條或柱狀的圖表類型；不會影響組合圖表中不相關的系列群組。

以下範例為包含第一個系列的群組設定重疊：

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

    // 新的圖表包含示範系列、類別和數值。
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

使用 **[ChartSeries.getFormat](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/chartseries/#getFormat)** 為整個系列設定預設填色。如果某個點已設定了明確的填色，其 **[ChartDataPoint.getFormat](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/chartdatapoint/#getFormat)** 會覆寫該系列的填色。

以下範例將第一個系列套用實心藍色填色：

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

系列名稱儲存在圖表資料工作簿中，通常顯示於圖例。對於叢集柱狀圖的預設工作簿，儲存格 B1 位於第 0 列第 1 欄，存放第一個系列的名稱。下列範例中的具名常數明確指出了此結構：

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

您也可以直接更新 **[ChartSeries.getName](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/chartseries/#getName)** 已參照的儲存格。此方式避免對既有圖表假設特定的列與欄：

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

## **取得自動系列填色**

**[ChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/chartseries/#getAutomaticSeriesColor)** 會回傳根據系列索引與圖表樣式計算出的顏色。這是未明確定義系列填色時所使用的顏色。呼叫此方法僅讀取計算出的顏色，不會指派新的填色。

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

實際顏色取決於圖表樣式與佈景主題。

## **為圖表系列設定負值反轉填色**

對於長條、柱狀與氣泡系列，**[ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/chartseries/#setInvertIfNegative)** 可在負值時使用不同的填色。請將系列的常規填色設為實心，啟用反轉，並透過 **[ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/chartseries/#getInvertedSolidFillColor)** 指定負值的顏色。負數在工作簿中仍保持不變，僅改變其顯示顏色。

以下範例以單一系列取代預設圖表資料。工作表第 0 列放置系列名稱，第 0 欄放置類別名稱，第 1 欄放置數值：

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

您也可以透過 **[ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/chartdatapoint/#setInvertIfNegative)** 為單一點啟用反轉。下列範例在系列層級關閉反轉，僅為選取的點啟用，同時將該點設定為負值以顯示效果：

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

若要使單一點變為空白而不移除其他點，請將其對應的工作簿儲存格設為 `null`。對於柱狀圖，可透過 **[ChartDataPoint.getValue](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/chartdatapoint/#getValue)** 取得繪製值。資料點仍保留在相同的類別位置，但圖表會依照空白值設定將其視為空白。

以下範例僅清除第一個系列的第二個點：

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

散佈圖使用分別的 X、Y 儲存格，氣泡圖則另有大小儲存格。僅清除您欲移除之值的儲存格。若只想保留其他點，請勿呼叫 **[ChartDataPointCollection.clear](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/chartdatapointcollection/#clear)**，因為該方法會移除集合中所有資料點。

## **設定系列間隙寬度**

間隙寬度是相鄰長條或柱狀叢集之間的空間，以長條或柱狀寬度的百分比表示。與重疊類似，它屬於父系列群組而非單一系列。對該群組呼叫 **[ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/chartseriesgroup/#setGapWidth)** 即可。較大的數值會在叢集之間產生更多空間，較小的數值則使叢集更緊密。

以下範例變更間隙寬度，並僅儲存最終的簡報：

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

## **常見問答**

**哪些圖表類型支援資料系列？**

所有由 **[ChartType](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/charttype/)** 列舉所代表的圖表類型皆使用圖表資料，但其系列並不具相同的值結構或設定。例如，類別圖表使用類別與值，散佈圖使用 X 與 Y 值，氣泡圖則額外加入氣泡大小。請使用與系列類型相符的資料點建立方法。重疊與間隙寬度等選項僅適用於相容的長條或柱狀群組。

**什麼是圖表系列群組？**

**[ChartSeriesGroup](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/chartseriesgroup/)** 包含共享群組層級繪圖設定的相容系列。組合圖表可包含多個群組，因此透過某一系列取得的群組設定不一定會影響圖表中所有系列。

**新建立的圖表是否包含預設資料？**

是的。預設情況下，**[ShapeCollection.addChart](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/shapecollection/#addChart)** 會建立示範系列、類別與值。您可以編輯這些儲存格，或在加入自訂資料集之前先清除系列與類別集合。亦可使用其他重載建立不含預設資料的圖表。

**圖表物件如何與工作簿儲存格連結？**

系列名稱、類別標籤與資料點值皆參照 **[ChartDataWorkbook](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/chartdataworkbook/)** 中的儲存格。變更所參照的儲存格即會更新對應的圖表元素。建構自訂資料時，請保持類別列與系列值列對齊，以確保每個點均繪製在正確的類別下。

**如何只清除單一點而不是整個系列？**

將相關的值儲存格設為 `null`，即可保留該點的類別位置作為空白點。僅在想移除該系列所有點時才使用 **[ChartDataPointCollection.clear](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/chartdatapointcollection/#clear)**，因為該方法會刪除整個集合的資料點。

**空白點會如何顯示？**

顯示結果取決於圖表類型以及透過 **[Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/chart/#setDisplayBlanksAs)** 設定的行為。支援的圖表可以將空白顯示為間隙、零值，或連接相鄰點。請選擇符合簡報中遺失資料意義的設定。

**負值會如何格式化？**

對於支援的長條、柱狀與氣泡系列，呼叫 **[ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/chartseries/#setInvertIfNegative)** 並設定 **[ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/chartseries/#getInvertedSolidFillColor)** 回傳的顏色。您亦可使用 **[ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/chartdatapoint/#setInvertIfNegative)** 為單一點覆寫此行為。這些方法僅影響格式，並不改變儲存的數值。

**當系列與點同時設定格式時，哪個會優先？**

明確的資料點格式會優先套用於該點。其他點則繼續使用明確的系列格式，或在系列未定義格式時使用自動的圖表樣式與佈景主題。群組設定（例如重疊與間隙寬度）屬於版面配置，並非點層級的格式覆寫。

**圖表能容納的系列數量是否有限制？**

Aspose.Slides 本身未設定固定的系列數上限。實務上，簡報檔案的限制、可用記憶體、渲染時間以及圖表可讀性會決定實際可用的上限。

**當欄位過於接近或過於分離時，我該怎麼調整？**

對相應的父系列群組呼叫 **[ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/chartseriesgroup/#setGapWidth)**。提高數值可擴大叢集之間的間距，降低數值則會使叢集更靠近。