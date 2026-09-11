---
title: 管理 Python 中的簡報表格
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
description: "使用 Aspose.Slides for Python via Java 在 PowerPoint 投影片中建立與編輯表格。探索簡單的程式碼範例，簡化您的表格工作流程。"
---
## **簡介**

PowerPoint 中的表格是顯示資訊的有效方式。以格子（按行與欄排列）的方式呈現資訊，直觀且易於理解。

Aspose.Slides 提供 [Table](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/table/) 類別、[Cell](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/cell/) 類別，以及其他類型，讓您能在各種簡報中建立、更新與管理表格。

## **從頭建立表格**

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/) 類別的實例。  
2. 依索引取得投影片的參照。  
3. 定義欄寬清單。  
4. 定義列高清單。  
5. 透過 [addTable](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/shapecollection/#addTable) 方法將 [Table](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/table/) 物件加入投影片。  
6. 逐一遍歷每個 [Cell](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/cell/)，為上、下、左、右邊框套用格式。  
7. 合併表格第一列的前兩個儲存格。  
8. 取得 [Cell](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/cell/) 的 [TextFrame](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/textframe/)。  
9. 向 [TextFrame](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/textframe/) 新增文字。  
10. 儲存已修改的簡報。

以下 Python 程式碼示範如何在簡報中建立表格：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat
from java.awt import Color

# 建立一個代表 PPTX 檔案的 Presentation 類別實例
presentation = Presentation()
try:

    # 取得第一張投影片
    slide = presentation.getSlides().get_Item(0)

    # 定義欄寬和列高
    column_widths = [50, 50, 50]
    row_heights = [50, 30, 30, 30, 30]

    # 在投影片上新增表格形狀
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)

    # 為每個儲存格設定邊框格式
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

    # 合併第 1 列的第 1 與第 2 個儲存格
    table.mergeCells(table.getRows().get_Item(0).get_Item(0), table.getRows().get_Item(0).get_Item(1), False)

    # 向合併的儲存格加入文字
    table.getRows().get_Item(0).get_Item(0).getTextFrame().setText("Merged Cells")

    # 將簡報儲存至磁碟
    presentation.save("table.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **標準表格的編號方式**

在標準表格中，儲存格的編號方式直接且以零為起點。表格的第一個儲存格編號為 0,0（第 0 欄，第 0 列）。

例如，具有 4 欄 4 列的表格，其儲存格編號如下：

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

以下 Python 程式碼示範如何建立具有標準儲存格編號的表格：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat
from java.awt import Color

# 建立一個代表 PPTX 檔案的 Presentation 類別實例
presentation = Presentation()
try:

    # 取得第一張投影片
    slide = presentation.getSlides().get_Item(0)

    # 定義欄寬和列高
    column_widths = [70, 70, 70, 70]
    row_heights = [70, 70, 70, 70]

    # 在投影片上新增表格形狀
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)

    # 為每個儲存格設定邊框格式
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

    # 將簡報儲存至磁碟
    presentation.save("StandardTables_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **存取既有表格**

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/) 類別的實例。  

2. 依索引取得包含表格的投影片參照。  

3. 宣告一個 [Table](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/table/) 變數，並將其設為 `None`。  

