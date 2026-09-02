---
title: Định dạng hình dạng PowerPoint trong JavaScript
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
- hiển thị hình dạng đen-trắng
- hiển thị hình dạng thang màu xám
- xoay hình dạng
- hiệu ứng bevel 3D
- hiệu ứng xoay 3D
- đặt lại định dạng
- PowerPoint
- bản trình bày
- Node.js
- JavaScript
- Aspose.Slides
description: "Định dạng các hình dạng PowerPoint trong JavaScript bằng Aspose.Slides — thiết lập các kiểu fill, line và effect cho các tệp PPT, PPTX và ODP với độ chính xác và kiểm soát toàn diện."
---
## **Giới thiệu**

Trong PowerPoint, bạn có thể thêm các hình dạng vào các slide. Vì hình dạng được tạo thành từ các đường, bạn có thể định dạng chúng bằng cách chỉnh sửa hoặc áp dụng các hiệu ứng cho viền của chúng. Ngoài ra, bạn có thể định dạng hình dạng bằng cách chỉ định các cài đặt kiểm soát cách nội bộ của chúng được tô màu.

![Định dạng hình dạng trong PowerPoint](format-shape-powerpoint.png)

Aspose.Slides for Node.js via Java cung cấp các lớp và phương thức cho phép bạn định dạng hình dạng bằng các tùy chọn giống như trong PowerPoint.

## **Định dạng Đường**

Sử dụng Aspose.Slides, bạn có thể chỉ định kiểu đường tùy chỉnh cho một hình dạng. Các bước sau mô tả quy trình:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/) .
1. Lấy tham chiếu đến một slide theo chỉ mục của nó.
1. Thêm một [AutoShape](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/autoshape/) vào slide.
1. Đặt [line style](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/linestyle/) cho hình dạng.
1. Đặt độ rộng của đường.
1. Đặt [dash style](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/linedashstyle/) cho đường.
1. Đặt màu đường cho hình dạng.
1. Lưu bản trình bày đã chỉnh sửa dưới dạng tệp PPTX.

Đoạn mã sau đây minh họa cách định dạng một hình chữ nhật `AutoShape`:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Tạo một thể hiện của lớp Presentation đại diện cho một tệp bản trình bày.
let presentation = new aspose.slides.Presentation();
try {
    // Lấy slide đầu tiên.
    let slide = presentation.getSlides().get_Item(0);

    // Thêm một auto shape loại Rectangle.
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 150, 150, 75);

    // Xóa fill khỏi hình dạng rectangle.
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

![Các đường viền đã định dạng trong bản trình bày](formatted-lines.png)

## **Áp dụng Hiệu ứng Phác thảo cho Đường viền Hình dạng**

Hiệu ứng phác thảo làm cho đường viền của hình dạng trông như được vẽ tay. Sử dụng [Shape.getLineFormat](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/shape/) để truy cập cài đặt đường, [LineFormat.getSketchFormat](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/lineformat/) để truy cập cài đặt phác thảo, và [SketchFormat.setSketchType](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/sketchformat/) để chọn một giá trị từ liệt kê [LineSketchType](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/linesketchtype/) .

