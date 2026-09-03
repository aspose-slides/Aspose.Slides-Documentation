---
title: .NET에서 프레젠테이션 슬라이드 전환 관리
linktitle: 슬라이드 전환
type: docs
weight: 90
url: /ko/net/slide-transition/
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
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET을 사용하여 슬라이드 전환을 적용하고, 자동 슬라이드 진행을 구성하며, Morph 및 기타 전환 효과를 사용자 지정합니다."
---
## **개요**

슬라이드 전환은 슬라이드 쇼 중 슬라이드가 나타나는 방식을 제어합니다. Aspose.Slides for .NET을 사용하면 각 슬라이드에 전환 효과를 선택하고, 마우스 클릭 또는 타이머에 의한 진행을 구성하며, 효과별 옵션을 조정할 수 있습니다. 이 문서에서는 C# 예제를 사용하여 전환을 적용하고, 정확한 전환 지속 시간을 설정하며, 슬라이드 타이밍을 관리하고 두 슬라이드 간에 Morph 전환을 만드는 방법을 보여줍니다. 예제는 또한 설정을 PPTX 파일로 저장하는 방법을 보여줍니다.

## **슬라이드 전환 추가**

전환을 적용하려면 [Presentation](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation/) 클래스로 프레젠테이션을 로드하고 슬라이드의 [SlideShowTransition](https://reference.aspose.com/slides/ko/net/aspose.slides/ibaseslide/slideshowtransition/) 속성에 접근합니다. [Type](https://reference.aspose.com/slides/ko/net/aspose.slides/islideshowtransition/type/)을 [TransitionType](https://reference.aspose.com/slides/ko/net/aspose.slides.slideshow/transitiontype/) 열거형의 값으로 설정한 후 프레젠테이션을 저장합니다.

다음 예제는 첫 번째 슬라이드에 Circle 전환을, 두 번째 슬라이드에 Comb 전환을 적용합니다. 최소 두 개의 슬라이드가 포함된 `input.pptx` 파일을 사용하십시오.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SlideShow;

using var presentation = new Presentation("input.pptx");

if (presentation.Slides.Count >= 2)
{
    presentation.Slides[0].SlideShowTransition.Type = TransitionType.Circle;
    presentation.Slides[1].SlideShowTransition.Type = TransitionType.Comb;

    presentation.Save("slide-transitions.pptx", SaveFormat.Pptx);
}
else
{
    Console.WriteLine("The input presentation must contain at least two slides.");
}
```

## **고급 슬라이드 전환 추가**

슬라이드가 화면에 머무는 시간과 마우스 클릭으로 슬라이드 쇼를 진행할지 여부를 구성할 수 있습니다. 다음 속성이 이 동작을 제어합니다:

- [AdvanceOnClick](https://reference.aspose.com/slides/ko/net/aspose.slides/islideshowtransition/advanceonclick/) 사용자가 마우스를 클릭하여 진행할 수 있도록 합니다.
- [AdvanceAfter](https://reference.aspose.com/slides/ko/net/aspose.slides/islideshowtransition/advanceafter/) 자동 진행을 가능하게 합니다.
- [AdvanceAfterTime](https://reference.aspose.com/slides/ko/net/aspose.slides/islideshowtransition/advanceaftertime/) 자동 진행 전 지연 시간을 밀리초 단위로 지정합니다.

클릭과 타이머 기반 진행을 모두 활성화하면 사용자가 클릭으로 진행하거나 타이머가 끝날 때까지 기다릴 수 있습니다. 타이머만 사용하려면 [AdvanceOnClick](https://reference.aspose.com/slides/ko/net/aspose.slides/islideshowtransition/advanceonclick/)을 `false`로 설정하십시오. 지연 시간은 슬라이드 쇼가 언제 진행되는지를 제어하며, 시각적 전환 효과의 지속 시간을 설정하지는 않습니다.

다음 예제는 첫 번째 세 슬라이드에 서로 다른 효과를 지정하고 각각 3초, 5초, 7초 후에 자동 진행을 활성화합니다. 마우스 클릭으로도 이러한 슬라이드를 진행할 수 있습니다. 최소 세 개의 슬라이드가 포함된 `input.pptx` 파일을 사용하십시오.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SlideShow;

using var presentation = new Presentation("input.pptx");

if (presentation.Slides.Count >= 3)
{
    var firstTransition = presentation.Slides[0].SlideShowTransition;
    firstTransition.Type = TransitionType.Circle;
    firstTransition.AdvanceOnClick = true;
    firstTransition.AdvanceAfter = true;
    firstTransition.AdvanceAfterTime = 3000;

    var secondTransition = presentation.Slides[1].SlideShowTransition;
    secondTransition.Type = TransitionType.Comb;
    secondTransition.AdvanceOnClick = true;
    secondTransition.AdvanceAfter = true;
    secondTransition.AdvanceAfterTime = 5000;

    var thirdTransition = presentation.Slides[2].SlideShowTransition;
    thirdTransition.Type = TransitionType.Zoom;
    thirdTransition.AdvanceOnClick = true;
    thirdTransition.AdvanceAfter = true;
    thirdTransition.AdvanceAfterTime = 7000;

    presentation.Save("advanced-transitions.pptx", SaveFormat.Pptx);
}
else
{
    Console.WriteLine("The input presentation must contain at least three slides.");
}
```

타이머 기반 진행이 활성화되었는지 확인하려면 [AdvanceAfter](https://reference.aspose.com/slides/ko/net/aspose.slides/islideshowtransition/advanceafter/)를 읽으십시오. 저장된 지연 시간만으로는 타이머가 활성 상태임을 의미하지 않습니다.

다음 예제는 위에서 저장한 파일을 열고, 활성화된 타이머를 각각 보고, 2초보다 큰 지연 시간이 있는 슬라이드에 대해 자동 진행을 비활성화합니다. 해당 슬라이드에 대해서는 마우스 클릭을 활성화하고 업데이트된 설정을 저장합니다.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("advanced-transitions.pptx");

foreach (var slide in presentation.Slides)
{
    var transition = slide.SlideShowTransition;

    if (transition.AdvanceAfter)
    {
        Console.WriteLine($"Slide {slide.SlideNumber}: advance after {transition.AdvanceAfterTime} ms.");

        if (transition.AdvanceAfterTime > 2000)
        {
            transition.AdvanceAfter = false;
            transition.AdvanceOnClick = true;
        }
    }
}

presentation.Save("adjusted-transitions.pptx", SaveFormat.Pptx);
```

## **전환 타이밍을 정확히 제어**

[Duration](https://reference.aspose.com/slides/ko/net/aspose.slides.slideshow/slideshowtransition/duration/)을 사용하여 전환 효과의 정확한 길이를 밀리초 단위로 지정합니다. 슬라이드의 [SlideShowTransition](https://reference.aspose.com/slides/ko/net/aspose.slides/ibaseslide/slideshowtransition/) 속성은 [ISlideShowTransition](https://reference.aspose.com/slides/ko/net/aspose.slides/islideshowtransition/)을 통해 이러한 설정을 노출합니다:

| 속성 | 용도 |
| --- | --- |
| [Duration](https://reference.aspose.com/slides/ko/net/aspose.slides.slideshow/slideshowtransition/duration/) | 전환 효과 자체의 지속 시간을 밀리초 단위로 설정합니다. |
| [AdvanceAfterTime](https://reference.aspose.com/slides/ko/net/aspose.slides.slideshow/slideshowtransition/advanceaftertime/) | 슬라이드가 자동으로 진행되기 전의 지연 시간을 밀리초 단위로 설정합니다. 이 타이머를 활성화하려면 [AdvanceAfter](https://reference.aspose.com/slides/ko/net/aspose.slides/islideshowtransition/advanceafter/)를 사용하십시오. |
| [Speed](https://reference.aspose.com/slides/ko/net/aspose.slides.slideshow/slideshowtransition/speed/) | [TransitionSpeed](https://reference.aspose.com/slides/ko/net/aspose.slides.slideshow/transitionspeed/)에서 사전 정의된 속도 범주(느림, 보통, 빠름) 중 하나를 선택합니다. 정확한 지속 시간이 지정되지 않은 경우에 사용됩니다. |

[Duration](https://reference.aspose.com/slides/ko/net/aspose.slides.slideshow/slideshowtransition/duration/)은 전환 효과만을 제어하며, 슬라이드가 화면에 머무는 시간을 결정하지는 않습니다. 자동 진행 지연은 별도로 구성하십시오. 명시적인 지속 시간이 설정되지 않은 경우 Aspose.Slides는 전환 유형과 [Speed](https://reference.aspose.com/slides/ko/net/aspose.slides.slideshow/slideshowtransition/speed/) 값을 기반으로 효과 지속 시간을 결정합니다.

### **모든 슬라이드에 동일한 지속 시간 적용**

일관된 템포를 위해 모든 슬라이드에 동일한 효과와 정확한 지속 시간을 적용합니다. 이 예제는 `input.pptx`를 로드하고, [TransitionType](https://reference.aspose.com/slides/ko/net/aspose.slides.slideshow/transitiontype/)에서 Fade를 선택한 뒤 각 전환에 750밀리초의 지속 시간을 부여합니다. 자동 진행은 5,000밀리초 후에 별도로 활성화하고 마우스 클릭 진행은 비활성화한 뒤 결과를 PPTX로 저장합니다.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SlideShow;

using var presentation = new Presentation("input.pptx");

foreach (var slide in presentation.Slides)
{
    var transition = slide.SlideShowTransition;
    transition.Type = TransitionType.Fade;
    transition.Duration = 750;

    // 효과 지속 시간과 별도로 자동 진행을 구성합니다.
    transition.AdvanceAfter = true;
    transition.AdvanceAfterTime = 5000;
    transition.AdvanceOnClick = false;
}

presentation.Save("precise-transitions.pptx", SaveFormat.Pptx);
```

### **개별 슬라이드에 다른 지속 시간 설정**

다른 슬라이드가 서로 다른 효과 지속 시간을 사용할 수 있습니다. 예를 들어 제목 슬라이드에는 짧은 전환을, 섹션 소개 슬라이드에는 더 긴 전환을 사용할 수 있습니다. 이 예제는 첫 번째 슬라이드에 500밀리초, 두 번째 슬라이드에 1,200밀리초를 설정합니다. 최소 두 개의 슬라이드가 포함된 `input.pptx` 파일을 사용하십시오.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SlideShow;

using var presentation = new Presentation("input.pptx");

if (presentation.Slides.Count >= 2)
{
    var firstTransition = presentation.Slides[0].SlideShowTransition;
    firstTransition.Type = TransitionType.Fade;
    firstTransition.Duration = 500;

    var secondTransition = presentation.Slides[1].SlideShowTransition;
    secondTransition.Type = TransitionType.Push;
    secondTransition.Duration = 1200;

    presentation.Save("individual-transition-durations.pptx", SaveFormat.Pptx);
}
else
{
    Console.WriteLine("The input presentation must contain at least two slides.");
}
```

### **애니메이션 출력과 전환 조정**

[animated GIF](/slides/ko/net/convert-powerpoint-to-animated-gif/), [HTML5 presentation](/slides/ko/net/export-to-html5/) 또는 [video](/slides/ko/net/convert-powerpoint-to-video/)를 준비할 때, 의도된 템포에 맞추기 위해 내보내기 전에 정확한 전환 지속 시간을 설정하십시오. 예를 들어 장면 사이에 600밀리초 페이드를 사용하고, 각 슬라이드의 진행 지연을 별도로 조정하여 내레이션이나 콘텐츠가 재생될 시간을 확보합니다.

GIF 및 비디오의 경우 출력 프레임 레이트를 효과 지속 시간과 맞추어야 합니다. 600밀리초는 30fps에서 18프레임에 해당합니다. HTML5에서는 내보내기 설정에서 애니메이션 전환을 활성화하십시오. 선택한 내보내기 형식이 지원하는 효과 및 타이밍 옵션을 확인하고, 동기화를 확인하기 위해 출력을 미리 보기하십시오.

### **기존 전환 지속 시간 읽기**

전환을 수정하기 전에 [Duration](https://reference.aspose.com/slides/ko/net/aspose.slides.slideshow/slideshowtransition/duration/)을 읽어 명시적인 값이 저장되어 있는지 확인하십시오. `-1`값은 명시적인 지속 시간이 설정되지 않았음을 의미하고, 0 이상의 값은 밀리초 단위로 저장된 지속 시간을 지정합니다. 설정되지 않은 값은 계산된 재생 지속 시간이 아니며, Aspose.Slides는 전환 유형과 [Speed](https://reference.aspose.com/slides/ko/net/aspose.slides.slideshow/slideshowtransition/speed/)를 사용하여 해당 지속 시간을 결정합니다. 전환 유형을 설정하면 지속 시간이 초기화될 수 있으므로 먼저 원래 설정을 검사하십시오.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("input.pptx");

foreach (var slide in presentation.Slides)
{
    var transition = slide.SlideShowTransition;
    var duration = transition.Duration;

    if (duration >= 0)
    {
        Console.WriteLine($"Slide {slide.SlideNumber}: stored transition duration is {duration} ms.");
    }
    else
    {
        Console.WriteLine($"Slide {slide.SlideNumber}: no explicit duration; timing depends on {transition.Type} and {transition.Speed}.");
    }
}
```

## **Morph 전환**

Morph 전환은 연속된 슬라이드에 있는 객체 간의 변화를 애니메이션합니다. 간단한 Morph 효과를 만들려면 슬라이드를 복제하고, 복제본에서 객체를 이동하거나 크기를 조정한 뒤 두 번째 슬라이드에 Morph 전환을 적용합니다. 이렇게 하면 전환이 원본 상태와 수정된 상태 사이의 해당 객체를 애니메이션하도록 합니다.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SlideShow;

using var presentation = new Presentation();

var firstSlide = presentation.Slides[0];
var rectangle = firstSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 100);
rectangle.TextFrame.Text = "Morph transition";

var secondSlide = presentation.Slides.AddClone(firstSlide);
var movedRectangle = secondSlide.Shapes[0];
movedRectangle.X += 100;
movedRectangle.Y += 50;
movedRectangle.Width -= 200;
movedRectangle.Height -= 10;

secondSlide.SlideShowTransition.Type = TransitionType.Morph;

presentation.Save("morph-transition.pptx", SaveFormat.Pptx);
```

## **Morph 전환 유형**

[TransitionMorphType](https://reference.aspose.com/slides/ko/net/aspose.slides.slideshow/transitionmorphtype/) 열거형은 Morph가 콘텐츠를 일치시키고 애니메이션하는 방식을 제어합니다:

- [ByObject](https://reference.aspose.com/slides/ko/net/aspose.slides.slideshow/transitionmorphtype/) 각 도형을 전체 객체로 취급합니다.
- [ByWord](https://reference.aspose.com/slides/ko/net/aspose.slides.slideshow/transitionmorphtype/) 가능한 경우 단어를 일치시켜 텍스트를 애니메이션합니다.
- [ByChar](https://reference.aspose.com/slides/ko/net/aspose.slides.slideshow/transitionmorphtype/) 가능한 경우 글자를 일치시켜 텍스트를 애니메이션합니다.

전환 [Type](https://reference.aspose.com/slides/ko/net/aspose.slides/islideshowtransition/type/)을 Morph로 설정한 다음 [Value](https://reference.aspose.com/slides/ko/net/aspose.slides/islideshowtransition/value/)에 접근하십시오. 이 값은 [IMorphTransition](https://reference.aspose.com/slides/ko/net/aspose.slides.slideshow/imorphtransition/) 인터페이스를 제공하며, 해당 인터페이스의 [MorphType](https://reference.aspose.com/slides/ko/net/aspose.slides.slideshow/imorphtransition/morphtype/) 속성을 사용해 매칭 모드를 선택합니다.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SlideShow;

using var presentation = new Presentation("morph-transition.pptx");

if (presentation.Slides.Count >= 2)
{
    var transition = presentation.Slides[1].SlideShowTransition;
    transition.Type = TransitionType.Morph;

    if (transition.Value is IMorphTransition morphTransition)
    {
        morphTransition.MorphType = TransitionMorphType.ByWord;
        presentation.Save("morph-by-word.pptx", SaveFormat.Pptx);
    }
    else
    {
        Console.WriteLine("Morph transition options are unavailable.");
    }
}
else
{
    Console.WriteLine("The input presentation must contain at least two slides.");
}
```

## **전환 효과 설정**

일부 전환은 방향이나 효과가 검은 화면에서 시작하는지 여부와 같은 추가 옵션을 제공합니다. 사용 가능한 옵션은 선택된 전환 [Type](https://reference.aspose.com/slides/ko/net/aspose.slides/islideshowtransition/type/)에 따라 달라집니다. 먼저 유형을 설정하고, 그 다음 [Value](https://reference.aspose.com/slides/ko/net/aspose.slides/islideshowtransition/value/)에서 적절한 인터페이스를 사용하십시오.

다음 예제는 `input.pptx`의 첫 번째 슬라이드에 Cut 전환을 적용합니다. [IOptionalBlackTransition](https://reference.aspose.com/slides/ko/net/aspose.slides.slideshow/ioptionalblacktransition/)을 통해 [FromBlack](https://reference.aspose.com/slides/ko/net/aspose.slides.slideshow/ioptionalblacktransition/fromblack/)을 설정하여 전환이 검은 화면에서 시작하도록 합니다.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SlideShow;

using var presentation = new Presentation("input.pptx");
var transition = presentation.Slides[0].SlideShowTransition;
transition.Type = TransitionType.Cut;

if (transition.Value is IOptionalBlackTransition cutTransition)
{
    cutTransition.FromBlack = true;
    presentation.Save("cut-from-black.pptx", SaveFormat.Pptx);
}
else
{
    Console.WriteLine("Cut transition options are unavailable.");
}
```

## **FAQ**

**슬라이드 전환의 재생 속도를 제어할 수 있나요?**

예. 밀리초 단위의 정확한 효과 지속 시간이 필요할 경우 [Duration](https://reference.aspose.com/slides/ko/net/aspose.slides.slideshow/slideshowtransition/duration/)을 사용하십시오. 사전 정의된 [TransitionSpeed](https://reference.aspose.com/slides/ko/net/aspose.slides.slideshow/transitionspeed/) 카테고리(느림, 보통, 빠름)만으로 충분하고 명시적인 지속 시간이 설정되지 않은 경우에는 [Speed](https://reference.aspose.com/slides/ko/net/aspose.slides.slideshow/slideshowtransition/speed/)을 사용하십시오. 이러한 설정은 자동 진행 지연과 별도로 전환 효과를 제어합니다.

**전환에 오디오를 연결하고 반복 재생할 수 있나요?**

예. [Sound](https://reference.aspose.com/slides/ko/net/aspose.slides/islideshowtransition/sound/)에 포함된 오디오를 지정하고, [TransitionSoundMode](https://reference.aspose.com/slides/ko/net/aspose.slides.slideshow/transitionsoundmode/) 열거형에서 `StartSound`로 [SoundMode](https://reference.aspose.com/slides/ko/net/aspose.slides/islideshowtransition/soundmode/)를 설정한 뒤 [SoundLoop](https://reference.aspose.com/slides/ko/net/aspose.slides/islideshowtransition/soundloop/)을 활성화하십시오. 오디오는 슬라이드 쇼에서 다음 사운드 이벤트가 발생할 때까지 반복됩니다.

**모든 슬라이드에 동일한 전환을 가장 빠르게 적용하는 방법은 무엇인가요?**

프레젠테이션의 [Slides](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation/slides/ko/) 컬렉션을 순회하면서 각 슬라이드의 전환 [Type](https://reference.aspose.com/slides/ko/net/aspose.slides/islideshowtransition/type/)을 동일한 값으로 설정하십시오. 같은 루프에서 타이밍 및 효과 옵션을 설정하면 슬라이드 간 동작을 일관되게 유지할 수 있습니다.

**슬라이드에 현재 설정된 전환을 어떻게 확인할 수 있나요?**

슬라이드의 [SlideShowTransition](https://reference.aspose.com/slides/ko/net/aspose.slides/ibaseslide/slideshowtransition/)에서 [Type](https://reference.aspose.com/slides/ko/net/aspose.slides/islideshowtransition/type/) 속성을 읽으십시오. 이 값은 [TransitionType](https://reference.aspose.com/slides/ko/net/aspose.slides.slideshow/transitiontype/) 열거형 중 하나이며, `None`이면 전환 효과가 적용되지 않은 것입니다.