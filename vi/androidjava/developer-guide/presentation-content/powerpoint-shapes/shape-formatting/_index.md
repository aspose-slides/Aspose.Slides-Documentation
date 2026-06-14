---
title: Định dạng các hình dạng PowerPoint trên Android
linktitle: Định dạng Hình dạng
type: docs
weight: 20
url: /vi/androidjava/shape-formatting/
keywords:
- định dạng hình dạng
- định dạng đường viền
- định dạng kiểu nối
- đổ gradient
- đổ pattern
- đổ hình ảnh
- đổ kết cấu
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
description: "Tìm hiểu cách định dạng các hình dạng PowerPoint trên Android bằng Aspose.Slides—đặt các kiểu tô, đường viền và hiệu ứng cho tệp PPT, PPTX và ODP một cách chính xác và kiểm soát đầy đủ."
---
## **Giới thiệu**

Trong PowerPoint, bạn có thể thêm các hình dạng vào các slide. Vì các hình dạng được tạo thành từ các đường, bạn có thể định dạng chúng bằng cách sửa đổi hoặc áp dụng hiệu ứng cho viền của chúng. Ngoài ra, bạn có thể định dạng các hình dạng bằng cách chỉ định các cài đặt kiểm soát cách phần bên trong của chúng được tô màu.

![format-shape-powerpoint](format-shape-powerpoint.png)

Aspose.Slides for Android qua Java cung cấp các giao diện và phương thức cho phép bạn định dạng các hình dạng bằng các tùy chọn có sẵn trong PowerPoint.

## **Định dạng Đường viền**

Sử dụng Aspose.Slides, bạn có thể chỉ định kiểu đường viền tùy chỉnh cho một hình dạng. Các bước sau mô tả quy trình:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/presentation/).
1. Lấy tham chiếu đến một slide theo chỉ mục của nó.
1. Thêm một [IAutoShape](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/iautoshape/) vào slide.
1. Đặt [line style](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/linestyle/) cho hình dạng.
1. Đặt độ rộng của đường viền.
1. Đặt [dash style](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/linedashstyle/) cho đường viền.
1. Đặt màu đường viền cho hình dạng.
1. Lưu bản trình chiếu đã sửa đổi dưới dạng tệp PPTX.

Mã sau minh họa cách định dạng một `AutoShape` hình chữ nhật:

