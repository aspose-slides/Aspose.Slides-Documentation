---
title: 使用 Python 管理演示文稿中的表格单元格
linktitle: 管理单元格
type: docs
weight: 30
url: /zh/python-net/manage-cells/
keywords:
- 表格单元格
- 合并单元格
- 删除边框
- 拆分单元格
- 单元格中的图像
- 背景颜色
- PowerPoint
- OpenDocument
- 演示文稿
- Python
- Aspose.Slides
description: "通过 Aspose.Slides for Python via .NET 轻松管理 PowerPoint 和 OpenDocument 中的表格单元格。快速掌握访问、修改和样式设置，实现无缝的幻灯片自动化。"
---

## **概述**

本文展示了如何使用 Aspose.Slides 在演示文稿中处理表格单元格。您将学习如何检测合并单元格、清除或自定义单元格边框，并了解 PowerPoint 在合并和拆分操作后如何对单元格重新编号，从而在复杂布局中预测索引。本文还演示了常见的格式化任务——例如更改单元格的背景填充——以及如何使用图片填充设置将图像直接放入表格单元格。每个场景均附有简洁的 Python 示例，这些示例创建或编辑表格后保存更新的演示文稿，帮助您快速将代码片段适配到自己的幻灯片中。

## **识别合并的表格单元格**

表格经常通过合并单元格来实现标题或分组相关数据。在本节中，您将了解如何判断特定单元格是否属于合并区域，以及如何引用主（左上）单元格，以便一致地读取或格式化整块区域。

1. 创建一个 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例。  
1. 从第一页获取表格。  
1. 遍历表格的行和列以查找合并单元格。  
1. 当发现合并单元格时打印一条消息。

以下 Python 代码用于识别演示文稿中的合并表格单元格：

```py
import aspose.slides as slides

with slides.Presentation("presentation_with_table.pptx") as presentation:
    # 假设第一页的第一个形状是表格。
    table = presentation.slides[0].shapes[0]

    for row_index in range(len(table.rows)):
        for column_index in range(len(table.columns)):
            cell = table.rows[row_index][column_index]
            if cell.is_merged_cell:
                print("Cell ({}, {}) is part of a merged region with a row span of {} and a column span of {}, starting from cell ({}, {}).".format(
                    row_index, column_index, cell.row_span, cell.col_span, cell.first_row_index, cell.first_column_index))
```

## **删除表格单元格边框**

有时表格边框会分散注意力或造成视觉杂乱。本节展示了如何从选定单元格或单元格的特定边侧删除边框，以实现更简洁的布局并更好地配合幻灯片设计。

1. 创建一个 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例。  
1. 按索引获取幻灯片。  
1. 定义列宽数组。  
1. 定义行高数组。  
1. 使用 [add_table](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_table/) 方法在幻灯片上添加表格。  
1. 遍历每个单元格以清除上、下、左、右四个边框。  
1. 将修改后的演示文稿另存为 PPTX 文件。

以下 Python 代码演示了如何删除表格单元格的边框：

```python
import aspose.slides as slides

# 实例化表示 PPTX 文件的 Presentation 类。
with slides.Presentation() as presentation:
    # 访问第一页。
    slide = presentation.slides[0]

    # 定义列宽和行高。
    column_widths = [50, 50, 50, 50]
    row_heights = [50, 30, 30, 30, 30]

    # 向幻灯片添加表格形状。
    table = slide.shapes.add_table(50, 50, column_widths, row_heights)

    # 清除每个单元格的边框填充。
    for row in table.rows:
        for cell in row:
            cell.cell_format.border_top.fill_format.fill_type = slides.FillType.NO_FILL
            cell.cell_format.border_bottom.fill_format.fill_type = slides.FillType.NO_FILL
            cell.cell_format.border_left.fill_format.fill_type = slides.FillType.NO_FILL
            cell.cell_format.border_right.fill_format.fill_type = slides.FillType.NO_FILL

    # 将 PPTX 文件保存到磁盘。
    presentation.save("table.pptx", slides.export.SaveFormat.PPTX)
```

## **合并单元格后的编号**

如果合并两对单元格，例如 (1, 1) 与 (2, 1) 以及 (1, 2) 与 (2, 2)，则合并后的表格仍保持与未合并时相同的单元格编号。以下 Python 代码演示了此行为：

```python
import aspose.slides as slides

# 实例化表示 PPTX 文件的 Presentation 类。
with slides.Presentation() as presentation:
    # 访问第一页。
    slide = presentation.slides[0]

    # 定义列宽和行高。
    column_widths = [70, 70, 70, 70]
    row_heights = [70, 70, 70, 70]

    # 向幻灯片添加表格形状。
    table = slide.shapes.add_table(50, 50, column_widths, row_heights)

    # 合并单元格 (1,1) 与 (2,1)。
    table.merge_cells(table.rows[1][1], table.rows[2][1], False)

    # 合并单元格 (1,2) 与 (2,2)。
    table.merge_cells(table.rows[1][2], table.rows[2][2], False)

    # 打印单元格索引。
    for row_index in range(len(table.rows)):
        for column_index in range(len(table.rows[row_index])):
            cell = table.rows[row_index][column_index]
            print(f"{cell.first_row_index, cell.first_column_index} ", end="")
        print()

    # 将 PPTX 文件保存到磁盘。
    presentation.save("merged_cells.pptx", slides.export.SaveFormat.PPTX)
```

输出：

```text
(0, 0) (0, 1) (0, 2) (0, 3) 
(1, 0) (1, 1) (1, 2) (1, 3) 
(2, 0) (1, 1) (1, 2) (2, 3) 
(3, 0) (3, 1) (3, 2) (3, 3)
```

## **拆分单元格后的编号**

