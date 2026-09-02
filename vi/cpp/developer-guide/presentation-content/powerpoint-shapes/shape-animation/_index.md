---
title: Áp dụng Hoạt Ảnh Hình trong Bản Trình Chiếu bằng C++
linktitle: Hoạt Ảnh Hình
type: docs
weight: 60
url: /vi/cpp/shape-animation/
keywords:
- hình
- hoạt ảnh
- hiệu ứng
- hình động
- văn bản động
- thêm hoạt ảnh
- lấy hoạt ảnh
- trích xuất hoạt ảnh
- thêm hiệu ứng
- lấy hiệu ứng
- trích xuất hiệu ứng
- âm thanh hiệu ứng
- áp dụng hoạt ảnh
- PowerPoint
- bản trình chiếu
- C++
- Aspose.Slides
description: "Học cách thêm, kiểm tra và tùy chỉnh hoạt ảnh hình, thời gian, âm thanh, hành vi sau hoạt ảnh và văn bản động với Aspose.Slides cho C++."
---
## **Tổng quan**

Aspose.Slides for C++ biểu diễn hoạt ảnh slide dưới dạng các hiệu ứng trong timeline của slide. Một hiệu ứng có hình mục tiêu, kiểu và phụ kiểu hoạt ảnh, một trigger, cài đặt thời gian, và các thuộc tính tùy chọn như âm thanh hoặc hành vi sau hoạt ảnh.

Timeline chứa hai loại chuỗi:

- **chuỗi chính** phát khi slide được chuyển tiếp.
- **chuỗi tương tác** bắt đầu khi hình trigger của nó được nhấp.

