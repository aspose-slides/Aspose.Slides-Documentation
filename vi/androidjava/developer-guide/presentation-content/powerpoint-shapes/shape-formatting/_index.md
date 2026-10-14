---
title: Định dạng hình dạng PowerPoint trên Android
linktitle: Định dạng Hình dạng
type: docs
weight: 20
url: /vi/androidjava/shape-formatting/
keywords:
- định dạng hình dạng
- định dạng đường viền
- hiệu ứng phác họa
- đường viền hình dạng phác họa
- định dạng kiểu nối
- đổ gradient
- đổ pattern
- đổ hình ảnh
- đổ texture
- đổ màu đặc
- độ trong suốt hình dạng
- hiển thị hình dạng đen‑trắng
- hiển thị hình dạng xám
- xoay hình dạng
- hiệu ứng bevel 3D
- hiệu ứng xoay 3D
- đặt lại định dạng
- PowerPoint
- bản trình chiếu
- Android
- Java
- Aspose.Slides
description: "Tìm hiểu cách định dạng các hình dạng PowerPoint trên Android bằng Aspose.Slides—đặt các kiểu fill, line và effect cho tệp PPT, PPTX và ODP một cách chính xác và kiểm soát toàn diện."
---
## **Giới thiệu**

Trong PowerPoint, bạn có thể thêm các hình dạng vào các slide. Vì các hình dạng được tạo thành từ các đường, bạn có thể định dạng chúng bằng cách sửa đổi hoặc áp dụng hiệu ứng cho đường viền. Ngoài ra, bạn cũng có thể định dạng hình dạng bằng cách chỉ định các thiết lập kiểm soát cách nội bộ của chúng được tô màu.

![định dạng hình PowerPoint](format-shape-powerpoint.png)

Aspose.Slides for Android via Java cung cấp các giao diện và phương thức cho phép bạn định dạng hình dạng bằng cùng các tùy chọn có trong PowerPoint.

## **Định dạng Đường viền**

Sử dụng Aspose.Slides, bạn có thể chỉ định kiểu đường viền tùy chỉnh cho một hình dạng. Các bước sau mô tả quy trình:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) .
1. Lấy tham chiếu tới một slide theo chỉ mục của nó.
1. Thêm một [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) vào slide.
1. Đặt [line style](https://reference.aspose.com/slides/androidjava/com.aspose.slides/linestyle/) cho hình dạng.
1. Đặt độ rộng của đường viền.
1. Đặt [dash style](https://reference.aspose.com/slides/androidjava/com.aspose.slides/linedashstyle/) cho đường viền.
1. Đặt màu đường viền cho hình dạng.
1. Lưu bản trình bày đã chỉnh sửa dưới dạng tệp PPTX.

Mã sau minh họa cách định dạng một `AutoShape` hình chữ nhật:

```java
import com.aspose.slides.*;
import java.awt.Color;

// Tạo thể hiện của lớp Presentation đại diện cho một tệp bản trình chiếu.
Presentation presentation = new Presentation();
try {
    // Lấy slide đầu tiên.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Thêm một auto shape loại Rectangle.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 150, 75);

    // Xóa phần fill khỏi hình chữ nhật để chỉ các đường viền hiển thị.
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

![Các đường viền đã được định dạng trong bản trình bày](formatted-lines.png)

## **Áp dụng Hiệu ứng Phác họa cho Đường viền Hình dạng**

Hiệu ứng phác họa làm cho đường viền hình dạng trông như được vẽ tay. Sử dụng [IShape.getLineFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/) để truy cập cài đặt đường viền, [ILineFormat.getSketchFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/) để truy cập cài đặt phác họa, và [ISketchFormat.setSketchType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/isketchformat/) để chọn một giá trị trong enum [LineSketchType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/linesketchtype/) .

Mã Java sau cho thấy cách áp dụng hiệu ứng [LineSketchType.Curved](https://reference.aspose.com/slides/androidjava/com.aspose.slides/linesketchtype/) , đọc giá trị đã gán một cách rõ ràng, và loại bỏ hiệu ứng bằng [LineSketchType.None](https://reference.aspose.com/slides/androidjava/com.aspose.slides/linesketchtype/) :

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);

    // Truy cập định dạng đường viền của hình và định dạng phác họa của nó.
    ISketchFormat sketchFormat = shape.getLineFormat().getSketchFormat();

    // Áp dụng hiệu ứng phác họa.
    sketchFormat.setSketchType(LineSketchType.Curved);

    // Đọc hiệu ứng phác họa được gán trực tiếp cho hình.
    int explicitSketchType = sketchFormat.getSketchType();
    System.out.println("Explicit sketch type: " + explicitSketchType);

    // Loại bỏ hiệu ứng phác họa.
    sketchFormat.setSketchType(LineSketchType.None);
} finally {
    presentation.dispose();
}
```

Giá trị trả về bởi [ISketchFormat.getSketchType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/isketchformat/) đại diện cho cài đặt được gán trực tiếp cho hình dạng. Nếu định dạng đường viền có thể được kế thừa từ một theme, master slide hoặc layout slide, hãy sử dụng [ILineFormat.getEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/) , truy cập [ILineFormatEffectiveData.getSketchFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformateffectivedata/) , và đọc [ISketchFormatEffectiveData.getSketchType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/isketchformateffectivedata/) . Giá trị hiệu quả phản ánh định dạng thực tế được áp dụng sau khi kế thừa được giải quyết:

```java
import com.aspose.slides.*;

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

* Round
* Miter
* Bevel

Mặc định, khi PowerPoint nối hai đường ở một góc (chẳng hạn ở góc của hình dạng), nó sử dụng cài đặt **Round**. Tuy nhiên, nếu bạn đang vẽ một hình dạng có các góc nhọn, bạn có thể muốn chọn tùy chọn **Miter**.

![Kiểu nối trong bản trình bày](join-style-powerpoint.png)

Mã Java sau minh họa cách ba hình chữ nhật (như trong ảnh trên) được tạo ra bằng các cài đặt kiểu nối Miter, Bevel và Round:

```java
import com.aspose.slides.*;
import java.awt.Color;

// Tạo thể hiện của lớp Presentation đại diện cho một tệp bản trình chiếu.
Presentation presentation = new Presentation();
try {
    // Lấy slide đầu tiên.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Thêm ba auto shape loại Rectangle.
    IAutoShape shape1 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 75);
    IAutoShape shape2 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 210, 20, 150, 75);
    IAutoShape shape3 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 135, 150, 75);

    // Đặt màu fill cho mỗi hình chữ nhật.
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

