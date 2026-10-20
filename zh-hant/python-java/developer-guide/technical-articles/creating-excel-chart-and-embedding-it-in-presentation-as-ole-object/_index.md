---
title: 建立 Excel 圖表並將其嵌入簡報作為 OLE 物件
type: docs
weight: 30
url: /zh-hant/python-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/
keywords:
- Excel 圖表
- 嵌入圖表
- OLE 物件
- PowerPoint
- 簡報
- Python
- Java
- Aspose.Slides
description: "使用 Aspose.Cells for Python via Java 建立 Excel 圖表，並將工作簿嵌入使用 Aspose.Slides 的 PowerPoint 簡報中，包含圖表預覽。"
---
## **概覽**

本文說明如何使用 Aspose.Cells for Python via Java 建立 Excel 柱狀圖，並將其工作簿嵌入使用 Aspose.Slides for Python via Java 的 PowerPoint 簡報中。嵌入的工作簿同時包含來源資料與圖表。另一個 PNG 預覽會在 OLE 物件被啟動前於投影片上顯示圖表。

結果是一個嵌入的 Excel 物件，而非原生的 PowerPoint 圖表。透過 OLE 編輯工作簿需要支援 OLE 啟動的桌面應用程式，以及相容的 Excel 安裝。

## **先決條件**

安裝 `aspose-cells` 與 `aspose-slides-java` Python 套件以及相容的 Java 執行環境。於啟動 JVM 之前匯入這兩個套件，以確保其 Java 函式庫可供 JPype 使用。產生簡報時不需要 Microsoft Office。

不需要任何輸入檔案：範例在記憶體中建立資料與圖表，然後將 `OutputChart.pptx` 寫入目前工作目錄。於非評估模式下執行時，請為兩個產品套用授權。

## **嵌入工作原理**

1. 建立包含資料工作表與圖表工作表的工作簿。
1. 將圖表工作表設為使用中，使工作簿開啟時直接顯示圖表。
1. 設定工作簿的 OLE 顯示範圍，並將圖表渲染為 PNG。
1. 將工作簿以 XLSX 格式儲存於記憶體，並將其位元組嵌入投影片中。
1. 將 PNG 指定為 OLE 物件的預覽，並將簡報儲存為 PPTX。

