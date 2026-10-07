---
title: 在 Python 中管理演示文稿的表格单元格
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
- 演示文稿
- Python
- Aspose.Slides
description: "在 Python 中使用 Aspose.Slides（通过 .NET）管理 PowerPoint 表格单元格：识别合并单元格、删除边框、拆分单元格，并设置背景颜色和图像。"
---
## **概述**

Aspose.Slides 允许您在 PowerPoint 演示文稿中访问和修改表格单元格。本文说明如何识别合并的表格单元格、删除单元格边框、在合并或拆分单元格后处理单元格编号、更改单元格的背景颜色，以及在表格单元格内添加图像。示例展示了如何创建或打开演示文稿、从幻灯片获取表格、通过单元格属性更新单元格格式，并将修改后的演示文稿另存为 PPTX 文件。

Aspose.Slides 使用从零开始的索引。本文中的坐标写为 `(column, row)`。

## **识别合并的表格单元格**

示例打开现有演示文稿，并将第一张幻灯片上的第一个形状视为表格。假设该幻灯片和形状存在且形状是表格。随后遍历所有行和列，并使用 [is_merged_cell](https://reference.aspose.com/slides/python-net/aspose.slides/cell/is_merged_cell/) 来识别合并区域中的单元格。对于每个匹配项，它以 `row;column` 顺序打印单元格坐标、[row_span](https://reference.aspose.com/slides/python-net/aspose.slides/cell/row_span/)、[col_span](https://reference.aspose.com/slides/python-net/aspose.slides/cell/col_span/)，以及该区域的起始坐标，[first_row_index](https://reference.aspose.com/slides/python-net/aspose.slides/cell/first_row_index/) 和 [first_column_index](https://reference.aspose.com/slides/python-net/aspose.slides/cell/first_column_index/)。

```python
import aspose.slides as slides

with slides.Presentation("presentation_with_table.pptx") as presentation:
    slide = presentation.slides[0]
    table = slide.shapes[0]

    for row_index in range(len(table.rows)):
        for column_index in range(len(table.columns)):
            cell = table.rows[row_index][column_index]
            if cell.is_merged_cell:
                print(f"Cell {row_index};{column_index} belongs to a merged region with row_span={cell.row_span} and col_span={cell.col_span} starting at {cell.first_row_index};{cell.first_column_index}.")
```

## **删除表格单元格边框**

创建一个 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)，并使用 [add_table](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_table/) 在其第一张幻灯片上添加表格。列宽、行高以及表格位置均以点为单位指定。示例将所有四个单元格边框设置为 [FillType.NO_FILL](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/)，使其不可见。

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [50, 50, 50, 50]
    row_heights = [50, 30, 30, 30, 30]
    table = slide.shapes.add_table(100, 50, column_widths, row_heights)

    for row in table.rows:
        for cell in row:
            cell.cell_format.border_top.fill_format.fill_type = slides.FillType.NO_FILL
            cell.cell_format.border_bottom.fill_format.fill_type = slides.FillType.NO_FILL
            cell.cell_format.border_left.fill_format.fill_type = slides.FillType.NO_FILL
            cell.cell_format.border_right.fill_format.fill_type = slides.FillType.NO_FILL

    presentation.save("table.pptx", slides.export.SaveFormat.PPTX)
```

## **合并表格单元格**

使用 [merge_cells](https://reference.aspose.com/slides/python-net/aspose.slides/table/merge_cells/) 合并表格单元格的矩形范围为一个单元格。指定范围左上角和右下角的单元格。最后一个参数控制合并是否可以包含指定范围之外的单元格；`False` 将合并限制在该范围内。

示例创建一个 4×4 表格，列宽和行高均为 70 点，然后将 `(1, 1)` 到 `(2, 2)` 的四个中心单元格合并。合并后得到的单元格跨越两列两行，而表格底层的网格仍保持四列四行。要访问合并单元格的内容或格式，请使用其左上位置：本例中为 `table.rows[1][1]`。合并范围内的其他位置仍然是表格网格的一部分，因此范围外单元格的索引保持不变。

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [70, 70, 70, 70]
    row_heights = [70, 70, 70, 70]
    table = slide.shapes.add_table(100, 50, column_widths, row_heights)

    table.merge_cells(table.rows[1][1], table.rows[2][2], False)

    presentation.save("merged_cells.pptx", slides.export.SaveFormat.PPTX)
```

