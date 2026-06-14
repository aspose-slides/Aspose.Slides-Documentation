---
title: 圖表
type: docs
weight: 60
url: /zh-hant/python-net/examples/elements/chart/
keywords:
- 圖表
- 新增圖表
- 存取圖表
- 移除圖表
- 更新圖表
- 程式碼範例
- PowerPoint
- OpenDocument
- 簡報
- Python
- Aspose.Slides
description: "在 Python 中使用 Aspose.Slides 建立與自訂圖表：新增資料、設定系列、座標軸與標籤、變更類型，並匯出—支援 PPT、PPTX 與 ODP。"
---
示範如何新增、存取、移除以及更新不同類型的圖表，使用 **Aspose.Slides for Python via .NET**。以下程式碼片段展示基本的圖表操作。

## **新增圖表**

此方法會在第一張投影片上新增一個簡單的區域圖表。

```py
def add_chart():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # 在第一張投影片上新增一個簡單的柱狀圖。
        chart = slide.shapes.add_chart(slides.charts.ChartType.AREA, 50, 50, 400, 300)

        presentation.save("chart.pptx", slides.export.SaveFormat.PPTX)
```

## **存取圖表**

以下程式碼從圖形集合中取得圖表。

```py
def access_chart():
    with slides.Presentation("chart.pptx") as presentation:
        slide = presentation.slides[0]

        # 取得投影片上第一個圖表。
        first_chart = None
        for shape in slide.shapes:
            if isinstance(shape, slides.charts.Chart):
                first_chart = shape
                break
```

## **移除圖表**

以下程式碼從投影片中移除圖表。

```py
def remove_chart():
    with slides.Presentation("chart.pptx") as presentation:
        slide = presentation.slides[0]

        # 假設第一個圖形是圖表。
        chart = slide.shapes[0]

        # 移除圖表。
        slide.shapes.remove(chart)

        presentation.save("chart_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **更新圖表資料**

您可以變更圖表屬性，例如標題。

```py
def update_chart_data():
    with slides.Presentation("chart.pptx") as presentation:
        slide = presentation.slides[0]

        # 假設第一個圖形是圖表。
        chart = slide.shapes[0]

        # 變更圖表標題。
        chart.chart_title.add_text_frame_for_overriding("Sales Report")

        presentation.save("chart_updated.pptx", slides.export.SaveFormat.PPTX)
```