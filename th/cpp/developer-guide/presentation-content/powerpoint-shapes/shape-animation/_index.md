---
title: นำการเคลื่อนไหวยของรูปทรงไปใช้ในงานนำเสนอด้วย C++
linktitle: การเคลื่อนไหวของรูปทรง
type: docs
weight: 60
url: /th/cpp/shape-animation/
keywords:
- รูปทรง
- การเคลื่อนไหว
- เอฟเฟกต์
- รูปทรงเคลื่อนไหว
- ข้อความเคลื่อนไหว
- เพิ่มการเคลื่อนไหว
- รับการเคลื่อนไหว
- สกัดการเคลื่อนไหว
- เพิ่มเอฟเฟกต์
- รับเอฟเฟกต์
- สกัดเอฟเฟกต์
- เสียงเอฟเฟกต์
- ใช้การเคลื่อนไหว
- PowerPoint
- งานนำเสนอ
- C++
- Aspose.Slides
description: "เรียนรู้วิธีเพิ่ม, ตรวจสอบและปรับแต่งการเคลื่อนไหวของรูปทรง, เวลา, เสียง, พฤติกรรมหลังการเคลื่อนไหวและข้อความเคลื่อนไหวด้วย Aspose.Slides สำหรับ C++."
---
## **ภาพรวม**

Aspose.Slides for C++ แสดงภาพเคลื่อนไหวของสไลด์เป็นเอฟเฟกต์บนไทม์ไลน์ของสไลด์ เอฟเฟกต์จะมีรูปทรงเป้าหมาย, ประเภทและชนิดย่อยของการเคลื่อนไหว, ตัวกระตุ้น, การตั้งค่าเวลา, และคุณสมบัติเสริมเช่นเสียงหรือพฤติกรรมหลังการเคลื่อนไหว

ไทม์ไลน์ประกอบด้วยลำดับสองประเภท:

- **ลำดับหลัก** ทำงานเมื่อสไลด์ก้าวหน้า
- **ลำดับเชิงโต้ตอบ** เริ่มทำงานเมื่อคลิกที่รูปทรงตัวกระตุ้น

