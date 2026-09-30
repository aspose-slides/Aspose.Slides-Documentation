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
- 表格标题行
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
description: "使用 Aspose.Slides for Python via .NET 在 PowerPoint 中管理表格行和列，并加快演示文稿的编辑和数据更新。"
---
## **介绍**

Aspose.Slides for Python via .NET 让您能够通过 [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/) 类在 PowerPoint 演示文稿中管理表格结构和格式。您可以指定标题行，克隆或删除行和列，并对整行或整列应用文本格式。

本文使用 Python 示例说明这些操作。它还展示了如何检索表格的样式预设，以便重新使用。表格行和列的索引从零开始。

## **控制行高**

使用 [Row.minimal_height](https://reference.aspose.com/slides/python-net/aspose.slides/row/minimal_height/) 设置行的最小高度（单位：磅）。它是下限，而非固定高度。[Row.height](https://reference.aspose.com/slides/python-net/aspose.slides/row/height/) 返回实际高度，只读。通过 [Table.rows](https://reference.aspose.com/slides/python-net/aspose.slides/table/rows/) 访问行。

示例加载 [row-height-input.pptx](row-height-input.pptx)，该文件在第一张幻灯片的第一个形状中包含一个表格。其第一行起始高度为 70 磅。单元格使用 18 磅 Arial 文本，换行，并且上下外边距为 6 磅；第二列的较长文本会换行成多行。示例将最小高度提升到 100 磅，然后降低到 20 磅，在每次更改后打印实际高度，并保存两个结果。

```python
import aspose.slides as slides

with slides.Presentation("row-height-input.pptx") as presentation:
    table = presentation.slides[0].shapes[0]
    row = table.rows[0]

    row.minimal_height = 100
    print(f"Increased: minimum = {row.minimal_height:.1f}, actual = {row.height:.1f} pt")
    presentation.save("row-height-increased.pptx", slides.export.SaveFormat.PPTX)

    row.minimal_height = 20
    print(f"Decreased: minimum = {row.minimal_height:.1f}, actual = {row.height:.1f} pt")
    presentation.save("row-height-decreased.pptx", slides.export.SaveFormat.PPTX)
```

使用提供的演示文稿时，增加最小值会为该行添加空间。降低最小值会移除多余空间，但实际高度仍大于 20 磅，因为文本和单元格外边距需要更多空间。仅仅降低最小值无法将行高度压低到内容所需空间以下。

实际高度受多种因素影响：

- **文本和字体大小：** 较长的文本、显式换行或更大的字体会需要更多垂直空间。
- **换行和列宽：** 启用换行后，较窄的 [Column.width](https://reference.aspose.com/slides/python-net/aspose.slides/column/width/) 会产生更多行。更宽的列可以减少垂直所需空间。
- **单元格外边距：** [Cell.margin_top](https://reference.aspose.com/slides/python-net/aspose.slides/cell/margin_top/) 和 [Cell.margin_bottom](https://reference.aspose.com/slides/python-net/aspose.slides/cell/margin_bottom/) 会添加垂直空间。[Cell.margin_left](https://reference.aspose.com/slides/python-net/aspose.slides/cell/margin_left/) 和 [Cell.margin_right](https://reference.aspose.com/slides/python-net/aspose.slides/cell/margin_right/) 会减小文本可用宽度，从而导致额外换行。

对于此不含合并单元格的表格，需要最多垂直空间的单元格决定整行的内容驱动下限。要让行更短，可能还需要缩短文本、减小字体大小或外边距，或加宽列。

下图显示了相同表格在相同比例下的效果。此次运行的实际高度分别为 70、100 和 55.2 磅：最终行仍高于其 20 磅的最小值。具体文本测量会因环境中可用的字体而异。下载保存的结果： [increased minimum](row-height-increased.pptx) 和 [decreased minimum](row-height-decreased.pptx)。

| 原始：最小 70 pt，实际 70 pt | 增加后：最小 100 pt，实际 100 pt | 减少后：最小 20 pt，实际 55.2 pt |
| --- | --- | --- |
| ![原始表格，第一行 70 点。](row-height-before.png) | ![将第一行最小值增加到 100 点后的表格。](row-height-increased.png) | ![将第一行最小值降低到 20 点后的表格；换行文本使行高仍高于最小值。](row-height-decreased.png) |

## **将首行设为标题**

使用 [first_row](https://reference.aspose.com/slides/python-net/aspose.slides/table/first_row/) 属性将首行标记为标题格式。其外观取决于表格应用的样式。

1. 使用 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类加载演示文稿。  
2. 访问第一张幻灯片。  
3. 访问该幻灯片上作为第一个形状存储的表格。  
4. 为其首行启用标题格式。  
5. 保存修改后的演示文稿。

示例需要 `table.pptx`，其中第一张幻灯片的第一个形状是表格。它为首行启用标题格式并保存为 `First_row_header.pptx`。

```python
import aspose.slides as slides

with slides.Presentation("table.pptx") as presentation:
    slide = presentation.slides[0]

    table = slide.shapes[0]
    table.first_row = True

    presentation.save("First_row_header.pptx", slides.export.SaveFormat.PPTX)
```

## **克隆表格行或列**

克隆行或列以重复使用其内容和格式。您可以将副本追加到表格末尾，或插入到指定位置。

1. 使用 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类加载演示文稿。  
2. 访问第一张幻灯片。  
3. 定义列宽和行高。  
4. 使用 [add_table](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_table/) 方法添加表格。  
5. 克隆所需的行。  
6. 克隆所需的列。  
7. 保存修改后的演示文稿。

示例需要 `Test.pptx`，其中至少包含一张幻灯片。它创建一个三列五行的表格，尺寸以磅为单位。随后将第一行和第一列的副本追加到表格末尾，再在索引 3（第四个位置）插入第二行和第二列的副本。结果表格拥有七行五列。`False` 参数禁用向相邻的合并行或列中克隆；此表格不含合并单元格。

```python
import aspose.slides as slides

with slides.Presentation("Test.pptx") as presentation:
    slide = presentation.slides[0]

    column_widths = [50, 50, 50]
    row_heights = [50, 30, 30, 30, 30]
    table = slide.shapes.add_table(100, 50, column_widths, row_heights)

    table.rows[0][0].text_frame.text = "Row 1 Cell 1"
    table.rows[0][1].text_frame.text = "Row 1 Cell 2"
    table.rows.add_clone(table.rows[0], False)

    table.rows[1][0].text_frame.text = "Row 2 Cell 1"
    table.rows[1][1].text_frame.text = "Row 2 Cell 2"
    table.rows.insert_clone(3, table.rows[1], False)

    table.columns.add_clone(table.columns[0], False)
    table.columns.insert_clone(3, table.columns[1], False)

    presentation.save("table_out.pptx", slides.export.SaveFormat.PPTX)
```

## **从表格中删除行或列**

删除表格中不再需要的行或列。删除项会导致其后面的行或列的索引向前移动。

1. 使用 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类创建演示文稿。  
2. 访问第一张幻灯片。  
3. 定义列宽和行高。  
4. 使用 [add_table](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_table/) 方法添加表格。  
5. 删除第二行和第二列。  
6. 保存修改后的演示文稿。

该示例创建一个 3×3 表格并删除索引为 1 的行和列，生成一个 2×2 表格，保存为 `TestTable_out.pptx`。尺寸以磅为单位。`False` 参数禁用删除相邻的合并行或列；此表格不含合并单元格。

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

对整行应用文本格式，以保持单元格的一致性。您可以设置字体属性、段落格式和文本方向，而无需逐个单元格设置。

1. 使用 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类加载演示文稿。  
2. 访问第一张幻灯片上的表格。  
3. 为首行设置 [font_height](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/font_height/)。  
4. 为首行设置 [alignment](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/alignment/) 和 [margin_right](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/margin_right/)。  
5. 为第二行设置 [text_vertical_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/text_vertical_type/)。  
6. 保存修改后的演示文稿。

示例需要 `table.pptx`，其中第一张幻灯片的第一个形状是表格且至少有两行。它对首行应用 25 磅文本、右对齐以及 20 磅的右段落外边距，然后对第二行设置竖排文本。

```python
import aspose.slides as slides

with slides.Presentation("table.pptx") as presentation:
    slide = presentation.slides[0]

    table = slide.shapes[0]

    portion_format = slides.PortionFormat()
    portion_format.font_height = 25
    table.rows[0].set_text_format(portion_format)

    paragraph_format = slides.ParagraphFormat()
    paragraph_format.alignment = slides.TextAlignment.RIGHT
    paragraph_format.margin_right = 20
    table.rows[0].set_text_format(paragraph_format)

    text_frame_format = slides.TextFrameFormat()
    text_frame_format.text_vertical_type = slides.TextVerticalType.VERTICAL
    table.rows[1].set_text_format(text_frame_format)

    presentation.save("row_formatting.pptx", slides.export.SaveFormat.PPTX)
```

## **在表格列级别设置文本格式**

对整列应用文本格式，以保持单元格的一致性。您可以设置字体属性、段落格式和文本方向，而无需逐个单元格设置。

1. 使用 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类加载演示文稿。  
2. 访问第一张幻灯片上的表格。  
3. 为首列设置 [font_height](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/font_height/)。  
4. 为首列设置 [alignment](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/alignment/) 和 [margin_right](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/margin_right/)。  
5. 为第二列设置 [text_vertical_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/text_vertical_type/)。  
6. 保存修改后的演示文稿。

示例需要 `table.pptx`，其中第一张幻灯片的第一个形状是表格且至少有两列。它对首列应用 25 磅文本、右对齐以及 20 磅的右段落外边距，然后对第二列设置竖排文本。

```python
import aspose.slides as slides

with slides.Presentation("table.pptx") as presentation:
    slide = presentation.slides[0]

    table = slide.shapes[0]

    portion_format = slides.PortionFormat()
    portion_format.font_height = 25
    table.columns[0].set_text_format(portion_format)

    paragraph_format = slides.ParagraphFormat()
    paragraph_format.alignment = slides.TextAlignment.RIGHT
    paragraph_format.margin_right = 20
    table.columns[0].set_text_format(paragraph_format)

    text_frame_format = slides.TextFrameFormat()
    text_frame_format.text_vertical_type = slides.TextVerticalType.VERTICAL
    table.columns[1].set_text_format(text_frame_format)

    presentation.save("column_formatting.pptx", slides.export.SaveFormat.PPTX)
```

## **获取表格样式属性**

使用 [style_preset](https://reference.aspose.com/slides/python-net/aspose.slides/table/style_preset/) 属性检索已应用于表格的预设，并在另一表格上重复使用。该属性标识预设本身，而不是单元格的单独格式覆盖。

示例创建一个表格，应用 [TableStylePreset.DARK_STYLE1](https://reference.aspose.com/slides/python-net/aspose.slides/tablestylepreset/) 并读取回该预设。当检索到的预设与应用的预设匹配时，打印 `True`，并将表格保存为 `table.pptx`。

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [100, 150]
    row_heights = [5, 5, 5]
    table = slide.shapes.add_table(10, 10, column_widths, row_heights)
    table.style_preset = slides.TableStylePreset.DARK_STYLE1

    style_preset = table.style_preset
    print(style_preset == slides.TableStylePreset.DARK_STYLE1)

    presentation.save("table.pptx", slides.export.SaveFormat.PPTX)
```

## **常见问题**

**我能将 PowerPoint 主题/样式应用到已创建的表格吗？**

是的。表格会继承幻灯片/版面/母版的主题，您仍可以在此基础上覆盖填充、边框和文本颜色。

**我可以像在 Excel 中那样对表格行进行排序吗？**

不可以，Aspose.Slides 表格没有内置的排序或筛选功能。请先在内存中对数据进行排序，然后按该顺序重新填充表格行。

**我能在保持特定单元格自定义颜色的同时使用条纹列吗？**

可以。打开条纹列后，仍然可以对特定单元格进行本地格式覆盖；单元格级别的格式会优先于表格样式。