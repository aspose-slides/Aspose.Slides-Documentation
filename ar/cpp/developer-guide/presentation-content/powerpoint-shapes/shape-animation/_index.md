---
title: تطبيق حركات الأشكال في العروض التقديمية باستخدام C++
linktitle: حركة الشكل
type: docs
weight: 60
url: /ar/cpp/shape-animation/
keywords:
- شكل
- حركة
- تأثير
- شكل متحرك
- نص متحرك
- إضافة حركة
- الحصول على حركة
- استخراج حركة
- إضافة تأثير
- الحصول على تأثير
- استخراج تأثير
- صوت التأثير
- تطبيق حركة
- PowerPoint
- عرض تقديمي
- C++
- Aspose.Slides
description: "تعلم كيفية إضافة وفحص وتخصيص حركات الأشكال، التوقيت، الأصوات، سلوك ما بعد الحركة، والنص المتحرك باستخدام Aspose.Slides لـ C++."
---
## **نظرة عامة**

Aspose.Slides for C++ يمثل حركات الشرائح كـ **effects** في **timeline** الشريحة. لكل تأثير هدف (shape)، نوع الحركة، النوع الفرعي، المشغل، إعدادات التوقيت، وخصائص اختيارية مثل الصوت أو سلوك ما بعد الحركة.

يحتوي الـ timeline على نوعين من التسلسلات:

- **التسلسل الرئيسي** يُشغل عندما تتقدم الشريحة.
- **التسلسل التفاعلي** يبدأ عندما يتم النقر على الشكل المشغل.

