---
title: Định dạng các hình PowerPoint trên Android
linktitle: Định dạng Hình
type: docs
weight: 20
url: /vi/androidjava/shape-formatting/
keywords:
- định dạng hình
- định dạng đường
- hiệu ứng vẽ tay
- đường viền vẽ tay
- định dạng kiểu nối
- đổ gradient
- đổ mẫu
- đổ ảnh
- đổ kết cấu
- đổ màu đặc
- độ trong suốt hình
- hiển thị hình đen‑trắng
- hiển thị hình xám
- xoay hình
- hiệu ứng bo 3D
- hiệu ứng xoay 3D
- đặt lại định dạng
- PowerPoint
- bản trình bày
- Android
- Java
- Aspose.Slides
description: "Tìm hiểu cách định dạng các hình PowerPoint trên Android bằng Aspose.Slides—đặt kiểu đổ, đường viền và hiệu ứng cho tệp PPT và PPTX một cách chính xác và kiểm soát đầy đủ."
---
## **Giới thiệu**

Định dạng các hình trong PowerPoint bằng cách điều chỉnh đường viền, nền và hiệu ứng. Aspose.Slides for Android via Java cho phép bạn kiểm soát các cài đặt này bằng mã, bao gồm độ trong suốt, xoay và định dạng 3D.

![Các tùy chọn định dạng hình trong PowerPoint](format-shape-powerpoint.png)

Aspose.Slides for Android via Java cung cấp các giao diện và phương thức cho phép bạn định dạng các hình bằng các tùy chọn có sẵn trong PowerPoint.

## **Định dạng Đường viền**

