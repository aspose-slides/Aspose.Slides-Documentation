---
title: Quản lý Chủ đề Bản trình chiếu trên Android
linktitle: Chủ đề Trình chiếu
type: docs
weight: 10
url: /vi/androidjava/presentation-theme/
keywords:
- Chủ đề PowerPoint
- Chủ đề trình chiếu
- Chủ đề slide
- Đặt chủ đề
- Thay đổi chủ đề
- Quản lý chủ đề
- Màu chủ đề
- Bảng màu bổ sung
- Phông chữ chủ đề
- Kiểu chủ đề
- Hiệu ứng chủ đề
- PowerPoint
- OpenDocument
- Trình chiếu
- Android
- Java
- Aspose.Slides
description: "Quản lý các chủ đề bản trình chiếu trong Aspose.Slides cho Android bằng Java để tạo, tùy chỉnh và chuyển đổi các tệp PowerPoint với thương hiệu nhất quán."
---
## **Giới thiệu**

Một chủ đề trình chiếu xác định các thuộc tính của các yếu tố thiết kế. Khi bạn chọn một chủ đề trình chiếu, thực chất bạn đang chọn một tập hợp cụ thể các yếu tố trực quan và các thuộc tính của chúng.

Trong PowerPoint, một chủ đề gồm các màu, [phông chữ](/slides/vi/androidjava/powerpoint-fonts/), [kiểu nền](/slides/vi/androidjava/presentation-background/), và hiệu ứng.

![các thành phần của chủ đề](theme-constituents.png)

## **Thay đổi màu chủ đề**

Một chủ đề PowerPoint sử dụng một tập hợp màu cụ thể cho các yếu tố khác nhau trên một slide. Nếu bạn không thích các màu, bạn có thể thay đổi chúng bằng cách áp dụng màu mới cho chủ đề. Để cho phép bạn chọn màu chủ đề mới, Aspose.Slides cung cấp các giá trị trong enumeration [SchemeColor](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/SchemeColor).

Mã Java này cho bạn cách thay đổi màu nhấn cho một chủ đề:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    IAutoShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);

    shape.getFillFormat().setFillType(FillType.Solid);

    shape.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
} finally {
    if (pres != null) pres.dispose();
}
```

Bạn có thể xác định giá trị thực tế của màu kết quả bằng cách này:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation pres = new Presentation();
try {
    IAutoShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);

    shape.getFillFormat().setFillType(FillType.Solid);

    shape.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);

    IFillFormatEffectiveData fillEffective = shape.getFillFormat().getEffective();

    Color effectiveColor = fillEffective.getSolidFillColor();

    System.out.println(String.format("Color [A=%d, R=%d, G=%d, B=%d]",
            effectiveColor.getAlpha(), effectiveColor.getRed(), effectiveColor.getGreen(), effectiveColor.getBlue()));
} finally {
    if (pres != null) pres.dispose();
}
```