Trong PowerPoint, Đổ Gradient là một tùy chọn định dạng cho phép bạn áp dụng một dải màu liên tục vào một hình dạng. Ví dụ, bạn có thể áp dụng hai màu hoặc nhiều màu sao cho một màu dần dần chuyển sang màu khác.

Cách áp dụng đổ gradient cho một hình dạng bằng Aspose.Slides:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) .
1. Lấy tham chiếu tới một slide theo chỉ mục của nó.
1. Thêm một [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) vào slide.
1. Đặt [FillType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/filltype/) của hình dạng thành `Gradient` .
1. Thêm hai màu ưa thích của bạn với vị trí đã xác định bằng các phương thức `add` của collection gradient stop được mở rộng bởi giao diện [IGradientFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igradientformat/) .
1. Lưu bản trình bày đã chỉnh sửa dưới dạng tệp PPTX.

Mã Java sau minh họa cách áp dụng hiệu ứng đổ gradient cho một hình ellipse:

```java
import com.aspose.slides.*;

// Tạo thể hiện của lớp Presentation đại diện cho một tệp bản trình chiếu.
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

    // Lưu tệp PPTX vào ổ đĩa.
    presentation.save("gradient_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Kết quả:

![Ellipse với đổ gradient](gradient-fill.png)

Nếu gradient trông khác trong ảnh xuất ra so với trong PowerPoint, xem phần [Choose a Gradient Rendering Style](/slides/vi/androidjava/convert-powerpoint-to-png/#choose-a-gradient-rendering-style). Bạn có thể chọn kiểu hiển thị mà không thay đổi gradient đã lưu trong bản trình bày.

## **Đổ Pattern**

Trong PowerPoint, Đổ Pattern là một tùy chọn định dạng cho phép bạn áp dụng một thiết kế hai màu—như chấm, sọc, giao chéo hoặc ô vuông—vào một hình dạng. Bạn có thể chọn màu tùy chỉnh cho nền và màu nền trước của pattern.

Aspose.Slides cung cấp hơn 45 kiểu pattern có sẵn mà bạn có thể áp dụng cho các hình dạng để tăng tính thẩm mỹ cho bản trình chiếu. Ngay cả sau khi chọn một pattern có sẵn, bạn vẫn có thể chỉ định chính xác các màu mà nó sẽ sử dụng.

Cách áp dụng pattern cho một hình dạng bằng Aspose.Slides:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) .
1. Lấy tham chiếu tới một slide theo chỉ mục của nó.
1. Thêm một [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) vào slide.
1. Đặt [FillType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/filltype/) của hình dạng thành `Pattern` .
1. Chọn một kiểu pattern từ các tùy chọn có sẵn.
1. Đặt [Background Color](https://reference.aspose.com/slides/androidjava/com.aspose.slides/patternformat/#getBackColor--) của pattern.
1. Đặt [Foreground Color](https://reference.aspose.com/slides/androidjava/com.aspose.slides/patternformat/#getForeColor--) của pattern.
1. Lưu bản trình bày đã chỉnh sửa dưới dạng tệp PPTX.

Mã Java sau minh họa cách áp dụng pattern cho một hình chữ nhật:

```java
import com.aspose.slides.*;
import java.awt.Color;

