---
title: Tích hợp dữ liệu Excel vào bản trình chiếu PowerPoint
linktitle: Tích hợp Excel
type: docs
weight: 330
url: /vi/python-java/excel-integration/
keywords:
- Excel
- sổ làm việc
- đọc Excel
- tích hợp Excel
- nguồn dữ liệu
- trộn thư
- nhập bảng
- Excel vào PowerPoint
- PowerPoint
- bản trình chiếu
- Python
- Java
- Aspose.Slides
description: "Đọc dữ liệu từ các sổ làm việc Excel trong Aspose.Slides cho Python qua Java bằng cách sử dụng API ExcelDataWorkbook. Tải các sheet và ô, và sử dụng các giá trị để tạo các bản trình chiếu PowerPoint dựa trên dữ liệu."
---
## **Giới thiệu**

Bản trình chiếu PowerPoint là một cách mạnh mẽ để hiển thị và truyền đạt thông tin. Chúng thường được sử dụng kết hợp với sổ làm việc Excel, trong đó Excel là nguồn dữ liệu có cấu trúc tuyệt vời và PowerPoint xuất sắc trong việc trực quan hoá dữ liệu đó cho khán giả.

Có rất nhiều kịch bản thực tế mà việc kết hợp Excel và PowerPoint là thiết yếu: trộn thư, điền dữ liệu vào bảng, tạo một slide cho mỗi bản ghi dữ liệu (tạo slide hàng loạt), tạo tài liệu đào tạo, và hợp nhất nhiều báo cáo Excel thành một bản trình chiếu duy nhất, chỉ kể một vài ví dụ.

Cho đến nay, việc triển khai các tính năng này với Aspose.Slides API đòi hỏi phải dựa vào các giải pháp bên thứ ba như Aspose.Cells. Mặc dù các công cụ này mạnh mẽ, chúng có thể quá phức tạp và tốn kém đối với người dùng chỉ cần chức năng tích hợp dữ liệu cơ bản.

## **Cách Hoạt Động**

Để việc làm việc với dữ liệu Excel trở nên dễ dàng và gọn gàng hơn, Aspose.Slides đã giới thiệu các lớp mới để đọc dữ liệu từ sổ làm việc Excel và nhập nội dung vào bản trình chiếu. Tính năng này mở ra những khả năng mạnh mẽ cho người dùng API muốn sử dụng Excel làm nguồn dữ liệu trong quy trình làm việc với bản trình chiếu.

Chức năng mới được thiết kế cho việc truy cập dữ liệu đa mục đích và không được tích hợp vào Mô hình Đối tượng Tài liệu Trình chiếu (DOM). Điều đó có nghĩa là *nó không cho phép chỉnh sửa hoặc lưu các tệp Excel* — mục đích duy nhất của nó là mở sổ làm việc và duyệt nội dung của chúng để truy xuất dữ liệu ô.

