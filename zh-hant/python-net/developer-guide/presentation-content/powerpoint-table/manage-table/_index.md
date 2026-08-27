---
title: 使用 Python 管理簡報表格
linktitle: 管理表格
type: docs
weight: 10
url: /zh-hant/python-net/manage-table/
keywords:
- 新增表格
- 建立表格
- 存取表格
- 長寬比
- 對齊文字
- 文字格式設定
- 表格樣式
- PowerPoint
- OpenDocument
- 簡報
- Python
- Aspose.Slides
description: "使用 Aspose.Slides for Python via .NET 在 PowerPoint 與 OpenDocument 投影片中建立與編輯表格。探索簡易程式碼範例，以簡化您的表格工作流程。"
---
## **簡介**

PowerPoint 中的表格是呈現資訊的有效方式。以格狀的儲存格（列與欄）排列的資訊直觀且易於理解。

Aspose.Slides 提供 [Table](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/table/) 類別、[Cell](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/cell/) 類別以及其他相關類型，協助您在任何簡報中建立、更新與管理表格。

## **從頭建立表格**

本節說明如何在 Aspose.Slides 中透過將表格形狀新增至投影片、定義列與欄以及設定精確尺寸，從頭建立表格。您還會看到如何以文字填充儲存格、調整對齊與邊框，並自訂表格外觀。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 類別的實例。
2. 依索引取得投影片參考。
3. 定義欄寬陣列。
4. 定義列高陣列。
5. 將 [Table](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/table/) 新增至投影片。
6. 逐一遍歷每個 [Cell](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/cell/) 並設定其上、下、左、右邊框。
7. 將前兩列與前兩欄的儲存格合併為單一儲存格。
8. 取得 [Cell](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/cell/) 的 [TextFrame](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/textframe/)。
9. 向 [TextFrame](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/textframe/) 新增文字。
10. 儲存已修改的簡報。

以下 Python 範例說明如何在簡報中建立表格：

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# 建立代表簡報檔案的 Presentation 類別實例。
with slides.Presentation() as presentation:
    # 取得第一張投影片。
    slide = presentation.slides[0]

    # 定義欄寬與列高。
    column_widths = [50, 50, 50]
    row_heights = [50, 30, 30, 30, 30]

    # 在投影片上添加表格形狀。
    table = slide.shapes.add_table(100, 50, column_widths, row_heights)

    # 設定每個儲存格的邊框格式。
    for row in table.rows:
        for cell in row:
            cell.cell_format.border_top.fill_format.fill_type = slides.FillType.SOLID
            cell.cell_format.border_top.fill_format.solid_fill_color.color = draw.Color.red
            cell.cell_format.border_top.width = 5

            cell.cell_format.border_bottom.fill_format.fill_type = slides.FillType.SOLID
            cell.cell_format.border_bottom.fill_format.solid_fill_color.color= draw.Color.red
            cell.cell_format.border_bottom.width = 5

            cell.cell_format.border_left.fill_format.fill_type = slides.FillType.SOLID
            cell.cell_format.border_left.fill_format.solid_fill_color.color =draw.Color.red
            cell.cell_format.border_left.width = 5

            cell.cell_format.border_right.fill_format.fill_type = slides.FillType.SOLID
            cell.cell_format.border_right.fill_format.solid_fill_color.color = draw.Color.red
            cell.cell_format.border_right.width = 5
        
    # 合併從 (row 0, col 0) 到 (row 1, col 1) 的儲存格。
    table.merge_cells(table.rows[0][0], table.rows[1][1], False)

    # 為合併的儲存格加入文字。
    table.rows[0][0].text_frame.text = "Merged Cells"

    # 將簡報儲存至磁碟。
    presentation.save("table.pptx", slides.export.SaveFormat.PPTX)
