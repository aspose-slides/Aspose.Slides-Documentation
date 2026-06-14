---
title: Tích hợp dữ liệu Excel vào bản trình bày PowerPoint
linktitle: Tích hợp Excel
type: docs
weight: 330
url: /vi/cpp/excel-integration/
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
- bản trình bày
- C++
- Aspose.Slides
description: "Đọc dữ liệu từ các sổ làm việc Excel trong Aspose.Slides bằng API ExcelDataWorkbook. Tải các sheet và ô, sau đó sử dụng giá trị để tạo các bản trình bày PowerPoint dựa trên dữ liệu."
---
## **Giới thiệu**

Bản trình bày PowerPoint là một cách mạnh mẽ để hiển thị và truyền đạt thông tin. Chúng thường được sử dụng cùng với sổ làm việc Excel, trong đó Excel là nguồn dữ liệu có cấu trúc tuyệt vời và PowerPoint xuất sắc trong việc trực quan hóa dữ liệu đó cho khán giả.

Có rất nhiều kịch bản thực tiễn mà việc kết hợp Excel và PowerPoint là thiết yếu: mail merge, điền dữ liệu vào bảng, tạo một slide cho mỗi bản ghi dữ liệu (tạo slide hàng loạt), tạo tài liệu đào tạo, và hợp nhất nhiều báo cáo Excel thành một bản trình bày, chỉ kể một vài.

Trước đây, việc triển khai các tính năng này với API Aspose.Slides đòi hỏi phải dựa vào các giải pháp bên thứ ba như Aspose.Cells. Mặc dù các công cụ này mạnh mẽ, chúng có thể quá phức tạp và tốn kém đối với người dùng chỉ cần chức năng tích hợp dữ liệu cơ bản.

## **Cách hoạt động**

Để làm việc với dữ liệu Excel dễ dàng và suôn sẻ hơn, Aspose.Slides đã giới thiệu các lớp mới để đọc dữ liệu từ sổ làm việc Excel và nhập nội dung vào bản trình bày. Tính năng này mở ra những khả năng mạnh mẽ cho người dùng API muốn sử dụng Excel như một nguồn dữ liệu trong quy trình làm việc với bản trình bày.

Chức năng mới được thiết kế cho việc truy cập dữ liệu tổng quát và không được tích hợp vào Mô hình Đối tượng Tài liệu (DOM) của Presentation. Điều đó có nghĩa là *nó không cho phép chỉnh sửa hoặc lưu tệp Excel* — mục đích duy nhất của nó là mở sổ làm việc và duyệt nội dung để lấy dữ liệu ô.

