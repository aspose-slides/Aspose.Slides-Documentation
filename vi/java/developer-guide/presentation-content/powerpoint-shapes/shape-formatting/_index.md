---
title: Định dạng các hình dạng PowerPoint trong Java
linktitle: Định dạng Hình dạng
type: docs
weight: 20
url: /vi/java/shape-formatting/
keywords:
- định dạng hình dạng
- định dạng đường viền
- hiệu ứng phác thảo
- đường viền hình dạng phác thảo
- định dạng kiểu nối
- đổ màu gradient
- đổ mẫu
- đổ hình ảnh
- đổ kết cấu
- đổ màu đơn
- độ trong suốt hình dạng
- hiển thị hình dạng đen‑trắng
- hiển thị hình dạng thang độ xám
- xoay hình dạng
- hiệu ứng bo 3D
- hiệu ứng xoay 3D
- đặt lại định dạng
- PowerPoint
- bản trình chiếu
- Java
- Aspose.Slides
description: "Tìm hiểu cách định dạng các hình dạng PowerPoint trong Java bằng Aspose.Slides—đặt các kiểu tô, đường viền và hiệu ứng cho tệp PPT, PPTX và ODP một cách chính xác và kiểm soát đầy đủ."
---
## **Giới thiệu**

Trong PowerPoint, bạn có thể thêm các hình dạng vào các slide. Vì các hình dạng được tạo thành từ các đường, bạn có thể định dạng chúng bằng cách chỉnh sửa hoặc áp dụng hiệu ứng cho viền của chúng. Ngoài ra, bạn có thể định dạng các hình dạng bằng cách chỉ định các cài đặt kiểm soát cách phần trong của chúng được tô màu.

![format-shape-powerpoint](format-shape-powerpoint.png)

Aspose.Slides for Java cung cấp các giao diện và phương thức cho phép bạn định dạng các hình dạng bằng các tùy chọn giống như trong PowerPoint.

## **Định dạng Đường viền**

