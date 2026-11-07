---
title: Quản lý các hộp văn bản trong bản trình chiếu trên .NET
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
description: "Tạo, nhận dạng, định dạng và cập nhật các hộp văn bản trong các bản trình chiếu PowerPoint và OpenDocument bằng Aspose.Slides cho .NET."
---
## **Giới thiệu**

Trong Aspose.Slides for .NET, văn bản trên slide được lưu trong các khung văn bản thuộc về các hình dạng. Giao diện [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) đại diện cho hình dạng chứa văn bản phổ biến nhất và cung cấp văn bản của nó thông qua thuộc tính [IAutoShape.TextFrame](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/textframe/).

{{% alert color="info" title="Note" %}}
Mỗi auto shape thực hiện [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/), nhưng không phải mọi shape đều là auto shape hoặc hỗ trợ khung văn bản. Khi xử lý một bản trình chiếu hiện có, hãy kiểm tra xem một shape có thực hiện `IAutoShape` hay không trước khi truy cập vào văn bản của nó.
{{% /alert %}}

## **Tạo một Hộp Văn Bản trên Slide**

Để tạo một hộp văn bản, thêm một auto shape vào slide, thêm văn bản vào khung văn bản của nó và lưu bản trình chiếu. Ví dụ sau tạo một hộp văn bản hình chữ nhật:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var textBox = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 75, 300, 50);
textBox.AddTextFrame("Aspose TextBox");

presentation.Save("TextBox.pptx", SaveFormat.Pptx);
```

Các tọa độ và kích thước truyền vào [IShapeCollection.AddAutoShape](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addautoshape/) được đo bằng điểm. [IAutoShape.AddTextFrame](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/addtextframe/) khởi tạo khung văn bản với văn bản được cung cấp.

## **Kiểm tra Hình dạng Hộp Văn Bản**

Sử dụng thuộc tính [AutoShape.IsTextBox](https://reference.aspose.com/slides/net/aspose.slides/autoshape/istextbox/) để xác định xem một auto shape có được coi là hộp văn bản hay không. Điều này hữu ích khi một bản trình chiếu chứa cả các auto shape chứa văn bản và các auto shape chỉ là đồ họa.

![Một hộp văn bản và một hình dạng](istextbox.png)

Ví dụ sau kiểm tra mọi auto shape trong một bản trình chiếu:

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

Một auto shape mới được thêm vào không được coi là hộp văn bản cho đến khi nó chứa văn bản không rỗng. Bạn có thể cung cấp văn bản đó thông qua [IAutoShape.AddTextFrame](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/addtextframe/) hoặc [ITextFrame.Text](https://reference.aspose.com/slides/net/aspose.slides/itextframe/text/). Thêm hoặc gán một chuỗi rỗng sẽ để `IsTextBox` là `false`:

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

Hai lời gọi đầu tiên in ra `True`; hai lời gọi cuối cùng in ra `False`.

## **Tìm Hình dạng Sở hữu Khung Văn Bản**

Mã xử lý văn bản chung có thể nhận được một [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/) mà không biết đối tượng trình chiếu nào chứa nó. Sử dụng thuộc tính chỉ đọc [ITextFrame.ParentShape](https://reference.aspose.com/slides/net/aspose.slides/itextframe/parentshape/) để điều hướng trở lại [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/) sở hữu nó.

Đối với một khung văn bản thuộc sở hữu của auto shape hoặc một hình dạng chứa văn bản khác, `ParentShape` chứa chủ sở hữu và [ITextFrame.ParentCell](https://reference.aspose.com/slides/net/aspose.slides/itextframe/parentcell/) là `null`. Kiểm tra giá trị trả về trước khi truy cập. Để xác định cả chủ sở hữu hình dạng và ô bảng, bao gồm các hình dạng liên kết với nút SmartArt, hãy xem [Search and Replace Text](/slides/vi/net/search-and-replace-text/).

## **Lấy Hình chữ nhật Văn bản của Hình dạng**

Bắt đầu với Aspose.Slides for .NET 26.11, [ITextFrame.GetTextRect](https://reference.aspose.com/slides/net/aspose.slides/itextframe/gettextrect/) trả về vùng văn bản được định nghĩa bởi hình học của hình cha. Các tọa độ và kích thước của nó được tính bằng điểm, so với góc trên‑trái của hình đó. Ví dụ, một hình ellipse có hình chữ nhật văn bản nhỏ hơn so với giới hạn bên ngoài của nó.

Hình chữ nhật này mô tả hình dạng, không phải các ký tự đã được vẽ. Thay đổi văn bản hoặc lề của khung văn bản không làm cho nó trở thành phép đo của văn bản đã chiếm. Sử dụng [paragraph bounds](/slides/vi/net/paragraph-bounds/) hoặc [portion bounds](/slides/vi/net/portion-bounds/) để đo kích thước văn bản đã được vẽ.

Sau khi [installing Aspose.Slides for .NET](/slides/vi/net/installation/) 26.11 hoặc mới hơn, chạy ví dụ này để vẽ hình chữ nhật văn bản hình học bằng màu đỏ. Các hình không được xoay và không được nhóm, vì vậy việc cộng vị trí X/Y của chúng đủ để đặt lớp phủ lên slide.

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

foreach (var shapeType in new[] { ShapeType.Rectangle, ShapeType.Ellipse })
{
    var x = shapeType == ShapeType.Rectangle ? 50 : 300;
    var shape = slide.Shapes.AddAutoShape(shapeType, x, 200, 200, 100);
    shape.AddTextFrame("Text area");
    var rectangle = shape.TextFrame.GetTextRect();
    Console.WriteLine($"{shapeType}: {rectangle}");

    var overlayX = shape.X + rectangle.X;
    var overlayY = shape.Y + rectangle.Y;
    var outline = slide.Shapes.AddAutoShape(ShapeType.Rectangle, overlayX, overlayY, rectangle.Width, rectangle.Height);
    outline.FillFormat.FillType = FillType.NoFill;
    outline.LineFormat.FillFormat.FillType = FillType.Solid;
    outline.LineFormat.FillFormat.SolidFillColor.Color = Color.Red;
}

presentation.Save("text-rectangles.pptx", SaveFormat.Pptx);
```

