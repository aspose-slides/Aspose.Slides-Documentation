---
title: 工作表調整大小的可行解決方案
type: docs
weight: 40
url: /zh-hant/python-net/working-solution-for-worksheet-resizing/
keywords:
- OLE
- 預覽圖像
- 圖像調整大小
- Excel
- 工作表
- PowerPoint
- 簡報
- Python
- Aspose.Slides
description: "在簡報中修復 Excel 工作表 OLE 調整大小問題：提供兩種方法保持物件框一致——縮放框架或縮放工作表——適用於 PPT 與 PPTX 格式。"
---
{{% alert color="info" title="Note" %}}

使用 Aspose 元件將 Excel 工作表以 OLE 物件嵌入 PowerPoint 簡報時，首次啟動後可能會出現大小意外變更。此行為會在 OLE 物件啟動前後產生明顯的視覺差異。本文說明此問題並描述兩種解決方法。

{{% /alert %}} 

## **背景**

在文章[管理 OLE](/slides/zh-hant/python-net/manage-ole/)中，我們說明了如何使用 Aspose.Slides for Python via .NET 為 PowerPoint 簡報加入 OLE 框。為了解決[物件預覽問題](/slides/zh-hant/python-net/object-preview-issue-when-adding-oleobjectframe/)，我們將選取工作表區域的影像指派給 OLE 物件框。於輸出簡報中，當您雙擊顯示工作表影像的 OLE 物件框時，Excel 活頁簿會被啟動。最終使用者可以對實際的 Excel 活頁簿進行任何變更，然後點擊已啟動的 Excel 活頁簿之外的區域返回投影片。使用者返回投影片時，OLE 物件框的大小會發生變化。調整比例會因 OLE 物件框與內嵌 Excel 活頁簿的大小不同而有所差異。

## **調整大小的原因**

由於 Excel 活頁簿本身具有視窗大小，首次啟動時會嘗試保留原始大小。另一方面，OLE 物件框也有自己的尺寸。根據 Microsoft 的說法，當 Excel 活頁簿被啟動時，Excel 與 PowerPoint 會協商尺寸，以確保在嵌入過程中維持正確的比例。調整大小的發生是基於 Excel 視窗大小與 OLE 物件框大小及位置之間的差異。

## **可行的解決方案**

有兩種可能的解決方案可避免調整大小的效果。

- 在 PowerPoint 簡報中將 OLE 框縮放至與選取列與欄的總高度與寬度相匹配。
- 保持 OLE 框尺寸不變，將選取的列與欄縮放以適應框的大小。

### **縮放 OLE 框尺寸**

此方法將 OLE 框尺寸設為與內嵌 Excel 工作表中選取列與欄的總高度與寬度相匹配。

