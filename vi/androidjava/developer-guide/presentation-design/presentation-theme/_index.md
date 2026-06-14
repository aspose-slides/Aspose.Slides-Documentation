---
title: Quản lý giao diện bản trình chiếu trên Android
linktitle: Giao diện bản trình chiếu
type: docs
weight: 10
url: /vi/androidjava/presentation-theme/
keywords:
- Giao diện PowerPoint
- giao diện bản trình chiếu
- giao diện slide
- thiết lập giao diện
- thay đổi giao diện
- quản lý giao diện
- màu giao diện
- bảng màu bổ sung
- phông chữ giao diện
- kiểu giao diện
- hiệu ứng giao diện
- PowerPoint
- OpenDocument
- bản trình chiếu
- Android
- Java
- Aspose.Slides
description: "Quản lý các giao diện bản trình chiếu trong Aspose.Slides cho Android bằng Java để tạo, tùy chỉnh và chuyển đổi tệp PowerPoint với thương hiệu nhất quán."
---
## **Giới thiệu**

Một giao diện bản trình chiếu xác định các thuộc tính của các yếu tố thiết kế. Khi bạn chọn một giao diện, bạn về cơ bản đang chọn một tập hợp cụ thể các yếu tố trực quan và các thuộc tính của chúng.

Trong PowerPoint, một giao diện bao gồm màu sắc, [phông chữ](/slides/vi/androidjava/powerpoint-fonts/), [kiểu nền](/slides/vi/androidjava/presentation-background/), và hiệu ứng.

![các thành phần của giao diện](theme-constituents.png)

## **Thay đổi màu giao diện**

Một giao diện PowerPoint sử dụng một tập hợp màu cụ thể cho các yếu tố khác nhau trên một slide. Nếu bạn không thích các màu này, bạn có thể thay đổi chúng bằng cách áp dụng màu mới cho giao diện. Để cho phép bạn chọn màu giao diện mới, Aspose.Slides cung cấp các giá trị trong enumeration [SchemeColor](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/SchemeColor).

Đoạn mã Java sau cho thấy cách thay đổi màu nhấn cho một giao diện:

```java
Presentation pres = new Presentation();
try {
    IAutoShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);

    shape.getFillFormat().setFillType(FillType.Solid);

    shape.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
} finally {
    if (pres != null) pres.dispose();
}
```

Bạn có thể xác định giá trị thực sự của màu kết quả bằng cách này:

```java
IFillFormatEffectiveData fillEffective = shape.getFillFormat().getEffective();

Color effectiveColor = fillEffective.getSolidFillColor();

System.out.println(String.format("Color [A=%d, R=%d, G=%d, B=%d]", 
        effectiveColor.getAlpha(), effectiveColor.getRed(), effectiveColor.getGreen(), effectiveColor.getBlue()));
```

Để minh họa thêm thao tác thay đổi màu, chúng tôi tạo một yếu tố khác và gán màu nhấn (từ thao tác ban đầu) cho nó. Sau đó chúng tôi thay đổi màu trong giao diện:

```java
IAutoShape otherShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 10, 120, 100, 100);

otherShape.getFillFormat().setFillType(FillType.Solid);

otherShape.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);

pres.getMasterTheme().getColorScheme().getAccent4().setColor(Color.RED);
```

Màu mới được áp dụng tự động cho cả hai yếu tố.

### **Đặt màu giao diện từ bảng màu bổ sung**

Khi bạn áp dụng các biến đổi độ sáng cho màu giao diện chính(1), các màu từ bảng màu bổ sung(2) sẽ được tạo ra. Bạn có thể đặt và lấy các màu giao diện đó.

![các màu trong bảng màu bổ sung](additional-palette-colors.png)

**1** - Màu giao diện chính

**2** - Màu từ bảng màu bổ sung.

