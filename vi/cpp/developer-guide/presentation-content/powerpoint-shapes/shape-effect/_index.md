---
title: "Áp dụng Hiệu ứng Hình dạng trong Bản trình chiếu bằng C++"
linktitle: "Hiệu ứng Hình dạng"
type: docs
weight: 30
url: /vi/cpp/shape-effect/
keywords:
- "hiệu ứng hình dạng"
- "hiệu ứng đổ bóng"
- "hiệu ứng phản chiếu"
- "hiệu ứng hào quang"
- "hiệu ứng cạnh mềm"
- "định dạng hiệu ứng"
- "PowerPoint"
- "bản trình chiếu"
- "C++"
- "Aspose.Slides"
description: "Biến đổi các tệp PPT và PPTX của bạn với các hiệu ứng hình dạng nâng cao bằng Aspose.Slides cho C++ — tạo các slide nổi bật, chuyên nghiệp chỉ trong vài giây."
---
## **Giới thiệu**

Trong khi các hiệu ứng trong PowerPoint có thể được sử dụng để làm nổi bật một hình dạng, chúng khác với [đổ màu](/slides/vi/cpp/shape-formatting/#gradient-fill) hoặc viền. Bằng cách sử dụng các hiệu ứng PowerPoint, bạn có thể tạo ra những phản chiếu thuyết phục trên một hình dạng, lan tỏa ánh hào quang của hình, v.v.

![Hiệu ứng hình dạng](shape-effect.png)

PowerPoint cung cấp sáu hiệu ứng có thể áp dụng cho các hình dạng. Bạn có thể áp dụng một hoặc nhiều hiệu ứng cho một hình dạng.

Một số sự kết hợp của các hiệu ứng trông tốt hơn so với những cái khác. Vì lý do này, PowerPoint có các tùy chọn dưới **Preset**. Các tùy chọn Preset thực chất là một sự kết hợp đã biết là đẹp của hai hoặc nhiều hiệu ứng. Bằng cách này, khi chọn một preset, bạn sẽ không phải lãng phí thời gian thử nghiệm hoặc kết hợp các hiệu ứng khác nhau để tìm ra một sự kết hợp phù hợp.

Aspose.Slides cung cấp các thuộc tính và phương thức trong lớp [EffectFormat](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/) cho phép bạn áp dụng các hiệu ứng tương tự cho các hình dạng trong bản trình bày PowerPoint.

## **Áp dụng Hiệu ứng Đổ Bóng**

Aspose.Slides cho C++ hỗ trợ các bóng đổ ngoài và trong cho các hình dạng. Bạn có thể tùy chỉnh màu sắc, hướng, khoảng cách và bán kính làm mờ của chúng để phù hợp với thiết kế bản trình bày của mình.

### **Áp dụng Bóng Đổ Ngoài**

Sử dụng bóng đổ ngoài để làm cho một thẻ hoặc bảng nổi bật so với nền slide. Bóng đổ mở rộng ra ngoài các cạnh của hình dạng, tạo ấn tượng rằng hình dạng được nâng lên so với slide. Điều chỉnh màu sắc, hướng, khoảng cách và bán kính làm mờ để phù hợp với ánh sáng và kiểu dáng của mẫu của bạn.

Đoạn mã C++ này cho thấy cách áp dụng [outer shadow effect](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/get_outershadoweffect/) cho một hình chữ nhật:
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

![Hiệu ứng bóng đổ](shadow_effect.png)

### **Áp dụng Bóng Đổ Trong**

Khi tái tạo phong cách trực quan của mẫu, sử dụng bóng đổ trong để tạo cho thẻ hoặc bảng một vẻ ngoài chìm. Bóng đổ ngoài mở rộng ra bên ngoài hình dạng và khiến nó trông như nâng lên, trong khi bóng đổ trong tạo bóng bên trong các cạnh của nó.

Gọi [EnableInnerShadowEffect](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/enableinnershadoweffect/), sau đó cấu hình [InnerShadowEffect](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/get_innershadoweffect/). Giá trị bán kính làm mờ lớn hơn tạo ra các cạnh mềm hơn.

Ví dụ C++ này tạo một thẻ màu xanh nhạt với bóng đổ trong màu xám đậm và lưu nó dưới dạng tệp PPTX:
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

![Hình chữ nhật màu xanh nhạt với bóng đổ trong](inner_shadow_effect.png)

Để loại bỏ bóng đổ trong, gọi [DisableInnerShadowEffect](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/disableinnershadoweffect/) trên định dạng hiệu ứng của hình dạng.

## **Áp dụng Hiệu ứng Phản chiếu**

Để áp dụng hiệu ứng phản chiếu trong Aspose.Slides cho C++, bạn có thể thêm một phản chiếu giống như gương cho các hình dạng, điều chỉnh các tham số như khoảng cách, độ trong suốt và kích thước. Hiệu ứng này nâng cao thẩm mỹ của bản trình bày bằng cách mang lại cho các hình dạng một vẻ ngoài bóng bẩy và tinh tế hơn. Nó dễ thực hiện với mã đơn giản, cho phép áp dụng nhanh chóng trên nhiều phần tử để có thiết kế đồng nhất.

Đoạn mã C++ này cho thấy cách áp dụng [reflection effect](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/get_reflectioneffect/) cho một hình dạng:
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

## **Áp dụng Hiệu ứng Hào quang**

Để áp dụng hiệu ứng hào quang cho một hình dạng trong Aspose.Slides cho C++, bạn có thể thêm một hào quang mềm mại và sáng rực xung quanh các hình dạng, điều chỉnh các thuộc tính như màu sắc và kích thước. Hiệu ứng này giúp làm nổi bật các hình dạng và thêm một yếu tố trực quan hấp dẫn, thu hút mắt vào bản trình bày của bạn. Nó dễ thực hiện với ít mã, nâng cao tổng thể giao diện của các slide.

Đoạn mã C++ này cho thấy cách áp dụng [glow effect](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/get_gloweffect/) cho một hình dạng:
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

## **Áp dụng Hiệu ứng Cạnh Mềm**

Để áp dụng hiệu ứng cạnh mềm trong Aspose.Slides cho C++, bạn có thể tạo một chuyển đổi mượt mà, mờ quanh các cạnh của một hình dạng. Hiệu ứng này mang lại một vẻ ngoài tinh tế và nhẹ nhàng hơn, phù hợp cho các thiết kế cần một diện mạo nhẹ nhàng, mềm mại. Bạn có thể dễ dàng điều chỉnh các tham số như bán kính để đạt được hiệu ứng mong muốn trên nhiều hình dạng trong bản trình bày của mình.

Đoạn mã C++ này cho thấy cách áp dụng [soft edges](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/get_softedgeeffect/) cho một hình dạng:
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

![Hiệu ứng cạnh mềm](soft_edges_effect.png)

## **Câu hỏi thường gặp**

**Có thể áp dụng nhiều hiệu ứng cho cùng một hình dạng không?**

Có, bạn có thể kết hợp các hiệu ứng khác nhau, chẳng hạn như bóng đổ, phản chiếu và hào quang, trên một hình dạng duy nhất để tạo ra một diện mạo năng động hơn.

**Các loại hình dạng nào có thể áp dụng hiệu ứng?**

Bạn có thể áp dụng hiệu ứng cho nhiều loại hình dạng, bao gồm các hình tự động, biểu đồ, bảng, hình ảnh, đối tượng SmartArt, đối tượng OLE và nhiều hơn nữa.

**Có thể áp dụng hiệu ứng cho các hình dạng được nhóm không?**

Có, bạn có thể áp dụng hiệu ứng cho các hình dạng được nhóm. Hiệu ứng sẽ áp dụng cho toàn bộ nhóm.