Vì các hộp văn bản, hình ảnh, biểu đồ, bảng và các đối tượng slide khác đều triển khai [IShape](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ishape/), bạn sử dụng cùng một phương pháp [ISequence::AddEffect](https://reference.aspose.com/slides/vi/cpp/aspose.slides.animation/isequence/addeffect/) cho hầu hết nội dung slide. Các hiệu ứng khả dụng được liệt kê trong kiểu liệt kê [EffectType](https://reference.aspose.com/slides/vi/cpp/aspose.slides.animation/effecttype/).

## **Thêm Hoạt Ảnh Cho Hình**

Để thêm một hoạt ảnh, lấy chuỗi chính của slide và gọi [ISequence::AddEffect](https://reference.aspose.com/slides/vi/cpp/aspose.slides.animation/isequence/addeffect/) với hình mục tiêu, kiểu hiệu ứng, phụ kiểu và trigger. Đối với hiệu ứng bắt đầu khi một hình khác được nhấp, tạo một chuỗi tương tác mà trigger là hình đó.

Ví dụ sau tạo cả hai loại hoạt ảnh và lưu kết quả vào `shape-animations.pptx`.

```cpp
#include <DOM/Animation/EffectSubtype.h>
#include <DOM/Animation/EffectTriggerType.h>
#include <DOM/Animation/EffectType.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/Animation/ISequenceCollection.h>
#include <DOM/Animation/ITiming.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto targetShape = slide->get_Shapes()->AddAutoShape(ShapeType::RoundCornerRectangle, 120.0f, 100.0f, 320.0f, 80.0f);
targetShape->get_TextFrame()->set_Text(u"Click to animate this shape");

auto mainSequence = slide->get_Timeline()->get_MainSequence();
auto entranceEffect = mainSequence->AddEffect(targetShape, EffectType::Fade, EffectSubtype::None, EffectTriggerType::OnClick);
entranceEffect->get_Timing()->set_Duration(1.5f);

auto triggerShape = slide->get_Shapes()->AddAutoShape(ShapeType::Bevel, 20.0f, 20.0f, 100.0f, 40.0f);
triggerShape->get_TextFrame()->set_Text(u"Move");

auto interactiveSequence = slide->get_Timeline()->get_InteractiveSequences()->Add(triggerShape);
interactiveSequence->AddEffect(targetShape, EffectType::PathFootball, EffectSubtype::None, EffectTriggerType::OnClick);

presentation->Save(u"shape-animations.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Trigger điều khiển thời điểm một hiệu ứng bắt đầu:

- [EffectTriggerType::OnClick](https://reference.aspose.com/slides/vi/cpp/aspose.slides.animation/effecttriggertype/) chờ một cú nhấp trong chuỗi chính, hoặc chờ một cú nhấp vào hình trigger trong chuỗi tương tác.
- [EffectTriggerType::WithPrevious](https://reference.aspose.com/slides/vi/cpp/aspose.slides.animation/effecttriggertype/) bắt đầu cùng với hiệu ứng trước.
- [EffectTriggerType::AfterPrevious](https://reference.aspose.com/slides/vi/cpp/aspose.slides.animation/effecttriggertype/) bắt đầu khi hiệu ứng trước kết thúc.

Để hoạt ảnh một hình ảnh, biểu đồ, hoặc một kiểu hình khác, truyền đối tượng đó vào [ISequence::AddEffect](https://reference.aspose.com/slides/vi/cpp/aspose.slides.animation/isequence/addeffect/) thay vì `targetShape`. Đối với các tùy chọn nhóm đặc thù cho biểu đồ, xem mục [Animated Charts](/slides/vi/cpp/animated-charts/).

## **Đọc Hoạt Ảnh Cho Hình**

Sử dụng [ISequence::GetEffectsByShape](https://reference.aspose.com/slides/vi/cpp/aspose.slides.animation/isequence/geteffectsbyshape/) khi bạn biết hình mục tiêu. Để kiểm tra mọi hiệu ứng, duyệt qua chuỗi chính và mọi chuỗi tương tác. Việc duyệt tránh việc giả định rằng một chuỗi có hiệu ứng ở chỉ mục `0`.

Ví dụ sau tạo một hình với các hiệu ứng chuỗi‑chính và chuỗi‑tương tác, lấy các hiệu ứng mục tiêu hình, rồi duyệt qua mọi chuỗi trên slide.

```cpp
#include <DOM/Animation/EffectSubtype.h>
#include <DOM/Animation/EffectTriggerType.h>
#include <DOM/Animation/EffectType.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/Animation/ISequenceCollection.h>
#include <DOM/Animation/ITiming.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/IAutoShape.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <system/console.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace System;

auto printSequence = [](const String& label, const SharedPtr<ISequence>& sequence)
{
    Console::WriteLine(String::Format(u"  {0}: {1} effect(s)", label, sequence->get_Count()));

    for (const auto& effect : sequence)
    {
        auto targetName = effect->get_TargetShape() == nullptr ? u"unknown" : effect->get_TargetShape()->get_Name();
        auto effectDescription = String::Format(u"{0} {1}; target: {2}; trigger: {3}", effect->get_Type(), effect->get_Subtype(), targetName, effect->get_Timing()->get_TriggerType());
        Console::WriteLine(u"    " + effectDescription);
    }
};

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto targetShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 120.0f, 100.0f, 320.0f, 80.0f);
targetShape->get_TextFrame()->set_Text(u"Animated shape");

auto mainSequence = slide->get_Timeline()->get_MainSequence();
mainSequence->AddEffect(targetShape, EffectType::Fade, EffectSubtype::None, EffectTriggerType::OnClick);

auto triggerShape = slide->get_Shapes()->AddAutoShape(ShapeType::Bevel, 20.0f, 20.0f, 100.0f, 40.0f);
triggerShape->get_TextFrame()->set_Text(u"Move");

auto interactiveSequence = slide->get_Timeline()->get_InteractiveSequences()->Add(triggerShape);
interactiveSequence->AddEffect(targetShape, EffectType::PathFootball, EffectSubtype::None, EffectTriggerType::OnClick);

auto targetEffects = mainSequence->GetEffectsByShape(targetShape);
Console::WriteLine(String::Format(u"The main sequence contains {0} effect(s) for {1}.", targetEffects->get_Length(), targetShape->get_Name()));

printSequence(u"Main sequence", mainSequence);

int32_t interactiveIndex = 1;
for (const auto& sequence : slide->get_Timeline()->get_InteractiveSequences())
{
    auto triggerName = sequence->get_TriggerShape() == nullptr ? u"unknown" : sequence->get_TriggerShape()->get_Name();
    auto sequenceLabel = String::Format(u"Interactive sequence {0}, trigger: {1}", interactiveIndex, triggerName);
    printSequence(sequenceLabel, sequence);
    interactiveIndex++;
}

presentation->Dispose();
```

Nếu bạn chỉ cần các hiệu ứng cho một hình, trước tiên xác định hình bằng tên, kiểu placeholder, hoặc thuộc tính ổn định khác; sau đó gọi [ISequence::GetEffectsByShape](https://reference.aspose.com/slides/vi/cpp/aspose.slides.animation/isequence/geteffectsbyshape/). Đừng giả định rằng [IShapeCollection::idx_get](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ishapecollection/idx_get/) ở chỉ mục `0` luôn là đối tượng mong muốn.

## **Làm Việc Với Hiệu Ứng Placeholder Kế Thừa**

Một placeholder trên slide bình thường có thể kế thừa hành vi hoạt ảnh từ placeholder tương ứng trên slide bố cục và slide master. [IShape::GetBasePlaceholder](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ishape/getbaseplaceholder/) trả về placeholder cha đó, hoặc `nullptr` khi không có cha.

Trong bản trình chiếu mẫu dưới đây, phần chân trang có **Random Bars** trên slide bình thường, **Split** trên slide bố cục, và **Fly In** trên slide master.

![Footer animation effect on the normal slide](slide-shape-animation.png)

![Footer placeholder animation effect on the layout slide](layout-shape-animation.png)

![Footer placeholder animation effect on the master slide](master-shape-animation.png)

Ví dụ tiếp theo tự xây dựng cấu trúc placeholder. Nó thêm hiệu ứng vào một placeholder master, một placeholder layout, và placeholder tương ứng trên slide bình thường. Mọi lần gọi [IShape::GetBasePlaceholder](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ishape/getbaseplaceholder/) đều được kiểm tra trước khi sử dụng hình trả về.

```cpp
#include <DOM/Animation/EffectSubtype.h>
#include <DOM/Animation/EffectTriggerType.h>
#include <DOM/Animation/EffectType.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/IAutoShape.h>
#include <DOM/IGlobalLayoutSlideCollection.h>
#include <DOM/ILayoutPlaceholderManager.h>
#include <DOM/ILayoutSlide.h>
#include <DOM/IMasterSlide.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/SlideLayoutType.h>
#include <Export/SaveFormat.h>
#include <system/array.h>
#include <system/console.h>
#include <system/exceptions.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;
using namespace System;

auto findPlaceholderWithBase = [](const SharedPtr<ISlide>& slide) -> SharedPtr<IShape>
{
    for (const auto& shape : slide->get_Shapes())
    {
        if (shape->GetBasePlaceholder() != nullptr)
            return shape;
    }

    return nullptr;
};

auto printEffects = [](const String& source, const ArrayPtr<SharedPtr<IEffect>>& effects)
{
    Console::WriteLine(String::Format(u"{0}: {1} effect(s)", source, effects->get_Length()));

    for (const auto& effect : effects)
        Console::WriteLine(String::Format(u"  {0} {1}", effect->get_Type(), effect->get_Subtype()));
};

auto presentation = MakeObject<Presentation>();
auto layoutSlide = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);
auto layoutPlaceholder = layoutSlide->get_PlaceholderManager()->AddTextPlaceholder(100.0f, 100.0f, 400.0f, 80.0f);
layoutSlide->get_Timeline()->get_MainSequence()->AddEffect(layoutPlaceholder, EffectType::Split, EffectSubtype::VerticalIn, EffectTriggerType::OnClick);

