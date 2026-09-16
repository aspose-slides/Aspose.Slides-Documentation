---
title: Quản lý Siêu Liên Kết Bản Trình Chiếu trong .NET
linktitle: Quản lý Siêu Liên Kết
type: docs
weight: 20
url: /vi/net/manage-hyperlinks/
keywords:
- thêm URL
- thêm siêu liên kết
- tạo siêu liên kết
- định dạng siêu liên kết
- xóa siêu liên kết
- cập nhật siêu liên kết
- siêu liên kết văn bản
- siêu liên kết slide
- siêu liên kết hình dạng
- siêu liên kết hình ảnh
- siêu liên kết video
- siêu liên kết có thể sửa đổi
- PowerPoint
- OpenDocument
- bản trình chiếu
- .NET
- C#
- Aspose.Slides
description: "Thêm, định dạng, cập nhật và xóa siêu liên kết trong các bản trình chiếu PowerPoint và OpenDocument bằng Aspose.Slides cho .NET, sử dụng các ví dụ C#."
---
## **Giới thiệu**

Siêu liên kết kết nối nội dung bản trình chiếu với một trang web hoặc một vị trí trong bản trình chiếu. Trong PowerPoint, siêu liên kết thường phục vụ hai mục đích:

* Mở một trang web từ văn bản, một hình dạng hoặc một khung đa phương tiện.  
* Điều hướng đến một slide khác, ví dụ, từ mục lục.

Aspose.Slides for .NET cho phép bạn thêm các liên kết này, kiểm soát giao diện và âm thanh của chúng, cập nhật các thuộc tính và xóa chúng. Các ví dụ dưới đây cho thấy cách làm việc với siêu liên kết trên các phần tử riêng lẻ và cách truy cập siêu liên kết ở mức bản trình chiếu, slide hoặc khung văn bản.

