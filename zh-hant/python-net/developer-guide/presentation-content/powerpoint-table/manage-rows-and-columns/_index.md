---
title: 使用 Python 管理 PowerPoint 表格中的列與欄
linktitle: 列與欄
type: docs
weight: 20
url: /zh-hant/python-net/manage-rows-and-columns/
keywords:
- 表格列
- 表格欄
- 第一列
- 表格標題列
- 克隆列
- 克隆欄
- 複製列
- 複製欄
- 移除列
- 移除欄
- 列文字格式化
- 欄文字格式化
- 表格樣式
- PowerPoint
- 簡報
- Python
- Aspose.Slides
description: "使用 Aspose.Slides for Python 透過 .NET，管理 PowerPoint 與 OpenDocument 表格的列與欄，並加速簡報編輯與資料更新。"
---
## **概覽**

本篇文章說明如何使用 Aspose.Slides for Python 來管理 PowerPoint 與 OpenDocument 簡報中的表格列與欄。您將學習如何新增、插入、複製與刪除列或欄，將第一列設定為標題列，調整大小與版面配置，並在列或欄層級套用文字與樣式格式。每項任務皆以簡潔、獨立的程式碼片段示範，基於 [Table](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/table/) API，讓您能快速在投影片上找到表格並重新塑造其結構以符合設計需求。

## **將首列設定為標題列**

將表格的第一列設定為標題，以明確區分欄位標題與資料。在 Aspose.Slides for Python 中，只需啟用表格的 *First Row* 選項，即可套用選取表格樣式所定義的標題格式。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 類別的執行個體並載入簡報。
1. 依索引存取投影片。
1. 迭代所有 [Shape](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/shape/) 物件以找到目標表格。
1. 設定表格的第一列為標題。

以下 Python 程式碼示範如何將表格的第一列設為標題：

```python
import aspose.slides as slides

# 實例化 Presentation 類別。
with slides.Presentation("table.pptx") as presentation:
    # 存取第一張投影片。
    slide = presentation.slides[0]

    # 遍歷形狀並取得表格的參考。
    for shape in slide.shapes:
        if type(shape) is slides.Table:
            table = shape
            break

    # 將表格的第一列設為標題列。
    table.first_row = True
    
    # 將簡報儲存至磁碟。
    presentation.save("table_out.pptx", slides.export.SaveFormat.PPTX)
```

## **複製表格列或欄**

複製任意表格列或欄，並將副本插入表格中指定的位置。此複製品會保留儲存格內容、格式與大小，讓您能快速且一致地擴充版面配置。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 類別的執行個體並載入簡報。
1. 依索引存取投影片。
1. 定義欄寬陣列。
1. 定義列高陣列。
1. 使用 `add_table(x, y, column_widths, row_heights)` 將 [Table](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/table/) 新增至投影片。
1. 複製表格列。
1. 複製表格欄。
1. 保存已修改的簡報。

以下 Python 程式碼示範如何複製 PowerPoint 表格的列與欄：

```python
 import aspose.slides as slides

# 實例化 Presentation 類別。
with slides.Presentation() as presentation:
    # 存取第一張投影片。
    slide = presentation.slides[0]

    # 定義欄寬與列高。
    column_widths = [50, 50, 50]
    row_heights = [50, 30, 30, 30, 30]

    # 在投影片上新增表格。
    table = slide.shapes.add_table(100, 50, column_widths, row_heights)

    # 在第 1 列第 1 欄加入文字。
    table.rows[0][0].text_frame.text = "Row 1 Cell 1"

    # 在第 2 列第 1 欄加入文字。
    table.rows[1][0].text_frame.text = "Row 1 Cell 2"

    # 在表格末端複製第 1 列。
    table.rows.add_clone(table.rows[0], False)

    # 在第 1 列第 2 欄加入文字。
    table.rows[0][1].text_frame.text = "Row 2 Cell 1"

    # 在第 2 列第 2 欄加入文字。
    table.rows[1][1].text_frame.text = "Row 2 Cell 2"

    # 將第 2 列複製為表格的第 4 列。
    table.rows.insert_clone(3,table.rows[1], False)

    # 在末端複製第一欄。
    table.columns.add_clone(table.columns[0], False)

    # 在索引 3（第 4 個位置）複製第二欄。
    table.columns.insert_clone(3,table.columns[1], False)
    
    # 將簡報儲存至磁碟。
    presentation.save("table_out.pptx", slides.export.SaveFormat.PPTX)
```

## **從表格移除列或欄**

使用 Aspose.Slides for Python 依索引移除任意列或欄，表格版面會自動重新調整，同時保留其餘儲存格的格式。這在簡化資料格或刪除佔位格時非常方便，無需重新建立表格。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 類別的執行個體並載入簡報。
1. 依索引存取投影片。
1. 定義欄寬陣列。
1. 定義列高陣列。
1. 使用 `add_table(x, y, column_widths, row_heights)` 將 ITable 新增至投影片。
1. 移除表格列。
1. 移除表格欄。
1. 保存已修改的簡報。

