---
title: C++을 사용하여 프레젠테이션에 형상 애니메이션 적용
linktitle: 형상 애니메이션
type: docs
weight: 60
url: /ko/cpp/shape-animation/
keywords:
- 형상
- 애니메이션
- 효과
- 애니메이션 형상
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
description: "Aspose.Slides for C++를 사용하여 형상 애니메이션, 타이밍, 사운드, 애니메이션 후 동작 및 애니메이션 텍스트를 추가, 검사 및 사용자 지정하는 방법을 배웁니다."
---
## **개요**

효과 내부의 개별 동작을 다루거나 이동 경로 세그먼트를 편집하려면, [사용자 지정 애니메이션](/slides/ko/cpp/custom-animation/)을 참조하십시오.

Aspose.Slides for C++는 슬라이드 타임라인에서 효과로 슬라이드 애니메이션을 나타냅니다. 효과는 대상 형상, 애니메이션 종류 및 하위 종류, 트리거, 타이밍 설정, 그리고 사운드 또는 애니메이션 후 동작과 같은 선택적 속성을 가집니다.

타임라인에는 두 가지 종류의 시퀀스가 포함됩니다:
- **메인 시퀀스**는 슬라이드가 진행됨에 따라 재생됩니다.
- **인터랙티브 시퀀스**는 트리거 형상이 클릭될 때 시작됩니다.

