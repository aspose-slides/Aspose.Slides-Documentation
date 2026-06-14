---
title: 在 .NET 中匯出簡報圖表
linktitle: 匯出圖表
type: docs
weight: 90
url: /zh-hant/net/export-chart/
keywords:
- 圖表
- 圖表轉影像
- 圖表作為影像
- 擷取圖表影像
- PowerPoint
- 簡報
- .NET
- C#
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for .NET 匯出簡報圖表，支援 PPT 與 PPTX 格式，並將報告流程簡化至任何工作流程。"
---
## **概覽**

Aspose.Slides 允許您將簡報中的圖表匯出為影像。本文說明如何從圖表取得影像並儲存，當您需要在 PowerPoint 簡報之外重新使用圖表視覺時，非常實用。

除了基本的影像匯出工作流程外，本文還解答常見的匯出相關問題，包括將圖表內容儲存為 SVG、透過渲染選項控制輸出尺寸、載入字型以保留標籤與圖例的外觀，以及在渲染過程中保持原始簡報的格式（例如佈景主題、樣式、填色與效果）。

## **取得圖表影像**
Aspose.Slides for .NET 提供擷取特定圖表影像的支援。以下範例說明。

```c#
using (Presentation presentation = new Presentation("test.pptx"))
{
    ISlide slide = presentation.Slides[0];
    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400);

    using (IImage image = chart.GetImage())
    {
        image.Save("image.png", ImageFormat.Png);
    }
}
```

## **常見問題**

**我可以將圖表匯出為向量 (SVG) 而不是點陣圖嗎？**

可以。圖表是一種形狀，其內容可使用 [shape-to-SVG saving method](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/shape/writeassvg/) 儲存為 SVG。

**如何在像素層面設定匯出圖表的精確大小？**

使用允許指定尺寸或比例的影像渲染重載；函式庫支援以給定的尺寸/比例渲染物件。

**匯出後標籤與圖例的字型顯示不正確，我該怎麼辦？**

[Load the required fonts](/slides/zh-hant/net/custom-font/) 透過 [FontsLoader](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/fontsloader/) 以確保圖表渲染保留字型度量與文字外觀。

**匯出是否會遵循 PowerPoint 的佈景主題、樣式與效果？**

會。Aspose.Slides 的渲染程式會遵循簡報的格式（佈景主題、樣式、填色、效果），因此圖表外觀得以保留。

**我可以在哪裡找到圖表影像以外的其他渲染/匯出功能？**

請參閱 [API](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export/)/[documentation](/slides/zh-hant/net/convert-powerpoint/) 的匯出章節，了解可輸出的目標（[PDF](/slides/zh-hant/net/convert-powerpoint-to-pdf/)、[SVG](/slides/zh-hant/net/render-a-slide-as-an-svg-image/)、[XPS](/slides/zh-hant/net/convert-powerpoint-to-xps/)、[HTML](/slides/zh-hant/net/convert-powerpoint-to-html/)、等）以及相關的渲染選項。