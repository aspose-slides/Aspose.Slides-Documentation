---
title: Quản lý liên kết siêu văn bản trong bản trình chiếu .NET
linktitle: Quản lý Liên kết
type: docs
weight: 20
url: /vi/net/manage-hyperlinks/
keywords:
- thêm URL
- thêm liên kết siêu văn bản
- tạo liên kết siêu văn bản
- định dạng liên kết siêu văn bản
- xóa liên kết siêu văn bản
- cập nhật liên kết siêu văn bản
- liên kết siêu văn bản văn bản
- liên kết siêu văn bản slide
- liên kết siêu văn bản hình dạng
- liên kết siêu văn bản hình ảnh
- liên kết siêu văn bản video
- liên kết siêu văn bản có thể thay đổi
- PowerPoint
- OpenDocument
- bản trình chiếu
- .NET
- C#
- Aspose.Slides
description: "Quản lý liên kết siêu văn bản trong các bản trình chiếu PowerPoint và OpenDocument một cách dễ dàng với Aspose.Slides cho .NET—tăng cường tính tương tác và quy trình làm việc chỉ trong vài phút."
---
## **Giới thiệu**

Liên kết siêu văn bản là một tham chiếu đến một đối tượng hoặc dữ liệu hoặc một vị trí trong một thứ gì đó. Đây là các liên kết siêu văn bản thường gặp trong các bản trình chiếu PowerPoint:

* Liên kết đến các trang web trong văn bản, hình dạng hoặc phương tiện
* Liên kết đến các slide

Aspose.Slides cho .NET cho phép bạn thực hiện nhiều tác vụ liên quan đến liên kết siêu văn bản trong các bản trình chiếu. 

{{% alert color="info" %}} 

Bạn có thể muốn xem [trình soạn thảo PowerPoint trực tuyến miễn phí của Aspose.](https://products.aspose.app/slides/vi/editor)

{{% /alert %}} 

## **Thêm Liên kết URL**

### **Thêm Liên kết URL vào Văn bản**

Mã C# này cho bạn thấy cách thêm liên kết siêu văn bản tới một trang web vào văn bản:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation())
{
	IAutoShape shape1 = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 600, 50, false);
	shape1.AddTextFrame("Aspose: File Format APIs");
	shape1.TextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkClick = new Hyperlink("https://www.aspose.com/");
	shape1.TextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkClick.Tooltip = "More than 70% Fortune 100 companies trust Aspose APIs";
	shape1.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FontHeight = 32;

	presentation.Save("presentation-out.pptx", SaveFormat.Pptx);
}
```

### **Thêm Liên kết URL vào Hình dạng hoặc Khung**

Mã mẫu này bằng C# cho bạn thấy cách thêm liên kết siêu văn bản tới một trang web vào một hình dạng:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation())
{
    IShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 600, 50);
    
    shape.HyperlinkClick = new Hyperlink("https://www.aspose.com/");
    shape.HyperlinkClick.Tooltip = "More than 70% Fortune 100 companies trust Aspose APIs";

    pres.Save("pres-out.pptx", SaveFormat.Pptx);
}
```

### **Thêm Liên kết URL vào Phương tiện**

Aspose.Slides cho phép bạn thêm liên kết siêu văn bản vào hình ảnh, âm thanh và tệp video. 

Mã mẫu này cho bạn thấy cách thêm một liên kết siêu văn bản vào **hình ảnh**:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation())
{
    // Thêm hình ảnh vào bản trình chiếu
    IPPImage image = pres.Images.AddImage(File.ReadAllBytes("image.png"));
    // Tạo khung ảnh trên slide 1 dựa trên hình ảnh đã thêm trước đó
    IPictureFrame pictureFrame = pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, image);

    pictureFrame.HyperlinkClick = new Hyperlink("https://www.aspose.com/");
    pictureFrame.HyperlinkClick.Tooltip = "More than 70% Fortune 100 companies trust Aspose APIs";

    pres.Save("pres-out.pptx", SaveFormat.Pptx);
}
```
Mã mẫu này cho bạn thấy cách thêm một liên kết siêu văn bản vào **tệp âm thanh**:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation())
{
    IAudio audio = pres.Audios.AddAudio(File.ReadAllBytes("audio.mp3"));
    IAudioFrame audioFrame = pres.Slides[0].Shapes.AddAudioFrameEmbedded(10, 10, 100, 100, audio);

    audioFrame.HyperlinkClick = new Hyperlink("https://www.aspose.com/");
    audioFrame.HyperlinkClick.Tooltip = "More than 70% Fortune 100 companies trust Aspose APIs";

    pres.Save("pres-out.pptx", SaveFormat.Pptx);
}
```
Mã mẫu này cho bạn thấy cách thêm một liên kết siêu văn bản vào **video**:

``` csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation())
{
    IVideo video = pres.Videos.AddVideo(File.ReadAllBytes("video.avi"));
    IVideoFrame videoFrame = pres.Slides[0].Shapes.AddVideoFrame(10, 10, 100, 100, video);

    videoFrame.HyperlinkClick = new Hyperlink("https://www.aspose.com/");
    videoFrame.HyperlinkClick.Tooltip = "More than 70% Fortune 100 companies trust Aspose APIs";

    pres.Save("pres-out.pptx", SaveFormat.Pptx);
}
```

{{%  alert  title="Tip"  color="info"  %}} 

Bạn có thể muốn xem *[Quản lý OLE](https://docs.aspose.com/slides/vi/net/manage-ole/)*.

{{% /alert %}}


## **Sử dụng Liên kết để Tạo Mục Lục**

Vì liên kết siêu văn bản cho phép bạn thêm tham chiếu đến các đối tượng hoặc vị trí, bạn có thể sử dụng chúng để tạo mục lục. 

Mã mẫu này cho bạn thấy cách tạo mục lục với các liên kết siêu văn bản:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using (var presentation = new Presentation())
{
    var firstSlide = presentation.Slides[0];
    var secondSlide = presentation.Slides.AddEmptySlide(firstSlide.LayoutSlide);

    var contentTable = firstSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 40, 40, 300, 100);
    contentTable.FillFormat.FillType = FillType.NoFill;
    contentTable.LineFormat.FillFormat.FillType = FillType.NoFill;
    contentTable.TextFrame.Paragraphs.Clear();

    var paragraph = new Paragraph();
    paragraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    paragraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    paragraph.Text = "Title of slide 2 .......... ";

    var linkPortion = new Portion();
    linkPortion.Text = "Page 2";
    linkPortion.PortionFormat.HyperlinkManager.SetInternalHyperlinkClick(secondSlide);

    paragraph.Portions.Add(linkPortion);
    contentTable.TextFrame.Paragraphs.Add(paragraph);

    presentation.Save("link_to_slide.pptx", SaveFormat.Pptx);
}
```

## **Định dạng Liên kết**

### **Màu sắc**

Với thuộc tính [ColorSource](https://reference.aspose.com/slides/vi/net/aspose.slides/ihyperlink/properties/colorsource) trong giao diện [IHyperlink](https://reference.aspose.com/slides/vi/net/aspose.slides/ihyperlink), bạn có thể đặt màu cho các liên kết siêu văn bản và cũng có thể lấy thông tin màu từ các liên kết. Tính năng này lần đầu được giới thiệu trong PowerPoint 2019, vì vậy các thay đổi liên quan đến thuộc tính này không áp dụng cho các phiên bản PowerPoint cũ hơn.

Mã mẫu này minh họa một thao tác trong đó các liên kết siêu văn bản với màu sắc khác nhau được thêm vào cùng một slide:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation())
{
    IAutoShape shape1 = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 450, 50, false);
    shape1.AddTextFrame("This is a sample of colored hyperlink.");
    shape1.TextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkClick = new Hyperlink("https://www.aspose.com/");
    shape1.TextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkClick.ColorSource = HyperlinkColorSource.PortionFormat;
    shape1.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FillFormat.FillType = FillType.Solid;
    shape1.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FillFormat.SolidFillColor.Color = Color.Red;

    IAutoShape shape2 = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 200, 450, 50, false);
    shape2.AddTextFrame("This is a sample of usual hyperlink.");
    shape2.TextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkClick = new Hyperlink("https://www.aspose.com/");

    presentation.Save("presentation-out-hyperlink.pptx", SaveFormat.Pptx);
}
```
### **Âm thanh**

