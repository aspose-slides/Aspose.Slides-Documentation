---
title: 使用 Python 匯出簡報圖表
linktitle: 匯出圖表
type: docs
weight: 90
url: /zh-hant/python-net/export-chart/
keywords:
- 圖表
- 圖表轉影像
- 圖表作為影像
- 提取圖表影像
- PowerPoint
- OpenDocument
- 簡報
- Python
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for Python via .NET 匯出簡報圖表，支援 PPT、PPTX 與 ODP 格式，並將報告流程簡化至任何工作流程中。"
---
## **概觀**

Aspose.Slides 允許您將投影片中的圖表匯出為影像。本文示範如何從圖表取得影像並將其儲存，當您需要在 PowerPoint 簡報之外重複使用圖表視覺時非常有用。

## **取得圖表影像**
Aspose.Slides for Python via .NET 提供了提取特定圖表影像的支援。以下提供範例。 

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation("test.pptx") as presentation:
	slide = presentation.slides[0]
	chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)
	
	with chart.get_image() as image:
		image.save("image.png", slides.ImageFormat.PNG)
```

## **常見問題**

**我可以將圖表匯出為向量 (SVG) 而不是點陣圖嗎？**

是。圖表是一個形狀，其內容可以使用 [shape-to-SVG saving method](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.charts/chart/write_as_svg/) 儲存為 SVG。

**如何以像素設定匯出圖表的精確大小？**

使用允許您指定尺寸或比例的影像渲染重載；此函式庫支援以指定的尺寸/比例渲染物件。

**如果匯出後標籤和圖例的字型顯示不正確，我該怎麼辦？**

[Load the required fonts](/slides/zh-hant/python-net/custom-font/) 透過 [FontsLoader](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/fontsloader/) 載入所需字型，以確保圖表渲染保留度量和文字外觀。

**匯出是否遵守 PowerPoint 主題、樣式和效果？**

是。Aspose.Slides 的渲染器遵循簡報的格式設定（主題、樣式、填色、效果），因此圖表的外觀會被保留。

**我在哪裡可以找到圖表影像之外的可用渲染/匯出功能？**

請參閱 [API](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.export/)/[documentation](/slides/zh-hant/python-net/convert-powerpoint/) 的匯出章節，以了解輸出目標（[PDF](/slides/zh-hant/python-net/convert-powerpoint-to-pdf/)、[SVG](/slides/zh-hant/python-net/render-a-slide-as-an-svg-image/)、[XPS](/slides/zh-hant/python-net/convert-powerpoint-to-xps/)、[HTML](/slides/zh-hant/python-net/convert-powerpoint-to-html/)、等）以及相關的渲染選項。