```java
// Tạo một đối tượng Presentation đại diện cho tệp bản trình chiếu.
Presentation presentation = new Presentation();
try {
    // Lấy slide đầu tiên.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Thêm một auto shape loại Rectangle.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 150, 75);

    // Đặt màu tô cho hình dạng hình chữ nhật.
    shape.getFillFormat().setFillType(FillType.NoFill);

    // Áp dụng định dạng cho các đường viền của hình chữ nhật.
    shape.getLineFormat().setStyle(LineStyle.ThickThin);
    shape.getLineFormat().setWidth(7);
    shape.getLineFormat().setDashStyle(LineDashStyle.Dash);

    // Đặt màu cho đường viền của hình chữ nhật.
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);

    // Lưu tệp PPTX vào ổ đĩa.
    presentation.save("formatted_lines.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Kết quả:

![The formatted lines in the presentation](formatted-lines.png)

## **Định dạng Kiểu Nối**

Ba tùy chọn kiểu nối:

* Round
* Miter
* Bevel

Mặc định, khi PowerPoint nối hai đường ở một góc (như ở góc của hình dạng), nó sử dụng cài đặt **Round**. Tuy nhiên, nếu bạn đang vẽ một hình dạng có các góc nhọn, bạn có thể muốn chọn tùy chọn **Miter**.

![The join style in the presentation](join-style-powerpoint.png)

Mã Java sau minh họa cách ba hình chữ nhật (như trong hình trên) được tạo bằng các cài đặt kiểu nối Miter, Bevel và Round:

```java
// Tạo một đối tượng Presentation đại diện cho tệp bản trình chiếu.
Presentation presentation = new Presentation();
try {
    // Lấy slide đầu tiên.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Thêm ba auto shape loại Rectangle.
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

    // Đặt độ rộng đường viền.
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

    // Lưu tệp PPTX vào ổ đĩa.
    presentation.save("join_styles.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Đổ Gradient**

Trong PowerPoint, Đổ Gradient là một tùy chọn định dạng cho phép bạn áp dụng một sự pha trộn liên tục của các màu lên một hình dạng. Ví dụ, bạn có thể áp dụng hai màu hoặc nhiều màu sao cho màu này dần dần chuyển sang màu kia.

Cách áp dụng Đổ Gradient cho một hình dạng bằng Aspose.Slides:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/presentation/).
1. Lấy tham chiếu đến một slide theo chỉ mục của nó.
1. Thêm một [IAutoShape](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/iautoshape/) vào slide.
1. Đặt [FillType](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/filltype/) của hình dạng thành `Gradient`.
1. Thêm hai màu bạn muốn với vị trí xác định bằng các phương thức `add` của bộ sưu tập dừng gradient được cung cấp bởi giao diện [IGradientFormat](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/igradientformat/).
1. Lưu bản trình chiếu đã sửa đổi dưới dạng tệp PPTX.

Mã Java sau minh họa cách áp dụng hiệu ứng Đổ Gradient cho một hình ellipse:

```java
// Tạo một đối tượng Presentation đại diện cho tệp bản trình chiếu.
Presentation presentation = new Presentation();
try {
    // Lấy slide đầu tiên.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Thêm một auto shape loại Ellipse.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 50, 150, 75);

    // Áp dụng định dạng gradient cho hình ellipse.
    shape.getFillFormat().setFillType(FillType.Gradient);
    shape.getFillFormat().getGradientFormat().setGradientShape(GradientShape.Linear);

    // Đặt hướng của gradient.
    shape.getFillFormat().getGradientFormat().setGradientDirection(GradientDirection.FromCorner2);

    // Thêm hai điểm dừng gradient.
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor((float)1.0, PresetColor.Purple);
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor((float)0, PresetColor.Red);

    // Lưu tệp PPTX vào ổ đĩa.
    presentation.save("gradient_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Kết quả:

![The ellipse with gradient fill](gradient-fill.png)

## **Đổ Pattern**

Trong PowerPoint, Đổ Pattern là một tùy chọn định dạng cho phép bạn áp dụng một thiết kế hai màu—như chấm, sọc, vằn chéo hoặc kẻ ô—cho một hình dạng. Bạn có thể chọn màu tùy chỉnh cho nền và màu nền trước của mẫu.

Aspose.Slides cung cấp hơn 45 kiểu mẫu được định nghĩa sẵn mà bạn có thể áp dụng cho các hình dạng để nâng cao tính thẩm mỹ của bản trình chiếu. Ngay cả sau khi chọn một mẫu đã định sẵn, bạn vẫn có thể chỉ định các màu chính xác mà mẫu sẽ sử dụng.

Cách áp dụng Đổ Pattern cho một hình dạng bằng Aspose.Slides:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/presentation/).
1. Lấy tham chiếu đến một slide theo chỉ mục của nó.
1. Thêm một [IAutoShape](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/iautoshape/) vào slide.
1. Đặt [FillType](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/filltype/) của hình dạng thành `Pattern`.
1. Chọn một kiểu mẫu từ các tùy chọn đã định sẵn.
1. Đặt [Background Color](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/patternformat/#getBackColor--) cho mẫu.
1. Đặt [Foreground Color](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/patternformat/#getForeColor--) cho mẫu.
1. Lưu bản trình chiếu đã sửa đổi dưới dạng tệp PPTX.

Mã Java sau minh họa cách áp dụng Đổ Pattern cho một hình chữ nhật:

```java
// Tạo một đối tượng Presentation đại diện cho tệp bản trình chiếu.
Presentation presentation = new Presentation();
try {
    // Lấy slide đầu tiên.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Thêm một auto shape loại Rectangle.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Đặt kiểu tô thành Pattern.
    shape.getFillFormat().setFillType(FillType.Pattern);

    // Đặt kiểu mẫu.
    shape.getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.Trellis);

    // Đặt màu nền và màu nền trước của mẫu.
    shape.getFillFormat().getPatternFormat().getBackColor().setColor(Color.LIGHT_GRAY);
    shape.getFillFormat().getPatternFormat().getForeColor().setColor(Color.YELLOW);

    // Lưu tệp PPTX vào ổ đĩa.
    presentation.save("pattern_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Kết quả:

![The rectangle with pattern fill](pattern-fill.png)

## **Đổ Hình ảnh**

Trong PowerPoint, Đổ Hình ảnh là một tùy chọn định dạng cho phép bạn chèn một hình ảnh vào bên trong một hình dạng—nghĩa là sử dụng hình ảnh làm nền cho hình dạng.

Cách sử dụng Aspose.Slides để áp dụng Đổ Hình ảnh cho một hình dạng:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/presentation/).
1. Lấy tham chiếu đến một slide theo chỉ mục của nó.
1. Thêm một [IAutoShape](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/iautoshape/) vào slide.
1. Đặt [FillType](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/filltype/) của hình dạng thành `Picture`.
1. Đặt chế độ đổ hình ảnh thành `Tile` (hoặc chế độ ưa thích khác).
1. Tạo một đối tượng [IPPImage](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ippimage/) từ hình ảnh bạn muốn sử dụng.
1. Gửi hình ảnh tới phương thức `ISlidesPicture.setImage`.
1. Lưu bản trình chiếu đã sửa đổi dưới dạng tệp PPTX.

Giả sử chúng ta có tệp "lotus.png" với hình ảnh sau:

![The lotus picture](lotus.png)

Mã Java sau minh họa cách đổ hình ảnh vào một hình dạng:

```java
// Tạo một đối tượng Presentation đại diện cho tệp bản trình chiếu.
Presentation presentation = new Presentation();
try {
    // Lấy slide đầu tiên.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Thêm một auto shape loại Rectangle.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 255, 130);
    
    // Đặt kiểu tô thành Picture.
    shape.getFillFormat().setFillType(FillType.Picture);

    // Đặt chế độ đổ hình ảnh.
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Tile);

    // Tải một hình ảnh và thêm nó vào tài nguyên của bản trình chiếu.
    IImage image = Images.fromFile("lotus.png");
    IPPImage picture = presentation.getImages().addImage(image);
    image.dispose();

    // Đặt hình ảnh.
    shape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);

    // Lưu tệp PPTX vào ổ đĩa.
    presentation.save("picture_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Kết quả:

![The shape with picture fill](picture-fill.png)

### **Tile Picture As Texture**

Nếu bạn muốn đặt một hình ảnh lặp lại làm kết cấu và tùy chỉnh hành vi lặp lại, bạn có thể sử dụng các phương thức sau của giao diện [IPictureFillFormat](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ipicturefillformat/) và lớp [PictureFillFormat](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/picturefillformat/):

- [setPictureFillMode](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ipicturefillformat/#setPictureFillMode-int-): Đặt chế độ đổ hình ảnh—`Tile` hoặc `Stretch`.
- [setTileAlignment](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ipicturefillformat/#setTileAlignment-byte-): Xác định cách căn chỉnh các ô trong hình dạng.
- [setTileFlip](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ipicturefillformat/#setTileFlip-int-): Kiểm soát việc lật ô theo chiều ngang, chiều dọc hoặc cả hai.
- [setTileOffsetX](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ipicturefillformat/#setTileOffsetX-float-): Đặt độ lệch ngang của ô (theo điểm) từ nguồn gốc của hình dạng.
- [setTileOffsetY](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ipicturefillformat/#setTileOffsetY-float-): Đặt độ lệch dọc của ô (theo điểm) từ nguồn gốc của hình dạng.
- [setTileScaleX](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ipicturefillformat/#setTileScaleX-float-): Xác định tỉ lệ ngang của ô dưới dạng phần trăm.
- [setTileScaleY](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ipicturefillformat/#setTileScaleY-float-): Xác định tỉ lệ dọc của ô dưới dạng phần trăm.

Mã mẫu sau cho thấy cách thêm một hình chữ nhật với Đổ Hình ảnh dạng lưới và cấu hình các tùy chọn lưới:

```java
// Tạo một đối tượng Presentation đại diện cho tệp bản trình chiếu.
Presentation presentation = new Presentation();
try {
    // Lấy slide đầu tiên.
    ISlide firstSlide = presentation.getSlides().get_Item(0);

    // Thêm một auto shape dạng hình chữ nhật.
    IAutoShape shape = firstSlide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 190, 95);

    // Đặt kiểu tô của hình dạng thành Picture.
    shape.getFillFormat().setFillType(FillType.Picture);

    // Tải ảnh và thêm nó vào tài nguyên của bản trình chiếu.
    IImage sourceImage = Images.fromFile("lotus.png");
    IPPImage presentationImage = presentation.getImages().addImage(sourceImage);
    sourceImage.dispose();

    // Gán ảnh cho hình dạng.
    IPictureFillFormat pictureFillFormat = shape.getFillFormat().getPictureFillFormat();
    pictureFillFormat.getPicture().setImage(presentationImage);

    // Cấu hình chế độ đổ hình ảnh và các thuộc tính lưới.
    pictureFillFormat.setPictureFillMode(PictureFillMode.Tile);
    pictureFillFormat.setTileOffsetX(-32);
    pictureFillFormat.setTileOffsetY(-32);
    pictureFillFormat.setTileScaleX(50);
    pictureFillFormat.setTileScaleY(50);
    pictureFillFormat.setTileAlignment(RectangleAlignment.BottomRight);
    pictureFillFormat.setTileFlip(TileFlip.FlipBoth);

    // Lưu tệp PPTX vào ổ đĩa.
    presentation.save("tile.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Kết quả:

![The tile options](tile-options.png)

## **Đổ Màu Đơn**

Trong PowerPoint, Đổ Màu Đơn là một tùy chọn định dạng làm đầy hình dạng bằng một màu duy nhất, đồng nhất. Màu nền đơn này được áp dụng mà không có gradient, kết cấu hay mẫu nào.

Để áp dụng Đổ Màu Đơn cho một hình dạng bằng Aspose.Slides, thực hiện các bước sau:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/presentation/).
1. Lấy tham chiếu đến một slide theo chỉ mục của nó.
1. Thêm một [IAutoShape](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/iautoshape/) vào slide.
1. Đặt [FillType](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/filltype/) của hình dạng thành `Solid`.
1. Gán màu tô mà bạn muốn cho hình dạng.
1. Lưu bản trình chiếu đã sửa đổi dưới dạng tệp PPTX.

Mã Java sau minh họa cách áp dụng Đổ Màu Đơn cho một hình chữ nhật trong slide PowerPoint:

```java
// Tạo một đối tượng Presentation đại diện cho tệp bản trình chiếu.
Presentation presentation = new Presentation();
try {
    // Lấy slide đầu tiên.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Thêm một auto shape loại Rectangle.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Đặt kiểu tô thành Solid.
    shape.getFillFormat().setFillType(FillType.Solid);

    // Đặt màu tô.
    shape.getFillFormat().getSolidFillColor().setColor(Color.YELLOW);

    // Lưu tệp PPTX vào ổ đĩa.
    presentation.save("solid_color_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Kết quả:

![The shape with solid color fill](solid-color-fill.png)

## **Đặt Độ Trong Suốt**

Trong PowerPoint, khi bạn áp dụng màu đơn, gradient, hình ảnh hoặc kết cấu cho các hình dạng, bạn cũng có thể đặt mức độ trong suốt để kiểm soát độ mờ của phần tô. Giá trị trong suốt cao hơn làm cho hình dạng trong suốt hơn, cho phép nền hoặc các đối tượng bên dưới hiển thị một phần.

Aspose.Slides cho phép bạn đặt mức độ trong suốt bằng cách điều chỉnh giá trị alpha trong màu được sử dụng cho phần tô. Cách thực hiện:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/presentation/).
1. Lấy tham chiếu đến một slide theo chỉ mục của nó.
1. Thêm một [IAutoShape](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/iautoshape/) vào slide.
1. Đặt [FillType](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/filltype/) thành `Solid`.
1. Sử dụng `Color` để định nghĩa một màu có độ trong suốt (thành phần `alpha` điều khiển độ trong suốt).
1. Lưu bản trình chiếu.

Mã Java sau minh họa cách áp dụng màu tô trong suốt cho một hình chữ nhật:

```java
// Tạo một đối tượng Presentation đại diện cho tệp bản trình chiếu.
Presentation presentation = new Presentation();
try {
    // Lấy slide đầu tiên.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Thêm một auto shape hình chữ nhật rắn.
    IAutoShape solidShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Thêm một auto shape hình chữ nhật trong suốt lên trên hình dạng rắn.
    IAutoShape transparentShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 80, 80, 150, 75);
    transparentShape.getFillFormat().setFillType(FillType.Solid);
    transparentShape.getFillFormat().getSolidFillColor().setColor(new Color(255, 255, 0, 204));

    // Lưu tệp PPTX vào ổ đĩa.
    presentation.save("shape_transparency.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Kết quả:

![The transparent shape](shape-transparency.png)

## **Xoay Hình dạng**

Aspose.Slides cho phép bạn xoay các hình dạng trong bản trình chiếu PowerPoint. Điều này hữu ích khi định vị các yếu tố hình ảnh với yêu cầu căn chỉnh hoặc thiết kế cụ thể.

Để xoay một hình dạng trên slide, thực hiện các bước sau:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/presentation/).
1. Lấy tham chiếu đến một slide theo chỉ mục của nó.
1. Thêm một [IAutoShape](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/iautoshape/) vào slide.
1. Đặt thuộc tính xoay của hình dạng thành góc mong muốn.
1. Lưu bản trình chiếu.

Mã Java sau minh họa cách xoay một hình dạng 5 độ:

```java
// Tạo một đối tượng Presentation đại diện cho tệp bản trình chiếu.
Presentation presentation = new Presentation();
try {
    // Lấy slide đầu tiên.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Thêm một auto shape loại Rectangle.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Xoay hình dạng 5 độ.
    shape.setRotation(5);

    // Lưu tệp PPTX vào ổ đĩa.
    presentation.save("shape_rotation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Kết quả:

![The shape rotation](shape-rotation.png)

## **Thêm Hiệu ứng Bo 3D**

Aspose.Slides cho phép bạn áp dụng hiệu ứng bo 3D cho các hình dạng bằng cách cấu hình thuộc tính [ThreeDFormat](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/threedformat/) của chúng.

Để thêm hiệu ứng bo 3D cho một hình dạng, thực hiện các bước sau:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/presentation/).
1. Lấy tham chiếu đến một slide theo chỉ mục của nó.
1. Thêm một [IAutoShape](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/iautoshape/) vào slide.
1. Cấu hình [ThreeDFormat](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/threedformat/) của hình dạng để định nghĩa các cài đặt bo.
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

![The 3D bevel effect](3D-bevel-effect.png)

## **Thêm Hiệu ứng Xoay 3D**

Aspose.Slides cho phép bạn áp dụng hiệu ứng xoay 3D cho các hình dạng bằng cách cấu hình thuộc tính [ThreeDFormat](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/threedformat/) của chúng.

Để áp dụng xoay 3D cho một hình dạng:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/presentation/).
1. Lấy tham chiếu đến một slide theo chỉ mục của nó.
1. Thêm một [IAutoShape](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/iautoshape/) vào slide.
1. Sử dụng [setCameraType](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/icamera/#setCameraType-int-) và [setLightType](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ilightrig/#setLightType-int-) để định nghĩa xoay 3D.
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

![The 3D rotation effect](3D-rotation-effect.png)

## **Đặt Lại Định dạng**

Mã Java sau cho thấy cách đặt lại định dạng của một slide và khôi phục vị trí, kích thước và định dạng của tất cả các hình dạng có placeholder trên [LayoutSlide](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/layoutslide/) về cài đặt mặc định:

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        // Đặt lại mỗi hình dạng trên slide có placeholder trong layout.
        slide.reset();
    }
    presentation.save("reset_formatting.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Câu hỏi thường gặp**

**Định dạng hình dạng có ảnh hưởng đến kích thước cuối cùng của tệp bản trình chiếu không?**

Chỉ ảnh hưởng rất ít. Các hình ảnh và phương tiện nhúng chiếm phần lớn không gian tệp, trong khi các tham số hình dạng như màu, hiệu ứng và gradient được lưu dưới dạng siêu dữ liệu và gần như không làm tăng kích thước.

**Làm sao tôi có thể phát hiện các hình dạng trên một slide có cùng định dạng để nhóm chúng lại?**

So sánh các thuộc tính định dạng chính của mỗi hình dạng—cài đặt fill, line và effect. Nếu tất cả các giá trị tương ứng khớp nhau, coi kiểu của chúng là giống nhau và nhóm các hình dạng đó lại, giúp việc quản lý kiểu sau này trở nên đơn giản hơn.

**Tôi có thể lưu một bộ các kiểu hình dạng tùy chỉnh vào một tệp riêng để sử dụng lại trong các bản trình chiếu khác không?**

Có. Lưu các hình mẫu với kiểu mong muốn trong một slide mẫu hoặc tệp .POTX. Khi tạo bản trình chiếu mới, mở mẫu, sao chép các hình đã định dạng bạn cần và áp dụng lại định dạng của chúng ở nơi cần thiết.