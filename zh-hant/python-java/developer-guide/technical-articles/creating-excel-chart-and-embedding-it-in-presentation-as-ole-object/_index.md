---
title: 建立 Excel 圖表並將其嵌入簡報為 OLE 物件
type: docs
weight: 30
url: /zh-hant/python-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/
keywords:
- Excel 圖表
- 嵌入圖表
- OLE 物件
- PowerPoint
- OpenDocument
- 簡報
- Python
- Java
- Aspose.Slides
description: "使用 Python 在 PowerPoint 與 OpenDocument 簡報中建立 Excel 圖表並將其嵌入為 OLE 物件。提供逐步說明和程式碼範例。"
---
## **背景**

在 PowerPoint 中，使用可編輯的圖表以圖形方式顯示資料是常見的做法。Aspose 支援使用 Aspose.Cells for Python via Java 建立 Excel 圖表，然後可透過 Aspose.Slides for Python via Java 將這些圖表嵌入為 PowerPoint 投影片中的 OLE 物件。本文說明必要的步驟，並提供一個 Python 程式碼範例，用於建立 Excel 圖表並將其作為 OLE 物件嵌入 PowerPoint 簡報，使用 Aspose.Cells 與 Aspose.Slides。

## **必要步驟**

1. 使用 Aspose.Cells 建立 Excel 圖表。
1. 使用 Aspose.Cells 設定 Excel 圖表的 OLE 大小。
1. 使用 Aspose.Cells 取得 Excel 圖表的圖像。
1. 使用 Aspose.Slides 將 Excel 圖表以 OLE 物件嵌入 PPTX 簡報中。
1. 以步驟 3 取得的圖像取代「EMBEDDED OLE OBJECT」圖像，以解決[object preview issue](/slides/zh-hant/python-java/object-preview-issue-when-adding-oleobjectframe/)。
1. 將簡報以 PPTX 格式儲存至磁碟。

## **必要步驟的實作**

上述步驟的 Python 實作如下：