{{% alert color="info" title="Note" %}}
Bạn cũng có thể chỉnh sửa bản trình chiếu bằng [trình chỉnh sửa PowerPoint trực tuyến miễn phí của Aspose](https://products.aspose.app/slides/vi/editor).
{{% /alert %}} 

## **Thêm Siêu Liên Kết URL**

Bạn có thể gán URL của trang web cho văn bản, hình dạng hoặc khung đa phương tiện. Phần tử mà bạn gán siêu liên kết sẽ xác định khu vực có thể nhấp: một đoạn văn bản sẽ liên kết tới văn bản đã chọn, trong khi một hình dạng hoặc khung sẽ liên kết tới đối tượng slide.

### **Thêm Siêu Liên Kết URL vào Văn Bản**

Để liên kết văn bản tới một trang web, gán một [Hyperlink](https://reference.aspose.com/slides/vi/net/aspose.slides/hyperlink/) cho thuộc tính [HyperlinkClick](https://reference.aspose.com/slides/vi/net/aspose.slides/portionformat/hyperlinkclick/) của đoạn văn bản, như được minh họa bên dưới. Chỉ phần văn bản đó sẽ trở nên có thể nhấp.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var textShape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 600, 50, false);
textShape.AddTextFrame("Aspose: File Format APIs");
var portionFormat = textShape.TextFrame.Paragraphs[0].Portions[0].PortionFormat;
portionFormat.HyperlinkClick = new Hyperlink("https://www.aspose.com/");
portionFormat.HyperlinkClick.Tooltip = "Explore Aspose file format APIs";
portionFormat.FontHeight = 32;

presentation.Save("presentation-out.pptx", SaveFormat.Pptx);
```

### **Thêm Siêu Liên Kết URL vào Hình Dạng và Khung Đa Phương Tiện**

Để làm cho một hình dạng hoặc khung có thể nhấp, đặt thuộc tính [HyperlinkClick](https://reference.aspose.com/slides/vi/net/aspose.slides/shape/hyperlinkclick/) của nó. Siêu liên kết thuộc về đối tượng đó chứ không phải một đoạn văn bản bên trong nó.

Cùng cách tiếp cận này áp dụng cho các khung hình ảnh, âm thanh và video: gán siêu liên kết cho khung và đặt [Tooltip](https://reference.aspose.com/slides/vi/net/aspose.slides/ihyperlink/tooltip/) của liên kết nếu cần.

Ví dụ sau làm cho một hình chữ nhật có thể nhấp:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var shape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 600, 50);

shape.HyperlinkClick = new Hyperlink("https://www.aspose.com/");
shape.HyperlinkClick.Tooltip = "Explore Aspose file format APIs";

presentation.Save("presentation-out.pptx", SaveFormat.Pptx);
```

## **Sử Dụng Siêu Liên Kết Để Tạo Mục Lục**

Siêu liên kết nội bộ cho phép người đọc nhảy từ mục lục tới một slide cụ thể. Ví dụ dưới đây sử dụng [SetInternalHyperlinkClick](https://reference.aspose.com/slides/vi/net/aspose.slides/ihyperlinkmanager/setinternalhyperlinkclick/) để liên kết văn bản “Page 2” trên slide đầu tiên tới slide thứ hai.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var firstSlide = presentation.Slides[0];
var secondSlide = presentation.Slides.AddEmptySlide(firstSlide.LayoutSlide);

var tableOfContents = firstSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 40, 40, 300, 100);
tableOfContents.FillFormat.FillType = FillType.NoFill;
tableOfContents.LineFormat.FillFormat.FillType = FillType.NoFill;
tableOfContents.TextFrame.Paragraphs.Clear();

var paragraph = new Paragraph();
paragraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
paragraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
paragraph.Text = "Title of slide 2 .......... ";

var linkPortion = new Portion();
linkPortion.Text = "Page 2";
linkPortion.PortionFormat.HyperlinkManager.SetInternalHyperlinkClick(secondSlide);

paragraph.Portions.Add(linkPortion);
tableOfContents.TextFrame.Paragraphs.Add(paragraph);

presentation.Save("link_to_slide.pptx", SaveFormat.Pptx);
```

## **Định Dạng Siêu Liên Kết**

### **Màu Sắc**

Thuộc tính [ColorSource](https://reference.aspose.com/slides/vi/net/aspose.slides/ihyperlink/colorsource/) của [IHyperlink](https://reference.aspose.com/slides/vi/net/aspose.slides/ihyperlink/) xác định liệu siêu liên kết có sử dụng màu siêu liên kết của bản trình chiếu hay định dạng của đoạn văn bản. Để áp dụng màu văn bản tùy chỉnh, chọn [HyperlinkColorSource.PortionFormat](https://reference.aspose.com/slides/vi/net/aspose.slides/hyperlinkcolorsource/) và đặt màu tô đầy cho đoạn. Tính năng này được giới thiệu trong PowerPoint 2019; các phiên bản cũ hơn không áp dụng thiết lập này.

Ví dụ dưới đây thêm hai siêu liên kết văn bản vào cùng một slide. Siêu liên kết đầu tiên dùng màu đỏ làm nền văn bản, trong khi siêu liên kết thứ hai giữ màu mặc định của siêu liên kết.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var coloredShape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 450, 50, false);
coloredShape.AddTextFrame("This hyperlink uses a custom color.");
var coloredPortionFormat = coloredShape.TextFrame.Paragraphs[0].Portions[0].PortionFormat;
coloredPortionFormat.HyperlinkClick = new Hyperlink("https://www.aspose.com/");
coloredPortionFormat.HyperlinkClick.ColorSource = HyperlinkColorSource.PortionFormat;
coloredPortionFormat.FillFormat.FillType = FillType.Solid;
coloredPortionFormat.FillFormat.SolidFillColor.Color = Color.Red;

var defaultShape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 200, 450, 50, false);
defaultShape.AddTextFrame("This hyperlink uses the default color.");
defaultShape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkClick = new Hyperlink("https://www.aspose.com/");

presentation.Save("presentation-out-hyperlink.pptx", SaveFormat.Pptx);
```
### **Âm Thanh**

Siêu liên kết có thể phát âm thanh khi được kích hoạt hoặc dừng âm thanh đang phát. Sử dụng các thuộc tính sau để cấu hình các hành vi này:

- [IHyperlink.Sound](https://reference.aspose.com/slides/vi/net/aspose.slides/ihyperlink/sound/) chỉ định âm thanh liên quan tới siêu liên kết.  
- [IHyperlink.StopSoundOnClick](https://reference.aspose.com/slides/vi/net/aspose.slides/ihyperlink/stopsoundonclick/) điều khiển việc kích hoạt siêu liên kết có dừng âm thanh trước đó hay không.

#### **Thêm Âm Thanh Siêu Liên Kết**

Ví dụ dưới đây tải `sampleaudio.wav` và liên kết nó với một nút trên slide đầu tiên. Nhấp vào nút sẽ phát âm thanh và chuyển sang slide tiếp theo. Một hình dạng thứ hai trên slide đó sẽ dừng âm thanh trước khi nhấp, mà không thực hiện hành động chuyển hướng.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var audioData = File.ReadAllBytes("sampleaudio.wav");
var hyperlinkSound = presentation.Audios.AddAudio(audioData);

var firstSlide = presentation.Slides[0];

var playButton = firstSlide.Shapes.AddAutoShape(ShapeType.SoundButton, 100, 100, 100, 50);
playButton.HyperlinkClick = Hyperlink.NextSlide;

if (!playButton.HyperlinkClick.StopSoundOnClick && playButton.HyperlinkClick.Sound == null)
{
    playButton.HyperlinkClick.Sound = hyperlinkSound;
}

var secondSlide = presentation.Slides.AddEmptySlide(firstSlide.LayoutSlide);

var stopButton = secondSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 100, 50);
stopButton.HyperlinkClick = Hyperlink.NoAction;

stopButton.HyperlinkClick.StopSoundOnClick = true;

presentation.Save("hyperlink-sound.pptx", SaveFormat.Pptx);
```

#### **Trích Xuất Âm Thanh Siêu Liên Kết**

Ví dụ dưới đây mở bản trình chiếu được tạo ở trên và đọc âm thanh siêu liên kết của hình dạng đầu tiên vào bộ nhớ thông qua [Sound](https://reference.aspose.com/slides/vi/net/aspose.slides/ihyperlink/sound/) và [BinaryData](https://reference.aspose.com/slides/vi/net/aspose.slides/iaudio/binarydata/).

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("hyperlink-sound.pptx");

if (presentation.Slides.Count > 0 && presentation.Slides[0].Shapes.Count > 0)
{
    var hyperlink = presentation.Slides[0].Shapes[0].HyperlinkClick;
    var sound = hyperlink?.Sound;
    if (sound != null)
    {
        var audioData = sound.BinaryData;
        Console.WriteLine($"Extracted {audioData.Length} bytes of hyperlink audio.");
    }
    else
    {
        Console.WriteLine("The first shape has no hyperlink sound.");
    }
}
else
{
    Console.WriteLine("The presentation has no first slide or shape to inspect.");
}
```

### **Cài Đặt Tooltip và Tương Tác**

Bạn có thể cập nhật các thuộc tính [IHyperlink](https://reference.aspose.com/slides/vi/net/aspose.slides/ihyperlink/) sau khi đã gán siêu liên kết cho văn bản hoặc hình dạng:

- [Tooltip](https://reference.aspose.com/slides/vi/net/aspose.slides/ihyperlink/tooltip/) thiết lập văn bản mà người xem có thể hiển thị như gợi ý cho liên kết.  
- [TargetFrame](https://reference.aspose.com/slides/vi/net/aspose.slides/ihyperlink/targetframe/) chỉ định khung mục tiêu trong một khung HTML cha, khi có.  
- [History](https://reference.aspose.com/slides/vi/net/aspose.slides/ihyperlink/history/) điều khiển việc kích hoạt liên kết có thêm điểm đến của nó vào danh sách siêu liên kết đã xem hay không.  
- [HighlightClick](https://reference.aspose.com/slides/vi/net/aspose.slides/ihyperlink/highlightclick/) điều khiển việc siêu liên kết có được làm nổi bật khi nhấp hay không.

## **Xóa Siêu Liên Kết khỏi Bản Trình Chiếu**

Sử dụng [GetAnyHyperlinks](https://reference.aspose.com/slides/vi/net/aspose.slides/ihyperlinkqueries/getanyhyperlinks/) để thu thập các container siêu liên kết, bao gồm các liên kết đoạn văn bản, trước khi thay đổi chúng. Ví dụ dưới đây xóa cả hai loại kích hoạt khỏi slide đầu tiên. Để xóa chỉ một loại, hãy gọi chỉ [RemoveHyperlinkClick](https://reference.aspose.com/slides/vi/net/aspose.slides/ihyperlinkmanager/removehyperlinkclick/) hoặc [RemoveHyperlinkMouseOver](https://reference.aspose.com/slides/vi/net/aspose.slides/ihyperlinkmanager/removehyperlinkmouseover/); việc xóa hành động nhấp không xóa phần tương ứng khi di chuột qua.

```csharp
using System;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("pres.pptx");

if (presentation.Slides.Count > 0)
{
    var containers = presentation.Slides[0].HyperlinkQueries.GetAnyHyperlinks().ToList();
    foreach (var container in containers)
    {
        container.HyperlinkManager.RemoveHyperlinkClick();
        container.HyperlinkManager.RemoveHyperlinkMouseOver();
    }
    presentation.Save("pres-removed-hyperlinks.pptx", SaveFormat.Pptx);
}
else
{
    Console.WriteLine("The presentation has no slides to process.");
}
```

Đối với việc xóa không điều kiện, [RemoveAllHyperlinks](https://reference.aspose.com/slides/vi/net/aspose.slides/ihyperlinkqueries/removeallhyperlinks/) xóa cả hai loại kích hoạt trong phạm vi đã chọn trong một lần gọi. Đối với việc dọn dẹp có chọn lọc và bao phủ các master, layout và notes, xem [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks).

## **Xây Dựng Kiểm Kê Siêu Liên Kết Đầy Đủ**

Trước khi phân phối một bản trình chiếu, hãy kiểm kê các hành động tương tác cũng như các liên kết web của nó. [GetAnyHyperlinks](https://reference.aspose.com/slides/vi/net/aspose.slides/ihyperlinkqueries/getanyhyperlinks/) trả về các đối tượng [IHyperlinkContainer](https://reference.aspose.com/slides/vi/net/aspose.slides/ihyperlinkcontainer/), không phải danh sách phẳng các chuỗi URL. Kiểm tra cả [HyperlinkClick](https://reference.aspose.com/slides/vi/net/aspose.slides/ihyperlinkcontainer/hyperlinkclick/) và [HyperlinkMouseOver](https://reference.aspose.com/slides/vi/net/aspose.slides/ihyperlinkcontainer/hyperlinkmouseover/) trên mỗi container. Chúng độc lập: cùng một container có thể cung cấp cả hai hành động, vì vậy một báo cáo đầy đủ có thể cần tới hai dòng cho mỗi container.

Quét chỉ các siêu liên kết ở mức hình dạng có thể bỏ lỡ các liên kết gắn vào các đoạn văn bản. Thay vào đó, truy vấn phạm vi thích hợp và giữ lại các container trả về để sau này bạn có thể cập nhật hoặc xóa các hành động của chúng.

### **Truy Vấn Các Phạm Vi Bản Trình Chiếu, Slide và Khung Văn Bản**

Giao diện [IHyperlinkQueries](https://reference.aspose.com/slides/vi/net/aspose.slides/ihyperlinkqueries/) có sẵn thông qua [IPresentation.HyperlinkQueries](https://reference.aspose.com/slides/vi/net/aspose.slides/ipresentation/hyperlinkqueries/), [IBaseSlide.HyperlinkQueries](https://reference.aspose.com/slides/vi/net/aspose.slides/ibaseslide/hyperlinkqueries/) và [ITextFrame.HyperlinkQueries](https://reference.aspose.com/slides/vi/net/aspose.slides/itextframe/hyperlinkqueries/). Mỗi phạm vi hỗ trợ các truy vấn giống nhau:

- [GetHyperlinkClicks](https://reference.aspose.com/slides/vi/net/aspose.slides/ihyperlinkqueries/gethyperlinkclicks/) trả về các container có hành động nhấp.  
- [GetHyperlinkMouseOvers](https://reference.aspose.com/slides/vi/net/aspose.slides/ihyperlinkqueries/gethyperlinkmouseovers/) trả về các container có hành động di chuột qua.  
- [GetAnyHyperlinks](https://reference.aspose.com/slides/vi/net/aspose.slides/ihyperlinkqueries/getanyhyperlinks/) trả về các container có một hoặc cả hai hành động.

Ví dụ dưới đây tạo `hyperlink-audit-input.pptx` với một liên kết nhấp bên ngoài, một liên kết di chuột qua tệp, điều hướng slide nội bộ, một liên kết di chuột qua văn bản và một hành động macro. Nó không thực thi bất kỳ hành động nào trong số này. Cùng ba truy vấn hoạt động ở mọi phạm vi; các số đếm mô tả số container, không phải tổng hành động. Phạm vi khung văn bản loại trừ các liên kết của hình dạng bao quanh.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var destination = presentation.Slides.AddEmptySlide(slide.LayoutSlide);
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 60);
shape.TextFrame.Text = "Click the text to go to slide 2";
shape.HyperlinkManager.SetExternalHyperlinkClick("https://example.com/");
shape.HyperlinkClick.Tooltip = "Public website";
shape.HyperlinkManager.SetExternalHyperlinkMouseOver("file:///C:/private/report.xlsx");

var portionFormat = shape.TextFrame.Paragraphs[0].Portions[0].PortionFormat;
portionFormat.HyperlinkManager.SetInternalHyperlinkClick(destination);
portionFormat.HyperlinkManager.SetExternalHyperlinkMouseOver("https://example.com/help");
var macroButton = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 120, 200, 60);
macroButton.HyperlinkManager.SetMacroHyperlinkClick("ReviewPresentation");

PrintCounts("Presentation", presentation.HyperlinkQueries);
PrintCounts("Slide 1", slide.HyperlinkQueries);
PrintCounts("Text frame", shape.TextFrame.HyperlinkQueries);
presentation.Save("hyperlink-audit-input.pptx", SaveFormat.Pptx);

static void PrintCounts(string scope, IHyperlinkQueries queries)
{
    var clickContainers = queries.GetHyperlinkClicks();
    var mouseOverContainers = queries.GetHyperlinkMouseOvers();
    var allContainers = queries.GetAnyHyperlinks();
    Console.WriteLine($"{scope}: click={clickContainers.Count}, mouse-over={mouseOverContainers.Count}, any={allContainers.Count}");
}
```

Đối với ví dụ này, các truy vấn bản trình chiếu và slide mỗi báo cáo ba container nhấp, hai container di chuột qua và ba container có một trong hai hành động. Truy vấn khung văn bản báo cáo một container trong mỗi danh mục.

### **Phân Loại Hành Động và Điểm Đến**

Sử dụng [IHyperlink.ActionType](https://reference.aspose.com/slides/vi/net/aspose.slides/ihyperlink/actiontype/) để giải thích một hành động trước khi giải thích điểm đến của nó. Các giá trị [HyperlinkActionType](https://reference.aspose.com/slides/vi/net/aspose.slides/hyperlinkactiontype/) bao gồm nhiều hơn việc điều hướng web:

| Giá Trị | Ý nghĩa cho việc kiểm toán |
| --- | --- |
| `Hyperlink` | Siêu liên kết bên ngoài; kiểm tra URL và giao thức của nó. |
| `JumpSpecificSlide` | Điều hướng nội bộ tới một slide cụ thể. |
| `JumpFirstSlide`, `JumpPreviousSlide`, `JumpNextSlide`, `JumpLastSlide`, `JumpLastViewedSlide` | Điều hướng trình chiếu tích hợp, được giải quyết trong ngữ cảnh trình chiếu. |
| `JumpEndShow`, `StartCustomSlideShow` | Kết thúc buổi trình chiếu hiện tại hoặc bắt đầu một buổi trình chiếu tùy chỉnh. |
| `StartMacro` | Thực thi macro. |
| `StartProgram` | Khởi chạy một chương trình. |
| `OpenFile`, `OpenPresentation` | Mở một tệp hoặc bản trình chiếu khác; xem xét riêng biệt so với URL web. |
| `StartStopMedia` | Bắt đầu hoặc dừng phát phương tiện. |
| `NoAction`, `Unknown` | Không có hành động điều hướng, hoặc hành động không nhận dạng được cần xem xét. |

Đọc các điểm đến bên ngoài từ [ExternalUrl](https://reference.aspose.com/slides/vi/net/aspose.slides/ihyperlink/externalurl/) và các điểm đến nội bộ cụ thể từ [TargetSlide](https://reference.aspose.com/slides/vi/net/aspose.slides/ihyperlink/targetslide/). Các hành động nội bộ và lệnh tích hợp có thể không có URL bên ngoài; một URL trống không có nghĩa là container không có hành động. Bảo tồn [ExternalUrlOriginal](https://reference.aspose.com/slides/vi/net/aspose.slides/ihyperlink/externalurloriginal/) khi nó khác với URL đã chuẩn hoá, và bao gồm [Tooltip](https://reference.aspose.com/slides/vi/net/aspose.slides/ihyperlink/tooltip/) khi có.

### **Báo Cáo, Làm Sạch và Xác Minh Siêu Liên Kết**

Ví dụ .NET 6+ dưới đây đọc một bản trình chiếu hiện có (sử dụng tệp được tạo ở trên), ghi `hyperlink-audit.json`, áp dụng một chính sách, lưu `hyperlink-sanitized.pptx`, và mở lại để kiểm tra cả hai loại kích hoạt một lần nữa. Nó thu thập các container trước khi thay đổi chúng và sử dụng so sánh tham chiếu để tránh xử lý cùng một container hai lần. Các truy vấn bản trình chiếu bao phủ các slide thông thường; để kiểm kê toàn gói, nó cũng truy vấn rõ ràng các master, layout, notes, và các master notes và handout khi có.

Báo cáo ghi lại chỉ mục slide dựa trên 1 và [SlideId](https://reference.aspose.com/slides/vi/net/aspose.slides/ibaseslide/slideid/) nếu có. [ISlideComponent.Slide](https://reference.aspose.com/slides/vi/net/aspose.slides/islidecomponent/slide/) cung cấp slide sở hữu cho các container được hỗ trợ. Các master, layout và notes không có chỉ mục slide thông thường và được xác định bằng phạm vi của chúng. Các container hình dạng và các container định dạng đoạn văn bản được gắn nhãn riêng; các loại container khác giữ tên kiểu thời gian chạy của chúng. Mỗi container nhận một ID cục bộ trong báo cáo để hai hành động của nó có thể được liên kết.

Chính sách ứng dụng có mục đích hạn chế này chỉ cho phép các URL HTTPS tuyệt đối và các mục tiêu slide nội bộ hợp lệ. Nó loại bỏ macro, chương trình, hành động tệp, các hành động trình chiếu khác, các hành động không xác định và các giao thức URL khác. Những loại bỏ này là quyết định chính sách, không phải một phán quyết an toàn của Aspose.Slides. Chỉ có HTTPS không đủ để tạo niềm tin: hãy thêm danh sách cho phép host và các kiểm tra khác cho ứng dụng của bạn. Cả URL bên ngoài gốc và đã chuẩn hoá đều được kiểm tra. Ví dụ này kiểm toán siêu dữ liệu mà không theo dõi liên kết hay thực thi hành động.

Để khắc phục, [HyperlinkManager](https://reference.aspose.com/slides/vi/net/aspose.slides/ihyperlinkcontainer/hyperlinkmanager/) của container hỗ trợ [SetExternalHyperlinkClick](https://reference.aspose.com/slides/vi/net/aspose.slides/ihyperlinkmanager/setexternalhyperlinkclick/), [RemoveHyperlinkClick](https://reference.aspose.com/slides/vi/net/aspose.slides/ihyperlinkmanager/removehyperlinkclick/), và [RemoveHyperlinkMouseOver](https://reference.aspose.com/slides/vi/net/aspose.slides/ihyperlinkmanager/removehyperlinkmouseover/). Ở đây, các liên kết nhấp bên ngoài bị cấm được thay thế bằng một trang đích HTTPS cố định; các nhấp bị cấm khác và các hành động di chuột qua bị cấm được xóa độc lập. Đặt `replaceExternalClicks` thành `false` để xóa tất cả các vi phạm chính sách. Chọn một trang thay thế thuộc sở hữu ứng dụng trước khi triển khai.

Cờ xuất khẩu của báo cáo sử dụng một chính sách xem xét PDF thận trọng: đánh dấu các hành động di chuột qua và bất kỳ thứ gì khác ngoài liên kết bên ngoài hoặc chuyển đổi slide cụ thể là có thể không được hỗ trợ. Đó là một gợi ý kiểm tra, không phải một bài kiểm tra khả năng hay bảo đảm rằng các liên kết không được đánh dấu sẽ tồn tại sau khi xuất. Các xuất khẩu PDF và HTML được hỗ trợ có thể giữ lại siêu liên kết, tùy thuộc vào hành động, tùy chọn xuất và trình xem. Các [hình ảnh] raster và [video] không thể giữ lại siêu liên kết tương tác; hãy đánh dấu mọi hành động khi kiểm toán cho các đầu ra đó.

```csharp
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using Aspose.Slides;
using Aspose.Slides.Export;

const bool replaceExternalClicks = true;
const string replacementUrl = "https://example.com/blocked-link";
using var presentation = new Presentation("hyperlink-audit-input.pptx");
var containers = CollectContainers(presentation);
var rows = new List<object>();

for (var index = 0; index < containers.Count; index++)
{
    var container = containers[index];
    AddRow(container.HyperlinkClick, "click", container, index + 1);
    AddRow(container.HyperlinkMouseOver, "mouse-over", container, index + 1);
}

var jsonOptions = new JsonSerializerOptions { WriteIndented = true };
var json = JsonSerializer.Serialize(rows, jsonOptions);
File.WriteAllText("hyperlink-audit.json", json);

foreach (var container in containers)
{
    var click = container.HyperlinkClick;
    if (PolicyViolation(click) != null)
    {
        if (replaceExternalClicks && click.ActionType == HyperlinkActionType.Hyperlink)
        {
            container.HyperlinkManager.SetExternalHyperlinkClick(replacementUrl);
        }
        else
        {
            container.HyperlinkManager.RemoveHyperlinkClick();
        }
    }
    if (PolicyViolation(container.HyperlinkMouseOver) != null)
    {
        container.HyperlinkManager.RemoveHyperlinkMouseOver();
    }
}

presentation.Save("hyperlink-sanitized.pptx", SaveFormat.Pptx);
using var reopened = new Presentation("hyperlink-sanitized.pptx");
var remainingContainers = CollectContainers(reopened);
var violations = 0;
foreach (var container in remainingContainers)
{
    if (PolicyViolation(container.HyperlinkClick) != null) violations++;
    if (PolicyViolation(container.HyperlinkMouseOver) != null) violations++;
}
Console.WriteLine($"Audit rows: {rows.Count}; prohibited actions after reopening: {violations}");
if (violations != 0)
{
    Console.WriteLine("Verification failed: do not distribute the saved presentation.");
    Environment.ExitCode = 1;
}

void AddRow(IHyperlink? link, string activation, IHyperlinkContainer container, int containerId)
{
    if (link == null) return;
    var ownerSlide = (container as ISlideComponent)?.Slide;
    var targetSlide = link.TargetSlide;
    var violation = PolicyViolation(link);
    var ownerType = container is IShape ? "Shape" : container is IPortionFormat ? "Text portion" : container.GetType().Name;
    var ordinaryAction = link.ActionType == HyperlinkActionType.Hyperlink || link.ActionType == HyperlinkActionType.JumpSpecificSlide;
    rows.Add(new
    {
        ContainerId = containerId,
        SlideIndex = SlideIndex(presentation, ownerSlide),
        SlideId = ownerSlide?.SlideId,
        Scope = ownerSlide?.GetType().Name,
        OwnerType = ownerType,
        Activation = activation,
        ActionType = link.ActionType.ToString(),
        ExternalUrl = link.ExternalUrl,
        TargetSlideIndex = SlideIndex(presentation, targetSlide),
        TargetSlideId = targetSlide?.SlideId,
        Tooltip = link.Tooltip,
        OriginalExternalUrl = link.ExternalUrlOriginal != link.ExternalUrl ? link.ExternalUrlOriginal : null,
        PotentiallyUnsafe = violation != null,
        PolicyViolation = violation,
        TargetExport = "PDF",
        PotentiallyUnsupportedByExport = activation == "mouse-over" || !ordinaryAction
    });
}

static int? SlideIndex(IPresentation presentation, IBaseSlide? slide)
{
    for (var index = 0; index < presentation.Slides.Count; index++)
    {
        if (ReferenceEquals(presentation.Slides[index], slide)) return index + 1;
    }
    return null;
}

static string? PolicyViolation(IHyperlink? link)
{
    if (link == null) return null;
    if (link.ActionType == HyperlinkActionType.JumpSpecificSlide)
    {
        return link.TargetSlide == null ? "Missing target slide" : null;
    }
    if (link.ActionType != HyperlinkActionType.Hyperlink) return "Action is not allowed";
    if (!IsHttps(link.ExternalUrl)) return "Normalized URL is not absolute HTTPS";
    var original = link.ExternalUrlOriginal;
    if (!string.IsNullOrEmpty(original) && !IsHttps(original)) return "Original URL is not absolute HTTPS";
    return null;
}

static bool IsHttps(string? value)
{
    return Uri.TryCreate(value, UriKind.Absolute, out var uri) && uri.Scheme == Uri.UriSchemeHttps;
}

static List<IHyperlinkContainer> CollectContainers(IPresentation presentation)
{
    var found = new List<IHyperlinkContainer>();
    found.AddRange(presentation.HyperlinkQueries.GetAnyHyperlinks());
    foreach (var master in presentation.Masters) AddScope(master);
    foreach (var layout in presentation.LayoutSlides) AddScope(layout);
    foreach (var slide in presentation.Slides) AddScope(slide.NotesSlideManager.NotesSlide);
    AddScope(presentation.MasterNotesSlideManager.MasterNotesSlide);
    AddScope(presentation.MasterHandoutSlideManager.MasterHandoutSlide);
    return found.Distinct<IHyperlinkContainer>(ReferenceEqualityComparer.Instance).ToList();

    void AddScope(IBaseSlide? slide)
    {
        if (slide != null) found.AddRange(slide.HyperlinkQueries.GetAnyHyperlinks());
    }
}
```

Với đầu vào được tạo ở trên, báo cáo chứa năm hàng hành động. Liên kết di chuột qua tệp và nhấp macro bị xóa, trong khi các liên kết HTTPS và điều hướng slide nội bộ vẫn còn. Kiểm tra in ra không có hành động bị cấm. Một đầu vào chứa URL nhấp bên ngoài bị cấm cũng kích hoạt nhánh thay thế. Một container có nhấp cho phép và di chuột qua bị cấm vẫn giữ hành động nhấp.

Sự dọn dẹp có chọn lọc này khác với [RemoveAllHyperlinks](https://reference.aspose.com/slides/vi/net/aspose.slides/ihyperlinkqueries/removeallhyperlinks/), vốn xóa cả hai loại kích hoạt trong toàn bộ phạm vi đã chọn bất kể chính sách. Kiểm tra ở đây chỉ kiểm tra các hành động siêu liên kết; nó không xóa các dự án VBA nhúng, đối tượng OLE hoặc nội dung hoạt động khác, và không xác thực tệp PDF hoặc HTML đã xuất.

## **Câu Hỏi Thường Gặp**

**Làm thế nào tôi có thể liên kết tới một phần hoặc slide đầu tiên của nó?**

Các phần trong PowerPoint nhóm các slide, nhưng một siêu liên kết nội bộ hướng tới một slide riêng lẻ. Để tạo điều hướng tới một phần, hãy liên kết tới slide đầu tiên trong phần đó.

**Tôi có thể gắn siêu liên kết vào các thành phần slide master để nó hoạt động trên mọi slide không?**

Có. Các thành phần slide master và layout hỗ trợ siêu liên kết. Các liên kết trên những thành phần này sẽ khả dụng trong trình chiếu trên các slide sử dụng master hoặc layout tương ứng.

**Liệu siêu liên kết có được giữ lại khi xuất sang PDF, HTML, hình ảnh hoặc video không?**

Các xuất khẩu PDF và HTML được hỗ trợ có thể giữ lại siêu liên kết; hình ảnh raster và video không thể. Xem các lưu ý xuất khẩu trong [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks).