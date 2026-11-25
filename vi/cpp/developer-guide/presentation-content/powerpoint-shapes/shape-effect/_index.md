---
title: "Áp dụng hiệu ứng hình dạng trong bài thuyết trình bằng C++"
linktitle: "Hiệu ứng hình dạng"
type: docs
weight: 30
url: /vi/cpp/shape-effect/
keywords:
- "hiệu ứng hình dạng"
- "hiệu ứng bóng"
- "hiệu ứng phản chiếu"
- "hiệu ứng hào quang"
- "hiệu ứng viền mềm"
- "định dạng hiệu ứng"
- PowerPoint
- "bài thuyết trình"
- C++
- Aspose.Slides
description: "Biến đổi tệp PPT và PPTX của bạn với các hiệu ứng hình dạng nâng cao bằng Aspose.Slides cho C++ — tạo các slide ấn tượng, chuyên nghiệp trong vài giây."
---
## **Giới thiệu**

Trong PowerPoint, các hiệu ứng có thể được sử dụng để làm nổi bật một hình dạng, nhưng chúng khác với [đổ màu](/slides/vi/cpp/shape-formatting/#gradient-fill) hoặc viền. Bằng cách sử dụng các hiệu ứng PowerPoint, bạn có thể tạo ra các phản chiếu thuyết phục trên một hình dạng, lan tỏa ánh hào quang của hình dạng, v.v.

![Shape effect](shape-effect.png)

PowerPoint cung cấp sáu hiệu ứng có thể được áp dụng cho các hình dạng. Bạn có thể áp dụng một hoặc nhiều hiệu ứng cho một hình dạng.

Một số kết hợp hiệu ứng trông tốt hơn các kết hợp khác. Vì lý do này, PowerPoint có các tùy chọn trong **Preset**. Các tùy chọn Preset thực chất là sự kết hợp của hai hoặc nhiều hiệu ứng đã được biết là hòa hợp với nhau. Nhờ đó, khi chọn một preset, bạn không phải tốn thời gian thử nghiệm hoặc kết hợp các hiệu ứng khác nhau để tìm một sự kết hợp phù hợp.

Aspose.Slides cung cấp các thuộc tính và phương thức trong lớp [EffectFormat](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/) cho phép bạn áp dụng các hiệu ứng tương tự cho các hình dạng trong bản trình bày PowerPoint.

## **Áp dụng hiệu ứng bóng**

Aspose.Slides cho C++ hỗ trợ bóng ngoài và bóng trong cho các hình dạng. Bạn có thể tùy chỉnh màu sắc, hướng, khoảng cách và bán kính làm mờ để phù hợp với thiết kế bản trình bày của mình.

### **Áp dụng bóng ngoài**

Sử dụng bóng ngoài để làm cho một thẻ hoặc bảng nổi bật so với nền slide. Bóng mở rộng ra ngoài các cạnh của hình dạng, tạo ấn tượng rằng hình dạng được nâng lên trên slide. Điều chỉnh màu sắc, hướng, khoảng cách và bán kính làm mờ để phù hợp với ánh sáng và phong cách của mẫu của bạn.

This C++ code shows how to apply the [hiệu ứng bóng ngoài](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/get_outershadoweffect/) to a rectangle:

```cpp
#include <DOM/Effects/IOuterShadow.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IEffectFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::RoundCornerRectangle, 20.0f, 20.0f, 200.0f, 100.0f);
auto effectFormat = shape->get_EffectFormat();
effectFormat->EnableOuterShadowEffect();
auto outerShadowEffect = effectFormat->get_OuterShadowEffect();
outerShadowEffect->get_ShadowColor()->set_Color(Color::get_DarkGray());
outerShadowEffect->set_Distance(10);
outerShadowEffect->set_Direction(45.0f);

presentation->Save(u"shadow_effect.pptx", SaveFormat::Pptx);
```

![Shadow effect](shadow_effect.png)

### **Áp dụng bóng trong**

Khi tái hiện kiểu dáng hình ảnh của một mẫu, sử dụng bóng trong để tạo cho thẻ hoặc bảng một vẻ ngoài lõm vào. Bóng ngoài mở rộng ra ngoài hình dạng và làm cho nó trông như được nâng lên, trong khi bóng trong tạo bóng cho bên trong các cạnh của nó.

Gọi [EnableInnerShadowEffect](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/enableinnershadoweffect/), sau đó cấu hình [InnerShadowEffect](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/get_innershadoweffect/). Giá trị bán kính làm mờ lớn hơn tạo ra các cạnh mềm hơn.

Ví dụ C++ này tạo một thẻ màu xanh nhạt với bóng trong màu xám đậm và lưu nó dưới dạng tệp PPTX:

```cpp
#include <DOM/Effects/IInnerShadow.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IEffectFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/FillType.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20.0f, 20.0f, 200.0f, 100.0f);
shape->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_LightBlue());
shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::NoFill);

shape->get_EffectFormat()->EnableInnerShadowEffect();
auto shadow = shape->get_EffectFormat()->get_InnerShadowEffect();
shadow->get_ShadowColor()->set_Color(Color::get_DimGray());
shadow->set_Direction(225);
shadow->set_Distance(7);
shadow->set_BlurRadius(6);

presentation->Save(u"inner_shadow_effect.pptx", SaveFormat::Pptx);
```

![Light blue rectangle with an inner shadow](inner_shadow_effect.png)

Để loại bỏ bóng trong, gọi [DisableInnerShadowEffect](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/disableinnershadoweffect/) trên định dạng hiệu ứng của hình dạng.

### **Áp dụng, thay đổi và xóa bóng Preset**

Gọi [EnablePresetShadowEffect](https://reference.aspose.com/slides/cpp/aspose.slides/ieffectformat/enablepresetshadoweffect/) và sử dụng [set_Preset](https://reference.aspose.com/slides/cpp/aspose.slides.effects/ipresetshadow/set_preset/) để chọn một [PresetShadowType](https://reference.aspose.com/slides/cpp/aspose.slides/presetshadowtype/). Để chuyển đổi kiểu, thay đổi preset trên cùng một hình dạng. Gọi [DisablePresetShadowEffect](https://reference.aspose.com/slides/cpp/aspose.slides/ieffectformat/disablepresetshadoweffect/) để xóa bóng trong khi vẫn giữ nguyên phần đổ màu và viền.

Ví dụ này giữ một bản sao của hình chữ nhật ở mỗi giai đoạn. Cả hai bóng đều được dịch chuyển 10 điểm. Hướng 225° đặt bóng đầu tiên phía trên và bên trái của hình chữ nhật, và 45° đặt bóng thứ hai phía dưới và bên phải.

```cpp
#include <DOM/Effects/IPresetShadow.h>
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IEffectFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideSize.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/PresetShadowType.h>
#include <DOM/ShapeType.h>
#include <DOM/SlideSizeScaleType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/enum.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>();
presentation->get_SlideSize()->SetSize(800, 120, SlideSizeScaleType::DoNotScale);
auto shapes = presentation->get_Slide(0)->get_Shapes();

auto shape = shapes->AddAutoShape(ShapeType::Rectangle, 15, 30, 170, 60);
shape->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_SteelBlue());
auto outline = shape->get_LineFormat()->get_FillFormat();
outline->set_FillType(FillType::Solid);
outline->get_SolidFillColor()->set_Color(Color::get_DarkBlue());
auto textFrame = shape->get_TextFrame();
textFrame->set_Text(u"No shadow");
textFrame->get_Paragraph(0)->get_ParagraphFormat()->get_DefaultPortionFormat()->set_FontHeight(14);
shapes->AddClone(shape);

shape->set_X(shape->get_X() + 200);
auto effectFormat = shape->get_EffectFormat();
effectFormat->EnablePresetShadowEffect();
auto shadow = effectFormat->get_PresetShadowEffect();
shadow->set_Preset(PresetShadowType::TopLeftDropShadow);
shadow->set_Distance(10);
shadow->set_Direction(225);
textFrame->set_Text(System::Enum<PresetShadowType>::GetName(shadow->get_Preset()));
shapes->AddClone(shape);

shape->set_X(shape->get_X() + 200);
shadow->set_Preset(PresetShadowType::BottomRightDropShadow);
shadow->set_Direction(45);
textFrame->set_Text(System::Enum<PresetShadowType>::GetName(shadow->get_Preset()));
shapes->AddClone(shape);

shape->set_X(shape->get_X() + 200);
effectFormat->DisablePresetShadowEffect();
textFrame->set_Text(u"No shadow");

presentation->Save(u"preset_shadows.pptx", SaveFormat::Pptx);
```

| Gốc | Preset đầu tiên | Preset thứ hai | Sau khi xóa |
| :---: | :---: | :---: | :---: |
| ![Không có bóng](preset_shadow_original.png) | ![Bóng rơi trên trái](preset_shadow_top_left.png) | ![Bóng rơi dưới phải](preset_shadow_bottom_right.png) | ![Không có bóng sau khi xóa](preset_shadow_removed.png) |

## **Áp dụng hiệu ứng phản chiếu**

Để áp dụng hiệu ứng phản chiếu trong Aspose.Slides cho C++, bạn có thể thêm một phản chiếu giống gương vào các hình dạng, điều chỉnh các tham số như khoảng cách, độ trong suốt và kích thước. Hiệu ứng này nâng cao thẩm mỹ của bản trình bày bằng cách mang lại cho các hình dạng vẻ ngoài mịn màng và tinh tế hơn. Nó dễ thực hiện với mã đơn giản, cho phép áp dụng nhanh chóng trên nhiều yếu tố để đạt thiết kế thống nhất.

This C++ code shows how to apply the [hiệu ứng phản chiếu](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/get_reflectioneffect/) to a shape:

```cpp
#include <DOM/Effects/IReflection.h>
#include <DOM/IAutoShape.h>
#include <DOM/IEffectFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/RectangleAlignment.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::RoundCornerRectangle, 20.0f, 20.0f, 200.0f, 100.0f);
auto effectFormat = shape->get_EffectFormat();
effectFormat->EnableReflectionEffect();
auto reflectionEffect = effectFormat->get_ReflectionEffect();
reflectionEffect->set_RectangleAlign(RectangleAlignment::Bottom);
reflectionEffect->set_Direction(90.0f);
reflectionEffect->set_Distance(40);
reflectionEffect->set_BlurRadius(2);

presentation->Save(u"reflection_effect.pptx", SaveFormat::Pptx);
```

![Hiệu ứng phản chiếu](reflection_effect.png)

## **Áp dụng hiệu ứng hào quang**

Để áp dụng hiệu ứng hào quang cho một hình dạng trong Aspose.Slides cho C++, bạn có thể thêm một hào quang mềm mại, rực rỡ xung quanh các hình dạng, điều chỉnh các thuộc tính như màu sắc và kích thước. Hiệu ứng này giúp làm nổi bật các hình dạng và thêm yếu tố hình ảnh thu hút, bắt mắt cho bản trình bày của bạn. Nó dễ thực hiện với mã tối thiểu, nâng cao tổng thể giao diện các slide.

This C++ code shows how to apply the [hiệu ứng hào quang](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/get_gloweffect/) to a shape:

```cpp
#include <DOM/Effects/IGlow.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IEffectFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::RoundCornerRectangle, 20.0f, 20.0f, 200.0f, 100.0f);
auto effectFormat = shape->get_EffectFormat();
effectFormat->EnableGlowEffect();
auto glowEffect = effectFormat->get_GlowEffect();
glowEffect->get_Color()->set_Color(Color::get_Magenta());
glowEffect->set_Radius(15);

presentation->Save(u"glow_effect.pptx", SaveFormat::Pptx);
```

![Hiệu ứng hào quang](glow_effect.png)

## **Áp dụng hiệu ứng viền mềm**

Để áp dụng hiệu ứng viền mềm trong Aspose.Slides cho C++, bạn có thể tạo một chuyển đổi mượt mà, mờ quanh các cạnh của một hình dạng. Hiệu ứng này mang lại vẻ ngoài tinh tế và nhẹ nhàng hơn, phù hợp cho các thiết kế cần phong cách nhẹ nhàng, mềm mại. Bạn có thể dễ dàng điều chỉnh các tham số như bán kính để đạt được hiệu ứng mong muốn trên nhiều hình dạng trong bản trình bày.

This C++ code shows how to apply the [viền mềm](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/get_softedgeeffect/) to a shape:

```cpp
#include <DOM/Effects/ISoftEdge.h>
#include <DOM/IAutoShape.h>
#include <DOM/IEffectFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::RoundCornerRectangle, 20.0f, 20.0f, 200.0f, 150.0f);
auto effectFormat = shape->get_EffectFormat();
effectFormat->EnableSoftEdgeEffect();
auto softEdgeEffect = effectFormat->get_SoftEdgeEffect();
softEdgeEffect->set_Radius(8);

presentation->Save(u"soft_edges_effect.pptx", SaveFormat::Pptx);
```

![Hiệu ứng viền mềm](soft_edges_effect.png)

## **Áp dụng hiệu ứng làm mờ**

Sử dụng làm mờ hình dạng để làm mềm phần đổ màu và viền của hình mà vẫn giữ khả năng chỉnh sửa. Gọi [SetBlurEffect](https://reference.aspose.com/slides/cpp/aspose.slides/ieffectformat/setblureffect/) trên định dạng hiệu ứng của hình. Bán kính được đo bằng điểm (1/72 inch): sử dụng giá trị không âm, giá trị lớn hơn tạo độ mờ mạnh hơn. Bán kính bằng không giữ nguyên diện mạo.

Cài đặt [Grow](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iblur/get_grow/) kiểm soát giới hạn hiển thị của hiệu ứng. Khi `false`, hiệu ứng làm mờ bị cắt trong giới hạn đã vẽ ban đầu, bao gồm viền. Khi `true`, hiệu ứng có thể mở rộng ra ngoài các giới hạn đó. Cả hai cài đặt đều không thay đổi vị trí hoặc kích thước của hình.

Bảng so sánh dưới đây sử dụng cùng màu đổ, viền và kích thước hình suốt quá trình. Hàng trên sử dụng `grow = false`; hàng dưới sử dụng `grow = true`.

![Hình chữ nhật gốc so sánh với bán kính làm mờ 5 và 15 điểm, với grow tắt và bật](shape_blur_comparison.png)

Ví dụ C++ này tạo một hình chữ nhật màu cam với viền xanh đậm, áp dụng làm mờ 5 điểm, rồi cập nhật lên làm mờ 15 điểm bằng cách gọi lại [SetBlurEffect](https://reference.aspose.com/slides/cpp/aspose.slides/ieffectformat/setblureffect/) . Nó lưu cả hai trạng thái đã làm mờ, sau đó gọi [DisableBlurEffect](https://reference.aspose.com/slides/cpp/aspose.slides/ieffectformat/disableblureffect/) và lưu hình mà không có hiệu ứng làm mờ.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IEffectFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/FillType.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 80.0f, 160.0f, 100.0f);
shape->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Orange());
shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_DarkBlue());
shape->get_LineFormat()->set_Width(8);

shape->get_EffectFormat()->SetBlurEffect(5, false);
presentation->Save(u"shape_blur_5.pptx", SaveFormat::Pptx);

shape->get_EffectFormat()->SetBlurEffect(15, true);
presentation->Save(u"shape_blur_15.pptx", SaveFormat::Pptx);

shape->get_EffectFormat()->DisableBlurEffect();
presentation->Save(u"shape_blur_removed.pptx", SaveFormat::Pptx);
```

Làm mờ hình ảnh ảnh hưởng đến phần đổ màu và viền cùng lúc. Hiệu ứng viền mềm làm mờ các cạnh của hình, trong khi làm mờ bóng chỉ làm mềm bóng. Các hiệu ứng biến đổi hình ảnh hoạt động trên nội dung hình ảnh; ví dụ này áp dụng làm mờ trực tiếp vào định dạng hiệu ứng của hình mà không chuyển hình thành hình ảnh.

## **Câu hỏi thường gặp**

**Có thể áp dụng nhiều hiệu ứng cho cùng một hình dạng không?**

Có, bạn có thể kết hợp các hiệu ứng khác nhau, như bóng, phản chiếu và hào quang, trên một hình dạng duy nhất để tạo ra diện mạo năng động hơn.

**Những hình dạng nào tôi có thể áp dụng hiệu ứng?**

Bạn có thể áp dụng hiệu ứng cho nhiều loại hình dạng, bao gồm autoshapes, biểu đồ, bảng, hình ảnh, đối tượng SmartArt, đối tượng OLE và nhiều hơn nữa.

**Có thể áp dụng hiệu ứng cho các hình dạng đã nhóm không?**

Có, bạn có thể áp dụng hiệu ứng cho các hình dạng đã nhóm. Hiệu ứng sẽ được áp dụng cho toàn bộ nhóm.