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
- 모프 전환
- 전환 유형
- 전환 효과
- PowerPoint
- OpenDocument
- 프레젠테이션
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET에서 슬라이드 전환을 맞춤 설정하는 방법을 알아보고, PowerPoint 및 OpenDocument 프레젠테이션에 대한 단계별 가이드를 제공합니다."
---
## **개요**

이 문서에서는 Aspose.Slides를 사용하여 프레젠테이션의 슬라이드 전환을 관리하는 방법을 설명합니다. 슬라이드에 전환 유형을 적용하고, 클릭 시 또는 지정된 시간 후에 전환이 진행되도록 전환 동작을 구성하며, 자동 전환을 확인하고 비활성화하고, Morph 전환 및 그 유형을 사용하고, 전환 효과 옵션을 설정하는 방법을 보여줍니다. 예제에서는 프레젠테이션을 로드하거나 생성하고, 선택된 슬라이드에 대한 전환 설정을 수정한 뒤 결과를 PPTX 파일로 저장하는 과정을 보여줍니다. 또한 전환 속도, 전환 사운드, 여러 슬라이드에 동일한 전환 적용, 슬라이드에 현재 설정된 전환 확인 등에 관한 일반적인 질문에도 답변합니다.

## **슬라이드 전환 추가**
슬라이드 전환을 쉽게 이해할 수 있도록 Aspose.Slides for .NET을 사용한 간단한 슬라이드 전환 관리 예제를 보여줍니다. 개발자는 슬라이드에 다양한 전환 효과를 적용할 뿐만 아니라 이러한 전환 효과의 동작을 사용자 정의할 수 있습니다. 간단한 슬라이드 전환 효과를 만들려면 아래 단계를 따르세요:

1. [Presentation](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation) 클래스의 인스턴스를 생성합니다.
1. TransitionType 열거형을 통해 Aspose.Slides for .NET에서 제공하는 전환 효과 중 하나를 선택하여 슬라이드에 슬라이드 전환 유형을 적용합니다.
1. 수정된 프레젠테이션 파일을 기록합니다.

```c#
// 소스 프레젠테이션 파일을 로드하기 위해 Presentation 클래스를 인스턴스화합니다
using (Presentation presentation = new Presentation("AccessSlides.pptx"))
{
    // 슬라이드 1에 원형 전환을 적용합니다
    presentation.Slides[0].SlideShowTransition.Type = TransitionType.Circle;

    // 슬라이드 2에 콤 타입 전환을 적용합니다
    presentation.Slides[1].SlideShowTransition.Type = TransitionType.Comb;

    // 프레젠테이션을 디스크에 저장합니다
    presentation.Save("SampleTransition_out.pptx", SaveFormat.Pptx);
}
```

## **고급 슬라이드 전환 추가**
위 섹션에서는 슬라이드에 간단한 전환 효과만 적용했습니다. 이제 해당 간단한 전환 효과를 보다 개선하고 제어하려면 아래 단계를 따르세요:

1. [Presentation](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation) 클래스의 인스턴스를 생성합니다.
1. Aspose.Slides for .NET에서 제공하는 전환 효과 중 하나를 선택하여 슬라이드에 슬라이드 전환 유형을 적용합니다.
1. 전환을 클릭 시 진행(Advance On Click), 특정 시간 후 진행(Advance After Time) 또는 두 가지 모두로 설정할 수 있습니다.
1. 슬라이드 전환이 클릭 시 진행으로 설정된 경우, 마우스를 클릭할 때만 전환이 진행됩니다. 또한 Advance After Time 속성이 설정된 경우, 지정된 시간이 경과하면 전환이 자동으로 진행됩니다.
1. 수정된 프레젠테이션을 프레젠테이션 파일로 기록합니다.