工作簿的顯示範圍與投影片上的框架扮演不同的角色。[setOleSize](https://reference.aspose.com/cells/python-java/asposecells.api/worksheetcollection/#setolesize) 采用零基的起始／結束列與行索引。[ChartCollection.add](https://reference.aspose.com/cells/python-java/asposecells.api/chartcollection/#add) 則使用顶部行、左侧列、底部行和右侧列。範例將第 55 行和第 25 列作為右下邊界；這些值僅為版面配置選擇，並非資料列或欄的數量。

投影片框架使用點 (points)。範例將其調整至投影片內部並置中，同時保持 PNG 的長寬比，而不是將預覽圖拉伸至填滿投影片。

## **建立並嵌入圖表**

以下完整範例會在 `DataSheet` 中填入四列五欄的數值。每一列會成為圖表的一個系列。儲存工作簿前，會將 `ChartSheet` 設為使用中的工作表。

工作簿會明確以 XLSX 格式儲存，並匹配傳遞給 [OleEmbeddedDataInfo](https://reference.aspose.com/slides/python-java/aspose.slides/oleembeddeddatainfo/) 的 `xlsx` 副檔名。Java 位元組陣列串流將工作簿與影像保留在記憶體中，並提供 Java API 所需的位元組陣列。PNG 直接從位元組載入，無需中間的 bitmap 轉換。透過 [getSubstitutePictureFormat](https://reference.aspose.com/slides/python-java/aspose.slides/oleobjectframe/#getSubstitutePictureFormat) 指派可取代預設的 OLE 佔位圖。

```python
import jpype
import asposecells
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposecells.api import Workbook, ChartType, SheetType, ImageOrPrintOptions, ImageType
from asposecells.api import SaveFormat as CellsSaveFormat
from asposeslides.api import Images, OleEmbeddedDataInfo, Presentation, SaveFormat

ByteArrayOutputStream = jpype.JClass("java.io.ByteArrayOutputStream")

workbook = Workbook()
try:
    data_sheet = workbook.getWorksheets().get(0)
    data_sheet.setName("DataSheet")

    values = [
        [67, 44, 46, 43, 24],
        [86, 64, 97, 29, 40],
        [68, 89, 78, 69, 38],
        [91, 48, 60, 26, 25],
    ]
    for row, row_values in enumerate(values):
        for column, value in enumerate(row_values):
            data_sheet.getCells().get(row, column).putValue(jpype.JInt(value))

    chart_sheet_index = workbook.getWorksheets().add(SheetType.CHART)
    chart_sheet = workbook.getWorksheets().get(chart_sheet_index)
    chart_sheet.setName("ChartSheet")

    last_chart_row = 55
    last_chart_column = 25
    chart_index = chart_sheet.getCharts().add(ChartType.COLUMN, 0, 0, last_chart_row, last_chart_column)
    chart = chart_sheet.getCharts().get(chart_index)
    for row in range(1, len(values) + 1):
        chart.getNSeries().add(f"DataSheet!A{row}:E{row}", False)

    workbook.getWorksheets().setActiveSheetIndex(chart_sheet_index)
    workbook.getWorksheets().setOleSize(0, last_chart_row, 0, last_chart_column)

    # 渲染圖表預覽並將可編輯的工作簿另行序列化。
    image_options = ImageOrPrintOptions()
    image_options.setImageType(ImageType.PNG)
    chart_image_stream = ByteArrayOutputStream()
    chart.toImage(chart_image_stream, image_options)
    chart_image_bytes = chart_image_stream.toByteArray()

    workbook_stream = ByteArrayOutputStream()
    workbook.save(workbook_stream, CellsSaveFormat.XLSX)
    workbook_bytes = workbook_stream.toByteArray()

    chart_image = Images.fromData(chart_image_bytes)
    try:
        presentation = Presentation()
        try:
            slide = presentation.getSlides().get_Item(0)
            slide_width = presentation.getSlideSize().getSize().getWidth()
            slide_height = presentation.getSlideSize().getSize().getHeight()

            # 在投影片內調整預覽大小，保持長寬比不變。
            scale = min(slide_width / chart_image.getWidth(), slide_height / chart_image.getHeight())
            frame_width = chart_image.getWidth() * scale
            frame_height = chart_image.getHeight() * scale
            frame_x = (slide_width - frame_width) / 2
            frame_y = (slide_height - frame_height) / 2

            embedded_data = OleEmbeddedDataInfo(workbook_bytes, "xlsx")
            ole_frame = slide.getShapes().addOleObjectFrame(frame_x, frame_y, frame_width, frame_height, embedded_data)
            preview_image = presentation.getImages().addImage(chart_image)
            ole_frame.getSubstitutePictureFormat().getPicture().setImage(preview_image)

            presentation.save("OutputChart.pptx", SaveFormat.Pptx)
        finally:
            presentation.dispose()
    finally:
        chart_image.dispose()
finally:
    workbook.dispose()
```

## **預期結果**

`OutputChart.pptx` 包含一張含有嵌入 Excel 工作簿與圖表預覽的投影片。工作簿內有原始資料以及包含四個系列的柱狀圖。預覽圖置於投影片中心，並保留其比例。

![以嵌入工作簿預覽方式顯示的 Excel 柱狀圖](excel-chart-ole-preview.png)

在具備 Excel 的相容桌面 PowerPoint 環境中，雙擊該物件即可啟動並編輯嵌入的工作簿。啟動與編輯取決於主機應用程式的 OLE 支援與安全性設定。

## **常見問題**

**為什麼需要預覽圖？**

嵌入的工作簿與投影片預覽屬於不同的內容。提供圖表影像可讓投影片顯示圖表，而非預設的「EMBEDDED OLE OBJECT」佔位圖。請參閱 [加入 OleObjectFrame 時的物件預覽問題](/slides/zh-hant/python-java/object-preview-issue-when-adding-oleobjectframe/)。

**當我在程式碼中變更工作簿時，預覽會自動更新嗎？**

將預覽視為快照。當以程式方式更新工作簿資料時，需要重新產生圖表影像，並同時替換預覽與嵌入的工作簿資料。

**我可以使用 XLS 而非 XLSX 嗎？**

可以。將工作簿儲存為 XLS 格式，並使用 `xls` 作為嵌入資料的副檔名。副檔名必須與實際的工作簿格式相符；僅更改副檔名不會轉換資料。

**為什麼物件在啟動後會改變大小？**

主機應用程式在啟動工作簿時可能會更新 OLE 物件的呈現方式。工作簿的 OLE 顯示範圍與投影片框架的尺寸皆會影響結果。請參閱 [PPTX 中圖表調整大小的可行解決方案](/slides/zh-hant/python-java/working-solution-for-chart-resizing-in-pptx/)。

## **相關章節**

- [PPTX 中圖表調整大小的可行解決方案](/slides/zh-hant/python-java/working-solution-for-chart-resizing-in-pptx/)
- [加入 OleObjectFrame 時的物件預覽問題](/slides/zh-hant/python-java/object-preview-issue-when-adding-oleobjectframe/)