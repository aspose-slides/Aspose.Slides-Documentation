---
title: Tích hợp dữ liệu Excel vào các bản trình bày PowerPoint
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
- ghép thư
- nhập bảng
- Excel vào PowerPoint
- PowerPoint
- bản trình bày
- .NET
- C#
- Aspose.Slides
description: "Đọc dữ liệu từ sổ làm việc Excel trong Aspose.Slides bằng API ExcelDataWorkbook. Tải các sheet và ô, sau đó sử dụng giá trị để tạo các bản trình bày PowerPoint dựa trên dữ liệu."
---
## **Giới thiệu**

PowerPoint là một công cụ mạnh mẽ để hiển thị và truyền đạt thông tin. Nó thường được sử dụng cùng với các sổ làm việc Excel, trong đó Excel đóng vai trò là nguồn dữ liệu có cấu trúc tuyệt vời và PowerPoint xuất sắc trong việc trực quan hoá dữ liệu đó cho khán giả.

Có rất nhiều kịch bản thực tế mà việc kết hợp Excel và PowerPoint là thiết yếu: ghép thư, điền dữ liệu vào bảng, tạo một slide cho mỗi bản ghi dữ liệu (tạo slide theo lô), tạo tài liệu đào tạo và hợp nhất nhiều báo cáo Excel vào một bản trình bày duy nhất, v.v.

Cho đến nay, việc triển khai các tính năng này bằng Aspose.Slides API yêu cầu dựa vào các giải pháp của bên thứ ba như Aspose.Cells. Mặc dù các công cụ này mạnh mẽ, chúng có thể quá phức tạp và tốn kém đối với người dùng chỉ cần chức năng tích hợp dữ liệu cơ bản.

## **Cách hoạt động**

Để làm việc với dữ liệu Excel dễ dàng và hiệu quả hơn, Aspose.Slides đã giới thiệu các lớp mới để đọc dữ liệu từ sổ làm việc Excel và nhập nội dung vào bản trình bày. Tính năng này mở ra những khả năng mạnh mẽ mới cho người dùng API muốn sử dụng Excel như một nguồn dữ liệu trong quy trình tạo slide.

Tính năng mới được thiết kế cho việc truy cập dữ liệu đa mục đích và không được tích hợp vào Presentation Document Object Model (DOM). Điều này có nghĩa là *nó không cho phép chỉnh sửa hoặc lưu tệp Excel* — mục đích duy nhất của nó là mở sổ làm việc và duyệt nội dung để lấy dữ liệu ô.