// Tạo thể hiện của lớp Presentation đại diện cho một tệp bản trình chiếu.
Presentation presentation = new Presentation();
try {
    // Lấy slide đầu tiên.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Thêm một auto shape loại Rectangle.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Đặt kiểu fill là Pattern.
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

![Hình chữ nhật với pattern](pattern-fill.png)

## **Đổ Hình Ảnh**

Trong PowerPoint, Đổ Hình Ảnh là một tùy chọn định dạng cho phép bạn chèn một hình ảnh vào bên trong một hình dạng—hiệu quả như việc sử dụng hình ảnh làm nền cho hình dạng.

Cách sử dụng Aspose.Slides để áp dụng đổ hình ảnh cho một hình dạng:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) .
1. Lấy tham chiếu tới một slide theo chỉ mục của nó.
1. Thêm một [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) vào slide.
1. Đặt [FillType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/filltype/) của hình dạng thành `Picture` .
1. Đặt chế độ đổ hình ảnh thành `Tile` (hoặc chế độ ưa thích khác).
1. Tạo một đối tượng [IPPImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ippimage/) từ hình ảnh bạn muốn sử dụng.
1. Truyền hình ảnh vào phương thức `ISlidesPicture.setImage` .
1. Lưu bản trình bày đã chỉnh sửa dưới dạng tệp PPTX.

Giả sử chúng ta có tệp "lotus.png" với hình ảnh sau:

![Hình lotus](lotus.png)

Mã Java sau minh họa cách đổ hình ảnh vào một hình dạng:

```java
import com.aspose.slides.*;

// Tạo thể hiện của lớp Presentation đại diện cho một tệp bản trình chiếu.
Presentation presentation = new Presentation();
try {
    // Lấy slide đầu tiên.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Thêm một auto shape loại Rectangle.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 255, 130);
    
    // Đặt kiểu fill là Picture.
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

![Hình dạng với đổ hình ảnh](picture-fill.png)

### **Tile Picture As Texture**

Nếu bạn muốn đặt một hình ảnh lát gạch làm texture và tùy chỉnh hành vi lát, bạn có thể sử dụng các phương thức sau của giao diện [IPictureFillFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/) và lớp [PictureFillFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/picturefillformat/) :

- [setPictureFillMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#setPictureFillMode-int-): Đặt chế độ đổ hình ảnh—`Tile` hoặc `Stretch` .
- [setTileAlignment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#setTileAlignment-byte-): Xác định cách căn chỉnh các lát trong hình dạng.
- [setTileFlip](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#setTileFlip-int-): Kiểm soát việc lật lát theo chiều ngang, dọc hoặc cả hai.
- [setTileOffsetX](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#setTileOffsetX-float-): Đặt độ lệch ngang của lát (theo point) so với gốc của hình dạng.
- [setTileOffsetY](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#setTileOffsetY-float-): Đặt độ lệch dọc của lát (theo point) so với gốc của hình dạng.
- [setTileScaleX](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#setTileScaleX-float-): Định nghĩa tỉ lệ mở rộng ngang của lát dưới dạng phần trăm.
- [setTileScaleY](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#setTileScaleY-float-): Định nghĩa tỉ lệ mở rộng dọc của lát dưới dạng phần trăm.

Mẫu mã sau cho thấy cách thêm một hình chữ nhật với đổ hình ảnh lát và cấu hình các tùy chọn lát:

```java
import com.aspose.slides.*;

// Tạo thể hiện của lớp Presentation đại diện cho một tệp bản trình chiếu.
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

    // Cấu hình chế độ đổ hình ảnh và các thuộc tính lát.
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

![Các tùy chọn lát](tile-options.png)

## **Đổ Màu Đặc**

