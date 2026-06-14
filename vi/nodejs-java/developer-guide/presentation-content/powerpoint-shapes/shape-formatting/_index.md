---
title: Định dạng các hình dạng PowerPoint trong JavaScript
linktitle: Định dạng hình dạng
type: docs
weight: 20
url: /vi/nodejs-java/shape-formatting/
keywords:
- định dạng hình dạng
- định dạng đường viền
- định dạng kiểu nối
- đổ gradient
- đổ mẫu
- đổ hình ảnh
- đổ texture
- đổ màu đơn
- độ trong suốt hình dạng
- xoay hình dạng
- hiệu ứng bo 3D
- hiệu ứng xoay 3D
- đặt lại định dạng
- PowerPoint
- bản trình chiếu
- Node.js
- JavaScript
- Aspose.Slides
description: "Định dạng các hình dạng PowerPoint bằng JavaScript sử dụng Aspose.Slides—đặt các kiểu tô, đường viền và hiệu ứng cho tệp PPT, PPTX và ODP một cách chính xác và kiểm soát đầy đủ."
---
## **Giới thiệu**

Trong PowerPoint, bạn có thể thêm các hình dạng vào các slide. Vì các hình dạng được tạo thành từ các đường, bạn có thể định dạng chúng bằng cách chỉnh sửa hoặc áp dụng hiệu ứng cho viền của chúng. Ngoài ra, bạn có thể định dạng các hình dạng bằng cách chỉ định các cài đặt kiểm soát cách nội bộ của chúng được tô.

![Định dạng hình dạng PowerPoint](format-shape-powerpoint.png)

Aspose.Slides cho Node.js qua Java cung cấp các lớp và phương thức cho phép bạn định dạng các hình dạng bằng các tùy chọn giống như trong PowerPoint.

## **Định dạng Đường viền**

Sử dụng Aspose.Slides, bạn có thể chỉ định kiểu đường viền tùy chỉnh cho một hình dạng. Các bước sau mô tả quy trình:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/).
1. Lấy một tham chiếu tới slide theo chỉ mục của nó.
1. Thêm một [AutoShape](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/autoshape/) vào slide.
1. Đặt [định dạng đường viền](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/linestyle/) cho hình dạng.
1. Đặt độ rộng của đường viền.
1. Đặt [định dạng gạch đứt](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/linedashstyle/) cho đường viền.
1. Đặt màu đường viền cho hình dạng.
1. Lưu bản trình chiếu đã chỉnh sửa dưới dạng tệp PPTX.

Mã sau đây minh họa cách định dạng một `AutoShape` hình chữ nhật:

