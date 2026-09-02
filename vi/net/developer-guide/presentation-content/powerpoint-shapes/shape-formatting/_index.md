---
title: Định dạng các hình dạng PowerPoint trong .NET
linktitle: Định dạng hình dạng
type: docs
weight: 20
url: /vi/net/shape-formatting/
keywords:
- định dạng hình dạng
- định dạng đường viền
- hiệu ứng vẽ tay
- đường viền hình dạng vẽ tay
- định dạng kiểu nối
- đổ màu gradient
- đổ màu mẫu
- đổ màu hình ảnh
- đổ màu texture
- đổ màu đồng nhất
- độ trong suốt hình dạng
- xoay hình dạng
- hiệu ứng bevel 3D
- hiệu ứng xoay 3D
- đặt lại định dạng
- PowerPoint
- bài thuyết trình
- .NET
- C#
- Aspose.Slides
description: "Tìm hiểu cách định dạng các hình dạng PowerPoint trong C# bằng Aspose.Slides—đặt các kiểu đổ, đường viền và hiệu ứng cho tệp PPT và PPTX một cách chính xác và kiểm soát đầy đủ."
---
## **Giới thiệu**

Trong PowerPoint, bạn có thể thêm các hình dạng vào các slide. Vì các hình dạng được tạo thành từ các đường thẳng, bạn có thể định dạng chúng bằng cách sửa đổi hoặc áp dụng hiệu ứng cho viền của chúng. Ngoài ra, bạn có thể định dạng các hình dạng bằng cách chỉ định các thiết lập kiểm soát cách phần bên trong được tô màu.

![định dạng hình dạng PowerPoint](format-shape-powerpoint.png)

Aspose.Slides for .NET cung cấp các giao diện và thuộc tính cho phép bạn định dạng các hình dạng bằng các tùy chọn có sẵn trong PowerPoint.

## **Định dạng đường viền**

