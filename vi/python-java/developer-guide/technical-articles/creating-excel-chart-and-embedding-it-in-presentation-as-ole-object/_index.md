---
title: Tạo biểu đồ Excel và nhúng chúng vào bản trình chiếu dưới dạng đối tượng OLE
type: docs
weight: 30
url: /vi/python-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/
keywords:
- Biểu đồ Excel
- Nhúng biểu đồ
- Đối tượng OLE
- PowerPoint
- OpenDocument
- Bản trình chiếu
- Python
- Java
- Aspose.Slides
description: "Tạo biểu đồ Excel và nhúng chúng dưới dạng đối tượng OLE trong các bản trình chiếu PowerPoint và OpenDocument bằng Python. Hướng dẫn chi tiết kèm mẫu mã."
---
## **Bối cảnh**

Trong PowerPoint, việc sử dụng biểu đồ có thể chỉnh sửa để hiển thị dữ liệu dưới dạng đồ họa là một thực tiễn phổ biến. Aspose hỗ trợ tạo biểu đồ Excel bằng Aspose.Cells for Python via Java, và các biểu đồ này có thể được nhúng dưới dạng đối tượng OLE trong các slide PowerPoint thông qua Aspose.Slides for Python via Java. Bài viết này trình bày các bước cần thiết và cung cấp một mẫu mã Python để tạo biểu đồ Excel và nhúng nó dưới dạng đối tượng OLE trong bản trình chiếu PowerPoint bằng Aspose.Cells và Aspose.Slides.

## **Các bước cần thiết**

Các bước theo thứ tự sau là cần thiết để tạo và nhúng một biểu đồ Excel dưới dạng đối tượng OLE trong slide PowerPoint:

1. Tạo biểu đồ Excel bằng Aspose.Cells.  
2. Đặt kích thước OLE của biểu đồ Excel bằng Aspose.Cells.  
3. Lấy hình ảnh của biểu đồ Excel bằng Aspose.Cells.  
4. Nhúng biểu đồ Excel dưới dạng đối tượng OLE trong bản trình chiếu PPTX bằng Aspose.Slides.  
5. Thay thế hình ảnh "EMBEDDED OLE OBJECT" bằng hình ảnh lấy được ở bước 3 để giải quyết vấn đề [object preview issue](/slides/vi/python-java/object-preview-issue-when-adding-oleobjectframe/).  
6. Lưu bản trình chiếu vào đĩa ở định dạng PPTX.

## **Triển khai các bước cần thiết**

Việc triển khai bằng Python cho các bước trên như sau:

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
    # Mảng các tên ô.
    cell_names = [
        "A1", "A2", "A3", "A4",
        "B1", "B2", "B3", "B4",
        "C1", "C2", "C3", "C4",
        "D1", "D2", "D3", "D4",
        "E1", "E2", "E3", "E4",
    ]

    # Mảng dữ liệu ô.
    cell_values = [
        67, 86, 68, 91,
        44, 64, 89, 48,
        46, 97, 78, 60,
        43, 29, 69, 26,
        24, 40, 38, 25,
    ]

    # Thêm một worksheet mới để điền dữ liệu vào các ô.
    data_sheet_index = workbook.getWorksheets().add()
    data_sheet = workbook.getWorksheets().get(data_sheet_index)
    sheet_name = "DataSheet"
    data_sheet.setName(sheet_name)

    # Đổ dữ liệu vào sheet dữ liệu.
    for cell_name, cell_value in zip(cell_names, cell_values):
        data_sheet.getCells().get(cell_name).setValue(jpype.JInt(cell_value))

    # Thêm một sheet biểu đồ.
    worksheet_index = workbook.getWorksheets().add(SheetType.CHART)
    chart_sheet = workbook.getWorksheets().get(worksheet_index)
    chart_sheet.setName("ChartSheet")
    chart_sheet_index = chart_sheet.getIndex()

    # Thêm biểu đồ vào sheet biểu đồ với chuỗi dữ liệu từ sheet dữ liệu.
    chart_index = chart_sheet.getCharts().add(ChartType.COLUMN, 0, chart_rows, 0, chart_columns)
    chart = chart_sheet.getCharts().get(chart_index)
    chart.getNSeries().add(sheet_name + "!A1:E1", False)
    chart.getNSeries().add(sheet_name + "!A2:E2", False)
    chart.getNSeries().add(sheet_name + "!A3:E3", False)
    chart.getNSeries().add(sheet_name + "!A4:E4", False)

    # Đặt sheet biểu đồ làm sheet hoạt động.
    workbook.getWorksheets().setActiveSheetIndex(chart_sheet_index)
    return chart_sheet_index


