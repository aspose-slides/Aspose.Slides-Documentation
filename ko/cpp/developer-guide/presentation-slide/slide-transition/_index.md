---
title: C++를 사용하여 프레젠테이션에서 슬라이드 전환 관리
linktitle: 슬라이드 전환
type: docs
weight: 80
url: /ko/cpp/slide-transition/
keywords:
- 슬라이드 전환
- 슬라이드 전환 추가
- 슬라이드 전환 적용
- 고급 슬라이드 전환
- Morph 전환
- 전환 유형
- 전환 효과
- PowerPoint
- OpenDocument
- 프레젠테이션
- C++
- Aspose.Slides
description: "Aspose.Slides for C++를 사용하여 슬라이드 전환을 적용하고 자동 슬라이드 진행을 구성하며 Morph 및 기타 전환 효과를 사용자 정의합니다."
---
## **개요**

슬라이드 전환은 슬라이드 쇼 동안 슬라이드가 표시되는 방식을 제어합니다. Aspose.Slides for C++를 사용하면 각 슬라이드에 전환 효과를 선택하고, 마우스 클릭 또는 타이머에 따라 진행을 구성하며, 효과에 특화된 옵션을 조정할 수 있습니다. 이 문서에서는 C++ 예제를 사용하여 전환을 적용하고, 정확한 전환 지속 시간을 설정하며, 슬라이드 타이밍을 관리하고, 두 슬라이드 사이에 Morph 전환을 만드는 방법을 보여줍니다. 또한 예제에서는 설정을 PPTX 파일로 저장하는 방법도 보여줍니다.

## **슬라이드 전환 추가**

전환을 적용하려면 [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) 클래스로 프레젠테이션을 로드하고 [get_SlideShowTransition](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseslide/get_slideshowtransition/)을 통해 슬라이드의 전환 설정에 접근합니다. [TransitionType](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/transitiontype/) 열거형의 값으로 [set_Type](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_type/)을 호출한 다음 프레젠테이션을 저장합니다.

다음 예제는 첫 번째 슬라이드에 Circle 전환을, 두 번째 슬라이드에 Comb 전환을 적용합니다. 최소 두 개 슬라이드가 있는 `input.pptx` 파일을 사용하십시오.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideShowTransition.h>
#include <DOM/SlideShowTransition/TransitionType.h>
#include <Export/SaveFormat.h>
#include <system/console.h>

using namespace System;
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::SlideShow;

auto presentation = MakeObject<Presentation>(u"input.pptx");

if (presentation->get_Slides()->get_Count() >= 2)
{
    presentation->get_Slide(0)->get_SlideShowTransition()->set_Type(TransitionType::Circle);
    presentation->get_Slide(1)->get_SlideShowTransition()->set_Type(TransitionType::Comb);

    presentation->Save(u"slide-transitions.pptx", SaveFormat::Pptx);
}
else
{
    Console::WriteLine(u"The input presentation must contain at least two slides.");
}

