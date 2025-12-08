---
title: 使用 Python 管理演示文稿表格
linktitle: 管理表格
type: docs
weight: 10
url: /zh/python-net/manage-table/
keywords:
- 添加表格
- 创建表格
- 访问表格
- 宽高比
- 对齐文本
- 文本格式化
- 表格样式
- PowerPoint
- OpenDocument
- 演示文稿
- Python
- Aspose.Slides
description: "使用 Aspose.Slides for Python（通过 .NET）在 PowerPoint 和 OpenDocument 幻灯片中创建和编辑表格。发现简洁的代码示例，以简化您的表格工作流。"
---

## **概述**

PowerPoint 中的表格是呈现信息的高效方式。以单元格网格（行和列）排列的信息直观且易于理解。

Aspose.Slides 提供了 [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/) 类、[Cell](https://reference.aspose.com/slides/python-net/aspose.slides/cell/) 类以及其他相关类型，帮助您在任意演示文稿中创建、更新和管理表格。

## **从头创建表格**

本节展示如何在 Aspose.Slides 中通过向幻灯片添加表格形状、定义行列并设置精确尺寸来从头创建表格。您还将看到如何向单元格填充文本、调整对齐和边框以及自定义表格外观。

1. 创建 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例。
2. 通过索引获取幻灯片的引用。
3. 定义列宽数组。
4. 定义行高数组。
5. 向幻灯片添加一个 [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/)。
6. 遍历每个 [Cell](https://reference.aspose.com/slides/python-net/aspose.slides/cell/) 并设置其上、下、右、左边框。
7. 合并表格第一行的前两个单元格。
8. 访问 [Cell](https://reference.aspose.com/slides/python-net/aspose.slides/cell/) 的 [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/)。
9. 向 [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) 添加文本。
10. 保存修改后的演示文稿。

以下 Python 示例展示了如何在演示文稿中创建表格：
```python
import aspose.pydrawing as draw
import aspose.slides as slides

# 实例化表示演示文稿文件的 Presentation 类。
with slides.Presentation() as presentation:
    # 访问第一张幻灯片。
    slide = presentation.slides[0]

    # 定义列宽和行高。
    column_widths = [50, 50, 50]
    row_heights = [50, 30, 30, 30, 30]

    # 向幻灯片添加表格形状。
    table = slide.shapes.add_table(100, 50, column_widths, row_heights)

    # 为每个单元格设置边框格式。
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
        
    # 合并从 (第0行, 第0列) 到 (第1行, 第1列) 的单元格。
    table.merge_cells(table.rows[0][0], table.rows[1][1], False)

    # 向合并后的单元格添加文本。
    table.rows[0][0].text_frame.text = "Merged Cells"

    # 将演示文稿保存到磁盘。
    presentation.save("table.pptx", slides.export.SaveFormat.PPTX)
```


## **标准表格中的编号**

在标准表格中，单元格编号直观且从零开始。表格中的第一个单元格索引为 (0, 0)（第 0 列，第 0 行）。

例如，在一个有 4 列 4 行的表格中，单元格编号如下：

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

以下 Python 示例展示了如何使用此零基编号来引用单元格：
```python
for row_index in range(len(table.rows)):
    for column_index in range(len(table.rows[row_index])):
        cell = table.rows[row_index][column_index]
        cell.text_frame.text = f"({column_index}, {row_index})"
```


## **访问已有表格**

本节介绍如何使用 Aspose.Slides 在演示文稿中定位并操作现有表格。您将学习如何在幻灯片上查找表格、访问其行、列和单元格，以及更新内容或格式。

1. 创建 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例。
2. 通过索引获取包含表格的幻灯片的引用。
3. 遍历所有 [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) 对象，直到找到表格。
4. 使用 [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/) 对象来操作表格。
5. 保存修改后的演示文稿。

{{% alert color="info" %}}
如果幻灯片包含多个表格，最好通过其 `alternative_text` 属性搜索所需的表格。
{{% /alert %}}

以下 Python 示例展示了如何访问并操作已有表格：
```python
import aspose.pydrawing as draw
import aspose.slides as slides

# 实例化 Presentation 类以加载 PPTX 文件。
with slides.Presentation("sample.pptx") as presentation:
    # 访问第一张幻灯片。
    slide = presentation.slides[0]

    table = None

    # 遍历形状并引用找到的第一个表格。
    for shape in slide.shapes:
        if isinstance(shape, slides.Table):
            table = shape
            break

    # 设置第一行第一个单元格的文本。
    if table is not None:
        table.rows[0][0].text_frame.text = "Found"

    # 将修改后的演示文稿保存到磁盘。
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


## **对齐表格中的文本**

本节展示如何使用 Aspose.Slides 控制表格单元格内的文本对齐。您将学习为单元格设置水平和垂直对齐，以保持内容的清晰和一致。

1. 创建 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例。
2. 通过索引获取幻灯片的引用。
3. 向幻灯片添加一个 [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/) 对象。
4. 从表格中访问一个 [Cell](https://reference.aspose.com/slides/python-net/aspose.slides/cell/) 对象。
5. 垂直对齐文本。
6. 保存修改后的演示文稿。

以下 Python 示例展示了如何对齐表格中的文本：
```python
import aspose.pydrawing as draw
import aspose.slides as slides

# 创建 Presentation 类的实例。
with slides.Presentation() as presentation:
    # 访问第一张幻灯片。
    slide = presentation.slides[0]

    # 定义列宽和行高。
    column_widths = [40, 120, 120, 120]
    row_heights = [100, 100, 100, 100]

    # 向幻灯片添加表格形状。
    table = slide.shapes.add_table(100, 50, column_widths, row_heights)
    table.rows[0][0].text_frame.text = "Numbers"
    table.rows[1][0].text_frame.text = "10"
    table.rows[2][0].text_frame.text = "20"
    table.rows[3][0].text_frame.text = "30"

    # 将文本居中并设置垂直方向。
    cell = table.rows[0][0]
    cell.text_anchor_type = slides.TextAnchorType.CENTER
    cell.text_vertical_type = slides.TextVerticalType.VERTICAL270

    # 将演示文稿保存到磁盘。
    presentation.save("aligned_cell.pptx", slides.export.SaveFormat.PPTX)
```


## **在表格级别设置文本格式**

本节展示如何在 Aspose.Slides 中对表格级别应用文本格式，使每个单元格继承一致的统一样式。您将学习全局设置字体大小、对齐方式和边距。

1. 创建 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例。
2. 通过索引获取幻灯片的引用。
3. 向幻灯片添加一个 [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/)。
4. 设置文本的字体大小（字体高度）。
5. 设置段落对齐方式和边距。
6. 设置垂直文本方向。
7. 保存修改后的演示文稿。

以下 Python 示例展示了如何将首选的格式选项应用于表格中的文本：
```python
import aspose.pydrawing as draw
import aspose.slides as slides

# 创建 Presentation 类的实例
with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    table = slide.shapes.add_table(20, 20, [100, 50, 30], [30, 50, 30])

    # 为所有表格单元格设置字体大小。
    portion_format = slides.PortionFormat()
    portion_format.font_height = 25
    table.set_text_format(portion_format)

    # 为所有表格单元格设置右对齐文本和右边距。
    paragraph_format = slides.ParagraphFormat()
    paragraph_format.alignment = slides.TextAlignment.RIGHT
    paragraph_format.margin_right = 20
    table.set_text_format(paragraph_format)

    # 为所有表格单元格设置垂直文字方向。
    text_frame_format = slides.TextFrameFormat()
    text_frame_format.text_vertical_type = slides.TextVerticalType.VERTICAL
    table.set_text_format(text_frame_format)

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


## **应用内置表格样式**

Aspose.Slides 让您直接在代码中使用预定义样式格式化表格。示例演示了创建表格、应用内置样式并保存结果——一种确保一致、专业格式的高效方式。
```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    table = slide.shapes.add_table(10, 10, [100, 150], [5, 5, 5])

    table.style_preset = slides.TableStylePreset.DARK_STYLE1

    presentation.save("table.pptx", slides.export.SaveFormat.PPTX)
```


## **锁定表格的宽高比**

形状的宽高比是其尺寸的比例。Aspose.Slides 提供了 `aspect_ratio_locked` 属性，可用于锁定表格和其他形状的宽高比。

以下 Python 示例展示了如何锁定表格的宽高比：
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

**我可以为整个表格及其单元格中的文本启用从右到左 (RTL) 阅读方向吗？**

是的。表格公开了 [right_to_left](https://reference.aspose.com/slides/python-net/aspose.slides/table/right_to_left/) 属性，段落则具有 [ParagraphFormat.right_to_left](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/right_to_left/)。同时使用可确保单元格内部的正确 RTL 顺序和渲染。

**如何防止用户在最终文件中移动或调整表格大小？**

使用 [shape locks](/slides/zh/python-net/applying-protection-to-presentation/) 禁用移动、调整大小、选择等。这些锁同样适用于表格。

**是否支持在单元格内部将图像插入为背景？**

是的。您可以为单元格设置 [picture fill](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/)，图像将根据所选模式（拉伸或平铺）覆盖单元格区域。