Trọng tâm của tính năng này là lớp mới [ExcelDataWorkbook](https://reference.aspose.com/slides/vi/cpp/aspose.slides.excel/exceldataworkbook/). Lớp này cho phép bạn tải một sổ làm việc Excel từ tệp cục bộ hoặc luồng. Sau khi tải, nó cung cấp một số overload của phương thức [GetCell](https://reference.aspose.com/slides/vi/cpp/aspose.slides.excel/exceldataworkbook/getcell/), mà bạn có thể dùng để lấy các ô cụ thể theo vị trí (ví dụ: chỉ số hàng và cột hoặc tên vùng).

Mỗi lần gọi [GetCell](https://reference.aspose.com/slides/vi/cpp/aspose.slides.excel/exceldataworkbook/getcell/) sẽ trả về một instance của lớp [ExcelDataCell](https://reference.aspose.com/slides/vi/cpp/aspose.slides.excel/exceldatacell/). Đối tượng này đại diện cho một ô duy nhất trong sổ làm việc Excel và cung cấp cho bạn truy cập giá trị của nó một cách đơn giản và trực quan.

#### **Nhập biểu đồ Excel**

Bước tiếp theo để mở rộng chức năng là lớp [ExcelWorkbookImporter](https://reference.aspose.com/slides/vi/cpp/aspose.slides.import/excelworkbookimporter/). Lớp tiện ích này cung cấp khả năng nhập nội dung từ một sổ làm việc Excel vào bản trình bày. Nó chứa một số overload của phương thức [AddChartFromWorkbook](https://reference.aspose.com/slides/vi/cpp/aspose.slides.import/excelworkbookimporter/addchartfromworkbook/), giúp bạn lấy biểu đồ đã chọn từ sổ làm việc Excel được chỉ định và thêm nó vào cuối bộ sưu tập shape đã cho tại tọa độ xác định.

Tóm lại, đây là một API nhẹ và đơn giản để đọc dữ liệu Excel — chính xác những gì nhiều nhà phát triển cần mà không phải chịu gánh nặng của một thư viện xử lý bảng tính đầy đủ.

## **Hãy cùng code**

### **Ví dụ kịch bản Mail Merge**

Trong ví dụ sau, chúng ta sẽ triển khai một kịch bản Mail Merge đơn giản bằng cách tạo nhiều bản trình bày dựa trên dữ liệu lưu trong một sổ làm việc Excel.

Để bắt đầu, chúng ta cần hai thứ:
1. Một sổ làm việc Excel chứa dữ liệu

![Ví dụ dữ liệu Excel](example1_image0.png)

2. Mẫu bản trình bày PowerPoint

![Ví dụ mẫu PowerPoint](example1_image1.png)

```cpp
// Tải sổ làm việc Excel chứa dữ liệu nhân viên.
auto workbook = MakeObject<ExcelDataWorkbook>(u"TemplateData.xlsx");
auto worksheetIndex = 0;

// Tải mẫu bản trình bày.
auto templatePresentation = MakeObject<Presentation>(u"PresentationTemplate.pptx");

    // Lặp qua các dòng Excel (bỏ qua tiêu đề ở dòng 0).
for (auto rowIndex = 1; rowIndex <= 4; rowIndex++) {

    // Tạo một bản trình bày mới cho mỗi bản ghi nhân viên.
    auto employeePresentation = MakeObject<Presentation>();

    // Xóa slide trống mặc định.
    employeePresentation->get_Slides()->RemoveAt(0);

    // Sao chép slide mẫu vào bản trình bày mới.
    auto slide = employeePresentation->get_Slides()->AddClone(templatePresentation->get_Slide(0));

    // Lấy các đoạn văn từ shape mục tiêu (giả sử shape có chỉ số 1 được sử dụng).
    auto paragraphs = ExplicitCast<IAutoShape>(slide->get_Shape(1))->get_TextFrame()->get_Paragraphs();

    // Thay thế các placeholder bằng dữ liệu từ Excel.
    auto employeeName = workbook->GetCell(worksheetIndex, rowIndex, 0)->get_Value()->ToString();
    auto namePortion = paragraphs->idx_get(0)->get_Portion(0);
    namePortion->set_Text(namePortion->get_Text().Replace(u"{{EmployeeName}}", employeeName));

    auto department = workbook->GetCell(worksheetIndex, rowIndex, 1)->get_Value()->ToString();
    auto departmentPortion = paragraphs->idx_get(1)->get_Portion(0);
    departmentPortion->set_Text(departmentPortion->get_Text().Replace(u"{{Department}}", department));

    auto yearsOfService = workbook->GetCell(worksheetIndex, rowIndex, 2)->get_Value()->ToString();
    auto yearsPortion = paragraphs->idx_get(2)->get_Portion(0);
    yearsPortion->set_Text(yearsPortion->get_Text().Replace(u"{{YearsOfService}}", yearsOfService));

    // Lưu bản trình bày cá nhân hoá vào một tệp riêng.
    employeePresentation->Save(String::Format(u"{0} Report.pptx", employeeName), SaveFormat::Pptx);
    employeePresentation->Dispose();
}

templatePresentation->Dispose();
```

![Kết quả](example1_image2.png)

### **Ví dụ bảng Excel**

Trong ví dụ thứ hai, chúng ta chỉ đơn giản sao chép dữ liệu từ một bảng Excel và hiển thị nó trên một slide PowerPoint theo định dạng hấp dẫn hơn.

Trong ví dụ này, chúng ta sử dụng lại cùng một sổ làm việc Excel từ ví dụ đầu tiên, chứa một bảng nhân viên đơn giản.

```cpp
// Tải sổ làm việc Excel chứa dữ liệu nhân viên.
auto workbook = MakeObject<ExcelDataWorkbook>(u"TemplateData.xlsx");
auto worksheetIndex = 0;

// Tạo một bản trình bày PowerPoint mới.
auto presentation = MakeObject<Presentation>();

// Thêm một shape bảng vào slide đầu tiên.
auto table = presentation->get_Slide(0)->get_Shapes()->AddTable(
    50, 200,
    MakeArray<double>({200, 200, 200}),
    MakeArray<double>({30, 30, 30, 30, 30})
);

// Điền dữ liệu từ sổ làm việc Excel vào bảng PowerPoint.
for (auto rowIndex = 0; rowIndex < 5; rowIndex++) {
    for (auto columnIndex = 0; columnIndex < 3; columnIndex++) {
        auto cellValue = workbook->GetCell(worksheetIndex, rowIndex, columnIndex)->get_Value()->ToString();
        table->get_Column(columnIndex)->idx_get(rowIndex)->get_TextFrame()->set_Text(cellValue);
    }
}

// Lưu bản trình bày kết quả vào tệp.
presentation->Save(u"Table.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

![Kết quả](example2_image0.png)

### **Ví dụ nhập biểu đồ Excel**

Trong ví dụ này, chúng ta nhập một biểu đồ từ bảng tính đầu tiên của sổ làm việc Excel đã dùng trong ví dụ trước. Biểu đồ sẽ liên kết tới sổ làm việc bên ngoài trong bản trình bày kết quả.

Đầu tiên, chúng ta thêm một biểu đồ Pie vào sổ làm việc Excel dựa trên bảng nhân viên.

![Ví dụ biểu đồ Excel](example3_image0.png)

```cpp
// Tạo một bản trình bày PowerPoint mới.
auto presentation = MakeObject<Presentation>();

// Lấy bộ sưu tập shape của slide đầu tiên.
auto shapes = presentation->get_Slide(0)->get_Shapes();

// Nhập biểu đồ có tên "Chart 1" từ sheet đầu tiên của sổ làm việc và thêm vào bộ sưu tập shape.
ExcelWorkbookImporter::AddChartFromWorkbook(shapes, 10.0, 10.0, u"TemplateData.xlsx", u"Sheet1", u"Chart 1", false);

// Lưu bản trình bày kết quả vào tệp.
presentation->Save(u"Chart.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

![Kết quả](example3_image1.png)

### **Ví dụ nhập tất cả biểu đồ Excel**

Hãy tưởng tượng bạn có một sổ làm việc Excel đầy các biểu đồ và cần nhập toàn bộ chúng vào một bản trình bày. Mỗi biểu đồ sẽ được đặt trên một slide mới.

Mã sau sẽ duyệt qua tất cả các worksheet trong tệp Excel nguồn, trích xuất các biểu đồ từ mỗi worksheet và thêm mỗi biểu đồ vào một slide riêng biệt bằng bố cục slide trống. Trong bản trình bày kết quả, chỉ dữ liệu biểu đồ sẽ được nhúng, không phải toàn bộ sổ làm việc.

```cpp
// Tải sổ làm việc Excel chứa dữ liệu nhân viên.
auto workbook = MakeObject<ExcelDataWorkbook>(u"ExcelWithCharts.xlsx");

// Tạo một bản trình bày PowerPoint mới.
auto presentation = MakeObject<Presentation>();

// Lấy bố cục slide trống.
auto blankLayout = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);

// Lấy tên của tất cả các worksheet có trong sổ làm việc Excel.
auto worksheetNames = workbook->GetWorksheetNames();

for (auto&& name : worksheetNames)
{
    // Lấy một dictionary ánh xạ chỉ số biểu đồ tới tên biểu đồ cho worksheet.
    auto worksheetCharts = workbook->GetChartsFromWorksheet(name);

    for (auto&& chart : worksheetCharts)
    {
        // Thêm một slide mới sử dụng bố cục trống.
        auto slide = presentation->get_Slides()->AddEmptySlide(blankLayout);

        // Nhập biểu đồ được chỉ định từ sổ làm việc Excel vào bộ sưu tập shape của slide.
        ExcelWorkbookImporter::AddChartFromWorkbook(slide->get_Shapes(), 10.0, 10.0, workbook, name, chart.get_Key(), false);
    }
}

// Lưu bản trình bày kết quả vào tệp.
presentation->Save(u"Charts.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Tóm tắt**

Cơ chế này, có sẵn trực tiếp trong Aspose.Slides, kết hợp việc làm việc với dữ liệu Excel và bản trình bày trong một nơi. Nó cho phép bạn tạo slide với biểu đồ trực quan và dữ liệu được trình bày dưới dạng bảng Excel — mà không cần bất kỳ thư viện phụ trợ hay tích hợp phức tạp nào.