텍스트 상자, 그림, 차트, 표 및 기타 슬라이드 개체는 [IShape](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ishape/)를 구현하므로 대부분의 슬라이드 콘텐츠에 대해 동일한 [ISequence::AddEffect](https://reference.aspose.com/slides/ko/cpp/aspose.slides.animation/isequence/addeffect/) 메서드를 사용합니다. 사용 가능한 효과는 [EffectType](https://reference.aspose.com/slides/ko/cpp/aspose.slides.animation/effecttype/) 열거형에 나열되어 있습니다.

## **형상 애니메이션 추가**

애니메이션을 추가하려면 슬라이드의 메인 시퀀스를 가져오고 대상 형상, 효과 유형, 하위 유형 및 트리거를 지정하여 [ISequence::AddEffect](https://reference.aspose.com/slides/ko/cpp/aspose.slides.animation/isequence/addeffect/)를 호출합니다. 다른 형상이 클릭될 때 시작되는 효과의 경우, 해당 형상을 트리거로 하는 인터랙티브 시퀀스를 생성합니다.

다음 예제는 두 유형의 애니메이션을 모두 생성하고 결과를 `shape-animations.pptx` 파일에 저장합니다.

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
- [EffectTriggerType::OnClick](https://reference.aspose.com/slides/ko/cpp/aspose.slides.animation/effecttriggertype/)은 메인 시퀀스에서 클릭을 기다리거나 인터랙티브 시퀀스에서 트리거 형상의 클릭을 기다립니다.
- [EffectTriggerType::WithPrevious](https://reference.aspose.com/slides/ko/cpp/aspose.slides.animation/effecttriggertype/)은 앞선 효과와 함께 시작합니다.
- [EffectTriggerType::AfterPrevious](https://reference.aspose.com/slides/ko/cpp/aspose.slides.animation/effecttriggertype/)은 앞선 효과가 끝났을 때 시작합니다.

그림, 차트 또는 다른 형상 유형을 애니메이션하려면 `targetShape` 대신 해당 객체를 [ISequence::AddEffect](https://reference.aspose.com/slides/ko/cpp/aspose.slides.animation/isequence/addeffect/)에 전달합니다. 차트 전용 그룹화 옵션은 [Animated Charts](/slides/ko/cpp/animated-charts/)를 참조하십시오.

## **형상 애니메이션 읽기**

대상 형상을 알고 있을 때는 [ISequence::GetEffectsByShape](https://reference.aspose.com/slides/ko/cpp/aspose.slides.animation/isequence/geteffectsbyshape/)를 사용하십시오. 모든 효과를 검사하려면 메인 시퀀스와 모든 인터랙티브 시퀀스를 열거합니다. 열거를 사용하면 시퀀스가 인덱스 `0`에 효과를 포함한다고 가정하는 것을 방지할 수 있습니다.

다음 예제는 메인 시퀀스와 인터랙티브 효과를 가진 형상을 생성하고, 해당 형상을 대상으로 하는 효과를 가져온 다음 슬라이드의 모든 시퀀스를 열거합니다.

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

하나의 형상에 대한 효과만 필요하다면 먼저 이름, 플레이스홀더 유형 또는 다른 안정적인 속성으로 형상을 식별하고 [ISequence::GetEffectsByShape](https://reference.aspose.com/slides/ko/cpp/aspose.slides.animation/isequence/geteffectsbyshape/)를 호출하십시오. 인덱스 `0`에 있는 [IShapeCollection::idx_get](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ishapecollection/idx_get/)가 항상 의도된 객체라고 가정하지 마십시오.

## **상속된 플레이스홀더 효과 작업**

일반 슬라이드의 플레이스홀더는 레이아웃 슬라이드와 마스터 슬라이드에 있는 해당 플레이스홀더로부터 애니메이션 동작을 상속할 수 있습니다. [IShape::GetBasePlaceholder](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ishape/getbaseplaceholder/)은 해당 부모 플레이스홀더를 반환하거나, 부모가 없을 경우 `nullptr`를 반환합니다.

다음 예제 프레젠테이션에서 푸터는 일반 슬라이드에서는 **Random Bars**, 레이아웃 슬라이드에서는 **Split**, 마스터 슬라이드에서는 **Fly In** 효과를 가지고 있습니다.

![일반 슬라이드의 푸터 애니메이션 효과](slide-shape-animation.png)

![레이아웃 슬라이드의 푸터 플레이스홀더 애니메이션 효과](layout-shape-animation.png)

![마스터 슬라이드의 푸터 플레이스홀더 애니메이션 효과](master-shape-animation.png)

다음 예제는 플레이스홀더 계층 구조를 직접 구축합니다. 마스터 플레이스홀더, 레이아웃 플레이스홀더 및 일반 슬라이드의 해당 플레이스홀더에 효과를 추가합니다. 반환된 형상을 사용하기 전에 [IShape::GetBasePlaceholder](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ishape/getbaseplaceholder/)에 대한 모든 호출을 확인합니다.

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

PowerPoint **Timing** 대화 상자는 [ITiming](https://reference.aspose.com/slides/ko/cpp/aspose.slides.animation/itiming/) 메서드에 매핑됩니다.

![애니메이션 효과에 대한 PowerPoint 타이밍 대화 상자](shape-animation.png)

- **Start**는 [ITiming::set_TriggerType](https://reference.aspose.com/slides/ko/cpp/aspose.slides.animation/itiming/set_triggertype/)에 매핑됩니다.
- **Duration**은 초 단위로 [ITiming::set_Duration](https://reference.aspose.com/slides/ko/cpp/aspose.slides.animation/itiming/set_duration/)에 매핑됩니다.
- **Delay**는 초 단위로 [ITiming::set_TriggerDelayTime](https://reference.aspose.com/slides/ko/cpp/aspose.slides.animation/itiming/set_triggerdelaytime/)에 매핑됩니다.
- **Repeat**은 [ITiming::set_RepeatCount](https://reference.aspose.com/slides/ko/cpp/aspose.slides.animation/itiming/set_repeatcount/), [ITiming::set_RepeatUntilNextClick](https://reference.aspose.com/slides/ko/cpp/aspose.slides.animation/itiming/set_repeatuntilnextclick/) 또는 [ITiming::set_RepeatUntilEndSlide](https://reference.aspose.com/slides/ko/cpp/aspose.slides.animation/itiming/set_repeatuntilendslide/)에 매핑됩니다.
- **Rewind when done playing**은 [ITiming::set_Rewind](https://reference.aspose.com/slides/ko/cpp/aspose.slides.animation/itiming/set_rewind/)에 매핑됩니다.

이 독립적인 예제는 효과를 추가하고 [ISequence::AddEffect](https://reference.aspose.com/slides/ko/cpp/aspose.slides.animation/isequence/addeffect/)가 반환한 객체를 통해 타이밍을 변경한 뒤 결과를 저장합니다. 반환된 [IEffect](https://reference.aspose.com/slides/ko/cpp/aspose.slides.animation/ieffect/) 참조를 유지하면 불필요한 컬렉션 인덱스를 피할 수 있습니다.

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

반복 모드를 의도적으로 하나만 사용하십시오. 반복 횟수와 "until" 플래그를 결합하면 다양한 뷰어에서 혼란스러운 결과를 초래할 수 있습니다. 반복 모드를 변경할 때는 [ITiming::set_RepeatCount](https://reference.aspose.com/slides/ko/cpp/aspose.slides.animation/itiming/set_repeatcount/)를 호출하기 전에 [ITiming::set_RepeatUntilNextClick](https://reference.aspose.com/slides/ko/cpp/aspose.slides.animation/itiming/set_repeatuntilnextclick/)와 [ITiming::set_RepeatUntilEndSlide](https://reference.aspose.com/slides/ko/cpp/aspose.slides.animation/itiming/set_repeatuntilendslide/)를 호출하십시오. 두 플래그 중 하나를 설정하면 활성 반복 모드도 변경됩니다.

## **애니메이션 사운드 추가 및 추출**

애니메이션 효과는 [IEffect::set_Sound](https://reference.aspose.com/slides/ko/cpp/aspose.slides.animation/ieffect/set_sound/)를 통해 포함된 오디오를 참조할 수 있습니다. [IEffect::set_StopPreviousSound](https://reference.aspose.com/slides/ko/cpp/aspose.slides.animation/ieffect/set_stopprevioussound/)은 이전 효과에 의해 시작된 오디오를 중지하도록 효과에 지시합니다.

### **효과에 사운드 추가**

다음 예제는 `animation-sound.wav`라는 로컬 오디오 파일이 존재한다고 가정합니다. 두 개의 효과를 생성하고 해당 파일을 첫 번째 효과의 사운드로 포함시킨 뒤 두 번째 효과가 사운드를 중지하도록 구성합니다. [ISequence::AddEffect](https://reference.aspose.com/slides/ko/cpp/aspose.slides.animation/isequence/addeffect/)가 반환한 객체를 사용하므로 시퀀스 인덱스가 필요하지 않습니다.

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

### **포함된 효과 사운드 추출**

다음 예제는 `presentation-with-animation-sounds.pptx`라는 로컬 프레젠테이션이 존재한다고 가정합니다. 메인 및 인터랙티브 시퀀스를 모두 스캔하고 모든 포함된 효과 사운드를 `extracted-animation-sounds` 디렉터리에 저장합니다. 확장자는 [IAudio::get_ContentType](https://reference.aspose.com/slides/ko/cpp/aspose.slides/iaudio/get_contenttype/)에서 제공되는 오디오 MIME 타입을 기반으로 선택됩니다.

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

대용량 오디오 객체의 경우, 전체 객체를 바이트 배열로 로드하는 대신 [IAudio::GetStream](https://reference.aspose.com/slides/ko/cpp/aspose.slides/iaudio/getstream/)을 사용하여 스트림을 파일로 복사하십시오.

## **애니메이션 후 동작 설정**

**After animation** 옵션은 효과가 끝난 후 형상에 어떤 일이 일어나는지를 제어합니다.

![After animation 설정을 표시하는 PowerPoint 효과 옵션 대화 상자](shape-after-animation.png)

[AfterAnimationType](https://reference.aspose.com/slides/ko/cpp/aspose.slides.animation/afteranimationtype/) 열거형은 형상을 그대로 두기, 색상 변경, 애니메이션 후 숨기기, 또는 다음 클릭 시 숨기기를 지원합니다. 유형이 [AfterAnimationType::Color](https://reference.aspose.com/slides/ko/cpp/aspose.slides.animation/afteranimationtype/)인 경우, [IEffect::get_AfterAnimationColor](https://reference.aspose.com/slides/ko/cpp/aspose.slides.animation/ieffect/get_afteranimationcolor/)를 호출하여 색상을 설정합니다.

이 독립적인 예제는 효과를 생성하고 반환된 효과 객체를 통해 애니메이션 후 동작을 설정한 뒤 결과를 저장합니다.

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

[AfterAnimationType::Color](https://reference.aspose.com/slides/ko/cpp/aspose.slides.animation/afteranimationtype/) 유형을 다른 것으로 변경하면 애니메이션 후 색상 설정이 지워집니다.

## **텍스트 애니메이션**

텍스트 애니메이션에는 두 가지 관련 제어가 있습니다:
- [ITextAnimation::set_BuildType](https://reference.aspose.com/slides/ko/cpp/aspose.slides.animation/itextanimation/set_buildtype/)은 단락을 함께 표시할지 단락 레벨별로 표시할지를 제어합니다.
- [IEffect::set_AnimateTextType](https://reference.aspose.com/slides/ko/cpp/aspose.slides.animation/ieffect/set_animatetexttype/)은 텍스트가 한 번에, 단어별로 또는 글자별로 표시될지를 제어합니다. [IEffect::set_DelayBetweenTextParts](https://reference.aspose.com/slides/ko/cpp/aspose.slides.animation/ieffect/set_delaybetweentextparts/)은 단어 또는 글자 사이의 지연을 설정합니다. 양수 값은 효과 지속 시간의 비율이며, 음수 값은 초 단위 지연입니다.

다음 독립적인 예제는 텍스트 상자 안의 단어들을 애니메이션합니다. [BuildType::AsOneObject](https://reference.aspose.com/slides/ko/cpp/aspose.slides.animation/buildtype/)은 단락별 빌드를 비활성화하여 단어 설정이 전체 텍스트 프레임에 적용되도록 합니다.

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

단락별로 텍스트 상자를 빌드하려면 [ITextAnimation::set_BuildType](https://reference.aspose.com/slides/ko/cpp/aspose.slides.animation/itextanimation/set_buildtype/)와 함께 [BuildType::ByLevelParagraphs1](https://reference.aspose.com/slides/ko/cpp/aspose.slides.animation/buildtype/) 또는 다른 단락 레벨을 사용하십시오. 자체 효과가 있는 단일 단락을 대상으로 하려면 [IParagraph](https://reference.aspose.com/slides/ko/cpp/aspose.slides/iparagraph/)을 받아들이는 [ISequence::AddEffect](https://reference.aspose.com/slides/ko/cpp/aspose.slides.animation/isequence/addeffect/) 오버로드를 사용하십시오. 단락 수준 예제는 [Animated Text](/slides/ko/cpp/animated-text/)를 참조하십시오.

## **내보내기 및 호환성 참고사항**

- PPT 또는 PPTX로 저장하면 애니메이션 모델이 보존되지만 최종 재생은 프레젠테이션 뷰어에 의해 제어됩니다.
- PDF 및 정적 이미지는 애니메이션을 재생하지 않습니다. 출력에 움직임을 표시해야 할 경우 [HTML5 export](/slides/ko/cpp/export-to-html5/), 애니메이션 GIF 또는 [video conversion](/slides/ko/cpp/convert-powerpoint-to-video/)을 사용하십시오.
- HTML5의 경우 [Html5Options::set_AnimateShapes](https://reference.aspose.com/slides/ko/cpp/aspose.slides.export/html5options/set_animateshapes/)를 활성화하고 필요시 [Html5Options::set_AnimateTransitions](https://reference.aspose.com/slides/ko/cpp/aspose.slides.export/html5options/set_animatetransitions/)를 활성화하십시오.
- 비디오 렌더링은 일반적인 입장, 강조, 종료 및 움직임 경로 효과를 많이 지원하지만 모든 PowerPoint 효과를 지원하지는 않습니다. 현재 [supported animations and effects](/slides/ko/cpp/convert-powerpoint-to-video/#supported-animations-and-effects)를 확인하고 대상 Aspose.Slides 버전으로 중요한 프레젠테이션을 테스트하십시오.
- 고급 사용자 정의 효과 및 다른 프레젠테이션 형식에서 가져온 효과는 파일에 보존될 수 있지만 PowerPoint, HTML5 또는 비디오에서 다르게 렌더링될 수 있습니다. 효과 이름에만 의존하지 말고 내보낸 결과를 검증하십시오.

## **FAQ**

**왜 애니메이션이 PowerPoint에서는 보이지만 PDF에서는 보이지 않을까요?**

PDF는 정적 형식이므로 애니메이션 및 슬라이드 전환이 재생되지 않습니다. 움직임을 유지해야 할 경우 HTML5, 애니메이션 GIF 또는 비디오로 내보내십시오.

**왜 효과가 비디오에서 다르게 재생될까요?**

비디오 내보내기는 원본 PowerPoint 동작을 저장하지 않고 애니메이션을 렌더링합니다. 일부 고급 효과는 지원되지 않거나 근사됩니다. 지원되는 효과 표를 검토하고 실제 프레젠테이션을 프로덕션 사용 전에 테스트하십시오.

**형상을 앞으로 또는 뒤로 이동하면 애니메이션 순서가 바뀔까요?**

아니요. 형상의 z-순서는 겹침을 제어하고, 시퀀스 순서와 트리거가 애니메이션 재생을 제어합니다. 다른 재생 순서가 필요하면 타임라인을 변경하십시오.