Đoạn mã JavaScript sau đây cho thấy cách áp dụng hiệu ứng [LineSketchType.Curved](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/linesketchtype/), đọc giá trị được gán một cách rõ ràng, và loại bỏ hiệu ứng bằng [LineSketchType.None](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/linesketchtype/):

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 200, 100);

    // Truy cập định dạng đường của hình dạng và định dạng phác thảo của nó.
    let sketchFormat = shape.getLineFormat().getSketchFormat();

    // Áp dụng hiệu ứng phác thảo.
    sketchFormat.setSketchType(aspose.slides.LineSketchType.Curved);

    // Đọc hiệu ứng phác thảo đã được gán trực tiếp cho hình dạng.
    let explicitSketchType = sketchFormat.getSketchType();
    console.log("Explicit sketch type: " + explicitSketchType);

    // Loại bỏ hiệu ứng phác thảo.
    sketchFormat.setSketchType(aspose.slides.LineSketchType.None);
} finally {
    presentation.dispose();
}
```

Giá trị trả về bởi [SketchFormat.getSketchType](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/sketchformat/) đại diện cho cài đặt được gán trực tiếp cho hình dạng. Nếu định dạng đường có thể được kế thừa từ chủ đề, slide chủ, hoặc slide bố cục, hãy sử dụng [LineFormat.getEffective](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/lineformat/), gọi `getSketchFormat` trên đối tượng trả về, sau đó gọi phương thức `getSketchType` của nó. Giá trị hiệu quả phản ánh định dạng thực tế được áp dụng sau khi kế thừa được giải quyết:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

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

* Tròn
* Mái cầu
* Góc xiên

Mặc định, khi PowerPoint nối hai đường ở một góc (chẳng hạn tại góc của hình dạng), nó sử dụng cài đặt **Tròn**. Tuy nhiên, nếu bạn đang vẽ một hình dạng với các góc sắc, bạn có thể muốn tùy chọn **Mái cầu**.

![Kiểu nối trong bản trình bày](join-style-powerpoint.png)

Đoạn mã JavaScript sau đây minh họa cách ba hình chữ nhật (như trong hình trên) được tạo bằng các cài đặt kiểu nối Mái cầu, Góc xiên và Tròn:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Tạo một thể hiện của lớp Presentation đại diện cho một tệp bản trình bày.
let presentation = new aspose.slides.Presentation();
try {
    // Lấy slide đầu tiên.
    let slide = presentation.getSlides().get_Item(0);

    // Thêm ba auto shape loại Rectangle.
    let shape1 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 150, 75);
    let shape2 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 210, 20, 150, 75);
    let shape3 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 135, 150, 75);

    // Đặt màu fill cho mỗi hình chữ nhật.
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

Trong PowerPoint, Đổ màu Gradient là một tùy chọn định dạng cho phép bạn áp dụng một pha trộn liên tục của các màu vào một hình dạng. Ví dụ, bạn có thể áp dụng hai màu hoặc nhiều màu sao cho màu này dần chuyển sang màu khác.

Dưới đây là cách áp dụng đổ màu gradient cho một hình dạng bằng Aspose.Slides:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/) .
1. Lấy tham chiếu đến một slide theo chỉ mục của nó.
1. Thêm một [AutoShape](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/autoshape/) vào slide.
1. Đặt [FillType](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/filltype/) của hình dạng thành `Gradient`.
1. Thêm hai màu bạn muốn với vị trí xác định bằng các phương thức `add` của bộ sưu tập gradient stop được cung cấp bởi lớp [GradientFormat](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/gradientformat/) .
1. Lưu bản trình bày đã chỉnh sửa dưới dạng tệp PPTX.

Đoạn mã JavaScript sau đây minh họa cách áp dụng hiệu ứng đổ màu gradient cho một hình ellipse:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Tạo một thể hiện của lớp Presentation đại diện cho một tệp bản trình bày.
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

![Ellipse với đổ màu gradient](gradient-fill.png)

## **Đổ mẫu**

Trong PowerPoint, Đổ mẫu là một tùy chọn định dạng cho phép bạn áp dụng một thiết kế hai màu—như chấm, sọc, vạch chéo, hoặc ô vuông—vào một hình dạng. Bạn có thể chọn màu tùy chỉnh cho nền và màu nền của mẫu.

Aspose.Slides cung cấp hơn 45 kiểu mẫu được định nghĩa sẵn mà bạn có thể áp dụng cho các hình dạng để nâng cao tính thẩm mỹ của bản trình bày. Ngay cả sau khi chọn một mẫu đã được định nghĩa, bạn vẫn có thể chỉ định các màu chính xác mà mẫu sẽ sử dụng.

Dưới đây là cách áp dụng đổ mẫu cho một hình dạng bằng Aspose.Slides:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/) .
1. Lấy tham chiếu đến một slide theo chỉ mục của nó.
1. Thêm một [AutoShape](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/autoshape/) vào slide.
1. Đặt [FillType](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/filltype/) của hình dạng thành `Pattern`.
1. Chọn một kiểu mẫu từ các tùy chọn đã định nghĩa sẵn.
1. Đặt [Background Color](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/patternformat/#getBackColor--) cho mẫu.
1. Đặt [Foreground Color](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/patternformat/#getForeColor--) cho mẫu.
1. Lưu bản trình bày đã chỉnh sửa dưới dạng tệp PPTX.

Đoạn mã JavaScript sau đây minh họa cách áp dụng đổ mẫu cho một hình chữ nhật:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Tạo một thể hiện của lớp Presentation đại diện cho một tệp bản trình bày.
let presentation = new aspose.slides.Presentation();
try {
    // Lấy slide đầu tiên.
    let slide = presentation.getSlides().get_Item(0);

    // Thêm một auto shape loại Rectangle.
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);

    // Đặt loại fill là Pattern.
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Pattern));

    // Đặt kiểu mẫu.
    shape.getFillFormat().getPatternFormat().setPatternStyle(java.newByte(aspose.slides.PatternStyle.Trellis));

    // Đặt màu nền và màu trước của mẫu.
    shape.getFillFormat().getPatternFormat().getBackColor().setColor(java.getStaticFieldValue("java.awt.Color", "LIGHT_GRAY"));
    shape.getFillFormat().getPatternFormat().getForeColor().setColor(java.getStaticFieldValue("java.awt.Color", "YELLOW"));

    // Lưu tệp PPTX vào đĩa.
    presentation.save("pattern_fill.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Kết quả:

![Hình chữ nhật với đổ mẫu](pattern-fill.png)

## **Đổ hình ảnh**

Trong PowerPoint, Đổ hình ảnh là một tùy chọn định dạng cho phép bạn chèn một hình ảnh bên trong một hình dạng—nghĩa là sử dụng hình ảnh làm nền cho hình dạng.

Dưới đây là cách sử dụng Aspose.Slides để áp dụng đổ hình ảnh cho một hình dạng:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/) .
1. Lấy tham chiếu đến một slide theo chỉ mục của nó.
1. Thêm một [AutoShape](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/autoshape/) vào slide.
1. Đặt [FillType](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/filltype/) của hình dạng thành `Picture`.
1. Đặt chế độ đổ hình ảnh thành `Tile` (hoặc chế độ khác bạn muốn).
1. Tạo một đối tượng [PPImage](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/ppimage/) từ hình ảnh bạn muốn sử dụng.
1. Truyền hình ảnh vào phương thức `ISlidesPicture.setImage` .
1. Lưu bản trình bày đã chỉnh sửa dưới dạng tệp PPTX.

Giả sử chúng ta có tệp "lotus.png" với hình ảnh sau:

![Hình ảnh bông sen](lotus.png)

Đoạn mã JavaScript sau đây minh họa cách đổ hình ảnh vào một hình dạng:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Tạo một thể hiện của lớp Presentation đại diện cho một tệp bản trình bày.
let presentation = new aspose.slides.Presentation();
try {
    // Lấy slide đầu tiên.
    let slide = presentation.getSlides().get_Item(0);

    // Thêm một auto shape loại Rectangle.
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 255, 130);
    
    // Đặt loại fill là Picture.
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));

    // Đặt chế độ đổ hình ảnh.
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(aspose.slides.PictureFillMode.Tile);

    // Tải ảnh và thêm vào tài nguyên của bản trình chiếu.
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

![Hình dạng với đổ hình ảnh](picture-fill.png)

### **Lát hình ảnh làm texture**

Nếu bạn muốn đặt một hình ảnh lát làm texture và tùy chỉnh hành vi lát, bạn có thể sử dụng các phương thức sau của lớp [PictureFillFormat](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/picturefillformat/) :

- [setPictureFillMode](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/picturefillformat/#setPictureFillMode): Đặt chế độ đổ hình ảnh—`Tile` hoặc `Stretch`.
- [setTileAlignment](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/picturefillformat/#setTileAlignment): Xác định căn chỉnh của các ô lát trong hình dạng.
- [setTileFlip](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/picturefillformat/#setTileFlip): Kiểm soát việc lật ô lát theo chiều ngang, chiều dọc hoặc cả hai.
- [setTileOffsetX](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/picturefillformat/#setTileOffsetX): Đặt khoảng dịch chiều ngang của ô lát (đơn vị điểm) so với gốc của hình dạng.
- [setTileOffsetY](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/picturefillformat/#setTileOffsetY): Đặt khoảng dịch chiều dọc của ô lát (đơn vị điểm) so với gốc của hình dạng.
- [setTileScaleX](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/picturefillformat/#setTileScaleX): Xác định tỷ lệ chiều ngang của ô lát dưới dạng phần trăm.
- [setTileScaleY](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/picturefillformat/#setTileScaleY): Xác định tỷ lệ chiều dọc của ô lát dưới dạng phần trăm.

Đoạn mã mẫu dưới đây cho thấy cách thêm một hình chữ nhật với đổ hình ảnh lát và cấu hình các tùy chọn lát:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Tạo một thể hiện của lớp Presentation đại diện cho một tệp bản trình bày.
let presentation = new aspose.slides.Presentation();
try {
    // Lấy slide đầu tiên.
    let firstSlide = presentation.getSlides().get_Item(0);

    // Thêm một auto shape hình chữ nhật.
    let shape = firstSlide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 190, 95);

    // Đặt loại fill của hình dạng thành Picture.
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));

    // Tải ảnh và thêm vào tài nguyên của bản trình chiếu.
    let sourceImage = aspose.slides.Images.fromFile("lotus.png");
    let presentationImage = presentation.getImages().addImage(sourceImage);
    sourceImage.dispose();

    // Gán ảnh cho hình dạng.
    let pictureFillFormat = shape.getFillFormat().getPictureFillFormat();
    pictureFillFormat.getPicture().setImage(presentationImage);

    // Cấu hình chế độ đổ hình ảnh và các thuộc tính lát.
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

![Các tùy chọn lát](tile-options.png)

## **Đổ màu Đơn**

Trong PowerPoint, Đổ màu Đơn là một tùy chọn định dạng làm đầy một hình dạng bằng một màu duy nhất, đồng nhất. Nền màu trơn này được áp dụng mà không có gradient, texture hay mẫu nào.

Để áp dụng đổ màu đơn cho một hình dạng bằng Aspose.Slides, thực hiện các bước sau:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/) .
1. Lấy tham chiếu đến một slide theo chỉ mục của nó.
1. Thêm một [AutoShape](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/autoshape/) vào slide.
1. Đặt [FillType](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/filltype/) của hình dạng thành `Solid`.
1. Gán màu fill mà bạn muốn cho hình dạng.
1. Lưu bản trình chiếu đã chỉnh sửa dưới dạng tệp PPTX.

Đoạn mã JavaScript sau đây minh họa cách áp dụng đổ màu đơn cho một hình chữ nhật trong slide PowerPoint:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Tạo một thể hiện của lớp Presentation đại diện cho một tệp bản trình bày.
let presentation = new aspose.slides.Presentation();
try {
    // Lấy slide đầu tiên.
    let slide = presentation.getSlides().get_Item(0);

    // Thêm một auto shape loại Rectangle.
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);

    // Đặt loại fill là Solid.
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));

    // Đặt màu fill.
    shape.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "YELLOW"));

    // Lưu tệp PPTX vào đĩa.
    presentation.save("solid_color_fill.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Kết quả:

![Hình dạng với đổ màu đơn](solid-color-fill.png)

## **Đặt Độ trong suốt**

Trong PowerPoint, khi bạn áp dụng màu đơn, gradient, hình ảnh hoặc texture cho các hình dạng, bạn cũng có thể đặt mức độ trong suốt để kiểm soát độ mờ của màu fill. Giá trị trong suốt cao hơn làm cho hình dạng trở nên trong suốt hơn, cho phép nền hoặc các đối tượng bên dưới hiển thị một phần.

Aspose.Slides cho phép bạn đặt mức độ trong suốt bằng cách điều chỉnh giá trị alpha trong màu được sử dụng cho fill. Cách thực hiện như sau:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/) .
1. Lấy tham chiếu đến một slide theo chỉ mục của nó.
1. Thêm một [AutoShape](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/autoshape/) vào slide.
1. Đặt [FillType](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/filltype/) thành `Solid`.
1. Sử dụng `Color` để xác định một màu có độ trong suốt (thành phần `alpha` kiểm soát độ trong suốt).
1. Lưu bản trình chiếu.

Đoạn mã JavaScript dưới đây minh họa cách áp dụng màu fill trong suốt cho một hình chữ nhật:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Tạo một thể hiện của lớp Presentation đại diện cho một tệp bản trình bày.
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

## **Xoay Hình dạng**

Aspose.Slides cho phép bạn xoay các hình dạng trong bản trình chiếu PowerPoint. Tính năng này hữu ích khi cần định vị các yếu tố trực quan với yêu cầu căn chỉnh hoặc thiết kế cụ thể.

Để xoay một hình dạng trên slide, thực hiện các bước sau:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/) .
1. Lấy tham chiếu đến một slide theo chỉ mục của nó.
1. Thêm một [AutoShape](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/autoshape/) vào slide.
1. Đặt thuộc tính xoay của hình dạng thành góc mong muốn.
1. Lưu bản trình chiếu.

Đoạn mã JavaScript dưới đây minh họa cách xoay một hình dạng 5 độ:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Tạo một thể hiện của lớp Presentation đại diện cho một tệp bản trình bày.
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

## **Thêm Hiệu ứng Bevel 3D**

Aspose.Slides cho phép bạn áp dụng hiệu ứng bevel 3D cho các hình dạng bằng cách cấu hình các thuộc tính [ThreeDFormat](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/threedformat/) của chúng.

Để thêm hiệu ứng bevel 3D cho một hình dạng, thực hiện các bước sau:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/) .
1. Lấy tham chiếu đến một slide theo chỉ mục của nó.
1. Thêm một [AutoShape](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/autoshape/) vào slide.
1. Cấu hình [ThreeDFormat](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/threedformat/) của hình dạng để xác định cài đặt bevel.
1. Lưu bản trình chiếu.

Đoạn mã JavaScript dưới đây cho thấy cách áp dụng hiệu ứng bevel 3D cho một hình dạng:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

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

    // Lưu bản trình bày dưới dạng tệp PPTX.
    presentation.save("3D_bevel_effect.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Kết quả:

![Hiệu ứng bevel 3D](3D-bevel-effect.png)

## **Thêm Hiệu ứng Xoay 3D**

Aspose.Slides cho phép bạn áp dụng hiệu ứng xoay 3D cho các hình dạng bằng cách cấu hình các thuộc tính [ThreeDFormat](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/threedformat/) của chúng.

Để áp dụng xoay 3D cho một hình dạng:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/) .
1. Lấy tham chiếu đến một slide theo chỉ mục của nó.
1. Thêm một [AutoShape](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/autoshape/) vào slide.
1. Sử dụng [setCameraType](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/camera/#setCameraType) và [setLightType](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/lightrig/#setLightType) để xác định xoay 3D.
1. Lưu bản trình chiếu.

Đoạn mã JavaScript dưới đây minh họa cách áp dụng hiệu ứng xoay 3D cho một hình dạng:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

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

![Hiệu ứng xoay 3D](3D-rotation-effect.png)

## **Kiểm soát Định dạng Đen-Trắng cho Hình dạng**

Phương thức [Shape.setBlackWhiteMode](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/shape/#setBlackWhiteMode) xác định cách một hình dạng riêng lẻ được hiển thị khi bản trình chiếu được xem hoặc xử lý ở chế độ đen-trắng. Phương thức này không kích hoạt chế độ hiển thị đen-trắng riêng biệt và không thay đổi fill, line hoặc các định dạng khác của hình dạng trong chế độ màu bình thường.

Sử dụng một giá trị từ liệt kê [BlackWhiteMode](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/blackwhitemode/) để chọn hành vi mong muốn. Ví dụ, `Automatic` cho phép ứng dụng hiển thị quyết định cách chuyển đổi, `Gray` và `LightGray` sử dụng màu xám, `BlackWhite` chỉ dùng đen và trắng, `Black` và `White` ép buộc một màu duy nhất, `Color` giữ nguyên màu bình thường, và `Hidden` bỏ qua hình dạng ở chế độ đen-trắng. `NotDefined` có nghĩa là không có chế độ cấp độ hình dạng nào được gán.

Đoạn mã JavaScript dưới đây tạo một hình dạng có màu và làm cho nó hiển thị dưới dạng màu xám trong chế độ hiển thị đen-trắng:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 200, 100);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "ORANGE"));

    // Giữ màu cam trong chế độ màu, nhưng hiển thị hình dạng với màu xám trong chế độ đen-trắng.
    shape.setBlackWhiteMode(java.newByte(aspose.slides.BlackWhiteMode.Gray));

    presentation.save("shape_black_white_mode.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Trong chế độ màu bình thường, hình chữ nhật giữ nguyên màu nền cam. Khi làm việc trong quy trình hiển thị đen-trắng, nó sử dụng màu xám vì chế độ đã được đặt thành `Gray`. Điều này cho phép bạn giữ một slide đầy màu sắc trong khi định nghĩa một cách hiển thị riêng biệt cho việc in ấn, xem trước hoặc các quy trình khác tôn trọng cài đặt hiển thị đen-trắng của bản trình chiếu.

## **Đặt lại Định dạng**

Đoạn mã JavaScript dưới đây cho thấy cách đặt lại định dạng của một slide và khôi phục vị trí, kích thước và định dạng của tất cả các hình dạng có placeholder trên [LayoutSlide](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/layoutslide/) về mặc định:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    for (let i = 0; i < presentation.getSlides().size(); i++) {
        let slide = presentation.getSlides().get_Item(i);
        // Đặt lại mỗi hình dạng trên slide có placeholder trên bố cục.
        slide.reset();
    }
    presentation.save("reset_formatting.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Câu hỏi thường gặp**

**Việc định dạng hình dạng có ảnh hưởng đến kích thước tệp bản trình bày cuối cùng không?**

Chỉ ảnh hưởng rất ít. Hình ảnh và phương tiện nhúng chiếm phần lớn dung lượng tệp, trong khi các tham số hình dạng như màu, hiệu ứng và gradient được lưu dưới dạng metadata và hầu như không tăng thêm kích thước.

**Làm thế nào để phát hiện các hình dạng trên một slide có cùng định dạng để tôi có thể nhóm chúng?**

So sánh các thuộc tính định dạng chính của mỗi hình dạng—các cài đặt fill, line và effect. Nếu tất cả các giá trị tương ứng khớp nhau, coi kiểu dáng của chúng là giống nhau và nhóm các hình dạng này lại với nhau, giúp việc quản lý kiểu sau này đơn giản hơn.

**Tôi có thể lưu một tập hợp các kiểu dáng hình dạng tùy chỉnh vào một tệp riêng để tái sử dụng trong các bản trình bày khác không?**

Có. Lưu các hình mẫu có kiểu dáng mong muốn trong một slide mẫu hoặc tệp .POTX. Khi tạo bản trình bày mới, mở mẫu, sao chép các hình dạng đã định dạng bạn cần và áp dụng lại định dạng của chúng ở bất kỳ nơi nào cần thiết.