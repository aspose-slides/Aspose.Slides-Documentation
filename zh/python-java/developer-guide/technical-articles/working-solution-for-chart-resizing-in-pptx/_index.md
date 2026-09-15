---
title: PPTX 中图表缩放的可行解决方案
type: docs
weight: 40
url: /zh/python-java/working-solution-for-chart-resizing-in-pptx/
keywords:
- 图表缩放
- Excel 图表
- OLE 对象
- 嵌入图表
- PowerPoint
- OpenDocument
- 演示文稿
- Python
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Python via Java 嵌入的 Excel OLE 对象时，修复 PPTX 中意外的图表缩放问题。学习两种代码方法以保持尺寸一致。"
---
## **背景**

已观察到，通过 Aspose 组件将 Excel 图表作为 OLE 对象嵌入 PowerPoint 演示文稿后，在首次激活后会被调整为不确定的比例。此行为导致图表在激活前后呈现出明显的视觉差异。Aspose 团队对该问题进行了深入调查，并找到了解决方案。本文描述了问题的原因以及相应的修复方法。

在[上一篇文章](/slides/zh/python-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)中，我们说明了如何使用 Aspose.Cells for Python via Java 创建 Excel 图表并使用 Aspose.Slides for Python via Java 将其嵌入到 PowerPoint 演示文稿中。为了解决[对象预览问题](/slides/zh/python-java/object-preview-issue-when-adding-oleobjectframe/)，我们将图表图像分配给图表的 OLE 对象框。在输出的演示文稿中，双击显示图表图像的 OLE 对象框时，Excel 图表会被激活。最终用户可以在底层 Excel 工作簿中进行任意更改，然后通过点击激活的工作簿之外的区域返回相应的幻灯片。用户返回幻灯片时，OLE 对象框的大小会发生变化，且缩放比例取决于 OLE 对象框和嵌入的 Excel 工作簿的原始尺寸。

## **调整原因**

由于 Excel 工作簿拥有自己的窗口大小，它会在首次激活时尝试保留原始尺寸。而 OLE 对象框则有独立的大小。根据微软的说法，当 Excel 工作簿被激活时，Excel 与 PowerPoint 会协商尺寸，并在嵌入过程中保持正确的比例。根据 Excel 窗口尺寸与 OLE 对象框的尺寸或位置之间的差异，就会产生缩放。

## **可行方案**

创建使用 Aspose.Slides for Python via Java 的 PowerPoint 演示文稿有两种可能的场景。

**场景 1：** 基于已有模板创建演示文稿。

**场景 2：** 从零开始创建演示文稿。

本文提供的解决方案适用于这两种场景。所有解决思路的基础相同：**嵌入的 OLE 对象窗口大小应与 PowerPoint 幻灯片中的 OLE 对象框大小匹配**。下面将讨论实现此目标的两种方法。

## **第一种方法**

本方法演示如何设置嵌入的 Excel 工作簿窗口大小，使其与 PowerPoint 幻灯片中 OLE 对象框的大小保持一致。

**场景 1**

假设我们已经定义了一个模板，并希望基于该模板创建演示文稿。模板中索引为 2 的形状用于放置包含嵌入式 Excel 工作簿的 OLE 框。在此情形下，OLE 对象框的大小是预先定义好的——它与模板中索引为 2 的形状大小相同。我们只需将工作簿的窗口大小设为该形状的大小。以下代码片段实现了此目的：

```python
import jpype
import asposecells
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposecells.api import Workbook, PrintSizeType
from asposecells.api import SaveFormat as CellsSaveFormat
from asposeslides.api import OleEmbeddedDataInfo, Presentation

ByteArrayOutputStream = jpype.JClass("java.io.ByteArrayOutputStream")

# 加载包含图表的 Excel 工作簿。
workbook = Workbook("chart.xls")
chart = workbook.getWorksheets().get(0).getCharts().get(0)

presentation = Presentation("template.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().get_Item(2)

    # 将工作簿窗口大小设置为英寸（PowerPoint 每英寸使用 72 点）。
    workbook.getSettings().setWindowWidthInch(shape.getWidth() / 72.0)
    workbook.getSettings().setWindowHeightInch(shape.getHeight() / 72.0)

    # 将工作簿保存到内存流。
    workbook_stream = ByteArrayOutputStream()
    workbook.save(workbook_stream, CellsSaveFormat.EXCEL_97_TO_2003)

    # 使用嵌入的 Excel 数据创建 OLE 对象框。
    workbook_data = workbook_stream.toByteArray()
    data_info = OleEmbeddedDataInfo(workbook_data, "xls")
    ole_frame = slide.getShapes().addOleObjectFrame(shape.getX(), shape.getY(), shape.getWidth(), shape.getHeight(), data_info)
finally:
    presentation.dispose()
```

