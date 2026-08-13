---
title: Aspose.Slides for .NET 15.7.0 的公開 API 與向後不相容變更
linktitle: Aspose.Slides for .NET 15.7.0
type: docs
weight: 180
url: /zh-hant/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-7-0/
keywords:
- 遷移
- 舊版程式碼
- 現代程式碼
- 舊版方法
- 現代方法
- PowerPoint
- OpenDocument
- 簡報
- .NET
- C#
- Aspose.Slides
description: "檢視 Aspose.Slides for .NET 的公開 API 更新與重大變更，以順利遷移您的 PowerPoint PPT、PPTX 與 ODP 簡報解決方案。"
---
{{% alert color="info" %}} 
此頁面列出所有 [added](/slides/zh-hant/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-7-0/) 或 [removed](/slides/zh-hant/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-7-0/) 類別、方法、屬性等，及在 Aspose.Slides for .NET 15.7.0 API 中引入的其他變更。
{{% /alert %}} 
## **公開 API 變更**
#### **已新增列舉 ImagePixelFormat**
已新增列舉 Aspose.Slides.Export.ImagePixelFormat，用於指定產生圖像的像素格式。
#### **已新增 IChartDataPoint.GetAutomaticDataPointColor() 方法**
根據系列索引、資料點索引、ParentSeriesGroup、IsColorVaried 屬性以及圖表樣式，傳回資料點的自動顏色。
如果 FillType 為 NotDefined，預設會使用此顏色。
#### **已在 Slide 中新增 RenderToGraphics 方法**
已在 Aspose.Slides.Slide 中新增 Method RenderToGraphics（以及其重載），用於將投影片渲染至 Graphics 物件。
#### **已在 ITiffOptions 和 TiffOptions 中新增 PixelFormat 屬性**
已在 Aspose.Slides.Export.ITiffOptions 和 Aspose.Slides.Export.TiffOptions 中新增屬性 PixelFormat，用於指定產生 TIFF 影像的像素格式。