---
title: Định dạng các hình PowerPoint trong Java
linktitle: Định dạng hình
type: docs
weight: 20
url: /vi/java/shape-formatting/
keywords:
- định dạng hình
- định dạng đường
- hiệu ứng phác thảo
- đường nét hình phác thảo
- định dạng kiểu nối
- độ đổ gradient
- độ đổ mẫu
- độ đổ ảnh
- độ đổ kết cấu
- độ đổ màu đặc
- độ trong suốt của hình
- hiển thị hình đen‑trắng
- hiển thị hình xám
- xoay hình
- hiệu ứng bo 3D
- hiệu ứng xoay 3D
- đặt lại định dạng
- PowerPoint
- bản thuyết trình
- Java
- Aspose.Slides
description: "Tìm hiểu cách định dạng các hình PowerPoint trong Java bằng Aspose.Slides—đặt các kiểu đổ, đường viền và hiệu ứng cho tệp PPT và PPTX một cách chính xác và kiểm soát đầy đủ."
---
## **Giới thiệu**

Định dạng các hình dạng trong PowerPoint bằng cách điều chỉnh đường viền, tô màu và hiệu ứng. Aspose.Slides for Java cho phép bạn kiểm soát các cài đặt này bằng lập trình, bao gồm độ trong suốt, xoay và định dạng 3D.

![Các tùy chọn định dạng hình dạng trong PowerPoint](format-shape-powerpoint.png)

Aspose.Slides for Java cung cấp các giao diện và phương thức cho phép bạn định dạng các hình dạng bằng các tùy chọn có sẵn trong PowerPoint.

## **Định dạng Đường viền**

