---
title: PPTX 中图表尺寸调整的可行解决方案
type: docs
weight: 60
url: /zh/python-net/working-solution-for-chart-resizing-in-pptx/
keywords:
- 图表尺寸调整
- Excel 图表
- OLE 对象
- 嵌入图表
- PowerPoint
- 演示文稿
- 通过 .NET 的 Python
- Python
- Aspose.Slides
description: "使用 Aspose.Slides for Python via .NET 嵌入的 Excel OLE 对象时，修复 PPTX 中意外的图表尺寸调整。设置固定图表尺寸，以保持图表和 OLE 框的大小一致。"
---
## **概述**

使用 Aspose 组件将 Excel 图表作为 OLE 对象嵌入 PowerPoint 演示文稿后，首次激活后图表可能会改变大小。这会导致图表在激活前后的外观出现明显差异。本文说明了导致尺寸变化的原因，并展示了通过将固定图表尺寸匹配到 OLE 框来防止此问题的方法。

在[在演示文稿中创建 Excel 图表并将其嵌入为 OLE 对象](/slides/zh/python-net/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)中，我们介绍了如何使用 Aspose.Cells for Python via .NET 创建 Excel 图表并使用 Aspose.Slides for Python via .NET 将其嵌入 PowerPoint 演示文稿。为了解决[对象预览问题](/slides/zh/python-net/object-preview-issue-when-adding-oleobjectframe/)，我们将图表图像分配给图表的 OLE 对象框。在输出的演示文稿中，双击显示图表图像的 OLE 对象框即可激活 Excel 图表。用户可以编辑嵌入的 Excel 工作簿，然后点击激活工作簿之外的区域返回幻灯片。用户返回幻灯片时，OLE 对象框的大小会发生变化，且缩放比例取决于 OLE 对象框和嵌入的 Excel 工作簿的原始尺寸。

## **尺寸变化的原因**

嵌入的 Excel 工作簿有其自身的窗口尺寸，Excel 会尝试在对象首次激活时保留该尺寸。幻灯片上的 OLE 框拥有独立定义的尺寸。当 Excel 工作簿被激活时，Excel 与 PowerPoint 会协商对象的大小，以在嵌入过程中保持其比例。因此，工作簿窗口与 OLE 框之间的差异会导致对象重新调整大小。

## **可行的解决方案**

将图表尺寸匹配到幻灯片上的 OLE 框，并使图表尺寸独立于工作簿窗口。此方案适用于新建演示文稿或基于现有模板的演示文稿。

示例需要 Aspose.Cells for Python via .NET 和 Aspose.Slides for Python via .NET。它在活动的图表工作表上创建一个简单的柱形图，并将工作簿以 XLS 格式嵌入。未分配图表预览图像；图表将在 PowerPoint 中激活 OLE 对象后可见。

