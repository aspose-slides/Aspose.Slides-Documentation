---
title: "Tích hợp dữ liệu Excel vào bản trình chiếu PowerPoint"
linktitle: "Tích hợp Excel"
type: docs
weight: 330
url: /vi/php-java/excel-integration/
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
- bài thuyết trình
- PHP
- Aspose.Slides
description: "Đọc dữ liệu từ sổ làm việc Excel bằng Aspose.Slides cho PHP qua Java. Tải các sheet và ô và sử dụng giá trị để tạo các bản trình chiếu PowerPoint dựa trên dữ liệu."
---
## **Giới thiệu**

Các bản trình chiếu PowerPoint là một cách mạnh mẽ để hiển thị và truyền đạt thông tin. Chúng thường được sử dụng kết hợp với các sổ làm việc Excel, trong đó Excel là nguồn dữ liệu có cấu trúc tuyệt vời và PowerPoint xuất sắc trong việc trực quan hoá dữ liệu đó cho khán giả.

Có rất nhiều kịch bản thực tế mà việc kết hợp Excel và PowerPoint là thiết yếu: mail merge, điền dữ liệu vào bảng, tạo một slide cho mỗi bản ghi dữ liệu (tạo slide hàng loạt), tạo tài liệu đào tạo, và hợp nhất nhiều báo cáo Excel thành một bản trình chiếu duy nhất, chỉ nêu vài ví dụ.

Cho đến nay, việc triển khai các tính năng này bằng API Aspose.Slides đòi hỏi phải dựa vào các giải pháp của bên thứ ba như Aspose.Cells. Mặc dù các công cụ này mạnh mẽ, chúng có thể quá phức tạp và tốn kém đối với người dùng chỉ cần chức năng tích hợp dữ liệu cơ bản.

## **Cách hoạt động**

Để việc làm việc với dữ liệu Excel trở nên dễ dàng và gọn gàng hơn, Aspose.Slides đã giới thiệu các lớp mới để đọc dữ liệu từ sổ làm việc Excel và nhập nội dung vào bản trình chiếu. Tính năng này mở ra những khả năng mạnh mẽ mới cho người dùng API muốn tận dụng Excel làm nguồn dữ liệu trong quy trình làm việc với bản trình chiếu.

Chức năng mới được thiết kế cho việc truy cập dữ liệu đa mục đích và không được tích hợp vào Presentation Document Object Model (DOM). Điều đó có nghĩa là *nó không cho phép chỉnh sửa hoặc lưu các file Excel* — mục đích duy nhất của nó là mở sổ làm việc và duyệt nội dung để lấy dữ liệu ô.

