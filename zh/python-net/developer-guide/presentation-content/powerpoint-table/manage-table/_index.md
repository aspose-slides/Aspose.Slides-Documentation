---
title: 管理表格
type: docs
weight: 10
url: /zh/python-net/manage-table/
keywords: "表格, 创建表格, 访问表格, 表格长宽比, PowerPoint 演示, Python, Aspose.Slides for Python via .NET"
description: "在 Python 中创建和管理 PowerPoint 演示中的表格"

---

在 PowerPoint 中，表格是一种有效展示和表述信息的方式。单元格网格中的信息（以行和列排列）直观且易于理解。

Aspose.Slides 提供了 [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/) 类, [ITable](https://reference.aspose.com/slides/python-net/aspose.slides/itable/) 接口, [Cell](https://reference.aspose.com/slides/python-net/aspose.slides/cell/) 类, [ICell](https://reference.aspose.com/slides/python-net/aspose.slides/icell/) 接口以及其他类型，使您可以创建、更新和管理各种演示中的表格。

## **从头开始创建表格**

1. 创建 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例。
2. 通过其索引获取幻灯片的引用。
3. 定义一个 `columnWidth` 数组。
4. 定义一个 `rowHeight` 数组。
5. 通过 `add_table(x, y, column_widths, row_heights)` 方法将 [ITable](https://reference.aspose.com/slides/python-net/aspose.slides/itable/) 对象添加到幻灯片。
6. 迭代每个 [ICell](https://reference.aspose.com/slides/python-net/aspose.slides/icell/)，应用格式到顶部、底部、右侧和左侧边框。
7. 合并表格第一行的前两个单元格。
8. 访问 [ICell](https://reference.aspose.com/slides/python-net/aspose.slides/icell/)'s [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/)。
9. 向 [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) 添加一些文本。
10. 保存修改后的演示文稿。

以下 Python 代码展示了如何在演示文稿中创建表格：

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# 实例化代表 PPTX 文件的 Presentation 类
with slides.Presentation() as pres:
    # 访问第一张幻灯片
    sld = pres.slides[0]

    # 定义列宽和行高
    dblCols =  [50, 50, 50] 
    dblRows =  [50, 30, 30, 30, 30] 

    # 向幻灯片添加表格形状
    tbl = sld.shapes.add_table(100, 50, dblCols, dblRows)

    # 设置每个单元格的边框格式
    for row in range(len(tbl.rows)):
        for cell in range(len(tbl.rows[row])):
            tbl.rows[row][cell].cell_format.border_top.fill_format.fill_type = slides.FillType.SOLID
            tbl.rows[row][cell].cell_format.border_top.fill_format.solid_fill_color.color = draw.Color.red
            tbl.rows[row][cell].cell_format.border_top.width = 5

            tbl.rows[row][cell].cell_format.border_bottom.fill_format.fill_type = slides.FillType.SOLID
            tbl.rows[row][cell].cell_format.border_bottom.fill_format.solid_fill_color.color= draw.Color.red
            tbl.rows[row][cell].cell_format.border_bottom.width =5

            tbl.rows[row][cell].cell_format.border_left.fill_format.fill_type = slides.FillType.SOLID
            tbl.rows[row][cell].cell_format.border_left.fill_format.solid_fill_color.color =draw.Color.red
            tbl.rows[row][cell].cell_format.border_left.width = 5

            tbl.rows[row][cell].cell_format.border_right.fill_format.fill_type = slides.FillType.SOLID
            tbl.rows[row][cell].cell_format.border_right.fill_format.solid_fill_color.color = draw.Color.red
            tbl.rows[row][cell].cell_format.border_right.width = 5
        

    # 合并第 1 行的单元格 1 和 2
    tbl.merge_cells(tbl.rows[0][0], tbl.rows[1][1], False)

    # 向合并的单元格添加文本
    tbl.rows[0][0].text_frame.text = "合并单元格"

    # 将演示文稿保存到磁盘
    pres.save("table.pptx", slides.export.SaveFormat.PPTX)
```

## **标准表格中的编号**

在标准表格中，单元格的编号是简单且从零开始的。表格中的第一个单元格索引为 0,0（列 0，行 0）。

例如，具有 4 列和 4 行的表格中的单元格编号如下：

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

以下 Python 代码展示了如何为表格中的单元格指定编号：

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# 实例化代表 PPTX 文件的 Presentation 类
with slides.Presentation() as pres:
    # 访问第一张幻灯片
    sld = pres.slides[0]

    # 定义列宽和行高
    dblCols =  [70, 70, 70, 70] 
    dblRows =  [70, 70, 70, 70] 

    # 向幻灯片添加表格形状
    tbl = sld.shapes.add_table(100, 50, dblCols, dblRows)

    # 设置每个单元格的边框格式
    for row in tbl.rows:
        for cell in row:
            cell.cell_format.border_top.fill_format.fill_type = slides.FillType.SOLID
            cell.cell_format.border_top.fill_format.solid_fill_color.color = draw.Color.red
            cell.cell_format.border_top.width = 5

            cell.cell_format.border_bottom.fill_format.fill_type = slides.FillType.SOLID
            cell.cell_format.border_bottom.fill_format.solid_fill_color.color = draw.Color.red
            cell.cell_format.border_bottom.width = 5

            cell.cell_format.border_left.fill_format.fill_type = slides.FillType.SOLID
            cell.cell_format.border_left.fill_format.solid_fill_color.color = draw.Color.red
            cell.cell_format.border_left.width = 5

            cell.cell_format.border_right.fill_format.fill_type = slides.FillType.SOLID
            cell.cell_format.border_right.fill_format.solid_fill_color.color = draw.Color.red
            cell.cell_format.border_right.width = 5

    # 将演示文稿保存到磁盘
    pres.save("StandardTables_out.pptx", slides.export.SaveFormat.PPTX)
```

## **访问现有表格**

1. 创建 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例。

2. 通过其索引获取包含表格的幻灯片的引用。

3. 创建 [ITable](https://reference.aspose.com/slides/python-net/aspose.slides/itable/) 对象并将其设置为 null。

4. 迭代表单元格对象直到找到表格。

   如果您怀疑您处理的幻灯片包含一个表格，您可以简单地检查它包含的所有形状。当形状被识别为表格时，您可以将其强制转换为 [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/) 对象。但如果您处理的幻灯片包含多个表格，那么最好通过其 `alternative_text` 查找所需的表格。

5. 使用 [ITable](https://reference.aspose.com/slides/python-net/aspose.slides/itable/) 对象与表格进行操作。在下面的示例中，我们向表格添加了新行。

6. 保存修改后的演示文稿。

以下 Python 代码展示了如何访问和操作现有表格：

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# 实例化代表 PPTX 文件的 Presentation 类
with slides.Presentation(path + "UpdateExistingTable.pptx") as pres:
    # 访问第一张幻灯片
    sld = pres.slides[0]

    # 初始化 null TableEx
    tbl = None

    # 迭代形状并设置找到的表格的引用
    for shp in sld.shapes:
        if type(shp) is slides.Table:
            tbl = shp

    # 设置第二行第一列的文本
    tbl.rows[0][1].text_frame.text = "新"

    # 将修改后的演示文稿保存到磁盘
    pres.save("table1_out.pptx", slides.export.SaveFormat.PPTX)
```


## **在表格中对齐文本**

1. 创建 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例。
2. 通过其索引获取幻灯片的引用。
3. 向幻灯片添加 [ITable](https://reference.aspose.com/slides/python-net/aspose.slides/itable/) 对象。
4. 从表格中访问 [ITextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/itextframe/) 对象。
5. 访问 [ITextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/itextframe/) [IParagraph](https://reference.aspose.com/slides/python-net/aspose.slides/iparagraph/)。
6. 垂直对齐文本。
7. 保存修改后的演示文稿。

以下 Python 代码展示了如何在表格中对齐文本：

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# 创建 Presentation 类的实例
with slides.Presentation() as presentation:
    # 获取第一张幻灯片 
    slide = presentation.slides[0]

    # 定义列宽和行高
    dblCols =  [120, 120, 120, 120] 
    dblRows =  [100, 100, 100, 100] 

    # 向幻灯片添加表格形状
    tbl = slide.shapes.add_table(100, 50, dblCols, dblRows)
    tbl.rows[1][0].text_frame.text = "10"
    tbl.rows[2][0].text_frame.text = "20"
    tbl.rows[3][0].text_frame.text = "30"

    # 访问文本框
    txtFrame = tbl.rows[0][0].text_frame

    # 为文本框创建段落对象
    paragraph = txtFrame.paragraphs[0]

    # 为段落创建部分对象
    portion = paragraph.portions[0]
    portion.text = "这里是文本"
    portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
    portion.portion_format.fill_format.solid_fill_color.color = draw.Color.black

    # 垂直对齐文本
    cell = tbl.rows[0][0]
    cell.text_anchor_type = slides.TextAnchorType.CENTER
    cell.text_vertical_type = slides.TextVerticalType.VERTICAL270

    # 将演示文稿保存到磁盘
    presentation.save("Vertical_Align_Text_out.pptx", slides.export.SaveFormat.PPTX)
```

## **在表格级别设置文本格式**

1. 创建 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例。
2. 通过其索引获取幻灯片的引用。
3. 从幻灯片访问 [ITable](https://reference.aspose.com/slides/python-net/aspose.slides/itable/) 对象。
4. 设置文本的 `font_height`。
5. 设置 `alignment` 和 `margin_right`。
6. 设置 `text_vertical_type`。
7. 保存修改后的演示文稿。

以下 Python 代码显示了如何将您的首选格式选项应用于表格中的文本：

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# 创建 Presentation 类的实例
with slides.Presentation() as presentation:
    someTable = presentation.slides[0].shapes.add_table(100, 100, [100, 50, 30], [30, 50, 30])

    # 设置表格单元格的字体高度
    portionFormat = slides.PortionFormat()
    portionFormat.font_height = 25
    someTable.set_text_format(portionFormat)

    # 一次性设置表格单元格的文本对齐和右边距
    paragraphFormat = slides.ParagraphFormat()
    paragraphFormat.alignment = slides.TextAlignment.RIGHT
    paragraphFormat.margin_right = 20
    someTable.set_text_format(paragraphFormat)

    # 设置表格单元格的文本垂直类型
    textFrameFormat = slides.TextFrameFormat()
    textFrameFormat.text_vertical_type = slides.TextVerticalType.VERTICAL
    someTable.set_text_format(textFrameFormat)


    presentation.save("result.pptx", slides.export.SaveFormat.PPTX)
```

## **获取表格样式属性**

Aspose.Slides 允许您检索表格的样式属性，以便您可以将这些细节用于另一个表格或其他地方。以下 Python 代码展示了如何从表格预设样式中获取样式属性：

```python
import aspose.slides as slides

with slides.Presentation() as pres:
    table = pres.slides[0].shapes.add_table(10, 10, [100, 150], [5, 5, 5])
    table.style_preset = slides.TableStylePreset.DARK_STYLE1
    pres.save("table.pptx", slides.export.SaveFormat.PPTX)
```

## **锁定表格的长宽比**

几何形状的长宽比是其在不同维度上的大小比率。Aspose.Slides 提供了 `aspect_ratio_locked` 属性，以允许您锁定表格和其他形状的长宽比设置。

以下 Python 代码展示了如何锁定表格的长宽比：

```c#
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as pres:
    table = pres.slides[0].shapes.add_table(100, 100, [100, 50, 30], [30, 50, 30])
    print("锁定长宽比设定: {0}".format(table.shape_lock.aspect_ratio_locked))

    table.shape_lock.aspect_ratio_locked = not table.shape_lock.aspect_ratio_locked

    print("锁定长宽比设定: {0}".format(table.shape_lock.aspect_ratio_locked))

    pres.save("pres-out.pptx", slides.export.SaveFormat.PPTX)
```