---
title: Tạo và Chỉnh sửa Hành vi Hoạt ảnh Tùy chỉnh trong C++
linktitle: Hoạt ảnh Tùy chỉnh
type: docs
weight: 151
url: /vi/cpp/custom-animation/
keywords:
- hoạt ảnh tùy chỉnh
- hành vi hoạt ảnh
- đường chuyển động
- PowerPoint
- bản trình chiếu
- C++
- Aspose.Slides
description: "Tạo, kiểm tra và chỉnh sửa các hành vi hoạt ảnh tùy chỉnh và các đường chuyển động có thể chỉnh sửa trong bản trình chiếu PowerPoint với Aspose.Slides cho C++."
---
## **Tổng quan**

Các hành vi hoạt ảnh tùy chỉnh cho phép bạn kiểm soát các thao tác riêng lẻ trong một hiệu ứng hoạt ảnh, chẳng hạn như thay đổi màu, xoay hình dạng, hoặc theo một đường chuyển động có thể chỉnh sửa. Hướng dẫn này cho thấy cách tạo và kết hợp các hành vi, cấu hình thời gian của chúng, kiểm tra và sửa đổi các hoạt ảnh hiện có, và xác minh rằng các thuộc tính của chúng vẫn tồn tại sau khi lưu và mở lại một bản trình chiếu.

Đối với các hiệu ứng được định trước và kích hoạt bằng cú nhấn, xem [Hoạt ảnh Hình](/slides/vi/cpp/shape-animation/).

## **Hiểu mô hình hoạt ảnh**

Một hoạt ảnh được tổ chức theo **Timeline → Sequence → Effect → Behaviors**:

- Slide của bạn [get_Timeline](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ibaseslide/get_timeline/) chứa chuỗi chính và các chuỗi tương tác.
- Một [ISequence](https://reference.aspose.com/slides/vi/cpp/aspose.slides.animation/isequence/) chứa các hiệu ứng, có thể nhắm vào các hình dạng khác nhau.
- Một [IEffect](https://reference.aspose.com/slides/vi/cpp/aspose.slides.animation/ieffect/) xác định hình dạng mục tiêu, preset, subtype và thời gian hiệu ứng.
- [IEffect::get_Behaviors](https://reference.aspose.com/slides/vi/cpp/aspose.slides.animation/ieffect/get_behaviors/) chứa các thao tác thực hiện hiệu ứng: thay đổi màu, di chuyển, xoay, thiết lập thuộc tính, v.v.

## **Tạo các hành vi riêng lẻ**

Gọi [ISequence::AddEffect](https://reference.aspose.com/slides/vi/cpp/aspose.slides.animation/isequence/addeffect/) để tạo một hiệu ứng và truy cập bộ sưu tập [get_Behaviors](https://reference.aspose.com/slides/vi/cpp/aspose.slides.animation/ieffect/get_behaviors/) của nó. Một preset có thể tự động điền bộ sưu tập này. Giữ các thao tác của nó khi mở rộng preset, hoặc sử dụng [Clear](https://reference.aspose.com/slides/vi/cpp/aspose.slides.animation/ibehaviorcollection/clear/) khi cố ý thay thế chúng.

[IBehaviorFactory](https://reference.aspose.com/slides/vi/cpp/aspose.slides.animation/ibehaviorfactory/) tạo tám loại hành vi được minh họa bên dưới. Chuyển động được trình bày trong [Xây dựng Đường chuyển động](#build-a-motion-path). Mỗi ví dụ tạo là mã tự chứa để chạy trong một hàm; các ví dụ chỉnh sửa sau này chỉ rõ tệp đầu ra chúng sử dụng.

### **Xoay**

Sử dụng [CreateRotationEffect](https://reference.aspose.com/slides/vi/cpp/aspose.slides.animation/ibehaviorfactory/createrotationeffect/) để tạo một phép xoay. [get_By](https://reference.aspose.com/slides/vi/cpp/aspose.slides.animation/irotationeffect/get_by/) định nghĩa góc tương đối bằng độ; [get_From](https://reference.aspose.com/slides/vi/cpp/aspose.slides.animation/irotationeffect/get_from/) và [get_To](https://reference.aspose.com/slides/vi/cpp/aspose.slides.animation/irotationeffect/get_to/) xác định các điểm cuối.

Ví dụ bắt đầu với một hiệu ứng Spin, thay thế các thao tác preset của nó bằng một hành vi xoay, và gán cho thao tác đó thời lượng hai giây. Góc tương đối 90 độ thể hiện một quay phần tư so với hướng ban đầu của hình, vì vậy không cần góc bắt đầu rõ ràng.

```cpp
#include <DOM/Animation/BehaviorFactory.h>
#include <DOM/Animation/EffectSubtype.h>
#include <DOM/Animation/EffectTriggerType.h>
#include <DOM/Animation/EffectType.h>
#include <DOM/Animation/IBehaviorCollection.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/IRotationEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/Animation/ITiming.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 160, 80);

auto effect = slide->get_Timeline()->get_MainSequence()->AddEffect(shape, EffectType::Spin, EffectSubtype::None, EffectTriggerType::OnClick);
effect->get_Behaviors()->Clear();

auto factory = MakeObject<BehaviorFactory>();
auto rotation = factory->CreateRotationEffect();
rotation->set_By(90.0f);
rotation->get_Timing()->set_Duration(2.0f);

effect->get_Behaviors()->Add(rotation);

presentation->Save(u"rotation.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

`rotation.pptx` chứa một hình và một hành vi xoay. Bộ sưu tập, thời gian và các ví dụ chỉnh sửa xoay bên dưới sử dụng tệp này.

### **Thang**

Sử dụng [CreateScaleEffect](https://reference.aspose.com/slides/vi/cpp/aspose.slides.animation/ibehaviorfactory/createscaleeffect/) với phần trăm X/Y: [get_From](https://reference.aspose.com/slides/vi/cpp/aspose.slides.animation/iscaleeffect/get_from/) và [get_To](https://reference.aspose.com/slides/vi/cpp/aspose.slides.animation/iscaleeffect/get_to/) mô tả kích thước bắt đầu và kết thúc, trong khi [get_By](https://reference.aspose.com/slides/vi/cpp/aspose.slides.animation/iscaleeffect/get_by/) mô tả sự thay đổi tương đối. Ở đây, 100 có nghĩa là kích thước gốc.

Ví dụ mở rộng cả hai chiều từ 100 % lên 125 % trong hai giây. Sử dụng cùng tỷ lệ ngang và dọc giữ nguyên tỉ lệ của hình; các tỷ lệ khác nhau sẽ kéo dài một chiều hơn chiều kia.

```cpp
#include <DOM/Animation/BehaviorFactory.h>
#include <DOM/Animation/EffectSubtype.h>
#include <DOM/Animation/EffectTriggerType.h>
#include <DOM/Animation/EffectType.h>
#include <DOM/Animation/IBehaviorCollection.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/IScaleEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/Animation/ITiming.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/point_f.h>
#include <system/array.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 160, 80);

auto effect = slide->get_Timeline()->get_MainSequence()->AddEffect(shape, EffectType::GrowShrink, EffectSubtype::None, EffectTriggerType::OnClick);
effect->get_Behaviors()->Clear();

auto factory = MakeObject<BehaviorFactory>();
auto scale = factory->CreateScaleEffect();
scale->set_From(PointF(100, 100));
scale->set_To(PointF(125, 125));
scale->get_Timing()->set_Duration(2.0f);

effect->get_Behaviors()->Add(scale);

presentation->Save(u"scale.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

### **Màu**

Sử dụng [CreateColorEffect](https://reference.aspose.com/slides/vi/cpp/aspose.slides.animation/ibehaviorfactory/createcoloreffect/) để thay đổi màu nền từ xanh dương sang cam. [get_From](https://reference.aspose.com/slides/vi/cpp/aspose.slides.animation/icoloreffect/get_from/) và [get_To](https://reference.aspose.com/slides/vi/cpp/aspose.slides.animation/icoloreffect/get_to/) là các màu; [get_By](https://reference.aspose.com/slides/vi/cpp/aspose.slides.animation/icoloreffect/get_by/) là độ lệch màu. [IBehavior::get_Properties](https://reference.aspose.com/slides/vi/cpp/aspose.slides.animation/ibehavior/get_properties/) xác định thuộc tính đang được hoạt ảnh.

Nền rắn của hình được khởi tạo thành xanh dương, trùng với màu bắt đầu của hoạt ảnh. Việc chọn thuộc tính màu nền cho biết hành vi sẽ thay đổi phần nào của hình; các màu đầu và cuối một mình không xác định thuộc tính đó. Hiệu ứng đã lưu mô tả một chuyển đổi hai giây sang màu cam.

```cpp
#include <DOM/Animation/BehaviorFactory.h>
#include <DOM/Animation/BehaviorProperty.h>
#include <DOM/Animation/EffectSubtype.h>
#include <DOM/Animation/EffectTriggerType.h>
#include <DOM/Animation/EffectType.h>
#include <DOM/Animation/IBehaviorCollection.h>
#include <DOM/Animation/IBehaviorPropertyCollection.h>
#include <DOM/Animation/IColorEffect.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/Animation/ITiming.h>
#include <DOM/FillType.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 160, 80);
shape->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());

auto effect = slide->get_Timeline()->get_MainSequence()->AddEffect(shape, EffectType::ChangeFillColor, EffectSubtype::None, EffectTriggerType::OnClick);
effect->get_Behaviors()->Clear();

auto factory = MakeObject<BehaviorFactory>();
auto color = factory->CreateColorEffect();
color->get_Properties()->Add(BehaviorProperty::get_FillColor()->get_Value());
color->get_From()->set_Color(Color::get_Blue());
color->get_To()->set_Color(Color::get_Orange());
color->get_Timing()->set_Duration(2.0f);

effect->get_Behaviors()->Add(color);

presentation->Save(u"color.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

### **Bộ lọc**

Sử dụng [CreateFilterEffect](https://reference.aspose.com/slides/vi/cpp/aspose.slides.animation/ibehaviorfactory/createfiltereffect/) để chọn một hiệu ứng wipe. [get_Type](https://reference.aspose.com/slides/vi/cpp/aspose.slides.animation/ifiltereffect/get_type/), [get_Subtype](https://reference.aspose.com/slides/vi/cpp/aspose.slides.animation/ifiltereffect/get_subtype/), và [get_Reveal](https://reference.aspose.com/slides/vi/cpp/aspose.slides.animation/ifiltereffect/get_reveal/) xác định bộ lọc, hướng và việc hiển thị hay ẩn hình.

Ví dụ này cấu hình một wipe hai giây hiển thị hình bằng subtype hướng phải. Các thiết lập bộ lọc thuộc về hành vi trong hiệu ứng, vì vậy chúng được cấu hình sau khi các thao tác gốc của preset đã bị xóa.

```cpp
#include <DOM/Animation/BehaviorFactory.h>
#include <DOM/Animation/EffectSubtype.h>
#include <DOM/Animation/EffectTriggerType.h>
#include <DOM/Animation/EffectType.h>
#include <DOM/Animation/FilterEffectRevealType.h>
#include <DOM/Animation/FilterEffectSubtype.h>
#include <DOM/Animation/FilterEffectType.h>
#include <DOM/Animation/IBehaviorCollection.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/IFilterEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/Animation/ITiming.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 160, 80);

auto effect = slide->get_Timeline()->get_MainSequence()->AddEffect(shape, EffectType::Wipe, EffectSubtype::None, EffectTriggerType::OnClick);
effect->get_Behaviors()->Clear();

auto factory = MakeObject<BehaviorFactory>();
auto filter = factory->CreateFilterEffect();
filter->set_Type(FilterEffectType::Wipe);
filter->set_Subtype(FilterEffectSubtype::Right);
filter->set_Reveal(FilterEffectRevealType::In);
filter->get_Timing()->set_Duration(2.0f);

effect->get_Behaviors()->Add(filter);

presentation->Save(u"filter.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

### **Thuộc tính**

Sử dụng [CreatePropertyEffect](https://reference.aspose.com/slides/vi/cpp/aspose.slides.animation/ibehaviorfactory/createpropertyeffect/) để hoạt ảnh độ trong suốt. [get_From](https://reference.aspose.com/slides/vi/cpp/aspose.slides.animation/ipropertyeffect/get_from/), [get_To](https://reference.aspose.com/slides/vi/cpp/aspose.slides.animation/ipropertyeffect/get_to/), và [get_By](https://reference.aspose.com/slides/vi/cpp/aspose.slides.animation/ipropertyeffect/get_by/) là các chuỗi được diễn giải bằng [get_ValueType](https://reference.aspose.com/slides/vi/cpp/aspose.slides.animation/ipropertyeffect/get_valuetype/) và [get_CalcMode](https://reference.aspose.com/slides/vi/cpp/aspose.slides.animation/ipropertyeffect/get_calcmode/). Chọn các điểm cuối hoặc độ lệch tương đối thay vì đặt cả ba một cách vô tư.

Ở đây, thuộc tính đã chọn là độ trong suốt, và các chuỗi số biểu thị sự thay đổi từ 25 % độ trong suốt lên độ trong suốt đầy đủ. Nội suy tuyến tính mô tả một sự thay đổi dần dần giữa các giá trị đó. Khi áp dụng ví dụ này cho thuộc tính khác, chọn kiểu giá trị và các giá trị điểm cuối phù hợp với thuộc tính đó.

```cpp
#include <DOM/Animation/BehaviorFactory.h>
#include <DOM/Animation/BehaviorProperty.h>
#include <DOM/Animation/EffectSubtype.h>
#include <DOM/Animation/EffectTriggerType.h>
#include <DOM/Animation/EffectType.h>
#include <DOM/Animation/IBehaviorCollection.h>
#include <DOM/Animation/IBehaviorPropertyCollection.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/IPropertyEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/Animation/ITiming.h>
#include <DOM/Animation/PropertyCalcModeType.h>
#include <DOM/Animation/PropertyValueType.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 160, 80);

auto effect = slide->get_Timeline()->get_MainSequence()->AddEffect(shape, EffectType::Fade, EffectSubtype::None, EffectTriggerType::OnClick);
effect->get_Behaviors()->Clear();

auto factory = MakeObject<BehaviorFactory>();
auto property = factory->CreatePropertyEffect();
property->get_Properties()->Add(BehaviorProperty::get_StyleOpacity()->get_Value());
property->set_ValueType(PropertyValueType::Number);
property->set_CalcMode(PropertyCalcModeType::Linear);
property->set_From(u"0.25");
property->set_To(u"1");
property->get_Timing()->set_Duration(2.0f);

effect->get_Behaviors()->Add(property);

presentation->Save(u"property.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

### **Đặt**

Sử dụng [CreateSetEffect](https://reference.aspose.com/slides/vi/cpp/aspose.slides.animation/ibehaviorfactory/createseteffect/) để gán tính năng hiển thị thông qua [get_To](https://reference.aspose.com/slides/vi/cpp/aspose.slides.animation/iseteffect/get_to/). Một hành vi đặt không nội suy giữa các điểm cuối.

Ví dụ chọn thuộc tính hiển thị và gán chuỗi `visible` khi hành vi chạy. Trong C++, đóng gói chuỗi thành một đối tượng trước khi gán cho hành vi đặt. Hình chữ nhật đã hiển thị trong bản trình chiếu tối thiểu này, vì vậy việc gán có thể không tạo ra thay đổi hình ảnh rõ ràng. Một thao tác như vậy hữu ích khi là một phần của hiệu ứng lớn hơn cũng kiểm soát thời điểm hình trở nên ẩn hoặc hiện.

```cpp
#include <DOM/Animation/BehaviorFactory.h>
#include <DOM/Animation/BehaviorProperty.h>
#include <DOM/Animation/EffectSubtype.h>
#include <DOM/Animation/EffectTriggerType.h>
#include <DOM/Animation/EffectType.h>
#include <DOM/Animation/IBehaviorCollection.h>
#include <DOM/Animation/IBehaviorPropertyCollection.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/Animation/ISetEffect.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 160, 80);

auto effect = slide->get_Timeline()->get_MainSequence()->AddEffect(shape, EffectType::Appear, EffectSubtype::None, EffectTriggerType::OnClick);
effect->get_Behaviors()->Clear();

auto factory = MakeObject<BehaviorFactory>();
auto set = factory->CreateSetEffect();
set->get_Properties()->Add(BehaviorProperty::get_StyleVisibility()->get_Value());
auto visibility = ObjectExt::Box<String>(u"visible");
set->set_To(visibility);

effect->get_Behaviors()->Add(set);

presentation->Save(u"set.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

### **Lệnh**

Sử dụng [CreateCommandEffect](https://reference.aspose.com/slides/vi/cpp/aspose.slides.animation/ibehaviorfactory/createcommandeffect/) và cấu hình [get_Type](https://reference.aspose.com/slides/vi/cpp/aspose.slides.animation/icommandeffect/get_type/), [get_CommandString](https://reference.aspose.com/slides/vi/cpp/aspose.slides.animation/icommandeffect/get_commandstring/), và [get_ShapeTarget](https://reference.aspose.com/slides/vi/cpp/aspose.slides.animation/icommandeffect/get_shapetarget/). Đặt một tệp ghi âm WAV tên `sample.wav` trong thư mục làm việc. Ví dụ này nhúng nó bằng [AddAudioFrameEmbedded](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ishapecollection/addaudioframeembedded/) và gắn một lệnh phát vào khung âm thanh.

Khung âm thanh vừa là mục tiêu của hiệu ứng vừa là mục tiêu của lệnh. Điều này kết nối yêu cầu phát với bản ghi nhúng; một chuỗi lệnh một mình không xác định đối tượng đa phương tiện nào sẽ được điều khiển. Hiệu ứng được cấu hình để bắt đầu khi nhấp trong khi chạy slide.

```cpp
#include <DOM/Animation/BehaviorFactory.h>
#include <DOM/Animation/CommandEffectType.h>
#include <DOM/Animation/EffectSubtype.h>
#include <DOM/Animation/EffectTriggerType.h>
#include <DOM/Animation/EffectType.h>
#include <DOM/Animation/IBehaviorCollection.h>
#include <DOM/Animation/ICommandEffect.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/IAudioFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>
#include <system/io/file_stream.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto audioStream = IO::File::OpenRead(u"sample.wav");
auto audioFrame = slide->get_Shapes()->AddAudioFrameEmbedded(100, 100, 40, 40, audioStream);

auto effect = slide->get_Timeline()->get_MainSequence()->AddEffect(audioFrame, EffectType::MediaPlay, EffectSubtype::None, EffectTriggerType::OnClick);
effect->get_Behaviors()->Clear();

auto factory = MakeObject<BehaviorFactory>();
auto command = factory->CreateCommandEffect();
command->set_Type(CommandEffectType::Call);
command->set_CommandString(u"play");
command->set_ShapeTarget(audioFrame);

effect->get_Behaviors()->Add(command);

presentation->Save(u"command.pptx", SaveFormat::Pptx);

audioStream->Close();

presentation->Dispose();
```

Lưu trữ lệnh trong `command.pptx`; nó không phát bản ghi. Phát lại yêu cầu trình chiếu hỗ trợ lệnh và đối tượng đa phương tiện mục tiêu.

## **Quản lý bộ sưu tập hành vi**

[IBehaviorCollection](https://reference.aspose.com/slides/vi/cpp/aspose.slides.animation/ibehaviorcollection/) hỗ trợ [Add](https://reference.aspose.com/slides/vi/cpp/aspose.slides.animation/ibehaviorcollection/add/), [Insert](https://reference.aspose.com/slides/vi/cpp/aspose.slides.animation/ibehaviorcollection/insert/), [Remove](https://reference.aspose.com/slides/vi/cpp/aspose.slides.animation/ibehaviorcollection/remove/), và [RemoveAt](https://reference.aspose.com/slides/vi/cpp/aspose.slides.animation/ibehaviorcollection/removeat/). Ví dụ này mở `rotation.pptx`, thêm thang, di chuyển nó trước khi xoay, và loại bỏ hành vi xoay. Loại bỏ và chèn lại cùng một đối tượng thay đổi vị trí lưu trữ của nó mà không tạo bản sao.

Chuỗi các chỉnh sửa thay đổi bộ sưu tập từ xoay‑thang thành thang‑xoay, rồi thành chỉ thang. Các chỉ mục tham chiếu tới bộ sưu tập hiện tại, vì vậy việc loại bỏ dùng chỉ mục mới của xoay sau khi đã sắp xếp lại. Đếm cuối cùng xác nhận hành vi nào sẽ được lưu.

```cpp
#include <DOM/Animation/BehaviorFactory.h>
#include <DOM/Animation/IBehaviorCollection.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/IScaleEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/Animation/ITiming.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <drawing/point_f.h>
#include <system/array.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>(u"rotation.pptx");
auto effect = presentation->get_Slide(0)->get_Timeline()->get_MainSequence()->idx_get(0);
auto behaviors = effect->get_Behaviors();

auto factory = MakeObject<BehaviorFactory>();
auto scale = factory->CreateScaleEffect();
scale->set_To(PointF(125, 125));
scale->get_Timing()->set_Duration(2.0f);

behaviors->Add(scale);

behaviors->Remove(scale);
behaviors->Insert(0, scale);
behaviors->RemoveAt(1);

for (auto behavior : behaviors)
    Console::WriteLine(behavior->GetType().get_Name());

presentation->Save(u"collection-edited.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

Kết quả là `ScaleEffect`: chỉ còn thang. Thứ tự trong bộ sưu tập tự nó không lên lịch các hành vi liên tiếp. Xóa toàn bộ bộ sưu tập chỉ khi thay thế tất cả các thao tác của nó.

## **Cấu hình thời gian hành vi**

[IBehavior::get_Timing](https://reference.aspose.com/slides/vi/cpp/aspose.slides.animation/ibehavior/get_timing/) mở ra [ITiming](https://reference.aspose.com/slides/vi/cpp/aspose.slides.animation/itiming/), độc lập với [IEffect::get_Timing](https://reference.aspose.com/slides/vi/cpp/aspose.slides.animation/ieffect/get_timing/). Thời gian hiệu ứng lên lịch cho toàn bộ hiệu ứng; thời gian hành vi mô tả một thao tác bên trong nó.

### **Đặt thời lượng, độ trễ, lặp lại và gia tốc**

Mở `rotation.pptx` và đặt [get_Duration](https://reference.aspose.com/slides/vi/cpp/aspose.slides.animation/itiming/get_duration/) và [get_TriggerDelayTime](https://reference.aspose.com/slides/vi/cpp/aspose.slides.animation/itiming/get_triggerdelaytime/) tính bằng giây, sau đó cấu hình [get_RepeatCount](https://reference.aspose.com/slides/vi/cpp/aspose.slides.animation/itiming/get_repeatcount/). [get_Accelerate](https://reference.aspose.com/slides/vi/cpp/aspose.slides.animation/itiming/get_accelerate/) và [get_Decelerate](https://reference.aspose.com/slides/vi/cpp/aspose.slides.animation/itiming/get_decelerate/) là các phần của thời lượng; giữ tổng của chúng không vượt quá 1.

Tệp đầu vào là tệp được tạo trong ví dụ xoay, trong đó hành vi đầu tiên được biết là một phép xoay. Ví dụ này chỉ thay đổi thời gian của hành vi đó; góc 90 độ vẫn còn nguyên. Giữ góc và thời gian riêng biệt giúp dễ dàng điều chỉnh tốc độ mà không cần xây dựng lại hoạt ảnh.

```cpp
#include <DOM/Animation/IBehaviorCollection.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/IRotationEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/Animation/ITiming.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"rotation.pptx");
auto effect = presentation->get_Slide(0)->get_Timeline()->get_MainSequence()->idx_get(0);

auto rotation = ExplicitCast<IRotationEffect>(effect->get_Behaviors()->idx_get(0));
rotation->get_Timing()->set_Duration(2.0f);
rotation->get_Timing()->set_TriggerDelayTime(0.5f);
rotation->get_Timing()->set_RepeatCount(3.0f);
rotation->get_Timing()->set_Accelerate(0.2f);
rotation->get_Timing()->set_Decelerate(0.2f);

presentation->Save(u"timing.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

Hành vi sử dụng thời lượng hai giây, độ trễ nửa giây, và số lần lặp 3. 20 % đầu và cuối thời lượng được dùng cho gia tốc và giảm tốc.

Các chính sách lặp khác bao gồm [get_RepeatDuration](https://reference.aspose.com/slides/vi/cpp/aspose.slides.animation/itiming/get_repeatduration/), [get_RepeatUntilEndSlide](https://reference.aspose.com/slides/vi/cpp/aspose.slides.animation/itiming/get_repeatuntilendslide/), và [get_RepeatUntilNextClick](https://reference.aspose.com/slides/vi/cpp/aspose.slides.animation/itiming/get_repeatuntilnextclick/); hãy chọn một chính sách thay vì bật đồng thời tất cả. [get_AutoReverse](https://reference.aspose.com/slides/vi/cpp/aspose.slides.animation/itiming/get_autoreverse/) phát hoạt ảnh ngược lại sau lượt tiến. Gia tốc và giảm tốc áp dụng cho các thay đổi liên tục, không phải cho các gán rời rạc hay lệnh.

## **Xây dựng Đường chuyển động**

Sử dụng [CreateMotionEffect](https://reference.aspose.com/slides/vi/cpp/aspose.slides.animation/ibehaviorfactory/createmotioneffect/) để tạo chuyển động. Các thuộc tính [get_From](https://reference.aspose.com/slides/vi/cpp/aspose.slides.animation/imotioneffect/get_from/), [get_To](https://reference.aspose.com/slides/vi/cpp/aspose.slides.animation/imotioneffect/get_to/), và [get_By](https://reference.aspose.com/slides/vi/cpp/aspose.slides.animation/imotioneffect/get_by/) mô tả tọa độ hoặc độ lệch dựa trên phần trăm. Để tạo một lộ trình có thể chỉnh sửa, tạo một [MotionPath](https://reference.aspose.com/slides/vi/cpp/aspose.slides.animation/motionpath/) và gán nó cho [IMotionEffect::get_Path](https://reference.aspose.com/slides/vi/cpp/aspose.slides.animation/imotioneffect/get_path/). [IMotionPath](https://reference.aspose.com/slides/vi/cpp/aspose.slides.animation/imotionpath/) lưu các lệnh đường.

[MotionCommandPathType](https://reference.aspose.com/slides/vi/cpp/aspose.slides.animation/motioncommandpathtype/) chọn thao tác:

| Lệnh | Điểm | Ý nghĩa |
| --- | --- | --- |
| MoveTo | One | Đặt vị trí bắt đầu. |
| LineTo | One | Di chuyển dọc theo đoạn thẳng tới điểm cuối. |
| CurveTo | Three | Theo một đường cong bậc ba được định nghĩa bởi hai điểm điều khiển và một điểm cuối. |
| CloseLoop | None | Quay lại vị trí bắt đầu. |
| End | None | Kết thúc đường. |

[MotionPathPointsType](https://reference.aspose.com/slides/vi/cpp/aspose.slides.animation/motionpathpointstype/) mô tả đặc tính chỉnh sửa điểm, chẳng hạn điểm góc hoặc mượt. Nó không thay thế loại lệnh. Sử dụng loại điểm cong cho ví dụ đường cong dưới đây, và loại điểm góc cho các đoạn thẳng.

Tọa độ đường được chuẩn hóa theo kích thước slide: độ dịch X 0.25 đại diện cho một phần tư chiều rộng slide, không phải 0.25 điểm. Y dương chạy xuống dưới. Các lệnh tuyệt đối chỉ định vị trí trong hệ tọa độ đường, các lệnh tương đối chỉ độ lệch từ vị trí hiện tại. Điều này tách biệt với [get_Origin](https://reference.aspose.com/slides/vi/cpp/aspose.slides.animation/imotioneffect/get_origin/), chọn khung tham chiếu của đường, và [get_PathEditMode](https://reference.aspose.com/slides/vi/cpp/aspose.slides.animation/imotioneffect/get_patheditmode/), kiểm soát cách đường di chuyển khi hình được di chuyển.

### **Tạo Đường thẳng**

Tạo một hành vi chuyển động với điểm bắt đầu, một đoạn thẳng, và lệnh kết thúc. [IMotionPath::Add](https://reference.aspose.com/slides/vi/cpp/aspose.slides.animation/imotionpath/add/) nhận loại lệnh, các điểm, loại điểm, và cờ tọa độ tương đối.

Lệnh bắt đầu thiết lập (0, 0), và đoạn thẳng kết thúc ở (0.25, 0), tạo ra độ dịch ngang một phần tư chiều rộng slide. Lệnh kết thúc không có điểm tọa độ. Khi đường đã được gán, việc thêm hành vi chuyển động vào hiệu ứng sẽ nối đường đó với hình chữ nhật.

```cpp
#include <DOM/Animation/BehaviorFactory.h>
#include <DOM/Animation/EffectSubtype.h>
#include <DOM/Animation/EffectTriggerType.h>
#include <DOM/Animation/EffectType.h>
#include <DOM/Animation/IBehaviorCollection.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/IMotionCmdPath.h>
#include <DOM/Animation/IMotionEffect.h>
#include <DOM/Animation/IMotionPath.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/Animation/ITiming.h>
#include <DOM/Animation/MotionCommandPathType.h>
#include <DOM/Animation/MotionOriginType.h>
#include <DOM/Animation/MotionPath.h>
#include <DOM/Animation/MotionPathPointsType.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/point_f.h>
#include <system/array.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 160, 80);

auto effect = slide->get_Timeline()->get_MainSequence()->AddEffect(shape, EffectType::PathRight, EffectSubtype::None, EffectTriggerType::OnClick);
effect->get_Behaviors()->Clear();

auto factory = MakeObject<BehaviorFactory>();
auto motion = factory->CreateMotionEffect();
motion->set_Origin(MotionOriginType::Layout);
motion->get_Timing()->set_Duration(2.0f);

auto path = MakeObject<MotionPath>();
auto startPoints = MakeArray<PointF>({ PointF(0, 0) });
path->Add(MotionCommandPathType::MoveTo, startPoints, MotionPathPointsType::Auto, false);
auto linePoints = MakeArray<PointF>({ PointF(0.25f, 0) });
path->Add(MotionCommandPathType::LineTo, linePoints, MotionPathPointsType::Corner, false);
auto endPoints = MakeArray<PointF>(0);
path->Add(MotionCommandPathType::End, endPoints, MotionPathPointsType::None, false);

motion->set_Path(path);
effect->get_Behaviors()->Add(motion);

presentation->Save(u"motion.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

`motion.pptx` chứa một hành vi chuyển động với ba lệnh đường. Các ví dụ chỉnh sửa tệp bên dưới sử dụng cấu trúc đã biết này.

### **So sánh tọa độ tuyệt đối và tương đối**

Hai đối tượng đường này mô tả cùng một lộ trình. Lệnh tuyệt đối kết thúc ở (0.3, 0.1); lệnh tương đối cộng (0.1, 0.1) vào vị trí hiện tại, (0.2, 0).

Cả hai đường đều bắt đầu ở cùng vị trí. Đối với đoạn thẳng tương đối, cộng các độ lệch X và Y vào vị trí hiện tại để nhận được điểm cuối; đối với đoạn thẳng tuyệt đối, đọc trực tiếp điểm cuối. Chuyển đổi cờ mà không chuyển đổi tọa độ sẽ mô tả một lộ trình khác.

```cpp
#include <DOM/Animation/IMotionCmdPath.h>
#include <DOM/Animation/IMotionPath.h>
#include <DOM/Animation/MotionCommandPathType.h>
#include <DOM/Animation/MotionPath.h>
#include <DOM/Animation/MotionPathPointsType.h>
#include <drawing/point_f.h>
#include <system/array.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace System;
using namespace System::Drawing;

auto absolutePath = MakeObject<MotionPath>();
auto startPoints = MakeArray<PointF>({ PointF(0.2f, 0) });
absolutePath->Add(MotionCommandPathType::MoveTo, startPoints, MotionPathPointsType::Auto, false);
auto absoluteEndPoints = MakeArray<PointF>({ PointF(0.3f, 0.1f) });
absolutePath->Add(MotionCommandPathType::LineTo, absoluteEndPoints, MotionPathPointsType::Corner, false);

auto relativePath = MakeObject<MotionPath>();
auto relativeStartPoints = MakeArray<PointF>({ PointF(0.2f, 0) });
relativePath->Add(MotionCommandPathType::MoveTo, relativeStartPoints, MotionPathPointsType::Auto, false);
auto relativeOffsets = MakeArray<PointF>({ PointF(0.1f, 0.1f) });
relativePath->Add(MotionCommandPathType::LineTo, relativeOffsets, MotionPathPointsType::Corner, true);
```

Gán bất kỳ đường nào cho một hành vi chuyển động để sử dụng trong bản trình chiếu. Đối số Boolean cuối cùng chọn tọa độ tương đối cho lệnh đó.

### **Thay thế Đường thẳng bằng Đường cong**

Mở `motion.pptx` và thay thế lệnh đường thẳng bằng một đường cong bậc ba. Đầu tiên cung cấp hai điểm điều khiển, sau đó là điểm cuối.

Vị trí bắt đầu được cung cấp bởi lệnh trước đó. Hai điểm đầu tiên tạo hình cong, trong khi điểm thứ ba là điểm đến; chúng không phải là ba điểm đến liên tiếp. Cập nhật đồng thời loại lệnh, loại điểm chỉnh sửa và mảng điểm giúp đoạn giữ đồng nhất với hình học mới.

```cpp
#include <DOM/Animation/IBehaviorCollection.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/IMotionCmdPath.h>
#include <DOM/Animation/IMotionEffect.h>
#include <DOM/Animation/IMotionPath.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/Animation/MotionCommandPathType.h>
#include <DOM/Animation/MotionPathPointsType.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <drawing/point_f.h>
#include <system/array.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>(u"motion.pptx");
auto effect = presentation->get_Slide(0)->get_Timeline()->get_MainSequence()->idx_get(0);
auto motion = ExplicitCast<IMotionEffect>(effect->get_Behaviors()->idx_get(0));

auto path = motion->get_Path();
path->idx_get(1)->set_CommandType(MotionCommandPathType::CurveTo);
path->idx_get(1)->set_PointsType(MotionPathPointsType::CurveSmooth);
auto curvePoints = MakeArray<PointF>({ PointF(0.1f, 0), PointF(0.2f, 0.1f), PointF(0.3f, 0.1f) });
path->idx_get(1)->set_Points(curvePoints);

presentation->Save(u"curve.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

Đường trong `curve.pptx` vẫn có ba lệnh; lệnh ở giữa hiện tại định nghĩa một đường cong.

## **Kiểm tra và chỉnh sửa Đường đã lưu**

Mỗi [IMotionCmdPath](https://reference.aspose.com/slides/vi/cpp/aspose.slides.animation/imotioncmdpath/) cung cấp [get_Points](https://reference.aspose.com/slides/vi/cpp/aspose.slides.animation/imotioncmdpath/get_points/), [get_CommandType](https://reference.aspose.com/slides/vi/cpp/aspose.slides.animation/imotioncmdpath/get_commandtype/), [get_PointsType](https://reference.aspose.com/slides/vi/cpp/aspose.slides.animation/imotioncmdpath/get_pointstype/), và [get_IsRelative](https://reference.aspose.com/slides/vi/cpp/aspose.slides.animation/imotioncmdpath/get_isrelative/). Các ví dụ sau sử dụng đường ba lệnh đã biết trong `motion.pptx`. Đối với đầu vào tùy ý, xác định hiệu ứng mong muốn và kiểm tra loại lệnh cùng số lượng điểm trước khi chỉnh sửa theo chỉ mục.

### **Đọc lệnh và tọa độ**

Đọc đường mà không thay đổi nó. Các lệnh End và CloseLoop không cần điểm, vì vậy cho phép mảng điểm null.

Kết quả liệt kê mỗi lệnh cùng cờ tọa độ tương đối trước khi liệt kê các điểm của nó. Điều này giúp bạn phân biệt điểm cuối với độ lệch trước khi sửa đổi đường. Một đường cong sẽ liệt kê ba điểm, trong khi đoạn thẳng trong tệp này chỉ liệt kê một.

```cpp
#include <DOM/Animation/IBehaviorCollection.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/IMotionCmdPath.h>
#include <DOM/Animation/IMotionEffect.h>
#include <DOM/Animation/IMotionPath.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/Animation/MotionCommandPathType.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <drawing/point_f.h>
#include <system/array.h>
#include <system/console.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace System;

auto presentation = MakeObject<Presentation>(u"motion.pptx");
auto effect = presentation->get_Slide(0)->get_Timeline()->get_MainSequence()->idx_get(0);
auto motion = ExplicitCast<IMotionEffect>(effect->get_Behaviors()->idx_get(0));

auto path = motion->get_Path();
for (auto segment : path)
{
    Console::WriteLine(u"{0}, relative: {1}", segment->get_CommandType(), segment->get_IsRelative());
    if (segment->get_Points() != nullptr)
        for (auto point : segment->get_Points())
            Console::WriteLine(u"X={0}, Y={1}", point.get_X(), point.get_Y());
}

presentation->Dispose();
```

Danh sách chứa một điểm bắt đầu, một đoạn thẳng tuyệt đối kết thúc ở (0.25, 0), và một lệnh End.

### **Thay đổi điểm cuối**

Mở `motion.pptx` và thay thế mảng điểm của đoạn thẳng để di chuyển điểm cuối của nó.

Trong tệp đầu vào, chỉ mục 0 là lệnh bắt đầu và chỉ mục 1 là đoạn thẳng. Thay thế điểm duy nhất của đoạn thẳng thay đổi đích của nó mà không thay đổi loại lệnh, thời gian hoặc vị trí trong bộ sưu tập. Vì lệnh sử dụng tọa độ tuyệt đối, cặp mới chỉ định một vị trí chứ không phải một độ lệch được cộng thêm.

```cpp
#include <DOM/Animation/IBehaviorCollection.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/IMotionCmdPath.h>
#include <DOM/Animation/IMotionEffect.h>
#include <DOM/Animation/IMotionPath.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <drawing/point_f.h>
#include <system/array.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>(u"motion.pptx");
auto effect = presentation->get_Slide(0)->get_Timeline()->get_MainSequence()->idx_get(0);

auto motion = ExplicitCast<IMotionEffect>(effect->get_Behaviors()->idx_get(0));
auto endpointPoints = MakeArray<PointF>({ PointF(0.4f, 0.1f) });
motion->get_Path()->idx_get(1)->set_Points(endpointPoints);

presentation->Save(u"motion-endpoint.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

Đoạn trong `motion-endpoint.pptx` kết thúc ở (0.4, 0.1); tệp gốc không thay đổi.

### **Thay thế đoạn**

Sử dụng [Insert](https://reference.aspose.com/slides/vi/cpp/aspose.slides.animation/imotionpath/insert/) và [RemoveAt](https://reference.aspose.com/slides/vi/cpp/aspose.slides.animation/imotionpath/removeat/) để thay thế đoạn thẳng trong `motion.pptx`. Việc chèn dịch đoạn thẳng cũ sang chỉ mục 2.

Điều này minh họa việc thay thế một đối tượng lệnh thay vì chỉnh sửa các tọa độ hiện có của nó. Sau khi chèn, bộ sưu tập tạm thời chứa lệnh bắt đầu, đoạn thẳng mới, đoạn thẳng cũ, và lệnh End. Xóa chỉ mục 2 loại bỏ đoạn thẳng cũ và để lại lộ trình mới.

```cpp
#include <DOM/Animation/IBehaviorCollection.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/IMotionCmdPath.h>
#include <DOM/Animation/IMotionEffect.h>
#include <DOM/Animation/IMotionPath.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/Animation/MotionCommandPathType.h>
#include <DOM/Animation/MotionPathPointsType.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <drawing/point_f.h>
#include <system/array.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>(u"motion.pptx");
auto effect = presentation->get_Slide(0)->get_Timeline()->get_MainSequence()->idx_get(0);
auto motion = ExplicitCast<IMotionEffect>(effect->get_Behaviors()->idx_get(0));

auto path = motion->get_Path();
auto linePoints = MakeArray<PointF>({ PointF(0.2f, 0.1f) });
path->Insert(1, MotionCommandPathType::LineTo, linePoints, MotionPathPointsType::Corner, false);
path->RemoveAt(2);

presentation->Save(u"motion-edited.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

Đường đã lưu vẫn có ba lệnh, với đoạn thẳng mới kết thúc ở (0.2, 0.1) và lệnh End ở cuối.

## **Sửa đổi và Xác minh hành vi hiện có**

Khi không biết chỉ mục của hành vi, hãy chọn nó theo loại. Ví dụ này mở `rotation.pptx`, tìm [IRotationEffect](https://reference.aspose.com/slides/vi/cpp/aspose.slides.animation/irotationeffect/), thay đổi góc, và kiểm tra giá trị đã lưu sau khi mở lại.

Kiểm tra loại cho phép vòng lặp bỏ qua các hành vi không phải xoay. Lần tải thứ hai đọc tệp đã lưu vào một đối tượng bản trình chiếu riêng, vì vậy việc so sánh kiểm tra dữ liệu đã được lưu thay vì giá trị còn trong bộ nhớ. Ví dụ này vẫn giả định hiệu ứng đã biết là đầu tiên trong chuỗi chính; chọn hành vi theo loại không định vị đúng hiệu ứng trong một bản trình chiếu tùy ý.

```cpp
#include <DOM/Animation/IBehaviorCollection.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/IRotationEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <cmath>
#include <system/console.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"rotation.pptx");
auto effect = presentation->get_Slide(0)->get_Timeline()->get_MainSequence()->idx_get(0);

for (auto behavior : effect->get_Behaviors())
{
    auto rotation = DynamicCast<IRotationEffect>(behavior);
    if (rotation != nullptr)
        rotation->set_By(180.0f);
}

presentation->Save(u"rotation-edited.pptx", SaveFormat::Pptx);

auto reopened = MakeObject<Presentation>(u"rotation-edited.pptx");
auto savedEffect = reopened->get_Slide(0)->get_Timeline()->get_MainSequence()->idx_get(0);

for (auto behavior : savedEffect->get_Behaviors())
{
    auto rotation = DynamicCast<IRotationEffect>(behavior);
    if (rotation != nullptr)
        Console::WriteLine(u"Rotation preserved: {0}", std::abs(rotation->get_By() - 180.0f) < 0.001f);
}

presentation->Dispose();
reopened->Dispose();
```

Kết quả là `Rotation preserved: True`. Áp dụng cùng mẫu kiểm tra kiểu cho các hành vi khác. Để kiểm tra bảo tồn đầy đủ, so sánh hình mục tiêu, hiệu ứng, loại và thứ tự hành vi, thời gian, và các lệnh đường. Sử dụng độ chênh lệch số cho các giá trị điểm nổi. Đối với bản trình chiếu có bố cục hoạt ảnh không xác định, xem [Đọc Hoạt ảnh Hình](/slides/vi/cpp/shape-animation/#read-shape-animations) để duyệt chuỗi chính và chuỗi tương tác.

## **Thứ tự hành vi, Preset và Phát lại**

Thứ tự trong [IBehaviorCollection](https://reference.aspose.com/slides/vi/cpp/aspose.slides.animation/ibehaviorcollection/) là thứ tự lưu trữ các thao tác của một hiệu ứng. Nó không phải là một danh sách phát mà mỗi hành vi tự động chờ hành vi trước. Thời gian và hiệu ứng bao bọc quyết định lịch trình. Các hành vi có thể chồng lên nhau, và các thao tác trên cùng một thuộc tính có thể tương tác qua [get_Additive](https://reference.aspose.com/slides/vi/cpp/aspose.slides.animation/ibehavior/get_additive/) và [get_Accumulate](https://reference.aspose.com/slides/vi/cpp/aspose.slides.animation/ibehavior/get_accumulate/). Không sử dụng chỉ việc sắp xếp lại bộ sưu tập để lên lịch “di chuyển, rồi xoay”; hãy dùng thời gian rõ ràng hoặc các hiệu ứng riêng như mô tả trong [Hoạt ảnh Hình](/slides/vi/cpp/shape-animation/).

[IEffect::get_Type](https://reference.aspose.com/slides/vi/cpp/aspose.slides.animation/ieffect/get_type/) và [IEffect::get_Subtype](https://reference.aspose.com/slides/vi/cpp/aspose.slides.animation/ieffect/get_subtype/) mô tả preset của nó. Chúng không phải là mô tả đầy đủ của cây hành vi đã chỉnh sửa. Chọn preset và subtype trước khi tùy chỉnh hành vi: thay đổi preset có thể xây dựng lại bộ sưu tập và loại bỏ các thao tác tùy chỉnh của bạn. Ví dụ, thay đổi một hiệu ứng Spin đã tùy chỉnh thành Fade có thể thay thế hành vi xoay bằng các hành vi đặt và bộ lọc. Kiểm tra lại bộ sưu tập sau khi thay đổi preset hoặc subtype. Xóa các hành vi preset cũng có thể loại bỏ các thao tác hiển thị hoặc khởi tạo mà preset cần. Các ví dụ cố ý sử dụng hình hiển thị và thay thế các hành vi; chúng không xây dựng lại toàn bộ triển khai của mỗi preset.

## **Tương thích định dạng**

Một cây hành vi được bảo tồn không đảm bảo phát lại giống nhau trong mọi trình xem hoặc bộ xuất. Kiểm tra dữ liệu đã lưu và kết quả render riêng biệt.

| Định dạng hoặc đầu ra | Cần xác minh |
| --- | --- |
| PPTX | Dùng làm định dạng chính cho các ví dụ này. Mở lại để xác minh cây hành vi có thể chỉnh sửa, sau đó kiểm tra phát lại trong phiên bản PowerPoint mong muốn. |
| PPT | Đại diện nhị phân legacy có thể khác so với PPTX. Thực hiện một vòng lưu‑mở‑lại riêng và kiểm tra phát lại; không suy ra hỗ trợ mọi tổ hợp tùy chỉnh chỉ từ kết quả PPTX thành công. |
| PDF, PNG, JPEG và các hình ảnh slide tĩnh khác | Chứa đại diện slide tĩnh, không phải một timeline hành vi có thể phát hoặc khung cuối hoạt ảnh được đảm bảo. |
| [HTML5](/slides/vi/cpp/export-to-html5/) | Có thể phát các hoạt ảnh được hỗ trợ khi bật hoạt ảnh hình trong tùy chọn xuất. Kiểm tra các tổ hợp tùy chỉnh trong trình duyệt. |
| [Animated GIF](/slides/vi/cpp/convert-powerpoint-to-animated-gif/) | Lưu các khung đã render, không phải các hành vi có thể chỉnh sửa hoặc tương tác bằng cú nhấn. Kiểm tra chuyển động thực tế đã render. |
| [Video](/slides/vi/cpp/convert-powerpoint-to-video/) | Render các khung hoạt ảnh và mã hoá chúng thành video. Hỗ trợ hạn chế đối với các [hoạt ảnh và hiệu ứng được hỗ trợ](/slides/vi/cpp/convert-powerpoint-to-video/#supported-animations-and-effects); các lệnh và sự kiện tương tác không trở thành một timeline có thể chỉnh sửa. |

## **Câu hỏi thường gặp**

**Tại sao hiệu ứng của tôi chứa các hành vi trước khi tôi thêm bất kỳ gì?**

Việc tạo một hiệu ứng được định trước có thể tạo ra các thao tác nền tảng của nó. Kiểm tra chúng trước khi quyết định mở rộng preset hoặc thay thế các hành vi.

**Việc di chuyển một hành vi lên đầu có làm nó phát trước không?**

Không nhất thiết. Thứ tự trong bộ sưu tập không thay thế cho thời gian. Kiểm tra độ trễ, thời lượng và tương tác giữa các thao tác trên cùng một thuộc tính.

**Tại sao lệnh End không có điểm?**

Nó đánh dấu kết thúc đường và không cần tọa độ. Khi kiểm tra một đường đọc từ tệp, hãy kiểm tra mảng điểm null.

**Một vòng quay thành công có đủ để xác nhận phát lại không?**

Không. Mở lại chỉ xác nhận việc bảo tồn các thuộc tính bạn đã kiểm tra. Hãy kiểm tra trình chiếu hoặc xuất động ảnh riêng để xác nhận hành vi trực quan của nó.