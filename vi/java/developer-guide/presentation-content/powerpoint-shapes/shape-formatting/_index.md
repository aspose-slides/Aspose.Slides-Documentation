---
title: Định dạng các hình PowerPoint trong Java
linktitle: Định dạng Hình
type: docs
weight: 20
url: /vi/java/shape-formatting/
keywords:
- định dạng hình
- định dạng đường
- hiệu ứng vẽ nháp
- đường vẽ nháp cho hình
- định dạng kiểu nối
- đổ màu gradient
- đổ mẫu
- đổ hình ảnh
- đổ kết cấu
- đổ màu đồng nhất
- trong suốt hình
- kết xuất hình đen‑trắng
- kết xuất hình xám
- xoay hình
- hiệu ứng viền 3D
- hiệu ứng xoay 3D
- đặt lại định dạng
- PowerPoint
- bản trình bày
- Java
- Aspose.Slides
description: "Tìm hiểu cách định dạng các hình PowerPoint trong Java bằng Aspose.Slides—đặt các kiểu đổ, đường và hiệu ứng cho tệp PPT và PPTX một cách chính xác và kiểm soát toàn diện."
---
## **Giới thiệu**

Định dạng các hình dạng trong PowerPoint bằng cách điều chỉnh viền, tô màu và hiệu ứng. Aspose.Slides cho Java cho phép bạn kiểm soát các cài đặt này bằng chương trình, bao gồm độ trong suốt, xoay và định dạng 3D.

![Các tùy chọn định dạng hình trong PowerPoint](format-shape-powerpoint.png)

Aspose.Slides cho Java cung cấp các giao diện và phương thức cho phép bạn định dạng hình dạng bằng các tùy chọn có sẵn trong PowerPoint.

## **Định dạng Đường**