```c#
// 프레젠테이션 파일을 나타내는 Presentation 클래스를 인스턴스화합니다
using (Presentation pres = new Presentation("BetterSlideTransitions.pptx"))
{

    // 슬라이드 1에 원형 전환을 적용합니다
    pres.Slides[0].SlideShowTransition.Type = TransitionType.Circle;


    // 전환 시간을 3초로 설정합니다
    pres.Slides[0].SlideShowTransition.AdvanceOnClick = true;
    pres.Slides[0].SlideShowTransition.AdvanceAfterTime = 3000;

    // 슬라이드 2에 콤 타입 전환을 적용합니다
    pres.Slides[1].SlideShowTransition.Type = TransitionType.Comb;


    // 전환 시간을 5초로 설정합니다
    pres.Slides[1].SlideShowTransition.AdvanceOnClick = true;
    pres.Slides[1].SlideShowTransition.AdvanceAfterTime = 5000;

    // 슬라이드 3에 줌 타입 전환을 적용합니다
    pres.Slides[2].SlideShowTransition.Type = TransitionType.Zoom;


    // 전환 시간을 7초로 설정합니다
    pres.Slides[2].SlideShowTransition.AdvanceOnClick = true;
    pres.Slides[2].SlideShowTransition.AdvanceAfterTime = 7000;

    // 프레젠테이션을 디스크에 저장합니다
    pres.Save("SampleTransition_out.pptx", SaveFormat.Pptx);
}
```