以下 Python 程式碼示範如何從表格中移除列與欄：

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

## **設定表格列層級的文字格式**

一次為整個表格列套用一致的文字樣式。使用 Aspose.Slides for Python，您可以同時設定該列所有儲存格的字型、大小、字重、顏色與對齊方式，以保持標題或資料列的統一性。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 類別的執行個體並載入簡報。
1. 依索引存取投影片。
1. 取得投影片上相關的 [Table](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/table/) 物件。
1. 設定第一列儲存格的字型高度。
1. 設定第一列儲存格的對齊方式與右邊距。
1. 設定第二列儲存格的文字垂直類型。
1. 保存已修改的簡報。

以下 Python 程式碼示範此操作。

```python
import aspose.slides as slides

# 建立 Presentation 類別的實例。
with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    table = slide.shapes.add_table(100, 100, [100, 50, 30], [30, 50, 30])

    # 設定第一列儲存格的字型高度。
    portion_format = slides.PortionFormat()
    portion_format.font_height = 25
    table.rows[0].set_text_format(portion_format)

    # 設定第一列儲存格的文字對齊方式與右側邊距。
    paragraph_format = slides.ParagraphFormat()
    paragraph_format.alignment = slides.TextAlignment.RIGHT
    paragraph_format.margin_right = 20
    table.rows[0].set_text_format(paragraph_format)

    # 設定第二列儲存格的文字垂直類型。
    text_frame_format = slides.TextFrameFormat()
    text_frame_format.text_vertical_type = slides.TextVerticalType.VERTICAL
    table.rows[1].set_text_format(text_frame_format)
	
    # 將簡報儲存至磁碟。
    presentation.save("result.pptx", slides.export.SaveFormat.PPTX)
```

## **設定表格欄層級的文字格式**

一次為整個表格欄套用一致的文字樣式。使用 Aspose.Slides for Python，您可以同時設定該欄所有儲存格的字型、大小、字重、顏色與對齊方式，打造統一的垂直資料帶。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 類別的執行個體並載入簡報。
1. 依索引存取投影片。
1. 取得投影片上相關的 [Table](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/table/) 物件。
1. 設定第一欄儲存格的字型高度。
1. 設定第一欄儲存格的對齊方式與右邊距。
1. 設定第二欄儲存格的文字垂直類型。
1. 保存已修改的簡報。

以下 Python 程式碼示範此操作：

```python
import aspose.slides as slides

# 建立 Presentation 類別的實例。
with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    table = slide.shapes.add_table(100, 100, [100, 50, 30], [30, 50, 30])

    # 設定第一欄儲存格的字型高度。
    portion_format = slides.PortionFormat()
    portion_format.font_height = 25
    table.columns[0].set_text_format(portion_format)

    # 設定第一欄儲存格的文字對齊方式與右側邊距。
    paragraph_format = slides.ParagraphFormat()
    paragraph_format.alignment = slides.TextAlignment.RIGHT
    paragraph_format.margin_right = 20
    table.columns[0].set_text_format(paragraph_format)

    # 設定第二欄儲存格的文字垂直類型。
    text_frame_format = slides.TextFrameFormat()
    text_frame_format.text_vertical_type = slides.TextVerticalType.VERTICAL
    table.columns[1].set_text_format(text_frame_format)

    # 將簡報儲存至磁碟。
    presentation.save("result.pptx", slides.export.SaveFormat.PPTX)
```

## **取得表格樣式屬性**

Aspose.Slides 允許您取得表格的樣式屬性，方便在其他表格或其他位置重複使用。以下 Python 程式碼示範如何從預設表格樣式取得樣式屬性：

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    table = slide.shapes.add_table(10, 10, [100, 150], [5, 5, 5])
    table.style_preset = slides.TableStylePreset.DARK_STYLE1

    presentation.save("table.pptx", slides.export.SaveFormat.PPTX)
```

## **常見問題**

**我可以將已建立的表格套用 PowerPoint 主題/樣式嗎？**

可以。表格會繼承投影片/版面/母片的主題，且仍可在其上覆寫填色、邊框與文字顏色。

**我可以像在 Excel 中那樣對表格列進行排序嗎？**

不行，Aspose.Slides 的表格沒有內建排序或篩選功能。請先在記憶體中排序資料，然後依排序後的順序重新填入表格列。

**我可以在保留特定儲存格自訂顏色的同時使用條紋欄嗎？**

可以。啟用條紋欄後，對個別儲存格套用本地格式；儲存格層級的格式會優先於表格樣式。