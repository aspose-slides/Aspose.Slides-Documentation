---
title: 在 Python 中管理演示文稿表格
linktitle: 管理表格
type: docs
weight: 10
url: /zh/python-java/manage-table/
keywords:
- 添加表格
- 创建表格
- 访问表格
- 宽高比
- 对齐文字
- 文本格式
- 表格样式
- PowerPoint
- 演示文稿
- Python
- Aspose.Slides
description: "使用针对 Java 的 Python 版 Aspose.Slides 在 PowerPoint 幻灯片中创建和编辑表格。发现简洁的代码示例，以简化您的表格工作流程。"
---
## **介绍**

PowerPoint 中的表格是显示信息的高效方式。网格单元格（按行列排列）中的信息直观且易于理解。

Aspose.Slides 提供了 [Table](https://reference.aspose.com/slides/zh/python-java/aspose.slides/table/) 类、[Cell](https://reference.aspose.com/slides/zh/python-java/aspose.slides/cell/) 类以及其他类型，帮助您在各种演示文稿中创建、更新和管理表格。

## **从头创建表格**

1. 创建 [Presentation](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/) 类的实例。  
2. 通过索引获取幻灯片的引用。  
3. 定义列宽列表。  
4. 定义行高列表。  
5. 通过 [addTable](https://reference.aspose.com/slides/zh/python-java/aspose.slides/shapecollection/#addTable) 方法向幻灯片添加一个 [Table](https://reference.aspose.com/slides/zh/python-java/aspose.slides/table/) 对象。  
6. 遍历每个 [Cell](https://reference.aspose.com/slides/zh/python-java/aspose.slides/cell/)，对上、下、左、右边框应用格式设置。  
7. 合并表格第一行的前两个单元格。  
8. 访问 [Cell](https://reference.aspose.com/slides/zh/python-java/aspose.slides/cell/) 的 [TextFrame](https://reference.aspose.com/slides/zh/python-java/aspose.slides/textframe/)。  
9. 向 [TextFrame](https://reference.aspose.com/slides/zh/python-java/aspose.slides/textframe/) 添加一些文本。  
10. 保存修改后的演示文稿。

下面的 Python 代码演示如何在演示文稿中创建表格：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat
from java.awt import Color

# 实例化一个表示 PPTX 文件的 Presentation 类
presentation = Presentation()
try:

    # 访问第一张幻灯片
    slide = presentation.getSlides().get_Item(0)

    # 定义列宽和行高
    column_widths = [50, 50, 50]
    row_heights = [50, 30, 30, 30, 30]

    # 向幻灯片添加表格形状
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)

    # 为每个单元格设置边框格式
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

    # 合并第 1 行的第 1 和第 2 个单元格
    table.mergeCells(table.getRows().get_Item(0).get_Item(0), table.getRows().get_Item(0).get_Item(1), False)

    # 向合并后的单元格添加文本
    table.getRows().get_Item(0).get_Item(0).getTextFrame().setText("Merged Cells")

    # 将演示文稿保存到磁盘
    presentation.save("table.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **标准表格中的编号**

在标准表格中，单元格的编号是直观的且从零开始。表格中的第一个单元格索引为 0,0（第 0 列，第 0 行）。

例如，具有 4 列 4 行的表格中的单元格编号如下：

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

下面的 Python 代码演示如何使用标准单元格编号创建表格：

```python
import jpype
import asposeslides

if not jpile.isJVMStarted():
    jpile.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat
from java.awt import Color

# 实例化一个表示 PPTX 文件的 Presentation 类
presentation = Presentation()
try:

    # 访问第一张幻灯片
    slide = presentation.getSlides().get_Item(0)

    # 定义列宽和行高
    column_widths = [70, 70, 70, 70]
    row_heights = [70, 70, 70, 70]

    # 向幻灯片添加表格形状
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)

    # 为每个单元格设置边框格式
    for row in table.getRows():
        for cell in row:
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(FillType.Solid)
            cell.getCellFormat().getBorderTop().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell.getCellFormat().getBorderTop().setWidth(5)
            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(FillType.Solid)
            cell.getCellFormat().getBorderBottom().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell.getCellFormat().getBorderBottom().setWidth(5)
            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(FillType.Solid)
            cell.getCellFormat().getBorderLeft().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell.getCellFormat().getBorderLeft().setWidth(5)
            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(FillType.Solid)
            cell.getCellFormat().getBorderRight().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell.getCellFormat().getBorderRight().setWidth(5)

    # 将演示文稿保存到磁盘
    presentation.save("StandardTables_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **访问现有表格**

1. 创建 [Presentation](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/) 类的实例。  
2. 通过索引获取包含该表格的幻灯片的引用。  
3. 为 [Table](https://reference.aspose.com/slides/zh/python-java/aspose.slides/table/) 对象初始化一个变量，并将其设为 `None`。  
4. 遍历所有 [Shape](https://reference.aspose.com/slides/zh/python-java/aspose.slides/shape/) 对象，直至找到表格。  
   如果您怀疑当前幻灯片只包含一个表格，可以直接检查它包含的所有形状。当形状被识别为表格时，可将其用作 [Table](https://reference.aspose.com/slides/zh/python-java/aspose.slides/table/) 对象。但如果幻灯片中包含多个表格，最好通过其 [getAlternativeText](https://reference.aspose.com/slides/zh/python-java/aspose.slides/shape/#getAlternativeText) 来搜索所需的表格。  
5. 使用 [Table](https://reference.aspose.com/slides/zh/python-java/aspose.slides/table/) 对象对表格进行操作。下面的示例中，我们更新第二行第一列的文本。  
6. 保存修改后的演示文稿。

下面的 Python 代码演示如何访问并操作现有表格：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, Table

# 实例化表示 PPTX 文件的 Presentation 类
presentation = Presentation("UpdateExistingTable.pptx")
try:

    # 访问第一张幻灯片
    slide = presentation.getSlides().get_Item(0)

    # 初始化表格引用
    table = None

    # 遍历形状并将找到的表格设置为引用
    for shape in slide.getShapes():
        if isinstance(shape, Table):
            table = shape

            # 设置第二行第一列的文本
            table.get_Item(0, 1).getTextFrame().setText("New")

    # 将修改后的演示文稿保存到磁盘
    presentation.save("table1_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **查找拥有 TextFrame 的单元格**

当通用文本处理代码从表格中收到 [TextFrame](https://reference.aspose.com/slides/zh/python-java/aspose.slides/textframe/) 时，使用 [TextFrame.getParentCell](https://reference.aspose.com/slides/zh/python-java/aspose.slides/textframe/#getParentCell) 方法检索拥有该框的 [Cell](https://reference.aspose.com/slides/zh/python-java/aspose.slides/cell/)。对于表格单元格的 TextFrame，[TextFrame.getParentCell](https://reference.aspose.com/slides/zh/python-java/aspose.slides/textframe/#getParentCell) 返回所有者，而 [TextFrame.getParentShape](https://reference.aspose.com/slides/zh/python-java/aspose.slides/textframe/#getParentShape) 返回 `None`，即使表格本身是一个形状。

单元格坐标可通过只读的 [Cell.getFirstColumnIndex](https://reference.aspose.com/slides/zh/python-java/aspose.slides/cell/#getFirstColumnIndex) 和 [Cell.getFirstRowIndex](https://reference.aspose.com/slides/zh/python-java/aspose.slides/cell/#getFirstRowIndex) 方法获取。[TextFrame.getParentCell](https://reference.aspose.com/slides/zh/python-java/aspose.slides/textframe/#getParentCell) 还提供只读导航：它返回所有者但不改变所有权。在使用返回的单元格之前，请始终检查是否为 `None`。

要查看完整示例（包括识别表格单元格和形状所有者，以及与 SmartArt 节点关联的形状），请参阅 [Search and Replace Text](/slides/zh/python-java/search-and-replace-text/)。

## **对齐表格中的文本**

1. 创建 [Presentation](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/) 类的实例。  
2. 通过索引获取幻灯片的引用。  
3. 向幻灯片添加一个 [Table](https://reference.aspose.com/slides/zh/python-java/aspose.slides/table/) 对象。  
4. 从表格中访问一个 [TextFrame](https://reference.aspose.com/slides/zh/python-java/aspose.slides/textframe/) 对象。  
5. 访问该 [TextFrame](https://reference.aspose.com/slides/zh/python-java/aspose.slides/textframe/) 对象的 [Paragraph](https://reference.aspose.com/slides/zh/python-java/aspose.slides/paragraph/)。  
6. 垂直对齐文本。  
7. 保存修改后的演示文稿。

下面的 Python 代码演示如何对齐表格中的文本：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat, TextAnchorType, TextVerticalType
from java.awt import Color

# 创建 Presentation 类的实例
presentation = Presentation()
try:

    # 获取第一张幻灯片
    slide = presentation.getSlides().get_Item(0)

    # 定义列宽和行高
    column_widths = [120, 120, 120, 120]
    row_heights = [100, 100, 100, 100]

    # 向幻灯片添加表格形状
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)
    table.get_Item(1, 0).getTextFrame().setText("10")
    table.get_Item(2, 0).getTextFrame().setText("20")
    table.get_Item(3, 0).getTextFrame().setText("30")

    # 获取文本框
    text_frame = table.get_Item(0, 0).getTextFrame()

    # 访问文本框中的第一个段落
    paragraph = text_frame.getParagraphs().get_Item(0)

    # 访问段落中的第一个文本片段
    portion = paragraph.getPortions().get_Item(0)
    portion.setText("Text here")
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)

    # 垂直对齐文本
    cell = table.get_Item(0, 0)
    cell.setTextAnchorType(TextAnchorType.Center)
    cell.setTextVerticalType(TextVerticalType.Vertical270)

    # 将演示文稿保存到磁盘
    presentation.save("Vertical_Align_Text_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **在表格级别设置文本格式**

1. 创建 [Presentation](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/) 类的实例。  
2. 通过索引获取幻灯片的引用。  
3. 从幻灯片访问一个 [Table](https://reference.aspose.com/slides/zh/python-java/aspose.slides/table/) 对象。  
4. 使用 [setFontHeight](https://reference.aspose.com/slides/zh/python-java/aspose.slides/baseportionformat/#setFontHeight) 设置文本的字体高度。  
5. 使用 [setAlignment](https://reference.aspose.com/slides/zh/python-java/aspose.slides/paragraphformat/#setAlignment) 和 [setMarginRight](https://reference.aspose.com/slides/zh/python-java/aspose.slides/paragraphformat/#setMarginRight) 设置对齐方式和右边距。  
6. 使用 [setTextVerticalType](https://reference.aspose.com/slides/zh/python-java/aspose.slides/textframeformat/#setTextVerticalType) 设置垂直文本类型。  
7. 保存修改后的演示文稿。

下面的 Python 代码演示如何将首选格式选项应用于表格中的文本：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ParagraphFormat, PortionFormat, Presentation, SaveFormat, TextAlignment, TextFrameFormat, TextVerticalType, Table

# 创建 Presentation 类的实例
presentation = Presentation("simpletable.pptx")
try:

    # 假设第一张幻灯片上的第一个形状是表格
    shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    if isinstance(shape, Table):
        table = shape

        # 设置表格单元格的字体高度
        portion_format = PortionFormat()
        portion_format.setFontHeight(25)
        table.setTextFormat(portion_format)

        # 一次性设置表格单元格的文本对齐方式和右边距
        paragraph_format = ParagraphFormat()
        paragraph_format.setAlignment(TextAlignment.Right)
        paragraph_format.setMarginRight(20)
        table.setTextFormat(paragraph_format)

        # 设置表格单元格的垂直文本类型
        text_frame_format = TextFrameFormat()
        text_frame_format.setTextVerticalType(TextVerticalType.Vertical)
        table.setTextFormat(text_frame_format)
        presentation.save("result.pptx", SaveFormat.Pptx)
    else:
        print("The first shape is not a table.")
finally:
    presentation.dispose()
```

## **获取表格样式属性**

Aspose.Slides 允许您检索表格的样式属性，以便在其他表格或其他位置使用这些细节。下面的 Python 代码演示如何从表格预设样式获取样式属性：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TableStylePreset

presentation = Presentation()
try:
    table = presentation.getSlides().get_Item(0).getShapes().addTable(10, 10, [100, 150], [5, 5, 5])
    table.setStylePreset(TableStylePreset.DarkStyle1)  # 更改默认样式预设主题

    # 获取表格的样式预设
    style_preset = table.getStylePreset()
    print("Table style preset: ", style_preset)

    # 将检索到的样式预设应用于另一个表格
    another_table = presentation.getSlides().get_Item(0).getShapes().addTable(10, 100, [100, 150], [5, 5, 5])
    another_table.setStylePreset(style_preset)
    presentation.save("table.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **锁定表格的宽高比**

几何形状的宽高比是其在不同维度上的尺寸比例。Aspose.Slides 提供了 [setAspectRatioLocked](https://reference.aspose.com/slides/zh/python-java/aspose.slides/graphicalobjectlock/#setAspectRatioLocked) 方法，以便对表格及其他形状锁定宽高比设置。

下面的 Python 代码演示如何锁定表格的宽高比：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, Table

presentation = Presentation("pres.pptx")
try:
    shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    if isinstance(shape, Table):
        table = shape
        print("Lock aspect ratio set: ", table.getGraphicalObjectLock().getAspectRatioLocked())
        table.getGraphicalObjectLock().setAspectRatioLocked(not table.getGraphicalObjectLock().getAspectRatioLocked())  # 反转
        print("Lock aspect ratio set: ", table.getGraphicalObjectLock().getAspectRatioLocked())
        presentation.save("pres-out.pptx", SaveFormat.Pptx)
    else:
        print("The first shape is not a table.")
finally:
    presentation.dispose()
```

## **常见问题**

**Can I enable right-to-left (RTL) reading direction for an entire table and the text in its cells?**  
是的。表格提供了 [setRightToLeft](https://reference.aspose.com/slides/zh/python-java/aspose.slides/table/#setRightToLeft) 方法，段落则有 [ParagraphFormat.setRightToLeft](https://reference.aspose.com/slides/zh/python-java/aspose.slides/paragraphformat/#setRightToLeft)。同时使用两者可确保单元格内文本的正确 RTL 顺序和渲染。

**How can I prevent users from moving or resizing a table in the final file?**  
使用 [shape locks](/slides/zh/python-java/applying-protection-to-presentation/) 可禁用移动、调整大小、选择等操作。这些锁同样适用于表格。

**Is inserting an image inside a cell as a background supported?**  
支持。您可以为单元格设置 [picture fill](https://reference.aspose.com/slides/zh/python-java/aspose.slides/picturefillformat/)，图像会根据选择的模式（拉伸或平铺）覆盖单元格区域。