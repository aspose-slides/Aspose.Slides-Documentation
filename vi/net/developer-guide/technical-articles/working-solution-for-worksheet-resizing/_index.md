---
title: Giải pháp hoạt động cho việc thay đổi kích thước bảng tính
type: docs
weight: 40
url: /vi/net/working-solution-for-worksheet-resizing/
keywords:
- OLE
- hình ảnh xem trước
- thay đổi kích thước ảnh
- Excel
- bảng tính
- PowerPoint
- bản thuyết trình
- .NET
- C#
- Aspose.Slides
description: "Khắc phục việc thay đổi kích thước OLE của bảng tính Excel trong bản thuyết trình: hai cách để giữ khung đối tượng nhất quán—điều chỉnh kích thước khung hoặc bảng tính—trên các định dạng PPT và PPTX."
---
{{% alert color="primary" %}} 

Đã được chứng minh rằng các bảng tính Excel được nhúng dưới dạng đối tượng OLE trong bản thuyết trình PowerPoint thông qua các thành phần Aspose bị thay đổi kích thước theo một tỷ lệ không xác định sau lần kích hoạt đầu tiên. Hành vi này tạo ra sự khác biệt về hình ảnh đáng chú ý trong bản thuyết trình giữa trạng thái trước và sau khi kích hoạt đối tượng OLE. Chúng tôi đã nghiên cứu chi tiết vấn đề này và đưa ra giải pháp, được trình bày trong bài viết này.

{{% /alert %}} 

## **Nền tảng**

Trong bài viết [Manage OLE](/slides/vi/net/manage-ole/), chúng tôi đã giải thích cách thêm một khung OLE vào bản thuyết trình PowerPoint bằng cách sử dụng Aspose.Slides cho .NET. Để giải quyết [object preview issue](/slides/vi/net/object-preview-issue-when-adding-oleobjectframe/), chúng tôi đã gán một hình ảnh của khu vực bảng tính đã chọn cho khung đối tượng OLE. Trong bản thuyết trình đầu ra, khi bạn nhấp đúp vào khung đối tượng OLE hiển thị hình ảnh bảng tính, sách làm việc Excel sẽ được kích hoạt. Người dùng cuối có thể thực hiện bất kỳ thay đổi nào mong muốn đối với sách làm việc Excel thực tế và sau đó trở lại slide bằng cách nhấp ra ngoài sách làm việc Excel đã kích hoạt. Kích thước của khung đối tượng OLE sẽ thay đổi khi người dùng trở lại slide. Hệ số thay đổi kích thước sẽ khác nhau tùy thuộc vào kích thước của khung OLE và sách làm việc Excel được nhúng. 

## **Nguyên nhân của việc thay đổi kích thước**

Vì sách làm việc Excel có kích thước cửa sổ riêng, nó cố gắng giữ nguyên kích thước gốc khi được kích hoạt lần đầu. Mặt khác, khung đối tượng OLE có kích thước riêng của nó. Theo Microsoft, khi sách làm việc Excel được kích hoạt, Excel và PowerPoint sẽ thương lượng kích thước để đảm bảo duy trì tỷ lệ đúng như một phần của quá trình nhúng. Việc thay đổi kích thước xảy ra dựa trên sự khác biệt giữa kích thước cửa sổ Excel và kích thước và vị trí của khung đối tượng OLE. 

## **Giải pháp hoạt động**

Có hai giải pháp khả thi để tránh hiệu ứng thay đổi kích thước.

- Điều chỉnh kích thước khung OLE trong bản thuyết trình PowerPoint để khớp với chiều cao và chiều rộng của số hàng và cột mong muốn trong khung OLE.  
- Giữ kích thước khung OLE cố định và điều chỉnh kích thước của các hàng và cột tham gia sao cho phù hợp với kích thước khung OLE đã chọn.  

### **Điều chỉnh kích thước khung OLE**

Trong cách tiếp cận này, chúng ta sẽ học cách đặt kích thước khung OLE của sách làm việc Excel được nhúng để khớp với kích thước tổng hợp của các hàng và cột tham gia trong bảng tính Excel.  

