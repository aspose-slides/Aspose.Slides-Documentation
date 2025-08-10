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
- OpenDocument
- 演示文稿
- Python
- Aspose.Slides
description: "使用 Aspose.Slides for Python via .NET 轻松管理 PowerPoint 和 OpenDocument 中的表格单元格。快速掌握单元格的访问、修改与样式设置，实现流畅的幻灯片自动化。"
---

## **识别合并的表格单元格**
1. 创建一个 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例。
2. 从第一页获取表格。
3. 遍历表格的行和列以查找合并单元格。
4. 在找到合并单元格时打印消息。

以下Python代码展示了如何识别演示文稿中的合并表格单元格：

```py
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation(path + "SomePresentationWithTable.pptx") as pres:
    table = pres.slides[0].shapes[0] # 假设 #0.Shape#0 是一个表格
    for i in range(len(table.rows)):
        for j in range(len(table.columns)):
            currentCell = table.rows[i][j]
            if currentCell.is_merged_cell:
                print("单元格 01 是合并单元格的一部分，RowSpan=2 和 ColSpan=3，起始于单元格 45.".format(
                    i, j, currentCell.row_span, currentCell.col_span, currentCell.first_row_index, currentCell.first_column_index))
```

## **移除表格单元格边框**
1. 创建一个 `Presentation` 类的实例。
2. 通过索引获取幻灯片的引用。
3. 定义宽度的列数组。
4. 定义高度的行数组。
5. 通过 `AddTable` 方法向幻灯片添加一个表格。
6. 遍历每一个单元格以清除上、下、右和左边框。
7. 将修改后的演示文稿保存为PPTX文件。

以下Python代码展示了如何移除表格单元格的边框：

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# 实例化表示PPTX文件的Presentation类
with slides.Presentation() as pres:
   # 访问第一张幻灯片
    sld = pres.slides[0]

    # 定义带宽的列和带高度的行
    dblCols = [ 50, 50, 50, 50 ]
    dblRows = [ 50, 30, 30, 30, 30 ]

    # 向幻灯片添加一个表格形状
    tbl = sld.shapes.add_table(100, 50, dblCols, dblRows)

    # 为每个单元格设置边框格式
    for row in tbl.rows:
        for cell in row:
            cell.cell_format.border_top.fill_format.fill_type = slides.FillType.NO_FILL
            cell.cell_format.border_bottom.fill_format.fill_type = slides.FillType.NO_FILL
            cell.cell_format.border_left.fill_format.fill_type = slides.FillType.NO_FILL
            cell.cell_format.border_right.fill_format.fill_type = slides.FillType.NO_FILL

    # 将PPTX文件写入磁盘
    pres.save("table_out.pptx", slides.export.SaveFormat.PPTX)
```


## **合并单元格中的编号**
如果我们合并两个单元格对 (1, 1) x (2, 1) 和 (1, 2) x (2, 2)，则结果表格将被编号。以下Python代码演示了此过程：

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# 实例化表示PPTX文件的Presentation类
with slides.Presentation() as presentation:
    # 访问第一张幻灯片
    sld = presentation.slides[0]

    # 定义带宽的列和带高度的行
    dblCols =  [70, 70, 70, 70] 
    dblRows =  [70, 70, 70, 70] 

    # 向幻灯片添加一个表格形状
    tbl = sld.shapes.add_table(100, 50, dblCols, dblRows)

    # 为每个单元格设置边框格式
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

    # 合并单元格 (1, 1) x (2, 1)
    tbl.merge_cells(tbl.rows[1][1], tbl.rows[2][1], False)

    # 合并单元格 (1, 2) x (2, 2)
    tbl.merge_cells(tbl.rows[1][2], tbl.rows[2][2], False)

    presentation.save("MergeCells_out.pptx", slides.export.SaveFormat.PPTX)
```

然后我们通过合并 (1, 1) 和 (1, 2) 进一步合并单元格。结果是一个表格，其中心包含一个大型合并单元格：

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# 实例化表示PPTX文件的Presentation类
with slides.Presentation() as presentation:
    # 访问第一张幻灯片
    slide = presentation.slides[0]

    # 定义带宽的列和带高度的行
    dblCols =  [70, 70, 70, 70] 
    dblRows =  [70, 70, 70, 70]

    # 向幻灯片添加一个表格形状
    table = slide.shapes.add_table(100, 50, dblCols, dblRows)

    # 为每个单元格设置边框格式
    for row in table.rows:
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

    # 合并单元格 (1, 1) x (2, 1)
    table.merge_cells(table.rows[1][1], table.rows[2][1], False)

    # 合并单元格 (1, 2) x (2, 2)
    table.merge_cells(table.rows[1][2], table.rows[2][2], False)

    # 合并单元格 (1, 2) x (2, 2)
    table.merge_cells(table.rows[1][1], table.rows[1][2], True)

    # 将PPTX文件写入磁盘
    presentation.save("MergeCells1_out.pptx", slides.export.SaveFormat.PPTX)
