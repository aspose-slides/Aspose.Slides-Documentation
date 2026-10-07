---
title: Quản lý các ô bảng trong bài thuyết trình bằng .NET
linktitle: Quản lý ô
type: docs
weight: 30
url: /vi/net/manage-cells/
keywords:
- ô bảng
- hợp nhất ô
- xóa viền
- tách ô
- hình ảnh trong ô
- màu nền
- PowerPoint
- bài thuyết trình
- .NET
- C#
- Aspose.Slides
description: "Quản lý các ô bảng PowerPoint trong C#: xác định các ô đã hợp nhất, xóa viền, tách ô, và đặt màu nền cũng như hình ảnh bằng Aspose.Slides cho .NET."
---
## **Tổng quan**

Aspose.Slides cho phép bạn truy cập và sửa đổi các ô bảng trong bài thuyết trình PowerPoint. Bài viết này giải thích cách xác định các ô bảng đã hợp nhất, xóa viền ô, làm việc với đánh số ô sau khi hợp nhất hoặc tách ô, thay đổi màu nền của ô, và thêm hình ảnh bên trong ô bảng. Các ví dụ cho thấy cách tạo hoặc mở một bài thuyết trình, lấy bảng từ một slide, cập nhật định dạng ô thông qua các thuộc tính của ô, và lưu bài thuyết trình đã sửa đổi dưới dạng tệp PPTX.

Aspose.Slides sử dụng chỉ mục bắt đầu từ 0 để truy cập các ô bảng theo thứ tự `(cột, hàng)`.

## **Xác định ô bảng đã hợp nhất**

