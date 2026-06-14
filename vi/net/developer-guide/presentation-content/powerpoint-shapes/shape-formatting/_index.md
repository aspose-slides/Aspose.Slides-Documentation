---
title: Định dạng các hình dạng PowerPoint trong .NET
linktitle: Định dạng hình dạng
type: docs
weight: 20
url: /vi/net/shape-formatting/
keywords:
- định dạng hình dạng
- định dạng đường
- định dạng kiểu nối
- đổ màu gradient
- đổ mẫu
- đổ ảnh
- đổ kết cấu
- đổ màu đồng nhất
- độ trong suốt hình dạng
- xoay hình dạng
- hiệu ứng đè 3D
- hiệu ứng xoay 3D
- đặt lại định dạng
- PowerPoint
- bản trình chiếu
- .NET
- C#
- Aspose.Slides
description: "Tìm hiểu cách định dạng các hình dạng PowerPoint bằng C# sử dụng Aspose.Slides—đặt các kiểu tô, đường và hiệu ứng cho tệp PPT và PPTX một cách chính xác và kiểm soát toàn diện."
---
## **Giới thiệu**

Trong PowerPoint, bạn có thể thêm các hình dạng vào các slide. Vì các hình dạng được tạo thành từ các đường, bạn có thể định dạng chúng bằng cách sửa đổi hoặc áp dụng hiệu ứng cho viền của chúng. Ngoài ra, bạn cũng có thể định dạng các hình dạng bằng cách chỉ định các cài đặt kiểm soát cách nội bộ của chúng được tô.

![Định dạng hình dạng PowerPoint](format-shape-powerpoint.png)

Aspose.Slides for .NET cung cấp các giao diện và thuộc tính cho phép bạn định dạng hình dạng bằng cùng các tùy chọn có sẵn trong PowerPoint.

## **Định dạng Đường**

