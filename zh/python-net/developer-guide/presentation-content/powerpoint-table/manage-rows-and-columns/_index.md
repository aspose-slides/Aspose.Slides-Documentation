---
title: 管理行和列
type: docs
weight: 20
url: /zh/python-net/manage-rows-and-columns/
keywords: "表格, 表格行和列, PowerPoint 演示文稿, Python, Aspose.Slides for Python via .NET"
description: "在 Python 中管理 PowerPoint 演示文稿中的表格行和列"
---

为了让您管理 PowerPoint 演示文稿中表格的行和列，Aspose.Slides 提供了 [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/) 类、[ITable](https://reference.aspose.com/slides/python-net/aspose.slides/itable/) 接口和其他许多类型。

## **将第一行设置为标题**

1. 创建一个 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例并加载演示文稿。
2. 通过其索引获取幻灯片的引用。
3. 创建一个 [ITable](https://reference.aspose.com/slides/python-net/aspose.slides/itable/) 对象并将其设置为 null。
4. 遍历所有 [IShape](https://reference.aspose.com/slides/python-net/aspose.slides/ishape/) 对象以找到相关表格。
5. 将表格的第一行设置为其标题。

这段 Python 代码向您展示了如何将表格的第一行设置为其标题：

```python
import aspose.slides as slides

# 实例化 Presentation 类
with slides.Presentation("table.pptx") as pres:
    # 访问第一张幻灯片
    sld = pres.slides[0]

    # 初始化 null TableEx
    tbl = None

    # 遍历形状并设置对表格的引用
    for shp in sld.shapes:
        if type(shp) is slides.Table:
            tbl = shp

    # 将表格的第一行设置为标题
    tbl.first_row = True
    
    # 将演示文稿保存到磁盘
    pres.save("table_out.pptx", slides.export.SaveFormat.PPTX)
```


## **克隆表格的行或列**

1. 创建一个 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例并加载演示文稿。
2. 通过其索引获取幻灯片的引用。
3. 定义一个 `columnWidth` 数组。
4. 定义一个 `rowHeight` 数组。
5. 通过 `add_table(x, y, column_widths, row_heights)` 方法将 [ITable](https://reference.aspose.com/slides/python-net/aspose.slides/itable/) 对象添加到幻灯片。
6. 克隆表格行。
7. 克隆表格列。
8. 保存修改后的演示文稿。

这段 Python 代码向您展示了如何克隆 PowerPoint 表格的行或列：

```python
 import aspose.slides as slides

# 实例化 Presentation 类
with slides.Presentation() as presentation:

    # 访问第一张幻灯片
    sld = presentation.slides[0]

    # 定义列宽和行高
    dblCols =  [50, 50, 50] 
    dblRows =  [50, 30, 30, 30, 30] 

    # 向幻灯片添加表格形状
    table = sld.shapes.add_table(100, 50, dblCols, dblRows)

    # 向第1行第1个单元格添加文本
    table.rows[0][0].text_frame.text = "第1行 第1个单元格"

    # 向第1行第2个单元格添加文本
    table.rows[1][0].text_frame.text = "第1行 第2个单元格"

    # 克隆第1行到表的末尾
    table.rows.add_clone(table.rows[0], False)

    # 向第2行第1个单元格添加文本
    table.rows[0][1].text_frame.text = "第2行 第1个单元格"

    # 向第2行第2个单元格添加文本
    table.rows[1][1].text_frame.text = "第2行 第2个单元格"

    # 克隆第2行为表的第4行
    table.rows.insert_clone(3,table.rows[1], False)

    # 在末尾克隆第一列
    table.columns.add_clone(table.columns[0], False)

    # 在第4列索引处克隆第2列
    table.columns.insert_clone(3,table.columns[1], False)
    
    # 将演示文稿保存到磁盘
    presentation.save("table_out.pptx", slides.export.SaveFormat.PPTX)
```

## **从表格中删除行或列**

1. 创建一个 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例并加载演示文稿。
2. 通过其索引获取幻灯片的引用。
3. 定义一个 `columnWidth` 数组。
4. 定义一个 `rowHeight` 数组。
5. 通过 `add_table(x, y, column_widths, row_heights)` 方法将 [ITable](https://reference.aspose.com/slides/python-net/aspose.slides/itable/) 对象添加到幻灯片。
6. 删除表格行。
7. 删除表格列。
8. 保存修改后的演示文稿。

这段 Python 代码向您展示了如何从表格中删除行或列：

```python
import aspose.slides as slides

with slides.Presentation() as pres:
    slide = pres.slides[0]
    colWidth =  [100, 50, 30] 
    rowHeight =  [30, 50, 30] 

    table = slide.shapes.add_table(100, 100, colWidth, rowHeight)
    table.rows.remove_at(1, False)
    table.columns.remove_at(1, False)
    pres.save("TestTable_out.pptx", slides.export.SaveFormat.PPTX)
```

## **在表格行级别设置文本格式**

1. 创建一个 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例并加载演示文稿。
2. 通过其索引获取幻灯片的引用。
3. 从幻灯片访问相关的 [ITable](https://reference.aspose.com/slides/python-net/aspose.slides/itable/) 对象。
4. 设置第一行单元格的 `font_height`。
5. 设置第一行单元格的 `alignment` 和 `margin_right`。
6. 设置第二行单元格的 `text_vertical_type`。
7. 保存修改后的演示文稿。

这段 Python 代码演示了该操作：

```python
import aspose.slides as slides

# 创建 Presentation 类的实例
with slides.Presentation() as presentation:
    
    slide = presentation.slides[0]

    someTable = slide.shapes.add_table(100, 100, [100, 50, 30], [30, 50, 30])

    # 设置第一行单元格的字体高度
    portionFormat = slides.PortionFormat()
    portionFormat.font_height = 25
    someTable.rows[0].set_text_format(portionFormat)

    # 设置第一行单元格的文本对齐方式和右边距
    paragraphFormat = slides.ParagraphFormat()
    paragraphFormat.alignment = slides.TextAlignment.RIGHT
    paragraphFormat.margin_right = 20
    someTable.rows[0].set_text_format(paragraphFormat)

    # 设置第二行单元格的文本垂直类型
    textFrameFormat = slides.TextFrameFormat()
    textFrameFormat.text_vertical_type = slides.TextVerticalType.VERTICAL
    someTable.rows[1].set_text_format(textFrameFormat)
	
    # 将演示文稿保存到磁盘
    presentation.save("result.pptx", slides.export.SaveFormat.PPTX)
```

## **在表格列级别设置文本格式**

1. 创建一个 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例并加载演示文稿。
2. 通过其索引获取幻灯片的引用。
3. 从幻灯片访问相关的 [ITable](https://reference.aspose.com/slides/python-net/aspose.slides/itable/) 对象。
4. 设置第一列单元格的 `font_height`。
5. 设置第一列单元格的 `alignment` 和 `margin_right`。
6. 设置第二列单元格的 `text_vertical_type`。
7. 保存修改后的演示文稿。

这段 Python 代码演示了该操作：

```python
import aspose.slides as slides

# 创建 Presentation 类的实例
with slides.Presentation() as pres:
    slide = pres.slides[0]
    someTable = slide.shapes.add_table(100, 100, [100, 50, 30], [30, 50, 30])

    # 设置第一列单元格的字体高度
    portionFormat = slides.PortionFormat()
    portionFormat.font_height = 25
    someTable.columns[0].set_text_format(portionFormat)

    # 设置第一列单元格的文本对齐方式和右边距 
    paragraphFormat = slides.ParagraphFormat()
    paragraphFormat.alignment = slides.TextAlignment.RIGHT
    paragraphFormat.margin_right = 20
    someTable.columns[0].set_text_format(paragraphFormat)

    # 设置第二列单元格的文本垂直类型
    textFrameFormat = slides.TextFrameFormat()
    textFrameFormat.text_vertical_type = slides.TextVerticalType.VERTICAL
    someTable.columns[1].set_text_format(textFrameFormat)

    # 将演示文稿保存到磁盘
    pres.save("result.pptx", slides.export.SaveFormat.PPTX)
```

## **获取表格样式属性**

Aspose.Slides 允许您检索表格的样式属性，以便您可以将这些细节用于另一个表格或其他地方。这段 Python 代码向您展示了如何从表格预设样式中获取样式属性：

```python
import aspose.slides as slides

with slides.Presentation() as pres:
    table = pres.slides[0].shapes.add_table(10, 10, [100, 150], [5, 5, 5])
    table.style_preset = slides.TableStylePreset.DARK_STYLE1
    pres.save("table.pptx", slides.export.SaveFormat.PPTX)
```