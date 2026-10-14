---
title: 使用 JavaScript 在簡報中自訂圓形圖
linktitle: 圓形圖
type: docs
url: /zh-hant/nodejs-java/pie-chart/
keywords:
- 圓形圖
- 管理圖表
- 自訂圖表
- 圖表選項
- 圖表設定
- 繪圖選項
- 切片顏色
- PowerPoint
- 簡報
- Node.js
- JavaScript
- Aspose.Slides
description: "使用 Aspose.Slides for Node.js via Java 於 JavaScript 中建立並自訂圓形圖。設定次要圖表、顯示資料標籤，並在 PowerPoint 中套用自動切片顏色。"
---
## **概觀**

本文說明如何在 Aspose.Slides 中使用圓形圖，並展示如何設定 Pie of Pie 與 Bar of Pie 圓形圖的次要圖表選項，以及如何為標準圓形圖啟用自動切片著色。

範例著重於圖表自訂工作，例如將圖表新增至投影片、調整系列與標籤設定、以自訂類別與數值取代預設圖表資料，並儲存更新後的簡報。

## **Pie of Pie 與 Bar of Pie 圓形圖的次要圖表選項**

Aspose.Slides for Node.js via Java 支援 Pie of Pie 與 Bar of Pie 圓形圖的次要圖表選項。這些選項可控制次要圖表的大小以及資料點在兩個圖表之間的分割方式。