示例创建了一个新的演示文稿，包含一个 9.5 × 4 英寸的 OLE 框，框左侧距左边缘 0.5 英寸，顶部距上边缘 1 英寸。幻灯片坐标和尺寸使用点（每英寸 72 点）。有关基于现有演示文稿的用法，请参见[使用模板](#使用模板)。

## **设置固定图表尺寸**

将[size_with_window](https://reference.aspose.com/cells/python-net/aspose.cells.charts/chart/size_with_window/)设为 false，使图表尺寸独立于工作簿窗口。通过[width](https://reference.aspose.com/cells/python-net/aspose.cells.drawing/shape/width/)和[height](https://reference.aspose.com/cells/python-net/aspose.cells.drawing/shape/height/)设置[chart_object](https://reference.aspose.com/cells/python-net/aspose.cells.charts/chart/chart_object/)的尺寸，并使用每英寸 96 像素的换算将点转换为像素：684 × 288 点的框对应 912 × 384 像素的图表。将[print_size](https://reference.aspose.com/cells/python-net/aspose.cells.charts/chart/print_size/)设为[PrintSizeType](https://reference.aspose.com/cells/python-net/aspose.cells/printsizetype/)的 CUSTOM 值。示例使用[add_ole_object_frame](https://reference.aspose.com/slides/python-net/aspose.slides/ishapecollection/add_ole_object_frame/)嵌入工作簿，并保存一个带有 9.5 × 4 英寸 OLE 框的演示文稿。

```python
import io
import aspose.cells as cells
import aspose.cells.charts as charts
import aspose.slides as slides

workbook = cells.Workbook()
data_sheet = workbook.worksheets[0]
data_sheet.name = "Data"
data_sheet.cells.get("A1").put_value(10)
data_sheet.cells.get("A2").put_value(20)

chart_sheet_index = workbook.worksheets.add(cells.SheetType.CHART)
chart_sheet = workbook.worksheets[chart_sheet_index]
chart_index = chart_sheet.charts.add(charts.ChartType.COLUMN, 0, 0, 20, 10)
chart = chart_sheet.charts[chart_index]
chart.n_series.add("Data!A1:A2", True)
workbook.worksheets.active_sheet_index = chart_sheet_index

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # 幻灯片坐标和尺寸使用点（每英寸 72 点）。
    width = 684.0  # 9.5 英寸。
    height = 288.0  # 4 英寸。

    chart.size_with_window = False
    # 使用每英寸 96 像素将点转换为图表像素。
    chart.chart_object.width = int(width / 72 * 96)
    chart.chart_object.height = int(height / 72 * 96)
    chart.print_size = cells.PrintSizeType.CUSTOM

    with io.BytesIO() as workbook_stream:
        workbook.save(workbook_stream, cells.SaveFormat.EXCEL_97_TO_2003)
        data_info = slides.dom.ole.OleEmbeddedDataInfo(workbook_stream.getvalue(), "xls")
        slide.shapes.add_ole_object_frame(36, 72, width, height, data_info)

    presentation.save("chart-fixed-size.pptx", slides.export.SaveFormat.PPTX)
```

## **使用模板**

现有演示文稿的尺寸逻辑相同。要调整示例，请执行以下步骤：

1. 加载模板演示文稿，而不是创建空白演示文稿。  
1. 确认第一张幻灯片至少包含三个形状，然后使用索引为 2 的形状作为占位符。  
1. 从该形状获取框的宽度和高度，而不是使用固定值 684 和 288。保持尺寸计算不变。  
1. 在占位符的位置添加 OLE 框，而不是使用固定坐标 36 和 72。  
1. 保存演示文稿前移除占位符。

## **常见问题解答**

**为什么我的嵌入 Excel 图表在 PowerPoint 中激活后会改变大小？**

因为 Excel 在首次激活时会尝试恢复原始窗口尺寸，而 PowerPoint 中的 OLE 对象框有自己的尺寸。PowerPoint 与 Excel 协商尺寸以保持宽高比，从而导致尺寸变化。

**如何保持图表和 OLE 框的尺寸一致？**

设置与 OLE 框匹配的固定图表尺寸，并在嵌入工作簿之前使用自定义图表打印尺寸。上面的示例展示了所需的设置和单位换算。

**仅匹配工作簿窗口尺寸是否足够？**

仅匹配工作簿窗口尺寸并不能可靠地阻止 OLE 框在激活后改变大小。请使用示例中展示的固定图表尺寸。

**此解决方案是否同时适用于基于模板的演示文稿和新建演示文稿？**

是的。对于模板，使用占位符的尺寸和位置；对于新建演示文稿，直接指定框的尺寸和位置。

**我可以将此示例用于其他电子表格程序创建的图表吗？**

该示例使用 Aspose.Cells 创建的 Excel 工作簿。它未演示其他电子表格程序的激活行为。

## **相关章节**

- [在演示文稿中创建 Excel 图表并将其嵌入为 OLE 对象](/slides/zh/python-net/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)
- [使用 PowerPoint 加载项自动更新 OLE 对象](/slides/zh/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)