---
title: اعمال انیمیشن‌های شکل در ارائه‌ها با استفاده از C++
linktitle: انیمیشن شکل
type: docs
weight: 60
url: /fa/cpp/shape-animation/
keywords:
- شکل
- انیمیشن
- اثر
- شکل متحرک
- متن متحرک
- افزودن انیمیشن
- دریافت انیمیشن
- استخراج انیمیشن
- افزودن اثر
- دریافت اثر
- استخراج اثر
- صدای اثر
- اعمال انیمیشن
- PowerPoint
- ارائه
- C++
- Aspose.Slides
description: "نحوهٔ افزودن، بازرسی و سفارشی‌سازی انیمیشن‌های شکل، زمان‌بندی، صداها، رفتار پس از انیمیشن و متن متحرک را با Aspose.Slides برای C++ بیاموزید."
---
## **نمای کلی**

برای کار با رفتارهای فردی داخل یک افکت یا ویرایش بخش‌های مسیر حرکتی، به [انیمیشن سفارشی](/slides/fa/cpp/custom-animation/) مراجعه کنید.

Aspose.Slides for C++ انیمیشن‌های اسلاید را به‌عنوان افکت‌ها در جدول زمان‌بندی اسلاید نمایش می‌دهد. یک افکت شامل شکل هدف، نوع و زیرنوع انیمیشن، یک محرک، تنظیمات زمان‌بندی، و ویژگی‌های اختیاری مانند صدا یا رفتار پس از انیمیشن است.

جدول زمان‌بندی دو نوع توالی را در بر می‌گیرد:

- توالی **اصلی** هنگام پیشروی اسلاید اجرا می‌شود.
- توالی **تعاملی** زمانی شروع می‌شود که شکل محرک آن کلیک شود.

