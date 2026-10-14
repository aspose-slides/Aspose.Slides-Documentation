---
title: Định dạng các hình dạng PowerPoint trong .NET
linktitle: Định dạng hình dạng
type: docs
weight: 20
url: /vi/net/shape-formatting/
keywords:
- định dạng hình dạng
- định dạng đường
- hiệu ứng sketch
- đường nét hình dạng sketch
- định dạng kiểu nối
- đổ màu gradient
- đổ mẫu
- đổ hình ảnh
- đổ họa tiết
- đổ màu đặc
- độ trong suốt hình dạng
- kết xuất hình dạng đen-trắng
- kết xuất hình dạng xám
- xoay hình dạng
- hiệu ứng Bo góc 3D
- hiệu ứng xoay 3D
- đặt lại định dạng
- PowerPoint
- bản trình chiếu
- .NET
- C#
- Aspose.Slides
description: "Tìm hiểu cách định dạng các hình dạng PowerPoint trong C# bằng Aspose.Slides—đặt các kiểu tô, đường và hiệu ứng cho các tệp PPT và PPTX một cách chính xác và kiểm soát hoàn toàn."
---
## **Giới thiệu**

Trong PowerPoint, bạn có thể thêm các hình dạng vào các slide. Vì các hình dạng được tạo thành từ các đường, bạn có thể định dạng chúng bằng cách sửa đổi hoặc áp dụng hiệu ứng lên đường viền. Ngoài ra, bạn có thể định dạng các hình dạng bằng cách chỉ định các cài đặt kiểm soát cách phần bên trong của chúng được tô màu.

![định dạng hình dạng trong PowerPoint](format-shape-powerpoint.png)

Aspose.Slides for .NET cung cấp các giao diện và thuộc tính cho phép bạn định dạng các hình dạng bằng các tùy chọn giống như trong PowerPoint.

## **Định dạng Đường**