Giả sử chúng ta có một bảng tính Excel mẫu và muốn thêm nó vào bản thuyết trình dưới dạng khung OLE. Trong trường hợp này, kích thước của khung đối tượng OLE sẽ được tính toán ban đầu dựa trên tổng chiều cao các hàng và chiều rộng các cột của các hàng và cột tham gia trong sách làm việc. Sau đó, chúng ta sẽ đặt kích thước của khung OLE thành giá trị đã tính toán này. Để tránh thông báo màu đỏ "EMBEDDED OLE OBJECT" cho khung OLE trong PowerPoint, chúng ta cũng sẽ chụp một hình ảnh của các vùng hàng và cột mong muốn trong sách làm việc và đặt nó làm hình ảnh khung OLE.  

```cs
int startRow = 0, rowCount = 10;
int startColumn = 0, columnCount = 13;
int worksheetIndex = 0;

int imageResolution = 96;

using var workbook = new Aspose.Cells.Workbook("sample.xlsx");
var worksheet = workbook.Worksheets[worksheetIndex];

// Set the displayed size when the workbook file is used as an OLE object in PowerPoint.
var lastRow = startRow + rowCount - 1;
var lastColumn = startColumn + columnCount - 1;
workbook.Worksheets.SetOleSize(startRow, lastRow, startColumn, lastColumn);

var cellRange = worksheet.Cells.CreateRange(startRow, startColumn, rowCount, columnCount);
var imageStream = CreateOleImage(cellRange, imageResolution);

// Get the width and height of the OLE image in points.
using var image = Image.FromStream(imageStream);
var imageWidth = image.Width * 72 / imageResolution;
var imageHeight = image.Height * 72 / imageResolution;

// We need to use the modified workbook.
using var oleStream = new MemoryStream();
workbook.Save(oleStream, Aspose.Cells.SaveFormat.Xlsx);

using var presentation = new Presentation();
var slide = presentation.Slides.First();

// Add the OLE image to the presentation resources.
imageStream.Seek(0, SeekOrigin.Begin);
var oleImage = presentation.Images.AddImage(imageStream);

// Create the OLE object frame.
var dataInfo = new OleEmbeddedDataInfo(oleStream.ToArray(), "xlsx");
var oleFrame = slide.Shapes.AddOleObjectFrame(10, 10, imageWidth, imageHeight, dataInfo);
oleFrame.SubstitutePictureFormat.Picture.Image = oleImage;
oleFrame.IsObjectIcon = false;

presentation.Save("output.pptx", SaveFormat.Pptx);
```

```cs
static MemoryStream CreateOleImage(Aspose.Cells.Range cellRange, int imageResolution)
{
    var pageSetup = cellRange.Worksheet.PageSetup;
    pageSetup.PrintArea = cellRange.Address;
    pageSetup.LeftMargin = 0;
    pageSetup.RightMargin = 0;
    pageSetup.TopMargin = 0;
    pageSetup.BottomMargin = 0;
    pageSetup.ClearHeaderFooter();

    var imageOptions = new Aspose.Cells.Rendering.ImageOrPrintOptions
    {
        ImageType = Aspose.Cells.Drawing.ImageType.Png,
        VerticalResolution = imageResolution,
        HorizontalResolution = imageResolution,
        OnePagePerSheet = true,
        OnlyArea = true
    };

    var sheetRender = new Aspose.Cells.Rendering.SheetRender(cellRange.Worksheet, imageOptions);
    var imageStream = new MemoryStream();

    sheetRender.ToImage(0, imageStream);
    imageStream.Seek(0, SeekOrigin.Begin);

    return imageStream;
}
```

### **Điều chỉnh kích thước phạm vi ô**

Trong cách tiếp cận này, chúng ta sẽ học cách điều chỉnh chiều cao của các hàng tham gia và chiều rộng của các cột tham gia để khớp với kích thước khung OLE tùy chỉnh.  

