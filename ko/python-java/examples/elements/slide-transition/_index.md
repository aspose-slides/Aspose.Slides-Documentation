---
title: 슬라이드 전환
type: docs
weight: 110
url: /ko/python-java/examples/elements/slide-transition/
keywords:
- 코드 예제
- 슬라이드 전환
- PowerPoint
- OpenDocument
- 프레젠테이션
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java 코드를 사용하여 PPT, PPTX 및 ODP 프레젠테이션에 대한 슬라이드 전환 적용 및 제거와 자동 슬라이드 진행 타이밍을 설정합니다."
---
이 문서에서는 **Aspose.Slides for Python via Java**를 사용한 슬라이드 전환 효과와 타이밍 적용 방법을 보여줍니다.

패키지는 [Installation](/slides/ko/python-java/installation/)에 설명된 대로 설치합니다. 각 예제는 JVM을 시작하기 전에 `asposeslides`를 가져오고, JVM이 실행된 후에 API를 가져옵니다.

## **슬라이드 전환 추가**

첫 번째 슬라이드에 페이드 전환 효과를 적용합니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, TransitionType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # 페이드 전환을 적용합니다.
    slide.getSlideShowTransition().setType(TransitionType.Fade)
finally:
    presentation.dispose()
```

## **슬라이드 전환 액세스**

슬라이드에 현재 할당된 전환 유형을 읽습니다.

```python
import jpide
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, TransitionType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    slide.getSlideShowTransition().setType(TransitionType.Push)

    # 전환 유형에 접근합니다.
    transition_type = slide.getSlideShowTransition().getType()
finally:
    presentation.dispose()
```

## **슬라이드 전환 제거**

모든 전환 효과를 지웁니다. JPype는 Python에서 `None`이 예약어이기 때문에 Java 상수 `None`을 `None_`로 노출합니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, TransitionType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    slide.getSlideShowTransition().setType(TransitionType.Fade)

    # 전환 효과를 제거합니다.
    slide.getSlideShowTransition().setType(TransitionType.None_)
finally:
    presentation.dispose()
```

## **전환 지속 시간 설정**

슬라이드가 자동으로 다음으로 넘어가기 전에 표시되는 시간을 지정합니다. 이 예제는 2초 후에 이동하며 마우스 클릭으로도 이동할 수 있도록 합니다. 이 타이밍은 전환 효과의 속도가 아니라 슬라이드 전환을 제어합니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    slide.getSlideShowTransition().setAdvanceOnClick(True)
    slide.getSlideShowTransition().setAdvanceAfter(True)
    slide.getSlideShowTransition().setAdvanceAfterTime(2000)  # 밀리초 단위.
finally:
    presentation.dispose()
```