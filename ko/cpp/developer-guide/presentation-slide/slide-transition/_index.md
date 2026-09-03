---
title: C++을 사용하여 프레젠테이션에서 슬라이드 전환 관리
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
description: "Aspose.Slides for C++를 사용하여 슬라이드 전환을 적용하고, 자동 슬라이드 진행을 구성하며, Morph 및 기타 전환 효과를 사용자 지정합니다."
---
## **개요**

슬라이드 전환은 슬라이드 쇼 중 슬라이드가 나타나는 방식을 제어합니다. Aspose.Slides for C++를 사용하면 각 슬라이드마다 전환 효과를 선택하고, 마우스 클릭 또는 타이머에 의한 진행을 구성하며, 효과별 옵션을 조정할 수 있습니다. 이 문서에서는 C++ 예제를 사용하여 전환을 적용하고, 정확한 전환 지속 시간을 설정하고, 슬라이드 타이밍을 관리하며, 두 슬라이드 사이에 Morph 전환을 만드는 방법을 보여줍니다. 또한 설정을 PPTX 파일에 저장하는 방법도 포함되어 있습니다.

## **슬라이드 전환 추가**

전환을 적용하려면 [Presentation](https://reference.aspose.com/slides/ko/cpp/aspose.slides/presentation/) 클래스로 프레젠테이션을 로드하고 [get_SlideShowTransition](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ibaseslide/get_slideshowtransition/) 메서드를 통해 슬라이드의 전환 설정에 접근합니다. [TransitionType](https://reference.aspose.com/slides/ko/cpp/aspose.slides.slideshow/transitiontype/) 열거형의 값으로 [set_Type](https://reference.aspose.com/slides/ko/cpp/aspose.slides/islideshowtransition/set_type/)을 호출한 다음 프레젠테이션을 저장합니다.

다음 예제는 첫 번째 슬라이드에 Circle 전환을, 두 번째 슬라이드에 Comb 전환을 적용합니다. 최소 두 개의 슬라이드가 있는 `input.pptx` 파일을 사용하십시오.

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

## **고급 슬라이드 전환 추가**

슬라이드가 화면에 머무는 시간과 마우스 클릭으로 슬라이드 쇼를 진행할지 여부를 구성할 수 있습니다. 다음 메서드가 이 동작을 제어합니다.

- [set_AdvanceOnClick](https://reference.aspose.com/slides/ko/cpp/aspose.slides/islideshowtransition/set_advanceonclick/)은 사용자가 마우스를 클릭하여 진행하도록 허용합니다.
- [set_AdvanceAfter](https://reference.aspose.com/slides/ko/cpp/aspose.slides/islideshowtransition/set_advanceafter/)은 자동 진행을 활성화합니다.
- [set_AdvanceAfterTime](https://reference.aspose.com/slides/ko/cpp/aspose.slides/islideshowtransition/set_advanceaftertime/)은 자동 진행 전의 지연 시간을 밀리초 단위로 지정합니다.

두 가지 진행 방식을 모두 활성화하면 사용자가 클릭으로 이동하거나 타이머가 끝날 때까지 기다릴 수 있습니다. 타이머만 사용하려면 [set_AdvanceOnClick](https://reference.aspose.com/slides/ko/cpp/aspose.slides/islideshowtransition/set_advanceonclick/)에 `false`를 전달하십시오. 지연 시간은 슬라이드 쇼가 언제 진행되는지를 제어하며, 시각적 전환 효과의 지속 시간을 설정하는 것이 아님을 유념하십시오.

이 예제는 처음 세 슬라이드에 각각 다른 효과를 할당하고 자동 진행을 3초, 5초, 7초 후에 활성화합니다. 마우스 클릭으로도 슬라이드를 진행할 수 있습니다. 최소 세 개의 슬라이드가 있는 `input.pptx` 파일을 사용하십시오.

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

타이머 진행이 활성화되었는지 확인하려면 [get_AdvanceAfter](https://reference.aspose.com/slides/ko/cpp/aspose.slides/islideshowtransition/get_advanceafter/)를 호출하십시오. 저장된 지연 시간만으로는 타이머가 활성 상태인지 판단할 수 없습니다.

다음 예제는 위에서 저장한 파일을 열어 각 슬라이드의 타이머가 활성화된 경우를 보고, 2초보다 큰 지연 시간을 가진 슬라이드의 자동 진행을 비활성화하고 마우스 클릭 진행을 활성화한 뒤 업데이트된 설정을 저장합니다.

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

## **전환 타이밍을 정확하게 제어하기**

[set_Duration](https://reference.aspose.com/slides/ko/cpp/aspose.slides/islideshowtransition/set_duration/)을 사용하여 전환 효과의 정확한 길이를 밀리초 단위로 지정합니다. 슬라이드의 [get_SlideShowTransition](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ibaseslide/get_slideshowtransition/) 메서드는 [ISlideShowTransition](https://reference.aspose.com/slides/ko/cpp/aspose.slides/islideshowtransition/)을 통해 이러한 설정에 접근할 수 있습니다.

| 메서드 | 목적 |
| --- | --- |
| [set_Duration](https://reference.aspose.com/slides/ko/cpp/aspose.slides/islideshowtransition/set_duration/) | 전환 효과 자체의 지속 시간을 밀리초 단위로 설정합니다. |
| [set_AdvanceAfterTime](https://reference.aspose.com/slides/ko/cpp/aspose.slides/islideshowtransition/set_advanceaftertime/) | 슬라이드가 자동으로 진행되기 전의 지연 시간을 밀리초 단위로 설정합니다. 타이머를 활성화하려면 `true`와 함께 set_AdvanceAfter를 호출합니다. |
| [set_Speed](https://reference.aspose.com/slides/ko/cpp/aspose.slides/islideshowtransition/set_speed/) | TransitionSpeed에서 미리 정의된 속도 범주(느림, 중간, 빠름) 중 하나를 선택합니다. 정확한 지속 시간이 지정되지 않았을 때 사용됩니다. |

[set_Duration](https://reference.aspose.com/slides/ko/cpp/aspose.slides/islideshowtransition/set_duration/)은 전환 효과만 제어하고 슬라이드가 화면에 남아 있는 시간을 결정하지 않습니다. 자동 진행 지연은 별도로 구성하십시오. 명시적인 지속 시간이 설정되지 않은 경우 Aspose.Slides는 전환 유형과 [get_Speed](https://reference.aspose.com/slides/ko/cpp/aspose.slides/islideshowtransition/get_speed/)이 반환하는 값을 기반으로 효과 지속 시간을 결정합니다.

### **모든 슬라이드에 동일한 지속 시간 적용**

일관된 템포를 위해 모든 슬라이드에 동일한 효과와 정확한 지속 시간을 적용합니다. 이 예제는 `input.pptx`를 로드하고 [TransitionType](https://reference.aspose.com/slides/ko/cpp/aspose.slides.slideshow/transitiontype/)에서 Fade를 선택한 뒤 각 전환에 750밀리초 지속 시간을 부여합니다. 자동 진행은 5,000밀리초 후에 활성화하고 마우스 클릭 진행은 비활성화한 뒤 결과를 PPTX로 저장합니다.

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

    // 효과 지속 시간과 별개로 자동 진행을 구성합니다.
    transition->set_AdvanceAfter(true);
    transition->set_AdvanceAfterTime(5000);
    transition->set_AdvanceOnClick(false);
}

presentation->Save(u"precise-transitions.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

### **슬라이드별로 다른 지속 시간 설정**

슬라이드마다 서로 다른 효과 지속 시간을 사용할 수 있습니다. 예를 들어 제목 슬라이드에는 짧은 전환을, 섹션 소개 슬라이드에는 더 긴 전환을 사용할 수 있습니다. 이 예제는 첫 번째 슬라이드에 500밀리초, 두 번째 슬라이드에 1,200밀리초를 설정합니다. 최소 두 개의 슬라이드가 있는 `input.pptx` 파일을 사용하십시오.

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

[animated GIF](/slides/ko/cpp/convert-powerpoint-to-animated-gif/), [HTML5 presentation](/slides/ko/cpp/export-to-html5/), 혹은 [video](/slides/ko/cpp/convert-powerpoint-to-video/)를 준비할 때 내보내기 전 정확한 전환 지속 시간을 설정하여 의도한 템포와 맞춥니다. 예를 들어 장면 사이에 600밀리초 페이드 전환을 사용하고, 각 슬라이드의 진행 지연을 별도로 조정하여 내레이션 또는 콘텐츠에 충분한 시간을 제공합니다.

GIF와 비디오의 경우 출력 프레임 레이트를 효과 지속 시간에 맞추세요: 600밀리초는 30fps에서 18프레임에 해당합니다. HTML5에서는 내보내기 설정에서 애니메이션 전환을 활성화하십시오. 선택한 내보내기 형식이 지원하는 전환 및 타이밍 옵션을 확인하고, 동기화 여부를 미리 보기로 확인하십시오.

### **기존 전환 지속 시간 읽기**

전환을 수정하기 전에 [get_Duration](https://reference.aspose.com/slides/ko/cpp/aspose.slides/islideshowtransition/get_duration/)을 호출하여 명시적인 값이 저장되어 있는지 확인합니다. `-1` 값은 명시적인 지속 시간이 설정되지 않았음을 의미하고, 0 이상 값은 밀리초 단위로 저장된 지속 시간을 나타냅니다. 이 값은 재생 계산된 지속 시간이 아니며, Aspose.Slides는 전환 유형과 [get_Speed](https://reference.aspose.com/slides/ko/cpp/aspose.slides/islideshowtransition/get_speed/)이 반환하는 값을 사용해 실제 재생 시간을 결정합니다. 전환 유형을 설정하면 지속 시간이 초기화될 수 있으므로 먼저 원래 설정을 검사하십시오.

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

Morph 전환은 연속된 슬라이드에서 객체 간의 변화를 애니메이션화합니다. 간단한 Morph 효과를 만들려면 슬라이드를 복제하고 복제본에서 객체를 이동하거나 크기를 조정한 뒤 두 번째 슬라이드에 Morph 전환을 적용합니다. 그러면 원본과 수정된 상태 사이를 연결하는 애니메이션이 자동으로 생성됩니다.

다음 예제는 텍스트 사각형이 있는 슬라이드를 만든 뒤 이를 복제하고 복제본에서 사각형의 위치와 크기를 변경합니다. 그런 다음 두 번째 슬라이드에 대해 [TransitionType](https://reference.aspose.com/slides/ko/cpp/aspose.slides.slideshow/transitiontype/) 열거형에서 Morph를 선택합니다. Morph를 지원하는 프레젠테이션 뷰어에서 저장된 파일을 열면 슬라이드 쇼 중 효과를 확인할 수 있습니다.

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

[TransitionMorphType](https://reference.aspose.com/slides/ko/cpp/aspose.slides.slideshow/transitionmorphtype/) 열거형은 Morph가 콘텐츠를 매칭하고 애니메이션화하는 방식을 제어합니다.

- [ByObject](https://reference.aspose.com/slides/ko/cpp/aspose.slides.slideshow/transitionmorphtype/)는 각 도형을 전체 객체로 취급합니다.
- [ByWord](https://reference.aspose.com/slides/ko/cpp/aspose.slides.slideshow/transitionmorphtype/)는 가능한 경우 단어 단위로 텍스트를 매칭하여 애니메이션합니다.
- [ByChar](https://reference.aspose.com/slides/ko/cpp/aspose.slides.slideshow/transitionmorphtype/)는 가능한 경우 문자 단위로 텍스트를 매칭하여 애니메이션합니다.

Morph를 선택하려면 [set_Type](https://reference.aspose.com/slides/ko/cpp/aspose.slides/islideshowtransition/set_type/)에 Morph를 전달한 뒤 [get_Value](https://reference.aspose.com/slides/ko/cpp/aspose.slides/islideshowtransition/get_value/)를 호출합니다. 반환된 값은 [IMorphTransition](https://reference.aspose.com/slides/ko/cpp/aspose.slides.slideshow/imorphtransition/) 인터페이스를 제공하며, 여기서 [set_MorphType](https://reference.aspose.com/slides/ko/cpp/aspose.slides.slideshow/imorphtransition/set_morphtype/) 메서드로 매칭 모드를 선택합니다.

이 예제는 이전 섹션에서 만든 프레젠테이션을 열고 두 번째 슬라이드에 단어 기반 Morph 애니메이션을 구성합니다.

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

일부 전환은 방향이나 검은 화면에서 시작 여부와 같은 추가 옵션을 제공합니다. 사용 가능한 옵션은 선택한 전환 유형에 따라 다릅니다. 먼저 유형을 설정한 뒤 [get_Value](https://reference.aspose.com/slides/ko/cpp/aspose.slides/islideshowtransition/get_value/)가 반환하는 적절한 인터페이스를 사용하십시오.

다음 예제는 `input.pptx`의 첫 번째 슬라이드에 Cut 전환을 적용합니다. [IOptionalBlackTransition](https://reference.aspose.com/slides/ko/cpp/aspose.slides.slideshow/ioptionalblacktransition/)를 통해 `true`를 전달하여 [set_FromBlack](https://reference.aspose.com/slides/ko/cpp/aspose.slides.slideshow/ioptionalblacktransition/set_fromblack/)을 호출하면 전환이 검은 화면에서 시작합니다.

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

**슬라이드 전환의 재생 속도를 제어할 수 있나요?**

예. 정확한 효과 지속 시간이 필요할 경우 밀리초 단위의 [set_Duration](https://reference.aspose.com/slides/ko/cpp/aspose.slides/islideshowtransition/set_duration/)을 사용하십시오. 미리 정의된 [TransitionSpeed](https://reference.aspose.com/slides/ko/cpp/aspose.slides.slideshow/transitionspeed/) 범주(느림, 중간, 빠름)만으로 충분하고 명시적인 지속 시간을 지정하지 않을 경우 [set_Speed](https://reference.aspose.com/slides/ko/cpp/aspose.slides/islideshowtransition/set_speed/)를 사용합니다. 이러한 설정은 자동 진행 지연과 독립적으로 전환 효과만을 제어합니다.

**전환에 오디오를 연결하고 반복 재생하도록 할 수 있나요?**

예. [set_Sound](https://reference.aspose.com/slides/ko/cpp/aspose.slides/islideshowtransition/set_sound/)로 내장 오디오를 지정하고, [TransitionSoundMode](https://reference.aspose.com/slides/ko/cpp/aspose.slides.slideshow/transitionsoundmode/) 열거형의 StartSound 값을 사용해 [set_SoundMode](https://reference.aspose.com/slides/ko/cpp/aspose.slides/islideshowtransition/set_soundmode/)를 호출한 뒤, [set_SoundLoop](https://reference.aspose.com/slides/ko/cpp/aspose.slides/islideshowtransition/set_soundloop/)을 사용해 루프를 활성화합니다. 오디오가 다음 사운드 이벤트가 발생할 때까지 반복 재생됩니다.

**모든 슬라이드에 동일한 전환을 적용하는 가장 빠른 방법은 무엇인가요?**

프레젠테이션의 [get_Slides](https://reference.aspose.com/slides/ko/cpp/aspose.slides/presentation/get_slides/) 메서드가 반환하는 컬렉션을 순회하면서 각 슬라이드의 전환에 대해 동일한 값을 가진 [set_Type](https://reference.aspose.com/slides/ko/cpp/aspose.slides/islideshowtransition/set_type/)을 호출합니다. 같은 루프 안에서 타이밍 및 효과 옵션을 설정하면 슬라이드 전반에 걸쳐 동작이 일관됩니다.

**슬라이드에 현재 설정된 전환이 무엇인지 확인하려면 어떻게 해야 하나요?**

슬라이드의 [get_SlideShowTransition](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ibaseslide/get_slideshowtransition/) 메서드가 반환하는 전환 객체에 대해 [get_Type](https://reference.aspose.com/slides/ko/cpp/aspose.slides/islideshowtransition/get_type/)을 호출합니다. 반환값은 [TransitionType](https://reference.aspose.com/slides/ko/cpp/aspose.slides.slideshow/transitiontype/) 열거형 중 하나이며, None이면 전환 효과가 적용되지 않은 것입니다.