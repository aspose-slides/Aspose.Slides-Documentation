---
title: Quản lý Hộp Văn Bản trong Bản Trình chiếu trên .NET
linktitle: Quản lý Hộp Văn Bản
type: docs
weight: 20
url: /vi/net/manage-textbox/
keywords:
- hộp văn bản
- khung văn bản
- thêm văn bản
- cập nhật văn bản
- tạo hộp văn bản
- kiểm tra hộp văn bản
- thêm cột văn bản
- thêm siêu liên kết
- PowerPoint
- bản trình chiếu
- .NET
- C#
- Aspose.Slides
description: "Tạo, xác định, định dạng và cập nhật hộp văn bản trong các bản trình chiếu PowerPoint và OpenDocument bằng Aspose.Slides cho .NET."
---
## **Giới thiệu**

Trong Aspose.Slides for .NET, văn bản trên slide được lưu trong các khung văn bản thuộc về các hình dạng. Giao diện [IAutoShape](https://reference.aspose.com/slides/vi/net/aspose.slides/iautoshape/) đại diện cho hình dạng chứa văn bản phổ biến nhất và cung cấp văn bản của nó thông qua thuộc tính [IAutoShape.TextFrame](https://reference.aspose.com/slides/vi/net/aspose.slides/iautoshape/textframe/).

{{% alert color="info" title="Note" %}}
Mỗi hình tự động đều thực hiện [IShape](https://reference.aspose.com/slides/vi/net/aspose.slides/ishape/), nhưng không phải mọi hình đều là hình tự động hoặc hỗ trợ khung văn bản. Khi xử lý một bản trình chiếu hiện có, hãy kiểm tra xem một hình có thực hiện `IAutoShape` hay không trước khi truy cập văn bản của nó.
{{% /alert %}}

## **Tạo một Hộp Văn Bản trên Slide**

Để tạo một hộp văn bản, thêm một hình tự động vào slide, thêm văn bản vào khung văn bản của nó và lưu bản trình chiếu. Ví dụ sau tạo một hộp văn bản hình chữ nhật:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var textBox = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 75, 300, 50);
textBox.AddTextFrame("Aspose TextBox");

presentation.Save("TextBox.pptx", SaveFormat.Pptx);
```

Các tọa độ và kích thước được truyền vào [IShapeCollection.AddAutoShape](https://reference.aspose.com/slides/vi/net/aspose.slides/ishapecollection/addautoshape/) được đo bằng điểm. [IAutoShape.AddTextFrame](https://reference.aspose.com/slides/vi/net/aspose.slides/iautoshape/addtextframe/) khởi tạo khung văn bản với văn bản được cung cấp.

## **Kiểm tra Hình Hộp Văn Bản**

Sử dụng thuộc tính [AutoShape.IsTextBox](https://reference.aspose.com/slides/vi/net/aspose.slides/autoshape/istextbox/) để xác định xem một hình tự động có được coi là hộp văn bản hay không. Điều này hữu ích khi một bản trình chiếu chứa cả các hình tự động có văn bản và các hình tự động chỉ có đồ họa.

![Một hộp văn bản và một hình dạng](istextbox.png)

Ví dụ sau kiểm tra mọi hình tự động trong một bản trình chiếu:

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var textBox = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 120, 40);
textBox.AddTextFrame("Text box");
slide.Shapes.AddAutoShape(ShapeType.Ellipse, 150, 10, 40, 40);

foreach (var currentSlide in presentation.Slides)
{
    foreach (var shape in currentSlide.Shapes)
    {
        if (shape is IAutoShape autoShape)
        {
            Console.WriteLine(autoShape.IsTextBox ? "The shape is a text box." : "The shape is not a text box.");
        }
    }
}
```

Một hình tự động mới được thêm vào sẽ không được xem là hộp văn bản cho đến khi nó chứa văn bản không rỗng. Bạn có thể cung cấp văn bản đó thông qua [IAutoShape.AddTextFrame](https://reference.aspose.com/slides/vi/net/aspose.slides/iautoshape/addtextframe/) hoặc [ITextFrame.Text](https://reference.aspose.com/slides/vi/net/aspose.slides/itextframe/text/). Thêm hoặc gán một chuỗi rỗng sẽ để `IsTextBox` ở trạng thái `false`:

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape1 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 40);
shape1.AddTextFrame("Shape 1");
Console.WriteLine(shape1.IsTextBox);

var shape2 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 70, 100, 40);
shape2.TextFrame.Text = "Shape 2";
Console.WriteLine(shape2.IsTextBox);

var shape3 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 130, 100, 40);
shape3.AddTextFrame("");
Console.WriteLine(shape3.IsTextBox);