Sử dụng Aspose.Slides, bạn có thể chỉ định kiểu đường tùy chỉnh cho một hình dạng. Các bước sau mô tả quy trình:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/) .
1. Lấy tham chiếu tới một slide theo chỉ mục của nó.
1. Thêm một [IAutoShape](https://reference.aspose.com/slides/vi/net/aspose.slides/iautoshape/) vào slide.
1. Đặt [line style](https://reference.aspose.com/slides/vi/net/aspose.slides/linestyle/) cho hình dạng.
1. Đặt độ rộng đường.
1. Đặt [dash style](https://reference.aspose.com/slides/vi/net/aspose.slides/linedashstyle/) cho đường.
1. Đặt màu đường cho hình dạng.
1. Lưu bản trình chiếu đã chỉnh sửa dưới dạng tệp PPTX.

Mã C# sau minh họa cách định dạng một `AutoShape` hình chữ nhật:

```c#
// Khởi tạo lớp Presentation đại diện cho một tệp trình chiếu.
using (Presentation presentation = new Presentation())
{
    // Lấy slide đầu tiên.
    ISlide slide = presentation.Slides[0];

    // Thêm một auto shape loại Rectangle.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Đặt màu nền cho hình dạng rectangle.
    shape.FillFormat.FillType = FillType.NoFill;

    // Áp dụng định dạng cho các đường của rectangle.
    shape.LineFormat.Style = LineStyle.ThickThin;
    shape.LineFormat.Width = 7;
    shape.LineFormat.DashStyle = LineDashStyle.Dash;

    // Đặt màu cho đường của rectangle.
    shape.LineFormat.FillFormat.FillType = FillType.Solid;
    shape.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;

    // Lưu tệp PPTX vào đĩa.
    presentation.Save("formatted_lines.pptx", SaveFormat.Pptx);
}
```

Kết quả:

![Các đường đã định dạng trong bản trình chiếu](formatted-lines.png)

## **Định dạng Kiểu Nối**

Dưới đây là ba tùy chọn kiểu nối:

* Tròn
* Mũi góc
* Góc xiên

Mặc định, khi PowerPoint nối hai đường ở một góc (như ở góc của một hình dạng), nó sử dụng cài đặt **Tròn**. Tuy nhiên, nếu bạn vẽ một hình dạng có góc nhọn, bạn có thể muốn sử dụng tùy chọn **Mũi góc**.

![Kiểu nối trong bản trình chiếu](join-style-powerpoint.png)

Mã C# sau minh họa cách ba hình chữ nhật (như trong hình trên) được tạo bằng các cài đặt kiểu nối Mũi góc, Góc xiên và Tròn:

```c#
// Khởi tạo lớp Presentation đại diện cho một tệp trình chiếu.
using (Presentation presentation = new Presentation())
{
    // Lấy slide đầu tiên.
    ISlide slide = presentation.Slides[0];

    // Thêm ba auto shape loại Rectangle.
    IAutoShape shape1 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 150, 75);
    IAutoShape shape2 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 210, 20, 150, 75);
    IAutoShape shape3 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 135, 150, 75);

    // Đặt màu nền cho mỗi hình dạng rectangle.
    shape1.FillFormat.FillType = FillType.Solid;
    shape1.FillFormat.SolidFillColor.Color = Color.Black;
    shape2.FillFormat.FillType = FillType.Solid;
    shape2.FillFormat.SolidFillColor.Color = Color.Black;
    shape3.FillFormat.FillType = FillType.Solid;
    shape3.FillFormat.SolidFillColor.Color = Color.Black;

    // Đặt độ rộng đường.
    shape1.LineFormat.Width = 15;
    shape2.LineFormat.Width = 15;
    shape3.LineFormat.Width = 15;

    // Đặt màu cho đường của mỗi rectangle.
    shape1.LineFormat.FillFormat.FillType = FillType.Solid;
    shape1.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;
    shape2.LineFormat.FillFormat.FillType = FillType.Solid;
    shape2.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;
    shape3.LineFormat.FillFormat.FillType = FillType.Solid;
    shape3.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;

    // Đặt kiểu nối.
    shape1.LineFormat.JoinStyle = LineJoinStyle.Miter;
    shape2.LineFormat.JoinStyle = LineJoinStyle.Bevel;
    shape3.LineFormat.JoinStyle = LineJoinStyle.Round;

    // Thêm văn bản vào mỗi rectangle.
    shape1.TextFrame.Text = "Miter Join Style";
    shape2.TextFrame.Text = "Bevel Join Style";
    shape3.TextFrame.Text = "Round Join Style";

    // Lưu tệp PPTX vào đĩa.
    presentation.Save("join_styles.pptx", SaveFormat.Pptx);
}
```

## **Đổ màu Gradient**

Trong PowerPoint, Đổ màu Gradient là một tùy chọn định dạng cho phép bạn áp dụng một sự pha trộn liên tục của các màu vào một hình dạng. Ví dụ, bạn có thể áp dụng hai màu hoặc nhiều hơn sao cho một màu dần dần chuyển sang màu khác.

Cách áp dụng Đổ màu Gradient cho một hình dạng bằng Aspose.Slides:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/) .
1. Lấy tham chiếu tới một slide theo chỉ mục của nó.
1. Thêm một [IAutoShape](https://reference.aspose.com/slides/vi/net/aspose.slides/iautoshape/) vào slide.
1. Đặt [FillType](https://reference.aspose.com/slides/vi/net/aspose.slides/filltype/) của hình dạng thành `Gradient`.
1. Thêm hai màu bạn muốn với vị trí đã định nghĩa bằng các phương thức `Add` của bộ sưu tập gradient stop được cung cấp bởi giao diện [IGradientFormat](https://reference.aspose.com/slides/vi/net/aspose.slides/igradientformat/) .
1. Lưu bản trình chiếu đã chỉnh sửa dưới dạng tệp PPTX.

Mã C# sau minh họa cách áp dụng hiệu ứng Đổ màu Gradient cho một hình ellipse:

```c#
// Khởi tạo lớp Presentation đại diện cho một tệp trình chiếu.
using (Presentation presentation = new Presentation())
{
    // Lấy slide đầu tiên.
    ISlide slide = presentation.Slides[0];

    // Thêm một auto shape loại Ellipse.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 50, 50, 150, 75);

    // Áp dụng định dạng gradient cho ellipse.
    shape.FillFormat.FillType = FillType.Gradient;
    shape.FillFormat.GradientFormat.GradientShape = GradientShape.Linear;

    // Đặt hướng của gradient.
    shape.FillFormat.GradientFormat.GradientDirection = GradientDirection.FromCorner2;

    // Thêm hai gradient stop.
    shape.FillFormat.GradientFormat.GradientStops.Add(1.0f, PresetColor.Purple);
    shape.FillFormat.GradientFormat.GradientStops.Add(0.0f, PresetColor.Red);

    // Lưu tệp PPTX vào đĩa.
    presentation.Save("gradient_fill.pptx", SaveFormat.Pptx);
}
```

Kết quả:

![Ellipse với Đổ màu Gradient](gradient-fill.png)

## **Đổ mẫu**

Trong PowerPoint, Đổ mẫu là một tùy chọn định dạng cho phép bạn áp dụng một thiết kế hai màu—như chấm, sọc, sọc chéo hoặc ô vuông—cho một hình dạng. Bạn có thể chọn màu tùy chỉnh cho màu nền và màu chữ của mẫu.

Aspose.Slides cung cấp hơn 45 kiểu mẫu được định nghĩa sẵn mà bạn có thể áp dụng cho các hình dạng để tăng tính thẩm mỹ cho bản trình chiếu. Ngay cả sau khi chọn một mẫu đã định nghĩa sẵn, bạn vẫn có thể chỉ định các màu chính xác mà nó sẽ sử dụng.

Cách áp dụng Đổ mẫu cho một hình dạng bằng Aspose.Slides:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/) .
1. Lấy tham chiếu tới một slide theo chỉ mục của nó.
1. Thêm một [IAutoShape](https://reference.aspose.com/slides/vi/net/aspose.slides/iautoshape/) vào slide.
1. Đặt [FillType](https://reference.aspose.com/slides/vi/net/aspose.slides/filltype/) của hình dạng thành `Pattern`.
1. Chọn kiểu mẫu từ các tùy chọn được định nghĩa trước.
1. Đặt [Background Color](https://reference.aspose.com/slides/vi/net/aspose.slides/ipatternformat/backcolor/) của mẫu.
1. Đặt [Foreground Color](https://reference.aspose.com/slides/vi/net/aspose.slides/ipatternformat/forecolor/) của mẫu.
1. Lưu bản trình chiếu đã chỉnh sửa dưới dạng tệp PPTX.

Mã C# sau minh họa cách áp dụng Đổ mẫu cho một hình chữ nhật:

```c#
// Khởi tạo lớp Presentation đại diện cho một tệp trình chiếu.
using (Presentation presentation = new Presentation())
{
    // Lấy slide đầu tiên.
    ISlide slide = presentation.Slides[0];

    // Thêm một auto shape loại Rectangle.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Đặt kiểu tô là Pattern.
    shape.FillFormat.FillType = FillType.Pattern;

    // Đặt kiểu mẫu.
    shape.FillFormat.PatternFormat.PatternStyle = PatternStyle.Trellis;

    // Đặt màu nền và màu trước của mẫu.
    shape.FillFormat.PatternFormat.BackColor.Color = Color.LightGray;
    shape.FillFormat.PatternFormat.ForeColor.Color = Color.Yellow;

    // Lưu tệp PPTX vào đĩa.
    presentation.Save("pattern_fill.pptx", SaveFormat.Pptx);
}
```

Kết quả:

![Hình chữ nhật với Đổ mẫu](pattern-fill.png)

## **Đổ ảnh**

Trong PowerPoint, Đổ ảnh là một tùy chọn định dạng cho phép bạn chèn một hình ảnh vào bên trong một hình dạng—thực chất sử dụng hình ảnh làm nền của hình dạng.

Cách sử dụng Aspose.Slides để áp dụng Đổ ảnh cho một hình dạng:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/) .
1. Lấy tham chiếu tới một slide theo chỉ mục của nó.
1. Thêm một [IAutoShape](https://reference.aspose.com/slides/vi/net/aspose.slides/iautoshape/) vào slide.
1. Đặt [FillType](https://reference.aspose.com/slides/vi/net/aspose.slides/filltype/) của hình dạng thành `Picture`.
1. Đặt chế độ đổ ảnh thành `Tile` (hoặc chế độ khác mà bạn muốn).
1. Tạo một đối tượng [IPPImage](https://reference.aspose.com/slides/vi/net/aspose.slides/ippimage/) từ hình ảnh bạn muốn sử dụng.
1. Gán hình ảnh này cho thuộc tính `Picture.Image` của `PictureFillFormat` của hình dạng.
1. Lưu bản trình chiếu đã chỉnh sửa dưới dạng tệp PPTX.

Giả sử chúng ta có tệp "lotus.png" với hình ảnh sau:

![Hình lotus](lotus.png)

Mã C# sau minh họa cách đổ ảnh vào một hình dạng:

```c#
// Khởi tạo lớp Presentation đại diện cho một tệp trình chiếu.
using (Presentation presentation = new Presentation())
{
    // Lấy slide đầu tiên.
    ISlide slide = presentation.Slides[0];

    // Thêm một auto shape loại Rectangle.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 255, 130);

    // Đặt kiểu tô là Picture.
    shape.FillFormat.FillType = FillType.Picture;

    // Đặt chế độ đổ ảnh.
    shape.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Tile;

    // Tải một hình ảnh và thêm vào tài nguyên của bản trình chiếu.
    IImage image = Images.FromFile("lotus.png");
    IPPImage presentationImage = presentation.Images.AddImage(image);
    image.Dispose();

    // Đặt hình ảnh.
    shape.FillFormat.PictureFillFormat.Picture.Image = presentationImage;

    // Lưu tệp PPTX vào đĩa.
    presentation.Save("picture_fill.pptx", SaveFormat.Pptx);
}
```

Kết quả:

![Hình dạng với Đổ ảnh](picture-fill.png)

### **Gạch ảnh làm kết cấu**

Nếu bạn muốn đặt một ảnh đã gạch làm kết cấu và tùy chỉnh hành vi gạch, bạn có thể sử dụng các thuộc tính sau của giao diện [IPictureFillFormat](https://reference.aspose.com/slides/vi/net/aspose.slides/ipicturefillformat/) và lớp [PictureFillFormat](https://reference.aspose.com/slides/vi/net/aspose.slides/picturefillformat/) :

- [PictureFillMode](https://reference.aspose.com/slides/vi/net/aspose.slides/ipicturefillformat/picturefillmode/) : Đặt chế độ đổ ảnh — hoặc `Tile` hoặc `Stretch`.
- [TileAlignment](https://reference.aspose.com/slides/vi/net/aspose.slides/ipicturefillformat/tilealignment/) : Xác định căn chỉnh của các ô trong hình dạng.
- [TileFlip](https://reference.aspose.com/slides/vi/net/aspose.slides/ipicturefillformat/tileflip/) : Kiểm soát xem ô có bị lật ngang, dọc, hay cả hai.
- [TileOffsetX](https://reference.aspose.com/slides/vi/net/aspose.slides/ipicturefillformat/tileoffsetx/) : Đặt độ lệch ngang của ô (theo điểm) từ gốc của hình dạng.
- [TileOffsetY](https://reference.aspose.com/slides/vi/net/aspose.slides/ipicturefillformat/tileoffsety/) : Đặt độ lệch dọc của ô (theo điểm) từ gốc của hình dạng.
- [TileScaleX](https://reference.aspose.com/slides/vi/net/aspose.slides/ipicturefillformat/tilescalex/) : Xác định tỷ lệ ngang của ô dưới dạng phần trăm.
- [TileScaleY](https://reference.aspose.com/slides/vi/net/aspose.slides/ipicturefillformat/tilescaley/) : Xác định tỷ lệ dọc của ô dưới dạng phần trăm.

Mã mẫu sau cho thấy cách thêm một hình chữ nhật với Đổ ảnh gạch và cấu hình các tùy chọn gạch:

```c#
// Khởi tạo lớp Presentation đại diện cho một tệp trình chiếu.
using (Presentation presentation = new Presentation())
{
    // Lấy slide đầu tiên.
    ISlide firstSlide = presentation.Slides[0];

    // Thêm một auto shape hình chữ nhật.
    IAutoShape shape = firstSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 190, 95);

    // Đặt kiểu tô của hình dạng là Picture.
    shape.FillFormat.FillType = FillType.Picture;

    // Tải hình ảnh và thêm vào tài nguyên của bản trình chiếu.
    IPPImage presentationImage;
    using (IImage sourceImage = Images.FromFile("lotus.png"))
        presentationImage = presentation.Images.AddImage(sourceImage);

    // Gán hình ảnh cho hình dạng.
    IPictureFillFormat pictureFillFormat = shape.FillFormat.PictureFillFormat;
    pictureFillFormat.Picture.Image = presentationImage;

    // Cấu hình chế độ đổ ảnh và các thuộc tính gạch.
    pictureFillFormat.PictureFillMode = PictureFillMode.Tile;
    pictureFillFormat.TileOffsetX = -32;
    pictureFillFormat.TileOffsetY = -32;
    pictureFillFormat.TileScaleX = 50;
    pictureFillFormat.TileScaleY = 50;
    pictureFillFormat.TileAlignment = RectangleAlignment.BottomRight;
    pictureFillFormat.TileFlip = TileFlip.FlipBoth;

    // Lưu tệp PPTX vào đĩa.
    presentation.Save("tile.pptx", SaveFormat.Pptx);
}
```

Kết quả:

![Các tùy chọn gạch](tile-options.png)

## **Đổ màu Đơn sắc**

Trong PowerPoint, Đổ màu Đơn sắc là một tùy chọn định dạng làm đầy một hình dạng bằng một màu duy nhất, đồng nhất. Màu nền đơn giản này được áp dụng mà không có bất kỳ gradient, kết cấu hay mẫu nào.

Để áp dụng Đổ màu Đơn sắc cho một hình dạng bằng Aspose.Slides, thực hiện các bước sau:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/) .
1. Lấy tham chiếu tới một slide theo chỉ mục của nó.
1. Thêm một [IAutoShape](https://reference.aspose.com/slides/vi/net/aspose.slides/iautoshape/) vào slide.
1. Đặt [FillType](https://reference.aspose.com/slides/vi/net/aspose.slides/filltype/) của hình dạng thành `Solid`.
1. Gán màu tô bạn muốn cho hình dạng.
1. Lưu bản trình chiếu đã chỉnh sửa dưới dạng tệp PPTX.

Mã C# sau minh họa cách áp dụng Đổ màu Đơn sắc cho một hình chữ nhật trong slide PowerPoint:

```c#
// Khởi tạo lớp Presentation đại diện cho một tệp trình chiếu.
using (Presentation presentation = new Presentation())
{
    // Lấy slide đầu tiên.
    ISlide slide = presentation.Slides[0];

    // Thêm một auto shape loại Rectangle.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Đặt kiểu tô là Solid.
    shape.FillFormat.FillType = FillType.Solid;

    // Đặt màu tô.
    shape.FillFormat.SolidFillColor.Color = Color.Yellow;

    // Lưu tệp PPTX vào đĩa.
    presentation.Save("solid_color_fill.pptx", SaveFormat.Pptx);
}
```

Kết quả:

![Hình dạng với Đổ màu Đơn sắc](solid-color-fill.png)

## **Đặt độ trong suốt**

Trong PowerPoint, khi bạn áp dụng một màu đơn, gradient, ảnh hoặc kết cấu cho các hình dạng, bạn cũng có thể đặt mức độ trong suốt để kiểm soát độ mờ của lớp tô. Giá trị trong suốt cao hơn sẽ làm cho hình dạng trong suốt hơn, cho phép nền hoặc các đối tượng phía dưới hiển thị một phần.

Aspose.Slides cho phép bạn đặt mức độ trong suốt bằng cách điều chỉnh giá trị alpha trong màu được sử dụng cho lớp tô. Cách thực hiện:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/) .
1. Lấy tham chiếu tới một slide theo chỉ mục của nó.
1. Thêm một [IAutoShape](https://reference.aspose.com/slides/vi/net/aspose.slides/iautoshape/) vào slide.
1. Đặt [FillType](https://reference.aspose.com/slides/vi/net/aspose.slides/filltype/) thành `Solid`.
1. Sử dụng `Color.FromArgb(alpha, baseColor)` để định nghĩa một màu có độ trong suốt (thành phần `alpha` kiểm soát độ trong suốt).
1. Lưu bản trình chiếu.

Mã C# sau minh họa cách áp dụng màu tô trong suốt cho một hình chữ nhật:

```c#
const int alpha = 128;

// Khởi tạo lớp Presentation đại diện cho một tệp trình chiếu.
using (Presentation presentation = new Presentation())
{
    // Lấy slide đầu tiên.
    ISlide slide = presentation.Slides[0];

    // Thêm một auto shape hình chữ nhật đặc.
    IAutoShape solidShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Thêm một auto shape hình chữ nhật trong suốt lên trên hình dạng đặc.
    IAutoShape transparentShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 80, 80, 150, 75);
    transparentShape.FillFormat.FillType = FillType.Solid;
    transparentShape.FillFormat.SolidFillColor.Color = Color.FromArgb(alpha, Color.Yellow);

    // Lưu tệp PPTX vào đĩa.
    presentation.Save("shape_transparency.pptx", SaveFormat.Pptx);
}
```

Kết quả:

![Hình dạng trong suốt](shape-transparency.png)

## **Xoay hình dạng**

Aspose.Slides cho phép bạn xoay các hình dạng trong bản trình chiếu PowerPoint. Điều này hữu ích khi bố trí các yếu tố hình ảnh với yêu cầu căn chỉnh hoặc thiết kế cụ thể.

Để xoay một hình dạng trên slide, thực hiện các bước sau:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/) .
1. Lấy tham chiếu tới một slide theo chỉ mục của nó.
1. Thêm một [IAutoShape](https://reference.aspose.com/slides/vi/net/aspose.slides/iautoshape/) vào slide.
1. Đặt thuộc tính `Rotation` của hình dạng thành góc mong muốn.
1. Lưu bản trình chiếu.

Mã C# sau minh họa cách xoay một hình dạng 5 độ:

```c#
// Khởi tạo lớp Presentation đại diện cho một tệp trình chiếu.
using (Presentation presentation = new Presentation())
{
    // Lấy slide đầu tiên.
    ISlide slide = presentation.Slides[0];

    // Thêm một auto shape loại Rectangle.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Xoay hình dạng 5 độ.
    shape.Rotation = 5;

    // Lưu tệp PPTX vào đĩa.
    presentation.Save("shape_rotation.pptx", SaveFormat.Pptx);
}
```

Kết quả:

![Xoay hình dạng](shape-rotation.png)

## **Thêm hiệu ứng Đè 3D**

Aspose.Slides cho phép bạn áp dụng các hiệu ứng Đè 3D cho các hình dạng bằng cách cấu hình các thuộc tính của [ThreeDFormat](https://reference.aspose.com/slides/vi/net/aspose.slides/threedformat/) .

Để thêm hiệu ứng Đè 3D cho một hình dạng, thực hiện các bước sau:

1. Khởi tạo lớp [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/) .
1. Lấy tham chiếu tới một slide theo chỉ mục của nó.
1. Thêm một [IAutoShape](https://reference.aspose.com/slides/vi/net/aspose.slides/iautoshape/) vào slide.
1. Cấu hình [ThreeDFormat](https://reference.aspose.com/slides/vi/net/aspose.slides/threedformat/) của hình dạng để xác định các cài đặt Đè.
1. Lưu bản trình chiếu.

Mã C# sau cho thấy cách áp dụng hiệu ứng Đè 3D cho một hình dạng:

```c#
// Tạo một thể hiện của lớp Presentation.
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Thêm một hình dạng vào slide.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 50, 50, 100, 100);
    shape.FillFormat.FillType = FillType.Solid;
    shape.FillFormat.SolidFillColor.Color = Color.Green;
    shape.LineFormat.FillFormat.FillType = FillType.Solid;
    shape.LineFormat.FillFormat.SolidFillColor.Color = Color.Orange;
    shape.LineFormat.Width = 2.0;

    // Đặt các thuộc tính ThreeDFormat của hình dạng.
    shape.ThreeDFormat.Depth = 4;
    shape.ThreeDFormat.BevelTop.BevelType = BevelPresetType.Circle;
    shape.ThreeDFormat.BevelTop.Height = 6;
    shape.ThreeDFormat.BevelTop.Width = 6;
    shape.ThreeDFormat.Camera.CameraType = CameraPresetType.OrthographicFront;
    shape.ThreeDFormat.LightRig.LightType = LightRigPresetType.ThreePt;
    shape.ThreeDFormat.LightRig.Direction = LightingDirection.Top;

    // Lưu bản trình chiếu dưới dạng tệp PPTX.
    presentation.Save("3D_bevel_effect.pptx", SaveFormat.Pptx);
}
```

Kết quả:

![Hiệu ứng Đè 3D](3D-bevel-effect.png)

## **Thêm hiệu ứng Xoay 3D**

Aspose.Slides cho phép bạn áp dụng các hiệu ứng Xoay 3D cho các hình dạng bằng cách cấu hình các thuộc tính của [ThreeDFormat](https://reference.aspose.com/slides/vi/net/aspose.slides/threedformat/) .

Để áp dụng Xoay 3D cho một hình dạng:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/) .
1. Lấy tham chiếu tới một slide theo chỉ mục của nó.
1. Thêm một [IAutoShape](https://reference.aspose.com/slides/vi/net/aspose.slides/iautoshape/) vào slide.
1. Đặt [CameraType](https://reference.aspose.com/slides/vi/net/aspose.slides/icamera/cameratype/) và [LightType](https://reference.aspose.com/slides/vi/net/aspose.slides/ilightrig/lighttype/) của hình dạng để xác định Xoay 3D.
1. Lưu bản trình chiếu.

Mã C# sau minh họa cách áp dụng hiệu ứng Xoay 3D cho một hình dạng:

```c#
// Tạo một thể hiện của lớp Presentation.
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);
    autoShape.TextFrame.Text = "Hello, Aspose!";

    autoShape.ThreeDFormat.Depth = 6;
    autoShape.ThreeDFormat.Camera.SetRotation(40, 35, 20);
    autoShape.ThreeDFormat.Camera.CameraType = CameraPresetType.IsometricLeftUp;
    autoShape.ThreeDFormat.LightRig.LightType = LightRigPresetType.Balanced;

    // Lưu bản trình chiếu dưới dạng tệp PPTX.
    presentation.Save("3D_rotation_effect.pptx", SaveFormat.Pptx);
}
```

Kết quả:

![Hiệu ứng Xoay 3D](3D-rotation-effect.png)

## **Đặt lại định dạng**

Mã C# sau cho thấy cách đặt lại định dạng của một slide và khôi phục vị trí, kích thước và định dạng của tất cả các hình dạng có trình giữ chỗ trên [LayoutSlide](https://reference.aspose.com/slides/vi/net/aspose.slides/layoutslide/) về cài đặt mặc định:

```c#
using (Presentation presentation = new Presentation("sample.pptx"))
{
    foreach (ISlide slide in presentation.Slides)
    {
        // Đặt lại mỗi hình dạng trên slide có trình giữ chỗ trên bố cục.
        slide.Reset();
    }

    presentation.Save("reset_formatting.pptx", SaveFormat.Pptx);
}
```

## **FAQ**

**Định dạng hình dạng có ảnh hưởng đến kích thước tệp bản trình chiếu cuối cùng không?**

Chỉ ảnh hưởng rất ít. Các hình ảnh và phương tiện nhúng chiếm phần lớn dung lượng tệp, trong khi các tham số hình dạng như màu, hiệu ứng và gradient được lưu dưới dạng siêu dữ liệu và gần như không làm tăng kích thước.

**Làm thế nào để tôi phát hiện các hình dạng trên một slide có cùng định dạng để có thể nhóm chúng?**

So sánh các thuộc tính định dạng chính của mỗi hình dạng—cài đặt fill, line và effect. Nếu tất cả các giá trị tương ứng khớp nhau, coi kiểu của chúng là giống nhau và nhóm logic các hình dạng đó, giúp việc quản lý kiểu sau này trở nên đơn giản hơn.

**Tôi có thể lưu một tập hợp các kiểu hình dạng tùy chỉnh vào một tệp riêng để tái sử dụng trong các bản trình chiếu khác không?**

Có. Lưu các hình mẫu có kiểu mong muốn vào một slide mẫu hoặc tệp mẫu .POTX. Khi tạo bản trình chiếu mới, mở mẫu, sao chép các hình dạng đã định kiểu bạn cần và áp dụng lại định dạng của chúng ở nơi cần thiết.