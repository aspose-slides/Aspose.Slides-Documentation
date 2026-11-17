---
title: Quản lý các ô bảng trong bản trình chiếu bằng .NET
linktitle: Quản lý các ô
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
- bản trình chiếu
- .NET
- C#
- Aspose.Slides
description: "Quản lý các ô bảng PowerPoint trong C#: xác định các ô đã hợp nhất, xóa viền, tách ô và đặt màu nền cũng như hình ảnh bằng Aspose.Slides cho .NET."
---
## **Tổng quan**

Aspose.Slides cho phép bạn truy cập và sửa đổi các ô bảng trong các bản trình chiếu PowerPoint. Bài viết này giải thích cách xác định các ô bảng đã hợp nhất, xóa viền ô, làm việc với việc đánh số ô sau khi hợp nhất hoặc tách ô, thay đổi màu nền của ô và thêm hình ảnh bên trong một ô bảng. Các ví dụ cho thấy cách tạo hoặc mở một bản trình chiếu, lấy bảng từ một slide, cập nhật định dạng ô qua các thuộc tính của ô, và lưu bản trình chiếu đã sửa đổi dưới dạng tệp PPTX.

Aspose.Slides sử dụng chỉ số bắt đầu từ 0 để truy cập các ô bảng theo thứ tự `(cột, hàng)`.

## **Xác định ô bảng đã hợp nhất**

