---
title: "Tích hợp dữ liệu Excel vào bản trình chiếu PowerPoint"
linktitle: "Tích hợp Excel"
type: docs
weight: 330
url: /vi/python-net/excel-integration/
keywords:
- Excel
- sổ làm việc
- đọc Excel
- tích hợp Excel
- nguồn dữ liệu
- gộp thư
- nhập bảng
- Excel vào PowerPoint
- PowerPoint
- bản trình chiếu
- Python
- Aspose.Slides
description: "Đọc dữ liệu từ sổ làm việc Excel trong Aspose.Slides bằng API ExcelDataWorkbook. Tải các sheet và ô và sử dụng giá trị để tạo các bản trình chiếu PowerPoint dựa trên dữ liệu."
---
## **Giới thiệu**

Bản trình chiếu PowerPoint là một cách mạnh mẽ để hiển thị và truyền đạt thông tin. Chúng thường được sử dụng cùng với sổ làm việc Excel, trong đó Excel là nguồn dữ liệu có cấu trúc xuất sắc và PowerPoint nổi trội trong việc trực quan hoá dữ liệu đó cho khán giả.

Có rất nhiều kịch bản thực tiễn mà việc kết hợp Excel và PowerPoint là cần thiết: mail merge, điền dữ liệu vào bảng, tạo một slide cho mỗi bản ghi dữ liệu (tạo slide hàng loạt), tạo tài liệu đào tạo, và hợp nhất nhiều báo cáo Excel thành một bản trình chiếu duy nhất, chỉ để nêu một vài ví dụ.

Cho đến nay, việc triển khai các tính năng này với API Aspose.Slides yêu cầu phải dựa vào các giải pháp của bên thứ ba như Aspose.Cells. Mặc dù các công cụ này mạnh mẽ, chúng có thể quá phức tạp và tốn kém đối với người dùng chỉ cần chức năng tích hợp dữ liệu cơ bản.

## **Cách hoạt động**

Để làm việc với dữ liệu Excel dễ dàng và gọn gàng hơn, Aspose.Slides đã giới thiệu các lớp mới để đọc dữ liệu từ sổ làm việc Excel và nhập nội dung vào bản trình chiếu. Tính năng này mở ra những khả năng mới mạnh mẽ cho người dùng API muốn tận dụng Excel làm nguồn dữ liệu trong quy trình làm việc với bản trình chiếu.

Chức năng mới được thiết kế cho việc truy cập dữ liệu mục đích chung và không được tích hợp vào mô hình đối tượng tài liệu (DOM) của Presentation. Điều đó có nghĩa là *không cho phép chỉnh sửa hoặc lưu file Excel* — mục đích duy nhất là mở sổ làm việc và duyệt qua nội dung để lấy dữ liệu ô.

