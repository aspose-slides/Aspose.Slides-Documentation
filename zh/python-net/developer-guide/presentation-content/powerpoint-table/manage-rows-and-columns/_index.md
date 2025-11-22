---
title: 使用 Python 管理 PowerPoint 表格中的行和列
linktitle: 行和列
type: docs
weight: 20
url: /zh/python-net/manage-rows-and-columns/
keywords:
- 表格行
- 表格列
- 第一行
- 表格标题
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
description: "使用 Aspose.Slides for Python 通过 .NET 在 PowerPoint 和 OpenDocument 中管理表格行和列，加快演示文稿编辑和数据更新。"
---

## **概述**

本文介绍如何使用 Aspose.Slides for Python 管理 PowerPoint 和 OpenDocument 演示文稿中的表格行和列。您将学习如何添加、插入、克隆和删除行或列，将首行标记为标题，调整大小和布局，以及在行或列级别应用文本和样式格式化。每个任务均使用基于 [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/) API 的简洁、独立的代码片段进行演示，帮助您快速在幻灯片上找到表格并重新构造其结构以匹配设计。

## **将首行设为标题**

将表格的首行标记为标题，以清晰地区分列标题和数据。在 Aspose.Slides for Python 中，只需启用表格的 *First Row* 选项，即可应用所选表格样式定义的标题格式。

1. 创建一个 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例并加载演示文稿。
1. 通过索引访问幻灯片。
1. 遍历所有 [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) 对象以找到相关表格。
1. 将表格的首行设为标题。

```python
import aspose.slides as slides

# 实例化 Presentation 类。
with slides.Presentation("table.pptx") as presentation:
    # 访问第一张幻灯片。
    slide = presentation.slides[0]

    # 遍历形状并获取表格的引用。
    for shape in slide.shapes:
        if type(shape) is slides.Table:
            table = shape
            break

    # 将表格的第一行设置为标题。
    table.first_row = True
    
    # 将演示文稿保存到磁盘。
    presentation.save("table_out.pptx", slides.export.SaveFormat.PPTX)
```


## **克隆表格行或列**

克隆任意表格行或列并将副本插入表格中的指定位置。复制品保留单元格内容、格式和大小，从而可以快速且一致地扩展布局。

1. 创建一个 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例并加载演示文稿。
1. 通过索引访问幻灯片。
1. 定义列宽数组。
1. 定义行高数组。
1. 使用 `add_table(x, y, column_widths, row_heights)` 将 [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/) 添加到幻灯片。
1. 克隆表格行。
1. 克隆表格列。
1. 保存修改后的演示文稿。

```python
 import aspose.slides as slides

# 实例化 Presentation 类。
with slides.Presentation() as presentation:
    # 访问第一张幻灯片。
    slide = presentation.slides[0]

    # 定义列宽和行高。
    column_widths = [50, 50, 50]
    row_heights = [50, 30, 30, 30, 30]

    # 向幻灯片添加表格。
    table = slide.shapes.add_table(100, 50, column_widths, row_heights)

    # 向第 1 行第 1 列添加文本。
    table.rows[0][0].text_frame.text = "Row 1 Cell 1"

    # 向第 2 行第 1 列添加文本。
    table.rows[1][0].text_frame.text = "Row 1 Cell 2"

    # 在表格末尾克隆第 1 行。
    table.rows.add_clone(table.rows[0], False)

    # 向第 1 行第 2 列添加文本。
    table.rows[0][1].text_frame.text = "Row 2 Cell 1"

    # 向第 2 行第 2 列添加文本。
    table.rows[1][1].text_frame.text = "Row 2 Cell 2"

    # 将第 2 行克隆为表格的第 4 行。
    table.rows.insert_clone(3,table.rows[1], False)

    # 在末尾克隆第一列。
    table.columns.add_clone(table.columns[0], False)

    # 在索引 3（第 4 位）处克隆第二列。
    table.columns.insert_clone(3,table.columns[1], False)
    
    # 将演示文稿保存到磁盘。
    presentation.save("table_out.pptx", slides.export.SaveFormat.PPTX)
```


## **从表格中删除行或列**

使用 Aspose.Slides for Python 通过索引删除任意行或列来简化表格——布局会自动重新调整，同时保留剩余单元格的格式。这对于简化数据网格或删除占位符而无需重新构建表格非常有用。