**场景 2**

如果我们想从头创建演示文稿，并在其中加入任意大小的 OLE 对象框以及嵌入的 Excel 工作簿，可使用如下代码片段。代码在幻灯片上创建一个宽 9.5 英寸、高 4 英寸、左上角坐标为 x = 0.5 英寸、y = 1 英寸的 OLE 对象框，然后将 Excel 工作簿窗口大小设置为相同的 4 英寸高、9.5 英寸宽。

```python
import jpype
import asposecells
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposecells.api import Workbook, PrintSizeType
from asposecells.api import SaveFormat as CellsSaveFormat
from asposeslides.api import OleEmbeddedDataInfo, Presentation

ByteArrayOutputStream = jpype.JClass("java.io.ByteArrayOutputStream")

# 加载包含图表的 Excel 工作簿。
workbook = Workbook("chart.xls")
chart = workbook.getWorksheets().get(0).getCharts().get(0)

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    desired_height = 288  # 4 英寸 (4 * 72)。
    desired_width = 684  # 9.5 英寸 (9.5 * 72)。

    # 使用窗口定义图表大小。
    chart.setSizeWithWindow(True)

    # 将工作簿窗口大小设置为英寸（PowerPoint 每英寸使用 72 点）。
    workbook.getSettings().setWindowWidthInch(desired_width / 72.0)
    workbook.getSettings().setWindowHeightInch(desired_height / 72.0)

    # 将工作簿保存到内存流。
    workbook_stream = ByteArrayOutputStream()
    workbook.save(workbook_stream, CellsSaveFormat.EXCEL_97_TO_2003)

    # 使用嵌入的 Excel 数据创建 OLE 对象框。
    workbook_data = workbook_stream.toByteArray()
    data_info = OleEmbeddedDataInfo(workbook_data, "xls")
    ole_frame = slide.getShapes().addOleObjectFrame(36.0, 72.0, desired_width, desired_height, data_info)
finally:
    presentation.dispose()
```

## **第二种方法**

本方法演示如何设置嵌入的 Excel 工作簿中图表的大小，使其与 PowerPoint 幻灯片中 OLE 对象框的大小保持一致。此方法适用于图表尺寸事先已知且固定不变的情况。

**场景 1**

假设我们已经定义了一个模板，并希望基于该模板创建演示文稿。模板中索引为 2 的形状用于放置包含嵌入式 Excel 工作簿的 OLE 框。在此情形下，OLE 框的大小是预先定义好的——它与模板中索引为 2 的形状大小相同。我们只需将工作簿中图表的大小设为该形状的大小。以下代码片段实现了此目的：

```python
import jpype
import asposecells
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposecells.api import Workbook, PrintSizeType
from asposecells.api import SaveFormat as CellsSaveFormat
from asposeslides.api import OleEmbeddedDataInfo, Presentation

ByteArrayOutputStream = jpype.JClass("java.io.ByteArrayOutputStream")

# 加载包含图表的 Excel 工作簿。
workbook = Workbook("chart.xls")
chart = workbook.getWorksheets().get(0).getCharts().get(0)

presentation = Presentation("template.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().get_Item(2)

    # 定义不使用窗口的图表大小。
    chart.setSizeWithWindow(False)

    # 以像素设置图表大小（Excel 每英寸使用 96 像素）。
    chart.getChartObject().setWidth(int((shape.getWidth() / 72.0) * 96.0))
    chart.getChartObject().setHeight(int((shape.getHeight() / 72.0) * 96.0))

    # 定义图表的打印大小。
    chart.setPrintSize(PrintSizeType.CUSTOM)

    # 将工作簿保存到内存流。
    workbook_stream = ByteArrayOutputStream()
    workbook.save(workbook_stream, CellsSaveFormat.EXCEL_97_TO_2003)

    # 使用嵌入的 Excel 数据创建 OLE 对象框。
    workbook_data = workbook_stream.toByteArray()
    data_info = OleEmbeddedDataInfo(workbook_data, "xls")
    ole_frame = slide.getShapes().addOleObjectFrame(shape.getX(), shape.getY(), shape.getWidth(), shape.getHeight(), data_info)
finally:
    presentation.dispose()
```

