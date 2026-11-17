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
- 儲存格內的圖片
- 背景顏色
- PowerPoint
- 簡報
- Python
- Aspose.Slides
description: "使用 Python 管理 PowerPoint 表格儲存格：辨識合併儲存格、移除邊框、拆分儲存格，並使用 Aspose.Slides for Python via .NET 設定背景顏色與圖片。"
---
## **概述**

Aspose.Slides 讓您能在 PowerPoint 簡報中存取和修改表格儲存格。本文說明如何偵測合併儲存格、移除儲存格邊框、在合併或拆分儲存格後處理儲存格編號、變更儲存格的背景色，以及在表格儲存格內加入圖片。範例示範如何建立或開啟簡報、從投影片取得表格、透過儲存格屬性更新儲存格格式，並將修改後的簡報儲存為 PPTX 檔。

Aspose.Slides 採用零基索引。本文中的座標寫成 `(column, row)`。

## **辨識合併表格儲存格**

此範例開啟現有簡報，將第一張投影片上的第一個形狀當作表格。它假設投影片與形狀均存在且該形狀為表格。接著遍歷所有列與欄，並使用 [is_merged_cell](https://reference.aspose.com/slides/python-net/aspose.slides/cell/is_merged_cell/) 來辨識位於合併區域的儲存格。對於每個符合的儲存格，會以 `row;column` 順序印出座標、[row_span](https://reference.aspose.com/slides/python-net/aspose.slides/cell/row_span/)、[col_span](https://reference.aspose.com/slides/python-net/aspose.slides/cell/col_span/) 以及區域的起始座標 [first_row_index](https://reference.aspose.com/slides/python-net/aspose.slides/cell/first_row_index/) 與 [first_column_index](https://reference.aspose.com/slides/python-net/aspose.slides/cell/first_column_index/)。

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

建立一個 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)，並使用 [add_table](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_table/) 在其第一張投影片加入表格。欄寬、列高與表格位置皆以點 (point) 為單位指定。範例將四側的儲存格邊框皆設定為 [FillType.NO_FILL](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/)，使其不可見。

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

## **加入對角線儲存格邊框**