```js
// Khởi tạo lớp Presentation đại diện cho tệp trình chiếu.
let presentation = new aspose.slides.Presentation();
try {
    // Lấy slide đầu tiên.
    let slide = presentation.getSlides().get_Item(0);

    // Thêm một auto shape loại Rectangle.
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 150, 150, 75);

    // Đặt màu tô cho hình dạng rectangle.
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

    // Áp dụng định dạng cho các đường của rectangle.
    shape.getLineFormat().setStyle(java.newByte(aspose.slides.LineStyle.ThickThin));
    shape.getLineFormat().setWidth(7);
    shape.getLineFormat().setDashStyle(java.newByte(aspose.slides.LineDashStyle.Dash));

    // Đặt màu cho đường viền của rectangle.
    shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));

    // Lưu tệp PPTX vào đĩa.
    presentation.save("formatted_lines.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Kết quả:

![Các đường viền đã định dạng trong bản trình chiếu](formatted-lines.png)

## **Định dạng Kiểu Nối**

Dưới đây là ba tùy chọn kiểu nối:

* Round
* Miter
* Bevel

Trong PowerPoint, mặc định khi nối hai đường ở một góc (như ở góc của một hình dạng), nó sử dụng cài đặt **Round**. Tuy nhiên, nếu bạn vẽ một hình dạng có góc sắc, bạn có thể muốn chọn tùy chọn **Miter**.

![Kiểu nối trong bản trình chiếu](join-style-powerpoint.png)

Mã JavaScript sau đây minh họa cách tạo ba hình chữ nhật (như trong hình trên) bằng các cài đặt kiểu nối Miter, Bevel và Round:

```js
// Khởi tạo lớp Presentation đại diện cho tệp trình chiếu.
let presentation = new aspose.slides.Presentation();
try {
    // Lấy slide đầu tiên.
    let slide = presentation.getSlides().get_Item(0);

    // Thêm ba auto shape loại Rectangle.
    let shape1 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 150, 75);
    let shape2 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 210, 20, 150, 75);
    let shape3 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 135, 150, 75);

    // Đặt màu tô cho mỗi hình chữ nhật.
    shape1.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape1.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    shape2.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape2.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    shape3.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape3.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));

    // Đặt độ rộng đường viền.
    shape1.getLineFormat().setWidth(15);
    shape2.getLineFormat().setWidth(15);
    shape3.getLineFormat().setWidth(15);

    // Đặt màu cho đường viền của mỗi hình chữ nhật.
    shape1.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape1.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    shape2.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape2.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    shape3.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape3.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));

    // Đặt kiểu nối.
    shape1.getLineFormat().setJoinStyle(java.newByte(aspose.slides.LineJoinStyle.Miter));
    shape2.getLineFormat().setJoinStyle(java.newByte(aspose.slides.LineJoinStyle.Bevel));
    shape3.getLineFormat().setJoinStyle(java.newByte(aspose.slides.LineJoinStyle.Round));

    // Thêm văn bản vào mỗi hình chữ nhật.
    shape1.getTextFrame().setText("Miter Join Style");
    shape2.getTextFrame().setText("Bevel Join Style");
    shape3.getTextFrame().setText("Round Join Style");

    // Lưu tệp PPTX vào đĩa.
    presentation.save("join_styles.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Đổ Gradient**

Trong PowerPoint, Đổ Gradient là một tùy chọn định dạng cho phép bạn áp dụng một dải màu liên tục vào một hình dạng. Ví dụ, bạn có thể áp dụng hai hoặc nhiều màu sao cho một màu dần chuyển sang màu khác.

Cách áp dụng Đổ Gradient cho một hình dạng bằng Aspose.Slides:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/).
1. Lấy một tham chiếu tới slide theo chỉ mục của nó.
1. Thêm một [AutoShape](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/autoshape/) vào slide.
1. Đặt [FillType](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/filltype/) của hình dạng thành `Gradient`.
1. Thêm hai màu ưa thích của bạn với vị trí đã xác định bằng các phương thức `add` của bộ sưu tập gradient stop được cung cấp bởi lớp [GradientFormat](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/gradientformat/).
1. Lưu bản trình chiếu đã chỉnh sửa dưới dạng tệp PPTX.

Mã JavaScript sau đây minh họa cách áp dụng hiệu ứng Đổ Gradient cho một ellipse:

