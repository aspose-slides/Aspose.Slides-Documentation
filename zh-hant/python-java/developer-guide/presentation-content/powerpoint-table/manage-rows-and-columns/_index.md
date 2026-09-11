---
title: 使用 Python 管理 PowerPoint 表格的列與欄
linktitle: 列與欄
type: docs
weight: 20
url: /zh-hant/python-java/manage-rows-and-columns/
keywords:
- 表格列
- 表格欄
- 第一列
- 表格標頭
- 克隆列
- 克隆欄
- 拷貝列
- 拷貝欄
- 移除列
- 移除欄
- 列文字格式設定
- 欄文字格式設定
- 表格樣式
- PowerPoint
- 簡報
- Python
- Aspose.Slides
description: "使用 Aspose.Slides for Python via Java 在 PowerPoint 中管理表格的列與欄，並加快簡報編輯與資料更新的速度。"
---
## **介紹**

為了讓您能在 PowerPoint 簡報中管理表格的列與欄，Aspose.Slides 提供了 [Table](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/table/) 類別以及許多其他類型。

## **將第一列設為表頭**

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/) 類別的實例並載入簡報。
2. 依索引取得投影片的參考。
3. 建立 [Table](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/table/) 參考並將其設定為 `None`。
4. 迭代全部 [Shape](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/shape/) 物件以找出相關的表格。
5. 將表格的第一列設為表頭。

這段 Python 程式碼示範如何將表格的第一列設為表頭：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, Table

