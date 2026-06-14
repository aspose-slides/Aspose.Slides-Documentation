---
title: Quản lý Chủ đề Bài thuyết trình trong .NET
linktitle: Chủ đề Bài thuyết trình
type: docs
weight: 10
url: /vi/net/presentation-theme/
keywords:
- Chủ đề PowerPoint
- chủ đề bài thuyết trình
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
- bài thuyết trình
- .NET
- C#
- Aspose.Slides
description: "Quản lý chủ đề bài thuyết trình trong Aspose.Slides cho .NET để tạo, tùy chỉnh và chuyển đổi các tệp PowerPoint với thương hiệu nhất quán."
---
## **Giới thiệu**

Một chủ đề bài thuyết trình xác định các thuộc tính của các yếu tố thiết kế. Khi bạn chọn một chủ đề bài thuyết trình, về cơ bản bạn đang chọn một tập hợp các yếu tố trực quan và các thuộc tính của chúng.

Trong PowerPoint, một chủ đề bao gồm màu sắc, [phông chữ](/slides/vi/net/powerpoint-fonts/), [phong cách nền](/slides/vi/net/presentation-background/), và các hiệu ứng.

![theme-constituents](theme-constituents.png)

## **Thay đổi màu chủ đề**

Một chủ đề PowerPoint sử dụng một bộ màu cụ thể cho các yếu tố khác nhau trên một slide. Nếu bạn không thích các màu này, bạn có thể thay đổi chúng bằng cách áp dụng màu mới cho chủ đề. Để cho phép bạn chọn màu chủ đề mới, Aspose.Slides cung cấp các giá trị trong enumeration [SchemeColor](https://reference.aspose.com/slides/vi/net/aspose.slides/schemecolor/).

Mã C# này cho bạn thấy cách thay đổi màu nhấn cho một chủ đề:

```c#
using (Presentation pres = new Presentation())
    
{
    IAutoShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);

    shape.FillFormat.FillType = FillType.Solid;

    shape.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
}
```

Bạn có thể xác định giá trị thực tế của màu kết quả theo cách này:

```c#
var fillEffective = shape.FillFormat.GetEffective();

Console.WriteLine($"{fillEffective.SolidFillColor.Name} ({fillEffective.SolidFillColor})"); // ff8064a2 (Màu [A=255, R=128, G=100, B=162])
```

Để minh họa thêm thao tác thay đổi màu, chúng tôi tạo một yếu tố khác và gán màu nhấn (từ thao tác ban đầu) cho nó. Sau đó chúng tôi thay đổi màu trong chủ đề:

```c#
IAutoShape otherShape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 10, 120, 100, 100);

otherShape.FillFormat.FillType = FillType.Solid;

otherShape.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;

pres.MasterTheme.ColorScheme.Accent4.Color = Color.Red;
```

Màu mới sẽ được áp dụng tự động cho cả hai yếu tố.

### **Đặt màu chủ đề từ bảng màu bổ sung**

Khi bạn áp dụng các biến đổi độ sáng cho màu chủ đề chính(1), các màu từ bảng màu bổ sung(2) sẽ được tạo ra. Bạn có thể thiết lập và lấy các màu chủ đề này.

![additional-palette-colors](additional-palette-colors.png)

**1** - Các màu chủ đề chính  

**2** - Các màu từ bảng màu bổ sung.

Mã C# này minh họa một thao tác trong đó các màu bảng màu bổ sung được lấy từ màu chủ đề chính và sau đó được sử dụng trong các hình dạng:

```c#
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Màu phụ 4
    IShape shape1 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 50, 50);

    shape1.FillFormat.FillType = FillType.Solid;
    shape1.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;

    // Màu phụ 4, Nhẹ hơn 80%
    IShape shape2 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 70, 50, 50);

    shape2.FillFormat.FillType = FillType.Solid;
    shape2.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
    shape2.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.2f);
    shape2.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.AddLuminance, 0.8f);

    // Màu phụ 4, Nhẹ hơn 60%
    IShape shape3 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 130, 50, 50);

    shape3.FillFormat.FillType = FillType.Solid;
    shape3.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
    shape3.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.4f);
    shape3.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.AddLuminance, 0.6f);

    // Màu phụ 4, Nhẹ hơn 40%
    IShape shape4 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 190, 50, 50);

    shape4.FillFormat.FillType = FillType.Solid;
    shape4.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
    shape4.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.6f);
    shape4.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.AddLuminance, 0.4f);

    // Màu phụ 4, Tối hơn 25%
    IShape shape5 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 250, 50, 50);

    shape5.FillFormat.FillType = FillType.Solid;
    shape5.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
    shape5.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.75f);

    // Màu phụ 4, Tối hơn 50%
    IShape shape6 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 310, 50, 50);

    shape6.FillFormat.FillType = FillType.Solid;
    shape6.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
    shape6.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.5f);

    presentation.Save("example.pptx", SaveFormat.Pptx);
}
```

### **Ánh xạ `SchemeColor` sang các màu `IColorScheme`**

Khi bạn làm việc với [SchemeColor](https://reference.aspose.com/slides/vi/net/aspose.slides/schemecolor/), bạn có thể nhận thấy rằng nó chứa các giá trị màu chủ đề sau:

`Background1`, `Background2`, `Text1`, và `Text2`.

Tuy nhiên, `Presentation.MasterTheme.ColorScheme` trả về [IColorScheme](https://reference.aspose.com/slides/vi/net/aspose.slides.theme/icolorscheme/), mà cung cấp các màu tương ứng là:

`Dark1`, `Dark2`, `Light1`, và `Light2`.

Sự khác biệt này chỉ ở tên gọi. Các giá trị này đề cập đến cùng các vị trí màu chủ đề và ánh xạ là cố định:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Không có việc chuyển đổi động giữa `Text`/`Background` và `Dark`/`Light`. Chúng chỉ là các tên thay thế cho cùng một màu chủ đề.

Sự khác biệt về cách đặt tên này xuất phát từ thuật ngữ của Microsoft Office. Các phiên bản Office cũ sử dụng `Dark 1`, `Light 1`, `Dark 2`, và `Light 2`, trong khi các giao diện UI mới hơn hiển thị cùng các vị trí dưới tên `Text 1`, `Background 1`, `Text 2`, và `Background 2`.

## **Thay đổi phông chữ chủ đề**

Để cho phép bạn chọn phông chữ cho các chủ đề và các mục đích khác, Aspose.Slides sử dụng các định danh đặc biệt sau (tương tự như trong PowerPoint):

* **+mn-lt** - Phông chữ thân văn bản Latin (Minor Latin Font)
* **+mj-lt** - Phông chữ tiêu đề Latin (Major Latin Font)
* **+mn-ea** - Phông chữ thân văn bản Đông Á (Minor East Asian Font)
* **+mj-ea** - Phông chữ tiêu đề Đông Á (Major East Asian Font)

Mã C# này cho bạn thấy cách gán phông Latin cho một yếu tố chủ đề:

```c#
IAutoShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);

Paragraph paragraph = new Paragraph();

Portion portion = new Portion("Theme text format");

paragraph.Portions.Add(portion);

shape.TextFrame.Paragraphs.Add(paragraph);

portion.PortionFormat.LatinFont = new FontData("+mn-lt");
```

Mã C# này cho bạn thấy cách thay đổi phông chữ chủ đề của bài thuyết trình:

```c#
pres.MasterTheme.FontScheme.Minor.LatinFont = new FontData("Arial");
```

Phông chữ trong tất cả các hộp văn bản sẽ được cập nhật.

{{% alert color="primary" title="TIP" %}} 
Bạn có thể muốn xem [phông PowerPoint](/slides/vi/net/powerpoint-fonts/). 
{{% /alert %}}

## **Thay đổi phong cách nền chủ đề**

Mặc định, ứng dụng PowerPoint cung cấp 12 nền được định trước nhưng chỉ 3 trong số 12 nền đó được lưu trong một bài thuyết trình điển hình.

![todo:image_alt_text](presentation-design_8.png)

Ví dụ, sau khi bạn lưu một bài thuyết trình trong ứng dụng PowerPoint, bạn có thể chạy mã C# này để biết số lượng nền được định trước trong bài thuyết trình:

```c#
using (Presentation pres = new Presentation("pres.pptx"))

{
    int numberOfBackgroundFills = pres.MasterTheme.FormatScheme.BackgroundFillStyles.Count;

    Console.WriteLine($"Number of background fill styles for theme is {numberOfBackgroundFills}");
}
```

{{% alert color="warning" %}} 
Sử dụng thuộc tính [BackgroundFillStyles](https://reference.aspose.com/slides/vi/net/aspose.slides.theme/formatscheme/backgroundfillstyles/) từ lớp [FormatScheme](https://reference.aspose.com/slides/vi/net/aspose.slides.theme/formatscheme/), bạn có thể thêm hoặc truy cập phong cách nền trong một chủ đề PowerPoint. 
{{% /alert %}}

Mã C# này cho bạn thấy cách đặt nền cho một bài thuyết trình:

```c#
pres.Masters[0].Background.StyleIndex = 2;
```

**Hướng dẫn chỉ mục**: 0 được dùng cho không có nền. Chỉ mục bắt đầu từ 1.

{{% alert color="primary" title="TIP" %}} 
Bạn có thể muốn xem [Nền PowerPoint](/slides/vi/net/presentation-background/). 
{{% /alert %}}

## **Thay đổi hiệu ứng chủ đề**

Một chủ đề PowerPoint thường chứa 3 giá trị cho mỗi mảng kiểu. Các mảng này được kết hợp thành 3 hiệu ứng: nhẹ, trung bình và mạnh. Ví dụ, đây là kết quả khi các hiệu ứng được áp dụng cho một hình dạng cụ thể:

![todo:image_alt_text](presentation-design_10.png)

Sử dụng 3 thuộc tính ([FillStyles](https://reference.aspose.com/slides/vi/net/aspose.slides.theme/formatscheme/fillstyles), [LineStyles](https://reference.aspose.com/slides/vi/net/aspose.slides.theme/formatscheme/linestyles), [EffectStyles](https://reference.aspose.com/slides/vi/net/aspose.slides.theme/formatscheme/effectstyles)) từ lớp [FormatScheme](https://reference.aspose.com/slides/vi/net/aspose.slides.theme/formatscheme) bạn có thể thay đổi các yếu tố trong một chủ đề (thậm chí linh hoạt hơn so với các tùy chọn trong PowerPoint).

Mã C# này cho bạn thấy cách thay đổi một hiệu ứng chủ đề bằng cách sửa đổi các phần của các yếu tố:

```c#
using (Presentation pres = new Presentation("Subtle_Moderate_Intense.pptx"))
{
    pres.MasterTheme.FormatScheme.LineStyles[0].FillFormat.SolidFillColor.Color = Color.Red;

    pres.MasterTheme.FormatScheme.FillStyles[2].FillType = FillType.Solid;

    pres.MasterTheme.FormatScheme.FillStyles[2].SolidFillColor.Color = Color.ForestGreen;

    pres.MasterTheme.FormatScheme.EffectStyles[2].EffectFormat.OuterShadowEffect.Distance = 10f;

    pres.Save("Design_04_Subtle_Moderate_Intense-out.pptx", SaveFormat.Pptx);
}
```

Các thay đổi kết quả trong màu nền, kiểu nền, hiệu ứng đổ bóng, v.v.:

![todo:image_alt_text](presentation-design_11.png)

## **Câu hỏi thường gặp**

**Có thể áp dụng một chủ đề cho một slide riêng lẻ mà không thay đổi master không?**

Có. Aspose.Slides hỗ trợ ghi đè chủ đề ở mức slide, vì vậy bạn có thể áp dụng một chủ đề cục bộ cho chỉ slide đó trong khi giữ nguyên master theme (thông qua [SlideThemeManager](https://reference.aspose.com/slides/vi/net/aspose.slides.theme/slidethememanager/)).

**Cách an toàn nhất để chuyển một chủ đề từ một bài thuyết trình này sang bài thuyết trình khác là gì?**

[Clone slides](/slides/vi/net/clone-slides/) cùng với master của chúng vào bài thuyết trình đích. Điều này bảo tồn master gốc, các bố cục và chủ đề liên quan nên giao diện vẫn đồng nhất.

**Làm sao tôi có thể xem các giá trị "hiệu lực" sau mọi kế thừa và ghi đè?**

Sử dụng các “view” ["effective"](/slides/vi/net/shape-effective-properties/) của API cho theme/color/font/effect. Các view này trả về các thuộc tính đã được giải quyết, cuối cùng sau khi áp dụng master và bất kỳ ghi đè cục bộ nào.