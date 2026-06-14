---
title: Tích hợp dữ liệu Excel vào bản trình chiếu PowerPoint
linktitle: Tích hợp Excel
type: docs
weight: 330
url: /vi/java/excel-integration/
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
- Java
- Aspose.Slides
description: "Đọc dữ liệu từ các sổ làm việc Excel trong Aspose.Slides bằng API ExcelDataWorkbook. Tải các sheet và ô và sử dụng giá trị để tạo các bản trình chiếu PowerPoint dựa trên dữ liệu."
---
## **Giới thiệu**

Các bản trình chiếu PowerPoint là một cách mạnh mẽ để hiển thị và truyền đạt thông tin. Chúng thường được sử dụng cùng với các sổ làm việc Excel, trong đó Excel là nguồn dữ liệu có cấu trúc tuyệt vời và PowerPoint xuất sắc trong việc hình ảnh hoá dữ liệu đó cho khán giả.

Có rất nhiều tình huống thực tế mà việc kết hợp Excel và PowerPoint là thiết yếu: trộn thư, điền dữ liệu vào bảng, tạo một slide cho mỗi bản ghi dữ liệu (tạo slide hàng loạt), tạo tài liệu đào tạo, và hợp nhất nhiều báo cáo Excel vào một bản trình chiếu duy nhất, chỉ vài ví dụ.

Trước đây, việc triển khai các tính năng này với API Aspose.Slides yêu cầu dựa vào các giải pháp của bên thứ ba như Aspose.Cells. Mặc dù các công cụ này mạnh mẽ, chúng có thể quá phức tạp và tốn kém đối với người dùng chỉ cần chức năng tích hợp dữ liệu cơ bản.

## **Cách hoạt động**

Để làm việc với dữ liệu Excel dễ dàng hơn và suôn sẻ hơn, Aspose.Slides đã giới thiệu các lớp mới để đọc dữ liệu từ sổ làm việc Excel và nhập nội dung vào một bản trình chiếu. Tính năng này mở ra những khả năng mới mạnh mẽ cho người dùng API muốn sử dụng Excel làm nguồn dữ liệu trong quy trình làm việc với bản trình chiếu.

Chức năng mới được thiết kế cho việc truy cập dữ liệu đa mục đích và không được tích hợp vào Mô hình Đối tượng Tài liệu Trình chiếu (Presentation Document Object Model - DOM). Điều đó có nghĩa là *nó không cho phép chỉnh sửa hay lưu các tệp Excel* — mục đích duy nhất của nó là mở sổ làm việc và duyệt qua nội dung để lấy dữ liệu ô.

