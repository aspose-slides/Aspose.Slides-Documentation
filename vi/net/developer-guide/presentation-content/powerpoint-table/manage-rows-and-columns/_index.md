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
- bản trình chiếu
- .NET
- C#
- Aspose.Slides
description: "Quản lý các hàng và cột của bảng trong PowerPoint bằng Aspose.Slides for .NET và tăng tốc việc chỉnh sửa bản trình chiếu cũng như cập nhật dữ liệu."
---
## **Giới thiệu**

Aspose.Slides for .NET cho phép bạn quản lý cấu trúc và định dạng bảng trong các bản trình chiếu PowerPoint thông qua lớp [Table](https://reference.aspose.com/slides/net/aspose.slides/table/) và giao diện [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/). Bạn có thể chỉ định một hàng tiêu đề, sao chép hoặc xóa các hàng và cột, và áp dụng định dạng văn bản cho toàn bộ hàng hoặc cột.

Bài viết này giải thích các thao tác này bằng các ví dụ C#. Nó cũng cho thấy cách lấy preset kiểu bảng để bạn có thể tái sử dụng. Các chỉ số hàng và cột của bảng được đánh số bắt đầu từ 0.

## **Kiểm soát chiều cao hàng**

Sử dụng [IRow.MinimalHeight](https://reference.aspose.com/slides/net/aspose.slides/irow/minimalheight/) để đặt chiều cao tối thiểu của một hàng tính bằng điểm. Đây là mức dưới, không phải chiều cao cố định. [IRow.Height](https://reference.aspose.com/slides/net/aspose.slides/irow/height/) trả về chiều cao thực tế và chỉ đọc. Truy cập hàng thông qua [ITable.Rows](https://reference.aspose.com/slides/net/aspose.slides/itable/rows/).

Ví dụ tải [row-height-input.pptx](row-height-input.pptx), trong đó bảng là hình dạng đầu tiên trên slide đầu tiên. Hàng đầu tiên của nó bắt đầu tại 70 điểm. Các ô sử dụng văn bản Arial 18 điểm, có ngắt dòng và lề trên dưới 6 điểm; văn bản dài hơn trong cột thứ hai ngắt dòng thành nhiều dòng. Ví dụ tăng tối thiểu lên 100 điểm, sau đó giảm xuống 20 điểm, in chiều cao thực tế sau mỗi thay đổi, và lưu cả hai kết quả.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("row-height-input.pptx");
var table = (ITable)presentation.Slides[0].Shapes[0];
var row = table.Rows[0];

row.MinimalHeight = 100;
Console.WriteLine($"Increased: minimum = {row.MinimalHeight:F1}, actual = {row.Height:F1} pt");
presentation.Save("row-height-increased.pptx", SaveFormat.Pptx);

row.MinimalHeight = 20;
Console.WriteLine($"Decreased: minimum = {row.MinimalHeight:F1}, actual = {row.Height:F1} pt");
presentation.Save("row-height-decreased.pptx", SaveFormat.Pptx);
```

Với bản trình chiếu được cung cấp, việc tăng tối thiểu sẽ thêm không gian vào hàng. Giảm nó sẽ loại bỏ không gian thừa, nhưng chiều cao thực tế vẫn lớn hơn 20 điểm vì văn bản và lề ô cần nhiều không gian hơn. Chỉ giảm tối thiểu không thể ép hàng xuống dưới mức không gian cần thiết cho nội dung.

Một số yếu tố ảnh hưởng đến chiều cao thực tế:

- **Văn bản và kích thước phông:** văn bản dài hơn, ngắt dòng thủ công, hoặc phông lớn hơn có thể yêu cầu nhiều không gian theo chiều dọc hơn.
- **Ngắt dòng và chiều rộng cột:** khi bật ngắt dòng, một [IColumn.Width](https://reference.aspose.com/slides/net/aspose.slides/icolumn/width/) hẹp hơn có thể tạo ra nhiều dòng hơn. Cột rộng hơn có thể giảm không gian cần thiết theo chiều dọc.
- **Lề ô:** [ICell.MarginTop](https://reference.aspose.com/slides/net/aspose.slides/icell/margintop/) và [ICell.MarginBottom](https://reference.aspose.com/slides/net/aspose.slides/icell/marginbottom/) thêm không gian theo chiều dọc. [ICell.MarginLeft](https://reference.aspose.com/slides/net/aspose.slides/icell/marginleft/) và [ICell.MarginRight](https://reference.aspose.com/slides/net/aspose.slides/icell/marginright/) giảm chiều rộng có sẵn cho văn bản và có thể gây ngắt dòng bổ sung.

Đối với bảng này không có ô hợp nhất, ô cần nhiều không gian theo chiều dọc nhất sẽ quyết định giới hạn dưới dựa trên nội dung cho toàn bộ hàng. Để làm hàng ngắn hơn, bạn cũng có thể cần rút ngắn văn bản, giảm kích thước phông hoặc lề, hoặc làm rộng cột.

Các hình ảnh dưới đây cho thấy cùng một bảng ở cùng tỉ lệ. Trong lần chạy này, các chiều cao thực tế là 70, 100 và 55.2 điểm: hàng cuối cùng vẫn cao hơn mức tối thiểu 20 điểm. Các đo lường văn bản chính xác có thể thay đổi tùy theo phông có sẵn trong môi trường của bạn. Tải các kết quả đã lưu: [tối thiểu tăng](row-height-increased.pptx) và [tối thiểu giảm](row-height-decreased.pptx).

| Gốc: tối thiểu 70 pt, thực tế 70 pt | Tăng: tối thiểu 100 pt, thực tế 100 pt | Giảm: tối thiểu 20 pt, thực tế 55.2 pt |
| --- | --- | --- |
| ![Original table with a 70-point first row.](row-height-before.png) | ![Table after increasing the first row minimum to 100 points.](row-height-increased.png) | ![Table after decreasing the first row minimum to 20 points; wrapped text keeps the row taller than the minimum.](row-height-decreased.png) |

## **Đặt hàng đầu tiên làm tiêu đề**

Sử dụng thuộc tính [FirstRow](https://reference.aspose.com/slides/net/aspose.slides/itable/firstrow/) để đánh dấu hàng đầu tiên cho định dạng tiêu đề. Hiển thị của nó phụ thuộc vào kiểu bảng được áp dụng cho bảng.

1. Tải bản trình chiếu bằng lớp [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
2. Truy cập slide đầu tiên.
3. Truy cập bảng được lưu dưới dạng hình dạng đầu tiên trên slide.
4. Bật định dạng tiêu đề cho hàng đầu tiên của nó.
5. Lưu bản trình chiếu đã sửa đổi.

Ví dụ yêu cầu `table.pptx` với một bảng là hình dạng đầu tiên trên slide đầu tiên. Nó bật định dạng tiêu đề cho hàng đầu tiên và lưu `First_row_header.pptx`.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("table.pptx");
var slide = presentation.Slides[0];

var table = (ITable)slide.Shapes[0];
table.FirstRow = true;

presentation.Save("First_row_header.pptx", SaveFormat.Pptx);
```

## **Sao chép một hàng hoặc cột bảng**

Sao chép các hàng hoặc cột để tái sử dụng nội dung và định dạng của chúng. Bạn có thể thêm một bản sao vào cuối bảng hoặc chèn vào vị trí cụ thể.

1. Tải bản trình chiếu bằng lớp [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
2. Truy cập slide đầu tiên.
3. Xác định chiều rộng cột và chiều cao hàng.
4. Thêm bảng bằng phương thức [AddTable](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addtable/).
5. Sao chép các hàng cần thiết.
6. Sao chép các cột cần thiết.
7. Lưu bản trình chiếu đã sửa đổi.

Ví dụ yêu cầu `Test.pptx` có ít nhất một slide. Nó tạo một bảng với ba cột và năm hàng, với các kích thước được chỉ định bằng điểm. Nó thêm các bản sao của hàng và cột đầu tiên, sau đó chèn các bản sao của hàng và cột thứ hai tại chỉ mục 3 (vị trí thứ tư). Bảng kết quả có bảy hàng và năm cột. Tham số `false` vô hiệu hoá việc sao chép vào các hàng hoặc cột hợp nhất kề; bảng này không có ô hợp nhất.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("Test.pptx");
var slide = presentation.Slides[0];

var columnWidths = new double[] { 50, 50, 50 };
var rowHeights = new double[] { 50, 30, 30, 30, 30 };
var table = slide.Shapes.AddTable(100, 50, columnWidths, rowHeights);

table[0, 0].TextFrame.Text = "Row 1 Cell 1";
table[1, 0].TextFrame.Text = "Row 1 Cell 2";
table.Rows.AddClone(table.Rows[0], false);

table[0, 1].TextFrame.Text = "Row 2 Cell 1";
table[1, 1].TextFrame.Text = "Row 2 Cell 2";
table.Rows.InsertClone(3, table.Rows[1], false);

table.Columns.AddClone(table.Columns[0], false);
table.Columns.InsertClone(3, table.Columns[1], false);

presentation.Save("table_out.pptx", SaveFormat.Pptx);
```

## **Xóa một hàng hoặc cột khỏi bảng**

Xóa các hàng hoặc cột không còn cần thiết trong bảng. Khi xóa một mục, chỉ số của các hàng hoặc cột phía sau nó sẽ dịch chuyển.

1. Tạo một bản trình chiếu bằng lớp [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
2. Truy cập slide đầu tiên.
3. Xác định chiều rộng cột và chiều cao hàng.
4. Thêm bảng bằng phương thức [AddTable](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addtable/).
5. Xóa hàng thứ hai và cột thứ hai.
6. Lưu bản trình chiếu đã sửa đổi.

Ví dụ này tạo một bảng ba‑by‑ba và xóa hàng và cột tại chỉ mục 1, để lại một bảng hai‑by‑hai trong `TestTable_out.pptx`. Các kích thước được tính bằng điểm. Tham số `false` vô hiệu hoá việc xóa các hàng hoặc cột hợp nhất kề; bảng này không có ô hợp nhất.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var columnWidths = new double[] { 100, 50, 30 };
var rowHeights = new double[] { 30, 50, 30 };
var table = slide.Shapes.AddTable(100, 100, columnWidths, rowHeights);

table.Rows.RemoveAt(1, false);
table.Columns.RemoveAt(1, false);

presentation.Save("TestTable_out.pptx", SaveFormat.Pptx);
```

## **Đặt định dạng văn bản ở mức hàng bảng**

Áp dụng định dạng văn bản cho toàn bộ hàng để giữ cho các ô của nó đồng nhất. Bạn có thể đặt các thuộc tính phông, định dạng đoạn văn và hướng văn bản mà không cần định dạng từng ô riêng lẻ.

1. Tải bản trình chiếu bằng lớp [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
2. Truy cập bảng trên slide đầu tiên.
3. Đặt [FontHeight](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/fontheight/) cho hàng đầu tiên.
4. Đặt [Alignment](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/alignment/) và [MarginRight](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/marginright/) cho hàng đầu tiên.
5. Đặt [TextVerticalType](https://reference.aspose.com/slides/net/aspose.slides/textframeformat/textverticaltype/) cho hàng thứ hai.
6. Lưu bản trình chiếu đã sửa đổi.

Ví dụ yêu cầu `table.pptx` với một bảng là hình dạng đầu tiên trên slide đầu tiên và ít nhất hai hàng. Nó áp dụng văn bản 25 điểm, căn phải, và lề đoạn văn phải 20 điểm cho hàng đầu tiên, sau đó đặt văn bản dọc cho hàng thứ hai.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("table.pptx");
var slide = presentation.Slides[0];

var table = (ITable)slide.Shapes[0];

var portionFormat = new PortionFormat { FontHeight = 25 };
table.Rows[0].SetTextFormat(portionFormat);

var paragraphFormat = new ParagraphFormat { Alignment = TextAlignment.Right, MarginRight = 20 };
table.Rows[0].SetTextFormat(paragraphFormat);

var textFrameFormat = new TextFrameFormat { TextVerticalType = TextVerticalType.Vertical };
table.Rows[1].SetTextFormat(textFrameFormat);

presentation.Save("row_formatting.pptx", SaveFormat.Pptx);
```

## **Đặt định dạng văn bản ở mức cột bảng**

Áp dụng định dạng văn bản cho toàn bộ cột để giữ cho các ô của nó đồng nhất. Bạn có thể đặt các thuộc tính phông, định dạng đoạn văn và hướng văn bản mà không cần định dạng từng ô riêng lẻ.

1. Tải bản trình chiếu bằng lớp [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
2. Truy cập bảng trên slide đầu tiên.
3. Đặt [FontHeight](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/fontheight/) cho cột đầu tiên.
4. Đặt [Alignment](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/alignment/) và [MarginRight](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/marginright/) cho cột đầu tiên.
5. Đặt [TextVerticalType](https://reference.aspose.com/slides/net/aspose.slides/textframeformat/textverticaltype/) cho cột thứ hai.
6. Lưu bản trình chiếu đã sửa đổi.

Ví dụ yêu cầu `table.pptx` với một bảng là hình dạng đầu tiên trên slide đầu tiên và ít nhất hai cột. Nó áp dụng văn bản 25 điểm, căn phải, và lề đoạn văn phải 20 điểm cho cột đầu tiên, sau đó đặt văn bản dọc cho cột thứ hai.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("table.pptx");
var slide = presentation.Slides[0];

var table = (ITable)slide.Shapes[0];

var portionFormat = new PortionFormat { FontHeight = 25 };
table.Columns[0].SetTextFormat(portionFormat);

var paragraphFormat = new ParagraphFormat { Alignment = TextAlignment.Right, MarginRight = 20 };
table.Columns[0].SetTextFormat(paragraphFormat);

var textFrameFormat = new TextFrameFormat { TextVerticalType = TextVerticalType.Vertical };
table.Columns[1].SetTextFormat(textFrameFormat);

presentation.Save("column_formatting.pptx", SaveFormat.Pptx);
```

## **Lấy thuộc tính kiểu bảng**

Sử dụng thuộc tính [StylePreset](https://reference.aspose.com/slides/net/aspose.slides/itable/stylepreset/) để lấy preset đã áp dụng cho một bảng và tái sử dụng nó cho bảng khác. Điều này xác định preset thay vì các ghi đè định dạng cá nhân trên ô.

Ví dụ tạo một bảng, áp dụng [TableStylePreset.DarkStyle1](https://reference.aspose.com/slides/net/aspose.slides/tablestylepreset/), và đọc lại preset. Nó in ra `DarkStyle1` và lưu bảng trong `table.pptx`.

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

Console.WriteLine(table.StylePreset);

presentation.Save("table.pptx", SaveFormat.Pptx);
```

## **Câu hỏi thường gặp**

**Có thể áp dụng chủ đề/kiểu PowerPoint cho một bảng đã được tạo sẵn không?**

Có. Bảng kế thừa chủ đề slide/bố cục/mẫu, và bạn vẫn có thể ghi đè màu nền, viền và màu chữ phía trên chủ đề đó.

**Có thể sắp xếp các hàng bảng như trong Excel không?**

Không, các bảng Aspose.Slides không có tính năng sắp xếp hoặc lọc tích hợp. Hãy sắp xếp dữ liệu trong bộ nhớ trước, sau đó điền lại các hàng bảng theo thứ tự đó.

**Có thể có các cột dải (kẻ sọc) trong khi vẫn giữ màu tùy chỉnh cho các ô cụ thể không?**

Có. Bật các cột dải, sau đó ghi đè các ô cụ thể bằng định dạng cục bộ; định dạng ở mức ô sẽ ưu tiên hơn kiểu bảng.