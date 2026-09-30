---
title: 管理 Python 中的演示文稿表格
linktitle: 管理表格
type: docs
weight: 10
url: /zh/python-java/manage-table/
keywords:
- 添加表格
- 创建表格
- 访问表格
- 宽高比
- 对齐文本
- 文本格式化
- 表格样式
- PowerPoint
- 演示文稿
- Python
- Aspose.Slides
description: "使用 Aspose.Slides for Python via Java 在 PowerPoint 幻灯片中创建和编辑表格。发现简洁的代码示例，简化您的表格工作流程。"
---
## **介绍**

PowerPoint 中的表格将信息组织为行和列，便于阅读和比较数值。

Aspose.Slides 提供了 [Table](https://reference.aspose.com/slides/python-java/aspose.slides/table/) 和 [Cell](https://reference.aspose.com/slides/python-java/aspose.slides/cell/) 类以及其他类型，帮助您在演示文稿中创建、更新和管理表格。

## **从零创建表格**

通过指定位置、列宽和行高来创建表格。将其添加到幻灯片后，您可以设置单元格边框、合并单元格并插入文本。

1. 创建一个 [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) 类的实例。
2. 按索引获取幻灯片的引用。
3. 定义以点为单位的列宽列表。
4. 定义以点为单位的行高列表。
5. 通过 [addTable](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addTable) 方法向幻灯片添加一个 [Table](https://reference.aspose.com/slides/python-java/aspose.slides/table/) 对象。
6. 遍历每个 [Cell](https://reference.aspose.com/slides/python-java/aspose.slides/cell/)，为上、下、左、右边框应用格式。
7. 合并表格第一行的前两个单元格。
8. 通过其 [getTextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getTextFrame) 方法访问合并后的单元格。
9. 设置合并单元格中的文本。
10. 保存修改后的演示文稿。

下面的示例在 (100, 50) 点处创建一个包含三列五行的表格。它使用宽度为 5 点的红色边框，合并第一行的前两个单元格，并将结果保存为 `table.pptx`。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    column_widths = [50, 50, 50]
    row_heights = [50, 30, 30, 30, 30]
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)

    for row in table.getRows():
        for cell in row:
            cell_format = cell.getCellFormat()
            cell_format.getBorderTop().getFillFormat().setFillType(FillType.Solid)
            cell_format.getBorderTop().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell_format.getBorderTop().setWidth(5)
            cell_format.getBorderBottom().getFillFormat().setFillType(FillType.Solid)
            cell_format.getBorderBottom().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell_format.getBorderBottom().setWidth(5)
            cell_format.getBorderLeft().getFillFormat().setFillType(FillType.Solid)
            cell_format.getBorderLeft().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell_format.getBorderLeft().setWidth(5)
            cell_format.getBorderRight().getFillFormat().setFillType(FillType.Solid)
            cell_format.getBorderRight().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell_format.getBorderRight().setWidth(5)

    table.mergeCells(table.get_Item(0, 0), table.get_Item(1, 0), False)
    table.get_Item(0, 0).getTextFrame().setText("Merged Cells")

    presentation.save("table.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **标准表格中的编号**

在标准表格中，单元格索引从零开始，并采用 (列, 行) 的顺序。第一个单元格的索引为 (0, 0)。

例如，具有 4 列 4 行的表格中的单元格编号如下：

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

此示例创建上述 4 × 4 表格，列宽和行高均为 70 点，使用宽度为 5 点的红色单元格边框。坐标用于说明单元格索引；示例保持单元格为空并将表格保存为 `StandardTables_out.pptx`。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    column_widths = [70, 70, 70, 70]
    row_heights = [70, 70, 70, 70]
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)

    for row in table.getRows():
        for cell in row:
            cell_format = cell.getCellFormat()
            cell_format.getBorderTop().getFillFormat().setFillType(FillType.Solid)
            cell_format.getBorderTop().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell_format.getBorderTop().setWidth(5)
            cell_format.getBorderBottom().getFillFormat().setFillType(FillType.Solid)
            cell_format.getBorderBottom().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell_format.getBorderBottom().setWidth(5)
            cell_format.getBorderLeft().getFillFormat().setFillType(FillType.Solid)
            cell_format.getBorderLeft().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell_format.getBorderLeft().setWidth(5)
            cell_format.getBorderRight().getFillFormat().setFillType(FillType.Solid)
            cell_format.getBorderRight().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell_format.getBorderRight().setWidth(5)

    presentation.save("StandardTables_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **访问现有表格**

表格存储在幻灯片的形状集合中。遍历形状以定位表格，然后使用 [Table](https://reference.aspose.com/slides/python-java/aspose.slides/table/) 类读取或更新其单元格。

1. 使用 [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) 类加载演示文稿。
2. 按索引获取包含表格的幻灯片引用。
3. 遍历 [Shape](https://reference.aspose.com/slides/python-java/aspose.slides/shape/) 对象，找到表格后停止。如果幻灯片包含多个表格，使用 [getAlternativeText](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getAlternativeText) 来识别所需的表格。
4. 更新目标单元格中的文本。
5. 保存修改后的演示文稿。

下面的示例打开 `UpdateExistingTable.pptx` 并在第一张幻灯片上找到第一个表格。它将第 0 列第 1 行的单元格设置为 `New`，并将结果保存为 `table1_out.pptx`。输入文件必须至少包含一张幻灯片，且该幻灯片上的第一个表格必须至少有一列两行。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, Table

presentation = Presentation("UpdateExistingTable.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    table = None

    for shape in slide.getShapes():
        if isinstance(shape, Table):
            table = shape
            break

    if table is not None:
        table.get_Item(0, 1).getTextFrame().setText("New")
        presentation.save("table1_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

要在现有表格中调整行大小并了解其实际高度为何可能超过请求的最小值，请参阅 [Control Row Height](/slides/zh/python-java/manage-rows-and-columns/#control-row-height)。

## **查找拥有文本框的单元格**

当通用文本处理代码从表格中收到一个 [TextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/) 时，使用 [TextFrame.getParentCell](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/#getParentCell) 方法检索其所属的 [Cell](https://reference.aspose.com/slides/python-java/aspose.slides/cell/)。对于表格单元格的文本框，[TextFrame.getParentCell](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/#getParentCell) 返回拥有者，而 [TextFrame.getParentShape](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/#getParentShape) 返回 `None`，即使表格本身也是一个形状。

单元格坐标可通过只读的 [Cell.getFirstColumnIndex](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getFirstColumnIndex) 和 [Cell.getFirstRowIndex](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getFirstRowIndex) 方法获取。[TextFrame.getParentCell](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/#getParentCell) 还提供只读导航：它返回拥有者但不改变所有权。在使用返回的单元格之前，请始终检查其是否为 `None`。

有关识别表格单元格和形状拥有者的完整示例（包括与 SmartArt 节点关联的形状），请参阅 [Search and Replace Text](/slides/zh/python-java/search-and-replace-text/)。

## **在表格中对齐文本**

您可以控制单个表格单元格的垂直锚定和文本方向。本节示例将第一单元格中的文本居中并旋转 270 度。

1. 创建一个 [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) 类的实例。
2. 按索引获取幻灯片的引用。
3. 向幻灯片添加一个 [Table](https://reference.aspose.com/slides/python-java/aspose.slides/table/) 对象。
4. 从表格中访问一个 [TextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/) 对象。
5. 访问第一个 [Paragraph](https://reference.aspose.com/slides/python-java/aspose.slides/paragraph/) 并设置其文本和颜色。
6. 使用 [setTextAnchorType](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#setTextAnchorType) 和 [setTextVerticalType](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#setTextVerticalType) 设置单元格的垂直锚定和文本方向。
7. 保存修改后的演示文稿。

此示例创建一个 4 × 4 表格，列宽为 120 点，行高为 100 点。它格式化单元格 (0, 0) 中的文本，在第一行的其余单元格中添加值，并将结果保存为 `Vertical_Align_Text_out.pptx`。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat, TextAnchorType, TextVerticalType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    column_widths = [120, 120, 120, 120]
    row_heights = [100, 100, 100, 100]
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)
    
    table.get_Item(1, 0).getTextFrame().setText("10")
    table.get_Item(2, 0).getTextFrame().setText("20")
    table.get_Item(3, 0).getTextFrame().setText("30")

    text_frame = table.get_Item(0, 0).getTextFrame()
    paragraph = text_frame.getParagraphs().get_Item(0)

    portion = paragraph.getPortions().get_Item(0)
    portion.setText("Text here")
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)

    cell = table.get_Item(0, 0)
    cell.setTextAnchorType(TextAnchorType.Center)
    cell.setTextVerticalType(TextVerticalType.Vertical270)

    presentation.save("Vertical_Align_Text_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **在表格级别设置文本格式**

使用 [setTextFormat](https://reference.aspose.com/slides/python-java/aspose.slides/table/#setTextFormat) 可对表格中所有单元格应用文本格式。其重载接受段落、文本框以及部分格式，因此您无需遍历单个单元格即可设置这些属性。

1. 使用 [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) 类加载演示文稿。
2. 按索引获取幻灯片的引用。
3. 从幻灯片中访问一个 [Table](https://reference.aspose.com/slides/python-java/aspose.slides/table/) 对象。
4. 使用 [setFontHeight](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setFontHeight) 为文本设置字体大小。
5. 使用 [setAlignment](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setAlignment) 和 [setMarginRight](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setMarginRight) 设置段落对齐方式和右侧边距。
6. 使用 [setTextVerticalType](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setTextVerticalType) 设置文本方向。
7. 保存修改后的演示文稿。

下面的示例打开 `table.pptx`（该文件必须至少包含一张幻灯片，并且表格是其第一个形状），将字体大小设为 25 点，段落右对齐并设置右边距为 20 点，使文本垂直排列。格式化后的演示文稿保存为 `result.pptx`。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ParagraphFormat, PortionFormat, Presentation, SaveFormat, TextAlignment, TextFrameFormat, TextVerticalType, Table

presentation = Presentation("table.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    table = slide.getShapes().get_Item(0)

    portion_format = PortionFormat()
    portion_format.setFontHeight(25)
    table.setTextFormat(portion_format)

    paragraph_format = ParagraphFormat()
    paragraph_format.setAlignment(TextAlignment.Right)
    paragraph_format.setMarginRight(20)
    table.setTextFormat(paragraph_format)

    text_frame_format = TextFrameFormat()
    text_frame_format.setTextVerticalType(TextVerticalType.Vertical)
    table.setTextFormat(text_frame_format)
    presentation.save("result.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **获取表格样式属性**

使用 [getStylePreset](https://reference.aspose.com/slides/python-java/aspose.slides/table/#getStylePreset) 读取表格的预设样式，使用 [setStylePreset](https://reference.aspose.com/slides/python-java/aspose.slides/table/#setStylePreset) 为其分配样式。本示例将 [TableStylePreset.DarkStyle1](https://reference.aspose.com/slides/python-java/aspose.slides/tablestylepreset/) 应用于一个表格，打印预设值，并将相同的预设分配给第二个表格。两个表格均保存为 `table-style.pptx`。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TableStylePreset

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    column_widths = [100, 150]
    row_heights = [5, 5, 5]
    table = slide.getShapes().addTable(10, 10, column_widths, row_heights)
    table.setStylePreset(TableStylePreset.DarkStyle1)

    style_preset = table.getStylePreset()
    print("Table style preset: ", style_preset)

    another_table = slide.getShapes().addTable(10, 100, column_widths, row_heights)
    another_table.setStylePreset(style_preset)

    presentation.save("table-style.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **锁定表格的宽高比**

表格的宽高比是其宽度与高度的比例。使用 [setAspectRatioLocked](https://reference.aspose.com/slides/python-java/aspose.slides/graphicalobjectlock/#setAspectRatioLocked) 可锁定此比例。

下面的示例打开 `pres.pptx`（该文件必须至少包含一张幻灯片，并且表格是其第一个形状），打印当前锁定状态，启用宽高比锁定，打印更新后的状态 (`True`)，并将结果保存为 `pres-out.pptx`。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, Table

presentation = Presentation("pres.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    table = slide.getShapes().get_Item(0)

    print("Lock aspect ratio set: ", table.getGraphicalObjectLock().getAspectRatioLocked())

    table.getGraphicalObjectLock().setAspectRatioLocked(True)
    print("Lock aspect ratio set: ", table.getGraphicalObjectLock().getAspectRatioLocked())

    presentation.save("pres-out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **常见问题**

**我可以为整个表格及其单元格中的文本启用从右到左 (RTL) 阅读方向吗？**

可以。表格提供了 [setRightToLeft](https://reference.aspose.com/slides/python-java/aspose.slides/table/#setRightToLeft) 方法，段落则有 [ParagraphFormat.setRightToLeft](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setRightToLeft)。两者一起使用可确保单元格内部的正确 RTL 顺序和渲染。

**如何防止用户在最终文件中移动或调整表格的大小？**

使用 [shape locks](/slides/zh/python-java/applying-protection-to-presentation/) 禁用移动、调整大小、选择等。这些锁同样适用于表格。

**是否支持在单元格内部将图像作为背景插入？**

支持。您可以为单元格设置 [picture fill](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/)，图像将根据所选模式（拉伸或平铺）覆盖单元格区域。