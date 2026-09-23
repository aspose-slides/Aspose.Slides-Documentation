---
title: 使用 JavaScript 管理簡報中的圖表資料標籤
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
description: "了解如何使用 JavaScript 與 Aspose.Slides for Node.js（透過 Java）在 PowerPoint 簡報中新增與格式化圖表資料標籤，打造更具吸引力的投影片。"
---
## **簡介**

資料標籤會顯示圖表系列與個別資料點的資訊，協助讀者辨識數值並了解圖表內容。本文說明如何格式化數值、顯示百分比、讀取標籤文字、調整類別軸標籤間距，以及設定圓餅圖標籤的位置。

## **設定圖表資料標籤的資料精度**

使用[setNumberFormatOfValues](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/chartseries/setnumberformatofvalues/)來格式化系列值。此範例建立一個使用預設資料的折線圖，顯示其資料表，並為第一個系列啟用值標籤。格式 `#,##0.00` 會顯示千位分隔符號與兩位小數，而不會改變底層的實際值。

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

## **將百分比顯示為標籤**

對於堆疊柱狀圖，計算每個數值佔其類別總和的百分比，並將文字指派給[ getTextFrameForOverriding](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/datalabel/gettextframeforoverriding/)返回的文字框。此範例使用預設圖表資料，並以 8 點字型顯示兩位小數的百分比。總和為零的類別會被跳過，以避免除以零的情況。若圖表資料變更，請重新計算自訂標籤文字。

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

## **在圖表資料標籤中設定百分號**

當值以分數形式儲存時，使用[setNumberFormat](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/datalabelformat/setnumberformat/)來顯示百分比。將`false`傳遞給[setNumberFormatLinkedToSource](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/datalabelformat/setnumberformatlinkedtosource/)可讓標籤格式獨立於來源儲存格。

此範例建立一個 100% 堆疊柱狀圖，四個類別各有紅色與藍色系列。每對值的總和為 1。標籤格式 `0.0%` 會將 0.30 顯示為 30.0%，而垂直軸則使用兩位小數。兩個系列皆使用白色、10 點的標籤文字。

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

使用[getActualLabelText](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/datalabel/getactuallabeltext/)取得資料標籤設定所產生的文字。當需要將標籤匯出為報表、搜尋簡報內容，或驗證產生的圖表時，此功能非常有用。以下範例中，預設的[data label format](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/datalabelformat/)會將每個類別名稱、系列名稱與數值組合在一起。某個資料點將其值格式化為百分比，另一個則使用[getTextFrameForOverriding](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/datalabel/gettextframeforoverriding/)取得的自訂文字。

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

儲存在資料點中的數字仍為 `0.75`，即使其標籤顯示 `75%` 並附帶類別和系列名稱。自訂文字會取代系統產生的標籤文字。無論哪種情況，[getActualLabelText](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/datalabel/getactuallabeltext/)都會回傳最終的標籤字串。若只想取得可見的標籤，請另行檢查[isVisible](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/datalabel/isvisible/)，如上所示。

## **設定標籤與軸的距離**

使用[setLabelOffset](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/axis/setlabeloffset/)來控制類別軸標籤與軸之間的距離。該值是軸標籤最大字型大小的百分比。此範例建立一個群組柱狀圖，將水平軸標籤偏移設定為 500。此設定會影響類別軸標籤，而不是附加於個別資料點的標籤。

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

在圓餅圖上，調整資料標籤的位置以改善間距並為引線騰出空間。

此範例顯示第一個資料點的值，將其標籤放在切片外側，並使用[setX](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/datalabel/setx/)與[setY](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/datalabel/sety/)調整水平與垂直偏移量。這些偏移量分別相對於圖表的寬度與高度。

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

![調整資料標籤位置的圓餅圖](pie-chart-adjusted-label.png)

## **常見問題**

**如何防止在密集圖表上資料標籤重疊？**

結合自動標籤排列、引線與縮小字型大小；必要時隱藏某些欄位（例如類別），或僅為極端值或關鍵點顯示標籤。

**如何僅對零值、負值或空值停用標籤？**

在啟用標籤前先過濾資料點，並依照自訂規則關閉零值、負值或遺失值的顯示。

**如何確保匯出為 PDF/圖片時標籤樣式一致？**

明確設定字型系列與大小，並確認該字型在渲染環境中可用，以避免使用備援字型。