เนื่องจากกล่องข้อความ, รูปภาพ, แผนภูมิ, ตารางและวัตถุสไลด์อื่น ๆ ปฏิบัติตาม [IShape](https://reference.aspose.com/slides/th/cpp/aspose.slides/ishape/) คุณจึงใช้เมธอดเดียวกันคือ [ISequence::AddEffect](https://reference.aspose.com/slides/th/cpp/aspose.slides.animation/isequence/addeffect/) สำหรับเนื้อหาสไลด์ส่วนใหญ่ เอฟเฟกต์ที่มีอยู่ได้ระบุไว้ในลำดับการ enumerated ของ [EffectType](https://reference.aspose.com/slides/th/cpp/aspose.slides.animation/effecttype/)

## **เพิ่มการเคลื่อนไหวให้รูปทรง**

เพื่อเพิ่มการเคลื่อนไหว ให้ดึงลำดับหลักของสไลด์และเรียก [ISequence::AddEffect](https://reference.aspose.com/slides/th/cpp/aspose.slides.animation/isequence/addeffect/) พร้อมรูปทรงเป้าหมาย, ประเภทเอฟเฟกต์, ชนิดย่อยและตัวกระตุ้น สำหรับเอฟเฟกต์ที่เริ่มเมื่อรูปทรงอื่นถูกคลิก ให้สร้างลำดับเชิงโต้ตอบที่ตัวกระตุ้นคือรูปทรงนั้น

ตัวอย่างต่อไปนี้สร้างเอฟเฟกต์ทั้งสองประเภทและบันทึกผลลัพธ์เป็นไฟล์ `shape-animations.pptx`

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

ตัวกระตุ้นกำหนดว่าเอฟเฟกต์จะเริ่มเมื่อไร:

- [EffectTriggerType::OnClick](https://reference.aspose.com/slides/th/cpp/aspose.slides.animation/effecttriggertype/) รอการคลิกในลำดับหลักหรือการคลิกบนรูปทรงตัวกระตุ้นในลำดับเชิงโต้ตอบ
- [EffectTriggerType::WithPrevious](https://reference.aspose.com/slides/th/cpp/aspose.slides.animation/effecttriggertype/) เริ่มพร้อมกับเอฟเฟกต์ก่อนหน้า
- [EffectTriggerType::AfterPrevious](https://reference.aspose.com/slides/th/cpp/aspose.slides.animation/effecttriggertype/) เริ่มเมื่อเอฟเฟกต์ก่อนหน้าสิ้นสุด

เพื่อทำให้รูปภาพ, แผนภูมิ หรือรูปทรงประเภทอื่นเคลื่อนไหว ให้ส่งออบเจกต์นั้นไปยัง [ISequence::AddEffect](https://reference.aspose.com/slides/th/cpp/aspose.slides.animation/isequence/addeffect/) แทน `targetShape` สำหรับตัวเลือกการจัดกลุ่มเฉพาะแผนภูมิ ดูที่ [Animated Charts](/slides/th/cpp/animated-charts/)

## **อ่านการเคลื่อนไหวของรูปทรง**

ใช้ [ISequence::GetEffectsByShape](https://reference.aspose.com/slides/th/cpp/aspose.slides.animation/isequence/geteffectsbyshape/) เมื่อคุณทราบรูปทรงเป้าหมาย เพื่อตรวจสอบทุกเอฟเฟกต์ ให้วนลูปผ่านลำดับหลักและทุกลำดับเชิงโต้ตอบ การวนลูปช่วยหลีกเลี่ยงการสันนิษฐานว่าลำดับมีเอฟเฟกต์ที่ตำแหน่ง `0`

ตัวอย่างต่อไปนี้สร้างรูปทรงพร้อมเอฟเฟกต์ลำดับหลักและเชิงโต้ตอบ, ดึงเอฟเฟกต์ที่เป้าหมายเป็นรูปทรงนั้น, แล้ววนลูปผ่านทุกลำดับบนสไลด์

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

หากคุณต้องการเอฟเฟกต์สำหรับรูปทรงหนึ่งรูปเท่านั้น ให้ระบุตัวรูปทรงโดยชื่อ, ชนิด placeholder หรือคุณสมบัติคงที่อื่น ๆ; จากนั้นเรียก [ISequence::GetEffectsByShape](https://reference.aspose.com/slides/th/cpp/aspose.slides.animation/isequence/geteffectsbyshape/) อย่าอนุมานว่า [IShapeCollection::idx_get](https://reference.aspose.com/slides/th/cpp/aspose.slides/ishapecollection/idx_get/) ที่ตำแหน่ง `0` จะเป็นออบเจกต์ที่ต้องการเสมอ

## **ทำงานกับเอฟเฟกต์ Placeholder ที่สืบทอดมาจาก Layout หรือ Master**

Placeholder บนสไลด์ปกติสามารถสืบทอดพฤติกรรมการเคลื่อนไหวจาก placeholder ที่สอดคล้องบนสไลด์ Layout และ Master ได้ [IShape::GetBasePlaceholder](https://reference.aspose.com/slides/th/cpp/aspose.slides/ishape/getbaseplaceholder/) จะคืนค่า placeholder พื้นฐานนั้น, หรือ `nullptr` หากไม่มีพ่อแม่

ในงานนำเสนอในตัวอย่างต่อไป, ส่วนท้ายมี **Random Bars** บนสไลด์ปกติ, **Split** บนสไลด์ Layout, และ **Fly In** บนสไลด์ Master

![ภาพเอฟเฟกต์การเคลื่อนไหวของส่วนท้ายบนสไลด์ปกติ](slide-shape-animation.png)

![ภาพเอฟเฟกต์การเคลื่อนไหวของ placeholder ส่วนท้ายบนสไลด์ Layout](layout-shape-animation.png)

![ภาพเอฟเฟกต์การเคลื่อนไหวของ placeholder ส่วนท้ายบนสไลด์ Master](master-shape-animation.png)

ตัวอย่างต่อไปนี้สร้างลำดับชั้นของ placeholder ด้วยตนเอง โดยเพิ่มเอฟเฟกต์ให้กับ placeholder ของ Master, placeholder ของ Layout, และ placeholder ที่สอดคล้องบนสไลด์ปกติ ทุกครั้งที่เรียก [IShape::GetBasePlaceholder](https://reference.aspose.com/slides/th/cpp/aspose.slides/ishape/getbaseplaceholder/) จะตรวจสอบค่ากลับก่อนนำมาใช้งาน

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

## **เปลี่ยนแปลงการตั้งค่าเวลาในการเคลื่อนไหว**

ไดอะล็อก **Timing** ของ PowerPoint จะแมพกับเมธอดของ [ITiming](https://reference.aspose.com/slides/th/cpp/aspose.slides.animation/itiming/)

![ไดอะล็อก Timing ของ PowerPoint สำหรับเอฟเฟกต์การเคลื่อนไหว](shape-animation.png)

- **Start** แมพกับ [ITiming::set_TriggerType](https://reference.aspose.com/slides/th/cpp/aspose.slides.animation/itiming/set_triggertype/)
- **Duration** แมพกับ [ITiming::set_Duration](https://reference.aspose.com/slides/th/cpp/aspose.slides.animation/itiming/set_duration/) หน่วยเป็นวินาที
- **Delay** แมพกับ [ITiming::set_TriggerDelayTime](https://reference.aspose.com/slides/th/cpp/aspose.slides.animation/itiming/set_triggerdelaytime/) หน่วยเป็นวินาที
- **Repeat** แมพกับ [ITiming::set_RepeatCount](https://reference.aspose.com/slides/th/cpp/aspose.slides.animation/itiming/set_repeatcount/), [ITiming::set_RepeatUntilNextClick](https://reference.aspose.com/slides/th/cpp/aspose.slides.animation/itiming/set_repeatuntilnextclick/) หรือ [ITiming::set_RepeatUntilEndSlide](https://reference.aspose.com/slides/th/cpp/aspose.slides.animation/itiming/set_repeatuntilendslide/)
- **Rewind when done playing** แมพกับ [ITiming::set_Rewind](https://reference.aspose.com/slides/th/cpp/aspose.slides.animation/itiming/set_rewind/)

ตัวอย่างอิสระนี้เพิ่มเอฟเฟกต์, ปรับเวลาผ่านออบเจกต์ที่คืนจาก [ISequence::AddEffect](https://reference.aspose.com/slides/th/cpp/aspose.slides.animation/isequence/addeffect/), แล้วบันทึกผลลัพธ์ การเก็บอ้างอิง [IEffect](https://reference.aspose.com/slides/th/cpp/aspose.slides.animation/ieffect/) ที่คืนกลับช่วยหลีกเลี่ยงการอ้างอิงดัชนีคอลเลกชันที่ไม่จำเป็น

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

ใช้โหมด repeat อย่างใดอย่างหนึ่งเท่านั้น การรวมจำนวน repeat กับแฟล็ก “until” อาจทำให้ผลลัพธ์สับสนในโปรแกรมดูต่าง ๆ เมื่อเปลี่ยนโหมด repeat ให้เรียก [ITiming::set_RepeatUntilNextClick](https://reference.aspose.com/slides/th/cpp/aspose.slides.animation/itiming/set_repeatuntilnextclick/) และ [ITiming::set_RepeatUntilEndSlide](https://reference.aspose.com/slides/th/cpp/aspose.slides.animation/itiming/set_repeatuntilendslide/) ก่อน [ITiming::set_RepeatCount](https://reference.aspose.com/slides/th/cpp/aspose.slides.animation/itiming/set_repeatcount/) เพราะการตั้งค่าแฟล็กใดแฟล็กหนึ่งจะทำให้โหมด repeat ที่ใช้งานเปลี่ยนไปด้วย

## **เพิ่มและสกัดเสียงเอฟเฟกต์การเคลื่อนไหว**

เอฟเฟกต์การเคลื่อนไหวสามารถอ้างอิงไฟล์เสียงที่ฝังไว้ผ่าน [IEffect::set_Sound](https://reference.aspose.com/slides/th/cpp/aspose.slides.animation/ieffect/set_sound/) [IEffect::set_StopPreviousSound](https://reference.aspose.com/slides/th/cpp/aspose.slides.animation/ieffect/set_stopprevioussound/) บอกให้เอฟเฟกต์หยุดเสียงที่เริ่มโดยเอฟเฟกต์ก่อนหน้า

### **เพิ่มเสียงให้กับเอฟเฟกต์**

ตัวอย่างต่อไปนี้ต้องการไฟล์เสียงภายในที่ชื่อ `animation-sound.wav` สร้างเอฟเฟกต์สองตัว, ฝังไฟล์ดังกล่าวเป็นเสียงของเอฟเฟกต์แรก, และกำหนดให้เอฟเฟกต์ที่สองหยุดเสียง ใช้ออบเจกต์ที่คืนจาก [ISequence::AddEffect](https://reference.aspose.com/slides/th/cpp/aspose.slides.animation/isequence/addeffect/) ดังนั้นไม่จำเป็นต้องระบุดัชนีของลำดับ

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

### **สกัดเสียงเอฟเฟกต์ที่ฝังไว้**

ตัวอย่างต่อไปนี้ต้องการไฟล์งานนำเสนอชื่อ `presentation-with-animation-sounds.pptx` จะสแกนลำดับหลักและลำดับเชิงโต้ตอบทั้งหมดและเขียนเสียงเอฟเฟกต์ที่ฝังไว้ทุกไฟล์ไปยังโฟลเดอร์ `extracted-animation-sounds` ส่วนขยายไฟล์จะถูกเลือกตาม MIME type ของเสียงที่ให้โดย [IAudio::get_ContentType](https://reference.aspose.com/slides/th/cpp/aspose.slides/iaudio/get_contenttype/)

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

สำหรับออบเจกต์เสียงขนาดใหญ่ ใช้ [IAudio::GetStream](https://reference.aspose.com/slides/th/cpp/aspose.slides/iaudio/getstream/) แล้วคัดลอกสตรีมไปยังไฟล์แทนการโหลดออบเจกต์ทั้งหมดเข้าสู่ byte array

## **ตั้งค่าการกระทำหลังการเคลื่อนไหว**

ตัวเลือก **After animation** ควบคุมว่าจะทำอะไรกับรูปทรงหลังจากเอฟเฟกต์สิ้นสุด

![ไดอะล็อก Options ของเอฟเฟกต์ PowerPoint แสดงการตั้งค่า After animation](shape-after-animation.png)

ลำดับการ enumerated ของ [AfterAnimationType](https://reference.aspose.com/slides/th/cpp/aspose.slides.animation/afteranimationtype/) รองรับการคงรูปทรงเดิม, เปลี่ยนสี, ซ่อนหลังการเคลื่อนไหว, หรือซ่อนเมื่อคลิกครั้งถัดไป เมื่อชนิดเป็น [AfterAnimationType::Color](https://reference.aspose.com/slides/th/cpp/aspose.slides.animation/afteranimationtype/) ให้เรียก [IEffect::get_AfterAnimationColor](https://reference.aspose.com/slides/th/cpp/aspose.slides.animation/ieffect/get_afteranimationcolor/) เพื่อกำหนดสีด้วย

ตัวอย่างอิสระนี้สร้างเอฟเฟกต์, ตั้งค่าพฤติกรรมหลังการเคลื่อนไหวผ่านออบเจกต์เอฟเฟกต์ที่คืนกลับ, แล้วบันทึกผลลัพธ์

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

การเปลี่ยนชนิดจาก [AfterAnimationType::Color](https://reference.aspose.com/slides/th/cpp/aspose.slides.animation/afteranimationtype/) จะล้างการตั้งค่าสีหลังการเคลื่อนไหว

## **เคลื่อนไหวข้อความ**

การเคลื่อนไหวของข้อความมีสองการควบคุมที่เกี่ยวข้อง:

- [ITextAnimation::set_BuildType](https://reference.aspose.com/slides/th/cpp/aspose.slides.animation/itextanimation/set_buildtype/) กำหนดว่ากย paragrap​h จะปรากฏพร้อมกันหรือเป็นระดับย่อยของย paragrap​h
- [IEffect::set_AnimateTextType](https://reference.aspose.com/slides/th/cpp/aspose.slides.animation/ieffect/set_animatetexttype/) กำหนดว่าข้อความจะปรากฏทั้งหมดพร้อมกัน, ทีละคำ, หรือทีละตัวอักษร [IEffect::set_DelayBetweenTextParts](https://reference.aspose.com/slides/th/cpp/aspose.slides.animation/ieffect/set_delaybetweentextparts/) ตั้งค่าความล่าช้าระหว่างคำหรืออักษร ค่าบวกเป็นเปอร์เซ็นต์ของระยะเวลาของเอฟเฟกต์; ค่าลบเป็นหน่วยวินาที

ตัวอย่างอิสระต่อไปนี้เคลื่อนไหวคำในกล่องข้อความ [BuildType::AsOneObject](https://reference.aspose.com/slides/th/cpp/aspose.slides.animation/buildtype/) ปิดการสร้างทีละย paragrap​h เพื่อให้การตั้งค่าคำนำไปใช้กับเฟรมข้อความทั้งหมด

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

หากต้องการสร้างกล่องข้อความเป็นย paragrap​h ใช้ [ITextAnimation::set_BuildType](https://reference.aspose.com/slides/th/cpp/aspose.slides.animation/itextanimation/set_buildtype/) ร่วมกับ [BuildType::ByLevelParagraphs1](https://reference.aspose.com/slides/th/cpp/aspose.slides.animation/buildtype/) หรือระดับย paragrap​h อื่น ๆ เพื่อกำหนดเอฟเฟกต์ให้กับย paragrap​h เดี่ยว ให้ใช้การ overload ของ [ISequence::AddEffect](https://reference.aspose.com/slides/th/cpp/aspose.slides.animation/isequence/addeffect/) ที่รับ [IParagraph](https://reference.aspose.com/slides/th/cpp/aspose.slides/iparagraph/) ดูที่ [Animated Text](/slides/th/cpp/animated-text/) สำหรับตัวอย่างระดับย paragrap​h

## **การส่งออกและบันทึกหมายเหตุความเข้ากันได้**

- การบันทึกเป็น PPT หรือ PPTX จะคงโมเดลการเคลื่อนไหวไว้, แต่การเล่นจริงขึ้นอยู่กับโปรแกรมดูพรีเซนเทชัน
- PDF และภาพนิ่งจะไม่เล่นการเคลื่อนไหว ใช้ [HTML5 export](/slides/th/cpp/export-to-html5/), GIF ที่เคลื่อนไหว, หรือ [video conversion](/slides/th/cpp/convert-powerpoint-to-video/) เมื่อผลลัพธ์ต้องแสดงการเคลื่อนไหว
- สำหรับ HTML5 ให้เปิดใช้งาน [Html5Options::set_AnimateShapes](https://reference.aspose.com/slides/th/cpp/aspose.slides.export/html5options/set_animateshapes/) และตามต้องการ [Html5Options::set_AnimateTransitions](https://reference.aspose.com/slides/th/cpp/aspose.slides.export/html5options/set_animatetransitions/)
- การเรนเดอร์วิดีโอรองรับเอฟเฟกต์การเข้ามา, เน้น, ออก, และเส้นทางการเคลื่อนที่หลายประเภท, แต่ไม่รองรับเอฟเฟกต์ PowerPoint ทุกอย่าง ตรวจสอบ [supported animations and effects](/slides/th/cpp/convert-powerpoint-to-video/#supported-animations-and-effects) ปัจจุบันและทดสอบพรีเซนเทชันที่สำคัญกับรุ่น Aspose.Slides ที่คุณใช้
- เอฟเฟกต์ที่กำหนดเองขั้นสูงและเอฟเฟกต์ที่นำเข้าจากรูปแบบพรีเซนเทชันอื่นอาจถูกเก็บไว้ในไฟล์แต่แสดงผลต่างกันใน PowerPoint, HTML5 หรือวิดีโอ ตรวจสอบผลการส่งออกแทนการอ้างอิงชื่อเอฟเฟกต์อย่างเดียว

## **คำถามที่พบบ่อย**

**ทำไมการเคลื่อนไหวถึงแสดงใน PowerPoint แต่ไม่แสดงใน PDF?**

PDF เป็นรูปแบบสถิตย์จึงไม่สนับสนุนการเคลื่อนไหวและการเปลี่ยนสไลด์ ให้ส่งออกเป็น HTML5, GIF ที่เคลื่อนไหว, หรือวิดีโอเมื่อจำเป็นต้องคงการเคลื่อนไหว

**ทำไมเอฟเฟกต์จึงเล่นแตกต่างกันในวิดีโอ?**

การส่งออกเป็นวิดีโอจะเรนเดอร์การเคลื่อนไหวแทนการเก็บพฤติกรรมดั้งเดิมของ PowerPoint บางเอฟเฟกต์ขั้นสูงอาจไม่ได้รับการสนับสนุนหรือถูกประมาณค่า ตรวจสอบตารางเอฟเฟกต์ที่สนับสนุนและทดสอบพรีเซนเทชันจริงก่อนการผลิต

**การย้ายรูปทรงไปข้างหน้า หรือข้างหลัง มีผลต่อลำดับการเคลื่อนไหวหรือไม่?**

ไม่มี ลำดับ z-order ของรูปทรงควบคุมการวางซ้อนกัน, ส่วนลำดับของลำดับและตัวกระตุ้นควบคุมการเล่นการเคลื่อนไหว ปรับไทม์ไลน์หากต้องการลำดับการเล่นที่ต่างออกไป