範例載入現有的 Excel 活頁簿，並使用零基索引選取其第一個工作表的前 10 列與 13 欄。[WorksheetCollection.set_ole_size](https://reference.aspose.com/cells/python-net/aspose.cells/worksheetcollection/set_ole_size/)定義顯示範圍。預覽以 96 DPI 進行渲染，並使用每英寸 72 點將像素尺寸轉換為點數。[ShapeCollection.add_ole_object_frame](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_ole_object_frame/)將已修改的活頁簿以這些尺寸嵌入框中。預覽透過[OleObjectFrame.substitute_picture_format](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/substitute_picture_format/)指派，以取代已儲存簡報中預設的「EMBEDDED OLE OBJECT」佔位文字。

預覽協助程式將[PageSetup.print_area](https://reference.aspose.com/cells/python-net/aspose.cells/pagesetup/print_area/)設為選取範圍，並移除邊界、頁首與頁尾。啟用[ImageOrPrintOptions.only_area](https://reference.aspose.com/cells/python-net/aspose.cells.rendering/imageorprintoptions/only_area/)後，[SheetRender.to_image](https://reference.aspose.com/cells/python-net/aspose.cells.rendering/sheetrender/to_image/)將該範圍渲染為 PNG 影像。協助程式在返回給簡報使用前，會先將影像串流倒回開頭。

```py
import io
import aspose.cells as cells

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

以下完整範例結合協助程式與活頁簿嵌入，並將簡報儲存為 `output.pptx`。

```py
import io
import aspose.slides as slides
import aspose.cells as cells

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

start_row, row_count = 0, 10
start_column, column_count = 0, 13
worksheet_index = 0

image_resolution = 96

with cells.Workbook("sample.xlsx") as workbook:
    worksheet = workbook.worksheets[worksheet_index]

    # 設定工作簿檔案作為 PowerPoint 中 OLE 物件時的顯示尺寸。
    last_row = start_row + row_count - 1
    last_column = start_column + column_count - 1
    workbook.worksheets.set_ole_size(start_row, last_row, start_column, last_column)

    cell_range = worksheet.cells.create_range(start_row, start_column, row_count, column_count)
    image_stream = create_ole_image(cell_range, image_resolution)

    # 取得 OLE 影像的寬度與高度（單位為點）。
    with slides.Images.from_stream(image_stream) as image:
        image_width = image.width * 72 / image_resolution
        image_height = image.height * 72 / image_resolution

    # 我們需要使用已修改的工作簿。
    with io.BytesIO() as ole_stream:
        workbook.save(ole_stream, cells.SaveFormat.XLSX)

        with slides.Presentation() as presentation:
            slide = presentation.slides[0]

            # 將 OLE 影像加入簡報資源。
            image_stream.seek(0)
            ole_image = presentation.images.add_image(image_stream)

            # 建立 OLE 物件框。
            data_info = slides.dom.ole.OleEmbeddedDataInfo(ole_stream.getvalue(), "xlsx")
            ole_frame = slide.shapes.add_ole_object_frame(10, 10, image_width, image_height, data_info)
            ole_frame.substitute_picture_format.picture.image = ole_image
            ole_frame.is_object_icon = False

            presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

### **縮放儲存格範圍尺寸**

此方法將選取列的高度與選取欄的寬度縮放，以符合自訂的 OLE 框尺寸。

範例載入現有的 Excel 活頁簿，並使用零基索引選取其第一個工作表的前 10 列與 13 欄。[WorksheetCollection.set_ole_size](https://reference.aspose.com/cells/python-net/aspose.cells/worksheetcollection/set_ole_size/)定義顯示範圍，以下協助程式將該範圍縮放至寬 400 點、高 100 點的框內。將修改後的活頁簿儲存至串流後，[ShapeCollection.add_ole_object_frame](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_ole_object_frame/)會依指定尺寸將其嵌入。以 96 DPI 渲染的預覽透過[OleObjectFrame.substitute_picture_format](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/substitute_picture_format/)指派，因此已儲存的簡報會顯示選取的儲存格，而非預設佔位文字。

縮放協助程式會為選取範圍計算寬度與高度比例，保留其欄的相對寬度與列的相對高度。它會先將計算出的尺寸從點數轉換為英吋，然後使用[Cells.set_column_width_inch](https://reference.aspose.com/cells/python-net/aspose.cells/cells/set_column_width_inch/)與[Cells.set_row_height_inch](https://reference.aspose.com/cells/python-net/aspose.cells/cells/set_row_height_inch/)套用。選取的範圍必須具備非零的寬度與高度。

```py
import aspose.cells as cells

# <param name="width">預期的儲存格範圍寬度（單位為點）。</param>
# <param name="height">預期的儲存格範圍高度（單位為點）。</param>
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

此預覽協助程式使用[SheetRender.to_image](https://reference.aspose.com/cells/python-net/aspose.cells.rendering/sheetrender/to_image/)渲染調整大小的範圍。它將[PageSetup.print_area](https://reference.aspose.com/cells/python-net/aspose.cells/pagesetup/print_area/)限制於該範圍，移除邊界、頁首與頁尾，並返回定位於開頭的 PNG 串流。

```py
import io
import aspose.cells as cells

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

以下完整範例結合協助程式與活頁簿嵌入，並將簡報儲存為 `output.pptx`。

```py
import io
import aspose.slides as slides
import aspose.cells as cells

# <param name="width">儲存格範圍的預期寬度（單位為點）。</param>
# <param name="height">儲存格範圍的預期高度（單位為點）。</param>
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

start_row, row_count = 0, 10
start_column, column_count = 0, 13
worksheet_index = 0

image_resolution = 96
frame_width, frame_height = 400.0, 100.0

with cells.Workbook("sample.xlsx") as workbook:
    worksheet = workbook.worksheets[worksheet_index]

    # 設定工作簿檔案作為 PowerPoint 中 OLE 物件時的顯示尺寸。
    last_row = start_row + row_count - 1
    last_column = start_column + column_count - 1
    workbook.worksheets.set_ole_size(start_row, last_row, start_column, last_column)

    # 將儲存格範圍縮放以符合框的尺寸。
    cell_range = worksheet.cells.create_range(start_row, start_column, row_count, column_count)
    scale_cell_range(cell_range, frame_width, frame_height)

    image_stream = create_ole_image(cell_range, image_resolution)

    # 我們需要使用已修改的工作簿。
    with io.BytesIO() as ole_stream:
        workbook.save(ole_stream, cells.SaveFormat.XLSX)

        with slides.Presentation() as presentation:
            slide = presentation.slides[0]

            # 將 OLE 影像加入簡報資源。
            ole_image = presentation.images.add_image(image_stream)

            # 建立 OLE 物件框。
            data_info = slides.dom.ole.OleEmbeddedDataInfo(ole_stream.getvalue(), "xlsx")
            ole_frame = slide.shapes.add_ole_object_frame(10, 10, frame_width, frame_height, data_info)
            ole_frame.substitute_picture_format.picture.image = ole_image
            ole_frame.is_object_icon = False

            presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **結論**

{{% alert color="info" title="Note" %}}

有兩種方法可解決工作表調整大小的問題。請依您的需求與使用情境選擇最適合的方式。無論簡報是從範本建立或是從頭開始，兩種方法皆可正常運作。此外，此解決方案對 OLE 物件框的尺寸沒有任何限制。

{{% /alert %}}

## **常見問題**

**為何嵌入的 Excel 工作表在 PowerPoint 中首次啟動時會改變大小？**

因為 Excel 嘗試在啟動時維持原始視窗大小，而 PowerPoint 中的 OLE 物件框則有自己的尺寸。PowerPoint 與 Excel 會協商尺寸以維持長寬比，導致調整大小的情況發生。

**能否完全防止此調整大小問題？**

可以。透過將 OLE 框縮放至符合 Excel 儲存格範圍尺寸，或將儲存格範圍縮放至符合目標 OLE 框尺寸，即可避免不必要的調整大小。

**應該使用哪種縮放方式，OLE 框縮放還是儲存格範圍縮放？**

如果希望保留 Excel 列與欄的原始尺寸，請選擇**OLE 框縮放**。如果希望在簡報中固定 OLE 框的尺寸，請選擇**儲存格範圍縮放**。

**這些解決方案在使用範本建立的簡報中也有效嗎？**

有效。兩種解決方案皆適用於基於範本或從頭建立的簡報。

**使用這些方法時，OLE 框的尺寸是否有限制？**

沒有。只要適當設定縮放比例，OLE 物件框可以設定為任意大小。

**有沒有辦法避免 PowerPoint 中顯示「EMBEDDED OLE OBJECT」佔位文字？**

可以。透過擷取目標 Excel 儲存格範圍的快照，並將其設為 OLE 框的佔位圖片，即可在簡報中顯示自訂的預覽影像，取代預設的佔位文字。