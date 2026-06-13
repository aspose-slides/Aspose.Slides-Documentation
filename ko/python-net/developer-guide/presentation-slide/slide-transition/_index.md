---
title: Python을 사용한 프레젠테이션 슬라이드 전환 관리
linktitle: 슬라이드 전환
type: docs
weight: 90
url: /ko/python-net/slide-transition/
keywords:
- 슬라이드 전환
- 슬라이드 전환 추가
- 슬라이드 전환 적용
- 고급 슬라이드 전환
- 모프 전환
- 전환 유형
- 전환 효과
- Python
- Aspose.Slides
description: "Aspose.Slides for Python을 통해 .NET에서 슬라이드 전환을 사용자 정의하는 방법을 알아보고, PowerPoint 및 OpenDocument 프레젠테이션에 대한 단계별 안내를 제공합니다."
---
## **개요**

Aspose.Slides for Python은 슬라이드 전환에 대한 전체 제어 기능을 제공하며, 전환 유형 선택부터 자동 프레젠테이션 워크플로우의 타이밍 및 트리거 구성까지 지원합니다. 슬라이드를 클릭 시 또는 지정된 지연 시간 후에 진행하도록 설정할 수 있으며, 검은색에서의 전환이나 방향성 입장과 같은 효과로 시각적 동작을 다듬을 수 있습니다. 이 라이브러리는 PowerPoint 2019에서 도입된 Morph 전환도 지원하며, 개체, 단어 또는 문자별로 변형되는 모드를 통해 슬라이드 간에 부드럽고 일관된 움직임을 만들 수 있습니다.

## **슬라이드 전환 추가**

보다 쉽게 이해할 수 있도록 이 예제에서는 Aspose.Slides for Python을 사용하여 간단한 슬라이드 전환을 관리하는 방법을 보여줍니다. 개발자는 슬라이드에 다양한 전환 효과를 적용하고 동작을 사용자 지정할 수 있습니다. 간단한 슬라이드 전환을 만들려면 다음 단계를 따르세요:

1. Presentation 클래스의 인스턴스를 생성합니다.
1. [TransitionType](https://reference.aspose.com/slides/ko/python-net/aspose.slides.slideshow/transitiontype/) 열거형의 효과 중 하나를 사용하여 슬라이드 전환을 적용합니다.
1. 수정된 프레젠테이션 파일을 저장합니다.

```py
import aspose.slides as slides

# 프레젠테이션 파일을 로드하기 위해 Presentation 클래스를 인스턴스화합니다.
with slides.Presentation("sample.pptx") as presentation:
    # 슬라이드 1에 원형 전환을 적용합니다.
    presentation.slides[0].slide_show_transition.type = slides.slideshow.TransitionType.CIRCLE

    # 슬라이드 2에 콤 전환을 적용합니다.
    presentation.slides[1].slide_show_transition.type = slides.slideshow.TransitionType.COMB

    # 프레젠테이션을 디스크에 저장합니다.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **고급 슬라이드 전환 추가**

이 섹션에서는 슬라이드에 간단한 전환 효과를 적용했습니다. 해당 효과를 더 정밀하고 세련되게 만들려면 다음 단계를 따르세요:

1. Presentation 클래스의 인스턴스를 생성합니다.
1. [TransitionType](https://reference.aspose.com/slides/ko/python-net/aspose.slides.slideshow/transitiontype/) 열거형의 효과 중 하나를 사용하여 슬라이드 전환을 적용합니다.
1. 전환을 클릭 시 진행(Advance On Click), 특정 시간 후 진행(Advance After Time) 또는 두 가지 모두로 설정합니다.
1. 수정된 프레젠테이션 파일을 저장합니다.

**Advance On Click**이 활성화된 경우 사용자가 클릭할 때만 슬라이드가 진행됩니다. **Advance After Time** 속성이 설정되면 지정된 간격 후에 슬라이드가 자동으로 진행됩니다.

```py
import aspose.slides as slides

# 프레젠테이션 파일을 열기 위해 Presentation 클래스를 인스턴스화합니다.
with slides.Presentation("sample.pptx") as presentation:
    slide0 = presentation.slides[0]

    # 슬라이드 1에 원형 전환을 적용합니다.
    slide0.slide_show_transition.type = slides.slideshow.TransitionType.CIRCLE

    # 클릭 시 진행을 활성화하고 3초 자동 진행을 설정합니다.
    slide0.slide_show_transition.advance_on_click = True
    slide0.slide_show_transition.advance_after_time = 3000

    slide1 = presentation.slides[1]

    # 슬라이드 2에 콤 전환을 적용합니다.
    slide1.slide_show_transition.type = slides.slideshow.TransitionType.COMB

    # 클릭 시 진행을 활성화하고 5초 자동 진행을 설정합니다.
    slide1.slide_show_transition.advance_on_click = True
    slide1.slide_show_transition.advance_after_time = 5000

    slide2 = presentation.slides[2]

    # 슬라이드 3에 확대 전환을 적용합니다.
    slide2.slide_show_transition.type = slides.slideshow.TransitionType.ZOOM

    # 클릭 시 진행을 활성화하고 7초 자동 진행을 설정합니다.
    slide2.slide_show_transition.advance_on_click = True
    slide2.slide_show_transition.advance_after_time = 7000

    # 프레젠테이션을 디스크에 저장합니다.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Morph 전환**

Aspose.Slides for Python은 [Morph 전환](https://reference.aspose.com/slides/ko/python-net/aspose.slides.slideshow/morphtransition/)을 지원하며, 이는 한 슬라이드에서 다음 슬라이드로의 부드러운 움직임을 애니메이션화합니다. 이 섹션에서는 Morph 전환 사용 방법을 설명합니다. 효과적으로 사용하려면 최소 하나의 공통 객체가 있는 두 개의 슬라이드가 필요합니다. 가장 쉬운 방법은 슬라이드를 복제한 다음 두 번째 슬라이드에서 객체를 다른 위치로 이동하는 것입니다.

다음 코드 스니펫은 텍스트가 포함된 슬라이드를 복제하고 두 번째 슬라이드에 Morph 전환을 적용하는 방법을 보여줍니다.

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide0 = presentation.slides[0]

    auto_shape = slide0.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 400, 100)
    auto_shape.text_frame.text = "Morph Transition in PowerPoint Presentations"

    # Morph 연속성을 위해 같은 도형을 가진 두 번째 슬라이드를 만들려면 첫 번째 슬라이드를 복제합니다.
    slide1 = presentation.slides.add_clone(slide0)

    # 두 번째 슬라이드에서 같은 사각형을 선택하고 위치와 크기를 변경합니다.
    shape = slide1.shapes[0]
    shape.x += 100
    shape.y += 50
    shape.width -= 200
    shape.height -= 10

    # 두 번째 슬라이드에 Morph 전환을 활성화하여 도형 변경을 부드럽게 애니메이션합니다.
    slide1.slide_show_transition.type = slides.slideshow.TransitionType.MORPH

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Morph 전환 유형**

[TransitionMorphType](https://reference.aspose.com/slides/ko/python-net/aspose.slides.slideshow/transitionmorphtype/) 열거형은 다양한 Morph 슬라이드 전환 유형을 나타냅니다.

다음 코드 스니펫은 슬라이드에 Morph 전환을 적용하고 morph 유형을 변경하는 방법을 보여줍니다.

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    slide.slide_show_transition.type = slides.slideshow.TransitionType.MORPH
    slide.slide_show_transition.value.morph_type = slides.slideshow.TransitionMorphType.BY_WORD
    
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **전환 효과 설정**

Aspose.Slides for Python을 사용하면 **From Black**, **From Left**, **From Right** 등과 같은 전환 효과를 설정할 수 있습니다. 전환 효과를 구성하려면 다음 단계를 따르세요:

1. Presentation 클래스의 인스턴스를 생성합니다.
1. 슬라이드에 대한 참조를 가져옵니다.
1. 원하는 전환 효과를 설정합니다.
1. 프레젠테이션을 PPTX 파일로 저장합니다.

아래 예제에서는 여러 전환 효과를 설정합니다.

```py
import aspose.slides as slides

# 프레젠테이션 파일을 열기 위해 Presentation 클래스를 인스턴스화합니다.
with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    # Cut 전환을 적용하고 From Black을 활성화합니다.
    slide.slide_show_transition.type = slides.slideshow.TransitionType.CUT
    slide.slide_show_transition.value.from_black = True

    # 프레젠테이션을 디스크에 저장합니다.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**슬라이드 전환의 재생 속도를 제어할 수 있나요?**

예. 전환의 [speed](https://reference.aspose.com/slides/ko/python-net/aspose.slides.slideshow/slideshowtransition/speed/)을 [TransitionSpeed](https://reference.aspose.com/slides/ko/python-net/aspose.slides.slideshow/transitionspeed/) 설정을 사용하여 지정합니다(예: slow/medium/fast).

**전환에 오디오를 연결하고 반복 재생할 수 있나요?**

예. 전환에 대한 사운드를 삽입하고 사운드 모드 및 반복 같은 설정을 통해 동작을 제어할 수 있습니다(예: [sound](https://reference.aspose.com/slides/ko/python-net/aspose.slides.slideshow/slideshowtransition/sound/), [sound_mode](https://reference.aspose.com/slides/ko/python-net/aspose.slides.slideshow/slideshowtransition/sound_mode/), [sound_loop](https://reference.aspose.com/slides/ko/python-net/aspose.slides.slideshow/slideshowtransition/sound_loop/), plus metadata such as [sound_is_built_in](https://reference.aspose.com/slides/ko/python-net/aspose.slides.slideshow/slideshowtransition/sound_is_built_in/), [sound_name](https://reference.aspose.com/slides/ko/python-net/aspose.slides.slideshow/slideshowtransition/sound_name/)).

**모든 슬라이드에 동일한 전환을 적용하는 가장 빠른 방법은 무엇인가요?**

각 슬라이드의 전환 설정에서 원하는 전환 유형을 구성합니다. 전환은 슬라이드마다 저장되므로 모든 슬라이드에 동일한 유형을 적용하면 일관된 결과를 얻을 수 있습니다.

**슬라이드에 현재 설정된 전환을 어떻게 확인할 수 있나요?**

슬라이드의 [transition settings](https://reference.aspose.com/slides/ko/python-net/aspose.slides/slide/slide_show_transition/)을 검사하고 해당 [transition type](https://reference.aspose.com/slides/ko/python-net/aspose.slides.slideshow/slideshowtransition/type/)을 확인합니다. 이 값이 적용된 효과를 정확히 알려줍니다.