Trong PowerPoint, Đổ Màu Đặc là một tùy chọn định dạng làm đầy một hình dạng bằng một màu duy nhất, đồng nhất. Nền màu này được áp dụng mà không có gradient, texture hay pattern nào.

Để áp dụng đổ màu đặc cho một hình dạng bằng Aspose.Slides, thực hiện các bước sau:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) .
1. Lấy tham chiếu tới một slide theo chỉ mục của nó.
1. Thêm một [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) vào slide.
1. Đặt [FillType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/filltype/) của hình dạng thành `Solid` .
1. Gán màu tô mong muốn cho hình dạng.
1. Lưu bản trình bày đã chỉnh sửa dưới dạng tệp PPTX.

Mã Java sau minh họa cách áp dụng đổ màu đặc cho một hình chữ nhật trong slide PowerPoint:

```java
import com.aspose.slides.*;
import java.awt.Color;

// Tạo thể hiện của lớp Presentation đại diện cho một tệp bản trình chiếu.
Presentation presentation = new Presentation();
try {
    // Lấy slide đầu tiên.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Thêm một auto shape loại Rectangle.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Đặt kiểu fill là Solid.
    shape.getFillFormat().setFillType(FillType.Solid);

    // Đặt màu fill.
    shape.getFillFormat().getSolidFillColor().setColor(Color.YELLOW);

    // Lưu tệp PPTX vào ổ đĩa.
    presentation.save("solid_color_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Kết quả:

![Hình dạng với đổ màu đặc](solid-color-fill.png)

## **Đặt Độ Trong suốt**

Trong PowerPoint, khi bạn áp dụng màu đặc, gradient, hình ảnh hoặc texture cho các hình dạng, bạn cũng có thể đặt mức độ trong suốt để kiểm soát độ mờ của phần tô. Giá trị trong suốt cao hơn làm cho hình dạng trong suốt hơn, cho phép nền hoặc các đối tượng bên dưới hiển thị một phần.

Aspose.Slides cho phép bạn đặt mức độ trong suốt bằng cách điều chỉnh giá trị alpha trong màu được dùng để tô. Cách thực hiện:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) .
1. Lấy tham chiếu tới một slide theo chỉ mục của nó.
1. Thêm một [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) vào slide.
1. Đặt [FillType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/filltype/) thành `Solid` .
1. Sử dụng `Color` để xác định một màu có độ trong suốt (thành phần `alpha` điều khiển mức trong suốt).
1. Lưu bản trình bày.

Mã Java dưới đây minh họa cách áp dụng màu tô trong suốt cho một hình chữ nhật:

```java
import com.aspose.slides.*;
import java.awt.Color;

// Tạo thể hiện của lớp Presentation đại diện cho một tệp bản trình chiếu.
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

    // Lưu tệp PPTX vào ổ đĩa.
    presentation.save("shape_transparency.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Kết quả:

![Hình dạng trong suốt](shape-transparency.png)

## **Xoay Hình dạng**

Aspose.Slides cho phép bạn xoay các hình dạng trong bản trình chiếu PowerPoint. Điều này hữu ích khi cần định vị các yếu tố hình ảnh với yêu cầu căn chỉnh hoặc thiết kế cụ thể.

Để xoay một hình dạng trên slide, thực hiện các bước sau:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) .
1. Lấy tham chiếu tới một slide theo chỉ mục của nó.
1. Thêm một [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) vào slide.
1. Đặt thuộc tính xoay của hình dạng thành góc mong muốn.
1. Lưu bản trình bày.

Mã Java sau minh họa cách xoay một hình dạng 5 độ:

```java
import com.aspose.slides.*;

// Tạo thể hiện của lớp Presentation đại diện cho một tệp bản trình chiếu.
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

![Xoay hình dạng](shape-rotation.png)

## **Thêm Hiệu ứng Đánh bóng 3D**

Aspose.Slides cho phép bạn áp dụng hiệu ứng đánh bóng 3D cho các hình dạng bằng cách cấu hình các thuộc tính [ThreeDFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/threedformat/) của chúng.

Để thêm hiệu ứng đánh bóng 3D cho một hình dạng, thực hiện các bước sau:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) .
1. Lấy tham chiếu tới một slide theo chỉ mục của nó.
1. Thêm một [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) vào slide.
1. Cấu hình [ThreeDFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/threedformat/) của hình dạng để định nghĩa các thiết lập bevel.
1. Lưu bản trình bày.

Mã Java dưới đây cho thấy cách áp dụng hiệu ứng đánh bóng 3D cho một hình dạng:

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

![Hiệu ứng đánh bóng 3D](3D-bevel-effect.png)

## **Thêm Hiệu ứng Xoay 3D**

Aspose.Slides cho phép bạn áp dụng hiệu ứng xoay 3D cho các hình dạng bằng cách cấu hình các thuộc tính [ThreeDFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/threedformat/) của chúng.

Để áp dụng xoay 3D cho một hình dạng:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) .
1. Lấy tham chiếu tới một slide theo chỉ mục của nó.
1. Thêm một [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) vào slide.
1. Sử dụng [setCameraType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icamera/#setCameraType-int-) và [setLightType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilightrig/#setLightType-int-) để định nghĩa xoay 3D.
1. Lưu bản trình bày.

Mã Java dưới đây minh họa cách áp dụng hiệu ứng xoay 3D cho một hình dạng:

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

## **Kiểm soát Hiển thị Đen‑Trắng cho Hình dạng**

Phương thức [IShape.setBlackWhiteMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#setBlackWhiteMode-byte-) xác định cách một hình dạng cá nhân được render khi bản trình chiếu được xem hoặc xử lý ở chế độ đen‑trắng. Nó không kích hoạt chế độ đen‑trắng tự động, và không thay đổi màu nền, đường viền hay các định dạng khác khi ở chế độ màu bình thường.

Sử dụng một giá trị từ lớp [BlackWhiteMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/blackwhitemode/) để chọn hành vi mong muốn. Ví dụ, `Automatic` để ứng dụng render tự động chọn cách chuyển đổi, `Gray` và `LightGray` sử dụng màu xám, `BlackWhite` chỉ dùng màu đen và trắng, `Black` và `White` ép buộc một màu duy nhất, `Color` giữ nguyên màu bình thường, và `Hidden` loại bỏ hình dạng trong chế độ đen‑trắng. `NotDefined` nghĩa là không có chế độ cấp cho hình dạng.

Mã Java dưới đây tạo một hình dạng màu và làm cho nó hiển thị màu xám trong chế độ hiển thị đen‑trắng:

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(Color.rgb(255, 165, 0));

    // Giữ màu nền cam ở chế độ màu, nhưng render hình dạng với màu xám trong chế độ đen‑trắng.
    shape.setBlackWhiteMode(BlackWhiteMode.Gray);

    presentation.save("shape_black_white_mode.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Trong chế độ màu bình thường, hình chữ nhật vẫn giữ màu nền cam. Khi ở quy trình hiển thị đen‑trắng, nó sẽ sử dụng màu xám vì chế độ đã được đặt thành `Gray`. Điều này giúp bạn giữ nguyên slide màu đầy đủ trong khi định nghĩa một dạng hiển thị riêng cho việc in ấn, xem trước hoặc các quy trình khác tôn trọng cài đặt hiển thị đen‑trắng của bản trình chiếu.

## **Đặt lại Định dạng**

Mã Java dưới đây cho thấy cách đặt lại định dạng của một slide và khôi phục vị trí, kích thước và định dạng của tất cả các hình dạng với placeholders trên [LayoutSlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/layoutslide/) về các thiết lập mặc định:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        // Đặt lại mỗi hình dạng trên slide mà có placeholder trên layout.
        slide.reset();
    }
    presentation.save("reset_formatting.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Việc định dạng hình dạng có ảnh hưởng đến kích thước cuối cùng của tệp bản trình chiếu không?**

Chỉ ảnh hưởng rất ít. Các hình ảnh và phương tiện nhúng chiếm phần lớn dung lượng tệp, còn các tham số hình dạng như màu, hiệu ứng và gradient chỉ được lưu dưới dạng metadata và gần như không làm tăng kích thước.

**Làm sao tôi có thể phát hiện các hình dạng trên một slide có cùng định dạng để có thể nhóm chúng lại?**

So sánh các thuộc tính định dạng chính của mỗi hình dạng—các thiết lập fill, line và effect. Nếu tất cả các giá trị tương ứng khớp nhau, coi chúng là cùng một kiểu và nhóm chúng lại, giúp việc quản lý kiểu sau này dễ dàng hơn.

**Tôi có thể lưu một tập hợp các kiểu hình dạng tùy chỉnh vào một tệp riêng để tái sử dụng trong các bản trình chiếu khác không?**

Có. Lưu các hình mẫu với các kiểu mong muốn vào một slide mẫu hoặc tệp mẫu .POTX. Khi tạo bản trình chiếu mới, mở mẫu, sao chép các hình đã định dạng cần thiết và áp dụng lại định dạng cho các đối tượng cần thiết.