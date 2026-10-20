---
title: 工作表調整大小的可行解決方案
type: docs
weight: 20
url: /zh-hant/python-java/working-solution-for-worksheet-resizing/
keywords:
- OLE
- 預覽圖像
- 圖像調整大小
- Excel
- 工作表
- PowerPoint
- 簡報
- Python
- Java
- Aspose.Slides
description: "在簡報中修復 Excel 工作表 OLE 調整大小問題：提供兩種方法使物件框保持一致——縮放框架或縮放工作表——適用於 PPT 與 PPTX 格式。"
---
{{% alert color="info" title="Note" %}}

使用 Aspose 元件在 PowerPoint 簡報中嵌入的 Excel 工作表作為 OLE 物件，首次啟動後可能會意外調整大小。此行為會在 OLE 物件啟動前後產生明顯的視覺差異。本文說明此問題並描述兩種解決方式。

{{% /alert %}}

## **背景**

在文章 [管理 OLE](/slides/zh-hant/python-java/manage-ole/) 中，我們說明了如何使用 Aspose.Slides for Python via Java 在 PowerPoint 簡報中新增 OLE 框架。為了解決 [物件預覽問題](/slides/zh-hant/python-java/object-preview-issue-when-adding-oleobjectframe/)，我們將選取的工作表區域圖像指派給 OLE 物件框架。在輸出簡報中，當您雙擊顯示工作表圖像的 OLE 物件框架時，Excel 活頁簿會被啟動。最終使用者可以對實際的 Excel 活頁簿進行任何所需的變更，然後點擊已啟動的 Excel 活頁簿之外的區域返回投影片。使用者返回投影片時，OLE 物件框架的大小會改變。調整大小的因子會依 OLE 物件框架及嵌入的 Excel 活頁簿的大小而異。

## **調整大小的原因**

由於 Excel 活頁簿有自己的視窗大小，它會在首次啟動時嘗試保留原始大小。另一方面，OLE 物件框架也有其自有大小。根據 Microsoft 的說法，當 Excel 活頁簿被啟動時，Excel 與 PowerPoint 會協商尺寸，以確保在嵌入過程中保持正確的比例。調整大小是根據 Excel 視窗大小與 OLE 物件框架的大小與位置之差異而產生的。

## **可行的解決方案**

有兩種可能的解決方案可避免此調整大小效果。

- 將 PowerPoint 簡報中的 OLE 框架縮放至與選取的列和欄的總高度與寬度相匹配。
- 保持 OLE 框架大小固定，並將選取的列和欄縮放以適應其內部。

### **縮放 OLE 框架大小**

此方法將 OLE 框架大小設定為與嵌入的 Excel 工作表中選取的列和欄的總高度與寬度相匹配。