Giả sử chúng ta có một bảng tính Excel mẫu và muốn thêm nó vào bản thuyết trình dưới dạng khung OLE. Trong trường hợp này, chúng ta sẽ đặt kích thước của khung OLE và điều chỉnh kích thước của các hàng và cột tham gia vào khu vực khung OLE. Sau đó, chúng ta sẽ lưu sách làm việc vào một luồng để áp dụng các thay đổi và chuyển đổi nó thành mảng byte để thêm vào khung OLE. Để tránh thông báo màu đỏ "EMBEDDED OLE OBJECT" cho khung OLE trong PowerPoint, chúng ta cũng sẽ chụp một hình ảnh của các vùng hàng và cột mong muốn trong sách làm việc và đặt nó làm hình ảnh khung OLE.  

```cs
int startRow = 0, rowCount = 10;
int startColumn = 0, columnCount = 13;
int worksheetIndex = 0;

int imageResolution = 96;
float frameWidth = 400, frameHeight = 100;

using var workbook = new Aspose.Cells.Workbook("sample.xlsx");
var worksheet = workbook.Worksheets[worksheetIndex];

// Thiết lập kích thước hiển thị khi tệp workbook được sử dụng làm đối tượng OLE trong PowerPoint.
var lastRow = startRow + rowCount - 1;
var lastColumn = startColumn + columnCount - 1;
workbook.Worksheets.SetOleSize(startRow, lastRow, startColumn, lastColumn);

// Điều chỉnh phạm vi ô để vừa khung kích thước.
var cellRange = worksheet.Cells.CreateRange(startRow, startColumn, rowCount, columnCount);
ScaleCellRange(cellRange, frameWidth, frameHeight);

var imageStream = CreateOleImage(cellRange, imageResolution);

// Chúng ta cần sử dụng workbook đã được chỉnh sửa.
using var oleStream = new MemoryStream();
workbook.Save(oleStream, Aspose.Cells.SaveFormat.Xlsx);

using var presentation = new Presentation();
var slide = presentation.Slides.First();

// Thêm hình ảnh OLE vào tài nguyên của bản thuyết trình.
var oleImage = presentation.Images.AddImage(imageStream);

// Tạo khung đối tượng OLE.
var dataInfo = new OleEmbeddedDataInfo(oleStream.ToArray(), "xlsx");
var oleFrame = slide.Shapes.AddOleObjectFrame(10, 10, frameWidth, frameHeight, dataInfo);
oleFrame.SubstitutePictureFormat.Picture.Image = oleImage;
oleFrame.IsObjectIcon = false;

presentation.Save("output.pptx", SaveFormat.Pptx);
```

```cs
/// <param name="width">Chiều rộng dự kiến của phạm vi ô tính bằng điểm.</param>
/// <param name="height">Chiều cao dự kiến của phạm vi ô tính bằng điểm.</param>
static void ScaleCellRange(Aspose.Cells.Range cellRange, float width, float height)
{
    var rangeWidth = cellRange.Width;
    var rangeHeight = cellRange.Height;

    for (int i = 0; i < cellRange.ColumnCount; i++)
    {
        var columnIndex = cellRange.FirstColumn + i;
        var columnWidth = cellRange.Worksheet.Cells.GetColumnWidth(columnIndex, false, Aspose.Cells.CellsUnitType.Point);

        var newColumnWidth = columnWidth * width / rangeWidth;
        var widthInInches = newColumnWidth / 72;
        cellRange.Worksheet.Cells.SetColumnWidthInch(columnIndex, widthInInches);
    }

    for (int i = 0; i < cellRange.RowCount; i++)
    {
        var rowIndex = cellRange.FirstRow + i;
        var rowHeight = cellRange.Worksheet.Cells.GetRowHeight(rowIndex, false, Aspose.Cells.CellsUnitType.Point);

        var newRowHeight = rowHeight * height / rangeHeight;
        var heightInInches = newRowHeight / 72;
        cellRange.Worksheet.Cells.SetRowHeightInch(rowIndex, heightInInches);
    }
}
```