4. 逐一遍歷所有 [Shape](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/shape/) 物件，直到找到表格。  

   若您認為目標投影片只有一個表格，可直接檢查其所有 Shape。當 Shape 被辨識為表格時，即可將其視為 [Table](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/table/) 物件。若投影片內有多個表格，建議透過其 [getAlternativeText](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/shape/#getAlternativeText) 進行搜尋。  

5. 使用 [Table](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/table/) 物件操作表格。以下範例更新第二列第一欄的文字。  

6. 儲存已修改的簡報。

以下 Python 程式碼示範如何存取並操作既有表格：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, Table

# 建立一個代表 PPTX 檔案的 Presentation 類別實例
presentation = Presentation("UpdateExistingTable.pptx")
try:

    # 取得第一張投影片
    slide = presentation.getSlides().get_Item(0)

    # 初始化表格參照。
    table = None

    # 遍歷形狀並設定找到的表格參照
    for shape in slide.getShapes():
        if isinstance(shape, Table):
            table = shape

            # 設定第二列第一欄的文字
            table.get_Item(0, 1).getTextFrame().setText("New")

    # 將修改後的簡報儲存至磁碟
    presentation.save("table1_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **找出擁有 TextFrame 的儲存格**

當通用文字處理程式從表格取得 [TextFrame](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/textframe/) 時，請使用 [TextFrame.getParentCell](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/textframe/#getParentCell) 方法取得其所屬的 [Cell](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/cell/)。對於表格儲存格的文字框，`TextFrame.getParentCell` 會回傳擁有者，而 `TextFrame.getParentShape` 會回傳 `None`，即使表格本身也是一個 Shape。

儲存格座標可透過唯讀的 [Cell.getFirstColumnIndex](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/cell/#getFirstColumnIndex) 與 [Cell.getFirstRowIndex](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/cell/#getFirstRowIndex) 方法取得。`TextFrame.getParentCell` 亦提供唯讀的導覽功能：它回傳擁有者但不會改變所有權。使用前務必先檢查回傳值是否為 `None`。

若需完整範例，說明如何辨識表格儲存格與 Shape 的擁有者（含 SmartArt 節點相關的 Shape），請參考 [Search and Replace Text](/slides/zh-hant/python-java/search-and-replace-text/)。

## **對表格內文字對齊**

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/) 類別的實例。  
2. 依索引取得投影片的參照。  
3. 將 [Table](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/table/) 物件加入投影片。  
4. 從表格取得 [TextFrame](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/textframe/) 物件。  
5. 取得該 [TextFrame](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/textframe/) 內的 [Paragraph](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/paragraph/)。  
6. 垂直對齊文字。  
7. 儲存已修改的簡報。

以下 Python 程式碼示範如何在表格內對齊文字：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat, TextAnchorType, TextVerticalType
from java.awt import Color

    # 建立 Presentation 類別的實例
presentation = Presentation()
try:

    # 取得第一張投影片
    slide = presentation.getSlides().get_Item(0)

    # 定義欄寬和列高
    column_widths = [120, 120, 120, 120]
    row_heights = [100, 100, 100, 100]

    # 將表格形狀加入投影片
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)
    table.get_Item(1, 0).getTextFrame().setText("10")
    table.get_Item(2, 0).getTextFrame().setText("20")
    table.get_Item(3, 0).getTextFrame().setText("30")

    # 取得文字框
    text_frame = table.get_Item(0, 0).getTextFrame()

    # 取得文字框中的第一段落
    paragraph = text_frame.getParagraphs().get_Item(0)

    # 取得段落中的第一個 Portion
    portion = paragraph.getPortions().get_Item(0)
    portion.setText("Text here")
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)

    # 垂直對齊文字
    cell = table.get_Item(0, 0)
    cell.setTextAnchorType(TextAnchorType.Center)
    cell.setTextVerticalType(TextVerticalType.Vertical270)

    # 將簡報儲存至磁碟
    presentation.save("Vertical_Align_Text_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **在表格層級設定文字格式**

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/) 類別的實例。  
2. 依索引取得投影片的參照。  
3. 從投影片取得 [Table](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/table/) 物件。  
4. 使用 [setFontHeight](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/baseportionformat/#setFontHeight) 設定文字字體高度。  
5. 以 [setAlignment](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/paragraphformat/#setAlignment) 及 [setMarginRight](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/paragraphformat/#setMarginRight) 設定對齊方式與右邊距。  
6. 透過 [setTextVerticalType](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/textframeformat/#setTextVerticalType) 設定垂直文字類型。  
7. 儲存已修改的簡報。

以下 Python 程式碼示範如何將您偏好的格式套用至表格內文字：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpime.startJVM()

from asposeslides.api import ParagraphFormat, PortionFormat, Presentation, SaveFormat, TextAlignment, TextFrameFormat, TextVerticalType, Table

# 建立 Presentation 類別的實例
presentation = Presentation("simpletable.pptx")
try:

    # 假設第一張投影片上的第一個形狀是表格
    shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    if isinstance(shape, Table):
        table = shape

        # 設定表格儲存格的字型高度
        portion_format = PortionFormat()
        portion_format.setFontHeight(25)
        table.setTextFormat(portion_format)

        # 在一次呼叫中設定表格儲存格的文字對齊與右邊距
        paragraph_format = ParagraphFormat()
        paragraph_format.setAlignment(TextAlignment.Right)
        paragraph_format.setMarginRight(20)
        table.setTextFormat(paragraph_format)

        # 設定表格儲存格的文字垂直類型
        text_frame_format = TextFrameFormat()
        text_frame_format.setTextVerticalType(TextVerticalType.Vertical)
        table.setTextFormat(text_frame_format)
        presentation.save("result.pptx", SaveFormat.Pptx)
    else:
        print("The first shape is not a table.")
finally:
    presentation.dispose()
```

## **取得表格樣式屬性**

Aspose.Slides 允許您擷取表格的樣式屬性，以便將這些細節套用至其他表格或其他位置。以下 Python 程式碼示範如何從表格預設樣式取得樣式屬性：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TableStylePreset

presentation = Presentation()
try:
    table = presentation.getSlides().get_Item(0).getShapes().addTable(10, 10, [100, 150], [5, 5, 5])
    table.setStylePreset(TableStylePreset.DarkStyle1)  # 更改預設的樣式預設主題

    # 取得表格的樣式預設
    style_preset = table.getStylePreset()
    print("Table style preset: ", style_preset)

    # 將取得的樣式預設套用到另一張表格
    another_table = presentation.getSlides().get_Item(0).getShapes().addTable(10, 100, [100, 150], [5, 5, 5])
    another_table.setStylePreset(style_preset)
    presentation.save("table.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **鎖定表格的長寬比**

幾何形狀的長寬比是指其在不同維度上的尺寸比例。Aspose.Slides 提供 [setAspectRatioLocked](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/graphicalobjectlock/#setAspectRatioLocked) 方法，讓您能鎖定表格及其他形狀的長寬比設定。

以下 Python 程式碼示範如何鎖定表格的長寬比：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, Table

presentation = Presentation("pres.pptx")
try:
    shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    if isinstance(shape, Table):
        table = shape
        print("Lock aspect ratio set: ", table.getGraphicalObjectLock().getAspectRatioLocked())
        table.getGraphicalObjectLock().setAspectRatioLocked(not table.getGraphicalObjectLock().getAspectRatioLocked())  # 反轉
        print("Lock aspect ratio set: ", table.getGraphicalObjectLock().getAspectRatioLocked())
        presentation.save("pres-out.pptx", SaveFormat.Pptx)
    else:
        print("The first shape is not a table.")
finally:
    presentation.dispose()
```

## **常見問題**

**我可以為整個表格以及儲存格內的文字啟用從右至左 (RTL) 讀取方向嗎？**

可以。表格提供 [setRightToLeft](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/table/#setRightToLeft) 方法，段落則有 [ParagraphFormat.setRightToLeft](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/paragraphformat/#setRightToLeft)。同時使用兩者即可確保儲存格內的 RTL 順序與呈現正確。

**如何防止使用者在最終檔案中移動或調整表格的大小？**

使用 [shape locks](/slides/zh-hant/python-java/applying-protection-to-presentation/) 可停用移動、調整大小、選取等功能，這些鎖定同樣適用於表格。

**是否支援在儲存格內插入影像作為背景？**

支援。您可以為儲存格設定 [picture fill](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/picturefillformat/)，影像會依所選模式（拉伸或平鋪）覆蓋儲存格區域。