Ví dụ mở một bản trình chiếu hiện có và truy cập hình dạng đầu tiên trên slide đầu tiên như là một bảng. Nó giả định rằng slide và hình dạng tồn tại và hình dạng là một bảng. Sau đó nó lặp qua tất cả các hàng và cột và sử dụng [IsMergedCell](https://reference.aspose.com/slides/net/aspose.slides/icell/ismergedcell/) để xác định các ô trong các vùng đã hợp nhất. Đối với mỗi kết quả phù hợp, nó in ra tọa độ ô theo thứ tự `hàng;cột`, [RowSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/rowspan/), [ColSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/colspan/), và tọa độ bắt đầu của vùng, [FirstRowIndex](https://reference.aspose.com/slides/net/aspose.slides/icell/firstrowindex/) và [FirstColumnIndex](https://reference.aspose.com/slides/net/aspose.slides/icell/firstcolumnindex/).

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

Tạo một [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) và thêm một bảng vào slide đầu tiên của nó bằng [AddTable](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addtable/). Độ rộng cột, chiều cao hàng và vị trí bảng được chỉ định bằng điểm. Ví dụ đặt cả bốn viền ô thành [FillType.NoFill](https://reference.aspose.com/slides/net/aspose.slides/filltype/), làm chúng trở nên vô hình.

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

## **Thêm viền chéo cho ô**

Sử dụng [BorderDiagonalDown](https://reference.aspose.com/slides/net/aspose.slides/icellformat/borderdiagonaldown/) để vẽ một đường từ góc trên‑trái đến góc dưới‑phải, và [BorderDiagonalUp](https://reference.aspose.com/slides/net/aspose.slides/icellformat/borderdiagonalup/) để vẽ một đường từ góc dưới‑trái đến góc trên‑phải. Một đường chéo có thể đánh dấu tiêu đề góc; cả hai đường chéo có thể tạo thành chữ X để đánh dấu ô là không áp dụng.

Mỗi đường chéo là một [ILineFormat](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/). Trong [FillFormat](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/fillformat/) của nó, đặt [FillType](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/filltype/) thành [FillType.Solid](https://reference.aspose.com/slides/net/aspose.slides/filltype/) và chọn một [SolidFillColor](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/solidfillcolor/). Đặt [Width](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/width/) của đường bằng điểm.

Ví dụ tạo ba ô trong một hàng: một đường chéo xuống màu đỏ, một đường chéo lên màu xanh, và cả hai đường chéo. Nó giữ nguyên các viền ô trên, dưới, trái và phải.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

double[] columnWidths = { 210, 210, 210 };
double[] rowHeights = { 160 };
var table = slide.Shapes.AddTable(45, 130, columnWidths, rowHeights);

var downwardBorder = table[0, 0].CellFormat.BorderDiagonalDown;
downwardBorder.FillFormat.FillType = FillType.Solid;
downwardBorder.FillFormat.SolidFillColor.Color = Color.Red;
downwardBorder.Width = 3;

var upwardBorder = table[1, 0].CellFormat.BorderDiagonalUp;
upwardBorder.FillFormat.FillType = FillType.Solid;
upwardBorder.FillFormat.SolidFillColor.Color = Color.Blue;
upwardBorder.Width = 5;

var crossDownwardBorder = table[2, 0].CellFormat.BorderDiagonalDown;
crossDownwardBorder.FillFormat.FillType = FillType.Solid;
crossDownwardBorder.FillFormat.SolidFillColor.Color = Color.Red;
crossDownwardBorder.Width = 3;

var crossUpwardBorder = table[2, 0].CellFormat.BorderDiagonalUp;
crossUpwardBorder.FillFormat.FillType = FillType.Solid;
crossUpwardBorder.FillFormat.SolidFillColor.Color = Color.Blue;
crossUpwardBorder.Width = 5;

presentation.Save("diagonal_cell_borders.pptx", SaveFormat.Pptx);
```

Một đường chéo là thuộc tính định dạng, không phải là sự tách ô. Mỗi ô vẫn giữ một [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/icell/textframe/); các vùng ở hai phía của đường chéo không thể chỉnh sửa độc lập.

Bảng đã lưu, được render trong Microsoft PowerPoint:

![Ba ô bảng hiển thị một đường chéo đỏ từ trên‑trái đến dưới‑phải, một đường chéo xanh từ dưới‑trái đến trên‑phải, và cả hai đường chéo tạo thành chữ X.](diagonal-cell-borders.png)

*Trái sang phải: đường chéo xuống (đỏ, 3 pt), đường chéo lên (xanh, 5 pt), và cả hai đường chéo.*

## **Hợp nhất các ô bảng**

Sử dụng [MergeCells](https://reference.aspose.com/slides/net/aspose.slides/itable/mergecells/) để kết hợp một phạm vi hình chữ nhật các ô bảng thành một ô. Chỉ định các ô ở góc trên‑trái và góc dưới‑phải của phạm vi. Đối số cuối cùng kiểm soát việc hợp nhất có bao gồm các ô bên ngoài phạm vi đã chỉ định hay không; `false` giữ việc hợp nhất trong phạm vi đó.

Ví dụ tạo một bảng 4‑by‑4 với các cột và hàng rộng 70 điểm, sau đó hợp nhất bốn ô trung tâm từ `(1, 1)` đến `(2, 2)`. Ô kết quả phủ rộng hai cột và hai hàng, trong khi lưới cơ bản của bảng vẫn giữ bốn cột và bốn hàng. Để truy cập nội dung hoặc định dạng của ô đã hợp nhất, sử dụng vị trí góc trên‑trái của nó: `table[1, 1]` trong ví dụ này. Các vị trí khác trong phạm vi đã hợp nhất vẫn là một phần của lưới bảng, vì vậy chỉ số của các ô ngoài phạm vi không thay đổi.

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

Ví dụ này tạo một bảng 4‑by‑4 với các cột và hàng rộng 70 điểm và gọi [SplitByWidth](https://reference.aspose.com/slides/net/aspose.slides/icell/splitbywidth/) trên ô `(1, 1)`. Một nửa độ rộng 70 điểm của ô được truyền vào để tạo hai ô có chiều rộng bằng nhau.

Sau lần tách này, hai nửa được truy cập dưới dạng `table[1, 1]` và `table[2, 1]`. Lưới bảng hiện có năm cột: các ô ban đầu ở cột 2 và 3 chuyển sang cột 3 và 4, tương ứng. Các chỉ số hàng không thay đổi. Sử dụng các chỉ số cột đã cập nhật khi truy cập các ô sau khi tách.

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

### **Tách các ô đã hợp nhất theo phạm vi hàng hoặc cột**

Để chuẩn bị các ô mẫu đã hợp nhất cho việc đưa dữ liệu, sử dụng [SplitByRowSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/splitbyrowspan/) để tách theo ranh giới hàng hiện có, hoặc [SplitByColSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/splitbycolspan/) để tách theo ranh giới cột.

Đối số `index` đếm các hàng ở phần trên hoặc các cột ở phần trái của phần tách; nó tương đối so với vùng đã hợp nhất:

- Tách hàng: `0 < index <` [RowSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/rowspan/).
- Tách cột: `0 < index <` [ColSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/colspan/).

Ví dụ giả định bản trình chiếu có một bảng là hình dạng đầu tiên trên slide đầu tiên, với các ô `(1, 2)` và `(1, 3)` đã hợp nhất theo chiều dọc. Bắt đầu từ vị trí dưới, nó sử dụng [FirstColumnIndex](https://reference.aspose.com/slides/net/aspose.slides/icell/firstcolumnindex/) và [FirstRowIndex](https://reference.aspose.com/slides/net/aspose.slides/icell/firstrowindex/) để xác định nguồn và kiểm tra cả hai phạm vi. `SplitByRowSpan(1)` sau đó tách các hàng 2 và 3 cho tên sản phẩm. Đối với một hợp nhất ngang hai cột, hãy dùng `SplitByColSpan(1)` thay thế.

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

Lưới bảng và các chỉ số ô xung quanh vẫn không thay đổi. Lấy các ô kết quả theo tọa độ của chúng; ở đây, cả hai ô đều có phạm vi 1 và [IsMergedCell](https://reference.aspose.com/slides/net/aspose.slides/icell/ismergedcell/) trả về `False`. Các vùng lớn hơn có thể vẫn còn một phần hợp nhất sau một lần tách.

Văn bản gốc và định dạng của nó vẫn nằm trong ô trên (hoặc trái); ô mới rỗng nhưng kế thừa định dạng ô như màu nền, viền và lề. Điền nội dung vào các ô sau khi tách và đặt bất kỳ định dạng văn bản nào cần thiết một cách rõ ràng.

Bản trình chiếu đã lưu chứa các ô “Product A” và “Product B” riêng biệt với định dạng ô mẫu được giữ nguyên. Xem [Cell API Reference](https://reference.aspose.com/slides/net/aspose.slides/cell/) để biết chi tiết.


<!-- visual-explanation:manage-cells:start -->
[![The merged cell at column 1, rows 2 and 3 splits into Product A and Product B with the same grid indices.](visual-manage-cells-62c80896698e.svg)](visual-manage-cells-62c80896698e.svg)

*Việc tách theo phạm vi hàng sử dụng ranh giới hiện có. Product A và Product B chiếm (1, 2) và (1, 3), tương ứng.*
<!-- visual-explanation:manage-cells:end -->

### **Tách ô theo chiều cao cụ thể**

[SplitByHeight](https://reference.aspose.com/slides/net/aspose.slides/icell/splitbyheight/) nhận chiều cao của phần trên bằng điểm. [SplitByRowSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/splitbyrowspan/) nhận số hàng lưới hiện có ở phần trên. Để căn giữa một ô 40 điểm trong cột bên phải, trừ 40 khỏi chiều cao thực tế của ô và chia phần còn lại đều lên trên và dưới nó.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

double[] columnWidths = { 160, 160 };
double[] rowHeights = { 140 };

var table = slide.Shapes.AddTable(50, 50, columnWidths, rowHeights);
table[0, 0].TextFrame.Text = "Left";

var height = table[1, 0].Height;
var margin = (height - 40) / 2;

table[1, 0].SplitByHeight(margin);
table[1, 1].SplitByHeight(40);
table[1, 1].TextFrame.Text = "Middle";

presentation.Save("split_by_height.pptx", SaveFormat.Pptx);
```

Lần tách đầu tiên thêm một hàng lưới, để lại 90 điểm phía dưới tại `[1, 1]`. Lần tách thứ hai nhắm vào ô đó và thêm một hàng nữa bên dưới nó. Cột bên phải hiện có `[1, 0]` ở 50 điểm (`margin`), `[1, 1]` ở 40 điểm, và `[1, 2]` ở 50 điểm (`margin`). Ô bên trái phủ ba hàng đầy đủ với chiều cao ban đầu là 140 điểm.

![Ô bên trái phủ toàn bộ chiều cao bảng bên cạnh ba ô với Middle ở giữa.](split-by-height.png)

## **Thay đổi màu nền ô bảng**

Ví dụ này tạo một bảng với các cột rộng 150 điểm và các hàng cao 50 điểm. Nó đặt [FillType](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/filltype/) thành đặc và [SolidFillColor](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/solidfillcolor/) thành màu đỏ cho ô `(2, 3)`, nằm ở cột thứ ba và hàng thứ tư.

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

## **Thêm hình ảnh vào bên trong một ô bảng**

Đặt hình ảnh đầu vào trong thư mục làm việc trước khi chạy ví dụ này. Nó tải hình ảnh bằng [Images.FromFile](https://reference.aspose.com/slides/net/aspose.slides/images/fromfile/) và thêm nó vào bộ sưu tập hình ảnh của bản trình chiếu bằng [AddImage](https://reference.aspose.com/slides/net/aspose.slides/iimagecollection/addimage/). Sau đó nó gán hình ảnh cho phần fill hình ảnh của ô `(0, 0)`, ô đầu tiên trong bảng.

[PictureFillMode.Stretch](https://reference.aspose.com/slides/net/aspose.slides/picturefillmode/) kéo dài hình ảnh để lấp đầy ô, có thể làm thay đổi tỷ lệ khung hình của nó. Độ rộng cột và chiều cao hàng được tính bằng điểm. Hình ảnh đã tải sẽ được giải phóng tự động bởi câu lệnh using của nó.

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

**Tôi có thể thiết lập độ dày và kiểu đường khác nhau cho các phía của cùng một ô không?**

Có. Các viền [top](https://reference.aspose.com/slides/net/aspose.slides/cellformat/bordertop/)/[bottom](https://reference.aspose.com/slides/net/aspose.slides/cellformat/borderbottom/)/[left](https://reference.aspose.com/slides/net/aspose.slides/cellformat/borderleft/)/[right](https://reference.aspose.com/slides/net/aspose.slides/cellformat/borderright/) có các thuộc tính riêng, vì vậy độ dày và kiểu của mỗi phía có thể khác nhau.

**Điều gì sẽ xảy ra với hình ảnh nếu tôi thay đổi kích thước cột/hàng sau khi đã đặt ảnh làm nền của ô?**

Hành vi phụ thuộc vào [fill mode](https://reference.aspose.com/slides/net/aspose.slides/picturefillmode/) (stretch/tile). Khi kéo dài, hình ảnh sẽ điều chỉnh theo ô mới; khi lát gạch, các ô ảnh sẽ được tính lại.

**Tôi có thể gán siêu liên kết cho toàn bộ nội dung của một ô không?**

[Hyperlinks](/slides/vi/net/manage-hyperlinks/) được đặt ở mức đoạn văn bản (portion) bên trong khung văn bản của ô hoặc ở mức toàn bộ bảng/hình dạng. Thực tế, bạn gán liên kết cho một đoạn hoặc cho toàn bộ văn bản trong ô.

**Tôi có thể đặt phông chữ khác nhau trong cùng một ô không?**

Có. Khung văn bản của ô hỗ trợ [portions](https://reference.aspose.com/slides/net/aspose.slides/portion/) (run) với định dạng độc lập—gia đình phông, kiểu, kích thước và màu.