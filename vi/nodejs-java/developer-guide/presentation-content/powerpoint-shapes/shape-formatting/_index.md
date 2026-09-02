---
title: Định dạng các hình dạng PowerPoint trong JavaScript
linktitle: Định dạng Hình dạng
type: docs
weight: 20
url: /vi/nodejs-java/shape-formatting/
keywords:
- định dạng hình dạng
- định dạng đường
- hiệu ứng phác thảo
- đường viền hình dạng phác thảo
- định dạng kiểu nối
- đổ màu gradient
- đổ mẫu
- đổ hình ảnh
- đổ texture
- đổ màu đồng nhất
- độ trong suốt hình dạng
- xoay hình dạng
- hiệu ứng bevel 3D
- hiệu ứng quay 3D
- đặt lại định dạng
- PowerPoint
- bản trình bày
- Node.js
- JavaScript
- Aspose.Slides
description: "Định dạng các hình dạng PowerPoint trong JavaScript bằng Aspose.Slides—đặt các kiểu tô, đường và hiệu ứng cho tệp PPT, PPTX và ODP với độ chính xác và kiểm soát toàn diện."
---
## **Giới thiệu**

Trong PowerPoint, bạn có thể thêm các hình dạng vào các slide. Vì các hình dạng được tạo thành từ các đường, bạn có thể định dạng chúng bằng cách chỉnh sửa hoặc áp dụng các hiệu ứng lên đường viền. Ngoài ra, bạn có thể định dạng các hình dạng bằng cách chỉ định các cài đặt kiểm soát cách phần bên trong của chúng được tô đầy.

![format-shape-powerpoint](format-shape-powerpoint.png)

Aspose.Slides for Node.js via Java cung cấp các lớp và phương thức cho phép bạn định dạng các hình dạng bằng các tùy chọn giống như trong PowerPoint.

## **Định dạng Đường**

Sử dụng Aspose.Slides, bạn có thể chỉ định kiểu đường tùy chỉnh cho một hình dạng. Các bước sau mô tả quy trình:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/).
2. Lấy một tham chiếu tới slide theo chỉ mục của nó.
3. Thêm một [AutoShape](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/autoshape/) vào slide.
4. Đặt [line style](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/linestyle/) cho hình dạng.
5. Đặt độ rộng của đường.
6. Đặt [dash style](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/linedashstyle/) cho đường.
7. Đặt màu đường cho hình dạng.
8. Lưu bản trình bày đã sửa đổi dưới dạng tệp PPTX.

Đoạn mã sau minh họa cách định dạng một `AutoShape` hình chữ nhật:

```js
// Khởi tạo lớp Presentation đại diện cho tệp bản trình bày.
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

    // Đặt màu cho đường của rectangle.
    shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));

    // Lưu tệp PPTX vào đĩa.
    presentation.save("formatted_lines.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Kết quả:

![Các đường đã định dạng trong bản trình bày](formatted-lines.png)

## **Áp dụng hiệu ứng Sketch cho Đường viền Hình dạng**

Hiệu ứng sketch làm cho đường viền của hình dạng trông như được vẽ tay. Sử dụng [Shape.getLineFormat](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/shape/) để truy cập cài đặt đường, [LineFormat.getSketchFormat](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/lineformat/) để truy cập cài đặt sketch, và [SketchFormat.setSketchType](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/sketchformat/) để chọn một giá trị trong enum [LineSketchType](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/linesketchtype/).

Đoạn mã JavaScript sau cho thấy cách áp dụng hiệu ứng [LineSketchType.Curved](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/linesketchtype/), đọc giá trị được gán một cách rõ ràng, và loại bỏ hiệu ứng bằng [LineSketchType.None](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/linesketchtype/):

```js
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 200, 100);

    // Truy cập định dạng đường của hình dạng và định dạng sketch của nó.
    let sketchFormat = shape.getLineFormat().getSketchFormat();

    // Áp dụng hiệu ứng sketch.
    sketchFormat.setSketchType(aspose.slides.LineSketchType.Curved);

    // Đọc hiệu ứng sketch được gán trực tiếp cho hình dạng.
    let explicitSketchType = sketchFormat.getSketchType();
    console.log("Explicit sketch type: " + explicitSketchType);

    // Xóa hiệu ứng sketch.
    sketchFormat.setSketchType(aspose.slides.LineSketchType.None);
} finally {
    presentation.dispose();
}
```

Giá trị trả về bởi [SketchFormat.getSketchType](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/sketchformat/) đại diện cho cài đặt được gán trực tiếp cho hình dạng. Nếu định dạng đường có thể được kế thừa từ chủ đề, slide mẫu hoặc slide bố trí, hãy sử dụng [LineFormat.getEffective](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/lineformat/), gọi `getSketchFormat` trên đối tượng trả về, sau đó gọi phương thức `getSketchType` của nó. Giá trị hiệu quả phản ánh định dạng thực sự được áp dụng sau khi giải quyết kế thừa:

```js
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    let lineFormat = shape.getLineFormat();

    let explicitSketchType = lineFormat.getSketchFormat().getSketchType();
    let effectiveLineFormat = lineFormat.getEffective();
    let effectiveSketchType = effectiveLineFormat.getSketchFormat().getSketchType();

    console.log("Explicit sketch type: " + explicitSketchType);
    console.log("Effective sketch type: " + effectiveSketchType);
} finally {
    presentation.dispose();
}
```

## **Định dạng Kiểu Nối**

Dưới đây là ba tùy chọn kiểu nối:

* Round
* Miter
* Bevel

Mặc định, khi PowerPoint nối hai đường ở một góc (ví dụ ở góc của một hình dạng), nó sử dụng cài đặt **Round**. Tuy nhiên, nếu bạn vẽ một hình dạng với các góc nhọn, bạn có thể thích tùy chọn **Miter** hơn.

![Kiểu nối trong bản trình bày](join-style-powerpoint.png)

Đoạn mã JavaScript sau minh họa cách ba hình chữ nhật (như trong hình trên) được tạo bằng các cài đặt kiểu nối Miter, Bevel và Round:

```js
// Khởi tạo lớp Presentation đại diện cho tệp bản trình bày.
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

    // Đặt độ rộng đường.
    shape1.getLineFormat().setWidth(15);
    shape2.getLineFormat().setWidth(15);
    shape3.getLineFormat().setWidth(15);

    // Đặt màu cho đường của mỗi hình chữ nhật.
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

## **Đổ màu Gradient**

Trong PowerPoint, Gradient Fill là một tùy chọn định dạng cho phép bạn áp dụng một hỗn hợp màu liên tục lên một hình dạng. Ví dụ, bạn có thể áp dụng hai hoặc nhiều màu sao cho màu này dần chuyển sang màu khác.

Dưới đây là cách áp dụng Gradient Fill cho một hình dạng bằng Aspose.Slides:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/).
2. Lấy một tham chiếu tới slide theo chỉ mục của nó.
3. Thêm một [AutoShape](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/autoshape/) vào slide.
4. Đặt [FillType](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/filltype/) của hình dạng thành `Gradient`.
5. Thêm hai màu bạn muốn với vị trí đã xác định bằng các phương thức `add` của bộ sưu tập gradient stop được cung cấp bởi lớp [GradientFormat](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/gradientformat/).
6. Lưu bản trình bày đã sửa đổi dưới dạng tệp PPTX.

Đoạn mã JavaScript sau minh họa cách áp dụng hiệu ứng Gradient Fill cho một ellipse:

```js
// Khởi tạo lớp Presentation đại diện cho tệp bản trình bày.
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

    // Thêm hai điểm dừng gradient.
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor(1.0, aspose.slides.PresetColor.Purple);
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor(0, aspose.slides.PresetColor.Red);

    // Lưu tệp PPTX vào đĩa.
    presentation.save("gradient_fill.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Kết quả:

![Ellipse với Gradient Fill](gradient-fill.png)

## **Pattern Fill**

Trong PowerPoint, Pattern Fill là một tùy chọn định dạng cho phép bạn áp dụng một thiết kế hai màu—như chấm, sọc, vân chéo hoặc caro—cho một hình dạng. Bạn có thể chọn màu tùy chỉnh cho nền trước và nền sau của mẫu.

Aspose.Slides cung cấp hơn 45 kiểu mẫu được định nghĩa trước mà bạn có thể áp dụng cho các hình dạng để tăng tính thẩm mỹ cho bản trình bày. Ngay cả sau khi chọn một mẫu đã định nghĩa, bạn vẫn có thể chỉ định màu chính xác mà nó sẽ sử dụng.

Đây là cách áp dụng Pattern Fill cho một hình dạng bằng Aspose.Slides:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/).
2. Lấy một tham chiếu tới slide theo chỉ mục của nó.
3. Thêm một [AutoShape](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/autoshape/) vào slide.
4. Đặt [FillType](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/filltype/) của hình dạng thành `Pattern`.
5. Chọn một kiểu mẫu từ các tùy chọn đã định nghĩa trước.
6. Đặt [Background Color](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/patternformat/#getBackColor--) của mẫu.
7. Đặt [Foreground Color](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/patternformat/#getForeColor--) của mẫu.
8. Lưu bản trình bày đã sửa đổi dưới dạng tệp PPTX.

Đoạn mã JavaScript sau minh họa cách áp dụng Pattern Fill cho một hình chữ nhật:

```js
// Khởi tạo lớp Presentation đại diện cho tệp bản trình bày.
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

    // Đặt màu nền và màu nền trước của mẫu.
    shape.getFillFormat().getPatternFormat().getBackColor().setColor(java.getStaticFieldValue("java.awt.Color", "LIGHT_GRAY"));
    shape.getFillFormat().getPatternFormat().getForeColor().setColor(java.getStaticFieldValue("java.awt.Color", "YELLOW"));

    // Lưu tệp PPTX vào đĩa.
    presentation.save("pattern_fill.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Kết quả:

![Hình chữ nhật với Pattern Fill](pattern-fill.png)

## **Picture Fill**

Trong PowerPoint, Picture Fill là một tùy chọn định dạng cho phép bạn chèn một hình ảnh vào bên trong một hình dạng—thực chất sử dụng hình ảnh làm nền cho hình dạng.

Dưới đây là cách sử dụng Aspose.Slides để áp dụng Picture Fill cho một hình dạng:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/).
2. Lấy một tham chiếu tới slide theo chỉ mục của nó.
3. Thêm một [AutoShape](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/autoshape/) vào slide.
4. Đặt [FillType](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/filltype/) của hình dạng thành `Picture`.
5. Đặt chế độ Picture Fill thành `Tile` (hoặc chế độ khác bạn muốn).
6. Tạo một đối tượng [PPImage](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/ppimage/) từ hình ảnh bạn muốn sử dụng.
7. Truyền hình ảnh cho phương thức `ISlidesPicture.setImage`.
8. Lưu bản trình bày đã sửa đổi dưới dạng tệp PPTX.

Giả sử chúng ta có một tệp "lotus.png" với hình ảnh sau:

![Hình lotus](lotus.png)

Đoạn mã JavaScript sau minh họa cách đổ hình dạng bằng ảnh:

```js
// Khởi tạo lớp Presentation đại diện cho tệp bản trình bày.
let presentation = new aspose.slides.Presentation();
try {
    // Lấy slide đầu tiên.
    let slide = presentation.getSlides().get_Item(0);

    // Thêm một auto shape loại Rectangle.
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 255, 130);
    
    // Đặt kiểu tô thành Picture.
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));

    // Đặt chế độ picture fill.
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(aspose.slides.PictureFillMode.Tile);

    // Tải một hình ảnh và thêm nó vào tài nguyên của bản trình bày.
    let image = aspose.slides.Images.fromFile("lotus.png");
    let picture = presentation.getImages().addImage(image);
    image.dispose();

    // Đặt hình ảnh.
    shape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);

    // Lưu tệp PPTX vào đĩa.
    presentation.save("picture_fill.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Kết quả:

![Hình dạng với Picture Fill](picture-fill.png)

### **Tile Picture As Texture**

Nếu bạn muốn đặt một ảnh dạng gạch làm texture và tùy chỉnh hành vi gạch, bạn có thể sử dụng các phương thức sau của lớp [PictureFillFormat](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/picturefillformat/):

- [setPictureFillMode](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/picturefillformat/#setPictureFillMode): Đặt chế độ Picture Fill—hoặc `Tile` hoặc `Stretch`.
- [setTileAlignment](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/picturefillformat/#setTileAlignment): Xác định cách căn chỉnh các ô gạch trong hình dạng.
- [setTileFlip](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/picturefillformat/#setTileFlip): Điều khiển việc lật ô gạch theo chiều ngang, chiều dọc hoặc cả hai.
- [setTileOffsetX](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/picturefillformat/#setTileOffsetX): Đặt độ lệch ngang của ô gạch (theo điểm) so với nguồn gốc của hình dạng.
- [setTileOffsetY](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/picturefillformat/#setTileOffsetY): Đặt độ lệch dọc của ô gạch (theo điểm) so với nguồn gốc của hình dạng.
- [setTileScaleX](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/picturefillformat/#setTileScaleX): Xác định tỉ lệ ngang của ô gạch dưới dạng phần trăm.
- [setTileScaleY](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/picturefillformat/#setTileScaleY): Xác định tỉ lệ dọc của ô gạch dưới dạng phần trăm.

Đoạn mã mẫu sau cho thấy cách thêm một hình chữ nhật với Picture Fill dạng gạch và cấu hình các tùy chọn gạch:

```js
// Khởi tạo lớp Presentation đại diện cho tệp bản trình bày.
let presentation = new aspose.slides.Presentation();
try {
    // Lấy slide đầu tiên.
    let firstSlide = presentation.getSlides().get_Item(0);

    // Thêm một auto shape hình chữ nhật.
    let shape = firstSlide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 190, 95);

    // Đặt kiểu tô của hình dạng thành Picture.
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));

    // Tải hình ảnh và thêm nó vào tài nguyên của bản trình bày.
    let sourceImage = aspose.slides.Images.fromFile("lotus.png");
    let presentationImage = presentation.getImages().addImage(sourceImage);
    sourceImage.dispose();

    // Gán hình ảnh cho hình dạng.
    let pictureFillFormat = shape.getFillFormat().getPictureFillFormat();
    pictureFillFormat.getPicture().setImage(presentationImage);

    // Cấu hình chế độ picture fill và các thuộc tính gạch.
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