Ở trung tâm của tính năng này là lớp mới [ExcelDataWorkbook](https://reference.aspose.com/slides/vi/python-net/aspose.slides.excel/exceldataworkbook/). Lớp này cho phép bạn tải một sổ làm việc Excel từ file cục bộ hoặc từ luồng. Sau khi tải, nó cung cấp một số overload của phương thức [get_cell](https://reference.aspose.com/slides/vi/python-net/aspose.slides.excel/exceldataworkbook/get_cell/), giúp bạn truy xuất các ô cụ thể theo vị trí (ví dụ: chỉ số hàng và cột hoặc các phạm vi đặt tên).

Mỗi lần gọi [get_cell](https://reference.aspose.com/slides/vi/python-net/aspose.slides.excel/exceldataworkbook/get_cell/) sẽ trả về một thể hiện của lớp [ExcelDataCell](https://reference.aspose.com/slides/vi/python-net/aspose.slides.excel/exceldatacell/). Đối tượng này đại diện cho một ô duy nhất trong sổ làm việc Excel và cung cấp cho bạn cách truy cập giá trị của ô một cách đơn giản và trực quan.

#### **Nhập biểu đồ Excel**

Bước tiếp theo để mở rộng tính năng là lớp [ExcelWorkbookImporter](https://reference.aspose.com/slides/vi/python-net/aspose.slides.importing/excelworkbookimporter/). Lớp tiện ích này cung cấp chức năng nhập nội dung từ một sổ làm việc Excel vào bản trình chiếu. Nó chứa một số overload của phương thức [add_chart_from_workbook](https://reference.aspose.com/slides/vi/python-net/aspose.slides.importing/excelworkbookimporter/add_chart_from_workbook/), giúp bạn lấy biểu đồ đã chọn từ sổ làm việc Excel được chỉ định và thêm nó vào cuối bộ sưu tập shape tại các tọa độ đã xác định.

Tóm lại, đây là một API nhẹ và dễ dùng để đọc dữ liệu Excel — chính xác những gì nhiều nhà phát triển cần mà không phải chịu gánh nặng của một thư viện xử lý bảng tính đầy đủ.

## **Hãy viết mã**

### **Ví dụ kịch bản Mail Merge**

Trong ví dụ dưới đây, chúng ta sẽ thực hiện một kịch bản Mail Merge đơn giản bằng cách tạo nhiều bản trình chiếu dựa trên dữ liệu được lưu trong một sổ làm việc Excel.

Để bắt đầu, chúng ta cần hai thứ:
1. Một sổ làm việc Excel chứa dữ liệu

![Ví dụ dữ liệu Excel](example1_image0.png)

2.  Mẫu bản trình chiếu PowerPoint

![Ví dụ mẫu PowerPoint](example1_image1.png)

```py
import aspose.slides as slides

# Tải sổ làm việc Excel chứa dữ liệu nhân viên.
workbook = slides.excel.ExcelDataWorkbook("TemplateData.xlsx")
worksheet_index = 0

# Tải mẫu bản trình chiếu.
with slides.Presentation("PresentationTemplate.pptx") as template_presentation:

    # Duyệt qua các hàng trong Excel (bỏ qua tiêu đề ở hàng 0).
    for row_index in range(1, 5):

        # Tạo một bản trình chiếu mới cho mỗi bản ghi nhân viên.
        with slides.Presentation() as employee_presentation:

            # Xóa slide trống mặc định.
            employee_presentation.slides.remove_at(0)

            # Sao chép slide mẫu vào bản trình chiếu mới.
            slide = employee_presentation.slides.add_clone(template_presentation.slides[0])

            # Lấy các đoạn văn từ shape mục tiêu (giả sử shape có chỉ số 1 được sử dụng).
            paragraphs = slide.shapes[1].text_frame.paragraphs

            # Thay thế các placeholder bằng dữ liệu từ Excel.
            employee_name = workbook.get_cell(worksheet_index, row_index, 0).value
            name_portion = paragraphs[0].portions[0]
            name_portion.text = name_portion.text.replace("{{EmployeeName}}", employee_name)

            department = workbook.get_cell(worksheet_index, row_index, 1).value
            department_portion = paragraphs[1].portions[0]
            department_portion.text = department_portion.text.replace("{{Department}}", department)

            years_of_service = str(workbook.get_cell(worksheet_index, row_index, 2).value)
            years_portion = paragraphs[2].portions[0]
            years_portion.text = years_portion.text.replace("{{YearsOfService}}", years_of_service)

            # Lưu bản trình chiếu cá nhân hoá vào một tệp riêng.
            employee_presentation.save(f"{employee_name} Report.pptx", slides.export.SaveFormat.PPTX)
```

![Kết quả](example1_image2.png)

### **Ví dụ bảng Excel**

Trong ví dụ thứ hai, chúng ta chỉ sao chép dữ liệu từ một bảng Excel và hiển thị nó trên một slide PowerPoint theo định dạng hấp dẫn hơn.

Trong ví dụ này, chúng ta tái sử dụng cùng một sổ làm việc Excel từ ví dụ đầu, chứa một bảng nhân viên đơn giản.

```py
# Tải sổ làm việc Excel chứa dữ liệu nhân viên.
workbook = slides.excel.ExcelDataWorkbook("TemplateData.xlsx")
worksheet_index = 0

# Tạo một bản trình chiếu PowerPoint mới.
with slides.Presentation() as presentation:

    # Thêm một shape bảng vào slide đầu tiên.
    table = presentation.slides[0].shapes.add_table(
        50, 200,
        [200, 200, 200],
        [30, 30, 30, 30, 30]
    )

    # Điền dữ liệu từ sổ làm việc Excel vào bảng PowerPoint.
    for row_index in range(0, 5):
        for column_index in range(0, 3):
            cell_value = str(workbook.get_cell(worksheet_index, row_index, column_index).value)
            table.columns[column_index][row_index].text_frame.text = cell_value

    # Lưu bản trình chiếu kết quả vào tệp.
    presentation.save("Table.pptx", slides.export.SaveFormat.PPTX)
```

![Kết quả](example2_image0.png)

### **Ví dụ nhập biểu đồ Excel**

Trong ví dụ này, chúng ta nhập một biểu đồ từ worksheet đầu tiên của sổ làm việc Excel đã dùng trong ví dụ trước. Biểu đồ sẽ được liên kết tới sổ làm việc bên ngoài trong bản trình chiếu kết quả.

Đầu tiên, chúng ta thêm một biểu đồ Pie vào sổ làm việc Excel dựa trên bảng nhân viên.

![Ví dụ biểu đồ Excel](example3_image0.png)

```py
# Tạo một bản trình chiếu PowerPoint mới.
with slides.Presentation() as presentation:
    # Lấy bộ sưu tập shape của slide đầu tiên.
    shapes = presentation.slides[0].shapes

    # Nhập biểu đồ có tên "Chart 1" từ sheet đầu tiên của sổ làm việc và thêm nó vào bộ sưu tập shape.
    slides.importing.ExcelWorkbookImporter.add_chart_from_workbook(
        shapes, 10, 10, "TemplateData.xlsx", "Sheet1", "Chart 1", False)

    # Lưu bản trình chiếu kết quả vào tệp.
    presentation.save("Chart.pptx", slides.export.SaveFormat.PPTX)
```

![Kết quả](example3_image1.png)

### **Ví dụ nhập tất cả biểu đồ Excel**

Hãy tưởng tượng bạn có một sổ làm việc Excel đầy các biểu đồ và cần nhập tất cả chúng vào một bản trình chiếu. Mỗi biểu đồ sẽ được đặt trên một slide mới.

Đoạn mã dưới đây duyệt qua tất cả các worksheet trong file Excel nguồn, trích xuất các biểu đồ từ mỗi worksheet và thêm mỗi biểu đồ vào một slide riêng bằng bố cục slide trống. Trong bản trình chiếu kết quả, chỉ dữ liệu biểu đồ sẽ được nhúng, không phải toàn bộ sổ làm việc.

```py
# Tải sổ làm việc Excel chứa dữ liệu nhân viên.
workbook = slides.excel.ExcelDataWorkbook("ExcelWithCharts.xlsx")

# Tạo một bản trình chiếu PowerPoint mới.
with slides.Presentation() as presentation:
    # Lấy bố cục slide trống.
    blank_layout = presentation.layout_slides.get_by_type(slides.SlideLayoutType.BLANK)

    # Lấy tên của tất cả các worksheet có trong sổ làm việc Excel.
    worksheet_names = workbook.get_worksheet_names()

    for name in worksheet_names:
        # Lấy một dictionary ánh xạ chỉ số biểu đồ tới tên biểu đồ cho worksheet.
        worksheet_charts = workbook.get_charts_from_worksheet(name)
        
        for chart in worksheet_charts:
            # Thêm một slide mới sử dụng bố cục trống.
            slide = presentation.slides.add_empty_slide(blank_layout)

            # Nhập biểu đồ đã chỉ định từ sổ làm việc Excel vào bộ sưu tập shape của slide.
            slides.importing.ExcelWorkbookImporter.add_chart_from_workbook(
                slide.shapes, 10, 10, workbook, name, chart.key, False)

    # Lưu bản trình chiếu kết quả vào tệp.
    presentation.save("Charts.pptx", slides.export.SaveFormat.PPTX)
```

## **Tóm tắt**

Cơ chế này, có sẵn trực tiếp trong Aspose.Slides, kết hợp việc làm việc với dữ liệu Excel và bản trình chiếu trong một nơi. Nó cho phép bạn tạo slide với biểu đồ trực quan và dữ liệu được trình bày dưới dạng bảng Excel — mà không cần bất kỳ thư viện bổ sung nào hay tích hợp phức tạp.