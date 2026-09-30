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
description: "使用 Aspose.Slides for Python via .NET 在 PowerPoint 和 OpenDocument 幻灯片中创建和编辑表格。发现简洁的代码示例，以简化您的表格工作流。"
---
## **介绍**

PowerPoint 中的表格将信息组织为行和列，使阅读和比较数值更加容易。

Aspose.Slides 提供 [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/) 和 [Cell](https://reference.aspose.com/slides/python-net/aspose.slides/cell/) 类及其他类型，帮助您在演示文稿中创建、更新和管理表格。

## **从头创建表格**

通过指定位置、列宽和行高来创建表格。将其添加到幻灯片后，您可以设置单元格边框、合并单元格并插入文本。

1. 创建 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例。
2. 通过索引获取幻灯片的引用。
3. 定义以点为单位的列宽列表。
4. 定义以点为单位的行高列表。
5. 通过 [add_table](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_table/) 方法向幻灯片添加 [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/) 对象。
6. 遍历每个 [Cell](https://reference.aspose.com/slides/python-net/aspose.slides/cell/)，为上、下、左、右边框应用格式。
7. 合并表格第一行的前两个单元格。
8. 通过合并单元格的 [text_frame](https://reference.aspose.com/slides/python-net/aspose.slides/cell/text_frame/) 属性访问它。
9. 设置合并单元格中的文本。
10. 保存修改后的演示文稿。

下面的示例在 (100, 50) 点位置创建一个包含三列五行的表格。它使用宽度为 5 点的红色边框，合并第一行的前两个单元格，并将结果保存为 `table.pptx`。

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [50, 50, 50]
    row_heights = [50, 30, 30, 30, 30]
    table = slide.shapes.add_table(100, 50, column_widths, row_heights)

    for row in table.rows:
        for cell in row:
            cell_format = cell.cell_format
            cell_format.border_top.fill_format.fill_type = slides.FillType.SOLID
            cell_format.border_top.fill_format.solid_fill_color.color = draw.Color.red
            cell_format.border_top.width = 5

            cell_format.border_bottom.fill_format.fill_type = slides.FillType.SOLID
            cell_format.border_bottom.fill_format.solid_fill_color.color = draw.Color.red
            cell_format.border_bottom.width = 5

            cell_format.border_left.fill_format.fill_type = slides.FillType.SOLID
            cell_format.border_left.fill_format.solid_fill_color.color = draw.Color.red
            cell_format.border_left.width = 5

            cell_format.border_right.fill_format.fill_type = slides.FillType.SOLID
            cell_format.border_right.fill_format.solid_fill_color.color = draw.Color.red
            cell_format.border_right.width = 5

    table.merge_cells(table.rows[0][0], table.rows[0][1], False)
    table.rows[0][0].text_frame.text = "Merged Cells"

    presentation.save("table.pptx", slides.export.SaveFormat.PPTX)
```

## **标准表格中的编号**

在标准表格中，单元格索引从零开始，顺序为（列，行）。第一个单元格的索引为 (0, 0)。在 Python 中，可使用 `table.rows[row_index][column_index]` 访问单元格；在此表达式中行索引位于前面。

例如，拥有 4 列 4 行的表格的单元格编号方式如下：

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

此示例创建上图所示的 4 × 4 表格，列宽和行高均为 70 点，使用宽度为 5 点的红色单元格边框。坐标用于说明单元格索引；示例保持单元格为空并将表格保存为 `StandardTables_out.pptx`。

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [70, 70, 70, 70]
    row_heights = [70, 70, 70, 70]
    table = slide.shapes.add_table(100, 50, column_widths, row_heights)

    for row in table.rows:
        for cell in row:
            cell_format = cell.cell_format
            cell_format.border_top.fill_format.fill_type = slides.FillType.SOLID
            cell_format.border_top.fill_format.solid_fill_color.color = draw.Color.red
            cell_format.border_top.width = 5

            cell_format.border_bottom.fill_format.fill_type = slides.FillType.SOLID
            cell_format.border_bottom.fill_format.solid_fill_color.color = draw.Color.red
            cell_format.border_bottom.width = 5

            cell_format.border_left.fill_format.fill_type = slides.FillType.SOLID
            cell_format.border_left.fill_format.solid_fill_color.color = draw.Color.red
            cell_format.border_left.width = 5

            cell_format.border_right.fill_format.fill_type = slides.FillType.SOLID
            cell_format.border_right.fill_format.solid_fill_color.color = draw.Color.red
            cell_format.border_right.width = 5

    presentation.save("StandardTables_out.pptx", slides.export.SaveFormat.PPTX)
```

## **访问现有表格**

表格存储在幻灯片的形状集合中。遍历形状以定位表格，然后使用 [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/) 类读取或更新其单元格。

1. 使用 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类加载演示文稿。
2. 通过索引获取包含该表格的幻灯片引用。
3. 遍历 [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) 对象并在找到表格时停止。如果幻灯片包含多个表格，使用 [alternative_text](https://reference.aspose.com/slides/python-net/aspose.slides/shape/alternative_text/) 来识别所需的表格。
4. 更新目标单元格中的文本。
5. 保存修改后的演示文稿。

下面的示例打开 `UpdateExistingTable.pptx` 并在第一张幻灯片上找到第一个表格。它将列 0、行 1 的单元格设置为 `New`，并将结果保存为 `table1_out.pptx`。输入文件必须至少包含一张幻灯片，且该幻灯片上的第一个表格必须至少有一列和两行。

```python
import aspose.slides as slides

with slides.Presentation("UpdateExistingTable.pptx") as presentation:
    slide = presentation.slides[0]
    table = None

    for shape in slide.shapes:
        if isinstance(shape, slides.Table):
            table = shape
            break

    if table is not None and len(table.rows) >= 2:
        table.rows[1][0].text_frame.text = "New"
        presentation.save("table1_out.pptx", slides.export.SaveFormat.PPTX)
```

要在现有表格中调整行高并了解其实际高度为何可能超过请求的最小值，请参阅[控制行高](/slides/zh/python-net/manage-rows-and-columns/#control-row-height)。

## **查找拥有 TextFrame 的单元格**

当通用文本处理代码从表格中收到 [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) 时，使用 [TextFrame.parent_cell](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/parent_cell/) 属性来获取所属的 [Cell](https://reference.aspose.com/slides/python-net/aspose.slides/cell/)。对于表格单元格的文本框，[TextFrame.parent_cell](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/parent_cell/) 已设置且 [TextFrame.parent_shape](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/parent_shape/) 为 `None`，即使表格本身也是一个形状。

单元格坐标可通过只读的 [Cell.first_column_index](https://reference.aspose.com/slides/python-net/aspose.slides/cell/first_column_index/) 和 [Cell.first_row_index](https://reference.aspose.com/slides/python-net/aspose.slides/cell/first_row_index/) 属性获取。[TextFrame.parent_cell](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/parent_cell/) 也是只读的：它提供指向所有者的导航，但不改变所有权。使用前务必检查返回的单元格是否为 `None`。

有关识别表格单元格和形状所有者（包括与 SmartArt 节点关联的形状）的完整示例，请参阅[搜索和替换文本](/slides/zh/python-net/search-and-replace-text/)。

## **对齐表格中的文本**

您可以控制各个表格单元格的垂直锚定和文本方向。本节示例将第一单元格的文本居中并旋转 270 度。

1. 创建 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例。
2. 通过索引获取幻灯片的引用。
3. 向幻灯片添加 [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/) 对象。
4. 从表格中获取一个 [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) 对象。
5. 访问第一个 [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/)，并设置其文本和颜色。
6. 设置单元格的 [text_anchor_type](https://reference.aspose.com/slides/python-net/aspose.slides/cell/text_anchor_type/) 和 [text_vertical_type](https://reference.aspose.com/slides/python-net/aspose.slides/cell/text_vertical_type/)。
7. 保存修改后的演示文稿。

此示例创建一个 4 × 4 表格，列宽为 120 点，行高为 100 点。它格式化单元格 (0, 0) 中的文本，向首行其余单元格添加值，并将结果保存为 `Vertical_Align_Text_out.pptx`。

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [120, 120, 120, 120]
    row_heights = [100, 100, 100, 100]
    table = slide.shapes.add_table(100, 50, column_widths, row_heights)
    table.rows[0][1].text_frame.text = "10"
    table.rows[0][2].text_frame.text = "20"
    table.rows[0][3].text_frame.text = "30"

    cell = table.rows[0][0]
    paragraph = cell.text_frame.paragraphs[0]
    portion = paragraph.portions[0]
    portion.text = "Text here"
    portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
    portion.portion_format.fill_format.solid_fill_color.color = draw.Color.black

    cell.text_anchor_type = slides.TextAnchorType.CENTER
    cell.text_vertical_type = slides.TextVerticalType.VERTICAL270

    presentation.save("Vertical_Align_Text_out.pptx", slides.export.SaveFormat.PPTX)
```

## **在表格级别设置文本格式**

使用 [set_text_format](https://reference.aspose.com/slides/python-net/aspose.slides/table/set_text_format/) 可对表格中所有单元格应用文本格式。其重载接受段落、文字框等格式设置，无需遍历单元格即可完成。

1. 使用 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类加载演示文稿。
2. 通过索引获取幻灯片的引用。
3. 从幻灯片中获取一个 [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/) 对象。
4. 设置文本的 [font_height](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/font_height/)。
5. 设置 [alignment](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/alignment/) 和 [margin_right](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/margin_right/)。
6. 设置 [text_vertical_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/text_vertical_type/)。
7. 保存修改后的演示文稿。

下面的示例打开 `table.pptx`（该文件必须至少包含一张幻灯片，且第一形状为表格），将字体大小设为 25 点，段落右对齐并设右边距为 20 点，使文本垂直排列。格式化后的演示文稿保存为 `result.pptx`。

```python
import aspose.slides as slides

with slides.Presentation("table.pptx") as presentation:
    slide = presentation.slides[0]
    table = slide.shapes[0]

    portion_format = slides.PortionFormat()
    portion_format.font_height = 25
    table.set_text_format(portion_format)

    paragraph_format = slides.ParagraphFormat()
    paragraph_format.alignment = slides.TextAlignment.RIGHT
    paragraph_format.margin_right = 20
    table.set_text_format(paragraph_format)

    text_frame_format = slides.TextFrameFormat()
    text_frame_format.text_vertical_type = slides.TextVerticalType.VERTICAL
    table.set_text_format(text_frame_format)

    presentation.save("result.pptx", slides.export.SaveFormat.PPTX)
```

## **获取表格样式属性**

使用 [style_preset](https://reference.aspose.com/slides/python-net/aspose.slides/table/style_preset/) 可读取或分配表格的预设样式。此示例将 [TableStylePreset.DARK_STYLE1](https://reference.aspose.com/slides/python-net/aspose.slides/tablestylepreset/) 应用于一个表格，打印预设名称，并将相同预设分配给第二个表格。两张表格均保存为 `table-style.pptx`。

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [100, 150]
    row_heights = [5, 5, 5]
    table = slide.shapes.add_table(10, 10, column_widths, row_heights)
    table.style_preset = slides.TableStylePreset.DARK_STYLE1

    style_preset = table.style_preset
    print(f"Table style preset: {style_preset.name}")

    another_table = slide.shapes.add_table(10, 100, column_widths, row_heights)
    another_table.style_preset = style_preset

    presentation.save("table-style.pptx", slides.export.SaveFormat.PPTX)
```

## **锁定表格的宽高比**

表格的宽高比是其宽度与高度的比值。使用 [aspect_ratio_locked](https://reference.aspose.com/slides/python-net/aspose.slides/graphicalobjectlock/aspect_ratio_locked/) 可锁定表格的此比例。

下面的示例打开 `pres.pptx`（该文件必须至少包含一张幻灯片，且第一形状为表格），打印当前锁定状态，启用宽高比锁定，打印更新后的状态 (`True`)，并将结果保存为 `pres-out.pptx`。

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    slide = presentation.slides[0]
    table = slide.shapes[0]

    print(f"Lock aspect ratio set: {table.shape_lock.aspect_ratio_locked}")
    
    table.shape_lock.aspect_ratio_locked = True
    print(f"Lock aspect ratio set: {table.shape_lock.aspect_ratio_locked}")

    presentation.save("pres-out.pptx", slides.export.SaveFormat.PPTX)
```

## **常见问题**

**我能为整个表格及其单元格中的文本启用从右到左 (RTL) 阅读方向吗？**

可以。表格公开了一个 [right_to_left](https://reference.aspose.com/slides/python-net/aspose.slides/table/right_to_left/) 属性，段落具有 [ParagraphFormat.right_to_left](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/right_to_left/) 属性。两者同时使用即可确保单元格内文本的正确 RTL 顺序和渲染。

**如何防止用户在最终文件中移动或调整表格的大小？**

使用[形状锁定](/slides/zh/python-net/applying-protection-to-presentation/)可以禁用移动、调整大小、选择等。这些锁定同样适用于表格。

**是否支持在单元格内部将图像作为背景插入？**

支持。您可以为单元格设置 [picture fill](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/)，图像将根据所选模式（拉伸或平铺）覆盖单元格区域。