---
title: 使用 Python 管理 PowerPoint 表格中的行和列
linktitle: 行和列
type: docs
weight: 20
url: /zh/python-java/manage-rows-and-columns/
keywords:
- 表格行
- 表格列
- 首行
- 表头
- 克隆行
- 克隆列
- 复制行
- 复制列
- 删除行
- 删除列
- 行文本格式化
- 列文本格式化
- 表格样式
- PowerPoint
- 演示文稿
- Python
- Aspose.Slides
description: "使用 Aspose.Slides for Python via Java 在 PowerPoint 中管理表格行列，并加速演示文稿的编辑和数据更新。"
---
## **介绍**

Aspose.Slides for Python via Java 让您能够通过 [Table](https://reference.aspose.com/slides/python-java/aspose.slides/table/) 类在 PowerPoint 演示文稿中管理表格的结构和格式。您可以指定标题行，克隆或删除行和列，并对整行或整列应用文本格式。

本文使用 Python 示例解释这些操作。它还展示了如何获取表格的样式预设，以便重复使用。表格的行列索引从零开始。

## **控制行高**

使用 [Row.setMinimalHeight](https://reference.aspose.com/slides/python-java/aspose.slides/row/#setMinimalHeight) 可以设置行的最小高度（单位为磅）。这只是下限，而非固定高度。 [Row.getHeight](https://reference.aspose.com/slides/python-java/aspose.slides/row/#getHeight) 返回实际高度。通过 [Table.getRows](https://reference.aspose.com/slides/python-java/aspose.slides/table/#getRows) 访问行。

示例加载 [row-height-input.pptx](row-height-input.pptx)，该文件在第一张幻灯片的首个形状中包含一个表格。其第一行起始高度为 70 磅。单元格使用 18 磅 Arial 字体、自动换行，并且上下边距为 6 磅；第二列的较长文本会换成多行。示例将最小高度提升至 100 磅，然后降低到 20 磅，在每次更改后打印实际高度，并保存两个结果。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("row-height-input.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    table = slide.getShapes().get_Item(0)
    row = table.getRows().get_Item(0)

    row.setMinimalHeight(100)
    print(f"Increased: minimum = {row.getMinimalHeight():.1f}, actual = {row.getHeight():.1f} pt")
    presentation.save("row-height-increased.pptx", SaveFormat.Pptx)

    row.setMinimalHeight(20)
    print(f"Decreased: minimum = {row.getMinimalHeight():.1f}, actual = {row.getHeight():.1f} pt")
    presentation.save("row-height-decreased.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

使用提供的演示文稿时，增加最小值会为行添加空间。降低最小值会移除多余的空间，但实际高度仍大于 20 磅，因为文本和单元格边距需要更多空间。仅降低最小值无法将行的高度压低到内容所需空间以下。

实际高度受以下多个因素影响：

- **文本和字体大小：** 较长的文本、显式换行或更大的字体可能需要更多垂直空间。
- **换行和列宽度：** 启用换行后，使用 [Column.setWidth](https://reference.aspose.com/slides/python-java/aspose.slides/column/#setWidth) 缩小列宽会产生更多行。更宽的列可降低垂直所需空间。
- **单元格边距：** [Cell.setMarginTop](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#setMarginTop) 和 [Cell.setMarginBottom](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#setMarginBottom) 增加垂直空间。[Cell.setMarginLeft](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#setMarginLeft) 和 [Cell.setMarginRight](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#setMarginRight) 减少文本可用宽度，可能导致额外换行。

对于此未合并单元格的表格，需占用最大垂直空间的单元格决定整行的内容驱动下限。要缩短行高，可能需要缩短文本、减小字号或边距，或增宽列宽。

下图展示了相同缩放比例下的同一表格。示例结果中，实际高度分别为 70、100 和 55.2 磅：最终行仍高于 20 磅的最小值。文本的精确测量会随环境中可用的字体而有所差异。下载保存的结果文件： [increased minimum](row-height-increased.pptx) 和 [decreased minimum](row-height-decreased.pptx)。

| 原始：最小 70 pt，实际 70 pt | 增加后：最小 100 pt，实际 100 pt | 减少后：最小 20 pt，实际 55.2 pt |
| --- | --- | --- |
| ![原始表格，第一行 70 磅。](row-height-before.png) | ![将第一行最小高度增加至 100 磅后的表格。](row-height-increased.png) | ![将第一行最小高度降低至 20 磅后的表格；换行文本使行仍高于最小值。](row-height-decreased.png) |

## **将第一行设为标题**

使用 [setFirstRow](https://reference.aspose.com/slides/python-java/aspose.slides/table/#setFirstRow) 方法将首行标记为标题格式。其外观取决于表格所应用的表格样式。

1. 使用 [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) 类加载演示文稿。  
2. 访问第一张幻灯片。  
3. 获取幻灯片上作为首个形状保存的表格。  
4. 为其第一行启用标题格式。  
5. 保存修改后的演示文稿。

示例需要在第一张幻灯片的首个形状中包含表格的 `table.pptx`。它为第一行启用标题格式并保存为 `First_row_header.pptx`。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("table.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    table = slide.getShapes().get_Item(0)
    table.setFirstRow(True)

    presentation.save("First_row_header.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **克隆表格行或列**

克隆行或列以复用其内容和格式。您可以将副本追加到表格末尾，或插入到指定位置。

1. 使用 [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) 类加载演示文稿。  
2. 访问第一张幻灯片。  
3. 定义列宽和行高。  
4. 使用 [addTable](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addTable) 方法添加表格。  
5. 克隆所需的行。  
6. 克隆所需的列。  
7. 保存修改后的演示文稿。

示例需要至少包含一张幻灯片的 `Test.pptx`。它创建了一个三列五行的表格，尺寸以磅为单位。随后将第一行和第一列的副本追加到表格末尾，再在索引 3（即第四色）处插入第二行和第二列的副本。结果表格为七行五列。`False` 参数禁用对相邻合并行或列的克隆；此表格没有合并单元格。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("Test.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    column_widths = jpype.JArray(jpype.JDouble)([50, 50, 50])
    row_heights = jpype.JArray(jpype.JDouble)([50, 30, 30, 30, 30])
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)

    table.get_Item(0, 0).getTextFrame().setText("Row 1 Cell 1")
    table.get_Item(1, 0).getTextFrame().setText("Row 1 Cell 2")
    table.getRows().addClone(table.getRows().get_Item(0), False)

    table.get_Item(0, 1).getTextFrame().setText("Row 2 Cell 1")
    table.get_Item(1, 1).getTextFrame().setText("Row 2 Cell 2")
    table.getRows().insertClone(3, table.getRows().get_Item(1), False)

    table.getColumns().addClone(table.getColumns().get_Item(0), False)
    table.getColumns().insertClone(3, table.getColumns().get_Item(1), False)

    presentation.save("table_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **从表格中删除行或列**

删除表格中不再需要的行或列。删除后，后续行或列的索引会相应移动。

1. 使用 [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) 类创建演示文稿。  
2. 访问第一张幻灯片。  
3. 定义列宽和行高。  
4. 使用 [addTable](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addTable) 方法添加表格。  
5. 删除第二行和第二列。  
6. 保存修改后的演示文稿。

此示例创建了一个 3×3 的表格，并删除索引为 1 的行和列，生成一个 2×2 的表格并保存为 `TestTable_out.pptx`。尺寸以磅为单位。`False` 参数禁用对相邻合并行或列的删除；该表格没有合并单元格。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    column_widths = jpype.JArray(jpype.JDouble)([100, 50, 30])
    row_heights = jpype.JArray(jpype.JDouble)([30, 50, 30])
    table = slide.getShapes().addTable(100, 100, column_widths, row_heights)

    table.getRows().removeAt(1, False)
    table.getColumns().removeAt(1, False)

    presentation.save("TestTable_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **在表格行级别设置文本格式**

对整行应用文本格式，以保持其单元格的一致性。您可以设置字体属性、段落格式和文字方向，而无需逐个单元格单独设置。

1. 使用 [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) 类加载演示文稿。  
2. 访问第一张幻灯片上的表格。  
3. 对第一行使用 [setFontHeight](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setFontHeight)。  
4. 对第一行使用 [setAlignment](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setAlignment) 和 [setMarginRight](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setMarginRight)。  
5. 对第二行使用 [setTextVerticalType](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setTextVerticalType)。  
6. 保存修改后的演示文稿。

示例需要在第一张幻灯片的首个形状中包含表格且至少有两行的 `table.pptx`。它对第一行应用 25 磅文字、右对齐以及 20 磅的右段落边距，然后在第二行设置垂直文本。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, PortionFormat, ParagraphFormat, TextFrameFormat, TextAlignment, TextVerticalType

presentation = Presentation("table.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    table = slide.getShapes().get_Item(0)

    portion_format = PortionFormat()
    portion_format.setFontHeight(25)
    table.getRows().get_Item(0).setTextFormat(portion_format)

    paragraph_format = ParagraphFormat()
    paragraph_format.setAlignment(TextAlignment.Right)
    paragraph_format.setMarginRight(20)
    table.getRows().get_Item(0).setTextFormat(paragraph_format)

    text_frame_format = TextFrameFormat()
    text_frame_format.setTextVerticalType(TextVerticalType.Vertical)
    table.getRows().get_Item(1).setTextFormat(text_frame_format)

    presentation.save("row_formatting.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **在表格列级别设置文本格式**

对整列应用文本格式，以保持其单元格的一致性。您可以设置字体属性、段落格式和文字方向，而无需逐个单元格单独设置。

1. 使用 [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) 类加载演示文稿。  
2. 访问第一张幻灯片上的表格。  
3. 对第一列使用 [setFontHeight](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setFontHeight)。  
4. 对第一列使用 [setAlignment](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setAlignment) 和 [setMarginRight](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setMarginRight)。  
5. 对第二列使用 [setTextVerticalType](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setTextVerticalType)。  
6. 保存修改后的演示文稿。

示例需要在第一张幻灯片的首个形状中包含表格且至少有两列的 `table.pptx`。它对第一列应用 25 磅文字、右对齐以及 20 磅的右段落边距，然后在第二列设置垂直文本。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, PortionFormat, ParagraphFormat, TextFrameFormat, TextAlignment, TextVerticalType

presentation = Presentation("table.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    table = slide.getShapes().get_Item(0)

    portion_format = PortionFormat()
    portion_format.setFontHeight(25)
    table.getColumns().get_Item(0).setTextFormat(portion_format)

    paragraph_format = ParagraphFormat()
    paragraph_format.setAlignment(TextAlignment.Right)
    paragraph_format.setMarginRight(20)
    table.getColumns().get_Item(0).setTextFormat(paragraph_format)

    text_frame_format = TextFrameFormat()
    text_frame_format.setTextVerticalType(TextVerticalType.Vertical)
    table.getColumns().get_Item(1).setTextFormat(text_frame_format)

    presentation.save("column_formatting.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **获取表格样式属性**

使用 [getStylePreset](https://reference.aspose.com/slides/python-java/aspose.slides/table/#getStylePreset) 方法获取表格所应用的预设样式，并可在另一表格中复用。该方法返回预设本身，而非单元格的个别格式覆盖。

示例创建表格，应用 [TableStylePreset.DarkStyle1](https://reference.aspose.com/slides/python-java/aspose.slides/tablestylepreset/#DarkStyle1)，随后读取该预设。它打印对应 `DarkStyle1` 的整数值，并将表格保存为 `table.pptx`。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TableStylePreset

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    column_widths = jpype.JArray(jpype.JDouble)([100, 150])
    row_heights = jpype.JArray(jpype.JDouble)([5, 5, 5])
    table = slide.getShapes().addTable(10, 10, column_widths, row_heights)
    table.setStylePreset(TableStylePreset.DarkStyle1)

    style_preset = table.getStylePreset()
    print(style_preset)

    presentation.save("table.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **常见问题**

**我可以将 PowerPoint 主题/样式应用于已创建的表格吗？**

是的。表格会继承幻灯片/版面/母版的主题，但您仍然可以在此基础上覆盖填充、边框和文字颜色。

**我可以像在 Excel 中那样对表格行进行排序吗？**

不能，Aspose.Slides 表格不具备内置的排序或筛选功能。请先在内存中对数据进行排序，然后按照该顺序重新填充表格行。

**我可以在保持特定单元格自定义颜色的同时使用分带（条纹）列吗？**

可以。启用分带列后，您可以对特定单元格进行本地格式覆盖；单元格级别的格式会优先于表格样式。