Đoạn mã Java này minh họa một thao tác trong đó các màu bảng màu bổ sung được lấy từ màu giao diện chính và sau đó được sử dụng trong các hình dạng:

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Accent 4
    IShape shape1 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 50, 50);

    shape1.getFillFormat().setFillType(FillType.Solid);
    shape1.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);

    // Accent 4, Nhẹ hơn 80%
    IShape shape2 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 70, 50, 50);

    shape2.getFillFormat().setFillType(FillType.Solid);
    shape2.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape2.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.2f);
    shape2.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.AddLuminance, 0.8f);

    // Accent 4, Nhẹ hơn 60%
    IShape shape3 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 130, 50, 50);

    shape3.getFillFormat().setFillType(FillType.Solid);
    shape3.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape3.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.4f);
    shape3.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.AddLuminance, 0.6f);

    // Accent 4, Nhẹ hơn 40%
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

    presentation.save(path + "example_accent4.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

### **Ánh xạ `SchemeColor` tới các màu `IColorScheme`**

Khi bạn làm việc với [SchemeColor](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/schemecolor/), bạn có thể nhận thấy nó chứa các giá trị màu giao diện sau:

`Background1`, `Background2`, `Text1`, và `Text2`.

Tuy nhiên, `Presentation.getMasterTheme().getColorScheme()` trả về [IColorScheme](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/icolorscheme/), cung cấp các màu tương ứng dưới dạng:

`Dark1`, `Dark2`, `Light1`, và `Light2`.

Sự khác biệt này chỉ ở tên gọi. Các giá trị này đề cập đến cùng các vị trí màu giao diện và ánh xạ luôn cố định:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Không có việc chuyển đổi động giữa `Text`/`Background` và `Dark`/`Light`. Chúng chỉ là các tên thay thế cho cùng các màu giao diện.

Sự khác biệt về tên gọi này xuất phát từ thuật ngữ của Microsoft Office. Các phiên bản Office cũ sử dụng `Dark 1`, `Light 1`, `Dark 2`, và `Light 2`, trong khi các phiên bản UI mới hiển thị cùng các vị trí dưới dạng `Text 1`, `Background 1`, `Text 2`, và `Background 2`.

## **Thay đổi phông chữ giao diện**

Để cho phép bạn chọn phông chữ cho giao diện và các mục đích khác, Aspose.Slides sử dụng các định danh đặc biệt này (giống như trong PowerPoint):

* **+mn-lt** - Phông chữ thân Latin (Phông chữ Latin phụ)
* **+mj-lt** - Phông chữ tiêu đề Latin (Phông chữ Latin chính)
* **+mn-ea** - Phông chữ thân Đông Á (Phông chữ Đông Á phụ)
* **+mj-ea** - Phông chữ tiêu đề Đông Á (Phông chữ Đông Á chính)

Đoạn mã Java này cho thấy cách gán phông chữ Latin cho một yếu tố giao diện:

```java
IAutoShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);

Paragraph paragraph = new Paragraph();

Portion portion = new Portion("Theme text format");

paragraph.getPortions().add(portion);

shape.getTextFrame().getParagraphs().add(paragraph);

portion.getPortionFormat().setLatinFont(new FontData("+mn-lt"));
```

Đoạn mã Java này cho thấy cách thay đổi phông chữ giao diện của bản trình chiếu:

```java
pres.getMasterTheme().getFontScheme().getMinor().setLatinFont(new FontData("Arial"));
```

Phông chữ trong tất cả các hộp văn bản sẽ được cập nhật.

{{% alert color="primary" title="TIP" %}} 
Bạn có thể muốn xem [phông chữ PowerPoint](/slides/vi/androidjava/powerpoint-fonts/). 
{{% /alert %}}

## **Thay đổi kiểu nền giao diện**

Mặc định, ứng dụng PowerPoint cung cấp 12 nền được định sẵn nhưng chỉ có 3 trong số 12 nền đó được lưu trong một bản trình chiếu thông thường. 

![todo:image_alt_text](presentation-design_8.png)

Ví dụ, sau khi bạn lưu một bản trình chiếu trong ứng dụng PowerPoint, bạn có thể chạy đoạn mã Java này để tìm số lượng nền được định sẵn trong bản trình chiếu:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    int numberOfBackgroundFills = pres.getMasterTheme().getFormatScheme().getBackgroundFillStyles().size();

    System.out.println("Number of background fill styles for theme is " + numberOfBackgroundFills);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="warning" %}} 
Sử dụng thuộc tính [BackgroundFillStyles](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/FormatScheme#getBackgroundFillStyles--) từ lớp [FormatScheme](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/FormatScheme), bạn có thể thêm hoặc truy cập kiểu nền trong một giao diện PowerPoint. 
{{% /alert %}} 

Đoạn mã Java này cho thấy cách đặt nền cho một bản trình chiếu:

```java
pres.getMasters().get_Item(0).getBackground().setStyleIndex(2);
```

**Hướng dẫn chỉ mục**: 0 được dùng cho không tô. Chỉ mục bắt đầu từ 1.

{{% alert color="primary" title="TIP" %}} 
Bạn có thể muốn xem [nền PowerPoint](/slides/vi/androidjava/presentation-background/). 
{{% /alert %}}

## **Thay đổi hiệu ứng giao diện**

Một giao diện PowerPoint thường chứa 3 giá trị cho mỗi mảng kiểu. Các mảng này được kết hợp thành 3 hiệu ứng: nhẹ (subtle), trung bình (moderate), và mạnh (intense). Ví dụ, đây là kết quả khi các hiệu ứng được áp dụng cho một hình dạng cụ thể:

![todo:image_alt_text](presentation-design_10.png)

Sử dụng 3 thuộc tính ([FillStyles](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/FormatScheme#getFillStyles--), [LineStyles](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/FormatScheme#getLineStyles--), [EffectStyles](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/FormatScheme#getEffectStyles--)) từ lớp [FormatScheme](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/FormatScheme) bạn có thể thay đổi các yếu tố trong một giao diện (cực kỳ linh hoạt hơn các tùy chọn trong PowerPoint).

Đoạn mã Java này cho thấy cách thay đổi một hiệu ứng giao diện bằng cách sửa đổi các phần của các yếu tố:

```java
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

Các thay đổi kết quả trong màu tô, loại tô, hiệu ứng đổ bóng, v.v.:

![todo:image_alt_text](presentation-design_11.png)

## **Câu hỏi thường gặp**

**Tôi có thể áp dụng một giao diện cho một slide riêng lẻ mà không thay đổi master không?**

Có. Aspose.Slides hỗ trợ ghi đè giao diện ở mức slide, vì vậy bạn có thể áp dụng một giao diện cục bộ cho slide đó mà vẫn giữ nguyên giao diện master (thông qua [SlideThemeManager](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/slidethememanager/)).

**Cách an toàn nhất để mang một giao diện từ bản trình chiếu này sang bản khác là gì?**

[Sao chép slide](/slides/vi/androidjava/clone-slides/) cùng với master của chúng vào bản trình chiếu đích. Điều này giữ nguyên master, bố cục và giao diện liên quan nên giao diện vẫn nhất quán.

**Làm sao tôi có thể xem các giá trị “hiệu lực” sau mọi kế thừa và ghi đè?**

Sử dụng các “khung nhìn hiệu lực” của API [/slides/vi/androidjava/shape-effective-properties/] cho giao diện/màu/phông chữ/hiệu ứng. Các khung nhìn này trả về các thuộc tính đã được giải quyết cuối cùng sau khi áp dụng master và bất kỳ ghi đè cục bộ nào.