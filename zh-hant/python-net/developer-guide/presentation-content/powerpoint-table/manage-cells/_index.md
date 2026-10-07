---
title: 使用 Python 管理簡報中的表格儲存格
linktitle: 管理儲存格
type: docs
weight: 30
url: /zh-hant/python-net/manage-cells/
keywords:
- 表格儲存格
- 合併儲存格
- 移除邊框
- 拆分儲存格
- 儲存格內的圖像
- 背景顏色
- PowerPoint
- 簡報
- Python
- Aspose.Slides
description: "使用 Python 管理 PowerPoint 表格儲存格：識別合併儲存格、移除邊框、拆分儲存格，並透過 .NET 的 Aspose.Slides for Python 設定背景顏色與圖像。"
---
## **概觀**

Aspose.Slides 允許您存取和修改 PowerPoint 簡報中的表格儲存格。本文說明如何識別合併的表格儲存格、移除儲存格邊框、在合併或拆分儲存格後處理儲存格編號、變更儲存格的背景色，以及在表格儲存格內加入圖像。範例展示了如何建立或開啟簡報、從投影片取得表格、透過儲存格屬性更新儲存格格式，並將修改後的簡報儲存為 PPTX 檔案。

Aspose.Slides 使用零基索引。本文中的座標寫為 `(column, row)`。

## **識別合併的表格儲存格**

此範例開啟現有簡報，並將第一張投影片上的第一個圖形當作表格存取。它假設投影片與圖形均存在且圖形為表格。然後遍歷所有列與欄，使用 [is_merged_cell](https://reference.aspose.com/slides/python-net/aspose.slides/cell/is_merged_cell/) 來識別位於合併區域的儲存格。對於每一個符合的儲存格，會以 `row;column` 的順序輸出座標、[row_span](https://reference.aspose.com/slides/python-net/aspose.slides/cell/row_span/)、[col_span](https://reference.aspose.com/slides/python-net/aspose.slides/cell/col_span/) 以及區域的起始座標，分別為 [first_row_index](https://reference.aspose.com/slides/python-net/aspose.slides/cell/first_row_index/) 和 [first_column_index](https://reference.aspose.com/slides/python-net/aspose.slides/cell/first_column_index/)。

```python
import aspose.slides as slides

with slides.Presentation("presentation_with_table.pptx") as presentation:
    slide = presentation.slides[0]
    table = slide.shapes[0]

    for row_index in range(len(table.rows)):
        for column_index in range(len(table.columns)):
            cell = table.rows[row_index][column_index]
            if cell.is_merged_cell:
                print(f"Cell {row_index};{column_index} belongs to a merged region with row_span={cell.row_span} and col_span={cell.col_span} starting at {cell.first_row_index};{cell.first_column_index}.")
```

## **移除表格儲存格邊框**

建立一個 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)，並使用 [add_table](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_table/) 在其第一張投影片上加入表格。欄寬、列高與表格位置皆以點 (point) 為單位指定。此範例將四個儲存格邊框全部設為 [FillType.NO_FILL](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/)，使其不可見。

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [50, 50, 50, 50]
    row_heights = [50, 30, 30, 30, 30]
    table = slide.shapes.add_table(100, 50, column_widths, row_heights)

    for row in table.rows:
        for cell in row:
            cell.cell_format.border_top.fill_format.fill_type = slides.FillType.NO_FILL
            cell.cell_format.border_bottom.fill_format.fill_type = slides.FillType.NO_FILL
            cell.cell_format.border_left.fill_format.fill_type = slides.FillType.NO_FILL
            cell.cell_format.border_right.fill_format.fill_type = slides.FillType.NO_FILL

    presentation.save("table.pptx", slides.export.SaveFormat.PPTX)
```

## **合併表格儲存格**

使用 [merge_cells](https://reference.aspose.com/slides/python-net/aspose.slides/table/merge_cells/) 將矩形範圍的表格儲存格合併為一個儲存格。指定範圍左上與右下角的儲存格。最後一個參數控制合併是否允許包含範圍外的儲存格；`False` 會將合併限制在該範圍內。

此範例建立一個 4×4 的表格，欄寬與列高皆為 70 點，然後將中心的四個儲存格從 `(1, 1)` 合併至 `(2, 2)`。合併後的儲存格跨兩欄兩列，而表格底層的格線仍保留四欄四列。若要存取合併儲存格的內容或格式，請使用其左上位置：本例中的 `table.rows[1][1]`。合併範圍內的其他位置仍屬於表格格線，因此範圍外儲存格的索引不會改變。

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [70, 70, 70, 70]
    row_heights = [70, 70, 70, 70]
    table = slide.shapes.add_table(100, 50, column_widths, row_heights)

    table.merge_cells(table.rows[1][1], table.rows[2][2], False)

    presentation.save("merged_cells.pptx", slides.export.SaveFormat.PPTX)
```

