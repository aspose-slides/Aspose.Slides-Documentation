---
title: Định dạng các hình dạng PowerPoint trong Java
linktitle: Định dạng Hình dạng
type: docs
weight: 20
url: /vi/java/shape-formatting/
keywords:
- định dạng hình dạng
- định dạng đường
- định dạng kiểu nối
- đổ màu gradient
- đổ màu mẫu
- đổ màu hình ảnh
- đổ màu kết cấu
- đổ màu đồng nhất
- độ trong suốt hình dạng
- xoay hình dạng
- hiệu ứng viền 3D
- hiệu ứng xoay 3D
- đặt lại định dạng
- PowerPoint
- bài thuyết trình
- Java
- Aspose.Slides
description: "Tìm hiểu cách định dạng các hình dạng PowerPoint trong Java bằng Aspose.Slides—đặt các kiểu đổ, đường và hiệu ứng cho tệp PPT, PPTX và ODP một cách chính xác và kiểm soát đầy đủ."
---
## **Giới thiệu**

Trong PowerPoint, bạn có thể thêm các hình dạng vào các slide. Vì hình dạng được tạo thành từ các đường, bạn có thể định dạng chúng bằng cách chỉnh sửa hoặc áp dụng hiệu ứng lên đường viền. Ngoài ra, bạn cũng có thể định dạng hình dạng bằng cách chỉ định các cài đặt kiểm soát cách phần bên trong của chúng được tô màu.

![format-shape-powerpoint](format-shape-powerpoint.png)

Aspose.Slides for Java cung cấp các giao diện và phương thức cho phép bạn định dạng hình dạng bằng các tùy chọn giống như trong PowerPoint.

## **Định dạng Đường viền**

Sử dụng Aspose.Slides, bạn có thể chỉ định kiểu đường tùy chỉnh cho một hình dạng. Các bước sau mô tả quy trình:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation/) .
1. Lấy tham chiếu đến một slide theo chỉ mục của nó.
1. Thêm một [IAutoShape](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iautoshape/) vào slide.
1. Đặt [line style](https://reference.aspose.com/slides/vi/java/com.aspose.slides/linestyle/) cho hình dạng.
1. Đặt độ rộng của đường.
1. Đặt [dash style](https://reference.aspose.com/slides/vi/java/com.aspose.slides/linedashstyle/) cho đường.
1. Đặt màu đường cho hình dạng.
1. Lưu bản trình chiếu đã sửa đổi dưới dạng tệp PPTX.

Mã mẫu dưới đây minh họa cách định dạng một `AutoShape` hình chữ nhật:

```java
// Khởi tạo lớp Presentation đại diện cho một tệp bài thuyết trình.
Presentation presentation = new Presentation();
try {
    // Lấy slide đầu tiên.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Thêm một hình tự động loại hình chữ nhật.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 150, 75);

    // Đặt màu tô cho hình chữ nhật.
    shape.getFillFormat().setFillType(FillType.NoFill);

    // Áp dụng định dạng cho các đường của hình chữ nhật.
    shape.getLineFormat().setStyle(LineStyle.ThickThin);
    shape.getLineFormat().setWidth(7);
    shape.getLineFormat().setDashStyle(LineDashStyle.Dash);

    // Đặt màu cho đường của hình chữ nhật.
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);

    // Lưu tệp PPTX vào đĩa.
    presentation.save("formatted_lines.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Kết quả:

![Các đường viền đã được định dạng trong bài thuyết trình](formatted-lines.png)

## **Định dạng Kiểu Nối**

Có ba tùy chọn kiểu nối:

* Tròn
* Lóa
* Khoan

Mặc định, khi PowerPoint nối hai đường ở một góc (chẳng hạn ở góc của hình dạng), nó sử dụng thiết lập **Tròn**. Tuy nhiên, nếu bạn đang vẽ một hình dạng có các góc sắc, bạn có thể thích tùy chọn **Lóa** hơn.

![Kiểu nối trong bài thuyết trình](join-style-powerpoint.png)

Mã Java dưới đây minh họa cách tạo ba hình chữ nhật (như trong hình trên) bằng các thiết lập kiểu nối Lóa, Khoan và Tròn:

```java
// Khởi tạo lớp Presentation đại diện cho một tệp bài thuyết trình.
Presentation presentation = new Presentation();
try {
    // Lấy slide đầu tiên.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Thêm ba hình tự động loại hình chữ nhật.
    IAutoShape shape1 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 75);
    IAutoShape shape2 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 210, 20, 150, 75);
    IAutoShape shape3 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 135, 150, 75);

    // Đặt màu tô cho mỗi hình chữ nhật.
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

    // Đặt màu cho đường của mỗi hình chữ nhật.
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

