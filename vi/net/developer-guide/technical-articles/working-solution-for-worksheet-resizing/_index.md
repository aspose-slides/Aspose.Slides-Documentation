---
title: Giải pháp thực tế cho việc thay đổi kích thước trang tính
type: docs
weight: 40
url: /vi/net/working-solution-for-worksheet-resizing/
keywords:
- OLE
- hình ảnh xem trước
- thay đổi kích thước hình ảnh
- Excel
- trang tính
- PowerPoint
- presentation
- .NET
- C#
- Aspose.Slides
description: "Sửa việc thay đổi kích thước OLE của trang tính Excel trong bản thuyết trình: hai cách để giữ khung đối tượng nhất quán—phóng to khung hoặc bảng tính—trên các định dạng PPT và PPTX."
---
{{% alert color="info" title="Note" %}}

Các trang tính Excel được nhúng dưới dạng đối tượng OLE trong bản thuyết trình PowerPoint bằng các thành phần Aspose có thể thay đổi kích thước một cách không mong muốn sau lần kích hoạt đầu tiên. Hành vi này tạo ra sự khác biệt về hình ảnh đáng chú ý giữa đối tượng OLE trước và sau khi kích hoạt. Bài viết này giải thích vấn đề và mô tả hai cách khắc phục.

{{% /alert %}} 

## **Bối cảnh**

Trong bài viết [Quản lý OLE](/slides/vi/net/manage-ole/), chúng tôi đã giải thích cách thêm khung OLE vào bản thuyết trình PowerPoint bằng Aspose.Slides for .NET. Để giải quyết [vấn đề xem trước đối tượng](/slides/vi/net/object-preview-issue-when-adding-oleobjectframe/), chúng tôi đã gán một hình ảnh của vùng trang tính đã chọn cho khung đối tượng OLE. Trong bản thuyết trình xuất ra, khi bạn nhấp đúp vào khung OLE hiển thị hình ảnh trang tính, workbook Excel sẽ được kích hoạt. Người dùng cuối có thể thực hiện bất kỳ thay đổi nào mong muốn trên workbook Excel thực tế và sau đó quay lại slide bằng cách nhấp ra ngoài workbook Excel đã kích hoạt. Kích thước của khung OLE sẽ thay đổi khi người dùng quay lại slide. Hệ số thay đổi kích thước sẽ khác nhau tùy thuộc vào kích thước của khung OLE và workbook Excel được nhúng. 

## **Nguyên nhân của việc thay đổi kích thước**

Vì workbook Excel có kích thước cửa sổ riêng, nó cố gắng giữ nguyên kích thước gốc khi được kích hoạt lần đầu. Ngược lại, khung OLE cũng có kích thước của riêng nó. Theo Microsoft, khi workbook Excel được kích hoạt, Excel và PowerPoint sẽ thương lượng kích thước để đảm bảo duy trì tỷ lệ đúng như một phần của quá trình nhúng. Việc thay đổi kích thước xảy ra dựa trên sự khác biệt giữa kích thước cửa sổ Excel và kích thước cũng như vị trí của khung OLE. 

## **Giải pháp thực tế**

Có hai giải pháp khả thi để tránh hiệu ứng thay đổi kích thước.

- Phóng to khung OLE trong bản thuyết trình PowerPoint để khớp với tổng chiều cao và chiều rộng của các hàng và cột đã chọn.  
- Giữ kích thước khung OLE cố định và phóng to các hàng và cột đã chọn để vừa với nó.  

### **Phóng to kích thước khung OLE**

Cách tiếp cận này đặt kích thước khung OLE sao cho khớp với tổng chiều cao và chiều rộng của các hàng và cột đã chọn trong trang tính Excel được nhúng.

