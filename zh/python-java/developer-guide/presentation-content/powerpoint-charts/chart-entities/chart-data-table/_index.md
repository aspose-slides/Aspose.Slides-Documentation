---
title: 使用 Python 在演示文稿中自定义图表数据表
linktitle: 数据表
type: docs
url: /zh/python-java/chart-data-table/
keywords:
- 图表数据
- 数据表
- 字体属性
- PowerPoint
- 演示文稿
- Python
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Python via Java 在 PowerPoint 演示文稿中自定义图表数据表的字体、边框和图例键。"
---
## **概述**

Aspose.Slides for Python via Java 允许您显示图表的数据表并自定义其文本格式、边框和图例键。本文介绍如何启用数据表、设置文本格式、控制每种边框以及显示或隐藏图例键。示例会将配置后的图表保存为 PPTX 文件。

## **设置字体属性**

要显示图表的数据表，请将 `True` 传递给 [setDataTable](https://reference.aspose.com/slides/zh/python-java/aspose.slides/chart/#setDataTable)。使用 [getChartDataTable](https://reference.aspose.com/slides/zh/python-java/aspose.slides/chart/#getChartDataTable) 访问表并配置其文本格式。

1. 使用 [Presentation](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/) 类加载演示文稿。  
2. 在第一张幻灯片上添加簇状柱形图。  
3. 启用图表的数据表。  
4. 使用 [setFontBold](https://reference.aspose.com/slides/zh/python-java/aspose.slides/baseportionformat/#setFontBold) 启用粗体，并将 `20` 传递给 [setFontHeight](https://reference.aspose.com/slides/zh/python-java/aspose.slides/baseportionformat/#setFontHeight) 设置 20 磅文本。  
5. 保存修改后的演示文稿。

以下示例需要工作目录中存在 `test.pptx`（至少包含一张幻灯片）。它会在位置 (50, 50) 添加一个默认数据的图表，宽度 600 点，高度 400 点。保存的 `output.pptx` 包含已启用数据表且应用了指定字体设置的图表。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, NullableBool, Presentation, SaveFormat

presentation = Presentation("test.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400)
    chart.setDataTable(True)

    portion_format = chart.getChartDataTable().getTextFormat().getPortionFormat()
    portion_format.setFontBold(NullableBool.True_)
    portion_format.setFontHeight(20)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **自定义数据表边框**

使用 [Chart.setDataTable](https://reference.aspose.com/slides/zh/python-java/aspose.slides/chart/#setDataTable) 启用表，并通过 [Chart.getChartDataTable](https://reference.aspose.com/slides/zh/python-java/aspose.slides/chart/#getChartDataTable) 访问它。您可以独立控制三种边框：

- [setBorderHorizontal](https://reference.aspose.com/slides/zh/python-java/aspose.slides/datatable/#setBorderHorizontal) 控制水平单元格边框。  
- [setBorderVertical](https://reference.aspose.com/slides/zh/python-java/aspose.slides/datatable/#setBorderVertical) 控制垂直单元格边框。  
- [setBorderOutline](https://reference.aspose.com/slides/zh/python-java/aspose.slides/datatable/#setBorderOutline) 控制表的外部边框。

将 `True` 传递给相应方法即可显示该边框，传递 `False` 则隐藏。下面的示例创建一个默认数据的簇状柱形图，显示水平边框和外部边框，隐藏垂直边框。该示例不需要输入文件。图表的位置和尺寸均以点为单位指定。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400)
    chart.setDataTable(True)

    data_table = chart.getChartDataTable()
    data_table.setBorderHorizontal(True)
    data_table.setBorderVertical(False)
    data_table.setBorderOutline(True)

    presentation.save("data-table-borders.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

下面的比较使用相同的图表数据和图例键设置，展示四种情况。首先启用所有边框，然后在每种变体中仅禁用一种边框。左下角的变体对应示例中的边框设置。

![启用所有边框、无水平边框、无垂直边框以及无外部边框的图表数据表](data-table-borders.png)

## **显示或隐藏图例键**

图例键是数据表中系列名称旁边的彩色标记，可帮助读者将每行对应到图表系列。将 `True` 传递给 [setShowLegendKey](https://reference.aspose.com/slides/zh/python-java/aspose.slides/datatable/#setShowLegendKey) 可显示这些标记，传递 `False` 则隐藏。

单独的图例由 [Chart.setLegend](https://reference.aspose.com/slides/zh/python-java/aspose.slides/chart/#setLegend) 控制。这些设置相互独立：隐藏单独图例不会隐藏数据表中的键，隐藏数据表键也不会隐藏单独图例。

下面的示例创建一个默认数据的图表，启用数据表并在表内显示图例键，同时隐藏单独的图例。所有表边框均显式启用。无需输入演示文稿。若仅想隐藏表内键，将 `False` 传递给 [setShowLegendKey](https://reference.aspose.com/slides/zh/python-java/aspose.slides/datatable/#setShowLegendKey)。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400)
    chart.setDataTable(True)
    chart.setLegend(False)

    data_table = chart.getChartDataTable()
    data_table.setBorderHorizontal(True)
    data_table.setBorderVertical(True)
    data_table.setBorderOutline(True)
    data_table.setShowLegendKey(True)

    presentation.save("data-table-legend-keys.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

下面的比较展示了同一表在图例键显示和隐藏两种状态下的效果。所有边框保持启用，单独的图表图例在两种情况下均被隐藏。

![左侧显示图例键、右侧隐藏图例键的图表数据表](data-table-legend-keys.png)

## **常见问题**

**我可以在图表的数据表中显示图例键吗？**

可以。将 `True` 传递给 [setShowLegendKey](https://reference.aspose.com/slides/zh/python-java/aspose.slides/datatable/#setShowLegendKey) 以显示图例键，传递 `False` 则隐藏。

**将演示文稿导出为 PDF、HTML 或图像时，数据表会被保留吗？**

会。Aspose.Slides 在导出为 [PDF](/slides/zh/python-java/convert-powerpoint-to-pdf/)、[HTML](/slides/zh/python-java/convert-powerpoint-to-html/) 或 [images](/slides/zh/python-java/convert-powerpoint-to-png/) 时，会将图表及其已显示的数据表作为幻灯片的一部分渲染。

**我可以在从模板加载的图表中使用数据表吗？**

可以。对于从现有演示文稿或模板加载的图表，使用 [hasDataTable](https://reference.aspose.com/slides/zh/python-java/aspose.slides/chart/#hasDataTable) 和 [setDataTable](https://reference.aspose.com/slides/zh/python-java/aspose.slides/chart/#setDataTable) 检查或更改是否显示数据表。

**如何查找已启用数据表的图表？**

遍历每张幻灯片上的形状，识别图表后调用其 [hasDataTable](https://reference.aspose.com/slides/zh/python-java/aspose.slides/chart/#hasDataTable) 方法。返回 `True` 表示该图表已启用数据表。