---
title: 使用 Python 自定义演示文稿图表中的误差线
linktitle: 误差线
type: docs
url: /zh/python-java/error-bar/
keywords:
- 误差线
- 自定义值
- PowerPoint
- 演示文稿
- Python
- Java
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for Python via Java 在图表中添加和自定义误差线——优化 PowerPoint 演示文稿中的数据可视化。"
---
## **概述**

本文介绍如何使用 Aspose.Slides 在演示文稿图表中使用误差线。它展示了如何向图表系列添加误差线、配置 X 和 Y 误差线设置，以及使用固定值、百分比值和自定义值等不同的值类型。

它还演示了如何通过相应的数据点集合为系列中的单个数据点分配自定义误差线值。此外，文章还简要说明了误差线在导出过程中的表现、它们与标记和数据标签的兼容性，以及在哪里可以找到相关的 API 参考类和枚举。

## **添加误差线**

Aspose.Slides for Python via Java 提供了用于管理误差线值的简洁 API。下面的示例代码使用固定值和百分比值类型。

1. 创建 [Presentation](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/) 类的实例。
1. 在所需的幻灯片中添加气泡图。
1. 访问第一条图表系列并设置误差线 X 格式。
1. 访问第一条图表系列并设置误差线 Y 格式。
1. 设置误差线的值和格式。
1. 将修改后的演示文稿写入 PPTX 文件。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, DataSourceType, ErrorBarType, ErrorBarValueType, Presentation, SaveFormat

# 创建 Presentation 类的实例。
presentation = Presentation()
try:
    # 创建气泡图。
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Bubble, 50, 50, 400, 300, True)

    # 添加误差线并设置其格式。
    series = chart.getChartData().getSeries().get_Item(0)
    error_bar_x = series.getErrorBarsXFormat()
    error_bar_y = series.getErrorBarsYFormat()

    error_bar_x.setVisible(True)
    error_bar_y.setVisible(True)
    error_bar_x.setValueType(ErrorBarValueType.Fixed)
    error_bar_x.setValue(0.1)
    error_bar_y.setValueType(ErrorBarValueType.Percentage)
    error_bar_y.setValue(5)
    error_bar_x.setType(ErrorBarType.Plus)
    error_bar_y.getFormat().getLine().setWidth(2.0)
    error_bar_x.setEndCap(True)

    # 保存演示文稿。
    presentation.save("ErrorBars.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **添加自定义误差线值**

Aspose.Slides for Python via Java 提供了用于管理自定义误差线值的简洁 API。当 [getValueType](https://reference.aspose.com/slides/zh/python-java/aspose.slides/errorbarsformat/#getValueType) 返回 [ErrorBarValueType.Custom](https://reference.aspose.com/slides/zh/python-java/aspose.slides/errorbarvaluetype/#Custom) 时，以下示例代码适用。要指定值，请对通过系列方法 [getDataPoints](https://reference.aspose.com/slides/zh/python-java/aspose.slides/chartseries/#getDataPoints) 返回的集合中的特定数据点使用 [getErrorBarsCustomValues](https://reference.aspose.com/slides/zh/python-java/aspose.slides/chartdatapoint/#getErrorBarsCustomValues)。

1. 创建 [Presentation](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/) 类的实例。
1. 在所需的幻灯片中添加气泡图。
1. 访问第一条图表系列并设置误差线 X 格式。
1. 访问第一条图表系列并设置误差线 Y 格式。
1. 访问图表系列中的各个数据点并设置它们的误差线值。
1. 设置误差线的值和格式。
1. 将修改后的演示文稿写入 PPTX 文件。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, DataSourceType, ErrorBarType, ErrorBarValueType, Presentation, SaveFormat

# 创建 Presentation 类的实例。
presentation = Presentation()
try:
    # 创建气泡图。
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Bubble, 50, 50, 400, 300, True)

    # 添加自定义误差线并设置其格式。
    series = chart.getChartData().getSeries().get_Item(0)
    error_bar_x = series.getErrorBarsXFormat()
    error_bar_y = series.getErrorBarsYFormat()
    error_bar_x.setVisible(True)
    error_bar_y.setVisible(True)
    error_bar_x.setValueType(ErrorBarValueType.Custom)
    error_bar_y.setValueType(ErrorBarValueType.Custom)

    # 访问图表系列的数据点并配置它们的误差线值来源。
    points = series.getDataPoints()
    data_source = points.getDataSourceTypeForErrorBarsCustomValues()
    data_source.setDataSourceTypeForXPlusValues(jpype.JByte(DataSourceType.DoubleLiterals))
    data_source.setDataSourceTypeForXMinusValues(jpype.JByte(DataSourceType.DoubleLiterals))
    data_source.setDataSourceTypeForYPlusValues(jpype.JByte(DataSourceType.DoubleLiterals))
    data_source.setDataSourceTypeForYMinusValues(jpype.JByte(DataSourceType.DoubleLiterals))

    # 为图表系列的数据点设置误差线值。
    for i in range(points.size()):
        custom_values = points.get_Item(i).getErrorBarsCustomValues()
        custom_values.getXMinus().setAsLiteralDouble(i + 1)
        custom_values.getXPlus().setAsLiteralDouble(i + 1)
        custom_values.getYMinus().setAsLiteralDouble(i + 1)
        custom_values.getYPlus().setAsLiteralDouble(i + 1)

    # 保存演示文稿。
    presentation.save("ErrorBarsCustomValues.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **常见问题解答**

**将演示文稿导出为 PDF 或图像时误差线会怎样？**

它们作为图表的一部分进行渲染，并在转换过程中与图表的其他格式一起保留下来，前提是使用兼容的版本或渲染器。

**误差线可以与标记和数据标签一起使用吗？**

可以。误差线是独立的元素，能够与标记和数据标签共存；如果元素重叠，可能需要调整格式。

**在哪里可以找到用于操作误差线的属性和类列表？**

在 API 参考中：[ErrorBarsFormat](https://reference.aspose.com/slides/zh/python-java/aspose.slides/errorbarsformat/) 类以及相关的 [ErrorBarType](https://reference.aspose.com/slides/zh/python-java/aspose.slides/errorbartype/) 和 [ErrorBarValueType](https://reference.aspose.com/slides/zh/python-java/aspose.slides/errorbarvaluetype/) 类。