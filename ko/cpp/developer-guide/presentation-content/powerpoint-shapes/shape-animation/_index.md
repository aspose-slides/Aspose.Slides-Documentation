---
title: C++ 를 사용해 프레젠테이션에 도형 애니메이션 적용
linktitle: 도형 애니메이션
type: docs
weight: 60
url: /ko/cpp/shape-animation/
keywords:
- 도형
- 애니메이션
- 효과
- 애니메이션 도형
- 애니메이션 텍스트
- 애니메이션 추가
- 애니메이션 가져오기
- 애니메이션 추출
- 효과 추가
- 효과 가져오기
- 효과 추출
- 효과 사운드
- 애니메이션 적용
- PowerPoint
- 프레젠테이션
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ 를 사용하여 도형 애니메이션, 타이밍, 사운드, 애니메이션 후 동작 및 애니메이션 텍스트를 추가, 검사 및 사용자 지정하는 방법을 학습합니다."
---
## **개요**

Aspose.Slides for C++ 은 슬라이드 타임라인에서 슬라이드 애니메이션을 효과로 나타냅니다. 효과에는 대상 모양, 애니메이션 유형 및 하위 유형, 트리거, 타이밍 설정, 그리고 사운드나 애니메이션 후 동작과 같은 선택적 속성이 포함될 수 있습니다.

타임라인에는 두 종류의 시퀀스가 있습니다:

- **주 시퀀스**는 슬라이드가 진행될 때 재생됩니다.
- **대화형 시퀀스**는 트리거 모양을 클릭하면 시작됩니다.

