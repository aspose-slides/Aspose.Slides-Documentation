---
title: 在 .NET 中管理簡報的圖表資料標記
linktitle: 資料標記
type: docs
url: /zh-hant/net/chart-data-marker/
keywords:
- 圖表
- 資料點
- 標記
- 標記選項
- 標記大小
- 填充類型
- PowerPoint
- 簡報
- .NET
- C#
- Aspose.Slides
description: "了解如何在 Aspose.Slides for .NET 中自訂圖表資料標記，透過清晰的 C# 程式碼範例提升 PPT 與 PPTX 簡報的效果。"
---
## **概覽**

本文說明如何在 Aspose.Slides 中使用圖表資料標記。它展示了如何建立圖表、存取系列及其資料點、在資料點層級為標記套用圖片填充、調整標記大小，並儲存更新後的簡報。它亦指出可透過 `MarkerStyleType` 列舉取得標準標記形狀，且在將圖表匯出為點陣圖格式或 SVG 時，標記外觀會被保留。

## **設定圖表標記選項**
標記可以在特定系列的圖表資料點上設定。若要設定圖表標記選項，請遵循以下步驟：

- 實例化 [Presentation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation) 類別。
- 建立預設圖表。
- 設定圖片。
- 取得第一個圖表系列。
- 新增資料點。
- 將簡報寫入磁碟。

在以下範例中，我們已在資料點層級設定圖表標記選項。

```c#
// 建立 Presentation 類別的實例
using Presentation presentation = new Presentation();

ISlide slide = presentation.Slides[0];

// 建立預設圖表
IChart chart = slide.Shapes.AddChart(ChartType.LineWithMarkers, 0, 0, 400, 400);

// 取得預設圖表資料工作表索引
int defaultWorksheetIndex = 0;

// 取得圖表資料工作表
IChartDataWorkbook fact = chart.ChartData.ChartDataWorkbook;

// 刪除示範系列
chart.ChartData.Series.Clear();

// 新增系列
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 1, 1, "Series 1"), chart.Type);

// 設定圖片
using IImage image1 = Images.FromFile("aspose-logo.jpg");
IPPImage imgx1 = presentation.Images.AddImage(image1);

// 設定圖片
using IImage image2 = Images.FromFile("Tulips.jpg");
IPPImage imgx2 = presentation.Images.AddImage(image2);

// 取得第一個圖表系列
IChartSeries series = chart.ChartData.Series[0];

// 在此新增資料點 (1:3)。
IChartDataPoint point = series.DataPoints.AddDataPointForLineSeries(fact.GetCell(defaultWorksheetIndex, 1, 1, (double)4.5));
point.Marker.Format.Fill.FillType = FillType.Picture;
point.Marker.Format.Fill.PictureFillFormat.Picture.Image = imgx1;

point = series.DataPoints.AddDataPointForLineSeries(fact.GetCell(defaultWorksheetIndex, 2, 1, (double)2.5));
point.Marker.Format.Fill.FillType = FillType.Picture;
point.Marker.Format.Fill.PictureFillFormat.Picture.Image = imgx2;

point = series.DataPoints.AddDataPointForLineSeries(fact.GetCell(defaultWorksheetIndex, 3, 1, (double)3.5));
point.Marker.Format.Fill.FillType = FillType.Picture;
point.Marker.Format.Fill.PictureFillFormat.Picture.Image = imgx1;

point = series.DataPoints.AddDataPointForLineSeries(fact.GetCell(defaultWorksheetIndex, 4, 1, (double)4.5));
point.Marker.Format.Fill.FillType = FillType.Picture;
point.Marker.Format.Fill.PictureFillFormat.Picture.Image = imgx2;

// 變更圖表系列的標記
series.Marker.Size = 15;

// 將簡報寫入磁碟
presentation.Save("MarkOptions_out.pptx", SaveFormat.Pptx);
```

## **常見問題**

**哪些標記形狀是預設可用的？**

提供標準形狀（圓形、方形、菱形、三角形等）；清單由 [MarkerStyleType](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.charts/markerstyletype/) 列舉定義。如果需要非標準形狀，請使用帶圖片填充的標記來模擬自訂視覺效果。

**在將圖表匯出為影像或 SVG 時，標記會被保留嗎？**

會的。將圖表渲染為 [點陣圖格式](/slides/zh-hant/net/convert-powerpoint-to-png/) 或儲存 [SVG 形狀](/slides/zh-hant/net/render-a-slide-as-an-svg-image/) 時，標記會保留其外觀和設定，包括大小、填充和輪廓。