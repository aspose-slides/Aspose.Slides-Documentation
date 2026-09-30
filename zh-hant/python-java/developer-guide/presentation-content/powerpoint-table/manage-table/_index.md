---
title: 在 Python 中管理簡報表格
linktitle: 管理表格
type: docs
weight: 10
url: /zh-hant/python-java/manage-table/
keywords:
- 新增表格
- 建立表格
- 存取表格
- 長寬比
- 對齊文字
- 文字格式設定
- 表格樣式
- PowerPoint
- 簡報
- Python
- Aspose.Slides
description: "使用 Aspose.Slides for Python via Java 在 PowerPoint 投影片中建立與編輯表格。探索簡潔的程式碼範例，以簡化您的表格工作流程。"
---
## **介紹**

PowerPoint 中的表格將資訊以行與列的方式組織，使閱讀與比較數值更為方便。

Aspose.Slides 提供 [Table](https://reference.aspose.com/slides/python-java/aspose.slides/table/) 與 [Cell](https://reference.aspose.com/slides/python-java/aspose.slides/cell/) 類別以及其他型別，讓您能在簡報中建立、更新與管理表格。

## **從頭建立表格**

透過指定位置、欄寬與列高來建立表格。將其加入投影片後，您可以設定儲存格邊框、合併儲存格與插入文字。

1. 建立 [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) 類別的實例。  
2. 依索引取得投影片的參考。  
3. 定義以點 (points) 為單位的欄寬清單。  
4. 定義以點 (points) 為單位的列高清單。  
5. 透過 [addTable](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addTable) 方法將 [Table](https://reference.aspose.com/slides/python-java/aspose.slides/table/) 物件加入投影片。  
6. 逐一處理每個 [Cell](https://reference.aspose.com/slides/python-java/aspose.slides/cell/)，為上、下、左、右邊框套用格式。  
7. 合併表格第一列的前兩個儲存格。  
8. 透過其 [getTextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getTextFrame) 方法存取合併後的儲存格。  
9. 設定合併儲存格的文字。  
10. 儲存已修改的簡報。

以下範例會在 (100, 50) 點的位置建立一個 3 欄 5 列的表格，套用寬度為 5 點的紅色邊框，合併第一列的前兩個儲存格，並將結果儲存為 `table.pptx`。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    column_widths = [50, 50, 50]
    row_heights = [50, 30, 30, 30, 30]
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)

    for row in table.getRows():
        for cell in row:
            cell_format = cell.getCellFormat()
            cell_format.getBorderTop().getFillFormat().setFillType(FillType.Solid)
            cell_format.getBorderTop().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell_format.getBorderTop().setWidth(5)
            cell_format.getBorderBottom().getFillFormat().setFillType(FillType.Solid)
            cell_format.getBorderBottom().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell_format.getBorderBottom().setWidth(5)
            cell_format.getBorderLeft().getFillFormat().setFillType(FillType.Solid)
            cell_format.getBorderLeft().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell_format.getBorderLeft().setWidth(5)
            cell_format.getBorderRight().getFillFormat().setFillType(FillType.Solid)
            cell_format.getBorderRight().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell_format.getBorderRight().setWidth(5)

    table.mergeCells(table.get_Item(0, 0), table.get_Item(1, 0), False)
    table.get_Item(0, 0).getTextFrame().setText("Merged Cells")

    presentation.save("table.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **標準表格的編號方式**

在標準表格中，儲存格索引是從零開始，使用 (欄, 列) 的順序。第一個儲存格的索引為 (0, 0)。

例如，擁有 4 欄 4 列的表格，其儲存格編號如下：

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

此範例會建立上圖所示的 4 × 4 表格，欄寬與列高皆為 70 點，並套用寬度為 5 點的紅色儲存格邊框。座標說明儲存格索引；範例會留下儲存格內容空白，並將表格儲存為 `StandardTables_out.pptx`。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    column_widths = [70, 70, 70, 70]
    row_heights = [70, 70, 70, 70]
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)

    for row in table.getRows():
        for cell in row:
            cell_format = cell.getCellFormat()
            cell_format.getBorderTop().getFillFormat().setFillType(FillType.Solid)
            cell_format.getBorderTop().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell_format.getBorderTop().setWidth(5)
            cell_format.getBorderBottom().getFillFormat().setFillType(FillType.Solid)
            cell_format.getBorderBottom().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell_format.getBorderBottom().setWidth(5)
            cell_format.getBorderLeft().getFillFormat().setFillType(FillType.Solid)
            cell_format.getBorderLeft().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell_format.getBorderLeft().setWidth(5)
            cell_format.getBorderRight().getFillFormat().setFillType(FillType.Solid)
            cell_format.getBorderRight().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell_format.getBorderRight().setWidth(5)

    presentation.save("StandardTables_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **存取現有表格**

表格儲存在投影片的形狀集合中。遍歷形狀以定位表格，然後使用 [Table](https://reference.aspose.com/slides/python-java/aspose.slides/table/) 類別讀取或更新其儲存格。

1. 使用 [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) 類別載入簡報。  
2. 依索引取得包含表格的投影片參考。  
3. 遍歷 [Shape](https://reference.aspose.com/slides/python-java/aspose.slides/shape/) 物件，當找到表格時即停止。如果投影片中有多個表格，使用 [getAlternativeText](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getAlternativeText) 來辨識所需的表格。  
4. 更新目標儲存格的文字。  
5. 儲存已修改的簡報。

以下範例會開啟 `UpdateExistingTable.pptx`，並在第一張投影片上找到第一個表格。它會將第 0 欄第 1 列的儲存格設為 `New`，然後將結果儲存為 `table1_out.pptx`。輸入檔必須至少包含一張投影片，且該投影片上的首個表格必須至少有一欄兩列。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, Table

presentation = Presentation("UpdateExistingTable.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    table = None

    for shape in slide.getShapes():
        if isinstance(shape, Table):
            table = shape
            break

    if table is not None:
        table.get_Item(0, 1).getTextFrame().setText("New")
        presentation.save("table1_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

若要調整既有表格的列高，並了解其實際高度為何可能超過要求的最小值，請參閱 [Control Row Height](/slides/zh-hant/python-java/manage-rows-and-columns/#control-row-height)。

## **找出擁有 TextFrame 的儲存格**

當通用文字處理程式從表格取得 [TextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/) 時，使用 [TextFrame.getParentCell](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/#getParentCell) 方法取得其所屬的 [Cell](https://reference.aspose.com/slides/python-java/aspose.slides/cell/)。對於表格儲存格的文字框而言，[TextFrame.getParentCell](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/#getParentCell) 會回傳擁有者，而 [TextFrame.getParentShape](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/#getParentShape) 則會回傳 `None`，即使表格本身也是一個形狀。

儲存格座標可透過唯讀的 [Cell.getFirstColumnIndex](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getFirstColumnIndex) 與 [Cell.getFirstRowIndex](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getFirstRowIndex) 方法取得。[TextFrame.getParentCell](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/#getParentCell) 也提供唯讀的導引功能：它回傳擁有者但不會改變所有權。使用前務必先檢查回傳的儲存格是否為 `None`。

如需完整範例，說明如何辨識表格儲存格與形狀的擁有者（包括與 SmartArt 節點相關的形狀），請參閱 [Search and Replace Text](/slides/zh-hant/python-java/search-and-replace-text/)。

## **在表格中對齊文字**

您可以控制個別儲存格的垂直錨點與文字方向。本節範例會將第一個儲存格的文字置中，並旋轉 270 度。

1. 建立 [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) 類別的實例。  
2. 依索引取得投影片參考。  
3. 將 [Table](https://reference.aspose.com/slides/python-java/aspose.slides/table/) 物件加入投影片。  
4. 從表格取得 [TextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/) 物件。  
5. 取得第一個 [Paragraph](https://reference.aspose.com/slides/python-java/aspose.slides/paragraph/)，並設定其文字與顏色。  
6. 使用 [setTextAnchorType](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#setTextAnchorType) 與 [setTextVerticalType](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#setTextVerticalType) 設定儲存格的垂直錨點與文字方向。  
7. 儲存已修改的簡報。

此範例會建立一個 4 × 4 表格，欄寬為 120 點、列高為 100 點。它會為儲存格 (0, 0) 格式化文字，並在第一列的其餘儲存格加入值，最後將結果儲存為 `Vertical_Align_Text_out.pptx`。

```python
import jpime
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat, TextAnchorType, TextVerticalType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    column_widths = [120, 120, 120, 120]
    row_heights = [100, 100, 100, 100]
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)
    
    table.get_Item(1, 0).getTextFrame().setText("10")
    table.get_Item(2, 0).getTextFrame().setText("20")
    table.get_Item(3, 0).getTextFrame().setText("30")

    text_frame = table.get_Item(0, 0).getTextFrame()
    paragraph = text_frame.getParagraphs().get_Item(0)

    portion = paragraph.getPortions().get_Item(0)
    portion.setText("Text here")
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)

    cell = table.get_Item(0, 0)
    cell.setTextAnchorType(TextAnchorType.Center)
    cell.setTextVerticalType(TextVerticalType.Vertical270)

    presentation.save("Vertical_Align_Text_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **在表格層級設定文字格式**

使用 [setTextFormat](https://reference.aspose.com/slides/python-java/aspose.slides/table/#setTextFormat) 可對表格中所有儲存格套用文字格式。其多載接受段落、區段與文字框的格式設定，讓您無需逐一遍歷儲存格即可設定這些屬性。

1. 使用 [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) 類別載入簡報。  
2. 依索引取得投影片參考。  
3. 從投影片取得 [Table](https://reference.aspose.com/slides/python-java/aspose.slides/table/) 物件。  
4. 使用 [setFontHeight](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setFontHeight) 設定文字的字體大小。  
5. 使用 [setAlignment](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setAlignment) 與 [setMarginRight](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setMarginRight) 設定段落對齊方式與右邊距。  
6. 使用 [setTextVerticalType](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setTextVerticalType) 設定文字方向。  
7. 儲存已修改的簡報。

以下範例會開啟 `table.pptx`（必須至少有一張投影片，且第一個形狀為表格），將字體大小設為 25 點，段落右對齊並設定右邊距 20 點，並將文字設為垂直。格式化後的簡報會儲存為 `result.pptx`。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ParagraphFormat, PortionFormat, Presentation, SaveFormat, TextAlignment, TextFrameFormat, TextVerticalType, Table

presentation = Presentation("table.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    table = slide.getShapes().get_Item(0)

    portion_format = PortionFormat()
    portion_format.setFontHeight(25)
    table.setTextFormat(portion_format)

    paragraph_format = ParagraphFormat()
    paragraph_format.setAlignment(TextAlignment.Right)
    paragraph_format.setMarginRight(20)
    table.setTextFormat(paragraph_format)

    text_frame_format = TextFrameFormat()
    text_frame_format.setTextVerticalType(TextVerticalType.Vertical)
    table.setTextFormat(text_frame_format)
    presentation.save("result.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **取得表格樣式屬性**

使用 [getStylePreset](https://reference.aspose.com/slides/python-java/aspose.slides/table/#getStylePreset) 讀取表格的預設樣式，使用 [setStylePreset](https://reference.aspose.com/slides/python-java/aspose.slides/table/#setStylePreset) 設定樣式。本範例會將 [TableStylePreset.DarkStyle1](https://reference.aspose.com/slides/python-java/aspose.slides/tablestylepreset/) 套用於第一個表格，列印預設值，然後將相同的預設套用於第二個表格。兩個表格均儲存於 `table-style.pptx`。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TableStylePreset

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    column_widths = [100, 150]
    row_heights = [5, 5, 5]
    table = slide.getShapes().addTable(10, 10, column_widths, row_heights)
    table.setStylePreset(TableStylePreset.DarkStyle1)

    style_preset = table.getStylePreset()
    print("Table style preset: ", style_preset)

    another_table = slide.getShapes().addTable(10, 100, column_widths, row_heights)
    another_table.setStylePreset(style_preset)

    presentation.save("table-style.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **鎖定表格的長寬比**

表格的長寬比是寬度與高度的比例。使用 [setAspectRatioLocked](https://reference.aspose.com/slides/python-java/aspose.slides/graphicalobjectlock/#setAspectRatioLocked) 可鎖定此比例。

以下範例會開啟 `pres.pptx`（必須至少有一張投影片，且第一個形狀為表格），列印目前的鎖定狀態，啟用長寬比鎖定，列印更新後的狀態 (`True`)，最後將結果儲存為 `pres-out.pptx`。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, Table

presentation = Presentation("pres.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    table = slide.getShapes().get_Item(0)

    print("Lock aspect ratio set: ", table.getGraphicalObjectLock().getAspectRatioLocked())

    table.getGraphicalObjectLock().setAspectRatioLocked(True)
    print("Lock aspect ratio set: ", table.getGraphicalObjectLock().getAspectRatioLocked())

    presentation.save("pres-out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **常見問題**

**我可以為整個表格以及其儲存格內的文字啟用從右至左 (RTL) 讀取方向嗎？**

可以。表格提供 [setRightToLeft](https://reference.aspose.com/slides/python-java/aspose.slides/table/#setRightToLeft) 方法，段落則有 [ParagraphFormat.setRightToLeft](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setRightToLeft)。同時使用兩者即可確保儲存格內文字的正確 RTL 排序與呈現。

**如何防止使用者在最終檔案中移動或調整表格的大小？**

使用 [shape locks](/slides/zh-hant/python-java/applying-protection-to-presentation/) 來停用移動、調整大小、選取等功能。這些鎖定同樣適用於表格。

**是否支援在儲存格內插入圖片作為背景？**

支援。您可以為儲存格設定 [picture fill](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/)，圖片會依所選模式（拉伸或鋪排）覆蓋整個儲存格區域。