---
title: 使用 Python 管理簡報中的表格儲存格
linktitle: 管理儲存格
type: docs
weight: 30
url: /zh-hant/python-java/manage-cells/
keywords:
- 表格儲存格
- 合併儲存格
- 移除邊框
- 拆分儲存格
- 儲存格中的圖片
- 背景顏色
- PowerPoint
- 簡報
- Python
- Aspose.Slides
description: "使用 Python 管理 PowerPoint 表格儲存格：識別合併儲存格、移除邊框、拆分儲存格，並使用 Aspose.Slides for Python via Java 設定背景顏色和圖片。"
---
## **概述**

Aspose.Slides 允許您存取和修改 PowerPoint 簡報中的表格儲存格。本文說明如何識別合併的表格儲存格、移除儲存格邊框、在合併或拆分儲存格後處理儲存格編號、變更儲存格的背景色彩，以及在表格儲存格內部加入圖片。示例展示如何建立或開啟簡報、從投影片取得表格、透過儲存格屬性更新儲存格格式，並將修改後的簡報另存為 PPTX 檔案。

Aspose.Slides 使用零基索引，以 `(column, row)` 的順序存取表格儲存格。

## **識別合併的表格儲存格**

此範例開啟現有簡報，並將第一張投影片上的第一個圖形作為表格存取。它假設投影片與圖形均存在且圖形為表格。接著遍歷所有列與欄，使用 [isMergedCell](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#isMergedCell) 來識別位於合併區域的儲存格。對於每個符合條件的儲存格，會以 `row;column` 的順序列印座標、[getRowSpan](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getRowSpan)、[getColSpan](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getColSpan) 以及區域的起始座標 [getFirstRowIndex](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getFirstRowIndex) 與 [getFirstColumnIndex](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getFirstColumnIndex)。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("presentation_with_table.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    table = slide.getShapes().get_Item(0)

    row_count = table.getRows().size()
    for row_index in range(row_count):
        column_count = table.getColumns().size()
        for column_index in range(column_count):
            cell = table.get_Item(column_index, row_index)
            if cell.isMergedCell():
                print(f"Cell {row_index};{column_index} belongs to a merged region with RowSpan={cell.getRowSpan()} and ColSpan={cell.getColSpan()} starting at {cell.getFirstRowIndex()};{cell.getFirstColumnIndex()}.")
finally:
    presentation.dispose()
```

## **移除表格儲存格邊框**

建立一個 [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/)，並使用 [addTable](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addTable) 在其第一張投影片上加入表格。欄寬、列高與表格位置皆以點 (pt) 為單位指定。範例將四側的儲存格邊框全部設為 [FillType.NoFill](https://reference.aspose.com/slides/python-java/aspose.slides/filltype/)，使其不可見。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, FillType, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    column_widths = [50, 50, 50, 50]
    row_heights = [50, 30, 30, 30, 30]
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)

    for row in table.getRows():
        for cell in row:
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(FillType.NoFill)
            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(FillType.NoFill)
            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(FillType.NoFill)
            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(FillType.NoFill)

    presentation.save("table.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **新增對角線儲存格邊框**

使用 [getBorderDiagonalDown](https://reference.aspose.com/slides/python-java/aspose.slides/cellformat/#getBorderDiagonalDown) 從左上角繪製至右下角，使用 [getBorderDiagonalUp](https://reference.aspose.com/slides/python-java/aspose.slides/cellformat/#getBorderDiagonalUp) 從左下角繪製至右上角。對角線可標示角落標題。兩條對角線組合可形成 X，以標示該儲存格不適用。

每條對角線皆為 [LineFormat](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/)。在其 [getFillFormat](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#getFillFormat) 中，使用 [setFillType](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#setFillType) 選取 [FillType.Solid](https://reference.aspose.com/slides/python-java/aspose.slides/filltype/)，並透過 [getSolidFillColor](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#getSolidFillColor) 設定顏色。再以 [setWidth](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setWidth) 設定線條寬度（單位為點）。

此範例在同一列建立三個儲存格：一個紅色向下對角線、一個藍色向上對角線，以及同時具備兩條對角線的儲存格。上、下、左、右四側的儲存格邊框保持不變。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, FillType, SaveFormat
from java.awt import Color


def format_border(border, color, width):
    fill = border.getFillFormat()
    fill.setFillType(FillType.Solid)
    fill.getSolidFillColor().setColor(color)
    border.setWidth(width)


presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    table = slide.getShapes().addTable(45, 130, [210, 210, 210], [160])

    left_cell = table.get_Item(0, 0).getCellFormat()
    middle_cell = table.get_Item(1, 0).getCellFormat()
    right_cell = table.get_Item(2, 0).getCellFormat()
    format_border(left_cell.getBorderDiagonalDown(), Color.RED, 3)
    format_border(middle_cell.getBorderDiagonalUp(), Color.BLUE, 5)
    format_border(right_cell.getBorderDiagonalDown(), Color.RED, 3)
    format_border(right_cell.getBorderDiagonalUp(), Color.BLUE, 5)

    presentation.save("diagonal_cell_borders.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

對角線屬於格式屬性，而非儲存格拆分。每個儲存格僅保留單一文字框，可透過 [getTextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getTextFrame) 取得。對角線兩側的區域無法分別編輯。

以下為儲存格在 Microsoft PowerPoint 中的呈現：

![三個表格儲存格分別顯示從左上到右下的紅色對角線、從左下到右上的藍色對角線，以及兩條對角線形成的 X。](diagonal-cell-borders.png)

*由左至右：向下對角線（紅色，3 pt）、向上對角線（藍色，5 pt），以及兩條對角線形成的 X。*

## **合併表格儲存格**

使用 [mergeCells](https://reference.aspose.com/slides/python-java/aspose.slides/table/#mergeCells) 可將矩形範圍的表格儲存格合併為單一儲存格。指定範圍左上角與右下角的儲存格。最後一個參數決定合併是否可包含指定範圍外的儲存格；`False` 會將合併限制於該範圍內。

此範例建立一個 4×4 的表格，欄寬與列高皆為 70 點，然後合併位於 `(1, 1)` 到 `(2, 2)` 的四個中心儲存格。結果儲存格跨越兩欄兩列，而表格底層的格線仍保留四欄四列。若要存取合併儲存格的內容或格式，請使用其左上角位置：本例中的 `table.get_Item(1, 1)`。合併範圍內其餘位置仍屬於表格格線的一部份，因而範圍外儲存格的索引不會改變。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    column_widths = [70, 70, 70, 70]
    row_heights = [70, 70, 70, 70]
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)

    table.mergeCells(table.get_Item(1, 1), table.get_Item(2, 2), False)

    presentation.save("merged_cells.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **拆分表格儲存格**

前一個範例的合併動作保留了表格的格線。拆分儲存格可能會產生新格線欄，並改變其右側儲存格的欄索引。Aspose.Slides 遵循 PowerPoint 的表格格線模型。

此範例建立一個 4×4 的表格（欄寬與列高皆為 70 點），並於儲存格 `(1, 1)` 呼叫 [splitByWidth](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#splitByWidth)。將該儲存格的 70 點寬度的一半傳入，以建立兩個等寬的儲存格。

拆分後，可分別以 `table.get_Item(1, 1)` 與 `table.get_Item(2, 1)` 取得兩半。表格格線現在變為五欄：原本位於第 2、3 欄的儲存格分別移至第 3、4 欄。列索引保持不變。拆分後存取儲存格時，請使用更新後的欄索引。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    column_widths = [70, 70, 70, 70]
    row_heights = [70, 70, 70, 70]
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)

    table.get_Item(1, 1).splitByWidth(table.get_Item(1, 1).getWidth() / 2)

    presentation.save("split_cells.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

<!-- visual-explanation:manage-cells:start -->
[![未合併的 70 點儲存格拆分為兩個 35 點儲存格，新增第五格線欄並將右側索引向右移動。](visual-manage-cells-04c40789d81c.svg)](visual-manage-cells-04c40789d81c.svg)

*寬度拆分影響儲存格 (1, 1)，使用零基 (column, row) 索引。其他列的儲存格仍跨越新形成的兩個欄位。*
<!-- visual-explanation:manage-cells:end -->

### **依列或欄跨距拆分合併儲存格**

若要為資料填入做好合併範本儲存格的準備，可使用 [splitByRowSpan](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#splitByRowSpan) 依現有列邊界拆分，或使用 [splitByColSpan](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#splitByColSpan) 依欄邊界拆分。

`index` 參數計算拆分上部的列數或左部的欄數，且相對於合併區域：

- 列拆分：`0 < index <` [getRowSpan](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getRowSpan)。
- 欄拆分：`0 < index <` [getColSpan](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getColSpan)。

本例假設簡報的第一張投影片第一個圖形為表格，且 `(1, 2)` 與 `(1, 3)` 兩個儲存格垂直合併。從較低的位置開始，使用 [getFirstColumnIndex](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getFirstColumnIndex) 與 [getFirstRowIndex](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getFirstRowIndex) 定位起點，並檢查兩個跨距。`splitByRowSpan(1)` 會將第 2、3 列分離，以放置產品名稱。若為水平的兩欄合併，則改用 `splitByColSpan(1)`。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("table_template.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    table = slide.getShapes().get_Item(0)

    selected_cell = table.get_Item(1, 3)
    first_column_index = selected_cell.getFirstColumnIndex()
    first_row_index = selected_cell.getFirstRowIndex()
    merged_cell = table.get_Item(first_column_index, first_row_index)

    if merged_cell.isMergedCell() and merged_cell.getRowSpan() == 2 and merged_cell.getColSpan() == 1:
        merged_cell.splitByRowSpan(1)

        # 從表格中取得拆分後的儲存格。
        upper_cell = table.get_Item(first_column_index, first_row_index)
        lower_cell = table.get_Item(first_column_index, first_row_index + 1)
        print(f"Upper cell merged: {upper_cell.isMergedCell()}")
        print(f"Lower cell merged: {lower_cell.isMergedCell()}")

        upper_cell.getTextFrame().setText("Product A")
        lower_cell.getTextFrame().setText("Product B")

        presentation.save("split_template.pptx", SaveFormat.Pptx)
    else:
        print("Select a merged region spanning exactly two rows and one column.")
finally:
    presentation.dispose()
```

表格格線與其周圍的儲存格索引保持不變。可透過座標取得產生的儲存格；此處兩者的跨距皆為 1，且 [isMergedCell](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#isMergedCell) 會回傳 `False`。較大的區域在一次拆分後仍可能保留部分合併。

原始文字與格式保留於上方（或左側）儲存格；新儲存格為空白，但會繼承填充、邊框與邊距等格式。拆分後請自行填入文字，並明確設定任何必要的文字格式。

儲存的簡報中會出現分別為「Product A」與「Product B」的儲存格，且保留範本的儲存格格式。請參閱 [Cell API Reference](https://reference.aspose.com/slides/python-java/aspose.slides/cell/) 了解詳細資訊。

### **依特定高度拆分儲存格**

[splitByHeight](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#splitByHeight) 以點為單位接受上部的高度。[splitByRowSpan](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#splitByRowSpan) 以格線列數接受上部的列數。若要將 40 點高的儲存格置於右欄置中，可先將儲存格實際高度減去 40，然後將剩餘空間平均分配於上下兩側。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat
presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    table = slide.getShapes().addTable(50, 50, [160, 160], [140])
    table.get_Item(0, 0).getTextFrame().setText("Left")

    height = table.get_Item(1, 0).getHeight()
    margin = (height - 40) / 2
    
    table.get_Item(1, 0).splitByHeight(margin)
    table.get_Item(1, 1).splitByHeight(40)
    table.get_Item(1, 1).getTextFrame().setText("Middle")

    presentation.save("split_by_height.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

第一次拆分會新增一列格線，且在儲存格 `(1, 1)` 的下方保留 90 點。第二次拆分會將該儲存格分為 40 點的中間儲存格與 50 點的底部儲存格。右欄現在由上至下依序有高度為 50、40、50 點的三個儲存格。左側儲存格跨越全部三列，仍保持原始的 140 點高度。

![左側儲存格跨越整個表格高度，右側有三個儲存格，其中中間為「Middle」。](split-by-height.png)

## **變更表格儲存格背景色彩**

此範例建立一個欄寬 150 點、列高 50 點的表格。它使用 [setFillType](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#setFillType) 選取實心填充，並以 [getSolidFillColor](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#getSolidFillColor) 取得的顏色設定儲存格 `(2, 3)`（第 3 欄第 4 列）為紅色。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, FillType, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    column_widths = [150, 150, 150, 150]
    row_heights = [50, 50, 50, 50, 50]
    table = slide.getShapes().addTable(50, 50, column_widths, row_heights)

    cell = table.get_Item(2, 3)
    cell.getCellFormat().getFillFormat().setFillType(FillType.Solid)
    cell.getCellFormat().getFillFormat().getSolidFillColor().setColor(Color.RED)

    presentation.save("cell_background_color.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **在表格儲存格內加入圖片**

在執行此範例前，請將輸入圖片放置於工作目錄中。它使用 [Images.fromFile](https://reference.aspose.com/slides/python-java/aspose.slides/images/#fromFile) 載入圖片，並以 [addImage](https://reference.aspose.com/slides/python-java/aspose.slides/imagecollection/#addImage) 加入簡報的圖片集合。接著將圖片指派給儲存格 `(0, 0)`（表格的第一個儲存格）的圖片填充。

[PictureFillMode.Stretch](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillmode/) 會將圖片伸展以填滿儲存格，可能會改變其長寬比例。欄寬與列高以點為單位。載入的圖片會在 `finally` 區塊中釋放，於加入簡報後予以處理。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Images, FillType, PictureFillMode, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    column_widths = [150, 150, 150, 150]
    row_heights = [100, 100, 100, 100, 90]
    table = slide.getShapes().addTable(50, 50, column_widths, row_heights)

    image = Images.fromFile("aspose_logo.jpg")
    try:
        presentation_image = presentation.getImages().addImage(image)
    finally:
        image.dispose()

    table.get_Item(0, 0).getCellFormat().getFillFormat().setFillType(FillType.Picture)
    table.get_Item(0, 0).getCellFormat().getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch)
    table.get_Item(0, 0).getCellFormat().getFillFormat().getPictureFillFormat().getPicture().setImage(presentation_image)

    presentation.save("table_cell_with_image.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **常見問答**

**我可以為單一儲存格的不同側設定不同的線條粗細與樣式嗎？**

可以。[top](https://reference.aspose.com/slides/python-java/aspose.slides/cellformat/#getBorderTop)/[bottom](https://reference.aspose.com/slides/python-java/aspose.slides/cellformat/#getBorderBottom)/[left](https://reference.aspose.com/slides/python-java/aspose.slides/cellformat/#getBorderLeft)/[right](https://reference.aspose.com/slides/python-java/aspose.slides/cellformat/#getBorderRight) 邊框擁有各自的屬性，因而每側的粗細與樣式皆可不同。

**若在將圖片設定為儲存格背景後，調整欄／列大小，圖片會發生什麼變化？**

行為取決於 [fill mode](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillmode/)（stretch 或 tile）。若使用伸展，圖片會隨新儲存格調整；若使用平鋪，平鋪圖案會重新計算。

**我可以將超連結指派給儲存格的全部內容嗎？**

[Hyperlinks](/slides/zh-hant/python-java/manage-hyperlinks/) 是在儲存格文字框內的文字（段落）層級或整個表格/形狀層級設定。實務上，您可以將連結指派給段落或儲存格內的全部文字。

**我可以在單一儲存格內設定不同的字型嗎？**

可以。儲存格的文字框支援 [portions](https://reference.aspose.com/slides/python-java/aspose.slides/portion/)（執行），每個執行都可以有獨立的字型、樣式、大小與顏色。