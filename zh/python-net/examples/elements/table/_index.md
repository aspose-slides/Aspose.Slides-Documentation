---
title: 表格
type: docs
weight: 120
url: /zh/python-net/examples/elements/table/
keywords:
- 表格
- 添加表格
- 访问表格
- 删除表格
- 合并单元格
- 代码示例
- PowerPoint
- OpenDocument
- 演示文稿
- Python
- Aspose.Slides
description: "使用 Aspose.Slides 在 Python 中创建和格式化表格：插入数据、合并单元格、设置边框样式、对齐内容，并支持 PPT、PPTX 和 ODP 的导入/导出。"
---
使用 **Aspose.Slides for Python via .NET** 添加表格、访问表格、删除表格和合并单元格的示例。

## **添加表格**

创建一个包含两行两列的简单表格。

```py
def add_table():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # 定义列宽和行高。
        widths = [80, 80]
        heights = [30, 30]

        # 向幻灯片添加表格形状。
        table = slide.shapes.add_table(50, 50, widths, heights)

        presentation.save("table.pptx", slides.export.SaveFormat.PPTX)
```

## **访问表格**

检索幻灯片上的第一个表格形状。

```py
def access_table():
    with slides.Presentation("table.pptx") as presentation:
        slide = presentation.slides[0]

        # 访问幻灯片上的第一个表格。
        first_table = next(shape for shape in slide.shapes if isinstance(shape, slides.Table))
```

## **删除表格**

从幻灯片中删除表格。

```py
def remove_table():
    with slides.Presentation("table.pptx") as presentation:
        slide = presentation.slides[0]

        # 假设第一个形状是表格。
        table = slide.shapes[0]

        # 从幻灯片中删除表格。
        slide.shapes.remove(table)

        presentation.save("table_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **合并表格单元格**

将表格中相邻的单元格合并为一个单元格。

```py
def merge_table_cells():
    with slides.Presentation("table.pptx") as presentation:
        slide = presentation.slides[0]

        # 假设第一个形状是表格。
        table = slide.shapes[0]

        # 合并单元格。
        table.merge_cells(table.rows[0][0], table.rows[1][1], False)

        presentation.save("cells_merged.pptx", slides.export.SaveFormat.PPTX)
```