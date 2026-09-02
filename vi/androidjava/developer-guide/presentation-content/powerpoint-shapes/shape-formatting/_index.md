---
title: Định dạng hình dạng PowerPoint trên Android
linktitle: Định dạng Hình dạng
type: docs
weight: 20
url: /vi/androidjava/shape-formatting/
keywords:
- định dạng hình
- định dạng đường
- hiệu ứng phác họa
- đường viền hình phác họa
- định dạng kiểu nối
- đổ màu gradient
- đổ màu pattern
- đổ màu hình ảnh
- đổ màu kết cấu
- đổ màu đồng nhất
- độ trong suốt hình dạng
- xoay hình dạng
- hiệu ứng bo 3D
- hiệu ứng xoay 3D
- đặt lại định dạng
- PowerPoint
- bản trình chiếu
- Android
- Java
- Aspose.Slides
description: "Tìm hiểu cách định dạng hình dạng PowerPoint trên Android bằng Aspose.Slides—đặt kiểu fill, line và effect cho các tệp PPT, PPTX và ODP một cách chính xác và kiểm soát đầy đủ."
---
## **Giới thiệu**

Trong PowerPoint, bạn có thể thêm các hình dạng vào các slide. Vì các hình dạng được tạo thành từ các đường, bạn có thể định dạng chúng bằng cách sửa đổi hoặc áp dụng hiệu ứng cho đường viền. Ngoài ra, bạn có thể định dạng hình dạng bằng cách chỉ định các cài đặt kiểm soát cách nền trong của chúng được tô.

![định dạng hình PowerPoint](format-shape-powerpoint.png)

Aspose.Slides for Android via Java cung cấp các giao diện và phương thức cho phép bạn định dạng hình dạng bằng các tùy chọn có trong PowerPoint.

## **Định dạng Đường viền**

Sử dụng Aspose.Slides, bạn có thể chỉ định kiểu đường tùy chỉnh cho một hình dạng. Các bước sau mô tả quy trình:

1. Tạo một thể hiện của lớp[Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/presentation/) .
1. Lấy tham chiếu đến một slide theo chỉ mục của nó.
1. Thêm một[IAutoShape](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/iautoshape/) vào slide.
1. Đặt[ line style](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/linestyle/) của hình dạng.
1. Đặt độ rộng đường.
1. Đặt[dash style](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/linedashstyle/) của đường.
1. Đặt màu đường cho hình dạng.
1. Lưu bản trình chiếu đã sửa đổi dưới dạng tệp PPTX.

Mã sau minh họa cách định dạng một `AutoShape` hình chữ nhật:

```java
// Tạo một thể hiện của lớp Presentation biểu thị một tệp trình chiếu.
Presentation presentation = new Presentation();
try {
    // Lấy slide đầu tiên.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Thêm một auto shape kiểu Rectangle.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 150, 75);

    // Đặt màu nền cho hình dạng hình chữ nhật.
    shape.getFillFormat().setFillType(FillType.NoFill);

    // Áp dụng định dạng cho các đường của hình chữ nhật.
    shape.getLineFormat().setStyle(LineStyle.ThickThin);
    shape.getLineFormat().setWidth(7);
    shape.getLineFormat().setDashStyle(LineDashStyle.Dash);

    // Đặt màu cho đường viền của hình chữ nhật.
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);

    // Lưu tệp PPTX vào đĩa.
    presentation.save("formatted_lines.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Kết quả:

![Các đường viền đã định dạng trong bản trình chiếu](formatted-lines.png)

## **Áp dụng Hiệu ứng Phác họa cho Đường viền Hình dạng**

Hiệu ứng phác họa làm cho đường viền hình dạng trông giống như được vẽ tay. Sử dụng[IShape.getLineFormat](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ishape/) để truy cập cài đặt đường, [ILineFormat.getSketchFormat](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ilineformat/) để truy cập cài đặt phác họa, và[ISketchFormat.setSketchType](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/isketchformat/) để chọn một giá trị trong liệt kê[LineSketchType](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/linesketchtype/) .

Mã Java sau cho thấy cách áp dụng hiệu ứng[LineSketchType.Curved](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/linesketchtype/), đọc giá trị đã chỉ định rõ ràng, và bỏ hiệu ứng bằng[LineSketchType.None](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/linesketchtype/) :

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);

    // Truy cập định dạng đường của hình và định dạng phác họa của nó.
    ISketchFormat sketchFormat = shape.getLineFormat().getSketchFormat();

    // Áp dụng hiệu ứng phác họa.
    sketchFormat.setSketchType(LineSketchType.Curved);

    // Đọc hiệu ứng phác họa được gán trực tiếp cho hình dạng.
    int explicitSketchType = sketchFormat.getSketchType();
    System.out.println("Explicit sketch type: " + explicitSketchType);

    // Xóa bỏ hiệu ứng phác họa.
    sketchFormat.setSketchType(LineSketchType.None);
} finally {
    presentation.dispose();
}
```