Để minh họa thêm thao tác thay đổi màu, chúng tôi tạo một yếu tố khác và gán màu nhấn (từ thao tác ban đầu) cho nó. Sau đó chúng tôi thay đổi màu trong chủ đề:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation pres = new Presentation();
try {
    IAutoShape otherShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 10, 120, 100, 100);

    otherShape.getFillFormat().setFillType(FillType.Solid);

    otherShape.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);

    pres.getMasterTheme().getColorScheme().getAccent4().setColor(Color.RED);
} finally {
    if (pres != null) pres.dispose();
}
```

Màu mới sẽ được áp dụng tự động cho cả hai yếu tố.

### **Đặt màu chủ đề từ bảng màu bổ sung**

Khi bạn áp dụng các biến đổi độ sáng cho màu chủ đề chính(1), các màu từ bảng màu bổ sung(2) sẽ được tạo ra. Bạn có thể sau đó đặt và lấy những màu chủ đề đó.

![các màu từ bảng màu bổ sung](additional-palette-colors.png)

**1** - Màu chủ đề chính  
**2** - Các màu từ bảng màu bổ sung.

Mã Java này minh họa một thao tác trong đó các màu từ bảng màu bổ sung được lấy từ màu chủ đề chính và sau đó được sử dụng trong các hình dạng:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Accent 4
    IShape shape1 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 50, 50);

    shape1.getFillFormat().setFillType(FillType.Solid);
    shape1.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);

    // Accent 4, Sáng hơn 80%
    IShape shape2 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 70, 50, 50);

    shape2.getFillFormat().setFillType(FillType.Solid);
    shape2.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape2.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.2f);
    shape2.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.AddLuminance, 0.8f);

    // Accent 4, Sáng hơn 60%
    IShape shape3 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 130, 50, 50);

    shape3.getFillFormat().setFillType(FillType.Solid);
    shape3.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape3.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.4f);
    shape3.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.AddLuminance, 0.6f);

    // Accent 4, Sáng hơn 40%
    IShape shape4 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 190, 50, 50);

    shape4.getFillFormat().setFillType(FillType.Solid);
    shape4.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape4.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.6f);
    shape4.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.AddLuminance, 0.4f);

    // Accent 4, Đậm hơn 25%
    IShape shape5 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 250, 50, 50);

    shape5.getFillFormat().setFillType(FillType.Solid);
    shape5.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape5.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.75f);

    // Accent 4, Đậm hơn 50%
    IShape shape6 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 310, 50, 50);

    shape6.getFillFormat().setFillType(FillType.Solid);
    shape6.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape6.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.5f);

    presentation.save("example_accent4.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

### **Ánh xạ `SchemeColor` tới các màu `IColorScheme`**

Khi bạn làm việc với [SchemeColor](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/schemecolor/), bạn có thể nhận thấy rằng nó chứa các giá trị màu chủ đề sau: `Background1`, `Background2`, `Text1` và `Text2`.

Tuy nhiên, `Presentation.getMasterTheme().getColorScheme()` trả về [IColorScheme](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/icolorscheme/), cung cấp các màu tương ứng là: `Dark1`, `Dark2`, `Light1` và `Light2`.

Sự khác nhau này chỉ ở tên gọi. Những giá trị này đề cập đến cùng các vị trí màu chủ đề và ánh xạ là cố định:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Không có chuyển đổi động giữa `Text`/`Background` và `Dark`/`Light`. Chúng chỉ là các tên thay thế cho cùng các màu chủ đề.

Sự khác nhau trong cách đặt tên này bắt nguồn từ thuật ngữ của Microsoft Office. Các phiên bản Office cũ dùng `Dark 1`, `Light 1`, `Dark 2`, và `Light 2`, trong khi các giao diện UI mới hiển thị cùng các vị trí này dưới dạng `Text 1`, `Background 1`, `Text 2`, và `Background 2`.

## **Thay đổi phông chữ chủ đề**

Để cho phép bạn chọn phông chữ cho chủ đề và các mục đích khác, Aspose.Slides sử dụng các định danh đặc biệt sau (tương tự như trong PowerPoint):

* **+mn-lt** - Phông chữ thân Latin (Phông chữ Latin phụ)
* **+mj-lt** - Phông chữ tiêu đề Latin (Phông chữ Latin chính)
* **+mn-ea** - Phông chữ thân Đông Á (Phông chữ Đông Á phụ)
* **+mj-ea** - Phông chữ tiêu đề Đông Á (Phông chữ Đông Á chính)

Mã Java này cho bạn cách gán phông chữ Latin cho một yếu tố chủ đề:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    IAutoShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);

    Paragraph paragraph = new Paragraph();

    Portion portion = new Portion("Theme text format");

    paragraph.getPortions().add(portion);

    shape.getTextFrame().getParagraphs().add(paragraph);

    portion.getPortionFormat().setLatinFont(new FontData("+mn-lt"));
} finally {
    if (pres != null) pres.dispose();
}
```

