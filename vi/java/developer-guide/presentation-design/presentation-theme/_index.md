---
title: Quản lý Chủ đề Bản trình chiếu trong Java
linktitle: Chủ đề Trình chiếu
type: docs
weight: 10
url: /vi/java/presentation-theme/
keywords:
- chủ đề PowerPoint
- chủ đề trình chiếu
- chủ đề slide
- đặt chủ đề
- thay đổi chủ đề
- quản lý chủ đề
- màu chủ đề
- bảng màu bổ sung
- phông chữ chủ đề
- kiểu chủ đề
- hiệu ứng chủ đề
- PowerPoint
- OpenDocument
- bản trình chiếu
- Java
- Aspose.Slides
description: "Quản lý các chủ đề bản trình chiếu trong Aspose.Slides cho Java để tạo, tùy chỉnh và chuyển đổi các tệp PowerPoint với thương hiệu nhất quán."
---
## **Giới thiệu**

Một chủ đề trình chiếu xác định các thuộc tính của các yếu tố thiết kế. Khi bạn chọn một chủ đề trình chiếu, bạn thực chất đang chọn một tập hợp cụ thể các yếu tố hình ảnh và các thuộc tính của chúng.

Trong PowerPoint, một chủ đề bao gồm màu sắc, [phông chữ](/slides/vi/java/powerpoint-fonts/), [kiểu nền](/slides/vi/java/presentation-background/), và hiệu ứng.

![theme-constituents](theme-constituents.png)

## **Thay đổi màu chủ đề**

Một chủ đề PowerPoint sử dụng một tập hợp màu sắc cụ thể cho các yếu tố khác nhau trên một slide. Nếu bạn không thích các màu này, bạn có thể thay đổi chúng bằng cách áp dụng màu mới cho chủ đề. Để cho phép bạn chọn một màu chủ đề mới, Aspose.Slides cung cấp các giá trị trong enumeration [SchemeColor](https://reference.aspose.com/slides/vi/java/com.aspose.slides/SchemeColor).

Mã Java này cho bạn thấy cách thay đổi màu nhấn cho một chủ đề:

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

Bạn có thể xác định giá trị hiệu quả của màu kết quả theo cách này:

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
    IAutoShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);

    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);

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

Khi bạn áp dụng các chuyển đổi độ sáng cho màu chủ đề chính (1), các màu từ bảng màu bổ sung (2) được tạo ra. Bạn có thể sau đó đặt và lấy các màu chủ đề đó. 

![additional-palette-colors](additional-palette-colors.png)

**1** - Màu chủ đề chính

**2** - Màu từ bảng màu bổ sung.

Mã Java này minh họa một thao tác trong đó các màu từ bảng màu bổ sung được lấy từ màu chủ đề chính và sau đó được sử dụng trong các hình dạng:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Màu nhấn 4
    IShape shape1 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 50, 50);

    shape1.getFillFormat().setFillType(FillType.Solid);
    shape1.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);

    // Màu nhấn 4, Sáng hơn 80%
    IShape shape2 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 70, 50, 50);

    shape2.getFillFormat().setFillType(FillType.Solid);
    shape2.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape2.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.2f);
    shape2.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.AddLuminance, 0.8f);

    // Màu nhấn 4, Sáng hơn 60%
    IShape shape3 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 130, 50, 50);

    shape3.getFillFormat().setFillType(FillType.Solid);
    shape3.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape3.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.4f);
    shape3.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.AddLuminance, 0.6f);

    // Màu nhấn 4, Sáng hơn 40%
    IShape shape4 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 190, 50, 50);

    shape4.getFillFormat().setFillType(FillType.Solid);
    shape4.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape4.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.6f);
    shape4.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.AddLuminance, 0.4f);

    // Màu nhấn 4, Đậm hơn 25%
    IShape shape5 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 250, 50, 50);

    shape5.getFillFormat().setFillType(FillType.Solid);
    shape5.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape5.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.75f);

    // Màu nhấn 4, Đậm hơn 50%
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