Sử dụng Aspose.Slides, bạn có thể chỉ định kiểu đường viền tùy chỉnh cho một hình dạng. Các bước sau mô tả quy trình:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/) .
1. Lấy tham chiếu đến một slide theo chỉ mục của nó.
1. Thêm một [IAutoShape](https://reference.aspose.com/slides/vi/net/aspose.slides/iautoshape/) vào slide.
1. Đặt [line style](https://reference.aspose.com/slides/vi/net/aspose.slides/linestyle/) cho hình dạng.
1. Đặt độ rộng của đường viền.
1. Đặt [dash style](https://reference.aspose.com/slides/vi/net/aspose.slides/linedashstyle/) cho đường viền.
1. Đặt màu của đường viền cho hình dạng.
1. Lưu bài thuyết trình đã sửa đổi dưới dạng tệp PPTX.

Mã C# sau minh họa cách định dạng một `AutoShape` hình chữ nhật:

```c#
// Khởi tạo lớp Presentation đại diện cho một tệp bài thuyết trình.
using (Presentation presentation = new Presentation())
{
    // Lấy slide đầu tiên.
    ISlide slide = presentation.Slides[0];

    // Thêm một auto shape loại Rectangle.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Đặt màu nền cho hình dạng rectangle.
    shape.FillFormat.FillType = FillType.NoFill;

    // Áp dụng định dạng cho các đường viền của rectangle.
    shape.LineFormat.Style = LineStyle.ThickThin;
    shape.LineFormat.Width = 7;
    shape.LineFormat.DashStyle = LineDashStyle.Dash;

    // Đặt màu cho đường viền của rectangle.
    shape.LineFormat.FillFormat.FillType = FillType.Solid;
    shape.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;

    // Lưu tệp PPTX vào đĩa.
    presentation.Save("formatted_lines.pptx", SaveFormat.Pptx);
}
```

Kết quả:

![Các đường viền đã được định dạng trong bài thuyết trình](formatted-lines.png)

## **Áp dụng hiệu ứng Sketch cho đường viền hình dạng**

Hiệu ứng sketch làm cho đường viền của hình dạng trông giống như được vẽ tay. Sử dụng [IShape.LineFormat](https://reference.aspose.com/slides/vi/net/aspose.slides/ishape/lineformat/) để truy cập các thiết lập đường viền, [ILineFormat.SketchFormat](https://reference.aspose.com/slides/vi/net/aspose.slides/ilineformat/sketchformat/) để truy cập các thiết lập sketch, và [ISketchFormat.SketchType](https://reference.aspose.com/slides/vi/net/aspose.slides/isketchformat/sketchtype/) để chọn một giá trị từ enum [LineSketchType](https://reference.aspose.com/slides/vi/net/aspose.slides/linesketchtype/) .

Mã C# dưới đây cho thấy cách áp dụng hiệu ứng [LineSketchType.Curved](https://reference.aspose.com/slides/vi/net/aspose.slides/linesketchtype/) , đọc giá trị đã gán một cách rõ ràng, và xóa hiệu ứng bằng [LineSketchType.None](https://reference.aspose.com/slides/vi/net/aspose.slides/linesketchtype/) :

```csharp
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

Giá trị trả về bởi `ISketchFormat.SketchType` đại diện cho thiết lập được gán trực tiếp cho hình dạng. Nếu việc định dạng đường viền có thể được kế thừa từ một chủ đề, slide chủ, hoặc slide bố cục, hãy sử dụng [ILineFormat.GetEffective](https://reference.aspose.com/slides/vi/net/aspose.slides/ilineformat/geteffective/) , truy cập [ILineFormatEffectiveData.SketchFormat](https://reference.aspose.com/slides/vi/net/aspose.slides/ilineformateffectivedata/sketchformat/) , và đọc [ISketchFormatEffectiveData.SketchType](https://reference.aspose.com/slides/vi/net/aspose.slides/isketchformateffectivedata/sketchtype/) . Giá trị hiệu lực phản ánh định dạng thực tế được áp dụng sau khi kế thừa được giải quyết:

```csharp
using var presentation = new Presentation("presentation.pptx");

var shape = presentation.Slides[0].Shapes[0];
var lineFormat = shape.LineFormat;

var explicitSketchType = lineFormat.SketchFormat.SketchType;
var effectiveLineFormat = lineFormat.GetEffective();
var effectiveSketchType = effectiveLineFormat.SketchFormat.SketchType;

Console.WriteLine($"Explicit sketch type: {explicitSketchType}");
Console.WriteLine($"Effective sketch type: {effectiveSketchType}");
```

## **Định dạng kiểu nối (Join Styles)**

Dưới đây là ba tùy chọn kiểu nối:

* Round
* Miter
* Bevel

Mặc định, khi PowerPoint nối hai đường ở một góc (chẳng hạn tại góc của hình dạng), nó sử dụng thiết lập **Round**. Tuy nhiên, nếu bạn đang vẽ một hình dạng với các góc nhọn, có thể bạn sẽ thích tùy chọn **Miter** hơn.

![Kiểu nối trong bài thuyết trình](join-style-powerpoint.png)

Mã C# sau minh họa cách ba hình chữ nhật (như trong ảnh trên) được tạo ra bằng các thiết lập kiểu nối Miter, Bevel và Round:

```c#
 // Khởi tạo lớp Presentation đại diện cho một tệp bài thuyết trình.
using (Presentation presentation = new Presentation())
{
    // Lấy slide đầu tiên.
    ISlide slide = presentation.Slides[0];

    // Thêm ba auto shape loại Rectangle.
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

    // Đặt độ rộng đường viền.
    shape1.LineFormat.Width = 15;
    shape2.LineFormat.Width = 15;
    shape3.LineFormat.Width = 15;

    // Đặt màu cho đường viền của mỗi hình chữ nhật.
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

Trong PowerPoint, Đổ màu Gradient là một tùy chọn định dạng cho phép bạn áp dụng một dải màu liên tục cho một hình dạng. Ví dụ, bạn có thể áp dụng hai hoặc nhiều màu sao cho một màu dần dần chuyển sang màu khác.

Cách áp dụng đổ màu Gradient cho một hình dạng bằng Aspose.Slides:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/) .
1. Lấy tham chiếu đến một slide theo chỉ mục của nó.
1. Thêm một [IAutoShape](https://reference.aspose.com/slides/vi/net/aspose.slides/iautoshape/) vào slide.
1. Đặt [FillType](https://reference.aspose.com/slides/vi/net/aspose.slides/filltype/) của hình dạng thành `Gradient` .
1. Thêm hai màu bạn muốn với các vị trí đã xác định bằng các phương thức `Add` của bộ sưu tập gradient stop được mở ra bởi giao diện [IGradientFormat](https://reference.aspose.com/slides/vi/net/aspose.slides/igradientformat/) .
1. Lưu bài thuyết trình đã sửa đổi dưới dạng tệp PPTX.

Mã C# dưới đây minh họa cách áp dụng hiệu ứng đổ màu Gradient cho một hình elip:

```c#
// Khởi tạo lớp Presentation đại diện cho một tệp bài thuyết trình.
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

![Elip với đổ màu Gradient](gradient-fill.png)

## **Đổ màu Pattern**

Trong PowerPoint, Đổ màu Pattern là một tùy chọn định dạng cho phép bạn áp dụng một thiết kế hai màu — chẳng hạn chấm, sọc, vạch chéo hoặc ô vuông — lên một hình dạng. Bạn có thể chọn màu tùy chỉnh cho màu nền và màu tiền cảnh của mẫu.

Aspose.Slides cung cấp hơn 45 kiểu mẫu được định nghĩa trước mà bạn có thể áp dụng cho các hình dạng để tăng tính thẩm mỹ cho bài thuyết trình. Ngay cả sau khi chọn một mẫu đã định nghĩa trước, bạn vẫn có thể chỉ định màu chính xác mà mẫu sẽ sử dụng.

Cách áp dụng đổ màu Pattern cho một hình dạng bằng Aspose.Slides:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/) .
1. Lấy tham chiếu đến một slide theo chỉ mục của nó.
1. Thêm một [IAutoShape](https://reference.aspose.com/slides/vi/net/aspose.slides/iautoshape/) vào slide.
1. Đặt [FillType](https://reference.aspose.com/slides/vi/net/aspose.slides/filltype/) của hình dạng thành `Pattern` .
1. Chọn một kiểu mẫu từ các tùy chọn đã định nghĩa trước.
1. Đặt [Background Color](https://reference.aspose.com/slides/vi/net/aspose.slides/ipatternformat/backcolor/) cho mẫu.
1. Đặt [Foreground Color](https://reference.aspose.com/slides/vi/net/aspose.slides/ipatternformat/forecolor/) cho mẫu.
1. Lưu bài thuyết trình đã sửa đổi dưới dạng tệp PPTX.

Mã C# dưới đây minh họa cách áp dụng đổ màu Pattern cho một hình chữ nhật:

```c#
// Khởi tạo lớp Presentation đại diện cho một tệp bài thuyết trình.
using (Presentation presentation = new Presentation())
{
    // Lấy slide đầu tiên.
    ISlide slide = presentation.Slides[0];

    // Thêm một auto shape loại Rectangle.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Đặt loại fill là Pattern.
    shape.FillFormat.FillType = FillType.Pattern;

    // Đặt kiểu mẫu.
    shape.FillFormat.PatternFormat.PatternStyle = PatternStyle.Trellis;

    // Đặt màu nền và màu tiền cảnh của mẫu.
    shape.FillFormat.PatternFormat.BackColor.Color = Color.LightGray;
    shape.FillFormat.PatternFormat.ForeColor.Color = Color.Yellow;

    // Lưu tệp PPTX vào đĩa.
    presentation.Save("pattern_fill.pptx", SaveFormat.Pptx);
}
```

Kết quả:

![Hình chữ nhật với đổ màu Pattern](pattern-fill.png)

## **Đổ màu Picture**

Trong PowerPoint, Đổ màu Picture là một tùy chọn định dạng cho phép bạn chèn một hình ảnh vào bên trong một hình dạng — thực chất sử dụng hình ảnh làm nền cho hình dạng.

Cách sử dụng Aspose.Slides để áp dụng đổ màu Picture cho một hình dạng:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/) .
1. Lấy tham chiếu đến một slide theo chỉ mục của nó.
1. Thêm một [IAutoShape](https://reference.aspose.com/slides/vi/net/aspose.slides/iautoshape/) vào slide.
1. Đặt [FillType](https://reference.aspose.com/slides/vi/net/aspose.slides/filltype/) của hình dạng thành `Picture` .
1. Đặt chế độ đổ màu picture thành `Tile` (hoặc chế độ khác bạn muốn).
1. Tạo một đối tượng [IPPImage](https://reference.aspose.com/slides/vi/net/aspose.slides/ippimage/) từ hình ảnh bạn muốn sử dụng.
1. Gán hình ảnh này cho thuộc tính `Picture.Image` của `PictureFillFormat` của hình dạng.
1. Lưu bài thuyết trình đã sửa đổi dưới dạng tệp PPTX.

Giả sử chúng ta có tệp "lotus.png" với hình ảnh sau:

![Hình lotus](lotus.png)

Mã C# dưới đây minh họa cách đổ hình ảnh vào một hình dạng:

```c#
// Khởi tạo lớp Presentation đại diện cho một tệp bài thuyết trình.
using (Presentation presentation = new Presentation())
{
    // Lấy slide đầu tiên.
    ISlide slide = presentation.Slides[0];

    // Thêm một auto shape loại Rectangle.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 255, 130);

    // Đặt loại fill là Picture.
    shape.FillFormat.FillType = FillType.Picture;

    // Đặt chế độ đổ picture.
    shape.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Tile;

    // Tải ảnh và thêm nó vào tài nguyên của bài thuyết trình.
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

![Hình dạng với đổ picture](picture-fill.png)

### **Tile Picture As Texture**

Nếu bạn muốn đặt một hình ảnh lặp lại làm texture và tùy chỉnh hành vi lặp, bạn có thể sử dụng các thuộc tính sau của giao diện [IPictureFillFormat](https://reference.aspose.com/slides/vi/net/aspose.slides/ipicturefillformat/) và lớp [PictureFillFormat](https://reference.aspose.com/slides/vi/net/aspose.slides/picturefillformat/) :

- [PictureFillMode](https://reference.aspose.com/slides/vi/net/aspose.slides/ipicturefillformat/picturefillmode/) : Đặt chế độ đổ picture — `Tile` hoặc `Stretch` .
- [TileAlignment](https://reference.aspose.com/slides/vi/net/aspose.slides/ipicturefillformat/tilealignment/) : Xác định cách căn chỉnh các ô ảnh bên trong hình dạng.
- [TileFlip](https://reference.aspose.com/slides/vi/net/aspose.slides/ipicturefillformat/tileflip/) : Kiểm soát việc lật ảnh theo chiều ngang, chiều dọc hoặc cả hai.
- [TileOffsetX](https://reference.aspose.com/slides/vi/net/aspose.slides/ipicturefillformat/tileoffsetx/) : Đặt độ dịch chuyển theo chiều ngang của ô ảnh (đơn vị point) kể từ gốc của hình dạng.
- [TileOffsetY](https://reference.aspose.com/slides/vi/net/aspose.slides/ipicturefillformat/tileoffsety/) : Đặt độ dịch chuyển theo chiều dọc của ô ảnh (đơn vị point) kể từ gốc của hình dạng.
- [TileScaleX](https://reference.aspose.com/slides/vi/net/aspose.slides/ipicturefillformat/tilescalex/) : Xác định tỷ lệ ngang của ô ảnh dưới dạng phần trăm.
- [TileScaleY](https://reference.aspose.com/slides/vi/net/aspose.slides/ipicturefillformat/tilescaley/) : Xác định tỷ lệ dọc của ô ảnh dưới dạng phần trăm.

Mã mẫu dưới đây cho thấy cách thêm một hình chữ nhật với đổ picture dạng lặp và cấu hình các tùy chọn lặp:

```c#
// Khởi tạo lớp Presentation đại diện cho một tệp bài thuyết trình.
using (Presentation presentation = new Presentation())
{
    // Lấy slide đầu tiên.
    ISlide firstSlide = presentation.Slides[0];

    // Thêm một auto shape hình chữ nhật.
    IAutoShape shape = firstSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 190, 95);

    // Đặt loại fill của hình dạng thành Picture.
    shape.FillFormat.FillType = FillType.Picture;

    // Tải ảnh và thêm nó vào tài nguyên của bài thuyết trình.
    IPPImage presentationImage;
    using (IImage sourceImage = Images.FromFile("lotus.png"))
        presentationImage = presentation.Images.AddImage(sourceImage);

    // Gán ảnh cho hình dạng.
    IPictureFillFormat pictureFillFormat = shape.FillFormat.PictureFillFormat;
    pictureFillFormat.Picture.Image = presentationImage;

    // Cấu hình chế độ đổ picture và các thuộc tính lặp.
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

![Các tùy chọn lặp ảnh](tile-options.png)

## **Đổ màu Solid Color**

Trong PowerPoint, Đổ màu Solid Color là một tùy chọn định dạng làm đầy một hình dạng bằng một màu đồng nhất duy nhất. Màu nền đơn giản này được áp dụng mà không có gradient, texture hay pattern nào.

Để áp dụng đổ màu Solid Color cho một hình dạng bằng Aspose.Slides, thực hiện các bước sau:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/) .
1. Lấy tham chiếu đến một slide theo chỉ mục của nó.
1. Thêm một [IAutoShape](https://reference.aspose.com/slides/vi/net/aspose.slides/iautoshape/) vào slide.
1. Đặt [FillType](https://reference.aspose.com/slides/vi/net/aspose.slides/filltype/) của hình dạng thành `Solid` .
1. Gán màu đổ mà bạn muốn cho hình dạng.
1. Lưu bài thuyết trình đã sửa đổi dưới dạng tệp PPTX.

Mã C# dưới đây minh họa cách áp dụng đổ màu Solid Color cho một hình chữ nhật trong slide PowerPoint:

```c#
// Khởi tạo lớp Presentation đại diện cho một tệp bài thuyết trình.
using (Presentation presentation = new Presentation())
{
    // Lấy slide đầu tiên.
    ISlide slide = presentation.Slides[0];

    // Thêm một auto shape loại Rectangle.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Đặt loại fill là Solid.
    shape.FillFormat.FillType = FillType.Solid;

    // Đặt màu nền.
    shape.FillFormat.SolidFillColor.Color = Color.Yellow;

    // Lưu tệp PPTX vào đĩa.
    presentation.Save("solid_color_fill.pptx", SaveFormat.Pptx);
}
```

Kết quả:

![Hình dạng với đổ màu Solid Color](solid-color-fill.png)

## **Đặt độ trong suốt (Transparency)**

Trong PowerPoint, khi bạn áp dụng đổ màu solid, gradient, picture hoặc texture cho các hình dạng, bạn cũng có thể đặt mức độ trong suốt để kiểm soát độ mờ của lớp đổ. Giá trị trong suốt cao hơn làm cho hình dạng càng trong suốt, cho phép nền hoặc các đối tượng phía sau hiển thị một phần.

Aspose.Slides cho phép bạn đặt mức độ trong suốt bằng cách điều chỉnh giá trị alpha trong màu được dùng để đổ. Cách thực hiện:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/) .
1. Lấy tham chiếu đến một slide theo chỉ mục của nó.
1. Thêm một [IAutoShape](https://reference.aspose.com/slides/vi/net/aspose.slides/iautoshape/) vào slide.
1. Đặt [FillType](https://reference.aspose.com/slides/vi/net/aspose.slides/filltype/) thành `Solid` .
1. Sử dụng `Color.FromArgb(alpha, baseColor)` để định nghĩa một màu có độ trong suốt (thành phần `alpha` kiểm soát độ trong suốt).
1. Lưu bài thuyết trình.

Mã C# dưới đây minh họa cách áp dụng màu đổ trong suốt cho một hình chữ nhật:

```c#
const int alpha = 128;

// Khởi tạo lớp Presentation đại diện cho một tệp bài thuyết trình.
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

Aspose.Slides cho phép bạn xoay các hình dạng trong bài thuyết trình PowerPoint. Điều này hữu ích khi cần định vị các yếu tố hình ảnh theo yêu cầu căn chỉnh hoặc thiết kế cụ thể.

Để xoay một hình dạng trên slide, thực hiện các bước sau:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/) .
1. Lấy tham chiếu đến một slide theo chỉ mục của nó.
1. Thêm một [IAutoShape](https://reference.aspose.com/slides/vi/net/aspose.slides/iautoshape/) vào slide.
1. Đặt thuộc tính `Rotation` của hình dạng thành góc mong muốn.
1. Lưu bài thuyết trình.

Mã C# dưới đây minh họa cách xoay một hình dạng 5 độ:

```c#
// Khởi tạo lớp Presentation đại diện cho một tệp bài thuyết trình.
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

## **Thêm hiệu ứng Bevel 3D**

Aspose.Slides cho phép bạn áp dụng hiệu ứng bevel 3D cho các hình dạng bằng cách cấu hình các thuộc tính [ThreeDFormat](https://reference.aspose.com/slides/vi/net/aspose.slides/threedformat/) .

Để thêm hiệu ứng bevel 3D cho một hình dạng, thực hiện các bước sau:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/) .
1. Lấy tham chiếu đến một slide theo chỉ mục của nó.
1. Thêm một [IAutoShape](https://reference.aspose.com/slides/vi/net/aspose.slides/iautoshape/) vào slide.
1. Cấu hình [ThreeDFormat](https://reference.aspose.com/slides/vi/net/aspose.slides/threedformat/) của hình dạng để định nghĩa các thiết lập bevel.
1. Lưu bài thuyết trình.

Mã C# dưới đây cho thấy cách áp dụng hiệu ứng bevel 3D cho một hình dạng:

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

    // Lưu bài thuyết trình dưới dạng tệp PPTX.
    presentation.Save("3D_bevel_effect.pptx", SaveFormat.Pptx);
}
```

Kết quả:

![Hiệu ứng bevel 3D](3D-bevel-effect.png)

## **Thêm hiệu ứng Xoay 3D**

Aspose.Slides cho phép bạn áp dụng hiệu ứng xoay 3D cho các hình dạng bằng cách cấu hình các thuộc tính [ThreeDFormat](https://reference.aspose.com/slides/vi/net/aspose.slides/threedformat/) .

Để áp dụng xoay 3D cho một hình dạng:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/) .
1. Lấy tham chiếu đến một slide theo chỉ mục của nó.
1. Thêm một [IAutoShape](https://reference.aspose.com/slides/vi/net/aspose.slides/iautoshape/) vào slide.
1. Đặt [CameraType](https://reference.aspose.com/slides/vi/net/aspose.slides/icamera/cameratype/) và [LightType](https://reference.aspose.com/slides/vi/net/aspose.slides/ilightrig/lighttype/) của hình dạng để xác định xoay 3D.
1. Lưu bài thuyết trình.

Mã C# dưới đây minh họa cách áp dụng hiệu ứng xoay 3D cho một hình dạng:

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

    // Lưu bài thuyết trình dưới dạng tệp PPTX.
    presentation.Save("3D_rotation_effect.pptx", SaveFormat.Pptx);
}
```

Kết quả:

![Hiệu ứng xoay 3D](3D-rotation-effect.png)

## **Đặt lại định dạng**

Mã C# dưới đây cho thấy cách đặt lại định dạng của một slide và khôi phục vị trí, kích thước và định dạng của tất cả các hình dạng có trình giữ chỗ trên [LayoutSlide](https://reference.aspose.com/slides/vi/net/aspose.slides/layoutslide/) về cài đặt mặc định:

```c#
using (Presentation presentation = new Presentation("sample.pptx"))
{
    foreach (ISlide slide in presentation.Slides)
    {
        // Đặt lại mỗi hình dạng trên slide có trình giữ chỗ trong bố cục.
        slide.Reset();
    }

    presentation.Save("reset_formatting.pptx", SaveFormat.Pptx);
}
```

## **FAQ**

**Định dạng hình dạng có ảnh hưởng đến kích thước cuối cùng của tệp bài thuyết trình không?**

Chỉ ảnh hưởng rất ít. Các hình ảnh và phương tiện nhúng chiếm phần lớn không gian tệp, trong khi các tham số hình dạng như màu sắc, hiệu ứng và gradient được lưu dưới dạng siêu dữ liệu và hầu như không làm tăng kích thước.

**Làm thế nào để phát hiện các hình dạng trên một slide có cùng định dạng để tôi có thể nhóm chúng?**

So sánh các thuộc tính định dạng chính của mỗi hình dạng — cài đặt fill, line và effect. Nếu tất cả các giá trị tương ứng khớp nhau, coi chúng là cùng một kiểu và nhóm logic các hình dạng đó, giúp việc quản lý kiểu sau này trở nên dễ dàng hơn.

**Tôi có thể lưu một tập hợp các kiểu hình dạng tùy chỉnh vào một tệp riêng để tái sử dụng trong các bài thuyết trình khác không?**

Có. Lưu các hình mẫu có kiểu mong muốn trong một slide mẫu hoặc tệp mẫu .POTX. Khi tạo một bài thuyết trình mới, mở mẫu, sao chép các hình dạng đã định dạng cần thiết và áp dụng lại định dạng của chúng ở bất kỳ vị trí nào cần thiết.