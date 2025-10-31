---
title: 在演示文稿中使用 Python 管理图表数据标记
linktitle: 数据标记
type: docs
url: /zh/python-net/chart-data-marker/
keywords:
- 图表
- 数据点
- 标记
- 标记选项
- 标记大小
- 填充类型
- PowerPoint
- OpenDocument
- 演示文稿
- Python
- Aspose.Slides
description: "了解如何在 Aspose.Slides 中自定义图表数据标记，通过清晰的代码示例提升 PPT、PPTX 和 ODP 格式演示文稿的效果。"
---

## **设置图表标记选项**
可以在特定系列的图表数据点上设置标记。要设置图表标记选项，请按照以下步骤操作：

- 实例化 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类。
- 创建默认图表。
- 设置图片。
- 获取第一个图表系列。
- 添加新数据点。
- 将演示文稿写入磁盘。

在下面的示例中，我们在数据点级别设置了图表标记选项。

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

# 创建 Presentation 类的实例
with slides.Presentation() as presentation:

    slide = presentation.slides[0]

    # 创建默认图表
    chart = slide.shapes.add_chart(charts.ChartType.LINE_WITH_MARKERS, 0, 0, 400, 400)

    # 获取默认图表数据工作表索引
    defaultWorksheetIndex = 0

    # 获取图表数据工作表
    fact = chart.chart_data.chart_data_workbook

    # 删除示例系列
    chart.chart_data.series.clear()

    # 添加新系列
    chart.chart_data.series.add(fact.get_cell(defaultWorksheetIndex, 1, 1, "Series 1"), chart.type)
            
    # 设置图片
    image1 = draw.Bitmap(path + "aspose-logo.jpg")
    imgx1 = presentation.images.add_image(image1)

    # 设置图片
    image2 = draw.Bitmap(path + "Tulips.jpg")
    imgx2 = presentation.images.add_image(image2)

    # 获取第一个图表系列
    series = chart.chart_data.series[0]

    # 在此处添加新点 (1:3)。
    point = series.data_points.add_data_point_for_line_series(fact.get_cell(defaultWorksheetIndex, 1, 1, 4.5))
    point.marker.format.fill.fill_type = slides.FillType.PICTURE
    point.marker.format.fill.picture_fill_format.picture.image = imgx1

    point = series.data_points.add_data_point_for_line_series(fact.get_cell(defaultWorksheetIndex, 2, 1, 2.5))
    point.marker.format.fill.fill_type = slides.FillType.PICTURE
    point.marker.format.fill.picture_fill_format.picture.image = imgx2

    point = series.data_points.add_data_point_for_line_series(fact.get_cell(defaultWorksheetIndex, 3, 1, 3.5))
    point.marker.format.fill.fill_type = slides.FillType.PICTURE
    point.marker.format.fill.picture_fill_format.picture.image = imgx1

    point = series.data_points.add_data_point_for_line_series(fact.get_cell(defaultWorksheetIndex, 4, 1, 4.5))
    point.marker.format.fill.fill_type = slides.FillType.PICTURE
    point.marker.format.fill.picture_fill_format.picture.image = imgx2

    # 更改图表系列标记
    series.marker.size = 15

    # 将演示文稿写入磁盘
    presentation.save("MarkOptions_out.pptx", slides.export.SaveFormat.PPTX)
```

## **常见问题**

**默认提供哪些标记形状？**

标准形状可用（圆形、方形、菱形、三角形等）；列表由 [MarkerStyleType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/markerstyletype/) 枚举定义。如果需要非标准形状，请使用带图片填充的标记来模拟自定义视觉效果。

**将图表导出为图像或 SVG 时，标记会被保留吗？**

是的。将图表渲染为 [raster formats](/slides/zh/python-net/convert-powerpoint-to-png/) 或保存为 [shapes as SVG](/slides/zh/python-net/render-a-slide-as-an-svg-image/) 时，标记会保留其外观和设置，包括大小、填充和轮廓。