Ở trung tâm của tính năng này là lớp mới [ExcelDataWorkbook](https://reference.aspose.com/slides/vi/python-java/aspose.slides/exceldataworkbook/). Lớp này cho phép bạn tải một sổ làm việc Excel từ tệp cục bộ hoặc luồng. Khi đã tải, nó cung cấp một số phiên bản overload của phương thức [ExcelDataWorkbook.getCell](https://reference.aspose.com/slides/vi/python-java/aspose.slides/exceldataworkbook/#getCell), mà bạn có thể dùng để truy xuất các ô cụ thể theo vị trí của chúng (ví dụ: chỉ số hàng và cột hoặc phạm vi có tên).

Mỗi lần gọi [ExcelDataWorkbook.getCell](https://reference.aspose.com/slides/vi/python-java/aspose.slides/exceldataworkbook/#getCell) sẽ trả về một đối tượng [ExcelDataCell](https://reference.aspose.com/slides/vi/python-java/aspose.slides/exceldatacell/). Đối tượng này đại diện cho một ô duy nhất trong sổ làm việc Excel và cung cấp cho bạn quyền truy cập vào giá trị của nó một cách đơn giản và trực quan.

#### **Nhập Biểu Đồ Excel**

Bước tiếp theo để mở rộng chức năng là lớp [ExcelWorkbookImporter](https://reference.aspose.com/slides/vi/python-java/aspose.slides/excelworkbookimporter/). Lớp tiện ích này cung cấp chức năng nhập nội dung từ sổ làm việc Excel vào bản trình chiếu. Nó chứa một số overload của phương thức [ExcelWorkbookImporter.addChartFromWorkbook](https://reference.aspose.com/slides/vi/python-java/aspose.slides/excelworkbookimporter/#addChartFromWorkbook), giúp bạn truy xuất biểu đồ đã chọn từ sổ làm việc Excel đã chỉ định và thêm nó vào cuối bộ sưu tập hình dạng đã cho tại tọa độ chỉ định.

#### **Nhập Bảng Excel**

Lớp [ExcelWorkbookImporter](https://reference.aspose.com/slides/vi/python-java/aspose.slides/excelworkbookimporter/) cũng chứa một số overload của phương thức [ExcelWorkbookImporter.addTableFromWorkbook](https://reference.aspose.com/slides/vi/python-java/aspose.slides/excelworkbookimporter/#addTableFromWorkbook). Các phương thức này cho phép bạn nhập một phạm vi ô được chỉ định từ một worksheet cụ thể và thêm nó như một bảng vào cuối bộ sưu tập hình dạng đã cho tại tọa độ chỉ định.

Tóm lại, đây là một API nhẹ và đơn giản để đọc dữ liệu Excel — chính xác những gì nhiều nhà phát triển cần mà không phải chịu gánh nặng của một thư viện xử lý bảng tính đầy đủ.

## **Hãy Code**

### **Ví Dụ Kịch Bản Trộn Thư**

Trong ví dụ sau, chúng ta sẽ triển khai một kịch bản trộn thư đơn giản bằng cách tạo nhiều bản trình chiếu dựa trên dữ liệu được lưu trữ trong một sổ làm việc Excel.

Để bắt đầu, chúng ta cần hai thứ:

1. Một sổ làm việc Excel chứa dữ liệu

![Excel data example](example1_image0.png)

2. Một mẫu bản trình chiếu PowerPoint

![PowerPoint template example](example1_image1.png)

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ExcelDataWorkbook, Presentation, SaveFormat

# Tải sổ làm việc Excel với dữ liệu nhân viên.
workbook = ExcelDataWorkbook("TemplateData.xlsx")
worksheet_index = 0

# Tải mẫu bản trình chiếu.
template_presentation = Presentation("PresentationTemplate.pptx")

try:
    # Lặp qua các hàng Excel (loại trừ tiêu đề ở hàng 0).
    for row_index in range(1, 5):

        # Tạo một bản trình chiếu cho mỗi bản ghi nhân viên.
        employee_presentation = Presentation()

        try:
            # Xóa slide trống mặc định.
            employee_presentation.getSlides().removeAt(0)

            # Sao chép slide mẫu vào bản trình chiếu.
            slide = employee_presentation.getSlides().addClone(template_presentation.getSlides().get_Item(0))

            # Lấy các đoạn văn từ hình dạng mục tiêu (giả sử chỉ mục hình dạng 1 được dùng).
            paragraphs = slide.getShapes().get_Item(1).getTextFrame().getParagraphs()

            # Thay thế các placeholder bằng dữ liệu từ Excel.
            employee_name = str(workbook.getCell(worksheet_index, row_index, 0).getValue())
            name_portion = paragraphs.get_Item(0).getPortions().get_Item(0)
            name_portion.setText(str(name_portion.getText()).replace("{{EmployeeName}}", employee_name))

            department = str(workbook.getCell(worksheet_index, row_index, 1).getValue())
            department_portion = paragraphs.get_Item(1).getPortions().get_Item(0)
            department_portion.setText(str(department_portion.getText()).replace("{{Department}}", department))

            years_of_service = str(workbook.getCell(worksheet_index, row_index, 2).getValue())
            years_portion = paragraphs.get_Item(2).getPortions().get_Item(0)
            years_portion.setText(str(years_portion.getText()).replace("{{YearsOfService}}", years_of_service))

            # Lưu bản trình chiếu cá nhân hoá vào một tệp riêng.
            employee_presentation.save(f"{employee_name} Report.pptx", SaveFormat.Pptx)
        finally:
            employee_presentation.dispose()
finally:
    template_presentation.dispose()
```

![Result](example1_image2.png)

### **Ví Dụ Bảng Excel**

Trong ví dụ thứ hai, chúng ta chỉ sao chép dữ liệu từ một bảng Excel và hiển thị nó trên một slide PowerPoint với định dạng hấp dẫn hơn về mặt hình ảnh.

Trong ví dụ này, chúng ta tái sử dụng cùng một sổ làm việc Excel từ ví dụ đầu tiên, chứa một bảng nhân viên đơn giản.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ExcelDataWorkbook, Presentation, SaveFormat

# Tải sổ làm việc Excel chứa dữ liệu nhân viên.
workbook = ExcelDataWorkbook("TemplateData.xlsx")
worksheet_index = 0

# Tạo một bản trình chiếu PowerPoint.
presentation = Presentation()

try:
    # Thêm một hình dạng bảng vào slide đầu tiên.
    column_widths = jpype.JArray(jpype.JDouble)([200, 200, 200])
    row_heights = jpype.JArray(jpype.JDouble)([30, 30, 30, 30, 30])
    table = presentation.getSlides().get_Item(0).getShapes().addTable(50, 200, column_widths, row_heights)

    # Điền bảng PowerPoint bằng dữ liệu từ sổ làm việc Excel.
    for row_index in range(5):
        for column_index in range(3):
            cell_value = str(workbook.getCell(worksheet_index, row_index, column_index).getValue())
            table.getColumns().get_Item(column_index).get_Item(row_index).getTextFrame().setText(cell_value)

    # Lưu bản trình chiếu kết quả vào tệp.
    presentation.save("Table.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![Result](example2_image0.png)

### **Ví Dụ Nhập Biểu Đồ Excel**

Trong ví dụ này, chúng ta nhập một biểu đồ từ worksheet đầu tiên của sổ làm việc Excel đã dùng trong ví dụ trước. Biểu đồ sẽ liên kết tới sổ làm việc bên ngoài trong bản trình chiếu kết quả.

Đầu tiên, chúng ta thêm một biểu đồ tròn vào sổ làm việc Excel dựa trên bảng nhân viên.

![Excel Chart example](example3_image0.png)

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ExcelWorkbookImporter, Presentation, SaveFormat

# Tạo một bản trình chiếu PowerPoint.
presentation = Presentation()
try:
    # Lấy bộ sưu tập hình dạng của slide đầu tiên.
    shapes = presentation.getSlides().get_Item(0).getShapes()

    # Nhập biểu đồ có tên "Chart 1" từ sheet đầu tiên của sổ làm việc và thêm nó vào bộ sưu tập hình dạng.
    ExcelWorkbookImporter.addChartFromWorkbook(shapes, 10, 10, "TemplateData.xlsx", "Sheet1", "Chart 1", False)

    # Lưu bản trình chiếu kết quả vào tệp.
    presentation.save("Chart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![Result](example3_image1.png)

### **Ví Dụ Nhập Tất Cả Biểu Đồ Excel**

Hãy tưởng tượng bạn có một sổ làm việc Excel đầy các biểu đồ và bạn cần nhập tất cả chúng vào một bản trình chiếu. Mỗi biểu đồ nên được đặt trên một slide mới.

Mã dưới đây lặp qua tất cả các worksheet trong tệp Excel nguồn, trích xuất các biểu đồ từ mỗi worksheet và thêm mỗi biểu đồ vào một slide riêng bằng cách sử dụng bố cục slide trống. Trong bản trình chiếu kết quả, chỉ dữ liệu biểu đồ sẽ được nhúng, không phải toàn bộ sổ làm việc.

```python
import jpype
import asposeslides

if not jpile.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ExcelDataWorkbook, ExcelWorkbookImporter, Presentation, SaveFormat, SlideLayoutType

    # Tải sổ làm việc Excel chứa dữ liệu nhân viên.
workbook = ExcelDataWorkbook("ExcelWithCharts.xlsx")

    # Tạo một bản trình chiếu PowerPoint.
presentation = Presentation()
try:
        # Lấy bố cục slide trống.
    blank_layout = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank)

        # Xóa slide mặc định để kết quả chứa một slide cho mỗi biểu đồ.
    presentation.getSlides().removeAt(0)

        # Lấy tên của tất cả các worksheet có trong sổ làm việc Excel.
    worksheet_names = workbook.getWorksheetNames()

    for name in worksheet_names:
            # Lấy một bản đồ ánh xạ chỉ mục biểu đồ tới tên biểu đồ cho worksheet.
        worksheet_charts = workbook.getChartsFromWorksheet(name)

        for chart in worksheet_charts:
                # Thêm một slide sử dụng bố cục trống.
            slide = presentation.getSlides().addEmptySlide(blank_layout)

                # Nhập biểu đồ đã chỉ định từ sổ làm việc Excel vào bộ sưu tập hình dạng của slide.
            ExcelWorkbookImporter.addChartFromWorkbook(slide.getShapes(), 10, 10, workbook, name, chart.getKey(), False)

        # Lưu bản trình chiếu kết quả vào tệp.
    presentation.save("Charts.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Ví Dụ Nhập Bảng Excel**

Trong ví dụ này, chúng ta nhập một bảng đã định dạng từ worksheet Excel trực tiếp vào bản trình chiếu PowerPoint.

Worksheet Excel nguồn chứa một bảng đã định dạng với dữ liệu nhân viên:

![Excel Table example](example4_image0.png)

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ExcelWorkbookImporter, Presentation, SaveFormat

# Tạo một bản trình chiếu PowerPoint.
presentation = Presentation()
try:
    # Lấy slide đầu tiên và bộ sưu tập hình dạng của nó.
    slide = presentation.getSlides().get_Item(0)
    shapes = slide.getShapes()

    # Nhập bảng từ sheet đầu tiên của sổ làm việc và thêm nó vào bộ sưu tập hình dạng.
    ExcelWorkbookImporter.addTableFromWorkbook(shapes, 10, 10, "TemplateData.xlsx", "Sheet1", "A1:C5")

    # Lưu bản trình chiếu kết quả vào tệp.
    presentation.save("FormattedTable.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![Result](example4_image1.png)

## **Tóm Tắt**

Cơ chế này, có sẵn trực tiếp trong Aspose.Slides, kết hợp việc làm việc với dữ liệu Excel và bản trình chiếu tại một nơi. Nó cho phép bạn tạo các slide với biểu đồ trực quan và dữ liệu được trình bày dưới dạng bảng Excel — mà không cần bất kỳ thư viện bổ sung nào hay các tích hợp phức tạp.