**场景 2**：

如果我们想从头创建演示文稿，并在其中加入任意大小的 OLE 对象框以及嵌入的 Excel 工作簿，可使用如下代码片段。代码在幻灯片上创建一个宽 9.5 英寸、高 4 英寸、左上角坐标为 x = 0.5 英寸、y = 1 英寸的 OLE 对象框，并将相应图表的尺寸设置为相同的 4 英寸高、9.5 英寸宽。

```python
import jpype
import asposecells
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposecells.api import Workbook, PrintSizeType
from asposecells.api import SaveFormat as CellsSaveFormat
from asposeslides.api import OleEmbeddedDataInfo, Presentation

ByteArrayOutputStream = jpype.JClass("java.io.ByteArrayOutputStream")

# 加载包含图表的 Excel 工作簿。
workbook = Workbook("chart.xls")
chart = workbook.getWorksheets().get(0).getCharts().get(0)

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    desired_height = 288  # 4 英寸 (4 * 72)。
    desired_width = 684  # 9.5 英寸 (9.5 * 72)。

    # 定义不使用窗口的图表大小。
    chart.setSizeWithWindow(False)

    # 以像素设置图表大小（Excel 每英寸使用 96 像素）。
    chart.getChartObject().setWidth(int((desired_width / 72.0) * 96.0))
    chart.getChartObject().setHeight(int((desired_height / 72.0) * 96.0))

    # 将工作簿保存到内存流。
    workbook_stream = ByteArrayOutputStream()
    workbook.save(workbook_stream, CellsSaveFormat.EXCEL_97_TO_2003)

    # 使用嵌入的 Excel 数据创建 OLE 对象框。
    workbook_data = workbook_stream.toByteArray()
    data_info = OleEmbeddedDataInfo(workbook_data, "xls")
    ole_frame = slide.getShapes().addOleObjectFrame(36.0, 72.0, desired_width, desired_height, data_info)
finally:
    presentation.dispose()
```

## **结论**

解决图表缩放问题有两种方法。选择哪种方法取决于具体需求和使用场景。无论是基于模板创建演示文稿还是从零开始创建，两种方法的实现方式相同。此外，此解决方案对 OLE 对象框的大小没有限制。

## **常见问题**

**为什么嵌入的 Excel 图表在 PowerPoint 中激活后会改变大小？**

因为 Excel 在首次激活时会尝试恢复原始窗口大小，而 PowerPoint 中的 OLE 对象框拥有自己的尺寸。PowerPoint 与 Excel 会协商尺寸以保持纵横比，从而导致缩放。

**是否可以彻底防止此缩放问题？**

可以。通过在嵌入之前将 Excel 工作簿窗口大小或图表大小与 OLE 对象框大小匹配，就能保持图表尺寸一致。

**应该采用设置工作簿窗口大小还是设置图表大小的方案？**

如果希望保持工作簿的纵横比并可能在以后进行调整，请使用**方案 1（窗口大小）**。如果图表尺寸是固定的且嵌入后不会变化，请使用**方案 2（图表大小）**。

**这些方法是否适用于基于模板的演示文稿和全新创建的演示文稿？**

是的。两种方法在基于模板创建和全新创建的演示文稿中表现相同。

**OLE 对象框的大小是否有限制？**

没有限制。只要 OLE 框的尺寸能够相应地缩放到工作簿或图表的大小，即可任意设定。

**这些方法能否用于其他电子表格程序创建的图表？**

示例针对使用 Aspose.Cells 创建的 Excel 图表，但原理同样适用于其他支持 OLE 且提供相似尺寸设置选项的电子表格程序。

## **相关章节**

- [创建 Excel 图表并将其作为 OLE 对象嵌入演示文稿](/slides/zh/python-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)