Khi bạn làm việc với [SchemeColor](https://reference.aspose.com/slides/vi/java/com.aspose.slides/schemecolor/), bạn có thể nhận thấy nó chứa các giá trị màu chủ đề sau:

`Background1`, `Background2`, `Text1`, và `Text2`.

Tuy nhiên, `Presentation.getMasterTheme().getColorScheme()` trả về [IColorScheme](https://reference.aspose.com/slides/vi/java/com.aspose.slides/icolorscheme/), cung cấp các màu tương ứng là:

`Dark1`, `Dark2`, `Light1`, và `Light2`.

Sự khác biệt này chỉ về cách đặt tên. Các giá trị này đề cập đến cùng các vị trí màu chủ đề và ánh xạ được cố định:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Không có sự chuyển đổi động giữa `Text`/`Background` và `Dark`/`Light`. Chúng chỉ là các tên thay thế cho cùng các màu chủ đề.

Sự khác biệt này về cách đặt tên xuất phát từ thuật ngữ của Microsoft Office. Các phiên bản Office cũ sử dụng `Dark 1`, `Light 1`, `Dark 2`, và `Light 2`, trong khi các phiên bản giao diện mới hiển thị cùng các vị trí này dưới dạng `Text 1`, `Background 1`, `Text 2`, và `Background 2`.

## **Thay đổi phông chữ chủ đề**

Để cho phép bạn chọn phông chữ cho các chủ đề và các mục đích khác, Aspose.Slides sử dụng các định danh đặc biệt này (tương tự như những gì được sử dụng trong PowerPoint):

* **+mn-lt** - Phông chữ thân Latin (Phông chữ Latin phụ)
* **+mj-lt** - Phông chữ tiêu đề Latin (Phông chữ Latin chính)
* **+mn-ea** - Phông chữ thân Đông Á (Phông chữ Đông Á phụ)
* **+mj-ea** - Phông chữ tiêu đề Đông Á (Phông chữ Đông Á chính)

Mã Java này cho bạn thấy cách gán phông chữ Latin cho một yếu tố của chủ đề:

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

Mã Java này cho bạn thấy cách thay đổi phông chữ chủ đề trình chiếu:

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
Bạn có thể muốn xem [phông chữ PowerPoint](/slides/vi/java/powerpoint-fonts/).
{{% /alert %}}

## **Thay đổi kiểu nền chủ đề**

Mặc định, ứng dụng PowerPoint cung cấp 12 nền được định trước nhưng chỉ 3 trong số 12 nền đó được lưu trong một bản trình chiếu thông thường. 

![todo:image_alt_text](presentation-design_8.png)

Ví dụ, sau khi bạn lưu một bản trình chiếu trong ứng dụng PowerPoint, bạn có thể chạy mã Java này để biết số lượng nền định trước trong bản trình chiếu:

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
Sử dụng thuộc tính [BackgroundFillStyles](https://reference.aspose.com/slides/vi/java/com.aspose.slides/FormatScheme#getBackgroundFillStyles--) từ lớp [FormatScheme](https://reference.aspose.com/slides/vi/java/com.aspose.slides/FormatScheme), bạn có thể thêm hoặc truy cập kiểu nền trong một chủ đề PowerPoint. 
{{% /alert %}} 

Mã Java này cho bạn thấy cách đặt nền cho một bản trình chiếu:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("pres.pptx");
try {
    pres.getMasters().get_Item(0).getBackground().setStyleIndex(2);
} finally {
    if (pres != null) pres.dispose();
}
```

**Hướng dẫn chỉ mục**: 0 được sử dụng cho không tô. Chỉ mục bắt đầu từ 1.

{{% alert color="info" title="TIP" %}} 
Bạn có thể muốn xem [Nền PowerPoint](/slides/vi/java/presentation-background/).
{{% /alert %}}

## **Thay đổi hiệu ứng chủ đề**

Một chủ đề PowerPoint thường chứa 3 giá trị cho mỗi mảng kiểu. Các mảng này được kết hợp thành 3 hiệu ứng: nhẹ, vừa, và mạnh. Ví dụ, đây là kết quả khi các hiệu ứng được áp dụng cho một hình dạng cụ thể:

![todo:image_alt_text](presentation-design_10.png)

Sử dụng 3 thuộc tính ([FillStyles](https://reference.aspose.com/slides/vi/java/com.aspose.slides/FormatScheme#getFillStyles--), [LineStyles](https://reference.aspose.com/slides/vi/java/com.aspose.slides/FormatScheme#getLineStyles--), [EffectStyles](https://reference.aspose.com/slides/vi/java/com.aspose.slides/FormatScheme#getEffectStyles--)) từ lớp [FormatScheme](https://reference.aspose.com/slides/vi/java/com.aspose.slides/FormatScheme) bạn có thể thay đổi các yếu tố trong một chủ đề (thậm chí linh hoạt hơn các tùy chọn trong PowerPoint).

Mã Java này cho bạn thấy cách thay đổi một hiệu ứng chủ đề bằng cách thay đổi các phần của yếu tố:

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

Các thay đổi kết quả trong màu nền, kiểu nền, hiệu ứng đổ bóng, v.v:

![todo:image_alt_text](presentation-design_11.png)

## **Câu hỏi thường gặp**

### Tôi có thể áp dụng một chủ đề cho một slide duy nhất mà không thay đổi master không?

Có. Aspose.Slides hỗ trợ ghi đè chủ đề ở mức slide, vì vậy bạn có thể áp dụng một chủ đề cục bộ cho slide đó mà vẫn giữ nguyên chủ đề master (thông qua [SlideThemeManager](https://reference.aspose.com/slides/vi/java/com.aspose.slides/slidethememanager/)).

### Cách an toàn nhất để chuyển một chủ đề từ bản trình chiếu này sang bản khác là gì?

[Clone slides](/slides/vi/java/clone-slides/) cùng với master của chúng vào bản trình chiếu đích. Điều này giữ nguyên master, bố cục và chủ đề liên quan để giao diện vẫn nhất quán.

### Làm sao tôi có thể xem các giá trị "hiệu quả" sau tất cả kế thừa và ghi đè?

Sử dụng "các chế độ xem hiệu quả" của API [/slides/vi/java/shape-effective-properties/] cho theme/color/font/effect. Những chế độ này trả về các thuộc tính đã được giải quyết, cuối cùng sau khi áp dụng master cộng với bất kỳ ghi đè cục bộ nào.