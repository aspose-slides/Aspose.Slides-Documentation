---
title: "Tích hợp dữ liệu Excel vào bản trình chiếu PowerPoint"
linktitle: "Tích hợp Excel"
type: docs
weight: 330
url: /vi/androidjava/excel-integration/
keywords:
- "Excel"
- "sổ làm việc"
- "đọc Excel"
- "tích hợp Excel"
- "nguồn dữ liệu"
- "trộn thư"
- "nhập bảng"
- "Excel vào PowerPoint"
- "PowerPoint"
- "bản trình chiếu"
- "Android"
- "Java"
- "Aspose.Slides"
description: "Đọc dữ liệu từ các workbook Excel trong Aspose.Slides bằng API ExcelDataWorkbook. Tải các sheet và ô và sử dụng giá trị để tạo các bản trình chiếu PowerPoint dựa trên dữ liệu."
---
## **Giới thiệu**

Bản trình chiếu PowerPoint là một cách mạnh mẽ để hiển thị và truyền đạt thông tin. Chúng thường được sử dụng kết hợp với các bảng tính Excel, trong đó Excel đóng vai trò là nguồn dữ liệu có cấu trúc xuất sắc và PowerPoint xuất sắc trong việc trực quan hoá dữ liệu đó cho người xem.

Có rất nhiều kịch bản thực tế mà việc kết hợp Excel và PowerPoint là thiết yếu: trộn thư, điền dữ liệu vào bảng, tạo một slide cho mỗi bản ghi dữ liệu (tạo slide hàng loạt), tạo tài liệu đào tạo, và hợp nhất nhiều báo cáo Excel vào một bản trình chiếu duy nhất, chỉ để nêu một vài ví dụ.

Cho đến nay, việc triển khai các tính năng như vậy với API Aspose.Slides yêu cầu phải dựa vào các giải pháp của bên thứ ba như Aspose.Cells. Mặc dù các công cụ này mạnh mẽ, chúng có thể quá phức tạp và tốn kém đối với người dùng chỉ cần chức năng tích hợp dữ liệu cơ bản.

## **Cách hoạt động**

Để việc làm việc với dữ liệu Excel trở nên dễ dàng và suôn sẻ hơn, Aspose.Slides đã giới thiệu các lớp mới để đọc dữ liệu từ các workbook Excel và nhập nội dung vào một bản trình chiếu. Tính năng này mở ra những khả năng mạnh mẽ mới cho người dùng API muốn tận dụng Excel làm nguồn dữ liệu trong quy trình làm việc của bản trình chiếu.

Chức năng mới được thiết kế cho việc truy cập dữ liệu đa mục đích và không được tích hợp vào Mô hình Đối tượng Tài liệu Trình chiếu (DOM). Điều đó có nghĩa là *nó không cho phép chỉnh sửa hoặc lưu các tập tin Excel* — mục đích duy nhất của nó là mở các workbook và điều hướng qua nội dung của chúng để lấy dữ liệu ô.