Đối với các hình 200 × 100 điểm ở trên, hình chữ nhật trả về `(0, 0, 200, 100)`; ellipse trả về khoảng `(29.289, 14.645, 141.421, 70.711)`. Phương thức này cũng đọc hình chữ nhật văn bản được khai báo của hình học tùy chỉnh. Nó không áp dụng việc xoay không gian slide hoặc biến đổi nhóm; hãy tính đến chúng riêng khi định vị lớp phủ. Một khung văn bản không có hình học, như khung văn bản ô bảng, có thể gây ra `InvalidOperationException`.

## **Thêm Cột vào Hộp Văn Bản**

Thuộc tính [ITextFrameFormat.ColumnCount](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/columncount/) chia khung văn bản thành các cột, trong khi [ITextFrameFormat.ColumnSpacing](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/columnspacing/) đặt khoảng cách giữa các cột tính bằng điểm. Cả hai thiết lập này thuộc về [ITextFrameFormat](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/) và có thể thay đổi thông qua khung văn bản của một hộp văn bản hiện có. Văn bản được luân chuyển lại giữa các cột trong cùng một hình dạng; nó không tiếp tục sang một hình dạng khác.

Ví dụ sau tạo một hộp văn bản ba cột với 10 điểm giữa các cột, lưu bản trình chiếu, và đọc lại các thiết lập đã lưu từ tệp xuất:

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

## **Trích xuất Văn bản từ Các Cột Riêng Lẻ**

