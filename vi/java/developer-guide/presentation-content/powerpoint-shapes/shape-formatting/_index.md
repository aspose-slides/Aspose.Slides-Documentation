---
title: Định dạng các hình dạng PowerPoint trong Java
linktitle: Định dạng Hình dạng
type: docs
weight: 20
url: /vi/java/shape-formatting/
keywords:
- định dạng hình dạng
- định dạng đường
- hiệu ứng vẽ tay
- đường vẽ tay của hình dạng
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
- bản thuyết trình
- Java
- Aspose.Slides
description: "Tìm hiểu cách định dạng các hình dạng PowerPoint trong Java bằng Aspose.Slides—đặt các kiểu đổ, đường viền và hiệu ứng cho các tệp PPT, PPTX và ODP một cách chính xác và kiểm soát toàn diện."
---
## **Introduction**

Trong PowerPoint, bạn có thể thêm các hình dạng vào các slide. Vì các hình dạng được tạo thành từ các đường, bạn có thể định dạng chúng bằng cách chỉnh sửa hoặc áp dụng hiệu ứng lên đường viền. Ngoài ra, bạn có thể định dạng các hình dạng bằng cách chỉ định các cài đặt kiểm soát cách điền nội bộ của chúng.

![format-shape-powerpoint](format-shape-powerpoint.png)

Aspose.Slides for Java cung cấp các giao diện và phương thức cho phép bạn định dạng các hình dạng bằng các tùy chọn giống như trong PowerPoint.

## **Format Lines**