Ở trung tâm của tính năng này là lớp mới [ExcelDataWorkbook](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/exceldataworkbook/) . Lớp này cho phép bạn tải một workbook Excel từ tệp cục bộ hoặc luồng. Khi đã tải, nó cung cấp một số overload của phương thức [getCell](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/exceldataworkbook/#getCell-int-int-int-) , mà bạn có thể dùng để lấy các ô cụ thể theo vị trí của chúng (ví dụ: chỉ số hàng và cột hoặc phạm vi có tên).

Mỗi lần gọi [getCell](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/exceldataworkbook/#getCell-int-int-int-) sẽ trả về một thể hiện của lớp [ExcelDataCell](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/exceldatacell/) . Đối tượng này đại diện cho một ô duy nhất trong workbook Excel và cung cấp cho bạn quyền truy cập vào giá trị của nó một cách đơn giản và trực quan.

#### **Nhập biểu đồ Excel**

Bước tiếp theo để mở rộng chức năng là lớp [ExcelWorkbookImporter](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/excelworkbookimporter/) . Lớp tiện ích này cung cấp chức năng nhập nội dung từ một workbook Excel vào một bản trình chiếu. Nó chứa một số overload của phương thức [addChartFromWorkbook](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/excelworkbookimporter/#addChartFromWorkbook-com.aspose.slides.IShapeCollection-float-float-com.aspose.slides.IExcelDataWorkbook-java.lang.String-int-boolean-) , giúp bạn lấy biểu đồ được chọn từ workbook Excel chỉ định và thêm nó vào cuối bộ sưu tập hình đã cho tại các tọa độ được xác định.

Tóm lại, đây là một API nhẹ và đơn giản để đọc dữ liệu Excel — chính xác những gì nhiều nhà phát triển cần mà không phải chịu gánh nặng của một thư viện xử lý bảng tính đầy đủ.

## **Hãy cùng viết mã**

### **Ví dụ kịch bản trộn thư**

Trong ví dụ sau, chúng ta sẽ triển khai một kịch bản Trộn Thư đơn giản bằng cách tạo nhiều bản trình chiếu dựa trên dữ liệu được lưu trong một workbook Excel.

Để bắt đầu, chúng ta cần hai thứ:
1. Một workbook Excel chứa dữ liệu

![Excel data example](example1_image0.png)

2. Mẫu bản trình chiếu PowerPoint

![PowerPoint template example](example1_image1.png)

```java
// Tải workbook Excel với dữ liệu nhân viên.
ExcelDataWorkbook workbook = new ExcelDataWorkbook("TemplateData.xlsx");
int worksheetIndex = 0;

// Tải mẫu bản trình chiếu.
Presentation templatePresentation = new Presentation("PresentationTemplate.pptx");

try {
    // Duyệt qua các hàng Excel (bỏ qua tiêu đề ở hàng 0).
    for (int rowIndex = 1; rowIndex <= 4; rowIndex++) {

        // Tạo bản trình chiếu mới cho mỗi bản ghi nhân viên.
        Presentation employeePresentation = new Presentation();

        try {
            // Xóa slide trống mặc định.
            employeePresentation.getSlides().removeAt(0);

            // Sao chép slide mẫu vào bản trình chiếu mới.
            ISlide slide = employeePresentation.getSlides().addClone(templatePresentation.getSlides().get_Item(0));

            // Lấy các đoạn văn từ shape mục tiêu (giả sử shape có chỉ số 1 được sử dụng).
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

            // Lưu bản trình chiếu cá nhân hóa vào tệp riêng.
            employeePresentation.save(String.format("%s Report.pptx", employeeName), SaveFormat.Pptx);
        } finally {
            employeePresentation.dispose();
        }
    }
} finally {
    templatePresentation.dispose();
}
```

![Result](example1_image2.png)

### **Ví dụ bảng Excel**

Trong ví dụ thứ hai, chúng ta chỉ đơn giản sao chép dữ liệu từ một bảng Excel và hiển thị nó trên một slide PowerPoint theo định dạng hấp dẫn hơn về mặt thị giác.

Trong ví dụ này, chúng ta tái sử dụng cùng một workbook Excel từ ví dụ đầu tiên, trong đó chứa một bảng nhân viên đơn giản.

```java
// Tải workbook Excel chứa dữ liệu nhân viên.
ExcelDataWorkbook workbook = new ExcelDataWorkbook("TemplateData.xlsx");
int worksheetIndex = 0;

// Tạo một bản trình chiếu PowerPoint mới.
Presentation presentation = new Presentation();

try {
    // Thêm shape bảng vào slide đầu tiên.
    ITable table = presentation.getSlides().get_Item(0).getShapes().addTable(
            50, 200,
            new double[]{200, 200, 200},
            new double[]{30, 30, 30, 30, 30}
    );

    // Điền bảng PowerPoint bằng dữ liệu từ workbook Excel.
    for (int rowIndex = 0; rowIndex < 5; rowIndex++) {
        for (int columnIndex = 0; columnIndex < 3; columnIndex++) {
            String cellValue = workbook.getCell(worksheetIndex, rowIndex, columnIndex).getValue().toString();
            table.getColumns().get_Item(columnIndex).get_Item(rowIndex).getTextFrame().setText(cellValue);
        }
    }

    // Lưu bản trình chiếu kết quả vào tệp.
    presentation.save("Table.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Result](example2_image0.png)

### **Ví dụ nhập biểu đồ Excel**

Trong ví dụ này, chúng ta nhập một biểu đồ từ trang tính đầu tiên của workbook Excel được sử dụng trong ví dụ trước. Biểu đồ sẽ liên kết tới workbook bên ngoài trong bản trình chiếu kết quả.

Đầu tiên, chúng ta thêm một biểu đồ Pie vào workbook Excel dựa trên bảng nhân viên.

![Excel Chart example](example3_image0.png)

```java
// Tạo một bản trình chiếu PowerPoint mới.
Presentation presentation = new Presentation();
try {
    // Lấy bộ sưu tập shape của slide đầu tiên.
    IShapeCollection shapes = presentation.getSlides().get_Item(0).getShapes();

    // Nhập biểu đồ có tên "Chart 1" từ sheet đầu tiên của workbook và thêm nó vào bộ sưu tập shape.
    ExcelWorkbookImporter.addChartFromWorkbook(shapes, 10, 10, "TemplateData.xlsx", "Sheet1", "Chart 1", false);

    // Lưu bản trình chiếu kết quả vào tệp.
    presentation.save("Chart.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Result](example3_image1.png)

### **Ví dụ nhập tất cả biểu đồ Excel**

Hãy tưởng tượng bạn có một workbook Excel đầy các biểu đồ và bạn cần nhập tất cả chúng vào một bản trình chiếu. Mỗi biểu đồ nên được đặt trên một slide mới.

Đoạn mã dưới đây duyệt qua tất cả các trang tính trong tệp Excel nguồn, trích xuất các biểu đồ từ mỗi trang tính, và thêm mỗi biểu đồ vào một slide riêng biệt bằng cách sử dụng bố cục slide trống. Trong bản trình chiếu kết quả, chỉ dữ liệu biểu đồ sẽ được nhúng, không phải toàn bộ workbook.

```java
// Tải workbook Excel chứa dữ liệu nhân viên.
ExcelDataWorkbook workbook = new ExcelDataWorkbook("ExcelWithCharts.xlsx");

// Tạo một bản trình chiếu PowerPoint mới.
Presentation presentation = new Presentation();
try {
    // Lấy bố cục slide trống.
    ILayoutSlide blankLayout = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank);

    // Lấy tên của tất cả các worksheet có trong workbook Excel.
    List<String> worksheetNames = workbook.getWorksheetNames();

    for (String name : worksheetNames) {
        // Lấy bản đồ ánh xạ chỉ số biểu đồ tới tên biểu đồ cho worksheet.
        Dictionary<Integer, String> worksheetCharts = workbook.getChartsFromWorksheet(name);

        for (KeyValuePair<Integer, String> chart : worksheetCharts) {
            // Thêm một slide mới sử dụng bố cục trống.
            ISlide slide = presentation.getSlides().addEmptySlide(blankLayout);

            // Nhập biểu đồ đã chỉ định từ workbook Excel vào bộ sưu tập shape của slide.
            ExcelWorkbookImporter.addChartFromWorkbook(
                    slide.getShapes(), 10, 10, workbook, name, chart.getKey(), false);
        }
    }

    // Lưu bản trình chiếu kết quả vào tệp.
    presentation.save("Charts.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Tóm tắt**

Cơ chế này, có sẵn trực tiếp trong Aspose.Slides, kết hợp việc làm việc với dữ liệu Excel và bản trình chiếu trong một nơi. Nó cho phép bạn tạo các slide với biểu đồ trực quan và dữ liệu được trình bày dưới dạng bảng Excel — mà không cần bất kỳ thư viện bổ sung nào hay các tích hợp phức tạp.