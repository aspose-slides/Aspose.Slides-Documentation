---
title: PPTX 中图表大小调整的可行解决方案
type: docs
weight: 40
url: /zh/python-java/working-solution-for-chart-resizing-in-pptx/
keywords:
- 图表大小调整
- Excel 图表
- OLE 对象
- 嵌入图表
- PowerPoint
- 演示文稿
- Python
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Python via Java 嵌入的 Excel OLE 对象时，修复 PPTX 中意外的图表大小调整。设置固定的图表尺寸以保持图表和 OLE 框尺寸一致。"
---
## **背景**

在 PowerPoint 演示文稿中使用 Aspose 组件将 Excel 图表嵌入为 OLE 对象后，首次激活时可能会改变大小。这会导致图表在激活前后的外观出现显著差异。本文解释了产生大小调整的原因，并展示如何通过使固定图表尺寸与 OLE 框匹配来防止此问题。

在[在演示文稿中创建 Excel 图表并将其嵌入为 OLE 对象](/slides/zh/python-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)，我们说明了如何使用 Aspose.Cells for Python via Java 创建 Excel 图表并使用 Aspose.Slides for Python via Java 将其嵌入 PowerPoint 演示文稿。为了解决[对象预览问题](/slides/zh/python-java/object-preview-issue-when-adding-oleobjectframe/)，我们将图表图像分配给图表的 OLE 对象框。在输出的演示文稿中，双击显示图表图像的 OLE 对象框会激活 Excel 图表。用户可以编辑嵌入的 Excel 工作簿，然后通过单击激活工作簿之外的区域返回幻灯片。用户返回幻灯片时，OLE 对象框的大小会发生变化，且调整系数取决于 OLE 对象框和嵌入的 Excel 工作簿的原始大小。

## **大小调整的原因**

嵌入的 Excel 工作簿有其自身的窗口尺寸，Excel 在对象首次激活时会尝试保留该尺寸。幻灯片上的 OLE 框则有独立定义的尺寸。当 Excel 工作簿被激活时，Excel 与 PowerPoint 会协商对象的大小，以在嵌入过程中保持比例。因此，工作簿窗口与 OLE 框之间的差异会导致对象进行大小调整。

## **可行的解决方案**

将图表大小与幻灯片上的 OLE 框匹配，并使图表尺寸独立于工作簿窗口。此解决方案适用于新建演示文稿或已有模板。

示例需要 Aspose.Cells for Python via Java 和 Aspose.Slides for Python via Java。它在活动图表工作表上创建一个简单的柱形图，并将工作簿以 XLS 格式嵌入。未分配图表预览图像；图表将在 PowerPoint 中激活 OLE 对象时可见。