def add_excel_chart_in_presentation(presentation, slide, workbook_data, chart_image):
    ole_height = jpype.JFloat(presentation.getSlideSize().getSize().getHeight())
    ole_width = jpype.JFloat(presentation.getSlideSize().getSize().getWidth())

    # Mô tả workbook dưới dạng dữ liệu OLE được nhúng.
    data_info = OleEmbeddedDataInfo(workbook_data, "xls")
    ole_frame = slide.getShapes().addOleObjectFrame(0.0, 0.0, ole_width, ole_height, data_info)
    image = presentation.getImages().addImage(chart_image)
    ole_frame.getSubstitutePictureFormat().getPicture().setImage(image)


# Tạo một workbook.
workbook = Workbook()

# Thêm biểu đồ Excel.
chart_rows = 55
chart_columns = 25
chart_sheet_index = add_excel_chart_in_workbook(workbook, chart_rows, chart_columns)

# Đặt kích thước OLE cho biểu đồ.
workbook.getWorksheets().setOleSize(0, chart_rows, 0, chart_columns)

# Lấy hình ảnh biểu đồ và lưu nó vào stream.
print_options = ImageOrPrintOptions()
print_options.setImageType(ImageType.PNG)
image_stream = ByteArrayOutputStream()
workbook.getWorksheets().get(chart_sheet_index).getCharts().get(0).toImage(image_stream, print_options)
chart_image = image_stream.toByteArray()

# Lưu workbook vào stream.
workbook_stream = ByteArrayOutputStream()
workbook.save(workbook_stream, CellsSaveFormat.EXCEL_97_TO_2003)
workbook_data = workbook_stream.toByteArray()

# Tạo một bản trình chiếu.
presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # Thêm workbook vào slide.
    add_excel_chart_in_presentation(presentation, slide, workbook_data, chart_image)

    # Lưu bản trình chiếu vào đĩa.
    presentation.save("OutputChart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Bản trình chiếu được tạo bằng phương pháp trên sẽ chứa biểu đồ Excel dưới dạng đối tượng OLE, có thể kích hoạt bằng cách nhấp đúp vào khung đối tượng OLE.

## **Kết luận**

Bằng cách sử dụng Aspose.Cells for Python via Java cùng với Aspose.Slides for Python via Java, chúng ta có thể tạo bất kỳ biểu đồ Excel nào mà Aspose.Cells hỗ trợ và nhúng biểu đồ đó dưới dạng đối tượng OLE trong slide PowerPoint. Kích thước OLE của biểu đồ Excel cũng có thể được xác định. Người dùng cuối sau đó có thể chỉnh sửa biểu đồ Excel như bất kỳ đối tượng OLE nào khác.

## **Các phần liên quan**

- [Giải pháp hoạt động cho việc thay đổi kích thước biểu đồ trong PPTX](/slides/vi/python-java/working-solution-for-chart-resizing-in-pptx/)
- [Vấn đề xem trước đối tượng khi thêm OleObjectFrame](/slides/vi/python-java/object-preview-issue-when-adding-oleobjectframe/)

## **Câu hỏi thường gặp**

**Các thư viện nào được sử dụng để tạo và nhúng biểu đồ Excel?**

Aspose.Cells for Python via Java tạo biểu đồ Excel, và Aspose.Slides for Python via Java nhúng nó dưới dạng đối tượng OLE trong slide PowerPoint.

**Người dùng có thể chỉnh sửa biểu đồ Excel đã nhúng như thế nào?**

Người dùng có thể nhấp đúp vào khung đối tượng OLE để kích hoạt biểu đồ và chỉnh sửa nó như bất kỳ đối tượng OLE nào khác.

**Làm thế nào để thay thế hình ảnh xem trước mặc định của đối tượng OLE?**

Ví dụ lấy hình ảnh của biểu đồ Excel bằng Aspose.Cells và dùng nó để thay thế hình ảnh "EMBEDDED OLE OBJECT".