presentation = Presentation("table.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    table = None
    for shape in slide.getShapes():
        if isinstance(shape, Table):
            table = shape
            table.setFirstRow(True)
    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **複製表格的列或欄**

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/) 類別的實例並載入簡報。
2. 依索引取得投影片的參考。
3. 定義欄寬清單。
4. 定義列高清單。
5. 透過 [addTable](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/shapecollection/#addTable) 方法將 [Table](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/table/) 物件新增至投影片。
6. 複製表格列。
7. 複製表格欄。
8. 儲存已修改的簡報。

這段 Python 程式碼示範如何複製 PowerPoint 表格的列或欄：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("Test.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    column_widths = [50, 50, 50]
    row_heights = [50, 30, 30, 30, 30]
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)
    table.get_Item(0, 0).getTextFrame().setText("Row 1 Cell 1")
    table.get_Item(1, 0).getTextFrame().setText("Row 1 Cell 2")
    table.getRows().addClone(table.getRows().get_Item(0), False)
    table.get_Item(0, 1).getTextFrame().setText("Row 2 Cell 1")
    table.get_Item(1, 1).getTextFrame().setText("Row 2 Cell 2")
    table.getRows().insertClone(3, table.getRows().get_Item(1), False)
    table.getColumns().addClone(table.getColumns().get_Item(0), False)
    table.getColumns().insertClone(3, table.getColumns().get_Item(1), False)
    presentation.save("table_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **從表格中移除列或欄**

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/) 類別的實例。
2. 依索引取得投影片的參考。
3. 定義欄寬清單。
4. 定義列高清單。
5. 透過 [addTable](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/shapecollection/#addTable) 方法將 [Table](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/table/) 物件新增至投影片。
6. 移除表格列。
7. 移除表格欄。
8. 儲存已修改的簡報。

這段 Python 程式碼示範如何從表格中移除列或欄：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    column_widths = [100, 50, 30]
    row_heights = [30, 50, 30]
    table = slide.getShapes().addTable(100, 100, column_widths, row_heights)
    table.getRows().removeAt(1, False)
    table.getColumns().removeAt(1, False)
    presentation.save("TestTable_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **在表格列層級設定文字格式**

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/) 類別的實例並載入簡報。
2. 依索引取得投影片的參考。
3. 從投影片存取相關的 [Table](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/table/) 物件。
4. 使用 [setFontHeight](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/baseportionformat/#setFontHeight) 設定第一列儲存格的字型高度。
5. 使用 [setAlignment](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/paragraphformat/#setAlignment) 與 [setMarginRight](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/paragraphformat/#setMarginRight) 設定第一列儲存格的文字對齊方式與右側邊距。
6. 使用 [setTextVerticalType](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/textframeformat/#setTextVerticalType) 設定第二列儲存格的垂直文字類型。
7. 儲存已修改的簡報。

此 Python 程式碼示範此操作。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, Table, PortionFormat, ParagraphFormat, TextFrameFormat, TextAlignment, TextVerticalType

presentation = Presentation("table.pptx")
try:
    shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    if isinstance(shape, Table):
        table = shape
        portion_format = PortionFormat()
        portion_format.setFontHeight(25)
        table.getRows().get_Item(0).setTextFormat(portion_format)
        paragraph_format = ParagraphFormat()
        paragraph_format.setAlignment(TextAlignment.Right)
        paragraph_format.setMarginRight(20)
        table.getRows().get_Item(0).setTextFormat(paragraph_format)
        text_frame_format = TextFrameFormat()
        text_frame_format.setTextVerticalType(TextVerticalType.Vertical)
        table.getRows().get_Item(1).setTextFormat(text_frame_format)
        presentation.save("result.pptx", SaveFormat.Pptx)
    else:
        print("The first shape is not a table.")
finally:
    presentation.dispose()
```

## **在表格欄層級設定文字格式**

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/) 類別的實例並載入簡報。
2. 依索引取得投影片的參考。
3. 從投影片存取相關的 [Table](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/table/) 物件。
4. 使用 [setFontHeight](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/baseportionformat/#setFontHeight) 設定第一欄儲存格的字型高度。
5. 使用 [setAlignment](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/paragraphformat/#setAlignment) 與 [setMarginRight](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/paragraphformat/#setMarginRight) 設定第一欄儲存格的文字對齊方式與右側邊距。
6. 使用 [setTextVerticalType](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/textframeformat/#setTextVerticalType) 設定第二欄儲存格的垂直文字類型。
7. 儲存已修改的簡報。

此 Python 程式碼示範此操作：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, Table, PortionFormat, ParagraphFormat, TextFrameFormat, TextAlignment, TextVerticalType

presentation = Presentation("table.pptx")
try:
    shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    if isinstance(shape, Table):
        table = shape
        portion_format = PortionFormat()
        portion_format.setFontHeight(25)
        table.getColumns().get_Item(0).setTextFormat(portion_format)
        paragraph_format = ParagraphFormat()
        paragraph_format.setAlignment(TextAlignment.Right)
        paragraph_format.setMarginRight(20)
        table.getColumns().get_Item(0).setTextFormat(paragraph_format)
        text_frame_format = TextFrameFormat()
        text_frame_format.setTextVerticalType(TextVerticalType.Vertical)
        table.getColumns().get_Item(1).setTextFormat(text_frame_format)
        presentation.save("result.pptx", SaveFormat.Pptx)
    else:
        print("The first shape is not a table.")
finally:
    presentation.dispose()
```

## **取得表格樣式屬性**

Aspose.Slides 允許您取得表格的樣式屬性，以便將這些細節用於其他表格或其他地方。此 Python 程式碼示範如何從表格預設樣式取得樣式屬性：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TableStylePreset

presentation = Presentation()
try:
    column_widths = [100, 150]
    row_heights = [5, 5, 5]
    table = presentation.getSlides().get_Item(0).getShapes().addTable(10, 10, column_widths, row_heights)
    table.setStylePreset(TableStylePreset.DarkStyle1)
    style_preset = table.getStylePreset()
    print(style_preset)
    presentation.save("table.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **常見問題**

**我可以將 PowerPoint 主題／樣式套用到已建立的表格嗎？**

可以。表格會繼承投影片／版面配置／母片的主題，且您仍然可以在此基礎上覆寫填色、邊框與文字顏色。

**我可以像 Excel 那樣對表格列進行排序嗎？**

不行，Aspose.Slides 的表格沒有內建的排序或篩選功能。請先在記憶體中排序資料，然後依排序後的順序重新填入表格列。

**我能在保留特定儲存格自訂顏色的同時，使用交錯欄樣式嗎？**

可以。開啟交錯欄後，對特定儲存格套用本機格式；儲存格層級的格式會優先於表格樣式。