```

## **標準表格的編號方式**

在標準表格中，儲存格編號相當直接且採零基礎。表格中的第一個儲存格索引為 (0, 0)（欄 0，列 0）。

例如，擁有 4 個欄與 4 個列的表格，其儲存格編號如下：

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

以下 Python 範例說明如何以此零基礎編號參照儲存格：

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    # 取得第一張投影片。
    slide = presentation.slides[0]

    # 新增一個含 4 個欄位與 4 個列的表格。
    table = slide.shapes.add_table(100, 50, [50, 50, 50, 50], [30, 30, 30, 30])

    for row_index in range(len(table.rows)):
        for column_index in range(len(table.rows[row_index])):
            cell = table.rows[row_index][column_index]
            cell.text_frame.text = f"({column_index}, {row_index})"

    presentation.save("table.pptx", slides.export.SaveFormat.PPTX)
```

## **存取現有表格**

本節說明如何使用 Aspose.Slides 在簡報中定位並操作現有表格。您將學習如何在投影片上找到表格、存取其列、欄與儲存格，並更新內容或格式。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 類別的實例。
2. 依索引取得包含表格的投影片參考。
3. 迭代所有 [Shape](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/shape/) 物件，直到找到表格。
4. 使用 [Table](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/table/) 物件操作表格。
5. 儲存已修改的簡報。

{{% alert color="info" title="Note" %}}
如果投影片中包含多個表格，建議依其 `alternative_text` 屬性搜尋所需的表格。
{{% /alert %}}

以下 Python 範例說明如何存取並操作現有表格：

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# 建立 Presentation 類別的實例以載入 PPTX 檔案。
with slides.Presentation("sample.pptx") as presentation:
    # 取得第一張投影片。
    slide = presentation.slides[0]

    table = None

    # 迭代形狀並參考找到的第一個表格。
    for shape in slide.shapes:
        if isinstance(shape, slides.Table):
            table = shape
            break

    # 設定第一列第一個儲存格的文字。
    if table is not None:
        table.rows[0][0].text_frame.text = "Found"

    # 將已修改的簡報儲存至磁碟。
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **尋找擁有文字框的儲存格**

當一般文字處理程式碼從表格取得 [TextFrame](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/textframe/) 時，使用 [TextFrame.parent_cell](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/textframe/parent_cell/) 屬性取得所屬的 [Cell](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/cell/)。對於表格儲存格的文字框，`TextFrame.parent_cell` 會被設定，而 `TextFrame.parent_shape` 為 `None`，即使表格本身也是一個形狀。

儲存格座標可透過唯讀的 [Cell.first_column_index](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/cell/first_column_index/) 與 [Cell.first_row_index](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/cell/first_row_index/) 屬性取得。`TextFrame.parent_cell` 亦為唯讀：它提供指向擁有者的導向，但不會改變擁有權。使用前務必檢查回傳的儲存格是否為 `None`。

欲取得完整範例（包括辨識表格儲存格與形狀擁有者，及與 SmartArt 節點相關的形狀），請參考 [Search and Replace Text](/slides/zh-hant/python-net/search-and-replace-text/)。

## **對齊表格內文字**

本節說明如何使用 Aspose.Slides 控制表格儲存格內文字的放置。您將學習如何在儲存格中垂直置中文字並變更文字的方向。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 類別的實例。
2. 依索引取得投影片參考。
3. 將 [Table](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/table/) 物件新增至投影片。
4. 從表格中取得 [Cell](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/cell/) 物件。
5. 使文字在儲存格內垂直置中並設定文字方向。
6. 儲存已修改的簡報。