示例创建一个新的演示文稿，其中包含一个 9.5 × 4 英寸的 OLE 框，距左边缘 0.5 英寸，距顶部 1 英寸。幻灯片坐标和尺寸使用点 (每英寸 72 点) 表示。对于已有演示文稿，请参见[使用模板](#use-a-template)。

## **设置固定的图表大小**

将 [setSizeWithWindow](https://reference.aspose.com/cells/python-java/asposecells.api/chart/#sizewithwindow) 设置为 false，以使图表尺寸独立于工作簿窗口。通过 [setWidth](https://reference.aspose.com/cells/python-java/asposecells.api/shape/#width) 和 [setHeight](https://reference.aspose.com/cells/python-java/asposecells.api/shape/#height) 设置 [getChartObject](https://reference.aspose.com/cells/python-java/asposecells.api/chart/#chartobject) 的尺寸，使用每英寸 96 像素将点转换为像素：684 × 288 点的框对应 912 × 384 像素的图表。将 [setPrintSize](https://reference.aspose.com/cells/python-java/asposecells.api/chart/#printsize) 设置为 [PrintSizeType](https://reference.aspose.com/cells/python-java/asposecells.api/printsizetype/) 的 CUSTOM 值。示例使用 [addOleObjectFrame](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addOleObjectFrame) 嵌入工作簿，并将演示文稿保存为带有 9.5 × 4 英寸 OLE 框的文件。

```python
import jpype
import asposecells
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposecells.api import ChartType, FileFormatType, PrintSizeType, SheetType, Workbook
from asposeslides.api import OleEmbeddedDataInfo, Presentation, SaveFormat

ByteArrayOutputStream = jpype.JClass("java.io.ByteArrayOutputStream")

workbook = Workbook()
try:
    data_sheet = workbook.getWorksheets().get(0)
    data_sheet.setName("Data")
    data_sheet.getCells().get("A1").putValue(10)
    data_sheet.getCells().get("A2").putValue(20)

    chart_sheet_index = workbook.getWorksheets().add(SheetType.CHART)
    chart_sheet = workbook.getWorksheets().get(chart_sheet_index)
    chart_index = chart_sheet.getCharts().add(ChartType.COLUMN, 0, 0, 20, 10)
    chart = chart_sheet.getCharts().get(chart_index)
    chart.getNSeries().add("Data!A1:A2", True)
    workbook.getWorksheets().setActiveSheetIndex(chart_sheet_index)

    presentation = Presentation()
    try:
        slide = presentation.getSlides().get_Item(0)

        # 幻灯片坐标和尺寸使用点表示（每英寸 72 点）。
        width = 684.0  # 9.5 英寸。
        height = 288.0  # 4 英寸。

        chart.setSizeWithWindow(False)
        # 将点转换为图表像素，使用每英寸 96 像素。
        chart.getChartObject().setWidth(int(width / 72.0 * 96.0))
        chart.getChartObject().setHeight(int(height / 72.0 * 96.0))
        chart.setPrintSize(PrintSizeType.CUSTOM)

        workbook_stream = ByteArrayOutputStream()
        workbook.save(workbook_stream, FileFormatType.EXCEL_97_TO_2003)
        workbook_data = workbook_stream.toByteArray()
        data_info = OleEmbeddedDataInfo(workbook_data, "xls")
        slide.getShapes().addOleObjectFrame(36.0, 72.0, width, height, data_info)

        presentation.save("chart-fixed-size.pptx", SaveFormat.Pptx)
    finally:
        presentation.dispose()
finally:
    workbook.dispose()
```

## **使用模板**

现有演示文稿的尺寸逻辑相同。要改编示例：

1. 加载模板演示文稿，而不是创建空白演示文稿。  
2. 检查第一张幻灯片是否至少包含三个形状，然后将索引为 2 的形状用作占位符。  
3. 从该形状获取框宽度和高度，而不是使用固定值 684 和 288。保持尺寸计算不变。  
4. 在占位符的位置添加 OLE 框，而不是使用固定坐标 36 和 72。  
5. 保存演示文稿之前删除占位符。

## **常见问题**

**为什么嵌入的 Excel 图表在 PowerPoint 中激活后会改变大小？**

因为 Excel 在首次激活时尝试恢复原始窗口尺寸，而 PowerPoint 中的 OLE 对象框拥有自己的尺寸。PowerPoint 与 Excel 协商以保持宽高比，这会导致大小调整。

**如何保持图表和 OLE 框的尺寸一致？**

设置与 OLE 框匹配的固定图表尺寸，并在嵌入工作簿之前使用自定义图表打印大小。上面的示例展示了所需的设置和单位转换。

**仅匹配工作簿窗口尺寸足够吗？**

仅匹配工作簿窗口尺寸并不能可靠地防止 OLE 框在激活后改变大小。请使用示例中显示的固定图表尺寸。

**此解决方案适用于基于模板的演示文稿和新建演示文稿吗？**

是的。对于模板，使用占位符的尺寸和位置。对于新建演示文稿，直接指定框的尺寸和位置。

**我可以将此示例用于其他电子表格程序创建的图表吗？**

示例使用的是使用 Aspose.Cells 创建的 Excel 工作簿。它未演示其他电子表格程序的激活行为。

## **相关章节**

- [在演示文稿中创建 Excel 图表并将其嵌入为 OLE 对象](/slides/zh/python-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)