Ví dụ mở một bài thuyết trình hiện có và truy cập hình dạng đầu tiên trên slide đầu tiên dưới dạng bảng. Nó giả định rằng slide và hình dạng tồn tại và hình dạng là một bảng. Sau đó nó lặp qua tất cả các hàng và cột và sử dụng [IsMergedCell](https://reference.aspose.com/slides/net/aspose.slides/icell/ismergedcell/) để xác định các ô trong vùng hợp nhất. Đối với mỗi kết quả phù hợp, nó in tọa độ ô theo thứ tự `row;column`, [RowSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/rowspan/), [ColSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/colspan/), và tọa độ bắt đầu của vùng, [FirstRowIndex](https://reference.aspose.com/slides/net/aspose.slides/icell/firstrowindex/) và [FirstColumnIndex](https://reference.aspose.com/slides/net/aspose.slides/icell/firstcolumnindex/).

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("presentation_with_table.pptx");
var slide = presentation.Slides[0];
var table = (ITable) slide.Shapes[0];

var rowCount = table.Rows.Count;
for (var rowIndex = 0; rowIndex < rowCount; rowIndex++)
{
    var columnCount = table.Columns.Count;
    for (var columnIndex = 0; columnIndex < columnCount; columnIndex++)
    {
        var cell = table[columnIndex, rowIndex];
        if (cell.IsMergedCell)
        {
            Console.WriteLine($"Cell {rowIndex};{columnIndex} belongs to a merged region with RowSpan={cell.RowSpan} and ColSpan={cell.ColSpan} starting at {cell.FirstRowIndex};{cell.FirstColumnIndex}.");
        }
    }
}
```
## **Xóa viền ô bảng**

Tạo một [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) và thêm một bảng vào slide đầu tiên của nó bằng [AddTable](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addtable/). Chiều rộng cột, chiều cao hàng và vị trí bảng được chỉ định bằng điểm. Ví dụ đặt tất cả bốn viền ô thành [FillType.NoFill](https://reference.aspose.com/slides/net/aspose.slides/filltype/), khiến chúng không hiển thị.

```csharp
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

double[] columnWidths = { 50, 50, 50, 50 };
double[] rowHeights = { 50, 30, 30, 30, 30 };
var table = slide.Shapes.AddTable(100, 50, columnWidths, rowHeights);

foreach (var row in table.Rows)
    foreach (var cell in row)
    {
        cell.CellFormat.BorderTop.FillFormat.FillType = FillType.NoFill;
        cell.CellFormat.BorderBottom.FillFormat.FillType = FillType.NoFill;
        cell.CellFormat.BorderLeft.FillFormat.FillType = FillType.NoFill;
        cell.CellFormat.BorderRight.FillFormat.FillType = FillType.NoFill;
    }

presentation.Save("table.pptx", SaveFormat.Pptx);
```
## **Hợp nhất các ô bảng**

Sử dụng [MergeCells](https://reference.aspose.com/slides/net/aspose.slides/itable/mergecells/) để kết hợp một phạm vi hình chữ nhật các ô bảng thành một ô. Chỉ định các ô ở góc trên‑trái và góc dưới‑phải của phạm vi. Tham số cuối cùng kiểm soát liệu việc hợp nhất có bao gồm các ô nằm ngoài phạm vi đã chỉ định hay không; `false` giữ việc hợp nhất trong phạm vi đó.

Ví dụ tạo một bảng 4x4 với các cột và hàng 70 điểm, sau đó hợp nhất bốn ô trung tâm từ `(1, 1)` đến `(2, 2)`. Ô kết quả kéo dài qua hai cột và hai hàng, trong khi lưới cơ bản của bảng vẫn giữ bốn cột và bốn hàng. Để truy cập nội dung hoặc định dạng của ô đã hợp nhất, sử dụng vị trí trên‑trái của nó: `table[1, 1]` trong ví dụ này. Các vị trí khác trong phạm vi đã hợp nhất vẫn là một phần của lưới bảng, vì vậy chỉ mục của các ô nằm ngoài phạm vi không thay đổi.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

double[] columnWidths = { 70, 70, 70, 70 };
double[] rowHeights = { 70, 70, 70, 70 };
var table = slide.Shapes.AddTable(100, 50, columnWidths, rowHeights);

table.MergeCells(table[1, 1], table[2, 2], false);

presentation.Save("merged_cells.pptx", SaveFormat.Pptx);
```
## **Tách các ô bảng**

Việc hợp nhất các ô trong ví dụ trước giữ nguyên lưới của bảng. Tách một ô có thể tạo thêm một cột lưới mới và thay đổi chỉ số cột của các ô bên phải nó. Aspose.Slides tuân theo mô hình lưới bảng của PowerPoint.

Ví dụ này tạo một bảng 4x4 với các cột và hàng 70 điểm và gọi [SplitByWidth](https://reference.aspose.com/slides/net/aspose.slides/icell/splitbywidth/) trên ô `(1, 1)`. Một nửa chiều rộng 70 điểm của ô được truyền để tạo hai ô có chiều rộng bằng nhau.

Sau khi tách, hai nửa được truy cập là `table[1, 1]` và `table[2, 1]`. Lưới bảng bây giờ có năm cột: các ô ban đầu ở cột 2 và 3 di chuyển sang cột 3 và 4, tương ứng. Chỉ mục hàng vẫn không thay đổi. Sử dụng các chỉ mục cột đã cập nhật khi truy cập các ô sau khi tách.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

double[] columnWidths = { 70, 70, 70, 70 };
double[] rowHeights = { 70, 70, 70, 70 };
var table = slide.Shapes.AddTable(100, 50, columnWidths, rowHeights);

table[1, 1].SplitByWidth(table[1, 1].Width / 2);

presentation.Save("split_cells.pptx", SaveFormat.Pptx);
```
### **Tách các ô đã hợp nhất theo Row Span hoặc Col Span**

Để chuẩn bị các ô mẫu đã hợp nhất cho việc điền dữ liệu, sử dụng [SplitByRowSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/splitbyrowspan/) để tách theo ranh giới hàng hiện có, hoặc [SplitByColSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/splitbycolspan/) để tách theo ranh giới cột.

Tham số `index` đếm số hàng ở phần trên hoặc số cột ở phần trái của phần tách; nó tương đối với vùng đã hợp nhất:

- Tách hàng: `0 < index <` [RowSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/rowspan/).
- Tách cột: `0 < index <` [ColSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/colspan/).

Ví dụ yêu cầu một bài thuyết trình có một bảng là hình dạng đầu tiên trên slide đầu tiên, với `(1, 2)` và `(1, 3)` được hợp nhất theo chiều dọc. Bắt đầu từ vị trí bên dưới, nó sử dụng [FirstColumnIndex](https://reference.aspose.com/slides/net/aspose.slides/icell/firstcolumnindex/) và [FirstRowIndex](https://reference.aspose.com/slides/net/aspose.slides/icell/firstrowindex/) để xác định nguồn gốc và kiểm tra cả hai span. `SplitByRowSpan(1)` sau đó tách các hàng 2 và 3 cho tên sản phẩm. Đối với hợp nhất ngang hai cột, sử dụng `SplitByColSpan(1)` thay thế.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("table_template.pptx");
var slide = presentation.Slides[0];
var table = (ITable) slide.Shapes[0];

var selectedCell = table[1, 3];
var firstColumnIndex = selectedCell.FirstColumnIndex;
var firstRowIndex = selectedCell.FirstRowIndex;
var mergedCell = table[firstColumnIndex, firstRowIndex];

if (mergedCell.IsMergedCell && mergedCell.RowSpan == 2 && mergedCell.ColSpan == 1)
{
    mergedCell.SplitByRowSpan(1);

    // Lấy các ô kết quả từ bảng sau khi tách.
    var upperCell = table[firstColumnIndex, firstRowIndex];
    var lowerCell = table[firstColumnIndex, firstRowIndex + 1];
    Console.WriteLine($"Upper cell merged: {upperCell.IsMergedCell}");
    Console.WriteLine($"Lower cell merged: {lowerCell.IsMergedCell}");

    upperCell.TextFrame.Text = "Product A";
    lowerCell.TextFrame.Text = "Product B";

    presentation.Save("split_template.pptx", SaveFormat.Pptx);
}
else
{
    Console.WriteLine("Select a merged region spanning exactly two rows and one column.");
}
```

Lưới bảng và các chỉ mục ô xung quanh vẫn không thay đổi. Lấy các ô kết quả theo tọa độ của chúng; ở đây, cả hai đều có span là 1 và [IsMergedCell](https://reference.aspose.com/slides/net/aspose.slides/icell/ismergedcell/) in ra `False`. Các vùng lớn hơn có thể vẫn còn một phần được hợp nhất sau một lần tách.

Văn bản gốc và định dạng của nó vẫn ở ô trên (hoặc bên trái); ô mới rỗng nhưng kế thừa định dạng ô như màu nền, viền và lề. Điền dữ liệu vào các ô sau khi tách và đặt bất kỳ định dạng văn bản yêu cầu nào một cách rõ ràng.

Bài thuyết trình đã lưu chứa các ô "Product A" và "Product B" riêng biệt với định dạng ô của mẫu được giữ lại. Xem [Cell API Reference](https://reference.aspose.com/slides/net/aspose.slides/cell/) để biết chi tiết.

## **Thay đổi màu nền của ô bảng**

Ví dụ này tạo một bảng với các cột 150 điểm và các hàng 50 điểm. Nó đặt [FillType](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/filltype/) thành solid và [SolidFillColor](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/solidfillcolor/) thành màu đỏ cho ô `(2, 3)`, nằm ở cột thứ ba và hàng thứ tư.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

double[] columnWidths = { 150, 150, 150, 150 };
double[] rowHeights = { 50, 50, 50, 50, 50 };
var table = slide.Shapes.AddTable(50, 50, columnWidths, rowHeights);

var cell = table[2, 3];
cell.CellFormat.FillFormat.FillType = FillType.Solid;
cell.CellFormat.FillFormat.SolidFillColor.Color = Color.Red;

presentation.Save("cell_background_color.pptx", SaveFormat.Pptx);
```
## **Thêm hình ảnh vào bên trong ô bảng**

Đặt hình ảnh đầu vào trong thư mục làm việc trước khi chạy ví dụ này. Nó tải hình ảnh bằng [Images.FromFile](https://reference.aspose.com/slides/net/aspose.slides/images/fromfile/) và thêm nó vào bộ sưu tập hình ảnh của bài thuyết trình bằng [AddImage](https://reference.aspose.com/slides/net/aspose.slides/iimagecollection/addimage/). Sau đó nó gán hình ảnh vào phần picture fill của ô `(0, 0)`, ô đầu tiên trong bảng.

[PictureFillMode.Stretch](https://reference.aspose.com/slides/net/aspose.slides/picturefillmode/) kéo dài hình ảnh để lấp đầy ô, có thể thay đổi tỷ lệ khung hình của nó. Chiều rộng cột và chiều cao hàng được tính bằng điểm. Hình ảnh đã tải sẽ được giải phóng tự động bởi câu lệnh using.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

double[] columnWidths = { 150, 150, 150, 150 };
double[] rowHeights = { 100, 100, 100, 100, 90 };
var table = slide.Shapes.AddTable(50, 50, columnWidths, rowHeights);

using var image = Images.FromFile("aspose_logo.jpg");
var ppImage = presentation.Images.AddImage(image);

table[0, 0].CellFormat.FillFormat.FillType = FillType.Picture;
table[0, 0].CellFormat.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;
table[0, 0].CellFormat.FillFormat.PictureFillFormat.Picture.Image = ppImage;

presentation.Save("table_cell_with_image.pptx", SaveFormat.Pptx);
```
## **Câu hỏi thường gặp**

**Tôi có thể đặt độ dày và kiểu đường khác nhau cho các cạnh khác nhau của một ô duy nhất không?**

Có. Các viền [top](https://reference.aspose.com/slides/net/aspose.slides/cellformat/bordertop/)/[bottom](https://reference.aspose.com/slides/net/aspose.slides/cellformat/borderbottom/)/[left](https://reference.aspose.com/slides/net/aspose.slides/cellformat/borderleft/)/[right](https://reference.aspose.com/slides/net/aspose.slides/cellformat/borderright/) có các thuộc tính riêng, vì vậy độ dày và kiểu của mỗi cạnh có thể khác nhau.

**Điều gì xảy ra với hình ảnh nếu tôi thay đổi kích thước cột/hàng sau khi đặt hình ảnh làm nền cho ô?**

Hành vi phụ thuộc vào [fill mode](https://reference.aspose.com/slides/net/aspose.slides/picturefillmode/) (stretch/tile). Khi kéo dài, hình ảnh sẽ điều chỉnh theo ô mới; khi xếp dạng tile, các ô ảnh sẽ được tính lại.

**Tôi có thể gán siêu liên kết cho toàn bộ nội dung của một ô không?**

[Hyperlinks](/slides/vi/net/manage-hyperlinks/) được đặt ở mức văn bản (phần) bên trong khung văn bản của ô hoặc ở mức của toàn bộ bảng/hình dạng. Trong thực tế, bạn gán liên kết cho một phần hoặc cho toàn bộ văn bản trong ô.

**Tôi có thể đặt các phông chữ khác nhau trong một ô duy nhất không?**

Có. Khung văn bản của ô hỗ trợ [portions](https://reference.aspose.com/slides/net/aspose.slides/portion/) (các đoạn) với định dạng độc lập—gia đình phông chữ, kiểu, kích cỡ và màu.