---
title: 使用 JavaScript 在簡報中管理圖表資料標籤
linktitle: 資料標籤
type: docs
url: /zh-hant/nodejs-java/chart-data-label/
keywords:
- 圖表
- 資料標籤
- 資料精度
- 百分比
- 標籤距離
- 標籤位置
- PowerPoint
- 簡報
- Node.js
- JavaScript
- Aspose.Slides
description: "學習如何在 PowerPoint 簡報中使用 JavaScript 以及 Aspose.Slides for Node.js（透過 Java）加入並格式化圖表資料標籤，以打造更具吸引力的投影片。"
---
## **簡介**

資料標籤顯示圖表系列與個別資料點的資訊，協助讀者辨識數值並了解圖表。本篇說明如何格式化值、顯示百分比、讀取標籤文字、控制超出座標軸最大值的標籤、調整類別座標軸標籤間距，以及定位圓餅圖標籤。

## **設定圖表資料標籤的數值精度**

使用 [setNumberFormatOfValues](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/setnumberformatofvalues/) 來格式化系列值。此範例建立一個使用預設資料的折線圖，顯示其資料表，並為第一個系列啟用值標籤。格式 `#,##0.00` 會顯示千位分隔符與兩位小數，且不會改變底層的實際值。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.Line, 50, 50, 450, 300);
    chart.setDataTable(true);

    const series = chart.getChartData().getSeries().get_Item(0);
    series.setNumberFormatOfValues("#,##0.00");
    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);

    presentation.save("PrecisionOfDatalabels_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **將百分比作為標籤顯示**

對於堆疊直條圖，計算每個值佔其類別總和的百分比，並將文字指派給 [getTextFrameForOverriding](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabel/gettextframeforoverriding/) 回傳的文字框。此範例使用預設圖表資料，將百分比以兩位小數、8 點字型顯示。總和為零的類別會被略過，以避免除以零。若圖表資料變更，需重新計算自訂標籤文字。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.StackedColumn, 20, 20, 400, 400);

    const categoryTotals = new Array(chart.getChartData().getCategories().size()).fill(0);
    for (let k = 0; k < chart.getChartData().getCategories().size(); k++) {
        for (let i = 0; i < chart.getChartData().getSeries().size(); i++) {
            const series = chart.getChartData().getSeries().get_Item(i);
            const pointValue = series.getDataPoints().get_Item(k).getValue().getData();
            categoryTotals[k] += Number(pointValue);
        }
    }

    for (let x = 0; x < chart.getChartData().getSeries().size(); x++) {
        const series = chart.getChartData().getSeries().get_Item(x);
        series.getLabels().getDefaultDataLabelFormat().setShowLegendKey(false);

        for (let j = 0; j < series.getDataPoints().size(); j++) {
            const label = series.getDataPoints().get_Item(j).getLabel();
            if (categoryTotals[j] == 0) {
                continue;
            }

            const pointValue = series.getDataPoints().get_Item(j).getValue().getData();
            const dataPointPercent = (Number(pointValue) / categoryTotals[j]) * 100;

            const portion = new aspose.slides.Portion();
            portion.setText(dataPointPercent.toFixed(2) + " %");
            portion.getPortionFormat().setFontHeight(8);

            label.getTextFrameForOverriding().setText("");
            const paragraph = label.getTextFrameForOverriding().getParagraphs().get_Item(0);
            paragraph.getPortions().add(portion);

            label.getDataLabelFormat().setShowValue(true);
            label.getDataLabelFormat().setShowSeriesName(false);
            label.getDataLabelFormat().setShowPercentage(false);
            label.getDataLabelFormat().setShowLegendKey(false);
            label.getDataLabelFormat().setShowCategoryName(false);
            label.getDataLabelFormat().setShowBubbleSize(false);
        }
    }

    presentation.save("DisplayPercentageAsLabels_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **使用圖表資料標籤設定百分比符號**

當值以分數形式儲存時，使用 [setNumberFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabelformat/setnumberformat/) 來顯示百分比。將 `false` 傳遞給 [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabelformat/setnumberformatlinkedtosource/) 可讓標籤格式獨立於來源儲存格。

此範例建立一個 100% 堆疊直條圖，四個類別各有紅色與藍色系列。每對數值的總和為 1。標籤格式 `0.0%` 會將 0.30 顯示為 30.0%，而垂直座標軸使用兩位小數。兩個系列的標籤文字皆為白色、10 點。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.PercentsStackedColumn, 20, 20, 500, 400);

    chart.getAxes().getVerticalAxis().setNumberFormatLinkedToSource(false);
    chart.getAxes().getVerticalAxis().setNumberFormat("0.00%");

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    const workbook = chart.getChartData().getChartDataWorkbook();
    const worksheetIndex = 0;
    for (let i = 0; i < 4; i++) {
        const categoryCell = workbook.getCell(worksheetIndex, i + 1, 0, "Category " + (i + 1));
        chart.getChartData().getCategories().add(categoryCell);
    }

    const seriesNames = ["Reds", "Blues"];
    const white = java.getStaticFieldValue("java.awt.Color", "WHITE");
    const seriesColors = [java.getStaticFieldValue("java.awt.Color", "RED"), java.getStaticFieldValue("java.awt.Color", "BLUE")];
    const values = [[0.30, 0.50, 0.80, 0.65], [0.70, 0.50, 0.20, 0.35]];

    for (let i = 0; i < seriesNames.length; i++) {
        const seriesCell = workbook.getCell(worksheetIndex, 0, i + 1, seriesNames[i]);
        const series = chart.getChartData().getSeries().add(seriesCell, chart.getType());
        for (let j = 0; j < 4; j++) {
            const valueCell = workbook.getCell(worksheetIndex, j + 1, i + 1, values[i][j]);
            series.getDataPoints().addDataPointForBarSeries(valueCell);
        }

        series.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
        series.getFormat().getFill().getSolidFillColor().setColor(seriesColors[i]);

        const labelFormat = series.getLabels().getDefaultDataLabelFormat();
        labelFormat.setShowValue(true);
        labelFormat.setNumberFormatLinkedToSource(false);
        labelFormat.setNumberFormat("0.0%");
        labelFormat.getTextFormat().getPortionFormat().setFontHeight(10);
        labelFormat.getTextFormat().getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
        labelFormat.getTextFormat().getPortionFormat().getFillFormat().getSolidFillColor().setColor(white);
    }

    presentation.save("SetDataLabelsPercentageSign_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **讀取資料標籤的實際文字**

使用 [getActualLabelText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabel/getactuallabeltext/) 取得資料標籤設定所產生的文字。這在為報告抽取標籤、搜尋簡報內容或驗證產生的圖表時非常有用。以下範例中，預設的 [data label format](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabelformat/) 結合每個類別名稱、系列名稱與數值。其中一個點將其數值格式化為百分比，另一個則使用 [getTextFrameForOverriding](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabel/gettextframeforoverriding/) 的自訂文字。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 300);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    const workbook = chart.getChartData().getChartDataWorkbook();
    const firstCategoryCell = workbook.getCell(0, 1, 0, "Q1");
    chart.getChartData().getCategories().add(firstCategoryCell);
    const secondCategoryCell = workbook.getCell(0, 2, 0, "Q2");
    chart.getChartData().getCategories().add(secondCategoryCell);

    const northSeriesCell = workbook.getCell(0, 0, 1, "North");
    const north = chart.getChartData().getSeries().add(northSeriesCell, chart.getType());
    const northFirstValueCell = workbook.getCell(0, 1, 1, 0.25);
    north.getDataPoints().addDataPointForBarSeries(northFirstValueCell);
    const northSecondValueCell = workbook.getCell(0, 2, 1, 0.75);
    north.getDataPoints().addDataPointForBarSeries(northSecondValueCell);

    const southSeriesCell = workbook.getCell(0, 0, 2, "South");
    const south = chart.getChartData().getSeries().add(southSeriesCell, chart.getType());
    const southFirstValueCell = workbook.getCell(0, 1, 2, 0.40);
    south.getDataPoints().addDataPointForBarSeries(southFirstValueCell);
    const southSecondValueCell = workbook.getCell(0, 2, 2, 0.60);
    south.getDataPoints().addDataPointForBarSeries(southSecondValueCell);

    for (let i = 0; i < chart.getChartData().getSeries().size(); i++) {
        const series = chart.getChartData().getSeries().get_Item(i);
        const format = series.getLabels().getDefaultDataLabelFormat();
        format.setShowCategoryName(true);
        format.setShowSeriesName(true);
        format.setShowValue(true);
    }

    north.getLabels().get_Item(1).getDataLabelFormat().setNumberFormatLinkedToSource(false);
    north.getLabels().get_Item(1).getDataLabelFormat().setNumberFormat("0%");
    south.getLabels().get_Item(0).getTextFrameForOverriding().setText("Reviewed");

    for (let i = 0; i < chart.getChartData().getSeries().size(); i++) {
        const series = chart.getChartData().getSeries().get_Item(i);
        for (let j = 0; j < series.getDataPoints().size(); j++) {
            const point = series.getDataPoints().get_Item(j);
            const label = point.getLabel();
            if (!label.isVisible()) {
                continue;
            }

            console.log("Value: " + point.getValue().getData() + "; label: " + label.getActualLabelText());
        }
    }
} finally {
    presentation.dispose();
}
```

儲存在資料點中的數字仍為 `0.75`，即使其標籤顯示 `75%` 並附帶類別與系列名稱。自訂文字會取代產生的標籤文字。無論哪種情況，[getActualLabelText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabel/getactuallabeltext/) 都會回傳最終的標籤字串。若只想抽取可見標籤，請另行檢查 [isVisible](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabel/isvisible/)，如上所示。

## **控制超出座標軸最大值的資料標籤**

當手動限制座標軸範圍時，部分資料點可能會超過其最大值。使用 [setShowDataLabelsOverMaximum](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/setshowdatalabelsovermaximum/) 可控制是否顯示這些資料標籤。此設定會變更標籤的可見性，但不會改變座標軸範圍或底層資料值。

下方範例建立一個 2D 群組直條圖，值分別為 60 與 120。它將 `false` 傳遞給 [setAutomaticMaxValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setautomaticmaxvalue/)，並使用 [setMaxValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setmaxvalue/) 將垂直座標軸的最大值設定為 100。第一張投影片允許顯示超出最大值的標籤；其複製版則停用此功能。兩張投影片皆儲存於 `DataLabelsOverMaximum.pptx`。

使用 [setShowValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabelformat/setshowvalue/) 啟用值標籤。圖表層級的設定本身不會自動顯示值，也不會覆寫個別標籤已停用的值顯示。此範例為整個系列啟用值，並使用 [setPosition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabelformat/setposition/) 將標籤放置在每根柱形的外端。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400);
    chart.setLegend(false);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    const workbook = chart.getChartData().getChartDataWorkbook();

    const firstCategory = workbook.getCell(0, 1, 0, "Within range");
    const secondCategory = workbook.getCell(0, 2, 0, "Above maximum");

    chart.getChartData().getCategories().add(firstCategory);
    chart.getChartData().getCategories().add(secondCategory);

    const seriesName = workbook.getCell(0, 0, 1, "Values");
    const series = chart.getChartData().getSeries().add(seriesName, chart.getType());

    const firstValue = workbook.getCell(0, 1, 1, 60);
    const secondValue = workbook.getCell(0, 2, 1, 120);

    series.getDataPoints().addDataPointForBarSeries(firstValue);
    series.getDataPoints().addDataPointForBarSeries(secondValue);

    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);
    series.getLabels().getDefaultDataLabelFormat().setPosition(aspose.slides.LegendDataLabelPosition.OutsideEnd);

    chart.getAxes().getVerticalAxis().setAutomaticMaxValue(false);
    chart.getAxes().getVerticalAxis().setMaxValue(100);
    chart.setShowDataLabelsOverMaximum(true);

    const secondSlide = presentation.getSlides().addClone(slide);
    const secondChart = secondSlide.getShapes().get_Item(0);
    secondChart.setShowDataLabelsOverMaximum(false);

    presentation.save("DataLabelsOverMaximum.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

以下圖片顯示 Microsoft PowerPoint 渲染的儲存投影片。設定 `true` 時，標籤 **120** 會在上緣可見；設定 `false` 時則隱藏。標籤 **60** 始終可見，座標軸最大值保持 **100**，第二個資料點仍為 **120**。

| setShowDataLabelsOverMaximum(true) | setShowDataLabelsOverMaximum(false) |
| --- | --- |
| ![PowerPoint 圖表顯示值標籤 120，座標軸最大值為 100](data-labels-over-maximum-true.png) | ![PowerPoint 圖表隱藏值標籤 120，座標軸最大值為 100](data-labels-over-maximum-false.png) |

{{% alert color="info" title="Chart Type" %}}
此範例使用具有值座標軸的 2D 直條圖。沒有值座標軸的圖表（例如圓餅圖與環形圖）不會有此種方式可限制的座標軸最大值。
{{% /alert %}}

## **設定標籤與座標軸的距離**

使用 [setLabelOffset](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setlabeloffset/) 來控制類別座標軸標籤與座標軸之間的距離。此數值是類別座標軸標籤最大字型大小的百分比。範例建立一個群組直條圖，將水平座標軸標籤偏移設定為 500。此設定會影響類別座標軸標籤，而非附加於個別資料點的標籤。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 300);
    chart.getAxes().getHorizontalAxis().setLabelOffset(500);

    presentation.save("SetCategoryAxisLabelDistance_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **調整標籤位置**

在圓餅圖上，調整資料標籤的位置以改善間距並為引線留出空間。

此範例顯示第一個資料點的數值，將其標籤置於切片外側，並使用 [setX](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabel/setx/) 與 [setY](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabel/sety/) 調整水平與垂直偏移。這兩個偏移分別相對於圖表的寬度與高度。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.Pie, 50, 50, 200, 200);
    const series = chart.getChartData().getSeries();

    const label = series.get_Item(0).getLabels().get_Item(0);
    label.getDataLabelFormat().setShowValue(true);
    label.getDataLabelFormat().setPosition(aspose.slides.LegendDataLabelPosition.OutsideEnd);
    label.setX(java.newFloat(0.71));
    label.setY(java.newFloat(0.04));

    presentation.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![已調整資料標籤位置的圓餅圖](pie-chart-adjusted-label.png)

## **在直條圖上方加入多行資料標籤**

此範例建立一個直條圖，於繪圖區上方放置兩行資料標籤。Series A 顯示可見的柱形，Series B 與 Series C 則提供額外的標籤，其柱形透過移除填色與輪廓而隱藏。[ChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/setoverlap/) 方法讓三個系列的類別中心對齊。

[ChartPlotArea](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartplotarea/) 設定保留標籤行的空間。經過 [Chart.validateChartLayout](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/validatechartlayout/) 計算預設位置後，[DataLabel.setX](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabel/setx/) 與 [DataLabel.setY](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabel/sety/) 會保留水平對齊，並套用垂直偏移以將標籤排列成兩行。數字仍為連結至系列值的資料標籤；僅有行標題是獨立的文字圖形。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");
const black = java.getStaticFieldValue("java.awt.Color", "BLACK");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 40, 40, 640, 200);
    chart.setTitle(false);
    chart.setLegend(false);
    chart.getTextFormat().getPortionFormat().setFontHeight(12);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    const workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    const categories = ["North", "South", "East", "West"];
    const seriesNames = ["Series A", "Series B", "Series C"];
    const seriesValues = [[35, 42, 28, 47], [22, 31, 19, 26], [12, 16, 14, 18]];

    for (let categoryIndex = 0; categoryIndex < categories.length; categoryIndex++) {
        const categoryCell = workbook.getCell(0, categoryIndex + 1, 0, categories[categoryIndex]);
        chart.getChartData().getCategories().add(categoryCell);
    }

    for (let seriesIndex = 0; seriesIndex < seriesNames.length; seriesIndex++) {
        const seriesCell = workbook.getCell(0, 0, seriesIndex + 1, seriesNames[seriesIndex]);
        const series = chart.getChartData().getSeries().add(seriesCell, aspose.slides.ChartType.ClusteredColumn);

        for (let categoryIndex = 0; categoryIndex < categories.length; categoryIndex++) {
            const valueCell = workbook.getCell(0, categoryIndex + 1, seriesIndex + 1, seriesValues[seriesIndex][categoryIndex]);
            series.getDataPoints().addDataPointForBarSeries(valueCell);
        }

        if (seriesIndex > 0) {
            // 隱藏 B 與 C 的柱形，但保留其資料標籤。
            series.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.NoFill));
            series.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
            series.getLabels().getDefaultDataLabelFormat().setShowValue(true);
            series.getLabels().getDefaultDataLabelFormat().getTextFormat().getPortionFormat().setFontHeight(12);
            const labelFill = series.getLabels().getDefaultDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat();
            labelFill.setFillType(java.newByte(aspose.slides.FillType.Solid));
            labelFill.getSolidFillColor().setColor(black);
            series.getLabels().getDefaultDataLabelFormat().setPosition(aspose.slides.LegendDataLabelPosition.InsideBase);
        }
    }

    // 使所有三個系列的類別中心對齊。
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setOverlap(java.newByte(100));

    // 為此緊湊範例使用較少的格線。
    chart.getAxes().getVerticalAxis().setAutomaticMajorUnit(false);
    chart.getAxes().getVerticalAxis().setMajorUnit(10);

    // 在繪圖區上方保留空間以放置兩行資料標籤。
    chart.getPlotArea().setLayoutTargetType(aspose.slides.LayoutTargetType.Inner);
    chart.getPlotArea().setX(java.newFloat(0.15));
    chart.getPlotArea().setY(java.newFloat(0.32));
    chart.getPlotArea().setWidth(java.newFloat(0.80));
    chart.getPlotArea().setHeight(java.newFloat(0.48));
    chart.validateChartLayout();

    for (let seriesIndex = 1; seriesIndex < seriesNames.length; seriesIndex++) {
        const series = chart.getChartData().getSeries().get_Item(seriesIndex);
        const rowTop = seriesIndex == 1 ? 0.15 : 0.03;

        for (let categoryIndex = 0; categoryIndex < categories.length; categoryIndex++) {
            const dataLabel = series.getDataPoints().get_Item(categoryIndex).getLabel();
            // 保持預設的水平位置。Y 為相對於
            // 預設標籤位置的偏移量，以圖表高度的比例表示。
            dataLabel.setX(0);
            dataLabel.setY(java.newFloat(rowTop - dataLabel.getActualY() / chart.getHeight()));
        }

        // 只有行標題是獨立的文字圖形。
        const rowHeading = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, chart.getX(), chart.getY() + rowTop * chart.getHeight(), 85, 18);
        rowHeading.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
        rowHeading.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
        rowHeading.addTextFrame(seriesNames[seriesIndex]);
        rowHeading.getTextFrame().getTextFrameFormat().setMarginTop(0);
        rowHeading.getTextFrame().getTextFrameFormat().setMarginBottom(0);
        const headingFormat = rowHeading.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat();
        headingFormat.setFontHeight(12);
        headingFormat.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
        headingFormat.getFillFormat().getSolidFillColor().setColor(black);
    }

    presentation.save("multiple-rows-of-labels.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![在繪圖區上方具有兩行資料標籤的直條圖](multiple-rows-of-labels.png)

## **常見問答**

**如何防止資料標籤在密集圖表上重疊？**

結合自動標籤放置、引線與縮小字型；必要時隱藏部分欄位（例如類別），或僅對極端值與關鍵點顯示標籤。

**如何僅對零值、負值或空值停用標籤？**

在啟用標籤之前先過濾資料點，並依據預定規則關閉 0、負值或缺失值的顯示。

**如何確保匯出為 PDF/影像時標籤樣式保持一致？**

明確設定字型系列與大小，並確認渲染環境中已安裝該字型，以避免回退。