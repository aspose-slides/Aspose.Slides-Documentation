---
title: 建立 Excel 圖表並將其作為 OLE 物件嵌入簡報中
type: docs
weight: 50
url: /zh-hant/python-net/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/
keywords:
- Excel 圖表
- 嵌入圖表
- OLE 物件
- PowerPoint
- 簡報
- Python
- Python via .NET
- Aspose.Slides
description: "使用 Aspose.Cells for Python via .NET 建立 Excel 圖表，並將活頁簿嵌入使用 Aspose.Slides 的 PowerPoint 簡報中，包含圖表預覽。"
---
## **概觀**

本文說明如何使用 Aspose.Cells for Python via .NET 建立 Excel 縱向長條圖，並將其活頁簿嵌入到使用 Aspose.Slides for Python via .NET 的 PowerPoint 簡報中。嵌入的活頁簿同時包含原始資料與圖表。會先以單獨的 PNG 預覽在投影片上顯示圖表，於 OLE 物件被啟用前呈現。

最終會得到嵌入的 Excel 物件，而非原生 PowerPoint 圖表。透過 OLE 編輯活頁簿需要支援 OLE 啟用的桌面應用程式，以及相容的 Excel 安裝。

## **先決條件**

在 Python 環境中安裝 `aspose-cells-python` 與 `aspose-slides` 套件。使用這些函式庫產生簡報時不需要 Microsoft Office。

不需要任何輸入檔案：範例會在記憶體中建立資料與圖表，然後將 `OutputChart.pptx` 寫入目前的工作目錄。於評估模式之外執行時，請為兩個產品套用授權。

## **嵌入運作方式**

1. 建立一個包含資料工作表與圖表工作表的活頁簿。
2. 將圖表工作表設為使用中，使活頁簿開啟時直接顯示圖表。
3. 設定活頁簿的 OLE 顯示範圍，並將圖表渲染為 PNG。
4. 將活頁簿以 XLSX 格式儲存於記憶體，並將其位元組嵌入投影片中。
5. 將 PNG 設為 OLE 物件的預覽圖，並將簡報儲存為 PPTX。

