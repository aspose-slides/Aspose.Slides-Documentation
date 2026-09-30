---
title: Quản lý các bảng trong bản trình chiếu bằng .NET
linktitle: Quản lý Bảng
type: docs
weight: 10
url: /vi/net/manage-table/
keywords:
- thêm bảng
- tạo bảng
- truy cập bảng
- tỷ lệ khung hình
- căn chỉnh văn bản
- định dạng văn bản
- kiểu bảng
- PowerPoint
- bản trình chiếu
- .NET
- C#
- Aspose.Slides
description: "Tạo và chỉnh sửa bảng trong các slide PowerPoint với Aspose.Slides cho .NET. Khám phá các ví dụ mã C# đơn giản để tối ưu hóa quy trình làm việc với bảng của bạn."
---
## **Giới thiệu**

Bảng trong PowerPoint sắp xếp thông tin thành các hàng và cột, giúp việc đọc và so sánh các giá trị trở nên dễ dàng hơn.

Aspose.Slides cung cấp lớp [Table](https://reference.aspose.com/slides/net/aspose.slides/table/) , giao diện [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) , lớp [Cell](https://reference.aspose.com/slides/net/aspose.slides/cell/) , giao diện [ICell](https://reference.aspose.com/slides/net/aspose.slides/icell/) và các kiểu khác để cho phép bạn tạo, cập nhật và quản lý các bảng trong bản trình chiếu.

## **Tạo bảng từ đầu**

Tạo một bảng bằng cách chỉ định vị trí, độ rộng cột và chiều cao hàng. Sau khi thêm nó vào slide, bạn có thể định dạng đường viền ô, hợp nhất ô và chèn văn bản.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) .
2. Lấy tham chiếu đến slide bằng chỉ mục của nó.
3. Xác định một mảng độ rộng cột bằng đơn vị point.
4. Xác định một mảng chiều cao hàng bằng đơn vị point.
5. Thêm một đối tượng [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) vào slide thông qua phương thức [AddTable](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addtable/) .
6. Duyệt qua từng [ICell](https://reference.aspose.com/slides/net/aspose.slides/icell/) để áp dụng định dạng cho các đường viền trên, dưới, phải và trái.
7. Hợp nhất hai ô đầu tiên của hàng đầu tiên của bảng.
8. Truy cập ô đã hợp nhất thông qua thuộc tính [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/icell/textframe/) .
9. Đặt văn bản trong ô đã hợp nhất.
10. Lưu bản trình chiếu đã chỉnh sửa.

Ví dụ dưới đây tạo một bảng với ba cột và năm hàng tại vị trí (100, 50) point. Nó áp dụng đường viền màu đỏ với độ rộng 5 point, hợp nhất hai ô đầu tiên ở hàng đầu tiên, và lưu kết quả dưới dạng `table.pptx`.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var columnWidths = new double[] { 50, 50, 50 };
var rowHeights = new double[] { 50, 30, 30, 30, 30 };
var table = slide.Shapes.AddTable(100, 50, columnWidths, rowHeights);

foreach (var row in table.Rows)
{
    foreach (var cell in row)
    {
        var cellFormat = cell.CellFormat;
        cellFormat.BorderTop.FillFormat.FillType = FillType.Solid;
        cellFormat.BorderTop.FillFormat.SolidFillColor.Color = Color.Red;
        cellFormat.BorderTop.Width = 5;

        cellFormat.BorderBottom.FillFormat.FillType = FillType.Solid;
        cellFormat.BorderBottom.FillFormat.SolidFillColor.Color = Color.Red;
        cellFormat.BorderBottom.Width = 5;

        cellFormat.BorderLeft.FillFormat.FillType = FillType.Solid;
        cellFormat.BorderLeft.FillFormat.SolidFillColor.Color = Color.Red;
        cellFormat.BorderLeft.Width = 5;

        cellFormat.BorderRight.FillFormat.FillType = FillType.Solid;
        cellFormat.BorderRight.FillFormat.SolidFillColor.Color = Color.Red;
        cellFormat.BorderRight.Width = 5;
    }
}

table.MergeCells(table[0, 0], table[1, 0], false);
table[0, 0].TextFrame.Text = "Merged Cells";

presentation.Save("table.pptx", SaveFormat.Pptx);
```

## **Đánh số trong một bảng tiêu chuẩn**

Trong một bảng tiêu chuẩn, chỉ mục ô bắt đầu từ số 0 và dùng thứ tự (cột, hàng). Ô đầu tiên có chỉ mục là (0, 0).

Ví dụ, các ô trong một bảng có 4 cột và 4 hàng được đánh số như sau:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

Ví dụ này tạo bảng 4 × 4 như hình trên, với độ rộng cột và chiều cao hàng là 70 point và đường viền ô màu đỏ với độ rộng 5 point. Các tọa độ minh họa chỉ mục ô; ví dụ để các ô trống và lưu bảng dưới dạng `StandardTables_out.pptx`.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var columnWidths = new double[] { 70, 70, 70, 70 };
var rowHeights = new double[] { 70, 70, 70, 70 };
var table = slide.Shapes.AddTable(100, 50, columnWidths, rowHeights);

foreach (var row in table.Rows)
{
    foreach (var cell in row)
    {
        var cellFormat = cell.CellFormat;
        cellFormat.BorderTop.FillFormat.FillType = FillType.Solid;
        cellFormat.BorderTop.FillFormat.SolidFillColor.Color = Color.Red;
        cellFormat.BorderTop.Width = 5;

        cellFormat.BorderBottom.FillFormat.FillType = FillType.Solid;
        cellFormat.BorderBottom.FillFormat.SolidFillColor.Color = Color.Red;
        cellFormat.BorderBottom.Width = 5;

        cellFormat.BorderLeft.FillFormat.FillType = FillType.Solid;
        cellFormat.BorderLeft.FillFormat.SolidFillColor.Color = Color.Red;
        cellFormat.BorderLeft.Width = 5;

        cellFormat.BorderRight.FillFormat.FillType = FillType.Solid;
        cellFormat.BorderRight.FillFormat.SolidFillColor.Color = Color.Red;
        cellFormat.BorderRight.Width = 5;
    }
}

presentation.Save("StandardTables_out.pptx", SaveFormat.Pptx);
```

## **Truy cập bảng hiện có**

Các bảng được lưu trong bộ sưu tập shape của slide. Duyệt qua các hình dạng để tìm một bảng, sau đó sử dụng giao diện [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) để đọc hoặc cập nhật các ô của nó.

1. Tải bản trình chiếu bằng cách sử dụng lớp [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) .
2. Lấy tham chiếu đến slide chứa bảng bằng chỉ mục của nó.
3. Duyệt qua các đối tượng [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/) và dừng lại khi tìm thấy một bảng. Nếu slide chứa nhiều bảng, hãy sử dụng [AlternativeText](https://reference.aspose.com/slides/net/aspose.slides/ishape/alternativetext/) để xác định bảng bạn cần.
4. Cập nhật văn bản trong ô mục tiêu.
5. Lưu bản trình chiếu đã chỉnh sửa.

Ví dụ dưới đây mở tệp `UpdateExistingTable.pptx` và tìm bảng đầu tiên trên slide đầu tiên. Nó đặt ô ở cột 0, hàng 1 thành `New` và lưu kết quả dưới dạng `table1_out.pptx`. Tệp đầu vào phải chứa ít nhất một slide, và bảng đầu tiên trên slide đó phải có ít nhất một cột và hai hàng.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("UpdateExistingTable.pptx");
var slide = presentation.Slides[0];
ITable? table = null;

foreach (var shape in slide.Shapes)
{
    if (shape is ITable candidateTable)
    {
        table = candidateTable;
        break;
    }
}

table![0, 1].TextFrame.Text = "New";

presentation.Save("table1_out.pptx", SaveFormat.Pptx);
```

Để thay đổi kích thước hàng trong một bảng hiện có và hiểu tại sao chiều cao thực tế có thể vượt quá mức tối thiểu được yêu cầu, xem mục [Control Row Height](/slides/vi/net/manage-rows-and-columns/#control-row-height).

## **Tìm ô chứa khung văn bản**

Khi mã xử lý văn bản chung nhận được một [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/) từ một bảng, sử dụng thuộc tính [ITextFrame.ParentCell](https://reference.aspose.com/slides/net/aspose.slides/itextframe/parentcell/) để lấy [ICell](https://reference.aspose.com/slides/net/aspose.slides/icell/) sở hữu.

Đối với khung văn bản của ô bảng, [ITextFrame.ParentCell](https://reference.aspose.com/slides/net/aspose.slides/itextframe/parentcell/) được đặt và [ITextFrame.ParentShape](https://reference.aspose.com/slides/net/aspose.slides/itextframe/parentshape/) có giá trị `null`, mặc dù bảng tự nó là một shape.

Các tọa độ của ô có sẵn thông qua các thuộc tính chỉ đọc [ICell.FirstColumnIndex](https://reference.aspose.com/slides/net/aspose.slides/icell/firstcolumnindex/) và [ICell.FirstRowIndex](https://reference.aspose.com/slides/net/aspose.slides/icell/firstrowindex/).

[ITextFrame.ParentCell](https://reference.aspose.com/slides/net/aspose.slides/itextframe/parentcell/) cũng chỉ đọc: nó cung cấp việc điều hướng tới chủ sở hữu nhưng không thay đổi quyền sở hữu. Luôn luôn kiểm tra xem ô trả về có `null` hay không trước khi sử dụng.

Để xem ví dụ hoàn chỉnh nhằm xác định chủ sở hữu của ô bảng và shape, bao gồm các shape liên kết với nút SmartArt, xem mục [Search and Replace Text](/slides/vi/net/search-and-replace-text/).

## **Căn chỉnh văn bản trong bảng**

Bạn có thể kiểm soát việc neo dọc và hướng văn bản của từng ô bảng. Ví dụ trong phần này căn giữa văn bản trong ô đầu tiên và xoay nó 270 độ.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) .
2. Lấy tham chiếu đến slide bằng chỉ mục của nó.
3. Thêm một đối tượng [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) vào slide.
4. Truy cập một đối tượng [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/) từ bảng.
5. Truy cập [IParagraph](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/) đầu tiên và đặt văn bản và màu sắc cho nó.
6. Đặt [TextAnchorType](https://reference.aspose.com/slides/net/aspose.slides/icell/textanchortype/) và [TextVerticalType](https://reference.aspose.com/slides/net/aspose.slides/icell/textverticaltype/) cho ô.
7. Lưu bản trình chiếu đã chỉnh sửa.

Ví dụ này tạo một bảng 4 × 4 với độ rộng cột 120 point và chiều cao hàng 100 point. Nó định dạng văn bản trong ô (0, 0), thêm giá trị vào các ô còn lại trong hàng đầu tiên, và lưu kết quả dưới dạng `Vertical_Align_Text_out.pptx`.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var columnWidths = new double[] { 120, 120, 120, 120 };
var rowHeights = new double[] { 100, 100, 100, 100 };
var table = slide.Shapes.AddTable(100, 50, columnWidths, rowHeights);
table[1, 0].TextFrame.Text = "10";
table[2, 0].TextFrame.Text = "20";
table[3, 0].TextFrame.Text = "30";

var cell = table[0, 0];
var paragraph = cell.TextFrame.Paragraphs[0];
var portion = paragraph.Portions[0];
portion.Text = "Text here";
portion.PortionFormat.FillFormat.FillType = FillType.Solid;
portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;

cell.TextAnchorType = TextAnchorType.Center;
cell.TextVerticalType = TextVerticalType.Vertical270;

presentation.Save("Vertical_Align_Text_out.pptx", SaveFormat.Pptx);
```

## **Đặt định dạng văn bản ở mức độ bảng**

Sử dụng [SetTextFormat](https://reference.aspose.com/slides/net/aspose.slides/ibulktextformattable/settextformat/) để áp dụng định dạng văn bản cho tất cả các ô trong bảng. Các phiên bản overload của nó chấp nhận định dạng phần, đoạn và khung văn bản, vì vậy bạn có thể đặt các thuộc tính này mà không cần duyệt từng ô riêng lẻ.

1. Tải bản trình chiếu bằng lớp [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) .
2. Lấy tham chiếu đến slide bằng chỉ mục của nó.
3. Truy cập một đối tượng [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) từ slide.
4. Đặt [FontHeight](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/fontheight/) cho văn bản.
5. Đặt [Alignment](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/alignment/) và [MarginRight](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/marginright/) .
6. Đặt [TextVerticalType](https://reference.aspose.com/slides/net/aspose.slides/textframeformat/textverticaltype/) .
7. Lưu bản trình chiếu đã chỉnh sửa.

Ví dụ dưới đây mở tệp `table.pptx`, tệp này phải chứa ít nhất một slide có bảng là shape đầu tiên. Nó đặt kích thước phông chữ là 25 point, căn phải các đoạn với lề phải 20 point, và làm cho văn bản dọc. Bản trình chiếu đã định dạng được lưu dưới dạng `result.pptx`.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("table.pptx");
var slide = presentation.Slides[0];

var table = (ITable)slide.Shapes[0];

var portionFormat = new PortionFormat();
portionFormat.FontHeight = 25;
table.SetTextFormat(portionFormat);

var paragraphFormat = new ParagraphFormat();
paragraphFormat.Alignment = TextAlignment.Right;
paragraphFormat.MarginRight = 20;
table.SetTextFormat(paragraphFormat);

var textFrameFormat = new TextFrameFormat();
textFrameFormat.TextVerticalType = TextVerticalType.Vertical;
table.SetTextFormat(textFrameFormat);

presentation.Save("result.pptx", SaveFormat.Pptx);
```

## **Lấy thuộc tính kiểu bảng**

Sử dụng [StylePreset](https://reference.aspose.com/slides/net/aspose.slides/itable/stylepreset/) để đọc hoặc gán kiểu đã định sẵn cho một bảng. Ví dụ này áp dụng [TableStylePreset.DarkStyle1](https://reference.aspose.com/slides/net/aspose.slides/tablestylepreset/) cho một bảng, in ra tên kiểu đã định sẵn, và gán cùng một kiểu cho bảng thứ hai. Cả hai bảng đều được lưu trong `table-style.pptx`.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var columnWidths = new double[] { 100, 150 };
var rowHeights = new double[] { 5, 5, 5 };
var table = slide.Shapes.AddTable(10, 10, columnWidths, rowHeights);
table.StylePreset = TableStylePreset.DarkStyle1;

var stylePreset = table.StylePreset;
Console.WriteLine($"Table style preset: {stylePreset}");

var anotherTable = slide.Shapes.AddTable(10, 100, columnWidths, rowHeights);
anotherTable.StylePreset = stylePreset;

presentation.Save("table-style.pptx", SaveFormat.Pptx);
```

## **Khóa tỷ lệ khung hình của bảng**

Tỷ lệ khung hình của bảng là tỉ lệ giữa chiều rộng và chiều cao của nó. Sử dụng [AspectRatioLocked](https://reference.aspose.com/slides/net/aspose.slides/igraphicalobjectlock/aspectratiolocked/) để khóa tỉ lệ này cho một bảng.

Ví dụ dưới đây mở tệp `pres.pptx`, tệp này phải chứa ít nhất một slide có bảng là shape đầu tiên. Nó in trạng thái khóa hiện tại, bật khóa tỷ lệ khung hình, in trạng thái đã cập nhật (`True`), và lưu kết quả dưới dạng `pres-out.pptx`.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("pres.pptx");
var slide = presentation.Slides[0];

var table = (ITable)slide.Shapes[0];

Console.WriteLine($"Lock aspect ratio set: {table.ShapeLock.AspectRatioLocked}");

table.ShapeLock.AspectRatioLocked = true;
Console.WriteLine($"Lock aspect ratio set: {table.ShapeLock.AspectRatioLocked}");

presentation.Save("pres-out.pptx", SaveFormat.Pptx);
```

## **FAQ**

**Có thể bật hướng đọc từ phải sang trái (RTL) cho toàn bộ bảng và văn bản trong các ô của nó không?**

Có. Bảng cung cấp thuộc tính [RightToLeft](https://reference.aspose.com/slides/net/aspose.slides/table/righttoleft/) , và các đoạn văn có [ParagraphFormat.RightToLeft](https://reference.aspose.com/slides/net/aspose.slides/paragraphformat/righttoleft/) . Sử dụng cả hai đảm bảo thứ tự RTL đúng và hiển thị chính xác bên trong các ô.

**Làm thế nào để ngăn người dùng di chuyển hoặc thay đổi kích thước bảng trong tệp cuối cùng?**

Sử dụng [shape locks](/slides/vi/net/applying-protection-to-presentation/) để vô hiệu hoá việc di chuyển, thay đổi kích thước, chọn, v.v. Các khóa này cũng áp dụng cho bảng.

**Có hỗ trợ chèn hình ảnh vào bên trong ô làm nền không?**

Có. Bạn có thể đặt một [picture fill](https://reference.aspose.com/slides/net/aspose.slides/picturefillformat/) cho ô; hình ảnh sẽ bao phủ toàn bộ khu vực ô theo chế độ đã chọn (kéo giãn hoặc lát).