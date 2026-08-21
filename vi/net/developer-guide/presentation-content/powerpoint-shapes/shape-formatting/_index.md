---
title: Định dạng các hình dạng PowerPoint trong .NET
linktitle: Định dạng Hình dạng
type: docs
weight: 20
url: /vi/net/shape-formatting/
keywords:
- định dạng hình
- định dạng đường
- hiệu ứng phác thảo
- đường hình phác thảo
- định dạng kiểu nối
- đổ màu gradient
- đổ hoạ tiết
- đổ hình ảnh
- đổ kết cấu
- đổ màu đơn
- độ trong suốt hình dạng
- hiển thị hình dạng đen-trắng
- hiển thị hình dạng xám
- xoay hình dạng
- hiệu ứng cham 3D
- hiệu ứng xoay 3D
- đặt lại định dạng
- PowerPoint
- bản trình chiếu
- .NET
- C#
- Aspose.Slides
description: "Tìm hiểu cách định dạng các hình dạng PowerPoint trong C# bằng Aspose.Slides—đặt kiểu tô, đường viền và hiệu ứng cho các tệp PPT và PPTX một cách chính xác và kiểm soát toàn diện."
---
## **Giới thiệu**

Trong PowerPoint, bạn có thể thêm các hình dạng vào các slide. Vì các hình dạng được tạo nên từ các đường nét, bạn có thể định dạng chúng bằng cách chỉnh sửa hoặc áp dụng hiệu ứng cho đường viền. Ngoài ra, bạn có thể định dạng các hình dạng bằng cách chỉ định các cài đặt kiểm soát cách tô nền bên trong của chúng.

![Định dạng hình trong PowerPoint](format-shape-powerpoint.png)

Aspose.Slides for .NET cung cấp các giao diện và thuộc tính cho phép bạn định dạng hình dạng bằng các tùy chọn giống như trong PowerPoint.

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

