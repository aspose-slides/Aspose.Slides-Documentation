---
title: 使用 JavaScript 在簡報中自訂圓餅圖
linktitle: 圓餅圖
type: docs
url: /zh-hant/nodejs-java/pie-chart/
keywords:
- 圓餅圖
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
description: "了解如何使用 Aspose.Slides for Node.js 以 JavaScript 建立並自訂圓餅圖，並可匯出至 PowerPoint，讓您在數秒內提升資料敘事的效果。"
---
## **概述**

本文說明如何在 Aspose.Slides 中使用圓餅圖。它展示了如何為「Pie of Pie」和「Bar of Pie」圖表設定次要圖表選項，以及如何為標準圓餅圖啟用自動切片著色。

範例聚焦於實務的圖表自訂步驟，例如在投影片中加入圖表、調整系列與標籤設定、以自訂的類別與數值取代預設圖表資料，並儲存更新後的簡報。

## **Pie of Pie 與 Bar of Pie 圖表的次要圖表選項**
Aspose.Slides for Node.js via Java 現已支援 Pie of Pie 或 Bar of Pie 圖表的次要圖表選項。在本主題中，我們將示範如何使用 Aspose.Slides 來指定這些選項。設定屬性請按以下步驟操作：

1. 實例化 [Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/Presentation) 類別物件。
1. 在投影片上加入圖表。
1. 指定圖表的次要圖表選項。
1. 將簡報寫入磁碟。

以下範例中，我們已設定 Pie of Pie 圖表的不同屬性。

```javascript
// 建立 Presentation 類別的實例
var pres = new aspose.slides.Presentation();
try {
    // 在投影片上新增圖表
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.PieOfPie, 50, 50, 500, 400);
    // 設定不同的屬性
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setSecondPieSize(149);
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setPieSplitBy(aspose.slides.PieSplitType.ByPercentage);
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setPieSplitPosition(53);
    // 將簡報寫入磁碟
    pres.save("SecondPlotOptionsforCharts_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **設定自動圓餅圖切片顏色**
Aspose.Slides for Node.js via Java 提供簡易的 API 以設定自動圓餅圖切片顏色。範例程式碼套用了上述屬性設定。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/Presentation) 類別的實例。
1. 存取第一張投影片。
1. 使用預設資料加入圖表。
1. 設定圖表標題。
1. 將第一個系列設定為顯示數值。
1. 設定圖表資料工作表的索引。
1. 取得圖表資料工作表。
1. 刪除預設產生的系列與類別。
1. 新增類別。
1. 新增系列。

將修改後的簡報寫入 PPTX 檔案。

```javascript
// 建立 Presentation 類別的實例
var pres = new aspose.slides.Presentation();
try {
    // 新增帶有預設資料的圖表
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Pie, 100, 100, 400, 400);
    // 設定圖表標題
    chart.getChartTitle().addTextFrameForOverriding("Sample Title");
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(aspose.slides.NullableBool.True);
    chart.getChartTitle().setHeight(20);
    chart.setTitle(true);
    // 設定第一個系列以顯示數值
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);
    // 設定圖表資料工作表的索引
    var defaultWorksheetIndex = 0;
    // 取得圖表資料工作表
    var fact = chart.getChartData().getChartDataWorkbook();
    // 刪除預設產生的系列與類別
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    // 新增類別
    chart.getChartData().getCategories().add(fact.getCell(0, 1, 0, "First Qtr"));
    chart.getChartData().getCategories().add(fact.getCell(0, 2, 0, "2nd Qtr"));
    chart.getChartData().getCategories().add(fact.getCell(0, 3, 0, "3rd Qtr"));
    // 新增系列
    var series = chart.getChartData().getSeries().add(fact.getCell(0, 0, 1, "Series 1"), chart.getType());
    // 立即填入系列資料
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));
    series.getParentSeriesGroup().setColorVaried(true);
    pres.save("Pie.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **常見問題**

**是否支援「Pie of Pie」和「Bar of Pie」變體？**

是的，該函式庫[支援](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/charttype/) 圓餅圖的次要圖表，包括「Pie of Pie」與「Bar of Pie」類型。

**我可以只將圖表匯出為影像（例如 PNG）嗎？**

是的，您可以[將圖表本身匯出為影像](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/shape/#getImage)（例如 PNG），而無需匯出整個簡報。