---
title: Quản lý hàng và cột trong bảng PowerPoint bằng .NET
linktitle: Hàng và Cột
type: docs
weight: 20
url: /vi/net/manage-rows-and-columns/
keywords:
- hàng bảng
- cột bảng
- hàng đầu tiên
- tiêu đề bảng
- nhân bản hàng
- nhân bản cột
- sao chép hàng
- sao chép cột
- xóa hàng
- xóa cột
- định dạng văn bản hàng
- định dạng văn bản cột
- kiểu bảng
- PowerPoint
- bài thuyết trình
- .NET
- C#
- Aspose.Slides
description: "Quản lý các hàng và cột của bảng trong PowerPoint với Aspose.Slides cho .NET và tăng tốc việc chỉnh sửa bài thuyết trình và cập nhật dữ liệu."
---
## **Giới thiệu**

Để cho phép bạn quản lý các hàng và cột của bảng trong một bài thuyết trình PowerPoint, Aspose.Slides cung cấp lớp [Table](https://reference.aspose.com/slides/vi/net/aspose.slides/table/) , giao diện [ITable](https://reference.aspose.com/slides/vi/net/aspose.slides/itable/) và nhiều loại khác. 

## **Đặt Hàng Đầu Tiên Là Tiêu Đề**

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation) và tải bài thuyết trình. 
2. Lấy tham chiếu của slide thông qua chỉ số của nó. 
3. Tạo một đối tượng [ITable](https://reference.aspose.com/slides/vi/net/aspose.slides/itable/) và đặt nó thành null. 
4. Duyệt qua tất cả các đối tượng [IShape](https://reference.aspose.com/slides/vi/net/aspose.slides/ishape/) để tìm bảng liên quan. 
5. Đặt hàng đầu tiên của bảng làm tiêu đề. 

Đoạn mã C# này cho bạn thấy cách đặt hàng đầu tiên của bảng làm tiêu đề:

```c#
// Tạo một thể hiện của lớp Presentation
Presentation pres = new Presentation("table.pptx");

// Accesses the first slide
ISlide sld = pres.Slides[0];

// Initializes the null TableEx
ITable tbl = null;

// Iterates through the shapes and sets a reference to the table
foreach (IShape shp in sld.Shapes)
{
    if (shp is ITable)
    {
        tbl = (ITable)shp;
    }
}

// Sets the first row of a table as its header
tbl.FirstRow = true;

// Saves the presentation to disk
pres.Save("First_row_header.pptx", SaveFormat.Pptx);
```


## **Sao chép một Hàng hoặc Cột của Bảng**

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation) và tải bài thuyết trình, 
2. Lấy tham chiếu của slide thông qua chỉ số của nó. 
3. Xác định một mảng `columnWidth`. 
4. Xác định một mảng `rowHeight`. 
5. Thêm một đối tượng [ITable](https://reference.aspose.com/slides/vi/net/aspose.slides/itable/) vào slide thông qua phương thức [AddTable](https://reference.aspose.com/slides/vi/net/aspose.slides/ishapecollection/addtable/). 
6. Sao chép hàng của bảng. 
7. Sao chép cột của bảng. 
8. Lưu bài thuyết trình đã sửa đổi. 

Đoạn mã C# này cho bạn thấy cách sao chép hàng hoặc cột của bảng PowerPoint:

```c#
 // Tạo một thể hiện của lớp Presentation
using (Presentation presentation = new Presentation("Test.pptx"))
{
    // Truy cập slide đầu tiên
    ISlide sld = presentation.Slides[0];

    // Xác định các cột với độ rộng và các hàng với độ cao
    double[] dblCols = { 50, 50, 50 };
    double[] dblRows = { 50, 30, 30, 30, 30 };

    // Thêm một hình dạng bảng vào slide
    ITable table = sld.Shapes.AddTable(100, 50, dblCols, dblRows);

    // Thêm một số văn bản vào ô 1 của hàng 1
    table[0, 0].TextFrame.Text = "Row 1 Cell 1";

    // Thêm một số văn bản vào ô 2 của hàng 1
    table[1, 0].TextFrame.Text = "Row 1 Cell 2";

    // Nhân bản hàng 1 ở cuối bảng
    table.Rows.AddClone(table.Rows[0], false);

    // Thêm một số văn bản vào ô 1 của hàng 2
    table[0, 1].TextFrame.Text = "Row 2 Cell 1";

    // Thêm một số văn bản vào ô 2 của hàng 2
    table[1, 1].TextFrame.Text = "Row 2 Cell 2";

    // Nhân bản hàng 2 làm hàng thứ 4 của bảng
    table.Rows.InsertClone(3,table.Rows[1], false);

    // Nhân bản cột đầu tiên ở cuối
    table.Columns.AddClone(table.Columns[0], false);

    // Nhân bản cột thứ 2 tại vị trí cột thứ 4
    table.Columns.InsertClone(3,table.Columns[1], false);
    
    // Lưu bài thuyết trình vào đĩa 
    presentation.Save("table_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **Xóa một Hàng hoặc Cột khỏi Bảng**

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation) và tải bài thuyết trình, 
2. Lấy tham chiếu của slide thông qua chỉ số của nó. 
3. Xác định một mảng `columnWidth`. 
4. Xác định một mảng `rowHeight`. 
5. Thêm một đối tượng [ITable](https://reference.aspose.com/slides/vi/net/aspose.slides/itable/) vào slide thông qua phương thức [AddTable](https://reference.aspose.com/slides/vi/net/aspose.slides/ishapecollection/addtable/). 
6. Xóa hàng của bảng. 
7. Xóa cột của bảng. 
8. Lưu bài thuyết trình đã sửa đổi. 

Đoạn mã C# này cho bạn thấy cách xóa một hàng hoặc cột khỏi bảng:

```c#
Presentation pres = new Presentation();

ISlide slide = pres.Slides[0];
double[] colWidth = { 100, 50, 30 };
double[] rowHeight = { 30, 50, 30 };

ITable table = slide.Shapes.AddTable(100, 100, colWidth, rowHeight);
table.Rows.RemoveAt(1, false);
table.Columns.RemoveAt(1, false);
pres.Save("TestTable_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```

## **Đặt Định Dạng Văn Bản ở Cấp Độ Hàng Bảng**

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation) và tải bài thuyết trình, 
2. Lấy tham chiếu của slide thông qua chỉ số của nó. 
3. Truy cập vào đối tượng [ITable](https://reference.aspose.com/slides/vi/net/aspose.slides/itable/) liên quan từ slide. 
4. Đặt [FontHeight](https://reference.aspose.com/slides/vi/net/aspose.slides/baseportionformat/fontheight/) cho các ô của hàng đầu tiên. 
5. Đặt [Alignment](https://reference.aspose.com/slides/vi/net/aspose.slides/iparagraphformat/alignment/) và [MarginRight](https://reference.aspose.com/slides/vi/net/aspose.slides/iparagraphformat/marginright/) cho các ô của hàng đầu tiên. 
6. Đặt [TextVerticalType](https://reference.aspose.com/slides/vi/net/aspose.slides/textframeformat/textverticaltype/) cho các ô của hàng thứ hai. 
7. Lưu bài thuyết trình đã sửa đổi. 

Đoạn mã C# này minh họa thao tác này.

```c#
// Tạo một thể hiện của lớp Presentation
Presentation presentation = new Presentation();
           
ISlide slide = presentation.Slides[0];

ITable someTable = presentation.Slides[0].Shapes[0] as ITable; // Giả sử rằng hình dạng đầu tiên trên slide đầu tiên là một bảng

// Đặt chiều cao phông chữ cho các ô của hàng đầu tiên
PortionFormat portionFormat = new PortionFormat();
portionFormat.FontHeight = 25;
someTable.Rows[0].SetTextFormat(portionFormat);

// Đặt căn chỉnh văn bản và lề phải cho các ô của hàng đầu tiên
ParagraphFormat paragraphFormat = new ParagraphFormat();
paragraphFormat.Alignment = TextAlignment.Right;
paragraphFormat.MarginRight = 20;
someTable.Rows[0].SetTextFormat(paragraphFormat);

// Đặt kiểu dọc của văn bản cho các ô của hàng thứ hai
TextFrameFormat textFrameFormat = new TextFrameFormat();
textFrameFormat.TextVerticalType = TextVerticalType.Vertical;
someTable.Rows[1].SetTextFormat(textFrameFormat);

// Lưu bài thuyết trình vào đĩa
presentation.Save("result.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```

## **Đặt Định Dạng Văn Bản ở Cấp Độ Cột Bảng**

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation) và tải bài thuyết trình, 
2. Lấy tham chiếu của slide thông qua chỉ số của nó. 
3. Truy cập vào đối tượng [ITable](https://reference.aspose.com/slides/vi/net/aspose.slides/itable/) liên quan từ slide. 
4. Đặt [FontHeight](https://reference.aspose.com/slides/vi/net/aspose.slides/baseportionformat/fontheight/) cho các ô của cột đầu tiên. 
5. Đặt [Alignment](https://reference.aspose.com/slides/vi/net/aspose.slides/iparagraphformat/alignment/) và [MarginRight](https://reference.aspose.com/slides/vi/net/aspose.slides/iparagraphformat/marginright/) cho các ô của cột đầu tiên. 
6. Đặt [TextVerticalType](https://reference.aspose.com/slides/vi/net/aspose.slides/textframeformat/textverticaltype/) cho các ô của cột thứ hai. 
7. Lưu bài thuyết trình đã sửa đổi. 

Đoạn mã C# này minh họa thao tác này: 

```c#
// Tạo một thể hiện của lớp Presentation
Presentation pres = new Presentation();
           
ISlide slide = pres.Slides[0];

ITable someTable = pres.Slides[0].Shapes[0] as ITable; // Giả sử rằng hình dạng đầu tiên trên slide đầu tiên là một bảng

// Đặt chiều cao phông chữ cho các ô của cột đầu tiên
PortionFormat portionFormat = new PortionFormat();
portionFormat.FontHeight = 25;
someTable.Columns[0].SetTextFormat(portionFormat);

// Đặt căn chỉnh văn bản và lề phải cho các ô của cột đầu tiên trong một lần gọi
ParagraphFormat paragraphFormat = new ParagraphFormat();
paragraphFormat.Alignment = TextAlignment.Right;
paragraphFormat.MarginRight = 20;
someTable.Columns[0].SetTextFormat(paragraphFormat);

// Đặt kiểu dọc của văn bản cho các ô của cột thứ hai
TextFrameFormat textFrameFormat = new TextFrameFormat();
textFrameFormat.TextVerticalType = TextVerticalType.Vertical;
someTable.Columns[1].SetTextFormat(textFrameFormat);

// Lưu bài thuyết trình vào đĩa
pres.Save("result.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

```

## **Lấy Thuộc Tính Kiểu Bảng**

Aspose.Slides cho phép bạn truy xuất các thuộc tính kiểu cho một bảng để có thể sử dụng các chi tiết này cho bảng khác hoặc ở nơi khác. Đoạn mã C# này cho bạn thấy cách lấy các thuộc tính kiểu từ kiểu bàn preset của bảng: 

```c#
using (Presentation pres = new Presentation())
{
    ITable table = pres.Slides[0].Shapes.AddTable(10, 10, new double[] { 100, 150 }, new double[] { 5, 5, 5 });
    table.StylePreset = TableStylePreset.DarkStyle1; // thay đổi chủ đề mẫu kiểu mặc định
    pres.Save("table.pptx", SaveFormat.Pptx);
}
```

## **Câu Hỏi Thường Gặp**

**Tôi có thể áp dụng chủ đề/phong cách PowerPoint cho một bảng đã được tạo không?**

Có. Bảng kế thừa chủ đề của slide/bố cục/maaster, và bạn vẫn có thể ghi đè lên các màu nền, viền và màu chữ trên chủ đề đó.

**Tôi có thể sắp xếp các hàng của bảng giống như trong Excel không?**

Không, bảng Aspose.Slides không có tính năng sắp xếp hoặc bộ lọc tích hợp. Hãy sắp xếp dữ liệu trong bộ nhớ trước, sau đó điền lại các hàng của bảng theo thứ tự đó.

**Tôi có thể có các cột được dải (đánh sọc) trong khi vẫn giữ màu tùy chỉnh cho các ô cụ thể không?**

Có. Bật tính năng cột dải, sau đó ghi đè các ô cụ thể bằng định dạng cục bộ; định dạng ở mức ô sẽ ưu tiên hơn kiểu bảng.