Sử dụng [TextFrame.SplitTextByColumns](https://reference.aspose.com/slides/net/aspose.slides/textframe/splittextbycolumns/) để lấy văn bản được gán cho mỗi cột nhìn thấy trong một khung văn bản hiện có. Phương thức này trả về một chuỗi cho mỗi cột, theo thứ tự đọc dựa trên cột. Một khung văn bản một cột sẽ tạo một mảng chứa một phần tử, và một cột trống được biểu diễn bằng một chuỗi rỗng. Các chuỗi chỉ chứa văn bản thuần; định dạng cấp phần không được giữ lại.

- Trích xuất văn bản trong khi duy trì thứ tự đọc dựa trên cột.
- Lập chỉ mục hoặc so sánh nội dung của các slide đa cột.
- Xuất mỗi cột ra một tệp riêng, trường cơ sở dữ liệu, hoặc đích khác.
- Kiểm tra cách văn bản được phân phối lại sau khi thay đổi [ITextFrameFormat.ColumnCount](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/columncount/), [ITextFrameFormat.ColumnSpacing](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/columnspacing/), phông chữ hoặc kích thước khung văn bản.

Phương thức này báo cáo văn bản được phân phối trong [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/) hiện tại; nó không tự động chuyển văn bản giữa các hình dạng hoặc hộp văn bản riêng biệt. Phân phối cột có thể phụ thuộc vào phông chữ có sẵn và các cài đặt bố cục văn bản khác, vì vậy hãy chắc chắn rằng các phông chữ cần thiết có sẵn khi kết quả nhất quán là quan trọng.

Ví dụ sau tải một bản trình chiếu, tìm auto shape đa cột đầu tiên có khung văn bản, đọc số cột đã cấu hình, và ghi văn bản từ mỗi cột vào một tệp riêng. Các hình không có khung văn bản sẽ bị bỏ qua.

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

## **Cập nhật Văn bản**

Để cập nhật văn bản trong toàn bộ bản trình chiếu, lặp qua các slide và hình dạng, chọn các auto shape, sau đó chỉnh sửa các phần văn bản của chúng. Làm việc ở mức phần cho phép bạn thay đổi cả văn bản và định dạng ký tự.

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

Quá trình duyệt này chỉ cập nhật văn bản trong các auto shape. Văn bản lưu trong bảng, biểu đồ, SmartArt hoặc các hình dạng được nhóm yêu cầu duyệt qua các bộ sưu tập riêng của các đối tượng đó.

## **Thêm Hộp Văn Bản với Siêu liên kết**

Một siêu liên kết có thể được gán cho một phần văn bản cụ thể, do đó chỉ văn bản đó hoạt động như liên kết có thể nhấp. Sử dụng [IHyperlinkManager.SetExternalHyperlinkClick](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkmanager/setexternalhyperlinkclick/) để liên kết phần đó với URL bên ngoài.

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

## **Câu hỏi thường gặp**

**Sự khác biệt giữa hộp văn bản và trình giữ chỗ văn bản trên slide master hoặc layout là gì?**

Một [placeholder](/slides/vi/net/manage-placeholder/) có thể kế thừa vị trí và định dạng từ một [master slide](https://reference.aspose.com/slides/net/aspose.slides/masterslide/) hoặc [layout slide](https://reference.aspose.com/slides/net/aspose.slides/layoutslide/). Một hộp văn bản thông thường là một hình dạng độc lập trên slide nơi nó được tạo và không nhận hành vi của trình giữ chỗ khi layout thay đổi.

**Làm sao tôi có thể thay thế văn bản mà không thay đổi văn bản trong biểu đồ, bảng hoặc SmartArt?**

Giới hạn quá trình duyệt chỉ tới các hình dạng thực hiện [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/), như đã minh họa trong ví dụ Cập nhật Văn bản. Biểu đồ, bảng và SmartArt lưu văn bản trong mô hình đối tượng riêng của chúng, vì vậy chúng không bị thay đổi bởi vòng lặp đó.