Sử dụng Aspose.Slides, bạn có thể chỉ định kiểu đường tùy chỉnh cho một hình dạng. Các bước sau mô tả quy trình:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation/) .
2. Lấy tham chiếu tới một slide theo chỉ mục của nó.
3. Thêm một [IAutoShape](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iautoshape/) vào slide.
4. Đặt [line style](https://reference.aspose.com/slides/vi/java/com.aspose.slides/linestyle/) cho hình dạng.
5. Đặt độ rộng của đường.
6. Đặt [dash style](https://reference.aspose.com/slides/vi/java/com.aspose.slides/linedashstyle/) cho đường.
7. Đặt màu đường cho hình dạng.
8. Lưu bản thuyết trình đã chỉnh sửa dưới dạng tệp PPTX.

```java
// Khởi tạo lớp Presentation đại diện cho một tệp thuyết trình.
Presentation presentation = new Presentation();
try {
    // Lấy slide đầu tiên.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Thêm một auto shape loại Rectangle.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 150, 75);

    // Đặt màu nền cho hình dạng rectangle.
    shape.getFillFormat().setFillType(FillType.NoFill);

    // Áp dụng định dạng cho các đường của rectangle.
    shape.getLineFormat().setStyle(LineStyle.ThickThin);
    shape.getLineFormat().setWidth(7);
    shape.getLineFormat().setDashStyle(LineDashStyle.Dash);

    // Đặt màu cho đường viền của rectangle.
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);

    // Lưu tệp PPTX vào đĩa.
    presentation.save("formatted_lines.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Các đường đã định dạng trong bản thuyết trình](formatted-lines.png)

## **Apply Sketch Effects to Shape Lines**

Hiệu ứng vẽ tay làm cho đường của hình dạng trông như được vẽ bằng tay. Sử dụng [IShape.getLineFormat](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ishape/) để truy cập cài đặt đường, [ILineFormat.getSketchFormat](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ilineformat/) để truy cập cài đặt vẽ tay, và [ISketchFormat.setSketchType](https://reference.aspose.com/slides/vi/java/com.aspose.slides/isketchformat/) để chọn một giá trị từ kiểu liệt kê [LineSketchType](https://reference.aspose.com/slides/vi/java/com.aspose.slides/linesketchtype/).

Mã Java sau đây cho thấy cách áp dụng hiệu ứng [LineSketchType.Curved](https://reference.aspose.com/slides/vi/java/com.aspose.slides/linesketchtype/), đọc giá trị được gán một cách rõ ràng, và loại bỏ hiệu ứng bằng [LineSketchType.None](https://reference.aspose.com/slides/vi/java/com.aspose.slides/linesketchtype/):

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);

    // Truy cập định dạng đường của hình dạng và định dạng sketch của nó.
    ISketchFormat sketchFormat = shape.getLineFormat().getSketchFormat();

    // Áp dụng hiệu ứng sketch.
    sketchFormat.setSketchType(LineSketchType.Curved);

    // Đọc hiệu ứng sketch được gán trực tiếp cho hình dạng.
    int explicitSketchType = sketchFormat.getSketchType();
    System.out.println("Explicit sketch type: " + explicitSketchType);

    // Xóa bỏ hiệu ứng sketch.
    sketchFormat.setSketchType(LineSketchType.None);
} finally {
    presentation.dispose();
}
```

Giá trị trả về bởi [ISketchFormat.getSketchType](https://reference.aspose.com/slides/vi/java/com.aspose.slides/isketchformat/) biểu thị cài đặt được gán trực tiếp cho hình dạng. Nếu định dạng đường có thể được kế thừa từ chủ đề, slide chủ, hoặc slide bố cục, hãy sử dụng [ILineFormat.getEffective](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ilineformat/), truy cập [ILineFormatEffectiveData.getSketchFormat](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ilineformateffectivedata/), và đọc [ISketchFormatEffectiveData.getSketchType](https://reference.aspose.com/slides/vi/java/com.aspose.slides/isketchformateffectivedata/). Giá trị hiệu quả phản ánh định dạng thực sự được áp dụng sau khi giải quyết kế thừa:

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

## **Format Join Styles**

Dưới đây là ba tùy chọn kiểu nối:

* Round
* Miter
* Bevel

Theo mặc định, khi PowerPoint nối hai đường ở một góc (ví dụ tại góc của một hình dạng), nó sử dụng cài đặt **Round**. Tuy nhiên, nếu bạn vẽ một hình dạng với các góc nhọn, bạn có thể ưu tiên tùy chọn **Miter**.

![Kiểu nối trong bản thuyết trình](join-style-powerpoint.png)

Mã Java sau đây minh họa cách ba hình chữ nhật (như trong hình trên) được tạo ra bằng cách sử dụng các cài đặt kiểu nối Miter, Bevel và Round:

```java
// Khởi tạo lớp Presentation đại diện cho một tệp thuyết trình.
Presentation presentation = new Presentation();
try {
    // Lấy slide đầu tiên.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Thêm ba auto shape loại Rectangle.
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

    // Lưu tệp PPTX vào đĩa.
    presentation.save("join_styles.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Gradient Fill**

Trong PowerPoint, Gradient Fill là một tùy chọn định dạng cho phép bạn áp dụng một sự pha trộn liên tục của các màu sắc lên một hình dạng. Ví dụ, bạn có thể áp dụng hai hoặc nhiều màu sao cho một màu dần dần chuyển sang màu khác.

Dưới đây là cách áp dụng gradient fill cho một hình dạng bằng Aspose.Slides:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation/) .
2. Lấy tham chiếu tới một slide theo chỉ mục.
3. Thêm một [IAutoShape](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iautoshape/) vào slide.
4. Đặt [FillType](https://reference.aspose.com/slides/vi/java/com.aspose.slides/filltype/) của hình dạng thành `Gradient`.
5. Thêm hai màu bạn muốn với vị trí xác định bằng các phương thức `add` của tập hợp gradient stop được cung cấp bởi giao diện [IGradientFormat](https://reference.aspose.com/slides/vi/java/com.aspose.slides/igradientformat/) .
6. Lưu bản thuyết trình đã chỉnh sửa dưới dạng tệp PPTX.

```java
// Khởi tạo lớp Presentation đại diện cho một tệp thuyết trình.
Presentation presentation = new Presentation();
try {
    // Lấy slide đầu tiên.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Thêm một auto shape loại Ellipse.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 50, 150, 75);

    // Áp dụng định dạng gradient cho ellipse.
    shape.getFillFormat().setFillType(FillType.Gradient);
    shape.getFillFormat().getGradientFormat().setGradientShape(GradientShape.Linear);

    // Đặt hướng của gradient.
    shape.getFillFormat().getGradientFormat().setGradientDirection(GradientDirection.FromCorner2);

    // Thêm hai gradient stop.
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor((float)1.0, PresetColor.Purple);
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor((float)0, PresetColor.Red);

    // Lưu tệp PPTX vào đĩa.
    presentation.save("gradient_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Ellipse với gradient fill](gradient-fill.png)

## **Pattern Fill**

Trong PowerPoint, Pattern Fill là một tùy chọn định dạng cho phép bạn áp dụng một thiết kế hai màu — như chấm, sọc, vệt chéo hoặc ô vuông — lên một hình dạng. Bạn có thể chọn màu tùy chỉnh cho nền trước và nền sau của mẫu.

Aspose.Slides cung cấp hơn 45 kiểu mẫu được định nghĩa trước mà bạn có thể áp dụng cho các hình dạng để nâng cao sức hấp dẫn trực quan của bản thuyết trình. Ngay cả sau khi chọn một mẫu đã định nghĩa, bạn vẫn có thể chỉ định các màu chính xác mà mẫu sẽ sử dụng.

Dưới đây là cách áp dụng pattern fill cho một hình dạng bằng Aspose.Slides:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation/) .
2. Lấy tham chiếu tới một slide theo chỉ mục.
3. Thêm một [IAutoShape](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iautoshape/) vào slide.
4. Đặt [FillType](https://reference.aspose.com/slides/vi/java/com.aspose.slides/filltype/) của hình dạng thành `Pattern`.
5. Chọn một kiểu mẫu từ các tùy chọn đã định nghĩa trước.
6. Đặt [Background Color](https://reference.aspose.com/slides/vi/java/com.aspose.slides/patternformat/#getBackColor--) của mẫu.
7. Đặt [Foreground Color](https://reference.aspose.com/slides/vi/java/com.aspose.slides/patternformat/#getForeColor--) của mẫu.
8. Lưu bản thuyết trình đã chỉnh sửa dưới dạng tệp PPTX.

```java
// Khởi tạo lớp Presentation đại diện cho một tệp thuyết trình.
Presentation presentation = new Presentation();
try {
    // Lấy slide đầu tiên.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Thêm một auto shape loại Rectangle.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Đặt loại fill thành Pattern.
    shape.getFillFormat().setFillType(FillType.Pattern);

    // Đặt kiểu mẫu.
    shape.getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.Trellis);

    // Đặt màu nền và màu phía trước cho mẫu.
    shape.getFillFormat().getPatternFormat().getBackColor().setColor(Color.LIGHT_GRAY);
    shape.getFillFormat().getPatternFormat().getForeColor().setColor(Color.YELLOW);

    // Lưu tệp PPTX vào đĩa.
    presentation.save("pattern_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Hình chữ nhật với pattern fill](pattern-fill.png)

## **Picture Fill**

Trong PowerPoint, Picture Fill là một tùy chọn định dạng cho phép bạn chèn một hình ảnh bên trong một hình dạng — thực tế sử dụng hình ảnh làm nền cho hình dạng.

Dưới đây là cách sử dụng Aspose.Slides để áp dụng picture fill cho một hình dạng:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation/) .
2. Lấy tham chiếu tới một slide theo chỉ mục.
3. Thêm một [IAutoShape](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iautoshape/) vào slide.
4. Đặt [FillType](https://reference.aspose.com/slides/vi/java/com.aspose.slides/filltype/) của hình dạng thành `Picture`.
5. Đặt chế độ picture fill thành `Tile` (hoặc chế độ khác mà bạn muốn).
6. Tạo một đối tượng [IPPImage](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ippimage/) từ hình ảnh bạn muốn sử dụng.
7. Gửi hình ảnh vào phương thức `ISlidesPicture.setImage` .
8. Lưu bản thuyết trình đã chỉnh sửa dưới dạng tệp PPTX.

Giả sử chúng ta có một tệp "lotus.png" với hình ảnh sau:

![Hình lotus](lotus.png)

```java
// Khởi tạo lớp Presentation đại diện cho một tệp thuyết trình.
Presentation presentation = new Presentation();
try {
    // Lấy slide đầu tiên.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Thêm một auto shape loại Rectangle.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 255, 130);
    
    // Đặt loại fill thành Picture.
    shape.getFillFormat().setFillType(FillType.Picture);

    // Đặt chế độ picture fill.
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Tile);

    // Tải hình ảnh và thêm nó vào tài nguyên của bản thuyết trình.
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

![Hình dạng với picture fill](picture-fill.png)

### **Tile Picture As Texture**

Nếu bạn muốn đặt một hình ảnh lặp lại làm texture và tùy chỉnh hành vi lặp, bạn có thể sử dụng các phương thức sau của giao diện [IPictureFillFormat](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ipicturefillformat/) và lớp [PictureFillFormat](https://reference.aspose.com/slides/vi/java/com.aspose.slides/picturefillformat/) :

- [setPictureFillMode](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ipicturefillformat/#setPictureFillMode-int-): Đặt chế độ picture fill — hoặc `Tile` hoặc `Stretch`.
- [setTileAlignment](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ipicturefillformat/#setTileAlignment-byte-): Xác định vị trí căn chỉnh của các ô trong hình dạng.
- [setTileFlip](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ipicturefillformat/#setTileFlip-int-): Điều khiển việc lật ô theo chiều ngang, chiều dọc, hoặc cả hai.
- [setTileOffsetX](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ipicturefillformat/#setTileOffsetX-float-): Đặt độ dịch ngang của ô (đơn vị điểm) so với gốc của hình dạng.
- [setTileOffsetY](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ipicturefillformat/#setTileOffsetY-float-): Đặt độ dịch dọc của ô (đơn vị điểm) so với gốc của hình dạng.
- [setTileScaleX](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ipicturefillformat/#setTileScaleX-float-): Xác định tỷ lệ ngang của ô dưới dạng phần trăm.
- [setTileScaleY](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ipicturefillformat/#setTileScaleY-float-): Xác định tỷ lệ dọc của ô dưới dạng phần trăm.

Mã mẫu sau cho thấy cách thêm một hình chữ nhật với picture fill dạng lặp và cấu hình các tùy chọn lặp:

```java
// Khởi tạo lớp Presentation đại diện cho một tệp thuyết trình.
Presentation presentation = new Presentation();
try {
    // Lấy slide đầu tiên.
    ISlide firstSlide = presentation.getSlides().get_Item(0);

    // Thêm một auto shape hình chữ nhật.
    IAutoShape shape = firstSlide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 190, 95);

    // Đặt loại fill của hình dạng thành Picture.
    shape.getFillFormat().setFillType(FillType.Picture);

    // Tải hình ảnh và thêm nó vào tài nguyên của bản thuyết trình.
    IImage sourceImage = Images.fromFile("lotus.png");
    IPPImage presentationImage = presentation.getImages().addImage(sourceImage);
    sourceImage.dispose();

    // Gán hình ảnh cho hình dạng.
    IPictureFillFormat pictureFillFormat = shape.getFillFormat().getPictureFillFormat();
    pictureFillFormat.getPicture().setImage(presentationImage);

    // Cấu hình chế độ picture fill và các thuộc tính lát gạch.
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

![Các tùy chọn lặp](tile-options.png)

## **Solid Color Fill**

Trong PowerPoint, Solid Color Fill là một tùy chọn định dạng làm đầy một hình dạng bằng một màu duy nhất, đồng nhất. Màu nền đơn giản này được áp dụng mà không có bất kỳ gradient, texture hay mẫu nào.

Để áp dụng solid color fill cho một hình dạng bằng Aspose.Slides, thực hiện các bước sau:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation/) .
2. Lấy tham chiếu tới một slide theo chỉ mục.
3. Thêm một [IAutoShape](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iautoshape/) vào slide.
4. Đặt [FillType](https://reference.aspose.com/slides/vi/java/com.aspose.slides/filltype/) của hình dạng thành `Solid`.
5. Gán màu fill bạn muốn cho hình dạng.
6. Lưu bản thuyết trình đã chỉnh sửa dưới dạng tệp PPTX.

```java
// Khởi tạo lớp Presentation đại diện cho một tệp thuyết trình.
Presentation presentation = new Presentation();
try {
    // Lấy slide đầu tiên.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Thêm một auto shape loại Rectangle.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Đặt loại fill thành Solid.
    shape.getFillFormat().setFillType(FillType.Solid);

    // Đặt màu nền.
    shape.getFillFormat().getSolidFillColor().setColor(Color.YELLOW);

    // Lưu tệp PPTX vào đĩa.
    presentation.save("solid_color_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Hình dạng với solid color fill](solid-color-fill.png)

## **Set Transparency**

Trong PowerPoint, khi bạn áp dụng solid color, gradient, picture hoặc texture fill cho các hình dạng, bạn cũng có thể đặt mức độ trong suốt để kiểm soát độ mờ của fill. Giá trị trong suốt cao hơn làm cho hình dạng trong suốt hơn, cho phép nền hoặc các đối tượng phía dưới hiển thị một phần.

Aspose.Slides cho phép bạn đặt mức độ trong suốt bằng cách điều chỉnh giá trị alpha trong màu được sử dụng cho fill. Dưới đây là cách thực hiện:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation/) .
2. Lấy tham chiếu tới một slide theo chỉ mục.
3. Thêm một [IAutoShape](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iautoshape/) vào slide.
4. Đặt [FillType](https://reference.aspose.com/slides/vi/java/com.aspose.slides/filltype/) thành `Solid`.
5. Sử dụng `Color` để định nghĩa một màu có độ trong suốt (thành phần `alpha` kiểm soát độ trong suốt).
6. Lưu bản thuyết trình.

```java
// Khởi tạo lớp Presentation đại diện cho một tệp thuyết trình.
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

![Hình dạng trong suốt](shape-transparency.png)

## **Rotate Shapes**

Aspose.Slides cho phép bạn xoay các hình dạng trong bản thuyết trình PowerPoint. Điều này hữu ích khi đặt vị trí các yếu tố trực quan với yêu cầu căn chỉnh hoặc thiết kế cụ thể.

Để xoay một hình dạng trên slide, thực hiện các bước sau:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation/) .
2. Lấy tham chiếu tới một slide theo chỉ mục.
3. Thêm một [IAutoShape](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iautoshape/) vào slide.
4. Đặt thuộc tính rotation của hình dạng thành góc mong muốn.
5. Lưu bản thuyết trình.

```java
// Khởi tạo lớp Presentation đại diện cho một tệp thuyết trình.
Presentation presentation = new Presentation();
try {
    // Lấy slide đầu tiên.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Thêm một auto shape loại Rectangle.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Xoay hình dạng 5 độ.
    shape.setRotation(5);

    // Lưu tệp PPTX vào đĩa.
    presentation.save("shape_rotation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Sự xoay của hình dạng](shape-rotation.png)

## **Add 3D Bevel Effects**

Aspose.Slides cho phép bạn áp dụng hiệu ứng 3D bevel cho các hình dạng bằng cách cấu hình các thuộc tính [ThreeDFormat](https://reference.aspose.com/slides/vi/java/com.aspose.slides/threedformat/) của chúng.

Để thêm hiệu ứng 3D bevel cho một hình dạng, thực hiện các bước sau:

1. Khởi tạo lớp [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation/) .
2. Lấy tham chiếu tới một slide theo chỉ mục.
3. Thêm một [IAutoShape](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iautoshape/) vào slide.
4. Cấu hình [ThreeDFormat](https://reference.aspose.com/slides/vi/java/com.aspose.slides/threedformat/) của hình dạng để định nghĩa các cài đặt bevel.
5. Lưu bản thuyết trình.

```java
// Khởi tạo một thể hiện của lớp Presentation.
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

    // Lưu bản thuyết trình dưới dạng tệp PPTX.
    presentation.save("3D_bevel_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Hiệu ứng 3D bevel](3D-bevel-effect.png)

## **Add 3D Rotation Effects**

Aspose.Slides cho phép bạn áp dụng hiệu ứng quay 3D cho các hình dạng bằng cách cấu hình các thuộc tính [ThreeDFormat](https://reference.aspose.com/slides/vi/java/com.aspose.slides/threedformat/) của chúng.

Để áp dụng quay 3D cho một hình dạng:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation/) .
2. Lấy tham chiếu tới một slide theo chỉ mục.
3. Thêm một [IAutoShape](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iautoshape/) vào slide.
4. Sử dụng [setCameraType](https://reference.aspose.com/slides/vi/java/com.aspose.slides/icamera/#setCameraType-int-) và [setLightType](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ilightrig/#setLightType-int-) để định nghĩa quay 3D.
5. Lưu bản thuyết trình.

```java
// Khởi tạo một thể hiện của lớp Presentation.
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);
    autoShape.getTextFrame().setText("Hello, Aspose!");

    autoShape.getThreeDFormat().setDepth(6);
    autoShape.getThreeDFormat().getCamera().setRotation(40, 35, 20);
    autoShape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.IsometricLeftUp);
    autoShape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Balanced);

    // Lưu bản thuyết trình dưới dạng tệp PPTX.
    presentation.save("3D_rotation_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Hiệu ứng quay 3D](3D-rotation-effect.png)

## **Reset Formatting**

Đoạn mã Java sau đây cho thấy cách đặt lại định dạng của một slide và khôi phục vị trí, kích thước và định dạng của tất cả các hình dạng có placeholder trên [LayoutSlide](https://reference.aspose.com/slides/vi/java/com.aspose.slides/layoutslide/) về cài đặt mặc định của chúng:

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        // Đặt lại mỗi hình dạng trên slide có placeholder trên bố cục.
        slide.reset();
    }
    presentation.save("reset_formatting.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Việc định dạng hình dạng có ảnh hưởng đến kích thước cuối cùng của tệp bản thuyết trình không?**

Chỉ một mức độ rất nhỏ. Các hình ảnh và phương tiện nhúng chiếm phần lớn không gian tệp, trong khi các tham số hình dạng như màu sắc, hiệu ứng và gradient được lưu dưới dạng metadata và gần như không làm tăng kích thước thêm.

**Làm sao tôi có thể phát hiện các hình dạng trên một slide có cùng định dạng để có thể nhóm chúng lại?**

So sánh các thuộc tính định dạng chính của mỗi hình dạng — cài đặt fill, line và effect. Nếu tất cả các giá trị tương ứng khớp nhau, coi kiểu của chúng là giống nhau và nhóm logic các hình dạng đó, giúp đơn giản hoá việc quản lý kiểu sau này.

**Tôi có thể lưu một bộ các kiểu hình dạng tùy chỉnh vào một tệp riêng để tái sử dụng trong các bản thuyết trình khác không?**

Có. Lưu các hình mẫu với kiểu mong muốn trong một bộ slide mẫu hoặc tệp mẫu .POTX. Khi tạo một bản thuyết trình mới, mở mẫu, sao chép các hình đã định dạng bạn cần và áp dụng lại định dạng của chúng ở bất kỳ nơi nào cần thiết.