از آنجا که جعبه‌های متن، تصاویر، نمودارها، جداول و سایر اشیای اسلاید پیاده‌سازی [IShape](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ishape/) را انجام می‌دهند، برای اکثر محتوای اسلاید از همان متد [ISequence::AddEffect](https://reference.aspose.com/slides/fa/cpp/aspose.slides.animation/isequence/addeffect/) استفاده می‌کنید. افکت‌های موجود در شمارش‌گر [EffectType](https://reference.aspose.com/slides/fa/cpp/aspose.slides.animation/effecttype/) فهرست شده‌اند.

## **افزودن انیمیشن‌های شکل**

برای افزودن یک انیمیشن، توالی اصلی اسلاید را دریافت کنید و متد [ISequence::AddEffect](https://reference.aspose.com/slides/fa/cpp/aspose.slides.animation/isequence/addeffect/) را با شکل هدف، نوع افکت، زیرنوع و محرک صدا بزنید. برای افکتی که هنگام کلیک بر روی شکل دیگری شروع می‌شود، توالی تعاملی‌ای ایجاد کنید که محرکش همان شکل دیگر باشد.

مثال زیر هر دو نوع انیمیشن را ایجاد می‌کند و نتیجه را در `shape-animations.pptx` ذخیره می‌نماید.

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

محرک تعیین می‌کند افکت چه زمانی شروع شود:

- [EffectTriggerType::OnClick](https://reference.aspose.com/slides/fa/cpp/aspose.slides.animation/effecttriggertype/) برای کلیک در توالی اصلی یا کلیک بر روی شکل محرک در توالی تعاملی صبر می‌کند.
- [EffectTriggerType::WithPrevious](https://reference.aspose.com/slides/fa/cpp/aspose.slides.animation/effecttriggertype/) همراه با اثر قبلی شروع می‌شود.
- [EffectTriggerType::AfterPrevious](https://reference.aspose.com/slides/fa/cpp/aspose.slides.animation/effecttriggertype/) زمانی که اثر قبلی تمام شد، شروع می‌شود.

برای انیمیشن یک تصویر، نمودار یا نوع دیگری از شکل، به جای `targetShape` همان شیء را به متد [ISequence::AddEffect](https://reference.aspose.com/slides/fa/cpp/aspose.slides.animation/isequence/addeffect/) پاس دهید. برای گزینه‌های گروه‌بندی مخصوص نمودارها، به [Animated Charts](/slides/fa/cpp/animated-charts/) مراجعه کنید.

## **خواندن انیمیشن‌های شکل**

از [ISequence::GetEffectsByShape](https://reference.aspose.com/slides/fa/cpp/aspose.slides.animation/isequence/geteffectsbyshape/) زمانی که شکل هدف را می‌دانید استفاده کنید. برای بررسی هر افکت، توالی اصلی و هر توالی تعاملی را enumeration کنید. enumeration از این فرض جلوگیری می‌کند که توالی دارای افکتی در ایندکس `0` باشد.

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

اگر فقط به افکت‌های یک شکل نیاز دارید، ابتدا شکل را بر اساس نام، نوع placeholder یا ویژگی پایدار دیگری شناسایی کنید؛ سپس متد [ISequence::GetEffectsByShape](https://reference.aspose.com/slides/fa/cpp/aspose.slides.animation/isequence/geteffectsbyshape/) را فراخوانی کنید. فرض نکنید که [IShapeCollection::idx_get](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ishapecollection/idx_get/) در ایندکس `0` همیشه شیء مورد نظر است.

## **کار با افکت‌های حامل به ارث‌برده**

یک placeholder در یک اسلاید عادی می‌تواند رفتار انیمیشن را از placeholder متناظر در اسلاید طرح‌بندی و اسلاید اصلی به ارث ببرد. [IShape::GetBasePlaceholder](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ishape/getbaseplaceholder/) آن placeholder والد را باز می‌گرداند یا `nullptr` زمانی که والد وجود نداشته باشد.

در ارائهٔ مثال زیر، پاورقی در اسلاید عادی دارای **Random Bars**، در اسلاید طرح‌بندی **Split** و در اسلاید اصلی **Fly In** دارد.

![افکت انیمیشن پاورقی در اسلاید معمولی](slide-shape-animation.png)

![افکت انیمیشن حامل پاورقی در اسلاید طرح‌بندی](layout-shape-animation.png)

![افکت انیمیشن حامل پاورقی در اسلاید اصلی](master-shape-animation.png)

مثال بعدی خود سلسله‌مراتبۀ placeholder را می‌سازد. افکت‌هایی به یک placeholder اصلی، یک placeholder طرح‌بندی و placeholder متناظر در اسلاید عادی اضافه می‌کند. قبل از استفاده از شکل برگردانده شده، هر بار فراخوانی [IShape::GetBasePlaceholder](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ishape/getbaseplaceholder/) بررسی می‌شود.

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

## **تغییر زمان‌بندی انیمیشن**

دیالوگ **Timing** پاورپوینت به متدهای [ITiming](https://reference.aspose.com/slides/fa/cpp/aspose.slides.animation/itiming/) مطابقت دارد.

![دیالوگ تنظیم زمان‌بندی پاورپوینت برای یک افکت انیمیشن](shape-animation.png)

- **Start** به [ITiming::set_TriggerType](https://reference.aspose.com/slides/fa/cpp/aspose.slides.animation/itiming/set_triggertype/) مطابقت دارد.
- **Duration** به [ITiming::set_Duration](https://reference.aspose.com/slides/fa/cpp/aspose.slides.animation/itiming/set_duration/) مطابقت دارد، بر حسب ثانیه.
- **Delay** به [ITiming::set_TriggerDelayTime](https://reference.aspose.com/slides/fa/cpp/aspose.slides.animation/itiming/set_triggerdelaytime/) مطابقت دارد، بر حسب ثانیه.
- **Repeat** به [ITiming::set_RepeatCount](https://reference.aspose.com/slides/fa/cpp/aspose.slides.animation/itiming/set_repeatcount/)، [ITiming::set_RepeatUntilNextClick](https://reference.aspose.com/slides/fa/cpp/aspose.slides.animation/itiming/set_repeatuntilnextclick/) یا [ITiming::set_RepeatUntilEndSlide](https://reference.aspose.com/slides/fa/cpp/aspose.slides.animation/itiming/set_repeatuntilendslide/) مطابقت دارد.
- **Rewind when done playing** به [ITiming::set_Rewind](https://reference.aspose.com/slides/fa/cpp/aspose.slides.animation/itiming/set_rewind/) مطابقت دارد.

این مثال مستقل یک افکت اضافه می‌کند، زمان‌بندی آن را از طریق شیء بازگردانده‌شده توسط [ISequence::AddEffect](https://reference.aspose.com/slides/fa/cpp/aspose.slides.animation/isequence/addeffect/) تغییر می‌دهد و نتیجه را ذخیره می‌کند. نگه‌داشتن مرجع بازگردانده‌شدهٔ [IEffect](https://reference.aspose.com/slides/fa/cpp/aspose.slides.animation/ieffect/) از نیاز به ایندکس مجموعهٔ غیرضروری جلوگیری می‌کند.

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

یک حالت تکرار را به‌صورت عمدی استفاده کنید. ترکیب شمارش تکرار با پرچم «until» می‌تواند نتایج گمراه‌کننده‌ای در نمایشگرهای مختلف ایجاد کند. هنگام تغییر حالت‌های تکرار، ابتدا [ITiming::set_RepeatUntilNextClick](https://reference.aspose.com/slides/fa/cpp/aspose.slides.animation/itiming/set_repeatuntilnextclick/) و [ITiming::set_RepeatUntilEndSlide](https://reference.aspose.com/slides/fa/cpp/aspose.slides.animation/itiming/set_repeatuntilendslide/) را فراخوانی کنید و سپس [ITiming::set_RepeatCount](https://reference.aspose.com/slides/fa/cpp/aspose.slides.animation/itiming/set_repeatcount/) را تنظیم کنید، زیرا تنظیم هر کدام از پرچم‌ها حالت تکرار فعال را نیز تغییر می‌دهد.

## **افزودن و استخراج صداهای انیمیشن**

یک افکت انیمیشن می‌تواند صوت تعبیه‌شده را از طریق [IEffect::set_Sound](https://reference.aspose.com/slides/fa/cpp/aspose.slides.animation/ieffect/set_sound/) ارجاع دهد. [IEffect::set_StopPreviousSound](https://reference.aspose.com/slides/fa/cpp/aspose.slides.animation/ieffect/set_stopprevioussound/) به یک افکت می‌گوید صداهایی را که توسط افکت قبلی شروع شده‌اند، متوقف کند.

### **افزودن صدا به یک افکت**

مثال زیر انتظار دارد فایلی صوتی محلی با نام `animation-sound.wav` موجود باشد. دو افکت ایجاد می‌کند، آن فایل را به‌عنوان صدا برای اولین افکت تعبیه می‌کند و افکت دوم را تنظیم می‌کند تا صدا را متوقف کند. این مثال از اشیائی که توسط [ISequence::AddEffect](https://reference.aspose.com/slides/fa/cpp/aspose.slides.animation/isequence/addeffect/) بازگردانده می‌شوند استفاده می‌کند، بنابراین نیازی به ایندکس توالی نیست.

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

### **استخراج صداهای تعبیه‌شدهٔ افکت**

مثال زیر انتظار دارد ارائهٔ محلی با نام `presentation-with-animation-sounds.pptx` موجود باشد. هر دو توالی اصلی و تعاملی را اسکن می‌کند و هر صداهای تعبیه‌شدهٔ افکت را در پوشهٔ `extracted-animation-sounds` می‌نویسد. پسوند بر اساس نوع MIME صوتی که توسط [IAudio::get_ContentType](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iaudio/get_contenttype/) مشخص می‌شود، انتخاب می‌گردد.

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

برای اشیای صوتی بزرگ، از [IAudio::GetStream](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iaudio/getstream/) استفاده کنید و جریان را به یک فایل کپی کنید به‌جای اینکه کل شیء را به‌صورت آرایه بایت بارگذاری کنید.

## **تنظیم رفتار پس از انیمیشن**

گزینه **After animation** تعیین می‌کند پس از پایان اثر، چه عملی بر روی شکل انجام شود.

![دیالوگ گزینه‌های اثر پاورپوینت که تنظیمات پس از انیمیشن را نشان می‌دهد](shape-after-animation.png)

شمارش‌گر [AfterAnimationType](https://reference.aspose.com/slides/fa/cpp/aspose.slides.animation/afteranimationtype/) امکان ترک شکل به‌همین‌صورت، تغییر رنگ آن، مخفی کردن پس از انیمیشن یا مخفی کردن آن در کلیک بعدی را فراهم می‌کند. وقتی نوع به [AfterAnimationType::Color](https://reference.aspose.com/slides/fa/cpp/aspose.slides.animation/afteranimationtype/) تنظیم شده باشد، برای تنظیم رنگ نیز باید از [IEffect::get_AfterAnimationColor](https://reference.aspose.com/slides/fa/cpp/aspose.slides.animation/ieffect/get_afteranimationcolor/) استفاده کنید.

این مثال مستقل یک افکت ایجاد می‌کند، رفتار پس از انیمیشن را از طریق شیء بازگرداندهٔ افکت تنظیم می‌کند و نتیجه را ذخیره می‌کند.

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

تغییر نوع از [AfterAnimationType::Color](https://reference.aspose.com/slides/fa/cpp/aspose.slides.animation/afteranimationtype/) تنظیم رنگ پس از انیمیشن را پاک می‌کند.

## **انیمیشن متن**

انیمیشن متن دو کنترل مرتبط دارد:

- [ITextAnimation::set_BuildType](https://reference.aspose.com/slides/fa/cpp/aspose.slides.animation/itextanimation/set_buildtype/) تعیین می‌کند آیا پاراگراف‌ها به‌صورت جمعی یا بر پایهٔ سطح پاراگراف ظاهر شوند.
- [IEffect::set_AnimateTextType](https://reference.aspose.com/slides/fa/cpp/aspose.slides.animation/ieffect/set_animatetexttype/) تعیین می‌کند متن به‌صورت یکجا، به‌صورت کلمه یا به‌صورت حرف ظاهر شود. [IEffect::set_DelayBetweenTextParts](https://reference.aspose.com/slides/fa/cpp/aspose.slides.animation/ieffect/set_delaybetweentextparts/) تاخیر بین کلمات یا حروف را تنظیم می‌کند. مقدار مثبت درصدی از مدت زمان افکت است؛ مقدار منفی تاخیر بر حسب ثانیه است.

مثال مستقل زیر کلمات موجود در یک جعبه متن را انیمیشن می‌دهد. [BuildType::AsOneObject](https://reference.aspose.com/slides/fa/cpp/aspose.slides.animation/buildtype/) ساختن پاراگراف به‌صورت پاراگراف‑به‑پاراگراف را غیرفعال می‌کند تا تنظیم کلمه برای کل قاب متن اعمال شود.

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

برای ساختن جعبه متن بر پایهٔ پاراگراف، از [ITextAnimation::set_BuildType](https://reference.aspose.com/slides/fa/cpp/aspose.slides.animation/itextanimation/set_buildtype/) همراه با [BuildType::ByLevelParagraphs1](https://reference.aspose.com/slides/fa/cpp/aspose.slides.animation/buildtype/) یا سطح پاراگراف دیگری استفاده کنید. برای هدف‌گذاری یک پاراگراف واحد با افکت خاص، بارگذاری [ISequence::AddEffect](https://reference.aspose.com/slides/fa/cpp/aspose.slides.animation/isequence/addeffect/) را که یک [IParagraph](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iparagraph/) می‌گیرد به کار ببرید. برای مثال‌های سطح پاراگراف به [Animated Text](/slides/fa/cpp/animated-text/) مراجعه کنید.

## **نکات صادرات و سازگاری**

- ذخیره‌سازی به فرمت PPT یا PPTX مدل انیمیشن را حفظ می‌کند، اما پخش نهایی توسط نمایشگر ارائه کنترل می‌شود.
- PDF و تصاویر ثابت انیمیشن را پخش نمی‌کنند. هنگامی که برای حفظ حرکات نیاز به خروجی است، از [HTML5 export](/slides/fa/cpp/export-to-html5/)، GIF متحرک یا [video conversion](/slides/fa/cpp/convert-powerpoint-to-video/) استفاده کنید.
- برای HTML5، [Html5Options::set_AnimateShapes](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/html5options/set_animateshapes/) را فعال کنید و در صورت نیاز [Html5Options::set_AnimateTransitions](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/html5options/set_animatetransitions/) را تنظیم کنید.
- رندر ویدئو بسیاری از افکت‌های ورودی، تأکید، خروج و مسیر حرکتی رایج را پشتیبانی می‌کند، اما همه افکت‌های پاورپوینت پشتیبانی نمی‌شوند. جدول [supported animations and effects](/slides/fa/cpp/convert-powerpoint-to-video/#supported-animations-and-effects) جاری را بررسی کنید و ارائه‌های مهم را با نسخهٔ هدف Aspose.Slides خود تست نمایید.
- افکت‌های سفارشی پیشرفته و افکت‌های وارد شده از فرمت‌های ارائهٔ دیگر ممکن است در فایل حفظ شوند اما در پاورپوینت، HTML5 یا ویدئو به‑طرز متفاوتی نمایش داده شوند. نتیجهٔ صادرشده را اعتبارسنجی کنید نه فقط بر اساس نام افکت.

## **سوالات متداول**

**چرا یک انیمیشن در پاورپوینت ظاهر می‌شود اما در PDF نیست؟**

PDF یک قالب ثابت است، بنابراین انیمیشن‌ها و انتقال‌های اسلاید پخش نمی‌شوند. برای حفظ حرکت از HTML5، GIF متحرک یا ویدئو استفاده کنید.

**چرا یک افکت در ویدئو به‌صورت متفاوتی اجرا می‌شود؟**

صادر ویدئو انیمیشن‌ها را رندر می‌کند نه اینکه رفتار اصلی پاورپوینت را ذخیره کند. برخی افکت‌های پیشرفته پشتیبانی نشده یا به‌صورت تقریبی اعمال می‌شوند. جدول افکت‌های پشتیبانی‌شده را بررسی کنید و ارائهٔ واقعی را قبل از استفادهٔ تولیدی تست کنید.

**آیا جابه‌جایی یک شکل به جلو یا عقب ترتیب انیمیشن آن را تغییر می‌دهد؟**

نه. ترتیب z‑order شکل فقط پوشش‌دهی را کنترل می‌کند، در حالی که ترتیب توالی و محرک‌ها اجرای انیمیشن را تعیین می‌کنند. اگر به ترتیب پخش متفاوتی نیاز دارید، جدول زمان‌بندی را تغییر دهید.