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
- 分割儲存格
- 儲存格中的圖片
- 背景色彩
- PowerPoint
- 簡報
- Python
- Aspose.Slides
description: "使用 Aspose.Slides for Python via Java，輕鬆在 PowerPoint 中管理表格儲存格。快速掌握存取、修改與樣式設定，實現順暢的投影片自動化。"
---
## **概述**

Aspose.Slides 讓您可以存取與修改 PowerPoint 簡報中的表格儲存格。本文說明如何識別合併的表格儲存格、移除儲存格邊框、在合併或分割儲存格後處理儲存格編號、變更儲存格的背景色，以及在表格儲存格內加入圖片。範例示範如何建立或開啟簡報、從投影片取得表格、透過儲存格屬性更新儲存格格式，並將修改後的簡報儲存為 PPTX 檔案。

## **識別合併的表格儲存格**

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/) 類別的實例。
2. 從第一張投影片取得表格。
3. 逐行逐列遍歷表格以找出合併的儲存格。
4. 發現合併儲存格時列印訊息。

以下 Python 程式碼示範如何在簡報中識別合併的表格儲存格：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Table

presentation = Presentation("SomePresentationWithTable.pptx")
try:
    # 假設第一張投影片上的第一個圖形是一個表格。
    shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    if isinstance(shape, Table):
        table = shape
        for i in range(table.getRows().size()):
            for j in range(table.getColumns().size()):
                current_cell = table.getRows().get_Item(i).get_Item(j)
                if current_cell.isMergedCell():
                    print(f"Cell {i};{j} is part of a merged cell with RowSpan={current_cell.getRowSpan()} and ColSpan={current_cell.getColSpan()} starting from Cell {current_cell.getFirstRowIndex()};{current_cell.getFirstColumnIndex()}.")
    else:
        print("The first shape is not a table.")
finally:
    presentation.dispose()