## **拆分表格单元格**

在前面的示例中合并单元格后，表格的网格保持不变。拆分单元格可能会引入新的网格列，并更改其右侧单元格的列索引。Aspose.Slides 遵循 PowerPoint 的表格网格模型。

本示例创建一个 4×4 表格，列宽和行高均为 70 点，并对单元格 `(1, 1)` 调用 [split_by_width](https://reference.aspose.com/slides/python-net/aspose.slides/cell/split_by_width/)。将单元格 70 点宽度的一半传入，以创建两个等宽单元格。

拆分后，这两个半单元格可通过 `table.rows[1][1]` 和 `table.rows[1][2]` 访问。表格网格现在有五列：原本位于第 2、3 列的单元格分别移动到第 3、4 列。行索引保持不变。拆分后访问单元格时请使用更新后的列索引。

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [70, 70, 70, 70]
    row_heights = [70, 70, 70, 70]
    table = slide.shapes.add_table(100, 50, column_widths, row_heights)

    table.rows[1][1].split_by_width(table.rows[1][1].width / 2)

    presentation.save("split_cells.pptx", slides.export.SaveFormat.PPTX)
```

### **按行或列跨度拆分合并的单元格**

为了在填充数据前准备合并的模板单元格，可使用 [split_by_row_span](https://reference.aspose.com/slides/python-net/aspose.slides/cell/split_by_row_span/) 按现有行边界拆分，或使用 [split_by_col_span](https://reference.aspose.com/slides/python-net/aspose.slides/cell/split_by_col_span/) 按列边界拆分。

`index` 参数统计拆分上部的行数或左侧的列数；它相对于合并区域：

- 行拆分：`0 < index <` [row_span](https://reference.aspose.com/slides/python-net/aspose.slides/cell/row_span/)。
- 列拆分：`0 < index <` [col_span](https://reference.aspose.com/slides/python-net/aspose.slides/cell/col_span/)。

示例假设演示文稿的第一张幻灯片的第一个形状是表格，且 `(1, 2)` 与 `(1, 3)` 垂直合并。它从下部位置开始，使用 [first_column_index](https://reference.aspose.com/slides/python-net/aspose.slides/cell/first_column_index/) 和 [first_row_index](https://reference.aspose.com/slides/python-net/aspose.slides/cell/first_row_index/) 定位起始点并检查两个跨度。使用 `split_by_row_span` 且索引为 1 可将第 2、3 行分离用于产品名称。对于水平的两列合并，则改用 `split_by_col_span` 且索引为 1。

```python
import aspose.slides as slides

with slides.Presentation("table_template.pptx") as presentation:
    slide = presentation.slides[0]
    table = slide.shapes[0]

    selected_cell = table.rows[3][1]
    first_column_index = selected_cell.first_column_index
    first_row_index = selected_cell.first_row_index
    merged_cell = table.rows[first_row_index][first_column_index]

    if merged_cell.is_merged_cell and merged_cell.row_span == 2 and merged_cell.col_span == 1:
        merged_cell.split_by_row_span(1)

        # 检索拆分后表格中得到的单元格。
        upper_cell = table.rows[first_row_index][first_column_index]
        lower_cell = table.rows[first_row_index + 1][first_column_index]
        print(f"Upper cell merged: {upper_cell.is_merged_cell}")
        print(f"Lower cell merged: {lower_cell.is_merged_cell}")

        upper_cell.text_frame.text = "Product A"
        lower_cell.text_frame.text = "Product B"

        presentation.save("split_template.pptx", slides.export.SaveFormat.PPTX)
    else:
        print("Select a merged region spanning exactly two rows and one column.")
```

表格网格和周围单元格的索引保持不变。通过坐标检索得到的单元格均拥有跨度 1，且 [is_merged_cell](https://reference.aspose.com/slides/python-net/aspose.slides/cell/is_merged_cell/) 返回 `False`。更大的区域在一次拆分后仍可能部分保持合并状态。

原始文本及其格式保留在上（或左）单元格；新单元格为空，但会继承填充、边框和边距等单元格格式。拆分后请填充单元格，并显式设置任何所需的文本格式。

保存的演示文稿包含单独的 “Product A” 与 “Product B” 单元格，保留了模板的单元格格式。请参阅 [Cell API Reference](https://reference.aspose.com/slides/python-net/aspose.slides/cell/) 获取详细信息。

## **更改表格单元格背景颜色**

本示例创建一个列宽 150 点、行高 50 点的表格。它将 [fill_type](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/fill_type/) 设置为 solid，并将 [solid_fill_color](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/solid_fill_color/) 设置为 red，以指定单元格 `(2, 3)`（第 3 列第 4 行）的背景颜色。

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [150, 150, 150, 150]
    row_heights = [50, 50, 50, 50, 50]
    table = slide.shapes.add_table(50, 50, column_widths, row_heights)

    cell = table.rows[3][2]
    cell.cell_format.fill_format.fill_type = slides.FillType.SOLID
    cell.cell_format.fill_format.solid_fill_color.color = draw.Color.red

    presentation.save("cell_background_color.pptx", slides.export.SaveFormat.PPTX)
```

## **在表格单元格内添加图像**

在运行本示例之前，请将输入图像放置在工作目录中。示例使用 [Images.from_file](https://reference.aspose.com/slides/python-net/aspose.slides/images/from_file/) 加载图像，并使用 [add_image](https://reference.aspose.com/slides/python-net/aspose.slides/imagecollection/add_image/) 将其添加到演示文稿的图像集合中。随后将该图像分配给单元格 `(0, 0)`（表格的第一个单元格）的图片填充。

[PictureFillMode.STRETCH](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillmode/) 将图像拉伸以填满单元格，这可能会改变其宽高比。列宽和行高以点为单位。加载的图像在其 `with` 块结束时会自动释放。

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [150, 150, 150, 150]
    row_heights = [100, 100, 100, 100, 90]
    table = slide.shapes.add_table(50, 50, column_widths, row_heights)

    with slides.Images.from_file("aspose_logo.jpg") as image:
        presentation_image = presentation.images.add_image(image)

    cell = table.rows[0][0]
    cell.cell_format.fill_format.fill_type = slides.FillType.PICTURE
    cell.cell_format.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.STRETCH
    cell.cell_format.fill_format.picture_fill_format.picture.image = presentation_image

    presentation.save("table_cell_with_image.pptx", slides.export.SaveFormat.PPTX)
```

## **常见问题**

**我可以为单个单元格的不同边设置不同的线粗细和样式吗？**

可以。单元格的 [top](https://reference.aspose.com/slides/python-net/aspose.slides/cellformat/border_top/)/[bottom](https://reference.aspose.com/slides/python-net/aspose.slides/cellformat/border_bottom/)/[left](https://reference.aspose.com/slides/python-net/aspose.slides/cellformat/border_left/)/[right](https://reference.aspose.com/slides/python-net/aspose.slides/cellformat/border_right/) 边框拥有独立的属性，因此每一侧的粗细和样式可以不同。

**在将图片设为单元格背景后，如果更改列/行大小，图片会怎样？**

行为取决于 [fill mode](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillmode/)（stretch/tile）。使用拉伸时，图片会随新单元格大小调整；使用平铺时，平铺会重新计算。

**我可以为单元格的全部内容分配超链接吗？**

[Hyperlinks](/slides/zh/python-net/manage-hyperlinks/) 在单元格的文本框（段落）级别或整个表格/形状级别设置。实际使用时，您可以将链接分配给段落或单元格内的全部文本。

**我可以在单个单元格内使用不同的字体吗？**

可以。单元格的文本框支持 [portions](https://reference.aspose.com/slides/python-net/aspose.slides/portion/)（运行），这些段落可以拥有独立的字体系列、样式、大小和颜色。