텍스트 상자, 그림, 차트, 표 및 기타 슬라이드 개체는 모두 [IShape](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ishape/)을 구현하므로 대부분의 슬라이드 콘텐츠에 대해 동일한 [ISequence::AddEffect](https://reference.aspose.com/slides/ko/cpp/aspose.slides.animation/isequence/addeffect/) 메서드를 사용합니다. 사용 가능한 효과는 [EffectType](https://reference.aspose.com/slides/ko/cpp/aspose.slides.animation/effecttype/) 열거형에 나열되어 있습니다.

## **모양 애니메이션 추가**

애니메이션을 추가하려면 슬라이드의 주 시퀀스를 가져와 대상 모양, 효과 유형, 하위 유형 및 트리거와 함께 [ISequence::AddEffect](https://reference.aspose.com/slides/ko/cpp/aspose.slides.animation/isequence/addeffect/) 를 호출합니다. 다른 모양을 클릭했을 때 시작되는 효과의 경우, 해당 다른 모양을 트리거로 하는 대화형 시퀀스를 생성합니다.

다음 예제는 두 종류의 애니메이션을 모두 생성하고 결과를 `shape-animations.pptx` 로 저장합니다.

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

트리거는 효과가 시작되는 시점을 제어합니다:

- [EffectTriggerType::OnClick](https://reference.aspose.com/slides/ko/cpp/aspose.slides.animation/effecttriggertype/) 은 주 시퀀스에서는 클릭을 기다리며, 대화형 시퀀스에서는 트리거 모양을 클릭하면 시작됩니다.
- [EffectTriggerType::WithPrevious](https://reference.aspose.com/slides/ko/cpp/aspose.slides.animation/effecttriggertype/) 은 이전 효과와 동시에 시작됩니다.
- [EffectTriggerType::AfterPrevious](https://reference.aspose.com/slides/ko/cpp/aspose.slides.animation/effecttriggertype/) 은 이전 효과가 끝난 후 시작됩니다.

그림, 차트 또는 다른 모양 유형을 애니메이션하려면 `targetShape` 대신 해당 객체를 [ISequence::AddEffect](https://reference.aspose.com/slides/ko/cpp/aspose.slides.animation/isequence/addeffect/) 에 전달합니다. 차트 전용 그룹화 옵션은 [Animated Charts](/slides/ko/cpp/animated-charts/) 를 참고하십시오.

## **모양 애니메이션 읽기**

대상 모양을 알고 있을 때는 [ISequence::GetEffectsByShape](https://reference.aspose.com/slides/ko/cpp/aspose.slides.animation/isequence/geteffectsbyshape/) 를 사용합니다. 모든 효과를 검사하려면 주 시퀀스와 모든 대화형 시퀀스를 열거합니다. 열거는 시퀀스가 인덱스 `0` 에 효과가 있다고 가정하는 것을 방지합니다.

다음 예제는 주 시퀀스 및 대화형 효과가 포함된 모양을 만들고, 해당 모양을 대상으로 하는 효과를 가져온 다음 슬라이드의 모든 시퀀스를 열거합니다.

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

하나의 모양에 대해서만 효과가 필요한 경우 먼저 이름, 자리표시자 유형 또는 다른 안정적인 속성으로 모양을 식별한 다음 [ISequence::GetEffectsByShape](https://reference.aspose.com/slides/ko/cpp/aspose.slides.animation/isequence/geteffectsbyshape/) 를 호출하십시오. 인덱스 `0` 에 있는 [IShapeCollection::idx_get](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ishapecollection/idx_get/) 가 항상 의도한 객체라고 가정하지 마세요.

## **상속된 자리표시자 효과 작업**

일반 슬라이드의 자리표시자는 레이아웃 슬라이드와 마스터 슬라이드에 있는 해당 자리표시자로부터 애니메이션 동작을 상속받을 수 있습니다. [IShape::GetBasePlaceholder](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ishape/getbaseplaceholder/) 은 부모 자리표시자를 반환하며, 부모가 없으면 `nullptr` 를 반환합니다.

다음 예제 프레젠테이션에서 푸터는 일반 슬라이드에서는 **Random Bars**, 레이아웃 슬라이드에서는 **Split**, 마스터 슬라이드에서는 **Fly In** 효과를 가지고 있습니다.

![일반 슬라이드의 바닥글 애니메이션 효과](slide-shape-animation.png)

![레이아웃 슬라이드의 바닥글 자리표시자 애니메이션 효과](layout-shape-animation.png)

![마스터 슬라이드의 바닥글 자리표시자 애니메이션 효과](master-shape-animation.png)

다음 예제는 자리표시자 계층 구조 자체를 구축합니다. 마스터 자리표시자, 레이아웃 자리표시자 및 일반 슬라이드의 해당 자리표시자에 효과를 추가합니다. [IShape::GetBasePlaceholder](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ishape/getbaseplaceholder/) 호출 결과가 `null` 이 아닌지 확인한 후에만 반환된 모양을 사용합니다.

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

## **애니메이션 타이밍 변경**

PowerPoint **Timing** 대화상자는 [ITiming](https://reference.aspose.com/slides/ko/cpp/aspose.slides.animation/itiming/) 의 메서드에 매핑됩니다.

![애니메이션 효과에 대한 PowerPoint 타이밍 대화상자](shape-animation.png)

- **Start** 는 [ITiming::set_TriggerType](https://reference.aspose.com/slides/ko/cpp/aspose.slides.animation/itiming/set_triggertype/) 에 매핑됩니다.
- **Duration** 은 초 단위로 [ITiming::set_Duration](https://reference.aspose.com/slides/ko/cpp/aspose.slides.animation/itiming/set_duration/) 에 매핑됩니다.
- **Delay** 은 초 단위로 [ITiming::set_TriggerDelayTime](https://reference.aspose.com/slides/ko/cpp/aspose.slides.animation/itiming/set_triggerdelaytime/) 에 매핑됩니다.
- **Repeat** 은 [ITiming::set_RepeatCount](https://reference.aspose.com/slides/ko/cpp/aspose.slides.animation/itiming/set_repeatcount/), [ITiming::set_RepeatUntilNextClick](https://reference.aspose.com/slides/ko/cpp/aspose.slides.animation/itiming/set_repeatuntilnextclick/), 또는 [ITiming::set_RepeatUntilEndSlide](https://reference.aspose.com/slides/ko/cpp/aspose.slides.animation/itiming/set_repeatuntilendslide/) 에 매핑됩니다.
- **Rewind when done playing** 은 [ITiming::set_Rewind](https://reference.aspose.com/slides/ko/cpp/aspose.slides.animation/itiming/set_rewind/) 에 매핑됩니다.

이 독립 예제는 효과를 추가하고, [ISequence::AddEffect](https://reference.aspose.com/slides/ko/cpp/aspose.slides.animation/isequence/addeffect/) 로 반환된 객체를 통해 타이밍을 변경한 뒤 결과를 저장합니다. 반환된 [IEffect](https://reference.aspose.com/slides/ko/cpp/aspose.slides.animation/ieffect/) 참조를 유지하면 불필요한 컬렉션 인덱스를 피할 수 있습니다.

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

반복 모드는 하나만 사용하십시오. 반복 횟수와 “until” 플래그를 함께 사용하면 다양한 뷰어에서 혼란스러운 결과가 발생할 수 있습니다. 반복 모드를 변경할 때는 [ITiming::set_RepeatUntilNextClick](https://reference.aspose.com/slides/ko/cpp/aspose.slides.animation/itiming/set_repeatuntilnextclick/) 과 [ITiming::set_RepeatUntilEndSlide](https://reference.aspose.com/slides/ko/cpp/aspose.slides.animation/itiming/set_repeatuntilendslide/) 을 먼저 호출하고, 그 다음에 [ITiming::set_RepeatCount](https://reference.aspose.com/slides/ko/cpp/aspose.slides.animation/itiming/set_repeatcount/) 를 호출해야 합니다. 왜냐하면 플래그를 설정하면 활성 반복 모드가 변경되기 때문입니다.

## **애니메이션 사운드 추가 및 추출**

애니메이션 효과는 [IEffect::set_Sound](https://reference.aspose.com/slides/ko/cpp/aspose.slides.animation/ieffect/set_sound/) 로 임베드된 오디오를 참조할 수 있습니다. [IEffect::set_StopPreviousSound](https://reference.aspose.com/slides/ko/cpp/aspose.slides.animation/ieffect/set_stopprevioussound/) 은 이전 효과에서 시작된 오디오를 중지하도록 지시합니다.

### **효과에 사운드 추가**

다음 예제는 `animation-sound.wav` 라는 로컬 오디오 파일을 요구합니다. 두 개의 효과를 만들고 첫 번째 효과의 사운드로 해당 파일을 임베드하며, 두 번째 효과가 사운드를 중지하도록 구성합니다. [ISequence::AddEffect](https://reference.aspose.com/slides/ko/cpp/aspose.slides.animation/isequence/addeffect/) 로 반환된 객체를 사용하므로 시퀀스 인덱스가 필요하지 않습니다.

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

### **내장된 효과 사운드 추출**

다음 예제는 `presentation-with-animation-sounds.pptx` 라는 로컬 프레젠테이션을 요구합니다. 주 시퀀스와 대화형 시퀀스를 모두 스캔하고 임베드된 모든 효과 사운드를 `extracted-animation-sounds` 디렉터리에 기록합니다. 확장자는 [IAudio::get_ContentType](https://reference.aspose.com/slides/ko/cpp/aspose.slides/iaudio/get_contenttype/) 에서 제공되는 오디오 MIME 타입을 기반으로 선택됩니다.

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

대용량 오디오 객체의 경우 [IAudio::GetStream](https://reference.aspose.com/slides/ko/cpp/aspose.slides/iaudio/getstream/) 을 사용해 스트림을 파일에 복사하면 전체 객체를 바이트 배열로 로드하지 않아도 됩니다.

## **애니메이션 후 동작 설정**

**After animation** 옵션은 효과가 끝난 후 모양에 어떤 일이 일어날지를 제어합니다.

![After animation 설정을 표시하는 PowerPoint 효과 옵션 대화상자](shape-after-animation.png)

[AfterAnimationType](https://reference.aspose.com/slides/ko/cpp/aspose.slides.animation/afteranimationtype/) 열거형은 모양을 그대로 두거나, 색을 변경하거나, 애니메이션 후 숨기거나, 다음 클릭 시 숨기는 옵션을 지원합니다. 유형이 [AfterAnimationType::Color](https://reference.aspose.com/slides/ko/cpp/aspose.slides.animation/afteranimationtype/) 인 경우 [IEffect::get_AfterAnimationColor](https://reference.aspose.com/slides/ko/cpp/aspose.slides.animation/ieffect/get_afteranimationcolor/) 로 색상을 함께 설정합니다.

이 독립 예제는 효과를 생성하고 반환된 효과 객체를 통해 after‑animation 동작을 설정한 뒤 결과를 저장합니다.

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

[AfterAnimationType::Color](https://reference.aspose.com/slides/ko/cpp/aspose.slides.animation/afteranimationtype/) 를 다른 유형으로 변경하면 after‑animation 색상 설정이 초기화됩니다.

## **텍스트 애니메이션**

텍스트 애니메이션에는 두 가지 관련 컨트롤이 있습니다:

- [ITextAnimation::set_BuildType](https://reference.aspose.com/slides/ko/cpp/aspose.slides.animation/itextanimation/set_buildtype/) 은 단락을 함께 표시할지 단락 수준으로 표시할지를 제어합니다.
- [IEffect::set_AnimateTextType](https://reference.aspose.com/slides/ko/cpp/aspose.slides.animation/ieffect/set_animatetexttype/) 은 텍스트가 한 번에, 단어별 또는 글자별로 나타날지를 제어합니다. [IEffect::set_DelayBetweenTextParts](https://reference.aspose.com/slides/ko/cpp/aspose.slides.animation/ieffect/set_delaybetweentextparts/) 은 단어 또는 글자 사이의 지연을 설정합니다. 양수 값은 효과 지속 시간의 백분율이며, 음수 값은 초 단위 지연입니다.

다음 독립 예제는 텍스트 상자의 단어를 애니메이션합니다. [BuildType::AsOneObject](https://reference.aspose.com/slides/ko/cpp/aspose.slides.animation/buildtype/) 은 단락별 빌드를 비활성화하여 단어 설정이 전체 텍스트 프레임에 적용되도록 합니다.

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

단락별로 텍스트 상자를 빌드하려면 [ITextAnimation::set_BuildType](https://reference.aspose.com/slides/ko/cpp/aspose.slides.animation/itextanimation/set_buildtype/) 에 [BuildType::ByLevelParagraphs1](https://reference.aspose.com/slides/ko/cpp/aspose.slides.animation/buildtype/) 등 적절한 단락 수준을 지정하십시오. 단일 단락에 별도 효과를 적용하려면 [IParagraph](https://reference.aspose.com/slides/ko/cpp/aspose.slides/iparagraph/) 을 받는 [ISequence::AddEffect](https://reference.aspose.com/slides/ko/cpp/aspose.slides.animation/isequence/addeffect/) 오버로드를 사용합니다. 단락 수준 예제는 [Animated Text](/slides/ko/cpp/animated-text/) 를 참고하세요.

## **내보내기 및 호환성 참고**

- PPT 또는 PPTX 로 저장하면 애니메이션 모델이 보존되지만 최종 재생은 프레젠테이션 뷰어가 제어합니다.
- PDF 및 정적 이미지는 애니메이션을 재생하지 않습니다. 움직임을 보여야 할 경우 [HTML5 export](/slides/ko/cpp/export-to-html5/), 애니메이션 GIF 또는 [video conversion](/slides/ko/cpp/convert-powerpoint-to-video/) 를 사용하십시오.
- HTML5 를 위해서는 [Html5Options::set_AnimateShapes](https://reference.aspose.com/slides/ko/cpp/aspose.slides.export/html5options/set_animateshapes/) 를 활성화하고, 필요에 따라 [Html5Options::set_AnimateTransitions](https://reference.aspose.com/slides/ko/cpp/aspose.slides.export/html5options/set_animatetransitions/) 를 사용하십시오.
- 비디오 렌더링은 일반적인 입장, 강조, 종료 및 움직임 경로 효과를 많이 지원하지만 모든 PowerPoint 효과를 지원하는 것은 아닙니다. 현재 [supported animations and effects](/slides/ko/cpp/convert-powerpoint-to-video/#supported-animations-and-effects) 를 확인하고 대상 Aspose.Slides 버전으로 중요한 프레젠테이션을 테스트하십시오.
- 고급 사용자 지정 효과 및 다른 프레젠테이션 형식에서 가져온 효과는 파일에 보존될 수 있으나 PowerPoint, HTML5 또는 비디오에서 다르게 렌더링될 수 있습니다. 효과 이름만을 근거로 하지 말고 내보낸 결과를 검증하십시오.

## **FAQ**

**PowerPoint에서는 애니메이션이 보이는데 PDF에서는 보이지 않는 이유는?**

PDF는 정적 형식이므로 애니메이션과 슬라이드 전환이 재생되지 않습니다. 움직임을 유지해야 할 경우 HTML5, 애니메이션 GIF 또는 비디오로 내보내십시오.

**비디오에서 효과가 다르게 재생되는 이유는?**

비디오 내보내기는 애니메이션을 실제로 렌더링하며 원래 PowerPoint 동작을 저장하지 않습니다. 일부 고급 효과는 지원되지 않거나 근사 처리됩니다. 지원되는 효과 표를 확인하고 실제 프레젠테이션을 테스트하십시오.

**모양을 앞으로 또는 뒤로 이동하면 애니메이션 순서가 변경되나요?**

아니요. 모양의 z‑order 는 겹침을 제어하고, 시퀀스 순서와 트리거가 애니메이션 재생을 제어합니다. 재생 순서를 변경하려면 타임라인을 조정해야 합니다.