---
title: 在 Android 上的簡報中自訂餅圖
linktitle: 餅圖
type: docs
url: /zh-hant/androidjava/pie-chart/
keywords:
- 餅圖
- 管理圖表
- 自訂圖表
- 圖表選項
- 圖表設定
- 繪圖選項
- 切片顏色
- PowerPoint
- 簡報
- Android
- Java
- Aspose.Slides
description: "了解如何在 Java 中使用 Aspose.Slides for Android 建立並自訂餅圖，可匯出至 PowerPoint，讓您在秒內提升資料敘事效果。"
---
## **概述**

本文說明如何在 Aspose.Slides 中使用圓形圖。它展示了如何為餅圖的餅圖與條狀圖的餅圖配置第二繪圖選項，以及如何為一般圓形圖啟用自動切片著色。

範例著重於實務圖表自訂步驟，例如將圖表加入投影片、調整系列與標籤設定、以自訂類別與數值取代預設圖表資料，並儲存更新後的簡報。

## **餅圖的餅圖與條狀圖的餅圖的第二繪圖選項**
Aspose.Slides for Android via Java 現在支援餅圖的餅圖或條狀圖的餅圖之第二繪圖選項。在本主題中，我們將示範如何使用 Aspose.Slides 指定這些選項。設定屬性時，請依照下列步驟進行：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/Presentation) 類別的實例。
1. 在投影片上新增圖表。
1. 指定圖表的第二繪圖選項。
1. 將簡報寫入磁碟。

以下範例設定了餅圖的餅圖的不同屬性。

```java
// 建立 Presentation 類別的實例
Presentation pres = new Presentation();
try {
    // 在投影片上新增圖表
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.PieOfPie, 50, 50, 500, 400);
    
    // 設定不同屬性
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setSecondPieSize(149);
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setPieSplitBy(PieSplitType.ByPercentage);
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setPieSplitPosition(53);
    
    // 將簡報寫入磁碟
    pres.save("SecondPlotOptionsforCharts_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **設定自動圓形圖切片顏色**
Aspose.Slides for Android via Java 提供簡易 API 以設定自動圓形圖切片顏色。以下範例程式碼說明如何套用上述屬性。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/Presentation) 類別的實例。
1. 取得第一張投影片。
1. 使用預設資料新增圖表。
1. 設定圖表標題。
1. 將第一個系列設定為顯示值。
1. 設定圖表資料工作表的索引。
1. 取得圖表資料工作表。
1. 刪除預設產生的系列與類別。
1. 新增類別。
1. 新增系列。

將修改後的簡報寫入 PPTX 檔案。

```java
// 建立 Presentation 類別的實例
Presentation pres = new Presentation();
try {
    // 使用預設資料新增圖表
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 100, 100, 400, 400);

    // 設定圖表標題
    chart.getChartTitle().addTextFrameForOverriding("Sample Title");
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(NullableBool.True);
    chart.getChartTitle().setHeight(20);
    chart.setTitle(true);

    // 設定第一個系列顯示值
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);

    // 設定圖表資料工作表的索引
    int defaultWorksheetIndex = 0;

    // 取得圖表資料工作表
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();

    // 刪除預設產生的系列與類別
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    // 新增類別
    chart.getChartData().getCategories().add(fact.getCell(0, 1, 0, "First Qtr"));
    chart.getChartData().getCategories().add(fact.getCell(0, 2, 0, "2nd Qtr"));
    chart.getChartData().getCategories().add(fact.getCell(0, 3, 0, "3rd Qtr"));

    // 新增系列
    IChartSeries series = chart.getChartData().getSeries().add(fact.getCell(0, 0, 1, "Series 1"), chart.getType());

    // 現在填入系列資料
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));

    series.getParentSeriesGroup().setColorVaried(true);
    pres.save("Pie.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **常見問題**

**是否支援「餅圖的餅圖」與「條狀圖的餅圖」變體？**

是的，程式庫[支援](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/charttype/) 圓形圖的第二繪圖，包括「餅圖的餅圖」與「條狀圖的餅圖」類型。

**我可以只將圖表匯出為圖像（例如 PNG）嗎？**

可以，您可以[將圖表本身匯出為圖像](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/shape/#getImage-int-float-float-)（例如 PNG），而不必匯出整個簡報。