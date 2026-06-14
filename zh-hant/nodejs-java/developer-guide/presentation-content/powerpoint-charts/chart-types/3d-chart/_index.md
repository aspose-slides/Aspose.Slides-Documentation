---
title: 使用 JavaScript 在簡報中自訂 3D 圖表
linktitle: 3D 圖表
type: docs
url: /zh-hant/nodejs-java/3d-chart/
keywords:
- 3D 圖表
- 旋轉
- 深度
- PowerPoint
- 簡報
- Node.js
- JavaScript
- Aspose.Slides
description: "了解如何在 Aspose.Slides for Node.js via Java 中建立與自訂 3-D 圖表，支援 PPT 與 PPTX 檔案 — 立即提升您的簡報效果。"
---
## **概述**

本文說明如何透過設定 `Rotation3D`（例如 `RotationX`、`RotationY`、`DepthPercents` 與 `RightAngleAxes`）自訂 Aspose.Slides 中的 3D 圖表。內容涵蓋建立簡報、加入預設資料的 3D 圖表、套用必要的 3D 觀景設定，並將修改後的簡報儲存為 PPTX 檔案的步驟。

## **設定 3D 圖表的 RotationX、RotationY 與 DepthPercents 屬性**

Aspose.Slides for Node.js via Java 提供簡易的 API 以設定這些屬性。以下說明將協助您設定 **X、Y 旋轉、DepthPercents** 等不同屬性。示例程式碼會套用上述屬性。

1. 建立 [簡報](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation/) 類別的執行個體。
1. 取得第一張投影片。
1. 新增帶有預設資料的圖表。
1. 設定 Rotation3D 屬性。
1. 將修改後的簡報寫入 PPTX 檔案。

```javascript
var pres = new aspose.slides.Presentation();
try {
    // 存取第一張投影片
    var slide = pres.getSlides().get_Item(0);
    // 新增帶有預設資料的圖表
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.StackedColumn3D, 0, 0, 500, 500);
    // 設定圖表資料工作表的索引
    var defaultWorksheetIndex = 0;
    // 取得圖表資料工作表
    var fact = chart.getChartData().getChartDataWorkbook();
    // 新增系列
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.getType());
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 2, "Series 2"), chart.getType());
    // 新增類別
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 3, 0, "Caetegoty 3"));
    // 設定 Rotation3D 屬性
    chart.getRotation3D().setRightAngleAxes(true);
    chart.getRotation3D().setRotationX(40);
    chart.getRotation3D().setRotationY(270);
    chart.getRotation3D().setDepthPercents(150);
    // 取得第二個圖表系列
    var series = chart.getChartData().getSeries().get_Item(1);
    // 現在填入系列資料
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 2, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 2, 10));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 2, 60));
    // 設定 OverLap 值
    series.getParentSeriesGroup().setOverlap(100);
    // 將簡報寫入磁碟
    pres.save("Rotation3D_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **常見問答**

**哪類圖表在 Aspose.Slides 中支援 3D 模式？**

Aspose.Slides 支援多種 3D 柱狀圖，包括 Column 3D、Clustered Column 3D、Stacked Column 3D 以及 100% Stacked Column 3D，並可透過 [圖表類型](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/charttype/) 列舉中曝露的相關 3D 類型取得。欲取得最新、完整的清單，請參閱您所安裝版本的 API 參考文件中的 [圖表類型](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/charttype/) 成員。

**我可以取得 3D 圖表的點陣圖以用於報告或網頁嗎？**

可以。您可以透過 [圖表 API](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/shape/#getImage) 匯出圖表為影像，或將整張投影片 [渲染整張投影片](/slides/zh-hant/nodejs-java/convert-powerpoint-to-png/) 成 PNG、JPEG 等格式。這在需要像素級預覽或將圖表嵌入文件、儀表板或網頁，且不需 PowerPoint 時特別有用。

**建置與渲染大型 3D 圖表的效能如何？**

效能會受到資料量與視覺複雜度的影響。為獲得最佳效果，建議盡量減少 3D 效果、避免在牆面與繪圖區使用大量紋理、在可能的情況下限制每個系列的資料點數量，並將輸出解析度與尺寸設定為符合目標顯示或列印需求的大小。