Sử dụng [IShape.getLineFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#getLineFormat--) để điều khiển đường viền của hình. Ví dụ này tạo một hình chữ nhật không tô màu với viền màu xanh dương dạng gạch đứt. [ILineFormat.setStyle](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#setStyle-byte-) chọn một đường hợp chất dày-mỏng, trong khi [ILineFormat.setWidth](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#setWidth-double-) đặt độ rộng của nó là 7 điểm và [ILineFormat.setDashStyle](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#setDashStyle-byte-) chọn mẫu gạch.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);
    shape.getFillFormat().setFillType(FillType.NoFill);
    shape.getLineFormat().setStyle(LineStyle.ThickThin);
    shape.getLineFormat().setWidth(7);
    shape.getLineFormat().setDashStyle(LineDashStyle.Dash);
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);

    presentation.save("formatted_lines.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Kết quả:

![Các đường viền đã định dạng trong bài thuyết trình](formatted-lines.png)

### **Đặt Mẫu Gạch Đường Tùy Chỉnh**

Sử dụng [ILineFormat.setCustomDashPattern](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#setCustomDashPattern-float---) khi các kiểu đường viền được định sẵn không cung cấp độ dài gạch và khoảng trống bạn cần, ví dụ cho các viền thương hiệu hoặc sơ đồ kỹ thuật. Gán một mẫu sẽ tự động thay đổi kiểu gạch của đường thành [LineDashStyle.Custom](https://reference.aspose.com/slides/java/com.aspose.slides/linedashstyle/).

Các mục trong mảng xen kẽ giữa độ dài gạch và khoảng trống, bắt đầu bằng một gạch. Mỗi giá trị là bội số của độ rộng đường: `{ 4, 2 }` với độ rộng 3 điểm tạo ra gạch dài 12 điểm tiếp theo là khoảng trống 6 điểm. Sử dụng các cặp giá trị hữu hạn, không âm để xác định các đoạn gạch‑khoảng trống hoàn chỉnh. Ví dụ sử dụng các giá trị dương để giữ mọi gạch và khoảng trống hiển thị.

Ví dụ này tạo năm đường màu xanh với cùng độ dài và đầu phẳng. Ba đường đầu tiên so sánh các mẫu ở độ rộng 3 điểm. Đường thứ tư lặp lại mẫu đầu tiên ở độ rộng gấp đôi, tăng gấp đôi cả độ dài gạch và khoảng trống. Đường thứ năm chuyển từ mẫu tùy chỉnh sang đường đặc.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    presentation.getSlideSize().setSize(600, 300, SlideSizeScaleType.DoNotScale);
    ISlide slide = presentation.getSlides().get_Item(0);

    float[][] patterns = {
        { 4, 2 },
        { 1, 2 },
        { 6, 2, 1, 2 },
        { 4, 2 },
        { 4, 2 }
    };

    for (int i = 0; i < patterns.length; i++) {
        IAutoShape line = slide.getShapes().addAutoShape(ShapeType.Line, 50, 50 + i * 50, 500, 0);
        line.getLineFormat().setWidth(i == 3 ? 6 : 3);
        line.getLineFormat().getFillFormat().setFillType(FillType.Solid);
        line.getLineFormat().getFillFormat().getSolidFillColor().setColor(new Color(0, 0, 139));
        line.getLineFormat().setCapStyle(LineCapStyle.Flat);
        line.getLineFormat().setBeginArrowheadStyle(LineArrowheadStyle.None);
        line.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.None);
        line.getLineFormat().setCustomDashPattern(patterns[i]);
    }

    // Chuyển dòng cuối cùng sang kiểu đặc.
    slide.getShapes().get_Item(4).getLineFormat().setDashStyle(LineDashStyle.Solid);

    presentation.save("custom_dash_patterns.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Để quay lại kiểu gạch định sẵn, truyền [LineDashStyle.Dash](https://reference.aspose.com/slides/java/com.aspose.slides/linedashstyle/) tới [ILineFormat.setDashStyle](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#setDashStyle-byte-). Kiểu đã chọn kiểm soát giao diện của đường.

Kết quả trong PowerPoint, từ trên xuống dưới: **{4, 2}, 3 pt**; **{1, 2}, 3 pt**; **{6, 2, 1, 2}, 3 pt**; **{4, 2}, 6 pt**; và **Solid, 3 pt**.

![Ba mẫu gạch tùy chỉnh, một đường rộng hơn sử dụng mẫu đầu tiên, và một đường đặc trong PowerPoint](custom-dash-patterns.png)

### **Đặt Đầu Đường**

Sử dụng [ILineFormat.setCapStyle](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#setCapStyle-byte-) để cài đặt các đầu của một đường mở. Lớp [LineCapStyle](https://reference.aspose.com/slides/java/com.aspose.slides/linecapstyle/) cung cấp ba kiểu đầu rõ ràng:

- `Flat`: Đường nét dừng lại tại điểm cuối.
- `Round`: Một đầu vòng cung bán tròn kéo dài ra ngoài điểm cuối một nửa độ rộng đường.
- `Square`: Một đầu vuông kéo dài ra ngoài điểm cuối một nửa độ rộng đường.

Lớp cũng bao gồm `NotDefined`, có nghĩa là không có kiểu đầu nào được gán một cách rõ ràng.

Đầu khác với mũi tên, mà thêm biểu tượng vào cuối đường, và các nối, mà kiểm soát các góc giữa các đoạn đường. Ví dụ này tắt mũi tên thông qua [ILineFormat.setBeginArrowheadStyle](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#setBeginArrowheadStyle-byte-) và [ILineFormat.setEndArrowheadStyle](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#setEndArrowheadStyle-byte-) để chỉ so sánh các hình dạng đầu.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    presentation.getSlideSize().setSize(500, 240, SlideSizeScaleType.DoNotScale);
    ISlide slide = presentation.getSlides().get_Item(0);

    byte[] capStyles = new byte[] { LineCapStyle.Flat, LineCapStyle.Round, LineCapStyle.Square };

    for (int i = 0; i < capStyles.length; i++) {
        IAutoShape line = slide.getShapes().addAutoShape(ShapeType.Line, 100, 50 + i * 70, 300, 0);
        line.getLineFormat().setWidth(20);
        line.getLineFormat().getFillFormat().setFillType(FillType.Solid);
        line.getLineFormat().getFillFormat().getSolidFillColor().setColor(new Color(0, 0, 139));
        line.getLineFormat().setDashStyle(LineDashStyle.Solid);
        line.getLineFormat().setCapStyle(capStyles[i]);
        line.getLineFormat().setBeginArrowheadStyle(LineArrowheadStyle.None);
        line.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.None);
    }

    presentation.save("line_caps.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Kết quả trong PowerPoint, từ trên xuống dưới: **Flat**, **Round**, và **Square**.

![Đầu phẳng, tròn và vuông trên các đường dày giống nhau trong PowerPoint](line-caps.png)

## **Áp dụng hiệu ứng phác thảo cho đường viền hình**

Một hiệu ứng phác thảo làm cho đường viền hình trông như được vẽ tay. Sử dụng [IShape.getLineFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#getLineFormat--) để truy cập cài đặt đường, [ILineFormat.getSketchFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#getSketchFormat--) để truy cập cài đặt phác thảo, và [ISketchFormat.setSketchType](https://reference.aspose.com/slides/java/com.aspose.slides/isketchformat/#setSketchType-int-) để chọn một giá trị từ lớp [LineSketchType](https://reference.aspose.com/slides/java/com.aspose.slides/linesketchtype/).

Đoạn mã Java sau hiển thị cách áp dụng hiệu ứng [LineSketchType.Curved](https://reference.aspose.com/slides/java/com.aspose.slides/linesketchtype/) , đọc giá trị đã gán rõ ràng, và loại bỏ hiệu ứng bằng [LineSketchType.None](https://reference.aspose.com/slides/java/com.aspose.slides/linesketchtype/):

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);

    ISketchFormat sketchFormat = shape.getLineFormat().getSketchFormat();
    sketchFormat.setSketchType(LineSketchType.Curved);
    int explicitSketchType = sketchFormat.getSketchType();
    System.out.println("Explicit sketch type: " + explicitSketchType);
    sketchFormat.setSketchType(LineSketchType.None);
} finally {
    presentation.dispose();
}
```

Giá trị trả về bởi [ISketchFormat.getSketchType](https://reference.aspose.com/slides/java/com.aspose.slides/isketchformat/#getSketchType--) đại diện cho cài đặt được gán trực tiếp cho hình. Nếu định dạng đường có thể được kế thừa từ chủ đề, slide chủ, hoặc slide bố cục, hãy sử dụng [ILineFormat.getEffective](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#getEffective--), truy cập [ILineFormatEffectiveData.getSketchFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformateffectivedata/#getSketchFormat--), và đọc [ISketchFormatEffectiveData.getSketchType](https://reference.aspose.com/slides/java/com.aspose.slides/isketchformateffectivedata/#getSketchType--). Giá trị thực tế phản ánh định dạng thực sự được áp dụng sau khi kế thừa được giải quyết. Ví dụ này yêu cầu một bản thuyết trình hiện có có ít nhất một hình trên slide đầu tiên và in cả hai giá trị:

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

Đây là ba tùy chọn kiểu nối:

* Round
* Miter
* Bevel

Kiểu nối kiểm soát cách hai đoạn viền gặp nhau tại một góc. Sử dụng **Round** cho các góc tròn, **Miter** cho các góc nhọn, hoặc **Bevel** cho các góc làm phẳng.

![Kiểu nối trong bản trình chiếu](join-style-powerpoint.png)

Ví dụ này tạo ba hình chữ nhật đen với viền màu xanh dày 15 điểm. Nó sử dụng [ILineFormat.setJoinStyle](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#setJoinStyle-byte-) để đặt các giá trị miter, bevel và round của [LineJoinStyle](https://reference.aspose.com/slides/java/com.aspose.slides/linejoinstyle/), tương ứng, để so sánh cách vẽ các góc.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape miterShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 75);
    IAutoShape bevelShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 210, 20, 150, 75);
    IAutoShape roundShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 135, 150, 75);

    miterShape.getFillFormat().setFillType(FillType.Solid);
    miterShape.getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    bevelShape.getFillFormat().setFillType(FillType.Solid);
    bevelShape.getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    roundShape.getFillFormat().setFillType(FillType.Solid);
    roundShape.getFillFormat().getSolidFillColor().setColor(Color.BLACK);

    miterShape.getLineFormat().setWidth(15);
    bevelShape.getLineFormat().setWidth(15);
    roundShape.getLineFormat().setWidth(15);

    miterShape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    miterShape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    bevelShape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    bevelShape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    roundShape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    roundShape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);

    miterShape.getLineFormat().setJoinStyle(LineJoinStyle.Miter);
    bevelShape.getLineFormat().setJoinStyle(LineJoinStyle.Bevel);
    roundShape.getLineFormat().setJoinStyle(LineJoinStyle.Round);

    miterShape.getTextFrame().setText("Miter Join Style");
    bevelShape.getTextFrame().setText("Bevel Join Style");
    roundShape.getTextFrame().setText("Round Join Style");

    presentation.save("join_styles.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Giới hạn Nối Miter ở Các Góc Nhọn**

Sử dụng [ILineFormat.setMiterLimit](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#setMiterLimit-float-) cùng với [ILineFormat.setJoinStyle](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#setJoinStyle-byte-) được đặt thành [LineJoinStyle.Miter](https://reference.aspose.com/slides/java/com.aspose.slides/linejoinstyle/) để giới hạn độ dài của góc nhọn.

Giới hạn là tỉ lệ giữa khoảng cách giữa các góc trong và ngoài của nối so với độ rộng đường. Ví dụ, giá trị `8` cho phép độ dài miter lên tới tám lần độ rộng đường; nó không phải là đo bằng điểm. Nếu góc vượt quá giới hạn, PowerPoint sẽ sử dụng nối bevel tại góc đó. Giới hạn lớn hơn cho phép các đầu nhọn hơn. Cài đặt này chỉ ảnh hưởng đến nối miter và không có hiệu quả nhìn thấy khi góc vẫn nằm trong cả hai giới hạn.

Ví dụ này tạo hai tam giác giống nhau, không tô màu, với viền dày 20 điểm. Tam giác bên trái sử dụng giới hạn `2`, còn bên phải sử dụng `8`. Mỗi tam giác rộng 80 điểm và cao 160 điểm, cho tỷ lệ độ dài miter‑so‑độ‑rộng‑đường khoảng `4.12`. Do đó, PowerPoint bevel góc trái và giữ nguyên góc phải.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    presentation.getSlideSize().setSize(500, 320, SlideSizeScaleType.DoNotScale);
    ISlide slide = presentation.getSlides().get_Item(0);

    float[] miterLimits = new float[] { 2f, 8f };

    for (int i = 0; i < miterLimits.length; i++) {
        IAutoShape triangle = slide.getShapes().addAutoShape(ShapeType.Triangle, 90 + i * 240, 110, 80, 160);
        triangle.getFillFormat().setFillType(FillType.NoFill);
        triangle.getLineFormat().setWidth(20);
        triangle.getLineFormat().getFillFormat().setFillType(FillType.Solid);
        triangle.getLineFormat().getFillFormat().getSolidFillColor().setColor(new Color(0, 0, 139));
        triangle.getLineFormat().setJoinStyle(LineJoinStyle.Miter);
        triangle.getLineFormat().setMiterLimit(miterLimits[i]);
    }

    presentation.save("miter_limits.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Kết quả trong PowerPoint: **Miter limit 2** ở bên trái và **miter limit 8** ở bên phải.

![Đỉnh được vuông góc với giới hạn miter 2 và đỉnh nhọn với giới hạn miter 8 trong PowerPoint](miter-limits.png)

## **Đổ Màu Độ Trơn**

Độ trơn màu pha màu qua một hình. Ví dụ này tô một hình elip bằng độ trơn tuyến tính góc 45 độ từ đỏ sang tím bằng cách sử dụng [IFillFormat.getGradientFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformat/#getGradientFormat--). Phương thức [IGradientStopCollection.addPresetColor](https://reference.aspose.com/slides/java/com.aspose.slides/igradientstopcollection/#addPresetColor-float-int-) đặt các điểm dừng màu tại 0 và 1, đầu và cuối của gradient. Xóa các điểm dừng hiện có đảm bảo chỉ hai màu này được sử dụng.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 50, 150, 75);
    shape.getFillFormat().setFillType(FillType.Gradient);
    shape.getFillFormat().getGradientFormat().setGradientShape(GradientShape.Linear);
    shape.getFillFormat().getGradientFormat().setLinearGradientAngle(45);
    shape.getFillFormat().getGradientFormat().getGradientStops().clear();
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor(1.0f, PresetColor.Purple);
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor(0.0f, PresetColor.Red);

    presentation.save("gradient_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Kết quả:

![Hình elip với độ trơn màu gradient](gradient-fill.png)

Nếu một gradient trông khác trong ảnh xuất khẩu so với trong PowerPoint, xem [Choose a Gradient Rendering Style](/slides/vi/java/convert-powerpoint-to-png/#choose-a-gradient-rendering-style). Bạn có thể chọn kiểu hiển thị mà không thay đổi gradient được lưu trong bản thuyết trình.

### **Đặt Góc Gradient Tuyến Tính**

Sử dụng [IGradientFormat.setLinearGradientAngle](https://reference.aspose.com/slides/java/com.aspose.slides/igradientformat/#setLinearGradientAngle-float-) để kiểm soát hướng của độ trơn [GradientShape.Linear](https://reference.aspose.com/slides/java/com.aspose.slides/gradientshape/). Góc đo bằng độ và tăng theo chiều kim đồng hồ: `0` chạy từ trái sang phải, `90` từ trên xuống dưới, `180` từ phải sang trái, và `270` từ dưới lên trên. Hỗ trợ góc thập phân. Các góc ngoài phạm vi `[0, 360)` được chuẩn hoá lại; ví dụ, `-45` trở thành `315` và `360` trở thành `0`.

Ví dụ này tạo sáu hình chữ nhật với các điểm dừng màu đỏ, xanh lá và xanh dương giống nhau tại vị trí `0`, `0.5`, và `1`. Tắt tỉ lệ để góc có thể được so sánh độc lập với tỷ lệ hình. Các góc, từ trái sang phải, là `0`, `45`, và `90` ở hàng trên, và `135`, `180`, và `270` ở hàng dưới.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    presentation.getSlideSize().setSize(720, 400, SlideSizeScaleType.DoNotScale);
    ISlide slide = presentation.getSlides().get_Item(0);

    float[] angles = new float[] { 0, 45, 90, 135, 180, 270 };

    for (int i = 0; i < angles.length; i++) {
        int x = 30 + (i % 3) * 230;
        int y = 30 + (i / 3) * 190;

        IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, x, y, 200, 150);
        shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);
        shape.getFillFormat().setFillType(FillType.Gradient);

        IGradientFormat gradient = shape.getFillFormat().getGradientFormat();
        gradient.setGradientShape(GradientShape.Linear);
        gradient.getGradientStops().clear();
        gradient.getGradientStops().add(0f, Color.RED);
        gradient.getGradientStops().add(0.5f, Color.GREEN);
        gradient.getGradientStops().add(1f, Color.BLUE);
        gradient.setLinearGradientScaled(NullableBool.False);
        gradient.setLinearGradientAngle(angles[i]);
    }

    presentation.save("linear_gradient_angles.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Kết quả trong PowerPoint:

![Gradient tuyến tính ở 0, 45 và 90 độ ở hàng trên, và 135, 180 và 270 độ ở hàng dưới](linear-gradient-angles.png)

### **Thu Phóng Độ Trơn Tuyến Tính với Hình**

[IGradientFormat.setLinearGradientScaled](https://reference.aspose.com/slides/java/com.aspose.slides/igradientformat/#setLinearGradientScaled-byte-) nhận một giá trị [NullableBool](https://reference.aspose.com/slides/java/com.aspose.slides/nullablebool/). Đặt rõ `False` để giữ góc gradient hình học khi tỷ lệ hình thay đổi, hoặc `True` để thu phóng gradient cùng với chiều rộng và chiều cao của hình. Khi thu phóng bật, góc hiển thị có thể khác góc đã gán trên một hình không vuông.

Ví dụ sau sử dụng góc `45` độ và cùng các điểm dừng màu như so sánh góc. Cột trái dùng `False`; cột phải dùng `True`. Mỗi cột chứa một hình chữ nhật rộng phía trên và một hình chữ nhật cao phía dưới. Cả hai đều bắt đầu với kích thước rộng giống nhau; thay đổi chiều rộng và chiều cao của hình thứ hai minh họa cách fill phản hồi khi thay đổi kích thước mà không thay đổi cài đặt gradient.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    presentation.getSlideSize().setSize(720, 460, SlideSizeScaleType.DoNotScale);
    ISlide slide = presentation.getSlides().get_Item(0);

    byte[] scalingOptions = new byte[] { NullableBool.False, NullableBool.True };

    for (int column = 0; column < scalingOptions.length; column++) {
        for (int row = 0; row < 2; row++) {
            int x = 30 + column * 360;
            int y = row == 0 ? 30 : 150;

            IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, x, y, 300, 90);
            shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);
            shape.getFillFormat().setFillType(FillType.Gradient);

            IGradientFormat gradient = shape.getFillFormat().getGradientFormat();
            gradient.setGradientShape(GradientShape.Linear);
            gradient.getGradientStops().clear();
            gradient.getGradientStops().add(0f, Color.RED);
            gradient.getGradientStops().add(0.5f, Color.GREEN);
            gradient.getGradientStops().add(1f, Color.BLUE);
            gradient.setLinearGradientAngle(45);
            gradient.setLinearGradientScaled(scalingOptions[column]);

            if (row == 1) {
                shape.setWidth(90);
                shape.setHeight(280);
            }
        }
    }

    presentation.save("linear_gradient_scaling.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Kết quả trong PowerPoint, với thu phóng tắt ở bên trái và bật ở bên phải:

![Hình chữ nhật rộng và cao với gradient 45 độ, so sánh LinearGradientScaled False bên trái và True bên phải](linear-gradient-scaling.png)

Với thu phóng tắt, các dải màu chéo giữ nguyên hướng trong cả hai hình. Với thu phóng bật, các dải kéo dài theo tỷ lệ hình. Điều này giúp tái tạo gradient của mẫu khi điều chỉnh hình sang kích thước khác. Trên một hình vuông, bật thu phóng không thay đổi giao diện của gradient `45` độ này.

Cả góc và cài đặt thu phóng áp dụng cho gradient tuyến tính. Chúng không điều khiển các độ trơn [GradientShape.Radial hoặc GradientShape.Rectangle](https://reference.aspose.com/slides/java/com.aspose.slides/gradientshape/).

### **Kết Hợp Góc với Hướng Gradient**

[IGradientFormat.setGradientDirection](https://reference.aspose.com/slides/java/com.aspose.slides/igradientformat/#setGradientDirection-int-) chọn một kiểu gradient từ lớp [GradientDirection](https://reference.aspose.com/slides/java/com.aspose.slides/gradientdirection/); nó không phải là thay thế cho góc số. Đối với gradient tuyến tính, các kiểu góc có thể thay đổi khu vực màu phân bố mà không thay đổi góc đã gán qua [setLinearGradientAngle](https://reference.aspose.com/slides/java/com.aspose.slides/igradientformat/#setLinearGradientAngle-float-). Giữ hướng không đổi khi so sánh góc hoặc thu phóng.

Ví dụ sau áp dụng cùng cài đặt theo thứ tự ngược nhau. Hai hình có giao diện giống nhau: gán hướng trước hoặc sau góc không thay đổi kết quả.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    for (int i = 0; i < 2; i++) {
        IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 30 + i * 140, 320, 100);
        shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);
        shape.getFillFormat().setFillType(FillType.Gradient);

        IGradientFormat gradient = shape.getFillFormat().getGradientFormat();
        gradient.setGradientShape(GradientShape.Linear);
        gradient.getGradientStops().clear();
        gradient.getGradientStops().add(0f, Color.RED);
        gradient.getGradientStops().add(0.5f, Color.GREEN);
        gradient.getGradientStops().add(1f, Color.BLUE);
        gradient.setLinearGradientScaled(NullableBool.True);

        if (i == 0) {
            gradient.setGradientDirection(GradientDirection.FromCorner1);
            gradient.setLinearGradientAngle(30);
        } else {
            gradient.setLinearGradientAngle(30);
            gradient.setGradientDirection(GradientDirection.FromCorner1);
        }
    }

    presentation.save("linear_gradient_direction.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Đổ Mẫu**

Một độ đổ mẫu áp dụng một thiết kế hai màu, chẳng hạn chấm, sọc hoặc ô vuông. Ví dụ này sử dụng [IPatternFormat.setPatternStyle](https://reference.aspose.com/slides/java/com.aspose.slides/ipatternformat/#setPatternStyle-byte-) để chọn mẫu dạng trellis. [IPatternFormat.getBackColor](https://reference.aspose.com/slides/java/com.aspose.slides/ipatternformat/#getBackColor--) cung cấp nền màu xám nhạt, và [IPatternFormat.getForeColor](https://reference.aspose.com/slides/java/com.aspose.slides/ipatternformat/#getForeColor--) cung cấp màu vàng cho mẫu.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);
    shape.getFillFormat().setFillType(FillType.Pattern);
    shape.getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.Trellis);
    shape.getFillFormat().getPatternFormat().getBackColor().setColor(Color.LIGHT_GRAY);
    shape.getFillFormat().getPatternFormat().getForeColor().setColor(Color.YELLOW);

    presentation.save("pattern_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Kết quả:

![Hình chữ nhật với độ đổ mẫu](pattern-fill.png)

## **Đổ Hình Ảnh**

Đổ hình ảnh sử dụng một ảnh bên trong một hình. Ví dụ này yêu cầu một ảnh cục bộ và sử dụng [Images.fromFile](https://reference.aspose.com/slides/java/com.aspose.slides/images/#fromFile-java.lang.String-) để tải nó vào bộ sưu tập ảnh của bản thuyết trình. Đặt [IPictureFillFormat.setPictureFillMode](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setPictureFillMode-int-) ở chế độ lật gạch để lặp lại ảnh trong hình chữ nhật. Ảnh nguồn được sử dụng ở đây được hiển thị bên dưới:

![Hình ảnh sen](lotus.png)

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 255, 130);
    shape.getFillFormat().setFillType(FillType.Picture);
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Tile);

    IImage image = Images.fromFile("lotus.png");
    IPPImage picture;
    try {
        picture = presentation.getImages().addImage(image);
    } finally {
        image.dispose();
    }
    shape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);

    presentation.save("picture_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Kết quả:

![Hình dạng với độ đổ hình ảnh](picture-fill.png)

### **Lát Hình Ảnh Thành Kết Cấu**

Nếu bạn muốn đặt một hình ảnh lật gạch làm kết cấu và tùy chỉnh hành vi lật, có thể sử dụng các phương thức sau của giao diện [IPictureFillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/) và lớp [PictureFillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/picturefillformat/):

- [setPictureFillMode](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setPictureFillMode-int-): Đặt chế độ độ đổ hình ảnh—`Tile` hoặc `Stretch`.
- [setTileAlignment](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setTileAlignment-byte-): Xác định cách căn chỉnh các gạch trong hình.
- [setTileFlip](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setTileFlip-int-): Kiểm soát việc lật gạch theo chiều ngang, dọc, hoặc cả hai.
- [setTileOffsetX](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setTileOffsetX-float-): Đặt độ lệch ngang của gạch (điểm) so với gốc của hình.
- [setTileOffsetY](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setTileOffsetY-float-): Đặt độ lệch dọc của gạch (điểm) so với gốc của hình.
- [setTileScaleX](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setTileScaleX-float-): Xác định tỷ lệ ngang của gạch dưới dạng phần trăm.
- [setTileScaleY](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setTileScaleY-float-): Xác định tỷ lệ dọc của gạch dưới dạng phần trăm.

Ví dụ này yêu cầu một ảnh cục bộ và cấu hình [IPictureFillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/) để lặp lại ảnh ở 50% kích thước gốc. Độ lệch `−32` điểm dịch gạch ngang và dọc; căn chỉnh góc dưới‑phải và lật cả hai hướng quyết định cách bố trí kết cấu lặp lại.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide firstSlide = presentation.getSlides().get_Item(0);

    IAutoShape shape = firstSlide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 190, 95);
    shape.getFillFormat().setFillType(FillType.Picture);

    IImage sourceImage = Images.fromFile("lotus.png");
    IPPImage presentationImage;
    try {
        presentationImage = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    IPictureFillFormat pictureFillFormat = shape.getFillFormat().getPictureFillFormat();
    pictureFillFormat.getPicture().setImage(presentationImage);
    pictureFillFormat.setPictureFillMode(PictureFillMode.Tile);
    pictureFillFormat.setTileOffsetX(-32);
    pictureFillFormat.setTileOffsetY(-32);
    pictureFillFormat.setTileScaleX(50);
    pictureFillFormat.setTileScaleY(50);
    pictureFillFormat.setTileAlignment(RectangleAlignment.BottomRight);
    pictureFillFormat.setTileFlip(TileFlip.FlipBoth);

    presentation.save("tile.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Kết quả:

![Các tùy chọn lát](tile-options.png)

## **Đổ Màu Đặc**

Đổ màu đặc cho hình một màu duy nhất, đồng nhất. Ví dụ này sử dụng [IFillFormat.setFillType](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformat/#setFillType-byte-) để đặt chế độ đổ đặc và gán màu vàng qua [IFillFormat.getSolidFillColor](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformat/#getSolidFillColor--), sau đó lưu hình chữ nhật trong bản thuyết trình.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(Color.YELLOW);

    presentation.save("solid_color_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Kết quả:

![Hình dạng với độ đổ màu đặc](solid-color-fill.png)

### **Sao chép màu trong khi bảo lưu tham chiếu Chủ đề**

Sử dụng [IColorFormat.copyFrom](https://reference.aspose.com/slides/java/com.aspose.slides/icolorformat/#copyFrom-com.aspose.slides.IColorFormat-) để sao chép định nghĩa màu, bao gồm loại màu, tham chiếu chủ đề và các biến đổi. Điều này hữu ích khi chuyển màu đổ giữa các hình cần tiếp tục tuân theo chủ đề bản thuyết trình. Phương thức chỉ sao chép màu: không sao chép kiểu đổ, viền, hoặc các định dạng khác của hình. Đặt kiểu đổ của đích một cách rõ ràng bằng [IFillFormat.setFillType](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformat/#setFillType-byte-).

Ví dụ này tạo ba hình chữ nhật, từ trái sang phải: nguồn, bản sao nhận thức chủ đề, và bản sao RGB cố định. Nguồn sử dụng [IColorFormat.setSchemeColor](https://reference.aspose.com/slides/java/com.aspose.slides/icolorformat/#setSchemeColor-int-) để tham chiếu màu accent đầu tiên và thêm tint qua [IColorOperationCollection.add](https://reference.aspose.com/slides/java/com.aspose.slides/icoloroperationcollection/#add-int-float-). Bản sao RGB sử dụng màu đổ hiệu quả của nguồn nên ba hình ban đầu trông giống nhau. Gọi [IColorFormat.setColor](https://reference.aspose.com/slides/java/com.aspose.slides/icolorformat/#setColor-java.awt.Color-) đặt giá trị RGB cố định và xóa mọi biến đổi màu hiện có.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    presentation.getSlideSize().setSize(660, 220, SlideSizeScaleType.DoNotScale);
    ISlide slide = presentation.getSlides().get_Item(0);

    presentation.getMasterTheme().getColorScheme().getAccent1().setColor(new Color(65, 105, 225));

    IAutoShape source = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 40, 180, 140);
    IAutoShape themeCopy = slide.getShapes().addAutoShape(ShapeType.Rectangle, 240, 40, 180, 140);
    IAutoShape rgbCopy = slide.getShapes().addAutoShape(ShapeType.Rectangle, 450, 40, 180, 140);

    for (IAutoShape shape : new IAutoShape[] { source, themeCopy, rgbCopy }) {
        shape.getFillFormat().setFillType(FillType.Solid);
        shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);
    }

    IColorFormat sourceColor = source.getFillFormat().getSolidFillColor();
    sourceColor.setSchemeColor(SchemeColor.Accent1);
    sourceColor.getColorTransform().add(ColorTransformOperation.Tint, 0.75f);

    themeCopy.getFillFormat().getSolidFillColor().copyFrom(sourceColor);
    rgbCopy.getFillFormat().getSolidFillColor().setColor(source.getFillFormat().getEffective().getSolidFillColor());

    IImage before = slide.getImage(1f, 1f);
    try {
        before.save("color-copy-before.png", ImageFormat.Png);
    } finally {
        before.dispose();
    }

    // Các tham chiếu chủ đề sẽ theo màu accent mới; giá trị RGB cố định thì không.
    presentation.getMasterTheme().getColorScheme().getAccent1().setColor(new Color(255, 69, 0));

    IImage after = slide.getImage(1f, 1f);
    try {
        after.save("color-copy-after.png", ImageFormat.Png);
    } finally {
        after.dispose();
    }
    presentation.save("copied_colors.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Trước khi thay đổi chủ đề, cả ba độ đổ đều trùng khớp:

![Nguồn, đích copyFrom và đích RGB cố định với các tô màu xanh đồng nhất](color-copy-before.png)

Sau khi thay đổi chủ đề, nguồn và bản sao nhận thức chủ đề theo màu accent mới và giữ tint. Bản sao RGB cố định vẫn xanh:

![Nguồn và đích copyFrom với màu cam, trong khi đích RGB cố định vẫn màu xanh](color-copy-after.png)

Định nghĩa đã sao chép độc lập với nguồn. Thay đổi sau này tham chiếu chủ đề của nguồn, gán màu khác, hoặc thêm/bớt biến đổi không làm thay đổi đích. Thay đổi chủ đề vẫn ảnh hưởng tới cả hai hình vì mỗi hình đều tham chiếu riêng vào cùng một màu chủ đề.

Lưu và mở lại PPTX bảo lưu loại màu trả về bởi [IColorFormat.getColorType](https://reference.aspose.com/slides/java/com.aspose.slides/icolorformat/#getColorType--), tham chiếu chủ đề, và bộ sưu tập biến đổi trả về bởi [IColorFormat.getColorTransform](https://reference.aspose.com/slides/java/com.aspose.slides/icolorformat/#getColorTransform--); chúng không bị làm phẳng thành RGB.

Khi sao chép giữa các ngữ cảnh chủ đề khác nhau, chẳng hạn các bản thuyết trình có bảng màu accent khác nhau, tham chiếu đã sao chép sẽ được giải quyết dựa trên chủ đề của đích. Vì vậy cùng một tham chiếu và biến đổi có thể tạo ra màu hiển thị khác nhau. Xem [Presentation Theme](/slides/vi/java/presentation-theme/) để biết thêm về cấu hình màu chủ đề.

## **Sử dụng Nền Slide làm Đổ cho Hình**

Sử dụng [IAutoShape.setUseBackgroundFill](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/#setUseBackgroundFill-boolean-) khi một hình cần khớp với nền slide, ví dụ trong mẫu bản thuyết trình. Đặt kiểu đổ bằng [IFillFormat.setFillType](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformat/#setFillType-byte-) thành [FillType.NotDefined](https://reference.aspose.com/slides/java/com.aspose.slides/filltype/) trước để xóa bất kỳ đổ nào được chỉ định rõ ràng. Với kết hợp này, hình sẽ sử dụng nền slide thay vì đổ kiểu của nó. Bật cờ này một mình không xóa đổ hiện có.

Điều này khác với [FillType.NoFill](https://reference.aspose.com/slides/java/com.aspose.slides/filltype/): đổ nền phủ các đối tượng phía sau hình bằng khu vực nền slide tương ứng, trong khi không đổ để các đối tượng đó vẫn hiển thị. Gradient vẫn căn chỉnh với slide thay vì khởi động lại bên trong mỗi hình.

Ví dụ sau tạo nền chủ được kế thừa bởi slide và đặt một dải màu hồng phía sau ba hình chữ nhật. Hình chữ nhật trái dùng nền, hình giữa không có đổ, và hình phải chuyển từ đổ nền sang đổ màu cam rõ ràng.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    presentation.getSlideSize().setSize(720, 400, SlideSizeScaleType.DoNotScale);
    ISlide slide = presentation.getSlides().get_Item(0);

    // Kế thừa gradient từ master.
    slide.getBackground().setType(BackgroundType.NotDefined);
    slide.getLayoutSlide().getBackground().setType(BackgroundType.NotDefined);
    IBackground background = slide.getLayoutSlide().getMasterSlide().getBackground();
    background.setType(BackgroundType.OwnBackground);
    background.getFillFormat().setFillType(FillType.Gradient);
    IGradientFormat gradient = background.getFillFormat().getGradientFormat();
    gradient.setGradientShape(GradientShape.Linear);
    gradient.setLinearGradientAngle(0);
    gradient.getGradientStops().clear();
    gradient.getGradientStops().add(0, new Color(0, 0, 139));
    gradient.getGradientStops().add(1, new Color(135, 206, 250));

    // Thêm đối tượng này trước để nó xuất hiện phía sau các hình chữ nhật.
    IAutoShape band = slide.getShapes().addAutoShape(ShapeType.Rectangle, 25, 150, 670, 100);
    band.getFillFormat().setFillType(FillType.Solid);
    band.getFillFormat().getSolidFillColor().setColor(Color.MAGENTA);
    band.getLineFormat().getFillFormat().setFillType(FillType.NoFill);

    IAutoShape backgroundShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 100, 160, 200);
    backgroundShape.getFillFormat().setFillType(FillType.NotDefined);
    backgroundShape.setUseBackgroundFill(true);

    IAutoShape noFillShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 280, 100, 160, 200);
    noFillShape.getFillFormat().setFillType(FillType.NoFill);

    IAutoShape explicitShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 510, 100, 160, 200);
    explicitShape.getFillFormat().setFillType(FillType.NotDefined);
    explicitShape.setUseBackgroundFill(true);

    // Tắt đổ nền trước khi áp dụng độ đổ rõ ràng.
    explicitShape.setUseBackgroundFill(false);
    explicitShape.getFillFormat().setFillType(FillType.Solid);
    explicitShape.getFillFormat().getSolidFillColor().setColor(new Color(255, 165, 0));

    presentation.save("background_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Kết quả, từ trái sang phải: **đổ nền**, **không đổ**, và **đổ rõ ràng**. Dải màu hồng bị ẩn bởi hình trái và phải nhưng vẫn hiển thị qua hình giữa.

![Đổ nền, không đổ, và đổ màu cam rõ ràng trên dải màu hồng](background-fill.png)

Hành vi tương tự áp dụng cho nền được định nghĩa trực tiếp trên slide hoặc kế thừa từ bố cục. Hình sử dụng nền đã giải quyết của slide; ví dụ để cả slide và bố cục không xác định nền nên master cung cấp nền.

## **Đặt Độ Trong Suốt**

Đối với độ đổ đặc, thành phần alpha của màu kiểm soát độ mờ: 0 là hoàn toàn trong suốt và 255 là hoàn toàn đục. Ví dụ này sử dụng giá trị alpha 128 cho một hình chữ nhật màu vàng, làm nó khoảng 50% trong suốt để hình dưới vẫn nhìn thấy. Màu được gán qua [IFillFormat.getSolidFillColor](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformat/#getSolidFillColor--).

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape solidShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    IAutoShape transparentShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 80, 80, 150, 75);
    transparentShape.getFillFormat().setFillType(FillType.Solid);
    transparentShape.getFillFormat().getSolidFillColor().setColor(new Color(255, 255, 0, 128));

    presentation.save("shape_transparency.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Kết quả:

![Hình dạng trong suốt](shape-transparency.png)

## **Xoay Hình**

Sử dụng [IShape.setRotation](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#setRotation-float-) để xoay một hình trong mặt phẳng slide. Góc đo bằng độ; ví dụ này xoay một hình chữ nhật 5 độ theo chiều kim đồng hồ và lưu bản thuyết trình.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);
    shape.setRotation(5);

    presentation.save("shape_rotation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Kết quả:

![Xoay hình dạng](shape-rotation.png)

## **Thêm Hiệu Ứng Bo 3D**

Sử dụng [IShape.getThreeDFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#getThreeDFormat--) để cho hình có độ sâu và cạnh bo. Ví dụ này tạo một hình elip xanh lá với viền màu cam, dùng [IThreeDFormat.setDepth](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#setDepth-double-) để đặt độ sâu 4 điểm, và áp dụng bo trên cùng dạng tròn với chiều rộng và chiều cao 6 điểm qua [IThreeDFormat.getBevelTop](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#getBevelTop--). Một camera trực giao phía trước và ánh sáng ba điểm làm cho bo hiển thị.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 50, 100, 100);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(new Color(0, 128, 0));
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(new Color(255, 165, 0));
    shape.getLineFormat().setWidth(2.0);
    shape.getThreeDFormat().setDepth(4);
    shape.getThreeDFormat().getBevelTop().setBevelType(BevelPresetType.Circle);
    shape.getThreeDFormat().getBevelTop().setHeight(6);
    shape.getThreeDFormat().getBevelTop().setWidth(6);
    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.ThreePt);
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);

    presentation.save("3D_bevel_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Kết quả:

![Hiệu ứng bo 3D](3D-bevel-effect.png)

## **Thêm Hiệu Ứng Xoay 3D**

Góc nhìn 3D của một hình được điều khiển bởi cài đặt camera. Ví dụ này sử dụng [ICamera.setRotation](https://reference.aspose.com/slides/java/com.aspose.slides/icamera/#setRotation-float-float-float-) với góc vĩ độ, kinh độ và quay vòng là 40, 35 và 20 độ. Nó chọn một camera isometric qua [ICamera.setCameraType](https://reference.aspose.com/slides/java/com.aspose.slides/icamera/#setCameraType-int-) và ánh sáng cân bằng qua [ILightRig.setLightType](https://reference.aspose.com/slides/java/com.aspose.slides/ilightrig/#setLightType-int-), sau đó lưu hình chữ nhật đã định dạng.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);
    autoShape.getTextFrame().setText("Hello, Aspose!");
    autoShape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.IsometricLeftUp);
    autoShape.getThreeDFormat().getCamera().setRotation(40, 35, 20);
    autoShape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Balanced);

    presentation.save("3D_rotation_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Kết quả:

![Hiệu ứng xoay 3D](3D-rotation-effect.png)

## **Kiểm Soát Hiển Thị Đen‑Trắng cho Hình**

Phương thức [IShape.setBlackWhiteMode](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#setBlackWhiteMode-byte-) xác định cách một hình riêng lẻ được hiển thị khi bản thuyết trình được xem hoặc xử lý ở chế độ đen‑trắng. Nó không bật chế độ đen‑trắng một cách độc lập, và không thay đổi đổ, đường viền hoặc các định dạng khác của hình ở chế độ màu bình thường.

Sử dụng một giá trị từ lớp [BlackWhiteMode](https://reference.aspose.com/slides/java/com.aspose.slides/blackwhitemode/) để chọn hành vi mong muốn. Ví dụ, `Automatic` để ứng dụng hiển thị chọn cách chuyển đổi, `Gray` và `LightGray` dùng màu xám, `BlackWhite` chỉ dùng đen và trắng, `Black` và `White` buộc một màu duy nhất, `Color` giữ màu bình thường, và `Hidden` loại bỏ hình trong chế độ đen‑trắng. `NotDefined` nghĩa là không có chế độ cấp độ hình nào được gán.

Ví dụ này tạo một hình chữ nhật màu cam và dùng [IShape.setBlackWhiteMode](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#setBlackWhiteMode-byte-) để đặt chế độ thành `Gray`. Hình đã lưu giữ màu đổ cam cho hiển thị màu bình thường và yêu cầu màu xám từ các ứng dụng tôn trọng cài đặt hiển thị đen‑trắng:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(new Color(255, 165, 0));
    shape.setBlackWhiteMode(BlackWhiteMode.Gray);

    presentation.save("shape_black_white_mode.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Ở chế độ màu bình thường, hình chữ nhật giữ màu đổ cam. Trong quy trình làm việc hiển thị đen‑trắng, nó sử dụng màu xám vì chế độ được đặt là `Gray`. Điều này cho phép bạn giữ một slide đầy màu trong khi định nghĩa giao diện riêng cho in ấn, xem trước, hoặc các quy trình khác tôn trọng cài đặt hiển thị đen‑trắng của bản thuyết trình.

## **Đặt Lại Định Dạng**

Sử dụng [ISlide.reset](https://reference.aspose.com/slides/java/com.aspose.slides/islide/#reset--) để khôi phục vị trí, kích thước và định dạng của các vị trí giữ chỗ slide từ các vị trí giữ chỗ bố cục tương ứng. Ví dụ này yêu cầu một bản thuyết trình hiện có với các vị trí giữ chỗ liên kết bố cục và đặt lại mọi slide trước khi lưu. Các hình không có vị trí giữ chỗ bố cục tương ứng sẽ không được đặt lại.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        slide.reset();
    }

    presentation.save("reset_formatting.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Định dạng hình ảnh có ảnh hưởng tới kích thước cuối cùng của file bản thuyết trình không?**

Màu sắc, kiểu đường và cài đặt hiệu ứng thường chỉ thêm ít dữ liệu so với hình ảnh và phương tiện được nhúng. Độ đổ hình ảnh có thể làm tăng kích thước file vì ảnh của chúng được lưu trong bản thuyết trình.

**Làm sao tôi có thể phát hiện các hình trên một slide có định dạng giống hệt nhau để có thể nhóm chúng lại?**

So sánh mỗi thuộc tính định dạng chính của hình—đổ, đường, và cài đặt hiệu ứng. Nếu tất cả các giá trị tương ứng khớp nhau, coi chúng là cùng kiểu và nhóm logic các hình đó, giúp quản lý kiểu sau này đơn giản hơn.

**Tôi có thể lưu một tập hợp các kiểu hình tùy chỉnh vào một file riêng để tái sử dụng trong các bản thuyết trình khác không?**

Có. Lưu các hình mẫu với các kiểu mong muốn trong một slide mẫu hoặc file .POTX. Khi tạo bản thuyết trình mới, mở mẫu, sao chép các hình đã định dạng cần thiết, và áp dụng lại định dạng của chúng ở bất kỳ nơi nào cần.