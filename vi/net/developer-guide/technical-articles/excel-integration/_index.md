---
title: Tích hợp dữ liệu Excel vào bản trình bày PowerPoint
linktitle: Tích hợp Excel
type: docs
weight: 330
url: /vi/net/excel-integration/
keywords:
- Excel
- sổ làm việc
- đọc Excel
- tích hợp Excel
- nguồn dữ liệu
- mail merge
- nhập bảng
- Excel vào PowerPoint
- PowerPoint
- bản trình bày
- .NET
- C#
- Aspose.Slides
description: "Đọc dữ liệu từ sổ làm việc Excel trong Aspose.Slides bằng API ExcelDataWorkbook. Tải các sheet và ô và sử dụng giá trị để tạo bản trình bày PowerPoint dựa trên dữ liệu."
---
## **Introduction**

Các bản trình bày PowerPoint là một cách mạnh mẽ để hiển thị và truyền đạt thông tin. Chúng thường được sử dụng cùng với các sổ làm việc Excel, trong đó Excel là nguồn dữ liệu có cấu trúc tuyệt vời và PowerPoint xuất sắc trong việc trực quan hóa dữ liệu đó cho khán giả.

Có nhiều tình huống thực tế mà việc kết hợp Excel và PowerPoint là cần thiết: mail merge, điền dữ liệu vào bảng, tạo một slide cho mỗi bản ghi dữ liệu (tạo slide hàng loạt), tạo tài liệu đào tạo, và hợp nhất nhiều báo cáo Excel thành một bản trình bày duy nhất, chỉ kể vài ví dụ.

Trước đây, việc triển khai các tính năng này với API Aspose.Slides đòi hỏi phải dựa vào các giải pháp của bên thứ ba như Aspose.Cells. Mặc dù các công cụ này mạnh mẽ, chúng có thể quá phức tạp và tốn kém đối với người dùng chỉ cần chức năng tích hợp dữ liệu cơ bản.

## **How It Works**

Để làm việc với dữ liệu Excel dễ dàng và thuận lợi hơn, Aspose.Slides đã giới thiệu các lớp mới để đọc dữ liệu từ sổ làm việc Excel và nhập nội dung vào một bản trình bày. Tính năng này mở ra những khả năng mạnh mẽ mới cho người dùng API muốn tận dụng Excel làm nguồn dữ liệu trong quy trình làm việc trình chiếu.

Chức năng mới được thiết kế cho việc truy cập dữ liệu chung và không được tích hợp vào Presentation Document Object Model (DOM). Điều đó có nghĩa là *nó không cho phép chỉnh sửa hoặc lưu các tệp Excel* — mục đích duy nhất của nó là mở sổ làm việc và duyệt qua nội dung để lấy dữ liệu ô.

Trọng tâm của tính năng này là lớp mới [ExcelDataWorkbook](https://reference.aspose.com/slides/vi/net/aspose.slides.excel/exceldataworkbook/) . Lớp này cho phép bạn tải một sổ làm việc Excel từ tệp cục bộ hoặc luồng. Khi đã tải, nó cung cấp một số overload của phương thức [GetCell](https://reference.aspose.com/slides/vi/net/aspose.slides.excel/exceldataworkbook/getcell/) , cho phép bạn lấy các ô cụ thể theo vị trí (ví dụ: chỉ số hàng và cột hoặc phạm vi có tên).

Mỗi lần gọi [GetCell](https://reference.aspose.com/slides/vi/net/aspose.slides.excel/exceldataworkbook/getcell/) sẽ trả về một thể hiện của lớp [ExcelDataCell](https://reference.aspose.com/slides/vi/net/aspose.slides.excel/exceldatacell/) . Đối tượng này đại diện cho một ô duy nhất trong sổ làm việc Excel và cung cấp cho bạn cách truy cập giá trị của nó một cách đơn giản và trực quan.

#### **Import an Excel Chart**

Bước tiếp theo để mở rộng chức năng là lớp [ExcelWorkbookImporter](https://reference.aspose.com/slides/vi/net/aspose.slides.import/excelworkbookimporter/) . Lớp tiện ích này cung cấp khả năng nhập nội dung từ một sổ làm việc Excel vào bản trình bày. Nó chứa một số overload của phương thức [AddChartFromWorkbook](https://reference.aspose.com/slides/vi/net/aspose.slides.import/excelworkbookimporter/addchartfromworkbook/) , giúp bạn lấy biểu đồ đã chọn từ sổ làm việc Excel được chỉ định và thêm nó vào cuối bộ sưu tập shape được cho tại các tọa độ chỉ định.

Tóm lại, đây là một API nhẹ và đơn giản để đọc dữ liệu Excel — chính xác những gì nhiều nhà phát triển cần mà không phải chịu gánh nặng của một thư viện xử lý bảng tính đầy đủ.

## **Let's Code**

### **Mail Merge Scenario Example**

Trong ví dụ sau, chúng ta sẽ triển khai một kịch bản Mail Merge đơn giản bằng cách tạo nhiều bản trình bày dựa trên dữ liệu lưu trong một sổ làm việc Excel.

Để bắt đầu, chúng ta cần hai thứ:
1. Một sổ làm việc Excel chứa dữ liệu

![Excel data example](example1_image0.png)

2.  Mẫu bản trình bày PowerPoint

![PowerPoint template example](example1_image1.png)

```csharp
// Tải sổ làm việc Excel với dữ liệu nhân viên.
ExcelDataWorkbook workbook = new ExcelDataWorkbook("TemplateData.xlsx");
int worksheetIndex = 0;

// Tải mẫu bản trình bày.
using Presentation templatePresentation = new Presentation("PresentationTemplate.pptx");

// Lặp qua các dòng Excel (ngoại trừ tiêu đề ở dòng 0).
for (int rowIndex = 1; rowIndex <= 4; rowIndex++)
{
    // Tạo bản trình bày mới cho mỗi bản ghi nhân viên.
    using Presentation employeePresentation = new Presentation();

    // Xóa slide trống mặc định.
    employeePresentation.Slides.RemoveAt(0);

    // Sao chép slide mẫu vào bản trình bày mới.
    ISlide slide = employeePresentation.Slides.AddClone(templatePresentation.Slides[0]);

    // Lấy các đoạn văn từ shape mục tiêu (giả sử shape có chỉ số 1 được sử dụng).
    IParagraphCollection paragraphs = (slide.Shapes[1] as IAutoShape).TextFrame.Paragraphs;

    // Thay thế các placeholder bằng dữ liệu từ Excel.
    string employeeName = workbook.GetCell(worksheetIndex, rowIndex, 0).Value.ToString();
    IPortion namePortion = paragraphs[0].Portions[0];
    namePortion.Text = namePortion.Text.Replace("{{EmployeeName}}", employeeName);

    string department = workbook.GetCell(worksheetIndex, rowIndex, 1).Value.ToString();
    IPortion departmentPortion = paragraphs[1].Portions[0];
    departmentPortion.Text = departmentPortion.Text.Replace("{{Department}}", department);

    string yearsOfService = workbook.GetCell(worksheetIndex, rowIndex, 2).Value.ToString();
    IPortion yearsPortion = paragraphs[2].Portions[0];
    yearsPortion.Text = yearsPortion.Text.Replace("{{YearsOfService}}", yearsOfService);

    // Lưu bản trình bày cá nhân hoá vào một tệp riêng.
    employeePresentation.Save($"{employeeName} Report.pptx", SaveFormat.Pptx);
}
```

![Result](example1_image2.png)

### **Excel Table Example**

Trong ví dụ thứ hai, chúng ta chỉ sao chép dữ liệu từ một bảng Excel và hiển thị nó trên một slide PowerPoint theo định dạng hấp dẫn hơn.

Trong ví dụ này, chúng ta tái sử dụng cùng một sổ làm việc Excel từ ví dụ đầu tiên, trong đó chứa một bảng nhân viên đơn giản.

```csharp
// Tải sổ làm việc Excel chứa dữ liệu nhân viên.
ExcelDataWorkbook workbook = new ExcelDataWorkbook("TemplateData.xlsx");
int worksheetIndex = 0;

// Tạo một bản trình bày PowerPoint mới.
using Presentation presentation = new Presentation();

// Thêm một shape bảng vào slide đầu tiên.
ITable table = presentation.Slides[0].Shapes.AddTable(
    50, 200,
    new double[] { 200, 200, 200 },
    new double[] { 30, 30, 30, 30, 30 }
);

// Điền dữ liệu từ sổ làm việc Excel vào bảng PowerPoint.
for (int rowIndex = 0; rowIndex < 5; rowIndex++)
{
    for (int columnIndex = 0; columnIndex < 3; columnIndex++)
    {
        string cellValue = workbook.GetCell(worksheetIndex, rowIndex, columnIndex).Value.ToString();
        table[columnIndex, rowIndex].TextFrame.Text = cellValue;
    }
}

// Lưu bản trình bày kết quả vào một tệp.
presentation.Save("Table.pptx", SaveFormat.Pptx);
```

![Result](example2_image0.png)

### **Import an Excel Chart Example**

Trong ví dụ này, chúng ta nhập một biểu đồ từ worksheet đầu tiên của sổ làm việc Excel đã dùng trong ví dụ trước. Biểu đồ sẽ liên kết tới sổ làm việc bên ngoài trong bản trình bày kết quả.

Đầu tiên, chúng ta thêm một biểu đồ Pie vào sổ làm việc Excel dựa trên bảng nhân viên.

![Excel Chart example](example3_image0.png)

```csharp
// Tạo một bản trình bày PowerPoint mới.
using Presentation presentation = new Presentation();

// Lấy bộ sưu tập shape của slide đầu tiên.
IShapeCollection shapes = presentation.Slides[0].Shapes;

// Nhập biểu đồ có tên "Chart 1" từ sheet đầu tiên của sổ làm việc và thêm nó vào bộ sưu tập shape.
ExcelWorkbookImporter.AddChartFromWorkbook(shapes, 10, 10, "TemplateData.xlsx", "Sheet1", "Chart 1", false);

// Lưu bản trình bày kết quả vào một tệp.
presentation.Save("Chart.pptx", SaveFormat.Pptx);
```
![Result](example3_image1.png)

### **Import All Excel Charts Example**

Hãy tưởng tượng bạn có một sổ làm việc Excel đầy các biểu đồ và bạn cần nhập tất cả chúng vào một bản trình bày. Mỗi biểu đồ sẽ được đặt trên một slide mới.

Mã sau duyệt qua tất cả các worksheet trong tệp Excel nguồn, trích xuất các biểu đồ từ mỗi worksheet, và thêm mỗi biểu đồ vào một slide riêng biệt bằng cách sử dụng bố cục slide trống. Trong bản trình bày kết quả, chỉ dữ liệu biểu đồ sẽ được nhúng, không phải toàn bộ sổ làm việc.

```csharp
// Tải sổ làm việc Excel chứa dữ liệu nhân viên.
ExcelDataWorkbook workbook = new ExcelDataWorkbook("ExcelWithCharts.xlsx");

// Tạo một bản trình bày PowerPoint mới.
using Presentation presentation = new Presentation();

// Lấy bố cục slide trống.
ILayoutSlide blankLayout = presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);

// Lấy tên của tất cả các worksheet có trong sổ làm việc Excel.
IList<string> worksheetNames = workbook.GetWorksheetNames();

foreach (var name in worksheetNames)
{
    // Lấy một từ điển ánh xạ chỉ số biểu đồ sang tên biểu đồ cho worksheet.
    IDictionary<int, string> worksheetCharts = workbook.GetChartsFromWorksheet(name);
    foreach (var chart in worksheetCharts)
    {
        // Thêm một slide mới sử dụng bố cục trống.
        ISlide slide = presentation.Slides.AddEmptySlide(blankLayout);

        // Nhập biểu đồ được chỉ định từ sổ làm việc Excel vào bộ sưu tập shape của slide.
        ExcelWorkbookImporter.AddChartFromWorkbook(slide.Shapes, 10, 10, workbook, name, chart.Key, false);
    }
}

// Lưu bản trình bày kết quả vào một tệp.
presentation.Save("Charts.pptx", SaveFormat.Pptx);
```

## **Summary**

Cơ chế này, có sẵn trực tiếp trong Aspose.Slides, kết hợp việc làm việc với dữ liệu Excel và bản trình bày trong một nơi. Nó cho phép bạn tạo slide với biểu đồ trực quan và dữ liệu được trình bày dưới dạng bảng Excel — mà không cần bất kỳ thư viện bổ sung hay tích hợp phức tạp nào.