使用 [border_diagonal_down](https://reference.aspose.com/slides/python-net/aspose.slides/cellformat/border_diagonal_down/) 於左上角至右下角繪製對角線，使用 [border_diagonal_up](https://reference.aspose.com/slides/python-net/aspose.slides/cellformat/border_diagonal_up/) 於左下角至右上角繪製對角線。對角線可用於標示角標題；兩條對角線一起形成 X 可標示儲存格「不適用」。

每條對角線都是一個 [LineFormat](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/)。在其 [fill_format](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/fill_format/) 中，將 [fill_type](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/fill_type/) 設為 [FillType.SOLID](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/)，並選擇 [solid_fill_color](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/solid_fill_color/)。再以點為單位設定線條的 [width](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/width/)。

範例在同一列建立三個儲存格：一個紅色向下對角線、一個藍色向上對角線，以及同時具有兩條對角線的儲存格。其上下左右四側的邊框保持不變。

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [210, 210, 210]
    row_heights = [160]
    table = slide.shapes.add_table(45, 130, column_widths, row_heights)

    downward_border = table.rows[0][0].cell_format.border_diagonal_down
    downward_border.fill_format.fill_type = slides.FillType.SOLID
    downward_border.fill_format.solid_fill_color.color = slides.Color.red
    downward_border.width = 3

    upward_border = table.rows[0][1].cell_format.border_diagonal_up
    upward_border.fill_format.fill_type = slides.FillType.SOLID
    upward_border.fill_format.solid_fill_color.color = slides.Color.blue
    upward_border.width = 5

    cross_downward_border = table.rows[0][2].cell_format.border_diagonal_down
    cross_downward_border.fill_format.fill_type = slides.FillType.SOLID
    cross_downward_border.fill_format.solid_fill_color.color = slides.Color.red
    cross_downward_border.width = 3

    cross_upward_border = table.rows[0][2].cell_format.border_diagonal_up
    cross_upward_border.fill_format.fill_type = slides.FillType.SOLID
    cross_upward_border.fill_format.solid_fill_color.color = slides.Color.blue
    cross_upward_border.width = 5

    presentation.save("diagonal_cell_borders.pptx", slides.export.SaveFormat.PPTX)
```

對角線屬於格式屬性，而非儲存格分割。每個儲存格僅保有單一 [text_frame](https://reference.aspose.com/slides/python-net/aspose.slides/cell/text_frame/)，對角線兩側的區域無法獨立編輯。

以下為儲存在 Microsoft PowerPoint 中的表格樣子：

![Three table cells showing a red diagonal from top-left to bottom-right, a blue diagonal from bottom-left to top-right, and both diagonals forming an X.](diagonal-cell-borders.png)

*由左至右：向下對角線（紅色，3 pt）、向上對角線（藍色，5 pt）以及兩條對角線形成的 X。*

## **合併表格儲存格**

使用 [merge_cells](https://reference.aspose.com/slides/python-net/aspose.slides/table/merge_cells/) 將矩形範圍的表格儲存格合併成一個儲存格。指定範圍的左上角與右下角儲存格。最後一個參數控制合併是否可包含範圍外的儲存格；`False` 表示僅在指定範圍內合併。

範例建立一個 4×4 的表格，欄寬與列高均為 70 點，然後將位於 `(1, 1)` 至 `(2, 2)` 的四個中心儲存格合併。合併後的儲存格跨兩欄兩列，而底層格線仍保留四欄四列。若要存取合併儲存格的內容或格式，請使用其左上位置：本例為 `table.rows[1][1]`。合併範圍內其餘位置仍屬於表格格線，因此範圍外儲存格的索引不會改變。

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

## **拆分表格儲存格**

前一個範例的合併保留了表格格線。拆分儲存格可能會產生新的格線欄，並且會改變其右側儲存格的欄索引。Aspose.Slides 依照 PowerPoint 的表格格線模型運作。

本例建立一個 4×4 的表格（欄寬與列高皆為 70 點），並對儲存格 `(1, 1)` 呼叫 [split_by_width](https://reference.aspose.com/slides/python-net/aspose.slides/cell/split_by_width/)。將儲存格 70 點寬度的一半傳入，以建立兩個等寬的儲存格。

拆分後，兩個子儲存格分別以 `table.rows[1][1]` 與 `table.rows[1][2]` 取用。表格格線現在變為五欄：原本位於第 2、3 欄的儲存格分別移至第 3、4 欄。列索引保持不變。之後存取儲存格時，請使用更新後的欄索引。

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


<!-- visual-explanation:manage-cells:start -->
[![An unmerged 70-point cell splits into two 35-point cells, adding a fifth grid column and shifting the indices to its right.](visual-manage-cells-04c40789d81c.svg)](visual-manage-cells-04c40789d81c.svg)

*寬度拆分影響儲存格 (1, 1)，使用零基 (column, row) 索引。其他列的儲存格仍跨兩個新欄位。*
<!-- visual-explanation:manage-cells:end -->

### **依列或欄跨度拆分合併儲存格**

若要在資料填入前將合併的範本儲存格分割，可使用 [split_by_row_span](https://reference.aspose.com/slides/python-net/aspose.slides/cell/split_by_row_span/) 沿既有列邊界拆分，或使用 [split_by_col_span](https://reference.aspose.com/slides/python-net/aspose.slides/cell/split_by_col_span/) 沿欄邊界拆分。

`index` 參數計算的是上半部的列數或左半部的欄數，且相對於合併區域：

- 列拆分：`0 < index <` [row_span](https://reference.aspose.com/slides/python-net/aspose.slides/cell/row_span/)。
- 欄拆分：`0 < index <` [col_span](https://reference.aspose.com/slides/python-net/aspose.slides/cell/col_span/)。

範例假設簡報的第一張投影片第一個形狀為表格，且儲存格 `(1, 2)` 與 `(1, 3)` 已垂直合併。從較低的位置開始，使用 [first_column_index](https://reference.aspose.com/slides/python-net/aspose.slides/cell/first_column_index/) 與 [first_row_index](https://reference.aspose.com/slides/python-net/aspose.slides/cell/first_row_index/) 定位起點，並檢查兩個跨度。以 `split_by_row_span` 並將索引設為 1，可將第 2、3 列分離以放置產品名稱。若為水平的雙欄合併，則改用 `split_by_col_span` 並將索引設為 1。

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

        # 從表格中取得拆分後產生的儲存格。
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

表格格線與其餘儲存格索引保持不變。可依座標取得產生的儲存格；此處兩個儲存格的跨度皆為 1，且 [is_merged_cell](https://reference.aspose.com/slides/python-net/aspose.slides/cell/is_merged_cell/) 會回傳 `False`。較大的區域在一次拆分後仍可能保留部分合併。

原始文字與格式保留在上方（或左側）儲存格；新儲存格則為空白，但會繼承填充、邊框與邊距等儲存格格式。拆分後請自行填入文字，並明確設定任何需要的文字格式。

儲存的簡報會產生分別為「Product A」與「Product B」的儲存格，且保留範本的儲存格格式。詳情請參閱 [Cell API Reference](https://reference.aspose.com/slides/python-net/aspose.slides/cell/)。

### **依特定高度拆分儲存格**

[split_by_height](https://reference.aspose.com/slides/python-net/aspose.slides/cell/split_by_height/) 以點為單位指定上半部的高度。[split_by_row_span](https://reference.aspose.com/slides/python-net/aspose.slides/cell/split_by_row_span/) 以格線列數指定上半部的高度。若要在右欄將 40 點的儲存格在垂直方向置中，可先從儲存格實際高度減去 40 點，然後將剩餘空間平均分配在上方與下方。

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [160, 160]
    row_heights = [140]
    
    table = slide.shapes.add_table(50, 50, column_widths, row_heights)
    table.rows[0][0].text_frame.text = "Left"

    height = table.rows[0][1].height
    margin = (height - 40) / 2

    table.rows[0][1].split_by_height(margin)
    table.rows[1][1].split_by_height(40)
    table.rows[1][1].text_frame.text = "Middle"

    presentation.save("split_by_height.pptx", slides.export.SaveFormat.PPTX)
```

第一次拆分會新增一個格線列，留下 `table.rows[1][1]` 中的下方 90 點。第二次拆分則將該儲存格再分為 40 點的中間儲存格與 50 點的底部儲存格。右欄的三個儲存格高度依序為 50、40、50 點（自上而下）。左側儲存格跨越所有三列，保持原始高度 140 點。

![The left cell spans the full table height beside three cells with Middle in the center.](split-by-height.png)

## **變更表格儲存格背景色**

本範例建立一個欄寬 150 點、列高 50 點的表格。將第 `(2, 3)` 個儲存格的 [fill_type](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/fill_type/) 設為實心，並將 [solid_fill_color](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/solid_fill_color/) 設為紅色。

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [150, 150, 150, 150]
    row_heights = [50, 50, 50, 50, 50]
    table = slide.shapes.add_table(50, 50, column_widths, row_heights)

    cell = table.rows[3][2]
    cell.cell_format.fill_format.fill_type = slides.FillType.SOLID
    cell.cell_format.fill_format.solid_fill_color.color = slides.Color.red

    presentation.save("cell_background_color.pptx", slides.export.SaveFormat.PPTX)
```

## **在表格儲存格內加入圖片**

在執行本範例前，請先將輸入圖片放置於工作目錄。範例使用 [Images.from_file](https://reference.aspose.com/slides/python-net/aspose.slides/images/from_file/) 讀取圖片，並透過 [add_image](https://reference.aspose.com/slides/python-net/aspose.slides/imagecollection/add_image/) 加入簡報的圖片集。之後將該圖片指派給儲存格 `(0, 0)`（表格的第一個儲存格）的圖片填充。

[PictureFillMode.STRETCH](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillmode/) 會將圖片拉伸以填滿儲存格，可能會改變其長寬比。欄寬與列高以點為單位。當 `with` 區塊結束時，已載入的圖片會自動釋放。

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

## **常見問題集**

**我可以為單一儲存格的不同邊設定不同的線寬與樣式嗎？**

可以。[top](https://reference.aspose.com/slides/python-net/aspose.slides/cellformat/border_top/)/[bottom](https://reference.aspose.com/slides/python-net/aspose.slides/cellformat/border_bottom/)/[left](https://reference.aspose.com/slides/python-net/aspose.slides/cellformat/border_left/)/[right](https://reference.aspose.com/slides/python-net/aspose.slides/cellformat/border_right/) 邊框都有獨立的屬性，故每一側的厚度與樣式皆可不同。

**如果在將圖片設定為儲存格背景後，變更欄或列大小，圖片會發生什麼變化？**

行為取決於 [fill mode](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillmode/)（stretch 或 tile）。使用拉伸時，圖片會依新儲存格調整大小；使用平鋪時，平鋪圖樣會重新計算。

**我可以為儲存格的全部內容指派超連結嗎？**

[Hyperlinks](/slides/zh-hant/python-net/manage-hyperlinks/) 是設定在儲存格文字框（portion）層級，或整個表格/形狀層級。實務上，您可以將連結指派給文字框中的某個區段，或指派給儲存格內的全部文字。

**我可以在單一儲存格內使用不同的字體嗎？**

可以。儲存格的文字框支援 [portions](https://reference.aspose.com/slides/python-net/aspose.slides/portion/)（文字片段），每個片段皆可設定獨立的字型、樣式、大小與顏色。