```js
// Khởi tạo lớp Presentation đại diện cho tệp trình chiếu.
let presentation = new aspose.slides.Presentation();
try {
    // Lấy slide đầu tiên.
    let slide = presentation.getSlides().get_Item(0);

    // Thêm một auto shape loại Ellipse.
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Ellipse, 50, 50, 150, 75);

    // Áp dụng định dạng gradient cho ellipse.
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Gradient));
    shape.getFillFormat().getGradientFormat().setGradientShape(java.newByte(aspose.slides.GradientShape.Linear));

    // Đặt hướng của gradient.
    shape.getFillFormat().getGradientFormat().setGradientDirection(aspose.slides.GradientDirection.FromCorner2);

    // Thêm hai gradient stop.
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor(1.0, aspose.slides.PresetColor.Purple);
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor(0, aspose.slides.PresetColor.Red);

    // Lưu tệp PPTX vào đĩa.
    presentation.save("gradient_fill.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Kết quả:

![Ellipse với Đổ Gradient](gradient-fill.png)

## **Đổ Pattern**

Trong PowerPoint, Đổ Pattern là một tùy chọn định dạng cho phép bạn áp dụng một thiết kế hai màu—như chấm, sọc, chéo hoặc kiểm—cho một hình dạng. Bạn có thể chọn màu tùy chỉnh cho nền và màu nền trước của pattern.

Aspose.Slides cung cấp hơn 45 kiểu pattern được định sẵn mà bạn có thể áp dụng cho các hình dạng để nâng cao tính thẩm mỹ của bản trình chiếu. Ngay cả khi đã chọn một pattern có sẵn, bạn vẫn có thể chỉ định màu chính xác cho nó.

Cách áp dụng Đổ Pattern cho một hình dạng bằng Aspose.Slides:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/).
1. Lấy một tham chiếu tới slide theo chỉ mục của nó.
1. Thêm một [AutoShape](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/autoshape/) vào slide.
1. Đặt [FillType](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/filltype/) của hình dạng thành `Pattern`.
1. Chọn một kiểu pattern từ các tùy chọn đã định sẵn.
1. Đặt [Background Color](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/patternformat/#getBackColor--) của pattern.
1. Đặt [Foreground Color](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/patternformat/#getForeColor--) của pattern.
1. Lưu bản trình chiếu đã chỉnh sửa dưới dạng tệp PPTX.

Mã JavaScript sau đây minh họa cách áp dụng Đổ Pattern cho một hình chữ nhật:

```js
// Khởi tạo lớp Presentation đại diện cho tệp trình chiếu.
let presentation = new aspose.slides.Presentation();
try {
    // Lấy slide đầu tiên.
    let slide = presentation.getSlides().get_Item(0);

    // Thêm một auto shape loại Rectangle.
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);

    // Đặt kiểu tô thành Pattern.
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Pattern));

    // Đặt kiểu mẫu.
    shape.getFillFormat().getPatternFormat().setPatternStyle(java.newByte(aspose.slides.PatternStyle.Trellis));

    // Đặt màu nền và màu nền phía trước của mẫu.
    shape.getFillFormat().getPatternFormat().getBackColor().setColor(java.getStaticFieldValue("java.awt.Color", "LIGHT_GRAY"));
    shape.getFillFormat().getPatternFormat().getForeColor().setColor(java.getStaticFieldValue("java.awt.Color", "YELLOW"));

    // Lưu tệp PPTX vào đĩa.
    presentation.save("pattern_fill.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Kết quả:

![Hình chữ nhật với Đổ Pattern](pattern-fill.png)

## **Đổ Picture**

Trong PowerPoint, Đổ Picture là một tùy chọn định dạng cho phép bạn chèn một hình ảnh vào trong một hình dạng—điều này thực chất sử dụng hình ảnh làm nền cho hình dạng.

Cách sử dụng Aspose.Slides để áp dụng Đổ Picture cho một hình dạng:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/).
1. Lấy một tham chiếu tới slide theo chỉ mục của nó.
1. Thêm một [AutoShape](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/autoshape/) vào slide.
1. Đặt [FillType](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/filltype/) của hình dạng thành `Picture`.
1. Đặt chế độ Đổ picture thành `Tile` (hoặc chế độ ưa thích khác).
1. Tạo một đối tượng [PPImage](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/ppimage/) từ hình ảnh bạn muốn sử dụng.
1. Truyền hình ảnh cho phương thức `ISlidesPicture.setImage`.
1. Lưu bản trình chiếu đã chỉnh sửa dưới dạng tệp PPTX.

Giả sử chúng ta có tệp "lotus.png" với hình ảnh sau:

![Hình ảnh lotus](lotus.png)

Mã JavaScript sau đây minh họa cách đổ picture cho một hình dạng:

```js
// Khởi tạo lớp Presentation đại diện cho tệp trình chiếu.
let presentation = new aspose.slides.Presentation();
try {
    // Lấy slide đầu tiên.
    let slide = presentation.getSlides().get_Item(0);

    // Thêm một auto shape loại Rectangle.
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 255, 130);
    
    // Đặt kiểu tô thành Picture.
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));

    // Đặt chế độ Đổ picture.
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(aspose.slides.PictureFillMode.Tile);

    // Tải một hình ảnh và thêm nó vào tài nguyên của bản trình chiếu.
    let image = aspose.slides.Images.fromFile("lotus.png");
    let picture = presentation.getImages().addImage(image);
    image.dispose();

    // Đặt picture.
    shape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);

    // Lưu tệp PPTX vào đĩa.
    presentation.save("picture_fill.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Kết quả:

![Hình dạng với Đổ Picture](picture-fill.png)

### **Tile Picture As Texture**

Nếu bạn muốn đặt một picture dạng lưới làm texture và tùy chỉnh hành vi lưới, bạn có thể sử dụng các phương thức sau của lớp [PictureFillFormat](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/picturefillformat/):

- [setPictureFillMode](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/picturefillformat/#setPictureFillMode): Đặt chế độ Đổ picture—hoặc `Tile` hoặc `Stretch`.
- [setTileAlignment](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/picturefillformat/#setTileAlignment): Xác định cách căn chỉnh các tile trong hình dạng.
- [setTileFlip](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/picturefillformat/#setTileFlip): Kiểm soát việc lật tile theo chiều ngang, chiều dọc hoặc cả hai.
- [setTileOffsetX](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/picturefillformat/#setTileOffsetX): Đặt độ dịch chuyển ngang của tile (đơn vị point) từ gốc của hình dạng.
- [setTileOffsetY](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/picturefillformat/#setTileOffsetY): Đặt độ dịch chuyển dọc của tile (đơn vị point) từ gốc của hình dạng.
- [setTileScaleX](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/picturefillformat/#setTileScaleX): Xác định tỉ lệ ngang của tile dưới dạng phần trăm.
- [setTileScaleY](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/picturefillformat/#setTileScaleY): Xác định tỉ lệ dọc của tile dưới dạng phần trăm.

Mã mẫu sau đây cho thấy cách thêm một hình chữ nhật với Đổ picture dạng lưới và cấu hình các tùy chọn tile:

```js
// Khởi tạo lớp Presentation đại diện cho một tệp trình chiếu.
let presentation = new aspose.slides.Presentation();
try {
    // Lấy slide đầu tiên.
    let firstSlide = presentation.getSlides().get_Item(0);

    // Thêm một auto shape hình chữ nhật.
    let shape = firstSlide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 190, 95);

    // Đặt kiểu tô của hình dạng thành Picture.
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));

    // Tải hình ảnh và thêm nó vào tài nguyên của bản trình chiếu.
    let sourceImage = aspose.slides.Images.fromFile("lotus.png");
    let presentationImage = presentation.getImages().addImage(sourceImage);
    sourceImage.dispose();

    // Gán hình ảnh cho hình dạng.
    let pictureFillFormat = shape.getFillFormat().getPictureFillFormat();
    pictureFillFormat.getPicture().setImage(presentationImage);

    // Cấu hình chế độ đổ picture và các thuộc tính lưới.
    pictureFillFormat.setPictureFillMode(aspose.slides.PictureFillMode.Tile);
    pictureFillFormat.setTileOffsetX(-32);
    pictureFillFormat.setTileOffsetY(-32);
    pictureFillFormat.setTileScaleX(50);
    pictureFillFormat.setTileScaleY(50);
    pictureFillFormat.setTileAlignment(java.newByte(aspose.slides.RectangleAlignment.BottomRight));
    pictureFillFormat.setTileFlip(aspose.slides.TileFlip.FlipBoth);

    // Lưu tệp PPTX vào đĩa.
    presentation.save("tile.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Kết quả:

![Các tùy chọn tile](tile-options.png)

## **Đổ Màu Đơn**

Trong PowerPoint, Đổ Màu Đơn là một tùy chọn định dạng làm đầy một hình dạng bằng một màu duy nhất, đồng nhất. Màu nền đơn giản này được áp dụng mà không có gradient, texture hay pattern nào.

Để áp dụng Đổ Màu Đơn cho một hình dạng bằng Aspose.Slides, thực hiện các bước sau:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/).
1. Lấy một tham chiếu tới slide theo chỉ mục của nó.
1. Thêm một [AutoShape](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/autoshape/) vào slide.
1. Đặt [FillType](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/filltype/) của hình dạng thành `Solid`.
1. Gán màu tô ưa thích của bạn cho hình dạng.
1. Lưu bản trình chiếu đã chỉnh sửa dưới dạng tệp PPTX.

Mã JavaScript sau đây minh họa cách áp dụng Đổ Màu Đơn cho một hình chữ nhật trong slide PowerPoint:

```js
// Khởi tạo lớp Presentation đại diện cho tệp trình chiếu.
let presentation = new aspose.slides.Presentation();
try {
    // Lấy slide đầu tiên.
    let slide = presentation.getSlides().get_Item(0);

    // Thêm một auto shape loại Rectangle.
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);

    // Đặt kiểu tô thành Solid.
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));

    // Đặt màu tô.
    shape.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "YELLOW"));

    // Lưu tệp PPTX vào đĩa.
    presentation.save("solid_color_fill.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Kết quả:

![Hình dạng với Đổ Màu Đơn](solid-color-fill.png)

## **Thiết Lập Độ Trong Suốt**

Trong PowerPoint, khi bạn áp dụng màu đơn, gradient, picture hoặc texture cho các hình dạng, bạn cũng có thể thiết lập mức độ trong suốt để kiểm soát độ mờ của màu tô. Giá trị trong suốt cao hơn sẽ làm cho hình dạng trong suốt hơn, cho phép nền hoặc các đối tượng phía sau hiển thị một phần.

Aspose.Slides cho phép bạn đặt mức độ trong suốt bằng cách điều chỉnh giá trị alpha trong màu được sử dụng cho phần tô. Cách làm:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/).
1. Lấy một tham chiếu tới slide theo chỉ mục của nó.
1. Thêm một [AutoShape](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/autoshape/) vào slide.
1. Đặt [FillType](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/filltype/) thành `Solid`.
1. Sử dụng `Color` để định nghĩa một màu có độ trong suốt (thành phần `alpha` kiểm soát độ trong suốt).
1. Lưu bản trình chiếu.

Mã JavaScript sau đây minh họa cách áp dụng màu tô trong suốt cho một hình chữ nhật:

```js
    // Khởi tạo lớp Presentation đại diện cho tệp trình chiếu.
    let presentation = new aspose.slides.Presentation();
    try {
        // Lấy slide đầu tiên.
        let slide = presentation.getSlides().get_Item(0);

        // Thêm một auto shape hình chữ nhật đặc.
        let solidShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);

        // Thêm một auto shape hình chữ nhật trong suốt lên trên hình dạng đặc.
        let transparentShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 80, 80, 150, 75);
        transparentShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
        transparentShape.getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 255, 255, 0, 204));

        // Lưu tệp PPTX vào đĩa.
        presentation.save("shape_transparency.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
```

Kết quả:

![Hình dạng trong suốt](shape-transparency.png)

## **Xoay Hình Dạng**

Aspose.Slides cho phép bạn xoay các hình dạng trong bản trình chiếu PowerPoint. Điều này hữu ích khi bạn cần định vị các phần tử trực quan với yêu cầu căn chỉnh hoặc thiết kế cụ thể.

Để xoay một hình dạng trên slide, thực hiện các bước sau:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/).
1. Lấy một tham chiếu tới slide theo chỉ mục của nó.
1. Thêm một [AutoShape](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/autoshape/) vào slide.
1. Đặt thuộc tính xoay của hình dạng thành góc mong muốn.
1. Lưu bản trình chiếu.

Mã JavaScript sau đây minh họa cách xoay một hình dạng 5 độ:

```js
// Khởi tạo lớp Presentation đại diện cho một tệp trình chiếu.
let presentation = new aspose.slides.Presentation();
try {
    // Lấy slide đầu tiên.
    let slide = presentation.getSlides().get_Item(0);

    // Thêm một auto shape loại Rectangle.
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);

    // Xoay hình dạng 5 độ.
    shape.setRotation(5);

    // Lưu tệp PPTX vào đĩa.
    presentation.save("shape_rotation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Kết quả:

![Xoay hình dạng](shape-rotation.png)

## **Thêm Hiệu Ứng Bo 3D**

Aspose.Slides cho phép bạn áp dụng hiệu ứng bo 3D cho các hình dạng bằng cách cấu hình thuộc tính [ThreeDFormat](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/threedformat/).

Để thêm hiệu ứng bo 3D cho một hình dạng, thực hiện các bước sau:

1. Khởi tạo lớp [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/).
1. Lấy một tham chiếu tới slide theo chỉ mục của nó.
1. Thêm một [AutoShape](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/autoshape/) vào slide.
1. Cấu hình [ThreeDFormat](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/threedformat/) của hình dạng để xác định các thiết lập bo.
1. Lưu bản trình chiếu.

Mã JavaScript sau đây cho thấy cách áp dụng hiệu ứng bo 3D cho một hình dạng:

```js
// Tạo một thể hiện của lớp Presentation.
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    // Thêm một hình dạng vào slide.
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Ellipse, 50, 50, 100, 100);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GREEN"));
    shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "ORANGE"));
    shape.getLineFormat().setWidth(2.0);

    // Đặt các thuộc tính ThreeDFormat của hình dạng.
    shape.getThreeDFormat().setDepth(4);
    shape.getThreeDFormat().getBevelTop().setBevelType(aspose.slides.BevelPresetType.Circle);
    shape.getThreeDFormat().getBevelTop().setHeight(6);
    shape.getThreeDFormat().getBevelTop().setWidth(6);
    shape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.ThreePt);
    shape.getThreeDFormat().getLightRig().setDirection(aspose.slides.LightingDirection.Top);

    // Lưu bản trình chiếu dưới dạng tệp PPTX.
    presentation.save("3D_bevel_effect.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Kết quả:

![Hiệu ứng bo 3D](3D-bevel-effect.png)

## **Thêm Hiệu Ứng Xoay 3D**

Aspose.Slides cho phép bạn áp dụng hiệu ứng xoay 3D cho các hình dạng bằng cách cấu hình thuộc tính [ThreeDFormat](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/threedformat/).

Để áp dụng xoay 3D cho một hình dạng:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/).
1. Lấy một tham chiếu tới slide theo chỉ mục của nó.
1. Thêm một [AutoShape](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/autoshape/) vào slide.
1. Sử dụng [setCameraType](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/camera/#setCameraType) và [setLightType](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/lightrig/#setLightType) để định nghĩa xoay 3D.
1. Lưu bản trình chiếu.

Mã JavaScript sau đây minh họa cách áp dụng hiệu ứng xoay 3D cho một hình dạng:

```js
// Tạo một thể hiện của lớp Presentation.
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);
    autoShape.getTextFrame().setText("Hello, Aspose!");

    autoShape.getThreeDFormat().setDepth(6);
    autoShape.getThreeDFormat().getCamera().setRotation(40, 35, 20);
    autoShape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.IsometricLeftUp);
    autoShape.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.Balanced);

    // Lưu bản trình chiếu dưới dạng tệp PPTX.
    presentation.save("3D_rotation_effect.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Kết quả:

![Hiệu ứng xoay 3D](3D-rotation-effect.png)

## **Đặt Lại Định Dạng**

Mã Java dưới đây cho thấy cách đặt lại định dạng của một slide và khôi phục vị trí, kích thước và định dạng của tất cả các hình dạng có placeholder trên [LayoutSlide](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/layoutslide/) về chế độ mặc định:

```js
let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    for (let i = 0; i < presentation.getSlides().size(); i++) {
        let slide = presentation.getSlides().get_Item(i);
        // Đặt lại mỗi hình dạng trên slide có placeholder trên layout.
        slide.reset();
    }
    presentation.save("reset_formatting.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Định dạng hình dạng có ảnh hưởng tới kích thước cuối cùng của tệp bản trình chiếu không?**

Chỉ ảnh hưởng rất ít. Các hình ảnh và phương tiện nhúng chiếm phần lớn không gian tệp, trong khi các tham số hình dạng như màu, hiệu ứng và gradient được lưu dưới dạng metadata và hầu như không tăng thêm dung lượng.

**Làm thế nào tôi có thể phát hiện các hình dạng trên một slide có cùng định dạng để có thể nhóm chúng lại?**

So sánh các thuộc tính định dạng chính của mỗi hình dạng—các thiết lập fill, line và effect. Nếu tất cả các giá trị tương ứng khớp nhau, coi chúng là cùng kiểu và nhóm logic các hình dạng này, giúp việc quản lý style sau này trở nên dễ dàng hơn.

**Tôi có thể lưu một bộ kiểu hình dạng tùy chỉnh vào tệp riêng để tái sử dụng trong các bản trình chiếu khác không?**

Có. Lưu các hình mẫu với style mong muốn trong một slide mẫu hoặc tệp .POTX. Khi tạo bản trình chiếu mới, mở mẫu, sao chép các hình đã style và áp dụng lại định dạng ở nơi cần.