Ở trung tâm của tính năng này là lớp mới [ExcelDataWorkbook](https://reference.aspose.com/slides/vi/net/aspose.slides.excel/exceldataworkbook/) . Lớp này cho phép bạn tải một sổ Excel từ tệp cục bộ hoặc luồng. Khi đã tải, nó cung cấp một số overload của phương thức [GetCell](https://reference.aspose.com/slides/vi/net/aspose.slides.excel/exceldataworkbook/getcell/) mà bạn có thể sử dụng để lấy các ô cụ thể dựa trên vị trí của chúng (ví dụ: chỉ số hàng và cột hoặc phạm vi có tên).

Mỗi lần gọi [GetCell](https://reference.aspose.com/slides/vi/net/aspose.slides.excel/exceldataworkbook/getcell/) sẽ trả về một thể hiện của lớp [ExcelDataCell](https://reference.aspose.com/slides/vi/net/aspose.slides.excel/exceldatacell/) . Đối tượng này đại diện cho một ô duy nhất trong sổ Excel và cung cấp cho bạn cách truy cập giá trị của nó một cách đơn giản và trực quan.

#### **Nhập biểu đồ Excel**

Bước tiếp theo để mở rộng chức năng là lớp [ExcelWorkbookImporter](https://reference.aspose.com/slides/vi/net/aspose.slides.import/excelworkbookimporter/) . Lớp tiện ích này cung cấp chức năng nhập nội dung từ sổ Excel vào bản trình bày. Nó chứa một số overload của phương thức [AddChartFromWorkbook](https://reference.aspose.com/slides/vi/net/aspose.slides.import/excelworkbookimporter/addchartfromworkbook/) , giúp bạn lấy biểu đồ đã chọn từ sổ Excel chỉ định và thêm nó vào cuối bộ sưu tập shape được cho tại các tọa độ xác định.

#### **Nhập bảng Excel**

Lớp [ExcelWorkbookImporter](https://reference.aspose.com/slides/vi/net/aspose.slides.import/excelworkbookimporter/) cũng chứa một số overload của phương thức [AddTableFromWorkbook](https://reference.aspose.com/slides/vi/net/aspose.slides.import/excelworkbookimporter/addtablefromworkbook/) . Những phương thức này cho phép bạn nhập một phạm vi ô được chỉ định từ một worksheet được chỉ định và thêm nó như một bảng vào cuối bộ sưu tập shape tại các tọa độ xác định.

Tóm lại, đây là một API nhẹ và đơn giản để đọc dữ liệu Excel — chính xác những gì nhiều nhà phát triển cần mà không phải chịu gánh nặng của một thư viện xử lý bảng tính đầy đủ.

## **Hãy cùng lập trình**

### **Ví dụ kịch bản Ghép thư**

Trong ví dụ dưới đây, chúng ta sẽ triển khai một kịch bản Ghép thư đơn giản bằng cách tạo nhiều bản trình bày dựa trên dữ liệu lưu trong một sổ Excel.

Để bắt đầu, chúng ta cần hai thứ:
1. Một sổ Excel chứa dữ liệu

![Ví dụ dữ liệu Excel](example1_image0.png)

2. Mẫu bản trình bày PowerPoint

![Ví dụ mẫu PowerPoint](example1_image1.png)

```csharp
// Tải sổ Excel chứa dữ liệu nhân viên.
ExcelDataWorkbook workbook = new ExcelDataWorkbook("TemplateData.xlsx");
int worksheetIndex = 0;

// Tải mẫu bản trình bày.
using Presentation templatePresentation = new Presentation("PresentationTemplate.pptx");

// Lặp qua các hàng Excel (bỏ qua tiêu đề ở hàng 0).
for (int rowIndex = 1; rowIndex <= 4; rowIndex++)
{
    // Tạo một bản trình bày mới cho mỗi bản ghi nhân viên.
    using Presentation employeePresentation = new Presentation();

    // Xóa slide trống mặc định.
    employeePresentation.Slides.RemoveAt(0);

    // Nhân bản slide mẫu vào bản trình bày mới.
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

![Kết quả](example1_image2.png)

### **Ví dụ bảng Excel**

Trong ví dụ thứ hai, chúng ta chỉ sao chép dữ liệu từ một bảng Excel và hiển thị nó trên một slide PowerPoint theo định dạng hấp dẫn hơn về mặt hình ảnh.

Trong ví dụ này, chúng ta tái sử dụng cùng một sổ Excel từ ví dụ đầu tiên, trong đó chứa một bảng nhân viên đơn giản.

```csharp
// Tải sổ Excel chứa dữ liệu nhân viên.
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

// Đổ dữ liệu từ sổ Excel vào bảng PowerPoint.
for (int rowIndex = 0; rowIndex < 5; rowIndex++)
{
    for (int columnIndex = 0; columnIndex < 3; columnIndex++)
    {
        string cellValue = workbook.GetCell(worksheetIndex, rowIndex, columnIndex).Value.ToString();
        table[columnIndex, rowIndex].TextFrame.Text = cellValue;
    }
}

// Lưu bản trình bày kết quả vào tệp.
presentation.Save("Table.pptx", SaveFormat.Pptx);
```

![Kết quả](example2_image0.png)

### **Ví dụ nhập biểu đồ Excel**

Trong ví dụ này, chúng ta nhập một biểu đồ từ worksheet đầu tiên của sổ Excel được sử dụng trong ví dụ trước. Biểu đồ sẽ liên kết tới sổ làm việc bên ngoài trong bản trình bày kết quả.

Đầu tiên, chúng ta thêm một biểu đồ Pie vào sổ Excel dựa trên bảng nhân viên.

![Ví dụ biểu đồ Excel](example3_image0.png)

```csharp
// Tạo một bản trình bày PowerPoint mới.
using Presentation presentation = new Presentation();

// Lấy bộ sưu tập shapes của slide đầu tiên.
IShapeCollection shapes = presentation.Slides[0].Shapes;

// Nhập biểu đồ có tên "Chart 1" từ sheet đầu tiên của sổ làm việc và thêm nó vào bộ sưu tập shapes.
ExcelWorkbookImporter.AddChartFromWorkbook(shapes, 10, 10, "TemplateData.xlsx", "Sheet1", "Chart 1", false);

// Lưu bản trình bày kết quả vào tệp.
presentation.Save("Chart.pptx", SaveFormat.Pptx);
```
![Kết quả](example3_image1.png)

### **Ví dụ nhập tất cả biểu đồ Excel**

Hãy tưởng tượng bạn có một sổ Excel đầy các biểu đồ và bạn cần nhập tất cả chúng vào một bản trình bày. Mỗi biểu đồ nên được đặt trên một slide mới.

Mã dưới đây duyệt qua tất cả các worksheet trong tệp Excel nguồn, trích xuất các biểu đồ từ mỗi worksheet và thêm mỗi biểu đồ vào một slide riêng biệt bằng bố cục slide trống. Trong bản trình bày kết quả, chỉ dữ liệu biểu đồ sẽ được nhúng, không phải toàn bộ sổ làm việc.

```csharp
// Tải sổ Excel chứa dữ liệu nhân viên.
ExcelDataWorkbook workbook = new ExcelDataWorkbook("ExcelWithCharts.xlsx");

// Tạo một bản trình bày PowerPoint mới.
using Presentation presentation = new Presentation();

// Lấy bố cục slide trống.
ILayoutSlide blankLayout = presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);

// Lấy danh sách tên tất cả các worksheet có trong sổ Excel.
IList<string> worksheetNames = workbook.GetWorksheetNames();

foreach (var name in worksheetNames)
{
    // Lấy một từ điển ánh xạ chỉ số biểu đồ sang tên biểu đồ cho worksheet.
    IDictionary<int, string> worksheetCharts = workbook.GetChartsFromWorksheet(name);
    foreach (var chart in worksheetCharts)
    {
        // Thêm một slide mới sử dụng bố cục trống.
        ISlide slide = presentation.Slides.AddEmptySlide(blankLayout);

        // Nhập biểu đồ được chỉ định từ sổ Excel vào bộ sưu tập shapes của slide.
        ExcelWorkbookImporter.AddChartFromWorkbook(slide.Shapes, 10, 10, workbook, name, chart.Key, false);
    }
}

// Lưu bản trình bày kết quả vào tệp.
presentation.Save("Charts.pptx", SaveFormat.Pptx);
```

### **Ví dụ nhập bảng Excel**

Trong ví dụ này, chúng ta nhập một bảng đã định dạng từ một worksheet Excel trực tiếp vào bản trình bày PowerPoint.

Worksheet Excel nguồn chứa một bảng đã định dạng với dữ liệu nhân viên:

![Ví dụ bảng Excel](example4_image0.png)

```csharp
// Tạo một bản trình bày PowerPoint mới.
using Presentation presentation = new Presentation();

// Lấy bộ sưu tập shapes của slide đầu tiên.
IShapeCollection shapes = presentation.Slides[0].Shapes;

// Nhập bảng từ sheet đầu tiên của sổ làm việc và thêm nó vào bộ sưu tập shapes.
ExcelWorkbookImporter.AddTableFromWorkbook(shapes, 10, 10, "TemplateData.xlsx", "Sheet1", "A1:C5");

// Lưu bản trình bày kết quả vào tệp.
presentation.Save("FormattedTable.pptx", SaveFormat.Pptx);
```
![Kết quả](example4_image1.png)

## **Tóm tắt**

Cơ chế này, có sẵn trực tiếp trong Aspose.Slides, kết hợp việc làm việc với dữ liệu Excel và bản trình bày ở một nơi. Nó cho phép bạn tạo slide với biểu đồ trực quan và dữ liệu được trình bày dưới dạng bảng Excel — mà không cần bất kỳ thư viện bổ sung hay tích hợp phức tạp nào.