presentation->Dispose();
```

## **휠 전환**

[set_Spokes](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/iwheeltransition/set_spokes/) 메서드는 [IWheelTransition](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/iwheeltransition/)에서 대상 슬라이드를 표시하는 방사형 섹터 수를 제어합니다. [TransitionType](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/transitiontype/)에서 Wheel 값을 사용하여 [set_Type](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_type/)을 호출한 다음 [IWheelTransition](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/iwheeltransition/)로서 [get_Value](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/get_value/)에 접근합니다.

이 예제는 두 개의 동일한 슬라이드 쌍을 생성합니다: 검은색 슬라이드와 그 다음에 금색 사각형이 있는 슬라이드. 대상 슬라이드는 1과 8의 spoke 수를 사용하며, [set_Speed](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_speed/)을 통해 같은 속도를 설정하고, [set_Duration](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_duration/)으로 8,000밀리초의 명시적 지속 시간을 설정해 차이를 쉽게 관찰할 수 있도록 합니다.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideSize.h>
#include <DOM/ISlideShowTransition.h>
#include <DOM/IBackground.h>
#include <DOM/BackgroundType.h>
#include <DOM/IFillFormat.h>
#include <DOM/FillType.h>
#include <DOM/IColorFormat.h>
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/ShapeType.h>
#include <DOM/SlideShowTransition/IWheelTransition.h>
#include <DOM/SlideShowTransition/ITransitionValueBase.h>
#include <DOM/SlideShowTransition/TransitionType.h>
#include <DOM/SlideShowTransition/TransitionSpeed.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <drawing/size_f.h>
#include <system/object_ext.h>
#include <cstdint>

using namespace System;
using namespace System::Drawing;
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::SlideShow;

auto presentation = MakeObject<Presentation>();
auto slideWidth = presentation->get_SlideSize()->get_Size().get_Width();
auto slideHeight = presentation->get_SlideSize()->get_Size().get_Height();

auto blackSlide = presentation->get_Slide(0);
blackSlide->get_Shapes()->Clear();
blackSlide->get_Background()->set_Type(BackgroundType::OwnBackground);
blackSlide->get_Background()->get_FillFormat()->set_FillType(FillType::Solid);
blackSlide->get_Background()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());

auto destinationSlide = presentation->get_Slides()->AddClone(blackSlide);
auto rectangle = destinationSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 0, 0, slideWidth, slideHeight);
rectangle->get_FillFormat()->set_FillType(FillType::Solid);
rectangle->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Gold());
rectangle->get_TextFrame()->set_Text(u"Wheel transition");

presentation->get_Slides()->AddClone(blackSlide);
presentation->get_Slides()->AddClone(destinationSlide);

const uint32_t spokeCounts[] = { 1, 8 };
for (auto i = 0; i < 2; i++)
{
    auto transition = presentation->get_Slide(i * 2 + 1)->get_SlideShowTransition();
    transition->set_Type(TransitionType::Wheel);
    auto wheelTransition = ExplicitCast<IWheelTransition>(transition->get_Value());
    wheelTransition->set_Spokes(spokeCounts[i]);
    transition->set_Speed(TransitionSpeed::Slow);
    transition->set_Duration(8000);
}

presentation->Save(u"wheel-transitions.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

PowerPoint에서 출력 프레젠테이션을 열고 슬라이드 쇼를 실행하십시오. 슬라이드 1에서 슬라이드 2로, 그 다음 슬라이드 3에서 슬라이드 4로 진행합니다. PowerPoint 재생에서 검증된 1개의 spoke 수는 시계 방향 한 번의 스윕으로 슬라이드를 표시하고, 8개의 spoke 수는 여덟 개의 방사형 섹터를 동시에 표시합니다. 대상 콘텐츠와 전환 타이밍은 동일하므로 차이는 표시 섹터 수입니다.

## **Reveal 전환을 사용한 검은색을 통한 페이드**

대상 슬라이드의 전환 유형을 Reveal로 설정한 다음 [IRevealTransition](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/irevealtransition/) 인터페이스에서 [set_ThroughBlack](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/irevealtransition/set_throughblack/)을 호출합니다. 예제는 청록색 원본 슬라이드와 산호색 대상 슬라이드를 생성하고, 두 슬라이드를 복제하여 검은색을 통한 페이드가 비활성화된 경우와 활성화된 경우의 동일한 2초 전환을 비교할 수 있게 합니다.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideShowTransition.h>
#include <DOM/IBackground.h>
#include <DOM/BackgroundType.h>
#include <DOM/IFillFormat.h>
#include <DOM/FillType.h>
#include <DOM/IColorFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IAutoShape.h>
#include <DOM/ShapeType.h>
#include <DOM/ITextFrame.h>
#include <DOM/IParagraph.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionFormat.h>
#include <DOM/SlideShowTransition/IRevealTransition.h>
#include <DOM/SlideShowTransition/ITransitionValueBase.h>
#include <DOM/SlideShowTransition/TransitionLeftRightDirectionType.h>
#include <DOM/SlideShowTransition/TransitionSpeed.h>
#include <DOM/SlideShowTransition/TransitionType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/object_ext.h>

using namespace System;
using namespace System::Drawing;
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::SlideShow;

auto styleSlide = [](SharedPtr<ISlide> slide, Color background, const String& label)
{
    slide->get_Background()->set_Type(BackgroundType::OwnBackground);
    auto fill = slide->get_Background()->get_FillFormat();
    fill->set_FillType(FillType::Solid);
    fill->get_SolidFillColor()->set_Color(background);

    auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 160, 180, 400, 130);
    auto textFrame = shape->get_TextFrame();
    textFrame->set_Text(label);
    textFrame->get_Paragraph(0)->get_Portion(0)->get_PortionFormat()->set_FontHeight(44);
};

auto presentation = MakeObject<Presentation>();

auto source = presentation->get_Slide(0);
auto destination = presentation->get_Slides()->AddClone(source);
styleSlide(source, Color::get_Teal(), u"Source");
styleSlide(destination, Color::get_Coral(), u"Destination");
presentation->get_Slides()->AddClone(source);
presentation->get_Slides()->AddClone(destination);

for (auto index : {1, 3})
{
    auto transition = presentation->get_Slide(index)->get_SlideShowTransition();
    transition->set_Type(TransitionType::Reveal);
    transition->set_Speed(TransitionSpeed::Slow);
    transition->set_Duration(2000);

    auto reveal = ExplicitCast<IRevealTransition>(transition->get_Value());
    reveal->set_Direction(TransitionLeftRightDirectionType::Left);
    reveal->set_ThroughBlack(index == 3);
}

presentation->Save(u"reveal-transitions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

PowerPoint 슬라이드 쇼에서 슬라이드 1에서 슬라이드 2로 진행합니다. 청록색이 바로 산호색으로 페이드됩니다. 그 다음 슬라이드 3에서 슬라이드 4로 진행합니다. 화면이 잠시 거의 검은색으로 어두워졌다가 산호색 슬라이드가 나타납니다. 두 슬라이드 모두 원래 배경 색을 유지합니다.

아래 행들은 0.5초 간격으로 PowerPoint에서 캡처한 프레임을 보여줍니다. 각 행의 가운데 프레임을 비교하여 설정의 효과를 확인하십시오.

![PowerPoint 재생에서 ThroughBlack 비활성화(상단) 및 활성화(하단). 하단 행만 거의 검은색을 통과합니다.](reveal-through-black.png)

## **고급 슬라이드 전환 추가**

슬라이드가 화면에 머무는 시간과 마우스 클릭으로 슬라이드 쇼를 진행할지 여부를 구성할 수 있습니다. 다음 메서드들이 이 동작을 제어합니다:

- [set_AdvanceOnClick](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_advanceonclick/) 은 사용자가 마우스를 클릭하여 진행할 수 있게 합니다.
- [set_AdvanceAfter](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_advanceafter/) 은 자동 진행을 활성화합니다.
- [set_AdvanceAfterTime](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_advanceaftertime/) 은 자동 진행 전 지연 시간을 밀리초 단위로 지정합니다.

클릭과 타이머 자동 진행을 모두 활성화하면 사용자는 클릭으로 진행하거나 타이머를 기다릴 수 있습니다. 타이머만 사용하려면 `false`와 함께 [set_AdvanceOnClick](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_advanceonclick/)을 호출합니다. 지연 시간은 슬라이드 쇼가 언제 진행되는지를 제어하며, 시각 전환 효과의 지속 시간을 설정하지는 않습니다.

이 예제는 첫 번째부터 세 번째 슬라이드에 서로 다른 효과를 할당하고 각각 3초, 5초, 7초 후에 자동 진행을 활성화합니다. 마우스 클릭으로도 슬라이드를 진행할 수 있습니다. 최소 세 개 슬라이드가 있는 `input.pptx` 파일을 사용하십시오.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideShowTransition.h>
#include <DOM/SlideShowTransition/TransitionType.h>
#include <Export/SaveFormat.h>
#include <system/console.h>

using namespace System;
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::SlideShow;

auto presentation = MakeObject<Presentation>(u"input.pptx");

if (presentation->get_Slides()->get_Count() >= 3)
{
    auto firstTransition = presentation->get_Slide(0)->get_SlideShowTransition();
    firstTransition->set_Type(TransitionType::Circle);
    firstTransition->set_AdvanceOnClick(true);
    firstTransition->set_AdvanceAfter(true);
    firstTransition->set_AdvanceAfterTime(3000);

    auto secondTransition = presentation->get_Slide(1)->get_SlideShowTransition();
    secondTransition->set_Type(TransitionType::Comb);
    secondTransition->set_AdvanceOnClick(true);
    secondTransition->set_AdvanceAfter(true);
    secondTransition->set_AdvanceAfterTime(5000);

    auto thirdTransition = presentation->get_Slide(2)->get_SlideShowTransition();
    thirdTransition->set_Type(TransitionType::Zoom);
    thirdTransition->set_AdvanceOnClick(true);
    thirdTransition->set_AdvanceAfter(true);
    thirdTransition->set_AdvanceAfterTime(7000);

    presentation->Save(u"advanced-transitions.pptx", SaveFormat::Pptx);
}
else
{
    Console::WriteLine(u"The input presentation must contain at least three slides.");
}

presentation->Dispose();
```

