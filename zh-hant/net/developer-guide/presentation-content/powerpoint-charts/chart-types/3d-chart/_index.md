---
title: 在 .NET 中自訂簡報的 3D 圖表
linktitle: 3D 圖表
type: docs
url: /zh-hant/net/3d-chart/
keywords:
- 3D 圖表
- 旋轉
- 深度
- PowerPoint
- 簡報
- .NET
- C#
- Aspose.Slides
description: "了解如何在 Aspose.Slides for .NET 中建立與自訂 3-D 圖表，支援 PPT 與 PPTX 檔案——立即提升您的簡報效果。"
---
## **概述**

本文說明如何透過設定 `Rotation3D`（例如 `RotationX`、`RotationY`、`DepthPercents` 與 `RightAngleAxes`）來自訂 Aspose.Slides 中的 3D 圖表。它示範了建立簡報、加入預設資料的 3D 圖表、套用所需的 3D 檢視設定，並將修改後的簡報儲存為 PPTX 檔案的步驟。

## **設定 3D 圖表的 RotationX、RotationY 與 DepthPercents 屬性**

Aspose.Slides for .NET 提供簡易的 API 以設定這些屬性。以下範例說明如何設定 X、Y 旋轉、**DepthPercents** 等不同屬性。範例程式碼示範了設定上述屬性。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation) 類別的實例。
1. 取得第一張投影片。
1. 加入帶有預設資料的圖表。
1. 設定 Rotation3D 屬性。
1. 將修改後的簡報寫入 PPTX 檔案。

```c#
// 建立 Presentation 類別的實例
Presentation presentation = new Presentation();
           
// 取得第一張投影片
ISlide slide = presentation.Slides[0];
 
// 加入預設資料的圖表
IChart chart = slide.Shapes.AddChart(ChartType.StackedColumn3D, 0, 0, 500, 500);
 
// 設定圖表資料工作表的索引
int defaultWorksheetIndex = 0;
 
// 取得圖表資料工作表
IChartDataWorkbook fact = chart.ChartData.ChartDataWorkbook;
 
// 新增系列
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.Type);
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 0, 2, "Series 2"), chart.Type);
 
// 新增類別
chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 3, 0, "Caetegoty 3"));
 
// 設定 Rotation3D 屬性
chart.Rotation3D.RightAngleAxes = true;
chart.Rotation3D.RotationX = 40;
chart.Rotation3D.RotationY = 270;
chart.Rotation3D.DepthPercents = 150;
 
// 取得第二個圖表系列
IChartSeries series = chart.ChartData.Series[1];
 
// 現在填入系列資料
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 1, 1, 20));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 2, 1, 50));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 3, 1, 30));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 1, 2, 30));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 2, 2, 10));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 3, 2, 60));
 
// 設定 OverLap 值
series.ParentSeriesGroup.Overlap = 100;         
 
// 將簡報寫入磁碟
presentation.Save("Rotation3D_out.pptx", SaveFormat.Pptx);
```

## **常見問題**

**哪些圖表類型在 Aspose.Slides 中支援 3D 模式？**

Aspose.Slides 支援 3D 變體的柱狀圖，包括 Column 3D、Clustered Column 3D、Stacked Column 3D 與 100% Stacked Column 3D，此外還有透過 [ChartType](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.charts/charttype/) 列舉的相關 3D 類型。欲取得完整且最新的清單，請檢視您所安裝版本的 API 參考中的 [ChartType](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.charts/charttype/) 成員。

**我可以取得 3D 圖表的點陣圖用於報告或網路嗎？**

可以。您可以透過 [chart API](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/shape/getimage/) 將圖表匯出為影像，或將整張投影片[轉換為 PNG](/slides/zh-hant/net/convert-powerpoint-to-png/) 等格式（如 PNG 或 JPEG）。當您需要像素完美的預覽，或想在文件、儀表板或網頁中嵌入圖表而不需 PowerPoint 時，這相當有用。

**建構與呈現大型 3D 圖表的效能如何？**

效能取決於資料量與視覺複雜度。為取得最佳結果，請盡量減少 3D 效果，避免在牆壁與圖表區域使用大型紋理，盡可能限制每個系列的資料點數量，並將輸出解析度與尺寸調整至符合目標顯示或列印需求的大小。