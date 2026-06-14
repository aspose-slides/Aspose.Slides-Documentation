---
title: Quản lý Siêu liên kết trong Bản trình chiếu .NET
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
description: "Dễ dàng quản lý siêu liên kết trong các bản trình chiếu PowerPoint và OpenDocument với Aspose.Slides cho .NET—tăng cường tính tương tác và quy trình làm việc chỉ trong vài phút."
---
## **Giới thiệu**

Siêu liên kết là một tham chiếu đến một đối tượng, dữ liệu hoặc một vị trí nào đó. Đây là các siêu liên kết phổ biến trong Bản trình chiếu PowerPoint:

* Liên kết tới các trang web trong văn bản, hình dạng hoặc phương tiện
* Liên kết tới các slide

Aspose.Slides for .NET cho phép bạn thực hiện nhiều tác vụ liên quan đến siêu liên kết trong bản trình chiếu. 

{{% alert color="primary" %}} 

Bạn có thể muốn khám phá Aspose đơn giản, [trình chỉnh sửa PowerPoint trực tuyến miễn phí.](https://products.aspose.app/slides/vi/editor)

{{% /alert %}} 

## **Thêm Siêu Liên Kết URL**

### **Thêm Siêu Liên Kết URL vào Văn Bản**

Đoạn mã C# này cho bạn thấy cách thêm siêu liên kết trang web vào văn bản:

```c#
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

### **Thêm Siêu Liên Kết URL vào Hình Dạng hoặc Khung**

Đoạn mã mẫu bằng C# này cho bạn thấy cách thêm siêu liên kết trang web vào một hình dạng:

```c#
using (Presentation pres = new Presentation())
{
    IShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 600, 50);
    
    shape.HyperlinkClick = new Hyperlink("https://www.aspose.com/");
    shape.HyperlinkClick.Tooltip = "More than 70% Fortune 100 companies trust Aspose APIs";

    pres.Save("pres-out.pptx", SaveFormat.Pptx);
}
```

### **Thêm Siêu Liên Kết URL vào Phương Tiện**

Aspose.Slides cho phép bạn thêm siêu liên kết vào hình ảnh, tệp âm thanh và video. 

Đoạn mã mẫu này cho bạn thấy cách thêm siêu liên kết vào **hình ảnh**:

```c#
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

 Đoạn mã mẫu này cho bạn thấy cách thêm siêu liên kết vào **tệp âm thanh**:

```c#
using (Presentation pres = new Presentation())
{
    IAudio audio = pres.Audios.AddAudio(File.ReadAllBytes("audio.mp3"));
    IAudioFrame audioFrame = pres.Slides[0].Shapes.AddAudioFrameEmbedded(10, 10, 100, 100, audio);

    audioFrame.HyperlinkClick = new Hyperlink("https://www.aspose.com/");
    audioFrame.HyperlinkClick.Tooltip = "More than 70% Fortune 100 companies trust Aspose APIs";

    pres.Save("pres-out.pptx", SaveFormat.Pptx);
}
```

 Đoạn mã mẫu này cho bạn thấy cách thêm siêu liên kết vào **video**:

``` csharp
using (Presentation pres = new Presentation())
{
    IVideo video = pres.Videos.AddVideo(File.ReadAllBytes("video.avi"));
    IVideoFrame videoFrame = pres.Slides[0].Shapes.AddVideoFrame(10, 10, 100, 100, video);

    videoFrame.HyperlinkClick = new Hyperlink("https://www.aspose.com/");
    videoFrame.HyperlinkClick.Tooltip = "More than 70% Fortune 100 companies trust Aspose APIs";

    pres.Save("pres-out.pptx", SaveFormat.Pptx);
}
```

{{%  alert  title="Mẹo"  color="primary"  %}} 

