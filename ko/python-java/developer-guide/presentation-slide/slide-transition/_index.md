---
title: Python via Java를 사용해 프레젠테이션의 슬라이드 전환 관리
linktitle: 슬라이드 전환
type: docs
weight: 80
url: /ko/python-java/slide-transition/
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
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java를 사용하여 슬라이드 전환을 적용하고, 자동 슬라이드 진행을 구성하며, Morph 및 기타 전환 효과를 사용자 지정합니다."
---
## **개요**

슬라이드 전환은 슬라이드 쇼 중 슬라이드가 표시되는 방식을 제어합니다. Aspose.Slides for Python via Java를 사용하면 각 슬라이드에 전환 효과를 선택하고, 마우스 클릭 또는 타이머에 의한 진행을 구성하며, 효과에 따라 추가 옵션을 조정할 수 있습니다. 이 문서에서는 Python 예제를 사용해 전환을 적용하고, 정확한 전환 지속 시간을 설정하고, 슬라이드 타이밍을 관리하며, 두 슬라이드 사이에 Morph 전환을 만드는 방법을 보여줍니다. 예제에서는 이러한 설정을 PPTX 파일에 저장하는 방법도 다룹니다.

## **슬라이드 전환 추가**

전환을 적용하려면 [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) 클래스로 프레젠테이션을 로드하고 [getSlideShowTransition](https://reference.aspose.com/slides/python-java/aspose.slides/baseslide/#getSlideShowTransition) 를 통해 슬라이드의 전환 설정에 접근합니다. [TransitionType](https://reference.aspose.com/slides/python-java/aspose.slides/transitiontype/) 열거형의 값을 사용해 [setType](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setType) 을 호출한 뒤 프레젠테이션을 저장합니다.

다음 예제는 첫 번째 슬라이드에 Circle 전환을, 두 번째 슬라이드에 Comb 전환을 적용합니다. 최소 두 개의 슬라이드가 포함된 `input.pptx` 파일을 사용하십시오.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TransitionType

presentation = Presentation("input.pptx")
try:
    if presentation.getSlides().size() >= 2:
        presentation.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Circle)
        presentation.getSlides().get_Item(1).getSlideShowTransition().setType(TransitionType.Comb)

        presentation.save("slide-transitions.pptx", SaveFormat.Pptx)
    else:
        print("The input presentation must contain at least two slides.")
finally:
    presentation.dispose()