以下範例在新簡報中建立一個 Pie of Pie 圓形圖，並以標籤顯示資料點數值。 [setSecondPieSize](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/#setSecondPieSize) 方法將次要圖表大小設定為主圖表的 149%。 [setPieSplitBy](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/#setPieSplitBy) 選擇依百分比分割，且 [setPieSplitPosition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/#setPieSplitPosition) 將門檻設定為 53%。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.PieOfPie, 50, 50, 500, 400);
    const series = chart.getChartData().getSeries().get_Item(0);

    // 顯示數值並設定次要圖表。
    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);
    const seriesGroup = series.getParentSeriesGroup();
    seriesGroup.setSecondPieSize(149);
    seriesGroup.setPieSplitBy(aspose.slides.PieSplitType.ByPercentage);
    seriesGroup.setPieSplitPosition(53);

    presentation.save("pie_of_pie.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **為次要圖表選取類別**

當您想將特定類別無論其百分比值為何，都集中於次要圖表時，可使用自訂分割。例如，銷售報表可能會將「線上」與「活動」放在一起，以便讀者比較這兩個渠道，即使它們分別佔總銷售的 35% 與 10%。

呼叫 [setPieSplitBy](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/#setPieSplitBy) 並傳入 [PieSplitType.Custom](https://reference.aspose.com/slides/nodejs-java/aspose.slides/piesplittype/#Custom)，再透過 [getPieSplitCustomPoints](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/#getPieSplitCustomPoints) 取得集合。集合的 [add](https://reference.aspose.com/slides/nodejs-java/aspose.slides/piesplitcustompointcollection/#add) 方法接受系列中的零基索引；使用 [addItem](https://reference.aspose.com/slides/nodejs-java/aspose.slides/piesplitcustompointcollection/#addItem) 新增資料點物件。在此範例中，索引 1 選取「線上」，索引 3 選取「活動」。同時暫時加入「合作夥伴」，再使用 [removeItem](https://reference.aspose.com/slides/nodejs-java/aspose.slides/piesplitcustompointcollection/#removeItem) 將其移除。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.PieOfPie, 50, 50, 600, 200);

    // 以通路銷售資料取代預設資料。
    const workbook = chart.getChartData().getChartDataWorkbook();
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    const categoryNames = [ "Retail", "Online", "Partners", "Events" ];
    const values = [ 40, 35, 15, 10 ];
    const seriesNameCell = workbook.getCell(0, 0, 1, "Sales");
    const series = chart.getChartData().getSeries().add(seriesNameCell, chart.getType());

    for (let i = 0; i < categoryNames.length; i++) {
        const categoryCell = workbook.getCell(0, i + 1, 0, categoryNames[i]);
        chart.getChartData().getCategories().add(categoryCell);

        const valueCell = workbook.getCell(0, i + 1, 1, values[i]);
        series.getDataPoints().addDataPointForPieSeries(valueCell);
    }

    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);
    const seriesGroup = series.getParentSeriesGroup();
    seriesGroup.setPieSplitBy(aspose.slides.PieSplitType.Custom);
    seriesGroup.setColorVaried(true);

    // 使用其零基索引選取 Online，並使用資料點物件選取 Events。
    seriesGroup.getPieSplitCustomPoints().add(1);
    seriesGroup.getPieSplitCustomPoints().addItem(series.getDataPoints().get_Item(3));

    // 將 Partners 從選取中排除，但不刪除其來源資料。
    seriesGroup.getPieSplitCustomPoints().add(2);
    seriesGroup.getPieSplitCustomPoints().removeItem(series.getDataPoints().get_Item(2));

    presentation.save("pie_of_pie_custom.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

「線上」(35) 與「活動」(10) 在次要圖表中顯示為獨立切片。於主圖表中，它們以值為 45 的合併切片呈現，並與「零售」(40) 及「合作夥伴」(15) 同列。從自訂選取中移除「合作夥伴」僅使其不出現在次要圖表，並不會從圖表來源資料中刪除該類別或其數值。

以下圖片顯示已於 PowerPoint 中儲存的簡報：

![Pie of Pie chart with Online and Events in the secondary plot and their combined value of 45 in the primary plot](pie_of_pie_custom.png)

## **設定自動圓形圖切片顏色**

Aspose.Slides for Node.js via Java 可自動為圓形圖的切片指派不同顏色。以下範例建立一個帶置中標題的圓形圖，並以三個季度類別及其數值取代預設資料。[setShowValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabelformat/#setShowValue) 方法將 20、50 與 30 的值顯示為標籤，而 [setColorVaried](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/#setColorVaried) 則為每個切片啟用不同顏色。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.Pie, 100, 100, 400, 400);

    // 加入置中圖表標題。
    chart.getChartTitle().addTextFrameForOverriding("Sample Title");
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(java.newByte(aspose.slides.NullableBool.True));
    chart.getChartTitle().setHeight(20);
    chart.setTitle(true);

    // 使用第一個工作表取代預設資料。
    const workbook = chart.getChartData().getChartDataWorkbook();
    const worksheetIndex = 0;
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    const categoryNames = [ "First Qtr", "2nd Qtr", "3rd Qtr" ];
    const values = [ 20, 50, 30 ];
    const seriesNameCell = workbook.getCell(worksheetIndex, 0, 1, "Series 1");
    const series = chart.getChartData().getSeries().add(seriesNameCell, chart.getType());

    for (let i = 0; i < categoryNames.length; i++) {
        const categoryCell = workbook.getCell(worksheetIndex, i + 1, 0, categoryNames[i]);
        chart.getChartData().getCategories().add(categoryCell);

        const valueCell = workbook.getCell(worksheetIndex, i + 1, 1, values[i]);
        series.getDataPoints().addDataPointForPieSeries(valueCell);
    }

    // 顯示數值並為切片分配不同顏色。
    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);
    series.getParentSeriesGroup().setColorVaried(true);

    presentation.save("pie.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **常見問題**

**是否支援 Pie of Pie 與 Bar of Pie 變體？**

是的，該函式庫 [支援](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/) 圓形圖的次要圖表，包括 Pie of Pie 與 Bar of Pie 類型。

**我能否僅將圖表匯出為影像（例如 PNG）？**

可以，您可以 [匯出圖表本身為影像](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getImage)（如 PNG），而無需匯出整個簡報。