---
title: 使用 Python 自定义演示文稿图表中的误差线
linktitle: 误差线
type: docs
url: /zh/python-net/error-bar/
keywords:
- 误差线
- 自定义值
- PowerPoint
- OpenDocument
- 演示文稿
- Python
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for Python via .NET 在 PowerPoint 和 OpenDocument 演示文稿中添加和自定义图表的误差线——优化数据可视化。"
---

## **添加误差线**
Aspose.Slides for Python via .NET 提供了用于管理误差线值的简洁 API。以下示例代码适用于使用自定义值类型的情况。要指定值，请使用系列 **DataPoints** 集合中特定数据点的 **ErrorBarCustomValues** 属性：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 实例。
1. 在所需幻灯片上添加气泡图表。
1. 访问第一个图表系列并设置误差线 X 格式。
1. 访问第一个图表系列并设置误差线 Y 格式。
1. 设置误差线的数值和格式。
1. 将修改后的演示文稿写入 PPTX 文件。

```py
import aspose.slides.charts as charts
import aspose.slides as slides

# 创建空演示文稿
with slides.Presentation() as presentation:
    # 创建气泡图表
    chart = presentation.slides[0].shapes.add_chart(charts.ChartType.BUBBLE, 50, 50, 400, 300, True)

    # 添加误差线并设置其格式
    errBarX = chart.chart_data.series[0].error_bars_x_format
    errBarY = chart.chart_data.series[0].error_bars_y_format
    errBarX.is_visible = True
    errBarY.is_visible = True
    errBarX.value_type = charts.ErrorBarValueType.FIXED
    errBarX.value = 0.1
    errBarY.value_type = charts.ErrorBarValueType.PERCENTAGE
    errBarY.value = 5
    errBarX.type = charts.ErrorBarType.PLUS
    errBarY.format.line.width = 2
    errBarX.has_end_cap = True

    # 保存演示文稿
    presentation.save("ErrorBars_out.pptx", slides.export.SaveFormat.PPTX)
```

## **添加自定义误差线值**
Aspose.Slides for Python via .NET 提供了用于管理自定义误差线值的简洁 API。以下示例代码适用于 **IErrorBarsFormat.ValueType** 属性等于 **Custom** 的情况。要指定值，请使用系列 **DataPoints** 集合中特定数据点的 **ErrorBarCustomValues** 属性：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 实例。
1. 在所需幻灯片上添加气泡图表。
1. 访问第一个图表系列并设置误差线 X 格式。
1. 访问第一个图表系列并设置误差线 Y 格式。
1. 访问图表系列的单个数据点并为每个数据点设置误差线值。
1. 设置误差线的数值和格式。
1. 将修改后的演示文稿写入 PPTX 文件。

```py
import aspose.slides.charts as charts
import aspose.slides as slides

# 创建空演示文稿
with slides.Presentation() as presentation:
    # 创建气泡图表
    chart = presentation.slides[0].shapes.add_chart(charts.ChartType.BUBBLE, 50, 50, 400, 300, True)

    # 添加自定义误差线并设置其格式
    series = chart.chart_data.series[0]
    errBarX = series.error_bars_x_format
    errBarY = series.error_bars_y_format
    errBarX.is_visible = True
    errBarY.is_visible = True
    errBarX.value_type = charts.ErrorBarValueType.CUSTOM
    errBarY.value_type = charts.ErrorBarValueType.CUSTOM

    # 访问图表系列数据点并为单个点设置误差线值
    points = series.data_points
    points.data_source_type_for_error_bars_custom_values.data_source_type_for_x_plus_values = charts.DataSourceType.DOUBLE_LITERALS
    points.data_source_type_for_error_bars_custom_values.data_source_type_for_x_minus_values = charts.DataSourceType.DOUBLE_LITERALS
    points.data_source_type_for_error_bars_custom_values.data_source_type_for_y_plus_values = charts.DataSourceType.DOUBLE_LITERALS
    points.data_source_type_for_error_bars_custom_values.data_source_type_for_y_minus_values = charts.DataSourceType.DOUBLE_LITERALS

    # 为图表系列点设置误差线
    for i in range(len(points)):
        points[i].error_bars_custom_values.x_minus.as_literal_double = i + 1
        points[i].error_bars_custom_values.x_plus.as_literal_double = i + 1
        points[i].error_bars_custom_values.y_minus.as_literal_double = i + 1
        points[i].error_bars_custom_values.y_plus.as_literal_double = i + 1

    # 保存演示文稿
    presentation.save("ErrorBarsCustomValues_out.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**将演示文稿导出为 PDF 或图像时，误差线会怎样？**

它们作为图表的一部分进行渲染，并在转换过程中与图表的其余格式一起保留，前提是使用兼容的版本或渲染器。

**误差线可以与标记和数据标签一起使用吗？**

可以。误差线是独立的元素，兼容标记和数据标签；如果元素重叠，可能需要调整格式。

**在哪里可以找到 API 中用于处理误差线的属性和枚举列表？**

在 API 参考中： [ErrorBarsFormat](https://reference.aspose.com/slides/python-net/aspose.slides.charts/errorbarsformat/) 类以及相关枚举 [ErrorBarType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/errorbartype/) 和 [ErrorBarValueType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/errorbarvaluetype/)。