```

## **Wheel 전환**

[TransitionType](https://reference.aspose.com/slides/python-java/aspose.slides/transitiontype/) 에서 Wheel을 선택하려면 [setType](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setType) 을 사용합니다. 그런 다음 [WheelTransition](https://reference.aspose.com/slides/python-java/aspose.slides/wheeltransition/) 설정에 접근하려면 [getValue](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#getValue) 을 호출합니다. [setSpokes](https://reference.aspose.com/slides/python-java/aspose.slides/wheeltransition/#setSpokes) 메서드는 목적지 슬라이드를 나타내는 방사형 부문 수를 제어합니다.

예제는 두 개의 동일한 슬라이드 쌍을 만듭니다. 각 쌍은 검은색 슬라이드로 시작하고 전체 슬라이드에 금색 사각형이 표시되는 슬라이드로 끝납니다. 두 목적지 슬라이드 모두 [setSpeed](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setSpeed) 로 설정한 느린 속도와 [setDuration](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setDuration) 로 지정한 8,000밀리초의 명시적 지속 시간을 사용합니다. 부채꼴 수만 변경됩니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Presentation, SaveFormat, ShapeType, TransitionSpeed, TransitionType

Color = jpype.JClass("java.awt.Color")
presentation = Presentation()
try:
    width = jpype.JFloat(presentation.getSlideSize().getSize().getWidth())
    height = jpype.JFloat(presentation.getSlideSize().getSize().getHeight())

    slides = presentation.getSlides()
    black_slide = slides.get_Item(0)
    black_slide.getShapes().clear()
    background = black_slide.getBackground()
    background.setType(BackgroundType.OwnBackground)
    background.getFillFormat().setFillType(FillType.Solid)
    background.getFillFormat().getSolidFillColor().setColor(Color.BLACK)

    destination_slide = slides.addClone(black_slide)
    rectangle = destination_slide.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, width, height)
    rectangle.getFillFormat().setFillType(FillType.Solid)
    rectangle.getFillFormat().getSolidFillColor().setColor(Color(255, 215, 0))
    rectangle.getTextFrame().setText("Wheel transition")

    slides.addClone(black_slide)
    slides.addClone(destination_slide)
    for slide_index, spokes in ((1, 1), (3, 8)):
        transition = slides.get_Item(slide_index).getSlideShowTransition()
        transition.setType(TransitionType.Wheel)
        wheel_transition = transition.getValue()
        wheel_transition.setSpokes(spokes)
        transition.setSpeed(TransitionSpeed.Slow)
        transition.setDuration(8000)

    presentation.save("wheel-transitions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

`wheel-transitions.pptx` 파일을 PowerPoint에서 열고 슬라이드 쇼를 시작합니다. 슬라이드 1에서 슬라이드 2로 진행하면 시계 방향으로 한 번에 금색 사각형이 나타납니다. 그 다음 슬라이드 3에서 슬라이드 4로 진행하면 8개의 방사형 부문이 동시에 금색 사각형을 드러냅니다.

## **고급 슬라이드 전환 추가**

슬라이드가 화면에 표시되는 시간과 마우스 클릭으로 슬라이드 쇼를 진행할지 여부를 구성할 수 있습니다. 다음 메서드가 해당 동작을 제어합니다.

- [setAdvanceOnClick](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setAdvanceOnClick) 은 사용자가 마우스를 클릭해 진행하도록 허용합니다.
- [setAdvanceAfter](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setAdvanceAfter) 은 자동 진행을 활성화합니다.
- [setAdvanceAfterTime](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setAdvanceAfterTime) 은 자동 진행 전 지연 시간을 밀리초 단위로 지정합니다.

클릭과 타이머 진행을 모두 활성화하면 사용자가 클릭하거나 타이머가 끝날 때 다음 슬라이드로 이동합니다. 타이머만 사용하려면 [setAdvanceOnClick](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setAdvanceOnClick) 에 `False` 를 전달하십시오. 지연 시간은 슬라이드 쇼가 언제 진행되는지를 제어하며, 시각적 전환 효과의 지속 시간을 설정하지는 않습니다.

이 예제는 첫 세 슬라이드에 서로 다른 효과를 할당하고 각각 3초, 5초, 7초 후에 자동 진행을 활성화합니다. 마우스 클릭으로도 이 슬라이드들을 진행할 수 있습니다. 최소 세 개의 슬라이드가 포함된 `input.pptx` 파일을 사용하십시오.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TransitionType

presentation = Presentation("input.pptx")
try:
    if presentation.getSlides().size() >= 3:
        first_transition = presentation.getSlides().get_Item(0).getSlideShowTransition()
        first_transition.setType(TransitionType.Circle)
        first_transition.setAdvanceOnClick(True)
        first_transition.setAdvanceAfter(True)
        first_transition.setAdvanceAfterTime(3000)

        second_transition = presentation.getSlides().get_Item(1).getSlideShowTransition()
        second_transition.setType(TransitionType.Comb)
        second_transition.setAdvanceOnClick(True)
        second_transition.setAdvanceAfter(True)
        second_transition.setAdvanceAfterTime(5000)

        third_transition = presentation.getSlides().get_Item(2).getSlideShowTransition()
        third_transition.setType(TransitionType.Zoom)
        third_transition.setAdvanceOnClick(True)
        third_transition.setAdvanceAfter(True)
        third_transition.setAdvanceAfterTime(7000)

        presentation.save("advanced-transitions.pptx", SaveFormat.Pptx)
    else:
        print("The input presentation must contain at least three slides.")
finally:
    presentation.dispose()
```