```cs
static Stream CreateOleImage(Aspose.Cells.Range cellRange, int imageResolution)
{
    var pageSetup = cellRange.Worksheet.PageSetup;
    pageSetup.PrintArea = cellRange.Address;
    pageSetup.LeftMargin = 0;
    pageSetup.RightMargin = 0;
    pageSetup.TopMargin = 0;
    pageSetup.BottomMargin = 0;
    pageSetup.ClearHeaderFooter();

    var imageOptions = new Aspose.Cells.Rendering.ImageOrPrintOptions
    {
        ImageType = Aspose.Cells.Drawing.ImageType.Png,
        VerticalResolution = imageResolution,
        HorizontalResolution = imageResolution,
        OnePagePerSheet = true,
        OnlyArea = true
    };

    var sheetRender = new Aspose.Cells.Rendering.SheetRender(cellRange.Worksheet, imageOptions);
    var imageStream = new MemoryStream();

    sheetRender.ToImage(0, imageStream);
    imageStream.Seek(0, SeekOrigin.Begin);

    return imageStream;
}
```

## **Kết luận**

{{% alert color="primary" %}}

Có hai cách tiếp cận để khắc phục vấn đề thay đổi kích thước bảng tính. Lựa chọn cách tiếp cận phù hợp phụ thuộc vào yêu cầu và trường hợp sử dụng cụ thể. Cả hai cách đều hoạt động tương tự, bất kể bản thuyết trình được tạo từ mẫu hay từ đầu. Ngoài ra, không có giới hạn nào về kích thước của khung đối tượng OLE trong giải pháp này.

{{% /alert %}}

## **FAQ**

**Tại sao một bảng tính Excel được nhúng lại thay đổi kích thước khi lần đầu tiên được kích hoạt trong PowerPoint?**  
Điều này xảy ra vì Excel cố gắng duy trì kích thước cửa sổ gốc khi được kích hoạt, trong khi khung đối tượng OLE trong PowerPoint có kích thước riêng. PowerPoint và Excel sẽ thương lượng kích thước để duy trì tỷ lệ khung hình, điều này có thể gây ra việc thay đổi kích thước.  

**Liệu có thể ngăn hoàn toàn vấn đề thay đổi kích thước này không?**  
Có. Bằng cách điều chỉnh kích thước khung OLE sao cho phù hợp với kích thước phạm vi ô Excel hoặc điều chỉnh phạm vi ô sao cho phù hợp với kích thước khung OLE mong muốn, bạn có thể ngăn ngừa việc thay đổi kích thước không mong muốn.  

**Phương pháp điều chỉnh nào nên sử dụng, điều chỉnh khung OLE hay điều chỉnh phạm vi ô?**  
Chọn **OLE frame scaling** nếu bạn muốn giữ nguyên kích thước hàng và cột gốc của Excel. Chọn **cell range scaling** nếu bạn muốn khung OLE trong bản thuyết trình có kích thước cố định.  

**Liệu các giải pháp này có hoạt động nếu bản thuyết trình của tôi dựa trên mẫu không?**  
Có. Cả hai giải pháp đều hoạt động cho các bản thuyết trình được tạo từ mẫu và từ đầu.  

**Có giới hạn nào đối với kích thước khung OLE khi sử dụng các phương pháp này không?**  
Không. Bạn có thể làm khung đối tượng OLE bất kỳ kích thước nào miễn là bạn đặt tỷ lệ phù hợp.  

**Có cách nào để tránh văn bản chỗ giữ chỗ "EMBEDDED OLE OBJECT" trong PowerPoint không?**  
Có. Bằng cách chụp ảnh nhanh của phạm vi ô Excel mục tiêu và đặt nó làm hình ảnh chỗ giữ chỗ cho khung OLE, bạn có thể hiển thị một hình ảnh xem trước tùy chỉnh thay cho chỗ giữ chỗ mặc định.  

## **Bài viết liên quan**

[Creating an Excel Chart and Embedding It in a Presentation as an OLE Object](/slides/vi/net/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)

[Updating OLE Objects Automatically Using an MS PowerPoint Add-In](/slides/vi/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)