Ở trung tâm của tính năng này là lớp mới [ExcelDataWorkbook](https://reference.aspose.com/slides/vi/php-java/aspose.slides/exceldataworkbook/). Lớp này cho phép bạn tải một sổ làm việc Excel từ tệp cục bộ hoặc từ luồng. Sau khi tải, nó cung cấp một số overload của phương thức [getCell](https://reference.aspose.com/slides/vi/php-java/aspose.slides/exceldataworkbook/#getCell), mà bạn có thể dùng để lấy các ô cụ thể theo vị trí (ví dụ: chỉ số hàng và cột hoặc phạm vi đặt tên).

Mỗi lần gọi [getCell](https://reference.aspose.com/slides/vi/php-java/aspose.slides/exceldataworkbook/#getCell) sẽ trả về một thể hiện của lớp [ExcelDataCell](https://reference.aspose.com/slides/vi/php-java/aspose.slides/exceldatacell/). Đối tượng này đại diện cho một ô duy nhất trong sổ làm việc Excel và cung cấp cho bạn quyền truy cập vào giá trị của nó một cách đơn giản và trực quan.

#### **Nhập biểu đồ Excel**

Bước tiếp theo để mở rộng chức năng là lớp [ExcelWorkbookImporter](https://reference.aspose.com/slides/vi/php-java/aspose.slides/excelworkbookimporter/). Lớp tiện ích này cung cấp chức năng nhập nội dung từ một sổ làm việc Excel vào bản trình chiếu. Nó chứa một số overload của phương thức [addChartFromWorkbook](https://reference.aspose.com/slides/vi/php-java/aspose.slides/excelworkbookimporter/#addChartFromWorkbook), giúp bạn lấy biểu đồ đã chọn từ sổ làm việc Excel được chỉ định và thêm nó vào cuối bộ sưu tập shape đã cho tại các tọa độ được chỉ định.

Tóm lại, đây là một API nhẹ và đơn giản để đọc dữ liệu Excel — chính xác những gì nhiều nhà phát triển cần mà không phải gánh nặng của một thư viện xử lý bảng tính đầy đủ.

## **Hãy cùng viết mã**

### **Ví dụ kịch bản Mail Merge**

Trong ví dụ sau, chúng ta sẽ thực hiện một kịch bản Mail Merge đơn giản bằng cách tạo nhiều bản trình chiếu dựa trên dữ liệu được lưu trong một sổ làm việc Excel.

Để bắt đầu, chúng ta cần hai thứ:
1. Một sổ làm việc Excel chứa dữ liệu

![Ví dụ dữ liệu Excel](example1_image0.png)

2. Mẫu bản trình chiếu PowerPoint

![Ví dụ mẫu PowerPoint](example1_image1.png)

```php
// Tải sổ làm việc Excel với dữ liệu nhân viên.
$workbook = new ExcelDataWorkbook("TemplateData.xlsx");
$worksheetIndex = 0;

// Tải mẫu bản trình chiếu.
$templatePresentation = new Presentation("PresentationTemplate.pptx");

try {
    // Lặp qua các hàng Excel (bỏ qua tiêu đề ở hàng 0).
    for ($rowIndex = 1; $rowIndex <= 4; $rowIndex++) {

        // Tạo một bản trình chiếu mới cho mỗi bản ghi nhân viên.
        $employeePresentation = new Presentation();

        try {
            // Xóa slide trống mặc định.
            $employeePresentation->getSlides()->removeAt(0);

            // Sao chép slide mẫu vào bản trình chiếu mới.
            $slide = $employeePresentation->getSlides()->addClone($templatePresentation->getSlides()->get_Item(0));

            // Lấy các đoạn văn từ shape mục tiêu (giả sử shape có chỉ mục 1 được dùng).
            $paragraphs = $slide->getShapes()->get_Item(1)->getTextFrame()->getParagraphs();

            // Thay thế các placeholder bằng dữ liệu từ Excel.
            $employeeName = $workbook->getCell($worksheetIndex, $rowIndex, 0)->getValue()->toString();
            $namePortion = $paragraphs->get_Item(0)->getPortions()->get_Item(0);
            $namePortion->setText($namePortion->getText()->replace("{{EmployeeName}}", $employeeName));

            $department = $workbook->getCell($worksheetIndex, $rowIndex, 1)->getValue()->toString();
            $departmentPortion = $paragraphs->get_Item(1)->getPortions()->get_Item(0);
            $departmentPortion->setText($departmentPortion->getText()->replace("{{Department}}", $department));

            $yearsOfService = $workbook->getCell($worksheetIndex, $rowIndex, 2)->getValue()->toString();
            $yearsPortion = $paragraphs->get_Item(2)->getPortions()->get_Item(0);
            $yearsPortion->setText($yearsPortion->getText()->replace("{{YearsOfService}}", $yearsOfService));

            // Lưu bản trình chiếu cá nhân hoá vào một tệp riêng.
            $employeePresentation->save(sprintf("%s Report.pptx", $employeeName), SaveFormat::Pptx);
        } finally {
            $employeePresentation->dispose();
        }
    }
} finally {
    $templatePresentation->dispose();
}
```

![Kết quả](example1_image2.png)

### **Ví dụ bảng Excel**

Trong ví dụ thứ hai, chúng ta chỉ đơn giản sao chép dữ liệu từ một bảng Excel và hiển thị nó trên một slide PowerPoint theo định dạng hấp dẫn hơn về mặt trực quan.

Trong ví dụ này, chúng ta tái sử dụng cùng một sổ làm việc Excel từ ví dụ đầu tiên, trong đó chứa một bảng nhân viên đơn giản.

```php
// Tải sổ làm việc Excel chứa dữ liệu nhân viên.
$workbook = new ExcelDataWorkbook("TemplateData.xlsx");
$worksheetIndex = 0;

// Tạo một bản trình chiếu PowerPoint mới.
$presentation = new Presentation();

try {
    // Thêm shape bảng vào slide đầu tiên.
    $table = $presentation->getSlides()->get_Item(0)->getShapes()->addTable(
            50, 200,
            array(200, 200, 200),
            array(30, 30, 30, 30, 30)
    );

    // Điền bảng PowerPoint bằng dữ liệu từ sổ làm việc Excel.
    for ($rowIndex = 0; $rowIndex < 5; $rowIndex++) {
        for ($columnIndex = 0; $columnIndex < 3; $columnIndex++) {
            $cellValue = $workbook->getCell($worksheetIndex, $rowIndex, $columnIndex)->getValue()->toString();
            $table->getColumns()->get_Item($columnIndex)->get_Item($rowIndex)->getTextFrame()->setText($cellValue);
        }
    }

    // Lưu bản trình chiếu kết quả vào tệp.
    $presentation->save("Table.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

![Kết quả](example2_image0.png)

### **Ví dụ nhập biểu đồ Excel**

Trong ví dụ này, chúng ta nhập một biểu đồ từ worksheet đầu tiên của sổ làm việc Excel đã dùng trong ví dụ trước. Biểu đồ sẽ được liên kết tới sổ làm việc bên ngoài trong bản trình chiếu kết quả.

Đầu tiên, chúng ta thêm một biểu đồ Pie vào sổ làm việc Excel dựa trên bảng nhân viên.

![Ví dụ biểu đồ Excel](example3_image0.png)

```php
// Tạo một bản trình chiếu PowerPoint mới.
$presentation = new Presentation();
try {
    // Lấy bộ sưu tập shape của slide đầu tiên.
    $shapes = $presentation->getSlides()->get_Item(0)->getShapes();

    // Nhập biểu đồ có tên "Chart 1" từ sheet đầu tiên của sổ làm việc và thêm nó vào bộ sưu tập shape.
    ExcelWorkbookImporter::addChartFromWorkbook($shapes, 10, 10, "TemplateData.xlsx", "Sheet1", "Chart 1", false);

    // Lưu bản trình chiếu kết quả vào tệp.
    $presentation->save("Chart.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

![Kết quả](example3_image1.png)

### **Ví dụ nhập tất cả biểu đồ Excel**

Hãy tưởng tượng bạn có một sổ làm việc Excel chứa đầy các biểu đồ và bạn cần nhập tất cả chúng vào một bản trình chiếu. Mỗi biểu đồ nên được đặt trên một slide mới.

Mã sau sẽ lặp qua tất cả các worksheet trong file Excel nguồn, trích xuất các biểu đồ từ mỗi worksheet và thêm mỗi biểu đồ vào một slide riêng biệt bằng cách sử dụng layout slide trống. Trong bản trình chiếu kết quả, chỉ dữ liệu biểu đồ sẽ được nhúng, không phải toàn bộ sổ làm việc.

```php
// Tải sổ làm việc Excel chứa dữ liệu nhân viên.
$workbook = new ExcelDataWorkbook("ExcelWithCharts.xlsx");

// Tạo một bản trình chiếu PowerPoint mới.
$presentation = new Presentation();
try {
    // Lấy bố cục slide trống.
    $blankLayout = $presentation->getLayoutSlides()->getByType(SlideLayoutType::Blank);

    // Lấy tên của tất cả các worksheet có trong sổ làm việc Excel.
    $worksheetNames = $workbook->getWorksheetNames()->iterator();

    while (java_values($worksheetNames->hasNext())) {
        $name = $worksheetNames->next();
        // Lấy một bản đồ ánh xạ chỉ số biểu đồ tới tên biểu đồ cho worksheet.
        $worksheetCharts = $workbook->getChartsFromWorksheet($name)->iterator();

        while (java_values($worksheetCharts->hasNext())) {
            $chart = $worksheetCharts->next();
            // Thêm một slide mới sử dụng bố cục trống.
            $slide = $presentation->getSlides()->addEmptySlide($blankLayout);

            // Nhập biểu đồ đã chỉ định từ sổ làm việc Excel vào bộ sưu tập shape của slide.
            ExcelWorkbookImporter::addChartFromWorkbook(
                    $slide->getShapes(), 10, 10, $workbook, $name, $chart->getKey(), false);
        }
    }

    // Lưu bản trình chiếu kết quả vào tệp.
    $presentation->save("Charts.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Tóm tắt**

Cơ chế này, có sẵn trực tiếp trong Aspose.Slides, kết hợp việc làm việc với dữ liệu Excel và bản trình chiếu trong một nơi. Nó cho phép bạn tạo các slide với biểu đồ trực quan và dữ liệu được trình bày dưới dạng bảng Excel — mà không cần bất kỳ thư viện bổ sung hay tích hợp phức tạp nào.