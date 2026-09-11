---
title: 使用 Python 在演示文稿中管理表格单元格
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
description: "使用 Aspose.Slides for Python via Java，轻松在 PowerPoint 中管理表格单元格。快速掌握访问、修改和样式化单元格，实现无缝幻灯片自动化。"
---
## **概述**

Aspose.Slides 允许您访问和修改 PowerPoint 演示文稿中的表格单元格。本文说明了如何识别合并的表格单元格、删除单元格边框、在合并或拆分单元格后处理单元格编号、更改单元格的背景颜色以及在表格单元格内添加图像。示例展示了如何创建或打开演示文稿、从幻灯片获取表格、通过单元格属性更新单元格格式，以及将修改后的演示文稿保存为 PPTX 文件。

## **识别合并的表格单元格**

1. 创建一个 [Presentation](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/) 类的实例。  
2. 从第一张幻灯片获取表格。  
3. 迭代表格的行和列以查找合并的单元格。  
4. 发现合并单元格时打印消息。

下面的 Python 代码演示了如何识别演示文稿中的合并表格单元格：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Table

presentation = Presentation("SomePresentationWithTable.pptx")
try:
    # 假设第一张幻灯片上的第一个形状是表格。
    shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    if isinstance(shape, Table):
        table = shape
        for i in range(table.getRows().size()):
            for j in range(table.getColumns().size()):
                current_cell = table.getRows().get_Item(i).get_Item(j)
                if current_cell.isMergedCell():
                    print(f"Cell {i};{j} is part of a merged cell with RowSpan={current_cell.getRowSpan()} and ColSpan={current_cell.getColSpan()} starting from Cell {current_cell.getFirstRowIndex()};{current_cell.getFirstColumnIndex()}.")
    else:
        print("The first shape is not a table.")
finally:
    presentation.dispose()
```

## **删除表格单元格边框**

1. 创建一个 [Presentation](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/) 类的实例。  
2. 通过索引获取幻灯片的引用。  
3. 定义列宽列表。  
4. 定义行高列表。  
5. 通过 [addTable](https://reference.aspose.com/slides/zh/python-java/aspose.slides/shapecollection/#addTable) 方法将表格添加到幻灯片。  
6. 遍历每个单元格，清除上、下、左、右四个边框。  
7. 将修改后的演示文稿保存为 PPTX 文件。

下面的 Python 代码演示了如何删除表格单元格的边框：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, FillType, SaveFormat

presentation = Presentation()
try:
    # 访问第一张幻灯片。
    slide = presentation.getSlides().get_Item(0)

    # 定义列宽和行高。
    column_widths = [50, 50, 50, 50]
    row_heights = [50, 30, 30, 30, 30]

    # 将表格添加到幻灯片。
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)

    # 为每个单元格设置边框格式。
    for row in table.getRows():
        for cell in row:
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(FillType.NoFill)
            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(FillType.NoFill)
            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(FillType.NoFill)
            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(FillType.NoFill)

    # 将演示文稿保存为 PPTX 文件。
    presentation.save("table_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **合并单元格后的编号**

如果我们合并两对单元格 (1, 1) 与 (2, 1) 以及 (1, 2) 与 (2, 2)，得到的表格仍保留其单元格编号。以下 Python 代码演示了该过程：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, FillType, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    # 访问第一张幻灯片。
    slide = presentation.getSlides().get_Item(0)

    # 定义列宽和行高。
    column_widths = [70, 70, 70, 70]
    row_heights = [70, 70, 70, 70]

    # 将表格添加到幻灯片。
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)

    # 为每个单元格设置边框格式。
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


    # 合并单元格 (1, 1) 和 (2, 1)。
    table.mergeCells(table.get_Item(1, 1), table.get_Item(2, 1), False)

    # 合并单元格 (1, 2) 和 (2, 2)。
    table.mergeCells(table.get_Item(1, 2), table.get_Item(2, 2), False)

    # 将演示文稿保存为 PPTX 文件。
    presentation.save("MergeCells_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

随后我们进一步合并单元格，将 (1, 1) 与 (1, 2) 合并。结果是表格中心出现一个大的合并单元格：

```python
import jpype
import asposeslides

if not jpue.isJVMStarted():
    jpue.startJVM()