Sử dụng Aspose.Slides, bạn có thể chỉ định kiểu đường tùy chỉnh cho một hình dạng. Các bước sau mô tả quy trình:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
1. Lấy tham chiếu đến một slide bằng chỉ mục của nó.
1. Thêm một [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) vào slide.
1. Đặt [line style](https://reference.aspose.com/slides/net/aspose.slides/linestyle/) cho hình dạng.
1. Đặt độ rộng của đường.
1. Đặt [dash style](https://reference.aspose.com/slides/net/aspose.slides/linedashstyle/) cho đường.
1. Đặt màu đường cho hình dạng.
1. Lưu bản trình chiếu đã sửa đổi dưới dạng tệp PPTX.

Đoạn mã C# sau minh họa cách định dạng một hình chữ nhật `AutoShape`:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// Khởi tạo lớp Presentation đại diện cho tệp trình chiếu.
using (Presentation presentation = new Presentation())
{
    // Lấy slide đầu tiên.
    ISlide slide = presentation.Slides[0];

    // Thêm một auto shape loại Hình chữ nhật.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Đặt màu nền cho hình dạng hình chữ nhật.
    shape.FillFormat.FillType = FillType.NoFill;

    // Áp dụng định dạng cho các đường của hình chữ nhật.
    shape.LineFormat.Style = LineStyle.ThickThin;
    shape.LineFormat.Width = 7;
    shape.LineFormat.DashStyle = LineDashStyle.Dash;

    // Đặt màu cho đường của hình chữ nhật.
    shape.LineFormat.FillFormat.FillType = FillType.Solid;
    shape.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;

    // Lưu tệp PPTX vào đĩa.
    presentation.Save("formatted_lines.pptx", SaveFormat.Pptx);
}
```

Kết quả:

![Các đường đã định dạng trong bản trình chiếu](formatted-lines.png)

## **Áp dụng Hiệu ứng Sketch cho Đường hình dạng**

Hiệu ứng sketch làm cho đường của hình dạng trông như được vẽ tay. Sử dụng [IShape.LineFormat](https://reference.aspose.com/slides/net/aspose.slides/ishape/lineformat/) để truy cập các cài đặt đường, [ILineFormat.SketchFormat](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/sketchformat/) để truy cập các cài đặt sketch, và [ISketchFormat.SketchType](https://reference.aspose.com/slides/net/aspose.slides/isketchformat/sketchtype/) để chọn một giá trị từ enumeration [LineSketchType](https://reference.aspose.com/slides/net/aspose.slides/linesketchtype/).

Đoạn mã C# sau cho thấy cách áp dụng hiệu ứng [LineSketchType.Curved](https://reference.aspose.com/slides/net/aspose.slides/linesketchtype/) , đọc giá trị được gán trực tiếp, và xóa hiệu ứng bằng [LineSketchType.None](https://reference.aspose.com/slides/net/aspose.slides/linesketchtype/):

```csharp
using Aspose.Slides;

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);

// Access the shape's line format and its sketch format.
var sketchFormat = shape.LineFormat.SketchFormat;

// Apply a sketch effect.
sketchFormat.SketchType = LineSketchType.Curved;

// Read the sketch effect assigned directly to the shape.
var explicitSketchType = sketchFormat.SketchType;
Console.WriteLine($"Explicit sketch type: {explicitSketchType}");

// Remove the sketch effect.
sketchFormat.SketchType = LineSketchType.None;
```

Giá trị trả về bởi `ISketchFormat.SketchType` đại diện cho cài đặt được gán trực tiếp cho hình dạng. Nếu định dạng đường có thể được kế thừa từ theme, master slide hoặc layout slide, hãy sử dụng [ILineFormat.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/geteffective/), truy cập [ILineFormatEffectiveData.SketchFormat](https://reference.aspose.com/slides/net/aspose.slides/ilineformateffectivedata/sketchformat/), và đọc [ISketchFormatEffectiveData.SketchType](https://reference.aspose.com/slides/net/aspose.slides/isketchformateffectivedata/sketchtype/). Giá trị effective phản ánh định dạng thực tế được áp dụng sau khi kế thừa được giải quyết:

```csharp
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");

var shape = presentation.Slides[0].Shapes[0];
var lineFormat = shape.LineFormat;

var explicitSketchType = lineFormat.SketchFormat.SketchType;
var effectiveLineFormat = lineFormat.GetEffective();
var effectiveSketchType = effectiveLineFormat.SketchFormat.SketchType;

Console.WriteLine($"Explicit sketch type: {explicitSketchType}");
Console.WriteLine($"Effective sketch type: {effectiveSketchType}");
```

## **Định dạng Kiểu Nối**

Dưới đây là ba tùy chọn kiểu nối:

* Round
* Miter
* Bevel

Mặc định, khi PowerPoint nối hai đường ở một góc (ví dụ tại góc của một hình dạng), nó sử dụng cài đặt **Round**. Tuy nhiên, nếu bạn đang vẽ một hình dạng có các góc nhọn, bạn có thể ưu tiên tùy chọn **Miter**.

![Kiểu nối trong bản trình chiếu](join-style-powerpoint.png)

Đoạn mã C# sau minh họa cách ba hình chữ nhật (như trong hình trên) được tạo bằng các cài đặt kiểu nối Miter, Bevel và Round:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// Khởi tạo lớp Presentation đại diện cho tệp trình chiếu.
using (Presentation presentation = new Presentation())
{
    // Lấy slide đầu tiên.
    ISlide slide = presentation.Slides[0];

    // Thêm ba auto shape loại Hình chữ nhật.
    IAutoShape shape1 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 150, 75);
    IAutoShape shape2 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 210, 20, 150, 75);
    IAutoShape shape3 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 135, 150, 75);

    // Đặt màu nền cho mỗi hình chữ nhật.
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

    // Đặt màu cho đường của mỗi hình chữ nhật.
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

    // Thêm văn bản vào mỗi hình chữ nhật.
    shape1.TextFrame.Text = "Miter Join Style";
    shape2.TextFrame.Text = "Bevel Join Style";
    shape3.TextFrame.Text = "Round Join Style";

    // Lưu tệp PPTX vào đĩa.
    presentation.Save("join_styles.pptx", SaveFormat.Pptx);
}
```

## **Đổ màu Gradient**

Trong PowerPoint, Gradient Fill là một tùy chọn định dạng cho phép bạn áp dụng một pha màu liên tục lên một hình dạng. Ví dụ, bạn có thể áp dụng hai hoặc nhiều màu sao cho một màu dần chuyển sang màu khác.

Dưới đây là cách áp dụng gradient fill cho một hình dạng bằng Aspose.Slides:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
1. Lấy tham chiếu đến một slide bằng chỉ mục của nó.
1. Thêm một [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) vào slide.
1. Đặt [FillType](https://reference.aspose.com/slides/net/aspose.slides/filltype/) của hình dạng thành `Gradient`.
1. Thêm hai màu ưa thích của bạn với vị trí đã định nghĩa bằng các phương thức `Add` của bộ sưu tập gradient stop được khai thác qua giao diện [IGradientFormat](https://reference.aspose.com/slides/net/aspose.slides/igradientformat/).
1. Lưu bản trình chiếu đã sửa đổi dưới dạng tệp PPTX.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Khởi tạo lớp Presentation đại diện cho tệp trình chiếu.
using (Presentation presentation = new Presentation())
{
    // Lấy slide đầu tiên.
    ISlide slide = presentation.Slides[0];

    // Thêm một auto shape loại Ellipse.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 50, 50, 150, 75);

    // Áp dụng định dạng gradient cho hình ellipse.
    shape.FillFormat.FillType = FillType.Gradient;
    shape.FillFormat.GradientFormat.GradientShape = GradientShape.Linear;

    // Đặt hướng của gradient.
    shape.FillFormat.GradientFormat.GradientDirection = GradientDirection.FromCorner2;

    // Thêm hai điểm dừng gradient.
    shape.FillFormat.GradientFormat.GradientStops.Add(1.0f, PresetColor.Purple);
    shape.FillFormat.GradientFormat.GradientStops.Add(0.0f, PresetColor.Red);

    // Lưu tệp PPTX vào đĩa.
    presentation.Save("gradient_fill.pptx", SaveFormat.Pptx);
}
```

Kết quả:

![Ellipse với độ đổ màu gradient](gradient-fill.png)

Nếu một gradient trông khác biệt trong ảnh xuất ra so với trong PowerPoint, xem [Choose a Gradient Rendering Style](/slides/vi/net/convert-powerpoint-to-png/#choose-a-gradient-rendering-style). Bạn có thể chọn kiểu kết xuất mà không thay đổi gradient fill được lưu trong bản trình chiếu.

## **Đổ mẫu**

Trong PowerPoint, Pattern Fill là một tùy chọn định dạng cho phép bạn áp dụng một thiết kế hai màu—như chấm, sọc, vằn chéo hoặc ô vuông—cho một hình dạng. Bạn có thể chọn màu tùy chỉnh cho tiền cảnh và nền của mẫu.

Aspose.Slides cung cấp hơn 45 kiểu mẫu được định nghĩa trước mà bạn có thể áp dụng cho các hình dạng để nâng cao tính thẩm mỹ của bản trình chiếu. Ngay cả sau khi chọn một mẫu đã định nghĩa, bạn vẫn có thể chỉ định màu chính xác mà nó sẽ sử dụng.

Dưới đây là cách áp dụng pattern fill cho một hình dạng bằng Aspose.Slides:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
1. Lấy tham chiếu đến một slide bằng chỉ mục của nó.
1. Thêm một [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) vào slide.
1. Đặt [FillType](https://reference.aspose.com/slides/net/aspose.slides/filltype/) của hình dạng thành `Pattern`.
1. Chọn một kiểu mẫu từ các tùy chọn đã định nghĩa trước.
1. Đặt [Background Color](https://reference.aspose.com/slides/net/aspose.slides/ipatternformat/backcolor/) của mẫu.
1. Đặt [Foreground Color](https://reference.aspose.com/slides/net/aspose.slides/ipatternformat/forecolor/) của mẫu.
1. Lưu bản trình chiếu đã sửa đổi dưới dạng tệp PPTX.

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// Khởi tạo lớp Presentation đại diện cho tệp trình chiếu.
using (Presentation presentation = new Presentation())
{
    // Lấy slide đầu tiên.
    ISlide slide = presentation.Slides[0];

    // Thêm một auto shape loại Rectangle.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Đặt loại fill thành Pattern.
    shape.FillFormat.FillType = FillType.Pattern;

    // Đặt kiểu mẫu.
    shape.FillFormat.PatternFormat.PatternStyle = PatternStyle.Trellis;

    // Đặt màu nền và màu tiền cảnh cho mẫu.
    shape.FillFormat.PatternFormat.BackColor.Color = Color.LightGray;
    shape.FillFormat.PatternFormat.ForeColor.Color = Color.Yellow;

    // Lưu tệp PPTX vào đĩa.
    presentation.Save("pattern_fill.pptx", SaveFormat.Pptx);
}
```

Kết quả:

![Hình chữ nhật với đổ mẫu](pattern-fill.png)

## **Đổ Hình ảnh**

Trong PowerPoint, Picture Fill là một tùy chọn định dạng cho phép bạn chèn một hình ảnh vào bên trong một hình dạng—thực chất sử dụng hình ảnh làm nền cho hình dạng.

Dưới đây là cách sử dụng Aspose.Slides để áp dụng picture fill cho một hình dạng:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
1. Lấy tham chiếu đến một slide bằng chỉ mục của nó.
1. Thêm một [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) vào slide.
1. Đặt [FillType](https://reference.aspose.com/slides/net/aspose.slides/filltype/) của hình dạng thành `Picture`.
1. Đặt chế độ picture fill thành `Tile` (hoặc chế độ ưa thích khác).
1. Tạo một đối tượng [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage/) từ hình ảnh bạn muốn sử dụng.
1. Gán hình ảnh này cho thuộc tính `Picture.Image` của `PictureFillFormat` của hình dạng.
1. Lưu bản trình chiếu đã sửa đổi dưới dạng tệp PPTX.

Giả sử chúng ta có tệp "lotus.png" với hình ảnh sau:

![Hình ảnh lotus](lotus.png)

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Khởi tạo lớp Presentation đại diện cho tệp trình chiếu.
using (Presentation presentation = new Presentation())
{
    // Lấy slide đầu tiên.
    ISlide slide = presentation.Slides[0];

    // Thêm một auto shape loại Rectangle.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 255, 130);

    // Đặt loại fill thành Picture.
    shape.FillFormat.FillType = FillType.Picture;

    // Đặt chế độ picture fill.
    shape.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Tile;

    // Tải ảnh và thêm vào tài nguyên của bản trình chiếu.
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

![Hình dạng với đổ hình ảnh](picture-fill.png)

### **Gạch Hình ảnh Thành Kết cấu**

Nếu bạn muốn đặt một hình ảnh dạng gạch làm kết cấu và tùy chỉnh hành vi gạch, bạn có thể sử dụng các thuộc tính sau của giao diện [IPictureFillFormat](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/) và lớp [PictureFillFormat](https://reference.aspose.com/slides/net/aspose.slides/picturefillformat/):

- [PictureFillMode](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/picturefillmode/): Đặt chế độ đổ hình ảnh—hoặc `Tile` hoặc `Stretch`.
- [TileAlignment](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/tilealignment/): Xác định cách căn chỉnh các ô gạch trong hình dạng.
- [TileFlip](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/tileflip/): Kiểm soát việc lật ô gạch theo chiều ngang, chiều dọc hoặc cả hai.
- [TileOffsetX](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/tileoffsetx/): Đặt khoảng dịch chuyển ngang của ô gạch (đơn vị điểm) so với gốc của hình dạng.
- [TileOffsetY](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/tileoffsety/): Đặt khoảng dịch chuyển dọc của ô gạch (đơn vị điểm) so với gốc của hình dạng.
- [TileScaleX](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/tilescalex/): Xác định tỷ lệ ngang của ô gạch dưới dạng phần trăm.
- [TileScaleY](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/tilescaley/): Xác định tỷ lệ dọc của ô gạch dưới dạng phần trăm.

Đoạn mã mẫu sau cho thấy cách thêm một hình chữ nhật với picture fill dạng gạch và cấu hình các tùy chọn gạch:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Khởi tạo lớp Presentation đại diện cho tệp trình chiếu.
using (Presentation presentation = new Presentation())
{
    // Lấy slide đầu tiên.
    ISlide firstSlide = presentation.Slides[0];

    // Thêm một auto shape hình chữ nhật.
    IAutoShape shape = firstSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 190, 95);

    // Đặt loại fill của hình dạng thành Picture.
    shape.FillFormat.FillType = FillType.Picture;

    // Tải ảnh và thêm vào tài nguyên của bản trình chiếu.
    IPPImage presentationImage;
    using (IImage sourceImage = Images.FromFile("lotus.png"))
        presentationImage = presentation.Images.AddImage(sourceImage);

    // Gán ảnh cho hình dạng.
    IPictureFillFormat pictureFillFormat = shape.FillFormat.PictureFillFormat;
    pictureFillFormat.Picture.Image = presentationImage;

    // Cấu hình chế độ picture fill và các thuộc tính gạch.
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

## **Đổ màu Đặc**

Trong PowerPoint, Solid Color Fill là một tùy chọn định dạng cho phép bạn tô màu một hình dạng bằng một màu duy nhất, đồng nhất. Màu nền đơn giản này được áp dụng mà không có gradient, texture hay pattern nào.

Để áp dụng solid color fill cho một hình dạng bằng Aspose.Slides, làm theo các bước sau:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
1. Lấy tham chiếu đến một slide bằng chỉ mục của nó.
1. Thêm một [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) vào slide.
1. Đặt [FillType](https://reference.aspose.com/slides/net/aspose.slides/filltype/) của hình dạng thành `Solid`.
1. Gán màu fill ưa thích của bạn cho hình dạng.
1. Lưu bản trình chiếu đã sửa đổi dưới dạng tệp PPTX.

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// Khởi tạo lớp Presentation đại diện cho tệp trình chiếu.
using (Presentation presentation = new Presentation())
{
    // Lấy slide đầu tiên.
    ISlide slide = presentation.Slides[0];

    // Thêm một auto shape loại Rectangle.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Đặt loại fill thành Solid.
    shape.FillFormat.FillType = FillType.Solid;

    // Đặt màu fill.
    shape.FillFormat.SolidFillColor.Color = Color.Yellow;

    // Lưu tệp PPTX vào đĩa.
    presentation.Save("solid_color_fill.pptx", SaveFormat.Pptx);
}
```

Kết quả:

![Hình dạng với đổ màu đặc](solid-color-fill.png)

## **Đặt Độ trong suốt**

Trong PowerPoint, khi bạn áp dụng solid color, gradient, picture hoặc texture fill cho các hình dạng, bạn cũng có thể đặt mức độ trong suốt để kiểm soát độ mờ của fill. Giá trị trong suốt cao hơn làm cho hình dạng trong suốt hơn, cho phép nền hoặc các đối tượng bên dưới hiển thị một phần.

Aspose.Slides cho phép bạn thiết lập mức độ trong suốt bằng cách điều chỉnh giá trị alpha trong màu được sử dụng cho fill. Dưới đây là cách thực hiện:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
1. Lấy tham chiếu đến một slide bằng chỉ mục của nó.
1. Thêm một [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) vào slide.
1. Đặt [FillType](https://reference.aspose.com/slides/net/aspose.slides/filltype/) thành `Solid`.
1. Sử dụng `Color.FromArgb(alpha, baseColor)` để định nghĩa màu có độ trong suốt (thành phần `alpha` kiểm soát độ trong suốt).
1. Lưu bản trình chiếu.

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

const int alpha = 128;

// Khởi tạo lớp Presentation đại diện cho tệp trình chiếu.
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

## **Xoay Hình dạng**

Aspose.Slides cho phép bạn xoay các hình dạng trong bản trình chiếu PowerPoint. Điều này hữu ích khi định vị các yếu tố trực quan với yêu cầu căn chỉnh hoặc thiết kế cụ thể.

Để xoay một hình dạng trên slide, thực hiện các bước sau:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
1. Lấy tham chiếu đến một slide bằng chỉ mục của nó.
1. Thêm một [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) vào slide.
1. Đặt thuộc tính `Rotation` của hình dạng thành góc mong muốn.
1. Lưu bản trình chiếu.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Khởi tạo lớp Presentation đại diện cho tệp trình chiếu.
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

## **Thêm hiệu ứng Bo góc 3D**

Aspose.Slides cho phép bạn áp dụng hiệu ứng Bo góc 3D cho các hình dạng bằng cách cấu hình các thuộc tính [ThreeDFormat](https://reference.aspose.com/slides/net/aspose.slides/threedformat/) của chúng.

Để thêm hiệu ứng Bo góc 3D cho một hình dạng, thực hiện các bước sau:

1. Khởi tạo lớp [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
1. Lấy tham chiếu đến một slide bằng chỉ mục của nó.
1. Thêm một [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) vào slide.
1. Cấu hình [ThreeDFormat](https://reference.aspose.com/slides/net/aspose.slides/threedformat/) của hình dạng để xác định cài đặt Bo góc.
1. Lưu bản trình chiếu.

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

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

![Hiệu ứng Bo góc 3D](3D-bevel-effect.png)

## **Thêm hiệu ứng Xoay 3D**

Aspose.Slides cho phép bạn áp dụng hiệu ứng Xoay 3D cho các hình dạng bằng cách cấu hình các thuộc tính [ThreeDFormat](https://reference.aspose.com/slides/net/aspose.slides/threedformat/) của chúng.

Để áp dụng Xoay 3D cho một hình dạng:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
1. Lấy tham chiếu đến một slide bằng chỉ mục của nó.
1. Thêm một [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) vào slide.
1. Đặt [CameraType](https://reference.aspose.com/slides/net/aspose.slides/icamera/cameratype/) và [LightType](https://reference.aspose.com/slides/net/aspose.slides/ilightrig/lighttype/) của hình dạng để xác định Xoay 3D.
1. Lưu bản trình chiếu.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Tạo một thể hiện của lớp Presentation.
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);
    autoShape.TextFrame.Text = "Hello, Aspose!";

    autoShape.ThreeDFormat.Camera.SetRotation(40, 35, 20);
    autoShape.ThreeDFormat.Camera.CameraType = CameraPresetType.IsometricLeftUp;
    autoShape.ThreeDFormat.LightRig.LightType = LightRigPresetType.Balanced;

    // Lưu bản trình chiếu dưới dạng tệp PPTX.
    presentation.Save("3D_rotation_effect.pptx", SaveFormat.Pptx);
}
```

Kết quả:

![Hiệu ứng Xoay 3D](3D-rotation-effect.png)

## **Điều khiển Kết xuất Đen-Trắng cho Hình dạng**

Thuộc tính [IShape.BlackWhiteMode](https://reference.aspose.com/slides/net/aspose.slides/ishape/blackwhitemode/) xác định cách một hình dạng riêng lẻ được kết xuất khi bản trình chiếu được xem hoặc xử lý ở chế độ đen-trắng. Thuộc tính này không tự kích hoạt chế độ hiển thị đen-trắng và không thay đổi fill, line hoặc các định dạng khác trong chế độ màu bình thường.

Sử dụng một giá trị từ enumeration [BlackWhiteMode](https://reference.aspose.com/slides/net/aspose.slides/blackwhitemode/) để chọn hành vi mong muốn. Ví dụ, `Automatic` để ứng dụng quyết định chuyển đổi, `Gray` và `LightGray` sử dụng màu xám, `BlackWhite` chỉ dùng đen và trắng, `Black` và `White` buộc một màu duy nhất, `Color` giữ nguyên màu bình thường, và `Hidden` loại bỏ hình dạng trong chế độ đen-trắng. `NotDefined` có nghĩa là không có chế độ ở mức hình dạng được gán.

Đoạn mã C# sau tạo một hình dạng màu và khiến nó hiển thị màu xám trong chế độ hiển thị đen-trắng:

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);
shape.FillFormat.FillType = FillType.Solid;
shape.FillFormat.SolidFillColor.Color = Color.Orange;

// Giữ màu đổ cam ở chế độ màu, nhưng kết xuất hình dạng với màu xám ở chế độ đen-trắng.
shape.BlackWhiteMode = BlackWhiteMode.Gray;

presentation.Save("shape_black_white_mode.pptx", SaveFormat.Pptx);
```

Trong chế độ màu bình thường, hình chữ nhật giữ màu nền cam. Trong quy trình hiển thị đen-trắng, nó sử dụng màu xám vì chế độ đã được đặt thành `Gray`. Điều này cho phép bạn giữ slide màu đầy đủ trong khi định nghĩa một dạng hiển thị riêng cho việc in, xem trước hoặc các quy trình khác tôn trọng cài đặt hiển thị đen-trắng của bản trình chiếu.

## **Đặt lại Định dạng**

Đoạn mã C# sau cho thấy cách đặt lại định dạng của một slide và khôi phục vị trí, kích thước và định dạng của tất cả các hình dạng có placeholder trên [LayoutSlide](https://reference.aspose.com/slides/net/aspose.slides/layoutslide/) về thiết lập mặc định:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    foreach (ISlide slide in presentation.Slides)
    {
        // Đặt lại mỗi hình dạng trên slide có placeholder trên layout.
        slide.Reset();
    }

    presentation.Save("reset_formatting.pptx", SaveFormat.Pptx);
}
```

## **Câu hỏi thường gặp**

**Does shape formatting affect the final presentation file size?**

Chỉ ảnh hưởng tối thiểu. Các hình ảnh và phương tiện nhúng chiếm phần lớn dung lượng tệp, trong khi các tham số hình dạng như màu, hiệu ứng và gradient được lưu dưới dạng siêu dữ liệu và hầu như không làm tăng kích thước.

**How can I detect shapes on a slide that share identical formatting so I can group them?**

So sánh các thuộc tính định dạng chính của mỗi hình dạng—các thiết lập fill, line và effect. Nếu tất cả các giá trị tương ứng khớp nhau, coi chúng là có cùng kiểu và nhóm logic các hình dạng đó, giúp việc quản lý kiểu sau này trở nên đơn giản hơn.

**Can I save a set of custom shape styles to a separate file for reuse in other presentations?**

Có. Lưu các hình mẫu với kiểu mong muốn trong một slide mẫu hoặc tệp mẫu .POTX. Khi tạo bản trình chiếu mới, mở mẫu, sao chép các hình dạng đã được định dạng và áp dụng lại định dạng của chúng ở bất kỳ nơi nào cần thiết.