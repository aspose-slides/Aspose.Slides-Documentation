---
title: اعمال انیمیشن‌های شکل در ارائه‌ها با استفاده از C++
linktitle: انیمیشن شکل
type: docs
weight: 60
url: /fa/cpp/shape-animation/
keywords:
- شکل
- انیمیشن
- افکت
- شکل انیمیشن‌شده
- متن انیمیشن‌شده
- افزودن انیمیشن
- دریافت انیمیشن
- استخراج انیمیشن
- افزودن افکت
- دریافت افکت
- استخراج افکت
- صدای افکت
- اعمال انیمیشن
- پاورپوینت
- ارائه
- C++
- Aspose.Slides
description: "یاد بگیرید چگونه انیمیشن‌های شکل را اضافه، بررسی و سفارشی‌سازی کنید، زمان‌بندی، صداها، رفتار پس از انیمیشن و متن انیمیشن‌شده را با Aspose.Slides برای C++."
---
## **بررسی کلی**

Aspose.Slides برای C++ انیمیشن‌های اسلاید را به‌صورت افکت‌ها در جدول‌زمان اسلاید نمایش می‌دهد. یک افکت شامل شکل هدف، نوع و زیرنوع انیمیشن، یک محرک، تنظیمات زمان‌بندی و ویژگی‌های اختیاری مانند صدا یا رفتار پس از انیمیشن است.

جدول‌زمان دو نوع دنباله دارد:

- دنباله **اصلی** هنگام پیشرفت اسلاید پخش می‌شود.
- دنباله **تعاملی** هنگامی که شکل محرک آن کلیک شود، آغاز می‌شود.

