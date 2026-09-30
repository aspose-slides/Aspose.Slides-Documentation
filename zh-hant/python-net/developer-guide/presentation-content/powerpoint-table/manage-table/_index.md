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
- 長寬比例
- 對齊文字
- 文字格式設定
- 表格樣式
- PowerPoint
- OpenDocument
- 簡報
- Python
- Aspose.Slides
description: "使用 Aspose.Slides for Python via .NET，在 PowerPoint 與 OpenDocument 投影片中建立與編輯表格。探索簡單的程式範例，以簡化您的表格工作流程。"
---
## **簡介**

PowerPoint 中的表格將資訊組織為列與欄，讓閱讀和比較數值更加容易。

Aspose.Slides 提供 [表格](https://reference.aspose.com/slides/python-net/aspose.slides/table/) 和 [儲存格](https://reference.aspose.com/slides/python-net/aspose.slides/cell/) 類別以及其他類型，讓您能在簡報中建立、更新和管理表格。

## **從頭建立表格**

透過指定位置、欄寬和列高來建立表格。將表格加入投影片後，您可以設定儲存格邊框、合併儲存格，並插入文字。

1. 建立 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 類別的實例。
2. 依索引取得投影片的參考。
3. 定義以點為單位的欄寬清單。
4. 定義以點為單位的列高清單。
5. 透過 [add_table](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_table/) 方法將 [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/) 物件加入投影片。
6. 遍歷每個 [Cell](https://reference.aspose.com/slides/python-net/aspose.slides/cell/)，為上、下、左、右邊框套用格式。
7. 合併表格第一列的前兩個儲存格。
8. 透過合併儲存格的 [text_frame](https://reference.aspose.com/slides/python-net/aspose.slides/cell/text_frame/) 屬性存取。
9. 設定合併儲存格中的文字。
10. 儲存已修改的簡報。

以下範例在 (100, 50) 點的位置建立一個具有三欄五列的表格。它套用寬度為 5 點的紅色邊框，合併第一列的前兩個儲存格，並將結果儲存為 `table.pptx`。

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [50, 50, 50]
    row_heights = [50, 30, 30, 30, 30]
    table = slide.shapes.add_table(100, 50, column_widths, row_heights)

    for row in table.rows:
        for cell in row:
            cell_format = cell.cell_format
            cell_format.border_top.fill_format.fill_type = slides.FillType.SOLID
            cell_format.border_top.fill_format.solid_fill_color.color = draw.Color.red
            cell_format.border_top.width = 5

            cell_format.border_bottom.fill_format.fill_type = slides.FillType.SOLID
            cell_format.border_bottom.fill_format.solid_fill_color.color = draw.Color.red
            cell_format.border_bottom.width = 5

            cell_format.border_left.fill_format.fill_type = slides.FillType.SOLID
            cell_format.border_left.fill_format.solid_fill_color.color = draw.Color.red
            cell_format.border_left.width = 5

            cell_format.border_right.fill_format.fill_type = slides.FillType.SOLID
            cell_format.border_right.fill_format.solid_fill_color.color = draw.Color.red
            cell_format.border_right.width = 5

    table.merge_cells(table.rows[0][0], table.rows[0][1], False)
    table.rows[0][0].text_frame.text = "Merged Cells"

    presentation.save("table.pptx", slides.export.SaveFormat.PPTX)
```

## **標準表格的編號方式**

在標準表格中，儲存格索引從零開始，且順序為 (欄, 列)。第一個儲存格的索引為 (0, 0)。在 Python 中，可使用 `table.rows[row_index][column_index]` 來存取儲存格；此表達式中列索引放在前面。

例如，具有 4 欄 4 列的表格之儲存格編號如下：

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

此範例建立上述示意的 4 × 4 表格，欄寬與列高皆為 70 點，並使用寬度為 5 點的紅色儲存格邊框。座標顯示儲存格索引；範例保持儲存格為空，並將表格儲存為 `StandardTables_out.pptx`。

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [70, 70, 70, 70]
    row_heights = [70, 70, 70, 70]
    table = slide.shapes.add_table(100, 50, column_widths, row_heights)

    for row in table.rows:
        for cell in row:
            cell_format = cell.cell_format
            cell_format.border_top.fill_format.fill_type = slides.FillType.SOLID
            cell_format.border_top.fill_format.solid_fill_color.color = draw.Color.red
            cell_format.border_top.width = 5

            cell_format.border_bottom.fill_format.fill_type = slides.FillType.SOLID
            cell_format.border_bottom.fill_format.solid_fill_color.color = draw.Color.red
            cell_format.border_bottom.width = 5

            cell_format.border_left.fill_format.fill_type = slides.FillType.SOLID
            cell_format.border_left.fill_format.solid_fill_color.color = draw.Color.red
            cell_format.border_left.width = 5

            cell_format.border_right.fill_format.fill_type = slides.FillType.SOLID
            cell_format.border_right.fill_format.solid_fill_color.color = draw.Color.red
            cell_format.border_right.width = 5

    presentation.save("StandardTables_out.pptx", slides.export.SaveFormat.PPTX)
```

## **存取現有表格**

表格儲存在投影片的形狀集合中。遍歷形狀以找到表格，然後使用 [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/) 類別讀取或更新其儲存格。

1. 使用 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 類別載入簡報。
2. 依索引取得包含該表格的投影片參考。
3. 遍歷 [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) 物件，遇到表格時停止。若投影片包含多個表格，使用 [alternative_text](https://reference.aspose.com/slides/python-net/aspose.slides/shape/alternative_text/) 以辨識所需的表格。
4. 更新目標儲存格中的文字。
5. 儲存已修改的簡報。

以下範例開啟 `UpdateExistingTable.pptx`，並在第一張投影片上找到第一個表格。它將第 0 欄第 1 列的儲存格設定為 `New`，並將結果儲存為 `table1_out.pptx`。輸入檔必須至少包含一張投影片，且該投影片的第一個表格至少有一欄兩列。

```python
import aspose.slides as slides

with slides.Presentation("UpdateExistingTable.pptx") as presentation:
    slide = presentation.slides[0]
    table = None

    for shape in slide.shapes:
        if isinstance(shape, slides.Table):
            table = shape
            break

    if table is not None and len(table.rows) >= 2:
        table.rows[1][0].text_frame.text = "New"
        presentation.save("table1_out.pptx", slides.export.SaveFormat.PPTX)
```

若要調整現有表格中列的大小並了解其實際高度為何會超過請求的最小值，請參閱 [控制列高度](/slides/zh-hant/python-net/manage-rows-and-columns/#control-row-height)。

## **尋找擁有文字框的儲存格**

當通用文字處理程式碼從表格取得 [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) 時，請使用 [TextFrame.parent_cell](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/parent_cell/) 屬性取得其所屬的 [Cell](https://reference.aspose.com/slides/python-net/aspose.slides/cell/)。對於表格儲存格的文字框，會設定 [TextFrame.parent_cell](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/parent_cell/) 而 [TextFrame.parent_shape](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/parent_shape/) 為 `None`，即使表格本身是一個形狀。

可透過唯讀的 [Cell.first_column_index](https://reference.aspose.com/slides/python-net/aspose.slides/cell/first_column_index/) 與 [Cell.first_row_index](https://reference.aspose.com/slides/python-net/aspose.slides/cell/first_row_index/) 屬性取得儲存格座標。[TextFrame.parent_cell](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/parent_cell/) 亦為唯讀：它提供指向擁有者的導向，但不會更改所有權。在使用之前務必檢查回傳的儲存格是否為 `None`。

欲取得完整範例以辨識表格儲存格與形狀的擁有者（包括與 SmartArt 節點相關的形狀），請參閱 [搜尋與取代文字](/slides/zh-hant/python-net/search-and-replace-text/)。

## **對齊表格文字**

您可以控制單一表格儲存格的垂直錨點與文字方向。本節範例將第一個儲存格的文字置中，並旋轉 270 度。

1. 建立 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 類別的實例。
2. 依索引取得投影片的參考。
3. 將 [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/) 物件加入投影片。
4. 從表格取得 [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) 物件。
5. 取得第一個 [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/)，並設定其文字與顏色。
6. 設定儲存格的 [text_anchor_type](https://reference.aspose.com/slides/python-net/aspose.slides/cell/text_anchor_type/) 與 [text_vertical_type](https://reference.aspose.com/slides/python-net/aspose.slides/cell/text_vertical_type/)。
7. 儲存已修改的簡報。

此範例建立一個 4 × 4 表格，欄寬為 120 點、列高為 100 點。它格式化儲存格 (0, 0) 的文字，並在第一列的其餘儲存格加入值，最後將結果儲存為 `Vertical_Align_Text_out.pptx`。

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [120, 120, 120, 120]
    row_heights = [100, 100, 100, 100]
    table = slide.shapes.add_table(100, 50, column_widths, row_heights)
    table.rows[0][1].text_frame.text = "10"
    table.rows[0][2].text_frame.text = "20"
    table.rows[0][3].text_frame.text = "30"

    cell = table.rows[0][0]
    paragraph = cell.text_frame.paragraphs[0]
    portion = paragraph.portions[0]
    portion.text = "Text here"
    portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
    portion.portion_format.fill_format.solid_fill_color.color = draw.Color.black

    cell.text_anchor_type = slides.TextAnchorType.CENTER
    cell.text_vertical_type = slides.TextVerticalType.VERTICAL270

    presentation.save("Vertical_Align_Text_out.pptx", slides.export.SaveFormat.PPTX)
```

## **在表格層級設定文字格式**

使用 [set_text_format](https://reference.aspose.com/slides/python-net/aspose.slides/table/set_text_format/) 以對表格中的所有儲存格套用文字格式。其多載接受部份、段落與文字框的格式設定，因而可以在不遍歷個別儲存格的情況下設定這些屬性。

1. 使用 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 類別載入簡報。
2. 依索引取得投影片的參考。
3. 從投影片取得 [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/) 物件。
4. 設定文字的 [font_height](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/font_height/)。
5. 設定 [alignment](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/alignment/) 與 [margin_right](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/margin_right/)。
6. 設定 [text_vertical_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/text_vertical_type/)。
7. 儲存已修改的簡報。

以下範例開啟 `table.pptx`（該檔案必須至少包含一張投影片，且第一個形狀為表格）。它將字體大小設定為 25 點，將段落右對齊並設右邊距 20 點，且將文字設為垂直。格式化後的簡報儲存為 `result.pptx`。

```python
import aspose.slides as slides

with slides.Presentation("table.pptx") as presentation:
    slide = presentation.slides[0]
    table = slide.shapes[0]

    portion_format = slides.PortionFormat()
    portion_format.font_height = 25
    table.set_text_format(portion_format)

    paragraph_format = slides.ParagraphFormat()
    paragraph_format.alignment = slides.TextAlignment.RIGHT
    paragraph_format.margin_right = 20
    table.set_text_format(paragraph_format)

    text_frame_format = slides.TextFrameFormat()
    text_frame_format.text_vertical_type = slides.TextVerticalType.VERTICAL
    table.set_text_format(text_frame_format)

    presentation.save("result.pptx", slides.export.SaveFormat.PPTX)
```

## **取得表格樣式屬性**

使用 [style_preset](https://reference.aspose.com/slides/python-net/aspose.slides/table/style_preset/) 讀取或指定表格的預設樣式。此範例將 [TableStylePreset.DARK_STYLE1](https://reference.aspose.com/slides/python-net/aspose.slides/tablestylepreset/) 套用於一個表格，列印預設名稱，並將相同的預設套用於第二個表格。兩個表格皆儲存於 `table-style.pptx`。

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [100, 150]
    row_heights = [5, 5, 5]
    table = slide.shapes.add_table(10, 10, column_widths, row_heights)
    table.style_preset = slides.TableStylePreset.DARK_STYLE1

    style_preset = table.style_preset
    print(f"Table style preset: {style_preset.name}")

    another_table = slide.shapes.add_table(10, 100, column_widths, row_heights)
    another_table.style_preset = style_preset

    presentation.save("table-style.pptx", slides.export.SaveFormat.PPTX)
```

## **鎖定表格的長寬比例**

表格的長寬比指的是其寬度與高度的比例。使用 [aspect_ratio_locked](https://reference.aspose.com/slides/python-net/aspose.slides/graphicalobjectlock/aspect_ratio_locked/) 以鎖定表格的此比例。

以下範例開啟 `pres.pptx`（該檔案必須至少包含一張投影片，且第一個形狀為表格）。它列印目前的鎖定狀態，啟用長寬比鎖定，列印更新後的狀態（`True`），並將結果儲存為 `pres-out.pptx`。

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    slide = presentation.slides[0]
    table = slide.shapes[0]

    print(f"Lock aspect ratio set: {table.shape_lock.aspect_ratio_locked}")
    
    table.shape_lock.aspect_ratio_locked = True
    print(f"Lock aspect ratio set: {table.shape_lock.aspect_ratio_locked}")

    presentation.save("pres-out.pptx", slides.export.SaveFormat.PPTX)
```

## **常見問題**

**我可以為整個表格及其儲存格內的文字啟用從右至左 (RTL) 閱讀方向嗎？**

可以。表格提供 [right_to_left](https://reference.aspose.com/slides/python-net/aspose.slides/table/right_to_left/) 屬性，段落則有 [ParagraphFormat.right_to_left](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/right_to_left/)。同時使用兩者即可確保儲存格內的文字以正確的 RTL 順序與呈現方式顯示。

**如何防止使用者在最終檔案中移動或調整表格大小？**

使用 [形狀鎖定](/slides/zh-hant/python-net/applying-protection-to-presentation/) 以停用移動、調整大小、選取等功能。這些鎖定同樣適用於表格。

**是否支援在儲存格內插入影像作為背景？**

可以。您可以為儲存格設定 [圖片填充](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/)，影像會依選擇的模式（拉伸或平鋪）覆蓋儲存格區域。