在前面的示例中，合并单元格后其他单元格的编号保持不变。本例先创建一个普通表格（无合并单元格），然后拆分单元格 (1, 1) 生成特殊表格。请注意该表格的编号——它可能看起来不寻常，但这正是 Microsoft PowerPoint 对表格单元格的编号方式，Aspose.Slides 与其保持一致。

以下 Python 代码演示了此行为：

```python
import aspose.slides as slides

# 实例化表示 PPTX 文件的 Presentation 类。
with slides.Presentation() as presentation:
    # 访问第一页。
    slide = presentation.slides[0]

    # 定义列宽和行高。
    column_widths = [70, 70, 70, 70]
    row_heights = [70, 70, 70, 70]

    # 向幻灯片添加表格形状。
    table = slide.shapes.add_table(50, 50, column_widths, row_heights)

    # 拆分单元格 (1, 1)。
    table.rows[1][1].split_by_width(table.rows[2][1].width / 2)

    # 打印单元格索引。
    for row_index in range(len(table.rows)):
        for column_index in range(len(table.rows[row_index])):
            cell = table.rows[row_index][column_index]
            print(f"{cell.first_row_index, cell.first_column_index} ", end="")
        print()

    # 将 PPTX 文件保存到磁盘。
    presentation.save("split_cells.pptx", slides.export.SaveFormat.PPTX)
```

输出：

```text
(0, 0) (0, 1) (0, 1) (0, 3) (0, 4) 
(1, 0) (1, 1) (1, 2) (1, 3) (1, 4) 
(2, 0) (2, 1) (2, 1) (2, 3) (2, 4) 
(3, 0) (3, 1) (3, 1) (3, 3) (3, 4) 
```

## **更改表格单元格背景颜色**

下面的 Python 示例演示了如何更改表格单元格的背景颜色：

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [150, 150, 150, 150]
    row_heights = [50, 50, 50, 50, 50]

    # 创建新表格。
    table = slide.shapes.add_table(50, 50, column_widths, row_heights)

    # 设置单元格的背景颜色。
    cell = table.rows[2][3]
    cell.cell_format.fill_format.fill_type = slides.FillType.SOLID
    cell.cell_format.fill_format.solid_fill_color.color = draw.Color.red

    presentation.save("cell_background_color.pptx", slides.export.SaveFormat.PPTX)
```

## **向表格单元格插入图像**

本节展示了如何在 Aspose.Slides 中将图像插入表格单元格。内容包括对目标单元格应用图片填充以及配置显示选项（如拉伸或平铺）。

1. 创建一个 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例。  
1. 按索引获取幻灯片引用。  
1. 定义列宽数组。  
1. 定义行高数组。  
1. 使用 [add_table](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_table/) 方法向幻灯片添加表格。  
1. 从文件加载图像。  
1. 将图像添加到演示文稿的图片集合以获取 [PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/)。  
1. 将单元格的 [FillType](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) 设置为 `PICTURE`。  
1. 将图像应用到表格单元格并选择填充模式（例如 `STRETCH`）。  
1. 将演示文稿保存为 PPTX 文件。

以下 Python 代码展示了在创建表格时如何将图像放入表格单元格：

```python
import aspose.slides as slides

# 实例化一个 Presentation 对象。
with slides.Presentation() as presentation:
    # 访问第一页。
    slide = presentation.slides[0]

    # 定义列宽和行高。
    column_widths = [150, 150, 150, 150]
    row_heights = [100, 100, 100, 100]

    # 向幻灯片添加表格形状。
    table = slide.shapes.add_table(50, 50, column_widths, row_heights)

    # 加载图像并将其添加到演示文稿以获取 PPImage。
    with slides.Images.from_file("image.png") as source_image:
        image = presentation.images.add_image(source_image)

    # 将图像应用到第一个表格单元格。
    cell = table.rows[0][0]
    cell.cell_format.fill_format.fill_type = slides.FillType.PICTURE
    cell.cell_format.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.STRETCH
    cell.cell_format.fill_format.picture_fill_format.picture.image = image

    # 将演示文稿保存到磁盘。
    presentation.save("image_in_table_cell.pptx", slides.export.SaveFormat.PPTX)
```

## **常见问题**

**我可以为同一单元格的不同边设置不同的线条粗细和样式吗？**

可以。[top](https://reference.aspose.com/slides/python-net/aspose.slides/cellformat/border_top/)、[bottom](https://reference.aspose.com/slides/python-net/aspose.slides/cellformat/border_bottom/)、[left](https://reference.aspose.com/slides/python-net/aspose.slides/cellformat/border_left/)、[right](https://reference.aspose.com/slides/python-net/aspose.slides/cellformat/border_right/) 边框各自拥有独立属性，因而每一侧的粗细和样式均可不同。这与本文中演示的单元格逐边框控制逻辑相吻合。

**如果在将图片设为单元格背景后更改列/行大小，会发生什么？**

行为取决于 [fill mode](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillmode/)（stretch/tile）。使用 stretch 时，图片会随单元格新尺寸自动调整；使用 tile 时，平铺会重新计算。本文已说明图片在单元格中的显示模式。

**我可以为单元格的所有内容分配超链接吗？**

[Hyperlinks](/slides/zh/python-net/manage-hyperlinks/) 可以在单元格文本框内的文本（portion）级别设置，也可以在整张表格/形状层面设置。实际操作时，您可以将链接赋予单元格中的某段文字或全部文字。

**我可以在同一个单元格内使用不同的字体吗？**

可以。单元格的文本框支持 [portions](https://reference.aspose.com/slides/python-net/aspose.slides/portion/)（即运行），每个 portion 都可以拥有独立的字体族、样式、大小和颜色。