var shape4 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 190, 100, 40);
shape4.TextFrame.Text = "";
Console.WriteLine(shape4.IsTextBox);
```

Hai lời gọi đầu tiên in ra `True`; hai lời gọi cuối in ra `False`.

## **Tìm Hình Sở Hữu Khung Văn Bản**

Mã xử lý văn bản chung có thể nhận một [ITextFrame](https://reference.aspose.com/slides/vi/net/aspose.slides/itextframe/) mà không biết đối tượng bản trình chiếu nào chứa nó. Hãy sử dụng thuộc tính chỉ đọc [ITextFrame.ParentShape](https://reference.aspose.com/slides/vi/net/aspose.slides/itextframe/parentshape/) để quay lại hình sở hữu [IShape](https://reference.aspose.com/slides/vi/net/aspose.slides/ishape/).

Đối với khung văn bản được sở hữu bởi một hình tự động hoặc một hình dạng khác chứa văn bản, `ParentShape` chứa chủ sở hữu và [ITextFrame.ParentCell](https://reference.aspose.com/slides/vi/net/aspose.slides/itextframe/parentcell/) có giá trị `null`. Kiểm tra giá trị trả về trước khi truy cập. Để xác định cả chủ sở hữu hình và ô bảng, bao gồm các hình liên kết với nút SmartArt, xem [Tìm và Thay Thế Văn Bản](/slides/vi/net/search-and-replace-text/).

## **Thêm Cột vào Hộp Văn Bản**

Thuộc tính [ITextFrameFormat.ColumnCount](https://reference.aspose.com/slides/vi/net/aspose.slides/itextframeformat/columncount/) chia khung văn bản thành các cột, trong khi [ITextFrameFormat.ColumnSpacing](https://reference.aspose.com/slides/vi/net/aspose.slides/itextframeformat/columnspacing/) thiết lập khoảng cách giữa các cột bằng điểm. Cả hai thiết lập này thuộc về [ITextFrameFormat](https://reference.aspose.com/slides/vi/net/aspose.slides/itextframeformat/) và có thể thay đổi thông qua khung văn bản của một hộp văn bản hiện có. Văn bản được sắp lại giữa các cột trong cùng một hình; nó không tiếp tục sang hình khác.

Ví dụ sau tạo một hộp văn bản ba cột với khoảng cách 10 điểm giữa các cột, lưu bản trình chiếu và đọc lại các cài đặt đã lưu từ tệp kết quả:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var textBox = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 300, 200);
textBox.AddTextFrame("This text is distributed automatically across all columns in the text box.");

var textFrameFormat = textBox.TextFrame.TextFrameFormat;
textFrameFormat.ColumnCount = 3;
textFrameFormat.ColumnSpacing = 10;

presentation.Save("TextBoxColumns.pptx", SaveFormat.Pptx);

using var savedPresentation = new Presentation("TextBoxColumns.pptx");
var savedTextBox = (IAutoShape)savedPresentation.Slides[0].Shapes[0];
var savedFormat = savedTextBox.TextFrame.TextFrameFormat;
Console.WriteLine($"Columns: {savedFormat.ColumnCount}; spacing: {savedFormat.ColumnSpacing} points");
```

## **Trích xuất Văn Bản từ Các Cột Riêng Lẻ**

