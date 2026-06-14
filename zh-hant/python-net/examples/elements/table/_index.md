---
title: 表格
type: docs
weight: 120
url: /zh-hant/python-net/examples/elements/table/
keywords:
- 表格
- 新增表格
- 取得表格
- 刪除表格
- 合併儲存格
- 程式碼範例
- PowerPoint
- OpenDocument
- 簡報
- Python
- Aspose.Slides
description: "使用 Aspose.Slides 在 Python 中建立與格式化表格：插入資料、合併儲存格、設定邊框樣式、對齊內容，並支援 PPT、PPTX 與 ODP 的匯入/匯出。"
---
以下示範如何使用 **Aspose.Slides for Python via .NET** 新增表格、存取表格、刪除表格以及合併儲存格。

## **Add a Table**

建立一個包含兩列兩欄的簡易表格。

```py
def add_table():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # 定義欄寬與列高。
        widths = [80, 80]
        heights = [30, 30]

        # 新增表格形狀到投影片。
        table = slide.shapes.add_table(50, 50, widths, heights)

        presentation.save("table.pptx", slides.export.SaveFormat.PPTX)
```

## **Access a Table**

取得投影片上第一個表格形狀。

```py
def access_table():
    with slides.Presentation("table.pptx") as presentation:
        slide = presentation.slides[0]

        # 取得投影片上的第一個表格。
        first_table = next(shape for shape in slide.shapes if isinstance(shape, slides.Table))
```

## **Remove a Table**

從投影片中刪除表格。

```py
def remove_table():
    with slides.Presentation("table.pptx") as presentation:
        slide = presentation.slides[0]

        # 假設第一個形狀是表格。
        table = slide.shapes[0]

        # 從投影片中移除表格。
        slide.shapes.remove(table)

        presentation.save("table_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Merge Table Cells**

將表格相鄰的儲存格合併為單一儲存格。

```py
def merge_table_cells():
    with slides.Presentation("table.pptx") as presentation:
        slide = presentation.slides[0]

        # 假設第一個形狀是表格。
        table = slide.shapes[0]

        # 合併儲存格。
        table.merge_cells(table.rows[0][0], table.rows[1][1], False)

        presentation.save("cells_merged.pptx", slides.export.SaveFormat.PPTX)
```