Giá trị trả về bởi[ISketchFormat.getSketchType](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/isketchformat/) đại diện cho cài đặt được gán trực tiếp cho hình dạng. Nếu định dạng đường có thể được kế thừa từ chủ đề, slide chủ hoặc slide bố cục, hãy sử dụng[ILineFormat.getEffective](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ilineformat/), truy cập[ILineFormatEffectiveData.getSketchFormat](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ilineformateffectivedata/), và đọc[ISketchFormatEffectiveData.getSketchType](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/isketchformateffectivedata/). Giá trị hiệu quả phản ánh định dạng thực tế được áp dụng sau khi kế thừa được giải quyết:

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    IShape shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    ILineFormat lineFormat = shape.getLineFormat();

    int explicitSketchType = lineFormat.getSketchFormat().getSketchType();
    ILineFormatEffectiveData effectiveLineFormat = lineFormat.getEffective();
    int effectiveSketchType = effectiveLineFormat.getSketchFormat().getSketchType();

    System.out.println("Explicit sketch type: " + explicitSketchType);
    System.out.println("Effective sketch type: " + effectiveSketchType);
} finally {
    presentation.dispose();
}
```

## **Định dạng Kiểu Nối**

Ba tùy chọn kiểu nối:

* Tròn
* Mối
* Bờ xiên

Mặc định, khi PowerPoint nối hai đường dưới một góc (ví dụ ở góc của hình dạng), nó sử dụng cài đặt **Tròn**. Tuy nhiên, nếu bạn vẽ một hình dạng có góc nhọn, bạn có thể muốn chọn tùy chọn **Mối**.

![Kiểu nối trong bản trình chiếu](join-style-powerpoint.png)

Mã Java sau minh họa cách ba hình chữ nhật (như trong hình trên) được tạo bằng các cài đặt kiểu nối Mối, Bờ xiên và Tròn:

```java
// Tạo một thể hiện của lớp Presentation biểu thị một tệp trình chiếu.
Presentation presentation = new Presentation();
try {
    // Lấy slide đầu tiên.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Thêm ba auto shape kiểu Rectangle.
    IAutoShape shape1 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 75);
    IAutoShape shape2 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 210, 20, 150, 75);
    IAutoShape shape3 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 135, 150, 75);

    // Đặt màu nền cho mỗi hình chữ nhật.
    shape1.getFillFormat().setFillType(FillType.Solid);
    shape1.getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    shape2.getFillFormat().setFillType(FillType.Solid);
    shape2.getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    shape3.getFillFormat().setFillType(FillType.Solid);
    shape3.getFillFormat().getSolidFillColor().setColor(Color.BLACK);

    // Đặt độ rộng đường.
    shape1.getLineFormat().setWidth(15);
    shape2.getLineFormat().setWidth(15);
    shape3.getLineFormat().setWidth(15);

    // Đặt màu cho đường viền của mỗi hình chữ nhật.
    shape1.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape1.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    shape2.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape2.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    shape3.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape3.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);

    // Đặt kiểu nối.
    shape1.getLineFormat().setJoinStyle(LineJoinStyle.Miter);
    shape2.getLineFormat().setJoinStyle(LineJoinStyle.Bevel);
    shape3.getLineFormat().setJoinStyle(LineJoinStyle.Round);

    // Thêm văn bản vào mỗi hình chữ nhật.
    shape1.getTextFrame().setText("Miter Join Style");
    shape2.getTextFrame().setText("Bevel Join Style");
    shape3.getTextFrame().setText("Round Join Style");

    // Lưu tệp PPTX vào đĩa.
    presentation.save("join_styles.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Đổ màu Gradient**

Trong PowerPoint, Đổ màu Gradient là một tùy chọn định dạng cho phép bạn áp dụng một hỗn hợp màu liên tục vào một hình dạng. Ví dụ, bạn có thể áp dụng hai hoặc nhiều màu sao cho một màu dần chuyển sang màu khác.

Cách áp dụng Gradient Fill cho một hình dạng bằng Aspose.Slides:

1. Tạo một thể hiện của lớp[Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/presentation/) .
1. Lấy tham chiếu đến một slide theo chỉ mục của nó.
1. Thêm một[IAutoShape](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/iautoshape/) vào slide.
1. Đặt[FillType](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/filltype/) của hình dạng thành `Gradient`.
1. Thêm hai màu bạn muốn với vị trí đã định nghĩa bằng các phương thức `add` của bộ sưu tập gradient stop được khai báo bởi giao diện[IGradientFormat](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/igradientformat/) .
1. Lưu bản trình chiếu đã sửa đổi dưới dạng tệp PPTX.

Mã Java sau minh họa cách áp dụng hiệu ứng Gradient Fill cho một hình ellipse:

```java
// Tạo một thể hiện của lớp Presentation biểu thị một tệp trình chiếu.
Presentation presentation = new Presentation();
try {
    // Lấy slide đầu tiên.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Thêm một auto shape kiểu Ellipse.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 50, 150, 75);

    // Áp dụng định dạng gradient cho ellipse.
    shape.getFillFormat().setFillType(FillType.Gradient);
    shape.getFillFormat().getGradientFormat().setGradientShape(GradientShape.Linear);

    // Đặt hướng của gradient.
    shape.getFillFormat().getGradientFormat().setGradientDirection(GradientDirection.FromCorner2);

    // Thêm hai điểm dừng gradient.
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor((float)1.0, PresetColor.Purple);
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor((float)0, PresetColor.Red);

    // Lưu tệp PPTX vào đĩa.
    presentation.save("gradient_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Kết quả:

![Ellipse với Gradient Fill](gradient-fill.png)

## **Đổ màu Pattern**

Trong PowerPoint, Pattern Fill là một tùy chọn định dạng cho phép bạn áp dụng một thiết kế hai màu—như chấm, sọc, chéo hoặc ô vuông—cho một hình dạng. Bạn có thể chọn màu tùy chỉnh cho màu nền và màu tiền cảnh của mẫu.

Aspose.Slides cung cấp hơn 45 kiểu mẫu được định sẵn mà bạn có thể áp dụng cho các hình dạng để tăng tính thẩm mỹ cho bản trình chiếu. Ngay cả sau khi chọn một mẫu đã định sẵn, bạn vẫn có thể chỉ định màu chính xác mà nó sẽ sử dụng.

Cách áp dụng Pattern Fill cho một hình dạng bằng Aspose.Slides:

1. Tạo một thể hiện của lớp[Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/presentation/) .
1. Lấy tham chiếu đến một slide theo chỉ mục của nó.
1. Thêm một[IAutoShape](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/iautoshape/) vào slide.
1. Đặt[FillType](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/filltype/) của hình dạng thành `Pattern`.
1. Chọn một kiểu mẫu từ các tùy chọn đã định sẵn.
1. Đặt[Background Color](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/patternformat/#getBackColor--) của mẫu.
1. Đặt[Foreground Color](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/patternformat/#getForeColor--) của mẫu.
1. Lưu bản trình chiếu đã sửa đổi dưới dạng tệp PPTX.

Mã Java sau minh họa cách áp dụng Pattern Fill cho một hình chữ nhật:

```java
// Tạo một thể hiện của lớp Presentation biểu thị một tệp trình chiếu.
Presentation presentation = new Presentation();
try {
    // Lấy slide đầu tiên.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Thêm một auto shape kiểu Rectangle.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Đặt kiểu fill thành Pattern.
    shape.getFillFormat().setFillType(FillType.Pattern);

    // Đặt kiểu mẫu.
    shape.getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.Trellis);

    // Đặt màu nền và màu tiền cảnh của mẫu.
    shape.getFillFormat().getPatternFormat().getBackColor().setColor(Color.LIGHT_GRAY);
    shape.getFillFormat().getPatternFormat().getForeColor().setColor(Color.YELLOW);

    // Lưu tệp PPTX vào đĩa.
    presentation.save("pattern_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Kết quả:

![Hình chữ nhật với Pattern Fill](pattern-fill.png)

## **Đổ màu Hình ảnh**

Trong PowerPoint, Picture Fill là một tùy chọn định dạng cho phép bạn chèn một hình ảnh vào bên trong một hình dạng—thực tế là sử dụng hình ảnh làm nền cho hình dạng.

Cách sử dụng Aspose.Slides để áp dụng Picture Fill cho một hình dạng:

1. Tạo một thể hiện của lớp[Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/presentation/) .
1. Lấy tham chiếu đến một slide theo chỉ mục của nó.
1. Thêm một[IAutoShape](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/iautoshape/) vào slide.
1. Đặt[FillType](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/filltype/) của hình dạng thành `Picture`.
1. Đặt chế độ picture fill thành `Tile` (hoặc chế độ khác bạn muốn).
1. Tạo một đối tượng[IPPImage](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ippimage/) từ hình ảnh bạn muốn sử dụng.
1. Truyền hình ảnh vào phương thức`ISlidesPicture.setImage` .
1. Lưu bản trình chiếu đã sửa đổi dưới dạng tệp PPTX.

Giả sử chúng ta có tệp "lotus.png" với hình ảnh sau:

![Hình ảnh lotus](lotus.png)

Mã Java sau minh họa cách lấp đầy hình dạng bằng hình ảnh:

```java
// Tạo một thể hiện của lớp Presentation biểu thị một tệp trình chiếu.
Presentation presentation = new Presentation();
try {
    // Lấy slide đầu tiên.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Thêm một auto shape kiểu Rectangle.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 255, 130);
    
    // Đặt kiểu fill thành Picture.
    shape.getFillFormat().setFillType(FillType.Picture);

    // Đặt chế độ picture fill.
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Tile);

    // Tải hình ảnh và thêm nó vào tài nguyên của bản trình chiếu.
    IImage image = Images.fromFile("lotus.png");
    IPPImage picture = presentation.getImages().addImage(image);
    image.dispose();

    // Đặt hình ảnh.
    shape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);

    // Lưu tệp PPTX vào đĩa.
    presentation.save("picture_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Kết quả:

![Hình dạng với Picture Fill](picture-fill.png)

### **Tile Picture As Texture**

Nếu bạn muốn đặt một hình ảnh lặp thành kết cấu và tùy chỉnh hành vi lặp, bạn có thể sử dụng các phương thức sau của giao diện[IPictureFillFormat](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ipicturefillformat/) và lớp[PictureFillFormat](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/picturefillformat/) :

- [setPictureFillMode](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ipicturefillformat/#setPictureFillMode-int-): Đặt chế độ picture fill—hoặc `Tile` hoặc `Stretch` .
- [setTileAlignment](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ipicturefillformat/#setTileAlignment-byte-): Xác định cách căn chỉnh các ô gạch trong hình dạng.
- [setTileFlip](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ipicturefillformat/#setTileFlip-int-): Điều khiển việc lật ô gạch theo chiều ngang, chiều dọc hoặc cả hai.
- [setTileOffsetX](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ipicturefillformat/#setTileOffsetX-float-): Đặt độ dịch chuyển theo chiều ngang của ô gạch (đơn vị point) so với gốc của hình dạng.
- [setTileOffsetY](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ipicturefillformat/#setTileOffsetY-float-): Đặt độ dịch chuyển theo chiều dọc của ô gạch (đơn vị point) so với gốc của hình dạng.
- [setTileScaleX](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ipicturefillformat/#setTileScaleX-float-): Xác định tỷ lệ chiều ngang của ô gạch dưới dạng phần trăm.
- [setTileScaleY](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ipicturefillformat/#setTileScaleY-float-): Xác định tỷ lệ chiều dọc của ô gạch dưới dạng phần trăm.

Mã mẫu sau cho thấy cách thêm một hình chữ nhật với picture fill dạng lặp và cấu hình các tùy chọn lặp:

```java
// Tạo một thể hiện của lớp Presentation biểu thị một tệp trình chiếu.
Presentation presentation = new Presentation();
try {
    // Lấy slide đầu tiên.
    ISlide firstSlide = presentation.getSlides().get_Item(0);

    // Thêm một auto shape hình chữ nhật.
    IAutoShape shape = firstSlide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 190, 95);

    // Đặt kiểu fill của hình dạng thành Picture.
    shape.getFillFormat().setFillType(FillType.Picture);

    // Tải hình ảnh và thêm nó vào tài nguyên của bản trình chiếu.
    IImage sourceImage = Images.fromFile("lotus.png");
    IPPImage presentationImage = presentation.getImages().addImage(sourceImage);
    sourceImage.dispose();

    // Gán hình ảnh cho hình dạng.
    IPictureFillFormat pictureFillFormat = shape.getFillFormat().getPictureFillFormat();
    pictureFillFormat.getPicture().setImage(presentationImage);

    // Cấu hình chế độ picture fill và các thuộc tính lặp.
    pictureFillFormat.setPictureFillMode(PictureFillMode.Tile);
    pictureFillFormat.setTileOffsetX(-32);
    pictureFillFormat.setTileOffsetY(-32);
    pictureFillFormat.setTileScaleX(50);
    pictureFillFormat.setTileScaleY(50);
    pictureFillFormat.setTileAlignment(RectangleAlignment.BottomRight);
    pictureFillFormat.setTileFlip(TileFlip.FlipBoth);

    // Lưu tệp PPTX vào đĩa.
    presentation.save("tile.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Kết quả:

![Các tùy chọn lặp](tile-options.png)

## **Đổ màu Đơn sắc**

Trong PowerPoint, Solid Color Fill là một tùy chọn định dạng khiến một hình dạng được tô một màu đồng nhất. Màu nền đơn giản này được áp dụng mà không có gradient, kết cấu hay mẫu nào.

Để áp dụng Solid Color Fill cho một hình dạng bằng Aspose.Slides, thực hiện các bước sau:

1. Tạo một thể hiện của lớp[Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/presentation/) .
1. Lấy tham chiếu đến một slide theo chỉ mục của nó.
1. Thêm một[IAutoShape](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/iautoshape/) vào slide.
1. Đặt[FillType](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/filltype/) của hình dạng thành `Solid`.
1. Gán màu tô bạn muốn cho hình dạng.
1. Lưu bản trình chiếu đã sửa đổi dưới dạng tệp PPTX.

Mã Java sau minh họa cách áp dụng Solid Color Fill cho một hình chữ nhật trong slide PowerPoint:

```java
// Tạo một thể hiện của lớp Presentation biểu thị một tệp trình chiếu.
Presentation presentation = new Presentation();
try {
    // Lấy slide đầu tiên.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Thêm một auto shape kiểu Rectangle.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Đặt kiểu fill thành Solid.
    shape.getFillFormat().setFillType(FillType.Solid);

    // Đặt màu nền.
    shape.getFillFormat().getSolidFillColor().setColor(Color.YELLOW);

    // Lưu tệp PPTX vào đĩa.
    presentation.save("solid_color_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Kết quả:

![Hình dạng với Solid Color Fill](solid-color-fill.png)

## **Thiết lập Độ trong suốt**

Trong PowerPoint, khi bạn áp dụng solid color, gradient, picture hoặc texture fill cho các hình dạng, bạn cũng có thể thiết lập mức độ trong suốt để kiểm soát độ mờ của phần tô. Giá trị trong suốt cao hơn làm cho hình dạng càng trong suốt, cho phép nền hoặc các đối tượng phía sau hiển thị một phần.

Aspose.Slides cho phép bạn thiết lập mức độ trong suốt bằng cách điều chỉnh giá trị alpha trong màu được dùng để tô. Cách thực hiện:

1. Tạo một thể hiện của lớp[Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/presentation/) .
1. Lấy tham chiếu đến một slide theo chỉ mục của nó.
1. Thêm một[IAutoShape](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/iautoshape/) vào slide.
1. Đặt[FillType](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/filltype/) thành `Solid`.
1. Sử dụng `Color` để định nghĩa một màu có độ trong suốt (thành phần `alpha` kiểm soát độ trong suốt).
1. Lưu bản trình chiếu.

Mã Java sau minh họa cách áp dụng màu tô trong suốt cho một hình chữ nhật:

```java
// Tạo một thể hiện của lớp Presentation biểu thị một tệp trình chiếu.
Presentation presentation = new Presentation();
try {
    // Lấy slide đầu tiên.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Thêm một auto shape hình chữ nhật đặc.
    IAutoShape solidShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Thêm một auto shape hình chữ nhật trong suốt lên trên hình dạng đặc.
    IAutoShape transparentShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 80, 80, 150, 75);
    transparentShape.getFillFormat().setFillType(FillType.Solid);
    transparentShape.getFillFormat().getSolidFillColor().setColor(new Color(255, 255, 0, 204));

    // Lưu tệp PPTX vào đĩa.
    presentation.save("shape_transparency.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Kết quả:

![Hình dạng trong suốt](shape-transparency.png)

## **Xoay Hình dạng**

Aspose.Slides cho phép bạn xoay các hình dạng trong bản trình chiếu PowerPoint. Điều này hữu ích khi cần định vị các yếu tố trực quan với yêu cầu căn chỉnh hoặc thiết kế cụ thể.

Để xoay một hình dạng trên slide, thực hiện các bước sau:

1. Tạo một thể hiện của lớp[Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/presentation/) .
1. Lấy tham chiếu đến một slide theo chỉ mục của nó.
1. Thêm một[IAutoShape](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/iautoshape/) vào slide.
1. Đặt thuộc tính xoay của hình dạng thành góc mong muốn.
1. Lưu bản trình chiếu.

Mã Java sau minh họa cách xoay một hình dạng 5 độ:

```java
// Tạo một thể hiện của lớp Presentation biểu thị một tệp trình chiếu.
Presentation presentation = new Presentation();
try {
    // Lấy slide đầu tiên.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Thêm một auto shape kiểu Rectangle.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Xoay hình dạng 5 độ.
    shape.setRotation(5);

    // Lưu tệp PPTX vào đĩa.
    presentation.save("shape_rotation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Kết quả:

![Xoay hình dạng](shape-rotation.png)

## **Thêm Hiệu ứng Bo 3D**

Aspose.Slides cho phép bạn áp dụng hiệu ứng bo 3D cho các hình dạng bằng cách cấu hình các thuộc tính[ThreeDFormat](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/threedformat/) của chúng.

Để thêm hiệu ứng bo 3D cho một hình dạng, thực hiện các bước sau:

1. Tạo một thể hiện của lớp[Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/presentation/) .
1. Lấy tham chiếu đến một slide theo chỉ mục của nó.
1. Thêm một[IAutoShape](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/iautoshape/) vào slide.
1. Cấu hình[ThreeDFormat](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/threedformat/) của hình dạng để xác định cài đặt bo.
1. Lưu bản trình chiếu.

Mã Java sau cho thấy cách áp dụng hiệu ứng bo 3D cho một hình dạng:

```java
// Tạo một thể hiện của lớp Presentation.
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Thêm một hình dạng vào slide.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 50, 100, 100);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(Color.GREEN);
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.ORANGE);
    shape.getLineFormat().setWidth(2.0);

    // Đặt các thuộc tính ThreeDFormat của hình dạng.
    shape.getThreeDFormat().setDepth(4);
    shape.getThreeDFormat().getBevelTop().setBevelType(BevelPresetType.Circle);
    shape.getThreeDFormat().getBevelTop().setHeight(6);
    shape.getThreeDFormat().getBevelTop().setWidth(6);
    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.ThreePt);
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);

    // Lưu bản trình chiếu dưới dạng tệp PPTX.
    presentation.save("3D_bevel_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Kết quả:

![Hiệu ứng bo 3D](3D-bevel-effect.png)

## **Thêm Hiệu ứng Xoay 3D**

Aspose.Slides cho phép bạn áp dụng hiệu ứng xoay 3D cho các hình dạng bằng cách cấu hình các thuộc tính[ThreeDFormat](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/threedformat/) của chúng.

Để áp dụng xoay 3D cho một hình dạng:

1. Tạo một thể hiện của lớp[Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/presentation/) .
1. Lấy tham chiếu đến một slide theo chỉ mục của nó.
1. Thêm một[IAutoShape](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/iautoshape/) vào slide.
1. Sử dụng[setCameraType](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/icamera/#setCameraType-int-) và[setLightType](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ilightrig/#setLightType-int-) để xác định xoay 3D.
1. Lưu bản trình chiếu.

Mã Java sau minh họa cách áp dụng hiệu ứng xoay 3D cho một hình dạng:

```java
// Tạo một thể hiện của lớp Presentation.
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);
    autoShape.getTextFrame().setText("Hello, Aspose!");

    autoShape.getThreeDFormat().setDepth(6);
    autoShape.getThreeDFormat().getCamera().setRotation(40, 35, 20);
    autoShape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.IsometricLeftUp);
    autoShape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Balanced);

    // Lưu bản trình chiếu dưới dạng tệp PPTX.
    presentation.save("3D_rotation_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Kết quả:

![Hiệu ứng xoay 3D](3D-rotation-effect.png)

## **Đặt lại Định dạng**

Mã Java sau cho thấy cách đặt lại định dạng của một slide và khôi phục vị trí, kích thước và định dạng của tất cả các hình dạng có trình giữ chỗ trên[LayoutSlide](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/layoutslide/) về thiết lập mặc định:

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        // Đặt lại mỗi hình dạng trên slide có trình giữ chỗ trong bố cục.
        slide.reset();
    }
    presentation.save("reset_formatting.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Câu hỏi thường gặp**

**Định dạng hình dạng có ảnh hưởng đến kích thước cuối cùng của tệp bản trình chiếu không?**

Chỉ ảnh hưởng rất ít. Các hình ảnh và phương tiện được nhúng chiếm phần lớn dung lượng tệp, trong khi các tham số hình dạng như màu, hiệu ứng và gradient được lưu dưới dạng siêu dữ liệu và hầu như không làm tăng kích thước.

**Làm sao tôi có thể phát hiện các hình dạng trên một slide có cùng định dạng để tôi có thể nhóm chúng lại?**

So sánh các thuộc tính định dạng chính của mỗi hình dạng—cài đặt fill, line và effect. Nếu tất cả các giá trị tương ứng khớp nhau, coi chúng là cùng một kiểu và nhóm logic các hình dạng đó, giúp quản lý kiểu sau này dễ dàng hơn.

**Tôi có thể lưu một bộ các kiểu hình dạng tùy chỉnh vào một tệp riêng để tái sử dụng trong các bản trình chiếu khác không?**

Có. Lưu các hình mẫu có kiểu mong muốn trong một slide mẫu hoặc tệp mẫu .POTX. Khi tạo bản trình chiếu mới, mở mẫu, sao chép các hình dạng đã định dạng mà bạn cần và áp dụng lại định dạng của chúng ở nơi cần thiết.