```

## **移除表格儲存格邊框**

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/) 類別的實例。
2. 依索引取得投影片的參考。
3. 定義欄寬清單。
4. 定義列高清單。
5. 透過 [addTable](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/shapecollection/#addTable) 方法將表格加入投影片。
6. 逐一儲存格清除上、下、左、右邊框。
7. 將修改後的簡報儲存為 PPTX 檔案。

以下 Python 程式碼示範如何移除表格儲存格的邊框：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, FillType, SaveFormat

presentation = Presentation()
try:
    # 存取第一張投影片。
    slide = presentation.getSlides().get_Item(0)

    # 定義欄寬與列高。
    column_widths = [50, 50, 50, 50]
    row_heights = [50, 30, 30, 30, 30]

    # 將表格加入投影片。
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)

    # 設定每個儲存格的邊框格式。
    for row in table.getRows():
        for cell in row:
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(FillType.NoFill)
            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(FillType.NoFill)
            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(FillType.NoFill)
            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(FillType.NoFill)

    # 將簡報儲存為 PPTX 檔案。
    presentation.save("table_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **合併儲存格中的編號**

如果我們合併兩對儲存格 (1, 1) 與 (2, 1)、以及 (1, 2) 與 (2, 2)，結果表格仍保留其儲存格編號。以下 Python 程式碼示範此過程：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, FillType, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    # 存取第一張投影片。
    slide = presentation.getSlides().get_Item(0)

    # 定義欄寬與列高。
    column_widths = [70, 70, 70, 70]
    row_heights = [70, 70, 70, 70]

    # 將表格加入投影片。
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)

    # 設定每個儲存格的邊框格式。
    for row in table.getRows():
        for cell in row:
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(FillType.Solid)
            cell.getCellFormat().getBorderTop().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell.getCellFormat().getBorderTop().setWidth(5)

            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(FillType.Solid)
            cell.getCellFormat().getBorderBottom().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell.getCellFormat().getBorderBottom().setWidth(5)

            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(FillType.Solid)
            cell.getCellFormat().getBorderLeft().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell.getCellFormat().getBorderLeft().setWidth(5)

            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(FillType.Solid)
            cell.getCellFormat().getBorderRight().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell.getCellFormat().getBorderRight().setWidth(5)


    # 合併儲存格 (1, 1) 與 (2, 1)。
    table.mergeCells(table.get_Item(1, 1), table.get_Item(2, 1), False)

    # 合併儲存格 (1, 2) 與 (2, 2)。
    table.mergeCells(table.get_Item(1, 2), table.get_Item(2, 2), False)

    # 將簡報儲存為 PPTX 檔案。
    presentation.save("MergeCells_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

接著我們進一步合併儲存格，將 (1, 1) 與 (1, 2) 合併。結果是一個在中心擁有大型合併儲存格的表格：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, FillType, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    # 存取第一張投影片。
    slide = presentation.getSlides().get_Item(0)

    # 定義欄寬與列高。
    column_widths = [70, 70, 70, 70]
    row_heights = [70, 70, 70, 70]

    # 將表格加入投影片。
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)

    # 設定每個儲存格的邊框格式。
    for row in table.getRows():
        for cell in row:
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(FillType.Solid)
            cell.getCellFormat().getBorderTop().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell.getCellFormat().getBorderTop().setWidth(5)

            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(FillType.Solid)
            cell.getCellFormat().getBorderBottom().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell.getCellFormat().getBorderBottom().setWidth(5)

            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(FillType.Solid)
            cell.getCellFormat().getBorderLeft().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell.getCellFormat().getBorderLeft().setWidth(5)

            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(FillType.Solid)
            cell.getCellFormat().getBorderRight().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell.getCellFormat().getBorderRight().setWidth(5)


    # 合併儲存格 (1, 1) 與 (2, 1)。
    table.mergeCells(table.get_Item(1, 1), table.get_Item(2, 1), False)

    # 合併儲存格 (1, 2) 與 (2, 2)。
    table.mergeCells(table.get_Item(1, 2), table.get_Item(2, 2), False)

    # 合併儲存格 (1, 1) 與 (1, 2)。
    table.mergeCells(table.get_Item(1, 1), table.get_Item(1, 2), True)

    # 將簡報儲存為 PPTX 檔案。
    presentation.save("MergeCells_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **分割儲存格的編號**

在前述範例中，合併表格儲存格不會改變其他儲存格的編號。

這次，我們使用一個普通表格（未合併儲存格）並嘗試分割儲存格 (1, 1) 以產生特殊表格。您可能需要留意此表格的編號，雖然看起來怪異，但這正是 Microsoft PowerPoint 對表格儲存格進行編號的方式，Aspose.Slides 亦如此。

以下 Python 程式碼示範我們所描述的過程：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, FillType, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    # 存取第一張投影片。
    slide = presentation.getSlides().get_Item(0)

    # 定義欄寬與列高。
    column_widths = [70, 70, 70, 70]
    row_heights = [70, 70, 70, 70]

    # 將表格加入投影片。
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)

    # 設定每個儲存格的邊框格式。
    for row in table.getRows():
        for cell in row:
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(FillType.Solid)
            cell.getCellFormat().getBorderTop().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell.getCellFormat().getBorderTop().setWidth(5)

            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(FillType.Solid)
            cell.getCellFormat().getBorderBottom().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell.getCellFormat().getBorderBottom().setWidth(5)

            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(FillType.Solid)
            cell.getCellFormat().getBorderLeft().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell.getCellFormat().getBorderLeft().setWidth(5)

            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(FillType.Solid)
            cell.getCellFormat().getBorderRight().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell.getCellFormat().getBorderRight().setWidth(5)


    # 分割儲存格 (1, 1)。
    table.get_Item(1, 1).splitByWidth(table.get_Item(2, 1).getWidth() / 2)

    # 將簡報儲存為 PPTX 檔案。
    presentation.save("SplitCells_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **變更表格儲存格的背景色**

以下 Python 程式碼示範如何變更表格儲存格的背景色：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, FillType, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    # 存取第一張投影片。
    slide = presentation.getSlides().get_Item(0)

    # 定義欄寬與列高。
    column_widths = [150, 150, 150, 150]
    row_heights = [50, 50, 50, 50, 50]

    # 將表格加入投影片。
    table = slide.getShapes().addTable(50, 50, column_widths, row_heights)

    # 設定儲存格的背景顏色。
    cell = table.get_Item(2, 3)
    cell.getCellFormat().getFillFormat().setFillType(FillType.Solid)
    cell.getCellFormat().getFillFormat().getSolidFillColor().setColor(Color.RED)

    # 將簡報儲存為 PPTX 檔案。
    presentation.save("cell_background_color.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **在表格儲存格內加入圖片**

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/) 類別的實例。
2. 依索引取得投影片的參考。
3. 定義欄寬清單。
4. 定義列高清單。
5. 透過 [addTable](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/shapecollection/#addTable) 方法將表格加入投影片。
6. 使用 [Images.fromFile](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/images/#fromFile) 載入圖片檔案。
7. 將圖片加入簡報以建立 [PPImage](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/ppimage/) 物件。
8. 將表格儲存格的 [FillFormat](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/fillformat/) 填充類型設定為 [FillType.Picture](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/filltype/#Picture)。
9. 將圖片加入表格的第一個儲存格。
10. 將修改後的簡報儲存為 PPTX 檔案。

以下 Python 程式碼示範在建立表格時如何將圖片放入儲存格內：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Images, FillType, PictureFillMode, SaveFormat

presentation = Presentation()
try:
    # 存取第一張投影片。
    slide = presentation.getSlides().get_Item(0)

    # 定義欄寬與列高。
    column_widths = [150, 150, 150, 150]
    row_heights = [100, 100, 100, 100, 90]

    # 將表格加入投影片。
    table = slide.getShapes().addTable(50, 50, column_widths, row_heights)

    # 從圖片檔案建立簡報影像。
    image = Images.fromFile("image.jpg")
    try:
        picture = presentation.getImages().addImage(image)
    finally:
        image.dispose()

    # 將圖片加入第一個表格儲存格。
    cell_format = table.get_Item(0, 0).getCellFormat()
    cell_format.getFillFormat().setFillType(FillType.Picture)
    cell_format.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch)
    cell_format.getFillFormat().getPictureFillFormat().getPicture().setImage(picture)

    # 將簡報儲存為 PPTX 檔案。
    presentation.save("Image_In_TableCell_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **常見問題**

**我可以為單一儲存格的不同邊設定不同的線條粗細與樣式嗎？**

可以。[top](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/cellformat/#getBorderTop)/[bottom](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/cellformat/#getBorderBottom)/[left](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/cellformat/#getBorderLeft)/[right](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/cellformat/#getBorderRight) 邊框各自有獨立屬性，因而可以讓每一側的粗細與樣式不同。這與本文中示範的每側邊框控制邏輯一致。

**在將圖片設為儲存格背景後，若變更欄或列的大小，圖片會發生什麼變化？**

行為取決於 [fill mode](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/picturefillmode/)（stretch/​tile）。使用 stretch 時，圖片會隨新儲存格尺寸調整；使用 tile 時，圖磚會重新計算。本文提及了儲存格內圖片的顯示模式。

**我可以為儲存格內的全部內容指定超連結嗎？**

[Hyperlinks](/slides/zh-hant/python-java/manage-hyperlinks/) 設定於儲存格文字框內的文字（段落）層級，或整個表格/形狀層級。實務上，您可以將連結指派給段落或儲存格內的全部文字。

**我可以在單一儲存格內使用不同的字型嗎？**

可以。儲存格的文字框支援 [portions](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/portion/)（文字跑）具有獨立的格式設定——包括字體、樣式、大小與顏色。