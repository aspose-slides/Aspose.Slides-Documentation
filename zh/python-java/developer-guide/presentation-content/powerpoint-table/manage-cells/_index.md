---
title: 使用 Python 管理演示文稿中的表格单元格
linktitle: 管理单元格
type: docs
weight: 30
url: /zh/python-java/manage-cells/
keywords:
- 表格单元格
- 合并单元格
- 删除边框
- 拆分单元格
- 单元格中的图像
- 背景颜色
- PowerPoint
- 演示文稿
- Python
- Aspose.Slides
description: "使用 Python 管理 PowerPoint 表格单元格：识别合并单元格、删除边框、拆分单元格，并使用 Aspose.Slides for Python via Java 设置背景颜色和图像。"
---
## **概述**

Aspose.Slides 允许您访问和修改 PowerPoint 演示文稿中的表格单元格。本文介绍如何识别合并的表格单元格、删除单元格边框、在合并或拆分单元格后处理单元格编号、更改单元格的背景颜色以及在表格单元格中添加图像。示例展示了如何创建或打开演示文稿、从幻灯片中获取表格、通过单元格属性更新单元格格式，并将修改后的演示文稿保存为 PPTX 文件。

Aspose.Slides 使用从零开始的索引，以 `(column, row)` 的顺序访问表格单元格。

## **识别合并的表格单元格**

