---
title: Quản lý bảng trong bản trình chiếu bằng .NET
linktitle: Quản lý bảng
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
description: "Tạo & chỉnh sửa bảng trong các slide PowerPoint với Aspose.Slides cho .NET. Khám phá các ví dụ mã C# đơn giản để tối ưu hoá quy trình làm việc với bảng của bạn."
---
## **Giới thiệu**

Một bảng trong PowerPoint là một cách hiệu quả để hiển thị và mô tả thông tin. Thông tin trong lưới các ô (được sắp xếp thành hàng và cột) trực quan và dễ hiểu.

Aspose.Slides cung cấp lớp [Table](https://reference.aspose.com/slides/vi/net/aspose.slides/table/), giao diện [ITable](https://reference.aspose.com/slides/vi/net/aspose.slides/itable/), lớp [Cell](https://reference.aspose.com/slides/vi/net/aspose.slides/cell/), giao diện [ICell](https://reference.aspose.com/slides/vi/net/aspose.slides/icell/) và các kiểu khác để cho phép bạn tạo, cập nhật và quản lý bảng trong mọi loại bài thuyết trình. 

## **Tạo bảng từ đầu**

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation) .
2. Lấy tham chiếu đến slide qua chỉ mục của nó. 
3. Định nghĩa một mảng `columnWidth`.
4. Định nghĩa một mảng `rowHeight`.
5. Thêm một đối tượng [ITable](https://reference.aspose.com/slides/vi/net/aspose.slides/itable/) vào slide bằng phương thức [AddTable](https://reference.aspose.com/slides/vi/net/aspose.slides/ishapecollection/addtable/) .
6. Duyệt qua từng [ICell](https://reference.aspose.com/slides/vi/net/aspose.slides/icell/) để áp dụng định dạng cho các đường viền trên, dưới, phải và trái.
7. Gộp hai ô đầu tiên của hàng đầu tiên trong bảng. 
8. Truy cập [TextFrame](https://reference.aspose.com/slides/vi/net/aspose.slides/textframe/) của một [ICell](https://reference.aspose.com/slides/vi/net/aspose.slides/icell/) . 
9. Thêm một số văn bản vào [TextFrame](https://reference.aspose.com/slides/vi/net/aspose.slides/textframe/) .
10. Lưu bản trình chiếu đã chỉnh sửa.

Đoạn mã C# này cho thấy cách tạo một bảng trong bản trình chiếu:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// Khởi tạo một lớp Presentation đại diện cho tệp PPTX
Presentation pres = new Presentation();

// Accesses the first slide
ISlide sld = pres.Slides[0];

// Defines columns with widths and rows with heights
double[] dblCols = { 50, 50, 50 };
double[] dblRows = { 50, 30, 30, 30, 30 };

// Adds a table shape to the slide
ITable tbl = sld.Shapes.AddTable(100, 50, dblCols, dblRows);

// Sets the border format for each cell
for (int row = 0; row < tbl.Rows.Count; row++)
{
	for (int cell = 0; cell < tbl.Rows[row].Count; cell++)
	{
		tbl.Rows[row][cell].CellFormat.BorderTop.FillFormat.FillType = FillType.Solid;
		tbl.Rows[row][cell].CellFormat.BorderTop.FillFormat.SolidFillColor.Color = Color.Red;
		tbl.Rows[row][cell].CellFormat.BorderTop.Width = 5;

		tbl.Rows[row][cell].CellFormat.BorderBottom.FillFormat.FillType = (FillType.Solid);
		tbl.Rows[row][cell].CellFormat.BorderBottom.FillFormat.SolidFillColor.Color= Color.Red;
		tbl.Rows[row][cell].CellFormat.BorderBottom.Width =5;

		tbl.Rows[row][cell].CellFormat.BorderLeft.FillFormat.FillType = FillType.Solid;
		tbl.Rows[row][cell].CellFormat.BorderLeft.FillFormat.SolidFillColor.Color =Color.Red;
		tbl.Rows[row][cell].CellFormat.BorderLeft.Width = 5;

		tbl.Rows[row][cell].CellFormat.BorderRight.FillFormat.FillType = FillType.Solid;
		tbl.Rows[row][cell].CellFormat.BorderRight.FillFormat.SolidFillColor.Color = Color.Red;
		tbl.Rows[row][cell].CellFormat.BorderRight.Width = 5;
	}
}
// Gộp các ô 1 và 2 của hàng 1
tbl.MergeCells(tbl.Rows[0][0], tbl.Rows[0][1], false);

// Thêm một số văn bản vào ô đã gộp
tbl.Rows[0][0].TextFrame.Text = "Merged Cells";

// Lưu bản trình chiếu vào đĩa
pres.Save("table.pptx", SaveFormat.Pptx);
```

## **Đánh số trong bảng chuẩn**

Trong một bảng chuẩn, việc đánh số các ô là đơn giản và bắt đầu từ 0. Ô đầu tiên trong bảng có chỉ mục là 0,0 (cột 0, hàng 0). 

Ví dụ, các ô trong một bảng có 4 cột và 4 hàng được đánh số như sau:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

Đoạn mã C# này tạo bảng chuẩn 4 × 4 được đánh số ở trên và thiết lập định dạng đường viền cho mỗi ô:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// Khởi tạo một lớp Presentation đại diện cho tệp PPTX
using (Presentation pres = new Presentation())
{

    // Truy cập slide đầu tiên
    ISlide sld = pres.Slides[0];

    // Xác định các cột với độ rộng và các hàng với độ cao
    double[] dblCols = { 70, 70, 70, 70 };
    double[] dblRows = { 70, 70, 70, 70 };

    // Thêm một shape bảng vào slide
    ITable tbl = sld.Shapes.AddTable(100, 50, dblCols, dblRows);

    // Đặt định dạng đường viền cho mỗi ô
    foreach (IRow row in tbl.Rows)
    {
        foreach (ICell cell in row)
        {
			cell.CellFormat.BorderTop.FillFormat.FillType = FillType.Solid;
			cell.CellFormat.BorderTop.FillFormat.SolidFillColor.Color = Color.Red;
			cell.CellFormat.BorderTop.Width = 5;

			cell.CellFormat.BorderBottom.FillFormat.FillType = FillType.Solid;
			cell.CellFormat.BorderBottom.FillFormat.SolidFillColor.Color = Color.Red;
			cell.CellFormat.BorderBottom.Width = 5;

			cell.CellFormat.BorderLeft.FillFormat.FillType = FillType.Solid;
			cell.CellFormat.BorderLeft.FillFormat.SolidFillColor.Color = Color.Red;
			cell.CellFormat.BorderLeft.Width = 5;

			cell.CellFormat.BorderRight.FillFormat.FillType = FillType.Solid;
			cell.CellFormat.BorderRight.FillFormat.SolidFillColor.Color = Color.Red;
			cell.CellFormat.BorderRight.Width = 5;
        }
    }

    // Lưu bản trình chiếu vào đĩa
    pres.Save("StandardTables_out.pptx", SaveFormat.Pptx);
}
```

## **Truy cập bảng hiện có**

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation) .

2. Lấy tham chiếu đến slide chứa bảng qua chỉ mục của nó. 

3. Tạo một đối tượng [ITable](https://reference.aspose.com/slides/vi/net/aspose.slides/itable/) và gán nó bằng null.

4. Duyệt qua tất cả các đối tượng [IShape](https://reference.aspose.com/slides/vi/net/aspose.slides/ishape/) cho đến khi tìm thấy bảng.

   Nếu bạn nghi ngờ slide đang làm việc chứa một bảng duy nhất, bạn có thể kiểm tra tất cả các shape trong nó. Khi một shape được xác định là bảng, bạn có thể ép kiểu nó thành đối tượng [Table](https://reference.aspose.com/slides/vi/net/aspose.slides/table/) . Nhưng nếu slide chứa nhiều bảng, tốt hơn là tìm bảng bạn cần qua thuộc tính [AlternativeText](https://reference.aspose.com/slides/vi/net/aspose.slides/ishape/alternativetext/) .

5. Sử dụng đối tượng [ITable](https://reference.aspose.com/slides/vi/net/aspose.slides/itable/) để làm việc với bảng. Trong ví dụ dưới, chúng tôi đã thêm một hàng mới vào bảng.

6. Lưu bản trình chiếu đã chỉnh sửa.

Đoạn mã C# này cho thấy cách truy cập và làm việc với một bảng hiện có:

```c#
using Aspose.Slides;

// Khởi tạo một lớp Presentation đại diện cho tệp PPTX
using (Presentation pres = new Presentation("UpdateExistingTable.pptx"))
{

    // Truy cập slide đầu tiên
    ISlide sld = pres.Slides[0];

    // Khởi tạo TableEx null
    ITable tbl = null;

    // Duyệt qua các shape và thiết lập tham chiếu tới bảng được tìm thấy
    foreach (IShape shp in sld.Shapes)
        if (shp is ITable)
            tbl = (ITable)shp;

    // Đặt văn bản cho cột đầu tiên của hàng thứ hai
    tbl[0, 1].TextFrame.Text = "New";

    // Lưu bản trình chiếu đã chỉnh sửa vào đĩa
    pres.Save("table1_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **Tìm ô chứa khung văn bản**

Khi mã xử lý văn bản chung nhận được một [ITextFrame](https://reference.aspose.com/slides/vi/net/aspose.slides/itextframe/) từ bảng, hãy sử dụng thuộc tính [ITextFrame.ParentCell](https://reference.aspose.com/slides/vi/net/aspose.slides/itextframe/parentcell/) để lấy ô [ICell](https://reference.aspose.com/slides/vi/net/aspose.slides/icell/) sở hữu. Đối với khung văn bản của ô bảng, [ITextFrame.ParentCell](https://reference.aspose.com/slides/vi/net/aspose.slides/itextframe/parentcell/) được đặt và [ITextFrame.ParentShape](https://reference.aspose.com/slides/vi/net/aspose.slides/itextframe/parentshape/) là `null`, mặc dù bảng tự nó là một shape.

Các tọa độ ô có sẵn qua các thuộc tính chỉ‑read‑only [ICell.FirstColumnIndex](https://reference.aspose.com/slides/vi/net/aspose.slides/icell/firstcolumnindex/) và [ICell.FirstRowIndex](https://reference.aspose.com/slides/vi/net/aspose.slides/icell/firstrowindex/) . [ITextFrame.ParentCell](https://reference.aspose.com/slides/vi/net/aspose.slides/itextframe/parentcell/) cũng chỉ‑read‑only: nó cung cấp hướng dẫn tới chủ sở hữu nhưng không thay đổi quyền sở hữu. Luôn luôn kiểm tra giá trị trả về có phải `null` trước khi sử dụng.

Đối với ví dụ đầy đủ xác định chủ sở hữu ô bảng và shape, bao gồm các shape liên kết với nút SmartArt, xem [Search and Replace Text](/slides/vi/net/search-and-replace-text/) .

## **Căn chỉnh văn bản trong bảng**

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation) .
2. Lấy tham chiếu đến slide qua chỉ mục của nó. 
3. Thêm một đối tượng [ITable](https://reference.aspose.com/slides/vi/net/aspose.slides/itable/) vào slide. 
4. Truy cập một đối tượng [ITextFrame](https://reference.aspose.com/slides/vi/net/aspose.slides/itextframe/) từ bảng. 
5. Truy cập [IParagraph](https://reference.aspose.com/slides/vi/net/aspose.slides/iparagraph/) của [ITextFrame](https://reference.aspose.com/slides/vi/net/aspose.slides/itextframe/) .
6. Căn chỉnh văn bản theo chiều dọc.
7. Lưu bản trình chiếu đã chỉnh sửa.

Đoạn mã C# này cho thấy cách căn chỉnh văn bản trong bảng:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// Tạo một thể hiện của lớp Presentation
Presentation presentation = new Presentation();

// Lấy slide đầu tiên
ISlide slide = presentation.Slides[0];

// Xác định các cột với độ rộng và các hàng với độ cao
double[] dblCols = { 120, 120, 120, 120 };
double[] dblRows = { 100, 100, 100, 100 };

// Thêm shape bảng vào slide
ITable tbl = slide.Shapes.AddTable(100, 50, dblCols, dblRows);
tbl[1, 0].TextFrame.Text = "10";
tbl[2, 0].TextFrame.Text = "20";
tbl[3, 0].TextFrame.Text = "30";

// Truy cập khung văn bản
ITextFrame txtFrame = tbl[0, 0].TextFrame;

// Tạo đối tượng Paragraph cho khung văn bản
IParagraph paragraph = txtFrame.Paragraphs[0];

// Tạo đối tượng Portion cho đoạn văn
IPortion portion = paragraph.Portions[0];
portion.Text = "Text here";
portion.PortionFormat.FillFormat.FillType = FillType.Solid;
portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;

// Căn chỉnh văn bản theo chiều dọc
ICell cell = tbl[0, 0];
cell.TextAnchorType = TextAnchorType.Center;
cell.TextVerticalType = TextVerticalType.Vertical270;

// Lưu bản trình chiếu vào đĩa
presentation.Save("Vertical_Align_Text_out.pptx", SaveFormat.Pptx);
```

## **Đặt định dạng văn bản ở mức bảng**

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/) .
2. Lấy tham chiếu đến slide qua chỉ mục của nó. 
3. Truy cập một đối tượng [ITable](https://reference.aspose.com/slides/vi/net/aspose.slides/itable/) từ Slide.
4. Đặt [FontHeight](https://reference.aspose.com/slides/vi/net/aspose.slides/baseportionformat/fontheight/) cho văn bản. 
5. Đặt [Alignment](https://reference.aspose.com/slides/vi/net/aspose.slides/iparagraphformat/alignment/) và [MarginRight](https://reference.aspose.com/slides/vi/net/aspose.slides/iparagraphformat/marginright/) .
6. Đặt [TextVerticalType](https://reference.aspose.com/slides/vi/net/aspose.slides/textframeformat/textverticaltype/) .
7. Lưu bản trình chiếu đã chỉnh sửa. 

Đoạn mã C# này cho thấy cách áp dụng các tùy chọn định dạng ưa thích cho văn bản trong bảng:

```c#
using Aspose.Slides;

// Tạo một thể hiện của lớp Presentation
Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];

ITable someTable = presentation.Slides[0].Shapes[0] as ITable; // Giả sử shape đầu tiên trên slide đầu tiên là một bảng

// Đặt độ cao phông chữ cho các ô bảng
PortionFormat portionFormat = new PortionFormat();
portionFormat.FontHeight = 25;
someTable.SetTextFormat(portionFormat);

// Đặt căn chỉnh văn bản và lề phải của các ô bảng trong một lệnh
ParagraphFormat paragraphFormat = new ParagraphFormat();
paragraphFormat.Alignment = TextAlignment.Right;
paragraphFormat.MarginRight = 20;
someTable.SetTextFormat(paragraphFormat);

// Đặt kiểu dọc của văn bản cho các ô bảng
TextFrameFormat textFrameFormat = new TextFrameFormat();
textFrameFormat.TextVerticalType = TextVerticalType.Vertical;
someTable.SetTextFormat(textFrameFormat);


presentation.Save("result.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```

## **Lấy thuộc tính kiểu bảng**

Aspose.Slides cho phép bạn lấy các thuộc tính kiểu cho một bảng để có thể sử dụng các chi tiết này cho bảng khác hoặc ở nơi khác. Đoạn mã C# này cho thấy cách lấy các thuộc tính kiểu từ một kiểu bảng đã được cài sẵn: 

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation())
{
    ITable table = pres.Slides[0].Shapes.AddTable(10, 10, new double[] { 100, 150 }, new double[] { 5, 5, 5 });
    table.StylePreset = TableStylePreset.DarkStyle1; // thay đổi preset style mặc định 

    // Lấy preset style của bảng.
    TableStylePreset stylePreset = table.StylePreset;
    Console.WriteLine($"Table style preset: {stylePreset}");

    // Áp dụng preset style đã lấy cho bảng khác.
    ITable anotherTable = pres.Slides[0].Shapes.AddTable(10, 100, new double[] { 100, 150 }, new double[] { 5, 5, 5 });
    anotherTable.StylePreset = stylePreset;

    pres.Save("table.pptx", SaveFormat.Pptx);
}
```

## **Khóa tỷ lệ khung hình của bảng**

Tỷ lệ khung hình của một shape hình học là tỷ lệ giữa các kích thước của nó trên các chiều khác nhau. Aspose.Slides cung cấp thuộc tính `AspectRatioLocked` để cho phép bạn khóa cài đặt tỷ lệ khung hình cho các bảng và các shape khác. 

Đoạn mã C# này cho thấy cách khóa tỷ lệ khung hình cho một bảng:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation("pres.pptx"))
{
    ITable table = (ITable)pres.Slides[0].Shapes[0];
    Console.WriteLine($"Lock aspect ratio set: {table.ShapeLock.AspectRatioLocked}");

    table.ShapeLock.AspectRatioLocked = !table.ShapeLock.AspectRatioLocked; // đảo ngược

    Console.WriteLine($"Lock aspect ratio set: {table.ShapeLock.AspectRatioLocked}");

    pres.Save("pres-out.pptx", SaveFormat.Pptx);
}
```

## **FAQ**

**Tôi có thể bật chế độ đọc từ phải sang trái (RTL) cho toàn bộ bảng và văn bản trong các ô không?**

Có. Bảng cung cấp thuộc tính [RightToLeft](https://reference.aspose.com/slides/vi/net/aspose.slides/table/righttoleft/) , và các đoạn văn có thuộc tính [ParagraphFormat.RightToLeft](https://reference.aspose.com/slides/vi/net/aspose.slides/paragraphformat/righttoleft/) . Sử dụng cả hai sẽ đảm bảo thứ tự và hiển thị RTL đúng trong các ô.

**Làm thế nào để ngăn người dùng di chuyển hoặc thay đổi kích thước bảng trong tệp cuối cùng?**

Sử dụng [shape locks](/slides/vi/net/applying-protection-to-presentation/) để tắt di chuyển, thay đổi kích thước, chọn, v.v. Các khóa này cũng áp dụng cho bảng.

**Có hỗ trợ chèn ảnh vào ô làm nền không?**

Có. Bạn có thể đặt một [picture fill](https://reference.aspose.com/slides/vi/net/aspose.slides/picturefillformat/) cho ô; ảnh sẽ bao phủ khu vực ô theo chế độ đã chọn (kéo dài hoặc lặp).