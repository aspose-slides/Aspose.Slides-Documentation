---
title: 图表
type: docs
weight: 60
url: /zh/python-net/examples/elements/chart/
keywords:
- 图表
- 添加图表
- 访问图表
- 删除图表
- 更新图表
- 代码示例
- PowerPoint
- OpenDocument
- 演示文稿
- Python
- Aspose.Slides
description: "在 Python 中使用 Aspose.Slides 创建和自定义图表：添加数据、格式化系列、坐标轴和标签、切换图表类型并导出——支持 PPT、PPTX 和 ODP。"
---
示例演示如何添加、访问、删除和更新不同类型的图表，使用 **Aspose.Slides for Python via .NET**。以下代码片段演示基础图表操作。

## **添加图表**

此方法在第一张幻灯片上添加一个简单的面积图。

```py
def add_chart():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # 在第一页幻灯片上添加一个简单的柱形图。
        chart = slide.shapes.add_chart(slides.charts.ChartType.AREA, 50, 50, 400, 300)

        presentation.save("chart.pptx", slides.export.SaveFormat.PPTX)
```

## **访问图表**

以下代码从形状集合中检索图表。

```py
def access_chart():
    with slides.Presentation("chart.pptx") as presentation:
        slide = presentation.slides[0]

        # 访问幻灯片上的第一个图表。
        first_chart = None
        for shape in slide.shapes:
            if isinstance(shape, slides.charts.Chart):
                first_chart = shape
                break
```

## **删除图表**

以下代码从幻灯片中删除图表。

```py
def remove_chart():
    with slides.Presentation("chart.pptx") as presentation:
        slide = presentation.slides[0]

        # 假设第一个形状是图表。
        chart = slide.shapes[0]

        # 删除图表。
        slide.shapes.remove(chart)

        presentation.save("chart_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **更新图表数据**

您可以更改图表属性，例如标题。

```py
def update_chart_data():
    with slides.Presentation("chart.pptx") as presentation:
        slide = presentation.slides[0]

        # 假设第一个形状是图表。
        chart = slide.shapes[0]

        # 更改图表标题。
        chart.chart_title.add_text_frame_for_overriding("Sales Report")

        presentation.save("chart_updated.pptx", slides.export.SaveFormat.PPTX)
```