Sử dụng [IShape.getLineFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#getLineFormat--) để điều khiển đường viền của hình. Ví dụ này tạo một hình chữ nhật không nền với đường viền xanh đứt nét. [ILineFormat.setStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#setStyle-byte-) chọn đường ghép dày-mỏng, trong khi [ILineFormat.setWidth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#setWidth-double-) đặt độ rộng là 7 điểm và [ILineFormat.setDashStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#setDashStyle-byte-) chọn kiểu gạch.

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

![Các đường đã được định dạng trong bản trình bày](formatted-lines.png)

### **Đặt Mẫu Gạch Đường Tùy Chỉnh**

Sử dụng [ILineFormat.setCustomDashPattern](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#setCustomDashPattern-float---) khi các kiểu đường có sẵn không cung cấp độ dài gạch và khoảng trống bạn cần, ví dụ cho các đường viền thương hiệu hoặc sơ đồ kỹ thuật. Khi gán một mẫu, kiểu gạch tự động chuyển thành [LineDashStyle.Custom](https://reference.aspose.com/slides/androidjava/com.aspose.slides/linedashstyle/).

Các mục trong mảng luân phiên giữa độ dài gạch và khoảng trống, bắt đầu bằng gạch. Mỗi giá trị là bội số của độ rộng đường: `{ 4, 2 }` với độ rộng 3 điểm tạo ra một gạch 12 điểm và một khoảng trống 6 điểm. Sử dụng các cặp giá trị hữu hạn, không âm để định nghĩa các đoạn gạch-khoảng trống đầy đủ. Ví dụ này sử dụng các giá trị dương để mọi gạch và khoảng trống luôn hiển thị.

Ví dụ này tạo năm đường xanh có cùng độ dài và đầu thẳng. Ba đường đầu tiên so sánh các mẫu ở độ rộng 3 điểm. Đường thứ tư lặp lại mẫu đầu tiên với độ rộng gấp đôi, tăng gấp đôi cả độ dài gạch và khoảng trống. Đường thứ năm chuyển từ mẫu tùy chỉnh sang đường liền.

```java
import com.aspose.slides.*;
import android.graphics.Color;

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
        line.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.rgb(0, 0, 139));
        line.getLineFormat().setCapStyle(LineCapStyle.Flat);
        line.getLineFormat().setBeginArrowheadStyle(LineArrowheadStyle.None);
        line.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.None);
        line.getLineFormat().setCustomDashPattern(patterns[i]);
    }

    // Trả về dòng cuối thành kiểu liền.
    slide.getShapes().get_Item(4).getLineFormat().setDashStyle(LineDashStyle.Solid);

    presentation.save("custom_dash_patterns.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Để trở lại kiểu gạch có sẵn, truyền [LineDashStyle.Dash](https://reference.aspose.com/slides/androidjava/com.aspose.slides/linedashstyle/) cho [ILineFormat.setDashStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#setDashStyle-byte-). Kiểu được chọn sẽ kiểm soát giao diện của đường.

Kết quả trong PowerPoint, từ trên xuống: **{4, 2}, 3 pt**; **{1, 2}, 3 pt**; **{6, 2, 1, 2}, 3 pt**; **{4, 2}, 6 pt**; và **Solid, 3 pt**.

![Ba mẫu gạch tùy chỉnh, một đường rộng hơn dùng mẫu đầu tiên, và một đường liền trong PowerPoint](custom-dash-patterns.png)

### **Đặt Kiểu Đầu Đường**

Sử dụng [ILineFormat.setCapStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#setCapStyle-byte-) để đặt đầu của một đường mở. Lớp [LineCapStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/linecapstyle/) cung cấp ba kiểu đầu rõ ràng:

- `Flat`: Đường dừng lại tại điểm cuối.
- `Round`: Đầu hình bán vòng mở rộng ra ngoài điểm cuối một nửa độ rộng đường.
- `Square`: Đầu hình vuông mở rộng ra ngoài điểm cuối một nửa độ rộng đường.

Lớp còn bao gồm `NotDefined`, nghĩa là không có kiểu đầu nào được chỉ định cụ thể.

Đầu khác với mũi tên, những ký hiệu được thêm vào đầu đường, và nối, những cách điều khiển góc giữa các đoạn đường. Ví dụ này tắt các mũi tên bằng [ILineFormat.setBeginArrowheadStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#setBeginArrowheadStyle-byte-) và [ILineFormat.setEndArrowheadStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#setEndArrowheadStyle-byte-) để chỉ so sánh các dạng đầu.

Ví dụ sau tạo ba đường ngang gần như giống nhau, rộng 20 điểm. Từ trên xuống, chúng sử dụng đầu `Flat`, `Round`, và `Square`. Các điểm cuối của chúng có cùng tọa độ ngang; đầu tròn và vuông mở rộng ra 10 điểm vượt ra ngoài mỗi đầu.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    presentation.getSlideSize().setSize(500, 240, SlideSizeScaleType.DoNotScale);
    ISlide slide = presentation.getSlides().get_Item(0);

    byte[] capStyles = new byte[] { LineCapStyle.Flat, LineCapStyle.Round, LineCapStyle.Square };

    for (int i = 0; i < capStyles.length; i++) {
        IAutoShape line = slide.getShapes().addAutoShape(ShapeType.Line, 100, 50 + i * 70, 300, 0);
        line.getLineFormat().setWidth(20);
        line.getLineFormat().getFillFormat().setFillType(FillType.Solid);
        line.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.rgb(0, 0, 139));
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

Kết quả trong PowerPoint, từ trên xuống: **Flat**, **Round**, và **Square**.

![Đầu thẳng, tròn và vuông trên các đường dày giống nhau trong PowerPoint](line-caps.png)

## **Áp Dụng Hiệu Ứng Vẽ Tay cho Đường Hình**

Hiệu ứng vẽ tay làm cho đường của hình trông như được vẽ bằng tay. Sử dụng [IShape.getLineFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#getLineFormat--) để truy cập cài đặt đường, [ILineFormat.getSketchFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#getSketchFormat--) để truy cập cài đặt vẽ tay, và [ISketchFormat.setSketchType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/isketchformat/#setSketchType-int-) để chọn giá trị từ lớp [LineSketchType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/linesketchtype/).

Đoạn mã Java sau hiển thị cách áp dụng hiệu ứng [LineSketchType.Curved](https://reference.aspose.com/slides/androidjava/com.aspose.slides/linesketchtype/), đọc giá trị được gán rõ ràng, và loại bỏ hiệu ứng bằng [LineSketchType.None](https://reference.aspose.com/slides/androidjava/com.aspose.slides/linesketchtype/):

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

Giá trị trả về bởi [ISketchFormat.getSketchType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/isketchformat/#getSketchType--) đại diện cho cài đặt được gán trực tiếp cho hình. Nếu định dạng đường có thể được kế thừa từ chủ đề, slide chủ, hoặc slide bố cục, sử dụng [ILineFormat.getEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#getEffective--), truy cập [ILineFormatEffectiveData.getSketchFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformateffectivedata/#getSketchFormat--), và đọc [ISketchFormatEffectiveData.getSketchType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/isketchformateffectivedata/#getSketchType--). Giá trị hiệu quả phản ánh định dạng thực tế được áp dụng sau khi kế thừa được giải quyết. Ví dụ này yêu cầu một bản trình bày hiện có với ít nhất một hình trên slide đầu tiên và in ra cả hai giá trị:

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

Kiểu nối quyết định cách hai đoạn viền gặp nhau tại một góc. Sử dụng **Round** cho góc tròn, **Miter** cho góc nhọn, hoặc **Bevel** cho góc phẳng.

![Kiểu nối trong bản trình bày](join-style-powerpoint.png)

Ví dụ này tạo ba hình chữ nhật đen với viền xanh rộng 15 điểm. Nó sử dụng [ILineFormat.setJoinStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#setJoinStyle-byte-) để áp dụng các giá trị miter, bevel và round của [LineJoinStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/linejoinstyle/), tương ứng, để so sánh cách các góc được vẽ.

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

### **Giới Hạn Nối Miter tại Các Góc Nhọn**

Sử dụng [ILineFormat.setMiterLimit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#setMiterLimit-float-) cùng với [ILineFormat.setJoinStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#setJoinStyle-byte-) đặt thành [LineJoinStyle.Miter](https://reference.aspose.com/slides/androidjava/com.aspose.slides/linejoinstyle/) để giới hạn độ dài của góc nhọn.

Giới hạn là tỷ lệ giữa khoảng cách giữa góc trong và góc ngoài của nối so với độ rộng đường. Ví dụ, giá trị `8` cho phép độ dài miter lên tới tám lần độ rộng đường; đây không phải là độ đo bằng điểm. Nếu góc vượt quá giới hạn, PowerPoint sẽ dùng nối bevel tại góc đó. Giới hạn lớn hơn cho phép các điểm nhọn hơn. Cài đặt này chỉ ảnh hưởng tới nối miter và không tạo hiệu ứng nhìn thấy khi góc vẫn nằm trong giới hạn.

Ví dụ này tạo hai tam giác không nền, viền rộng 20 điểm. Tam giác bên trái dùng giới hạn `2`, còn bên phải dùng `8`. Mỗi tam giác rộng 80 điểm và cao 160 điểm, cho tỷ lệ độ dài miter so với độ rộng đường khoảng `4.12`. Do đó, PowerPoint bevel góc trái và giữ góc phải nhọn.

```java
import com.aspose.slides.*;
import android.graphics.Color;

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
        triangle.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.rgb(0, 0, 139));
        triangle.getLineFormat().setJoinStyle(LineJoinStyle.Miter);
        triangle.getLineFormat().setMiterLimit(miterLimits[i]);
    }

    presentation.save("miter_limits.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Kết quả trong PowerPoint: **Giới hạn miter 2** ở bên trái và **giới hạn miter 8** ở bên phải.

![Một đỉnh bevel với giới hạn miter 2 và một đỉnh nhọn với giới hạn miter 8 trong PowerPoint](miter-limits.png)

## **Đổ Gradient**

Đổ gradient pha trộn màu sắc trên một hình. Ví dụ này đổ một hình ellipse bằng gradient tuyến tính góc 45 độ từ đỏ sang tím bằng cách sử dụng [IFillFormat.getGradientFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformat/#getGradientFormat--). Phương thức [IGradientStopCollection.addPresetColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igradientstopcollection/#addPresetColor-float-int-) đặt các điểm dừng màu tại 0 và 1, tức đầu và cuối gradient. Xóa các điểm dừng hiện có đảm bảo chỉ có hai màu này được dùng.

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

![Ellipse với gradient fill](gradient-fill.png)

Nếu gradient trông khác trong hình ảnh đã xuất so với trong PowerPoint, xem mục [Choose a Gradient Rendering Style](/slides/vi/androidjava/convert-powerpoint-to-png/#choose-a-gradient-rendering-style). Bạn có thể chọn kiểu render mà không thay đổi gradient được lưu trong bản trình bày.

### **Đặt Góc Gradient Tuyến Tính**

Sử dụng [IGradientFormat.setLinearGradientAngle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igradientformat/#setLinearGradientAngle-float-) để kiểm soát hướng của gradient loại [GradientShape.Linear](https://reference.aspose.com/slides/androidjava/com.aspose.slides/gradientshape/). Góc đo bằng độ và tăng theo chiều kim đồng hồ: `0` chạy từ trái sang phải, `90` từ trên xuống dưới, `180` từ phải sang trái, và `270` từ dưới lên trên. Các góc thập phân được hỗ trợ. Các góc hữu hạn ngoài khoảng `[0, 360)` sẽ được chuẩn hoá thành một vòng; ví dụ, `-45` trở thành `315` và `360` trở thành `0`.

Ví dụ này tạo sáu hình chữ nhật với các điểm dừng đỏ, xanh lá và xanh dương giống nhau tại vị trí `0`, `0.5`, và `1`. Tỷ lệ được tắt để góc có thể so sánh độc lập với tỉ lệ của các hình. Các góc, từ trái sang phải, là `0`, `45`, và `90` ở hàng đầu, và `135`, `180`, và `270` ở hàng thứ hai.

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

![Gradient tuyến tính ở các góc 0, 45, 90 độ ở hàng trên, và 135, 180, 270 độ ở hàng dưới](linear-gradient-angles.png)

### **Tỷ Lệ Gradient Tuyến Tính Với Hình**

[IGradientFormat.setLinearGradientScaled](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igradientformat/#setLinearGradientScaled-byte-) nhận một giá trị [NullableBool](https://reference.aspose.com/slides/androidjava/com.aspose.slides/nullablebool/). Đặt rõ `False` để giữ góc gradient hình học khi tỷ lệ hình thay đổi, hoặc `True` để tỷ lệ gradient cùng với chiều rộng và chiều cao của hình. Khi tỷ lệ bật, góc nhìn thấy có thể khác với góc đã gán trên một hình không phải hình vuông.

Ví dụ sau sử dụng góc `45` độ và các điểm dừng màu giống như so sánh góc. Cột trái dùng `False`; cột phải dùng `True`. Mỗi cột chứa một hình chữ nhật rộng ở trên và một hình chữ nhật cao ở dưới. Cả hai đều bắt đầu với cùng kích thước rộng; thay đổi chiều rộng và chiều cao của hình chữ nhật thứ hai cho thấy cách fill phản hồi khi thay đổi kích thước mà không thay đổi cài đặt gradient.

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

Kết quả trong PowerPoint, với tỷ lệ tắt bên trái và bật bên phải:

![Hình chữ nhật rộng và cao với gradient 45 độ, so sánh LinearGradientScaled False bên trái và True bên phải](linear-gradient-scaling.png)

Khi tỷ lệ tắt, dải màu chéo giữ cùng hướng trong cả hai hình. Khi tỷ lệ bật, dải màu kéo dài theo tỷ lệ của hình. Điều này giúp tái tạo gradient của mẫu khi điều chỉnh hình sang kích thước khác. Trên hình vuông, bật tỷ lệ không thay đổi giao diện của gradient `45` độ này.

Cả góc và cài đặt tỷ lệ đều áp dụng cho gradient tuyến tính. Chúng không kiểm soát các loại fill [GradientShape.Radial hoặc GradientShape.Rectangle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/gradientshape/).

### **Kết Hợp Góc Với Hướng Gradient**

[IGradientFormat.setGradientDirection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igradientformat/#setGradientDirection-int-) chọn một kiểu gradient từ lớp [GradientDirection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/gradientdirection/); nó không phải là thay thế cho góc số. Đối với gradient tuyến tính, các kiểu góc có thể thay đổi khu vực màu được phân bố mà không thay đổi góc được đặt qua [setLinearGradientAngle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igradientformat/#setLinearGradientAngle-float-). Giữ hướng không thay đổi khi so sánh góc hoặc tỷ lệ.

Ví dụ sau áp dụng cùng cài đặt nhưng theo thứ tự ngược nhau. Hai hình chữ nhật có giao diện giống nhau: đặt hướng trước hoặc sau góc không ảnh hưởng đến kết quả.

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

Đổ mẫu áp dụng một thiết kế hai màu, chẳng hạn chấm, sọc hoặc kẻ ô. Ví dụ này sử dụng [IPatternFormat.setPatternStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipatternformat/#setPatternStyle-byte-) để chọn mẫu trellis. [IPatternFormat.getBackColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipatternformat/#getBackColor--) cung cấp nền xám nhạt, và [IPatternFormat.getForeColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipatternformat/#getForeColor--) cung cấp màu vàng cho mẫu.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);
    shape.getFillFormat().setFillType(FillType.Pattern);
    shape.getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.Trellis);
    shape.getFillFormat().getPatternFormat().getBackColor().setColor(Color.rgb(192, 192, 192));
    shape.getFillFormat().getPatternFormat().getForeColor().setColor(Color.YELLOW);

    presentation.save("pattern_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Kết quả:

![Hình chữ nhật với đổ mẫu](pattern-fill.png)

## **Đổ Hình Ảnh**

Đổ hình ảnh sử dụng một ảnh bên trong một hình. Ví dụ này yêu cầu một ảnh cục bộ và dùng [Images.fromFile](https://reference.aspose.com/slides/androidjava/com.aspose.slides/images/#fromFile-java.lang.String-) để tải nó vào bộ sưu tập ảnh của bản trình bày. Đặt [IPictureFillFormat.setPictureFillMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#setPictureFillMode-int-) ở chế độ lặp lại để ảnh được lặp lại trong hình chữ nhật. Ảnh nguồn được sử dụng ở đây được hiển thị dưới đây:

![Ảnh bông sen](lotus.png)

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

![Hình với đổ hình ảnh](picture-fill.png)

### **Lặp Ảnh Như Kết Cấu**

Nếu bạn muốn đặt ảnh lặp lại làm kết cấu và tùy chỉnh cách lặp, có thể dùng các phương thức sau của giao diện [IPictureFillFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/) và lớp [PictureFillFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/picturefillformat/):

- [setPictureFillMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#setPictureFillMode-int-): Đặt chế độ đổ ảnh—`Tile` hoặc `Stretch`.
- [setTileAlignment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#setTileAlignment-byte-): Xác định cách căn chỉnh các ô trong hình.
- [setTileFlip](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#setTileFlip-int-): Kiểm soát việc lật ô theo chiều ngang, dọc hoặc cả hai.
- [setTileOffsetX](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#setTileOffsetX-float-): Đặt độ dịch ngang của ô (điểm) từ gốc hình.
- [setTileOffsetY](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#setTileOffsetY-float-): Đặt độ dịch dọc của ô (điểm) từ gốc hình.
- [setTileScaleX](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#setTileScaleX-float-): Xác định tỷ lệ ngang của ô dưới dạng phần trăm.
- [setTileScaleY](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#setTileScaleY-float-): Xác định tỷ lệ dọc của ô dưới dạng phần trăm.

Ví dụ này yêu cầu một ảnh cục bộ và cấu hình [IPictureFillFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/) để lặp lại ở 50% kích thước gốc. Dịch chuyển `−32` điểm làm các ô dịch ngang và dọc; căn chỉnh góc dưới‑phải và lật cả hai chiều xác định cách kết cấu lặp được sắp xếp.

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

![Các tùy chọn ô lặp](tile-options.png)

## **Đổ Màu Đặc**

Đổ màu đặc cung cấp cho hình một màu duy nhất, đồng nhất. Ví dụ này dùng [IFillFormat.setFillType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformat/#setFillType-byte-) để chọn chế độ đổ đặc và gán màu vàng qua [IFillFormat.getSolidFillColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformat/#getSolidFillColor--), sau đó lưu hình chữ nhật trong bản trình bày.

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

![Hình với đổ màu đặc](solid-color-fill.png)

### **Sao Chép Màu Khi Giữ Tham Chiếu Chủ Đề**

Sử dụng [IColorFormat.copyFrom](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icolorformat/#copyFrom-com.aspose.slides.IColorFormat-) để sao chép định nghĩa màu, bao gồm kiểu màu, tham chiếu chủ đề và các biến đổi. Điều này hữu ích khi chuyển màu đổ giữa các hình mà vẫn muốn chúng tuân theo chủ đề của bản trình bày. Phương thức chỉ sao chép màu: không sao chép kiểu đổ, viền hay các định dạng hình khác. Đặt kiểu đổ của đối tượng đích một cách rõ ràng bằng [IFillFormat.setFillType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformat/#setFillType-byte-).

Ví dụ này tạo ba hình chữ nhật, từ trái sang phải: nguồn, bản sao có nhận thức chủ đề, và bản sao RGB cố định. Nguồn sử dụng [IColorFormat.setSchemeColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icolorformat/#setSchemeColor-int-) để tham chiếu màu nhấn thứ nhất và thêm một tông màu qua [IColorOperationCollection.add](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icoloroperationcollection/#add-int-float-). Bản sao RGB dùng màu đổ hiệu quả của nguồn nên ba hình ban đầu trông giống hệt nhau. Gọi [IColorFormat.setColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icolorformat/#setColor-java.lang.Integer-) đặt giá trị RGB cố định và xóa mọi biến đổi màu hiện có.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    presentation.getSlideSize().setSize(660, 220, SlideSizeScaleType.DoNotScale);
    ISlide slide = presentation.getSlides().get_Item(0);

    presentation.getMasterTheme().getColorScheme().getAccent1().setColor(Color.rgb(65, 105, 225));

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

    // Tham chiếu chủ đề theo màu nhấn mới; giá trị RGB cố định không thay đổi.
    presentation.getMasterTheme().getColorScheme().getAccent1().setColor(Color.rgb(255, 69, 0));

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

Trước khi thay đổi chủ đề, ba đổ màu đều khớp:

![Nguồn, đích copyFrom và đích RGB cố định với các đổ màu xanh giống nhau](color-copy-before.png)

Sau khi thay đổi chủ đề, nguồn và bản sao có nhận thức chủ đề sẽ theo màu nhấn mới và giữ tông màu. Bản sao RGB cố định vẫn giữ màu xanh:

![Nguồn và đích copyFrom với các đổ màu cam, trong khi đích RGB cố định vẫn là màu xanh](color-copy-after.png)

Định nghĩa được sao chép là độc lập với nguồn. Thay đổi tham chiếu chủ đề của nguồn, gán màu khác, hoặc thêm/bớt biến đổi sẽ không ảnh hưởng đến đích. Thay đổi chủ đề vẫn ảnh hưởng tới cả hai hình vì mỗi hình đều tham chiếu riêng vào cùng một màu chủ đề.

Lưu và mở lại tệp PPTX sẽ giữ lại kiểu màu được sao chép mà [IColorFormat.getColorType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icolorformat/#getColorType--) trả về, tham chiếu chủ đề và bộ sưu tập biến đổi mà [IColorFormat.getColorTransform](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icolorformat/#getColorTransform--) trả về; nó không làm phẳng định nghĩa thành RGB.

Khi sao chép giữa các ngữ cảnh chủ đề khác nhau, chẳng hạn các bản trình bày với bảng màu nhấn khác nhau, tham chiếu đã sao chép sẽ được giải quyết theo chủ đề của đích. Vì vậy cùng một tham chiếu và biến đổi có thể tạo ra màu hiển thị khác. Xem mục [Presentation Theme](/slides/vi/androidjava/presentation-theme/) để biết thêm về cấu hình màu chủ đề.

## **Sử Dụng Nền Slide Như Đổ Hình**

Dùng [IAutoShape.setUseBackgroundFill](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/#setUseBackgroundFill-boolean-) khi một hình cần khớp với nền slide, ví dụ trong mẫu bản trình bày. Đặt kiểu đổ bằng [IFillFormat.setFillType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformat/#setFillType-byte-) thành [FillType.NotDefined](https://reference.aspose.com/slides/androidjava/com.aspose.slides/filltype/) trước để loại bỏ bất kỳ đổ nào được chỉ định rõ. Với kết hợp này, hình sẽ sử dụng nền slide thay vì đổ kiểu của nó. Chỉ bật cờ này không loại bỏ một đổ được chỉ định sẵn.

Điều này khác với [FillType.NoFill](https://reference.aspose.com/slides/androidjava/com.aspose.slides/filltype/): đổ nền che các đối tượng phía sau hình bằng vùng nền slide tương ứng, trong khi “không đổ” để các đối tượng đó vẫn hiển thị. Gradient vẫn được căn chỉnh với slide thay vì bắt đầu lại bên trong mỗi hình.

Ví dụ sau tạo nền chủ được kế thừa bởi slide và đặt một dải màu hồng phía sau ba hình chữ nhật. Hình bên trái sử dụng nền, hình ở giữa không có đổ, và hình bên phải chuyển từ đổ nền sang đổ màu cam rõ ràng.

```java
import com.aspose.slides.*;
import android.graphics.Color;

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
    gradient.getGradientStops().add(0, Color.rgb(0, 0, 139));
    gradient.getGradientStops().add(1, Color.rgb(135, 206, 250));

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

    // Tắt việc đổ nền trước khi áp dụng đổ rõ ràng.
    explicitShape.setUseBackgroundFill(false);
    explicitShape.getFillFormat().setFillType(FillType.Solid);
    explicitShape.getFillFormat().getSolidFillColor().setColor(Color.rgb(255, 165, 0));

    presentation.save("background_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Kết quả, từ trái sang phải: **đổ nền**, **không đổ**, và **đổ rõ ràng**. Dải màu hồng bị ẩn bởi hai hình bên trái và phải nhưng vẫn hiện ra qua hình ở giữa.

![Đổ nền, không đổ và đổ màu cam rõ ràng trên dải màu hồng](background-fill.png)

Hành vi tương tự áp dụng cho nền được định nghĩa trực tiếp trên slide hoặc kế thừa từ layout. Hình sử dụng nền đã được giải quyết của slide; ví dụ này để cả nền slide và layout không xác định để master cung cấp.

## **Đặt Độ Trong Suốt**

Đối với đổ màu đặc, thành phần alpha của màu kiểm soát độ mờ: 0 hoàn toàn trong suốt và 255 hoàn toàn không trong suốt. Ví dụ này dùng giá trị alpha 128 cho một hình chữ nhật màu vàng, làm cho nó khoảng 50% trong suốt để hình dưới vẫn nhìn thấy. Màu được gán qua [IFillFormat.getSolidFillColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformat/#getSolidFillColor--).

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape solidShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    IAutoShape transparentShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 80, 80, 150, 75);
    transparentShape.getFillFormat().setFillType(FillType.Solid);
    transparentShape.getFillFormat().getSolidFillColor().setColor(Color.argb(128, 255, 255, 0));

    presentation.save("shape_transparency.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Kết quả:

![Hình trong suốt](shape-transparency.png)

## **Xoay Hình**

Sử dụng [IShape.setRotation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#setRotation-float-) để xoay một hình trong mặt phẳng slide. Góc đo bằng độ; ví dụ này xoay một hình chữ nhật 5 độ theo chiều kim đồng hồ và lưu bản trình bày.

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

![Xoay hình](shape-rotation.png)

## **Thêm Hiệu Ứng Bo 3D**

Sử dụng [IShape.getThreeDFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#getThreeDFormat--) để tạo độ sâu và các cạnh bo cho một hình. Ví dụ này tạo một ellipse xanh lá với viền cam, dùng [IThreeDFormat.setDepth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#setDepth-double-) đặt độ sâu 4 điểm, và áp dụng một bo trên tròn với chiều rộng và chiều cao 6 điểm qua [IThreeDFormat.getBevelTop](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#getBevelTop--). Một camera trực quan hướng mặt và chiếu sáng ba‑điểm làm cho bo hiển thị.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 50, 100, 100);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(Color.rgb(0, 128, 0));
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.rgb(255, 165, 0));
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

Góc nhìn 3D của một hình được điều khiển bởi cài đặt camera. Ví dụ này dùng [ICamera.setRotation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icamera/#setRotation-float-float-float-) với các góc vĩ độ, kinh độ và vòng quay là 40, 35 và 20 độ. Nó chọn một camera isometric qua [ICamera.setCameraType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icamera/#setCameraType-int-) và ánh sáng cân bằng qua [ILightRig.setLightType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilightrig/#setLightType-int-), sau đó lưu hình chữ nhật đã định dạng.

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

## **Kiểm Soát Render Đen‑Trắng Cho Các Hình**

Phương thức [IShape.setBlackWhiteMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#setBlackWhiteMode-byte-) chỉ định cách một hình được render khi bản trình bày được xem hoặc xử lý ở chế độ đen‑trắng. Nó không tự động bật chế độ đen‑trắng và không thay đổi đổ, đường viền hoặc các định dạng khác của hình trong chế độ màu bình thường.

Sử dụng một giá trị từ lớp [BlackWhiteMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/blackwhitemode/) để chọn hành vi mong muốn. Ví dụ, `Automatic` để ứng dụng render quyết định cách chuyển đổi, `Gray` và `LightGray` dùng màu xám, `BlackWhite` chỉ dùng đen và trắng, `Black` và `White` ép một màu duy nhất, `Color` giữ màu bình thường, và `Hidden` bỏ qua hình trong chế độ đen‑trắng. `NotDefined` nghĩa là không có chế độ cấp độ hình được gán.

Ví dụ này tạo một hình chữ nhật màu cam và dùng [IShape.setBlackWhiteMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#setBlackWhiteMode-byte-) để chọn màu xám. Hình được lưu giữ màu cam cho hiển thị màu bình thường và yêu cầu màu xám từ các ứng dụng tôn trọng cài đặt hiển thị đen‑trắng:

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(Color.rgb(255, 165, 0));
    shape.setBlackWhiteMode(BlackWhiteMode.Gray);

    presentation.save("shape_black_white_mode.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Trong chế độ màu bình thường, hình chữ nhật giữ màu cam. Trong quy trình làm việc hiển thị đen‑trắng, nó dùng màu xám vì chế độ đã được đặt thành `Gray`. Điều này cho phép bạn giữ slide đầy màu sắc trong khi định nghĩa một giao diện riêng cho in ấn, xem trước hoặc các quy trình khác tôn trọng cài đặt hiển thị đen‑trắng của bản trình bày.

## **Đặt Lại Định Dạng**

Sử dụng [ISlide.reset](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/#reset--) để khôi phục vị trí, kích thước và định dạng của các placeholder slide từ các placeholder bố cục tương ứng. Ví dụ này yêu cầu một bản trình bày hiện có với các placeholder liên kết bố cục và đặt lại mọi slide trước khi lưu. Các hình không có placeholder bố cục tương ứng sẽ không được đặt lại.

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

## **Câu Hỏi Thường Gặp**

**Định dạng hình có ảnh hưởng đến kích thước cuối cùng của tệp PPTX không?**

Màu sắc, kiểu đường và cài đặt hiệu ứng thường chỉ thêm một lượng dữ liệu nhỏ so với hình ảnh và phương tiện được nhúng. Đổ hình ảnh có thể làm tăng kích thước tệp vì ảnh được lưu trong bản trình bày.

**Làm sao tôi có thể phát hiện các hình trên một slide có định dạng giống hệt nhau để có thể nhóm chúng?**

So sánh các thuộc tính định dạng chính của mỗi hình—đổ, đường và cài đặt hiệu ứng. Nếu tất cả các giá trị tương ứng trùng khớp, coi chúng là cùng một phong cách và nhóm logic các hình đó, giúp quản lý phong cách sau này dễ dàng hơn.

**Tôi có thể lưu một tập hợp các kiểu hình tùy chỉnh vào tệp riêng để tái sử dụng trong các bản trình bày khác không?**

Có. Lưu các hình mẫu với các kiểu mong muốn trong một slide deck mẫu hoặc tệp .POTX. Khi tạo bản trình bày mới, mở mẫu, sao chép các hình đã định dạng bạn cần và áp dụng lại định dạng của chúng ở nơi cần.