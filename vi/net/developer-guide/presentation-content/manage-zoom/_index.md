---
title: Quản lý Zoom trong bản trình bày .NET
linktitle: Quản lý Zoom
type: docs
weight: 60
url: /vi/net/manage-zoom/
keywords:
- zoom
- khung zoom
- zoom slide
- zoom phần
- zoom tổng hợp
- thêm zoom
- PowerPoint
- bản trình bày
- .NET
- C#
- Aspose.Slides
description: "Tạo và tùy chỉnh Zoom với Aspose.Slides cho .NET — chuyển đổi giữa các phần, thêm hình thu nhỏ và chuyển tiếp trong các bản trình bày PPT, PPTX và ODP."
---
## **Giới thiệu**

Zoom trong PowerPoint cho phép bạn nhảy tới và từ các slide, phần và đoạn cụ thể của bản trình bày. Khi bạn đang thuyết trình, khả năng điều hướng nhanh chóng qua nội dung này có thể rất hữu ích. 

![overview_image](overview.png)

* Để tóm tắt toàn bộ bản trình bày trên một slide duy nhất, sử dụng [Summary Zoom](#Summary-Zoom).
* Để hiển thị chỉ các slide đã chọn, sử dụng [Slide Zoom](#Slide-Zoom).
* Để hiển thị chỉ một phần, sử dụng [Section Zoom](#Section-Zoom).

## **Slide Zoom**
Zoom slide có thể làm cho bản trình bày của bạn năng động hơn, cho phép bạn điều hướng tự do giữa các slide theo bất kỳ thứ tự nào mà không làm gián đoạn luồng trình bày. Zoom slide rất phù hợp cho các bài thuyết trình ngắn không có nhiều phần, nhưng bạn vẫn có thể sử dụng chúng trong các kịch bản trình bày khác nhau.

Zoom slide giúp bạn đi sâu vào nhiều thông tin khác nhau trong khi vẫn cảm giác như đang ở trên một bảng vẽ duy nhất. 

![overview_image](slidezoomsel.png)

Đối với các đối tượng Zoom slide, Aspose.Slides cung cấp enum [ZoomImageType](https://reference.aspose.com/slides/vi/net/aspose.slides/zoomimagetype), interface [IZoomFrame](https://reference.aspose.com/slides/vi/net/aspose.slides/izoomframe) và một số phương thức dưới interface [IShapeCollection](https://reference.aspose.com/slides/vi/net/aspose.slides/ishapecollection).

### **Create Zoom Frames**

Bạn có thể thêm một khung zoom vào slide theo cách sau:

1.	Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation).
2.	Tạo các slide mới mà bạn dự định liên kết với các khung zoom. 
3.	Thêm văn bản nhận dạng và nền cho các slide đã tạo.
4.	Thêm các khung zoom (chứa tham chiếu tới các slide đã tạo) vào slide đầu tiên.
5.	Ghi bản trình bày đã sửa đổi dưới dạng tệp PPTX.

Mã C# này cho bạn thấy cách tạo một khung zoom trên slide:

``` csharp 
using (Presentation pres = new Presentation())
{
    //Thêm các slide mới vào bản trình bày
    ISlide slide2 = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    ISlide slide3 = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);

    // Tạo nền cho slide thứ hai
    slide2.Background.Type = BackgroundType.OwnBackground;
    slide2.Background.FillFormat.FillType = FillType.Solid;
    slide2.Background.FillFormat.SolidFillColor.Color = Color.Cyan;

    // Tạo hộp văn bản cho slide thứ hai
    IAutoShape autoshape = slide2.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.TextFrame.Text = "Second Slide";

    // Tạo nền cho slide thứ ba
    slide3.Background.Type = BackgroundType.OwnBackground;
    slide3.Background.FillFormat.FillType = FillType.Solid;
    slide3.Background.FillFormat.SolidFillColor.Color = Color.DarkKhaki;

    // Tạo hộp văn bản cho slide thứ ba
    autoshape = slide3.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.TextFrame.Text = "Trird Slide";

    //Thêm các đối tượng ZoomFrame
    pres.Slides[0].Shapes.AddZoomFrame(20, 20, 250, 200, slide2);
    pres.Slides[0].Shapes.AddZoomFrame(200, 250, 250, 200, slide3);

    // Lưu bản trình bày
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```
### **Create Zoom Frames with Custom Images**
Với Aspose.Slides for .NET, bạn có thể tạo một khung zoom với ảnh preview slide khác nhau theo cách sau: 
1.	Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation).
2.	Tạo một slide mới mà bạn dự định liên kết với khung zoom. 
3.	Thêm văn bản nhận dạng và nền cho slide.
4.	Tạo một đối tượng [IPPImage](https://reference.aspose.com/slides/vi/net/aspose.slides/ippimage) bằng cách thêm ảnh vào bộ sưu tập Images của đối tượng [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation) sẽ được dùng để điền vào khung.
5.	Thêm các khung zoom (chứa tham chiếu tới slide đã tạo) vào slide đầu tiên.
6.	Ghi bản trình bày đã sửa đổi dưới dạng tệp PPTX.

Mã C# này cho bạn thấy cách tạo một khung zoom với ảnh khác:

``` csharp 
using (Presentation pres = new Presentation())
{
    //Thêm một slide mới vào bản trình bày
    ISlide slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);

    // Tạo nền cho slide thứ hai
    slide.Background.Type = BackgroundType.OwnBackground;
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Cyan;

    // Tạo hộp văn bản cho slide thứ ba
    IAutoShape autoshape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.TextFrame.Text = "Second Slide";

    // Tạo hình ảnh mới cho đối tượng zoom
    IImage image = Images.FromFile("image.png");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    //Thêm đối tượng ZoomFrame
    pres.Slides[0].Shapes.AddZoomFrame(20, 20, 300, 200, slide, ppImage);

    // Lưu bản trình bày
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```
### **Format Zoom Frames**
Trong các phần trước, chúng tôi đã cho bạn thấy cách tạo các khung zoom đơn giản. Để tạo các khung zoom phức tạp hơn, bạn phải thay đổi định dạng của một khung đơn giản. Có một số tùy chọn định dạng bạn có thể áp dụng cho khung zoom. 

Bạn có thể kiểm soát định dạng của khung zoom trên slide theo cách sau:

1.	Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation).
2.	Tạo các slide mới để liên kết tới chúng bạn dự định liên kết khung zoom. 
3.	Thêm một số văn bản nhận dạng và nền cho các slide đã tạo.
4.	Thêm các khung zoom (chứa tham chiếu tới các slide đã tạo) vào slide đầu tiên.
5.	Tạo một đối tượng [IPPImage](https://reference.aspose.com/slides/vi/net/aspose.slides/ippimage) bằng cách thêm ảnh vào bộ sưu tập Images của đối tượng [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation) sẽ được dùng để điền vào khung.
6.	Đặt ảnh tùy chỉnh cho đối tượng khung zoom đầu tiên.
7.	Thay đổi định dạng đường viền cho đối tượng khung zoom thứ hai.
8.	Gỡ bỏ nền khỏi ảnh của đối tượng khung zoom thứ hai.
5.	Ghi bản trình bày đã sửa đổi dưới dạng tệp PPTX.

Mã C# này cho bạn thấy cách thay đổi định dạng của khung zoom trên slide: 

``` csharp 
using (Presentation pres = new Presentation())
{
    //Thêm các slide mới vào bản trình bày
    ISlide slide2 = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    ISlide slide3 = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);

    // Tạo nền cho slide thứ hai
    slide2.Background.Type = BackgroundType.OwnBackground;
    slide2.Background.FillFormat.FillType = FillType.Solid;
    slide2.Background.FillFormat.SolidFillColor.Color = Color.Cyan;

    // Tạo hộp văn bản cho slide thứ hai
    IAutoShape autoshape = slide2.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.TextFrame.Text = "Second Slide";

    // Tạo nền cho slide thứ ba
    slide3.Background.Type = BackgroundType.OwnBackground;
    slide3.Background.FillFormat.FillType = FillType.Solid;
    slide3.Background.FillFormat.SolidFillColor.Color = Color.DarkKhaki;

    // Tạo hộp văn bản cho slide thứ ba
    autoshape = slide3.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.TextFrame.Text = "Trird Slide";

    //Thêm các đối tượng ZoomFrame
    IZoomFrame zoomFrame1 = pres.Slides[0].Shapes.AddZoomFrame(20, 20, 250, 200, slide2);
    IZoomFrame zoomFrame2 = pres.Slides[0].Shapes.AddZoomFrame(200, 250, 250, 200, slide3);

    // Tạo hình ảnh mới cho đối tượng zoom
    IImage image = Images.FromFile("image.png");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    // Đặt ảnh tùy chỉnh cho đối tượng zoomFrame1
    zoomFrame1.ZoomImage = ppImage;

    // Đặt định dạng khung zoom cho đối tượng zoomFrame2
    zoomFrame2.LineFormat.Width = 5;
    zoomFrame2.LineFormat.FillFormat.FillType = FillType.Solid;
    zoomFrame2.LineFormat.FillFormat.SolidFillColor.Color = Color.HotPink;
    zoomFrame2.LineFormat.DashStyle = LineDashStyle.DashDot;

    // Cài đặt không hiển thị nền cho đối tượng zoomFrame2
    zoomFrame2.ShowBackground = false;

    // Lưu bản trình bày
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```

## **Section Zoom**

Zoom phần là một liên kết tới một phần trong bản trình bày của bạn. Bạn có thể sử dụng zoom phần để quay lại các phần mà bạn muốn nhấn mạnh. Hoặc bạn có thể dùng chúng để làm nổi bật cách các phần của bản trình bày kết nối với nhau. 

![overview_image](seczoomsel.png)

Đối với các đối tượng Zoom phần, Aspose.Slides cung cấp interface [ISectionZoomFrame](https://reference.aspose.com/slides/vi/net/aspose.slides/isectionzoomframe) và một số phương thức dưới interface [IShapeCollection](https://reference.aspose.com/slides/vi/net/aspose.slides/ishapecollection).

### **Create Section Zoom Frames**

Bạn có thể thêm một khung zoom phần vào slide theo cách sau:

1.	Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation).
2.	Tạo một slide mới. 
3.	Thêm nền nhận dạng vào slide đã tạo.
4.	Tạo một phần mới mà bạn dự định liên kết với khung zoom. 
5.	Thêm một khung zoom phần (chứa tham chiếu tới phần đã tạo) vào slide đầu tiên.
6.	Ghi bản trình bày đã sửa đổi dưới dạng tệp PPTX.

Mã C# này cho bạn thấy cách tạo một khung zoom trên slide:

``` csharp 
using (Presentation pres = new Presentation())
{
    //Thêm một slide mới vào bản trình bày
    ISlide slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.YellowGreen;
    slide.Background.Type = BackgroundType.OwnBackground;

    // Thêm một Section mới vào bản trình bày
    pres.Sections.AddSection("Section 1", slide);

    // Thêm một đối tượng SectionZoomFrame
    ISectionZoomFrame sectionZoomFrame = pres.Slides[0].Shapes.AddSectionZoomFrame(20, 20, 300, 200, pres.Sections[1]);

    // Lưu bản trình bày
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```
### **Create Section Zoom Frames with Custom Images**

Sử dụng Aspose.Slides for .NET, bạn có thể tạo một khung zoom phần với ảnh preview slide khác nhau theo cách sau: 

1.	Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation).
2.	Tạo một slide mới.
3.	Thêm nền nhận dạng vào slide đã tạo.
4.	Tạo một phần mới mà bạn dự định liên kết với khung zoom. 
5.	Tạo một đối tượng [IPPImage](https://reference.aspose.com/slides/vi/net/aspose.slides/ippimage) bằng cách thêm ảnh vào bộ sưu tập Images của đối tượng [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation) sẽ được dùng để điền vào khung.
5.	Thêm một khung zoom phần (chứa tham chiếu tới phần đã tạo) vào slide đầu tiên.
6.	Ghi bản trình bày đã sửa đổi dưới dạng tệp PPTX.

Mã C# này cho bạn thấy cách tạo một khung zoom với ảnh khác:

``` csharp 
using (Presentation pres = new Presentation())
{
    //Thêm slide mới vào bản trình bày
    ISlide slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.YellowGreen;
    slide.Background.Type = BackgroundType.OwnBackground;

    // Thêm một Section mới vào bản trình bày
    pres.Sections.AddSection("Section 1", slide);

    // Tạo hình ảnh mới cho đối tượng zoom
    IImage image = Images.FromFile("image.png");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    // Thêm đối tượng SectionZoomFrame
    ISectionZoomFrame sectionZoomFrame = pres.Slides[0].Shapes.AddSectionZoomFrame(20, 20, 300, 200, pres.Sections[1], ppImage);

    // Lưu bản trình bày
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```
### **Format Section Zoom Frames**

Để tạo các khung zoom phần phức tạp hơn, bạn phải thay đổi định dạng của một khung đơn giản. Có một số tùy chọn định dạng bạn có thể áp dụng cho khung zoom phần. 

Bạn có thể kiểm soát định dạng của khung zoom phần trên slide theo cách sau:

1.	Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation).
2.	Tạo một slide mới.
3.	Thêm nền nhận dạng vào slide đã tạo.
4.	Tạo một phần mới mà bạn dự định liên kết với khung zoom. 
5.	Thêm một khung zoom phần (chứa tham chiếu tới phần đã tạo) vào slide đầu tiên.
6.	Thay đổi kích thước và vị trí cho đối tượng zoom phần đã tạo.
7.	Tạo một đối tượng [IPPImage](https://reference.aspose.com/slides/vi/net/aspose.slides/ippimage) bằng cách thêm ảnh vào bộ sưu tập Images của đối tượng [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation) sẽ được dùng để điền vào khung.
8.	Đặt ảnh tùy chỉnh cho đối tượng khung zoom phần đã tạo.
9.	Đặt khả năng *trở về slide gốc từ phần đã liên kết*. 
10.	Gỡ bỏ nền khỏi ảnh của đối tượng khung zoom phần.
11.	Thay đổi định dạng đường viền cho đối tượng khung zoom thứ hai.
12.	Thay đổi thời gian chuyển đổi.
13.	Ghi bản trình bày đã sửa đổi dưới dạng tệp PPTX.

Mã C# này cho bạn thấy cách thay đổi định dạng của khung zoom phần:

``` csharp 
using (Presentation pres = new Presentation())
{
    //Thêm một slide mới vào bản trình bày
    ISlide slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.YellowGreen;
    slide.Background.Type = BackgroundType.OwnBackground;

    // Thêm một Section mới vào bản trình bày
    pres.Sections.AddSection("Section 1", slide);

    // Thêm đối tượng SectionZoomFrame
    ISectionZoomFrame sectionZoomFrame = pres.Slides[0].Shapes.AddSectionZoomFrame(20, 20, 300, 200, pres.Sections[1]);

    // Định dạng cho SectionZoomFrame
    sectionZoomFrame.X = 100;
    sectionZoomFrame.Y = 300;
    sectionZoomFrame.Width = 100;
    sectionZoomFrame.Height = 75;

    IImage image = Images.FromFile("image.png");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    sectionZoomFrame.ZoomImage = ppImage;

    sectionZoomFrame.ReturnToParent = true;
    sectionZoomFrame.ShowBackground = false;

    sectionZoomFrame.LineFormat.FillFormat.FillType = FillType.Solid;
    sectionZoomFrame.LineFormat.FillFormat.SolidFillColor.Color = Color.Brown;
    sectionZoomFrame.LineFormat.DashStyle = LineDashStyle.DashDot;
    sectionZoomFrame.LineFormat.Width = 2.5f;

    sectionZoomFrame.TransitionDuration = 1.5f;

    // Lưu bản trình bày
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```


## **Summary Zoom**

Summary Zoom giống như một trang đích nơi tất cả các phần của bản trình bày được hiển thị đồng thời. Khi bạn thuyết trình, bạn có thể sử dụng zoom để di chuyển từ một vị trí trong bản trình bày đến vị trí khác theo bất kỳ thứ tự nào bạn muốn. Bạn có thể sáng tạo, bỏ qua hoặc quay lại các phần của slide mà không làm gián đoạn luồng trình bày.

![overview_image](sumzoomsel.png)

Đối với các đối tượng Summary Zoom, Aspose.Slides cung cấp các interface [ISummaryZoomFrame](https://reference.aspose.com/slides/vi/net/aspose.slides/isummaryzoomframe), [ISummaryZoomFrameSection](https://reference.aspose.com/slides/vi/net/aspose.slides/isummaryzoomsection) và [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/vi/net/aspose.slides/isummaryzoomsectioncollection) cùng một số phương thức dưới interface [IShapeCollection](https://reference.aspose.com/slides/vi/net/aspose.slides/ishapecollection).

### **Create a Summary Zoom**

Bạn có thể thêm một khung Summary Zoom vào slide theo cách sau:

1.	Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation).
2.	Tạo các slide mới với nền nhận dạng và các phần mới cho các slide đã tạo.
3.	Thêm khung Summary Zoom vào slide đầu tiên.
4.	Ghi bản trình bày đã sửa đổi dưới dạng tệp PPTX.

Mã C# này cho bạn thấy cách tạo một khung Summary Zoom trên slide:

``` csharp 
using (Presentation pres = new Presentation())
{
    //Thêm một slide mới vào bản trình bày
    ISlide slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Brown;
    slide.Background.Type = BackgroundType.OwnBackground;

    // Thêm một section mới vào bản trình bày
    pres.Sections.AddSection("Section 1", slide);

    //Thêm một slide mới vào bản trình bày
    slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Aqua;
    slide.Background.Type = BackgroundType.OwnBackground;

    // Thêm một section mới vào bản trình bày
    pres.Sections.AddSection("Section 2", slide);

    //Thêm một slide mới vào bản trình bày
    slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Chartreuse;
    slide.Background.Type = BackgroundType.OwnBackground;

    // Thêm một section mới vào bản trình bày
    pres.Sections.AddSection("Section 3", slide);

    //Thêm một slide mới vào bản trình bày
    slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.DarkGreen;
    slide.Background.Type = BackgroundType.OwnBackground;

    // Thêm một section mới vào bản trình bày
    pres.Sections.AddSection("Section 4", slide);

    // Thêm một đối tượng SummaryZoomFrame
    ISummaryZoomFrame summaryZoomFrame = pres.Slides[0].Shapes.AddSummaryZoomFrame(150, 50, 300, 200);

    // Lưu bản trình bày
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```

### **Add and Remove a Summary Zoom Section**

Tất cả các phần trong một khung Summary Zoom được biểu diễn bằng các đối tượng [ISummaryZoomFrameSection](https://reference.aspose.com/slides/vi/net/aspose.slides/isummaryzoomsection), được lưu trữ trong đối tượng [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/vi/net/aspose.slides/isummaryzoomsectioncollection). Bạn có thể thêm hoặc xóa một đối tượng phần Summary Zoom thông qua interface [ISummaryZoomSectionCollection] theo cách sau:

1.	Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation).
2.	Tạo các slide mới với nền nhận dạng và các phần mới cho các slide đã tạo.
3.	Thêm một khung Summary Zoom vào slide đầu tiên.
4.	Thêm một slide và phần mới vào bản trình bày.
5.	Thêm phần đã tạo vào khung Summary Zoom.
6.	Xóa phần đầu tiên khỏi khung Summary Zoom.
7.	Ghi bản trình bày đã sửa đổi dưới dạng tệp PPTX.

Mã C# này cho bạn thấy cách thêm và xóa các phần trong khung Summary Zoom:

``` csharp 
using (Presentation pres = new Presentation())
{
    //Thêm một slide mới vào bản trình bày
    ISlide slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Brown;
    slide.Background.Type = BackgroundType.OwnBackground;

    // Thêm một section mới vào bản trình bày
    pres.Sections.AddSection("Section 1", slide);

    //Thêm một slide mới vào bản trình bày
    slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Aqua;
    slide.Background.Type = BackgroundType.OwnBackground;

    // Thêm một section mới vào bản trình bày
    pres.Sections.AddSection("Section 2", slide);

    // Thêm một đối tượng SummaryZoomFrame
    ISummaryZoomFrame summaryZoomFrame = pres.Slides[0].Shapes.AddSummaryZoomFrame(150, 50, 300, 200);

    //Thêm một slide mới vào bản trình bày
    slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Chartreuse;
    slide.Background.Type = BackgroundType.OwnBackground;

    // Thêm một section mới vào bản trình bày
    ISection section3 = pres.Sections.AddSection("Section 3", slide);

    // Thêm một section vào Summary Zoom
    summaryZoomFrame.SummaryZoomCollection.AddSummaryZoomSection(section3);

    // Xóa section khỏi Summary Zoom
    summaryZoomFrame.SummaryZoomCollection.RemoveSummaryZoomSection(pres.Sections[1]);

    // Lưu bản trình bày
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```

### **Format Summary Zoom Sections**

Để tạo các đối tượng phần Summary Zoom phức tạp hơn, bạn phải thay đổi định dạng của một khung đơn giản. Có một số tùy chọn định dạng bạn có thể áp dụng cho đối tượng phần Summary Zoom. 

Bạn có thể kiểm soát định dạng cho một đối tượng phần Summary Zoom trong khung Summary Zoom theo cách sau:

1.	Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation).
2.	Tạo các slide mới với nền nhận dạng và các phần mới cho các slide đã tạo.
3.	Thêm một khung Summary Zoom vào slide đầu tiên.
4.	Lấy một đối tượng phần Summary Zoom cho đối tượng đầu tiên từ `ISummaryZoomSectionCollection`.
7.	Tạo một đối tượng [IPPImage](https://reference.aspose.com/slides/vi/net/aspose.slides/ippimage) bằng cách thêm ảnh vào bộ sưu tập images của đối tượng [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation) sẽ được dùng để điền vào khung.
8.	Đặt ảnh tùy chỉnh cho đối tượng khung zoom phần đã tạo.
9.	Đặt khả năng *trở về slide gốc từ phần đã liên kết*. 
11.	Thay đổi định dạng đường viền cho đối tượng khung zoom thứ hai.
12.	Thay đổi thời gian chuyển đổi.
13.	Ghi bản trình bày đã sửa đổi dưới dạng tệp PPTX.

Mã C# này cho bạn thấy cách thay đổi định dạng cho đối tượng phần Summary Zoom:

``` csharp 
using (Presentation pres = new Presentation())
{
    //Thêm một slide mới vào bản trình bày
    ISlide slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Brown;
    slide.Background.Type = BackgroundType.OwnBackground;

    // Thêm một section mới vào bản trình bày
    pres.Sections.AddSection("Section 1", slide);

    //Thêm một slide mới vào bản trình bày
    slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Aqua;
    slide.Background.Type = BackgroundType.OwnBackground;

    // Thêm một section mới vào bản trình bày
    pres.Sections.AddSection("Section 2", slide);

    // Thêm một đối tượng SummaryZoomFrame
    ISummaryZoomFrame summaryZoomFrame = pres.Slides[0].Shapes.AddSummaryZoomFrame(150, 50, 300, 200);

    // Lấy đối tượng SummaryZoomSection đầu tiên
    ISummaryZoomSection summarySection = summaryZoomFrame.SummaryZoomCollection[0];

    IImage image = Images.FromFile("image.png");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    // Định dạng cho đối tượng SummaryZoomSection
    summarySection.ZoomImage = ppImage;
    summarySection.ReturnToParent = false;

    summarySection.LineFormat.FillFormat.FillType = FillType.Solid;
    summarySection.LineFormat.FillFormat.SolidFillColor.Color = Color.Black;
    summarySection.LineFormat.DashStyle = LineDashStyle.DashDot;
    summarySection.LineFormat.Width = 1.5f;

    summarySection.TransitionDuration = 1.5f;

    // Lưu bản trình bày
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```

## **FAQ**

**Can I control returning to the 'parent' slide after showing the target?**

Yes. The [Zoom frame](https://reference.aspose.com/slides/vi/net/aspose.slides/zoomframe/) or [section](https://reference.aspose.com/slides/vi/net/aspose.slides/sectionzoomframe/) has a `ReturnToParent` behavior that, when enabled, sends viewers back to the originating slide after they visit the target content.

**Can I adjust the 'speed' or duration of the Zoom transition?**

Yes. Zoom supports setting a `TransitionDuration` so you can control how long the jump animation takes.

**Are there limits on how many Zoom objects a presentation can contain?**

There is no hard API limit documented. Practical limits depend on overall presentation complexity and the viewer's performance. You can add many Zoom frames, but consider file size and rendering time.