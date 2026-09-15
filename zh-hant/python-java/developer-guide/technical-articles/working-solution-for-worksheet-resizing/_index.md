---
title: 工作表調整大小的可行解決方案
type: docs
weight: 20
url: /zh-hant/python-java/working-solution-for-worksheet-resizing/
keywords:
- OLE
- 預覽影像
- 影像調整大小
- Excel
- 工作表
- PowerPoint
- 簡報
- Python
- Java
- Aspose.Slides
description: "在簡報中修復 Excel 工作表 OLE 調整大小：透過兩種方式保持物件框一致性—縮放框架或工作表—支援 PPT 與 PPTX 格式。"
---
{{% alert color="info" title="Note" %}}
已觀察到，透過 Aspose 元件在 PowerPoint 簡報中嵌入為 OLE 物件的 Excel 工作表，在首次啟動後會被調整為未指定位的比例。此行為會在簡報中產生 OLE 物件啟動前後的明顯視覺差異。我們已詳細調查此問題並提供了解決方案，相關內容已於本文說明。
{{% /alert %}}

## **背景**

在文章 [Manage OLE](/slides/zh-hant/python-java/manage-ole/) 中，我們說明了如何使用 Aspose.Slides for Python via Java 在 PowerPoint 簡報中加入 OLE 框。為了解決 [object preview issue](/slides/zh-hant/python-java/object-preview-issue-when-adding-oleobjectframe/) ，我們為 OLE 物件框指派了所選工作表區域的影像。於產出的簡報中，當您雙擊顯示工作表影像的 OLE 物件框時，Excel 活頁簿會被啟動。最終使用者可以對實際的 Excel 活頁簿進行任意修改，然後點擊已啟動的 Excel 活頁簿之外的區域返回投影片。使用者返回投影片時，OLE 物件框的大小會發生變化。調整比例會依 OLE 物件框與嵌入的 Excel 活頁簿的大小而異。

## **調整大小的原因**

由於 Excel 活頁簿具有自身的視窗大小，首次啟動時會嘗試保留原始大小。另一方面，OLE 物件框也有自己的尺寸。根據 Microsoft 的說法，當 Excel 活頁簿被啟動時，Excel 與 PowerPoint 會協商尺寸，以確保在嵌入過程中維持正確的比例。調整大小是根據 Excel 視窗尺寸與 OLE 物件框的大小與位置之差異而發生的。

## **可行的解決方案**

有兩種可能的解決方案可避免此調整大小的效果。

- 在 PowerPoint 簡報中縮放 OLE 框的大小，使其符合 OLE 框中所需行列的高度與寬度。
- 保持 OLE 框大小不變，並縮放所參與的行與列的大小，使其適應選定的 OLE 框尺寸。

### **縮放 OLE 框大小**

在此方法中，我們將學習如何設定嵌入的 Excel 活頁簿的 OLE 框大小，使其與 Excel 工作表中參與行列的累積大小相匹配。

假設我們有一個範本 Excel 工作表，想將其作為 OLE 框加入簡報。在此情況下，OLE 物件框的大小將首先根據工作簿中參與行列的累積行高與列寬計算。然後，我們將把 OLE 框的大小設定為此計算值。為避免 PowerPoint 中 OLE 框顯示紅色的「EMBEDDED OLE OBJECT」訊息，我們還會擷取工作簿中所需行列的影像，並將其設定為 OLE 框的占位圖像。

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

    # 設定工作簿在 PowerPoint 中作為 OLE 物件使用時的顯示大小。
    last_row = start_row + row_count - 1
    last_column = start_column + column_count - 1
    workbook.getWorksheets().setOleSize(start_row, last_row, start_column, last_column)

    cell_range = worksheet.getCells().createRange(start_row, start_column, row_count, column_count)

    image_stream = create_ole_image(cell_range, image_resolution)
    try:
        # 取得 OLE 圖像的寬度與高度（點數）。
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

            # 將 OLE 圖像加入簡報資源。
            image_stream.reset()
            ole_image = presentation.getImages().addImage(image_stream)

            # 建立 OLE 物件框。
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

在此方法中，我們將學習如何縮放參與的行高與列寬，以符合自訂的 OLE 框尺寸。

假設我們有一個範本 Excel 工作表，想將其作為 OLE 框加入簡報。在此情況下，我們會設定 OLE 框的大小，並縮放參與 OLE 框區域的行與列的尺寸。接著，我們將工作簿儲存至串流以套用變更，並轉換為位元組陣列以加入 OLE 框。為避免 PowerPoint 中 OLE 框顯示紅色的「EMBEDDED OLE OBJECT」訊息，我們同樣會擷取工作簿中所需行列的影像，並將其設定為 OLE 框的占位圖像。

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

    # 設定工作簿在 PowerPoint 中作為 OLE 物件使用時的顯示大小。
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

            # 將 OLE 圖像加入簡報資源。
            image_stream.reset()
            ole_image = presentation.getImages().addImage(image_stream)

            # 建立 OLE 物件框。
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
有兩種方法可解決工作表調整大小的問題。選擇適當的方法取決於具體需求與使用情境。無論簡報是從範本建立或是全新創建，兩種方法皆以相同方式運作。此外，此解決方案對 OLE 物件框的大小沒有任何限制。
{{% /alert %}}

## **常見問答**

**為何嵌入的 Excel 工作表在 PowerPoint 中首次啟動時會改變大小？**  
這是因為 Excel 在啟動時會嘗試保持原始視窗大小，而 PowerPoint 中的 OLE 物件框則有自己的尺寸。PowerPoint 與 Excel 會協商尺寸以維持長寬比，這可能導致調整大小。

**是否能完全防止此調整大小的問題？**  
可以。透過將 OLE 框縮放至符合 Excel 儲存格範圍的大小，或將儲存格範圍縮放至符合所需的 OLE 框尺寸，即可防止不必要的調整大小。

**我該使用哪種縮放方式，OLE 框縮放還是儲存格範圍縮放？**  
若希望保留原始的 Excel 行列大小，請選擇 **OLE frame scaling**。若希望在簡報中 OLE 框保持固定大小，請選擇 **cell range scaling**。

**如果我的簡報是基於範本，這些解決方案仍然有效嗎？**  
會。這兩種解決方案皆適用於從範本建立或全新建立的簡報。

**使用這些方法時，OLE 框的大小有上限嗎？**  
沒有。只要適當設定縮放比例，OLE 物件框可以任意大小。

**有沒有方法避免 PowerPoint 中的「EMBEDDED OLE OBJECT」佔位文字？**  
可以。透過擷取目標 Excel 儲存格範圍的快照，並將其設定為 OLE 框的占位圖像，即可以自訂的預覽圖取代預設的佔位文字。

## **相關文章**

[在簡報中建立 Excel 圖表並將其嵌入為 OLE 物件](/slides/zh-hant/python-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)