타이머 진행이 활성화되었는지 확인하려면 [getAdvanceAfter](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#getAdvanceAfter) 를 호출하십시오. 저장된 지연 시간만으로는 타이머가 활성 상태인지 판단할 수 없습니다.

다음 예제는 앞서 저장한 파일을 열어 각 슬라이드의 타이머 상태를 보고하고, 2초를 초과하는 지연이 있는 슬라이드의 자동 진행을 비활성화합니다. 해당 슬라이드에 대해 마우스 클릭 진행을 활성화하고 업데이트된 설정을 저장합니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("advanced-transitions.pptx")
try:
    for slide in presentation.getSlides():
        transition = slide.getSlideShowTransition()

        if transition.getAdvanceAfter():
            print(f"Slide {slide.getSlideNumber()}: advance after {transition.getAdvanceAfterTime()} ms.")

            if transition.getAdvanceAfterTime() > 2000:
                transition.setAdvanceAfter(False)
                transition.setAdvanceOnClick(True)

    presentation.save("adjusted-transitions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **전환 타이밍을 정확히 제어**

[setDuration](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setDuration) 을 사용해 전환 효과의 정확한 길이를 밀리초 단위로 지정합니다. 슬라이드의 [getSlideShowTransition](https://reference.aspose.com/slides/python-java/aspose.slides/baseslide/#getSlideShowTransition) 메서드를 통해 이러한 설정을 [SlideShowTransition](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/) 로 노출합니다.

| 메서드 | 목적 |
| --- | --- |
| [setDuration](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setDuration) | 전환 효과 자체의 지속 시간을 밀리초 단위로 설정합니다. |
| [setAdvanceAfterTime](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setAdvanceAfterTime) | 슬라이드가 자동으로 진행되기 전 지연 시간을 밀리초 단위로 설정합니다. 이 타이머를 활성화하려면 [setAdvanceAfter](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setAdvanceAfter) 에 `True` 를 전달하십시오. |
| [setSpeed](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setSpeed) | [TransitionSpeed](https://reference.aspose.com/slides/python-java/aspose.slides/transitionspeed/) 열거형에서 미리 정의된 속도 범주(Slow, Medium, Fast) 중 하나를 선택합니다. 정확한 지속 시간이 지정되지 않은 경우 사용됩니다. |

[setDuration](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setDuration) 은 전환 효과만 제어하며, 슬라이드가 화면에 표시되는 시간에는 영향을 주지 않습니다. 자동 진행 지연은 별도로 구성하십시오. 명시적 지속 시간이 설정되지 않은 경우 Aspose.Slides는 전환 유형과 [getSpeed](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#getSpeed) 값으로 효과 지속 시간을 결정합니다.

<!-- visual-explanation:slide-transition:start -->
[![Separate bars identify the 750-ms transition duration and 5,000-ms automatic advancement setting.](visual-slide-transition-1f705a740cf6.svg)](visual-slide-transition-1f705a740cf6.svg)

*공유된 예제는 각 슬라이드에 750 ms Fade 전환을 적용하고, 별도로 5 000 ms 자동 진행을 활성화합니다. 전환 지속 시간은 효과를 제어하고, 진행은 슬라이드를 떠나는 시점을 제어합니다. 이 막대는 실제 측정된 타임라인이 아니라 설정을 나타내는 도식입니다.*
<!-- visual-explanation:slide-transition:end -->

### **모든 슬라이드에 동일한 지속 시간 적용**

일관된 속도를 유지하려면 모든 슬라이드에 동일한 효과와 정확한 지속 시간을 적용하십시오. 이 예제는 `input.pptx` 를 로드하고 [TransitionType](https://reference.aspose.com/slides/python-java/aspose.slides/transitiontype/) 에서 Fade를 선택한 뒤 각 전환에 750 ms 지속 시간을 부여합니다. 또한 5 000 ms 후 자동 진행을 별도로 활성화하고 마우스 클릭 진행을 비활성화한 뒤 결과를 PPTX 로 저장합니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TransitionType

presentation = Presentation("input.pptx")
try:
    for slide in presentation.getSlides():
        transition = slide.getSlideShowTransition()
        transition.setType(TransitionType.Fade)
        transition.setDuration(750)

        # 효과 지속 시간과 별개로 자동 진행을 구성합니다.
        transition.setAdvanceAfter(True)
        transition.setAdvanceAfterTime(5000)
        transition.setAdvanceOnClick(False)

    presentation.save("precise-transitions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **개별 슬라이드에 서로 다른 지속 시간 설정**

슬라이드마다 다른 효과 지속 시간을 사용할 수 있습니다. 예를 들어 제목 슬라이드에는 짧은 전환을, 섹션 소개 슬라이드에는 긴 전환을 적용합니다. 이 예제는 첫 번째 슬라이드에 500 ms, 두 번째 슬라이드에 1 200 ms 를 설정합니다. 최소 두 개의 슬라이드가 포함된 `input.pptx` 파일을 사용하십시오.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TransitionType

presentation = Presentation("input.pptx")
try:
    if presentation.getSlides().size() >= 2:
        first_transition = presentation.getSlides().get_Item(0).getSlideShowTransition()
        first_transition.setType(TransitionType.Fade)
        first_transition.setDuration(500)

        second_transition = presentation.getSlides().get_Item(1).getSlideShowTransition()
        second_transition.setType(TransitionType.Push)
        second_transition.setDuration(1200)

        presentation.save("individual-transition-durations.pptx", SaveFormat.Pptx)
    else:
        print("The input presentation must contain at least two slides.")
finally:
    presentation.dispose()
```

### **애니메이션 출력과 전환 조정**

[animated GIF](/slides/ko/python-java/convert-powerpoint-to-animated-gif/), [HTML5 presentation](/slides/ko/python-java/export-to-html5/), 또는 [video](/slides/ko/python-java/convert-powerpoint-to-video/) 를 만들 때는 내보내기 전 정확한 전환 지속 시간을 설정해 의도한 템포와 맞추십시오. 예를 들어 장면 사이에 600 ms 페이드를 사용하고, 각 슬라이드의 진행 지연을 별도로 조정해 내레이션이나 콘텐츠가 표시될 시간을 확보합니다.

GIF와 비디오의 경우 출력 프레임 레이트를 효과 지속 시간에 맞추십시오: 600 ms는 30 fps에서 18프레임에 해당합니다. HTML5에서는 내보내기 설정에서 애니메이션 전환을 활성화하십시오. 선택한 내보내기 형식이 지원하는 효과와 타이밍 옵션을 확인하고, 동기화를 확인하기 위해 출력을 미리 보기하십시오.

### **기존 전환 지속 시간 읽기**

전환을 수정하기 전에 [getDuration](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#getDuration) 를 호출해 명시적 값이 저장되어 있는지 확인하십시오. `-1` 값은 명시적 지속 시간이 설정되지 않았음을 의미하고, 0 이상 값은 밀리초 단위의 저장된 지속 시간을 나타냅니다. 이 값은 계산된 재생 지속 시간이 아니라 Aspose.Slides가 전환 유형과 [getSpeed](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#getSpeed) 값을 사용해 결정하는 값입니다. 전환 유형을 설정하면 지속 시간이 초기화될 수 있으므로 원본 설정을 먼저 확인하십시오.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("input.pptx")
try:
    for slide in presentation.getSlides():
        transition = slide.getSlideShowTransition()
        duration = transition.getDuration()

        if duration >= 0:
            print(f"Slide {slide.getSlideNumber()}: stored transition duration is {duration} ms.")
        else:
            print(f"Slide {slide.getSlideNumber()}: no explicit duration; timing depends on transition type {transition.getType()} and speed {transition.getSpeed()}.")
finally:
    presentation.dispose()
```

## **Morph 전환**

Morph 전환은 연속된 슬라이드에 있는 개체 간의 변화를 애니메이션화합니다. 간단한 Morph 효과를 만들려면 슬라이드를 복제하고 복제본에서 개체를 이동하거나 크기를 조정한 뒤 두 번째 슬라이드에 Morph 전환을 적용합니다. 이렇게 하면 원본과 수정된 상태 사이를 애니메이션화할 대응 개체가 자동으로 매핑됩니다.

다음 예제는 텍스트 사각형이 있는 슬라이드를 만든 뒤 슬라이드를 복제하고 복제본에서 사각형의 위치와 크기를 변경합니다. 그런 다음 두 번째 슬라이드에 대해 [TransitionType](https://reference.aspose.com/slides/python-java/aspose.slides/transitiontype/) 열거형에서 Morph를 선택합니다. Morph를 지원하는 프레젠테이션 뷰어에서 저장된 파일을 열어 슬라이드 쇼 중 효과를 확인하십시오.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TransitionType, ShapeType

presentation = Presentation()
try:
    first_slide = presentation.getSlides().get_Item(0)
    rectangle = first_slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 100)
    rectangle.getTextFrame().setText("Morph transition")

    second_slide = presentation.getSlides().addClone(first_slide)
    moved_rectangle = second_slide.getShapes().get_Item(0)
    moved_rectangle.setX(moved_rectangle.getX() + 100)
    moved_rectangle.setY(moved_rectangle.getY() + 50)
    moved_rectangle.setWidth(moved_rectangle.getWidth() - 200)
    moved_rectangle.setHeight(moved_rectangle.getHeight() - 10)

    second_slide.getSlideShowTransition().setType(TransitionType.Morph)

    presentation.save("morph-transition.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Morph 전환 유형**

[TransitionMorphType](https://reference.aspose.com/slides/python-java/aspose.slides/transitionmorphtype/) 열거형은 Morph가 콘텐츠를 매핑하고 애니메이션화하는 방식을 제어합니다.

- [ByObject](https://reference.aspose.com/slides/python-java/aspose.slides/transitionmorphtype/#ByObject) 은 각 도형을 전체 객체로 취급합니다.
- [ByWord](https://reference.aspose.com/slides/python-java/aspose.slides/transitionmorphtype/#ByWord) 은 가능한 경우 단어 단위로 텍스트를 매핑합니다.
- [ByChar](https://reference.aspose.com/slides/python-java/aspose.slides/transitionmorphtype/#ByChar) 은 가능한 경우 문자 단위로 텍스트를 매핑합니다.

[setType](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setType) 으로 Morph를 선택한 뒤 [getValue](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#getValue) 에 접근합니다. 반환된 값은 [MorphTransition](https://reference.aspose.com/slides/python-java/aspose.slides/morphtransition/) 클래스의 인스턴스이며, 이 클래스의 [setMorphType](https://reference.aspose.com/slides/python-java/aspose.slides/morphtransition/#setMorphType) 메서드로 매핑 모드를 선택합니다.

이 예제는 이전 섹션에서 만든 프레젠테이션을 열고 두 번째 슬라이드에 단어 기반 Morph 애니메이션을 구성합니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TransitionType, TransitionMorphType, MorphTransition

presentation = Presentation("morph-transition.pptx")
try:
    if presentation.getSlides().size() >= 2:
        transition = presentation.getSlides().get_Item(1).getSlideShowTransition()
        transition.setType(TransitionType.Morph)
        transition_value = transition.getValue()

        if isinstance(transition_value, MorphTransition):
            morph_transition = transition_value
            morph_transition.setMorphType(TransitionMorphType.ByWord)
            presentation.save("morph-by-word.pptx", SaveFormat.Pptx)
        else:
            print("Morph transition options are unavailable.")
    else:
        print("The input presentation must contain at least two slides.")
finally:
    presentation.dispose()
```

## **전환 효과 설정**

일부 전환은 방향이나 검은 화면에서 시작 여부와 같은 추가 옵션을 노출합니다. 사용 가능한 옵션은 [setType](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setType) 로 선택한 전환에 따라 달라집니다. 먼저 유형을 설정한 뒤 [getValue](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#getValue) 로 반환된 적절한 클래스를 사용하십시오.

다음 예제는 `input.pptx` 의 첫 번째 슬라이드에 Cut 전환을 적용합니다. [OptionalBlackTransition](https://reference.aspose.com/slides/python-java/aspose.slides/optionalblacktransition/) 의 [setFromBlack](https://reference.aspose.com/slides/python-java/aspose.slides/optionalblacktransition/#setFromBlack) 을 호출해 전환이 검은 화면에서 시작하도록 합니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TransitionType, OptionalBlackTransition

presentation = Presentation("input.pptx")
try:
    transition = presentation.getSlides().get_Item(0).getSlideShowTransition()
    transition.setType(TransitionType.Cut)
    transition_value = transition.getValue()

    if isinstance(transition_value, OptionalBlackTransition):
        cut_transition = transition_value
        cut_transition.setFromBlack(True)
        presentation.save("cut-from-black.pptx", SaveFormat.Pptx)
    else:
        print("Cut transition options are unavailable.")
finally:
    presentation.dispose()
```

## **FAQ**

**슬라이드 전환의 재생 속도를 제어할 수 있나요?**

예. 밀리초 단위로 정확한 효과 지속 시간이 필요하면 [setDuration](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setDuration) 을 사용하십시오. 미리 정의된 [TransitionSpeed](https://reference.aspose.com/slides/python-java/aspose.slides/transitionspeed/) 범주(느림, 보통, 빠름)만으로 충분하고 명시적 지속 시간을 지정하지 않을 경우에는 [setSpeed](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setSpeed) 를 사용하십시오. 이러한 설정은 자동 진행 지연과는 별개로 전환 효과만을 제어합니다.

**전환에 오디오를 첨부하고 반복 재생할 수 있나요?**

예. [setSound](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setSound) 로 내장 오디오를 지정하고, [TransitionSoundMode](https://reference.aspose.com/slides/python-java/aspose.slides/transitionsoundmode/) 열거형에서 `StartSound` 를 [setSoundMode](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setSoundMode) 에 전달한 뒤, `True` 로 [setSoundLoop](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setSoundLoop) 을 활성화하십시오. 오디오는 다음 사운드 이벤트가 나타날 때까지 반복됩니다.

**모든 슬라이드에 동일한 전환을 적용하는 가장 빠른 방법은 무엇인가요?**

프레젠테이션의 [getSlides](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getSlides) 컬렉션을 반복하면서 각 슬라이드의 전환에 대해 같은 값을 가진 [setType](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setType) 을 호출하십시오. 동일한 루프 내에서 타이밍 및 효과 옵션도 설정하면 슬라이드 전체에 일관된 동작을 유지할 수 있습니다.

**슬라이드에 현재 설정된 전환을 확인하려면 어떻게 해야 하나요?**

슬라이드의 [getSlideShowTransition](https://reference.aspose.com/slides/python-java/aspose.slides/baseslide/#getSlideShowTransition) 결과에 대해 [getType](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#getType) 을 호출하십시오. 반환값은 [TransitionType](https://reference.aspose.com/slides/python-java/aspose.slides/transitiontype/) 열거형의 값이며, `None_` 은 전환 효과가 적용되지 않았음을 의미합니다.