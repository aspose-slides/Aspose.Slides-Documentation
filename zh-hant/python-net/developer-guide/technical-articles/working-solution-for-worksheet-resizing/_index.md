---
title: 工作表重新調整大小的可行解決方案
type: docs
weight: 40
url: /zh-hant/python-net/working-solution-for-worksheet-resizing/
keywords:
- OLE
- 預覽影像
- 影像重新調整大小
- Excel
- 工作表
- PowerPoint
- 簡報
- Python
- Aspose.Slides
description: "在簡報中修復 Excel 工作表 OLE 重新調整大小問題：兩種方式保持物件框一致——縮放框架或工作表——支援 PPT 與 PPTX 格式。"
---
{{% alert color="primary" %}}

已觀察到，透過 Aspose 元件在 PowerPoint 簡報中嵌入為 OLE 物件的 Excel 工作表，在首次啟動後會被重新調整至未知的比例。此行為在 OLE 物件的啟動前後狀態之間產生顯著的視覺差異。我們已詳細調查此問題並提供了解決方案，相關內容已收錄於本篇文章。

{{% /alert %}}

## **背景**

在文章[Manage OLE](/slides/zh-hant/python-net/manage-ole/)中，我們說明了如何使用 Aspose.Slides for Python via .NET 将 OLE 框新增至 PowerPoint 簡報。為了解決[object preview issue](/slides/zh-hant/python-net/object-preview-issue-when-adding-oleobjectframe/)問題，我們將選取的工作表區域的影像指定給 OLE 物件框。在輸出簡報中，當您雙擊顯示工作表影像的 OLE 物件框時，Excel 活頁簿會被啟動。最終使用者可以對實際的 Excel 活頁簿進行任何想要的更改，然後點擊已啟動的 Excel 活頁簿之外的區域返回投影片。使用者返回投影片時，OLE 物件框的大小會改變。重新調整的比例會依據 OLE 物件框與嵌入的 Excel 活頁簿的大小而有所不同。

## **重新調整大小的原因**

由於 Excel 活頁簿具有自身的視窗大小，它會在首次啟動時嘗試保留原始尺寸。另一方面，OLE 物件框也有其自訂大小。根據 Microsoft 的說法，當 Excel 活頁簿被啟動時，Excel 與 PowerPoint 會協商尺寸，以確保在嵌入過程中維持正確的比例。重新調整大小是根據 Excel 視窗尺寸與 OLE 物件框的尺寸及位置之差異而發生的。

## **可行的解決方案**

有兩種可能的解決方案可避免此重新調整大小的效果。

- 在 PowerPoint 簡報中縮放 OLE 框的大小，使其匹配 OLE 框中所需的行數與列數的高度與寬度。
- 保持 OLE 框大小不變，並縮放參與的行與列的尺寸，以符合選取的 OLE 框大小。

### **縮放 OLE 框大小**

在此方法中，我們將學習如何設定嵌入的 Excel 活頁簿的 OLE 框大小，使其符合 Excel 工作表中參與的行與列的累計尺寸。

假設我們有一個範本 Excel 工作表，並希望將其以 OLE 框的形式加入簡報。在此情況下，OLE 物件框的大小會先根據工作簿中參與的行高與列寬的累計值來計算。然後，我們將把 OLE 框的大小設定為此計算值。為避免在 PowerPoint 中出現紅色的「EMBEDDED OLE OBJECT」訊息，我們還會擷取工作簿中所需行列的影像，並將其設定為 OLE 框的圖像。

