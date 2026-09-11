---
title: 使用 Python via Java 匯出簡報圖表
linktitle: 匯出圖表
type: docs
weight: 90
url: /zh-hant/python-java/export-chart/
keywords:
- 圖表
- 圖表轉圖像
- 圖表作為圖像
- 提取圖表圖像
- PowerPoint
- 簡報
- Python
- Java
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for Python via Java 匯出簡報圖表，支援 PPT 與 PPTX 格式，並將報告流程簡化至任何工作流程中。"
---
## **概覽**

Aspose.Slides 允許您將簡報中的圖表匯出為圖像。本文說明如何從圖表取得圖像並儲存，這在需要在 PowerPoint 簡報之外重複使用圖表視覺效果時非常有用。

除了基本的圖像匯出工作流程外，本文還針對常見的匯出相關問題提供解答，包括將圖表內容儲存為 SVG、透過渲染選項控制輸出大小、載入字型以保留標籤與圖例外觀，以及在渲染過程中保持原始簡報的格式（如佈景主題、樣式、填色與效果）。

## **取得圖表圖像**
Aspose.Slides for Python via Java 支援擷取特定圖表的圖像。以下範例示範如何執行此操作。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, ImageFormat, Presentation

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400)

    chart_image = chart.getImage()
    try:
        chart_image.save("image.jpg", ImageFormat.Jpeg)
    finally:
        chart_image.dispose()
finally:
    presentation.dispose()
```

## **常見問題集**

**我可以將圖表匯出為向量圖（SVG）而非點陣圖嗎？**

是的。圖表是一個形狀，其內容可以使用[shape-to-SVG 儲存方法](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/shape/#writeAsSvgToBytes)儲存為 SVG。

**如何以像素設定匯出圖表的確切大小？**

使用允許您指定尺寸或比例的影像渲染重載——函式庫支援以給定的尺寸/比例渲染物件。

**匯出後標籤與圖例的字型顯示不正確，我該怎麼做？**

[載入所需的字型](/slides/zh-hant/python-java/custom-font/)，透過[FontsLoader](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/fontsloader/)以確保圖表渲染時保留字型度量與文字外觀。

**匯出時是否遵循 PowerPoint 的佈景主題、樣式與效果？**

是的。Aspose.Slides 的渲染器遵循簡報的格式（佈景主題、樣式、填色、效果），因此圖表的外觀得以保留。

**我可以在哪裡找到圖表圖像以外的渲染/匯出功能？**

請參閱[API](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/)/[說明文件](/slides/zh-hant/python-java/convert-powerpoint/)以取得輸出目標（[PDF](/slides/zh-hant/python-java/convert-powerpoint-to-pdf/)、[SVG](/slides/zh-hant/python-java/render-a-slide-as-an-svg-image/)、[XPS](/slides/zh-hant/python-java/convert-powerpoint-to-xps/)、[HTML](/slides/zh-hant/python-java/convert-powerpoint-to-html/) 等）以及相關的渲染選項。