Sử dụng [IShape.getLineFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#getLineFormat--) để kiểm soát viền của hình. Ví dụ này tạo một hình chữ nhật không tô màu với viền xanh đứt nét. [ILineFormat.setStyle](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#setStyle-byte-) chọn một đường ghép dày‑mỏng, trong khi [ILineFormat.setWidth](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#setWidth-double-) đặt độ rộng thành 7 điểm và [ILineFormat.setDashStyle](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#setDashStyle-byte-) chọn mẫu nét đứt.

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

![Các đường viền đã định dạng trong bản trình bày](formatted-lines.png)

### **Đặt Mẫu Đường Nét Tùy Chỉnh**

Sử dụng [ILineFormat.setCustomDashPattern](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#setCustomDashPattern-float:A-) khi các kiểu đường nét định sẵn không cung cấp độ dài dash và khoảng trống bạn cần, ví dụ cho viền thương hiệu hoặc sơ đồ kỹ thuật. Gán một mẫu sẽ tự động thay đổi kiểu dash của đường thành [LineDashStyle.Custom](https://reference.aspose.com/slides/java/com.aspose.slides/linedashstyle/).

Các mục trong mảng luân phiên giữa độ dài dash và khoảng trống, bắt đầu bằng dash. Mỗi giá trị là bội của độ rộng đường: `{ 4, 2 }` với độ rộng 3 điểm tạo ra dash 12 điểm sau đó là khoảng trống 6 điểm. Sử dụng các cặp giá trị hữu hạn, không âm để định nghĩa các đoạn dash‑và‑khoảng trống hoàn chỉnh. Ví dụ sử dụng các giá trị dương để giữ cho mọi dash và khoảng trống đều hiển thị.

Ví dụ này tạo năm đường màu xanh với cùng độ dài và đầu phẳng. Ba đường đầu tiên so sánh các mẫu ở độ rộng 3 điểm. Đường thứ tư lặp lại mẫu đầu tiên với độ rộng gấp đôi, làm gấp đôi cả độ dài dash và khoảng trống. Đường thứ năm chuyển từ mẫu tùy chỉnh sang đường liền.

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

    // Đặt đường cuối cùng thành kiểu liền.
    slide.getShapes().get_Item(4).getLineFormat().setDashStyle(LineDashStyle.Solid);

    presentation.save("custom_dash_patterns.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Để trở lại một kiểu dash định sẵn, hãy truyền [LineDashStyle.Dash](https://reference.aspose.com/slides/java/com.aspose.slides/linedashstyle/) vào [ILineFormat.setDashStyle](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#setDashStyle-byte-). Kiểu đã chọn sẽ điều khiển giao diện của đường.

Kết quả trong PowerPoint, từ trên xuống dưới: **{4, 2}, 3 pt**; **{1, 2}, 3 pt**; **{6, 2, 1, 2}, 3 pt**; **{4, 2}, 6 pt**; và **Solid, 3 pt**.

![Ba mẫu dash tùy chỉnh, một đường rộng hơn sử dụng mẫu đầu tiên, và một đường liền trong PowerPoint](custom-dash-patterns.png)

### **Đặt Đầu Đường**

Sử dụng [ILineFormat.setCapStyle](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#setCapStyle-byte-) để đặt đầu của một đường mở. Lớp [LineCapStyle](https://reference.aspose.com/slides/java/com.aspose.slides/linecapstyle/) cung cấp ba kiểu đầu rõ ràng:

- `Flat`: Đường kẻ dừng lại tại điểm cuối.
- `Round`: Đầu cung tròn mở rộng ra ngoài điểm cuối một nửa độ rộng đường.
- `Square`: Đầu vuông mở rộng ra ngoài điểm cuối một nửa độ rộng đường.

Lớp cũng bao gồm `NotDefined`, có nghĩa là không có kiểu đầu nào được gán một cách rõ ràng.

Đầu khác với mũi tên, chúng thêm ký hiệu vào đầu đường, và các nối, chúng kiểm soát góc giữa các đoạn đường. Ví dụ này tắt mũi tên bằng cách sử dụng [ILineFormat.setBeginArrowheadStyle](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#setBeginArrowheadStyle-byte-) và [ILineFormat.setEndArrowheadStyle](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#setEndArrowheadStyle-byte-) để chỉ so sánh các hình dạng đầu.

Ví dụ dưới đây tạo ba đường ngang hầu như giống nhau, mỗi đường rộng 20 điểm. Từ trên xuống dưới, chúng sử dụng đầu phẳng, tròn và vuông. Các điểm cuối của chúng có cùng tọa độ ngang; đầu tròn và vuông mở rộng ra 10 điểm ngoài mỗi điểm cuối.

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

![Đầu phẳng, tròn và vuông trên các đường dày đồng nhất trong PowerPoint](line-caps.png)

## **Áp Dụng Hiệu Ứng Vẽ Nháp cho Đường Hình**

Hiệu ứng vẽ nháp khiến đường của hình trông như được vẽ tay. Sử dụng [IShape.getLineFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#getLineFormat--) để truy cập cài đặt đường, [ILineFormat.getSketchFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#getSketchFormat--) để truy cập cài đặt nháp, và [ISketchFormat.setSketchType](https://reference.aspose.com/slides/java/com.aspose.slides/isketchformat/#setSketchType-int-) để chọn một giá trị từ lớp [LineSketchType](https://reference.aspose.com/slides/java/com.aspose.slides/linesketchtype/).

Đoạn mã Java sau cho thấy cách áp dụng hiệu ứng [LineSketchType.Curved](https://reference.aspose.com/slides/java/com.aspose.slides/linesketchtype/), đọc giá trị đã gán một cách rõ ràng, và loại bỏ hiệu ứng bằng [LineSketchType.None](https://reference.aspose.com/slides/java/com.aspose.slides/linesketchtype/):

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

Giá trị trả về bởi [ISketchFormat.getSketchType](https://reference.aspose.com/slides/java/com.aspose.slides/isketchformat/#getSketchType--) biểu thị cài đặt được gán trực tiếp cho hình. Nếu định dạng đường có thể được kế thừa từ chủ đề, slide chủ, hoặc slide bố trí, sử dụng [ILineFormat.getEffective](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#getEffective--), truy cập [ILineFormatEffectiveData.getSketchFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformateffectivedata/#getSketchFormat--), và đọc [ISketchFormatEffectiveData.getSketchType](https://reference.aspose.com/slides/java/com.aspose.slides/isketchformateffectivedata/#getSketchType--). Giá trị hiệu quả phản ánh định dạng thực sự được áp dụng sau khi kế thừa được giải quyết. Ví dụ này yêu cầu một bản trình bày hiện có có ít nhất một hình trên slide đầu tiên và in cả hai giá trị:

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

Dưới đây là ba tùy chọn kiểu nối:

* Round
* Miter
* Bevel

Kiểu nối kiểm soát cách hai đoạn viền gặp nhau tại một góc. Sử dụng **Round** cho các góc tròn, **Miter** cho các góc nhọn, hoặc **Bevel** cho các góc được làm phẳng.

![Kiểu nối trong bản trình bày](join-style-powerpoint.png)

Ví dụ này tạo ba hình chữ nhật màu đen với viền xanh rộng 15 điểm. Nó sử dụng [ILineFormat.setJoinStyle](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#setJoinStyle-byte-) để đặt các giá trị miter, bevel và round của [LineJoinStyle](https://reference.aspose.com/slides/java/com.aspose.slides/linejoinstyle/), tương ứng, để so sánh cách các góc được vẽ.

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

### **Giới Hạn Nối Miter ở Các Góc Gọn**

Sử dụng [ILineFormat.setMiterLimit](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#setMiterLimit-float-) cùng với [ILineFormat.setJoinStyle](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#setJoinStyle-byte-) được đặt thành [LineJoinStyle.Miter](https://reference.aspose.com/slides/java/com.aspose.slides/linejoinstyle/) để giới hạn độ mở rộng của một góc nhọn.

Giới hạn là tỉ lệ giữa khoảng cách giữa góc trong và góc ngoài của nối so với độ rộng đường. Ví dụ, giá trị `8` cho phép độ dài miter lên tới tám lần độ rộng đường; nó không phải là đo bằng điểm. Nếu góc vượt quá giới hạn, PowerPoint sẽ dùng nối bevel ở góc đó. Giới hạn lớn hơn cho phép các điểm nhọn hơn. Cài đặt này chỉ ảnh hưởng đến các nối miter và việc thay đổi nó sẽ không gây ra hiệu ứng nhìn thấy khi góc vẫn nằm trong cả hai giới hạn.

Ví dụ này tạo hai tam giác không tô màu giống hệt nhau với viền rộng 20 điểm. Tam giác bên trái sử dụng giới hạn `2`, còn bên phải sử dụng `8`. Mỗi tam giác rộng 80 điểm và cao 160 điểm, tạo ra tỉ lệ độ dài miter‑so‑với‑độ‑rộng‑đường ở góc trên khoảng `4.12`. Do đó, PowerPoint sẽ bevel đỉnh trái và giữ nguyên đỉnh phải.

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

![Một đỉnh được cắt chừng với giới hạn miter 2 và một đỉnh nhọn với giới hạn miter 8 trong PowerPoint](miter-limits.png)

## **Đổ Màu Gradient**

Gradient kết hợp các màu trên một hình. Ví dụ này đổ màu gradient tuyến tính vào một hình ellipse với góc 45 độ từ đỏ sang tím bằng cách sử dụng [IFillFormat.getGradientFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformat/#getGradientFormat--). Phương thức [IGradientStopCollection.addPresetColor](https://reference.aspose.com/slides/java/com.aspose.slides/igradientstopcollection/#addPresetColor-float-int-) đặt các điểm dừng màu tại 0 và 1, tức là đầu và cuối gradient. Xóa các điểm dừng hiện có đảm bảo chỉ sử dụng hai màu này.

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

![Hình ellipse với màu gradient](gradient-fill.png)

Nếu một gradient trông khác nhau trong ảnh xuất ra so với trong PowerPoint, xem [Chọn Kiểu Kết Xuất Gradient](/slides/vi/java/convert-powerpoint-to-png/#choose-a-gradient-rendering-style). Bạn có thể chọn kiểu kết xuất mà không thay đổi gradient được lưu trong bản trình bày.

### **Đặt Góc Gradient Tuyến Tính**

Sử dụng [IGradientFormat.setLinearGradientAngle](https://reference.aspose.com/slides/java/com.aspose.slides/igradientformat/#setLinearGradientAngle-float-) để kiểm soát hướng của một lớp màu [GradientShape.Linear](https://reference.aspose.com/slides/java/com.aspose.slides/gradientshape/). Góc đo bằng độ và tăng theo chiều kim đồng hồ: `0` chạy từ trái sang phải, `90` từ trên xuống dưới, `180` từ phải sang trái, và `270` từ dưới lên trên. Hỗ trợ các góc phân số. Các góc hữu hạn ngoài `[0, 360)` sẽ được chuẩn hoá thành một vòng quay; ví dụ, `-45` trở thành `315` và `360` trở thành `0`.

Ví dụ này tạo sáu hình chữ nhật với các điểm dừng màu đỏ, xanh lá và xanh dương giống nhau tại vị trí `0`, `0.5`, và `1`. Tính năng thu phóng bị tắt để có thể so sánh góc độc lập với tỉ lệ hình chữ nhật. Các góc, từ trái sang phải, là `0`, `45`, và `90` ở hàng đầu, và `135`, `180`, và `270` ở hàng thứ hai.

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

![Gradient tuyến tính ở 0°, 45°, và 90° ở hàng trên, và 135°, 180°, và 270° ở hàng dưới](linear-gradient-angles.png)

### **Thu Phóng Gradient Tuyến Tính theo Hình**

[IGradientFormat.setLinearGradientScaled](https://reference.aspose.com/slides/java/com.aspose.slides/igradientformat/#setLinearGradientScaled-byte-) nhận một giá trị [NullableBool](https://reference.aspose.com/slides/java/com.aspose.slides/nullablebool/). Đặt rõ ràng thành `False` để giữ góc gradient hình học khi tỷ lệ hình thay đổi, hoặc thành `True` để thu phóng gradient cùng với chiều rộng và chiều cao của hình. Khi thu phóng bật, góc nhìn thấy có thể khác với góc đã gán trên một hình không vuông.

Ví dụ dưới đây sử dụng góc `45` độ và các điểm dừng màu giống như so sánh góc. Cột trái dùng `False`; cột phải dùng `True`. Mỗi cột chứa một hình chữ nhật rộng trên một hình chữ nhật cao. Cả hai đều bắt đầu với cùng kích thước rộng; việc thay đổi chiều rộng và chiều cao của hình chữ nhật thứ hai cho thấy cách màu đổ phản hồi khi thay đổi kích thước mà không thay đổi cài đặt gradient.

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

Kết quả trong PowerPoint, với thu phóng bị tắt ở bên trái và bật ở bên phải:

![Các hình chữ nhật rộng và cao với gradient 45°, so sánh LinearGradientScaled False ở bên trái với True ở bên phải](linear-gradient-scaling.png)

Với thu phóng bị tắt, các dải màu chéo giữ cùng hướng trong cả hai hình chữ nhật. Với thu phóng bật, các dải màu kéo dài theo tỷ lệ hình. Điều này giúp tái tạo gradient của mẫu khi điều chỉnh hình sang kích thước khác. Trên một hình vuông, bật thu phóng không làm thay đổi ngoại hình của gradient `45` độ này.

Cả hai cài đặt góc và thu phóng áp dụng cho gradient tuyến tính. Chúng không kiểm soát các lớp màu [GradientShape.Radial hoặc GradientShape.Rectangle](https://reference.aspose.com/slides/java/com.aspose.slides/gradientshape/).

### **Kết Hợp Góc với Hướng Gradient**

[IGradientFormat.setGradientDirection](https://reference.aspose.com/slides/java/com.aspose.slides/igradientformat/#setGradientDirection-int-) chọn một kiểu gradient từ lớp [GradientDirection](https://reference.aspose.com/slides/java/com.aspose.slides/gradientdirection/); nó không thay thế cho một góc số. Đối với gradient tuyến tính, các kiểu góc có thể thay đổi vùng màu được phân bố mà không thay đổi góc được gán qua [setLinearGradientAngle](https://reference.aspose.com/slides/java/com.aspose.slides/igradientformat/#setLinearGradientAngle-float-). Giữ hướng không đổi khi so sánh góc hoặc thu phóng.

Ví dụ dưới đây áp dụng các cài đặt giống nhau theo thứ tự ngược nhau. Hai hình chữ nhật có cùng ngoại hình: gán hướng trước hoặc sau góc không làm thay đổi kết quả.

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

Đổ mẫu áp dụng một thiết kế hai màu, chẳng hạn chấm, sọc, hoặc ca rô. Ví dụ này sử dụng [IPatternFormat.setPatternStyle](https://reference.aspose.com/slides/java/com.aspose.slides/ipatternformat/#setPatternStyle-byte-) để chọn mẫu trellis. [IPatternFormat.getBackColor](https://reference.aspose.com/slides/java/com.aspose.slides/ipatternformat/#getBackColor--) cung cấp nền xám nhạt, và [IPatternFormat.getForeColor](https://reference.aspose.com/slides/java/com.aspose.slides/ipatternformat/#getForeColor--) cung cấp màu vàng cho mẫu.

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

![Hình chữ nhật với đổ mẫu](pattern-fill.png)

## **Đổ Hình Ảnh**

Đổ hình ảnh sử dụng một ảnh bên trong một hình. Ví dụ này yêu cầu một ảnh cục bộ và sử dụng [Images.fromFile](https://reference.aspose.com/slides/java/com.aspose.slides/images/#fromFile-java.lang.String-) để tải nó vào bộ sưu tập ảnh của bản trình bày. Đặt [IPictureFillFormat.setPictureFillMode](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setPictureFillMode-int-) ở chế độ lặp lại sẽ lặp lại ảnh trong hình chữ nhật. Ảnh nguồn được sử dụng ở đây được hiển thị bên dưới:

![Hình ảnh hoa sen](lotus.png)

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

![Hình dạng với đổ hình ảnh](picture-fill.png)

### **Lật Hình Ảnh Thành Kết Cấu**

Nếu bạn muốn đặt một ảnh lặp lại làm kết cấu và tùy chỉnh hành vi lặp, bạn có thể sử dụng các phương pháp sau của giao diện [IPictureFillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/) và lớp [PictureFillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/picturefillformat/):

- [setPictureFillMode](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setPictureFillMode-int-): Đặt chế độ đổ hình ảnh—hoặc `Tile` hoặc `Stretch`.
- [setTileAlignment](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setTileAlignment-byte-): Xác định căn chỉnh của các ô trong hình dạng.
- [setTileFlip](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setTileFlip-int-): Kiểm soát việc lật ô theo chiều ngang, chiều dọc, hoặc cả hai.
- [setTileOffsetX](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setTileOffsetX-float-): Đặt độ dịch chuyển ngang của ô (theo điểm) so với nguồn gốc của hình dạng.
- [setTileOffsetY](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setTileOffsetY-float-): Đặt độ dịch chuyển dọc của ô (theo điểm) so với nguồn gốc của hình dạng.
- [setTileScaleX](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setTileScaleX-float-): Xác định tỉ lệ ngang của ô dưới dạng phần trăm.
- [setTileScaleY](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setTileScaleY-float-): Xác định tỉ lệ dọc của ô dưới dạng phần trăm.

Ví dụ này yêu cầu một ảnh cục bộ và cấu hình [IPictureFillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/) để lặp lại nó với kích thước 50% so với kích thước gốc. Độ dịch chuyển `−32` điểm dịch các ô theo chiều ngang và chiều dọc; căn chỉnh dưới‑phải và lật cả hai hướng xác định cách kết cấu lặp được sắp xếp.

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

![Các tùy chọn xếp gạch](tile-options.png)

## **Đổ Màu Đơn**

Đổ màu đơn cung cấp cho hình một màu duy nhất, đồng nhất. Ví dụ này sử dụng [IFillFormat.setFillType](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformat/#setFillType-byte-) để đặt chế độ đổ màu đơn và gán màu vàng qua [IFillFormat.getSolidFillColor](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformat/#getSolidFillColor--), sau đó lưu hình chữ nhật trong một bản trình bày.

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

![Hình dạng với màu đổ đơn](solid-color-fill.png)

## **Sử Dụng Nền Slide làm Đổ cho Hình**

Sử dụng [IAutoShape.setUseBackgroundFill](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/#setUseBackgroundFill-boolean-) khi một hình cần khớp với nền slide, ví dụ trong một mẫu bản trình bày. Sử dụng [IFillFormat.setFillType](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformat/#setFillType-byte-) để [FillType.NotDefined](https://reference.aspose.com/slides/java/com.aspose.slides/filltype/) trước nhằm loại bỏ bất kỳ đổ màu nào được xác định rõ. Với sự kết hợp này, hình sẽ sử dụng nền slide thay vì đổ màu kiểu của nó. Chỉ bật cờ này không loại bỏ một đổ màu đã xác định sẵn.

Điều này khác với [FillType.NoFill](https://reference.aspose.com/slides/java/com.aspose.slides/filltype/): đổ màu nền phủ các đối tượng phía sau hình bằng khu vực nền slide tương ứng, trong khi không đổ để lại các đối tượng đó hiển thị. Gradient vẫn được căn chỉnh với slide thay vì khởi động lại bên trong mỗi hình.

Ví dụ dưới đây tạo một nền chủ được kế thừa bởi slide và đặt một dải màu magenta phía sau ba hình chữ nhật. Hình chữ nhật bên trái sử dụng nền, hình giữa không có đổ, và hình bên phải chuyển từ đổ nền sang đổ màu cam rõ ràng.

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

    // Vô hiệu hoá việc đổ nền trước khi áp dụng đổ màu rõ ràng.
    explicitShape.setUseBackgroundFill(false);
    explicitShape.getFillFormat().setFillType(FillType.Solid);
    explicitShape.getFillFormat().getSolidFillColor().setColor(new Color(255, 165, 0));

    presentation.save("background_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Kết quả, từ trái sang phải: **background fill**, **no fill**, và **explicit fill**. Dải màu magenta bị ẩn bởi hình bên trái và bên phải nhưng vẫn hiển thị qua hình giữa.

![Nền đổ, không đổ, và đổ màu cam rõ ràng trên dải màu magenta](background-fill.png)

Hành vi tương tự áp dụng cho nền được định nghĩa trực tiếp trên slide hoặc kế thừa từ bố trí. Hình sử dụng nền đã được giải quyết của slide; ví dụ để cả nền slide và nền bố trí không xác định để master cung cấp.

## **Đặt Độ Trong Suốt**

Đối với đổ màu đơn, thành phần alpha của màu kiểm soát độ trong suốt: 0 là hoàn toàn trong suốt và 255 là hoàn toàn mờ. Ví dụ này sử dụng giá trị alpha 128 cho một hình chữ nhật màu vàng, làm cho nó gần 50% trong suốt để hình chữ nhật phía dưới vẫn nhìn thấy. Màu được gán qua [IFillFormat.getSolidFillColor](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformat/#getSolidFillColor--).

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

![Hình dạng trong suốt](shape-transparency.png)

## **Xoay Hình**

Sử dụng [IShape.setRotation](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#setRotation-float-) để xoay một hình trong mặt phẳng slide. Góc đo bằng độ; ví dụ này xoay một hình chữ nhật 5 độ theo chiều kim đồng hồ và lưu bản trình bày.

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

![Xoay hình](shape-rotation.png)

## **Thêm Hiệu Ứng Viền 3D**

Sử dụng [IShape.getThreeDFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#getThreeDFormat--) để cho hình có độ sâu và các cạnh viền. Ví dụ này tạo một ellipse màu xanh lá cây với viền màu cam, sử dụng [IThreeDFormat.setDepth](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#setDepth-double-) để đặt độ sâu 4 điểm, và áp dụng viền trên dạng vòng tròn với độ rộng và độ cao 6 điểm qua [IThreeDFormat.getBevelTop](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#getBevelTop--). Một camera trực diện dạng orthographic và ánh sáng ba‑điểm làm cho viền hiển thị.

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

![Hiệu ứng viền 3D](3D-bevel-effect.png)

## **Thêm Hiệu Ứng Xoay 3D**

Góc nhìn 3D của hình được điều khiển bởi các cài đặt camera. Ví dụ này sử dụng [ICamera.setRotation](https://reference.aspose.com/slides/java/com.aspose.slides/icamera/#setRotation-float-float-float-) với các góc vĩ độ, kinh độ và quay vòng là 40, 35, và 20 độ tương ứng. Nó chọn một camera isometric qua [ICamera.setCameraType](https://reference.aspose.com/slides/java/com.aspose.slides/icamera/#setCameraType-int-) và ánh sáng cân bằng qua [ILightRig.setLightType](https://reference.aspose.com/slides/java/com.aspose.slides/ilightrig/#setLightType-int-), rồi lưu hình chữ nhật đã định dạng.

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

![Hiệu ứng xoay 3D](3D-rotation-effect.png)

## **Kiểm Soát Kết Xuất Đen‑Trắng cho Hình**

Phương pháp [IShape.setBlackWhiteMode](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#setBlackWhiteMode-byte-) chỉ định cách một hình riêng lẻ được kết xuất khi bản trình bày được xem hoặc xử lý ở chế độ đen‑trắng. Nó không tự động bật hiển thị đen‑trắng và không thay đổi đổ màu, viền hay các định dạng khác của hình trong chế độ màu bình thường.

Sử dụng một giá trị từ lớp [BlackWhiteMode](https://reference.aspose.com/slides/java/com.aspose.slides/blackwhitemode/) để chọn hành vi mong muốn. Ví dụ, `Automatic` để ứng dụng kết xuất chọn cách chuyển đổi, `Gray` và `LightGray` sử dụng màu xám, `BlackWhite` chỉ dùng đen và trắng, `Black` và `White` buộc một màu duy nhất, `Color` giữ nguyên màu bình thường, và `Hidden` bỏ qua hình trong chế độ đen‑trắng. `NotDefined` có nghĩa là không có chế độ cấp độ hình nào được gán.

Ví dụ này tạo một hình chữ nhật màu cam và sử dụng [IShape.setBlackWhiteMode](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#setBlackWhiteMode-byte-) để đặt chế độ thành `Gray`. Hình đã lưu giữ nguyên màu cam cho hiển thị màu bình thường và yêu cầu màu xám từ các ứng dụng tôn trọng cài đặt hiển thị đen‑trắng:

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

Trong chế độ màu bình thường, hình chữ nhật giữ màu cam. Trong quy trình hiển thị đen‑trắng, nó sử dụng màu xám vì chế độ được đặt thành `Gray`. Điều này cho phép bạn bảo tồn một slide đầy màu sắc đồng thời định nghĩa giao diện riêng cho in ấn, xem trước, hoặc các quy trình khác tôn trọng cài đặt hiển thị đen‑trắng của bản trình bày.

## **Đặt Lại Định Dạng**

Sử dụng [ISlide.reset](https://reference.aspose.com/slides/java/com.aspose.slides/islide/#reset--) để khôi phục vị trí, kích thước và định dạng của các placeholder trên slide từ các placeholder bố trí tương ứng. Ví dụ này yêu cầu một bản trình bày hiện có có các placeholder liên kết bố trí và đặt lại mọi slide trước khi lưu. Các hình không có placeholder bố trí tương ứng sẽ không được đặt lại.

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

## **CÂU HỎI THƯỜNG GẶP**

**Định dạng hình ảnh có ảnh hưởng đến kích thước cuối cùng của file trình bày không?**

Màu sắc, kiểu đường và cài đặt hiệu ứng thường chỉ thêm một lượng dữ liệu nhỏ so với các ảnh và phương tiện nhúng. Đổ hình ảnh có thể tăng kích thước file vì ảnh của chúng được lưu trong bản trình bày.

**Làm sao tôi có thể phát hiện các hình trên slide có cùng định dạng để nhóm chúng lại?**

So sánh mỗi hình dựa trên các thuộc tính định dạng chính — màu đổ, kiểu đường và cài đặt hiệu ứng. Nếu tất cả các giá trị tương ứng khớp nhau, coi chúng là cùng một kiểu và nhóm các hình lại, điều này giúp việc quản lý kiểu sau này đơn giản hơn.

**Tôi có thể lưu một tập hợp các kiểu hình tùy chỉnh vào một tệp riêng để sử dụng lại trong các bản trình bày khác không?**

Có. Lưu các hình mẫu có kiểu mong muốn trong một slide mẫu hoặc tệp .POTX. Khi tạo bản trình bày mới, mở mẫu, sao chép các hình đã tạo kiểu cần thiết, và áp dụng lại định dạng của chúng ở bất kỳ nơi nào cần.