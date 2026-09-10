---
title: 使用 Python 在簡報中自訂氣泡圖
linktitle: 氣泡圖
type: docs
url: /zh-hant/python-java/bubble-chart/
keywords:
- 氣泡圖
- 氣泡大小
- 大小縮放
- 大小表示
- PowerPoint
- 簡報
- Python
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Python via Java 在 PowerPoint 中輕鬆建立並自訂功能強大的氣泡圖，以提升您的資料視覺化效果。"
---
## **概觀**

本文說明如何在 Aspose.Slides 中使用氣泡圖，並涵蓋兩項特定的自訂選項：透過 [setBubbleSizeScale](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/chartseriesgroup/#setBubbleSizeScale) 方法對氣泡大小進行縮放，以及透過 [setBubbleSizeRepresentation](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/chartseriesgroup/#setBubbleSizeRepresentation) 方法控制氣泡大小值的表示方式。示例演示了如何建立氣泡圖、調整其大小縮放，並將氣泡大小的表示方式切換為使用寬度。本文還包含簡短的 FAQ 區段，說明對「Bubble with 3-D」圖表類型的支援，指出實際圖表的限制取決於效能與目標 PowerPoint 版本，並解釋匯出會透過 Aspose.Slides 渲染引擎保留圖表外觀。

## **氣泡圖大小縮放**
Aspose.Slides for Python via Java 透過 [ChartSeries.getBubbleSizeScale](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/chartseries/#getBubbleSizeScale)、[ChartSeriesGroup.getBubbleSizeScale](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/chartseriesgroup/#getBubbleSizeScale) 與 [ChartSeriesGroup.setBubbleSizeScale](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/chartseriesgroup/#setBubbleSizeScale) 方法支援氣泡圖大小縮放。下列示例說明如何縮放氣泡大小。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Bubble, 100, 100, 400, 300)

    chart.getChartData().getSeriesGroups().get_Item(0).setBubbleSizeScale(150)

    presentation.save("Result.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **以氣泡圖大小表示資料**
[ChartSeriesGroup](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/chartseriesgroup/) 類別提供 [setBubbleSizeRepresentation](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/chartseriesgroup/#setBubbleSizeRepresentation) 與 [getBubbleSizeRepresentation](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/chartseriesgroup/#getBubbleSizeRepresentation) 方法。氣泡大小的表示方式指定氣泡圖中氣泡大小值如何呈現。可能的值有 [BubbleSizeRepresentationType.Area](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/bubblesizerepresentationtype/#Area) 與 [BubbleSizeRepresentationType.Width](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/bubblesizerepresentationtype/#Width)。[BubbleSizeRepresentationType](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/bubblesizerepresentationtype/) 列舉定義了以氣泡圖大小表示資料的可能方式。以下示例說明如何使用寬度來表示氣泡大小。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BubbleSizeRepresentationType, ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Bubble, 50, 50, 600, 400, True)

    chart.getChartData().getSeriesGroups().get_Item(0).setBubbleSizeRepresentation(BubbleSizeRepresentationType.Width)

    presentation.save("Presentation_BubbleSizeRepresentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **常見問題**

**是否支援「具有 3-D 效果的氣泡圖」，且它與一般氣泡圖有何不同？**

是的。此圖表類型稱為「Bubble with 3-D」。它會為氣泡套用 3-D 樣式，但不會額外增加軸線；資料仍然是 X‑Y‑S（大小）。此類型可在 [chart type](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/charttype/) 類別中取得。

**氣泡圖的系列與資料點數量是否有限制？**

在 API 層面沒有硬性限制；限制取決於效能與目標 PowerPoint 版本。建議將資料點數量維持在易於閱讀與渲染速度合理的範圍內。

**匯出（PDF、影像）會如何影響氣泡圖的外觀？**

匯出至支援的格式會保留圖表外觀，由 Aspose.Slides 引擎負責渲染。對於點陣或向量格式，遵循一般圖表渲染規則（解析度、抗鋸齒），因此請選擇足夠的 DPI 以符合列印需求。