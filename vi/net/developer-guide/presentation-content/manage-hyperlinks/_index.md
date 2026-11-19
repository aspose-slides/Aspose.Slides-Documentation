---
title: Quản lý Siêu liên kết Bản trình chiếu trong .NET
linktitle: Quản lý Siêu liên kết
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
- siêu liên kết có thể thay đổi
- PowerPoint
- OpenDocument
- bản trình chiếu
- .NET
- C#
- Aspose.Slides
description: "Thêm, định dạng, cập nhật và xóa siêu liên kết trong các bản trình chiếu PowerPoint và OpenDocument bằng Aspose.Slides cho .NET, sử dụng các ví dụ C#."
---
## **Giới thiệu**

Một siêu liên kết kết nối nội dung bản trình chiếu với một trang web hoặc một vị trí trong bản trình chiếu. Trong PowerPoint, siêu liên kết thường phục vụ hai mục đích:

* Mở một trang web từ văn bản, hình dạng hoặc khung phương tiện.
* Điều hướng đến một slide khác, ví dụ, từ mục lục.

Aspose.Slides for .NET cho phép bạn thêm các liên kết này, kiểm soát giao diện và âm thanh của chúng, cập nhật thuộc tính và xóa chúng. Các ví dụ dưới đây cho thấy cách làm việc với siêu liên kết trên các phần tử riêng lẻ và cách truy cập siêu liên kết ở mức bản trình chiếu, slide hoặc khung văn bản.

