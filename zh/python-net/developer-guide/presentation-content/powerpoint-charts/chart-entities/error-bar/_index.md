---
title: 误差线
type: docs
url: /python-net/error-bar/
keywords: "误差线, 误差线值 PowerPoint 演示文稿, Python, Aspose.Slides for Python via .NET"
description: "在 Python 中向 PowerPoint 演示文稿添加误差线"
---

## **添加误差线**
Aspose.Slides for Python via .NET 提供了一个简单的 API 来管理误差线值。示例代码适用于使用自定义值类型的情况。要指定一个值，请使用 **DataPoints** 集合中特定数据点的 **ErrorBarCustomValues** 属性：

1. 创建 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例。
1. 在所需幻灯片上添加气泡图。
1. 访问第一个图表系列并设置误差线 X 格式。
1. 访问第一个图表系列并设置误差线 Y 格式。
1. 设置误差线的值和格式。
1. 将修改后的演示文稿写入 PPTX 文件。

```py
import aspose.slides.charts as charts
import aspose.slides as slides

# 创建空的演示文稿
with slides.Presentation() as presentation:
    # 创建气泡图
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
Aspose.Slides for Python via .NET 提供了一个简单的 API 来管理自定义误差线值。示例代码适用于 **IErrorBarsFormat.ValueType** 属性等于 **Custom** 的情况。要指定一个值，请使用 **DataPoints** 集合中特定数据点的 **ErrorBarCustomValues** 属性：

1. 创建 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例。
1. 在所需幻灯片上添加气泡图。
1. 访问第一个图表系列并设置误差线 X 格式。
1. 访问第一个图表系列并设置误差线 Y 格式。
1. 访问图表系列的单个数据点并为单个系列数据点设置误差线值。
1. 设置误差线的值和格式。
1. 将修改后的演示文稿写入 PPTX 文件。

```py
import aspose.slides.charts as charts
import aspose.slides as slides

# 创建空的演示文稿
with slides.Presentation() as presentation:
    # 创建气泡图
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