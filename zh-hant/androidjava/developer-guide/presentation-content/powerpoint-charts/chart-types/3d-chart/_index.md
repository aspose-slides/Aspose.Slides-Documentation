---
title: 在 Android 上自訂簡報的 3D 圖表
linktitle: 3D 圖表
type: docs
url: /zh-hant/androidjava/3d-chart/
keywords:
- 3D 圖表
- 旋轉
- 深度
- PowerPoint
- 簡報
- Android
- Java
- Aspose.Slides
description: "了解如何在 Aspose.Slides for Android via Java 中建立與自訂 3D 圖表，支援 PPT 與 PPTX 檔案——立即提升您的簡報效果。"
---
## **概觀**

本篇文章說明如何透過設定 `Rotation3D` 的 `RotationX`、`RotationY`、`DepthPercents` 以及 `RightAngleAxes`，自訂 Aspose.Slides 中的 3D 圖表。內容包括建立簡報、加入帶預設資料的 3D 圖表、套用必要的 3D 檢視設定，並將修改後的簡報儲存為 PPTX 檔案。

## **設定 3D 圖表的 RotationX、RotationY 與 DepthPercents 屬性**

Aspose.Slides for Android via Java 提供簡易的 API 以設定這些屬性。以下文章將說明如何設定各種屬性，例如 **X、Y 旋轉、DepthPercents** 等。範例程式碼示範了上述屬性的設定方式。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/presentation/) 類別的實例。
2. 存取第一張投影片。
3. 加入帶預設資料的圖表。
4. 設定 Rotation3D 屬性。
5. 將修改後的簡報寫入 PPTX 檔案。

```java
Presentation pres = new Presentation();
try {
    // 存取第一張投影片
    ISlide slide = pres.getSlides().get_Item(0);
    
    // 新增帶預設資料的圖表
    IChart chart = slide.getShapes().addChart(ChartType.StackedColumn3D, 0, 0, 500, 500);
    
    // 設定圖表資料工作表的索引
    int defaultWorksheetIndex = 0;
    
    // 取得圖表資料工作表
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();
    
    // 新增系列
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.getType());
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 2, "Series 2"), chart.getType());
    
    // 新增類別
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 3, 0, "Caetegoty 3"));
    
    // 設定 Rotation3D 屬性
    chart.getRotation3D().setRightAngleAxes(true);
    chart.getRotation3D().setRotationX((byte)40);
    chart.getRotation3D().setRotationY(270);
    chart.getRotation3D().setDepthPercents(150);
    
    // 取得第二個圖表系列
    IChartSeries series = chart.getChartData().getSeries().get_Item(1);
    
    // 現在填入系列資料
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 2, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 2, 10));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 2, 60));
    
    // 設定 OverLap 值
    series.getParentSeriesGroup().setOverlap((byte)100);
    
    // 將簡報寫入磁碟
    pres.save("Rotation3D_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **常見問題**

**哪些圖表類型在 Aspose.Slides 中支援 3D 模式？**

Aspose.Slides 支援柱狀圖的 3D 變體，包括 Column 3D、Clustered Column 3D、Stacked Column 3D 以及 100% Stacked Column 3D，並且還有透過 [ChartType](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/charttype/) 類別所公開的相關 3D 類型。欲取得最新完整清單，請檢查您安裝版本的 API 參考中的 [ChartType](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/charttype/) 成員。

**我可以取得 3D 圖表的點陣圖以供報告或網站使用嗎？**

可以。您可以透過 [圖表 API](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/shape/#getImage-int-float-float-) 將圖表匯出為影像，或是將整張投影片 [將整張投影片渲染為圖像](/slides/zh-hant/androidjava/convert-powerpoint-to-png/) 為 PNG 或 JPEG 等格式。這在需要像素完美的預覽或將圖表嵌入文件、儀表板或網頁而不需 PowerPoint 時非常有用。

**大型 3D 圖表的建構與渲染效能如何？**

效能取決於資料量與視覺複雜度。為取得最佳結果，請盡量減少 3D 效果、避免在牆面與繪圖區使用大量紋理、在可能的情況下限制每個系列的資料點數量，並將輸出渲染為符合目標顯示或列印需求的適當尺寸（解析度與尺寸）。