```py
def create_ole_image(cell_range, image_resolution):
    page_setup = cell_range.worksheet.page_setup
    page_setup.print_area = cell_range.address
    page_setup.left_margin = 0.0
    page_setup.right_margin = 0.0
    page_setup.top_margin = 0.0
    page_setup.bottom_margin = 0.0
    page_setup.clear_header_footer()

    image_options = cells.rendering.ImageOrPrintOptions()
    image_options.image_type = cells.drawing.ImageType.PNG
    image_options.vertical_resolution = image_resolution
    image_options.horizontal_resolution = image_resolution
    image_options.one_page_per_sheet = True
    image_options.only_area = True

    sheet_render = cells.rendering.SheetRender(cell_range.worksheet, image_options)
    image_data = io.BytesIO()

    sheet_render.to_image(0, image_data)
    image_data.seek(0)

    return image_data
```
```py
start_row, row_count = 0, 10
start_column, column_count = 0, 13
worksheet_index = 0

image_resolution = 96

with cells.Workbook("sample.xlsx") as workbook:
    worksheet = workbook.worksheets[worksheet_index]

    # 設定工作簿檔案作為 PowerPoint 中 OLE 物件使用時的顯示大小。
    last_row = start_row + row_count - 1
    last_column = start_column + column_count - 1
    workbook.worksheets.set_ole_size(start_row, last_row, start_column, last_column)

    cell_range = worksheet.cells.create_range(start_row, start_column, row_count, column_count)
    image_stream = create_ole_image(cell_range, image_resolution)

    # 取得 OLE 圖片的寬度與高度（以點為單位）。
    with slides.Images.from_stream(image_stream) as image:
        image_width = image.width * 72 / image_resolution
        image_height = image.height * 72 / image_resolution

    # 我們需要使用已修改的工作簿。
    with io.BytesIO() as ole_stream:
        workbook.save(ole_stream, cells.SaveFormat.XLSX)

        with slides.Presentation() as presentation:
            slide = presentation.slides[0]

            # 將 OLE 圖片加入簡報資源。
            image_stream.seek(0)
            ole_image = presentation.images.add_image(image_stream)

            # 建立 OLE 物件框。
            data_info = slides.dom.ole.OleEmbeddedDataInfo(ole_stream.getvalue(), "xlsx")
            ole_frame = slide.shapes.add_ole_object_frame(10, 10, image_width, image_height, data_info)
            ole_frame.substitute_picture_format.picture.image = ole_image
            ole_frame.is_object_icon = False

            presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

### **縮放儲存格範圍大小**

在此方法中，我們將學習如何縮放參與的行高與列寬，使其符合自訂的 OLE 框大小。

假設我們有一個範本 Excel 工作表，並希望將其以 OLE 框的形式加入簡報。在此情況下，我們將設定 OLE 框的大小，並縮放參與 OLE 框區域的行與列的尺寸。接著，我們會將工作簿儲存至串流以套用變更，並轉換為位元組陣列以加入 OLE 框。為避免在 PowerPoint 中出現紅色的「EMBEDDED OLE OBJECT」訊息，我們還會擷取工作簿中所需行列的影像，並將其設定為 OLE 框的圖像。

```py
# <param name="width">預期的儲存格範圍寬度（單位：點）。</param>
# <param name="height">預期的儲存格範圍高度（單位：點）。</param>
def scale_cell_range(cell_range, width, height):
    range_width = cell_range.width
    range_height = cell_range.height

    for i in range(cell_range.column_count):
        column_index = cell_range.first_column + i
        column_width = cell_range.worksheet.cells.get_column_width(column_index, False, cells.CellsUnitType.POINT)

        new_column_width = column_width * width / range_width
        width_in_inches = new_column_width / 72
        cell_range.worksheet.cells.set_column_width_inch(column_index, width_in_inches)

    for i in range(cell_range.row_count):
        row_index = cell_range.first_row + i
        row_height = cell_range.worksheet.cells.get_row_height(row_index, False, cells.CellsUnitType.POINT)

        new_row_height = row_height * height / range_height
        height_in_inches = new_row_height / 72
        cell_range.worksheet.cells.set_row_height_inch(row_index, height_in_inches)
```
```py
def create_ole_image(cell_range, image_resolution):
    page_setup = cell_range.worksheet.page_setup
    page_setup.print_area = cell_range.address
    page_setup.left_margin = 0.0
    page_setup.right_margin = 0.0
    page_setup.top_margin = 0.0
    page_setup.bottom_margin = 0.0
    page_setup.clear_header_footer()

    image_options = cells.rendering.ImageOrPrintOptions()
    image_options.image_type = cells.drawing.ImageType.PNG
    image_options.vertical_resolution = image_resolution
    image_options.horizontal_resolution = image_resolution
    image_options.one_page_per_sheet = True
    image_options.only_area = True

    sheet_render = cells.rendering.SheetRender(cell_range.worksheet, image_options)
    image_data = io.BytesIO()

    sheet_render.to_image(0, image_data)
    image_data.seek(0)

    return image_data
```
```py
start_row, row_count = 0, 10
start_column, column_count = 0, 13
worksheet_index = 0

image_resolution = 96
frame_width, frame_height = 400.0, 100.0

with cells.Workbook("sample.xlsx") as workbook:
    worksheet = workbook.worksheets[worksheet_index]

    # 設定工作簿檔案作為 PowerPoint 中 OLE 物件使用時的顯示大小。
    last_row = start_row + row_count - 1
    last_column = start_column + column_count - 1
    workbook.worksheets.set_ole_size(start_row, last_row, start_column, last_column)

    # 將儲存格範圍縮放以符合框架大小。
    cell_range = worksheet.cells.create_range(start_row, start_column, row_count, column_count)
    scale_cell_range(cell_range, frame_width, frame_height)

    image_stream = create_ole_image(cell_range, image_resolution)

    # 我們需要使用已修改的工作簿。
    with io.BytesIO() as ole_stream:
        workbook.save(ole_stream, cells.SaveFormat.XLSX)

        with slides.Presentation() as presentation:
            slide = presentation.slides[0]

            # 將 OLE 圖片加入簡報資源。
            ole_image = presentation.images.add_image(image_stream)

            # 建立 OLE 物件框。
            data_info = slides.dom.ole.OleEmbeddedDataInfo(ole_stream.getvalue(), "xlsx")
            ole_frame = slide.shapes.add_ole_object_frame(10, 10, frame_width, frame_height, data_info)
            ole_frame.substitute_picture_format.picture.image = ole_image
            ole_frame.is_object_icon = False

            presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **結論**

{{% alert color="primary" %}}

有兩種方法可以解決工作表重新調整大小的問題。選擇適當的方法取決於具體需求與使用情境。無論是從範本還是從頭建立簡報，兩種方法的運作方式皆相同。此外，此解決方案對 OLE 物件框的大小沒有任何限制。

{{% /alert %}}