Ở trung tâm của tính năng này là lớp mới [ExcelDataWorkbook](https://reference.aspose.com/slides/vi/java/com.aspose.slides/exceldataworkbook/). Lớp này cho phép bạn tải một sổ làm việc Excel từ tệp cục bộ hoặc luồng. Khi đã tải, nó cung cấp một số overload của phương thức [getCell](https://reference.aspose.com/slides/vi/java/com.aspose.slides/exceldataworkbook/#getCell-int-int-int-) mà bạn có thể dùng để lấy các ô cụ thể theo vị trí của chúng (ví dụ: chỉ số hàng và cột hoặc các phạm vi có tên).

Mỗi lần gọi [getCell](https://reference.aspose.com/slides/vi/java/com.aspose.slides/exceldataworkbook/#getCell-int-int-int-) sẽ trả về một thể hiện của lớp [ExcelDataCell](https://reference.aspose.com/slides/vi/java/com.aspose.slides/exceldatacell/). Đối tượng này đại diện cho một ô duy nhất trong sổ làm việc Excel và cho phép bạn truy cập giá trị của nó một cách đơn giản và trực quan.

#### **Nhập biểu đồ Excel**

Bước tiếp theo để mở rộng chức năng là lớp [ExcelWorkbookImporter](https://reference.aspose.com/slides/vi/java/com.aspose.slides/excelworkbookimporter/). Lớp tiện ích này cung cấp chức năng nhập nội dung từ một sổ làm việc Excel vào bản trình chiếu. Nó chứa một số overload của phương thức [addChartFromWorkbook](https://reference.aspose.com/slides/vi/java/com.aspose.slides/excelworkbookimporter/#addChartFromWorkbook-com.aspose.slides.IShapeCollection-float-float-com.aspose.slides.IExcelDataWorkbook-java.lang.String-int-boolean-) giúp bạn lấy biểu đồ đã chọn từ sổ làm việc Excel được chỉ định và thêm nó vào cuối bộ sưu tập hình dạng đã cho tại tọa độ chỉ định.

Nói ngắn gọn, đây là một API nhẹ và đơn giản để đọc dữ liệu Excel — chính xác những gì nhiều nhà phát triển cần mà không phải chịu gánh nặng của một thư viện xử lý bảng tính đầy đủ.

## **Hãy cùng lập trình**

### **Ví dụ kịch bản Mail Merge**

Trong ví dụ sau, chúng ta sẽ triển khai một kịch bản Mail Merge đơn giản bằng cách tạo nhiều bản trình chiếu dựa trên dữ liệu lưu trong một sổ làm việc Excel.

Để bắt đầu, chúng ta cần hai thứ:
1. Một sổ làm việc Excel chứa dữ liệu

![Ví dụ dữ liệu Excel](example1_image0.png)

2. Mẫu bản trình chiếu PowerPoint

![Ví dụ mẫu PowerPoint](example1_image1.png)

```java
// Tải sổ làm việc Excel chứa dữ liệu nhân viên.
ExcelDataWorkbook workbook = new ExcelDataWorkbook("TemplateData.xlsx");
int worksheetIndex = 0;

// Tải mẫu bản trình chiếu.
Presentation templatePresentation = new Presentation("PresentationTemplate.pptx");

try {
    // Lặp qua các hàng Excel (ngoại trừ tiêu đề ở hàng 0).
    for (int rowIndex = 1; rowIndex <= 4; rowIndex++) {

        // Tạo một bản trình chiếu mới cho mỗi bản ghi nhân viên.
        Presentation employeePresentation = new Presentation();

        try {
            // Xóa slide trống mặc định.
            employeePresentation.getSlides().removeAt(0);

            // Sao chép slide mẫu vào bản trình chiếu mới.
            ISlide slide = employeePresentation.getSlides().addClone(templatePresentation.getSlides().get_Item(0));

            // Lấy các đoạn văn từ hình dạng mục tiêu (giả sử chỉ mục hình dạng 1 được sử dụng).
            IParagraphCollection paragraphs = ((IAutoShape)slide.getShapes().get_Item(1)).getTextFrame().getParagraphs();

            // Thay thế các placeholder bằng dữ liệu từ Excel.
            String employeeName = workbook.getCell(worksheetIndex, rowIndex, 0).getValue().toString();
            IPortion namePortion = paragraphs.get_Item(0).getPortions().get_Item(0);
            namePortion.setText(namePortion.getText().replace("{{EmployeeName}}", employeeName));

            String department = workbook.getCell(worksheetIndex, rowIndex, 1).getValue().toString();
            IPortion departmentPortion = paragraphs.get_Item(1).getPortions().get_Item(0);
            departmentPortion.setText(departmentPortion.getText().replace("{{Department}}", department));

            String yearsOfService = workbook.getCell(worksheetIndex, rowIndex, 2).getValue().toString();
            IPortion yearsPortion = paragraphs.get_Item(2).getPortions().get_Item(0);
            yearsPortion.setText(yearsPortion.getText().replace("{{YearsOfService}}", yearsOfService));

            // Lưu bản trình chiếu đã cá nhân hoá vào một tệp riêng.
            employeePresentation.save(String.format("%s Report.pptx", employeeName), SaveFormat.Pptx);
        } finally {
            employeePresentation.dispose();
        }
    }
} finally {
    templatePresentation.dispose();
}
```

![Kết quả](example1_image2.png)

### **Ví dụ bảng Excel**

Trong ví dụ thứ hai, chúng ta đơn giản sao chép dữ liệu từ một bảng Excel và hiển thị nó trên một slide PowerPoint theo định dạng trực quan hơn.

Trong ví dụ này, chúng ta tái sử dụng cùng một sổ làm việc Excel từ ví dụ đầu tiên, chứa một bảng nhân viên đơn giản.

```java
// Tải sổ làm việc Excel chứa dữ liệu nhân viên.
ExcelDataWorkbook workbook = new ExcelDataWorkbook("TemplateData.xlsx");
int worksheetIndex = 0;

// Tạo một bản trình chiếu PowerPoint mới.
Presentation presentation = new Presentation();

try {
    // Thêm một hình dạng bảng vào slide đầu tiên.
    ITable table = presentation.getSlides().get_Item(0).getShapes().addTable(
            50, 200,
            new double[]{200, 200, 200},
            new double[]{30, 30, 30, 30, 30}
    );

    // Điền dữ liệu từ sổ làm việc Excel vào bảng PowerPoint.
    for (int rowIndex = 0; rowIndex < 5; rowIndex++) {
        for (int columnIndex = 0; columnIndex < 3; columnIndex++) {
            String cellValue = workbook.getCell(worksheetIndex, rowIndex, columnIndex).getValue().toString();
            table.getColumns().get_Item(columnIndex).get_Item(rowIndex).getTextFrame().setText(cellValue);
        }
    }

    // Lưu bản trình chiếu kết quả vào một tệp.
    presentation.save("Table.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Kết quả](example2_image0.png)

### **Ví dụ nhập biểu đồ Excel**

Trong ví dụ này, chúng ta nhập một biểu đồ từ worksheet đầu tiên của sổ làm việc Excel được dùng trong ví dụ trước. Biểu đồ sẽ liên kết đến sổ làm việc bên ngoài trong bản trình chiếu kết quả.

Đầu tiên, chúng ta thêm một biểu đồ Pie vào sổ làm việc Excel dựa trên bảng nhân viên.

![Ví dụ biểu đồ Excel](example3_image0.png)

```java
// Tạo một bản trình chiếu PowerPoint mới.
Presentation presentation = new Presentation();
try {
    // Lấy bộ sưu tập các hình dạng của slide đầu tiên.
    IShapeCollection shapes = presentation.getSlides().get_Item(0).getShapes();

    // Nhập biểu đồ có tên "Chart 1" từ sheet đầu tiên của sổ làm việc và thêm nó vào bộ sưu tập các hình dạng.
    ExcelWorkbookImporter.addChartFromWorkbook(shapes, 10, 10, "TemplateData.xlsx", "Sheet1", "Chart 1", false);

    // Lưu bản trình chiếu kết quả vào một tệp.
    presentation.save("Chart.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Kết quả](example3_image1.png)

### **Ví dụ nhập tất cả biểu đồ Excel**

Hãy tưởng tượng bạn có một sổ làm việc Excel đầy các biểu đồ và bạn cần nhập tất cả chúng vào một bản trình chiếu. Mỗi biểu đồ nên được đặt trên một slide mới.

Đoạn mã sau lặp qua tất cả các worksheet trong tệp Excel nguồn, trích xuất các biểu đồ từ mỗi worksheet và thêm mỗi biểu đồ vào một slide riêng bằng bố cục slide trống. Trong bản trình chiếu kết quả, chỉ dữ liệu biểu đồ sẽ được nhúng, không phải toàn bộ sổ làm việc.

```java
// Tải sổ làm việc Excel chứa dữ liệu nhân viên.
ExcelDataWorkbook workbook = new ExcelDataWorkbook("ExcelWithCharts.xlsx");

// Tạo một bản trình chiếu PowerPoint mới.
Presentation presentation = new Presentation();
try {
    // Lấy bố cục slide trống.
    ILayoutSlide blankLayout = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank);

    // Lấy tên của tất cả các worksheet có trong sổ làm việc Excel.
    List<String> worksheetNames = workbook.getWorksheetNames();

    for (String name : worksheetNames) {
        // Lấy một bản đồ ánh xạ chỉ số biểu đồ tới tên biểu đồ cho worksheet.
        Dictionary<Integer, String> worksheetCharts = workbook.getChartsFromWorksheet(name);

        for (KeyValuePair<Integer, String> chart : worksheetCharts) {
            // Thêm một slide mới sử dụng bố cục trống.
            ISlide slide = presentation.getSlides().addEmptySlide(blankLayout);

            // Nhập biểu đồ đã chỉ định từ sổ làm việc Excel vào bộ sưu tập hình dạng của slide.
            ExcelWorkbookImporter.addChartFromWorkbook(
                    slide.getShapes(), 10, 10, workbook, name, chart.getKey(), false);
        }
    }

    // Lưu bản trình chiếu kết quả vào một tệp.
    presentation.save("Charts.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Tóm tắt**

Cơ chế này, có sẵn trực tiếp trong Aspose.Slides, kết hợp việc làm việc với dữ liệu Excel và bản trình chiếu trong một nơi. Nó cho phép bạn tạo slide với các biểu đồ trực quan và dữ liệu được trình bày dưới dạng bảng Excel — mà không cần bất kỳ thư viện bổ sung hay tích hợp phức tạp nào.