Aspose.Slides cung cấp các thuộc tính này để cho phép bạn nhấn mạnh một liên kết siêu văn bản bằng âm thanh:
- [IHyperlink.Sound](https://reference.aspose.com/slides/vi/net/aspose.slides/ihyperlink/properties/sound) 
- [IHyperlink.StopSoundOnClick](https://reference.aspose.com/slides/vi/net/aspose.slides/ihyperlink/properties/stopsoundonclick)

#### **Thêm Âm thanh cho Liên kết**

Mã C# này cho bạn thấy cách đặt liên kết siêu văn bản để phát âm thanh và dừng nó bằng một liên kết siêu văn bản khác:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation())
{
	// Thêm âm thanh mới vào bộ sưu tập âm thanh của bản trình chiếu
	IAudio playSound = pres.Audios.AddAudio(File.ReadAllBytes("sampleaudio.wav"));

	ISlide firstSlide = pres.Slides[0];

	// Thêm hình dạng mới với liên kết tới slide tiếp theo
	IShape firstShape = firstSlide.Shapes.AddAutoShape(ShapeType.SoundButton, 100, 100, 100, 50);
	firstShape.HyperlinkClick = Hyperlink.NextSlide;

	// Kiểm tra liên kết cho "No Sound"
	if (!firstShape.HyperlinkClick.StopSoundOnClick && firstShape.HyperlinkClick.Sound == null)
	{
		// Đặt liên kết sẽ phát âm thanh
		firstShape.HyperlinkClick.Sound = playSound;
	}

	// Thêm slide trống 
	ISlide secondSlide = pres.Slides.AddEmptySlide(firstSlide.LayoutSlide);

	// Thêm hình dạng mới với liên kết NoAction
	IShape secondShape = secondSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 100, 50);
	secondShape.HyperlinkClick = Hyperlink.NoAction;

	// Đặt cờ "Stop previous sound" cho liên kết
	secondShape.HyperlinkClick.StopSoundOnClick = true;

	pres.Save("hyperlink-sound.pptx", SaveFormat.Pptx);
}
```

#### **Trích xuất Âm thanh từ Liên kết**

Mã C# này cho bạn thấy cách trích xuất âm thanh được sử dụng trong một liên kết siêu văn bản:

```c#
using Aspose.Slides;

using (Presentation pres = new Presentation("hyperlink-sound.pptx"))
{
	ISlide firstSlide = pres.Slides[0];

	// Lấy liên kết siêu văn bản của hình dạng đầu tiên
	IHyperlink link = firstSlide.Shapes[0].HyperlinkClick;

	if (link.Sound != null)
	{
		// Trích xuất âm thanh của liên kết siêu văn bản thành mảng byte
		byte[] audioData = link.Sound.BinaryData;
	}
}
```

## **Xóa Liên kết khỏi Bản trình chiếu**

### **Xóa Liên kết khỏi Văn bản**

Mã C# này cho bạn thấy cách xóa liên kết siêu văn bản khỏi văn bản trong một slide của bản trình chiếu:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation("pres.pptx"))
{
    ISlide slide = pres.Slides[0];
    foreach (IShape shape in slide.Shapes)
    {
        IAutoShape autoShape = shape as IAutoShape;
        if (autoShape != null)
        {
            foreach (IParagraph paragraph in autoShape.TextFrame.Paragraphs)
            {
                foreach (IPortion portion in paragraph.Portions)
                {
                    portion.PortionFormat.HyperlinkManager.RemoveHyperlinkClick();
                }
            }
        }
    }
    
    pres.Save("pres-removed-hyperlinks.pptx", SaveFormat.Pptx);
}
```

### **Xóa Liên kết khỏi Hình dạng hoặc Khung**

Mã C# này cho bạn thấy cách xóa liên kết siêu văn bản khỏi một hình dạng trong slide của bản trình chiếu: 

``` csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation("demo.pptx")) 
{ 
   ISlide slide = pres.Slides[0]; 
   foreach (IShape shape in slide.Shapes) 
     { 
       shape.HyperlinkManager.RemoveHyperlinkClick(); 
     } 
   pres.Save("pres-removed-hyperlinks.pptx", SaveFormat.Pptx); 
}
```

## **Liên kết có thể thay đổi**

Lớp [Hyperlink](https://reference.aspose.com/slides/vi/net/aspose.slides/hyperlink) có thể thay đổi. Với lớp này, bạn có thể thay đổi giá trị của các thuộc tính sau:

- [IHyperlink.TargetFrame](https://reference.aspose.com/slides/vi/net/aspose.slides/ihyperlink/properties/targetframe)
- [IHyperlink.Tooltip](https://reference.aspose.com/slides/vi/net/aspose.slides/ihyperlink/properties/tooltip)
- [IHyperlink.History](https://reference.aspose.com/slides/vi/net/aspose.slides/ihyperlink/properties/history)
- [IHyperlink.HighlightClick](https://reference.aspose.com/slides/vi/net/aspose.slides/ihyperlink/properties/highlightclick)

Đoạn mã dưới đây cho bạn thấy cách thêm một liên kết siêu văn bản vào slide và chỉnh sửa chú giải công cụ (tooltip) của nó sau này:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation())
{   
   IAutoShape shape1 = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 600, 50, false);    
    
   shape1.AddTextFrame("Aspose: File Format APIs");
    
   shape1.TextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkClick = new Hyperlink("https://www.aspose.com/");
    
    shape1.TextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkClick.Tooltip = "More than 70% Fortune 100 companies trust Aspose APIs";
    
    shape1.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FontHeight = 32;
    
 presentation.Save("presentation-out.pptx", SaveFormat.Pptx);
}
```

## **Các thuộc tính được hỗ trợ trong IHyperlinkQueries**

Bạn có thể truy cập IHyperlinkQueries từ một bản trình chiếu, slide hoặc văn bản mà trong đó liên kết siêu văn bản được định nghĩa. 

- [IPresentation.HyperlinkQueries](https://reference.aspose.com/slides/vi/net/aspose.slides/ipresentation/properties/hyperlinkqueries)
- [IBaseSlide.HyperlinkQueries](https://reference.aspose.com/slides/vi/net/aspose.slides/ibaseslide/properties/hyperlinkqueries)
- [ITextFrame.HyperlinkQueries](https://reference.aspose.com/slides/vi/net/aspose.slides/itextframe/properties/hyperlinkqueries)

Lớp IHyperlinkQueries hỗ trợ các phương thức và thuộc tính sau: 

- [IHyperlinkQueries.GetHyperlinkClicks();](https://reference.aspose.com/slides/vi/net/aspose.slides/ihyperlinkqueries/methods/gethyperlinkclicks)
- [IHyperlinkQueries.GetHyperlinkMouseOvers();](https://reference.aspose.com/slides/vi/net/aspose.slides/ihyperlinkqueries/methods/gethyperlinkmouseovers)
- [IHyperlinkQueries.GetAnyHyperlinks();](https://reference.aspose.com/slides/vi/net/aspose.slides/ihyperlinkqueries/methods/getanyhyperlinks)
- [IHyperlinkQueries.RemoveAllHyperlinks();](https://reference.aspose.com/slides/vi/net/aspose.slides/ihyperlinkqueries/methods/removeallhyperlinks)

## **FAQ**

### Làm sao tôi có thể tạo điều hướng nội bộ không chỉ tới một slide, mà tới một “phần” hoặc slide đầu tiên của một phần?

Các phần trong PowerPoint là nhóm các slide; điều hướng về mặt kỹ thuật hướng tới một slide cụ thể. Để “đi tới một phần”, bạn thường liên kết tới slide đầu tiên của phần đó.

### Tôi có thể gắn liên kết siêu văn bản vào các yếu tố của master slide để chúng hoạt động trên tất cả các slide không?

Có. Các yếu tố của master slide và layout hỗ trợ liên kết siêu văn bản. Những liên kết này sẽ xuất hiện trên các slide con và có thể nhấp được trong quá trình trình chiếu.

### Liên kết siêu văn bản có được giữ lại khi xuất ra PDF, HTML, hình ảnh hoặc video không?

Trong [PDF](/slides/vi/net/convert-powerpoint-to-pdf/) và [HTML](/slides/vi/net/convert-powerpoint-to-html/), có — các liên kết thường được giữ lại. Khi xuất ra [hình ảnh](/slides/vi/net/convert-powerpoint-to-png/) và [video](/slides/vi/net/convert-powerpoint-to-video/), tính năng có thể nhấp sẽ không được chuyển sang do bản chất của các định dạng này (khung raster/video không hỗ trợ liên kết siêu văn bản).