Bạn có thể muốn xem *[Quản lý OLE](https://docs.aspose.com/slides/vi/net/manage-ole/)*.

{{% /alert %}}


## **Sử Dụng Siêu Liên Kết Để Tạo Mục Lục**

Vì siêu liên kết cho phép bạn thêm tham chiếu tới các đối tượng hoặc vị trí, bạn có thể sử dụng chúng để tạo mục lục. 

Đoạn mã mẫu này cho bạn thấy cách tạo mục lục với siêu liên kết:

```c#
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

## **Định Dạng Siêu Liên Kết**

### **Màu Sắc**

Với thuộc tính [ColorSource](https://reference.aspose.com/slides/vi/net/aspose.slides/ihyperlink/properties/colorsource) trong giao diện [IHyperlink](https://reference.aspose.com/slides/vi/net/aspose.slides/ihyperlink), bạn có thể đặt màu cho siêu liên kết và cũng có thể lấy thông tin màu từ siêu liên kết. Tính năng này lần đầu được giới thiệu trong PowerPoint 2019, vì vậy các thay đổi liên quan đến thuộc tính này không áp dụng cho các phiên bản PowerPoint cũ hơn.

Đoạn mã mẫu này minh họa một thao tác trong đó các siêu liên kết với màu sắc khác nhau được thêm vào cùng một slide:

```c#
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
### **Âm Thanh**

Aspose.Slides cung cấp các thuộc tính sau để cho phép bạn nhấn mạnh một siêu liên kết bằng âm thanh:
- [IHyperlink.Sound](https://reference.aspose.com/slides/vi/net/aspose.slides/ihyperlink/properties/sound) 
- [IHyperlink.StopSoundOnClick](https://reference.aspose.com/slides/vi/net/aspose.slides/ihyperlink/properties/stopsoundonclick)

#### **Thêm Âm Thanh Cho Siêu Liên Kết**

Đoạn mã C# này cho bạn thấy cách thiết lập siêu liên kết phát âm thanh và dừng nó bằng một siêu liên kết khác:

```c#
using (Presentation pres = new Presentation())
{
	// Thêm âm thanh mới vào bộ sưu tập âm thanh của bản trình chiếu
	IAudio playSound = pres.Audios.AddAudio(File.ReadAllBytes("sampleaudio.wav"));

	ISlide firstSlide = pres.Slides[0];

	// Thêm hình dạng mới với siêu liên kết tới slide tiếp theo
	IShape firstShape = firstSlide.Shapes.AddAutoShape(ShapeType.SoundButton, 100, 100, 100, 50);
	firstShape.HyperlinkClick = Hyperlink.NextSlide;

	// Kiểm tra siêu liên kết cho "No Sound"
	if (!firstShape.HyperlinkClick.StopSoundOnClick && firstShape.HyperlinkClick.Sound == null)
	{
		// Đặt siêu liên kết phát âm thanh
		firstShape.HyperlinkClick.Sound = playSound;
	}

	// Thêm slide trống 
	ISlide secondSlide = pres.Slides.AddEmptySlide(firstSlide.LayoutSlide);

	// Thêm hình dạng mới với siêu liên kết NoAction
	IShape secondShape = secondSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 100, 50);
	secondShape.HyperlinkClick = Hyperlink.NoAction;

	// Đặt cờ "Stop previous sound" cho siêu liên kết
	secondShape.HyperlinkClick.StopSoundOnClick = true;

	pres.Save("hyperlink-sound.pptx", SaveFormat.Pptx);
}
```

#### **Trích Xuất Âm Thanh Từ Siêu Liên Kết**

Đoạn mã C# này cho bạn thấy cách trích xuất âm thanh được sử dụng trong một siêu liên kết:

```c#
using (Presentation pres = new Presentation("hyperlink-sound.pptx"))
{
	ISlide firstSlide = pres.Slides[0];

	// Lấy siêu liên kết của hình dạng đầu tiên
	IHyperlink link = firstSlide.Shapes[0].HyperlinkClick;

	if (link.Sound != null)
	{
		// Trích xuất âm thanh siêu liên kết dưới dạng mảng byte
		byte[] audioData = link.Sound.BinaryData;
	}
}
```

## **Xóa Siêu Liên Kết Khỏi Bản Trình Chiếu**

### **Xóa Siêu Liên Kết Khỏi Văn Bản**

Đoạn mã C# này cho bạn thấy cách xóa siêu liên kết khỏi văn bản trong một slide của bản trình chiếu:

```c#
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

### **Xóa Siêu Liên Kết Khỏi Hình Dạng hoặc Khung**

Đoạn mã C# này cho bạn thấy cách xóa siêu liên kết khỏi một hình dạng trong một slide của bản trình chiếu: 

``` csharp
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

## **Siêu Liên Kết Có Thể Thay Đổi**

Lớp [Hyperlink](https://reference.aspose.com/slides/vi/net/aspose.slides/hyperlink) là mutable. Với lớp này, bạn có thể thay đổi giá trị của các thuộc tính sau:

- [IHyperlink.TargetFrame](https://reference.aspose.com/slides/vi/net/aspose.slides/ihyperlink/properties/targetframe)
- [IHyperlink.Tooltip](https://reference.aspose.com/slides/vi/net/aspose.slides/ihyperlink/properties/tooltip)
- [IHyperlink.History](https://reference.aspose.com/slides/vi/net/aspose.slides/ihyperlink/properties/history)
- [IHyperlink.HighlightClick](https://reference.aspose.com/slides/vi/net/aspose.slides/ihyperlink/properties/highlightclick)

Đoạn mã mẫu cho bạn thấy cách thêm một siêu liên kết vào slide và chỉnh sửa tooltip của nó sau đó:

```c#
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

## **Các Thuộc Tính Được Hỗ Trợ Trong IHyperlinkQueries**

Bạn có thể truy cập IHyperlinkQueries từ một bản trình chiếu, slide hoặc văn bản mà siêu liên kết được định nghĩa. 

- [IPresentation.HyperlinkQueries](https://reference.aspose.com/slides/vi/net/aspose.slides/ipresentation/properties/hyperlinkqueries)
- [IBaseSlide.HyperlinkQueries](https://reference.aspose.com/slides/vi/net/aspose.slides/ibaseslide/properties/hyperlinkqueries)
- [ITextFrame.HyperlinkQueries](https://reference.aspose.com/slides/vi/net/aspose.slides/itextframe/properties/hyperlinkqueries)

Lớp IHyperlinkQueries hỗ trợ các phương thức và thuộc tính sau: 

- [IHyperlinkQueries.GetHyperlinkClicks();](https://reference.aspose.com/slides/vi/net/aspose.slides/ihyperlinkqueries/methods/gethyperlinkclicks)
- [IHyperlinkQueries.GetHyperlinkMouseOvers();](https://reference.aspose.com/slides/vi/net/aspose.slides/ihyperlinkqueries/methods/gethyperlinkmouseovers)
- [IHyperlinkQueries.GetAnyHyperlinks();](https://reference.aspose.com/slides/vi/net/aspose.slides/ihyperlinkqueries/methods/getanyhyperlinks)
- [IHyperlinkQueries.RemoveAllHyperlinks();](https://reference.aspose.com/slides/vi/net/aspose.slides/ihyperlinkqueries/methods/removeallhyperlinks)

## **Câu Hỏi Thường Gặp**

**Làm thế nào tôi có thể tạo điều hướng nội bộ không chỉ tới một slide, mà tới “phần” hoặc slide đầu tiên của một phần?**

Các phần trong PowerPoint là các nhóm slide; điều hướng về mặt kỹ thuật vẫn nhắm tới một slide cụ thể. Để “đi tới một phần”, bạn thường liên kết tới slide đầu tiên của phần đó.

**Tôi có thể gắn siêu liên kết vào các thành phần của slide chủ (master) để chúng hoạt động trên tất cả các slide không?**

Có. Các thành phần của slide chủ và bố cục hỗ trợ siêu liên kết. Các liên kết này sẽ xuất hiện trên các slide con và có thể nhấp được trong khi trình chiếu.

**Liệu siêu liên kết có được giữ lại khi xuất ra PDF, HTML, hình ảnh hoặc video không?**

Trong [PDF](/slides/vi/net/convert-powerpoint-to-pdf/) và [HTML](/slides/vi/net/convert-powerpoint-to-html/), có, các liên kết thường được giữ lại. Khi xuất ra [hình ảnh](/slides/vi/net/convert-powerpoint-to-png/) và [video](/slides/vi/net/convert-powerpoint-to-video/), khả năng nhấp sẽ không được chuyển vì các định dạng này (khung raster/video) không hỗ trợ siêu liên kết.