Trong PowerPoint, Đổ màu Gradient là một tùy chọn định dạng cho phép bạn áp dụng một sự pha trộn liên tục của các màu vào một hình dạng. Ví dụ, bạn có thể áp dụng hai hoặc nhiều màu sao cho một màu dần chuyển sang màu khác.

Đây là cách áp dụng độ đổ màu gradient cho một hình dạng bằng Aspose.Slides:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation/) .
1. Lấy tham chiếu đến một slide theo chỉ mục của nó.
1. Thêm một [IAutoShape](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iautoshape/) vào slide.
1. Đặt [FillType](https://reference.aspose.com/slides/vi/java/com.aspose.slides/filltype/) của hình dạng thành `Gradient`.
1. Thêm hai màu ưa thích của bạn cùng với vị trí đã xác định bằng các phương thức `add` của bộ sưu tập gradient stop được mở rộng bởi giao diện [IGradientFormat](https://reference.aspose.com/slides/vi/java/com.aspose.slides/igradientformat/) .
1. Lưu bản trình chiếu đã sửa đổi dưới dạng tệp PPTX.

Mã Java dưới đây minh họa cách áp dụng hiệu ứng độ đổ màu gradient cho một hình ellipse:

```java
// Khởi tạo lớp Presentation đại diện cho một tệp bài thuyết trình.
Presentation presentation = new Presentation();
try {
    // Lấy slide đầu tiên.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Thêm một hình tự động loại Ellipse.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 50, 150, 75);

    // Áp dụng định dạng gradient cho hình ellipse.
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

![Elip với độ đổ màu gradient](gradient-fill.png)

## **Đổ màu Pattern**

Trong PowerPoint, Đổ màu Pattern là một tùy chọn định dạng cho phép bạn áp dụng một thiết kế hai màu—như chấm, sọc, vạch chéo hoặc ô vuông—vào một hình dạng. Bạn có thể chọn màu tùy chỉnh cho nền trước và nền sau của mẫu.

Aspose.Slides cung cấp hơn 45 kiểu mẫu được định trước mà bạn có thể áp dụng cho các hình dạng để tăng tính thẩm mỹ cho bài thuyết trình. Ngay cả sau khi chọn một mẫu đã định trước, bạn vẫn có thể chỉ định các màu chính xác mà mẫu sẽ sử dụng.

Đây là cách áp dụng độ đổ mẫu cho một hình dạng bằng Aspose.Slides:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation/) .
1. Lấy tham chiếu đến một slide theo chỉ mục của nó.
1. Thêm một [IAutoShape](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iautoshape/) vào slide.
1. Đặt [FillType](https://reference.aspose.com/slides/vi/java/com.aspose.slides/filltype/) của hình dạng thành `Pattern`.
1. Chọn một kiểu mẫu từ các tùy chọn được định trước.
1. Đặt [Background Color](https://reference.aspose.com/slides/vi/java/com.aspose.slides/patternformat/#getBackColor--) của mẫu.
1. Đặt [Foreground Color](https://reference.aspose.com/slides/vi/java/com.aspose.slides/patternformat/#getForeColor--) của mẫu.
1. Lưu bản trình chiếu đã sửa đổi dưới dạng tệp PPTX.

Mã Java dưới đây minh họa cách áp dụng độ đổ mẫu cho một hình chữ nhật:

```java
// Khởi tạo lớp Presentation đại diện cho một tệp bài thuyết trình.
Presentation presentation = new Presentation();
try {
    // Lấy slide đầu tiên.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Thêm một hình tự động loại Rectangle.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Đặt kiểu tô là Pattern.
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

![Hình chữ nhật với độ đổ mẫu](pattern-fill.png)

## **Đổ màu Hình ảnh**

Trong PowerPoint, Đổ màu Hình ảnh là một tùy chọn định dạng cho phép bạn chèn một hình ảnh vào bên trong một hình dạng—thực tế là sử dụng hình ảnh làm nền cho hình dạng.

Đây là cách sử dụng Aspose.Slides để áp dụng độ đổ hình ảnh cho một hình dạng:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation/) .
1. Lấy tham chiếu đến một slide theo chỉ mục của nó.
1. Thêm một [IAutoShape](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iautoshape/) vào slide.
1. Đặt [FillType](https://reference.aspose.com/slides/vi/java/com.aspose.slides/filltype/) của hình dạng thành `Picture`.
1. Đặt chế độ độ đổ hình ảnh thành `Tile` (hoặc chế độ ưa thích khác).
1. Tạo một đối tượng [IPPImage](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ippimage/) từ hình ảnh bạn muốn sử dụng.
1. Truyền hình ảnh vào phương thức `ISlidesPicture.setImage` .
1. Lưu bản trình chiếu đã sửa đổi dưới dạng tệp PPTX.

Giả sử chúng ta có tệp "lotus.png" với hình ảnh sau:

![Hình ảnh bông sen](lotus.png)

Mã Java dưới đây minh họa cách đổ hình ảnh vào một hình dạng:

```java
// Khởi tạo lớp Presentation đại diện cho một tệp bài thuyết trình.
Presentation presentation = new Presentation();
try {
    // Lấy slide đầu tiên.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Thêm một hình tự động loại Rectangle.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 255, 130);
    
    // Đặt kiểu tô là Picture.
    shape.getFillFormat().setFillType(FillType.Picture);

    // Đặt chế độ độ đổ hình ảnh.
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Tile);

    // Tải một hình ảnh và thêm nó vào các tài nguyên của bài thuyết trình.
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

![Hình dạng với độ đổ hình ảnh](picture-fill.png)

### **Gạch Hình ảnh làm Kết cấu**

Nếu bạn muốn đặt một hình ảnh theo dạng gạch làm kết cấu và tùy chỉnh cách gạch được sắp xếp, bạn có thể sử dụng các phương thức sau của giao diện [IPictureFillFormat](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ipicturefillformat/) và lớp [PictureFillFormat](https://reference.aspose.com/slides/vi/java/com.aspose.slides/picturefillformat/) :

- [setPictureFillMode](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ipicturefillformat/#setPictureFillMode-int-): Đặt chế độ độ đổ hình ảnh—hoặc `Tile` hoặc `Stretch`.
- [setTileAlignment](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ipicturefillformat/#setTileAlignment-byte-): Xác định cách căn chỉnh các ô gạch trong hình dạng.
- [setTileFlip](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ipicturefillformat/#setTileFlip-int-): Kiểm soát việc lật ô gạch theo chiều ngang, dọc hoặc cả hai.
- [setTileOffsetX](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ipicturefillformat/#setTileOffsetX-float-): Đặt độ dịch chuyển ngang của ô gạch (theo điểm) so với nguồn gốc của hình dạng.
- [setTileOffsetY](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ipicturefillformat/#setTileOffsetY-float-): Đặt độ dịch chuyển dọc của ô gạch (theo điểm) so với nguồn gốc của hình dạng.
- [setTileScaleX](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ipicturefillformat/#setTileScaleX-float-): Xác định tỷ lệ ngang của ô gạch dưới dạng phần trăm.
- [setTileScaleY](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ipicturefillformat/#setTileScaleY-float-): Xác định tỷ lệ dọc của ô gạch dưới dạng phần trăm.

Mã mẫu dưới đây cho thấy cách thêm một hình chữ nhật với độ đổ hình ảnh dạng gạch và cấu hình các tùy chọn gạch:

```java
// Khởi tạo lớp Presentation đại diện cho một tệp bài thuyết trình.
Presentation presentation = new Presentation();
try {
    // Lấy slide đầu tiên.
    ISlide firstSlide = presentation.getSlides().get_Item(0);

    // Thêm một hình tự động hình chữ nhật.
    IAutoShape shape = firstSlide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 190, 95);

    // Đặt kiểu tô của hình thành Picture.
    shape.getFillFormat().setFillType(FillType.Picture);

    // Tải hình ảnh và thêm nó vào các tài nguyên của bài thuyết trình.
    IImage sourceImage = Images.fromFile("lotus.png");
    IPPImage presentationImage = presentation.getImages().addImage(sourceImage);
    sourceImage.dispose();

    // Gán hình ảnh cho hình dạng.
    IPictureFillFormat pictureFillFormat = shape.getFillFormat().getPictureFillFormat();
    pictureFillFormat.getPicture().setImage(presentationImage);

    // Cấu hình chế độ độ đổ hình ảnh và các thuộc tính gạch.
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

![Các tùy chọn gạch](tile-options.png)

## **Đổ màu Đơn**

Trong PowerPoint, Đổ màu Đơn là một tùy chọn định dạng giúp lấp đầy hình dạng bằng một màu duy nhất, đồng nhất. Màu nền đơn giản này được áp dụng mà không có gradient, kết cấu hay mẫu nào.

Để áp dụng độ đổ màu đơn cho một hình dạng bằng Aspose.Slides, hãy thực hiện các bước sau:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation/) .
1. Lấy tham chiếu đến một slide theo chỉ mục của nó.
1. Thêm một [IAutoShape](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iautoshape/) vào slide.
1. Đặt [FillType](https://reference.aspose.com/slides/vi/java/com.aspose.slides/filltype/) của hình dạng thành `Solid`.
1. Gán màu tô ưa thích của bạn cho hình dạng.
1. Lưu bản trình chiếu đã sửa đổi dưới dạng tệp PPTX.

Mã Java dưới đây minh họa cách áp dụng độ đổ màu đơn cho một hình chữ nhật trong slide PowerPoint:

```java
// Khởi tạo lớp Presentation đại diện cho một tệp bài thuyết trình.
Presentation presentation = new Presentation();
try {
    // Lấy slide đầu tiên.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Thêm một hình tự động loại Rectangle.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Đặt kiểu tô là Solid.
    shape.getFillFormat().setFillType(FillType.Solid);

    // Đặt màu tô.
    shape.getFillFormat().getSolidFillColor().setColor(Color.YELLOW);

    // Lưu tệp PPTX vào đĩa.
    presentation.save("solid_color_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Kết quả:

![Hình dạng với độ đổ màu đơn](solid-color-fill.png)

## **Đặt Độ trong suốt**

Trong PowerPoint, khi bạn áp dụng một màu đơn, gradient, hình ảnh hoặc kết cấu cho các hình dạng, bạn cũng có thể đặt mức độ trong suốt để kiểm soát độ mờ của phần tô. Giá trị trong suốt cao hơn sẽ làm cho hình dạng trở nên trong suốt hơn, cho phép nền hoặc các đối tượng phía dưới được nhìn thấy một phần.

Aspose.Slides cho phép bạn đặt mức độ trong suốt bằng cách điều chỉnh giá trị alpha trong màu được sử dụng để tô. Đây là cách thực hiện:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation/) .
1. Lấy tham chiếu đến một slide theo chỉ mục của nó.
1. Thêm một [IAutoShape](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iautoshape/) vào slide.
1. Đặt [FillType](https://reference.aspose.com/slides/vi/java/com.aspose.slides/filltype/) thành `Solid`.
1. Sử dụng `Color` để định nghĩa một màu có độ trong suốt (thành phần `alpha` kiểm soát độ trong suốt).
1. Lưu bản trình chiếu.

Mã Java dưới đây minh họa cách áp dụng màu tô trong suốt cho một hình chữ nhật:

```java
// Khởi tạo lớp Presentation đại diện cho một tệp bài thuyết trình.
Presentation presentation = new Presentation();
try {
    // Lấy slide đầu tiên.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Thêm một hình tự động hình chữ nhật đặc.
    IAutoShape solidShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Thêm một hình tự động hình chữ nhật trong suốt lên trên hình đặc.
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

Aspose.Slides cho phép bạn xoay các hình dạng trong các bài thuyết trình PowerPoint. Điều này có thể hữu ích khi định vị các yếu tố hình ảnh với yêu cầu căn chỉnh hoặc thiết kế cụ thể.

Để xoay một hình dạng trên slide, hãy thực hiện các bước sau:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation/) .
1. Lấy tham chiếu đến một slide theo chỉ mục của nó.
1. Thêm một [IAutoShape](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iautoshape/) vào slide.
1. Đặt thuộc tính xoay của hình dạng thành góc mong muốn.
1. Lưu bản trình chiếu.

Mã Java dưới đây minh họa cách xoay một hình dạng 5 độ:

```java
// Khởi tạo lớp Presentation đại diện cho một tệp bài thuyết trình.
Presentation presentation = new Presentation();
try {
    // Lấy slide đầu tiên.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Thêm một hình tự động loại Rectangle.
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

## **Thêm Hiệu ứng Viền 3D**

Aspose.Slides cho phép bạn áp dụng các hiệu ứng viền 3D cho các hình dạng bằng cách cấu hình các thuộc tính [ThreeDFormat](https://reference.aspose.com/slides/vi/java/com.aspose.slides/threedformat/) của chúng.

Để thêm hiệu ứng viền 3D cho một hình dạng, hãy thực hiện các bước sau:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation/) .
1. Lấy tham chiếu đến một slide theo chỉ mục của nó.
1. Thêm một [IAutoShape](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iautoshape/) vào slide.
1. Cấu hình [ThreeDFormat](https://reference.aspose.com/slides/vi/java/com.aspose.slides/threedformat/) của hình dạng để định nghĩa các thiết lập viền.
1. Lưu bản trình chiếu.

Mã Java dưới đây cho thấy cách áp dụng hiệu ứng viền 3D cho một hình dạng:

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

    // Set the shape's ThreeDFormat properties.
    shape.getThreeDFormat().setDepth(4);
    shape.getThreeDFormat().getBevelTop().setBevelType(BevelPresetType.Circle);
    shape.getThreeDFormat().getBevelTop().setHeight(6);
    shape.getThreeDFormat().getBevelTop().setWidth(6);
    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.ThreePt);
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);

    // Save the presentation as a PPTX file.
    presentation.save("3D_bevel_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Kết quả:

![Hiệu ứng viền 3D](3D-bevel-effect.png)

## **Thêm Hiệu ứng Xoay 3D**

Aspose.Slides cho phép bạn áp dụng các hiệu ứng xoay 3D cho các hình dạng bằng cách cấu hình các thuộc tính [ThreeDFormat](https://reference.aspose.com/slides/vi/java/com.aspose.slides/threedformat/) của chúng.

Để áp dụng xoay 3D cho một hình dạng:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation/) .
1. Lấy tham chiếu đến một slide theo chỉ mục của nó.
1. Thêm một [IAutoShape](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iautoshape/) vào slide.
1. Sử dụng [setCameraType](https://reference.aspose.com/slides/vi/java/com.aspose.slides/icamera/#setCameraType-int-) và [setLightType](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ilightrig/#setLightType-int-) để định nghĩa xoay 3D.
1. Lưu bản trình chiếu.

Mã Java dưới đây minh họa cách áp dụng hiệu ứng xoay 3D cho một hình dạng:

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

    // Lưu bài thuyết trình dưới dạng tệp PPTX.
    presentation.save("3D_rotation_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Kết quả:

![Hiệu ứng xoay 3D](3D-rotation-effect.png)

## **Đặt lại Định dạng**

Mã Java dưới đây cho thấy cách đặt lại định dạng của một slide và khôi phục vị trí, kích thước và định dạng của tất cả các hình dạng có placeholder trên [LayoutSlide](https://reference.aspose.com/slides/vi/java/com.aspose.slides/layoutslide/) về trạng thái mặc định:

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        // Đặt lại mỗi hình dạng trên slide có placeholder trong bố cục.
        slide.reset();
    }
    presentation.save("reset_formatting.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Định dạng hình dạng có ảnh hưởng đến kích thước file bài thuyết trình cuối cùng không?**

Chỉ ảnh hưởng rất ít. Các hình ảnh và phương tiện nhúng chiếm phần lớn không gian file, trong khi các tham số hình dạng như màu, hiệu ứng và gradient được lưu dưới dạng siêu dữ liệu và gần như không làm tăng kích thước.

**Làm sao tôi có thể phát hiện các hình dạng trên một slide có cùng định dạng để có thể nhóm chúng?**

So sánh các thuộc tính định dạng chính của mỗi hình dạng—các cài đặt fill, line và effect. Nếu tất cả các giá trị tương ứng khớp nhau, coi kiểu của chúng là giống nhau và nhóm logic các hình dạng đó, giúp việc quản lý kiểu sau này trở nên đơn giản hơn.

**Tôi có thể lưu một bộ các kiểu dạng tùy chỉnh vào một file riêng để tái sử dụng trong các bài thuyết trình khác không?**

Có. Lưu các hình mẫu có kiểu mong muốn vào một slide mẫu hoặc tệp .POTX. Khi tạo bài thuyết trình mới, mở mẫu, sao chép các hình đã định kiểu cần thiết và áp dụng lại định dạng của chúng ở bất kỳ vị trí nào cần thiết.