{{% alert color="info" title="Note" %}}
Bạn cũng có thể chỉnh sửa bản trình chiếu bằng [trình chỉnh sửa PowerPoint trực tuyến miễn phí của Aspose](https://products.aspose.app/slides/editor).
{{% /alert %}}

## **Thêm Siêu liên kết URL**

Bạn có thể gán một URL trang web cho văn bản, hình dạng hoặc khung phương tiện. Phần tử mà bạn gán siêu liên kết sẽ quyết định khu vực có thể nhấp: một đoạn văn bản liên kết phần văn bản đã chọn, trong khi một hình dạng hoặc khung liên kết toàn bộ đối tượng slide.

Đối với các bản trình chiếu chứa siêu liên kết tương đối, hãy xem [Quản lý Cơ sở Siêu liên kết](/slides/vi/net/presentation-properties/#manage-the-hyperlink-base) để đọc, thay đổi hoặc xóa cơ sở ở mức tài liệu.

### **Thêm Siêu liên kết URL cho Văn bản**

Để liên kết văn bản với một trang web, gán một [Hyperlink](https://reference.aspose.com/slides/net/aspose.slides/hyperlink/) vào thuộc tính [HyperlinkClick](https://reference.aspose.com/slides/net/aspose.slides/portionformat/hyperlinkclick/) của đoạn văn bản, như minh họa dưới đây. Chỉ phần đoạn văn bản đó sẽ có thể nhấp.

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

### **Thêm Siêu liên kết URL cho Hình dạng và Khung phương tiện**

Gán một URL vào thuộc tính [HyperlinkClick](https://reference.aspose.com/slides/net/aspose.slides/shape/hyperlinkclick/) của hình chữ nhật để toàn bộ khu vực của nó có thể nhấp. Thuộc tính [Tooltip](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/tooltip/) cung cấp cho người đọc một gợi ý về đích khi họ di chuột qua hình chữ nhật. Các thuộc tính tương tự áp dụng cho khung ảnh, âm thanh và video.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var shape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 600, 50);

shape.HyperlinkClick = new Hyperlink("https://www.aspose.com/");
shape.HyperlinkClick.Tooltip = "Explore Aspose file format APIs";

presentation.Save("presentation-out.pptx", SaveFormat.Pptx);
```

## **Sử dụng Siêu liên kết để Tạo Mục lục**

Siêu liên kết nội bộ cho phép người đọc chuyển từ mục lục tới một slide cụ thể. Ví dụ sau sử dụng [SetInternalHyperlinkClick](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkmanager/setinternalhyperlinkclick/) để liên kết văn bản “Page 2” trên slide đầu tiên tới slide thứ hai.

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

## **Định dạng Siêu liên kết**

Bạn có thể thay đổi màu của văn bản có liên kết, phát hoặc dừng âm thanh khi người đọc kích hoạt một liên kết, và đặt tooltip hiển thị khi di chuột.

### **Màu sắc**

Thuộc tính [ColorSource](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/colorsource/) của [IHyperlink](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/) quyết định siêu liên kết sẽ sử dụng màu siêu liên kết của bản trình chiếu hay định dạng của đoạn văn bản. Để áp dụng màu văn bản tùy chỉnh, chọn [HyperlinkColorSource.PortionFormat](https://reference.aspose.com/slides/net/aspose.slides/hyperlinkcolorsource/) và đặt màu tô đầy cho đoạn. Tính năng này được giới thiệu trong PowerPoint 2019; các phiên bản cũ hơn không áp dụng cài đặt này.

Trong ví dụ này, việc đặt [ColorSource](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/colorsource/) cho liên kết đầu tiên làm cho văn bản của nó hiển thị màu đỏ. Liên kết thứ hai giữ màu siêu liên kết của bản trình chiếu.

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

### **Âm thanh**

Một siêu liên kết có thể phát âm thanh khi được kích hoạt hoặc dừng âm thanh đang phát. Sử dụng các thuộc tính sau để cấu hình các hành vi này:

- [IHyperlink.Sound](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/sound/) chỉ định âm thanh liên quan đến siêu liên kết.
- [IHyperlink.StopSoundOnClick](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/stopsoundonclick/) kiểm soát việc kích hoạt siêu liên kết có dừng âm thanh trước đó hay không.

#### **Thêm Âm thanh cho Siêu liên kết**

Nút trên slide đầu tiên sử dụng [Sound](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/sound/) để phát âm thanh từ tệp WAV khi người đọc nhấp để chuyển tiếp. Trên slide thứ hai, một nút riêng biệt sử dụng [StopSoundOnClick](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/stopsoundonclick/) để dừng phát và giữ người đọc ở slide đó.

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

#### **Trích xuất Âm thanh Siêu liên kết**

Ví dụ sau mở bản trình chiếu được tạo ở trên và đọc âm thanh siêu liên kết của hình dạng đầu tiên vào bộ nhớ thông qua [Sound](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/sound/) và [BinaryData](https://reference.aspose.com/slides/net/aspose.slides/iaudio/binarydata/).

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

### **Tooltip và Cài đặt Tương tác**

Bạn có thể cập nhật các thuộc tính [IHyperlink](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/) sau khi gán siêu liên kết cho văn bản hoặc hình dạng:

- [Tooltip](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/tooltip/) đặt văn bản mà người xem có thể hiển thị như một gợi ý cho liên kết.
- [TargetFrame](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/targetframe/) chỉ định khung đích trong một khung cha HTML, nếu áp dụng.
- [History](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/history/) kiểm soát việc kích hoạt liên kết có đưa đích của nó vào danh sách các siêu liên kết đã xem hay không.
- [HighlightClick](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/highlightclick/) kiểm soát việc siêu liên kết được làm nổi bật khi được nhấp.

## **Xóa Siêu liên kết khỏi Bản trình chiếu**

Sử dụng [GetAnyHyperlinks](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/getanyhyperlinks/) để thu thập các container siêu liên kết, bao gồm các liên kết đoạn văn bản, trước khi thay đổi chúng. Ví dụ sau xóa cả hai loại kích hoạt khỏi slide đầu tiên. Để xóa chỉ một loại, gọi chỉ [RemoveHyperlinkClick](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkmanager/removehyperlinkclick/) hoặc [RemoveHyperlinkMouseOver](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkmanager/removehyperlinkmouseover/); việc xóa hành động nhấp không xóa hành động di chuột.

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

Đối với việc xóa vô điều kiện, [RemoveAllHyperlinks](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/removeallhyperlinks/) xóa cả hai loại kích hoạt trong phạm vi đã chọn trong một lần gọi. Đối với việc dọn dẹp có chọn lọc và bao phủ các master, layout và notes, xem [Báo cáo, Làm sạch và Xác minh Siêu liên kết](#report-sanitize-and-verify-hyperlinks).

### **Xóa Siêu liên kết Trước khi Thay thế Văn bản SmartArt**

Khi bạn thay thế một đoạn văn trong một nút SmartArt hiện có, việc xóa các phần văn bản của nó có thể để lại một siêu liên kết cũ còn hiệu lực. Lấy đoạn văn thông qua [ISmartArtNode.TextFrame](https://reference.aspose.com/slides/net/aspose.slides.smartart/ismartartnode/textframe/). Trước khi xóa các phần, gọi [RemoveAllHyperlinks](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/removeallhyperlinks/) thông qua [HyperlinkQueries](https://reference.aspose.com/slides/net/aspose.slides/itextframe/hyperlinkqueries/) trên khung văn bản của hình dạng nút hiển thị đoạn văn. Điều này xóa mọi siêu liên kết trong khung đó, bao gồm các liên kết trong các đoạn văn khác.

Ví dụ giả định rằng hình dạng thứ ba trên slide đầu tiên là một đồ họa SmartArt. Nó thay thế đoạn văn đầu tiên của nút thứ tư. Trong bản trình chiếu này, hình dạng đầu tiên của nút hiển thị đoạn văn đó.

Sau khi thêm cả hai phần, ví dụ đọc định dạng hiệu lực của chúng bằng [GetEffective](https://reference.aspose.com/slides/net/aspose.slides/iportionformat/geteffective/). Thuộc tính hiệu lực [HyperlinkClick](https://reference.aspose.com/slides/net/aspose.slides/iportionformateffectivedata/hyperlinkclick/) trả về siêu liên kết mới cho phần đầu và `null` cho phần thứ hai.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.SmartArt;

using var presentation = new Presentation("SmartArtHyperlink.pptx");
var slide = presentation.Slides[0];

var smartArt = (ISmartArt)slide.Shapes[2];
var node = smartArt.AllNodes[3];
var paragraph = node.TextFrame.Paragraphs[0];

node.Shapes[0].TextFrame.HyperlinkQueries.RemoveAllHyperlinks();
paragraph.Portions.Clear();

var link = new Portion("New reference");
link.PortionFormat.HyperlinkClick = new Hyperlink("https://example.com/new");
paragraph.Portions.Add(link);
var text = new Portion(" (updated)");
paragraph.Portions.Add(text);

Console.WriteLine(link.PortionFormat.GetEffective().HyperlinkClick.ExternalUrl); // https://example.com/new
Console.WriteLine(text.PortionFormat.GetEffective().HyperlinkClick?.ToString() ?? "null"); // null
```

## **Xây dựng Danh mục Siêu liên kết Đầy đủ**

Trước khi phân phối một bản trình chiếu, kiểm kê các hành động tương tác cũng như các liên kết web của nó. [GetAnyHyperlinks](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/getanyhyperlinks/) trả về các đối tượng [IHyperlinkContainer](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkcontainer/), không phải danh sách phẳng các chuỗi URL. Kiểm tra cả [HyperlinkClick](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkcontainer/hyperlinkclick/) và [HyperlinkMouseOver](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkcontainer/hyperlinkmouseover/) trên mỗi container. Chúng là độc lập: cùng một container có thể hiển thị cả hai hành động, vì vậy một báo cáo đầy đủ có thể cần tới hai hàng cho mỗi container.

Quét chỉ các siêu liên kết ở mức hình dạng có thể bỏ qua các liên kết gắn vào các phần văn bản. Thay vào đó, truy vấn phạm vi thích hợp và giữ lại các container đã trả về để bạn có thể cập nhật hoặc xóa chúng sau này.

### **Truy vấn Phạm vi Bản trình chiếu, Slide và Khung Văn bản**

Giao diện [IHyperlinkQueries](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/) khả dụng qua [IPresentation.HyperlinkQueries](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/hyperlinkqueries/), [IBaseSlide.HyperlinkQueries](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide/hyperlinkqueries/) và [ITextFrame.HyperlinkQueries](https://reference.aspose.com/slides/net/aspose.slides/itextframe/hyperlinkqueries/). Mỗi phạm vi hỗ trợ cùng các truy vấn:

- [GetHyperlinkClicks](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/gethyperlinkclicks/) trả về các container có hành động nhấp.
- [GetHyperlinkMouseOvers](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/gethyperlinkmouseovers/) trả về các container có hành động di chuột.
- [GetAnyHyperlinks](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/getanyhyperlinks/) trả về các container có một hoặc cả hai hành động.

Ví dụ này gán hành động nhấp và di chuột cho một hình dạng và văn bản của nó, và một hành động macro cho một nút riêng. Nó so sánh các container trả về bởi [GetAnyHyperlinks](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/getanyhyperlinks/) với số lượng cho mỗi loại kích hoạt. Một truy vấn khung văn bản chỉ đếm các liên kết trong văn bản. Các hành động của hình dạng bao trùm xuất hiện trong các truy vấn slide và bản trình chiếu.

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

Đối với ví dụ này, các truy vấn bản trình chiếu và slide mỗi đều báo cáo ba container nhấp, hai container di chuột và ba container có một trong hai hành động. Truy vấn khung văn bản báo cáo một container trong mỗi danh mục.

### **Phân loại Hành động và Đích**

Sử dụng [IHyperlink.ActionType](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/actiontype/) để diễn giải một hành động trước khi diễn giải đích của nó. Các giá trị [HyperlinkActionType](https://reference.aspose.com/slides/net/aspose.slides/hyperlinkactiontype/) bao gồm nhiều hơn chỉ điều hướng web:

| Values | Meaning for an audit |
| --- | --- |
| `Hyperlink` | Siêu liên kết bên ngoài; kiểm tra URL và scheme của nó. |
| `JumpSpecificSlide` | Điều hướng nội bộ tới một slide cụ thể. |
| `JumpFirstSlide`, `JumpPreviousSlide`, `JumpNextSlide`, `JumpLastSlide`, `JumpLastViewedSlide` | Điều hướng trình chiếu tích hợp, được giải quyết trong ngữ cảnh trình chiếu. |
| `JumpEndShow`, `StartCustomSlideShow` | Kết thúc trình chiếu hiện tại hoặc bắt đầu trình chiếu tùy chỉnh. |
| `StartMacro` | Thực thi macro. |
| `StartProgram` | Khởi chạy chương trình. |
| `OpenFile`, `OpenPresentation` | Mở tệp hoặc bản trình chiếu khác; xem xét riêng biệt so với URL web. |
| `StartStopMedia` | Bắt đầu hoặc dừng phát phương tiện. |
| `NoAction`, `Unknown` | Không có hành động điều hướng, hoặc hành động không nhận dạng được cần xem xét. |

Đọc đích ngoài từ [ExternalUrl](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/externalurl/) và các đích nội bộ cụ thể từ [TargetSlide](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/targetslide/). Các hành động nội bộ và lệnh tích hợp có thể không có URL bên ngoài; một URL rỗng không có nghĩa là container không có hành động. Bảo tồn [ExternalUrlOriginal](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/externalurloriginal/) khi nó khác với URL đã chuẩn hoá, và bao gồm [Tooltip](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/tooltip/) khi có.

### **Báo cáo, Làm sạch và Xác minh Siêu liên kết**

Ví dụ .NET 6+ này mở bản trình chiếu từ ví dụ trước và ghi một bản ghi JSON cho mỗi hành động. Nó sử dụng [GetAnyHyperlinks](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/getanyhyperlinks/) để thu thập các container trên các slide thường, master, layout và notes, bao gồm master notes và handout khi có. Nó dùng so sánh tham chiếu để đếm mỗi container một lần, áp dụng chính sách mô tả bên dưới, và mở lại bản trình chiếu đã lưu để kiểm tra cả hành động nhấp và di chuột.

Báo cáo ghi chỉ mục slide bắt đầu từ 1 và [SlideId](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide/slideid/) khi có. [ISlideComponent.Slide](https://reference.aspose.com/slides/net/aspose.slides/islidecomponent/slide/) cung cấp slide sở hữu cho các container được hỗ trợ. Master, layout và notes không có chỉ mục slide thường và được xác định bằng phạm vi của chúng. Các container hình dạng và container định dạng đoạn văn được gắn nhãn riêng; các loại container khác giữ tên kiểu thời gian chạy. Mỗi container nhận một ID cục bộ trong báo cáo để hai hành động của nó có thể được liên kết.

Chính sách ứng dụng có tính hạn chế này chỉ cho phép URL HTTPS tuyệt đối và các đích slide nội bộ hợp lệ. Nó loại bỏ macro, chương trình, hành động tệp, các hành động trình chiếu khác, hành động không xác định và các scheme URL khác. Những loại loại bỏ này là quyết định chính sách, không phải phán đoán an toàn của Aspose.Slides. HTTPS một mình không tạo nên độ tin cậy: hãy thêm danh sách cho phép host và các kiểm tra khác cho ứng dụng của bạn. Cả URL ngoài gốc và đã chuẩn hoá đều được kiểm tra. Ví dụ kiểm tra siêu dữ liệu mà không theo dõi liên kết hay thực thi hành động.

Để khắc phục, [HyperlinkManager](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkcontainer/hyperlinkmanager/) của container hỗ trợ [SetExternalHyperlinkClick](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkmanager/setexternalhyperlinkclick/), [RemoveHyperlinkClick](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkmanager/removehyperlinkclick/) và [RemoveHyperlinkMouseOver](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkmanager/removehyperlinkmouseover/). Ở đây, các liên kết nhấp ngoài bị cấm được thay thế bằng một trang đích HTTPS cố định; các nhấp ngoài bị cấm khác và các hành động di chuột bị cấm được xóa độc lập. Đặt `replaceExternalClicks` thành `false` để xóa tất cả vi phạm chính sách thay vì thay thế. Chọn một trang thay thế do ứng dụng sở hữu trước khi triển khai.

Cờ xuất báo cáo sử dụng chính sách xem xét PDF thận trọng: đánh dấu các hành động di chuột và bất kỳ thứ gì khác ngoài liên kết ngoài hoặc chuyển slide cụ thể là có thể không được hỗ trợ. Đây là gợi ý xem xét, không phải kiểm tra khả năng hay bảo đảm các liên kết không được đánh dấu sẽ tồn tại khi xuất. Các xuất PDF và HTML được hỗ trợ ([PDF](/slides/vi/net/convert-powerpoint-to-pdf/) và [HTML](/slides/vi/net/convert-powerpoint-to-html/)) có thể giữ lại siêu liên kết, tùy thuộc vào hành động, tùy chọn xuất và trình xem. Các ảnh raster ([images](/slides/vi/net/convert-powerpoint-to-png/)) và video ([video](/slides/vi/net/convert-powerpoint-to-video/)) không thể giữ siêu liên kết tương tác; hãy đánh dấu mọi hành động khi kiểm tra các đầu ra này.

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

Với đầu vào được tạo ở trên, báo cáo chứa năm hàng hành động. Liên kết di chuột tệp và macro nhấp được xóa, trong khi các liên kết HTTPS và điều hướng slide nội bộ vẫn còn. Việc xác minh in ra không có hành động bị cấm. Một đầu vào chứa URL nhấp ngoài bị cấm cũng sẽ thực hiện nhánh thay thế. Một container có nhấp cho phép và di chuột bị cấm sẽ giữ hành động nhấp của nó.

Việc dọn dẹp có chọn lọc này khác với [RemoveAllHyperlinks](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/removeallhyperlinks/), lệnh này xóa cả hai loại kích hoạt trong toàn bộ phạm vi đã chọn bất kể chính sách. Xác minh ở đây chỉ kiểm tra các hành động siêu liên kết; nó không xóa các dự án VBA nhúng, đối tượng OLE hoặc nội dung hoạt động khác, và không xác thực tệp PDF hoặc HTML đã xuất.

## **Câu hỏi thường gặp**

**Làm thế nào để liên kết tới một phần hoặc slide đầu tiên của phần đó?**

Các phần trong PowerPoint nhóm các slide, nhưng một siêu liên kết nội bộ nhắm tới một slide riêng lẻ. Để tạo điều hướng tới một phần, hãy liên kết tới slide đầu tiên trong phần đó.

**Có thể gắn siêu liên kết vào các yếu tố slide master để chúng hoạt động trên tất cả các slide không?**

Có. Các yếu tố slide master và layout hỗ trợ siêu liên kết. Các liên kết trên các yếu tố này sẽ khả dụng trong chế độ trình chiếu trên các slide sử dụng master hoặc layout tương ứng.

**Siêu liên kết có được giữ lại khi xuất sang PDF, HTML, hình ảnh hoặc video không?**

Các xuất PDF và HTML được hỗ trợ có thể giữ lại siêu liên kết; hình ảnh raster và video không thể. Xem các lưu ý xuất trong [Báo cáo, Làm sạch và Xác minh Siêu liên kết](#report-sanitize-and-verify-hyperlinks).