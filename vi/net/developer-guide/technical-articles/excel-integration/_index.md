---
title: Tích hợp dữ liệu Excel vào bản thuyết trình PowerPoint
linktitle: Tích hợp Excel
type: docs
weight: 330
url: /vi/net/excel-integration/
aliases:
  - /net/developer-guide/technical-articles/excel-integration/
keywords:
- Excel
- sổ làm việc
- đọc Excel
- tích hợp Excel
- nguồn dữ liệu
- gửi thư trộn
- nhập bảng
- Excel vào PowerPoint
- PowerPoint
- bản thuyết trình
- .NET
- C#
- Aspose.Slides
description: "Đọc dữ liệu từ sổ làm việc Excel trong Aspose.Slides bằng API ExcelDataWorkbook. Tải các sheet và ô và sử dụng giá trị để tạo bản thuyết trình PowerPoint dựa trên dữ liệu."
---
## **Giới thiệu**

Các bài thuyết trình PowerPoint là một cách mạnh mẽ để hiển thị và truyền đạt thông tin. Chúng thường được sử dụng kết hợp với các workbook Excel, trong đó Excel là nguồn dữ liệu có cấu trúc tuyệt vời và PowerPoint xuất sắc trong việc trực quan hoá dữ liệu đó cho khán giả.

Có rất nhiều kịch bản thực tế mà việc kết hợp Excel và PowerPoint là thiết yếu: mail merge, điền dữ liệu vào bảng, tạo một slide cho mỗi bản ghi dữ liệu (tạo slide hàng loạt), tạo tài liệu đào tạo, và hợp nhất nhiều báo cáo Excel thành một bản thuyết trình duy nhất, chỉ kể vài ví dụ.

Cho đến nay, việc triển khai các tính năng này với API Aspose.Slides yêu cầu dựa vào các giải pháp bên thứ ba như Aspose.Cells. Mặc dù các công cụ này mạnh mẽ, chúng có thể quá phức tạp và tốn kém cho người dùng chỉ cần chức năng tích hợp dữ liệu cơ bản.

## **Cách hoạt động**

Để làm việc với dữ liệu Excel dễ dàng và gọn gàng hơn, Aspose.Slides đã giới thiệu các lớp mới để đọc dữ liệu từ workbook Excel và nhập nội dung vào một bản thuyết trình. Tính năng này mở ra những khả năng mới mạnh mẽ cho người dùng API muốn tận dụng Excel như một nguồn dữ liệu trong quy trình làm việc với slide.

Chức năng mới được thiết kế cho việc truy cập dữ liệu mục đích chung và không được tích hợp vào Presentation Document Object Model (DOM). Điều đó có nghĩa là *nó không cho phép chỉnh sửa hoặc lưu file Excel* — mục đích duy nhất của nó là mở workbook và duyệt qua nội dung để lấy dữ liệu ô.

Trọng tâm của tính năng này là lớp mới [ExcelDataWorkbook](https://reference.aspose.com/slides/vi/net/aspose.slides.excel/exceldataworkbook/) . Lớp này cho phép bạn tải một workbook Excel từ tệp cục bộ hoặc luồng. Khi đã tải, nó cung cấp một số overload của phương thức [GetCell](https://reference.aspose.com/slides/vi/net/aspose.slides.excel/exceldataworkbook/getcell/) , mà bạn có thể dùng để lấy các ô cụ thể theo vị trí (ví dụ: chỉ số hàng và cột hoặc phạm vi có tên).

Mỗi lần gọi [GetCell](https://reference.aspose.com/slides/vi/net/aspose.slides.excel/exceldataworkbook/getcell/) sẽ trả về một thể hiện của lớp [ExcelDataCell](https://reference.aspose.com/slides/vi/net/aspose.slides.excel/exceldatacell/) . Đối tượng này đại diện cho một ô duy nhất trong workbook Excel và cung cấp cho bạn truy cập tới giá trị của ô một cách đơn giản và trực quan.

#### **Nhập biểu đồ Excel**

Bước tiếp theo để mở rộng chức năng là lớp [ExcelWorkbookImporter](https://reference.aspose.com/slides/vi/net/aspose.slides.import/excelworkbookimporter/) . Lớp tiện ích này cung cấp chức năng nhập nội dung từ một workbook Excel vào một bản thuyết trình. Nó chứa một số overload của phương thức [AddChartFromWorkbook](https://reference.aspose.com/slides/vi/net/aspose.slides.import/excelworkbookimporter/addchartfromworkbook/) , giúp bạn lấy biểu đồ đã chọn từ workbook Excel được chỉ định và thêm nó vào cuối bộ sưu tập shape cho trước tại tọa độ đã chỉ định.

#### **Nhập bảng Excel**

Lớp [ExcelWorkbookImporter](https://reference.aspose.com/slides/vi/net/aspose.slides.import/excelworkbookimporter/) cũng chứa một số overload của phương thức [AddTableFromWorkbook](https://reference.aspose.com/slides/vi/net/aspose.slides.import/excelworkbookimporter/addtablefromworkbook/) . Các phương thức này cho phép bạn nhập một phạm vi ô được chỉ định từ một worksheet được chỉ định và thêm nó dưới dạng bảng vào cuối bộ sưu tập shape cho trước tại tọa độ đã chỉ định.

Tóm lại, đây là một API nhẹ và đơn giản để đọc dữ liệu Excel — chính xác những gì nhiều nhà phát triển cần mà không phải chịu gánh nặng của một thư viện xử lý bảng tính đầy đủ.

## **Hãy lập trình**

### **Ví dụ kịch bản Mail Merge**

Trong ví dụ sau, chúng ta sẽ triển khai một kịch bản Mail Merge đơn giản bằng cách tạo nhiều bản thuyết trình dựa trên dữ liệu lưu trong một workbook Excel.

Để bắt đầu, chúng ta cần hai thứ:
1. Một workbook Excel chứa dữ liệu

![Ví dụ dữ liệu Excel](example1_image0.png)

2.  Mẫu bản thuyết trình PowerPoint

![Ví dụ mẫu PowerPoint](example1_image1.png)

```csharp
// Tải workbook Excel chứa dữ liệu nhân viên.
ExcelDataWorkbook workbook = new ExcelDataWorkbook("TemplateData.xlsx");
int worksheetIndex = 0;

// Tải mẫu bản thuyết trình.
using Presentation templatePresentation = new Presentation("PresentationTemplate.pptx");

// Lặp qua các hàng Excel (loại trừ tiêu đề ở hàng 0).
for (int rowIndex = 1; rowIndex <= 4; rowIndex++)
{
    // Tạo một bản thuyết trình mới cho mỗi bản ghi nhân viên.
    using Presentation employeePresentation = new Presentation();

    // Xóa slide trống mặc định.
    employeePresentation.Slides.RemoveAt(0);

    // Sao chép slide mẫu vào bản thuyết trình mới.
    ISlide slide = employeePresentation.Slides.AddClone(templatePresentation.Slides[0]);

    // Lấy các đoạn văn từ shape mục tiêu (giả sử sử dụng shape có chỉ số 1).
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

    // Lưu bản thuyết trình cá nhân hoá vào một tệp riêng.
    employeePresentation.Save($"{employeeName} Report.pptx", SaveFormat.Pptx);
}
```

![Kết quả](example1_image2.png)

### **Ví dụ bảng Excel**

Trong ví dụ thứ hai, chúng ta chỉ sao chép dữ liệu từ một bảng Excel và hiển thị nó trên một slide PowerPoint theo dạng trực quan hơn.

Trong ví dụ này, chúng ta tái sử dụng cùng một workbook Excel từ ví dụ đầu tiên, chứa một bảng nhân viên đơn giản.

```csharp
// Tải workbook Excel chứa dữ liệu nhân viên.
ExcelDataWorkbook workbook = new ExcelDataWorkbook("TemplateData.xlsx");
int worksheetIndex = 0;

// Tạo một bản thuyết trình PowerPoint mới.
using Presentation presentation = new Presentation();

// Thêm shape bảng vào slide đầu tiên.
ITable table = presentation.Slides[0].Shapes.AddTable(
    50, 200,
    new double[] { 200, 200, 200 },
    new double[] { 30, 30, 30, 30, 30 }
);

// Điền dữ liệu từ workbook Excel vào bảng PowerPoint.
for (int rowIndex = 0; rowIndex < 5; rowIndex++)
{
    for (int columnIndex = 0; columnIndex < 3; columnIndex++)
    {
        string cellValue = workbook.GetCell(worksheetIndex, rowIndex, columnIndex).Value.ToString();
        table[columnIndex, rowIndex].TextFrame.Text = cellValue;
    }
}

// Lưu bản thuyết trình đã tạo ra vào tệp.
presentation.Save("Table.pptx", SaveFormat.Pptx);
```

![Kết quả](example2_image0.png)

### **Ví dụ nhập biểu đồ Excel**

Trong ví dụ này, chúng ta nhập một biểu đồ từ worksheet đầu tiên của workbook Excel đã dùng trong ví dụ trước. Biểu đồ sẽ liên kết tới workbook bên ngoài trong bản thuyết trình kết quả.

Đầu tiên, chúng ta thêm một biểu đồ Pie vào workbook Excel dựa trên bảng nhân viên.

![Ví dụ biểu đồ Excel](example3_image0.png)

```csharp
// Tạo một bản thuyết trình PowerPoint mới.
using Presentation presentation = new Presentation();

// Get the shapes collection of the first slide.
IShapeCollection shapes = presentation.Slides[0].Shapes;

// Import the chart named "Chart 1" from the first sheet of the workbook and add it to the shapes collection.
ExcelWorkbookImporter.AddChartFromWorkbook(shapes, 10, 10, "TemplateData.xlsx", "Sheet1", "Chart 1", false);

// Lưu bản thuyết trình đã tạo ra vào tệp.
presentation.Save("Chart.pptx", SaveFormat.Pptx);
```
![Kết quả](example3_image1.png)

### **Ví dụ nhập tất cả biểu đồ Excel**

Hãy tưởng tượng bạn có một workbook Excel đầy biểu đồ và bạn cần nhập tất cả chúng vào một bản thuyết trình. Mỗi biểu đồ sẽ được đặt trên một slide mới.

Đoạn mã dưới đây duyệt qua tất cả các worksheet trong file Excel nguồn, trích xuất các biểu đồ từ mỗi worksheet, và thêm mỗi biểu đồ vào một slide riêng bằng cách sử dụng bố cục slide trống. Trong bản thuyết trình kết quả, chỉ dữ liệu biểu đồ sẽ được nhúng, không phải toàn bộ workbook.

```csharp
// Tải workbook Excel chứa dữ liệu nhân viên.
ExcelDataWorkbook workbook = new ExcelDataWorkbook("ExcelWithCharts.xlsx");

// Tạo một bản thuyết trình PowerPoint mới.
using Presentation presentation = new Presentation();

// Lấy bố cục slide trống.
ILayoutSlide blankLayout = presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);

// Lấy tên của tất cả các worksheet có trong workbook Excel.
IList<string> worksheetNames = workbook.GetWorksheetNames();

foreach (var name in worksheetNames)
{
    // Lấy một từ điển ánh xạ chỉ số biểu đồ sang tên biểu đồ cho worksheet.
    IDictionary<int, string> worksheetCharts = workbook.GetChartsFromWorksheet(name);
    foreach (var chart in worksheetCharts)
    {
        // Thêm một slide mới sử dụng bố cục trống.
        ISlide slide = presentation.Slides.AddEmptySlide(blankLayout);

        // Nhập biểu đồ đã chỉ định từ workbook Excel vào bộ sưu tập shape của slide.
        ExcelWorkbookImporter.AddChartFromWorkbook(slide.Shapes, 10, 10, workbook, name, chart.Key, false);
    }
}

// Lưu bản thuyết trình đã tạo ra vào tệp.
presentation.Save("Charts.pptx", SaveFormat.Pptx);
```

### **Ví dụ nhập bảng Excel**

Trong ví dụ này, chúng ta nhập một bảng đã định dạng từ một worksheet Excel trực tiếp vào bản thuyết trình PowerPoint.

Worksheet Excel nguồn chứa một bảng đã định dạng với dữ liệu nhân viên:

![Ví dụ bảng Excel](example4_image0.png)

```csharp
// Tạo một bản thuyết trình PowerPoint mới.
using Presentation presentation = new Presentation();

// Lấy bộ sưu tập shape của slide đầu tiên.
IShapeCollection shapes = presentation.Slides[0].Shapes;

// Nhập bảng từ sheet đầu tiên của workbook và thêm nó vào bộ sưu tập shape.
ExcelWorkbookImporter.AddTableFromWorkbook(shapes, 10, 10, "TemplateData.xlsx", "Sheet1", "A1:C5");

// Lưu bản thuyết trình đã tạo ra vào tệp.
presentation.Save("FormattedTable.pptx", SaveFormat.Pptx);
```

![Kết quả](example4_image1.png)


## **Tóm tắt**

Cơ chế này, có sẵn trực tiếp trong Aspose.Slides, kết hợp việc làm việc với dữ liệu Excel và bản thuyết trình trong một nơi. Nó cho phép bạn tạo slide với biểu đồ trực quan và dữ liệu được trình bày dưới dạng bảng Excel — mà không cần thư viện bổ sung hay tích hợp phức tạp.