Sử dụng [TextFrame.SplitTextByColumns](https://reference.aspose.com/slides/vi/net/aspose.slides/textframe/splittextbycolumns/) để lấy văn bản được gán cho mỗi cột hiển thị trong một khung văn bản hiện có. Phương thức trả về một chuỗi cho mỗi cột, theo thứ tự đọc dựa trên cột. Một khung văn bản một cột tạo ra một mảng với một phần tử, và một cột rỗng được biểu diễn bằng một chuỗi rỗng. Các chuỗi chỉ chứa văn bản thuần; định dạng cấp phần không được bảo lưu.

Điều này hữu ích khi bạn cần:

- Trích xuất văn bản đồng thời bảo lưu thứ tự đọc dựa trên cột.
- Đánh chỉ mục hoặc so sánh nội dung của các slide đa cột.
- Xuất mỗi cột ra một tệp riêng, trường cơ sở dữ liệu hoặc đích khác.
- Kiểm tra cách văn bản được phân phối lại sau khi thay đổi [ITextFrameFormat.ColumnCount](https://reference.aspose.com/slides/vi/net/aspose.slides/itextframeformat/columncount/), [ITextFrameFormat.ColumnSpacing](https://reference.aspose.com/slides/vi/net/aspose.slides/itextframeformat/columnspacing/), phông chữ hoặc kích thước khung văn bản.

Phương thức báo cáo văn bản phân phối trong [ITextFrame](https://reference.aspose.com/slides/vi/net/aspose.slides/itextframe/) hiện tại; nó không tự động chuyển văn bản giữa các hình hoặc hộp văn bản riêng biệt. Phân phối cột có thể phụ thuộc vào phông chữ có sẵn và các thiết lập bố cục văn bản khác, vì vậy hãy đảm bảo các phông chữ cần thiết có sẵn khi kết quả nhất quán là quan trọng.

Ví dụ sau tải một bản trình chiếu, tìm hình tự động đa cột đầu tiên có khung văn bản, đọc số cột đã cấu hình và ghi văn bản từ mỗi cột ra một tệp riêng. Các hình không cung cấp khung văn bản sẽ bị bỏ qua.

```csharp
using System;
using System.IO;
using Aspose.Slides;

using var presentation = new Presentation("MultiColumnText.pptx");

IAutoShape? textBox = null;
foreach (var shape in presentation.Slides[0].Shapes)
{
    if (shape is IAutoShape autoShape && autoShape.TextFrame is not null)
    {
        var columnCount = autoShape.TextFrame.TextFrameFormat.ColumnCount;
        if (columnCount > 1)
        {
            textBox = autoShape;
            break;
        }
    }
}

if (textBox is null)
{
    Console.WriteLine("No multi-column text frame was found.");
}
else
{
    var textFrame = textBox.TextFrame;
    var configuredColumnCount = textFrame.TextFrameFormat.ColumnCount;
    var columnTexts = textFrame.SplitTextByColumns();

    Console.WriteLine($"Configured columns: {configuredColumnCount}");

    for (var columnIndex = 0; columnIndex < columnTexts.Length; columnIndex++)
    {
        var columnNumber = columnIndex + 1;
        var columnText = columnTexts[columnIndex];
        Console.WriteLine($"Column {columnNumber}: {columnText}");
        File.WriteAllText($"Column-{columnNumber}.txt", columnText);
    }
}
```

## **Cập nhật Văn Bản**

Để cập nhật văn bản trong toàn bộ bản trình chiếu, lặp qua các slide và hình dạng, chọn các hình tự động, sau đó chỉnh sửa các phần văn bản của chúng. Làm việc ở mức phần cho phép bạn thay đổi cả văn bản và định dạng ký tự.

Ví dụ sau thay thế mọi lần xuất hiện của `years` bằng `months` trong văn bản của hình tự động và làm in đậm mỗi phần bị ảnh hưởng:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("Text.pptx");

foreach (var slide in presentation.Slides)
{
    foreach (var shape in slide.Shapes)
    {
        if (shape is not IAutoShape autoShape)
        {
            continue;
        }

        foreach (var paragraph in autoShape.TextFrame.Paragraphs)
        {
            foreach (var portion in paragraph.Portions)
            {
                portion.Text = portion.Text.Replace("years", "months");
                portion.PortionFormat.FontBold = NullableBool.True;
            }
        }
    }
}

presentation.Save("TextChanged.pptx", SaveFormat.Pptx);
```

Quá trình duyệt này chỉ cập nhật văn bản trong các hình tự động. Văn bản được lưu trong bảng, biểu đồ, SmartArt hoặc các hình nhóm yêu cầu duyệt các bộ sưu tập riêng của các đối tượng đó.

## **Thêm Hộp Văn Bản với Siêu Liên Kết**

Một siêu liên kết có thể được gán cho một phần văn bản cụ thể, vì vậy chỉ phần văn bản đó sẽ hoạt động như một liên kết có thể nhấp. Sử dụng [IHyperlinkManager.SetExternalHyperlinkClick](https://reference.aspose.com/slides/vi/net/aspose.slides/ihyperlinkmanager/setexternalhyperlinkclick/) để liên kết phần đó với một URL bên ngoài.

Ví dụ sau tạo văn bản có liên kết và lưu nó vào một bản trình chiếu:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var textBox = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 150, 200, 50);
textBox.AddTextFrame("Aspose.Slides");

var textPortion = textBox.TextFrame.Paragraphs[0].Portions[0];
textPortion.PortionFormat.HyperlinkManager.SetExternalHyperlinkClick("https://www.aspose.com/");

presentation.Save("Hyperlink.pptx", SaveFormat.Pptx);
```

## **FAQ**

**What is the difference between a text box and a text placeholder on a master or layout slide?**

Một [placeholder](/slides/vi/net/manage-placeholder/) có thể kế thừa vị trí và định dạng từ một [master slide](https://reference.aspose.com/slides/vi/net/aspose.slides/masterslide/) hoặc [layout slide](https://reference.aspose.com/slides/vi/net/aspose.slides/layoutslide/). Một hộp văn bản thông thường là một hình độc lập trên slide nơi nó được tạo và không nhận hành vi của trình giữ chỗ khi bố cục thay đổi.

**How can I replace text without changing text in charts, tables, or SmartArt?**

Hạn chế việc duyệt chỉ các hình dạng thực hiện [IAutoShape](https://reference.aspose.com/slides/vi/net/aspose.slides/iautoshape/), như đã trình bày trong ví dụ Cập nhật Văn Bản. Các biểu đồ, bảng và SmartArt lưu văn bản trong mô hình đối tượng riêng của chúng, vì vậy chúng sẽ không bị thay đổi bởi vòng lặp đó.