活頁簿的顯示範圍與投影片上的框架扮演不同角色。 [set_ole_size](https://reference.aspose.com/cells/python-net/aspose.cells/worksheetcollection/set_ole_size/) 使用零基礎的起始/結束列與欄索引。相對地，[ChartCollection.add](https://reference.aspose.com/cells/python-net/aspose.cells.charts/chartcollection/add/) 使用上方列、左側欄、下方列與右側欄。範例以第 55 行與第 25 欄作為右下界限；這些數值屬於版面配置的選擇，而非資料列或欄的數量。

投影片框架使用點作為單位。範例將其調整至投影片內部並置中，同時保留 PNG 的長寬比例，而不是將預覽圖拉伸至填滿整個投影片。

## **建立並嵌入圖表**

以下完整範例會在 `DataSheet` 中填入四列五欄的數值。每一列會成為圖表的一個系列。於儲存活頁簿之前，會將 `ChartSheet` 設為使用中的工作表。

活頁簿會明確儲存為 XLSX，與傳遞給 [OleEmbeddedDataInfo](https://reference.aspose.com/slides/python-net/aspose.slides.dom.ole/oleembeddeddatainfo/) 的 `xlsx` 副檔名相符。PNG 直接從其串流載入，未經中介的位圖轉換。透過 [substitute_picture_format](https://reference.aspose.com/slides/python-net/aspose.slides/ioleobjectframe/substitute_picture_format/) 指派後，會取代預設的 OLE 佔位符。

```python
import io
import aspose.cells as cells
import aspose.cells.charts as charts
import aspose.cells.drawing as drawing
import aspose.slides as slides

workbook = cells.Workbook()
data_sheet = workbook.worksheets[0]
data_sheet.name = "DataSheet"

values = [
    [67, 44, 46, 43, 24],
    [86, 64, 97, 29, 40],
    [68, 89, 78, 69, 38],
    [91, 48, 60, 26, 25],
]

for row, row_values in enumerate(values):
    for column, value in enumerate(row_values):
        data_sheet.cells.get(row, column).put_value(value)

chart_sheet_index = workbook.worksheets.add(cells.SheetType.CHART)
chart_sheet = workbook.worksheets[chart_sheet_index]
chart_sheet.name = "ChartSheet"

last_chart_row = 55
last_chart_column = 25
chart_index = chart_sheet.charts.add(charts.ChartType.COLUMN, 0, 0, last_chart_row, last_chart_column)
chart = chart_sheet.charts[chart_index]
for row in range(1, len(values) + 1):
    chart.n_series.add(f"DataSheet!A{row}:E{row}", False)

workbook.worksheets.active_sheet_index = chart_sheet_index
workbook.worksheets.set_ole_size(0, last_chart_row, 0, last_chart_column)

# 渲染圖表預覽並分別序列化可編輯的活頁簿。
with io.BytesIO() as chart_image_stream, io.BytesIO() as workbook_stream:
    chart.to_image(chart_image_stream, drawing.ImageType.PNG)
    chart_image_stream.seek(0)
    workbook.save(workbook_stream, cells.SaveFormat.XLSX)
    workbook_bytes = workbook_stream.getvalue()

    with slides.Images.from_stream(chart_image_stream) as chart_image:
        with slides.Presentation() as presentation:
            slide = presentation.slides[0]
            slide_size = presentation.slide_size.size

            # 在投影片內調整預覽大小，使其適合且不改變長寬比。
            scale = min(slide_size.width / chart_image.width, slide_size.height / chart_image.height)
            frame_width = chart_image.width * scale
            frame_height = chart_image.height * scale
            frame_x = (slide_size.width - frame_width) / 2
            frame_y = (slide_size.height - frame_height) / 2

            embedded_data = slides.dom.ole.OleEmbeddedDataInfo(workbook_bytes, "xlsx")
            ole_frame = slide.shapes.add_ole_object_frame(frame_x, frame_y, frame_width, frame_height, embedded_data)
            preview_image = presentation.images.add_image(chart_image)
            ole_frame.substitute_picture_format.picture.image = preview_image

            presentation.save("OutputChart.pptx", slides.export.SaveFormat.PPTX)
```

## **預期結果**

`OutputChart.pptx` 包含一張投影片，內有嵌入的 Excel 活頁簿與圖表預覽。活頁簿內含原始資料及一個四系列的縱向長條圖。預覽圖置於投影片中央，且保持其比例。

![Excel 縱向長條圖作為嵌入活頁簿的預覽](excel-chart-ole-preview.png)

在具備 Excel 的相容桌面 PowerPoint 環境中，雙擊該物件即可啟動並編輯嵌入的活頁簿。啟用與編輯取決於主機應用程式的 OLE 支援與安全性設定。

## **常見問題**

**為何需要預覽圖？**

嵌入的活頁簿與投影片的預覽屬於不同的內容。提供圖表影像，使投影片顯示圖表而不是預設的「EMBEDDED OLE OBJECT」佔位符。請參閱 [Object Preview Issue when Adding OleObjectFrame](/slides/zh-hant/python-net/object-preview-issue-when-adding-oleobjectframe/)。

**當我在程式碼中變更活頁簿時，預覽會自動更新嗎？**

將預覽視為快照。若以程式方式更新活頁簿資料，需重新產生圖表影像，並更換預覽與嵌入的活頁簿資料。

**我可以使用 XLS 而非 XLSX 嗎？**

可以。將活頁簿儲存為 XLS 格式，並使用 `xls` 作為嵌入資料的副檔名。副檔名必須與實際的活頁簿格式相符，僅更改副檔名並不會轉換資料。

**為何物件在啟用後可能會改變大小？**

當主機應用程式啟動活頁簿時，可能會更新 OLE 物件的呈現方式。活頁簿的 OLE 顯示範圍與投影片框架的尺寸皆會影響結果。請參閱 [Resize OLE Objects Automatically in PowerPoint Presentations](/slides/zh-hant/python-net/working-solution-for-worksheet-resizing/)。

## **相關章節**

- [自動調整 PowerPoint 簡報中 OLE 物件大小](/slides/zh-hant/python-net/working-solution-for-worksheet-resizing/)
- [加入 OleObjectFrame 時的物件預覽問題](/slides/zh-hant/python-net/object-preview-issue-when-adding-oleobjectframe/)
- [管理 OLE 物件](/slides/zh-hant/python-net/manage-ole/)