```python
import jpype
import asposecells
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposecells.api import Workbook, ChartType, SheetType, ImageOrPrintOptions, ImageType
from asposecells.api import SaveFormat as CellsSaveFormat
from asposeslides.api import OleEmbeddedDataInfo, Presentation, SaveFormat

ByteArrayOutputStream = jpype.JClass("java.io.ByteArrayOutputStream")


def add_excel_chart_in_workbook(workbook, chart_rows, chart_columns):
    # 儲存格名稱陣列。
    cell_names = [
        "A1", "A2", "A3", "A4",
        "B1", "B2", "B3", "B4",
        "C1", "C2", "C3", "C4",
        "D1", "D2", "D3", "D4",
        "E1", "E2", "E3", "E4",
    ]

    # 儲存格資料陣列。
    cell_values = [
        67, 86, 68, 91,
        44, 64, 89, 48,
        46, 97, 78, 60,
        43, 29, 69, 26,
        24, 40, 38, 25,
    ]

    # 新增工作表以填入資料至儲存格。
    data_sheet_index = workbook.getWorksheets().add()
    data_sheet = workbook.getWorksheets().get(data_sheet_index)
    sheet_name = "DataSheet"
    data_sheet.setName(sheet_name)

    # 將資料填入資料工作表。
    for cell_name, cell_value in zip(cell_names, cell_values):
        data_sheet.getCells().get(cell_name).setValue(jpype.JInt(cell_value))

    # 新增圖表工作表。
    worksheet_index = workbook.getWorksheets().add(SheetType.CHART)
    chart_sheet = workbook.getWorksheets().get(worksheet_index)
    chart_sheet.setName("ChartSheet")
    chart_sheet_index = chart_sheet.getIndex()

    # 在圖表工作表加入圖表，資料系列來源於資料工作表。
    chart_index = chart_sheet.getCharts().add(ChartType.COLUMN, 0, chart_rows, 0, chart_columns)
    chart = chart_sheet.getCharts().get(chart_index)
    chart.getNSeries().add(sheet_name + "!A1:E1", False)
    chart.getNSeries().add(sheet_name + "!A2:E2", False)
    chart.getNSeries().add(sheet_name + "!A3:E3", False)
    chart.getNSeries().add(sheet_name + "!A4:E4", False)

    # 設定圖表工作表為使用中的工作表。
    workbook.getWorksheets().setActiveSheetIndex(chart_sheet_index)
    return chart_sheet_index


def add_excel_chart_in_presentation(presentation, slide, workbook_data, chart_image):
    ole_height = jpype.JFloat(presentation.getSlideSize().getSize().getHeight())
    ole_width = jpype.JFloat(presentation.getSlideSize().getSize().getWidth())

    # 將活頁簿描述為嵌入的 OLE 資料。
    data_info = OleEmbeddedDataInfo(workbook_data, "xls")
    ole_frame = slide.getShapes().addOleObjectFrame(0.0, 0.0, ole_width, ole_height, data_info)
    image = presentation.getImages().addImage(chart_image)
    ole_frame.getSubstitutePictureFormat().getPicture().setImage(image)


# 建立活頁簿。
workbook = Workbook()

# 新增 Excel 圖表。
chart_rows = 55
chart_columns = 25
chart_sheet_index = add_excel_chart_in_workbook(workbook, chart_rows, chart_columns)

# 設定圖表的 OLE 大小。
workbook.getWorksheets().setOleSize(0, chart_rows, 0, chart_columns)

# 取得圖表影像並儲存至串流。
print_options = ImageOrPrintOptions()
print_options.setImageType(ImageType.PNG)
image_stream = ByteArrayOutputStream()
workbook.getWorksheets().get(chart_sheet_index).getCharts().get(0).toImage(image_stream, print_options)
chart_image = image_stream.toByteArray()

# 將活頁簿儲存至串流。
workbook_stream = ByteArrayOutputStream()
workbook.save(workbook_stream, CellsSaveFormat.EXCEL_97_TO_2003)
workbook_data = workbook_stream.toByteArray()

# 建立簡報。
presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # 將活頁簿加入投影片。
    add_excel_chart_in_presentation(presentation, slide, workbook_data, chart_image)

    # 將簡報儲存至磁碟。
    presentation.save("OutputChart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

上述方法建立的簡報將包含作為 OLE 物件的 Excel 圖表，使用者可透過雙擊 OLE 物件框架來啟動並編輯圖表。

## **結論**

透過結合 Aspose.Cells for Python via Java 與 Aspose.Slides for Python via Java，我們可以建立 Aspose.Cells 支援的任何 Excel 圖表，並將該圖表嵌入為 PowerPoint 投影片中的 OLE 物件。也可以自行定義 Excel 圖表的 OLE 大小。最終使用者即可像編輯其他 OLE 物件一樣編輯此 Excel 圖表。

## **相關章節**

- [在 PPTX 中調整圖表大小的可行解決方案](/slides/zh-hant/python-java/working-solution-for-chart-resizing-in-pptx/)
- [加入 OleObjectFrame 時的物件預覽問題](/slides/zh-hant/python-java/object-preview-issue-when-adding-oleobjectframe/)

## **常見問題**

**使用哪些程式庫來建立與嵌入 Excel 圖表？**

Aspose.Cells for Python via Java 用於建立 Excel 圖表，Aspose.Slides for Python via Java 則將其作為 OLE 物件嵌入 PowerPoint 投影片中。

**使用者如何編輯嵌入的 Excel 圖表？**

使用者可雙擊 OLE 物件框架以啟動圖表，並像編輯其他 OLE 物件一樣進行編輯。

**預設的 OLE 物件預覽是如何被取代的？**

範例使用 Aspose.Cells 取得 Excel 圖表的圖像，並以此取代「EMBEDDED OLE OBJECT」圖像。