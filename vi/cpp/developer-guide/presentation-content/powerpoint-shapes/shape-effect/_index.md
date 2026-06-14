---
title: Áp dụng hiệu ứng hình dạng trong bài thuyết trình bằng C++
linktitle: Hiệu ứng hình dạng
type: docs
weight: 30
url: /vi/cpp/shape-effect/
keywords:
- hiệu ứng hình dạng
- hiệu ứng bóng đổ
- hiệu ứng phản chiếu
- hiệu ứng hào quang
- hiệu ứng cạnh mềm
- định dạng hiệu ứng
- PowerPoint
- bài thuyết trình
- C++
- Aspose.Slides
description: "Chuyển đổi các tệp PPT và PPTX của bạn với các hiệu ứng hình dạng nâng cao bằng Aspose.Slides cho C++ — tạo các slide ấn tượng, chuyên nghiệp trong vài giây."
---
## **Giới thiệu**

Trong khi các hiệu ứng trong PowerPoint có thể được sử dụng để làm cho một hình dạng nổi bật, chúng khác với [đổ màu](/slides/vi/cpp/shape-formatting/#gradient-fill) hoặc viền. Sử dụng các hiệu ứng PowerPoint, bạn có thể tạo phản chiếu thuyết phục trên một hình dạng, lan tỏa ánh hào quang của hình dạng, v.v.

<img src="shape-effect.png" alt="shape-effect" style="zoom:50%;" />

* PowerPoint cung cấp sáu hiệu ứng có thể áp dụng cho các hình dạng. Bạn có thể áp dụng một hoặc nhiều hiệu ứng cho một hình dạng. 

* Một số kết hợp hiệu ứng trông đẹp hơn so với những kết hợp khác. Vì lý do này, PowerPoint có tùy chọn **Preset**. Các tùy chọn Preset về cơ bản là một tổ hợp đã được kiểm chứng là đẹp mắt của hai hoặc nhiều hiệu ứng. Bằng cách chọn một preset, bạn sẽ không phải tốn thời gian thử nghiệm hoặc kết hợp các hiệu ứng khác nhau để tìm ra một tổ hợp hợp lý.

Aspose.Slides cung cấp các thuộc tính và phương thức trong lớp [EffectFormat](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.effect_format/) cho phép bạn áp dụng cùng các hiệu ứng cho các hình dạng trong bài thuyết trình PowerPoint.

## **Áp dụng hiệu ứng bóng đổ**

Đoạn mã C++ này cho bạn thấy cách áp dụng hiệu ứng bóng đổ ngoài ([OuterShadowEffect](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.effect_format#aea1a48246d3240e29092498f648bc028)) cho một hình chữ nhật:

```c++
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::RoundCornerRectangle, 20.0f, 20.0f, 200.0f, 150.0f);

auto effectFormat = shape->get_EffectFormat();
effectFormat->EnableOuterShadowEffect();
auto outerShadowEffect = effectFormat->get_OuterShadowEffect();
outerShadowEffect->get_ShadowColor()->set_Color(System::Drawing::Color::get_DarkGray());
outerShadowEffect->set_Distance(10);
outerShadowEffect->set_Direction(45.0f);

pres->Save(u"output.pptx", SaveFormat::Pptx);
```

## **Áp dụng hiệu ứng phản chiếu**

Đoạn mã C++ này cho bạn thấy cách áp dụng hiệu ứng phản chiếu cho một hình dạng:

```c++
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::RoundCornerRectangle, 20.0f, 20.0f, 200.0f, 150.0f);

auto effectFormat = shape->get_EffectFormat();
effectFormat->EnableReflectionEffect();
auto reflectionEffect = effectFormat->get_ReflectionEffect();
reflectionEffect->set_RectangleAlign(RectangleAlignment::Bottom);
reflectionEffect->set_Direction(90.0f);
reflectionEffect->set_Distance(55);
reflectionEffect->set_BlurRadius(4);

pres->Save(u"reflection.pptx", SaveFormat::Pptx);
```

## **Áp dụng hiệu ứng hào quang**

Đoạn mã C++ này cho bạn thấy cách áp dụng hiệu ứng hào quang cho một hình dạng:

```c++
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::RoundCornerRectangle, 20.0f, 20.0f, 200.0f, 150.0f);

auto effectFormat = shape->get_EffectFormat();
effectFormat->EnableGlowEffect();
auto glowEffect = effectFormat->get_GlowEffect();
glowEffect->get_Color()->set_Color(System::Drawing::Color::get_Magenta());
glowEffect->set_Radius(15);

pres->Save(u"glow.pptx", SaveFormat::Pptx);
```

## **Áp dụng hiệu ứng cạnh mềm**

Đoạn mã C++ này cho bạn thấy cách áp dụng hiệu ứng cạnh mềm cho một hình dạng:

```c++
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::RoundCornerRectangle, 20.0f, 20.0f, 200.0f, 150.0f);

auto effectFormat = shape->get_EffectFormat();
effectFormat->EnableSoftEdgeEffect();
auto softEdgeEffect = effectFormat->get_SoftEdgeEffect();
softEdgeEffect->set_Radius(15);

pres->Save(u"softEdges.pptx", SaveFormat::Pptx);
```

## **Câu hỏi thường gặp**

**Tôi có thể áp dụng nhiều hiệu ứng cho cùng một hình dạng không?**

Có, bạn có thể kết hợp các hiệu ứng khác nhau, chẳng hạn như bóng đổ, phản chiếu và hào quang, trên một hình dạng duy nhất để tạo ra diện mạo sinh động hơn.

**Tôi có thể áp dụng hiệu ứng cho những hình dạng nào?**

Bạn có thể áp dụng hiệu ứng cho nhiều loại hình dạng, bao gồm các hình tự động, biểu đồ, bảng, hình ảnh, đối tượng SmartArt, đối tượng OLE và hơn thế nữa.

**Tôi có thể áp dụng hiệu ứng cho các nhóm hình dạng không?**

Có, bạn có thể áp dụng hiệu ứng cho các nhóm hình dạng. Hiệu ứng sẽ được áp dụng cho toàn bộ nhóm.