from asposeslides.api import Presentation, FillType, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    # 访问第一张幻灯片。
    slide = presentation.getSlides().get_Item(0)

    # 定义列宽和行高。
    column_widths = [70, 70, 70, 70]
    row_heights = [70, 70, 70, 70]

    # 将表格添加到幻灯片。
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)

    # 为每个单元格设置边框格式。
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


    # 合并单元格 (1, 1) 和 (2, 1)。
    table.mergeCells(table.get_Item(1, 1), table.get_Item(2, 1), False)

    # 合并单元格 (1, 2) 和 (2, 2)。
    table.mergeCells(table.get_Item(1, 2), table.get_Item(2, 2), False)

    # 合并单元格 (1, 1) 和 (1, 2)。
    table.mergeCells(table.get_Item(1, 1), table.get_Item(1, 2), True)

    # 将演示文稿保存为 PPTX 文件。
    presentation.save("MergeCells_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **拆分单元格后的编号**

在前面的示例中，合并表格单元格并未改变其他单元格的编号。

这一次，我们使用一个普通表格（没有合并单元格），然后尝试拆分单元格 (1, 1) 以得到一个特殊的表格。您可能需要注意该表格的编号，看起来可能有些奇怪。但这正是 Microsoft PowerPoint 对表格单元格的编号方式，Aspose.Slides 也遵循相同规则。

下面的 Python 代码演示了我们描述的过程：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, FillType, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    # 访问第一张幻灯片。
    slide = presentation.getSlides().get_Item(0)

    # 定义列宽和行高。
    column_widths = [70, 70, 70, 70]
    row_heights = [70, 70, 70, 70]

    # 将表格添加到幻灯片。
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)

    # 为每个单元格设置边框格式。
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


    # 拆分单元格 (1, 1)。
    table.get_Item(1, 1).splitByWidth(table.get_Item(2, 1).getWidth() / 2)

    # 将演示文稿保存为 PPTX 文件。
    presentation.save("SplitCells_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **更改表格单元格的背景颜色**

下面的 Python 代码展示了如何更改表格单元格的背景颜色：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, FillType, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    # 访问第一张幻灯片。
    slide = presentation.getSlides().get_Item(0)

    # 定义列宽和行高。
    column_widths = [150, 150, 150, 150]
    row_heights = [50, 50, 50, 50, 50]

    # 将表格添加到幻灯片。
    table = slide.getShapes().addTable(50, 50, column_widths, row_heights)

    # 设置单元格的背景颜色。
    cell = table.get_Item(2, 3)
    cell.getCellFormat().getFillFormat().setFillType(FillType.Solid)
    cell.getCellFormat().getFillFormat().getSolidFillColor().setColor(Color.RED)

    # 将演示文稿保存为 PPTX 文件。
    presentation.save("cell_background_color.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **在表格单元格内添加图像**

1. 创建一个 [Presentation](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/) 类的实例。  
2. 通过索引获取幻灯片的引用。  
3. 定义列宽列表。  
4. 定义行高列表。  
5. 通过 [addTable](https://reference.aspose.com/slides/zh/python-java/aspose.slides/shapecollection/#addTable) 方法将表格添加到幻灯片。  
6. 使用 [Images.fromFile](https://reference.aspose.com/slides/zh/python-java/aspose.slides/images/#fromFile) 加载图像文件。  
7. 将图像添加到演示文稿以创建 [PPImage](https://reference.aspose.com/slides/zh/python-java/aspose.slides/ppimage/) 对象。  
8. 将表格单元格的 [FillFormat](https://reference.aspose.com/slides/zh/python-java/aspose.slides/fillformat/) 填充类型设置为 [FillType.Picture](https://reference.aspose.com/slides/zh/python-java/aspose.slides/filltype/#Picture)。  
9. 将图像添加到表格的第一个单元格。  
10. 将修改后的演示文稿保存为 PPTX 文件。

下面的 Python 代码演示了在创建表格时如何将图像放入表格单元格：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Images, FillType, PictureFillMode, SaveFormat

presentation = Presentation()
try:
    # 访问第一张幻灯片。
    slide = presentation.getSlides().get_Item(0)

    # 定义列宽和行高。
    column_widths = [150, 150, 150, 150]
    row_heights = [100, 100, 100, 100, 90]

    # 将表格添加到幻灯片。
    table = slide.getShapes().addTable(50, 50, column_widths, row_heights)

    # 从图像文件创建演示文稿图像。
    image = Images.fromFile("image.jpg")
    try:
        picture = presentation.getImages().addImage(image)
    finally:
        image.dispose()

    # 将图像添加到第一个表格单元格。
    cell_format = table.get_Item(0, 0).getCellFormat()
    cell_format.getFillFormat().setFillType(FillType.Picture)
    cell_format.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch)
    cell_format.getFillFormat().getPictureFillFormat().getPicture().setImage(picture)

    # 将演示文稿保存为 PPTX 文件。
    presentation.save("Image_In_TableCell_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **常见问题解答**

**能否为单个单元格的不同边设置不同的线粗和样式？**

可以。单元格的 [top](https://reference.aspose.com/slides/zh/python-java/aspose.slides/cellformat/#getBorderTop)/[bottom](https://reference.aspose.com/slides/zh/python-java/aspose.slides/cellformat/#getBorderBottom)/[left](https://reference.aspose.com/slides/zh/python-java/aspose.slides/cellformat/#getBorderLeft)/[right](https://reference.aspose.com/slides/zh/python-java/aspose.slides/cellformat/#getBorderRight) 边框拥有各自的属性，因而每一侧的粗细和样式都可以不同。这与本文中演示的针对单元格的按侧边框控制逻辑一致。

**在将图片设为单元格背景后，如果更改列/行尺寸，图片会怎样？**

行为取决于 [fill mode](https://reference.aspose.com/slides/zh/python-java/aspose.slides/picturefillmode/)（stretch/tilе）。如果是拉伸，图片会随新的单元格大小调整；如果是平铺，则会重新计算平铺方式。本文中已说明单元格里图片的显示模式。

**能否为单元格的所有内容分配超链接？**

[Hyperlinks](/slides/zh/python-java/manage-hyperlinks/) 可以在单元格文本框内部的文本（段落）级别设置，也可以在整个表格/形状级别设置。实践中，您可以将链接分配给文本片段或整个单元格的全部文本。

**能否在单个单元格内使用不同的字体？**

可以。单元格的文本框支持 [portions](https://reference.aspose.com/slides/zh/python-java/aspose.slides/portion/)（即运行），每个 Portion 可以拥有独立的格式，包括字体族、样式、大小和颜色。