Mã Java này cho bạn cách thay đổi phông chữ chủ đề của bản trình chiếu:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    pres.getMasterTheme().getFontScheme().getMinor().setLatinFont(new FontData("Arial"));
} finally {
    if (pres != null) pres.dispose();
}
```

Phông chữ trong tất cả các hộp văn bản sẽ được cập nhật.

{{% alert color="info" title="TIP" %}} 
Bạn có thể muốn xem [phông chữ PowerPoint](/slides/vi/androidjava/powerpoint-fonts/).
{{% /alert %}}

## **Thay đổi kiểu nền chủ đề**

Mặc định, ứng dụng PowerPoint cung cấp 12 nền được xác định trước nhưng chỉ 3 trong số 12 nền đó được lưu trong một bản trình chiếu thông thường.

![todo:image_alt_text](presentation-design_8.png)

Ví dụ, sau khi bạn lưu một bản trình chiếu trong ứng dụng PowerPoint, bạn có thể chạy mã Java này để biết số lượng nền được xác định trước trong bản trình chiếu:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("pres.pptx");
try {
    int numberOfBackgroundFills = pres.getMasterTheme().getFormatScheme().getBackgroundFillStyles().size();

    System.out.println("Number of background fill styles for theme is " + numberOfBackgroundFills);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="warning" %}} 
Sử dụng thuộc tính [BackgroundFillStyles](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/FormatScheme#getBackgroundFillStyles--) từ lớp [FormatScheme](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/FormatScheme), bạn có thể thêm hoặc truy cập kiểu nền trong một chủ đề PowerPoint.
{{% /alert %}} 

Mã Java này cho bạn cách đặt nền cho một bản trình chiếu:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("pres.pptx");
try {
    pres.getMasters().get_Item(0).getBackground().setStyleIndex(2);
} finally {
    if (pres != null) pres.dispose();
}
```

**Hướng dẫn chỉ mục**: 0 được dùng cho không tô màu. Chỉ mục bắt đầu từ 1.

{{% alert color="info" title="TIP" %}} 
Bạn có thể muốn xem [PowerPoint Background](/slides/vi/androidjava/presentation-background/).
{{% /alert %}}

## **Thay đổi hiệu ứng chủ đề**

Một chủ đề PowerPoint thường chứa 3 giá trị cho mỗi mảng kiểu. Các mảng này được kết hợp thành 3 hiệu ứng: tinh tế, vừa phải và mạnh mẽ. Ví dụ, đây là kết quả khi các hiệu ứng được áp dụng cho một hình dạng cụ thể:

![todo:image_alt_text](presentation-design_10.png)

Sử dụng 3 thuộc tính ([FillStyles](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/FormatScheme#getFillStyles--), [LineStyles](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/FormatScheme#getLineStyles--), [EffectStyles](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/FormatScheme#getEffectStyles--)) từ lớp [FormatScheme](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/FormatScheme), bạn có thể thay đổi các yếu tố trong một chủ đề (thậm chí linh hoạt hơn so với các tùy chọn trong PowerPoint).

Mã Java này cho bạn cách thay đổi một hiệu ứng chủ đề bằng cách thay đổi một phần các yếu tố:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation pres = new Presentation("Subtle_Moderate_Intense.pptx");
try {
    pres.getMasterTheme().getFormatScheme().getLineStyles().get_Item(0).getFillFormat().getSolidFillColor().setColor(Color.RED);

    pres.getMasterTheme().getFormatScheme().getFillStyles().get_Item(2).setFillType(FillType.Solid);

    pres.getMasterTheme().getFormatScheme().getFillStyles().get_Item(2).getSolidFillColor().setColor(Color.GREEN);

    pres.getMasterTheme().getFormatScheme().getEffectStyles().get_Item(2).getEffectFormat().getOuterShadowEffect().setDistance(10f);

    pres.save("Design_04_Subtle_Moderate_Intense-out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

Các thay đổi kết quả trong màu tô, kiểu tô, hiệu ứng bóng, v.v.:

![todo:image_alt_text](presentation-design_11.png)

## **Câu hỏi thường gặp**

### Tôi có thể áp dụng một chủ đề cho một slide riêng lẻ mà không thay đổi master không?

Có. Aspose.Slides hỗ trợ ghi đè chủ đề ở mức slide, vì vậy bạn có thể áp dụng một chủ đề cục bộ chỉ cho slide đó trong khi giữ nguyên chủ đề master (thông qua [SlideThemeManager](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/slidethememanager/)).

### Cách an toàn nhất để mang một chủ đề từ một bản trình chiếu sang bản trình chiếu khác là gì?

[Sao chép slide](/slides/vi/androidjava/clone-slides/) cùng với master của chúng vào bản trình chiếu đích. Điều này bảo tồn master, bố cục và chủ đề liên quan ban đầu nên giao diện vẫn đồng nhất.

### Làm sao tôi có thể xem các giá trị "effective" sau mọi kế thừa và ghi đè?

Sử dụng các ["effective" views](/slides/vi/androidjava/shape-effective-properties/) của API cho theme/color/font/effect. Các view này trả về các thuộc tính đã được giải quyết, cuối cùng sau khi áp dụng master và bất kỳ ghi đè cục bộ nào.