1. 创建一个 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例并加载演示文稿。
1. 通过索引访问幻灯片。
1. 定义列宽数组。
1. 定义行高数组。
1. 使用 `add_table(x, y, column_widths, row_heights)` 将 ITable 添加到幻灯片。
1. 删除表格行。
1. 删除表格列。
1. 保存修改后的演示文稿。

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    
    column_widths = [100, 50, 30]
    row_heights = [30, 50, 30]

    table = slide.shapes.add_table(100, 100, column_widths, row_heights)
    table.rows.remove_at(1, False)
    table.columns.remove_at(1, False)

    presentation.save("TestTable_out.pptx", slides.export.SaveFormat.PPTX)
```


## **在表格行级别设置文本格式**

一次性对整行表格应用一致的文本样式。使用 Aspose.Slides for Python，您可以一次性为该行的所有单元格设置字体系列、字号、粗细、颜色和对齐方式，以保持标题或数据带的一致性。

1. 创建一个 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例并加载演示文稿。
1. 通过索引访问幻灯片。
1. 访问幻灯片上相关的 [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/) 对象。
1. 为首行单元格设置字体高度。
1. 为首行单元格设置对齐方式和右边距。
1. 为第二行单元格设置文本垂直类型。
1. 保存修改后的演示文稿。

```python
import aspose.slides as slides

# 创建 Presentation 类的实例。
with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    table = slide.shapes.add_table(100, 100, [100, 50, 30], [30, 50, 30])

    # 设置首行单元格的字体高度。
    portion_format = slides.PortionFormat()
    portion_format.font_height = 25
    table.rows[0].set_text_format(portion_format)

    # 设置首行单元格的文本对齐方式和右侧边距。
    paragraph_format = slides.ParagraphFormat()
    paragraph_format.alignment = slides.TextAlignment.RIGHT
    paragraph_format.margin_right = 20
    table.rows[0].set_text_format(paragraph_format)

    # 设置第二行单元格的文本垂直类型。
    text_frame_format = slides.TextFrameFormat()
    text_frame_format.text_vertical_type = slides.TextVerticalType.VERTICAL
    table.rows[1].set_text_format(text_frame_format)
	
    # 将演示文稿保存到磁盘。
    presentation.save("result.pptx", slides.export.SaveFormat.PPTX)
```


## **在表格列级别设置文本格式**

一次性对整列表格应用一致的文本样式。使用 Aspose.Slides for Python，您可以为列中的所有单元格设置字体系列、字号、粗细、颜色和对齐方式，从而为标题或数据创建统一的垂直带。

1. 创建一个 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例并加载演示文稿。
1. 通过索引访问幻灯片。
1. 访问幻灯片上相关的 [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/) 对象。
1. 为首列单元格设置字体高度。
1. 为首列单元格设置对齐方式和右边距。
1. 为第二列单元格设置文本垂直类型。
1. 保存修改后的演示文稿。

```python
import aspose.slides as slides

# 创建 Presentation 类的实例。
with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    table = slide.shapes.add_table(100, 100, [100, 50, 30], [30, 50, 30])

    # 设置第一列单元格的字体高度。
    portion_format = slides.PortionFormat()
    portion_format.font_height = 25
    table.columns[0].set_text_format(portion_format)

    # 设置第一列单元格的文本对齐方式和右侧边距。
    paragraph_format = slides.ParagraphFormat()
    paragraph_format.alignment = slides.TextAlignment.RIGHT
    paragraph_format.margin_right = 20
    table.columns[0].set_text_format(paragraph_format)

    # 设置第二列单元格的文本垂直类型。
    text_frame_format = slides.TextFrameFormat()
    text_frame_format.text_vertical_type = slides.TextVerticalType.VERTICAL
    table.columns[1].set_text_format(text_frame_format)

    # 将演示文稿保存到磁盘。
    presentation.save("result.pptx", slides.export.SaveFormat.PPTX)
```


## **获取表格样式属性**

Aspose.Slides 允许您获取表格的样式属性，以便在其他表格或其他位置重复使用。以下 Python 代码演示如何从预设表格样式中获取样式属性：

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    table = slide.shapes.add_table(10, 10, [100, 150], [5, 5, 5])
    table.style_preset = slides.TableStylePreset.DARK_STYLE1

    presentation.save("table.pptx", slides.export.SaveFormat.PPTX)
```


## **FAQ**

**我可以将 PowerPoint 主题/样式应用于已经创建的表格吗？**

可以。表格会继承幻灯片/布局/母版的主题，您仍然可以在该主题之上覆盖填充、边框和文本颜色。

**我能像在 Excel 中一样对表格行进行排序吗？**

不能，Aspose.Slides 表格没有内置的排序或筛选功能。请先在内存中对数据进行排序，然后按该顺序重新填充表格行。

**我可以在保留特定单元格自定义颜色的同时使用分栏（条纹）列吗？**

可以。启用分栏列后，可对特定单元格进行本地格式覆盖；单元格级别的格式会优先于表格样式。