---
title: 使用 Java 客製化簡報中的 3D 圖表
linktitle: 3D 圖表
type: docs
url: /zh-hant/java/3d-chart/
keywords:
- 3D 圖表
- 旋轉
- 深度
- PowerPoint
- 簡報
- Java
- Aspose.Slides
description: "了解如何在 Aspose.Slides for Java 中建立與自訂 3-D 圖表，支援 PPT 和 PPTX 檔案——立即提升您的簡報效果。"
---
## **概述**

本文說明如何透過設定 `Rotation3D` 的 `RotationX`、`RotationY`、`DepthPercents` 與 `RightAngleAxes` 來自訂 Aspose.Slides 中的 3D 圖表。本文將逐步示範建立簡報、加入預設資料的 3D 圖表、套用所需的 3D 觀點設定，並將修改後的簡報儲存為 PPTX 檔案。

## **設定 3D 圖表的 RotationX、RotationY 與 DepthPercents 屬性**

Aspose.Slides for Java 提供簡易的 API 來設定這些屬性。以下文章將說明如何設定不同的屬性，例如 **X、Y 旋轉、DepthPercents** 等。範例程式碼示範了上述屬性的設定方式。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation/) 類別的實例。
2. 存取第一張投影片。
3. 加入具有預設資料的圖表。
4. 設定 Rotation3D 屬性。
5. 將修改後的簡報寫入 PPTX 檔案。

```java
Presentation pres = new Presentation();
try {
    // 存取第一張投影片
    ISlide slide = pres.getSlides().get_Item(0);
    
    // 新增具有預設資料的圖表
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
    
    // 立即填入系列資料
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

## **FAQ**

**哪些圖表類型在 Aspose.Slides 中支援 3D 模式？**

Aspose.Slides 支援 3D 變體的柱狀圖，包括 Column 3D、Clustered Column 3D、Stacked Column 3D 與 100% Stacked Column 3D，並透過 [ChartType](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/charttype/) 類別提供相關的 3D 型別。欲取得完整且最新的列表，請檢查您所安裝版本的 API 參考文件中 [ChartType](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/charttype/) 成員。

**我可以取得 3D 圖表的點陣圖以用於報告或網站嗎？**

可以。您可透過 [chart API](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/shape/#getImage-int-float-float-) 或 [將整張投影片轉換](/slides/zh-hant/java/convert-powerpoint-to-png/) 成 PNG、JPEG 等格式，將圖表匯出為影像。當您需要像素準確的預覽，或想在不使用 PowerPoint 的情況下將圖表嵌入文件、儀表板或網頁時，此方式相當有用。

**大型 3D 圖表的建構與呈現效能如何？**

效能取決於資料量與視覺複雜度。為獲得最佳效果，請盡量減少 3D 效果、避免在牆面與繪圖區域使用大量紋理、在可能的情況下限制每個資料系列的資料點數量，並將輸出渲染為符合目標顯示或列印需求的適當尺寸（解析度與尺寸）。