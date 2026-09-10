---
title: 在 Python 中自訂簡報圖表的繪圖區
linktitle: 繪圖區
type: docs
url: /zh-hant/python-java/chart-plot-area/
keywords:
- 圖表
- 繪圖區
- 繪圖區寬度
- 繪圖區高度
- 繪圖區大小
- 版面配置模式
- PowerPoint
- 簡報
- Python
- Java
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for Python via Java 於 PowerPoint 簡報中自訂圖表的繪圖區，輕鬆提升投影片視覺效果。"
---
## **概述**

本文說明如何在 Aspose.Slides 中操作圖表的繪圖區。它說明如何透過驗證圖表版面配置，然後讀取 X、Y、寬度與高度值，以取得繪圖區的實際位置與大小。

此外，還示範如何在手動設定版面配置時，使用 [LayoutTargetType](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/layouttargettype/) 來定義繪圖區是以內部區域還是包括軸線與軸標籤的外部區域來計算。

## **取得圖表繪圖區的寬度與高度**

Aspose.Slides for Python via Java 提供簡單的 API 用於讀取圖表繪圖區的實際位置與大小。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/) 類別的實例。
1. 取得第一張投影片。
1. 新增一個含預設資料的圖表。
1. 在取得實際值之前，呼叫 [Chart.validateChartLayout](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/chart/#validateChartLayout) 方法。
1. 取得圖表元件相對於圖表左上角的實際 X 位置（左側）。
1. 取得圖表元件相對於圖表左上角的實際 Y 位置（上側）。
1. 取得圖表元件的實際寬度。
1. 取得圖表元件的實際高度。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation

# 建立 Presentation 類別的實例。
presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 500, 350)
    chart.validateChartLayout()

    plot_area = chart.getPlotArea()
    x = plot_area.getActualX()
    y = plot_area.getActualY()
    width = plot_area.getActualWidth()
    height = plot_area.getActualHeight()
finally:
    presentation.dispose()
```

## **設定圖表繪圖區的版面配置模式**

Aspose.Slides for Python via Java 提供簡單的 API 以設定圖表繪圖區的版面配置模式。[setLayoutTargetType](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/chartplotarea/#setLayoutTargetType) 與 [getLayoutTargetType](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/chartplotarea/#getLayoutTargetType) 方法可在 [ChartPlotArea](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/chartplotarea/) 類別中使用。若繪圖區的版面配置為手動定義，此設定會指定是以內部（不含軸線與軸標籤）或外部（含軸線與軸標籤）方式布局。此列舉在 [LayoutTargetType](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/layouttargettype/) 中定義了兩個可能的值。

- [Inner](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/layouttargettype/#Inner) 指定繪圖區大小不包含刻度線與軸標籤。
- [Outer](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/layouttargettype/#Outer) 指定繪圖區大小包含刻度線與軸標籤。

以下提供範例程式碼。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, LayoutTargetType, Presentation, SaveFormat

# 建立 Presentation 類別的實例。
presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 100, 600, 400)
    plot_area = chart.getPlotArea()
    plot_area.setX(0.2)
    plot_area.setY(0.2)
    plot_area.setWidth(0.7)
    plot_area.setHeight(0.7)
    plot_area.setLayoutTargetType(LayoutTargetType.Inner)

    presentation.save("SetLayoutMode_inner.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **常見問題**

**實際 X、實際 Y、實際寬度和實際高度以什麼單位回傳？**

以點 (point) 為單位；1 英吋 = 72 點。這是 Aspose.Slides 的座標單位。

**繪圖區在內容上與圖表區有何不同？**

繪圖區是資料繪製區域（系列、格線、趨勢線等）；圖表區則包括周圍的元素（標題、圖例等）。在 3D 圖表中，繪圖區亦包含牆面/底面與坐標軸。

**當版面配置為手動時，繪圖區的 X、Y、寬度和高度如何解釋？**

它們是相對於圖表整體大小的比例 (0–1)；在此模式下會停用自動定位，使用者設定的比例會直接套用。

**為何在新增或移動圖例後繪圖區位置會改變？**

圖例位於圖表區的繪圖區之外，但會影響版面配置與可用空間，因此在自動定位啟用時，繪圖區可能會隨之移動。（這是 PowerPoint 圖表的標準行為。）