auto masterPlaceholder = layoutPlaceholder->GetBasePlaceholder();
if (masterPlaceholder != nullptr)
{
    auto masterSequence = layoutSlide->get_MasterSlide()->get_Timeline()->get_MainSequence();
    masterSequence->AddEffect(masterPlaceholder, EffectType::Fly, EffectSubtype::Bottom, EffectTriggerType::OnClick);
}

auto slide = presentation->get_Slides()->AddEmptySlide(layoutSlide);
auto slidePlaceholder = findPlaceholderWithBase(slide);

if (slidePlaceholder == nullptr)
    throw InvalidOperationException(u"The slide does not contain a placeholder linked to its layout slide.");

slide->get_Timeline()->get_MainSequence()->AddEffect(slidePlaceholder, EffectType::RandomBars, EffectSubtype::Horizontal, EffectTriggerType::OnClick);
printEffects(u"Normal slide", slide->get_Timeline()->get_MainSequence()->GetEffectsByShape(slidePlaceholder));

auto baseLayoutPlaceholder = slidePlaceholder->GetBasePlaceholder();
if (baseLayoutPlaceholder != nullptr)
{
    printEffects(u"Layout slide", layoutSlide->get_Timeline()->get_MainSequence()->GetEffectsByShape(baseLayoutPlaceholder));

    auto baseMasterPlaceholder = baseLayoutPlaceholder->GetBasePlaceholder();
    if (baseMasterPlaceholder != nullptr)
        printEffects(u"Master slide", layoutSlide->get_MasterSlide()->get_Timeline()->get_MainSequence()->GetEffectsByShape(baseMasterPlaceholder));
}