또한 [AdvanceAfter](https://reference.aspose.com/slides/ko/net/aspose.slides/islideshowtransition/advanceafter/) 속성을 사용하여 슬라이드 전환이 다음 슬라이드로 이동하도록 구성되었는지 확인하거나 해당 설정을 비활성화할 수 있습니다.

다음 C# 코드는 해당 작업을 시연합니다:

```c#
// 프레젠테이션 파일을 나타내는 Presentation 클래스를 인스턴스화합니다
using (Presentation pres = new Presentation("SampleTransition_out.pptx"))
{
    foreach (ISlide slide in pres.Slides)
    {
        // 슬라이드 전환을 가져옵니다
        ISlideShowTransition slideTransition = slide.SlideShowTransition;

        // Advance After Time 설정이 활성화되어 있는지 확인합니다
        if (slideTransition.AdvanceAfter)
        {
            // Advance After Time 값을 출력합니다
            Console.WriteLine("The slide #" + slide.SlideNumber + " AdvancedAfterTime: " + slideTransition.AdvanceAfterTime);
        }

        // AdvancedAfterTime 값이 2초보다 크면 특정 시간 후에 전환을 비활성화합니다
        if (slideTransition.AdvanceAfterTime > 2000)
        {
            slideTransition.AdvanceAfter = false;
        }
    }
}
```

## **Morph 전환**
Aspose.Slides for .NET은 이제 [Morph Transition](https://reference.aspose.com/slides/ko/net/aspose.slides.slideshow/imorphtransition)을 지원합니다. 이는 PowerPoint 2019에 도입된 새로운 Morph 전환을 나타냅니다. Morph 전환을 사용하면 한 슬라이드에서 다음 슬라이드로 부드러운 움직임을 애니메이션화할 수 있습니다. 이 문서에서는 개념과 Morph 전환 사용 방법을 설명합니다. Morph 전환을 효과적으로 사용하려면 최소 하나의 공통 객체가 있는 두 개의 슬라이드가 필요합니다. 가장 쉬운 방법은 슬라이드를 복제한 다음 두 번째 슬라이드에서 객체를 다른 위치로 이동하는 것입니다.

다음 코드 조각은 텍스트가 포함된 슬라이드 복제본을 프레젠테이션에 추가하고 두 번째 슬라이드에 [morph type](https://reference.aspose.com/slides/ko/net/aspose.slides.slideshow/imorphtransition/properties/morphtype) 전환을 설정하는 방법을 보여줍니다.

```c#
using (Presentation presentation = new Presentation())
{
    AutoShape autoshape = (AutoShape)presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 100);
    autoshape.TextFrame.Text = "Morph Transition in PowerPoint Presentations";

    presentation.Slides.AddClone(presentation.Slides[0]);

    presentation.Slides[1].Shapes[0].X += 100;
    presentation.Slides[1].Shapes[0].Y += 50;
    presentation.Slides[1].Shapes[0].Width -= 200;
    presentation.Slides[1].Shapes[0].Height -= 10;

    presentation.Slides[1].SlideShowTransition.Type = Aspose.Slides.SlideShow.TransitionType.Morph;

    presentation.Save("presentation-out.pptx", SaveFormat.Pptx);
}
```

## **Morph 전환 유형**
새로운 [Aspose.Slides.SlideShow.TransitionMorphType](https://reference.aspose.com/slides/ko/net/aspose.slides.slideshow/transitionmorphtype) 열거형이 추가되었습니다. 이는 다양한 Morph 슬라이드 전환 유형을 나타냅니다.

TransitionMorphType 열거형에는 세 가지 멤버가 있습니다:

- ByObject: 형태를 개별 객체로 간주하여 Morph 전환을 수행합니다.
- ByWord: 가능한 경우 텍스트를 단어 단위로 전송하면서 Morph 전환을 수행합니다.
- ByChar: 가능한 경우 텍스트를 문자 단위로 전송하면서 Morph 전환을 수행합니다.

다음 코드 조각은 슬라이드에 Morph 전환을 설정하고 Morph 유형을 변경하는 방법을 보여줍니다:

```c#
using (Presentation presentation = new Presentation("presentation.pptx"))
{
    presentation.Slides[0].SlideShowTransition.Type = TransitionType.Morph;
    ((IMorphTransition)presentation.Slides[0].SlideShowTransition.Value).MorphType = TransitionMorphType.ByWord;
    presentation.Save("presentation-out.pptx", SaveFormat.Pptx);
}
```

## **전환 효과 설정**
Aspose.Slides for .NET은 검은색에서, 왼쪽에서, 오른쪽에서 등과 같은 전환 효과 설정을 지원합니다. 전환 효과를 설정하려면 아래 단계를 따르세요:

- [Presentation](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation) 클래스의 인스턴스를 생성합니다.
- 슬라이드의 참조를 가져옵니다.
- 전환 효과를 설정합니다.
- 프레젠테이션을 [PPTX](https://docs.fileformat.com/presentation/pptx/) 파일로 기록합니다.

아래 예제에서는 전환 효과를 설정했습니다.

```c#
// Presentation 클래스 인스턴스를 생성합니다
Presentation presentation = new Presentation("AccessSlides.pptx");

// 효과 설정
presentation.Slides[0].SlideShowTransition.Type = TransitionType.Cut;
((OptionalBlackTransition)presentation.Slides[0].SlideShowTransition.Value).FromBlack = true;

// 프레젠테이션을 디스크에 저장합니다
presentation.Save("SetTransitionEffects_out.pptx", SaveFormat.Pptx);
```

## **FAQ**

**슬라이드 전환의 재생 속도를 제어할 수 있나요?**

예. 전환의 [Speed](https://reference.aspose.com/slides/ko/net/aspose.slides.slideshow/slideshowtransition/speed/)를 [TransitionSpeed](https://reference.aspose.com/slides/ko/net/aspose.slides.slideshow/transitionspeed/) 설정(예: slow/medium/fast)으로 지정합니다.

**전환에 오디오를 연결하고 반복 재생할 수 있나요?**

예. 전환에 사운드를 삽입하고 사운드 모드와 루핑([Sound](https://reference.aspose.com/slides/ko/net/aspose.slides.slideshow/slideshowtransition/sound/), [SoundMode](https://reference.aspose.com/slides/ko/net/aspose.slides.slideshow/slideshowtransition/soundmode/), [SoundLoop](https://reference.aspose.com/slides/ko/net/aspose.slides.slideshow/slideshowtransition/soundloop/)) 등 설정을 통해 동작을 제어할 수 있습니다. 또한 [SoundIsBuiltIn](https://reference.aspose.com/slides/ko/net/aspose.slides.slideshow/slideshowtransition/soundisbuiltin/) 및 [SoundName](https://reference.aspose.com/slides/ko/net/aspose.slides.slideshow/slideshowtransition/soundname/)과 같은 메타데이터도 사용할 수 있습니다.

**모든 슬라이드에 동일한 전환을 적용하는 가장 빠른 방법은 무엇인가요?**

각 슬라이드의 전환 설정에 원하는 전환 유형을 구성하면 됩니다. 전환은 슬라이드별로 저장되므로 모든 슬라이드에 동일한 유형을 적용하면 일관된 결과를 얻을 수 있습니다.

**슬라이드에 현재 설정된 전환을 어떻게 확인할 수 있나요?**

슬라이드의 [transition settings](https://reference.aspose.com/slides/ko/net/aspose.slides/baseslide/slideshowtransition/)을 검사하고 해당 슬라이드의 [transition type](https://reference.aspose.com/slides/ko/net/aspose.slides.slideshow/slideshowtransition/type/)을 읽으면 현재 적용된 효과를 정확히 알 수 있습니다.