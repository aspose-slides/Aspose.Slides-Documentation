---
title: Quản lý chủ đề trình chiếu trong C++
linktitle: Chủ đề trình chiếu
type: docs
weight: 10
url: /vi/cpp/presentation-theme/
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
- trình chiếu
- C++
- Aspose.Slides
description: "Quản lý chủ đề trình chiếu trong Aspose.Slides cho C++ để tạo, tùy chỉnh và chuyển đổi tệp PowerPoint với thương hiệu nhất quán."
---
## **Giới thiệu**

Một chủ đề trình chiếu xác định các thuộc tính của các yếu tố thiết kế. Khi bạn chọn một chủ đề trình chiếu, bạn về cơ bản đang chọn một tập hợp cụ thể các yếu tố trực quan và các thuộc tính của chúng.

Trong PowerPoint, một chủ đề bao gồm màu sắc, [phông chữ](/slides/vi/cpp/powerpoint-fonts/), [kiểu nền](/slides/vi/cpp/presentation-background/), và hiệu ứng.

![theme-constituents](theme-constituents.png)

## **Thay đổi màu chủ đề**

Một chủ đề PowerPoint sử dụng một tập hợp màu cụ thể cho các yếu tố khác nhau trên một slide. Nếu bạn không thích các màu, bạn có thể thay đổi chúng bằng cách áp dụng màu mới cho chủ đề. Để cho phép bạn chọn màu chủ đề mới, Aspose.Slides cung cấp các giá trị dưới dạng liệt kê [SchemeColor](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.i_color_format#aad82c1d2daf9d92e4d44a5a9b3bbcf28).

Đoạn mã C++ này cho bạn thấy cách thay đổi màu nhấn cho một chủ đề:

```c++
auto pres = System::MakeObject<Presentation>();

auto shape = pres->get_Slides()->idx_get(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f);

shape->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_FillFormat()->get_SolidFillColor()->set_SchemeColor(SchemeColor::Accent4);
```

Bạn có thể xác định giá trị thực tế của màu kết quả bằng cách này:

```c++
auto fillEffective = shape->get_FillFormat()->GetEffective();
    
Console::WriteLine(u"{0} ({1})", fillEffective->get_SolidFillColor().get_Name(), fillEffective->get_SolidFillColor());
// ff8064a2 (Màu [A=255, R=128, G=100, B=162])
```

Để minh họa thêm thao tác thay đổi màu, chúng tôi tạo một yếu tố khác và gán màu nhấn (từ thao tác ban đầu) cho nó. Sau đó chúng tôi thay đổi màu trong chủ đề:

```c++
auto otherShape = pres->get_Slides()->idx_get(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10.0f, 120.0f, 100.0f, 100.0f);
    
otherShape->get_FillFormat()->set_FillType(FillType::Solid);
otherShape->get_FillFormat()->get_SolidFillColor()->set_SchemeColor(SchemeColor::Accent4);

pres->get_MasterTheme()->get_ColorScheme()->get_Accent4()->set_Color(Color::get_Red());
```

Màu mới sẽ tự động áp dụng cho cả hai yếu tố.

### **Đặt màu chủ đề từ Bảng màu bổ sung**

Khi bạn áp dụng các biến đổi độ sáng cho màu chủ đề chính(1), các màu từ bảng màu bổ sung(2) sẽ được tạo ra. Bạn có thể đặt và lấy các màu chủ đề này.

![additional-palette-colors](additional-palette-colors.png)

**1**- Màu chủ đề chính

**2** - Màu từ bảng màu bổ sung.

Đoạn mã C++ này minh họa một thao tác mà các màu bảng màu bổ sung được lấy từ màu chủ đề chính và sau đó được sử dụng trong các hình dạng:

```c++
auto presentation = System::MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);
auto shapes = slide->get_Shapes();

// Accent 4
auto shape1 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 10.0f, 50.0f, 50.0f);
auto fillFormat1 = shape1->get_FillFormat();

fillFormat1->set_FillType(FillType::Solid);
fillFormat1->get_SolidFillColor()->set_SchemeColor(SchemeColor::Accent4);

// Accent 4, Nhẹ hơn 80%
auto shape2 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 70.0f, 50.0f, 50.0f);
auto fillFormat2 = shape2->get_FillFormat();
auto solidFillColor2 = fillFormat2->get_SolidFillColor();

fillFormat2->set_FillType(FillType::Solid);
solidFillColor2->set_SchemeColor(SchemeColor::Accent4);
solidFillColor2->get_ColorTransform()->Add(ColorTransformOperation::MultiplyLuminance, 0.2f);
solidFillColor2->get_ColorTransform()->Add(ColorTransformOperation::AddLuminance, 0.8f);

// Accent 4, Nhẹ hơn 60%
auto shape3 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 130.0f, 50.0f, 50.0f);
auto fillFormat3 = shape3->get_FillFormat();
auto solidFillColor3 = fillFormat3->get_SolidFillColor();

fillFormat3->set_FillType(FillType::Solid);
solidFillColor3->set_SchemeColor(SchemeColor::Accent4);
solidFillColor3->get_ColorTransform()->Add(ColorTransformOperation::MultiplyLuminance, 0.4f);
solidFillColor3->get_ColorTransform()->Add(ColorTransformOperation::AddLuminance, 0.6f);

// Accent 4, Nhẹ hơn 40%
auto shape4 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 190.0f, 50.0f, 50.0f);
auto fillFormat4 = shape4->get_FillFormat();
auto solidFillColor4 = fillFormat4->get_SolidFillColor();

fillFormat4->set_FillType(FillType::Solid);
solidFillColor4->set_SchemeColor(SchemeColor::Accent4);
solidFillColor4->get_ColorTransform()->Add(ColorTransformOperation::MultiplyLuminance, 0.6f);
solidFillColor4->get_ColorTransform()->Add(ColorTransformOperation::AddLuminance, 0.4f);

// Accent 4, Đậm hơn 25%
auto shape5 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 250.0f, 50.0f, 50.0f);
auto fillFormat5 = shape5->get_FillFormat();
auto solidFillColor5 = fillFormat5->get_SolidFillColor();

fillFormat5->set_FillType(FillType::Solid);
solidFillColor5->set_SchemeColor(SchemeColor::Accent4);
solidFillColor5->get_ColorTransform()->Add(ColorTransformOperation::MultiplyLuminance, 0.75f);

// Accent 4, Đậm hơn 50%
auto shape6 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 310.0f, 50.0f, 50.0f);
auto fillFormat6 = shape6->get_FillFormat();
auto solidFillColor6 = fillFormat6->get_SolidFillColor();

fillFormat6->set_FillType(FillType::Solid);
solidFillColor6->set_SchemeColor(SchemeColor::Accent4);
solidFillColor6->get_ColorTransform()->Add(ColorTransformOperation::MultiplyLuminance, 0.5f);

presentation->Save(u"example.pptx", Export::SaveFormat::Pptx);
```

### **Ánh xạ `SchemeColor` tới các màu `IColorScheme`**

Khi làm việc với [SchemeColor](https://reference.aspose.com/slides/vi/cpp/aspose.slides/schemecolor/), bạn có thể nhận thấy nó chứa các giá trị màu chủ đề sau:

`Background1`, `Background2`, `Text1`, và `Text2`.

Tuy nhiên, `Presentation::get_MasterTheme()::get_ColorScheme()` trả về [IColorScheme](https://reference.aspose.com/slides/vi/cpp/aspose.slides.theme/icolorscheme/), cung cấp các màu tương ứng dưới dạng:

`Dark1`, `Dark2`, `Light1`, và `Light2`.

Sự khác biệt này chỉ ở tên gọi. Các giá trị này tham chiếu tới cùng các vị trí màu chủ đề và việc ánh xạ là cố định:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Không có chuyển đổi động nào giữa `Text`/`Background` và `Dark`/`Light`. Chúng chỉ là các tên thay thế cho cùng màu chủ đề.

Sự khác biệt về tên này bắt nguồn từ thuật ngữ của Microsoft Office. Các phiên bản Office cũ sử dụng `Dark 1`, `Light 1`, `Dark 2`, và `Light 2`, trong khi các phiên bản UI mới hiển thị cùng các vị trí dưới dạng `Text 1`, `Background 1`, `Text 2`, và `Background 2`.

## **Thay đổi phông chữ chủ đề**

Để cho phép bạn chọn phông chữ cho các chủ đề và các mục đích khác, Aspose.Slides sử dụng các định danh đặc biệt này (giống như trong PowerPoint):

* **+mn-lt** - Body Font Latin (Minor Latin Font)
* **+mj-lt** - Heading Font Latin (Major Latin Font)
* **+mn-ea** - Body Font East Asian (Minor East Asian Font)
* **+mj-ea** - Body Font East Asian (Major East Asian Font)

Đoạn mã C++ này cho bạn thấy cách gán phông Latin cho một yếu tố trong chủ đề:

```c++
auto shape = pres->get_Slides()->idx_get(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f);

auto paragraph = System::MakeObject<Paragraph>();
auto portion = System::MakeObject<Portion>(u"Theme text format");

paragraph->get_Portions()->Add(portion);
shape->get_TextFrame()->get_Paragraphs()->Add(paragraph);

portion->get_PortionFormat()->set_LatinFont(System::MakeObject<FontData>(u"+mn-lt"));
```

Đoạn mã C++ này cho bạn thấy cách thay đổi phông chữ chủ đề của bản trình chiếu:

```c++
pres->get_MasterTheme()->get_FontScheme()->get_Minor()->set_LatinFont(MakeObject<FontData>(u"Arial"));
```

Phông chữ trong tất cả các hộp văn bản sẽ được cập nhật.

{{% alert color="primary" title="TIP" %}} 

Bạn có thể muốn xem [phông chữ PowerPoint](/slides/vi/cpp/powerpoint-fonts/).

{{% /alert %}}

## **Thay đổi kiểu nền chủ đề**

Mặc định, ứng dụng PowerPoint cung cấp 12 nền được định sẵn nhưng chỉ 3 trong số 12 nền đó được lưu trong một bản trình chiếu thông thường.

![todo:image_alt_text](presentation-design_8.png)

Ví dụ, sau khi bạn lưu một bản trình chiếu trong ứng dụng PowerPoint, bạn có thể chạy đoạn mã C++ này để biết số lượng nền định sẵn trong bản trình chiếu:

```c++
auto pres = MakeObject<Presentation>(u"pres.pptx");
        
int32_t numberOfBackgroundFills = pres->get_MasterTheme()->get_FormatScheme()->get_BackgroundFillStyles()->get_Count();

Console::WriteLine(u"Number of background fill styles for theme is {0}", numberOfBackgroundFills);
```

{{% alert color="warning" %}} 

Sử dụng thuộc tính [BackgroundFillStyles](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.theme.format_scheme#aec29b94bc65619519a86a8d4607f5f7d) từ lớp [FormatScheme](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.theme.i_format_scheme/), bạn có thể thêm hoặc truy cập kiểu nền trong một chủ đề PowerPoint.

{{% /alert %}}

Đoạn mã C++ này cho bạn thấy cách đặt nền cho một bản trình chiếu:

```c++
pres->get_Masters()->idx_get(0)->get_Background()->set_StyleIndex(2);
```

**Hướng dẫn chỉ mục**: 0 được dùng cho không có màu. Chỉ mục bắt đầu từ 1.

{{% alert color="primary" title="TIP" %}} 

Bạn có thể muốn xem [Nền PowerPoint](/slides/vi/cpp/presentation-background/).

{{% /alert %}}

## **Thay đổi hiệu ứng chủ đề**

Một chủ đề PowerPoint thường chứa 3 giá trị cho mỗi mảng kiểu. Các mảng này được kết hợp thành 3 hiệu ứng: subtle, moderate, và intense. Ví dụ, đây là kết quả khi các hiệu ứng được áp dụng cho một hình dạng cụ thể:

![todo:image_alt_text](presentation-design_10.png)

Bằng cách sử dụng 3 thuộc tính ([FillStyles](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.theme.i_format_scheme#ab80b867174104e26e4824dc8585a1563), [LineStyles](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.theme.i_format_scheme#ae68a6d0a27dd2ada86a857ebde695ecd), [EffectStyles](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.theme.i_format_scheme#aba41300412c5c755fe82cf735bcf0f58)) từ lớp [FormatScheme](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.theme.i_format_scheme/) bạn có thể thay đổi các yếu tố trong một chủ đề (còn linh hoạt hơn nhiều so với các tùy chọn trong PowerPoint).

Đoạn mã C++ này cho bạn thấy cách thay đổi hiệu ứng chủ đề bằng cách thay đổi các phần của yếu tố:

```c++
auto pres = System::MakeObject<Presentation>(u"Subtle_Moderate_Intense.pptx");
        
pres->get_MasterTheme()->get_FormatScheme()->get_LineStyles()->idx_get(0)->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());

pres->get_MasterTheme()->get_FormatScheme()->get_FillStyles()->idx_get(2)->set_FillType(FillType::Solid);

pres->get_MasterTheme()->get_FormatScheme()->get_FillStyles()->idx_get(2)->get_SolidFillColor()->set_Color(Color::get_ForestGreen());

pres->get_MasterTheme()->get_FormatScheme()->get_EffectStyles()->idx_get(2)->get_EffectFormat()->get_OuterShadowEffect()->set_Distance(10.f);

pres->Save(u"Design_04_Subtle_Moderate_Intense-out.pptx", SaveFormat::Pptx);
```

Các thay đổi kết quả trong màu nền, kiểu nền, hiệu ứng bóng đổ, v.v.:

![todo:image_alt_text](presentation-design_11.png)

## **Câu hỏi thường gặp**

**Có thể áp dụng một chủ đề cho một slide duy nhất mà không thay đổi master không?**

Có. Aspose.Slides hỗ trợ ghi đè chủ đề ở mức slide, vì vậy bạn có thể áp dụng một chủ đề cục bộ chỉ cho slide đó trong khi giữ nguyên chủ đề master (thông qua [SlideThemeManager](https://reference.aspose.com/slides/vi/cpp/aspose.slides.theme/slidethememanager/)).

**Cách an toàn nhất để mang một chủ đề từ bản trình chiếu này sang bản trình chiếu khác là gì?**

[Clone slides](/slides/vi/cpp/clone-slides/) cùng với master của chúng vào bản trình chiếu đích. Điều này bảo tồn master, layout và chủ đề liên quan để giao diện vẫn nhất quán.

**Làm sao tôi có thể xem các giá trị "hiệu quả" sau tất cả kế thừa và ghi đè?**

Sử dụng các "view" ["effective"](/slides/vi/cpp/shape-effective-properties/) của API cho theme/color/font/effect. Những view này trả về các thuộc tính đã được giải quyết cuối cùng sau khi áp dụng master và mọi ghi đè cục bộ.