![Các tùy chọn gạch](tile-options.png)

## **Solid Color Fill**

Trong PowerPoint, Solid Color Fill là một tùy chọn định dạng mà lấp đầy một hình dạng bằng một màu duy nhất, đồng nhất. Màu nền đơn giản này được áp dụng mà không có gradient, texture hay pattern nào.

Để áp dụng Solid Color Fill cho một hình dạng bằng Aspose.Slides, thực hiện các bước sau:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/).
2. Lấy một tham chiếu tới slide theo chỉ mục của nó.
3. Thêm một [AutoShape](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/autoshape/) vào slide.
4. Đặt [FillType](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/filltype/) của hình dạng thành `Solid`.
5. Gán màu tô bạn muốn cho hình dạng.
6. Lưu bản trình bày đã sửa đổi dưới dạng tệp PPTX.

Đoạn mã JavaScript sau minh họa cách áp dụng Solid Color Fill cho một hình chữ nhật trong slide PowerPoint:

```js
// Khởi tạo lớp Presentation đại diện cho tệp bản trình bày.
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

![Hình dạng với Solid Color Fill](solid-color-fill.png)

## **Đặt độ trong suốt**

Trong PowerPoint, khi bạn áp dụng Solid Color, Gradient, Picture hoặc Texture Fill cho các hình dạng, bạn cũng có thể đặt mức độ trong suốt để kiểm soát độ mờ của phần tô. Giá trị trong suốt cao hơn làm cho hình dạng trong suốt hơn, cho phép nền hoặc các đối tượng phía dưới hiển thị một phần.

Aspose.Slides cho phép bạn đặt mức độ trong suốt bằng cách điều chỉnh giá trị alpha trong màu được dùng để tô. Cách thực hiện như sau:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/).
2. Lấy một tham chiếu tới slide theo chỉ mục của nó.
3. Thêm một [AutoShape](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/autoshape/) vào slide.
4. Đặt [FillType](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/filltype/) thành `Solid`.
5. Sử dụng `Color` để định nghĩa một màu có độ trong suốt (thành phần `alpha` kiểm soát độ trong suốt).
6. Lưu bản trình bày.

Đoạn mã JavaScript sau minh họa cách áp dụng màu tô trong suốt cho một hình chữ nhật:

```js
// Khởi tạo lớp Presentation đại diện cho tệp bản trình bày.
let presentation = new aspose.slides.Presentation();
try {
    // Lấy slide đầu tiên.
    let slide = presentation.getSlides().get_Item(0);

    // Thêm một auto shape hình chữ nhật đặc.
    let solidShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);

    // Thêm một auto shape hình chữ nhật trong suốt lên trên hình chữ nhật đặc.
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

## **Xoay hình dạng**

Aspose.Slides cho phép bạn xoay các hình dạng trong bản trình bày PowerPoint. Điều này hữu ích khi cần đặt các yếu tố hình ảnh với yêu cầu căn chỉnh hoặc thiết kế cụ thể.