Sử dụng Aspose.Slides, bạn có thể chỉ định kiểu đường tùy chỉnh cho một hình dạng. Các bước sau mô tả quy trình:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation/) .
2. Lấy một tham chiếu tới slide theo chỉ mục của nó.
3. Thêm một [IAutoShape](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iautoshape/) vào slide.
4. Đặt [line style](https://reference.aspose.com/slides/vi/java/com.aspose.slides/linestyle/) cho hình dạng.
5. Đặt độ rộng đường.
6. Đặt [dash style](https://reference.aspose.com/slides/vi/java/com.aspose.slides/linedashstyle/) cho đường.
7. Đặt màu đường cho hình dạng.
8. Lưu bản trình chiếu đã chỉnh sửa dưới dạng tệp PPTX.

Đoạn mã sau minh họa cách định dạng một `AutoShape` hình chữ nhật:

```java
import com.aspose.slides.*;
import java.awt.Color;

// Khởi tạo lớp Presentation đại diện cho một tệp bài thuyết trình.
Presentation presentation = new Presentation();
try {
    // Lấy slide đầu tiên.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Thêm một auto shape loại Hình chữ nhật.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 150, 75);

    // Đặt màu nền cho hình chữ nhật.
    shape.getFillFormat().setFillType(FillType.NoFill);

    // Áp dụng định dạng cho các đường viền của hình chữ nhật.
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

## **Áp dụng Hiệu ứng Phác thảo cho Đường viền Hình dạng**

Hiệu ứng phác thảo làm cho đường viền của một hình dạng trông giống như được vẽ tay. Sử dụng [IShape.getLineFormat](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ishape/) để truy cập cài đặt đường, [ILineFormat.getSketchFormat](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ilineformat/) để truy cập cài đặt phác thảo, và [ISketchFormat.setSketchType](https://reference.aspose.com/slides/vi/java/com.aspose.slides/isketchformat/) để chọn một giá trị từ enumeration [LineSketchType](https://reference.aspose.com/slides/vi/java/com.aspose.slides/linesketchtype/).

Đoạn mã Java sau cho thấy cách áp dụng hiệu ứng [LineSketchType.Curved](https://reference.aspose.com/slides/vi/java/com.aspose.slides/linesketchtype/), đọc giá trị đã được gán rõ ràng, và loại bỏ hiệu ứng bằng [LineSketchType.None](https://reference.aspose.com/slides/vi/java/com.aspose.slides/linesketchtype/):

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);

    // Truy cập định dạng đường viền của hình dạng và định dạng phác thảo của nó.
    ISketchFormat sketchFormat = shape.getLineFormat().getSketchFormat();

    // Áp dụng hiệu ứng phác thảo.
    sketchFormat.setSketchType(LineSketchType.Curved);

    // Đọc hiệu ứng phác thảo được gán trực tiếp cho hình dạng.
    int explicitSketchType = sketchFormat.getSketchType();
    System.out.println("Explicit sketch type: " + explicitSketchType);

    // Xóa bỏ hiệu ứng phác thảo.
    sketchFormat.setSketchType(LineSketchType.None);
} finally {
    presentation.dispose();
}
```

Giá trị trả về bởi [ISketchFormat.getSketchType](https://reference.aspose.com/slides/vi/java/com.aspose.slides/isketchformat/) đại diện cho cài đặt được gán trực tiếp cho hình dạng. Nếu định dạng đường có thể được kế thừa từ chủ đề, slide chủ, hoặc slide bố cục, hãy sử dụng [ILineFormat.getEffective](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ilineformat/), truy cập [ILineFormatEffectiveData.getSketchFormat](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ilineformateffectivedata/), và đọc [ISketchFormatEffectiveData.getSketchType](https://reference.aspose.com/slides/vi/java/com.aspose.slides/isketchformateffectivedata/). Giá trị hiệu quả phản ánh định dạng thực sự được áp dụng sau khi kế thừa được giải quyết:

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

Dưới đây là ba tùy chọn kiểu nối:

* Tròn
* Vuông
* Xiên

Mặc định, khi PowerPoint nối hai đường ở một góc (ví dụ ở góc của một hình dạng), nó sử dụng cài đặt **Round**. Tuy nhiên, nếu bạn đang vẽ một hình dạng với các góc nhọn, bạn có thể thích tùy chọn **Miter**.

![Kiểu nối trong bản trình chiếu](join-style-powerpoint.png)

Đoạn mã Java sau minh họa cách ba hình chữ nhật (như trong ảnh ở trên) được tạo ra bằng cách sử dụng các cài đặt kiểu nối Miter, Bevel và Round:

```java
import com.aspose.slides.*;
import java.awt.Color;

// Khởi tạo lớp Presentation đại diện cho một tệp bài thuyết trình.
Presentation presentation = new Presentation();
try {
    // Lấy slide đầu tiên.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Thêm ba auto shape loại Hình chữ nhật.
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

## **Đổ màu Gradient**

Trong PowerPoint, Gradient Fill là một tùy chọn định dạng cho phép bạn áp dụng một sự pha trộn liên tục của các màu vào một hình dạng. Ví dụ, bạn có thể áp dụng hai hoặc nhiều màu sao cho một màu dần dần chuyển sang màu khác.

Đây là cách áp dụng đổ màu gradient cho một hình dạng bằng Aspose.Slides:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation/) .
2. Lấy một tham chiếu tới slide theo chỉ mục của nó.
3. Thêm một [IAutoShape](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iautoshape/) vào slide.
4. Đặt [FillType](https://reference.aspose.com/slides/vi/java/com.aspose.slides/filltype/) của hình dạng thành `Gradient`.
5. Thêm hai màu bạn muốn cùng với vị trí đã định nghĩa bằng các phương thức `add` của bộ sưu tập gradient stop được cung cấp bởi giao diện [IGradientFormat](https://reference.aspose.com/slides/vi/java/com.aspose.slides/igradientformat/) .
6. Lưu bản trình chiếu đã chỉnh sửa dưới dạng tệp PPTX.

```java
import com.aspose.slides.*;

// Khởi tạo lớp Presentation đại diện cho một tệp bài thuyết trình.
Presentation presentation = new Presentation();
try {
    // Lấy slide đầu tiên.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Thêm một auto shape loại Ellipse.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 50, 150, 75);

    // Áp dụng định dạng gradient cho ellipse.
    shape.getFillFormat().setFillType(FillType.Gradient);
    shape.getFillFormat().getGradientFormat().setGradientShape(GradientShape.Linear);

    // Đặt hướng cho gradient.
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

![Ellipse với đổ màu gradient](gradient-fill.png)

## **Đổ mẫu**

Trong PowerPoint, Pattern Fill là một tùy chọn định dạng cho phép bạn áp dụng một thiết kế hai màu—như chấm, sọc, chéo, hoặc caro—vào một hình dạng. Bạn có thể chọn màu tùy chỉnh cho nền trước và nền sau của mẫu.

Aspose.Slides cung cấp hơn 45 kiểu mẫu được định sẵn mà bạn có thể áp dụng cho các hình dạng để nâng cao tính thẩm mỹ của bản trình chiếu. Ngay cả sau khi chọn một mẫu đã định sẵn, bạn vẫn có thể chỉ định màu chính xác mà nó sẽ sử dụng.

Đây là cách áp dụng đổ mẫu cho một hình dạng bằng Aspose.Slides:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation/) .
2. Lấy một tham chiếu tới slide theo chỉ mục của nó.
3. Thêm một [IAutoShape](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iautoshape/) vào slide.
4. Đặt [FillType](https://reference.aspose.com/slides/vi/java/com.aspose.slides/filltype/) của hình dạng thành `Pattern`.
5. Chọn một kiểu mẫu từ các tùy chọn được định sẵn.
6. Đặt [Background Color](https://reference.aspose.com/slides/vi/java/com.aspose.slides/patternformat/#getBackColor--) của mẫu.
7. Đặt [Foreground Color](https://reference.aspose.com/slides/vi/java/com.aspose.slides/patternformat/#getForeColor--) của mẫu.
8. Lưu bản trình chiếu đã chỉnh sửa dưới dạng tệp PPTX.

```java
import com.aspose.slides.*;
import java.awt.Color;

// Khởi tạo lớp Presentation đại diện cho một tệp bài thuyết trình.
Presentation presentation = new Presentation();
try {
    // Lấy slide đầu tiên.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Thêm một auto shape loại Rectangle.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Đặt kiểu nền thành Pattern.
    shape.getFillFormat().setFillType(FillType.Pattern);

    // Đặt kiểu mẫu.
    shape.getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.Trellis);

    // Đặt màu nền và màu tiền cảnh cho mẫu.
    shape.getFillFormat().getPatternFormat().getBackColor().setColor(Color.LIGHT_GRAY);
    shape.getFillFormat().getPatternFormat().getForeColor().setColor(Color.YELLOW);

    // Lưu tệp PPTX vào đĩa.
    presentation.save("pattern_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Kết quả:

![Hình chữ nhật với đổ mẫu](pattern-fill.png)

## **Đổ hình ảnh**

Trong PowerPoint, Picture Fill là một tùy chọn định dạng cho phép bạn chèn một hình ảnh bên trong một hình dạng—hiệu quả như đang sử dụng hình ảnh đó làm nền cho hình dạng.

Đây là cách sử dụng Aspose.Slides để áp dụng đổ hình ảnh cho một hình dạng:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation/) .
2. Lấy một tham chiếu tới slide theo chỉ mục của nó.
3. Thêm một [IAutoShape](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iautoshape/) vào slide.
4. Đặt [FillType](https://reference.aspose.com/slides/vi/java/com.aspose.slides/filltype/) của hình dạng thành `Picture`.
5. Đặt chế độ đổ hình ảnh thành `Tile` (hoặc chế độ khác mà bạn muốn).
6. Tạo một đối tượng [IPPImage](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ippimage/) từ hình ảnh bạn muốn sử dụng.
7. Truyền hình ảnh vào phương thức `ISlidesPicture.setImage` .
8. Lưu bản trình chiếu đã chỉnh sửa dưới dạng tệp PPTX.

Giả sử chúng ta có một tệp "lotus.png" với hình ảnh sau:

![Hình lotus](lotus.png)

```java
import com.aspose.slides.*;

// Khởi tạo lớp Presentation đại diện cho một tệp bài thuyết trình.
Presentation presentation = new Presentation();
try {
    // Lấy slide đầu tiên.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Thêm một auto shape loại Rectangle.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 255, 130);
    
    // Đặt kiểu nền thành Picture.
    shape.getFillFormat().setFillType(FillType.Picture);

    // Đặt chế độ đổ hình ảnh.
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Tile);

    // Tải ảnh và thêm vào tài nguyên của bản trình chiếu.
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

![Hình dạng với đổ hình ảnh](picture-fill.png)

### **Lát Hình ảnh Thành Kết Cấu**

Nếu bạn muốn đặt một hình ảnh lát làm kết cấu và tùy chỉnh hành vi lát, bạn có thể sử dụng các phương thức sau của giao diện [IPictureFillFormat](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ipicturefillformat/) và lớp [PictureFillFormat](https://reference.aspose.com/slides/vi/java/com.aspose.slides/picturefillformat/) :

- [setPictureFillMode](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ipicturefillformat/#setPictureFillMode-int-): Đặt chế độ đổ hình ảnh—hoặc `Tile` hoặc `Stretch`.
- [setTileAlignment](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ipicturefillformat/#setTileAlignment-byte-): Xác định cách căn chỉnh các ô gạch trong hình dạng.
- [setTileFlip](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ipicturefillformat/#setTileFlip-int-): Điều khiển việc lật ô gạch theo chiều ngang, chiều dọc, hoặc cả hai.
- [setTileOffsetX](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ipicturefillformat/#setTileOffsetX-float-): Đặt độ lệch ngang của ô gạch (theo điểm) so với gốc của hình dạng.
- [setTileOffsetY](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ipicturefillformat/#setTileOffsetY-float-): Đặt độ lệch dọc của ô gạch (theo điểm) so với gốc của hình dạng.
- [setTileScaleX](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ipicturefillformat/#setTileScaleX-float-): Xác định tỉ lệ ngang của ô gạch dưới dạng phần trăm.
- [setTileScaleY](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ipicturefillformat/#setTileScaleY-float-): Xác định tỉ lệ dọc của ô gạch dưới dạng phần trăm.

Đoạn mã mẫu sau cho thấy cách thêm một hình chữ nhật với đổ hình ảnh lát và cấu hình các tùy chọn ô gạch:

```java
import com.aspose.slides.*;

// Khởi tạo lớp Presentation đại diện cho một tệp bài thuyết trình.
Presentation presentation = new Presentation();
try {
    // Lấy slide đầu tiên.
    ISlide firstSlide = presentation.getSlides().get_Item(0);

    // Thêm một auto shape hình chữ nhật.
    IAutoShape shape = firstSlide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 190, 95);

    // Đặt kiểu nền của hình dạng thành Picture.
    shape.getFillFormat().setFillType(FillType.Picture);

    // Tải ảnh và thêm vào tài nguyên của bản trình chiếu.
    IImage sourceImage = Images.fromFile("lotus.png");
    IPPImage presentationImage = presentation.getImages().addImage(sourceImage);
    sourceImage.dispose();

    // Gán ảnh cho hình dạng.
    IPictureFillFormat pictureFillFormat = shape.getFillFormat().getPictureFillFormat();
    pictureFillFormat.getPicture().setImage(presentationImage);

    // Cấu hình chế độ đổ ảnh và các thuộc tính lát.
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

![Các tùy chọn ô gạch](tile-options.png)

## **Đổ màu Đơn**

Trong PowerPoint, Solid Color Fill là một tùy chọn định dạng giúp tô màu một hình dạng bằng một màu duy nhất, đồng nhất. Nền màu đơn giản này được áp dụng mà không có gradient, texture, hay pattern.

Để áp dụng đổ màu đơn cho một hình dạng bằng Aspose.Slides, hãy thực hiện các bước sau:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation/) .
2. Lấy một tham chiếu tới slide theo chỉ mục của nó.
3. Thêm một [IAutoShape](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iautoshape/) vào slide.
4. Đặt [FillType](https://reference.aspose.com/slides/vi/java/com.aspose.slides/filltype/) của hình dạng thành `Solid`.
5. Gán màu tô bạn muốn vào hình dạng.
6. Lưu bản trình chiếu đã chỉnh sửa dưới dạng tệp PPTX.

```java
import com.aspose.slides.*;
import java.awt.Color;

// Khởi tạo lớp Presentation đại diện cho một tệp bài thuyết trình.
Presentation presentation = new Presentation();
try {
    // Lấy slide đầu tiên.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Thêm một auto shape loại Rectangle.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Đặt kiểu nền thành Solid.
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

![Hình dạng với đổ màu đơn](solid-color-fill.png)

## **Đặt Độ trong Suốt**

Trong PowerPoint, khi bạn áp dụng màu đơn, gradient, hình ảnh, hoặc texture lên các hình dạng, bạn cũng có thể đặt mức độ trong suốt để điều chỉnh độ mờ của lớp tô. Giá trị trong suốt cao hơn làm cho hình dạng trong suốt hơn, cho phép nền hoặc các đối tượng phía sau hiển thị phần nào.

Aspose.Slides cho phép bạn thiết lập mức độ trong suốt bằng cách điều chỉnh giá trị alpha trong màu được dùng để tô. Đây là cách làm:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation/) .
2. Lấy một tham chiếu tới slide theo chỉ mục của nó.
3. Thêm một [IAutoShape](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iautoshape/) vào slide.
4. Đặt [FillType](https://reference.aspose.com/slides/vi/java/com.aspose.slides/filltype/) thành `Solid`.
5. Sử dụng `Color` để định nghĩa một màu có độ trong suốt (thành phần `alpha` kiểm soát độ trong suốt).
6. Lưu bản trình chiếu.

```java
import com.aspose.slides.*;
import java.awt.Color;

// Khởi tạo lớp Presentation đại diện cho một tệp bài thuyết trình.
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

Aspose.Slides cho phép bạn xoay các hình dạng trong bản trình chiếu PowerPoint. Điều này hữu ích khi định vị các yếu tố hình ảnh với yêu cầu căn chỉnh hoặc thiết kế cụ thể.

Để xoay một hình dạng trên slide, hãy thực hiện các bước sau:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation/) .
2. Lấy một tham chiếu tới slide theo chỉ mục của nó.
3. Thêm một [IAutoShape](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iautoshape/) vào slide.
4. Đặt thuộc tính xoay của hình dạng thành góc mong muốn.
5. Lưu bản trình chiếu.

```java
import com.aspose.slides.*;

// Khởi tạo lớp Presentation đại diện cho một tệp bài thuyết trình.
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

Kết quả:

![Xoay hình dạng](shape-rotation.png)

## **Thêm Hiệu ứng Bo 3D**

Aspose.Slides cho phép bạn áp dụng hiệu ứng bo 3D cho các hình dạng bằng cách cấu hình các thuộc tính [ThreeDFormat](https://reference.aspose.com/slides/vi/java/com.aspose.slides/threedformat/) .

Để thêm hiệu ứng bo 3D cho một hình dạng, hãy thực hiện các bước sau:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation/) .
2. Lấy một tham chiếu tới slide theo chỉ mục của nó.
3. Thêm một [IAutoShape](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iautoshape/) vào slide.
4. Cấu hình [ThreeDFormat] của hình dạng để định nghĩa các cài đặt bo.
5. Lưu bản trình chiếu.

```java
import com.aspose.slides.*;
import java.awt.Color;

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

Aspose.Slides cho phép bạn áp dụng hiệu ứng xoay 3D cho các hình dạng bằng cách cấu hình các thuộc tính [ThreeDFormat](https://reference.aspose.com/slides/vi/java/com.aspose.slides/threedformat/) .

Để áp dụng xoay 3D cho một hình dạng:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation/) .
2. Lấy một tham chiếu tới slide theo chỉ mục của nó.
3. Thêm một [IAutoShape](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iautoshape/) vào slide.
4. Sử dụng [setCameraType](https://reference.aspose.com/slides/vi/java/com.aspose.slides/icamera/#setCameraType-int-) và [setLightType](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ilightrig/#setLightType-int-) để định nghĩa xoay 3D.
5. Lưu bản trình chiếu.

```java
import com.aspose.slides.*;

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

## **Kiểm soát Định dạng Đen‑Trắng cho Hình dạng**

Phương thức [IShape.setBlackWhiteMode](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ishape/#setBlackWhiteMode-byte-) xác định cách một hình dạng riêng lẻ được hiển thị khi bản trình chiếu được xem hoặc xử lý ở chế độ đen‑trắng. Nó không tự động bật hiển thị đen‑trắng, và không thay đổi màu nền, đường viền hoặc các định dạng khác của hình dạng trong chế độ màu bình thường.

Bạn có thể sử dụng một giá trị từ lớp [BlackWhiteMode](https://reference.aspose.com/slides/vi/java/com.aspose.slides/blackwhitemode/) để chọn hành vi mong muốn. Ví dụ, `Automatic` cho phép ứng dụng hiển thị lựa chọn chuyển đổi, `Gray` và `LightGray` dùng màu xám, `BlackWhite` chỉ sử dụng màu đen và trắng, `Black` và `White` ép buộc một màu duy nhất, `Color` giữ nguyên màu bình thường, và `Hidden` loại bỏ hình dạng trong chế độ đen‑trắng. `NotDefined` có nghĩa là không có chế độ nào được gán cho hình dạng.

Đoạn mã Java sau tạo một hình dạng có màu và làm cho nó hiển thị màu xám trong chế độ hiển thị đen‑trắng:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(Color.ORANGE);

    // Giữ màu nền cam trong chế độ màu, nhưng hiển thị hình dạng với màu xám trong chế độ đen-trắng.
    shape.setBlackWhiteMode(BlackWhiteMode.Gray);

    presentation.save("shape_black_white_mode.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Trong chế độ màu bình thường, hình chữ nhật vẫn giữ màu nền cam. Trong quy trình hiển thị đen‑trắng, nó sẽ sử dụng màu xám vì chế độ được đặt thành `Gray`. Điều này cho phép bạn giữ nguyên slide màu đầy đủ trong khi định nghĩa một giao diện riêng cho việc in ấn, xem trước, hoặc các quy trình khác tôn trọng cài đặt hiển thị đen‑trắng của bản trình chiếu.

## **Đặt lại Định dạng**

Đoạn mã Java sau cho thấy cách đặt lại định dạng của một slide và khôi phục vị trí, kích thước, và định dạng của tất cả các hình dạng có placeholder trên [LayoutSlide](https://reference.aspose.com/slides/vi/java/com.aspose.slides/layoutslide/) về cài đặt mặc định của chúng:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        // Đặt lại mỗi hình dạng trên slide có placeholder trên layout.
        slide.reset();
    }
    presentation.save("reset_formatting.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Câu hỏi thường gặp**

**Việc định dạng hình dạng có ảnh hưởng đến kích thước cuối cùng của tệp bản trình chiếu không?**

Chỉ rất ít. Các hình ảnh và phương tiện nhúng chiếm phần lớn dung lượng tệp, trong khi các tham số hình dạng như màu, hiệu ứng và gradient được lưu dưới dạng metadata và hầu như không làm tăng kích thước.

**Làm thế nào tôi có thể phát hiện các hình dạng trên một slide có cùng định dạng để có thể nhóm chúng lại?**

So sánh các thuộc tính định dạng chính của mỗi hình dạng — cài đặt fill, line và effect. Nếu tất cả các giá trị tương ứng khớp nhau, coi chúng là có cùng style và nhóm các hình dạng đó lại, điều này giúp đơn giản hoá việc quản lý style sau này.

**Tôi có thể lưu một bộ các style hình dạng tùy chỉnh vào một tệp riêng để tái sử dụng trong các bản trình chiếu khác không?**

Đúng. Lưu các hình mẫu có style mong muốn vào một bộ slide mẫu hoặc tệp .POTX. Khi tạo bản trình chiếu mới, mở mẫu, sao chép các hình dạng đã được style và áp dụng lại định dạng ở nơi cần.