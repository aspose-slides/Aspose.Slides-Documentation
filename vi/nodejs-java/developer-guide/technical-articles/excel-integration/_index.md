---
title: Tích hợp dữ liệu Excel vào bản thuyết trình PowerPoint
linktitle: Tích hợp Excel
type: docs
weight: 330
url: /vi/nodejs-java/excel-integration/
keywords:
- Excel
- sổ làm việc
- đọc Excel
- tích hợp Excel
- nguồn dữ liệu
- hợp nhất thư
- nhập bảng
- Excel vào PowerPoint
- PowerPoint
- bản thuyết trình
- Node.js
- JavaScript
- Aspose.Slides
description: "Đọc dữ liệu từ sổ làm việc Excel trong JavaScript bằng Aspose.Slides. Tải các sheet và ô và sử dụng giá trị để tạo các bản thuyết trình PowerPoint dựa trên dữ liệu."
---
## **Giới thiệu**

Các bản thuyết trình PowerPoint là một cách mạnh mẽ để hiển thị và truyền đạt thông tin. Chúng thường được sử dụng cùng với các workbook Excel, trong đó Excel là nguồn dữ liệu có cấu trúc tuyệt vời và PowerPoint xuất sắc trong việc trực quan hoá dữ liệu đó cho khán giả.

Có nhiều kịch bản thực tế mà việc kết hợp Excel và PowerPoint là thiết yếu: hợp nhất thư, điền dữ liệu vào bảng, tạo một slide cho mỗi bản ghi dữ liệu (tạo slide hàng loạt), tạo tài liệu đào tạo, và hợp nhất nhiều báo cáo Excel vào một bản thuyết trình duy nhất, chỉ để nêu một vài ví dụ.

Cho đến nay, việc triển khai các tính năng này với Aspose.Slides API đòi hỏi phải dựa vào các giải pháp của bên thứ ba như Aspose.Cells. Mặc dù những công cụ này mạnh mẽ, chúng có thể quá phức tạp và tốn kém cho người dùng chỉ cần chức năng tích hợp dữ liệu cơ bản.

## **Cách hoạt động**

Để làm việc với dữ liệu Excel dễ dàng và hợp lý hơn, Aspose.Slides đã giới thiệu các lớp mới để đọc dữ liệu từ workbook Excel và nhập nội dung vào bản thuyết trình. Tính năng này mở ra những khả năng mới mạnh mẽ cho người dùng API muốn sử dụng Excel làm nguồn dữ liệu trong quy trình làm việc với bản thuyết trình.

Chức năng mới được thiết kế cho truy cập dữ liệu đa mục đích và không được tích hợp vào Mô hình Đối tượng Tài liệu (DOM) của Presentation. Điều đó có nghĩa là *không cho phép chỉnh sửa hoặc lưu file Excel* — mục đích duy nhất của nó là mở workbook và duyệt qua nội dung để lấy dữ liệu ô.