```

## **拆分单元格中的编号**
在之前的示例中，当表格单元格被合并时，其他单元格中的编号或编号系统没有改变。

这一次，我们取一个普通表格（没有合并单元格的表格），然后尝试拆分单元格 (1,1) 以获得一个特殊的表格。您可能想注意这个表格的编号，可能会被认为很奇怪。但是，这就是Microsoft PowerPoint对表格单元格进行编号的方式，Aspose.Slides也这样做。

以下Python代码演示了我们描述的过程：

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# 实例化表示PPTX文件的Presentation类
with slides.Presentation() as presentation:
    # 访问第一张幻灯片
    slide = presentation.slides[0]

    # 定义带宽的列和带高度的行
    dblCols =  [70, 70, 70, 70] 
    dblRows =  [70, 70, 70, 70] 

    # 向幻灯片添加一个表格形状
    table = slide.shapes.add_table(100, 50, dblCols, dblRows)

    # 为每个单元格设置边框格式
    for row in table.rows:
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

    # 合并单元格 (1, 1) x (2, 1)
    table.merge_cells(table.rows[1][1], table.rows[2][1], False)

    # 合并单元格 (1, 2) x (2, 2)
    table.merge_cells(table.rows[1][2], table.rows[2][2], False)

    # 拆分单元格 (1, 1)
    table.rows[1][1].split_by_width(table.rows[2][1].width / 2)

    # 将PPTX文件写入磁盘
    presentation.save("CellSplit_out.pptx", slides.export.SaveFormat.PPTX)
```

## **改变表格单元格背景颜色**

以下Python代码展示了如何改变表格单元格的背景颜色：

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    dblCols = [ 150, 150, 150, 150 ]
    dblRows = [ 50, 50, 50, 50, 50 ]

    # 创建一个新表格
    table = slide.shapes.add_table(50, 50, dblCols, dblRows)

    # 设置单元格的背景颜色 
    cell = table.rows[2][3]
    cell.cell_format.fill_format.fill_type = slides.FillType.SOLID
    cell.cell_format.fill_format.solid_fill_color.color = draw.Color.red

    presentation.save("cell_background_color.pptx", slides.export.SaveFormat.PPTX)
```

## **在表格单元格中添加图像**
1. 创建一个 `Presentation` 类的实例。
2. 通过索引获取幻灯片的引用。
3. 定义宽度的列数组。
4. 定义高度的行数组。
5. 通过 `AddTable` 方法向幻灯片添加一个表格。 
6. 创建一个 `Bitmap` 对象来保存图像文件。
7. 将位图图像添加到 `IPPImage` 对象。
8. 将表格单元格的 `FillFormat` 设置为 `Picture`。
9. 将图像添加到表格的第一个单元格。
10. 将修改后的演示文稿保存为PPTX文件。

以下Python代码展示了如何在创建表格时将图像放置在表格单元格中：

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# 实例化一个Presentation类对象
with slides.Presentation() as presentation:
    # 访问第一张幻灯片
    islide = presentation.slides[0]

    # 定义带宽的列和带高度的行
    dblCols =  [150, 150, 150, 150] 
    dblRows =  [100, 100, 100, 100, 90] 

    # 向幻灯片添加一个表格形状
    tbl = islide.shapes.add_table(50, 50, dblCols, dblRows)

    # 创建一个位图图像对象以保存图像文件
    image = draw.Bitmap(path + "aspose-logo.jpg")

    # 使用位图对象创建一个IPPImage对象
    imgx1 = presentation.images.add_image(image)

    # 将图像添加到第一个表格单元格
    tbl.rows[0][0].cell_format.fill_format.fill_type = slides.FillType.PICTURE
    tbl.rows[0][0].cell_format.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.STRETCH
    tbl.rows[0][0].cell_format.fill_format.picture_fill_format.picture.image = imgx1

    # 将PPTX保存到磁盘
    presentation.save("Image_In_TableCell_out.pptx", slides.export.SaveFormat.PPTX)
```