Ví dụ tải một workbook Excel hiện có và chọn 10 hàng đầu tiên và 13 cột đầu tiên của worksheet đầu tiên bằng chỉ mục bắt đầu từ 0. [WorksheetCollection.SetOleSize](https://reference.aspose.com/cells/net/aspose.cells/worksheetcollection/setolesize/) xác định phạm vi hiển thị. Bản xem trước được tạo ở 96 DPI và kích thước pixel của nó được chuyển sang points dùng 72 points mỗi inch. [ShapeCollection.AddOleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/shapecollection/addoleobjectframe/) nhúng workbook đã chỉnh sửa vào một khung với các kích thước đó. Bản xem trước được gán thông qua [OleObjectFrame.SubstitutePictureFormat](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe/substitutepictureformat/) để thay thế chỗ giữ chỗ "EMBEDDED OLE OBJECT" trong bản thuyết trình đã lưu.

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.DOM.Ole;
using Aspose.Slides.Export;

int startRow = 0, rowCount = 10;
int startColumn = 0, columnCount = 13;
int worksheetIndex = 0;

int imageResolution = 96;

using var workbook = new Aspose.Cells.Workbook("sample.xlsx");
var worksheet = workbook.Worksheets[worksheetIndex];

// Đặt kích thước hiển thị khi tệp workbook được sử dụng làm đối tượng OLE trong PowerPoint.
var lastRow = startRow + rowCount - 1;
var lastColumn = startColumn + columnCount - 1;
workbook.Worksheets.SetOleSize(startRow, lastRow, startColumn, lastColumn);

var cellRange = worksheet.Cells.CreateRange(startRow, startColumn, rowCount, columnCount);
var imageStream = CreateOleImage(cellRange, imageResolution);

// Lấy chiều rộng và chiều cao của hình ảnh OLE tính bằng points.
using var image = Image.FromStream(imageStream);
var imageWidth = image.Width * 72 / imageResolution;
var imageHeight = image.Height * 72 / imageResolution;

// Cần phải sử dụng workbook đã sửa đổi.
using var oleStream = new MemoryStream();
workbook.Save(oleStream, Aspose.Cells.SaveFormat.Xlsx);

using var presentation = new Presentation();
var slide = presentation.Slides.First();

// Thêm hình ảnh OLE vào tài nguyên của bản thuyết trình.
imageStream.Seek(0, SeekOrigin.Begin);
var oleImage = presentation.Images.AddImage(imageStream);

// Tạo khung đối tượng OLE.
var dataInfo = new OleEmbeddedDataInfo(oleStream.ToArray(), "xlsx");
var oleFrame = slide.Shapes.AddOleObjectFrame(10, 10, imageWidth, imageHeight, dataInfo);
oleFrame.SubstitutePictureFormat.Picture.Image = oleImage;
oleFrame.IsObjectIcon = false;

presentation.Save("output.pptx", SaveFormat.Pptx);
```

Trợ giúp preview đặt [PageSetup.PrintArea](https://reference.aspose.com/cells/net/aspose.cells/pagesetup/printarea/) thành phạm vi đã chọn và loại bỏ lề, đầu trang và chân trang. Với [ImageOrPrintOptions.OnlyArea](https://reference.aspose.com/cells/net/aspose.cells.rendering/imageorprintoptions/onlyarea/) được bật, [SheetRender.ToImage](https://reference.aspose.com/cells/net/aspose.cells.rendering/sheetrender/toimage/) tạo ra phạm vi dưới dạng hình PNG. Trợ giúp này quay lại vị trí đầu của luồng hình ảnh trước khi trả về để sử dụng trong bản thuyết trình.

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

### **Phóng to kích thước vùng ô**

Cách tiếp cận này phóng to chiều cao của các hàng đã chọn và chiều rộng của các cột đã chọn để khớp với một khung OLE tùy chỉnh.

Ví dụ tải một workbook Excel hiện có và chọn 10 hàng đầu tiên và 13 cột đầu tiên của worksheet đầu tiên bằng chỉ mục bắt đầu từ 0. [WorksheetCollection.SetOleSize](https://reference.aspose.com/cells/net/aspose.cells/worksheetcollection/setolesize/) xác định phạm vi hiển thị, và trợ giúp bên dưới phóng to phạm vi đó để vừa với một khung rộng 400 points và cao 100 points. Sau khi lưu workbook đã chỉnh sửa vào một luồng, [ShapeCollection.AddOleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/shapecollection/addoleobjectframe/) nhúng nó với kích thước đã chỉ định. Một bản xem trước được tạo ở 96 DPI được gán thông qua [OleObjectFrame.SubstitutePictureFormat](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe/substitutepictureformat/), vì vậy bản thuyết trình đã lưu sẽ hiển thị các ô đã chọn thay vì chỗ giữ chỗ mặc định.

```cs
using Aspose.Slides;
using Aspose.Slides.DOM.Ole;
using Aspose.Slides.Export;

int startRow = 0, rowCount = 10;
int startColumn = 0, columnCount = 13;
int worksheetIndex = 0;

int imageResolution = 96;
float frameWidth = 400, frameHeight = 100;

using var workbook = new Aspose.Cells.Workbook("sample.xlsx");
var worksheet = workbook.Worksheets[worksheetIndex];

// Đặt kích thước hiển thị khi tệp workbook được sử dụng làm đối tượng OLE trong PowerPoint.
var lastRow = startRow + rowCount - 1;
var lastColumn = startColumn + columnCount - 1;
workbook.Worksheets.SetOleSize(startRow, lastRow, startColumn, lastColumn);

// Phóng to phạm vi ô để vừa với kích thước khung.
var cellRange = worksheet.Cells.CreateRange(startRow, startColumn, rowCount, columnCount);
ScaleCellRange(cellRange, frameWidth, frameHeight);

var imageStream = CreateOleImage(cellRange, imageResolution);

// Cần sử dụng workbook đã chỉnh sửa.
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

Trợ giúp scaling tính toán các tỷ lệ chiều rộng và chiều cao riêng cho phạm vi đã chọn, bảo toàn độ rộng tương đối của các cột và độ cao tương đối của các hàng. Nó chuyển đổi các kích thước đã tính từ points sang inches trước khi áp dụng chúng bằng [Cells.SetColumnWidthInch](https://reference.aspose.com/cells/net/aspose.cells/cells/setcolumnwidthinch/) và [Cells.SetRowHeightInch](https://reference.aspose.com/cells/net/aspose.cells/cells/setrowheightinch/). Phạm vi đã chọn phải có độ rộng và độ cao khác 0.

```cs
/// <param name="width">Chiều rộng mong muốn của phạm vi ô tính bằng points.</param>
/// <param name="height">Chiều cao mong muốn của phạm vi ô tính bằng points.</param>
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

Trợ giúp preview này tạo ra phạm vi đã thay đổi kích thước bằng cách sử dụng [SheetRender.ToImage](https://reference.aspose.com/cells/net/aspose.cells.rendering/sheetrender/toimage/). Nó giới hạn [PageSetup.PrintArea](https://reference.aspose.com/cells/net/aspose.cells/pagesetup/printarea/) chỉ ở phạm vi đó, loại bỏ lề, đầu trang và chân trang, và trả về một luồng PNG đặt ở vị trí đầu.

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

{{% alert color="info" title="Note" %}}

Có hai cách tiếp cận để khắc phục vấn đề thay đổi kích thước của trang tính. Hãy chọn cách tiếp cận phù hợp nhất với yêu cầu và trường hợp sử dụng của bạn. Cả hai cách đều hoạt động tương tự, bất kể bản thuyết trình được tạo từ mẫu hay từ đầu. Ngoài ra, không có giới hạn nào về kích thước của khung OLE trong giải pháp này.

{{% /alert %}}

## **Câu hỏi thường gặp**

**Tại sao một trang tính Excel được nhúng lại thay đổi kích thước khi lần đầu được kích hoạt trong PowerPoint?**

Điều này xảy ra vì Excel cố gắng giữ kích thước cửa sổ gốc khi được kích hoạt, trong khi khung OLE trong PowerPoint có kích thước riêng. PowerPoint và Excel sẽ thương lượng kích thước để duy trì tỷ lệ, dẫn đến việc thay đổi kích thước.

**Liệu có thể ngăn hoàn toàn vấn đề thay đổi kích thước này không?**

Có. Bằng cách phóng to khung OLE để vừa với kích thước phạm vi ô Excel hoặc phóng to phạm vi ô để vừa với kích thước khung OLE mong muốn, bạn có thể ngăn việc thay đổi kích thước không mong muốn.

**Nên dùng phương pháp phóng to khung OLE hay phóng to phạm vi ô?**

Chọn **phóng to khung OLE** nếu bạn muốn giữ nguyên kích thước hàng và cột Excel gốc. Chọn **phóng to phạm vi ô** nếu bạn muốn có kích thước cố định cho khung OLE trong bản thuyết trình.

**Các giải pháp này có hoạt động nếu bản thuyết trình của tôi dựa trên mẫu không?**

Có. Cả hai giải pháp đều hoạt động cho các bản thuyết trình được tạo từ mẫu và từ đầu.

**Có giới hạn nào về kích thước của khung OLE khi sử dụng các phương pháp này không?**

Không. Bạn có thể đặt khung OLE ở bất kỳ kích thước nào miễn là bạn điều chỉnh tỷ lệ một cách phù hợp.

**Có cách nào tránh văn bản chỗ giữ chỗ "EMBEDDED OLE OBJECT" trong PowerPoint không?**

Có. Bằng cách chụp ảnh phạm vi ô Excel mục tiêu và đặt nó làm hình ảnh chỗ giữ chỗ của khung OLE, bạn có thể hiển thị một hình ảnh xem trước tùy chỉnh thay cho chỗ giữ chỗ mặc định.

## **Bài viết liên quan**

[Creating an Excel Chart and Embedding It in a Presentation as an OLE Object](/slides/vi/net/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)

[Updating OLE Objects Automatically Using an MS PowerPoint Add-In](/slides/vi/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)