Mã C# sau đây minh họa cách định dạng một `AutoShape` hình chữ nhật:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// Khởi tạo lớp Presentation đại diện cho tệp bản trình chiếu.
using (Presentation presentation = new Presentation())
{
    // Lấy slide đầu tiên.
    ISlide slide = presentation.Slides[0];

    // Thêm một auto shape loại Rectangle.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Đặt màu tô cho hình dạng rectangle.
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

## **Áp dụng Hiệu ứng Vẽ Phác thảo cho Đường của Hình**

Hiệu ứng phác thảo làm cho đường của hình trông như được vẽ tay. Sử dụng [IShape.LineFormat](https://reference.aspose.com/slides/vi/net/aspose.slides/ishape/lineformat/) để truy cập cài đặt đường, [ILineFormat.SketchFormat](https://reference.aspose.com/slides/vi/net/aspose.slides/ilineformat/sketchformat/) để truy cập cài đặt phác thảo, và [ISketchFormat.SketchType](https://reference.aspose.com/slides/vi/net/aspose.slides/isketchformat/sketchtype/) để chọn một giá trị từ liệt kê [LineSketchType](https://reference.aspose.com/slides/vi/net/aspose.slides/linesketchtype/) .

Mã C# sau đây cho thấy cách áp dụng hiệu ứng [LineSketchType.Curved](https://reference.aspose.com/slides/vi/net/aspose.slides/linesketchtype/) , đọc giá trị được gán rõ ràng, và loại bỏ hiệu ứng bằng [LineSketchType.None](https://reference.aspose.com/slides/vi/net/aspose.slides/linesketchtype/) :

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

Giá trị trả về bởi `ISketchFormat.SketchType` đại diện cho cài đặt được gán trực tiếp cho hình dạng. Nếu việc định dạng đường có thể được kế thừa từ một chủ đề, slide chủ, hoặc slide bố cục, hãy sử dụng [ILineFormat.GetEffective](https://reference.aspose.com/slides/vi/net/aspose.slides/ilineformat/geteffective/) , truy cập [ILineFormatEffectiveData.SketchFormat](https://reference.aspose.com/slides/vi/net/aspose.slides/ilineformateffectivedata/sketchformat/) , và đọc [ISketchFormatEffectiveData.SketchType](https://reference.aspose.com/slides/vi/net/aspose.slides/isketchformateffectivedata/sketchtype/) . Giá trị hiệu quả phản ánh định dạng thực tế được áp dụng sau khi kế thừa được giải quyết:

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

* Tròn
* Miter
* Bevel

Theo mặc định, khi PowerPoint nối hai đường ở một góc (ví dụ như ở góc của hình), nó sử dụng cài đặt **Round**. Tuy nhiên, nếu bạn đang vẽ một hình có các góc nhọn, bạn có thể ưu tiên tùy chọn **Miter**.

![Kiểu nối trong bản trình chiếu](join-style-powerpoint.png)

Mã C# sau đây minh họa cách ba hình chữ nhật (như trong hình trên) được tạo bằng cách sử dụng các cài đặt kiểu nối Miter, Bevel và Round:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// Khởi tạo lớp Presentation đại diện cho tệp bản trình chiếu.
using (Presentation presentation = new Presentation())
{
    // Lấy slide đầu tiên.
    ISlide slide = presentation.Slides[0];

    // Thêm ba auto shape loại Rectangle.
    IAutoShape shape1 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 150, 75);
    IAutoShape shape2 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 210, 20, 150, 75);
    IAutoShape shape3 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 135, 150, 75);

    // Đặt màu tô cho mỗi hình chữ nhật.
    shape1.FillFormat.FillType = FillType.Solid;
    shape1.FillFormat.SolidFillColor.Color = Color.Black;
    shape2.FillFormat.FillType = FillType.Solid;
    shape2.FillFormat.SolidFillColor.Color = Color.Black;
    shape3.FillFormat.FillType = FillType.Solid;
    shape3.FillFormat.SolidFillColor.Color = Color.Black;

    // Đặt độ rộng của đường.
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

Trong PowerPoint, Đổ màu Gradient là một tùy chọn định dạng cho phép bạn áp dụng sự pha trộn liên tục của các màu vào một hình dạng. Ví dụ, bạn có thể áp dụng hai hoặc nhiều màu sao cho một màu dần dần chuyển sang màu khác.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/) .
1. Lấy tham chiếu tới một slide theo chỉ mục của nó.
1. Thêm một [IAutoShape](https://reference.aspose.com/slides/vi/net/aspose.slides/iautoshape/) vào slide.
1. Đặt [FillType](https://reference.aspose.com/slides/vi/net/aspose.slides/filltype/) của hình dạng thành `Gradient` .
1. Thêm hai màu bạn muốn với vị trí đã định nghĩa bằng các phương thức `Add` của bộ sưu tập gradient stop được cung cấp bởi giao diện [IGradientFormat](https://reference.aspose.com/slides/vi/net/aspose.slides/igradientformat/) .
1. Lưu bản trình chiếu đã chỉnh sửa dưới dạng tệp PPTX.

Mã C# sau đây minh họa cách áp dụng hiệu ứng đổ màu gradient cho một hình ellipse:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Khởi tạo lớp Presentation đại diện cho tệp bản trình chiếu.
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

![Hình ellipse với đổ màu gradient](gradient-fill.png)

## **Đổ Màu Hoạ Tiết**

Trong PowerPoint, Đổ màu Hoạ tiết là một tùy chọn định dạng cho phép bạn áp dụng một thiết kế hai màu — chẳng hạn như chấm, sọc, vệt chéo, hoặc caro — vào một hình dạng. Bạn có thể chọn màu tùy chỉnh cho tiền cảnh và nền của hoạ tiết.

Aspose.Slides cung cấp hơn 45 kiểu hoạ tiết được định nghĩa sẵn mà bạn có thể áp dụng cho các hình dạng để tăng tính thẩm mỹ cho bản trình chiếu. Ngay cả khi đã chọn một hoạ tiết có sẵn, bạn vẫn có thể chỉ định màu chính xác mà nó sẽ sử dụng.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/) .
1. Lấy tham chiếu tới một slide theo chỉ mục của nó.
1. Thêm một [IAutoShape](https://reference.aspose.com/slides/vi/net/aspose.slides/iautoshape/) vào slide.
1. Đặt [FillType](https://reference.aspose.com/slides/vi/net/aspose.slides/filltype/) của hình dạng thành `Pattern` .
1. Chọn một kiểu hoạ tiết từ các tùy chọn đã định sẵn.
1. Đặt [Background Color](https://reference.aspose.com/slides/vi/net/aspose.slides/ipatternformat/backcolor/) cho hoạ tiết.
1. Đặt [Foreground Color](https://reference.aspose.com/slides/vi/net/aspose.slides/ipatternformat/forecolor/) cho hoạ tiết.
1. Lưu bản trình chiếu đã chỉnh sửa dưới dạng tệp PPTX.

Mã C# sau đây minh họa cách áp dụng hoạ tiết cho một hình chữ nhật:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// Khởi tạo lớp Presentation đại diện cho tệp bản trình chiếu.
using (Presentation presentation = new Presentation())
{
    // Lấy slide đầu tiên.
    ISlide slide = presentation.Slides[0];

    // Thêm một auto shape loại Rectangle.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Đặt kiểu tô là Pattern.
    shape.FillFormat.FillType = FillType.Pattern;

    // Đặt kiểu hoạ tiết.
    shape.FillFormat.PatternFormat.PatternStyle = PatternStyle.Trellis;

    // Đặt màu nền và màu tiền cảnh cho hoạ tiết.
    shape.FillFormat.PatternFormat.BackColor.Color = Color.LightGray;
    shape.FillFormat.PatternFormat.ForeColor.Color = Color.Yellow;

    // Lưu tệp PPTX vào đĩa.
    presentation.Save("pattern_fill.pptx", SaveFormat.Pptx);
}
```

Kết quả:

![Hình chữ nhật với đổ hoạ tiết](pattern-fill.png)

## **Đổ Hình Ảnh**

Trong PowerPoint, Đổ hình ảnh là một tùy chọn định dạng cho phép bạn chèn một hình ảnh vào bên trong một hình dạng — thực tế sử dụng hình ảnh làm nền cho hình dạng.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/) .
1. Lấy tham chiếu tới một slide theo chỉ mục của nó.
1. Thêm một [IAutoShape](https://reference.aspose.com/slides/vi/net/aspose.slides/iautoshape/) vào slide.
1. Đặt [FillType](https://reference.aspose.com/slides/vi/net/aspose.slides/filltype/) của hình dạng thành `Picture` .
1. Đặt chế độ đổ hình ảnh thành `Tile` (hoặc chế độ khác bạn muốn).
1. Tạo một đối tượng [IPPImage](https://reference.aspose.com/slides/vi/net/aspose.slides/ippimage/) từ hình ảnh bạn muốn sử dụng.
1. Gán hình ảnh này cho thuộc tính `Picture.Image` của `PictureFillFormat` của hình dạng.
1. Lưu bản trình chiếu đã chỉnh sửa dưới dạng tệp PPTX.

Giả sử chúng ta có tệp "lotus.png" với hình ảnh sau:

![Hình ảnh bông sen](lotus.png)

Mã C# sau đây minh họa cách đổ hình ảnh vào một hình dạng:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Khởi tạo lớp Presentation đại diện cho tệp bản trình chiếu.
using (Presentation presentation = new Presentation())
{
    // Lấy slide đầu tiên.
    ISlide slide = presentation.Slides[0];

    // Thêm một auto shape loại Rectangle.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 255, 130);

    // Đặt kiểu tô là Picture.
    shape.FillFormat.FillType = FillType.Picture;

    // Đặt chế độ đổ hình ảnh.
    shape.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Tile;

    // Tải một hình ảnh và thêm nó vào tài nguyên của bản trình chiếu.
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

### **Lát Hình Ảnh Như Kết Cấu**

Nếu bạn muốn đặt một hình ảnh lát làm kết cấu và tùy chỉnh hành vi lát, bạn có thể sử dụng các thuộc tính sau của giao diện [IPictureFillFormat](https://reference.aspose.com/slides/vi/net/aspose.slides/ipicturefillformat/) và lớp [PictureFillFormat](https://reference.aspose.com/slides/vi/net/aspose.slides/picturefillformat/) :

- [PictureFillMode](https://reference.aspose.com/slides/vi/net/aspose.slides/ipicturefillformat/picturefillmode/) : Đặt chế độ đổ hình ảnh — hoặc `Tile` hoặc `Stretch` .
- [TileAlignment](https://reference.aspose.com/slides/vi/net/aspose.slides/ipicturefillformat/tilealignment/) : Xác định căn chỉnh của các ô trong hình dạng.
- [TileFlip](https://reference.aspose.com/slides/vi/net/aspose.slides/ipicturefillformat/tileflip/) : Kiểm soát việc lật ô theo chiều ngang, dọc, hoặc cả hai.
- [TileOffsetX](https://reference.aspose.com/slides/vi/net/aspose.slides/ipicturefillformat/tileoffsetx/) : Đặt độ lệch ngang của ô (theo điểm) so với gốc của hình dạng.
- [TileOffsetY](https://reference.aspose.com/slides/vi/net/aspose.slides/ipicturefillformat/tileoffsety/) : Đặt độ lệch dọc của ô (theo điểm) so với gốc của hình dạng.
- [TileScaleX](https://reference.aspose.com/slides/vi/net/aspose.slides/ipicturefillformat/tilescalex/) : Xác định tỷ lệ ngang của ô dưới dạng phần trăm.
- [TileScaleY](https://reference.aspose.com/slides/vi/net/aspose.slides/ipicturefillformat/tilescaley/) : Xác định tỷ lệ dọc của ô dưới dạng phần trăm.

Mã mẫu sau cho thấy cách thêm một hình chữ nhật với đổ hình ảnh lát và cấu hình các tùy chọn lát:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Khởi tạo lớp Presentation đại diện cho tệp bản trình chiếu.
using (Presentation presentation = new Presentation())
{
    // Lấy slide đầu tiên.
    ISlide firstSlide = presentation.Slides[0];

    // Thêm một auto shape dạng Rectangle.
    IAutoShape shape = firstSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 190, 95);

    // Đặt kiểu tô của hình dạng thành Picture.
    shape.FillFormat.FillType = FillType.Picture;

    // Tải hình ảnh và thêm nó vào tài nguyên của bản trình chiếu.
    IPPImage presentationImage;
    using (IImage sourceImage = Images.FromFile("lotus.png"))
        presentationImage = presentation.Images.AddImage(sourceImage);

    // Gán hình ảnh cho hình dạng.
    IPictureFillFormat pictureFillFormat = shape.FillFormat.PictureFillFormat;
    pictureFillFormat.Picture.Image = presentationImage;

    // Cấu hình chế độ đổ hình ảnh và các thuộc tính lát.
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

![Các tùy chọn lát](tile-options.png)

## **Đổ Màu Đơn**

Trong PowerPoint, Đổ màu Đơn là một tùy chọn định dạng làm đầy một hình dạng bằng một màu duy nhất, đồng nhất. Nền màu đơn này được áp dụng mà không có gradient, kết cấu hay hoạ tiết nào.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/) .
1. Lấy tham chiếu tới một slide theo chỉ mục của nó.
1. Thêm một [IAutoShape](https://reference.aspose.com/slides/vi/net/aspose.slides/iautoshape/) vào slide.
1. Đặt [FillType](https://reference.aspose.com/slides/vi/net/aspose.slides/filltype/) của hình dạng thành `Solid` .
1. Gán màu tô bạn muốn cho hình dạng.
1. Lưu bản trình chiếu đã chỉnh sửa dưới dạng tệp PPTX.

Mã C# sau đây minh họa cách áp dụng đổ màu đơn cho một hình chữ nhật trong slide PowerPoint:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// Khởi tạo lớp Presentation đại diện cho tệp bản trình chiếu.
using (Presentation presentation = new Presentation())
{
    // Lấy slide đầu tiên.
    ISlide slide = presentation.Slides[0];

    // Thêm một auto shape loại Rectangle.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Đặt kiểu tô thành Solid.
    shape.FillFormat.FillType = FillType.Solid;

    // Đặt màu tô.
    shape.FillFormat.SolidFillColor.Color = Color.Yellow;

    // Lưu tệp PPTX vào đĩa.
    presentation.Save("solid_color_fill.pptx", SaveFormat.Pptx);
}
```

Kết quả:

![Hình dạng với đổ màu đơn](solid-color-fill.png)

## **Đặt Độ Trong Suốt**

Trong PowerPoint, khi bạn áp dụng màu đơn, gradient, hình ảnh hoặc kết cấu cho các hình dạng, bạn cũng có thể đặt mức độ trong suốt để kiểm soát độ mờ của lớp tô. Giá trị trong suốt cao hơn làm cho hình dạng trong suốt hơn, cho phép nền hoặc các đối tượng bên dưới hiển thị một phần.

Aspose.Slides cho phép bạn đặt mức độ trong suốt bằng cách điều chỉnh giá trị alpha trong màu được dùng để tô. Cách thực hiện như sau:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/) .
1. Lấy tham chiếu tới một slide theo chỉ mục của nó.
1. Thêm một [IAutoShape](https://reference.aspose.com/slides/vi/net/aspose.slides/iautoshape/) vào slide.
1. Đặt [FillType](https://reference.aspose.com/slides/vi/net/aspose.slides/filltype/) thành `Solid` .
1. Sử dụng `Color.FromArgb(alpha, baseColor)` để định nghĩa một màu với độ trong suốt (thành phần `alpha` kiểm soát độ trong suốt) .
1. Lưu bản trình chiếu.

Mã C# sau đây minh họa cách áp dụng màu tô trong suốt cho một hình chữ nhật:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

const int alpha = 128;

// Khởi tạo lớp Presentation đại diện cho tệp bản trình chiếu.
using (Presentation presentation = new Presentation())
{
    // Lấy slide đầu tiên.
    ISlide slide = presentation.Slides[0];

    // Thêm một auto shape hình chữ nhật rắn.
    IAutoShape solidShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Thêm một auto shape hình chữ nhật trong suốt lên trên hình rắn.
    IAutoShape transparentShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 80, 80, 150, 75);
    transparentShape.FillFormat.FillType = FillType.Solid;
    transparentShape.FillFormat.SolidFillColor.Color = Color.FromArgb(alpha, Color.Yellow);

    // Lưu tệp PPTX vào đĩa.
    presentation.Save("shape_transparency.pptx", SaveFormat.Pptx);
}
```

Kết quả:

![Hình dạng trong suốt](shape-transparency.png)

## **Xoay Hình Dạng**

Aspose.Slides cho phép bạn xoay các hình dạng trong bản trình chiếu PowerPoint. Điều này hữu ích khi đặt các yếu tố hình ảnh với yêu cầu căn chỉnh hoặc thiết kế cụ thể.

Để xoay một hình dạng trên slide, thực hiện các bước sau:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/) .
1. Lấy tham chiếu tới một slide theo chỉ mục của nó.
1. Thêm một [IAutoShape](https://reference.aspose.com/slides/vi/net/aspose.slides/iautoshape/) vào slide.
1. Đặt thuộc tính `Rotation` của hình dạng thành góc mong muốn.
1. Lưu bản trình chiếu.

Mã C# sau đây minh họa cách xoay một hình dạng 5 độ:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Khởi tạo lớp Presentation đại diện cho tệp bản trình chiếu.
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

## **Thêm Hiệu Ứng Cham 3D**

Aspose.Slides cho phép bạn áp dụng hiệu ứng cham 3D cho các hình dạng bằng cách cấu hình các thuộc tính [ThreeDFormat](https://reference.aspose.com/slides/vi/net/aspose.slides/threedformat/) của chúng.

Để thêm hiệu ứng cham 3D vào một hình dạng, thực hiện các bước sau:

1. Khởi tạo lớp [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/) .
1. Lấy tham chiếu tới một slide theo chỉ mục của nó.
1. Thêm một [IAutoShape](https://reference.aspose.com/slides/vi/net/aspose.slides/iautoshape/) vào slide.
1. Cấu hình [ThreeDFormat](https://reference.aspose.com/slides/vi/net/aspose.slides/threedformat/) của hình dạng để xác định các cài đặt cham.
1. Lưu bản trình chiếu.

Mã C# sau đây cho thấy cách áp dụng hiệu ứng cham 3D cho một hình dạng:

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

![Hiệu ứng cham 3D](3D-bevel-effect.png)

## **Thêm Hiệu Ứng Xoay 3D**

Aspose.Slides cho phép bạn áp dụng hiệu ứng xoay 3D cho các hình dạng bằng cách cấu hình các thuộc tính [ThreeDFormat](https://reference.aspose.com/slides/vi/net/aspose.slides/threedformat/) của chúng.

Để áp dụng xoay 3D cho một hình dạng:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/) .
1. Lấy tham chiếu tới một slide theo chỉ mục của nó.
1. Thêm một [IAutoShape](https://reference.aspose.com/slides/vi/net/aspose.slides/iautoshape/) vào slide.
1. Đặt [CameraType](https://reference.aspose.com/slides/vi/net/aspose.slides/icamera/cameratype/) và [LightType](https://reference.aspose.com/slides/vi/net/aspose.slides/ilightrig/lighttype/) của hình dạng để xác định xoay 3D.
1. Lưu bản trình chiếu.

Mã C# sau đây minh họa cách áp dụng hiệu ứng xoay 3D cho một hình dạng:

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

![Hiệu ứng xoay 3D](3D-rotation-effect.png)

## **Kiểm Soát Định Dạng Đen-Trắng cho Hình Dạng**

Thuộc tính [IShape.BlackWhiteMode](https://reference.aspose.com/slides/vi/net/aspose.slides/ishape/blackwhitemode/) chỉ định cách một hình dạng riêng lẻ được hiển thị khi bản trình chiếu được xem hoặc xử lý ở chế độ đen‑trắng. Thuộc tính này không tự động bật chế độ hiển thị đen‑trắng và không thay đổi màu nền, đường viền hoặc các định dạng khác của hình dạng trong chế độ màu bình thường.

Sử dụng một giá trị trong liệt kê [BlackWhiteMode](https://reference.aspose.com/slides/vi/net/aspose.slides/blackwhitemode/) để chọn hành vi mong muốn. Ví dụ, `Automatic` để ứng dụng hiển thị tự chọn cách chuyển đổi, `Gray` và `LightGray` dùng màu xám, `BlackWhite` chỉ dùng màu đen và trắng, `Black` và `White` buộc một màu duy nhất, `Color` giữ nguyên màu bình thường, và `Hidden` bỏ qua hình dạng trong chế độ đen‑trắng. `NotDefined` có nghĩa là không có chế độ ở cấp độ hình dạng được gán.

Mã C# sau tạo một hình dạng màu và làm cho nó hiển thị màu xám trong chế độ hiển thị đen‑trắng:

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);
shape.FillFormat.FillType = FillType.Solid;
shape.FillFormat.SolidFillColor.Color = Color.Orange;

// Giữ màu nền cam ở chế độ màu, nhưng hiển thị hình dạng với màu xám trong chế độ đen-trắng.
shape.BlackWhiteMode = BlackWhiteMode.Gray;

presentation.Save("shape_black_white_mode.pptx", SaveFormat.Pptx);
```

Trong chế độ màu bình thường, hình chữ nhật giữ màu nền cam. Trong quy trình hiển thị đen‑trắng, nó sử dụng màu xám vì chế độ của nó được đặt thành `Gray`. Điều này cho phép bạn giữ slide màu đầy đủ trong khi định nghĩa cách hiển thị riêng cho việc in, xem trước, hoặc các quy trình khác tuân thủ cài đặt hiển thị đen‑trắng của bản trình chiếu.

## **Đặt Lại Định Dạng**

Mã C# sau cho thấy cách đặt lại định dạng của một slide và khôi phục vị trí, kích thước và định dạng của tất cả các hình dạng có placeholder trên [LayoutSlide](https://reference.aspose.com/slides/vi/net/aspose.slides/layoutslide/) về các cài đặt mặc định của chúng:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    foreach (ISlide slide in presentation.Slides)
    {
        // Đặt lại mỗi hình dạng trên slide có placeholder trên bố cục.
        slide.Reset();
    }

    presentation.Save("reset_formatting.pptx", SaveFormat.Pptx);
}
```

## **FAQ**

**Định dạng hình dạng có ảnh hưởng đến kích thước cuối cùng của tệp bản trình chiếu không?**

Chỉ ảnh hưởng rất ít. Các hình ảnh và phương tiện nhúng chiếm phần lớn dung lượng tệp, trong khi các tham số hình dạng như màu, hiệu ứng và gradient được lưu dưới dạng siêu dữ liệu và hầu như không tăng thêm kích thước.

**Làm thế nào tôi có thể phát hiện các hình dạng trên một slide có cùng định dạng để nhóm chúng lại?**

So sánh các thuộc tính định dạng chính của mỗi hình dạng — cài đặt fill, line và effect. Nếu tất cả các giá trị tương ứng khớp nhau, coi các kiểu của chúng là giống nhau và nhóm các hình dạng đó lại, giúp việc quản lý kiểu sau này trở nên đơn giản hơn.

**Tôi có thể lưu một bộ các kiểu hình dạng tùy chỉnh vào một tệp riêng để tái sử dụng trong các bản trình chiếu khác không?**

Có. Lưu các hình mẫu với các kiểu mong muốn trong một slide mẫu hoặc một tệp mẫu .POTX. Khi tạo bản trình chiếu mới, mở mẫu, sao chép các hình dạng đã được định dạng mà bạn cần, và áp dụng lại định dạng của chúng ở nơi cần thiết.