타이머 자동 진행이 활성화되었는지 확인하려면 [get_AdvanceAfter](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/get_advanceafter/)을 호출하십시오. 저장된 지연 시간만으로는 타이머가 활성화됐다고 판단할 수 없습니다.

다음 예제는 위에서 저장한 파일을 열어 각 활성화된 타이머를 보고하고, 지연 시간이 2초를 초과하는 슬라이드에 대해 자동 진행을 비활성화합니다. 해당 슬라이드에 마우스 클릭을 활성화하고 업데이트된 설정을 저장합니다.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideShowTransition.h>
#include <Export/SaveFormat.h>
#include <system/console.h>

using namespace System;
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = MakeObject<Presentation>(u"advanced-transitions.pptx");

for (auto&& slide : presentation->get_Slides())
{
    auto transition = slide->get_SlideShowTransition();

    if (transition->get_AdvanceAfter())
    {
        Console::WriteLine(u"Slide {0}: advance after {1} ms.", slide->get_SlideNumber(), transition->get_AdvanceAfterTime());

        if (transition->get_AdvanceAfterTime() > 2000)
        {
            transition->set_AdvanceAfter(false);
            transition->set_AdvanceOnClick(true);
        }
    }
}

presentation->Save(u"adjusted-transitions.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

## **전환 타이밍 정밀 제어**

[set_Duration](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_duration/) 을 사용하여 전환 효과의 정확한 길이를 밀리초 단위로 지정합니다. 슬라이드의 [get_SlideShowTransition](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseslide/get_slideshowtransition/) 메서드는 [ISlideShowTransition](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/) 을 통해 이러한 설정을 노출합니다.

| 메서드 | 목적 |
| --- | --- |
| [set_Duration](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_duration/) | 전환 효과 자체의 지속 시간을 밀리초 단위로 설정합니다. |
| [set_AdvanceAfterTime](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_advanceaftertime/) | 슬라이드가 자동으로 진행되기 전의 지연 시간을 밀리초 단위로 설정합니다. 이 타이머를 활성화하려면 `true`와 함께 [set_AdvanceAfter](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_advanceafter/)을 호출합니다. |
| [set_Speed](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_speed/) | [TransitionSpeed](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/transitionspeed/) 에서 사전 정의된 속도 범주인 Slow, Medium, Fast 중 하나를 선택합니다. 정확한 지속 시간이 지정되지 않은 경우에 사용됩니다. |

[set_Duration](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_duration/) 은 전환 효과만 제어하고, 슬라이드가 화면에 남는 시간은 결정하지 않습니다. 자동 진행 지연은 별도로 구성하십시오. 명시적 지속 시간이 설정되지 않으면 Aspose.Slides는 전환 유형과 [get_Speed](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/get_speed/) 이 반환하는 값을 기반으로 효과 지속 시간을 결정합니다.

[![분리된 막대가 750ms 전환 지속 시간과 5,000ms 자동 진행 설정을 식별합니다.](visual-slide-transition-1f705a740cf6.svg)](visual-slide-transition-1f705a740cf6.svg)
<!-- visual-explanation:slide-transition:start -->
<!-- visual-explanation:slide-transition:end -->

### **모든 슬라이드에 동일한 지속 시간 적용**

일관된 템포를 위해 모든 슬라이드에 동일한 효과와 정확한 지속 시간을 적용합니다. 이 예제는 `input.pptx`를 로드하고, [TransitionType](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/transitiontype/)에서 Fade를 선택한 뒤 각 전환에 750밀리초의 지속 시간을 부여합니다. 또한 5,000밀리초 후 자동 진행을 별도로 활성화하고 마우스 클릭에 의한 진행은 비활성화한 뒤 결과를 PPTX로 저장합니다.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideShowTransition.h>
#include <DOM/SlideShowTransition/TransitionType.h>
#include <Export/SaveFormat.h>

using namespace System;
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::SlideShow;

auto presentation = MakeObject<Presentation>(u"input.pptx");

for (auto&& slide : presentation->get_Slides())
{
    auto transition = slide->get_SlideShowTransition();
    transition->set_Type(TransitionType::Fade);
    transition->set_Duration(750);

    // 전환 효과 지속 시간과는 별도로 자동 진행을 구성합니다.
    transition->set_AdvanceAfter(true);
    transition->set_AdvanceAfterTime(5000);
    transition->set_AdvanceOnClick(false);
}

presentation->Save(u"precise-transitions.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

### **개별 슬라이드에 서로 다른 지속 시간 설정**

슬라이드마다 서로 다른 효과 지속 시간을 사용할 수 있습니다. 예를 들어 제목 슬라이드에는 짧은 전환을, 섹션 소개 슬라이드에는 긴 전환을 사용합니다. 이 예제는 첫 번째 슬라이드에 500밀리초, 두 번째 슬라이드에 1,200밀리초를 설정합니다. 최소 두 개 슬라이드가 있는 `input.pptx` 파일을 사용하십시오.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideShowTransition.h>
#include <DOM/SlideShowTransition/TransitionType.h>
#include <Export/SaveFormat.h>
#include <system/console.h>

using namespace System;
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::SlideShow;

auto presentation = MakeObject<Presentation>(u"input.pptx");

if (presentation->get_Slides()->get_Count() >= 2)
{
    auto firstTransition = presentation->get_Slide(0)->get_SlideShowTransition();
    firstTransition->set_Type(TransitionType::Fade);
    firstTransition->set_Duration(500);

    auto secondTransition = presentation->get_Slide(1)->get_SlideShowTransition();
    secondTransition->set_Type(TransitionType::Push);
    secondTransition->set_Duration(1200);

    presentation->Save(u"individual-transition-durations.pptx", SaveFormat::Pptx);
}
else
{
    Console::WriteLine(u"The input presentation must contain at least two slides.");
}

presentation->Dispose();
```

### **애니메이션 출력과 전환 조정**

[animated GIF](/slides/ko/cpp/convert-powerpoint-to-animated-gif/), [HTML5 presentation](/slides/ko/cpp/export-to-html5/) 또는 [video](/slides/ko/cpp/convert-powerpoint-to-video/) 를 준비할 때, 의도한 템포에 맞추려면 내보내기 전에 정확한 전환 지속 시간을 설정하십시오. 예를 들어 장면 사이에 600밀리초 페이드를 사용하고, 각 슬라이드의 진행 지연을 별도로 조정하여 내레이션이나 콘텐츠를 위한 시간을 확보합니다.

GIF 및 비디오의 경우, 출력 프레임률을 효과 지속 시간에 맞추십시오: 600밀리초는 초당 30프레임에서 18프레임에 해당합니다. HTML5에서는 내보내기 설정에서 애니메이션 전환을 활성화하십시오. 선택한 내보내기 형식이 지원하는 효과와 타이밍 옵션을 확인하고, 출력물을 미리 보아 동기화를 확인하십시오.

### **기존 전환 지속 시간 읽기**

전환을 수정하기 전에 [get_Duration](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/get_duration/)을 호출하여 명시적 값이 저장되어 있는지 확인합니다. `-1` 값은 명시적 지속 시간이 설정되지 않았음을 의미하고, 음이 아닌 값은 저장된 지속 시간을 밀리초 단위로 지정합니다. 설정되지 않은 값은 계산된 재생 지속 시간이 아니며, Aspose.Slides는 전환 유형과 [get_Speed](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/get_speed/) 이 반환하는 값을 사용해 해당 지속 시간을 결정합니다. 전환 유형을 설정하면 지속 시간이 초기화될 수 있으므로 먼저 원래 설정을 점검하십시오.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideShowTransition.h>
#include <DOM/SlideShowTransition/TransitionType.h>
#include <DOM/SlideShowTransition/TransitionSpeed.h>
#include <system/console.h>

using namespace System;
using namespace Aspose::Slides;

auto presentation = MakeObject<Presentation>(u"input.pptx");

for (auto&& slide : presentation->get_Slides())
{
    auto transition = slide->get_SlideShowTransition();
    auto duration = transition->get_Duration();

    if (duration >= 0)
    {
        Console::WriteLine(u"Slide {0}: stored transition duration is {1} ms.", slide->get_SlideNumber(), duration);
    }
    else
    {
        Console::WriteLine(u"Slide {0}: no explicit duration; timing depends on {1} and {2}.", slide->get_SlideNumber(), transition->get_Type(), transition->get_Speed());
    }
}

presentation->Dispose();
```

## **Morph 전환**

Morph 전환은 연속된 슬라이드에 있는 객체 간의 변화를 애니메이션화합니다. 간단한 Morph 효과를 만들려면 슬라이드를 복제하고 복제본에서 객체를 이동하거나 크기를 조정한 뒤 두 번째 슬라이드에 Morph 전환을 적용합니다. 이렇게 하면 전환 대상 객체가 원래 상태와 변경된 상태 사이를 애니메이션합니다.

다음 예제는 텍스트 사각형이 있는 슬라이드를 만들고, 해당 슬라이드를 복제한 뒤 복제본에서 사각형의 위치와 크기를 변경합니다. 그런 다음 두 번째 슬라이드에 대해 [TransitionType](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/transitiontype/) 열거형에서 Morph를 선택합니다. 저장된 파일을 Morph를 지원하는 프레젠테이션 뷰어에서 열어 슬라이드 쇼 중 효과를 확인하십시오.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideShowTransition.h>
#include <DOM/IAutoShape.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/ShapeType.h>
#include <DOM/SlideShowTransition/TransitionType.h>
#include <Export/SaveFormat.h>

using namespace System;
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::SlideShow;

auto presentation = MakeObject<Presentation>();

auto firstSlide = presentation->get_Slide(0);
auto rectangle = firstSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 400, 100);
rectangle->get_TextFrame()->set_Text(u"Morph transition");

auto secondSlide = presentation->get_Slides()->AddClone(firstSlide);
auto movedRectangle = secondSlide->get_Shape(0);
movedRectangle->set_X(movedRectangle->get_X() + 100);
movedRectangle->set_Y(movedRectangle->get_Y() + 50);
movedRectangle->set_Width(movedRectangle->get_Width() - 200);
movedRectangle->set_Height(movedRectangle->get_Height() - 10);

secondSlide->get_SlideShowTransition()->set_Type(TransitionType::Morph);

presentation->Save(u"morph-transition.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

## **Morph 전환 유형**

[TransitionMorphType](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/transitionmorphtype/) 열거형은 Morph가 콘텐츠를 매칭하고 애니메이션하는 방식을 제어합니다:

- [ByObject](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/transitionmorphtype/) 은 각 형태를 전체 객체로 간주합니다.
- [ByWord](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/transitionmorphtype/) 은 가능한 경우 단어를 매칭하여 텍스트를 애니메이션합니다.
- [ByChar](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/transitionmorphtype/) 은 가능한 경우 문자를 매칭하여 텍스트를 애니메이션합니다.

전환을 [get_Value](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/get_value/) 에 접근하기 전에 [set_Type](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_type/) 에 Morph를 지정하여 호출합니다. 반환된 값은 [IMorphTransition](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/imorphtransition/) 인터페이스를 제공하며, 이 인터페이스의 [set_MorphType](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/imorphtransition/set_morphtype/) 메서드가 매칭 모드를 선택합니다.

이 예제는 이전 섹션에서 만든 프레젠테이션을 열고 두 번째 슬라이드에 단어 기반 Morph 애니메이션을 사용하도록 구성합니다.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideShowTransition.h>
#include <DOM/SlideShowTransition/IMorphTransition.h>
#include <DOM/SlideShowTransition/ITransitionValueBase.h>
#include <DOM/SlideShowTransition/TransitionMorphType.h>
#include <DOM/SlideShowTransition/TransitionType.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/object_ext.h>

using namespace System;
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::SlideShow;

auto presentation = MakeObject<Presentation>(u"morph-transition.pptx");

if (presentation->get_Slides()->get_Count() >= 2)
{
    auto transition = presentation->get_Slide(1)->get_SlideShowTransition();
    transition->set_Type(TransitionType::Morph);

    auto morphTransition = AsCast<IMorphTransition>(transition->get_Value());
    if (morphTransition != nullptr)
    {
        morphTransition->set_MorphType(TransitionMorphType::ByWord);
        presentation->Save(u"morph-by-word.pptx", SaveFormat::Pptx);
    }
    else
    {
        Console::WriteLine(u"Morph transition options are unavailable.");
    }
}
else
{
    Console::WriteLine(u"The input presentation must contain at least two slides.");
}

presentation->Dispose();
```

## **전환 효과 설정**

일부 전환은 방향이나 효과가 검은 화면에서 시작하는지와 같은 추가 옵션을 제공합니다. 사용 가능한 옵션은 선택한 전환 유형에 따라 다릅니다. 먼저 유형을 설정하고, 그런 다음 [get_Value](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/get_value/) 이 반환하는 적절한 인터페이스를 사용하십시오.

다음 예제는 `input.pptx`의 첫 번째 슬라이드에 Cut 전환을 적용합니다. [IOptionalBlackTransition](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/ioptionalblacktransition/) 를 통해 `true`와 함께 [set_FromBlack](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/ioptionalblacktransition/set_fromblack/) 을 호출하여 전환이 검은 화면에서 시작하도록 합니다.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideShowTransition.h>
#include <DOM/SlideShowTransition/IOptionalBlackTransition.h>
#include <DOM/SlideShowTransition/ITransitionValueBase.h>
#include <DOM/SlideShowTransition/TransitionType.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/object_ext.h>

using namespace System;
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::SlideShow;

auto presentation = MakeObject<Presentation>(u"input.pptx");
auto transition = presentation->get_Slide(0)->get_SlideShowTransition();
transition->set_Type(TransitionType::Cut);

auto cutTransition = AsCast<IOptionalBlackTransition>(transition->get_Value());
if (cutTransition != nullptr)
{
    cutTransition->set_FromBlack(true);
    presentation->Save(u"cut-from-black.pptx", SaveFormat::Pptx);
}
else
{
    Console::WriteLine(u"Cut transition options are unavailable.");
}

presentation->Dispose();
```

## **FAQ**

**슬라이드 전환 재생 속도를 제어할 수 있나요?**

예. 밀리초 단위의 정확한 효과 지속 시간이 필요할 때는 [set_Duration](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_duration/)을 사용하십시오. 사전 정의된 [TransitionSpeed](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/transitionspeed/) 범주(느림, 보통, 빠름)만으로 충분하고 명시적 지속 시간이 설정되지 않은 경우에는 [set_Speed](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_speed/)을 사용하십시오. 이러한 설정은 자동 진행 지연과는 별개로 전환 효과를 제어합니다.

**전환에 오디오를 첨부하고 반복 재생하도록 할 수 있나요?**

예. [set_Sound](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_sound/) 으로 임베드된 오디오를 할당하고, [TransitionSoundMode](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/transitionsoundmode/) 열거형의 StartSound와 함께 [set_SoundMode](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_soundmode/) 을 호출하며, [set_SoundLoop](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_soundloop/) 로 반복 재생을 활성화합니다. 오디오는 슬라이드 쇼에서 다음 사운드 이벤트가 발생할 때까지 반복됩니다.

**모든 슬라이드에 동일한 전환을 적용하는 가장 빠른 방법은 무엇인가요?**

프레젠테이션의 [get_Slides](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_slides/) 메서드가 반환하는 컬렉션을 순회하면서 각 슬라이드의 전환에 대해 동일한 값을 사용해 [set_Type](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_type/) 을 호출합니다. 동일한 루프에서 타이밍 및 효과 옵션을 설정하면 슬라이드마다 동작이 일관됩니다.

**슬라이드에 현재 설정된 전환이 무엇인지 확인하려면 어떻게 해야 하나요?**

슬라이드의 [get_SlideShowTransition](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseslide/get_slideshowtransition/) 메서드가 반환하는 전환에 대해 [get_Type](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/get_type/) 을 호출합니다. 이 메서드는 [TransitionType](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/transitiontype/) 열거형의 값을 반환하며, None은 전환 효과가 적용되지 않았음을 의미합니다.