presentation->Save(u"placeholder-animations.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Thay Đổi Thời Gian Hoạt Ảnh**

Hộp thoại PowerPoint **Timing** tương ứng với các phương pháp của [ITiming](https://reference.aspose.com/slides/vi/cpp/aspose.slides.animation/itiming/).

![PowerPoint Timing dialog for an animation effect](shape-animation.png)

- **Start** tương ứng với [ITiming::set_TriggerType](https://reference.aspose.com/slides/vi/cpp/aspose.slides.animation/itiming/set_triggertype/).
- **Duration** tương ứng với [ITiming::set_Duration](https://reference.aspose.com/slides/vi/cpp/aspose.slides.animation/itiming/set_duration/), tính bằng giây.
- **Delay** tương ứng với [ITiming::set_TriggerDelayTime](https://reference.aspose.com/slides/vi/cpp/aspose.slides.animation/itiming/set_triggerdelaytime/), tính bằng giây.
- **Repeat** tương ứng với [ITiming::set_RepeatCount](https://reference.aspose.com/slides/vi/cpp/aspose.slides.animation/itiming/set_repeatcount/), [ITiming::set_RepeatUntilNextClick](https://reference.aspose.com/slides/vi/cpp/aspose.slides.animation/itiming/set_repeatuntilnextclick/), hoặc [ITiming::set_RepeatUntilEndSlide](https://reference.aspose.com/slides/vi/cpp/aspose.slides.animation/itiming/set_repeatuntilendslide/).
- **Rewind when done playing** tương ứng với [ITiming::set_Rewind](https://reference.aspose.com/slides/vi/cpp/aspose.slides.animation/itiming/set_rewind/).

Ví dụ độc lập này thêm một hiệu ứng, thay đổi thời gian của nó thông qua đối tượng trả về bởi [ISequence::AddEffect](https://reference.aspose.com/slides/vi/cpp/aspose.slides.animation/isequence/addeffect/), và lưu kết quả. Giữ tham chiếu đến [IEffect](https://reference.aspose.com/slides/vi/cpp/aspose.slides.animation/ieffect/) trả về tránh việc phải truy cập chỉ mục bộ sưu tập không cần thiết.

```cpp
#include <DOM/Animation/EffectSubtype.h>
#include <DOM/Animation/EffectTriggerType.h>
#include <DOM/Animation/EffectType.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/Animation/ITiming.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 120.0f, 100.0f, 320.0f, 80.0f);
shape->get_TextFrame()->set_Text(u"Timed animation");

auto effect = slide->get_Timeline()->get_MainSequence()->AddEffect(shape, EffectType::Fade, EffectSubtype::None, EffectTriggerType::OnClick);
effect->get_Timing()->set_TriggerType(EffectTriggerType::OnClick);
effect->get_Timing()->set_Duration(2.0f);
effect->get_Timing()->set_TriggerDelayTime(0.5f);
effect->get_Timing()->set_RepeatUntilNextClick(false);
effect->get_Timing()->set_RepeatUntilEndSlide(false);
effect->get_Timing()->set_RepeatCount(2.0f);
effect->get_Timing()->set_Rewind(true);

presentation->Save(u"shape-animation-timing.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Sử dụng một chế độ lặp duy nhất. Kết hợp số lần lặp với cờ “until” có thể tạo ra kết quả gây nhầm lẫn trong các trình xem khác nhau. Khi thay đổi chế độ lặp, gọi trước [ITiming::set_RepeatUntilNextClick](https://reference.aspose.com/slides/vi/cpp/aspose.slides.animation/itiming/set_repeatuntilnextclick/) và [ITiming::set_RepeatUntilEndSlide](https://reference.aspose.com/slides/vi/cpp/aspose.slides.animation/itiming/set_repeatuntilendslide/) rồi mới đến [ITiming::set_RepeatCount](https://reference.aspose.com/slides/vi/cpp/aspose.slides.animation/itiming/set_repeatcount/), vì việc đặt bất kỳ cờ nào cũng sẽ thay đổi chế độ lặp đang hoạt động.

## **Thêm và Trích Xuất Âm Thanh Hoạt Ảnh**

Một hiệu ứng hoạt ảnh có thể tham chiếu âm thanh nhúng thông qua [IEffect::set_Sound](https://reference.aspose.com/slides/vi/cpp/aspose.slides.animation/ieffect/set_sound/). [IEffect::set_StopPreviousSound](https://reference.aspose.com/slides/vi/cpp/aspose.slides.animation/ieffect/set_stopprevioussound/) chỉ định hiệu ứng dừng âm thanh đã được một hiệu ứng trước đó khởi động.

### **Thêm Âm Thanh Vào Hiệu Ứng**

Ví dụ dưới đây yêu cầu một tệp âm thanh cục bộ tên `animation-sound.wav`. Nó tạo hai hiệu ứng, nhúng tệp đó làm âm thanh cho hiệu ứng thứ nhất, và cấu hình hiệu ứng thứ hai để dừng âm thanh. Nó sử dụng các đối tượng trả về bởi [ISequence::AddEffect](https://reference.aspose.com/slides/vi/cpp/aspose.slides.animation/isequence/addeffect/), vì vậy không cần chỉ mục chuỗi.

```cpp
#include <DOM/Animation/EffectSubtype.h>
#include <DOM/Animation/EffectTriggerType.h>
#include <DOM/Animation/EffectType.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/IAudio.h>
#include <DOM/IAudioCollection.h>
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto firstShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 80.0f, 100.0f, 240.0f, 80.0f);
auto secondShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 400.0f, 100.0f, 240.0f, 80.0f);
firstShape->get_TextFrame()->set_Text(u"Starts sound");
secondShape->get_TextFrame()->set_Text(u"Stops sound");

auto sequence = slide->get_Timeline()->get_MainSequence();
auto firstEffect = sequence->AddEffect(firstShape, EffectType::Fade, EffectSubtype::None, EffectTriggerType::OnClick);
auto secondEffect = sequence->AddEffect(secondShape, EffectType::Fade, EffectSubtype::None, EffectTriggerType::OnClick);

auto audioData = File::ReadAllBytes(u"animation-sound.wav");
auto effectSound = presentation->get_Audios()->AddAudio(audioData);
firstEffect->set_Sound(effectSound);
secondEffect->set_StopPreviousSound(true);

presentation->Save(u"shape-animation-sound.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

### **Trích Xuất Âm Thanh Nhúng Của Hiệu Ứng**

Ví dụ dưới đây yêu cầu một bản trình chiếu cục bộ tên `presentation-with-animation-sounds.pptx`. Nó quét cả chuỗi chính và chuỗi tương tác và ghi mọi âm thanh hiệu ứng nhúng vào thư mục `extracted-animation-sounds`. Phần mở rộng được chọn dựa trên MIME type âm thanh được cung cấp bởi [IAudio::get_ContentType](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iaudio/get_contenttype/).

```cpp
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/Animation/ISequenceCollection.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/IAudio.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/io/directory.h>
#include <system/io/file.h>
#include <system/io/path.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace System;
using namespace System::IO;

auto getAudioExtension = [](const String& contentType)
{
    auto normalizedType = String::IsNullOrEmpty(contentType) ? String::Empty : contentType.ToLowerInvariant();

    if (normalizedType == u"audio/mpeg")
        return String(u".mp3");

    if (normalizedType == u"audio/mp4")
        return String(u".m4a");

    if (normalizedType == u"audio/ogg")
        return String(u".ogg");

    if (normalizedType == u"audio/wav" || normalizedType == u"audio/x-wav")
        return String(u".wav");

    return String(u".bin");
};

auto saveSounds = [&getAudioExtension](const SharedPtr<ISequence>& sequence, const String& outputDirectory, int32_t& soundIndex)
{
    for (const auto& effect : sequence)
    {
        if (effect->get_Sound() == nullptr)
            continue;

        auto extension = getAudioExtension(effect->get_Sound()->get_ContentType());
        auto outputPath = Path::Combine(outputDirectory, String::Format(u"effect-sound-{0}{1}", soundIndex, extension));
        File::WriteAllBytes(outputPath, effect->get_Sound()->get_BinaryData());
        soundIndex++;
    }
};

auto inputPath = String(u"presentation-with-animation-sounds.pptx");
auto outputDirectory = String(u"extracted-animation-sounds");

Directory::CreateDirectory_(outputDirectory);

auto presentation = MakeObject<Presentation>(inputPath);
int32_t soundIndex = 1;

for (const auto& slide : presentation->get_Slides())
{
    saveSounds(slide->get_Timeline()->get_MainSequence(), outputDirectory, soundIndex);

    for (const auto& sequence : slide->get_Timeline()->get_InteractiveSequences())
        saveSounds(sequence, outputDirectory, soundIndex);
}

Console::WriteLine(String::Format(u"Extracted {0} sound file(s) to {1}.", soundIndex - 1, Path::GetFullPath(outputDirectory)));
presentation->Dispose();
```

Đối với các đối tượng âm thanh lớn, sử dụng [IAudio::GetStream](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iaudio/getstream/) và sao chép luồng vào tệp thay vì tải toàn bộ đối tượng vào mảng byte.

## **Đặt Hành Vi Sau Hoạt Ảnh**

Tùy chọn **After animation** điều khiển điều gì xảy ra với một hình sau khi hiệu ứng của nó kết thúc.

![PowerPoint Effect Options dialog showing After animation settings](shape-after-animation.png)

Kiểu liệt kê [AfterAnimationType](https://reference.aspose.com/slides/vi/cpp/aspose.slides.animation/afteranimationtype/) hỗ trợ để lại hình không thay đổi, thay đổi màu, ẩn nó sau hoạt ảnh, hoặc ẩn nó khi nhấp tiếp theo. Khi kiểu là [AfterAnimationType::Color](https://reference.aspose.com/slides/vi/cpp/aspose.slides.animation/afteranimationtype/), gọi [IEffect::get_AfterAnimationColor](https://reference.aspose.com/slides/vi/cpp/aspose.slides.animation/ieffect/get_afteranimationcolor/) để thiết lập màu.

Ví dụ độc lập này tạo một hiệu ứng, đặt hành vi sau‑hoạt ảnh thông qua đối tượng hiệu ứng trả về, và lưu kết quả.

```cpp
#include <DOM/Animation/AfterAnimationType.h>
#include <DOM/Animation/EffectSubtype.h>
#include <DOM/Animation/EffectTriggerType.h>
#include <DOM/Animation/EffectType.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
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
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 120.0f, 100.0f, 320.0f, 80.0f);
shape->get_TextFrame()->set_Text(u"Dim after animation");

auto effect = slide->get_Timeline()->get_MainSequence()->AddEffect(shape, EffectType::Fade, EffectSubtype::None, EffectTriggerType::OnClick);
effect->set_AfterAnimationType(AfterAnimationType::Color);
effect->get_AfterAnimationColor()->set_Color(Color::get_LightGray());

presentation->Save(u"shape-animation-after-effect.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Thay đổi kiểu khỏi [AfterAnimationType::Color](https://reference.aspose.com/slides/vi/cpp/aspose.slides.animation/afteranimationtype/) sẽ xóa cài đặt màu sau‑hoạt ảnh.

## **Hoạt Ảnh Văn Bản**

Hoạt ảnh văn bản có hai điều khiển liên quan:

- [ITextAnimation::set_BuildType](https://reference.aspose.com/slides/vi/cpp/aspose.slides.animation/itextanimation/set_buildtype/) kiểm soát việc các đoạn văn xuất hiện cùng nhau hay theo mức độ đoạn.
- [IEffect::set_AnimateTextType](https://reference.aspose.com/slides/vi/cpp/aspose.slides.animation/ieffect/set_animatetexttype/) kiểm soát việc văn bản xuất hiện một lần, theo từ, hoặc theo ký tự. [IEffect::set_DelayBetweenTextParts](https://reference.aspose.com/slides/vi/cpp/aspose.slides.animation/ieffect/set_delaybetweentextparts/) đặt độ trễ giữa các từ hoặc ký tự. Giá trị dương là phần trăm của thời lượng hiệu ứng; giá trị âm là độ trễ tính bằng giây.

Ví dụ độc lập dưới đây hoạt ảnh các từ trong một hộp văn bản. [BuildType::AsOneObject](https://reference.aspose.com/slides/vi/cpp/aspose.slides.animation/buildtype/) vô hiệu hoá việc xây dựng theo đoạn, vì vậy cài đặt từ áp dụng cho toàn bộ khung văn bản.

```cpp
#include <DOM/Animation/AnimateTextType.h>
#include <DOM/Animation/BuildType.h>
#include <DOM/Animation/EffectSubtype.h>
#include <DOM/Animation/EffectTriggerType.h>
#include <DOM/Animation/EffectType.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/Animation/ITextAnimation.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto textBox = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 80.0f, 80.0f, 560.0f, 100.0f);
textBox->get_TextFrame()->set_Text(u"Aspose.Slides animates this sentence word by word.");

auto effect = slide->get_Timeline()->get_MainSequence()->AddEffect(textBox, EffectType::Fade, EffectSubtype::None, EffectTriggerType::OnClick);
effect->get_TextAnimation()->set_BuildType(BuildType::AsOneObject);
effect->set_AnimateTextType(AnimateTextType::ByWord);
effect->set_DelayBetweenTextParts(20.0f);

presentation->Save(u"animated-text.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Để xây dựng một hộp văn bản theo đoạn, sử dụng [ITextAnimation::set_BuildType](https://reference.aspose.com/slides/vi/cpp/aspose.slides.animation/itextanimation/set_buildtype/) với [BuildType::ByLevelParagraphs1](https://reference.aspose.com/slides/vi/cpp/aspose.slides.animation/buildtype/) hoặc mức độ đoạn khác. Để đặt một đoạn riêng biệt với hiệu ứng riêng, sử dụng phương thức overload của [ISequence::AddEffect](https://reference.aspose.com/slides/vi/cpp/aspose.slides.animation/isequence/addeffect/) nhận một [IParagraph](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iparagraph/). Xem mục [Animated Text](/slides/vi/cpp/animated-text/) để có các ví dụ cấp đoạn.

## **Xuất Và Lưu Ý Tương Thích**

- Lưu dưới dạng PPT hoặc PPTX giữ nguyên mô hình hoạt ảnh, nhưng việc phát lại cuối cùng do trình xem bản trình chiếu điều khiển.
- PDF và hình ảnh tĩnh không phát hoạt ảnh. Sử dụng [HTML5 export](/slides/vi/cpp/export-to-html5/), GIF động, hoặc [video conversion](/slides/vi/cpp/convert-powerpoint-to-video/) khi đầu ra phải hiển thị chuyển động.
- Đối với HTML5, bật [Html5Options::set_AnimateShapes](https://reference.aspose.com/slides/vi/cpp/aspose.slides.export/html5options/set_animateshapes/) và, khi cần, [Html5Options::set_AnimateTransitions](https://reference.aspose.com/slides/vi/cpp/aspose.slides.export/html5options/set_animatetransitions/).
- Kết xuất video hỗ trợ nhiều hiệu ứng vào, nhấn mạnh, ra, và đường chuyển động phổ biến, nhưng không phải mọi hiệu ứng PowerPoint đều được hỗ trợ. Kiểm tra mục [supported animations and effects](/slides/vi/cpp/convert-powerpoint-to-video/#supported-animations-and-effects) hiện tại và kiểm thử các bản trình chiếu quan trọng với phiên bản Aspose.Slides bạn dùng.
- Các hiệu ứng tùy chỉnh nâng cao và các hiệu ứng được nhập từ định dạng bản trình chiếu khác có thể được lưu trong tệp nhưng hiển thị khác nhau trong PowerPoint, HTML5, hoặc video. Xác thực kết quả xuất thay vì chỉ dựa vào tên hiệu ứng.

## **Câu Hỏi Thường Gặp**

**Tại sao một hoạt ảnh xuất hiện trong PowerPoint mà không xuất hiện trong PDF?**

PDF là định dạng tĩnh, vì vậy hoạt ảnh và chuyển đổi slide không được phát. Xuất sang HTML5, GIF động, hoặc video khi cần giữ chuyển động.

**Tại sao một hiệu ứng hiển thị khác nhau trong video?**

Xuất video render hoạt ảnh thay vì lưu hành vi gốc của PowerPoint. Một số hiệu ứng nâng cao không được hỗ trợ hoặc chỉ được ước tính. Kiểm tra bảng hiệu ứng được hỗ trợ và thử nghiệm bản trình chiếu thực tế trước khi đưa vào sản xuất.

**Di chuyển một hình lên phía trước hoặc phía sau có thay đổi thứ tự hoạt ảnh không?**

Không. Z‑order của hình chỉ điều khiển chồng lớp, trong khi thứ tự chuỗi và trigger điều khiển việc phát hoạt ảnh. Thay đổi timeline nếu bạn cần một thứ tự phát khác.