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
- 文字格式化
- 表格樣式
- PowerPoint
- OpenDocument
- 簡報
- Python
- Aspose.Slides
description: "使用 Aspose.Slides for Python（透過 .NET）在 PowerPoint 與 OpenDocument 投影片中建立與編輯表格。探索簡易程式碼範例，以簡化您的表格工作流程。"
---
## **簡介**

PowerPoint 中的表格是呈現資訊的有效方式。以儲存格（列與欄）格子排列的資訊直觀且易於理解。

Aspose.Slides 提供 [表格](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/table/) 、[儲存格](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/cell/) 類別及其他相關型別，協助您在任何簡報中建立、更新和管理表格。

## **從頭建立表格**

本節說明如何在 Aspose.Slides 中從頭建立表格，方法是將表格形狀加入投影片、定義其列與欄，並設定精確尺寸。您還會看到如何將文字填入儲存格、調整對齊與邊框，以及自訂表格外觀。

1. 建立 [簡報](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 類別的實例。  
2. 依索引取得投影片的參考。  
3. 定義欄寬陣列。  
4. 定義列高陣列。  
5. 將 [表格](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/table/) 新增至投影片。  
6. 遍歷每個 [儲存格](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/cell/)，並格式化其上、下、右、左邊框。  
7. 合併表格第一列的前兩個儲存格。  
8. 取得 [儲存格](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/cell/) 的 [文字框](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/textframe/)。  
9. 向 [文字框](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/textframe/) 新增文字。  
10. 儲存已修改的簡報。

下列 Python 範例示範如何在簡報中建立表格：

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# 實例化代表簡報檔案的 Presentation 類別。
with slides.Presentation() as presentation:
    # 存取第一張投影片。
    slide = presentation.slides[0]

    # 定義欄寬和列高。
    column_widths = [50, 50, 50]
    row_heights = [50, 30, 30, 30, 30]

    # 將表格形狀新增至投影片。
    table = slide.shapes.add_table(100, 50, column_widths, row_heights)

    # 為每個儲存格設定邊框格式。
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
        
    # 合併從 (第0列, 第0欄) 到 (第1列, 第1欄) 的儲存格。
    table.merge_cells(table.rows[0][0], table.rows[1][1], False)

    # 在合併的儲存格中加入文字。
    table.rows[0][0].text_frame.text = "Merged Cells"

    # 將簡報儲存至磁碟。
    presentation.save("table.pptx", slides.export.SaveFormat.PPTX)
```

## **標準表格的編號**

在標準表格中，儲存格編號直接且以零為起點。表格的第一個儲存格編號為 (0, 0)（第 0 欄，第 0 列）。

例如，在擁有 4 個欄位和 4 列的表格中，儲存格的編號如下：

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

下列 Python 範例示範如何使用此零基編號來參照儲存格：

```python
for row_index in range(len(table.rows)):
    for column_index in range(len(table.rows[row_index])):
        cell = table.rows[row_index][column_index]
        cell.text_frame.text = f"({column_index}, {row_index})"
```

## **存取現有表格**

本節說明如何在簡報中定位並操作現有表格。您將學習如何在投影片上找到表格、存取其列、欄與儲存格，並更新內容或格式。

1. 建立 [簡報](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 類別的實例。  
2. 依索引取得包含表格的投影片參考。  
3. 遍歷所有 [形狀](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/shape/) 物件，直到找到表格。  
4. 使用 [表格](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/table/) 物件來操作表格。  
5. 儲存已修改的簡報。

{{% alert color="info" %}}
如果投影片包含多個表格，最好透過其 `alternative_text` 屬性來搜尋所需的表格。
{{% /alert %}}

下列 Python 範例示範如何存取與操作現有表格：

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# 實例化 Presentation 類別以載入 PPTX 檔案。
with slides.Presentation("sample.pptx") as presentation:
    # 取得第一張投影片。
    slide = presentation.slides[0]

    table = None

    # 遍歷形狀並參照找到的第一個表格。
    for shape in slide.shapes:
        if isinstance(shape, slides.Table):
            table = shape
            break

    # 設定第一列第一個儲存格的文字。
    if table is not None:
        table.rows[0][0].text_frame.text = "Found"

    # 將修改後的簡報儲存至磁碟。
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **對齊表格中的文字**

本節說明如何使用 Aspose.Slides 控制表格儲存格內文字的對齊方式。您將學習設定儲存格的水平與垂直對齊，以保持內容清晰且一致。

1. 建立 [簡報](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 類別的實例。  
2. 依索引取得投影片的參考。  
3. 將 [表格](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/table/) 物件新增至投影片。  
4. 從表格取得 [儲存格] 物件。  
5. 垂直對齊文字。  
6. 儲存已修改的簡報。

下列 Python 範例示範如何對齊表格中的文字：

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

    # 在投影片上加入表格形狀。
    table = slide.shapes.add_table(100, 50, column_widths, row_heights)
    table.rows[0][0].text_frame.text = "Numbers"
    table.rows[1][0].text_frame.text = "10"
    table.rows[2][0].text_frame.text = "20"
    table.rows[3][0].text_frame.text = "30"

    # 文字置中並設定垂直方向。
    cell = table.rows[0][0]
    cell.text_anchor_type = slides.TextAnchorType.CENTER
    cell.text_vertical_type = slides.TextVerticalType.VERTICAL270

    # 將簡報儲存至磁碟。
    presentation.save("aligned_cell.pptx", slides.export.SaveFormat.PPTX)
```

## **在表格層級設定文字格式**

本節說明如何在 Aspose.Slides 中於表格層級套用文字格式，使每個儲存格繼承一致的統一樣式。您將學習全域設定字型大小、對齊方式與邊距。

1. 建立 [簡報](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 類別的實例。  
2. 依索引取得投影片的參考。  
3. 將 [表格](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/table/) 新增至投影片。  
4. 設定文字的字型大小（字體高度）。  
5. 設定段落對齊方式與邊距。  
6. 設定垂直文字方向。  
7. 儲存已修改的簡報。

下列 Python 範例示範如何將您偏好的格式選項套用到表格文字：

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

    # 設定所有表格儲存格的文字右對齊並設定右邊距。
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

Aspose.Slides 讓您直接在程式碼中使用預先定義的樣式來格式化表格。範例示範建立表格、套用內建樣式，並儲存結果——這是確保格式一致且專業的有效方法。

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    table = slide.shapes.add_table(10, 10, [100, 150], [5, 5, 5])

    table.style_preset = slides.TableStylePreset.DARK_STYLE1

    presentation.save("table.pptx", slides.export.SaveFormat.PPTX)
```

## **鎖定表格的長寬比**

形狀的長寬比是其尺寸的比例。Aspose.Slides 提供 `aspect_ratio_locked` 屬性，讓您能鎖定表格及其他形狀的長寬比。

下列 Python 範例示範如何為表格鎖定長寬比：

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

**我可以為整個表格及其儲存格中的文字啟用從右至左 (RTL) 讀取方向嗎？**

是。表格提供 [right_to_left](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/table/right_to_left/) 屬性，段落則有 [ParagraphFormat.right_to_left](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/paragraphformat/right_to_left/)。同時使用兩者可確保儲存格內正確的 RTL 順序與呈現。

**如何防止使用者在最終檔案中移動或調整表格的大小？**

使用 [shape locks](/slides/zh-hant/python-net/applying-protection-to-presentation/) 來停用移動、調整大小、選取等功能。這些鎖定也適用於表格。

**是否支援在儲存格內插入影像作為背景？**

是的。您可以為儲存格設定 [picture fill](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/picturefillformat/)，圖片將依所選模式（拉伸或並排）覆蓋儲存格區域。