Ở trung tâm của tính năng này là lớp mới [ExcelDataWorkbook](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/exceldataworkbook/). Lớp này cho phép bạn tải một workbook Excel từ file cục bộ hoặc từ một luồng. Sau khi tải, nó cung cấp một số overload của phương thức [getCell](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/exceldataworkbook/#getCell), bạn có thể dùng để lấy các ô cụ thể theo vị trí của chúng (ví dụ: chỉ số hàng và cột hoặc phạm vi đặt tên).

Mỗi lần gọi [getCell](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/exceldataworkbook/#getCell) sẽ trả về một thể hiện của lớp [ExcelDataCell](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/exceldatacell/). Đối tượng này đại diện cho một ô duy nhất trong workbook Excel và cung cấp cho bạn truy cập giá trị của nó một cách đơn giản và tự nhiên.

#### **Nhập biểu đồ Excel**

Bước tiếp theo để mở rộng chức năng là lớp [ExcelWorkbookImporter](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/excelworkbookimporter/). Lớp tiện ích này cung cấp chức năng nhập nội dung từ một workbook Excel vào bản thuyết trình. Nó chứa một số overload của phương thức [addChartFromWorkbook](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/excelworkbookimporter/#addChartFromWorkbook), giúp bạn lấy biểu đồ đã chọn từ workbook Excel được chỉ định và thêm nó vào cuối bộ sưu tập hình dạng đã cho tại tọa độ chỉ định.

Tóm lại, đây là một API nhẹ và đơn giản để đọc dữ liệu Excel — chính xác những gì nhiều nhà phát triển cần mà không phải chịu gánh nặng của một thư viện xử lý bảng tính đầy đủ.

## **Hãy cùng lập trình**

### **Ví dụ kịch bản Mail Merge**

Trong ví dụ sau, chúng ta sẽ triển khai một kịch bản Mail Merge đơn giản bằng cách tạo nhiều bản thuyết trình dựa trên dữ liệu được lưu trong một workbook Excel.

Để bắt đầu, chúng ta cần hai thứ:
1. Một workbook Excel chứa dữ liệu

![Ví dụ dữ liệu Excel](example1_image0.png)

2. Mẫu bản thuyết trình PowerPoint

![Ví dụ mẫu PowerPoint](example1_image1.png)

```js
// Tải workbook Excel chứa dữ liệu nhân viên.
let workbook = new aspose.slides.ExcelDataWorkbook("TemplateData.xlsx");
const worksheetIndex = 0;

// Tải mẫu bản thuyết trình.
let templatePresentation = new aspose.slides.Presentation("PresentationTemplate.pptx");

try {
    // Lặp qua các hàng trong Excel (bỏ qua tiêu đề ở hàng 0).
    for (let rowIndex = 1; rowIndex <= 4; rowIndex++) {

        // Tạo một bản thuyết trình mới cho mỗi bản ghi nhân viên.
        let employeePresentation = new aspose.slides.Presentation();

        try {
            // Xóa slide trống mặc định.
            employeePresentation.getSlides().removeAt(0);

            // Sao chép slide mẫu vào bản thuyết trình mới.
            let slide = employeePresentation.getSlides().addClone(templatePresentation.getSlides().get_Item(0));

            // Lấy các đoạn văn từ shape mục tiêu (giả sử shape chỉ số 1 được sử dụng).
            let paragraphs = slide.getShapes().get_Item(1).getTextFrame().getParagraphs();

            // Thay thế các placeholder bằng dữ liệu từ Excel.
            let employeeName = workbook.getCell(worksheetIndex, rowIndex, 0).getValue().toString();
            let namePortion = paragraphs.get_Item(0).getPortions().get_Item(0);
            namePortion.setText(namePortion.getText().replace("{{EmployeeName}}", employeeName));

            let department = workbook.getCell(worksheetIndex, rowIndex, 1).getValue().toString();
            let departmentPortion = paragraphs.get_Item(1).getPortions().get_Item(0);
            departmentPortion.setText(departmentPortion.getText().replace("{{Department}}", department));

            let yearsOfService = workbook.getCell(worksheetIndex, rowIndex, 2).getValue().toString();
            let yearsPortion = paragraphs.get_Item(2).getPortions().get_Item(0);
            yearsPortion.setText(yearsPortion.getText().replace("{{YearsOfService}}", yearsOfService));

            // Lưu bản thuyết trình cá nhân hoá vào một file riêng.
            employeePresentation.save(`${employeeName} Report.pptx`, aspose.slides.SaveFormat.Pptx);
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

Trong ví dụ thứ hai, chúng ta chỉ cần sao chép dữ liệu từ một bảng Excel và hiển thị nó trên một slide PowerPoint theo định dạng hấp dẫn hơn.

Trong ví dụ này, chúng ta tái sử dụng cùng một workbook Excel từ ví dụ đầu tiên, trong đó chứa một bảng nhân viên đơn giản.

```js
// Tải workbook Excel chứa dữ liệu nhân viên.
let workbook = new aspose.slides.ExcelDataWorkbook("TemplateData.xlsx");
const worksheetIndex = 0;

// Tạo một bản thuyết trình PowerPoint mới.
let presentation = new aspose.slides.Presentation();

try {
    // Thêm một shape bảng vào slide đầu tiên.
    let table = presentation.getSlides().get_Item(0).getShapes().addTable(
            50, 200,
            java.newArray("double", [200, 200, 200]),
            java.newArray("double", [30, 30, 30, 30, 30])
    );

    // Điền dữ liệu vào bảng PowerPoint từ workbook Excel.
    for (let rowIndex = 0; rowIndex < 5; rowIndex++) {
        for (let columnIndex = 0; columnIndex < 3; columnIndex++) {
            let cellValue = workbook.getCell(worksheetIndex, rowIndex, columnIndex).getValue().toString();
            table.getColumns().get_Item(columnIndex).get_Item(rowIndex).getTextFrame().setText(cellValue);
        }
    }

    // Lưu bản thuyết trình kết quả vào file.
    presentation.save("Table.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Kết quả](example2_image0.png)

### **Ví dụ nhập biểu đồ Excel**

Trong ví dụ này, chúng ta nhập một biểu đồ từ worksheet đầu tiên của workbook Excel đã dùng trong ví dụ trước. Biểu đồ sẽ liên kết tới workbook bên ngoài trong bản thuyết trình kết quả.

Đầu tiên, chúng ta thêm một biểu đồ Pie vào workbook Excel dựa trên bảng nhân viên.

![Ví dụ biểu đồ Excel](example3_image0.png)

```js
// Tạo một bản thuyết trình PowerPoint mới.
let presentation = new aspose.slides.Presentation();
try {
    // Lấy bộ sưu tập shape của slide đầu tiên.
    let shapes = presentation.getSlides().get_Item(0).getShapes();

    // Nhập biểu đồ có tên "Chart 1" từ sheet đầu tiên của workbook và thêm nó vào bộ sưu tập shape.
    aspose.slides.ExcelWorkbookImporter.addChartFromWorkbook(shapes, 10, 10, "TemplateData.xlsx", "Sheet1", "Chart 1", false);

    // Lưu bản thuyết trình kết quả vào file.
    presentation.save("Chart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Kết quả](example3_image1.png)

### **Ví dụ nhập tất cả biểu đồ Excel**

Hãy tưởng tượng bạn có một workbook Excel đầy các biểu đồ và bạn cần nhập tất cả chúng vào một bản thuyết trình. Mỗi biểu đồ sẽ được đặt trên một slide mới.

Đoạn mã sau lặp qua tất cả các worksheet trong file Excel nguồn, trích xuất các biểu đồ từ mỗi worksheet, và thêm mỗi biểu đồ vào một slide riêng biệt bằng cách sử dụng bố cục slide trống. Trong bản thuyết trình kết quả, chỉ dữ liệu biểu đồ sẽ được nhúng, không phải toàn bộ workbook.

```js
// Tải workbook Excel chứa dữ liệu nhân viên.
let workbook = new aspose.slides.ExcelDataWorkbook("ExcelWithCharts.xlsx");

// Tạo một bản thuyết trình PowerPoint mới.
let presentation = new aspose.slides.Presentation();
try {
    // Lấy bố cục slide trống.
    let layoutType = java.newByte(aspose.slides.SlideLayoutType.Blank);
    let layoutSlide = presentation.getLayoutSlides().getByType(layoutType);

    // Lấy tên của tất cả các worksheet có trong workbook Excel.
    let worksheetNames = workbook.getWorksheetNames().iterator();

    while (worksheetNames.hasNext()) {
        let name = worksheetNames.next();
        // Lấy bản đồ ánh xạ chỉ mục biểu đồ tới tên biểu đồ cho worksheet.
        let worksheetCharts = workbook.getChartsFromWorksheet(name).iterator();

        while (worksheetCharts.hasNext()) {
            let chart = worksheetCharts.next();
            // Thêm một slide mới sử dụng bố cục trống.
            let slide = presentation.getSlides().addEmptySlide(layoutSlide);

            // Nhập biểu đồ đã chỉ định từ workbook Excel vào bộ sưu tập shape của slide.
            aspose.slides.ExcelWorkbookImporter.addChartFromWorkbook(
                    slide.getShapes(), 10, 10, workbook, name, chart.getKey(), false);
        }
    }

    // Lưu bản thuyết trình kết quả vào file.
    presentation.save("Charts.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Tóm tắt**

Cơ chế này, có sẵn trực tiếp trong Aspose.Slides, kết hợp việc làm việc với dữ liệu Excel và bản thuyết trình trong một nơi. Nó cho phép bạn tạo các slide với biểu đồ trực quan và dữ liệu được trình bày dưới dạng bảng Excel — mà không cần bất kỳ thư viện bổ sung nào hay tích hợp phức tạp.