示例打开现有演示文稿，并将第一张幻灯片上的第一个形状作为表格访问。它假设幻灯片和形状存在且该形状是表格。随后遍历所有行和列，并使用 [isMergedCell](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#isMergedCell) 来识别位于合并区域的单元格。对于每个匹配项，打印 `row;column` 顺序的单元格坐标、[getRowSpan](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getRowSpan)、[getColSpan](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getColSpan) 以及区域起始坐标的 [getFirstRowIndex](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getFirstRowIndex) 和 [getFirstColumnIndex](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getFirstColumnIndex)。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("presentation_with_table.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    table = slide.getShapes().get_Item(0)

    row_count = table.getRows().size()
    for row_index in range(row_count):
        column_count = table.getColumns().size()
        for column_index in range(column_count):
            cell = table.get_Item(column_index, row_index)
            if cell.isMergedCell():
                print(f"Cell {row_index};{column_index} belongs to a merged region with RowSpan={cell.getRowSpan()} and ColSpan={cell.getColSpan()} starting at {cell.getFirstRowIndex()};{cell.getFirstColumnIndex()}.")
finally:
    presentation.dispose()
```

## **删除表格单元格边框**

创建一个 [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) 并使用 [addTable](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addTable) 在其第一张幻灯片上添加表格。列宽、行高和表格位置以点为单位指定。示例将四个单元格边框全部设置为 [FillType.NoFill](https://reference.aspose.com/slides/python-java/aspose.slides/filltype/)，使其不可见。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, FillType, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    column_widths = [50, 50, 50, 50]
    row_heights = [50, 30, 30, 30, 30]
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)

    for row in table.getRows():
        for cell in row:
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(FillType.NoFill)
            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(FillType.NoFill)
            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(FillType.NoFill)
            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(FillType.NoFill)

    presentation.save("table.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **合并表格单元格**

使用 [mergeCells](https://reference.aspose.com/slides/python-java/aspose.slides/table/#mergeCells) 将矩形范围的表格单元格合并为一个单元格。指定范围左上角和右下角的单元格。最后一个参数控制合并是否可以包含指定范围之外的单元格；`False` 将合并限制在该范围内。

示例创建一个 4×4 的表格，列宽和行高均为 70 点，然后将 `(1, 1)` 到 `(2, 2)` 的四个中心单元格合并。合并后的单元格跨越两列两行，而表格底层网格仍保留四列四行。要访问合并单元格的内容或格式，请使用其左上位置：本示例中的 `table.get_Item(1, 1)`。合并范围内的其他位置仍是表格网格的一部分，因此范围外单元格的索引不变。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    column_widths = [70, 70, 70, 70]
    row_heights = [70, 70, 70, 70]
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)

    table.mergeCells(table.get_Item(1, 1), table.get_Item(2, 2), False)

    presentation.save("merged_cells.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **拆分表格单元格**

在前面的示例中合并单元格保留了表格的网格。拆分单元格可能会引入新的网格列并改变其右侧单元格的列索引。Aspose.Slides 遵循 PowerPoint 的表格网格模型。

本示例创建一个 4×4 的表格，列宽和行高均为 70 点，并对单元格 `(1, 1)` 调用 [splitByWidth](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#splitByWidth)。将单元格 70 点宽度的一半传入，以创建两个等宽单元格。

拆分后，这两个半部可通过 `table.get_Item(1, 1)` 和 `table.get_Item(2, 1)` 访问。表格网格现在有五列：原本位于第 2 列和第 3 列的单元格分别移动到第 3 列和第 4 列。行索引保持不变。拆分后访问单元格时请使用更新后的列索引。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    column_widths = [70, 70, 70, 70]
    row_heights = [70, 70, 70, 70]
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)

    table.get_Item(1, 1).splitByWidth(table.get_Item(1, 1).getWidth() / 2)

    presentation.save("split_cells.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **按行或列跨度拆分合并的单元格**

为了准备合并的模板单元格进行数据填充，可使用 [splitByRowSpan](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#splitByRowSpan) 按现有行边界拆分，或使用 [splitByColSpan](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#splitByColSpan) 按列边界拆分。

`index` 参数计数拆分上部的行或左部的列；它相对于合并区域：

- 行拆分：`0 < index <` [getRowSpan](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getRowSpan)。
- 列拆分：`0 < index <` [getColSpan](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getColSpan)。

示例假设演示文稿的第一张幻灯片的第一个形状是表格，且 `(1, 2)` 与 `(1, 3)` 垂直合并。它从下方位置开始，使用 [getFirstColumnIndex](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getFirstColumnIndex) 和 [getFirstRowIndex](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getFirstRowIndex) 定位起点并检查两个跨度。`splitByRowSpan(1)` 随后将第 2 行和第 3 行分离用于产品名称。对于水平两列合并，请改用 `splitByColSpan(1)`。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("table_template.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    table = slide.getShapes().get_Item(0)

    selected_cell = table.get_Item(1, 3)
    first_column_index = selected_cell.getFirstColumnIndex()
    first_row_index = selected_cell.getFirstRowIndex()
    merged_cell = table.get_Item(first_column_index, first_row_index)

    if merged_cell.isMergedCell() and merged_cell.getRowSpan() == 2 and merged_cell.getColSpan() == 1:
        merged_cell.splitByRowSpan(1)

        # 检索拆分后表格中的结果单元格。
        upper_cell = table.get_Item(first_column_index, first_row_index)
        lower_cell = table.get_Item(first_column_index, first_row_index + 1)
        print(f"Upper cell merged: {upper_cell.isMergedCell()}")
        print(f"Lower cell merged: {lower_cell.isMergedCell()}")

        upper_cell.getTextFrame().setText("Product A")
        lower_cell.getTextFrame().setText("Product B")

        presentation.save("split_template.pptx", SaveFormat.Pptx)
    else:
        print("Select a merged region spanning exactly two rows and one column.")
finally:
    presentation.dispose()
```

表格网格和周围单元格索引保持不变。按坐标检索结果单元格；此处两者的跨度均为 1，且 [isMergedCell](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#isMergedCell) 输出 `False`。更大的区域在一次拆分后仍可能部分保持合并。

原始文本及其格式保留在上（或左）单元格中；新单元格为空，但继承填充、边框和边距等单元格格式。拆分后填充单元格并显式设置所需的文本格式。

保存的演示文稿包含独立的 “Product A” 与 “Product B” 单元格，保留了模板单元格的格式。参见 [Cell API Reference](https://reference.aspose.com/slides/python-java/aspose.slides/cell/) 获取详细信息。

## **更改表格单元格背景颜色**

本示例创建一个列宽为 150 点、行高为 50 点的表格。它使用 [setFillType](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#setFillType) 选择实心填充，并将 [getSolidFillColor](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#getSolidFillColor) 返回的颜色设为红色，应用于单元格 `(2, 3)`（第 3 列第 4 行）。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, FillType, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    column_widths = [150, 150, 150, 150]
    row_heights = [50, 50, 50, 50, 50]
    table = slide.getShapes().addTable(50, 50, column_widths, row_heights)

    cell = table.get_Item(2, 3)
    cell.getCellFormat().getFillFormat().setFillType(FillType.Solid)
    cell.getCellFormat().getFillFormat().getSolidFillColor().setColor(Color.RED)

    presentation.save("cell_background_color.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **在表格单元格内添加图像**

在运行本示例之前，将输入图像放置在工作目录中。示例使用 [Images.fromFile](https://reference.aspose.com/slides/python-java/aspose.slides/images/#fromFile) 加载图像，并使用 [addImage](https://reference.aspose.com/slides/python-java/aspose.slides/imagecollection/#addImage) 将其加入演示文稿的图像集合。随后将该图像分配给单元格 `(0, 0)`（表格的第一个单元格）的图片填充。

[PictureFillMode.Stretch](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillmode/) 将图像拉伸以填满单元格，可能会改变其宽高比。列宽和行高以点为单位。加载的图像在 `finally` 块中被释放，以确保在加入演示文稿后释放资源。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Images, FillType, PictureFillMode, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    column_widths = [150, 150, 150, 150]
    row_heights = [100, 100, 100, 100, 90]
    table = slide.getShapes().addTable(50, 50, column_widths, row_heights)

    image = Images.fromFile("aspose_logo.jpg")
    try:
        presentation_image = presentation.getImages().addImage(image)
    finally:
        image.dispose()

    table.get_Item(0, 0).getCellFormat().getFillFormat().setFillType(FillType.Picture)
    table.get_Item(0, 0).getCellFormat().getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch)
    table.get_Item(0, 0).getCellFormat().getFillFormat().getPictureFillFormat().getPicture().setImage(presentation_image)

    presentation.save("table_cell_with_image.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **常见问题**

**我可以为单个单元格的不同侧设置不同的线条粗细和样式吗？**

可以。单元格的 [上](https://reference.aspose.com/slides/python-java/aspose.slides/cellformat/#getBorderTop)/[下](https://reference.aspose.com/slides/python-java/aspose.slides/cellformat/#getBorderBottom)/[左](https://reference.aspose.com/slides/python-java/aspose.slides/cellformat/#getBorderLeft)/[右](https://reference.aspose.com/slides/python-java/aspose.slides/cellformat/#getBorderRight) 边框具有独立属性，因而每一侧的粗细和样式可以不同。

**如果在将图片设为单元格背景后更改列/行大小，图片会怎样？**

行为取决于 [填充模式](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillmode/)（stretch/tile）。在拉伸模式下，图片会随新单元格大小调整；在平铺模式下，平铺会重新计算。

**我可以为单元格的全部内容分配超链接吗？**

[超链接](/slides/zh/python-java/manage-hyperlinks/) 在单元格的文本框内部按文本（段落）级别设置，或在整个表格/形状级别设置。实际上，您可以将链接分配给段落或单元格中的全部文本。

**我可以在单个单元格内使用不同的字体吗？**

可以。单元格的文本框支持 [portions](https://reference.aspose.com/slides/python-java/aspose.slides/portion/)（文本片段），每个片段可以拥有独立的字体系列、样式、大小和颜色。