نظرًا لأن صناديق النص، الصور، المخططات، الجداول، وغيرها من كائنات الشريحة تنفذ [IShape](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ishape/)، يمكنك استخدام نفس طريقة [ISequence::AddEffect](https://reference.aspose.com/slides/ar/cpp/aspose.slides.animation/isequence/addeffect/) لمعظم محتوى الشريحة. يتم سرد التأثيرات المتاحة في تعداد [EffectType](https://reference.aspose.com/slides/ar/cpp/aspose.slides.animation/effecttype/).

## **إضافة حركات الأشكال**

لإضافة حركة، احصل على التسلسل الرئيسي للشفرة واستدعِ [ISequence::AddEffect](https://reference.aspose.com/slides/ar/cpp/aspose.slides.animation/isequence/addeffect/) مع الشكل الهدف، نوع التأثير، النوع الفرعي، والمشغل. بالنسبة لتأثير يبدأ عند النقر على شكل آخر، أنشئ تسلسلاً تفاعليًا يكون مشغله ذلك الشكل الآخر.

المثال التالي ينشئ كلا النوعين من الحركات ويحفظ النتيجة إلى `shape-animations.pptx`.

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

المشغل يتحكم بوقت بدء التأثير:

- [EffectTriggerType::OnClick](https://reference.aspose.com/slides/ar/cpp/aspose.slides.animation/effecttriggertype/) ينتظر نقرة في التسلسل الرئيسي، أو نقرة على الشكل المشغل في تسلسل تفاعلي.
- [EffectTriggerType::WithPrevious](https://reference.aspose.com/slides/ar/cpp/aspose.slides.animation/effecttriggertype/) يبدأ مع التأثير السابق.
- [EffectTriggerType::AfterPrevious](https://reference.aspose.com/slides/ar/cpp/aspose.slides.animation/effecttriggertype/) يبدأ عندما ينتهي التأثير السابق.

لتحريك صورة أو مخطط أو أي نوع آخر من الأشكال، مرّر ذلك الكائن إلى [ISequence::AddEffect](https://reference.aspose.com/slides/ar/cpp/aspose.slides.animation/isequence/addeffect/) بدلاً من `targetShape`. للحصول على خيارات تجميع خاصة بالمخططات، راجع [Animated Charts](/slides/ar/cpp/animated-charts/).

## **قراءة حركات الأشكال**

استخدم [ISequence::GetEffectsByShape](https://reference.aspose.com/slides/ar/cpp/aspose.slides.animation/isequence/geteffectsbyshape/) عندما تعرف الشكل الهدف. لتفحص كل تأثير، قم بتعداد التسلسل الرئيسي وكل تسلسل تفاعلي. التعداد يجنب الافتراض بأن التسلسل يحتوي على تأثير في الفهرس `0`.

المثال التالي ينشئ شكلاً يحتوي على تأثيرات في التسلسل الرئيسي والتفاعلي، يحصل على التأثيرات التي تستهدف الشكل، ثم يعدّد كل التسلسلات في الشريحة.

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

إذا كنت بحاجة فقط إلى التأثيرات لشكل واحد، حدد الشكل أولاً بالاسم، أو نوع العنصر النائب، أو أي خاصية ثابتة أخرى؛ ثم استدعِ [ISequence::GetEffectsByShape](https://reference.aspose.com/slides/ar/cpp/aspose.slides.animation/isequence/geteffectsbyshape/). لا تفترض أن [IShapeCollection::idx_get](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ishapecollection/idx_get/) عند الفهرس `0` هو دائماً الكائن المقصود.

## **العمل مع تأثيرات العناصر النائبة الموروثة**

يمكن لعنصر نائب على شريحة عادية أن يرث سلوك الحركة من العنصر النائب المقابل على شريحة التخطيط وشريحة القالب. تُعيد [IShape::GetBasePlaceholder](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ishape/getbaseplaceholder/) ذلك العنصر النائب الأب، أو `nullptr` إذا لم يوجد أب.

في عرض الشرائح المثال التالي، التذييل يحتوي على **Random Bars** على الشريحة العادية، **Split** على شريحة التخطيط، و**Fly In** على شريحة القالب.

![تأثير حركة التذييل على الشريحة العادية](slide-shape-animation.png)

![تأثير حركة عنصر نائب التذييل على شريحة التخطيط](layout-shape-animation.png)

![تأثير حركة عنصر نائب التذييل على شريحة القالب](master-shape-animation.png)

المثال التالي يبني هيكلية العنصر النائب نفسها. يضيف تأثيرات إلى عنصر نائب القالب، عنصر نائب التخطيط، والعنصر النائب المقابل على شريحة عادية. يتم فحص كل استدعاء لـ [IShape::GetBasePlaceholder](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ishape/getbaseplaceholder/) قبل استخدام الشكل المعاد.

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

## **تغيير توقيت الحركة**

حوار **Timing** في PowerPoint يتطابق مع طرق [ITiming](https://reference.aspose.com/slides/ar/cpp/aspose.slides.animation/itiming/).

![حوار توقيت PowerPoint لتأثير الحركة](shape-animation.png)

- **Start** يتطابق مع [ITiming::set_TriggerType](https://reference.aspose.com/slides/ar/cpp/aspose.slides.animation/itiming/set_triggertype/).
- **Duration** يتطابق مع [ITiming::set_Duration](https://reference.aspose.com/slides/ar/cpp/aspose.slides.animation/itiming/set_duration/)، بالثواني.
- **Delay** يتطابق مع [ITiming::set_TriggerDelayTime](https://reference.aspose.com/slides/ar/cpp/aspose.slides.animation/itiming/set_triggerdelaytime/)، بالثواني.
- **Repeat** يتطابق مع [ITiming::set_RepeatCount](https://reference.aspose.com/slides/ar/cpp/aspose.slides.animation/itiming/set_repeatcount/)، [ITiming::set_RepeatUntilNextClick](https://reference.aspose.com/slides/ar/cpp/aspose.slides.animation/itiming/set_repeatuntilnextclick/)، أو [ITiming::set_RepeatUntilEndSlide](https://reference.aspose.com/slides/ar/cpp/aspose.slides.animation/itiming/set_repeatuntilendslide/).
- **Rewind when done playing** يتطابق مع [ITiming::set_Rewind](https://reference.aspose.com/slides/ar/cpp/aspose.slides.animation/itiming/set_rewind/).

هذا المثال المستقل يضيف تأثيرًا، يغيّر توقيته عبر الكائن المعاد من [ISequence::AddEffect](https://reference.aspose.com/slides/ar/cpp/aspose.slides.animation/isequence/addeffect/)، ويحفظ النتيجة. الاحتفاظ بالمرجع المعاد لـ [IEffect](https://reference.aspose.com/slides/ar/cpp/aspose.slides.animation/ieffect/) يتجنب الحاجة إلى فهرس مجموعة غير ضروري.

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

استخدم وضعية تكرار واحدة فقط عمداً. الجمع بين عدد التكرار وعلامة "حتى" قد ينتج نتائج مربكة في مشغلات مختلفة. عند تغيير أوضاع التكرار، استدعِ [ITiming::set_RepeatUntilNextClick](https://reference.aspose.com/slides/ar/cpp/aspose.slides.animation/itiming/set_repeatuntilnextclick/) و[ITiming::set_RepeatUntilEndSlide](https://reference.aspose.com/slides/ar/cpp/aspose.slides.animation/itiming/set_repeatuntilendslide/) قبل [ITiming::set_RepeatCount](https://reference.aspose.com/slides/ar/cpp/aspose.slides.animation/itiming/set_repeatcount/)، لأن تعيين أي من العلامتين يغيّر وضعية التكرار النشطة.

## **إضافة واستخراج أصوات الحركة**

يمكن لتأثير الحركة الإشارة إلى صوت مضمّن عبر [IEffect::set_Sound](https://reference.aspose.com/slides/ar/cpp/aspose.slides.animation/ieffect/set_sound/). [IEffect::set_StopPreviousSound](https://reference.aspose.com/slides/ar/cpp/aspose.slides.animation/ieffect/set_stopprevioussound/) يُخبر التأثير بإيقاف الصوت الذي بدأه تأثير سابق.

### **إضافة صوت إلى تأثير**

المثال التالي يتوقع ملف صوت محلي اسمه `animation-sound.wav`. ينشئ تأثيرين، يضمّن ذلك الملف كصوت للتأثير الأول، ويضبط التأثير الثاني لإيقاف الصوت. يستخدم الكائنات المعادة من [ISequence::AddEffect](https://reference.aspose.com/slides/ar/cpp/aspose.slides.animation/isequence/addeffect/)، لذلك لا يلزم فهرس التسلسل.

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

### **استخراج أصوات التأثير المضمّنة**

المثال التالي يتوقع عرضًا تقديميًا محليًا اسمه `presentation-with-animation-sounds.pptx`. يقوم بمسح كل من التسلسل الرئيسي والتسلسل التفاعلي ويكتب كل صوت تأثير مضمّن إلى المجلد `extracted-animation-sounds`. يتم اختيار الامتداد بناءً على نوع MIME الصوتي المعرّف بواسطة [IAudio::get_ContentType](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iaudio/get_contenttype/).

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

للملفات الصوتية الكبيرة، استخدم [IAudio::GetStream](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iaudio/getstream/) وانسخ الدفق إلى ملف بدلًا من تحميل الكائن بالكامل إلى مصفوفة بايتات.

## **تعيين سلوك ما بعد الحركة**

خيار **After animation** يتحكم بما يحدث للشكل بعد انتهاء تأثيره.

![حوار خيارات تأثير PowerPoint يظهر إعدادات After animation](shape-after-animation.png)

تعداد [AfterAnimationType](https://reference.aspose.com/slides/ar/cpp/aspose.slides.animation/afteranimationtype/) يدعم ترك الشكل دون تغيير، تغيير لونه، إخفائه بعد الحركة، أو إخفائه عند النقر التالي. عندما يكون النوع هو [AfterAnimationType::Color](https://reference.aspose.com/slides/ar/cpp/aspose.slides.animation/afteranimationtype/)، استدعِ [IEffect::get_AfterAnimationColor](https://reference.aspose.com/slides/ar/cpp/aspose.slides.animation/ieffect/get_afteranimationcolor/) لتعيين اللون أيضًا.

هذا المثال المستقل ينشئ تأثيرًا، يحدد سلوك ما بعد الحركة عبر كائن التأثير المعاد، ويحفظ النتيجة.

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

تغيير النوع بعيدًا عن [AfterAnimationType::Color](https://reference.aspose.com/slides/ar/cpp/aspose.slides.animation/afteranimationtype/) يمسح إعداد لون ما بعد الحركة.

## **تحريك النص**

تحريك النص له تحكمين مرتبطين:

- [ITextAnimation::set_BuildType](https://reference.aspose.com/slides/ar/cpp/aspose.slides.animation/itextanimation/set_buildtype/) يحدد ما إذا كانت الفقرات تظهر معًا أو على مستوى الفقرة.
- [IEffect::set_AnimateTextType](https://reference.aspose.com/slides/ar/cpp/aspose.slides.animation/ieffect/set_animatetexttype/) يحدد ما إذا كان النص يظهر مرة واحدة، كلمة بكلمة، أو حرف بحرف. [IEffect::set_DelayBetweenTextParts](https://reference.aspose.com/slides/ar/cpp/aspose.slides.animation/ieffect/set_delaybetweentextparts/) يحدد التأخير بين الكلمات أو الحروف. القيمة الإيجابية هي نسبة مئوية من مدة التأثير؛ القيمة السالبة هي تأخير بالثواني.

المثال المستقل التالي يحرك الكلمات داخل صندوق نص. [BuildType::AsOneObject](https://reference.aspose.com/slides/ar/cpp/aspose.slides.animation/buildtype/) يلغي بناء الفقرة-بفقرة بحيث يطبق الإعداد الخاص بالكلمة على الإطار النصي بالكامل.

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

لبناء صندوق نص وفق الفقرة، استخدم [ITextAnimation::set_BuildType](https://reference.aspose.com/slides/ar/cpp/aspose.slides.animation/itextanimation/set_buildtype/) مع [BuildType::ByLevelParagraphs1](https://reference.aspose.com/slides/ar/cpp/aspose.slides.animation/buildtype/) أو مستوى فقرة آخر. لاستهداف فقرة واحدة بتأثير خاص بها، استخدم overload من [ISequence::AddEffect](https://reference.aspose.com/slides/ar/cpp/aspose.slides.animation/isequence/addeffect/) الذي يقبل [IParagraph](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iparagraph/). راجع [Animated Text](/slides/ar/cpp/animated-text/) لأمثلة على مستوى الفقرة.

## **تصدير وملاحظات التوافق**

- الحفظ إلى PPT أو PPTX يحتفظ بنموذج الحركة، لكن تشغيله النهائي يتحكم به عارض العرض.
- PDF والصور الثابتة لا تشغل الحركات. استخدم [HTML5 export](/slides/ar/cpp/export-to-html5/)، GIF متحرك، أو [تحويل الفيديو](/slides/ar/cpp/convert-powerpoint-to-video/) عندما يجب إظهار الحركة.
- بالنسبة إلى HTML5، فعّل [Html5Options::set_AnimateShapes](https://reference.aspose.com/slides/ar/cpp/aspose.slides.export/html5options/set_animateshapes/) وعند الحاجة [Html5Options::set_AnimateTransitions](https://reference.aspose.com/slides/ar/cpp/aspose.slides.export/html5options/set_animatetransitions/).
- تصيير الفيديو يدعم العديد من تأثيرات الدخول، التأكيد، الخروج، ومسارات الحركة الشائعة، لكن ليس كل تأثير PowerPoint مدعوم. تحقّق من [التأثيرات والحركات المدعومة](/slides/ar/cpp/convert-powerpoint-to-video/#supported-animations-and-effects) واختبر العروض الحرجة مع إصدار Aspose.Slides المستهدف.
- قد تُحفظ التأثيرات المخصصة المتقدمة والتأثيرات المستوردة من صيغ عروض تقديمية أخرى في الملف لكن تُعرض بشكل مختلف في PowerPoint أو HTML5 أو الفيديو. راجع النتيجة المصدرة بدلاً من الاعتماد فقط على اسم التأثير.

## **الأسئلة المتكررة**

**لماذا تظهر حركة في PowerPoint لكن لا تظهر في PDF؟**

PDF هو تنسيق ثابت، لذا لا تُشغَّل الحركات وانتقالات الشرائح. صدّر إلى HTML5 أو GIF متحرك أو فيديو عندما يجب الحفاظ على الحركة.

**لماذا يُظهر تأثير مختلف في الفيديو؟**

تصدير الفيديو يُعيد رسم الحركات بدلاً من تخزين سلوك PowerPoint الأصلي. بعض التأثيرات المتقدمة غير مدعومة أو تُقَرّب. راجع جدول التأثيرات المدعومة واختبر العرض الفعلي قبل الاستخدام الإنتاجي.

**هل تغيير موضع الشكل إلى الأمام أو الخلف يغيّر ترتيب حركته؟**

لا. ترتيب z-order للشكل يتحكم في التداخل، بينما ترتيب التسلسل والمشغلات يتحكمان في تشغيل الحركة. غيّر الـ timeline إذا كنت تحتاج ترتيب تشغيل مختلف.