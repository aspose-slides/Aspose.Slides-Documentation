---
title: Quản lý bảng trình chiếu trong .NET
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
description: "Tạo và chỉnh sửa bảng trong các slide PowerPoint với Aspose.Slides cho .NET. Khám phá các ví dụ mã C# đơn giản để tối ưu hoá quy trình làm việc với bảng."
---
## **Giới thiệu**

Bảng trong PowerPoint là một cách hiệu quả để hiển thị và truyền đạt thông tin. Thông tin trong lưới các ô (sắp xếp theo hàng và cột) rất đơn giản và dễ hiểu.

Aspose.Slides cung cấp lớp [Table](https://reference.aspose.com/slides/vi/net/aspose.slides/table/) , giao diện [ITable](https://reference.aspose.com/slides/vi/net/aspose.slides/itable/) , lớp [Cell](https://reference.aspose.com/slides/vi/net/aspose.slides/cell/) , giao diện [ICell](https://reference.aspose.com/slides/vi/net/aspose.slides/icell/) và các kiểu khác để cho phép bạn tạo, cập nhật và quản lý các bảng trong mọi loại bản trình bày. 

## **Tạo bảng từ đầu**

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation) .
2. Lấy tham chiếu của slide thông qua chỉ mục của nó. 
3. Xác định một mảng `columnWidth`.
4. Xác định một mảng `rowHeight`.
5. Thêm một đối tượng [ITable](https://reference.aspose.com/slides/vi/net/aspose.slides/itable/) vào slide thông qua phương pháp [AddTable](https://reference.aspose.com/slides/vi/net/aspose.slides/ishapecollection/addtable/) .
6. Lặp qua từng [ICell](https://reference.aspose.com/slides/vi/net/aspose.slides/icell/) để áp dụng định dạng cho các đường viền trên, dưới, phải và trái.
7. Hợp nhất hai ô đầu tiên của hàng đầu tiên của bảng. 
8. Truy cập [TextFrame](https://reference.aspose.com/slides/vi/net/aspose.slides/textframe/) của một [ICell](https://reference.aspose.com/slides/vi/net/aspose.slides/icell/) . 
9. Thêm một số văn bản vào [TextFrame](https://reference.aspose.com/slides/vi/net/aspose.slides/textframe/) .
10. Lưu bản trình bày đã sửa đổi.

Mã C# này cho bạn thấy cách tạo bảng trong một bản trình bày:

```c#
// Khởi tạo một lớp Presentation đại diện cho tệp PPTX
Presentation pres = new Presentation();

// Truy cập slide đầu tiên
ISlide sld = pres.Slides[0];

// Xác định các cột với độ rộng và các hàng với độ cao
double[] dblCols = { 50, 50, 50 };
double[] dblRows = { 50, 30, 30, 30, 30 };

// Thêm một hình dạng bảng vào slide
ITable tbl = sld.Shapes.AddTable(100, 50, dblCols, dblRows);

// Đặt định dạng viền cho mỗi ô
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
// Hợp nhất các ô 1 và 2 của hàng 1
tbl.MergeCells(tbl.Rows[0][0], tbl.Rows[1][1], false);

// Thêm một số văn bản vào ô đã hợp nhất
tbl.Rows[0][0].TextFrame.Text = "Merged Cells";

// Lưu bản trình chiếu vào đĩa
pres.Save("table.pptx", SaveFormat.Pptx);
```

## **Đánh số trong một bảng tiêu chuẩn**

Trong một bảng tiêu chuẩn, việc đánh số các ô rất đơn giản và bắt đầu từ 0. Ô đầu tiên trong bảng được đánh chỉ số là 0,0 (cột 0, hàng 0). 

Ví dụ, các ô trong một bảng có 4 cột và 4 hàng được đánh số như sau:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

Mã C# này cho bạn thấy cách chỉ định đánh số cho các ô trong một bảng:

```c#
 // Khởi tạo một lớp Presentation đại diện cho tệp PPTX
 using (Presentation pres = new Presentation())
 {
 
     // Truy cập slide đầu tiên
     ISlide sld = pres.Slides[0];
 
     // Xác định các cột với độ rộng và các hàng với độ cao
     double[] dblCols = { 70, 70, 70, 70 };
     double[] dblRows = { 70, 70, 70, 70 };
 
     // Thêm một hình dạng bảng vào slide
     ITable tbl = sld.Shapes.AddTable(100, 50, dblCols, dblRows);
 
     // Đặt định dạng viền cho mỗi ô
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

## **Truy cập một bảng hiện có**

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation) .

2. Lấy tham chiếu tới slide chứa bảng thông qua chỉ mục của nó. 

3. Tạo một đối tượng [ITable](https://reference.aspose.com/slides/vi/net/aspose.slides/itable/) và gán nó bằng null.

4. Lặp qua tất cả các đối tượng [IShape](https://reference.aspose.com/slides/vi/net/aspose.slides/ishape/) cho tới khi tìm thấy bảng.

   Nếu bạn nghi ngờ slide đang xử lý chứa một bảng duy nhất, bạn có thể đơn giản kiểm tra tất cả các hình dạng mà nó chứa. Khi một hình dạng được xác định là bảng, bạn có thể ép kiểu nó thành đối tượng [Table](https://reference.aspose.com/slides/vi/net/aspose.slides/table/) . Nhưng nếu slide chứa nhiều bảng, thì tốt hơn hết bạn nên tìm kiếm bảng cần thiết qua thuộc tính [AlternativeText](https://reference.aspose.com/slides/vi/net/aspose.slides/ishape/alternativetext/) của nó.

5. Sử dụng đối tượng [ITable](https://reference.aspose.com/slides/vi/net/aspose.slides/itable/) để làm việc với bảng. Trong ví dụ dưới đây, chúng tôi đã thêm một hàng mới vào bảng.

6. Lưu bản trình bày đã sửa đổi.

Mã C# này cho bạn thấy cách truy cập và làm việc với một bảng hiện có:

```c#
// Khởi tạo một lớp Presentation đại diện cho tệp PPTX
using (Presentation pres = new Presentation("UpdateExistingTable.pptx"))
{

    // Truy cập slide đầu tiên
    ISlide sld = pres.Slides[0];

    // Khởi tạo TableEx null
    ITable tbl = null;

    // Duyệt qua các shape và đặt tham chiếu tới bảng được tìm thấy
    foreach (IShape shp in sld.Shapes)
        if (shp is ITable)
            tbl = (ITable)shp;

    // Đặt văn bản cho cột đầu tiên của hàng thứ hai
    tbl[0, 1].TextFrame.Text = "New";

    // Lưu bản trình chiếu đã sửa đổi vào đĩa
    pres.Save("table1_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **Căn chỉnh văn bản trong bảng**

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation) .
2. Lấy tham chiếu của slide thông qua chỉ mục của nó. 
3. Thêm một đối tượng [ITable](https://reference.aspose.com/slides/vi/net/aspose.slides/itable/) vào slide. 
4. Truy cập một đối tượng [ITextFrame](https://reference.aspose.com/slides/vi/net/aspose.slides/itextframe/) từ bảng. 
5. Truy cập [IParagraph](https://reference.aspose.com/slides/vi/net/aspose.slides/iparagraph/) của [ITextFrame](https://reference.aspose.com/slides/vi/net/aspose.slides/itextframe/) .
6. Căn chỉnh văn bản theo chiều dọc.
7. Lưu bản trình bày đã sửa đổi.

Mã C# này cho bạn thấy cách căn chỉnh văn bản trong bảng:

```c#
// Tạo một thể hiện của lớp Presentation
Presentation presentation = new Presentation();

// Lấy slide đầu tiên
ISlide slide = presentation.Slides[0];

// Xác định các cột với độ rộng và các hàng với độ cao
double[] dblCols = { 120, 120, 120, 120 };
double[] dblRows = { 100, 100, 100, 100 };

// Thêm hình dạng bảng vào slide
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
presentation.Save("Vertical_Align_Text_out.pptx", SaveFormat.Ppptx);
```

## **Đặt định dạng văn bản ở mức độ bảng**

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/) .
2. Lấy tham chiếu của slide thông qua chỉ mục của nó. 
3. Truy cập một đối tượng [ITable](https://reference.aspose.com/slides/vi/net/aspose.slides/itable/) từ Slide.
4. Đặt [FontHeight](https://reference.aspose.com/slides/vi/net/aspose.slides/baseportionformat/fontheight/) cho văn bản. 
5. Đặt [Alignment](https://reference.aspose.com/slides/vi/net/aspose.slides/iparagraphformat/alignment/) và [MarginRight](https://reference.aspose.com/slides/vi/net/aspose.slides/iparagraphformat/marginright/) . 
6. Đặt [TextVerticalType](https://reference.aspose.com/slides/vi/net/aspose.slides/textframeformat/textverticaltype/) .
7. Lưu bản trình bày đã sửa đổi. 

Mã C# này cho bạn thấy cách áp dụng các tùy chọn định dạng ưa thích cho văn bản trong bảng:

```c#
// Tạo một thể hiện của lớp Presentation
Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];

ITable someTable = presentation.Slides[0].Shapes[0] as ITable; // Giả sử rằng hình dạng đầu tiên trên slide đầu tiên là một bảng

// Đặt chiều cao phông chữ cho các ô của bảng
PortionFormat portionFormat = new PortionFormat();
portionFormat.FontHeight = 25;
someTable.SetTextFormat(portionFormat);

// Đặt căn chỉnh văn bản và lề phải cho các ô của bảng trong một lệnh
ParagraphFormat paragraphFormat = new ParagraphFormat();
paragraphFormat.Alignment = TextAlignment.Right;
paragraphFormat.MarginRight = 20;
someTable.SetTextFormat(paragraphFormat);

// Đặt loại văn bản dọc cho các ô của bảng
TextFrameFormat textFrameFormat = new TextFrameFormat();
textFrameFormat.TextVerticalType = TextVerticalType.Vertical;
someTable.SetTextFormat(textFrameFormat);


presentation.Save("result.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```

## **Lấy thuộc tính kiểu bảng**

Aspose.Slides cho phép bạn lấy các thuộc tính kiểu cho một bảng để bạn có thể sử dụng các chi tiết này cho bảng khác hoặc ở nơi khác. Mã C# này cho bạn thấy cách lấy các thuộc tính kiểu từ một kiểu bảng đã được đặt trước: 

```c#
using (Presentation pres = new Presentation())
{
    ITable table = pres.Slides[0].Shapes.AddTable(10, 10, new double[] { 100, 150 }, new double[] { 5, 5, 5 });
    table.StylePreset = TableStylePreset.DarkStyle1; // thay đổi chủ đề mẫu kiểu mặc định
    pres.Save("table.pptx", SaveFormat.Pptx);
}
```

## **Khóa tỷ lệ khung hình của bảng**

Tỷ lệ khung hình của một hình dạng hình học là tỉ lệ kích thước của nó trên các chiều khác nhau. Aspose.Slides cung cấp thuộc tính `AspectRatioLocked` để cho phép bạn khóa cài đặt tỷ lệ khung hình cho các bảng và các hình dạng khác. 

Mã C# này cho bạn thấy cách khóa tỷ lệ khung hình cho một bảng:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    ITable table = (ITable)pres.Slides[0].Shapes[0];
    Console.WriteLine($"Lock aspect ratio set: {table.ShapeLock.AspectRatioLocked}");

    table.ShapeLock.AspectRatioLocked = !table.ShapeLock.AspectRatioLocked; // đảo ngược

    Console.WriteLine($"Lock aspect ratio set: {table.ShapeLock.AspectRatioLocked}");

    pres.Save("pres-out.pptx", SaveFormat.Pptx);
}
```

## **Câu hỏi thường gặp**

**Tôi có thể bật chế độ đọc từ phải sang trái (RTL) cho toàn bộ bảng và văn bản trong các ô của nó không?**

Có. Bảng cung cấp thuộc tính [RightToLeft](https://reference.aspose.com/slides/vi/net/aspose.slides/table/righttoleft/) , và các đoạn văn có [ParagraphFormat.RightToLeft](https://reference.aspose.com/slides/vi/net/aspose.slides/paragraphformat/righttoleft/) . Sử dụng cả hai đảm bảo thứ tự và hiển thị RTL chính xác bên trong các ô.

**Làm thế nào để ngăn người dùng di chuyển hoặc thay đổi kích thước bảng trong tệp cuối cùng?**

Sử dụng [shape locks](/slides/vi/net/applying-protection-to-presentation/) để tắt việc di chuyển, thay đổi kích thước, chọn, v.v. Những khóa này cũng áp dụng cho bảng.

**Có hỗ trợ chèn hình ảnh vào bên trong một ô làm nền không?**

Có. Bạn có thể đặt một [picture fill](https://reference.aspose.com/slides/vi/net/aspose.slides/picturefillformat/) cho ô; hình ảnh sẽ phủ toàn bộ khu vực ô theo chế độ đã chọn (kéo dài hoặc lát gạch).