此範例載入現有的 Excel 活頁簿，並使用零基索引選取其第一個工作表的前 10 列和 13 欄。[WorksheetCollection.setOleSize](https://reference.aspose.com/cells/python-java/asposecells.api/worksheetcollection/#setolesize) 定義要顯示的範圍。預覽以 96 DPI 進行渲染，並使用每英吋 72 點的比例將像素尺寸轉換為點。[ShapeCollection.addOleObjectFrame](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addOleObjectFrame) 將修改過的活頁簿以該尺寸嵌入框架中。預覽透過 [OleObjectFrame.getSubstitutePictureFormat](https://reference.aspose.com/slides/python-java/aspose.slides/oleobjectframe/#getSubstitutePictureFormat) 指派，以取代已儲存簡報中的 "EMBEDDED OLE OBJECT" 佔位符。

預覽輔助程式將 [PageSetup.setPrintArea](https://reference.aspose.com/cells/python-java/asposecells.api/pagesetup/#printarea) 設為選取的範圍，並移除邊距、頁首與頁尾。啟用 [ImageOrPrintOptions.setOnlyArea](https://reference.aspose.com/cells/python-java/asposecells.api/imageorprintoptions/#onlyarea) 後，[SheetRender.toImage](https://reference.aspose.com/cells/python-java/asposecells.api/sheetrender/#toimage) 會將該範圍渲染為 PNG 圖像。此輔助程式回傳一個包含 PNG 圖像的新輸入串流，並將指標定位於開頭以供簡報使用。

```python
import jpype
import asposecells
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposecells.api import Workbook, ImageOrPrintOptions, ImageType, SheetRender, CellsUnitType
from asposecells.api import SaveFormat as CellsSaveFormat
from asposeslides.api import Presentation, OleEmbeddedDataInfo, SaveFormat

ByteArrayInputStream = jpype.JClass("java.io.ByteArrayInputStream")
ByteArrayOutputStream = jpype.JClass("java.io.ByteArrayOutputStream")


def create_ole_image(cell_range, image_resolution):
    page_setup = cell_range.getWorksheet().getPageSetup()
    page_setup.setPrintArea(cell_range.getAddress())
    page_setup.setLeftMargin(0)
    page_setup.setRightMargin(0)
    page_setup.setTopMargin(0)
    page_setup.setBottomMargin(0)
    page_setup.clearHeaderFooter()

    image_options = ImageOrPrintOptions()
    image_options.setImageType(ImageType.PNG)
    image_options.setVerticalResolution(image_resolution)
    image_options.setHorizontalResolution(image_resolution)
    image_options.setOnePagePerSheet(True)
    image_options.setOnlyArea(True)

    sheet_render = SheetRender(cell_range.getWorksheet(), image_options)
    image_stream = ByteArrayOutputStream()
    try:
        sheet_render.toImage(0, image_stream)
        image_data = image_stream.toByteArray()
        return ByteArrayInputStream(image_data)
    finally:
        image_stream.close()


start_row, row_count = 0, 10
start_column, column_count = 0, 13
worksheet_index = 0
image_resolution = 96

workbook = Workbook("sample.xlsx")
try:
    worksheet = workbook.getWorksheets().get(worksheet_index)

    # 設定工作簿作為 PowerPoint 中 OLE 物件使用時的顯示大小。
    last_row = start_row + row_count - 1
    last_column = start_column + column_count - 1
    workbook.getWorksheets().setOleSize(start_row, last_row, start_column, last_column)

    cell_range = worksheet.getCells().createRange(start_row, start_column, row_count, column_count)

    image_stream = create_ole_image(cell_range, image_resolution)
    try:
        # 取得 OLE 圖像的寬度與高度（以點為單位）。
        image_io = jpype.JClass("javax.imageio.ImageIO")
        image = image_io.read(image_stream)
        frame_width = image.getWidth() * 72.0 / image_resolution
        frame_height = image.getHeight() * 72.0 / image_resolution

        # 使用已修改的工作簿。
        ole_stream = ByteArrayOutputStream()
        try:
            workbook.save(ole_stream, CellsSaveFormat.XLSX)
            workbook_data = ole_stream.toByteArray()
        finally:
            ole_stream.close()

        presentation = Presentation()
        try:
            slide = presentation.getSlides().get_Item(0)

            # 將 OLE 圖像加入簡報資源中。
            image_stream.reset()
            ole_image = presentation.getImages().addImage(image_stream)

            # 建立 OLE 物件框架。
            data_info = OleEmbeddedDataInfo(workbook_data, "xlsx")
            ole_frame = slide.getShapes().addOleObjectFrame(10.0, 10.0, frame_width, frame_height, data_info)
            ole_frame.getSubstitutePictureFormat().getPicture().setImage(ole_image)
            ole_frame.setObjectIcon(False)

            presentation.save("output.pptx", SaveFormat.Pptx)
        finally:
            presentation.dispose()
    finally:
        image_stream.close()
finally:
    workbook.dispose()
```

### **縮放儲存格範圍大小**

此方法將選取列的高度與選取欄的寬度縮放，以匹配自訂的 OLE 框架大小。

此範例載入現有的 Excel 活頁簿，並使用零基索引選取其第一個工作表的前 10 列和 13 欄。[WorksheetCollection.setOleSize](https://reference.aspose.com/cells/python-java/asposecells.api/worksheetcollection/#setolesize) 定義要顯示的範圍，且 scale_cell_range 輔助程式將該範圍縮放以適應寬 400 點、高 100 點的框架。將修改過的活頁簿儲存至串流後，[ShapeCollection.addOleObjectFrame](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addOleObjectFrame) 以指定大小嵌入。透過 [OleObjectFrame.getSubstitutePictureFormat](https://reference.aspose.com/slides/python-java/aspose.slides/oleobjectframe/#getSubstitutePictureFormat) 指派的 96 DPI 渲染預覽，使已儲存的簡報顯示選取的儲存格而非預設的佔位符。

縮放輔助程式會計算選取範圍的寬度與高度比例，保留其欄的相對寬度與列的相對高度。它在使用 [Cells.setColumnWidthInch](https://reference.aspose.com/cells/python-java/asposecells.api/cells/#setcolumnwidthinch) 與 [Cells.setRowHeightInch](https://reference.aspose.com/cells/python-java/asposecells.api/cells/#setrowheightinch) 套用之前，先將計算出的尺寸從點轉換為英吋。選取的範圍寬度與高度必須非零。

此預覽輔助程式使用 [SheetRender.toImage](https://reference.aspose.com/cells/python-java/asposecells.api/sheetrender/#toimage) 來渲染調整大小的範圍。它將 [PageSetup.setPrintArea](https://reference.aspose.com/cells/python-java/asposecells.api/pagesetup/#printarea) 限定為該範圍，移除邊距、頁首與頁尾，並回傳一個定位於開頭的 PNG 串流。

```python
import jpype
import asposecells
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposecells.api import Workbook, ImageOrPrintOptions, ImageType, SheetRender, CellsUnitType
from asposecells.api import SaveFormat as CellsSaveFormat
from asposeslides.api import Presentation, OleEmbeddedDataInfo, SaveFormat

ByteArrayInputStream = jpype.JClass("java.io.ByteArrayInputStream")
ByteArrayOutputStream = jpype.JClass("java.io.ByteArrayOutputStream")


def create_ole_image(cell_range, image_resolution):
    page_setup = cell_range.getWorksheet().getPageSetup()
    page_setup.setPrintArea(cell_range.getAddress())
    page_setup.setLeftMargin(0)
    page_setup.setRightMargin(0)
    page_setup.setTopMargin(0)
    page_setup.setBottomMargin(0)
    page_setup.clearHeaderFooter()

    image_options = ImageOrPrintOptions()
    image_options.setImageType(ImageType.PNG)
    image_options.setVerticalResolution(image_resolution)
    image_options.setHorizontalResolution(image_resolution)
    image_options.setOnePagePerSheet(True)
    image_options.setOnlyArea(True)

    sheet_render = SheetRender(cell_range.getWorksheet(), image_options)
    image_stream = ByteArrayOutputStream()
    try:
        sheet_render.toImage(0, image_stream)
        image_data = image_stream.toByteArray()
        return ByteArrayInputStream(image_data)
    finally:
        image_stream.close()


def scale_cell_range(cell_range, width, height):
    # 預期的儲存格範圍寬度與高度以點為單位。
    range_width = cell_range.getWidth()
    range_height = cell_range.getHeight()
    cells = cell_range.getWorksheet().getCells()

    for i in range(cell_range.getColumnCount()):
        column_index = cell_range.getFirstColumn() + i
        column_width = cells.getColumnWidth(column_index, False, CellsUnitType.POINT)
        new_column_width = column_width * width / range_width
        width_in_inches = new_column_width / 72.0
        cells.setColumnWidthInch(column_index, width_in_inches)

    for i in range(cell_range.getRowCount()):
        row_index = cell_range.getFirstRow() + i
        row_height = cells.getRowHeight(row_index, False, CellsUnitType.POINT)
        new_row_height = row_height * height / range_height
        height_in_inches = new_row_height / 72.0
        cells.setRowHeightInch(row_index, height_in_inches)


start_row, row_count = 0, 10
start_column, column_count = 0, 13
worksheet_index = 0
image_resolution = 96
frame_width, frame_height = 400.0, 100.0
workbook = Workbook("sample.xlsx")
try:
    worksheet = workbook.getWorksheets().get(worksheet_index)

    # 設定工作簿作為 PowerPoint 中 OLE 物件使用時的顯示大小。
    last_row = start_row + row_count - 1
    last_column = start_column + column_count - 1
    workbook.getWorksheets().setOleSize(start_row, last_row, start_column, last_column)

    cell_range = worksheet.getCells().createRange(start_row, start_column, row_count, column_count)
    # 將儲存格範圍縮放以符合框架大小。
    scale_cell_range(cell_range, frame_width, frame_height)
    image_stream = create_ole_image(cell_range, image_resolution)
    try:

        # 使用已修改的工作簿。
        ole_stream = ByteArrayOutputStream()
        try:
            workbook.save(ole_stream, CellsSaveFormat.XLSX)
            workbook_data = ole_stream.toByteArray()
        finally:
            ole_stream.close()

        presentation = Presentation()
        try:
            slide = presentation.getSlides().get_Item(0)

            # 將 OLE 圖像加入簡報資源中。
            image_stream.reset()
            ole_image = presentation.getImages().addImage(image_stream)

            # 建立 OLE 物件框架。
            data_info = OleEmbeddedDataInfo(workbook_data, "xlsx")
            ole_frame = slide.getShapes().addOleObjectFrame(10.0, 10.0, frame_width, frame_height, data_info)
            ole_frame.getSubstitutePictureFormat().getPicture().setImage(ole_image)
            ole_frame.setObjectIcon(False)

            presentation.save("output.pptx", SaveFormat.Pptx)
        finally:
            presentation.dispose()
    finally:
        image_stream.close()
finally:
    workbook.dispose()
```

## **結論**

{{% alert color="info" title="Note" %}} 

有兩種方法可解決工作表調整大小的問題。請選擇最符合您需求與使用情境的方法。無論簡報是從範本還是從頭建立，兩種方法的運作方式皆相同。此外，此解決方案對 OLE 物件框架的大小沒有任何限制。

{{% /alert %}}

## **常見問題**

**為什麼嵌入的 Excel 工作表在 PowerPoint 中首次啟動時會改變大小？**

這是因為 Excel 在啟動時會嘗試保持原始視窗大小，而 PowerPoint 中的 OLE 物件框架有其自有尺寸。PowerPoint 與 Excel 會協商大小以維持長寬比，從而可能導致調整大小。

**是否能完全防止此調整大小問題？**

可以。透過將 OLE 框架縮放以符合 Excel 儲存格範圍大小，或將儲存格範圍縮放以符合所需的 OLE 框架大小，即可避免不必要的調整。

**我應該使用哪種縮放方法，OLE 框架縮放還是儲存格範圍縮放？**

如果您想保留原始的 Excel 列與欄大小，請選擇 **OLE 框架縮放**。如果您希望簡報中的 OLE 框架具有固定尺寸，請選擇 **儲存格範圍縮放**。

**如果我的簡報是基於範本，這些解決方案會有效嗎？**

會。兩種解決方案皆適用於從範本建立的簡報以及從頭建立的簡報。

**使用這些方法時，OLE 框架的大小有上限嗎？**

沒有。只要適當設定縮放，OLE 物件框架可以任意大小。

**有沒有方法避免 PowerPoint 中的「EMBEDDED OLE OBJECT」佔位文字？**

可以。透過擷取目標 Excel 儲存格範圍的快照，並將其設定為 OLE 框架的佔位圖像，即可在預設佔位符號位置顯示自訂的預覽圖像。

## **相關文章**

[在簡報中建立 Excel 圖表並嵌入為 OLE 物件](/slides/zh-hant/python-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)

[使用 MS PowerPoint 增益集自動更新 OLE 物件](/slides/zh-hant/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)