Để xoay một hình dạng trên slide, thực hiện các bước sau:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/).
2. Lấy một tham chiếu tới slide theo chỉ mục của nó.
3. Thêm một [AutoShape](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/autoshape/) vào slide.
4. Đặt thuộc tính xoay của hình dạng thành góc mong muốn.
5. Lưu bản trình bày.

Đoạn mã JavaScript sau minh họa cách xoay một hình dạng 5 độ:

```js
// Khởi tạo lớp Presentation đại diện cho tệp bản trình bày.
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

## **Thêm hiệu ứng 3D Bevel**

Aspose.Slides cho phép bạn áp dụng hiệu ứng 3D Bevel cho các hình dạng bằng cách cấu hình các thuộc tính [ThreeDFormat](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/threedformat/) của chúng.

Để thêm hiệu ứng 3D Bevel cho một hình dạng, thực hiện các bước sau:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/).
2. Lấy một tham chiếu tới slide theo chỉ mục của nó.
3. Thêm một [AutoShape](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/autoshape/) vào slide.
4. Cấu hình [ThreeDFormat](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/threedformat/) của hình dạng để xác định các cài đặt bevel.
5. Lưu bản trình bày.

Đoạn mã JavaScript sau cho thấy cách áp dụng hiệu ứng 3D Bevel cho một hình dạng:

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

    // Đặt các thuộc tính ThreeDFormat cho hình dạng.
    shape.getThreeDFormat().setDepth(4);
    shape.getThreeDFormat().getBevelTop().setBevelType(aspose.slides.BevelPresetType.Circle);
    shape.getThreeDFormat().getBevelTop().setHeight(6);
    shape.getThreeDFormat().getBevelTop().setWidth(6);
    shape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.ThreePt);
    shape.getThreeDFormat().getLightRig().setDirection(aspose.slides.LightingDirection.Top);

    // Lưu bản trình bày dưới dạng tệp PPTX.
    presentation.save("3D_bevel_effect.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Kết quả:

![Hiệu ứng 3D Bevel](3D-bevel-effect.png)

## **Thêm hiệu ứng 3D Rotation**

Aspose.Slides cho phép bạn áp dụng hiệu ứng 3D Rotation cho các hình dạng bằng cách cấu hình các thuộc tính [ThreeDFormat](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/threedformat/) của chúng.

Để áp dụng 3D Rotation cho một hình dạng:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/).
2. Lấy một tham chiếu tới slide theo chỉ mục của nó.
3. Thêm một [AutoShape](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/autoshape/) vào slide.
4. Sử dụng [setCameraType](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/camera/#setCameraType) và [setLightType](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/lightrig/#setLightType) để xác định 3D Rotation.
5. Lưu bản trình bày.

Đoạn mã JavaScript sau minh họa cách áp dụng hiệu ứng 3D Rotation cho một hình dạng:

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

    // Lưu bản trình bày dưới dạng tệp PPTX.
    presentation.save("3D_rotation_effect.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Kết quả:

![Hiệu ứng 3D Rotation](3D-rotation-effect.png)

## **Đặt lại Định dạng**

Đoạn mã Java sau cho thấy cách đặt lại định dạng của một slide và khôi phục vị trí, kích thước và định dạng của tất cả các hình dạng có placeholder trên [LayoutSlide](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/layoutslide/) về cài đặt mặc định:

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

**Định dạng hình dạng có ảnh hưởng đến kích thước tệp bản trình bày cuối cùng không?**

Chỉ ảnh hưởng rất ít. Các hình ảnh và phương tiện nhúng chiếm phần lớn không gian tệp, trong khi các tham số hình dạng như màu sắc, hiệu ứng và gradient được lưu dưới dạng metadata và thực chất không làm tăng kích thước đáng kể.

**Làm thế nào tôi có thể phát hiện các hình dạng trên một slide có cùng định dạng để có thể nhóm chúng lại?**

So sánh các thuộc tính định dạng chính của mỗi hình dạng—cài đặt fill, line và effect. Nếu tất cả các giá trị tương ứng đều khớp, coi chúng là có cùng kiểu và nhóm chúng lại, giúp việc quản lý kiểu sau này dễ dàng hơn.

**Tôi có thể lưu một tập hợp các kiểu hình dạng tùy chỉnh vào một tệp riêng để tái sử dụng trong các bản trình bày khác không?**

Có. Lưu các hình mẫu có kiểu mong muốn trong một slide mẫu hoặc tệp template .POTX. Khi tạo bản trình bày mới, mở template, sao chép các hình dạng đã định dạng cần thiết và áp dụng lại định dạng của chúng ở nơi cần.