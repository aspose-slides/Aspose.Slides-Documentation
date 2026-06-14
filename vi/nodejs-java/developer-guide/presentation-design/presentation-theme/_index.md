---
title: Quản lý Chủ đề Bản trình chiếu trong JavaScript
linktitle: Chủ đề Trình chiếu
type: docs
weight: 10
url: /vi/nodejs-java/presentation-theme/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Quản lý các chủ đề bản trình chiếu trong JavaScript bằng Aspose.Slides cho Node.js để tạo, tùy chỉnh và chuyển đổi các tệp PowerPoint với thương hiệu nhất quán."
---
## **Giới thiệu**

Một chủ đề trình chiếu xác định các thuộc tính của các yếu tố thiết kế. Khi bạn chọn một chủ đề trình chiếu, bạn về cơ bản đang chọn một tập hợp cụ thể các yếu tố trực quan và các thuộc tính của chúng.

Trong PowerPoint, một chủ đề bao gồm các màu sắc, [fonts](/slides/vi/nodejs-java/powerpoint-fonts/), [background styles](/slides/vi/nodejs-java/presentation-background/), và hiệu ứng.

![theme-constituents](theme-constituents.png)

## **Thay đổi màu chủ đề**

Một chủ đề PowerPoint sử dụng một tập hợp màu sắc cụ thể cho các yếu tố khác nhau trên một slide. Nếu bạn không thích các màu, bạn có thể thay đổi chúng bằng cách áp dụng màu mới cho chủ đề. Để cho phép bạn chọn màu chủ đề mới, Aspose.Slides cung cấp các giá trị trong enumeration [SchemeColor](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/SchemeColor).

Mã JavaScript này cho bạn thấy cách thay đổi màu sắc nhấn cho một chủ đề:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, 100, 100);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

Bạn có thể xác định giá trị thực tế của màu kết quả theo cách này:

```javascript
var fillEffective = shape.getFillFormat().getEffective();
var effectiveColor = fillEffective.getSolidFillColor();
console.log(java.callStaticMethodSync("java.lang.String", "format", "Color [A=%d, R=%d, G=%d, B=%d]", effectiveColor.getAlpha(), effectiveColor.getRed(), effectiveColor.getGreen(), effectiveColor.getBlue()));
```

Để minh họa thêm thao tác thay đổi màu, chúng ta tạo một yếu tố khác và gán màu nhấn (từ thao tác ban đầu) cho nó. Sau đó chúng ta thay đổi màu trong chủ đề:

```javascript
var otherShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 120, 100, 100);
otherShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
otherShape.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
pres.getMasterTheme().getColorScheme().getAccent4().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
```

Màu mới sẽ được áp dụng tự động cho cả hai yếu tố.

### **Đặt màu chủ đề từ bảng màu bổ sung**

Khi bạn áp dụng các biến đổi độ sáng cho màu chủ đề chính(1), các màu từ bảng màu bổ sung(2) sẽ được tạo ra. Sau đó bạn có thể đặt và lấy các màu chủ đề đó.

![additional-palette-colors](additional-palette-colors.png)

**1** - Màu chủ đề chính

**2** - Màu từ bảng màu bổ sung.

Mã JavaScript này minh họa một thao tác mà các màu từ bảng màu bổ sung được lấy từ màu chủ đề chính và sau đó được sử dụng trong các hình dạng:

```javascript
var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);
    // Accent 4
    var shape1 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, 50, 50);
    shape1.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape1.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
    // Accent 4, Sáng hơn 80%
    var shape2 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 70, 50, 50);
    shape2.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape2.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
    shape2.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.MultiplyLuminance, 0.2);
    shape2.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.AddLuminance, 0.8);
    // Accent 4, Sáng hơn 60%
    var shape3 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 130, 50, 50);
    shape3.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape3.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
    shape3.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.MultiplyLuminance, 0.4);
    shape3.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.AddLuminance, 0.6);
    // Accent 4, Sáng hơn 40%
    var shape4 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 190, 50, 50);
    shape4.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape4.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
    shape4.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.MultiplyLuminance, 0.6);
    shape4.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.AddLuminance, 0.4);
    // Accent 4, Đậm hơn 25%
    var shape5 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 250, 50, 50);
    shape5.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape5.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
    shape5.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.MultiplyLuminance, 0.75);
    // Accent 4, Đậm hơn 50%
    var shape6 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 310, 50, 50);
    shape6.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape6.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
    shape6.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.MultiplyLuminance, 0.5);
    presentation.save(path + "example_accent4.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

### **Ánh xạ `SchemeColor` tới các màu `ColorScheme`**

Khi bạn làm việc với [SchemeColor](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/schemecolor/), bạn có thể nhận thấy rằng nó chứa các giá trị màu chủ đề sau: `Background1`, `Background2`, `Text1`, và `Text2`.

Tuy nhiên, `Presentation.getMasterTheme().getColorScheme()` trả về [ColorScheme](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/colorscheme/), mà cung cấp các màu tương ứng là: `Dark1`, `Dark2`, `Light1`, và `Light2`.

Sự khác nhau này chỉ ở tên gọi. Các giá trị này đề cập đến cùng các vị trí màu chủ đề và ánh xạ là cố định:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Không có chuyển đổi động nào giữa `Text`/`Background` và `Dark`/`Light`. Chúng chỉ là các tên thay thế cho cùng một màu chủ đề.

Sự khác biệt về cách đặt tên này bắt nguồn từ thuật ngữ của Microsoft Office. Các phiên bản Office cũ sử dụng `Dark 1`, `Light 1`, `Dark 2`, và `Light 2`, trong khi các phiên bản giao diện người dùng mới hiển thị các vị trí tương tự dưới dạng `Text 1`, `Background 1`, `Text 2`, và `Background 2`.

## **Thay đổi phông chữ chủ đề**

Để cho phép bạn chọn phông chữ cho các chủ đề và các mục đích khác, Aspose.Slides sử dụng các định danh đặc biệt sau (tương tự như trong PowerPoint):

* **+mn-lt** - Phông chữ Body Latin (Minor Latin Font)
* **+mj-lt** - Phông chữ Heading Latin (Major Latin Font)
* **+mn-ea** - Phông chữ Body East Asian (Minor East Asian Font)
* **+mj-ea** - Phông chữ Body East Asian (Major East Asian Font)

Mã JavaScript này cho bạn thấy cách gán phông chữ Latin cho một yếu tố chủ đề:

```javascript
var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, 100, 100);
var paragraph = new aspose.slides.Paragraph();
var portion = new aspose.slides.Portion("Theme text format");
paragraph.getPortions().add(portion);
shape.getTextFrame().getParagraphs().add(paragraph);
portion.getPortionFormat().setLatinFont(new aspose.slides.FontData("+mn-lt"));
```

Mã JavaScript này cho bạn thấy cách thay đổi phông chữ chủ đề của bản trình chiếu:

```javascript
pres.getMasterTheme().getFontScheme().getMinor().setLatinFont(new aspose.slides.FontData("Arial"));
```

Phông chữ trong tất cả các hộp văn bản sẽ được cập nhật.

{{% alert color="primary" title="TIP" %}} 
Bạn có thể muốn xem [PowerPoint fonts](/slides/vi/nodejs-java/powerpoint-fonts/).
{{% /alert %}}

## **Thay đổi kiểu nền chủ đề**

Mặc định, ứng dụng PowerPoint cung cấp 12 nền được định nghĩa trước nhưng chỉ 3 trong số 12 nền đó được lưu trong một bản trình chiếu thường.

![todo:image_alt_text](presentation-design_8.png)

Ví dụ, sau khi bạn lưu một bản trình chiếu trong ứng dụng PowerPoint, bạn có thể chạy mã JavaScript này để tìm số lượng nền được định nghĩa trước trong bản trình chiếu:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var numberOfBackgroundFills = pres.getMasterTheme().getFormatScheme().getBackgroundFillStyles().size();
    console.log("Number of background fill styles for theme is " + numberOfBackgroundFills);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

{{% alert color="warning" %}} 
Sử dụng thuộc tính [BackgroundFillStyles](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/FormatScheme#getBackgroundFillStyles--) từ lớp [FormatScheme](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/FormatScheme), bạn có thể thêm hoặc truy cập kiểu nền trong một chủ đề PowerPoint.
{{% /alert %}} 

Mã JavaScript này cho bạn thấy cách đặt nền cho một bản trình chiếu:

```javascript
pres.getMasters().get_Item(0).getBackground().setStyleIndex(2);
```

**Hướng dẫn chỉ mục**: 0 được dùng cho không có nền. Chỉ mục bắt đầu từ 1.

{{% alert color="primary" title="TIP" %}} 
Bạn có thể muốn xem [PowerPoint Background](/slides/vi/nodejs-java/presentation-background/).
{{% /alert %}}

## **Thay đổi hiệu ứng chủ đề**

Một chủ đề PowerPoint thường chứa 3 giá trị cho mỗi mảng kiểu. Các mảng này được kết hợp thành 3 hiệu ứng: subtle, moderate và intense. Ví dụ, đây là kết quả khi áp dụng các hiệu ứng lên một hình dạng cụ thể:

![todo:image_alt_text](presentation-design_10.png)

Sử dụng 3 thuộc tính ([FillStyles](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/FormatScheme#getFillStyles--), [LineStyles](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/FormatScheme#getLineStyles--), [EffectStyles](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/FormatScheme#getEffectStyles--)) từ lớp [FormatScheme](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/FormatScheme) bạn có thể thay đổi các yếu tố trong một chủ đề (thậm chí linh hoạt hơn các tùy chọn trong PowerPoint).

Mã JavaScript này cho bạn thấy cách thay đổi một hiệu ứng chủ đề bằng cách thay đổi các phần của yếu tố:

```javascript
var pres = new aspose.slides.Presentation("Subtle_Moderate_Intense.pptx");
try {
    pres.getMasterTheme().getFormatScheme().getLineStyles().get_Item(0).getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    pres.getMasterTheme().getFormatScheme().getFillStyles().get_Item(2).setFillType(java.newByte(aspose.slides.FillType.Solid));
    pres.getMasterTheme().getFormatScheme().getFillStyles().get_Item(2).getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GREEN"));
    pres.getMasterTheme().getFormatScheme().getEffectStyles().get_Item(2).getEffectFormat().getOuterShadowEffect().setDistance(10.0);
    pres.save("Design_04_Subtle_Moderate_Intense-out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

Các thay đổi kết quả trong màu nền, kiểu nền, hiệu ứng bóng đổ, v.v.:

![todo:image_alt_text](presentation-design_11.png)

## **Câu hỏi thường gặp**

**Tôi có thể áp dụng một chủ đề cho một slide duy nhất mà không thay đổi master không?**

Có. Aspose.Slides hỗ trợ ghi đè chủ đề ở mức slide, vì vậy bạn có thể áp dụng một chủ đề cục bộ cho slide đó mà vẫn giữ nguyên chủ đề master (thông qua [SlideThemeManager](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/slidethememanager/)).

**Cách an toàn nhất để chuyển một chủ đề từ bản trình chiếu này sang bản trình chiếu khác là gì?**

[Clone slides](/slides/vi/nodejs-java/clone-slides/) cùng với master của chúng vào bản trình chiếu đích. Điều này giữ nguyên master, bố cục và chủ đề liên quan để giao diện vẫn nhất quán.

**Làm thế nào để xem các giá trị “effective” sau tất cả các kế thừa và ghi đè?**

Sử dụng các “view” ["effective"](/slides/vi/nodejs-java/shape-effective-properties/) của API cho theme/color/font/effect. Các view này trả về các thuộc tính đã được giải quyết, cuối cùng sau khi áp dụng master cùng bất kỳ ghi đè cục bộ nào.