以下 Python 範例說明如何對齊表格內文字：

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# 建立 Presentation 類別的實例。
with slides.Presentation() as presentation:
    # 取得第一張投影片。
    slide = presentation.slides[0]

    # 定義欄寬與列高。
    column_widths = [40, 120, 120, 120]
    row_heights = [100, 100, 100, 100]

    # 在投影片上新增表格形狀。
    table = slide.shapes.add_table(100, 50, column_widths, row_heights)
    table.rows[0][0].text_frame.text = "Numbers"
    table.rows[1][0].text_frame.text = "10"
    table.rows[2][0].text_frame.text = "20"
    table.rows[3][0].text_frame.text = "30"

    # 置中文字並設定垂直方向。
    cell = table.rows[0][0]
    cell.text_anchor_type = slides.TextAnchorType.CENTER
    cell.text_vertical_type = slides.TextVerticalType.VERTICAL270

    # 將簡報儲存至磁碟。
    presentation.save("aligned_cell.pptx", slides.export.SaveFormat.PPTX)
```

## **設定表格層級的文字格式**

本節說明如何在 Aspose.Slides 中於表格層級套用文字格式，使每個儲存格皆繼承一致且統一的樣式。您將學習如何全局設定字型大小、對齊方式與邊距。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 類別的實例。
2. 依索引取得投影片參考。
3. 將 [Table](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/table/) 新增至投影片。
4. 設定文字的字型大小（字型高度）。
5. 設定段落對齊與邊距。
6. 設定垂直文字方向。
7. 儲存已修改的簡報。

以下 Python 範例說明如何將您偏好的格式選項套用於表格內文字：

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# 建立 Presentation 類別的實例
with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    table = slide.shapes.add_table(20, 20, [100, 50, 30], [30, 50, 30])

    # 設定所有表格儲存格的字型大小。
    portion_format = slides.PortionFormat()
    portion_format.font_height = 25
    table.set_text_format(portion_format)

    # 設定所有表格儲存格的右對齊文字與右邊距。
    paragraph_format = slides.ParagraphFormat()
    paragraph_format.alignment = slides.TextAlignment.RIGHT
    paragraph_format.margin_right = 20
    table.set_text_format(paragraph_format)

    # 設定所有表格儲存格的垂直文字方向。
    text_frame_format = slides.TextFrameFormat()
    text_frame_format.text_vertical_type = slides.TextVerticalType.VERTICAL
    table.set_text_format(text_frame_format)

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **套用內建表格樣式**

Aspose.Slides 讓您可以直接在程式碼中使用預定義樣式格式化表格。此範例示範建立表格、套用內建樣式，並儲存結果——是一種確保格式一致、專業的高效方式。

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    table = slide.shapes.add_table(10, 10, [100, 150], [5, 5, 5])

    table.style_preset = slides.TableStylePreset.DARK_STYLE1

    presentation.save("table.pptx", slides.export.SaveFormat.PPTX)
```

## **鎖定表格的長寬比**

形狀的長寬比是其尺寸的比例。Aspose.Slides 提供 `aspect_ratio_locked` 屬性，允許您為表格及其他形狀鎖定長寬比。

以下 Python 範例說明如何為表格鎖定長寬比：

```py
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    table = slide.shapes.add_table(20, 20, [100, 50, 30], [30, 50, 30])

    print(f"Lock aspect ratio set: {table.shape_lock.aspect_ratio_locked}")
    table.shape_lock.aspect_ratio_locked = not table.shape_lock.aspect_ratio_locked
    print(f"Lock aspect ratio set: {table.shape_lock.aspect_ratio_locked}")

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **常見問題**

**我可以為整個表格及其儲存格內的文字啟用從右至左 (RTL) 閱讀方向嗎？**

可以。表格提供 [right_to_left](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/table/right_to_left/) 屬性，段落則有 [ParagraphFormat.right_to_left](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/paragraphformat/right_to_left/)。同時使用兩者即可確保儲存格內的正確 RTL 排序與呈現。

**如何防止使用者在最終檔案中移動或調整表格大小？**

使用 [shape locks](/slides/zh-hant/python-net/applying-protection-to-presentation/) 以停用移動、調整大小、選取等功能。這些鎖定同樣適用於表格。

**是否支援將影像作為儲存格的背景插入？**

支援。您可以為儲存格設定 [picture fill](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/picturefillformat/)，影像會依所選模式（伸展或平鋪）覆蓋儲存格區域。