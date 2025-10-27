---
title: Manage Presentation Tables with Python
linktitle: Manage Table
type: docs
weight: 10
url: /zh/python-net/manage-table/
keywords:
- add table
- create table
- access table
- aspect ratio
- align text
- text formatting
- table style
- PowerPoint
- OpenDocument
- presentation
- Python
- Aspose.Slides
description: "Create & edit tables in PowerPoint and OpenDocument slides with Aspose.Slides for Python via .NET. Discover simple code examples to streamline your table workflows."
---

## **概述**

PowerPoint 中的表格是呈现信息的高效方式。将信息以单元格（行和列）的网格形式组织，直观且易于理解。

Aspose.Slides 提供了 [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/) 类、[Cell](https://reference.aspose.com/slides/python-net/aspose.slides/cell/) 类以及其他相关类型，帮助您在任何演示文稿中创建、更新和管理表格。

## **从头创建表格**

本节展示如何在 Aspose.Slides 中通过向幻灯片添加表格形状、定义行列以及设置精确尺寸来从头创建表格。您还将看到如何向单元格填充文本、调整对齐和边框以及自定义表格外观。

1. 创建一个 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例。  
2. 通过索引获取幻灯片的引用。  
3. 定义列宽数组。  
4. 定义行高数组。  
5. 向幻灯片添加一个 [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/)。  
6. 遍历每个 [Cell]，并设置其上、下、左、右边框的格式。  
7. 合并表格第一行的前两个单元格。  
8. 访问 [Cell] 的 [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/)。  
9. 向 [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) 添加文本。  
10. 保存修改后的演示文稿。

下面的 Python 示例演示如何在演示文稿中创建表格：

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Instantiate the Presentation class that represents a presentation file.
with slides.Presentation() as presentation:
    # Access the first slide.
    slide = presentation.slides[0]

    # Define column widths and row heights.
    column_widths = [50, 50, 50]
    row_heights = [50, 30, 30, 30, 30]

    # Add a table shape to the slide.
    table = slide.shapes.add_table(100, 50, column_widths, row_heights)

    # Set the border format for each cell.
    for row in table.rows:
        for cell in row:
            cell.cell_format.border_top.fill_format.fill_type = slides.FillType.SOLID
            cell.cell_format.border_top.fill_format.solid_fill_color.color = draw.Color.red
            cell.cell_format.border_top.width = 5

            cell.cell_format.border_bottom.fill_format.fill_type = slides.FillType.SOLID
            cell.cell_format.border_bottom.fill_format.solid_fill_color.color= draw.Color.red
            cell.cell_format.border_bottom.width = 5

            cell.cell_format.border_left.fill_format.fill_type = slides.FillType.SOLID
            cell.cell_format.border_left.fill_format.solid_fill_color.color =draw.Color.red
            cell.cell_format.border_left.width = 5

            cell.cell_format.border_right.fill_format.fill_type = slides.FillType.SOLID
            cell.cell_format.border_right.fill_format.solid_fill_color.color = draw.Color.red
            cell.cell_format.border_right.width = 5
        
    # Merge cells from (row 0, col 0) to (row 1, col 1).
    table.merge_cells(table.rows[0][0], table.rows[1][1], False)

    # Add text to the merged cell.
    table.rows[0][0].text_frame.text = "Merged Cells"

    # Save the presentation to disk.
    presentation.save("table.pptx", slides.export.SaveFormat.PPTX)
```

## **标准表格中的编号**

在标准表格中，单元格编号直观且从零开始。表格中的第一个单元格索引为 (0, 0)（列 0，行 0）。

例如，具有 4 列 4 行的表格，其单元格编号如下：

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

以下 Python 示例演示如何使用此零基编号引用单元格：

```python
for row_index in range(len(table.rows)):
    for column_index in range(len(table.rows[row_index])):
        cell = table.rows[row_index][column_index]
        cell.text_frame.text = f"({column_index}, {row_index})"
```

## **访问现有表格**

本节说明如何使用 Aspose.Slides 在演示文稿中定位并操作现有表格。您将学习如何在幻灯片上找到表格、访问其行、列和单元格，并更新内容或格式。

1. 创建一个 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例。  
2. 通过索引获取包含表格的幻灯片引用。  
3. 遍历所有 [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) 对象，直到找到表格。  
4. 使用 [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/) 对象来操作表格。  
5. 保存修改后的演示文稿。

{{% alert color="info" %}}
如果幻灯片包含多个表格，最好通过其 `alternative_text` 属性搜索所需的表格。
{{% /alert %}}

下面的 Python 示例演示如何访问并操作现有表格：

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Instantiate the Presentation class to load a PPTX file.
with slides.Presentation("sample.pptx") as presentation:
    # Access the first slide.
    slide = presentation.slides[0]

    table = None

    # Iterate through shapes and reference the first table found.
    for shape in slide.shapes:
        if isinstance(shape, slides.Table):
            table = shape
            break

    # Set the text of the first cell in the first row.
    if table is not None:
        table.rows[0][0].text_frame.text = "Found"

    # Save the modified presentation to disk.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **对齐表格中的文本**

本节展示如何使用 Aspose.Slides 控制表格单元格内文本的对齐方式。您将学习为单元格设置水平和垂直对齐，以保持内容清晰一致。

1. 创建一个 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例。  
2. 通过索引获取幻灯片的引用。  
3. 向幻灯片添加一个 [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/) 对象。  
4. 从表格中访问一个 [Cell](https://reference.aspose.com/slides/python-net/aspose.slides/cell/) 对象。  
5. 垂直对齐文本。  
6. 保存修改后的演示文稿。

下面的 Python 示例演示如何对表格中的文本进行对齐：

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Create an instance of the Presentation class.
with slides.Presentation() as presentation:
    # Access the first slide.
    slide = presentation.slides[0]

    # Define column widths and row heights.
    column_widths = [40, 120, 120, 120]
    row_heights = [100, 100, 100, 100]

    # Add a table shape to the slide.
    table = slide.shapes.add_table(100, 50, column_widths, row_heights)
    table.rows[0][0].text_frame.text = "Numbers"
    table.rows[1][0].text_frame.text = "10"
    table.rows[2][0].text_frame.text = "20"
    table.rows[3][0].text_frame.text = "30"

    # Center the text and set vertical orientation.
    cell = table.rows[0][0]
    cell.text_anchor_type = slides.TextAnchorType.CENTER
    cell.text_vertical_type = slides.TextVerticalType.VERTICAL270

    # Save the presentation to disk.
    presentation.save("aligned_cell.pptx", slides.export.SaveFormat.PPTX)
```

## **在表格级别设置文本格式**

本节展示如何在 Aspose.Slides 中对表格级别应用文本格式，使每个单元格继承一致的统一样式。您将学习全局设置字体大小、对齐方式和边距。

1. 创建一个 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例。  
2. 通过索引获取幻灯片的引用。  
3. 向幻灯片添加一个 [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/)。  
4. 为文本设置字体大小（字体高度）。  
5. 设置段落对齐和边距。  
6. 设置垂直文本方向。  
7. 保存修改后的演示文稿。

下面的 Python 示例演示如何将首选的格式化选项应用于表格中的文本：

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Creates an instance of the Presentation class
with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    table = slide.shapes.add_table(20, 20, [100, 50, 30], [30, 50, 30])

    # Set the font size for all table cells.
    portion_format = slides.PortionFormat()
    portion_format.font_height = 25
    table.set_text_format(portion_format)

    # Set right-aligned text and a right margin for all table cells.
    paragraph_format = slides.ParagraphFormat()
    paragraph_format.alignment = slides.TextAlignment.RIGHT
    paragraph_format.margin_right = 20
    table.set_text_format(paragraph_format)

    # Set the vertical text orientation for all table cells.
    text_frame_format = slides.TextFrameFormat()
    text_frame_format.text_vertical_type = slides.TextVerticalType.VERTICAL
    table.set_text_format(text_frame_format)

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **应用内置表格样式**

Aspose.Slides 允许您在代码中使用预定义样式格式化表格。示例演示如何创建表格、应用内置样式并保存结果——这是一种确保一致、专业格式的高效方式。

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    table = slide.shapes.add_table(10, 10, [100, 150], [5, 5, 5])

    table.style_preset = slides.TableStylePreset.DARK_STYLE1

    presentation.save("table.pptx", slides.export.SaveFormat.PPTX)
```

## **锁定表格的宽高比**

形状的宽高比是其尺寸的比例。Aspose.Slides 提供 `aspect_ratio_locked` 属性，允许您锁定表格及其他形状的宽高比。

下面的 Python 示例演示如何锁定表格的宽高比：

```py
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    table = slide.shapes.add_table(20, 20, [100, 50, 30], [30, 50, 30])

    print(f"Lock aspect ratio set: {table.shape_lock.aspect_ratio_locked}")
    table.shape_lock.aspect_ratio_locked = not table.shape_lock.aspect_ratio_locked
    print(f"Lock aspect ratio set: {table.shape_lock.aspect_ratio_locked}")

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **常见问题**

**我能否为整个表格及其单元格中的文本启用从右到左 (RTL) 阅读方向？**  
可以。表格公开了 [right_to_left](https://reference.aspose.com/slides/python-net/aspose.slides/table/right_to_left/) 属性，段落则有 [ParagraphFormat.right_to_left](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/right_to_left/)。两者结合使用即可在单元格内确保正确的 RTL 顺序和渲染。

**如何防止用户在最终文件中移动或调整表格大小？**  
使用 [shape locks](/slides/zh/python-net/applying-protection-to-presentation/) 可禁用移动、调整大小、选择等。这些锁定同样适用于表格。

**是否支持在单元格内插入图片作为背景？**  
支持。您可以为单元格设置 [picture fill](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/)，图片将根据所选模式（拉伸或平铺）覆盖单元格区域。