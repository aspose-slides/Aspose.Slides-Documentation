---
title: Python을 사용하여 프레젠테이션의 슬라이드 전환 관리
linktitle: 슬라이드 전환
type: docs
weight: 90
url: /ko/python-net/slide-transition/
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
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET를 사용하여 슬라이드 전환을 적용하고 자동 슬라이드 진행을 구성하며 Morph 및 기타 전환 효과를 사용자 정의합니다."
---
## **개요**

슬라이드 전환은 슬라이드 쇼 중 슬라이드가 표시되는 방식을 제어합니다. Aspose.Slides for Python via .NET을 사용하면 각 슬라이드에 전환 효과를 선택하고, 마우스 클릭 또는 타이머에 의한 진행을 구성하며, 효과별 옵션을 조정할 수 있습니다. 이 문서에서는 Python 예제를 통해 전환을 적용하고, 정확한 전환 지속 시간을 설정하며, 슬라이드 타이밍을 관리하고, 두 슬라이드 사이에 Morph 전환을 만드는 방법을 보여줍니다. 예제에서는 설정을 PPTX 파일에 저장하는 방법도 다룹니다.

## **슬라이드 전환 추가**

전환을 적용하려면 [Presentation](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/) 클래스로 프레젠테이션을 로드하고 슬라이드의 [slide_show_transition](https://reference.aspose.com/slides/ko/python-net/aspose.slides/slide/slide_show_transition/) 속성에 접근합니다. 그 [type](https://reference.aspose.com/slides/ko/python-net/aspose.slides.slideshow/slideshowtransition/type/)을 [TransitionType](https://reference.aspose.com/slides/ko/python-net/aspose.slides.slideshow/transitiontype/) 열거형의 값으로 설정한 뒤 프레젠테이션을 저장합니다.

다음 예제는 첫 번째 슬라이드에 Circle 전환을, 두 번째 슬라이드에 Comb 전환을 적용합니다. 최소 두 개 슬라이드가 포함된 `input.pptx` 파일을 사용하십시오.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    if len(presentation.slides) >= 2:
        presentation.slides[0].slide_show_transition.type = slides.slideshow.TransitionType.CIRCLE
        presentation.slides[1].slide_show_transition.type = slides.slideshow.TransitionType.COMB

        presentation.save("slide-transitions.pptx", slides.export.SaveFormat.PPTX)
    else:
        print("The input presentation must contain at least two slides.")
```

## **고급 슬라이드 전환 추가**

슬라이드가 화면에 머무는 시간과 마우스 클릭으로 슬라이드 쇼가 진행되는지를 구성할 수 있습니다. 다음 속성이 이 동작을 제어합니다.

- [advance_on_click](https://reference.aspose.com/slides/ko/python-net/aspose.slides.slideshow/slideshowtransition/advance_on_click/) 은 사용자가 마우스를 클릭하여 진행할 수 있도록 합니다.
- [advance_after](https://reference.aspose.com/slides/ko/python-net/aspose.slides.slideshow/slideshowtransition/advance_after/) 은 자동 진행을 활성화합니다.
- [advance_after_time](https://reference.aspose.com/slides/ko/python-net/aspose.slides.slideshow/slideshowtransition/advance_after_time/) 은 자동 진행 전 지연 시간을 밀리초 단위로 지정합니다.

클릭과 타이머 진행을 모두 활성화하면 사용자는 클릭으로 진행하거나 타이머가 끝날 때까지 기다릴 수 있습니다. 타이머만 사용하려면 [advance_on_click](https://reference.aspose.com/slides/ko/python-net/aspose.slides.slideshow/slideshowtransition/advance_on_click/) 을 `False` 로 설정하십시오. 지연 시간은 슬라이드 쇼가 진행되는 시점을 제어하며, 시각적 전환 효과의 지속 시간을 설정하지는 않습니다.

다음 예제는 첫 세 슬라이드에 서로 다른 효과를 할당하고 각각 3초, 5초, 7초 후에 자동 진행되도록 설정합니다. 마우스 클릭으로도 슬라이드를 진행할 수 있습니다. 최소 세 개 슬라이드가 포함된 `input.pptx` 파일을 사용하십시오.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    if len(presentation.slides) >= 3:
        first_transition = presentation.slides[0].slide_show_transition
        first_transition.type = slides.slideshow.TransitionType.CIRCLE
        first_transition.advance_on_click = True
        first_transition.advance_after = True
        first_transition.advance_after_time = 3000

        second_transition = presentation.slides[1].slide_show_transition
        second_transition.type = slides.slideshow.TransitionType.COMB
        second_transition.advance_on_click = True
        second_transition.advance_after = True
        second_transition.advance_after_time = 5000

        third_transition = presentation.slides[2].slide_show_transition
        third_transition.type = slides.slideshow.TransitionType.ZOOM
        third_transition.advance_on_click = True
        third_transition.advance_after = True
        third_transition.advance_after_time = 7000

        presentation.save("advanced-transitions.pptx", slides.export.SaveFormat.PPTX)
    else:
        print("The input presentation must contain at least three slides.")
```

타이머 진행이 활성화되었는지 확인하려면 [advance_after](https://reference.aspose.com/slides/ko/python-net/aspose.slides.slideshow/slideshowtransition/advance_after/) 를 읽으십시오. 저장된 지연 시간만 있다고 해서 타이머가 활성화된 것은 아닙니다.

다음 예제는 앞서 저장한 파일을 열어 각 슬라이드에 적용된 타이머를 보고, 2초 초과 지연을 가진 슬라이드의 자동 진행을 비활성화하고 해당 슬라이드에 마우스 클릭을 활성화한 뒤 업데이트된 설정을 저장합니다.

```python
import aspose.slides as slides

with slides.Presentation("advanced-transitions.pptx") as presentation:
    for slide in presentation.slides:
        transition = slide.slide_show_transition

        if transition.advance_after:
            print(f"Slide {slide.slide_number}: advance after {transition.advance_after_time} ms.")

            if transition.advance_after_time > 2000:
                transition.advance_after = False
                transition.advance_on_click = True

    presentation.save("adjusted-transitions.pptx", slides.export.SaveFormat.PPTX)
```

## **전환 타이밍을 정확하게 제어**

전환 효과의 정확한 길이를 밀리초 단위로 지정하려면 [duration](https://reference.aspose.com/slides/ko/python-net/aspose.slides.slideshow/slideshowtransition/duration/) 을 사용합니다. 슬라이드의 [slide_show_transition](https://reference.aspose.com/slides/ko/python-net/aspose.slides/slide/slide_show_transition/) 속성은 [SlideShowTransition](https://reference.aspose.com/slides/ko/python-net/aspose.slides.slideshow/slideshowtransition/) 을 통해 이러한 설정을 노출합니다.

| 속성 | 목적 |
| --- | --- |
| [duration](https://reference.aspose.com/slides/ko/python-net/aspose.slides.slideshow/slideshowtransition/duration/) | 전환 효과 자체의 지속 시간을 밀리초 단위로 설정합니다. |
| [advance_after_time](https://reference.aspose.com/slides/ko/python-net/aspose.slides.slideshow/slideshowtransition/advance_after_time/) | 슬라이드가 자동으로 진행되기 전의 지연 시간을 밀리초 단위로 설정합니다. 이 타이머를 활성화하려면 [advance_after](https://reference.aspose.com/slides/ko/python-net/aspose.slides.slideshow/slideshowtransition/advance_after/) 를 사용하십시오. |
| [speed](https://reference.aspose.com/slides/ko/python-net/aspose.slides.slideshow/slideshowtransition/speed/) | [TransitionSpeed](https://reference.aspose.com/slides/ko/python-net/aspose.slides.slideshow/transitionspeed/) 열거형의 미리 정의된 속도 범주(SLOW, MEDIUM, FAST) 중 하나를 선택합니다. 정확한 지속 시간이 지정되지 않은 경우에 사용됩니다. |

[duration](https://reference.aspose.com/slides/ko/python-net/aspose.slides.slideshow/slideshowtransition/duration/) 은 전환 효과만 제어하며, 슬라이드가 화면에 머무는 시간은 결정하지 않습니다. 자동 진행 지연은 별도로 구성하십시오. 명시적인 지속 시간이 설정되지 않으면 Aspose.Slides는 전환 유형과 [speed](https://reference.aspose.com/slides/ko/python-net/aspose.slides.slideshow/slideshowtransition/speed/) 값을 기반으로 효과 지속 시간을 결정합니다.

### **모든 슬라이드에 동일한 지속 시간 적용**

일관된 진행 속도를 위해 모든 슬라이드에 동일한 효과와 정확한 지속 시간을 적용합니다. 이 예제는 `input.pptx` 를 로드하고 [TransitionType](https://reference.aspose.com/slides/ko/python-net/aspose.slides.slideshow/transitiontype/) 중 Fade 를 선택한 뒤 각 전환에 750밀리초의 지속 시간을 부여합니다. 또한 자동 진행을 5,000밀리초 후에 활성화하고 마우스 클릭 진행을 비활성화한 뒤 결과를 PPTX 로 저장합니다.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    for slide in presentation.slides:
        transition = slide.slide_show_transition
        transition.type = slides.slideshow.TransitionType.FADE
        transition.duration = 750

        # 효과 지속 시간과는 별개로 자동 진행을 구성합니다.
        transition.advance_after = True
        transition.advance_after_time = 5000
        transition.advance_on_click = False

    presentation.save("precise-transitions.pptx", slides.export.SaveFormat.PPTX)
```

### **슬라이드별로 다른 지속 시간 설정**

슬라이드마다 다른 효과 지속 시간을 사용할 수 있습니다. 예를 들어 제목 슬라이드에는 짧은 전환을, 섹션 소개 슬라이드에는 더 긴 전환을 적용합니다. 이 예제는 첫 번째 슬라이드에 500밀리초, 두 번째 슬라이드에 1,200밀리초를 설정합니다. 최소 두 개 슬라이드가 포함된 `input.pptx` 파일을 사용하십시오.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    if len(presentation.slides) >= 2:
        first_transition = presentation.slides[0].slide_show_transition
        first_transition.type = slides.slideshow.TransitionType.FADE
        first_transition.duration = 500

        second_transition = presentation.slides[1].slide_show_transition
        second_transition.type = slides.slideshow.TransitionType.PUSH
        second_transition.duration = 1200

        presentation.save("individual-transition-durations.pptx", slides.export.SaveFormat.PPTX)
    else:
        print("The input presentation must contain at least two slides.")
```

### **애니메이션 출력과 전환 동기화**

[animated GIF](/slides/ko/python-net/convert-powerpoint-to-animated-gif/), [HTML5 presentation](/slides/ko/python-net/export-to-html5/), 또는 [video](/slides/ko/python-net/convert-powerpoint-to-video/) 를 준비할 때 내보내기 전에 정확한 전환 지속 시간을 설정하여 의도한 템포에 맞추십시오. 예를 들어 장면 사이에 600밀리초 페이드 전환을 사용하고, 각 슬라이드의 진행 지연을 별도로 조정하여 내레이션이나 콘텐츠가 재생될 시간을 확보합니다.

GIF와 비디오에서는 프레임 레이트를 효과 지속 시간과 맞추어야 합니다: 600밀리초는 초당 30프레임 기준 18프레임에 해당합니다. HTML5에서는 내보내기 설정에서 애니메이션 전환을 활성화하십시오. 선택한 내보내기 형식이 지원하는 효과 및 타이밍 옵션을 확인하고, 동기화를 확인하기 위해 미리보기를 실행하십시오.

### **기존 전환 지속 시간 읽기**

전환을 수정하기 전에 [duration](https://reference.aspose.com/slides/ko/python-net/aspose.slides.slideshow/slideshowtransition/duration/) 을 읽어 명시적인 값이 저장되어 있는지 확인하십시오. `-1` 값은 명시적인 지속 시간이 설정되지 않았음을 의미하고, 음수가 아닌 값은 밀리초 단위로 저장된 지속 시간을 나타냅니다. 이 값은 계산된 재생 지속 시간이 아니며, Aspose.Slides는 전환 유형과 [speed](https://reference.aspose.com/slides/ko/python-net/aspose.slides.slideshow/slideshowtransition/speed/) 를 사용해 해당 지속 시간을 결정합니다. 전환 유형을 설정하면 지속 시간이 초기화될 수 있으니 원래 설정을 먼저 검사하십시오.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    for slide in presentation.slides:
        transition = slide.slide_show_transition
        duration = transition.duration

        if duration >= 0:
            print(f"Slide {slide.slide_number}: stored transition duration is {duration} ms.")
        else:
            print(f"Slide {slide.slide_number}: no explicit duration; timing depends on {transition.type} and {transition.speed}.")
```

## **Morph 전환**

Morph 전환은 연속된 슬라이드에 있는 객체 간의 변화를 애니메이션화합니다. 간단한 Morph 효과를 만들려면 슬라이드를 복제하고, 복제본에서 객체를 이동하거나 크기를 조정한 뒤 두 번째 슬라이드에 Morph 전환을 적용합니다. 이렇게 하면 전환이 원본 및 수정된 상태 사이의 해당 객체들을 애니메이션화합니다.

다음 예제는 텍스트 사각형이 있는 슬라이드를 만든 뒤 해당 슬라이드를 복제하고 복제본에서 사각형의 위치와 크기를 변경합니다. 그런 다음 두 번째 슬라이드에 대해 [TransitionType](https://reference.aspose.com/slides/ko/python-net/aspose.slides.slideshow/transitiontype/) 열거형에서 Morph 를 선택합니다. Morph 를 지원하는 프레젠테이션 뷰어에서 저장된 파일을 열어 슬라이드 쇼 중 효과를 확인하십시오.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    first_slide = presentation.slides[0]
    rectangle = first_slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 400, 100)
    rectangle.text_frame.text = "Morph transition"

    second_slide = presentation.slides.add_clone(first_slide)
    moved_rectangle = second_slide.shapes[0]
    moved_rectangle.x += 100
    moved_rectangle.y += 50
    moved_rectangle.width -= 200
    moved_rectangle.height -= 10

    second_slide.slide_show_transition.type = slides.slideshow.TransitionType.MORPH

    presentation.save("morph-transition.pptx", slides.export.SaveFormat.PPTX)
```

## **Morph 전환 유형**

[TransitionMorphType](https://reference.aspose.com/slides/ko/python-net/aspose.slides.slideshow/transitionmorphtype/) 열거형은 Morph 가 콘텐츠를 일치시키고 애니메이션화하는 방식을 제어합니다.

- [BY_OBJECT](https://reference.aspose.com/slides/ko/python-net/aspose.slides.slideshow/transitionmorphtype/) 은 각 도형을 전체 객체로 취급합니다.
- [BY_WORD](https://reference.aspose.com/slides/ko/python-net/aspose.slides.slideshow/transitionmorphtype/) 은 가능한 경우 단어를 기준으로 텍스트를 애니메이션화합니다.
- [BY_CHAR](https://reference.aspose.com/slides/ko/python-net/aspose.slides.slideshow/transitionmorphtype/) 은 가능한 경우 문자 단위로 텍스트를 애니메이션화합니다.

전환 [type](https://reference.aspose.com/slides/ko/python-net/aspose.slides.slideshow/slideshowtransition/type/) 을 Morph 로 설정한 뒤 [value](https://reference.aspose.com/slides/ko/python-net/aspose.slides.slideshow/slideshowtransition/value/) 에 접근하십시오. 반환된 [MorphTransition](https://reference.aspose.com/slides/ko/python-net/aspose.slides.slideshow/morphtransition/) 객체의 [morph_type](https://reference.aspose.com/slides/ko/python-net/aspose.slides.slideshow/morphtransition/morph_type/) 속성을 사용해 일치 모드를 선택합니다.

이 예제는 앞섹션에서 만든 프레젠테이션을 열고 두 번째 슬라이드를 단어 기반 Morph 애니메이션으로 구성합니다.

```python
import aspose.slides as slides

with slides.Presentation("morph-transition.pptx") as presentation:
    if len(presentation.slides) >= 2:
        transition = presentation.slides[1].slide_show_transition
        transition.type = slides.slideshow.TransitionType.MORPH
        morph_transition = transition.value

        if isinstance(morph_transition, slides.slideshow.MorphTransition):
            morph_transition.morph_type = slides.slideshow.TransitionMorphType.BY_WORD
            presentation.save("morph-by-word.pptx", slides.export.SaveFormat.PPTX)
        else:
            print("Morph transition options are unavailable.")
    else:
        print("The input presentation must contain at least two slides.")
```

## **전환 효과 설정**

일부 전환은 방향이나 검은 화면에서 시작하는지 여부와 같은 추가 옵션을 노출합니다. 사용 가능한 옵션은 선택한 전환 [type](https://reference.aspose.com/slides/ko/python-net/aspose.slides.slideshow/slideshowtransition/type/) 에 따라 달라집니다. 먼저 유형을 설정한 다음 [value](https://reference.aspose.com/slides/ko/python-net/aspose.slides.slideshow/slideshowtransition/value/) 에서 해당 전환 객체를 사용하십시오.

다음 예제는 `input.pptx` 의 첫 번째 슬라이드에 Cut 전환을 적용하고, [OptionalBlackTransition](https://reference.aspose.com/slides/ko/python-net/aspose.slides.slideshow/optionalblacktransition/) 의 [from_black](https://reference.aspose.com/slides/ko/python-net/aspose.slides.slideshow/optionalblacktransition/from_black/) 을 설정해 전환이 검은 화면에서 시작하도록 합니다.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    transition = presentation.slides[0].slide_show_transition
    transition.type = slides.slideshow.TransitionType.CUT
    cut_transition = transition.value

    if isinstance(cut_transition, slides.slideshow.OptionalBlackTransition):
        cut_transition.from_black = True
        presentation.save("cut-from-black.pptx", slides.export.SaveFormat.PPTX)
    else:
        print("Cut transition options are unavailable.")
```

## **FAQ**

**슬라이드 전환의 재생 속도를 제어할 수 있나요?**

네. 밀리초 단위의 정확한 효과 지속 시간이 필요할 때는 [duration](https://reference.aspose.com/slides/ko/python-net/aspose.slides.slideshow/slideshowtransition/duration/) 을 사용하십시오. 미리 정의된 [TransitionSpeed](https://reference.aspose.com/slides/ko/python-net/aspose.slides.slideshow/transitionspeed/) 카테고리(SLOW, MEDIUM, FAST)만으로 충분하고 명시적인 지속 시간을 설정하지 않을 경우에는 [speed](https://reference.aspose.com/slides/ko/python-net/aspose.slides.slideshow/slideshowtransition/speed/) 을 사용하십시오. 이러한 설정은 자동 진행 지연과는 독립적으로 전환 효과를 제어합니다.

**전환에 오디오를 추가하고 반복 재생하게 할 수 있나요?**

네. [sound](https://reference.aspose.com/slides/ko/python-net/aspose.slides.slideshow/slideshowtransition/sound/) 에 임베디드 오디오를 지정하고, [sound_mode](https://reference.aspose.com/slides/ko/python-net/aspose.slides.slideshow/slideshowtransition/sound_mode/) 을 [TransitionSoundMode](https://reference.aspose.com/slides/ko/python-net/aspose.slides.slideshow/transitionsoundmode/) 열거형의 START_SOUND 로 설정한 뒤, [sound_loop](https://reference.aspose.com/slides/ko/python-net/aspose.slides.slideshow/slideshowtransition/sound_loop/) 을 활성화하십시오. 오디오가 다음 사운드 이벤트가 발생할 때까지 반복 재생됩니다.

**모든 슬라이드에 동일한 전환을 적용하는 가장 빠른 방법은 무엇인가요?**

프레젠테이션의 [slides](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/slides/ko/) 컬렉션을 순회하면서 각 슬라이드의 전환 [type](https://reference.aspose.com/slides/ko/python-net/aspose.slides.slideshow/slideshowtransition/type/) 을 동일한 값으로 설정하십시오. 같은 루프 안에서 타이밍 및 효과 옵션을 모두 설정하면 슬라이드 간 동작이 일관됩니다.

**현재 슬라이드에 설정된 전환을 확인하려면 어떻게 해야 하나요?**

슬라이드의 [slide_show_transition](https://reference.aspose.com/slides/ko/python-net/aspose.slides/slide/slide_show_transition/) 에서 [type](https://reference.aspose.com/slides/ko/python-net/aspose.slides.slideshow/slideshowtransition/type/) 속성을 읽으십시오. 반환값은 [TransitionType](https://reference.aspose.com/slides/ko/python-net/aspose.slides.slideshow/transitiontype/) 열거형의 값이며, NONE 은 전환 효과가 적용되지 않았음을 의미합니다.