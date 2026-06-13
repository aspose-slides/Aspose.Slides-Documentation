---
title: 슬라이드 전환
type: docs
weight: 110
url: /ko/python-net/examples/elements/slide-transition/
keywords:
- 슬라이드 전환
- 슬라이드 전환 추가
- 슬라이드 전환 가져오기
- 슬라이드 전환 제거
- 전환 지속 시간
- 코드 예제
- PowerPoint
- OpenDocument
- 프레젠테이션
- Python
- Aspose.Slides
description: "Aspose.Slides를 사용하여 Python에서 슬라이드 전환을 제어합니다: 유형, 속도, 사운드 및 타이밍을 선택하여 PPT, PPTX 및 ODP 프레젠테이션을 다듬습니다."
---
**Aspose.Slides for Python via .NET**를 사용하여 슬라이드 전환 효과와 타이밍을 적용하는 방법을 보여줍니다.

## **슬라이드 전환 추가**

첫 번째 슬라이드에 페이드 전환 효과를 적용합니다.

```py
def add_slide_transition():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # 페이드 전환 적용.
        slide.slide_show_transition.type = slides.slideshow.TransitionType.FADE

        presentation.save("slide_transition.pptx", slides.export.SaveFormat.PPTX)
```

## **슬라이드 전환 가져오기**

슬라이드에 현재 할당된 전환 유형을 읽습니다.

```py
def access_slide_transition():
    with slides.Presentation("slide_transition.pptx") as presentation:
        slide = presentation.slides[0]

        # 전환 유형에 액세스합니다.
        transition_type = slide.slide_show_transition.type
```

## **슬라이드 전환 제거**

전환 유형을 `NONE`으로 설정하여 모든 전환 효과를 제거합니다.

```py
def remove_slide_transition():
    with slides.Presentation("slide_transition.pptx") as presentation:
        slide = presentation.slides[0]

        # 전환을 없애려면 none으로 설정합니다.
        slide.slide_show_transition.type = slides.slideshow.TransitionType.NONE

        presentation.save("slide_transition_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **전환 지속 시간 설정**

자동으로 진행되기 전에 슬라이드가 표시되는 시간을 지정합니다.

```py
def set_transition_duration():
    with slides.Presentation("slide_transition.pptx") as presentation:
        slide = presentation.slides[0]

        slide.slide_show_transition.advance_on_click = True
        slide.slide_show_transition.advance_after_time = 2000  # 밀리초 단위.

        presentation.save("transition_duration.pptx", slides.export.SaveFormat.PPTX)
```