## **分割表格儲存格**

在前一個範例中合併儲存格會保留表格的格線。分割儲存格可能會新增格線欄位，並改變其右側儲存格的欄索引。Aspose.Slides 依照 PowerPoint 的表格格線模型運作。

此範例建立一個 4×4 的表格，欄寬與列高皆為 70 點，並對儲存格 `(1, 1)` 呼叫 [split_by_width](https://reference.aspose.com/slides/python-net/aspose.slides/cell/split_by_width/)。將 70 點寬度的一半傳入，以建立兩個等寬的儲存格。

分割後，可分別以 `table.rows[1][1]` 與 `table.rows[1][2]` 取得兩半。表格格線現在變為五欄：原本位於第 2 與第 3 欄的儲存格分別移至第 3 與第 4 欄。列索引保持不變。分割後存取儲存格時，請使用更新後的欄索引。

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [70, 70, 70, 70]
    row_heights = [70, 70, 70, 70]
    table = slide.shapes.add_table(100, 50, column_widths, row_heights)

    table.rows[1][1].split_by_width(table.rows[1][1].width / 2)

    presentation.save("split_cells.pptx", slides.export.SaveFormat.PPTX)
```

### **依列或欄跨度分割合併儲存格**

若要為資料填入準備合併的樣板儲存格，可使用 [split_by_row_span](https://reference.aspose.com/slides/python-net/aspose.slides/cell/split_by_row_span/) 依現有列邊界分割，或使用 [split_by_col_span](https://reference.aspose.com/slides/python-net/aspose.slides/cell/split_by_col_span/) 依欄邊界分割。

`index` 參數表示分割上半部的列數或左半部的欄數，依相對於合併區域計算：

- 列分割：`0 < index <` [row_span](https://reference.aspose.com/slides/python-net/aspose.slides/cell/row_span/)。
- 欄分割：`0 < index <` [col_span](https://reference.aspose.com/slides/python-net/aspose.slides/cell/col_span/)。

本範例假設簡報的第一張投影片第一個圖形是一個表格，且 `(1, 2)` 與 `(1, 3)` 兩儲存格已垂直合併。從下方位置開始，使用 [first_column_index](https://reference.aspose.com/slides/python-net/aspose.slides/cell/first_column_index/) 與 [first_row_index](https://reference.aspose.com/slides/python-net/aspose.slides/cell/first_row_index/) 取得起點，並檢查兩個跨度。使用 `split_by_row_span` 並將索引設為 1，則會分離第 2、3 列以放置產品名稱。若為水平雙欄合併，則改為使用 `split_by_col_span` 並將索引設為 1。

```python
import aspose.slides as slides

with slides.Presentation("table_template.pptx") as presentation:
    slide = presentation.slides[0]
    table = slide.shapes[0]

    selected_cell = table.rows[3][1]
    first_column_index = selected_cell.first_column_index
    first_row_index = selected_cell.first_row_index
    merged_cell = table.rows[first_row_index][first_column_index]

    if merged_cell.is_merged_cell and merged_cell.row_span == 2 and merged_cell.col_span == 1:
        merged_cell.split_by_row_span(1)

        # 從分割後的表格中取得結果儲存格。
        upper_cell = table.rows[first_row_index][first_column_index]
        lower_cell = table.rows[first_row_index + 1][first_column_index]
        print(f"Upper cell merged: {upper_cell.is_merged_cell}")
        print(f"Lower cell merged: {lower_cell.is_merged_cell}")

        upper_cell.text_frame.text = "Product A"
        lower_cell.text_frame.text = "Product B"

        presentation.save("split_template.pptx", slides.export.SaveFormat.PPTX)
    else:
        print("Select a merged region spanning exactly two rows and one column.")
```

表格格線與周圍儲存格索引保持不變。可依座標取得分割後的儲存格；此處兩個儲存格的跨度皆為 1，且 [is_merged_cell](https://reference.aspose.com/slides/python-net/aspose.slides/cell/is_merged_cell/) 會回傳 `False`。較大的區域在一次分割後仍可能保留部分合併。

原始文字與其格式保留在上方（或左方）儲存格；新儲存格則為空，但會繼承填充、邊框與邊距等儲存格格式。分割後請自行填入文字，並明確設定任何所需的文字格式。

儲存的簡報會包含「Product A」與「Product B」兩個獨立儲存格，且保留樣板儲存格的格式。請參閱 [Cell API Reference](https://reference.aspose.com/slides/python-net/aspose.slides/cell/) 以取得更多細節。

## **變更表格儲存格背景色**

此範例建立一個欄寬 150 點、列高 50 點的表格。它將儲存格 `(2, 3)`（第 3 欄第 4 列）的 [fill_type](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/fill_type/) 設為實心，並將 [solid_fill_color](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/solid_fill_color/) 設為紅色。

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [150, 150, 150, 150]
    row_heights = [50, 50, 50, 50, 50]
    table = slide.shapes.add_table(50, 50, column_widths, row_heights)

    cell = table.rows[3][2]
    cell.cell_format.fill_format.fill_type = slides.FillType.SOLID
    cell.cell_format.fill_format.solid_fill_color.color = draw.Color.red

    presentation.save("cell_background_color.pptx", slides.export.SaveFormat.PPTX)
```

## **在表格儲存格內加入圖像**

在執行本範例前，請先將輸入圖像放置於工作目錄。範例使用 [Images.from_file](https://reference.aspose.com/slides/python-net/aspose.slides/images/from_file/) 載入圖像，並以 [add_image](https://reference.aspose.com/slides/python-net/aspose.slides/imagecollection/add_image/) 加入簡報的圖像集合。接著將該圖像指派給儲存格 `(0, 0)`（表格的第一個儲存格）的圖片填充。

[PictureFillMode.STRETCH](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillmode/) 會將圖像拉伸以填滿儲存格，可能會改變其長寬比。欄寬與列高以點為單位。當 `with` 區塊結束時，載入的圖像會自動釋放。

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [150, 150, 150, 150]
    row_heights = [100, 100, 100, 100, 90]
    table = slide.shapes.add_table(50, 50, column_widths, row_heights)

    with slides.Images.from_file("aspose_logo.jpg") as image:
        presentation_image = presentation.images.add_image(image)

    cell = table.rows[0][0]
    cell.cell_format.fill_format.fill_type = slides.FillType.PICTURE
    cell.cell_format.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.STRETCH
    cell.cell_format.fill_format.picture_fill_format.picture.image = presentation_image

    presentation.save("table_cell_with_image.pptx", slides.export.SaveFormat.PPTX)
```

## **常見問題**

**我能為同一個儲存格的不同邊設定不同的線寬與樣式嗎？**

可以。[top](https://reference.aspose.com/slides/python-net/aspose.slides/cellformat/border_top/)、[bottom](https://reference.aspose.com/slides/python-net/aspose.slides/cellformat/border_bottom/)、[left](https://reference.aspose.com/slides/python-net/aspose.slides/cellformat/border_left/)、[right](https://reference.aspose.com/slides/python-net/aspose.slides/cellformat/border_right/) 邊框各自擁有獨立屬性，因而可以設定不同的寬度與樣式。

**若在將圖片設定為儲存格背景後調整欄/列大小，圖片會如何變化？**

行為取決於 [fill mode](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillmode/)（stretch 或 tile）。使用 stretch 時，圖片會依新儲存格尺寸自動調整；使用 tile 時，平鋪圖塊會重新計算。

**我能將超連結指派給儲存格內的所有內容嗎？**

[Hyperlinks](/slides/zh-hant/python-net/manage-hyperlinks/) 是在儲存格文字框（portion）層級或整個表格/圖形層級設定的。實務上，您可以將連結指派給文字框中的某個 portion，或指派給儲存格內的全部文字。

**我能在同一個儲存格內設定不同的字型嗎？**

可以。儲存格的文字框支援 [portions](https://reference.aspose.com/slides/python-net/aspose.slides/portion/)（即文字執行序），每個 portion 可擁有獨立的字型、樣式、大小與顏色。