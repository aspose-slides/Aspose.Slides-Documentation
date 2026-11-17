---
title: 使用 Python 管理演示文稿中的表格单元格
linktitle: 管理单元格
type: docs
weight: 30
url: /zh/python-net/manage-cells/
keywords:
- 表格单元格
- 合并单元格
- 移除边框
- 拆分单元格
- 单元格中的图像
- 背景颜色
- PowerPoint
- 演示文稿
- Python
- Aspose.Slides
description: "使用 Python 管理 PowerPoint 表格单元格：识别合并单元格、移除边框、拆分单元格，并使用 Aspose.Slides for Python via .NET 设置背景颜色和图像。"
---
## **概述**

Aspose.Slides 允许您访问和修改 PowerPoint 演示文稿中的表格单元格。本文说明如何识别合并的表格单元格、移除单元格边框、在合并或拆分单元格后处理单元格编号、更改单元格的背景色以及在表格单元格内添加图像。示例展示了如何创建或打开演示文稿、从幻灯片获取表格、通过单元格属性更新单元格格式，并将修改后的演示文稿保存为 PPTX 文件。

Aspose.Slides 使用从零开始的索引。本文中的坐标写成 `(column, row)`。

## **识别合并的表格单元格**

示例打开现有演示文稿并将第一张幻灯片上的第一个形状作为表格访问。它假设幻灯片和形状均存在且该形状是表格。随后遍历所有行和列，并使用 [is_merged_cell](https://reference.aspose.com/slides/python-net/aspose.slides/cell/is_merged_cell/) 来识别合并区域中的单元格。对于每个匹配项，按 `row;column` 顺序打印单元格坐标、[row_span](https://reference.aspose.com/slides/python-net/aspose.slides/cell/row_span/)、[col_span](https://reference.aspose.com/slides/python-net/aspose.slides/cell/col_span/)，以及区域的起始坐标，[first_row_index](https://reference.aspose.com/slides/python-net/aspose.slides/cell/first_row_index/) 和 [first_column_index](https://reference.aspose.com/slides/python-net/aspose.slides/cell/first_column_index/)。

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

## **移除表格单元格边框**

创建一个 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 并使用 [add_table](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_table/) 在其第一张幻灯片上添加表格。列宽、行高以及表格位置均以点为单位指定。示例将四条单元格边框全部设置为 [FillType.NO_FILL](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/)，使其不可见。

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

## **添加对角线单元格边框**

使用 [border_diagonal_down](https://reference.aspose.com/slides/python-net/aspose.slides/cellformat/border_diagonal_down/) 绘制从左上角到右下角的线，使用 [border_diagonal_up](https://reference.aspose.com/slides/python-net/aspose.slides/cellformat/border_diagonal_up/) 绘制从左下角到右上角的线。对角线可标记角标题；两条对角线共同形成 X 可标记单元格为“不适用”。

每条对角线都是一个 [LineFormat](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/)。在其 [fill_format](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/fill_format/) 中，将 [fill_type](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/fill_type/) 设置为 [FillType.SOLID](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/)，并选择 [solid_fill_color](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/solid_fill_color/)。将线的 [width](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/width/) 以点为单位设置。

示例在同一行创建三个单元格：一个红色向下对角线、一个蓝色向上对角线以及两条对角线都存在的单元格。它保留了顶部、底部、左侧和右侧的单元格边框不变。

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [210, 210, 210]
    row_heights = [160]
    table = slide.shapes.add_table(45, 130, column_widths, row_heights)

    downward_border = table.rows[0][0].cell_format.border_diagonal_down
    downward_border.fill_format.fill_type = slides.FillType.SOLID
    downward_border.fill_format.solid_fill_color.color = slides.Color.red
    downward_border.width = 3

    upward_border = table.rows[0][1].cell_format.border_diagonal_up
    upward_border.fill_format.fill_type = slides.FillType.SOLID
    upward_border.fill_format.solid_fill_color.color = slides.Color.blue
    upward_border.width = 5

    cross_downward_border = table.rows[0][2].cell_format.border_diagonal_down
    cross_downward_border.fill_format.fill_type = slides.FillType.SOLID
    cross_downward_border.fill_format.solid_fill_color.color = slides.Color.red
    cross_downward_border.width = 3

    cross_upward_border = table.rows[0][2].cell_format.border_diagonal_up
    cross_upward_border.fill_format.fill_type = slides.FillType.SOLID
    cross_upward_border.fill_format.solid_fill_color.color = slides.Color.blue
    cross_upward_border.width = 5

    presentation.save("diagonal_cell_borders.pptx", slides.export.SaveFormat.PPTX)
```

对角线是一种格式属性，而非单元格拆分。每个单元格保留单个 [text_frame](https://reference.aspose.com/slides/python-net/aspose.slides/cell/text_frame/)，对角线两侧的区域不能独立编辑。

保存后的表格在 Microsoft PowerPoint 中的渲染效果：

![三个表格单元格分别显示从左上到右下的红色对角线、从左下到右上的蓝色对角线以及形成 X 的两条对角线。](diagonal-cell-borders.png)

*从左到右：向下对角线（红色，3 pt），向上对角线（蓝色，5 pt），以及两条对角线形成的 X。*

## **合并表格单元格**

使用 [merge_cells](https://reference.aspose.com/slides/python-net/aspose.slides/table/merge_cells/) 将矩形范围的表格单元格合并为一个单元格。指定范围左上角和右下角的单元格。最后一个参数控制合并是否可以包含指定范围之外的单元格；`False` 将合并限制在该范围内。

示例创建一个 4×4 的表格，列宽和行高均为 70 点，然后将 `(1, 1)` 到 `(2, 2)` 的四个中心单元格合并。得到的单元格跨越两列两行，而表格底层网格仍保留四列四行。要访问合并单元格的内容或格式，请使用其左上位置：本例中的 `table.rows[1][1]`。合并范围内的其他位置仍是表格网格的一部分，因此范围外单元格的索引保持不变。

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

在前面的示例中合并单元格会保留表格的网格。拆分单元格可能会引入新的网格列并改变其右侧单元格的列索引。Aspose.Slides 遵循 PowerPoint 的表格网格模型。

本例创建一个 4×4 的表格，列宽和行高均为 70 点，对单元格 `(1, 1)` 调用 [split_by_width](https://reference.aspose.com/slides/python-net/aspose.slides/cell/split_by_width/)。将单元格 70 点宽度的一半传入，以创建两个等宽单元格。

拆分后，这两个半单元格分别通过 `table.rows[1][1]` 和 `table.rows[1][2]` 访问。表格网格现在有五列：原本位于第 2、3 列的单元格分别移至第 3、4 列。行索引保持不变。拆分后访问单元格时请使用更新后的列索引。

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


<!-- visual-explanation:manage-cells:start -->
[![一个未合并的 70 点单元格拆分为两个 35 点单元格，添加了第五列网格并将右侧的索引向右移动。](visual-manage-cells-04c40789d81c.svg)](visual-manage-cells-04c40789d81c.svg)

*宽度拆分影响单元格 (1, 1)，使用零基 (column, row) 索引。其他行保持一个单元格跨越两个新列位置。*
<!-- visual-explanation:manage-cells:end -->

### **按行或列跨度拆分合并单元格**

要为数据填充准备合并的模板单元格，可使用 [split_by_row_span](https://reference.aspose.com/slides/python-net/aspose.slides/cell/split_by_row_span/) 按现有行边界拆分，或使用 [split_by_col_span](https://reference.aspose.com/slides/python-net/aspose.slides/cell/split_by_col_span/) 按列边界拆分。

`index` 参数计数的是拆分上部的行或左部的列，相对于合并区域：

- 行拆分：`0 < index <` [row_span](https://reference.aspose.com/slides/python-net/aspose.slides/cell/row_span/)。
- 列拆分：`0 < index <` [col_span](https://reference.aspose.com/slides/python-net/aspose.slides/cell/col_span/)。

示例假设演示文稿的第一张幻灯片的第一形状是表格，且 `(1, 2)` 与 `(1, 3)` 垂直合并。它从下方位置出发，使用 [first_column_index](https://reference.aspose.com/slides/python-net/aspose.slides/cell/first_column_index/) 和 [first_row_index](https://reference.aspose.com/slides/python-net/aspose.slides/cell/first_row_index/) 定位起点并检查两个跨度。`split_by_row_span` 并将索引设为 1 可将第 2 行和第 3 行分离用于产品名称。对于水平的两列合并，则改用 `split_by_col_span` 并将索引设为 1。

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

        # 检索拆分后表格中的结果单元格。
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

表格网格及其周围单元格索引保持不变。通过坐标检索得到的单元格均为单跨度（1），且 [is_merged_cell](https://reference.aspose.com/slides/python-net/aspose.slides/cell/is_merged_cell/) 返回 `False`。更大的区域在一次拆分后仍可保持部分合并状态。

原始文本及其格式保留在上（或左）单元格中；新单元格为空，但继承诸如填充、边框和边距等单元格格式。拆分后填充单元格并显式设置任何所需的文本格式。

保存的演示文稿包含分别为 “Product A” 和 “Product B” 的单元格，保留了模板单元格的格式。详见 [Cell API Reference](https://reference.aspose.com/slides/python-net/aspose.slides/cell/)。

### **按特定高度拆分单元格**

[split_by_height](https://reference.aspose.com/slides/python-net/aspose.slides/cell/split_by_height/) 接受上部的高度（单位：点）。[split_by_row_span](https://reference.aspose.com/slides/python-net/aspose.slides/cell/split_by_row_span/) 接受上部已有网格行的数量。要在右列的单元格中垂直居中一个 40 点高的单元格，可先用实际高度减去 40，再将剩余空间平均分配到上下两侧。

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [160, 160]
    row_heights = [140]
    
    table = slide.shapes.add_table(50, 50, column_widths, row_heights)
    table.rows[0][0].text_frame.text = "Left"

    height = table.rows[0][1].height
    margin = (height - 40) / 2

    table.rows[0][1].split_by_height(margin)
    table.rows[1][1].split_by_height(40)
    table.rows[1][1].text_frame.text = "Middle"

    presentation.save("split_by_height.pptx", slides.export.SaveFormat.PPTX)
```

第一次拆分添加了一行网格，留下 `table.rows[1][1]` 中的下部 90 点。第二次拆分将该单元格分为一个 40 点的中部单元格和一个 50 点的底部单元格。右列的三个单元格现在从上到下的高度分别为 50、40、50 点。左侧单元格跨越所有三行，保持原始高度 140 点。

![左侧单元格跨越整个表格高度，右侧有三个单元格，中间为 “Middle”。](split-by-height.png)

## **更改表格单元格背景颜色**

本例创建一个列宽 150 点、行高 50 点的表格。它将单元格 `(2, 3)`（第 3 列第 4 行）的 [fill_type](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/fill_type/) 设置为实色，并将 [solid_fill_color](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/solid_fill_color/) 设为红色。

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [150, 150, 150, 150]
    row_heights = [50, 50, 50, 50, 50]
    table = slide.shapes.add_table(50, 50, column_widths, row_heights)

    cell = table.rows[3][2]
    cell.cell_format.fill_format.fill_type = slides.FillType.SOLID
    cell.cell_format.fill_format.solid_fill_color.color = slides.Color.red

    presentation.save("cell_background_color.pptx", slides.export.SaveFormat.PPTX)
```

## **在表格单元格内添加图像**

在运行本示例之前，请将输入图像放在工作目录中。示例使用 [Images.from_file](https://reference.aspose.com/slides/python-net/aspose.slides/images/from_file/) 加载图像，并使用 [add_image](https://reference.aspose.com/slides/python-net/aspose.slides/imagecollection/add_image/) 将其添加到演示文稿的图像集合。随后将该图像分配给单元格 `(0, 0)`（表格中的第一个单元格）的图片填充。

[PictureFillMode.STRETCH](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillmode/) 会拉伸图像以填满单元格，这可能会改变其宽高比。列宽和行高均以点为单位。加载的图像在其 `with` 块结束时会自动释放。

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

**我可以为同一个单元格的不同侧设置不同的线粗细和样式吗？**

可以。单元格的 [top](https://reference.aspose.com/slides/python-net/aspose.slides/cellformat/border_top/)、[bottom](https://reference.aspose.com/slides/python-net/aspose.slides/cellformat/border_bottom/)、[left](https://reference.aspose.com/slides/python-net/aspose.slides/cellformat/border_left/)、[right](https://reference.aspose.com/slides/python-net/aspose.slides/cellformat/border_right/) 边框各有独立属性，因而每一侧的粗细和样式都可以不同。

**如果在将图片设为单元格背景后更改列/行尺寸，会发生什么？**

行为取决于 [fill mode](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillmode/)（stretch/til e）。使用拉伸时，图像会随新单元格尺寸调整；使用平铺时，平铺会重新计算。

**我可以将超链接分配给单元格的全部内容吗？**

[Hyperlinks](/slides/zh/python-net/manage-hyperlinks/) 是在单元格文本框（text portion）级别或整个表格/形状级别设置的。实践中，您可以将链接分配给文本片段或整个单元格内的所有文本。

**我可以在同一个单元格内使用不同的字体吗？**

可以。单元格的文本框支持 [portions](https://reference.aspose.com/slides/python-net/aspose.slides/portion/)（文本运行），每个 portion 可以拥有独立的字体族、样式、大小和颜色。