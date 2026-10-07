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
- 儲存格內的圖像
- 背景顏色
- PowerPoint
- 簡報
- Python
- Aspose.Slides
description: "使用 Aspose.Slides for Python via Java 在 Python 中管理 PowerPoint 表格儲存格：識別合併儲存格、移除邊框、拆分儲存格，並設定背景顏色與圖像。"
---
## **概觀**

Aspose.Slides 允許您存取和修改 PowerPoint 簡報中的表格儲存格。本文說明如何識別合併的表格儲存格、移除儲存格邊框、在合併或拆分儲存格後處理儲存格編號、變更儲存格的背景色以及在表格儲存格內加入圖片。示例展示了如何建立或開啟簡報、從投影片取得表格、透過儲存格屬性更新儲存格格式，並將修改後的簡報儲存為 PPTX 檔案。

Aspose.Slides 使用零基索引，以 (column, row) 的順序存取表格儲存格。

## **識別合併的表格儲存格**

此範例開啟現有簡報，並將第一張投影片的第一個圖形作為表格存取。假設投影片與圖形皆存在且圖形為表格。接著遍歷所有列與行，使用 [isMergedCell](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#isMergedCell) 來識別合併區域中的儲存格。對於每個符合的儲存格，會以 `row;column` 的順序列印儲存格座標、[getRowSpan](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getRowSpan)、[getColSpan](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getColSpan) 以及區域起始座標 [getFirstRowIndex](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getFirstRowIndex) 與 [getFirstColumnIndex](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getFirstColumnIndex)。

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

建立一個 [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/)，並使用 [addTable](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addTable) 在其第一張投影片加入表格。欄寬、列高與表格位置均以點 (point) 為單位指定。範例將四側邊框全部設為 [FillType.NoFill](https://reference.aspose.com/slides/python-java/aspose.slides/filltype/)，使其不可見。

```python
import jpime
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

## **合併表格儲存格**

使用 [mergeCells](https://reference.aspose.com/slides/python-java/aspose.slides/table/#mergeCells) 可將矩形範圍的表格儲存格合併為單一儲存格。指定範圍左上角與右下角的儲存格。最後一個參數控制合併是否可包含指定範圍之外的儲存格；`False` 會將合併限制於該範圍內。

此範例建立一個 4×4 的表格，欄與列寬皆為 70 點，然後合併位於 `(1, 1)` 至 `(2, 2)` 的四個中心儲存格。結果儲存格跨兩欄兩列，而表格的底層格線仍保留四欄四列。若要存取合併儲存格的內容或格式，使用其左上角位置：在本例中為 `table.get_Item(1, 1)`。合併範圍內的其他位置仍屬於表格格線，因此範圍外的儲存格索引不會變動。

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

在前一個範例中合併儲存格會保留表格的格線。拆分儲存格可能會產生新的格線欄，並改變其右側儲存格的欄索引。Aspose.Slides 遵循 PowerPoint 的表格格線模型。

此範例建立一個 4×4 的表格，欄與列寬皆為 70 點，並在儲存格 `(1, 1)` 上呼叫 [splitByWidth](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#splitByWidth)。將儲存格 70 點寬度的一半傳入，以建立兩個等寬的儲存格。

拆分後，兩個子儲存格分別以 `table.get_Item(1, 1)` 與 `table.get_Item(2, 1)` 取用。表格格線現在有五欄：原本位於第 2、3 欄的儲存格分別移至第 3、4 欄。列索引保持不變。拆分後存取儲存格時，請使用這些更新後的欄索引。

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

### **依列或欄跨距拆分合併儲存格**

若要為資料填入做準備，使用 [splitByRowSpan](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#splitByRowSpan) 依現有列邊界拆分，或使用 [splitByColSpan](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#splitByColSpan) 依欄邊界拆分。

`index` 參數計算的是分割上方部分的列數或左側部分的欄數，且相對於合併區域：

- 列拆分：`0 < index <` [getRowSpan](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getRowSpan)。
- 欄拆分：`0 < index <` [getColSpan](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getColSpan)。

此範例假設簡報的第一張投影片的第一個圖形是一個表格，且 `(1, 2)` 與 `(1, 3)` 兩個儲存格已垂直合併。從較低的位置開始，使用 [getFirstColumnIndex](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getFirstColumnIndex) 與 [getFirstRowIndex](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getFirstRowIndex) 取得起點，並檢查兩個跨距。`splitByRowSpan(1)` 隨後將第 2 與第 3 列分開，以放置商品名稱。若為水平兩欄合併，則改用 `splitByColSpan(1)`。

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

        # 在拆分後從表格中取得產生的儲存格。
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

表格格線與周圍儲存格索引保持不變。依座標取得結果儲存格；此處兩者的跨距皆為 1，且 [isMergedCell](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#isMergedCell) 會回傳 `False`。較大的區域在一次拆分後仍可保留部分合併。

原始文字與其格式仍保留在上方（或左側）儲存格；新儲存格為空白，但會繼承儲存格格式，例如填色、邊框與邊距。拆分後請自行填入文字，並明確設定任何所需的文字格式。

儲存的簡報包含「Product A」與「Product B」兩個獨立儲存格，且保留了範本的儲存格格式。有關詳細資訊，請參閱 [儲存格 API 參考](https://reference.aspose.com/slides/python-java/aspose.slides/cell/)。

## **變更表格儲存格背景色**

此範例建立一個欄寬 150 點、列高 50 點的表格。它使用 [setFillType](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#setFillType) 設定實心填色，並將 [getSolidFillColor](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#getSolidFillColor) 取得的顏色設定為紅色，以套用於儲存格 `(2, 3)`（第 3 欄第 4 列）。

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

在執行此範例前，請將輸入圖片放置於工作目錄。它使用 [Images.fromFile](https://reference.aspose.com/slides/python-java/aspose.slides/images/#fromFile) 載入圖片，並以 [addImage](https://reference.aspose.com/slides/python-java/aspose.slides/imagecollection/#addImage) 將其加入簡報的圖片集合。接著將圖片指派給儲存格 `(0, 0)`（表格的第一個儲存格）的圖片填色。

[PictureFillMode.Stretch](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillmode/) 會將圖片拉伸以填滿儲存格，可能會改變其長寬比。欄寬與列高以點為單位。載入的圖片會在 `finally` 區塊中於加入簡報後釋放。

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

## **FAQ**

**我可以為單一儲存格的不同邊設定不同的線條粗細和樣式嗎？**

可以。[上](https://reference.aspose.com/slides/python-java/aspose.slides/cellformat/#getBorderTop)/[下](https://reference.aspose.com/slides/python-java/aspose.slides/cellformat/#getBorderBottom)/[左](https://reference.aspose.com/slides/python-java/aspose.slides/cellformat/#getBorderLeft)/[右](https://reference.aspose.com/slides/python-java/aspose.slides/cellformat/#getBorderRight) 邊框各自有獨立屬性，因而可設定不同的粗細與樣式。

**如果在將圖片設為儲存格背景後變更欄/列大小，圖片會怎樣？**

行為取決於[填充模式](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillmode/)（stretch / tile）。使用拉伸時，圖片會依新儲存格調整；使用平鋪時，平鋪圖案會重新計算。

**我可以將超連結指定給儲存格的全部內容嗎？**

[超連結](/slides/zh-hant/python-java/manage-hyperlinks/) 是在儲存格文字框內的文字（段落）層級或整個表格/圖形層級設定的。實務上，您可以將連結指派給段落或儲存格內的全部文字。

**我可以在單一儲存格內設定不同的字型嗎？**

可以。儲存格的文字框支援 [文字片段](https://reference.aspose.com/slides/python-java/aspose.slides/portion/)（執行序）具獨立的格式設定——包括字型、樣式、大小與顏色。