از آنجا که جعبه‌های متن، تصاویر، نمودارها، جداول و سایر اشیای اسلاید [IShape](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ishape/) را پیاده‌سازی می‌کنند، برای بیشتر محتوای اسلاید از همان متد [ISequence::AddEffect](https://reference.aspose.com/slides/fa/cpp/aspose.slides.animation/isequence/addeffect/) استفاده می‌کنید. افکت‌های موجود در شمارش‌نامی [EffectType](https://reference.aspose.com/slides/fa/cpp/aspose.slides.animation/effecttype/) فهرست شده‌اند.

## **افزودن انیمیشن‌های شکل**

برای افزودن یک انیمیشن، دنبالهٔ اصلی اسلاید را به دست آورده و متد [ISequence::AddEffect](https://reference.aspose.com/slides/fa/cpp/aspose.slides.animation/isequence/addeffect/) را با شکل هدف، نوع افکت، زیرنوع و محرک فراخوانی کنید. برای افکتی که هنگام کلیک روی شکل دیگری شروع می‌شود، یک دنبالهٔ تعاملی ایجاد کنید که محرک آن همان شکل دیگر باشد.

مثال زیر هر دو نوع انیمیشن را ایجاد کرده و نتیجه را در فایل `shape-animations.pptx` ذخیره می‌کند.

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

محرک زمان شروع افکت را تعیین می‌کند:

- [EffectTriggerType::OnClick](https://reference.aspose.com/slides/fa/cpp/aspose.slides.animation/effecttriggertype/) صبر می‌کند تا در دنبالهٔ اصلی کلیک شود، یا تا در دنبالهٔ تعاملی روی شکل محرک کلیک شود.
- [EffectTriggerType::WithPrevious](https://reference.aspose.com/slides/fa/cpp/aspose.slides.animation/effecttriggertype/) همزمان با افکت قبلی آغاز می‌شود.
- [EffectTriggerType::AfterPrevious](https://reference.aspose.com/slides/fa/cpp/aspose.slides.animation/effecttriggertype/) پس از اتمام افکت قبلی شروع می‌شود.

برای انیمیشن تصویر، نمودار یا هر نوع شکل دیگر، به جای `targetShape` همان شیء را به [ISequence::AddEffect](https://reference.aspose.com/slides/fa/cpp/aspose.slides.animation/isequence/addeffect/) پاس دهید. برای گزینه‌های گروه‌بندی مخصوص نمودارها، بخش [Animated Charts](/slides/fa/cpp/animated-charts/) را ببینید.

## **خواندن انیمیشن‌های شکل**

هنگامی که شکل هدف را می‌دانید، از [ISequence::GetEffectsByShape](https://reference.aspose.com/slides/fa/cpp/aspose.slides.animation/isequence/geteffectsbyshape/) استفاده کنید. برای بررسی همهٔ افکت‌ها، دنبالهٔ اصلی و همهٔ دنباله‌های تعاملی را مرور کنید. این روش از فرض اینکه یک دنباله حتماً افکتی در ایندکس `0` دارد، جلوگیری می‌کند.

مثال زیر یک شکل با افکت‌های دنبالهٔ اصلی و تعاملی ایجاد می‌کند، افکت‌های هدف‌دار به آن شکل را دریافت می‌کند و سپس همهٔ دنباله‌ها را در اسلاید مرور می‌کند.

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

اگر فقط به افکت‌های یک شکل نیاز دارید، ابتدا شکل را بر اساس نام، نوع جای‌دار یا ویژگی پایدار دیگری شناسایی کنید؛ سپس [ISequence::GetEffectsByShape](https://reference.aspose.com/slides/fa/cpp/aspose.slides.animation/isequence/geteffectsbyshape/) را فراخوانی کنید. فرض نکنید که [IShapeCollection::idx_get](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ishapecollection/idx_get/) در ایندکس `0` همیشه شیء مورد نظر است.

## **کار با افکت‌های جای‌دار ارث‌برده**

یک جای‌دار در اسلاید معمولی می‌تواند رفتار انیمیشن را از جای‌دار متناظر در اسلاید چیدمان و اسلاید مستر به ارث ببرد. [IShape::GetBasePlaceholder](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ishape/getbaseplaceholder/) آن جای‌دار والد را برمی‌گرداند یا زمانی که والد وجود نداشته باشد `nullptr` می‌دهد.

در ارائهٔ نمونهٔ زیر، پانویس در اسلاید معمولی **Random Bars** دارد، در اسلاید چیدمان **Split** و در اسلاید مستر **Fly In** دارد.

![اثر انیمیشن پابرگ در اسلاید عادی](slide-shape-animation.png)

![اثر انیمیشن جای‌دار پابرگ در اسلاید چیدمان](layout-shape-animation.png)

![اثر انیمیشن جای‌دار پابرگ در اسلاید مستر](master-shape-animation.png)

مثال بعدی سلسله‌مراتب جای‌دار را می‌سازد. افکت‌ها به یک جای‌دار مستر، یک جای‌دار چیدمان و جای‌دار متناظر در اسلاید معمولی اضافه می‌شود. قبل از استفاده از شکل برگردانده‌شده، هر بار [IShape::GetBasePlaceholder](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ishape/getbaseplaceholder/) بررسی می‌شود.

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

دیالوگ **Timing** در PowerPoint به متدهای [ITiming](https://reference.aspose.com/slides/fa/cpp/aspose.slides.animation/itiming/) نگاشته می‌شود.

![دیالوگ زمان‌بندی PowerPoint برای یک افکت انیمیشن](shape-animation.png)

- **شروع** به [ITiming::set_TriggerType](https://reference.aspose.com/slides/fa/cpp/aspose.slides.animation/itiming/set_triggertype/) نگاشته می‌شود.
- **مدت** به [ITiming::set_Duration](https://reference.aspose.com/slides/fa/cpp/aspose.slides.animation/itiming/set_duration/) در ثانیه‌ها نگاشته می‌شود.
- **تاخیر** به [ITiming::set_TriggerDelayTime](https://reference.aspose.com/slides/fa/cpp/aspose.slides.animation/itiming/set_triggerdelaytime/) در ثانیه‌ها نگاشته می‌شود.
- **تکرار** به [ITiming::set_RepeatCount](https://reference.aspose.com/slides/fa/cpp/aspose.slides.animation/itiming/set_repeatcount/)، [ITiming::set_RepeatUntilNextClick](https://reference.aspose.com/slides/fa/cpp/aspose.slides.animation/itiming/set_repeatuntilnextclick/) یا [ITiming::set_RepeatUntilEndSlide](https://reference.aspose.com/slides/fa/cpp/aspose.slides.animation/itiming/set_repeatuntilendslide/) نگاشته می‌شود.
- **بازگرداندن پس از پخش** به [ITiming::set_Rewind](https://reference.aspose.com/slides/fa/cpp/aspose.slides.animation/itiming/set_rewind/) نگاشته می‌شود.

این مثال مستقل یک افکت اضافه می‌کند، زمان‌بندی آن را از طریق شیء برگردانده‌شده توسط [ISequence::AddEffect](https://reference.aspose.com/slides/fa/cpp/aspose.slides.animation/isequence/addeffect/) تغییر می‌دهد و نتیجه را ذخیره می‌کند. نگه داشتن مرجع [IEffect](https://reference.aspose.com/slides/fa/cpp/aspose.slides.animation/ieffect/) جلوگیری از نیاز به ایندکس‌گذاری غیرضروری در مجموعه می‌کند.

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

یک حالت تکرار را به‌طور عمدی انتخاب کنید. ترکیب شمارش تکرار با پرچم «تا» می‌تواند نتایج گیج‌کننده‌ای در نماینده‌های مختلف ایجاد کند. هنگام تغییر حالت‌های تکرار، ابتدا [ITiming::set_RepeatUntilNextClick](https://reference.aspose.com/slides/fa/cpp/aspose.slides.animation/itiming/set_repeatuntilnextclick/) و [ITiming::set_RepeatUntilEndSlide](https://reference.aspose.com/slides/fa/cpp/aspose.slides.animation/itiming/set_repeatuntilendslide/) را صدا بزنید و سپس [ITiming::set_RepeatCount](https://reference.aspose.com/slides/fa/cpp/aspose.slides.animation/itiming/set_repeatcount/) را فراخوانی کنید، زیرا تنظیم هر یک از پرچم‌ها حالت تکرار فعال را نیز تغییر می‌دهد.

## **افزودن و استخراج صداهای انیمیشن**

یک افکت انیمیشن می‌تواند صوتی جاسازی‌شده را از طریق [IEffect::set_Sound](https://reference.aspose.com/slides/fa/cpp/aspose.slides.animation/ieffect/set_sound/) ارجاع دهد. [IEffect::set_StopPreviousSound](https://reference.aspose.com/slides/fa/cpp/aspose.slides.animation/ieffect/set_stopprevioussound/) به افکت می‌گوید صدای شروع شده توسط افکت قبلی را متوقف کند.

### **افزودن صدا به یک افکت**

مثال زیر انتظار دارد فایل صوتی محلی به نام `animation-sound.wav` موجود باشد. دو افکت ایجاد می‌کند، آن فایل را به عنوان صدا برای اولین افکت جاسازی می‌کند و افکت دوم را طوری تنظیم می‌کند که صدای آن را متوقف کند. از اشیایی که توسط [ISequence::AddEffect](https://reference.aspose.com/slides/fa/cpp/aspose.slides.animation/isequence/addeffect/) برگردانده می‌شوند استفاده می‌شود، بنابراین نیازی به ایندکس دنباله نیست.

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

### **استخراج صداهای افکت‌های جاسازی‌شده**

مثال زیر انتظار دارد ارائهٔ محلی به نام `presentation-with-animation-sounds.pptx` موجود باشد. هر دو دنبالهٔ اصلی و تعاملی را اسکن می‌کند و هر صداِ افکت جاسازی‌شده را در پوشهٔ `extracted-animation-sounds` می‌نویسد. پسوند بر اساس MIME type صوتی که توسط [IAudio::get_ContentType](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iaudio/get_contenttype/) ارائه می‌شود، انتخاب می‌شود.

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

برای اشیای صوتی بزرگ، از [IAudio::GetStream](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iaudio/getstream/) استفاده کنید و جریان را به یک فایل کپی کنید به‌جای بارگذاری کل شیء در یک آرایه بایت.

## **تنظیم رفتار پس از انیمیشن**

گزینه **After animation** تعیین می‌کند پس از اتمام افکت، با شکل چه‌کار شود.

![دیالوگ گزینه‌های افکت PowerPoint که تنظیمات After animation را نشان می‌دهد](shape-after-animation.png)

شمارش‌نامی [AfterAnimationType](https://reference.aspose.com/slides/fa/cpp/aspose.slides.animation/afteranimationtype/) پشتیبانی می‌کند که شکل بدون تغییر بماند، رنگ آن تغییر کند، پس از انیمیشن مخفی شود یا در کلیک بعدی مخفی بماند. وقتی نوع [AfterAnimationType::Color](https://reference.aspose.com/slides/fa/cpp/aspose.slides.animation/afteranimationtype/) باشد، برای تنظیم رنگ باید [IEffect::get_AfterAnimationColor](https://reference.aspose.com/slides/fa/cpp/aspose.slides.animation/ieffect/get_afteranimationcolor/) فراخوانی شود.

این مثال مستقل یک افکت ایجاد می‌کند، رفتار پس از انیمیشن آن را از طریق شیء افکت برگردانده‌شده تنظیم می‌کند و نتیجه را ذخیره می‌نماید.

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

تغییر نوع از [AfterAnimationType::Color](https://reference.aspose.com/slides/fa/cpp/aspose.slides.animation/afteranimationtype/) باعث پاک‌سازی تنظیم رنگ پس از انیمیشن می‌شود.

## **انیمیشن متن**

انیمیشن متن دو کنترل مرتبط دارد:

- [ITextAnimation::set_BuildType](https://reference.aspose.com/slides/fa/cpp/aspose.slides.animation/itextanimation/set_buildtype/) تعیین می‌کند که پاراگراف‌ها به‌صورت همزمان یا به‌صورت سطح‌پاراگراف ظاهر شوند.
- [IEffect::set_AnimateTextType](https://reference.aspose.com/slides/fa/cpp/aspose.slides.animation/ieffect/set_animatetexttype/) تعیین می‌کند که متن به‌صورت کل، کلمه به کلمه یا حرف به حرف ظاهر شود. [IEffect::set_DelayBetweenTextParts](https://reference.aspose.com/slides/fa/cpp/aspose.slides.animation/ieffect/set_delaybetweentextparts/) تأخیر بین کلمات یا حروف را تنظیم می‌کند. مقدار مثبت درصدی از مدت افکت است؛ مقدار منفی مقدار تأخیر بر حسب ثانیه است.

مثال مستقل زیر کلمات موجود در یک جعبهٔ متن را انیمیشن می‌دهد. [BuildType::AsOneObject](https://reference.aspose.com/slides/fa/cpp/aspose.slides.animation/buildtype/) ساختن پاراگراف به‌صورت پیوسته را غیرفعال می‌کند تا تنظیم کلمه برای کل فریم متن اعمال شود.

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

برای ساختن جعبهٔ متن به‌صورت پاراگراف، از [ITextAnimation::set_BuildType](https://reference.aspose.com/slides/fa/cpp/aspose.slides.animation/itextanimation/set_buildtype/) همراه با [BuildType::ByLevelParagraphs1](https://reference.aspose.com/slides/fa/cpp/aspose.slides.animation/buildtype/) یا سطح پاراگراف دیگری استفاده کنید. برای هدف‌گیری یک پاراگراف منفرد با افکت خاص، از overload متد [ISequence::AddEffect](https://reference.aspose.com/slides/fa/cpp/aspose.slides.animation/isequence/addeffect/) که یک [IParagraph](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iparagraph/) می‌پذیرد، بهره ببرید. برای مثال‌های سطح‑پاراگراف به بخش [Animated Text](/slides/fa/cpp/animated-text/) مراجعه کنید.

## **یادداشت‌های خروجی و سازگاری**

- ذخیره به فرمت PPT یا PPTX مدل انیمیشن را حفظ می‌کند، اما پخش نهایی توسط برنامهٔ مشاهدهٔ ارائه کنترل می‌شود.
- PDF و تصاویر ثابت انیمیشن پخش نمی‌کنند. برای نمایش حرکت، از [HTML5 export](/slides/fa/cpp/export-to-html5/)، GIF متحرک یا [تبدیل به ویدیو](/slides/fa/cpp/convert-powerpoint-to-video/) استفاده کنید.
- برای HTML5، [Html5Options::set_AnimateShapes](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/html5options/set_animateshapes/) و در صورت نیاز [Html5Options::set_AnimateTransitions](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/html5options/set_animatetransitions/) را فعال کنید.
- رندرینگ ویدیو بسیاری از افکت‌های ورودی، تأکید، خروجی و مسیر حرکت را پشتیبانی می‌کند، اما همهٔ افکت‌های PowerPoint پشتیبانی نمی‌شوند. جدول [انیمیشن‌ها و افکت‌های پشتیبانی‌شده](/slides/fa/cpp/convert-powerpoint-to-video/#supported-animations-and-effects) را بررسی کنید و ارائه‌های مهم را با نسخهٔ موردنظر Aspose.Slides خود تست کنید.
- افکت‌های سفارشی پیشرفته و افکت‌های وارد شده از فرمت‌های دیگر ممکن است در فایل حفظ شوند ولی در PowerPoint، HTML5 یا ویدیو به‌صورت متفاوت رندر شوند. نتیجهٔ خروجی را اعتبارسنجی کنید نه فقط بر روی نام افکت تکیه کنید.

## **پرسش‌های متداول**

**چرا یک انیمیشن در PowerPoint نشان داده می‌شود اما در PDF نیست؟**

PDF یک فرمت ثابت است، بنابراین انیمیشن‌ها و انتقال‌های اسلاید پخش نمی‌شوند. برای حفظ حرکت، به HTML5، GIF متحرک یا ویدیو خروجی بدهید.

**چرا یک افکت در ویدیو به‌صورت متفاوتی پخش می‌شود؟**

خروجی ویدیو انیمیشن‌ها را رندر می‌کند نه اینکه رفتار اصلی PowerPoint را ذخیره کند. برخی افکت‌های پیشرفته پشتیبانی نمی‌شوند یا به‌صورت تخمینی اجرا می‌شوند. جدول افکت‌های پشتیبانی‌شده را مرور کنید و ارائهٔ واقعی را قبل از استفاده در تولید تست کنید.

**آیا جابجایی یک شکل به جلو یا عقب ترتیب انیمیشن آن را تغییر می‌دهد؟**

نه. ترتیب لایهٔ Z شکل فقط پوشش را تعیین می‌کند، در حالی که ترتیب دنباله و محرک‌ها پخش انیمیشن را کنترل می‌کنند. اگر به ترتیب پخش متفاوتی نیاز دارید، جدول‌زمان را تغییر دهید.